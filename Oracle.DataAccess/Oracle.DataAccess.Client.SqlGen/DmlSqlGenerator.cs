using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Data.Common.Utils;
using System.Data.Metadata.Edm;
using System.Globalization;
using System.Text;

namespace Oracle.DataAccess.Client.SqlGen;

internal static class DmlSqlGenerator
{
	private class ExpressionTranslator : BasicExpressionVisitor
	{
		private readonly StringBuilder _commandText;

		private readonly DbModificationCommandTree _commandTree;

		private readonly List<OracleParameter> _parameters;

		private readonly Dictionary<EdmMember, OracleParameter> _memberValues;

		private readonly EFOracleVersion _version;

		private int parameterNameCount;

		internal List<OracleParameter> Parameters => _parameters;

		internal Dictionary<EdmMember, OracleParameter> MemberValues => _memberValues;

		internal ExpressionTranslator(StringBuilder commandText, DbModificationCommandTree commandTree, bool preserveMemberValues, EFOracleVersion version)
		{
			_commandText = commandText;
			_commandTree = commandTree;
			_version = version;
			_parameters = new List<OracleParameter>();
			_memberValues = (preserveMemberValues ? new Dictionary<EdmMember, OracleParameter>() : null);
		}

		internal OracleParameter CreateParameter(OracleDbType oracleType, ParameterDirection direction)
		{
			OracleParameter oracleParameter = new OracleParameter();
			oracleParameter.ParameterName = NextName();
			oracleParameter.OracleDbType = oracleType;
			oracleParameter.Direction = direction;
			_parameters.Add(oracleParameter);
			return oracleParameter;
		}

		internal OracleParameter CreateParameter(object value, TypeUsage type)
		{
			OracleParameter oracleParameter = EFOracleProviderServices.CreateOracleParameter(NextName(), type, ParameterMode.In, value, _version);
			_parameters.Add(oracleParameter);
			return oracleParameter;
		}

		private string NextName()
		{
			string result = ":p" + parameterNameCount.ToString(CultureInfo.InvariantCulture);
			parameterNameCount++;
			return result;
		}

		public override void Visit(DbAndExpression expression)
		{
			VisitBinary(expression, " and ");
		}

		public override void Visit(DbOrExpression expression)
		{
			VisitBinary(expression, " or ");
		}

		public override void Visit(DbComparisonExpression expression)
		{
			VisitBinary(expression, " = ");
			RegisterMemberValue(expression.Left, expression.Right);
		}

		internal void RegisterMemberValue(DbExpression propertyExpression, DbExpression value)
		{
			if (_memberValues != null)
			{
				EdmMember property = ((DbPropertyExpression)propertyExpression).Property;
				if (value.ExpressionKind != DbExpressionKind.Null)
				{
					_memberValues[property] = _parameters[_parameters.Count - 1];
				}
			}
		}

		public override void Visit(DbIsNullExpression expression)
		{
			expression.Argument.Accept(this);
			_commandText.Append(" is null");
		}

		public override void Visit(DbNotExpression expression)
		{
			_commandText.Append("not (");
			expression.Accept(this);
			_commandText.Append(")");
		}

		public override void Visit(DbConstantExpression expression)
		{
			OracleParameter oracleParameter = CreateParameter(expression.Value, expression.ResultType);
			_commandText.Append(oracleParameter.ParameterName);
		}

		public override void Visit(DbScanExpression expression)
		{
			string metadataProperty = MetadataHelpers.GetMetadataProperty<string>(expression.Target, "DefiningQuery");
			if (metadataProperty != null)
			{
				if (!(_commandTree is DbDeleteCommandTree))
				{
					_ = _commandTree is DbInsertCommandTree;
				}
				throw new InvalidOperationException();
			}
			_commandText.Append(SqlGenerator.GetTargetTSql(expression.Target));
		}

		public override void Visit(DbPropertyExpression expression)
		{
			_commandText.Append(GenerateMemberTSql(expression.Property));
		}

		public override void Visit(DbNullExpression expression)
		{
			_commandText.Append("null");
		}

