using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Common.CommandTrees;
using System.Data.Common.Utils;
using System.Data.Metadata.Edm;
using System.Globalization;
using System.Text;

namespace Oracle.DataAccess.Client.SqlGen;

internal sealed class SqlGenerator : DbExpressionVisitor<ISqlFragment>
{
	private delegate ISqlFragment FunctionHandler(SqlGenerator sqlgen, DbFunctionExpression functionExpr);

	private const byte defaultDecimalPrecision = 38;

	private Stack<SqlSelectStatement> selectStatementStack;

	private Stack<bool> isParentAJoinStack;

	private Dictionary<string, int> allExtentNames;

	private Dictionary<string, int> allColumnNames;

	private readonly SymbolTable symbolTable = new SymbolTable();

	private bool isVarRefSingle;

	private static readonly Dictionary<string, FunctionHandler> _canonicalFunctionHandlers = InitializeCanonicalFunctionHandlers();

	private static readonly char[] hexDigits = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	private EFOracleVersion _sqlVersion;

	private EFOracleProviderManifest _providerManifest;

	private SqlSelectStatement CurrentSelectStatement => selectStatementStack.Peek();

	private bool IsParentAJoin
	{
		get
		{
			if (isParentAJoinStack.Count != 0)
			{
				return isParentAJoinStack.Peek();
			}
			return false;
		}
	}

	internal Dictionary<string, int> AllExtentNames => allExtentNames;

	internal Dictionary<string, int> AllColumnNames => allColumnNames;

	internal bool IsPre10g => _sqlVersion < EFOracleVersion.Oracle10gR1;

	private static Dictionary<string, FunctionHandler> InitializeCanonicalFunctionHandlers()
	{
		Dictionary<string, FunctionHandler> dictionary = new Dictionary<string, FunctionHandler>(53, StringComparer.Ordinal);
		dictionary.Add("Left", HandleCanonicalFunctionLeft);
		dictionary.Add("Right", HandleCanonicalFunctionRight);
		dictionary.Add("IndexOf", HandleCanonicalFunctionIndexOf2);
		dictionary.Add("Substring", HandleCanonicalFunctionSubstring);
		dictionary.Add("Length", HandleCanonicalFunctionLength);
		dictionary.Add("NewGuid", HandleCanonicalFunctionNewGuid);
		dictionary.Add("Round", HandleCanonicalFunctionRound);
		dictionary.Add("ToLower", HandleCanonicalFunctionToLower);
		dictionary.Add("ToUpper", HandleCanonicalFunctionToUpper);
		dictionary.Add("Ceiling", HandleCanonicalFunctionCeiling);
		dictionary.Add("Trim", HandleCanonicalFunctionTrim);
		dictionary.Add("Year", HandleCanonicalFunctionDatepart);
		dictionary.Add("Month", HandleCanonicalFunctionDatepart);
		dictionary.Add("Day", HandleCanonicalFunctionDatepart);
		dictionary.Add("Hour", HandleCanonicalFunctionDatepart);
		dictionary.Add("Minute", HandleCanonicalFunctionDatepart);
		dictionary.Add("Second", HandleCanonicalFunctionDatepart);
		dictionary.Add("Millisecond", HandleCanonicalFunctionDatepart);
		dictionary.Add("CurrentDateTime", HandleCanonicalFunctionCurrentDateTime);
		dictionary.Add("CurrentUtcDateTime", HandleCanonicalFunctionCurrentDateTime);
		dictionary.Add("CurrentDateTimeOffset", HandleCanonicalFunctionCurrentDateTime);
		dictionary.Add("GetTotalOffsetMinutes", HandleCanonicalFunctionGetTotalOffsetMinutes);
		dictionary.Add("Concat", HandleConcatFunction);
		dictionary.Add("BitwiseAnd", HandleCanonicalFunctionBitwise);
		dictionary.Add("BitwiseNot", HandleCanonicalFunctionBitwise);
		dictionary.Add("BitwiseOr", HandleCanonicalFunctionBitwise);
		dictionary.Add("BitwiseXor", HandleCanonicalFunctionBitwise);
		dictionary.Add("Truncate", HandleCanonicalFunctionTruncate);
		dictionary.Add("TruncateTime", HandleCanonicalFunctionTruncate);
		dictionary.Add("DayOfYear", HandleCanonicalFunctionDatepart);
		dictionary.Add("AddNanoseconds", HandleCanonicalFunctionDatepartAdd);
		dictionary.Add("AddMicroseconds", HandleCanonicalFunctionDatepartAdd);
		dictionary.Add("AddMilliseconds", HandleCanonicalFunctionDatepartAdd);
		dictionary.Add("AddSeconds", HandleCanonicalFunctionDatepartAdd);
		dictionary.Add("AddMinutes", HandleCanonicalFunctionDatepartAdd);
		dictionary.Add("AddHours", HandleCanonicalFunctionDatepartAdd);
		dictionary.Add("AddDays", HandleCanonicalFunctionDatepartAdd);
		dictionary.Add("AddMonths", HandleCanonicalFunctionDatepartAdd);
		dictionary.Add("AddYears", HandleCanonicalFunctionDatepartAdd);
		dictionary.Add("CreateDateTime", HandleCanonicalFunctionCurrentDateTime);
		dictionary.Add("CreateDateTimeOffset", HandleCanonicalFunctionCurrentDateTime);
		dictionary.Add("DiffNanoseconds", HandleCanonicalFunctionDatepartDiff);
		dictionary.Add("DiffMilliseconds", HandleCanonicalFunctionDatepartDiff);
		dictionary.Add("DiffMicroseconds", HandleCanonicalFunctionDatepartDiff);
		dictionary.Add("DiffSeconds", HandleCanonicalFunctionDatepartDiff);
		dictionary.Add("DiffMinutes", HandleCanonicalFunctionDatepartDiff);
		dictionary.Add("DiffHours", HandleCanonicalFunctionDatepartDiff);
		dictionary.Add("DiffDays", HandleCanonicalFunctionDatepartDiff);
		dictionary.Add("DiffMonths", HandleCanonicalFunctionDatepartDiff);
		dictionary.Add("DiffYears", HandleCanonicalFunctionDatepartDiff);
		dictionary.Add("Contains", HandleCanonicalFunctionIndexOf2);
		dictionary.Add("EndsWith", HandleCanonicalFunctionIndexOf2);
		dictionary.Add("StartsWith", HandleCanonicalFunctionIndexOf2);
		return dictionary;
	}

	private SqlGenerator(EFOracleProviderManifest providerManifest, EFOracleVersion sqlVersion)
	{
		_providerManifest = providerManifest;
		_sqlVersion = sqlVersion;
	}

	internal static string GenerateSql(DbCommandTree tree, EFOracleProviderManifest providerManifest, EFOracleVersion sqlVersion, out List<OracleParameter> parameters, out CommandType commandType)
	{
		SqlGenerator sqlGenerator = null;
		commandType = CommandType.Text;
		parameters = null;
		if (tree is DbQueryCommandTree)
		{
			sqlGenerator = new SqlGenerator(providerManifest, sqlVersion);
			return sqlGenerator.GenerateSql((DbQueryCommandTree)tree);
		}
		if (tree is DbInsertCommandTree)
		{
			return DmlSqlGenerator.GenerateInsertSql((DbInsertCommandTree)tree, providerManifest, sqlVersion, out parameters);
		}
		if (tree is DbDeleteCommandTree)
		{
			return DmlSqlGenerator.GenerateDeleteSql((DbDeleteCommandTree)tree, providerManifest, sqlVersion, out parameters);
		}
		if (tree is DbUpdateCommandTree)
		{
			return DmlSqlGenerator.GenerateUpdateSql((DbUpdateCommandTree)tree, providerManifest, sqlVersion, out parameters);
		}
		if (tree is DbFunctionCommandTree)
		{
			sqlGenerator = new SqlGenerator(providerManifest, sqlVersion);
			return GenerateFunctionSql((DbFunctionCommandTree)tree, out commandType, out parameters);
		}
		parameters = null;
		return null;
	}

	private static string GenerateFunctionSql(DbFunctionCommandTree tree, out CommandType commandType, out List<OracleParameter> parameters)
	{
		EdmFunction edmFunction = tree.EdmFunction;
		parameters = null;
		string metadataProperty = MetadataHelpers.GetMetadataProperty<string>(edmFunction, "CommandTextAttribute");
		string metadataProperty2 = MetadataHelpers.GetMetadataProperty<string>(edmFunction, "Schema");
		string metadataProperty3 = MetadataHelpers.GetMetadataProperty<string>(edmFunction, "StoreFunctionNameAttribute");
		string metadataProperty4 = MetadataHelpers.GetMetadataProperty<string>(edmFunction, "EFOracleProviderExtensions:CursorParameterName");
		if (!string.IsNullOrEmpty(metadataProperty4))
		{
			parameters = new List<OracleParameter>();
			OracleParameter oracleParameter = new OracleParameter();
			oracleParameter.OracleDbType = OracleDbType.RefCursor;
			oracleParameter.ParameterName = metadataProperty4;
			oracleParameter.Direction = ParameterDirection.Output;
			parameters.Add(oracleParameter);
		}
		if (string.IsNullOrEmpty(metadataProperty))
		{
			commandType = CommandType.StoredProcedure;
			string name = (string.IsNullOrEmpty(metadataProperty3) ? edmFunction.Name : metadataProperty3);
			string text = QuoteIdentifier_storeFunctionName(name);
			if (!string.IsNullOrEmpty(metadataProperty2))
			{
				string text2 = QuoteIdentifier(metadataProperty2);
				return text2 + "." + text;
			}
			return text;
		}
		commandType = CommandType.Text;
		return metadataProperty;
	}

	private string GenerateSql(DbQueryCommandTree tree)
	{
		selectStatementStack = new Stack<SqlSelectStatement>();
		isParentAJoinStack = new Stack<bool>();
		allExtentNames = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		allColumnNames = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		ISqlFragment sqlStatement;
		if (MetadataHelpers.IsCollectionType(tree.Query.ResultType.EdmType))
		{
			SqlSelectStatement sqlSelectStatement = VisitExpressionEnsureSqlStatement(tree.Query);
			sqlSelectStatement.IsTopMost = true;
			sqlStatement = sqlSelectStatement;
		}
		else
		{
			SqlBuilder sqlBuilder = new SqlBuilder();
			sqlBuilder.Append("SELECT ");
			sqlBuilder.Append(tree.Query.Accept(this));
			sqlStatement = sqlBuilder;
		}
		if (isVarRefSingle)
		{
			throw new NotSupportedException();
		}
		return WriteSql(sqlStatement);
	}