		public override void Visit(DbNewInstanceExpression expression)
		{
			bool flag = true;
			foreach (DbExpression argument in expression.Arguments)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					_commandText.Append(", ");
				}
				argument.Accept(this);
			}
		}

		private void VisitBinary(DbBinaryExpression expression, string separator)
		{
			_commandText.Append("(");
			expression.Left.Accept(this);
			_commandText.Append(separator);
			expression.Right.Accept(this);
			_commandText.Append(")");
		}
	}

	private const int s_commandTextBuilderInitialCapacity = 256;

	internal static string GenerateUpdateSql(DbUpdateCommandTree tree, EFOracleProviderManifest providerManifest, EFOracleVersion sqlVersion, out List<OracleParameter> parameters)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		ExpressionTranslator expressionTranslator = new ExpressionTranslator(stringBuilder, tree, null != tree.Returning, sqlVersion);
		if (tree.SetClauses.Count == 0)
		{
			stringBuilder.AppendLine("declare :p int");
		}
		stringBuilder.Append("update ");
		tree.Target.Expression.Accept(expressionTranslator);
		stringBuilder.AppendLine();
		bool flag = true;
		stringBuilder.Append("set ");
		foreach (DbSetClause setClause in tree.SetClauses)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				stringBuilder.Append(", ");
			}
			setClause.Property.Accept(expressionTranslator);
			stringBuilder.Append(" = ");
			setClause.Value.Accept(expressionTranslator);
		}
		if (flag)
		{
			stringBuilder.Append(":p = 0");
		}
		stringBuilder.AppendLine();
		stringBuilder.Append("where ");
		tree.Predicate.Accept(expressionTranslator);
		stringBuilder.AppendLine();
		GenerateReturningSql(stringBuilder, tree, expressionTranslator, tree.Returning, providerManifest, sqlVersion);
		parameters = expressionTranslator.Parameters;
		return stringBuilder.ToString();
	}

	internal static string GenerateDeleteSql(DbDeleteCommandTree tree, EFOracleProviderManifest providerManifest, EFOracleVersion sqlVersion, out List<OracleParameter> parameters)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		ExpressionTranslator expressionTranslator = new ExpressionTranslator(stringBuilder, tree, preserveMemberValues: false, sqlVersion);
		stringBuilder.Append("delete ");
		tree.Target.Expression.Accept(expressionTranslator);
		stringBuilder.AppendLine();
		stringBuilder.Append("where ");
		tree.Predicate.Accept(expressionTranslator);
		parameters = expressionTranslator.Parameters;
		return stringBuilder.ToString();
	}

	internal static string GenerateInsertSql(DbInsertCommandTree tree, EFOracleProviderManifest providerManifest, EFOracleVersion sqlVersion, out List<OracleParameter> parameters)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		ExpressionTranslator expressionTranslator = new ExpressionTranslator(stringBuilder, tree, null != tree.Returning, sqlVersion);
		stringBuilder.Append("insert into ");
		tree.Target.Expression.Accept(expressionTranslator);
		if (0 < tree.SetClauses.Count)
		{
			stringBuilder.Append("(");
			bool flag = true;
			foreach (DbSetClause setClause in tree.SetClauses)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append(", ");
				}
				setClause.Property.Accept(expressionTranslator);
			}
			stringBuilder.AppendLine(")");
			flag = true;
			stringBuilder.Append("values (");
			foreach (DbSetClause setClause2 in tree.SetClauses)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append(", ");
				}
				setClause2.Value.Accept(expressionTranslator);
				expressionTranslator.RegisterMemberValue(setClause2.Property, setClause2.Value);
			}
			stringBuilder.AppendLine(")");
		}
		else
		{
			stringBuilder.AppendLine().AppendLine("default values");
		}
		GenerateReturningSql(stringBuilder, tree, expressionTranslator, tree.Returning, providerManifest, sqlVersion);
		parameters = expressionTranslator.Parameters;
		return stringBuilder.ToString();
	}

	private static string GenerateMemberTSql(EdmMember member)
	{
		return SqlGenerator.QuoteIdentifier(member.Name);
	}

	private static void GenerateReturningSql(StringBuilder commandText, DbModificationCommandTree tree, ExpressionTranslator translator, DbExpression returning, EFOracleProviderManifest providerManifest, EFOracleVersion sqlVersion)
	{
		if (returning == null)
		{
			return;
		}
		EntitySetBase target = ((DbScanExpression)tree.Target.Expression).Target;
		StringBuilder stringBuilder = new StringBuilder(50);
		stringBuilder.Append("declare\n");
		foreach (EdmMember keyMember in target.ElementType.KeyMembers)
		{
			stringBuilder.Append(GenerateMemberTSql(keyMember));
			stringBuilder.Append(" ");
			stringBuilder.Append(SqlGenerator.GetSqlPrimitiveType(providerManifest, sqlVersion, keyMember.TypeUsage));
			stringBuilder.Append(";\n");
		}
		stringBuilder.Append("begin\n");
		commandText.Insert(0, stringBuilder.ToString());
		OracleParameter oracleParameter = translator.CreateParameter(OracleDbType.RefCursor, ParameterDirection.Output);
		commandText.Append("returning\n");
		string value = string.Empty;
		foreach (EdmMember keyMember2 in target.ElementType.KeyMembers)
		{
			commandText.Append(value);
			commandText.Append(GenerateMemberTSql(keyMember2));
			value = ", ";
		}
		commandText.Append(" into\n");
		value = string.Empty;
		foreach (EdmMember keyMember3 in target.ElementType.KeyMembers)
		{
			commandText.Append(value);
			commandText.Append(GenerateMemberTSql(keyMember3));
			value = ", ";
		}
		commandText.Append(";\n");
		commandText.Append("open ");
		commandText.Append(oracleParameter.ParameterName);
		commandText.Append(" for select\n");
		value = string.Empty;
		foreach (EdmMember keyMember4 in target.ElementType.KeyMembers)
		{
			commandText.Append(value);
			commandText.Append(GenerateMemberTSql(keyMember4));
			commandText.Append(" as ");
			commandText.Append(GenerateMemberTSql(keyMember4));
			value = ", ";
		}
		commandText.Append(" from dual;\n");
		commandText.Append("end;");
	}

	private static bool IsValidIdentityColumnType(TypeUsage typeUsage)
	{
		if (typeUsage.EdmType.BuiltInTypeKind != BuiltInTypeKind.PrimitiveType)
		{
			return false;
		}
		switch (typeUsage.EdmType.Name)
		{
		case "tinyint":
		case "smallint":
		case "int":
		case "bigint":
			return true;
		case "decimal":
		case "numeric":
		{
			if (typeUsage.Facets.TryGetValue("Scale", ignoreCase: false, out var item))
			{
				return Convert.ToInt32(item.Value, CultureInfo.InvariantCulture) == 0;
			}
			return false;
		}
		default:
			return false;
		}
	}
}