	private string WriteSql(ISqlFragment sqlStatement)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		using (SqlWriter writer = new SqlWriter(stringBuilder))
		{
			sqlStatement.WriteSql(writer, this);
		}
		return stringBuilder.ToString();
	}

	public override ISqlFragment Visit(DbAndExpression e)
	{
		return VisitBinaryExpression(" AND ", DbExpressionKind.And, e.Left, e.Right);
	}

	public override ISqlFragment Visit(DbApplyExpression e)
	{
		List<DbExpressionBinding> list = new List<DbExpressionBinding>();
		list.Add(e.Input);
		list.Add(e.Apply);
		return VisitJoinExpression(list, DbExpressionKind.CrossJoin, e.ExpressionKind switch
		{
			DbExpressionKind.CrossApply => "CROSS APPLY", 
			DbExpressionKind.OuterApply => "OUTER APPLY", 
			_ => throw new InvalidOperationException(), 
		}, null);
	}

	public override ISqlFragment Visit(DbArithmeticExpression e)
	{
		SqlBuilder sqlBuilder;
		switch (e.ExpressionKind)
		{
		case DbExpressionKind.Divide:
			sqlBuilder = VisitBinaryExpression(" / ", e.ExpressionKind, e.Arguments[0], e.Arguments[1]);
			break;
		case DbExpressionKind.Minus:
			sqlBuilder = VisitBinaryExpression(" - ", e.ExpressionKind, e.Arguments[0], e.Arguments[1]);
			break;
		case DbExpressionKind.Modulo:
			sqlBuilder = new SqlBuilder();
			sqlBuilder.Append("MOD(");
			sqlBuilder.Append(e.Arguments[0].Accept(this));
			sqlBuilder.Append(",");
			sqlBuilder.Append(e.Arguments[1].Accept(this));
			sqlBuilder.Append(")");
			break;
		case DbExpressionKind.Multiply:
			sqlBuilder = VisitBinaryExpression(" * ", e.ExpressionKind, e.Arguments[0], e.Arguments[1]);
			break;
		case DbExpressionKind.Plus:
			sqlBuilder = VisitBinaryExpression(" + ", e.ExpressionKind, e.Arguments[0], e.Arguments[1]);
			break;
		case DbExpressionKind.UnaryMinus:
			sqlBuilder = new SqlBuilder();
			sqlBuilder.Append(" -(");
			sqlBuilder.Append(e.Arguments[0].Accept(this));
			sqlBuilder.Append(")");
			break;
		default:
			throw new InvalidOperationException(string.Empty);
		}
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbCaseExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("CASE");
		for (int i = 0; i < e.When.Count; i++)
		{
			sqlBuilder.Append(" WHEN (");
			sqlBuilder.Append(e.When[i].Accept(this));
			sqlBuilder.Append(") THEN ");
			sqlBuilder.Append(e.Then[i].Accept(this));
		}
		if (e.Else != null && !(e.Else is DbNullExpression))
		{
			sqlBuilder.Append(" ELSE ");
			sqlBuilder.Append(e.Else.Accept(this));
		}
		sqlBuilder.Append(" END");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbCastExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		string sqlPrimitiveType = GetSqlPrimitiveType(e.ResultType);
		switch (sqlPrimitiveType.ToLowerInvariant())
		{
		case "nclob":
			sqlBuilder.Append("TO_NCLOB(");
			sqlBuilder.Append(e.Argument.Accept(this));
			sqlBuilder.Append(")");
			break;
		case "clob":
			sqlBuilder.Append("TO_CLOB(");
			sqlBuilder.Append(e.Argument.Accept(this));
			sqlBuilder.Append(")");
			break;
		case "blob":
			sqlBuilder.Append("TO_BLOB(");
			sqlBuilder.Append(e.Argument.Accept(this));
			sqlBuilder.Append(")");
			break;
		default:
			sqlBuilder.Append(" CAST( ");
			sqlBuilder.Append(e.Argument.Accept(this));
			sqlBuilder.Append(" AS ");
			sqlBuilder.Append(sqlPrimitiveType);
			sqlBuilder.Append(")");
			break;
		}
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbComparisonExpression e)
	{
		return e.ExpressionKind switch
		{
			DbExpressionKind.Equals => VisitComparisonExpression(" = ", e.Left, e.Right), 
			DbExpressionKind.LessThan => VisitComparisonExpression(" < ", e.Left, e.Right), 
			DbExpressionKind.LessThanOrEquals => VisitComparisonExpression(" <= ", e.Left, e.Right), 
			DbExpressionKind.GreaterThan => VisitComparisonExpression(" > ", e.Left, e.Right), 
			DbExpressionKind.GreaterThanOrEquals => VisitComparisonExpression(" >= ", e.Left, e.Right), 
			DbExpressionKind.NotEquals => VisitComparisonExpression(" <> ", e.Left, e.Right), 
			_ => throw new InvalidOperationException(string.Empty), 
		};
	}

	private ISqlFragment VisitConstant(DbConstantExpression e, bool isCastOptional)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		if (MetadataHelpers.TryGetPrimitiveTypeKind(e.ResultType, out var typeKind))
		{
			switch (typeKind)
			{
			case PrimitiveTypeKind.Int32:
				sqlBuilder.Append(e.Value.ToString());
				break;
			case PrimitiveTypeKind.Binary:
				sqlBuilder.Append(" CAST('");
				sqlBuilder.Append(ByteArrayToBinaryString((byte[])e.Value));
				sqlBuilder.Append("' AS RAW(");
				sqlBuilder.Append(((byte[])e.Value).Length.ToString());
				sqlBuilder.Append("))");
				break;
			case PrimitiveTypeKind.Boolean:
				sqlBuilder.Append(((bool)e.Value) ? "1" : "0");
				break;
			case PrimitiveTypeKind.Byte:
				WrapWithCastIfNeeded(!isCastOptional, e.Value.ToString(), "number(2)", sqlBuilder);
				break;
			case PrimitiveTypeKind.DateTime:
				sqlBuilder.Append("TO_TIMESTAMP(");
				sqlBuilder.Append(EscapeSingleQuote(((DateTime)e.Value).ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture), isUnicode: false));
				sqlBuilder.Append(", 'YYYY-MM-DD HH24:MI:SS.FF')");
				break;
			case PrimitiveTypeKind.Time:
				throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "Oracle Data Provider for .NET", typeKind.ToString()));
			case PrimitiveTypeKind.DateTimeOffset:
				sqlBuilder.Append("TO_TIMESTAMP_TZ(");
				sqlBuilder.Append(EscapeSingleQuote(((DateTimeOffset)e.Value).ToString("yyyy-MM-dd HH:mm:ss.fff zzz", CultureInfo.InvariantCulture), isUnicode: false));
				sqlBuilder.Append(", 'yyyy-mm-dd HH24:MI:SS.FF3 TZH:TZM')");
				break;
			case PrimitiveTypeKind.Decimal:
			{
				string text = ((decimal)e.Value).ToString(CultureInfo.InvariantCulture);
				bool flag = -1 == text.IndexOf('.') && text.TrimStart('-').Length < 20;
				string typeName = "decimal(" + Math.Max((byte)text.Length, (byte)38).ToString(CultureInfo.InvariantCulture) + ")";
				flag = false;
				WrapWithCastIfNeeded(flag, text, typeName, sqlBuilder);
				break;
			}
			case PrimitiveTypeKind.Double:
				isCastOptional = true;
				if (IsPre10g)
				{
					WrapWithCastIfNeeded(!isCastOptional, ((double)e.Value).ToString(), "number", sqlBuilder);
				}
				else
				{
					WrapWithCastIfNeeded(!isCastOptional, ((double)e.Value).ToString(), "binary_double", sqlBuilder);
				}
				break;
			case PrimitiveTypeKind.Guid:
				sqlBuilder.Append(" CAST('");
				if (e.Value is Guid)
				{
					sqlBuilder.Append(ByteArrayToBinaryString(((Guid)e.Value).ToByteArray()));
				}
				else
				{
					sqlBuilder.Append(ByteArrayToBinaryString((byte[])e.Value));
				}
				sqlBuilder.Append("' AS RAW(16))");
				break;
			case PrimitiveTypeKind.Int16:
				isCastOptional = true;
				WrapWithCastIfNeeded(!isCastOptional, e.Value.ToString(), "number(4)", sqlBuilder);
				break;
			case PrimitiveTypeKind.Int64:
				isCastOptional = true;
				WrapWithCastIfNeeded(!isCastOptional, e.Value.ToString(), "number(18)", sqlBuilder);
				break;
			case PrimitiveTypeKind.Single:
				isCastOptional = true;
				if (IsPre10g)
				{
					WrapWithCastIfNeeded(!isCastOptional, ((float)e.Value).ToString(), "number", sqlBuilder);
				}
				else
				{
					WrapWithCastIfNeeded(!isCastOptional, ((float)e.Value).ToString(), "binary_float", sqlBuilder);
				}
				break;
			case PrimitiveTypeKind.String:
			{
				if (!MetadataHelpers.TryGetIsUnicode(e.ResultType, out var isUnicode))
				{
					isUnicode = false;
				}
				sqlBuilder.Append(EscapeSingleQuote(e.Value as string, isUnicode));
				break;
			}
			default:
				throw new NotSupportedException();
			}
			return sqlBuilder;
		}
		throw new NotSupportedException();
	}

	private static void WrapWithCastIfNeeded(bool cast, string value, string typeName, SqlBuilder result)
	{
		if (!cast)
		{
			result.Append(value);
			return;
		}
		result.Append("cast(");
		result.Append(value);
		result.Append(" as ");
		result.Append(typeName);
		result.Append(")");
	}

	public override ISqlFragment Visit(DbConstantExpression e)
	{
		return VisitConstant(e, isCastOptional: false);
	}

	public override ISqlFragment Visit(DbDerefExpression e)
	{
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbDistinctExpression e)
	{
		SqlSelectStatement sqlSelectStatement = VisitExpressionEnsureSqlStatement(e.Argument);
		if (!IsCompatible(sqlSelectStatement, e.ExpressionKind))
		{
			TypeUsage elementTypeUsage = MetadataHelpers.GetElementTypeUsage(e.Argument.ResultType);
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, "distinct", elementTypeUsage, out var fromSymbol);
			AddFromSymbol(sqlSelectStatement, "distinct", fromSymbol, addToSymbolTable: false);
		}
		sqlSelectStatement.IsDistinct = true;
		return sqlSelectStatement;
	}

	public override ISqlFragment Visit(DbElementExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("(");
		sqlBuilder.Append(VisitExpressionEnsureSqlStatement(e.Argument));
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbExceptExpression e)
	{
		return VisitSetOpExpression(e.Left, e.Right, "MINUS");
	}

	public override ISqlFragment Visit(DbExpression e)
	{
		throw new InvalidOperationException(string.Empty);
	}

	public override ISqlFragment Visit(DbScanExpression e)
	{
		EntitySetBase target = e.Target;
		if (IsParentAJoin)
		{
			SqlBuilder sqlBuilder = new SqlBuilder();
			sqlBuilder.Append(GetTargetTSql(target));
			return sqlBuilder;
		}
		SqlSelectStatement sqlSelectStatement = new SqlSelectStatement();
		sqlSelectStatement.From.Append(GetTargetTSql(target));
		return sqlSelectStatement;
	}

	internal static string GetTargetTSql(EntitySetBase entitySetBase)
	{
		string metadataProperty = MetadataHelpers.GetMetadataProperty<string>(entitySetBase, "DefiningQuery");
		if (metadataProperty == null)
		{
			string metadataProperty2 = MetadataHelpers.GetMetadataProperty<string>(entitySetBase, "Schema");
			StringBuilder stringBuilder = new StringBuilder(50);
			if (!string.IsNullOrEmpty(metadataProperty2))
			{
				stringBuilder.Append(QuoteIdentifier(metadataProperty2));
				stringBuilder.Append(".");
			}
			string metadataProperty3 = MetadataHelpers.GetMetadataProperty<string>(entitySetBase, "Table");
			if (!string.IsNullOrEmpty(metadataProperty3))
			{
				stringBuilder.Append(QuoteIdentifier(metadataProperty3));
			}
			else
			{
				stringBuilder.Append(QuoteIdentifier(entitySetBase.Name));
			}
			return stringBuilder.ToString();
		}
		return "(" + metadataProperty + ")";
	}

	public override ISqlFragment Visit(DbFilterExpression e)
	{
		return VisitFilterExpression(e.Input, e.Predicate, negatePredicate: false);
	}

	public override ISqlFragment Visit(DbFunctionExpression e)
	{
		if (IsSpecialCanonicalFunction(e))
		{
			return HandleSpecialCanonicalFunction(e);
		}
		return HandleFunctionDefault(e);
	}

	public override ISqlFragment Visit(DbLambdaExpression expression)
	{
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbEntityRefExpression e)
	{
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbRefKeyExpression e)
	{
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbGroupByExpression e)
	{
		Symbol fromSymbol;
		SqlSelectStatement sqlSelectStatement = VisitInputExpression(e.Input.Expression, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		if (!IsCompatible(sqlSelectStatement, e.ExpressionKind))
		{
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		}
		selectStatementStack.Push(sqlSelectStatement);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement, e.Input.VariableName, fromSymbol);
		symbolTable.Add(e.Input.GroupVariableName, fromSymbol);
		RowType edmType = MetadataHelpers.GetEdmType<RowType>(MetadataHelpers.GetEdmType<CollectionType>(e.ResultType).TypeUsage);
		bool flag = GroupByAggregatesNeedInnerQuery(e.Aggregates) || GroupByKeysNeedInnerQuery(e.Keys, e.Input.VariableName);
		SqlSelectStatement sqlSelectStatement2;
		if (flag)
		{
			sqlSelectStatement2 = CreateNewSelectStatement(sqlSelectStatement, e.Input.VariableName, e.Input.VariableType, finalizeOldStatement: false, out fromSymbol);
			AddFromSymbol(sqlSelectStatement2, e.Input.VariableName, fromSymbol, addToSymbolTable: false);
		}
		else
		{
			sqlSelectStatement2 = sqlSelectStatement;
		}
		using (IEnumerator<EdmProperty> enumerator = (object)edmType.Properties.GetEnumerator())
		{
			enumerator.MoveNext();
			string s = "";
			foreach (DbExpression key in e.Keys)
			{
				EdmProperty current2 = enumerator.Current;
				string s2 = QuoteIdentifier(current2.Name);
				sqlSelectStatement2.GroupBy.Append(s);
				ISqlFragment s3 = key.Accept(this);
				if (!flag)
				{
					sqlSelectStatement2.Select.Append(s);
					sqlSelectStatement2.Select.AppendLine();
					sqlSelectStatement2.Select.Append(s3);
					sqlSelectStatement2.Select.Append(" AS ");
					sqlSelectStatement2.Select.Append(s2);
					sqlSelectStatement2.GroupBy.Append(s3);
				}
				else
				{
					sqlSelectStatement.Select.Append(s);
					sqlSelectStatement.Select.AppendLine();
					sqlSelectStatement.Select.Append(s3);
					sqlSelectStatement.Select.Append(" AS ");
					sqlSelectStatement.Select.Append(s2);
					sqlSelectStatement2.Select.Append(s);
					sqlSelectStatement2.Select.AppendLine();
					sqlSelectStatement2.Select.Append(fromSymbol);
					sqlSelectStatement2.Select.Append(".");
					sqlSelectStatement2.Select.Append(s2);
					sqlSelectStatement2.Select.Append(" AS ");
					sqlSelectStatement2.Select.Append(s2);
					sqlSelectStatement2.GroupBy.Append(s2);
				}
				s = ", ";
				enumerator.MoveNext();
			}
			foreach (DbAggregate aggregate in e.Aggregates)
			{
				EdmProperty current4 = enumerator.Current;
				string s4 = QuoteIdentifier(current4.Name);
				ISqlFragment sqlFragment = aggregate.Arguments[0].Accept(this);
				object aggregateArgument;
				if (flag)
				{
					SqlBuilder sqlBuilder = new SqlBuilder();
					sqlBuilder.Append(fromSymbol);
					sqlBuilder.Append(".");
					sqlBuilder.Append(s4);
					aggregateArgument = sqlBuilder;
					sqlSelectStatement.Select.Append(s);
					sqlSelectStatement.Select.AppendLine();
					sqlSelectStatement.Select.Append(sqlFragment);
					sqlSelectStatement.Select.Append(" AS ");
					sqlSelectStatement.Select.Append(s4);
				}
				else
				{
					aggregateArgument = sqlFragment;
				}
				ISqlFragment s5 = VisitAggregate(aggregate, aggregateArgument);
				sqlSelectStatement2.Select.Append(s);
				sqlSelectStatement2.Select.AppendLine();
				sqlSelectStatement2.Select.Append(s5);
				sqlSelectStatement2.Select.Append(" AS ");
				sqlSelectStatement2.Select.Append(s4);
				s = ", ";
				enumerator.MoveNext();
			}
		}
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		return sqlSelectStatement2;
	}

	public override ISqlFragment Visit(DbIntersectExpression e)
	{
		return VisitSetOpExpression(e.Left, e.Right, "INTERSECT");
	}

	public override ISqlFragment Visit(DbIsEmptyExpression e)
	{
		return VisitIsEmptyExpression(e, negate: false);
	}

	public override ISqlFragment Visit(DbIsNullExpression e)
	{
		return VisitIsNullExpression(e, negate: false);
	}

	public override ISqlFragment Visit(DbIsOfExpression e)
	{
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbCrossJoinExpression e)
	{
		return VisitJoinExpression(e.Inputs, e.ExpressionKind, "CROSS JOIN", null);
	}

	public override ISqlFragment Visit(DbJoinExpression e)
	{
		string joinString = e.ExpressionKind switch
		{
			DbExpressionKind.FullOuterJoin => "FULL OUTER JOIN", 
			DbExpressionKind.InnerJoin => "INNER JOIN", 
			DbExpressionKind.LeftOuterJoin => "LEFT OUTER JOIN", 
			_ => null, 
		};
		List<DbExpressionBinding> list = new List<DbExpressionBinding>(2);
		list.Add(e.Left);
		list.Add(e.Right);
		return VisitJoinExpression(list, e.ExpressionKind, joinString, e.JoinCondition);
	}

	public override ISqlFragment Visit(DbLikeExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(e.Argument.Accept(this));
		sqlBuilder.Append(" LIKE ");
		sqlBuilder.Append(e.Pattern.Accept(this));
		if (e.Escape.ExpressionKind != DbExpressionKind.Null)
		{
			sqlBuilder.Append(" ESCAPE ");
			SqlBuilder sqlBuilder2 = (SqlBuilder)e.Escape.Accept(this);
			if (!sqlBuilder2.IsEmpty && ((string)sqlBuilder2.sqlFragments[0]).StartsWith("N'"))
			{
				sqlBuilder2.sqlFragments[0] = ((string)sqlBuilder2.sqlFragments[0]).Remove(0, 1);
			}
			sqlBuilder.Append(sqlBuilder2);
		}
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbLimitExpression e)
	{
		SqlSelectStatement sqlSelectStatement = VisitExpressionEnsureSqlStatement(e.Argument, addDefaultColumns: false);
		if (!IsCompatible(sqlSelectStatement, e.ExpressionKind))
		{
			TypeUsage elementTypeUsage = MetadataHelpers.GetElementTypeUsage(e.Argument.ResultType);
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, "top", elementTypeUsage, out var fromSymbol);
			AddFromSymbol(sqlSelectStatement, "top", fromSymbol, addToSymbolTable: false);
		}
		ISqlFragment topCount = HandleCountExpression(e.Limit);
		sqlSelectStatement.Top = new TopClause(topCount, e.WithTies);
		return sqlSelectStatement;
	}

	public override ISqlFragment Visit(DbNewInstanceExpression e)
	{
		if (MetadataHelpers.IsCollectionType(e.ResultType.EdmType))
		{
			return VisitCollectionConstructor(e);
		}
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbNotExpression e)
	{
		if (e.Argument is DbNotExpression dbNotExpression)
		{
			return dbNotExpression.Argument.Accept(this);
		}
		if (e.Argument is DbIsEmptyExpression e2)
		{
			return VisitIsEmptyExpression(e2, negate: true);
		}
		if (e.Argument is DbIsNullExpression e3)
		{
			return VisitIsNullExpression(e3, negate: true);
		}
		if (e.Argument is DbComparisonExpression dbComparisonExpression && dbComparisonExpression.ExpressionKind == DbExpressionKind.Equals)
		{
			return VisitBinaryExpression(" <> ", DbExpressionKind.NotEquals, dbComparisonExpression.Left, dbComparisonExpression.Right);
		}
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(" NOT (");
		sqlBuilder.Append(e.Argument.Accept(this));
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbNullExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("NULL");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbOfTypeExpression e)
	{
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbOrExpression e)
	{
		return VisitBinaryExpression(" OR ", e.ExpressionKind, e.Left, e.Right);
	}

	public override ISqlFragment Visit(DbParameterReferenceExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(":" + e.ParameterName);
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbProjectExpression e)
	{
		Symbol fromSymbol;
		SqlSelectStatement sqlSelectStatement = VisitInputExpression(e.Input.Expression, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		bool flag = false;
		if (!IsCompatible(sqlSelectStatement, e.ExpressionKind))
		{
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		}
		selectStatementStack.Push(sqlSelectStatement);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement, e.Input.VariableName, fromSymbol);
		if (e.Projection is DbNewInstanceExpression e2)
		{
			sqlSelectStatement.Select.Append(VisitNewInstanceExpression(e2, flag, out var newColumns));
			if (flag)
			{
				sqlSelectStatement.OutputColumnsRenamed = true;
				sqlSelectStatement.OutputColumns = newColumns;
			}
		}
		else
		{
			sqlSelectStatement.Select.Append(e.Projection.Accept(this));
		}
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		return sqlSelectStatement;
	}

	public override ISqlFragment Visit(DbPropertyExpression e)
	{
		ISqlFragment sqlFragment = e.Instance.Accept(this);
		if (e.Instance is DbVariableReferenceExpression)
		{
			isVarRefSingle = false;
		}
		if (sqlFragment is JoinSymbol joinSymbol)
		{
			if (joinSymbol.IsNestedJoin)
			{
				return new SymbolPair(joinSymbol, joinSymbol.NameToExtent[e.Property.Name]);
			}
			return joinSymbol.NameToExtent[e.Property.Name];
		}
		SqlBuilder sqlBuilder;
		if (sqlFragment is SymbolPair symbolPair)
		{
			if (symbolPair.Column is JoinSymbol joinSymbol2)
			{
				symbolPair.Column = joinSymbol2.NameToExtent[e.Property.Name];
				return symbolPair;
			}
			if (symbolPair.Column.Columns.ContainsKey(e.Property.Name))
			{
				sqlBuilder = new SqlBuilder();
				sqlBuilder.Append(symbolPair.Source);
				sqlBuilder.Append(".");
				sqlBuilder.Append(symbolPair.Column.Columns[e.Property.Name]);
				return sqlBuilder;
			}
		}
		sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(sqlFragment);
		sqlBuilder.Append(".");
		if (sqlFragment is Symbol symbol && symbol.OutputColumnsRenamed)
		{
			sqlBuilder.Append(symbol.Columns[e.Property.Name]);
		}
		else
		{
			sqlBuilder.Append(QuoteIdentifier(e.Property.Name));
		}
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbQuantifierExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		bool negatePredicate = e.ExpressionKind == DbExpressionKind.All;
		if (e.ExpressionKind == DbExpressionKind.Any)
		{
			sqlBuilder.Append("EXISTS (");
		}
		else
		{
			sqlBuilder.Append("NOT EXISTS (");
		}
		SqlSelectStatement sqlSelectStatement = VisitFilterExpression(e.Input, e.Predicate, negatePredicate);
		if (sqlSelectStatement.Select.IsEmpty)
		{
			AddDefaultColumns(sqlSelectStatement);
		}
		sqlBuilder.Append(sqlSelectStatement);
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbRefExpression e)
	{
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbRelationshipNavigationExpression e)
	{
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbSkipExpression e)
	{
		Symbol fromSymbol;
		SqlSelectStatement sqlSelectStatement = VisitInputExpression(e.Input.Expression, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		if (!IsCompatible(sqlSelectStatement, e.ExpressionKind))
		{
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		}
		selectStatementStack.Push(sqlSelectStatement);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement, e.Input.VariableName, fromSymbol);
		List<Symbol> columnList = AddDefaultColumns(sqlSelectStatement);
		sqlSelectStatement.Select.Append(", row_number() OVER (ORDER BY ");
		AddSortKeys(sqlSelectStatement.Select, e.SortOrder);
		sqlSelectStatement.Select.Append(") AS ");
		Symbol s = new Symbol("row_number", null);
		sqlSelectStatement.Select.Append(s);
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		SqlSelectStatement sqlSelectStatement2 = new SqlSelectStatement();
		sqlSelectStatement2.From.Append("( ");
		sqlSelectStatement2.From.Append(sqlSelectStatement);
		sqlSelectStatement2.From.AppendLine();
		sqlSelectStatement2.From.Append(") ");
		Symbol symbol = null;
		if (sqlSelectStatement.FromExtents.Count == 1 && sqlSelectStatement.FromExtents[0] is JoinSymbol joinSymbol)
		{
			JoinSymbol joinSymbol2 = new JoinSymbol(e.Input.VariableName, e.Input.VariableType, joinSymbol.ExtentList);
			joinSymbol2.IsNestedJoin = true;
			joinSymbol2.ColumnList = columnList;
			joinSymbol2.FlattenedExtentList = joinSymbol.FlattenedExtentList;
			symbol = joinSymbol2;
		}
		if (symbol == null)
		{
			symbol = new Symbol(e.Input.VariableName, e.Input.VariableType);
		}
		selectStatementStack.Push(sqlSelectStatement2);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement2, e.Input.VariableName, symbol);
		sqlSelectStatement2.Where.Append(symbol);
		sqlSelectStatement2.Where.Append(".");
		sqlSelectStatement2.Where.Append(s);
		sqlSelectStatement2.Where.Append(" > ");
		sqlSelectStatement2.Where.Append(HandleCountExpression(e.Count));
		AddSortKeys(sqlSelectStatement2.OrderBy, e.SortOrder);
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		return sqlSelectStatement2;
	}

	public override ISqlFragment Visit(DbSortExpression e)
	{
		Symbol fromSymbol;
		SqlSelectStatement sqlSelectStatement = VisitInputExpression(e.Input.Expression, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		if (!IsCompatible(sqlSelectStatement, e.ExpressionKind))
		{
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		}
		selectStatementStack.Push(sqlSelectStatement);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement, e.Input.VariableName, fromSymbol);
		AddSortKeys(sqlSelectStatement.OrderBy, e.SortOrder);
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		return sqlSelectStatement;
	}

	public override ISqlFragment Visit(DbTreatExpression e)
	{
		throw new NotSupportedException();
	}

	public override ISqlFragment Visit(DbUnionAllExpression e)
	{
		return VisitSetOpExpression(e.Left, e.Right, "UNION ALL");
	}

	public override ISqlFragment Visit(DbVariableReferenceExpression e)
	{
		if (isVarRefSingle)
		{
			throw new NotSupportedException();
		}
		isVarRefSingle = true;
		Symbol symbol = symbolTable.Lookup(e.VariableName);
		if (!CurrentSelectStatement.FromExtents.Contains(symbol))
		{
			CurrentSelectStatement.OuterExtents[symbol] = true;
		}
		return symbol;
	}

	private static SqlBuilder VisitAggregate(DbAggregate aggregate, object aggregateArgument)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		if (!(aggregate is DbFunctionAggregate dbFunctionAggregate))
		{
			throw new NotSupportedException();
		}
		WriteFunctionName(sqlBuilder, dbFunctionAggregate.Function);
		sqlBuilder.Append("(");
		DbFunctionAggregate dbFunctionAggregate2 = dbFunctionAggregate;
		if (dbFunctionAggregate2 != null && dbFunctionAggregate2.Distinct)
		{
			sqlBuilder.Append("DISTINCT ");
		}
		sqlBuilder.Append(aggregateArgument);
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	private void ParanthesizeExpressionIfNeeded(DbExpression e, SqlBuilder result)
	{
		if (IsComplexExpression(e))
		{
			result.Append("(");
			result.Append(e.Accept(this));
			result.Append(")");
		}
		else
		{
			result.Append(e.Accept(this));
		}
	}

	private SqlBuilder VisitBinaryExpression(string op, DbExpressionKind expressionKind, DbExpression left, DbExpression right)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		bool flag = true;
		foreach (DbExpression item in CommandTreeUtils.FlattenAssociativeExpression(expressionKind, left, right))
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				sqlBuilder.Append(op);
			}
			ParanthesizeExpressionIfNeeded(item, sqlBuilder);
		}
		return sqlBuilder;
	}

	private SqlBuilder VisitComparisonExpression(string op, DbExpression left, DbExpression right)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		bool isCastOptional = left.ResultType.EdmType == right.ResultType.EdmType;
		if (left.ExpressionKind == DbExpressionKind.Constant)
		{
			sqlBuilder.Append(VisitConstant((DbConstantExpression)left, isCastOptional));
		}
		else
		{
			ParanthesizeExpressionIfNeeded(left, sqlBuilder);
		}
		sqlBuilder.Append(op);
		if (right.ExpressionKind == DbExpressionKind.Constant)
		{
			sqlBuilder.Append(VisitConstant((DbConstantExpression)right, isCastOptional));
		}
		else
		{
			ParanthesizeExpressionIfNeeded(right, sqlBuilder);
		}
		return sqlBuilder;
	}

	private SqlSelectStatement VisitInputExpression(DbExpression inputExpression, string inputVarName, TypeUsage inputVarType, out Symbol fromSymbol)
	{
		ISqlFragment sqlFragment = inputExpression.Accept(this);
		SqlSelectStatement sqlSelectStatement = sqlFragment as SqlSelectStatement;
		if (sqlSelectStatement == null)
		{
			sqlSelectStatement = new SqlSelectStatement();
			WrapNonQueryExtent(sqlSelectStatement, sqlFragment, inputExpression.ExpressionKind);
		}
		if (sqlSelectStatement.FromExtents.Count == 0)
		{
			fromSymbol = new Symbol(inputVarName, inputVarType);
		}
		else if (sqlSelectStatement.FromExtents.Count == 1)
		{
			fromSymbol = sqlSelectStatement.FromExtents[0];
		}
		else
		{
			JoinSymbol joinSymbol = new JoinSymbol(inputVarName, inputVarType, sqlSelectStatement.FromExtents);
			joinSymbol.FlattenedExtentList = sqlSelectStatement.AllJoinExtents;
			fromSymbol = joinSymbol;
			sqlSelectStatement.FromExtents.Clear();
			sqlSelectStatement.FromExtents.Add(fromSymbol);
		}
		return sqlSelectStatement;
	}

	private SqlBuilder VisitIsEmptyExpression(DbIsEmptyExpression e, bool negate)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		if (!negate)
		{
			sqlBuilder.Append(" NOT");
		}
		sqlBuilder.Append(" EXISTS (");
		sqlBuilder.Append(VisitExpressionEnsureSqlStatement(e.Argument));
		sqlBuilder.AppendLine();
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	private ISqlFragment VisitCollectionConstructor(DbNewInstanceExpression e)
	{
		if (e.Arguments.Count == 1 && e.Arguments[0].ExpressionKind == DbExpressionKind.Element)
		{
			DbElementExpression dbElementExpression = e.Arguments[0] as DbElementExpression;
			SqlSelectStatement sqlSelectStatement = VisitExpressionEnsureSqlStatement(dbElementExpression.Argument);
			if (!IsCompatible(sqlSelectStatement, DbExpressionKind.Element))
			{
				TypeUsage elementTypeUsage = MetadataHelpers.GetElementTypeUsage(dbElementExpression.Argument.ResultType);
				sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, "element", elementTypeUsage, out var fromSymbol);
				AddFromSymbol(sqlSelectStatement, "element", fromSymbol, addToSymbolTable: false);
			}
			sqlSelectStatement.Top = new TopClause(1, withTies: false);
			return sqlSelectStatement;
		}
		CollectionType edmType = MetadataHelpers.GetEdmType<CollectionType>(e.ResultType);
		bool flag = MetadataHelpers.IsPrimitiveType(edmType.TypeUsage.EdmType);
		SqlBuilder sqlBuilder = new SqlBuilder();
		string s = "";
		if (e.Arguments.Count == 0)
		{
			sqlBuilder.Append(" SELECT CAST(null as ");
			sqlBuilder.Append(GetSqlPrimitiveType(edmType.TypeUsage));
			sqlBuilder.Append(") AS X FROM DUAL AS Y WHERE 1=0");
		}
		foreach (DbExpression argument in e.Arguments)
		{
			sqlBuilder.Append(s);
			sqlBuilder.Append(" SELECT ");
			sqlBuilder.Append(argument.Accept(this));
			if (flag)
			{
				sqlBuilder.Append(" FROM DUAL ");
			}
			s = " UNION ALL ";
		}
		return sqlBuilder;
	}

	private SqlBuilder VisitIsNullExpression(DbIsNullExpression e, bool negate)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(e.Argument.Accept(this));
		if (!negate)
		{
			sqlBuilder.Append(" IS NULL");
		}
		else
		{
			sqlBuilder.Append(" IS NOT NULL");
		}
		return sqlBuilder;
	}

	private ISqlFragment VisitJoinExpression(IList<DbExpressionBinding> inputs, DbExpressionKind joinKind, string joinString, DbExpression joinCondition)
	{
		SqlSelectStatement sqlSelectStatement;
		if (!IsParentAJoin)
		{
			sqlSelectStatement = new SqlSelectStatement();
			sqlSelectStatement.AllJoinExtents = new List<Symbol>();
			selectStatementStack.Push(sqlSelectStatement);
		}
		else
		{
			sqlSelectStatement = CurrentSelectStatement;
		}
		symbolTable.EnterScope();
		string text = "";
		bool flag = true;
		int count = inputs.Count;
		for (int i = 0; i < count; i++)
		{
			DbExpressionBinding dbExpressionBinding = inputs[i];
			if (text.Length != 0)
			{
				sqlSelectStatement.From.AppendLine();
			}
			sqlSelectStatement.From.Append(text + " ");
			bool flag2 = dbExpressionBinding.Expression.ExpressionKind == DbExpressionKind.Scan || (flag && (IsJoinExpression(dbExpressionBinding.Expression) || IsApplyExpression(dbExpressionBinding.Expression)));
			isParentAJoinStack.Push(flag2 ? true : false);
			int count2 = sqlSelectStatement.FromExtents.Count;
			ISqlFragment fromExtentFragment = dbExpressionBinding.Expression.Accept(this);
			isParentAJoinStack.Pop();
			ProcessJoinInputResult(fromExtentFragment, sqlSelectStatement, dbExpressionBinding, count2);
			text = joinString;
			flag = false;
		}
		if (joinKind == DbExpressionKind.FullOuterJoin || joinKind == DbExpressionKind.InnerJoin || joinKind == DbExpressionKind.LeftOuterJoin)
		{
			sqlSelectStatement.From.Append(" ON ");
			isParentAJoinStack.Push(item: false);
			sqlSelectStatement.From.Append(joinCondition.Accept(this));
			isParentAJoinStack.Pop();
		}
		symbolTable.ExitScope();
		if (!IsParentAJoin)
		{
			selectStatementStack.Pop();
		}
		return sqlSelectStatement;
	}

	private void ProcessJoinInputResult(ISqlFragment fromExtentFragment, SqlSelectStatement result, DbExpressionBinding input, int fromSymbolStart)
	{
		Symbol symbol = null;
		if (result != fromExtentFragment)
		{
			if (fromExtentFragment is SqlSelectStatement sqlSelectStatement)
			{
				if (sqlSelectStatement.Select.IsEmpty)
				{
					List<Symbol> columnList = AddDefaultColumns(sqlSelectStatement);
					if (IsJoinExpression(input.Expression) || IsApplyExpression(input.Expression))
					{
						List<Symbol> fromExtents = sqlSelectStatement.FromExtents;
						JoinSymbol joinSymbol = new JoinSymbol(input.VariableName, input.VariableType, fromExtents);
						joinSymbol.IsNestedJoin = true;
						joinSymbol.ColumnList = columnList;
						symbol = joinSymbol;
					}
					else if (sqlSelectStatement.FromExtents[0] is JoinSymbol joinSymbol2)
					{
						JoinSymbol joinSymbol3 = new JoinSymbol(input.VariableName, input.VariableType, joinSymbol2.ExtentList);
						joinSymbol3.IsNestedJoin = true;
						joinSymbol3.ColumnList = columnList;
						joinSymbol3.FlattenedExtentList = joinSymbol2.FlattenedExtentList;
						symbol = joinSymbol3;
					}
					else if (sqlSelectStatement.FromExtents[0].OutputColumnsRenamed)
					{
						symbol = new Symbol(input.VariableName, input.VariableType, sqlSelectStatement.FromExtents[0].Columns);
					}
				}
				else if (sqlSelectStatement.OutputColumnsRenamed)
				{
					symbol = new Symbol(input.VariableName, input.VariableType, sqlSelectStatement.OutputColumns);
				}
				result.From.Append(" (");
				result.From.Append(sqlSelectStatement);
				result.From.Append(" )");
			}
			else if (input.Expression is DbScanExpression)
			{
				result.From.Append(fromExtentFragment);
			}
			else
			{
				WrapNonQueryExtent(result, fromExtentFragment, input.Expression.ExpressionKind);
			}
			if (symbol == null)
			{
				symbol = new Symbol(input.VariableName, input.VariableType);
			}
			AddFromSymbol(result, input.VariableName, symbol);
			result.AllJoinExtents.Add(symbol);
		}
		else
		{
			List<Symbol> list = new List<Symbol>();
			for (int i = fromSymbolStart; i < result.FromExtents.Count; i++)
			{
				list.Add(result.FromExtents[i]);
			}
			result.FromExtents.RemoveRange(fromSymbolStart, result.FromExtents.Count - fromSymbolStart);
			symbol = new JoinSymbol(input.VariableName, input.VariableType, list);
			result.FromExtents.Add(symbol);
			symbolTable.Add(input.VariableName, symbol);
		}
	}

	private ISqlFragment VisitNewInstanceExpression(DbNewInstanceExpression e, bool aliasesNeedRenaming, out Dictionary<string, Symbol> newColumns)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		if (e.ResultType.EdmType is RowType rowType)
		{
			if (aliasesNeedRenaming)
			{
				newColumns = new Dictionary<string, Symbol>(e.Arguments.Count);
			}
			else
			{
				newColumns = null;
			}
			ReadOnlyMetadataCollection<EdmProperty> properties = rowType.Properties;
			string s = "";
			for (int i = 0; i < e.Arguments.Count; i++)
			{
				DbExpression dbExpression = e.Arguments[i];
				if (MetadataHelpers.IsRowType(dbExpression.ResultType.EdmType))
				{
					throw new NotSupportedException();
				}
				EdmProperty edmProperty = properties[i];
				sqlBuilder.Append(s);
				sqlBuilder.AppendLine();
				sqlBuilder.Append(dbExpression.Accept(this));
				sqlBuilder.Append(" AS ");
				if (aliasesNeedRenaming)
				{
					Symbol symbol = new Symbol(edmProperty.Name, edmProperty.TypeUsage);
					symbol.NeedsRenaming = true;
					symbol.NewName = "Internal_" + edmProperty.Name;
					sqlBuilder.Append(symbol);
					newColumns.Add(edmProperty.Name, symbol);
				}
				else
				{
					sqlBuilder.Append(QuoteIdentifier(edmProperty.Name));
				}
				s = ", ";
			}
			return sqlBuilder;
		}
		throw new NotSupportedException();
	}

	private ISqlFragment VisitSetOpExpression(DbExpression left, DbExpression right, string separator)
	{
		SqlSelectStatement sqlSelectStatement = VisitExpressionEnsureSqlStatement(left);
		SqlSelectStatement s = VisitExpressionEnsureSqlStatement(right);
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(sqlSelectStatement);
		sqlBuilder.AppendLine();
		sqlBuilder.Append(separator);
		sqlBuilder.AppendLine();
		sqlBuilder.Append(s);
		if (!sqlSelectStatement.OutputColumnsRenamed)
		{
			return sqlBuilder;
		}
		SqlSelectStatement sqlSelectStatement2 = new SqlSelectStatement();
		sqlSelectStatement2.From.Append("( ");
		sqlSelectStatement2.From.Append(sqlBuilder);
		sqlSelectStatement2.From.AppendLine();
		sqlSelectStatement2.From.Append(") ");
		Symbol fromSymbol = new Symbol("X", left.ResultType, sqlSelectStatement.OutputColumns);
		AddFromSymbol(sqlSelectStatement2, null, fromSymbol, addToSymbolTable: false);
		return sqlSelectStatement2;
	}

	private static bool IsSpecialCanonicalFunction(DbFunctionExpression e)
	{
		if (MetadataHelpers.IsCanonicalFunction(e.Function))
		{
			return _canonicalFunctionHandlers.ContainsKey(e.Function.Name);
		}
		return false;
	}

	private ISqlFragment HandleFunctionDefault(DbFunctionExpression e)
	{
		SqlBuilder result = new SqlBuilder();
		WriteFunctionName(result, e.Function);
		HandleFunctionArgumentsDefault(e, result);
		return result;
	}

	private ISqlFragment HandleFunctionDefaultGivenName(DbFunctionExpression e, string functionName)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(functionName);
		HandleFunctionArgumentsDefault(e, sqlBuilder);
		return sqlBuilder;
	}

	private void HandleFunctionArgumentsDefault(DbFunctionExpression e, SqlBuilder result)
	{
		bool metadataProperty = MetadataHelpers.GetMetadataProperty<bool>(e.Function, "NiladicFunctionAttribute");
		if (metadataProperty && e.Arguments.Count > 0)
		{
			throw new MetadataException(OpoErrResManager.GetErrorMesg(ErrRes.EF_NILADIC_FUNCTION));
		}
		if (metadataProperty)
		{
			return;
		}
		result.Append("(");
		string s = "";
		foreach (DbExpression argument in e.Arguments)
		{
			result.Append(s);
			result.Append(argument.Accept(this));
			s = ", ";
		}
		result.Append(")");
	}

	private ISqlFragment HandleSpecialCanonicalFunction(DbFunctionExpression e)
	{
		return HandleSpecialFunction(_canonicalFunctionHandlers, e);
	}

	private ISqlFragment HandleSpecialFunction(Dictionary<string, FunctionHandler> handlers, DbFunctionExpression e)
	{
		return handlers[e.Function.Name](this, e);
	}

	private static ISqlFragment HandleCanonicalFunctionSubstring(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "SUBSTR");
	}

	private static ISqlFragment HandleCanonicalFunctionLeft(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("SUBSTR (");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append(",1,");
		sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionRight(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("(CASE WHEN LENGTH(");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append(") >= (");
		sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
		sqlBuilder.Append(") THEN ");
		sqlBuilder.Append("SUBSTR (");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append(",-(");
		sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
		sqlBuilder.Append("),");
		sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
		sqlBuilder.Append(")");
		sqlBuilder.Append(" ELSE ");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append(" END)");
		return sqlBuilder;
	}

	private static ISqlFragment HandleConcatFunction(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("((");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append(")||(");
		sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
		sqlBuilder.Append("))");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionBitwise(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		switch (e.Function.Name.ToUpperInvariant())
		{
		case "BITWISEAND":
			sqlBuilder.Append("BITAND(");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(",");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append(")");
			break;
		case "BITWISEOR":
			sqlBuilder.Append("((");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(")+(");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append(")-BITAND(");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(",");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("))");
			break;
		case "BITWISEXOR":
			sqlBuilder.Append("((");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(")+(");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append(")-2*BITAND(");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(",");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("))");
			break;
		case "BITWISENOT":
			sqlBuilder.Append("((0 - ");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(") - 1)");
			break;
		}
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionDatepart(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		if (e.Function.Name.ToUpperInvariant() == "MILLISECOND")
		{
			sqlBuilder.Append(" NVL(TO_NUMBER(SUBSTR(TO_CHAR(CAST(");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(" AS TIMESTAMP(3))");
			sqlBuilder.Append(" , 'DD-MON-RR HH24:MI:SSXFF'), 20, 3)), 0) ");
			return sqlBuilder;
		}
		if (e.Function.Name.ToUpperInvariant() == "DAYOFYEAR")
		{
			sqlBuilder.Append(" TO_NUMBER(TO_CHAR(");
			sqlBuilder.Append("CAST(");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(" AS TIMESTAMP)");
			sqlBuilder.Append(", 'DDD')) ");
			return sqlBuilder;
		}
		sqlBuilder.Append("EXTRACT (");
		sqlBuilder.Append(e.Function.Name.ToUpperInvariant());
		sqlBuilder.Append(" FROM (");
		sqlBuilder.Append(" CAST(");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append(" AS TIMESTAMP)");
		sqlBuilder.Append("))");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionDatepartAdd(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		MetadataHelpers.TryGetPrimitiveTypeKind(e.Arguments[0].ResultType, out var typeKind);
		if (typeKind != PrimitiveTypeKind.DateTimeOffset)
		{
			sqlBuilder.Append(" CAST(");
		}
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		if (typeKind != PrimitiveTypeKind.DateTimeOffset)
		{
			sqlBuilder.Append(" AS TIMESTAMP(9))");
		}
		sqlBuilder.Append(" + ");
		switch (e.Function.Name.ToUpperInvariant())
		{
		case "ADDYEARS":
			sqlBuilder.Append(" INTERVAL '");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("' YEAR(9) ");
			break;
		case "ADDMONTHS":
			sqlBuilder.Append(" INTERVAL '");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("' MONTH(9) ");
			break;
		case "ADDDAYS":
			sqlBuilder.Append(" INTERVAL '");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("' DAY(9) ");
			break;
		case "ADDHOURS":
			sqlBuilder.Append(" INTERVAL '");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("' HOUR(9) ");
			break;
		case "ADDMINUTES":
			sqlBuilder.Append(" INTERVAL '");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("' MINUTE(9) ");
			break;
		case "ADDSECONDS":
			sqlBuilder.Append(" INTERVAL '");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("' SECOND(9) ");
			break;
		case "ADDMILLISECONDS":
			sqlBuilder.Append(" (INTERVAL '");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("' SECOND(9) / 1000) ");
			break;
		case "ADDMICROSECONDS":
			sqlBuilder.Append(" (INTERVAL '");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("' SECOND(9) / (1000 * 1000)) ");
			break;
		case "ADDNANOSECONDS":
			sqlBuilder.Append(" (INTERVAL '");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("' SECOND(9) / (1000 * 1000 * 1000)) ");
			break;
		}
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionDatepartDiff(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		MetadataHelpers.TryGetPrimitiveTypeKind(e.Arguments[1].ResultType, out var typeKind);
		SqlBuilder sqlBuilder = new SqlBuilder();
		switch (e.Function.Name.ToUpperInvariant())
		{
		case "DIFFYEARS":
			if (typeKind == PrimitiveTypeKind.DateTimeOffset)
			{
				sqlBuilder.Append(" TRUNC(EXTRACT(");
				sqlBuilder.Append(" DAY FROM (");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(")) / 365) ");
			}
			else
			{
				sqlBuilder.Append(" TRUNC(EXTRACT(");
				sqlBuilder.Append(" DAY FROM (");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(")) / 365) ");
			}
			break;
		case "DIFFMONTHS":
			if (typeKind == PrimitiveTypeKind.DateTimeOffset)
			{
				sqlBuilder.Append(" TRUNC(EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(")) / 31) ");
			}
			else
			{
				sqlBuilder.Append(" TRUNC(EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(")) / 31) ");
			}
			break;
		case "DIFFDAYS":
			if (typeKind == PrimitiveTypeKind.DateTimeOffset)
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(")) ");
			}
			else
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(")) ");
			}
			break;
		case "DIFFHOURS":
			if (typeKind == PrimitiveTypeKind.DateTimeOffset)
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*24 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(")) ");
			}
			else
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*24 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(")) ");
			}
			break;
		case "DIFFMINUTES":
			if (typeKind == PrimitiveTypeKind.DateTimeOffset)
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*24*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM (");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM (");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(")) ");
			}
			else
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*24*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM (");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM (");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(")) ");
			}
			break;
		case "DIFFSECONDS":
			if (typeKind == PrimitiveTypeKind.DateTimeOffset)
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM (");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*24*60*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*60*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM (");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" SECOND FROM (");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(")) ");
			}
			else
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM (");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*24*60*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*60*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM (");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*60 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" SECOND FROM (");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(")) ");
			}
			break;
		case "DIFFMILLISECONDS":
			if (typeKind == PrimitiveTypeKind.DateTimeOffset)
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*24*60*60*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*60*60*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*60*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" SECOND FROM (");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*1000 ");
			}
			else
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*24*60*60*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9)) ");
				sqlBuilder.Append("))*60*60*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9)) ");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9)) ");
				sqlBuilder.Append("))*60*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" SECOND FROM (");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*1000 ");
			}
			break;
		case "DIFFMICROSECONDS":
			if (typeKind == PrimitiveTypeKind.DateTimeOffset)
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*24*60*60*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*60*60*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*60*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" SECOND FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*1000*1000 ");
			}
			else
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*24*60*60*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*60*60*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*60*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" SECOND FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*1000*1000 ");
			}
			break;
		case "DIFFNANOSECONDS":
			if (typeKind == PrimitiveTypeKind.DateTimeOffset)
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*24*60*60*1000*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*60*60*1000*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*60*1000*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" SECOND FROM(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append("))*1000*1000*1000 ");
			}
			else
			{
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" DAY FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9)) ");
				sqlBuilder.Append("))*24*60*60*1000*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" HOUR FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*60*60*1000*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" MINUTE FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*60*1000*1000*1000 + ");
				sqlBuilder.Append(" EXTRACT(");
				sqlBuilder.Append(" SECOND FROM(");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append(" - ");
				sqlBuilder.Append(" CAST(");
				sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
				sqlBuilder.Append(" AS TIMESTAMP(9))");
				sqlBuilder.Append("))*1000*1000*1000 ");
			}
			break;
		}
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionGetTotalOffsetMinutes(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("(EXTRACT (TIMEZONE_HOUR FROM (");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append(")) * 60 + EXTRACT (TIMEZONE_MINUTE FROM (");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append(")))");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionCurrentDateTime(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		switch (e.Function.Name.ToUpperInvariant())
		{
		case "CURRENTDATETIME":
			sqlBuilder.Append("LOCALTIMESTAMP");
			break;
		case "CURRENTUTCDATETIME":
			sqlBuilder.Append("SYS_EXTRACT_UTC(LOCALTIMESTAMP)");
			break;
		case "CURRENTDATETIMEOFFSET":
			sqlBuilder.Append("SYSTIMESTAMP");
			break;
		case "CREATEDATETIME":
			sqlBuilder.Append("TO_TIMESTAMP(");
			sqlBuilder.Append("'");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append("-");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("-");
			sqlBuilder.Append(e.Arguments[2].Accept(sqlgen));
			sqlBuilder.Append(" ");
			sqlBuilder.Append(e.Arguments[3].Accept(sqlgen));
			sqlBuilder.Append(":");
			sqlBuilder.Append(e.Arguments[4].Accept(sqlgen));
			sqlBuilder.Append(":");
			sqlBuilder.Append(((DbConstantExpression)e.Arguments[5]).Value.ToString());
			sqlBuilder.Append("'");
			sqlBuilder.Append(", 'YYYY-MM-DD HH24:MI:SS.FF')");
			break;
		case "CREATEDATETIMEOFFSET":
			sqlBuilder.Append("TO_TIMESTAMP_TZ(");
			sqlBuilder.Append("'");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append("-");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("-");
			sqlBuilder.Append(e.Arguments[2].Accept(sqlgen));
			sqlBuilder.Append(" ");
			sqlBuilder.Append(e.Arguments[3].Accept(sqlgen));
			sqlBuilder.Append(":");
			sqlBuilder.Append(e.Arguments[4].Accept(sqlgen));
			sqlBuilder.Append(":");
			sqlBuilder.Append($"{((DbConstantExpression)e.Arguments[5]).Value:00.000000000}");
			sqlBuilder.Append(" ");
			sqlBuilder.Append(e.Arguments[6].Accept(sqlgen));
			sqlBuilder.Append("'");
			sqlBuilder.Append(", 'yyyy-mm-dd HH24:MI:SS.FF TZH:TZM')");
			break;
		}
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionIndexOf(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "INSTR");
	}

	private static ISqlFragment HandleCanonicalFunctionIndexOf2(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		switch (e.Function.Name.ToUpperInvariant())
		{
		case "INDEXOF":
			sqlBuilder.Append(" NVL(INSTR(");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append(", ");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append("), 0) ");
			break;
		case "CONTAINS":
			sqlBuilder.Append(" CASE WHEN ");
			sqlBuilder.Append(" NVL(INSTR(");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(", ");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("), 0) ");
			sqlBuilder.Append(" != 0 THEN 1 ELSE 0 END ");
			break;
		case "STARTSWITH":
			sqlBuilder.Append(" CASE WHEN ");
			sqlBuilder.Append(" NVL(INSTR(");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(", ");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append("), 0) ");
			sqlBuilder.Append(" = 1 THEN 1 ELSE 0 END ");
			break;
		case "ENDSWITH":
			sqlBuilder.Append(" CASE WHEN NVL(INSTR(");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(", ");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append(", LENGTH(");
			sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
			sqlBuilder.Append(") - LENGTH(");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append(") + 1, 1 ), 0) > 0 THEN 1 ELSE 0 END ");
			break;
		}
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionNewGuid(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "SYS_GUID");
	}

	private static ISqlFragment HandleCanonicalFunctionLength(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("LENGTH(");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionRound(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("ROUND(");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		if (e.Arguments.Count == 1)
		{
			sqlBuilder.Append(", 0)");
		}
		else
		{
			sqlBuilder.Append(", ");
			sqlBuilder.Append(e.Arguments[1].Accept(sqlgen));
			sqlBuilder.Append(")");
		}
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionTrim(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("LTRIM(RTRIM(");
		sqlBuilder.Append(e.Arguments[0].Accept(sqlgen));
		sqlBuilder.Append("))");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionToLower(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "LOWER");
	}

	private static ISqlFragment HandleCanonicalFunctionToUpper(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "UPPER");
	}

	private static ISqlFragment HandleCanonicalFunctionCeiling(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "CEIL");
	}

	private static ISqlFragment HandleCanonicalFunctionTruncate(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "TRUNC");
	}

	private static void WriteFunctionName(SqlBuilder result, EdmFunction function)
	{
		string metadataProperty = MetadataHelpers.GetMetadataProperty<string>(function, "StoreFunctionNameAttribute");
		string text = ((metadataProperty == null) ? function.Name : metadataProperty);
		if (MetadataHelpers.IsCanonicalFunction(function))
		{
			if (text.ToUpperInvariant() == "STDEV")
			{
				result.Append("STDDEV");
			}
			else if (text.ToUpperInvariant() == "STDEVP")
			{
				result.Append("STDDEV_POP");
			}
			else if (text.ToUpperInvariant() == "VAR")
			{
				result.Append("VARIANCE");
			}
			else if (text.ToUpperInvariant() == "VARP")
			{
				result.Append("VAR_POP");
			}
			else if (text.ToUpperInvariant() == "BIGCOUNT")
			{
				result.Append("COUNT");
			}
			else
			{
				result.Append(text.ToUpperInvariant());
			}
		}
		else if (IsBuiltInStoreFunction(function))
		{
			result.Append(text);
		}
		else
		{
			string metadataProperty2 = MetadataHelpers.GetMetadataProperty<string>(function, "Schema");
			if (string.IsNullOrEmpty(metadataProperty2))
			{
				result.Append(QuoteIdentifier(function.NamespaceName));
			}
			else
			{
				result.Append(QuoteIdentifier(metadataProperty2));
			}
			result.Append(".");
			result.Append(QuoteIdentifier_storeFunctionName(text));
		}
	}

	private void AddColumns(SqlSelectStatement selectStatement, Symbol symbol, List<Symbol> columnList, Dictionary<string, Symbol> columnDictionary, ref string separator)
	{
		if (symbol is JoinSymbol joinSymbol)
		{
			if (!joinSymbol.IsNestedJoin)
			{
				foreach (Symbol extent in joinSymbol.ExtentList)
				{
					if (extent.Type != null && !MetadataHelpers.IsPrimitiveType(extent.Type.EdmType))
					{
						AddColumns(selectStatement, extent, columnList, columnDictionary, ref separator);
					}
				}
				return;
			}
			{
				foreach (Symbol column in joinSymbol.ColumnList)
				{
					selectStatement.Select.Append(separator);
					selectStatement.Select.Append(symbol);
					selectStatement.Select.Append(".");
					selectStatement.Select.Append(column);
					if (columnDictionary.ContainsKey(column.Name))
					{
						columnDictionary[column.Name].NeedsRenaming = true;
						column.NeedsRenaming = true;
					}
					else
					{
						columnDictionary[column.Name] = column;
					}
					columnList.Add(column);
					separator = ", ";
				}
				return;
			}
		}
		if (symbol.OutputColumnsRenamed)
		{
			selectStatement.OutputColumnsRenamed = true;
			selectStatement.OutputColumns = new Dictionary<string, Symbol>();
		}
		if (symbol.Type == null || MetadataHelpers.IsPrimitiveType(symbol.Type.EdmType))
		{
			AddColumn(selectStatement, symbol, columnList, columnDictionary, ref separator, "X");
			return;
		}
		foreach (EdmProperty property in MetadataHelpers.GetProperties(symbol.Type))
		{
			AddColumn(selectStatement, symbol, columnList, columnDictionary, ref separator, property.Name);
		}
	}

	private void AddColumn(SqlSelectStatement selectStatement, Symbol symbol, List<Symbol> columnList, Dictionary<string, Symbol> columnDictionary, ref string separator, string columnName)
	{
		allColumnNames[columnName] = 0;
		if (!symbol.Columns.TryGetValue(columnName, out var value))
		{
			value = new Symbol(columnName, null);
			symbol.Columns.Add(columnName, value);
		}
		selectStatement.Select.Append(separator);
		selectStatement.Select.Append(symbol);
		selectStatement.Select.Append(".");
		if (symbol.OutputColumnsRenamed)
		{
			selectStatement.Select.Append(value);
			selectStatement.OutputColumns.Add(value.Name, value);
		}
		else
		{
			selectStatement.Select.Append(QuoteIdentifier(columnName));
		}
		selectStatement.Select.Append(" AS ");
		selectStatement.Select.Append(value);
		if (columnDictionary.ContainsKey(columnName))
		{
			columnDictionary[columnName].NeedsRenaming = true;
			value.NeedsRenaming = true;
		}
		else
		{
			columnDictionary[columnName] = symbol.Columns[columnName];
		}
		columnList.Add(value);
		separator = ", ";
	}

	private List<Symbol> AddDefaultColumns(SqlSelectStatement selectStatement)
	{
		List<Symbol> list = new List<Symbol>();
		Dictionary<string, Symbol> columnDictionary = new Dictionary<string, Symbol>(StringComparer.OrdinalIgnoreCase);
		string separator = "";
		if (!selectStatement.Select.IsEmpty)
		{
			separator = ", ";
		}
		foreach (Symbol fromExtent in selectStatement.FromExtents)
		{
			AddColumns(selectStatement, fromExtent, list, columnDictionary, ref separator);
		}
		return list;
	}

	private void AddFromSymbol(SqlSelectStatement selectStatement, string inputVarName, Symbol fromSymbol)
	{
		AddFromSymbol(selectStatement, inputVarName, fromSymbol, addToSymbolTable: true);
	}

	private void AddFromSymbol(SqlSelectStatement selectStatement, string inputVarName, Symbol fromSymbol, bool addToSymbolTable)
	{
		if (selectStatement.FromExtents.Count == 0 || fromSymbol != selectStatement.FromExtents[0])
		{
			selectStatement.FromExtents.Add(fromSymbol);
			selectStatement.From.Append(" ");
			selectStatement.From.Append(fromSymbol);
			allExtentNames[fromSymbol.Name] = 0;
		}
		if (addToSymbolTable)
		{
			symbolTable.Add(inputVarName, fromSymbol);
		}
	}

	private void AddSortKeys(SqlBuilder orderByClause, IList<DbSortClause> sortKeys)
	{
		string s = "";
		foreach (DbSortClause sortKey in sortKeys)
		{
			orderByClause.Append(s);
			orderByClause.Append(sortKey.Expression.Accept(this));
			if (!string.IsNullOrEmpty(sortKey.Collation))
			{
				orderByClause.Append(" COLLATE ");
				orderByClause.Append(sortKey.Collation);
			}
			orderByClause.Append(sortKey.Ascending ? " ASC" : " DESC");
			s = ", ";
		}
	}

	private SqlSelectStatement CreateNewSelectStatement(SqlSelectStatement oldStatement, string inputVarName, TypeUsage inputVarType, out Symbol fromSymbol)
	{
		return CreateNewSelectStatement(oldStatement, inputVarName, inputVarType, finalizeOldStatement: true, out fromSymbol);
	}

	private SqlSelectStatement CreateNewSelectStatement(SqlSelectStatement oldStatement, string inputVarName, TypeUsage inputVarType, bool finalizeOldStatement, out Symbol fromSymbol)
	{
		fromSymbol = null;
		if (finalizeOldStatement && oldStatement.Select.IsEmpty)
		{
			List<Symbol> columnList = AddDefaultColumns(oldStatement);
			if (oldStatement.FromExtents[0] is JoinSymbol joinSymbol)
			{
				JoinSymbol joinSymbol2 = new JoinSymbol(inputVarName, inputVarType, joinSymbol.ExtentList);
				joinSymbol2.IsNestedJoin = true;
				joinSymbol2.ColumnList = columnList;
				joinSymbol2.FlattenedExtentList = joinSymbol.FlattenedExtentList;
				fromSymbol = joinSymbol2;
			}
		}
		if (fromSymbol == null)
		{
			if (oldStatement.OutputColumnsRenamed)
			{
				fromSymbol = new Symbol(inputVarName, inputVarType, oldStatement.OutputColumns);
			}
			else
			{
				fromSymbol = new Symbol(inputVarName, inputVarType);
			}
		}
		SqlSelectStatement sqlSelectStatement = new SqlSelectStatement();
		sqlSelectStatement.From.Append("( ");
		sqlSelectStatement.From.Append(oldStatement);
		sqlSelectStatement.From.AppendLine();
		sqlSelectStatement.From.Append(") ");
		return sqlSelectStatement;
	}

	private static string EscapeSingleQuote(string s, bool isUnicode)
	{
		return (isUnicode ? "N'" : "'") + s.Replace("'", "''") + "'";
	}

	internal string GetSqlPrimitiveType(TypeUsage type)
	{
		return GetSqlPrimitiveType(_providerManifest, _sqlVersion, type);
	}

	internal static string GetSqlPrimitiveType(DbProviderManifest providerManifest, EFOracleVersion sqlVersion, TypeUsage type)
	{
		TypeUsage storeType = providerManifest.GetStoreType(type);
		string text = storeType.EdmType.Name;
		int maxLength = 0;
		byte precision = 0;
		byte scale = 0;
		switch (((PrimitiveType)storeType.EdmType).PrimitiveTypeKind)
		{
		case PrimitiveTypeKind.Binary:
			if (!MetadataHelpers.IsFacetValueConstant(storeType, "MaxLength"))
			{
				text = "blob";
			}
			break;
		case PrimitiveTypeKind.String:
			if (!MetadataHelpers.IsFacetValueConstant(storeType, "MaxLength"))
			{
				MetadataHelpers.TryGetMaxLength(storeType, out maxLength);
				text = text + "(" + maxLength.ToString(CultureInfo.InvariantCulture) + ")";
			}
			break;
		case PrimitiveTypeKind.DateTime:
		case PrimitiveTypeKind.Time:
		{
			text = ((!MetadataHelpers.TryGetByteFacetValue(type, "Precision", out var byteValue)) ? "date" : ((byteValue <= 9) ? "timestamp" : "timestamp with local time zone"));
			break;
		}
		case PrimitiveTypeKind.DateTimeOffset:
			text = "timestamp with time zone";
			break;
		case PrimitiveTypeKind.Decimal:
			if (!MetadataHelpers.IsFacetValueConstant(storeType, "Precision"))
			{
				MetadataHelpers.TryGetPrecision(storeType, out precision);
				MetadataHelpers.TryGetScale(storeType, out scale);
				text = text + "(" + precision + "," + scale + ")";
			}
			break;
		case PrimitiveTypeKind.Boolean:
			text = "number(1,0)";
			break;
		case PrimitiveTypeKind.Guid:
			text = "raw(16)";
			break;
		case PrimitiveTypeKind.Single:
			text = ((sqlVersion >= EFOracleVersion.Oracle10gR1) ? "binary_float" : "number");
			break;
		case PrimitiveTypeKind.Double:
			text = ((sqlVersion >= EFOracleVersion.Oracle10gR1) ? "binary_double" : "number");
			break;
		}
		return text;
	}

	private ISqlFragment HandleCountExpression(DbExpression e)
	{
		if (e.ExpressionKind == DbExpressionKind.Constant)
		{
			SqlBuilder sqlBuilder = new SqlBuilder();
			sqlBuilder.Append(((DbConstantExpression)e).Value.ToString());
			return sqlBuilder;
		}
		return e.Accept(this);
	}

	private static bool IsApplyExpression(DbExpression e)
	{
		if (DbExpressionKind.CrossApply != e.ExpressionKind)
		{
			return DbExpressionKind.OuterApply == e.ExpressionKind;
		}
		return true;
	}

	private static bool IsJoinExpression(DbExpression e)
	{
		if (DbExpressionKind.CrossJoin != e.ExpressionKind && DbExpressionKind.FullOuterJoin != e.ExpressionKind && DbExpressionKind.InnerJoin != e.ExpressionKind)
		{
			return DbExpressionKind.LeftOuterJoin == e.ExpressionKind;
		}
		return true;
	}

	private static bool IsComplexExpression(DbExpression e)
	{
		DbExpressionKind expressionKind = e.ExpressionKind;
		if (expressionKind == DbExpressionKind.Constant || expressionKind == DbExpressionKind.ParameterReference || expressionKind == DbExpressionKind.Property)
		{
			return false;
		}
		return true;
	}

	private static bool IsCompatible(SqlSelectStatement result, DbExpressionKind expressionKind)
	{
		switch (expressionKind)
		{
		case DbExpressionKind.Distinct:
			if (result.Top == null)
			{
				return result.OrderBy.IsEmpty;
			}
			return false;
		case DbExpressionKind.Filter:
			if (result.Select.IsEmpty && result.Where.IsEmpty && result.GroupBy.IsEmpty)
			{
				return result.Top == null;
			}
			return false;
		case DbExpressionKind.GroupBy:
			if (result.Select.IsEmpty && result.GroupBy.IsEmpty && result.OrderBy.IsEmpty)
			{
				return result.Top == null;
			}
			return false;
		case DbExpressionKind.Element:
		case DbExpressionKind.Limit:
			return result.Top == null;
		case DbExpressionKind.Project:
			if (result.Select.IsEmpty && result.GroupBy.IsEmpty)
			{
				return !result.IsDistinct;
			}
			return false;
		case DbExpressionKind.Skip:
			if (result.Select.IsEmpty && result.GroupBy.IsEmpty && result.OrderBy.IsEmpty)
			{
				return !result.IsDistinct;
			}
			return false;
		case DbExpressionKind.Sort:
			if (result.Select.IsEmpty && result.GroupBy.IsEmpty && result.OrderBy.IsEmpty)
			{
				return !result.IsDistinct;
			}
			return false;
		default:
			throw new InvalidOperationException(string.Empty);
		}
	}

	internal static string QuoteIdentifier(string name)
	{
		return "\"" + name.Replace("\"", "\"\"") + "\"";
	}

	internal static string QuoteIdentifier_storeFunctionName(string name)
	{
		if (name.Contains("."))
		{
			int num = 0;
			int num2;
			for (num2 = name.IndexOf("."); num2 != -1; num2 = name.IndexOf(".", num2 + 1))
			{
				num++;
			}
			if (num == 1)
			{
				return "\"" + name.Replace(".", "\".\"") + "\"";
			}
			num2 = name.LastIndexOf(".");
			string text = name.Substring(0, num2);
			return "\"" + text + "\".\"" + name.Substring(num2 + 1) + "\"";
		}
		return "\"" + name + "\"";
	}

	private SqlSelectStatement VisitExpressionEnsureSqlStatement(DbExpression e)
	{
		return VisitExpressionEnsureSqlStatement(e, addDefaultColumns: true);
	}

	private SqlSelectStatement VisitExpressionEnsureSqlStatement(DbExpression e, bool addDefaultColumns)
	{
		SqlSelectStatement sqlSelectStatement;
		switch (e.ExpressionKind)
		{
		case DbExpressionKind.Filter:
		case DbExpressionKind.GroupBy:
		case DbExpressionKind.Project:
		case DbExpressionKind.Sort:
			sqlSelectStatement = e.Accept(this) as SqlSelectStatement;
			break;
		default:
		{
			string inputVarName = "c";
			symbolTable.EnterScope();
			TypeUsage typeUsage = null;
			switch (e.ExpressionKind)
			{
			case DbExpressionKind.CrossApply:
			case DbExpressionKind.CrossJoin:
			case DbExpressionKind.FullOuterJoin:
			case DbExpressionKind.InnerJoin:
			case DbExpressionKind.LeftOuterJoin:
			case DbExpressionKind.OuterApply:
			case DbExpressionKind.Scan:
				typeUsage = MetadataHelpers.GetElementTypeUsage(e.ResultType);
				break;
			default:
				typeUsage = MetadataHelpers.GetEdmType<CollectionType>(e.ResultType).TypeUsage;
				break;
			}
			sqlSelectStatement = VisitInputExpression(e, inputVarName, typeUsage, out var fromSymbol);
			AddFromSymbol(sqlSelectStatement, inputVarName, fromSymbol);
			symbolTable.ExitScope();
			break;
		}
		}
		if (addDefaultColumns && sqlSelectStatement.Select.IsEmpty)
		{
			AddDefaultColumns(sqlSelectStatement);
		}
		return sqlSelectStatement;
	}

	private SqlSelectStatement VisitFilterExpression(DbExpressionBinding input, DbExpression predicate, bool negatePredicate)
	{
		Symbol fromSymbol;
		SqlSelectStatement sqlSelectStatement = VisitInputExpression(input.Expression, input.VariableName, input.VariableType, out fromSymbol);
		if (!IsCompatible(sqlSelectStatement, DbExpressionKind.Filter))
		{
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, input.VariableName, input.VariableType, out fromSymbol);
		}
		selectStatementStack.Push(sqlSelectStatement);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement, input.VariableName, fromSymbol);
		if (negatePredicate)
		{
			sqlSelectStatement.Where.Append("NOT (");
		}
		sqlSelectStatement.Where.Append(predicate.Accept(this));
		if (negatePredicate)
		{
			sqlSelectStatement.Where.Append(")");
		}
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		return sqlSelectStatement;
	}

	private static void WrapNonQueryExtent(SqlSelectStatement result, ISqlFragment sqlFragment, DbExpressionKind expressionKind)
	{
		if (expressionKind == DbExpressionKind.Function)
		{
			result.From.Append(sqlFragment);
			return;
		}
		result.From.Append(" (");
		result.From.Append(sqlFragment);
		result.From.Append(")");
	}

	private static bool IsBuiltInStoreFunction(EdmFunction function)
	{
		if (MetadataHelpers.GetMetadataProperty<bool>(function, "BuiltInAttribute"))
		{
			return !MetadataHelpers.IsCanonicalFunction(function);
		}
		return false;
	}

	private static string ByteArrayToBinaryString(byte[] binaryArray)
	{
		StringBuilder stringBuilder = new StringBuilder(binaryArray.Length * 2);
		for (int i = 0; i < binaryArray.Length; i++)
		{
			stringBuilder.Append(hexDigits[(binaryArray[i] & 0xF0) >> 4]).Append(hexDigits[binaryArray[i] & 0xF]);
		}
		return stringBuilder.ToString();
	}

	private static bool GroupByAggregatesNeedInnerQuery(IList<DbAggregate> aggregates)
	{
		foreach (DbAggregate aggregate in aggregates)
		{
			if (GroupByAggregateNeedsInnerQuery(aggregate.Arguments[0]))
			{
				return true;
			}
		}
		return false;
	}

	private static bool GroupByAggregateNeedsInnerQuery(DbExpression expression)
	{
		if (expression.ExpressionKind == DbExpressionKind.Constant)
		{
			return false;
		}
		if (expression.ExpressionKind == DbExpressionKind.Cast)
		{
			DbCastExpression dbCastExpression = (DbCastExpression)expression;
			return GroupByAggregateNeedsInnerQuery(dbCastExpression.Argument);
		}
		if (expression.ExpressionKind == DbExpressionKind.Property)
		{
			DbPropertyExpression dbPropertyExpression = (DbPropertyExpression)expression;
			return GroupByAggregateNeedsInnerQuery(dbPropertyExpression.Instance);
		}
		if (expression.ExpressionKind == DbExpressionKind.VariableReference)
		{
			return false;
		}
		return true;
	}

	private static bool GroupByKeysNeedInnerQuery(IList<DbExpression> keys, string inputVarRefName)
	{
		foreach (DbExpression key in keys)
		{
			if (GroupByKeyNeedsInnerQuery(key, inputVarRefName))
			{
				return true;
			}
		}
		return false;
	}

	private static bool GroupByKeyNeedsInnerQuery(DbExpression expression, string inputVarRefName)
	{
		if (expression.ExpressionKind == DbExpressionKind.Cast)
		{
			DbCastExpression dbCastExpression = (DbCastExpression)expression;
			return GroupByKeyNeedsInnerQuery(dbCastExpression.Argument, inputVarRefName);
		}
		if (expression.ExpressionKind == DbExpressionKind.Property)
		{
			DbPropertyExpression dbPropertyExpression = (DbPropertyExpression)expression;
			return GroupByKeyNeedsInnerQuery(dbPropertyExpression.Instance, inputVarRefName);
		}
		if (expression.ExpressionKind == DbExpressionKind.VariableReference)
		{
			DbVariableReferenceExpression dbVariableReferenceExpression = expression as DbVariableReferenceExpression;
			return !dbVariableReferenceExpression.VariableName.Equals(inputVarRefName);
		}
		return true;
	}

	private void Assert10gOrNewer(PrimitiveTypeKind primitiveTypeKind)
	{
		Assert10gOrNewer(_sqlVersion, primitiveTypeKind);
	}

	private static void Assert10gOrNewer(EFOracleVersion _sqlVersion, PrimitiveTypeKind primitiveTypeKind)
	{
		if (_sqlVersion < EFOracleVersion.Oracle10gR1)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, primitiveTypeKind.ToString()));
		}
	}

	private void Assert10gOrNewer(DbFunctionExpression e)
	{
		if (IsPre10g)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, e.Function.Name));
		}
	}
}
