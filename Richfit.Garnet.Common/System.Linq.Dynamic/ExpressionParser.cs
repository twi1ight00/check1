using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Linq.Dynamic;

/// <summary>
/// ExpressionParser
/// </summary>
internal class ExpressionParser
{
	/// <summary>
	/// Token
	/// </summary>
	private struct Token
	{
		public TokenId id;

		public string text;

		public int pos;
	}

	/// <summary>
	/// TokenId
	/// </summary>
	private enum TokenId
	{
		Unknown,
		End,
		Identifier,
		StringLiteral,
		IntegerLiteral,
		RealLiteral,
		Exclamation,
		Percent,
		Amphersand,
		OpenParen,
		CloseParen,
		Asterisk,
		Plus,
		Comma,
		Minus,
		Dot,
		Slash,
		Colon,
		LessThan,
		Equal,
		GreaterThan,
		Question,
		OpenBracket,
		CloseBracket,
		Bar,
		ExclamationEqual,
		DoubleAmphersand,
		LessThanEqual,
		LessGreater,
		DoubleEqual,
		GreaterThanEqual,
		DoubleBar
	}

	/// <summary>
	/// ILogicalSignatures
	/// </summary>
	private interface ILogicalSignatures
	{
		void F(bool x, bool y);

		void F(bool? x, bool? y);
	}

	/// <summary>
	/// IArithmeticSignatures
	/// </summary>
	private interface IArithmeticSignatures
	{
		void F(int x, int y);

		void F(uint x, uint y);

		void F(long x, long y);

		void F(ulong x, ulong y);

		void F(float x, float y);

		void F(double x, double y);

		void F(decimal x, decimal y);

		void F(int? x, int? y);

		void F(uint? x, uint? y);

		void F(long? x, long? y);

		void F(ulong? x, ulong? y);

		void F(float? x, float? y);

		void F(double? x, double? y);

		void F(decimal? x, decimal? y);
	}

	private interface IRelationalSignatures : IArithmeticSignatures
	{
		void F(string x, string y);

		void F(char x, char y);

		void F(DateTime x, DateTime y);

		void F(TimeSpan x, TimeSpan y);

		void F(char? x, char? y);

		void F(DateTime? x, DateTime? y);

		void F(TimeSpan? x, TimeSpan? y);
	}

	private interface IEqualitySignatures : IRelationalSignatures, IArithmeticSignatures
	{
		void F(bool x, bool y);

		void F(bool? x, bool? y);
	}

	private interface IAddSignatures : IArithmeticSignatures
	{
		void F(DateTime x, TimeSpan y);

		void F(TimeSpan x, TimeSpan y);

		void F(DateTime? x, TimeSpan? y);

		void F(TimeSpan? x, TimeSpan? y);
	}

	private interface ISubtractSignatures : IAddSignatures, IArithmeticSignatures
	{
		void F(DateTime x, DateTime y);

		void F(DateTime? x, DateTime? y);
	}

	private interface INegationSignatures
	{
		void F(int x);

		void F(long x);

		void F(float x);

		void F(double x);

		void F(decimal x);

		void F(int? x);

		void F(long? x);

		void F(float? x);

		void F(double? x);

		void F(decimal? x);
	}

	private interface INotSignatures
	{
		void F(bool x);

		void F(bool? x);
	}

	private interface IEnumerableSignatures
	{
		void Where(bool predicate);

		void Any();

		void Any(bool predicate);

		void All(bool predicate);

		void Count();

		void Count(bool predicate);

		void Min(object selector);

		void Max(object selector);

		void Sum(int selector);

		void Sum(int? selector);

		void Sum(long selector);

		void Sum(long? selector);

		void Sum(float selector);

		void Sum(float? selector);

		void Sum(double selector);

		void Sum(double? selector);

		void Sum(decimal selector);

		void Sum(decimal? selector);

		void Average(int selector);

		void Average(int? selector);

		void Average(long selector);

		void Average(long? selector);

		void Average(float selector);

		void Average(float? selector);

		void Average(double selector);

		void Average(double? selector);

		void Average(decimal selector);

		void Average(decimal? selector);
	}

	private class MethodData
	{
		public MethodBase MethodBase;

		public ParameterInfo[] Parameters;

		public Expression[] Args;
	}

	private static readonly Type[] predefinedTypes = new Type[20]
	{
		typeof(object),
		typeof(bool),
		typeof(char),
		typeof(string),
		typeof(sbyte),
		typeof(byte),
		typeof(short),
		typeof(ushort),
		typeof(int),
		typeof(uint),
		typeof(long),
		typeof(ulong),
		typeof(float),
		typeof(double),
		typeof(decimal),
		typeof(DateTime),
		typeof(TimeSpan),
		typeof(Guid),
		typeof(Math),
		typeof(Convert)
	};

	private static readonly Expression trueLiteral = Expression.Constant(true);

	private static readonly Expression falseLiteral = Expression.Constant(false);

	private static readonly Expression nullLiteral = Expression.Constant(null);

	private static readonly string keywordIt = "it";

	private static readonly string keywordIif = "iif";

	private static readonly string keywordNew = "new";

	private static Dictionary<string, object> keywords;

	private Dictionary<string, object> symbols;

	private IDictionary<string, object> externals;

	private Dictionary<Expression, string> literals;

	private ParameterExpression it;

	private string text;

	private int textPos;

	private int textLen;

	private char ch;

	private Token token;

	public ExpressionParser(ParameterExpression[] parameters, string expression, object[] values)
	{
		if (expression == null)
		{
			throw new ArgumentNullException("expression");
		}
		if (keywords == null)
		{
			keywords = CreateKeywords();
		}
		symbols = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		literals = new Dictionary<Expression, string>();
		if (parameters != null)
		{
			ProcessParameters(parameters);
		}
		if (values != null)
		{
			ProcessValues(values);
		}
		text = expression;
		textLen = text.Length;
		SetTextPos(0);
		NextToken();
	}

	private void ProcessParameters(ParameterExpression[] parameters)
	{
		foreach (ParameterExpression pe in parameters)
		{
			if (!string.IsNullOrEmpty(pe.Name))
			{
				AddSymbol(pe.Name, pe);
			}
		}
		if (parameters.Length == 1 && string.IsNullOrEmpty(parameters[0].Name))
		{
			it = parameters[0];
		}
	}

	private void ProcessValues(object[] values)
	{
		for (int i = 0; i < values.Length; i++)
		{
			object value = values[i];
			if (i == values.Length - 1 && value is IDictionary<string, object>)
			{
				externals = (IDictionary<string, object>)value;
			}
			else
			{
				AddSymbol("@" + i.ToString(CultureInfo.InvariantCulture), value);
			}
		}
	}

	private void AddSymbol(string name, object value)
	{
		if (symbols.ContainsKey(name))
		{
			throw ParseError("The identifier '{0}' was defined more than once", name);
		}
		symbols.Add(name, value);
	}

	public Expression Parse(Type resultType)
	{
		int exprPos = token.pos;
		Expression expr = ParseExpression();
		if (resultType != null && (expr = PromoteExpression(expr, resultType, exact: true)) == null)
		{
			throw ParseError(exprPos, "Expression of type '{0}' expected", GetTypeName(resultType));
		}
		ValidateToken(TokenId.End, "Syntax error");
		return expr;
	}

	public IEnumerable<DynamicOrdering> ParseOrdering()
	{
		List<DynamicOrdering> orderings = new List<DynamicOrdering>();
		while (true)
		{
			bool flag = true;
			Expression expr = ParseExpression();
			bool ascending = true;
			if (TokenIdentifierIs("asc") || TokenIdentifierIs("ascending"))
			{
				NextToken();
			}
			else if (TokenIdentifierIs("desc") || TokenIdentifierIs("descending"))
			{
				NextToken();
				ascending = false;
			}
			orderings.Add(new DynamicOrdering
			{
				Selector = expr,
				Ascending = ascending
			});
			if (token.id != TokenId.Comma)
			{
				break;
			}
			NextToken();
		}
		ValidateToken(TokenId.End, "Syntax error");
		return orderings;
	}

	private Expression ParseExpression()
	{
		int errorPos = token.pos;
		Expression expr = ParseLogicalOr();
		if (token.id == TokenId.Question)
		{
			NextToken();
			Expression expr2 = ParseExpression();
			ValidateToken(TokenId.Colon, "':' expected");
			NextToken();
			Expression expr3 = ParseExpression();
			expr = GenerateConditional(expr, expr2, expr3, errorPos);
		}
		return expr;
	}

	private Expression ParseLogicalOr()
	{
		Expression left = ParseLogicalAnd();
		while (token.id == TokenId.DoubleBar || TokenIdentifierIs("or"))
		{
			Token op = token;
			NextToken();
			Expression right = ParseLogicalAnd();
			CheckAndPromoteOperands(typeof(ILogicalSignatures), op.text, ref left, ref right, op.pos);
			left = Expression.OrElse(left, right);
		}
		return left;
	}

	private Expression ParseLogicalAnd()
	{
		Expression left = ParseComparison();
		while (token.id == TokenId.DoubleAmphersand || TokenIdentifierIs("and"))
		{
			Token op = token;
			NextToken();
			Expression right = ParseComparison();
			CheckAndPromoteOperands(typeof(ILogicalSignatures), op.text, ref left, ref right, op.pos);
			left = Expression.AndAlso(left, right);
		}
		return left;
	}

	private Expression ParseComparison()
	{
		Expression left = ParseAdditive();
		while (token.id == TokenId.Equal || token.id == TokenId.DoubleEqual || token.id == TokenId.ExclamationEqual || token.id == TokenId.LessGreater || token.id == TokenId.GreaterThan || token.id == TokenId.GreaterThanEqual || token.id == TokenId.LessThan || token.id == TokenId.LessThanEqual)
		{
			Token op = token;
			NextToken();
			Expression right = ParseAdditive();
			bool isEquality = op.id == TokenId.Equal || op.id == TokenId.DoubleEqual || op.id == TokenId.ExclamationEqual || op.id == TokenId.LessGreater;
			if (isEquality && !left.Type.IsValueType && !right.Type.IsValueType)
			{
				if (left.Type != right.Type)
				{
					if (left.Type.IsAssignableFrom(right.Type))
					{
						right = Expression.Convert(right, left.Type);
					}
					else
					{
						if (!right.Type.IsAssignableFrom(left.Type))
						{
							throw IncompatibleOperandsError(op.text, left, right, op.pos);
						}
						left = Expression.Convert(left, right.Type);
					}
				}
			}
			else if (IsEnumType(left.Type) || IsEnumType(right.Type))
			{
				if (left.Type != right.Type)
				{
					Expression e;
					if ((e = PromoteExpression(right, left.Type, exact: true)) != null)
					{
						right = e;
					}
					else
					{
						if ((e = PromoteExpression(left, right.Type, exact: true)) == null)
						{
							throw IncompatibleOperandsError(op.text, left, right, op.pos);
						}
						left = e;
					}
				}
			}
			else
			{
				CheckAndPromoteOperands(isEquality ? typeof(IEqualitySignatures) : typeof(IRelationalSignatures), op.text, ref left, ref right, op.pos);
			}
			switch (op.id)
			{
			case TokenId.Equal:
			case TokenId.DoubleEqual:
				left = GenerateEqual(left, right);
				break;
			case TokenId.ExclamationEqual:
			case TokenId.LessGreater:
				left = GenerateNotEqual(left, right);
				break;
			case TokenId.GreaterThan:
				left = GenerateGreaterThan(left, right);
				break;
			case TokenId.GreaterThanEqual:
				left = GenerateGreaterThanEqual(left, right);
				break;
			case TokenId.LessThan:
				left = GenerateLessThan(left, right);
				break;
			case TokenId.LessThanEqual:
				left = GenerateLessThanEqual(left, right);
				break;
			}
		}
		return left;
	}

	private Expression ParseAdditive()
	{
		Expression left = ParseMultiplicative();
		while (token.id == TokenId.Plus || token.id == TokenId.Minus || token.id == TokenId.Amphersand)
		{
			Token op = token;
			NextToken();
			Expression right = ParseMultiplicative();
			switch (op.id)
			{
			case TokenId.Plus:
				if (left.Type == typeof(string) || right.Type == typeof(string))
				{
					break;
				}
				CheckAndPromoteOperands(typeof(IAddSignatures), op.text, ref left, ref right, op.pos);
				left = GenerateAdd(left, right);
				continue;
			case TokenId.Minus:
				CheckAndPromoteOperands(typeof(ISubtractSignatures), op.text, ref left, ref right, op.pos);
				left = GenerateSubtract(left, right);
				continue;
			case TokenId.Amphersand:
				break;
			default:
				continue;
			}
			left = GenerateStringConcat(left, right);
		}
		return left;
	}

	private Expression ParseMultiplicative()
	{
		Expression left = ParseUnary();
		while (token.id == TokenId.Asterisk || token.id == TokenId.Slash || token.id == TokenId.Percent || TokenIdentifierIs("mod"))
		{
			Token op = token;
			NextToken();
			Expression right = ParseUnary();
			CheckAndPromoteOperands(typeof(IArithmeticSignatures), op.text, ref left, ref right, op.pos);
			switch (op.id)
			{
			case TokenId.Asterisk:
				left = Expression.Multiply(left, right);
				break;
			case TokenId.Slash:
				left = Expression.Divide(left, right);
				break;
			case TokenId.Identifier:
			case TokenId.Percent:
				left = Expression.Modulo(left, right);
				break;
			}
		}
		return left;
	}

	private Expression ParseUnary()
	{
		if (token.id == TokenId.Minus || token.id == TokenId.Exclamation || TokenIdentifierIs("not"))
		{
			Token op = token;
			NextToken();
			if (op.id == TokenId.Minus && (token.id == TokenId.IntegerLiteral || token.id == TokenId.RealLiteral))
			{
				token.text = "-" + token.text;
				token.pos = op.pos;
				return ParsePrimary();
			}
			Expression expr = ParseUnary();
			if (op.id == TokenId.Minus)
			{
				CheckAndPromoteOperand(typeof(INegationSignatures), op.text, ref expr, op.pos);
				expr = Expression.Negate(expr);
			}
			else
			{
				CheckAndPromoteOperand(typeof(INotSignatures), op.text, ref expr, op.pos);
				expr = Expression.Not(expr);
			}
			return expr;
		}
		return ParsePrimary();
	}

	private Expression ParsePrimary()
	{
		Expression expr = ParsePrimaryStart();
		while (true)
		{
			bool flag = true;
			if (token.id == TokenId.Dot)
			{
				NextToken();
				expr = ParseMemberAccess(null, expr);
				continue;
			}
			if (token.id == TokenId.OpenBracket)
			{
				expr = ParseElementAccess(expr);
				continue;
			}
			break;
		}
		return expr;
	}

	private Expression ParsePrimaryStart()
	{
		return token.id switch
		{
			TokenId.Identifier => ParseIdentifier(), 
			TokenId.StringLiteral => ParseStringLiteral(), 
			TokenId.IntegerLiteral => ParseIntegerLiteral(), 
			TokenId.RealLiteral => ParseRealLiteral(), 
			TokenId.OpenParen => ParseParenExpression(), 
			_ => throw ParseError("Expression expected"), 
		};
	}

	private Expression ParseStringLiteral()
	{
		ValidateToken(TokenId.StringLiteral);
		char quote = token.text[0];
		string s = token.text.Substring(1, token.text.Length - 2);
		int start = 0;
		while (true)
		{
			bool flag = true;
			int i = s.IndexOf(quote, start);
			if (i < 0)
			{
				break;
			}
			s = s.Remove(i, 1);
			start = i + 1;
		}
		if (quote == '\'')
		{
			if (s.Length != 1)
			{
				throw ParseError("Character literal must contain exactly one character");
			}
			NextToken();
			return CreateLiteral(s[0], s);
		}
		NextToken();
		return CreateLiteral(s, s);
	}

	private Expression ParseIntegerLiteral()
	{
		ValidateToken(TokenId.IntegerLiteral);
		string text = token.text;
		if (text[0] != '-')
		{
			if (!ulong.TryParse(text, out var value))
			{
				throw ParseError("Invalid integer literal '{0}'", text);
			}
			NextToken();
			if (value <= int.MaxValue)
			{
				return CreateLiteral((int)value, text);
			}
			if (value <= uint.MaxValue)
			{
				return CreateLiteral((uint)value, text);
			}
			if (value <= long.MaxValue)
			{
				return CreateLiteral((long)value, text);
			}
			return CreateLiteral(value, text);
		}
		if (!long.TryParse(text, out var value2))
		{
			throw ParseError("Invalid integer literal '{0}'", text);
		}
		NextToken();
		if (value2 >= int.MinValue && value2 <= int.MaxValue)
		{
			return CreateLiteral((int)value2, text);
		}
		return CreateLiteral(value2, text);
	}

	private Expression ParseRealLiteral()
	{
		ValidateToken(TokenId.RealLiteral);
		string text = token.text;
		object value = null;
		char last = text[text.Length - 1];
		double d;
		if (last == 'F' || last == 'f')
		{
			if (float.TryParse(text.Substring(0, text.Length - 1), out var f))
			{
				value = f;
			}
		}
		else if (double.TryParse(text, out d))
		{
			value = d;
		}
		if (value == null)
		{
			throw ParseError("Invalid real literal '{0}'", text);
		}
		NextToken();
		return CreateLiteral(value, text);
	}

	private Expression CreateLiteral(object value, string text)
	{
		ConstantExpression expr = Expression.Constant(value);
		literals.Add(expr, text);
		return expr;
	}

	private Expression ParseParenExpression()
	{
		ValidateToken(TokenId.OpenParen, "'(' expected");
		NextToken();
		Expression e = ParseExpression();
		ValidateToken(TokenId.CloseParen, "')' or operator expected");
		NextToken();
		return e;
	}

	private Expression ParseIdentifier()
	{
		ValidateToken(TokenId.Identifier);
		if (keywords.TryGetValue(token.text, out var value))
		{
			if (value is Type)
			{
				return ParseTypeAccess((Type)value);
			}
			if (value == keywordIt)
			{
				return ParseIt();
			}
			if (value == keywordIif)
			{
				return ParseIif();
			}
			if (value == keywordNew)
			{
				return ParseNew();
			}
			NextToken();
			return (Expression)value;
		}
		if (symbols.TryGetValue(token.text, out value) || (externals != null && externals.TryGetValue(token.text, out value)))
		{
			Expression expr = value as Expression;
			if (expr == null)
			{
				expr = Expression.Constant(value);
			}
			else if (expr is LambdaExpression lambda)
			{
				return ParseLambdaInvocation(lambda);
			}
			NextToken();
			return expr;
		}
		if (it != null)
		{
			return ParseMemberAccess(null, it);
		}
		throw ParseError("Unknown identifier '{0}'", token.text);
	}

	private Expression ParseIt()
	{
		if (it == null)
		{
			throw ParseError("No 'it' is in scope");
		}
		NextToken();
		return it;
	}

	private Expression ParseIif()
	{
		int errorPos = token.pos;
		NextToken();
		Expression[] args = ParseArgumentList();
		if (args.Length != 3)
		{
			throw ParseError(errorPos, "The 'iif' function requires three arguments");
		}
		return GenerateConditional(args[0], args[1], args[2], errorPos);
	}

	private Expression GenerateConditional(Expression test, Expression expr1, Expression expr2, int errorPos)
	{
		if (test.Type != typeof(bool))
		{
			throw ParseError(errorPos, "The first expression must be of type 'Boolean'");
		}
		if (expr1.Type != expr2.Type)
		{
			Expression expr1as2 = ((expr2 != nullLiteral) ? PromoteExpression(expr1, expr2.Type, exact: true) : null);
			Expression expr2as1 = ((expr1 != nullLiteral) ? PromoteExpression(expr2, expr1.Type, exact: true) : null);
			if (expr1as2 != null && expr2as1 == null)
			{
				expr1 = expr1as2;
			}
			else
			{
				if (expr2as1 == null || expr1as2 != null)
				{
					string type1 = ((expr1 != nullLiteral) ? expr1.Type.Name : "null");
					string type2 = ((expr2 != nullLiteral) ? expr2.Type.Name : "null");
					if (expr1as2 != null && expr2as1 != null)
					{
						throw ParseError(errorPos, "Both of the types '{0}' and '{1}' convert to the other", type1, type2);
					}
					throw ParseError(errorPos, "Neither of the types '{0}' and '{1}' converts to the other", type1, type2);
				}
				expr2 = expr2as1;
			}
		}
		return Expression.Condition(test, expr1, expr2);
	}

	private Expression ParseNew()
	{
		NextToken();
		ValidateToken(TokenId.OpenParen, "'(' expected");
		NextToken();
		List<DynamicProperty> properties = new List<DynamicProperty>();
		List<Expression> expressions = new List<Expression>();
		while (true)
		{
			bool flag = true;
			int exprPos = token.pos;
			Expression expr = ParseExpression();
			string propName;
			if (TokenIdentifierIs("as"))
			{
				NextToken();
				propName = GetIdentifier();
				NextToken();
			}
			else
			{
				if (!(expr is MemberExpression me))
				{
					throw ParseError(exprPos, "Expression is missing an 'as' clause");
				}
				propName = me.Member.Name;
			}
			expressions.Add(expr);
			properties.Add(new DynamicProperty(propName, expr.Type));
			if (token.id != TokenId.Comma)
			{
				break;
			}
			NextToken();
		}
		ValidateToken(TokenId.CloseParen, "')' or ',' expected");
		NextToken();
		Type type = DynamicExpression.CreateClass(properties);
		MemberBinding[] bindings = new MemberBinding[properties.Count];
		for (int i = 0; i < bindings.Length; i++)
		{
			bindings[i] = Expression.Bind(type.GetProperty(properties[i].Name), expressions[i]);
		}
		return Expression.MemberInit(Expression.New(type), bindings);
	}

	private Expression ParseLambdaInvocation(LambdaExpression lambda)
	{
		int errorPos = token.pos;
		NextToken();
		Expression[] args = ParseArgumentList();
		if (FindMethod(lambda.Type, "Invoke", staticAccess: false, args, out var _) != 1)
		{
			throw ParseError(errorPos, "Argument list incompatible with lambda expression");
		}
		return Expression.Invoke(lambda, args);
	}

	private Expression ParseTypeAccess(Type type)
	{
		int errorPos = token.pos;
		NextToken();
		if (token.id == TokenId.Question)
		{
			if (!type.IsValueType || IsNullableType(type))
			{
				throw ParseError(errorPos, "Type '{0}' has no nullable form", GetTypeName(type));
			}
			type = typeof(Nullable<>).MakeGenericType(type);
			NextToken();
		}
		if (token.id == TokenId.OpenParen)
		{
			Expression[] args = ParseArgumentList();
			MethodBase method;
			switch (FindBestMethod(type.GetConstructors(), args, out method))
			{
			case 0:
				if (args.Length == 1)
				{
					return GenerateConversion(args[0], type, errorPos);
				}
				throw ParseError(errorPos, "No matching constructor in type '{0}'", GetTypeName(type));
			case 1:
				return Expression.New((ConstructorInfo)method, args);
			default:
				throw ParseError(errorPos, "Ambiguous invocation of '{0}' constructor", GetTypeName(type));
			}
		}
		ValidateToken(TokenId.Dot, "'.' or '(' expected");
		NextToken();
		return ParseMemberAccess(type, null);
	}

	private Expression GenerateConversion(Expression expr, Type type, int errorPos)
	{
		Type exprType = expr.Type;
		if (exprType == type)
		{
			return expr;
		}
		if (exprType.IsValueType && type.IsValueType)
		{
			if ((IsNullableType(exprType) || IsNullableType(type)) && GetNonNullableType(exprType) == GetNonNullableType(type))
			{
				return Expression.Convert(expr, type);
			}
			if (((IsNumericType(exprType) || IsEnumType(exprType)) && IsNumericType(type)) || IsEnumType(type))
			{
				return Expression.ConvertChecked(expr, type);
			}
		}
		if (exprType.IsAssignableFrom(type) || type.IsAssignableFrom(exprType) || exprType.IsInterface || type.IsInterface)
		{
			return Expression.Convert(expr, type);
		}
		throw ParseError(errorPos, "A value of type '{0}' cannot be converted to type '{1}'", GetTypeName(exprType), GetTypeName(type));
	}

	private Expression ParseMemberAccess(Type type, Expression instance)
	{
		if (instance != null)
		{
			type = instance.Type;
		}
		int errorPos = token.pos;
		string id = GetIdentifier();
		NextToken();
		if (token.id == TokenId.OpenParen)
		{
			if (instance != null && type != typeof(string))
			{
				Type enumerableType = FindGenericType(typeof(IEnumerable<>), type);
				if (enumerableType != null)
				{
					Type elementType = enumerableType.GetGenericArguments()[0];
					return ParseAggregate(instance, elementType, id, errorPos);
				}
			}
			Expression[] args = ParseArgumentList();
			MethodBase mb;
			switch (FindMethod(type, id, instance == null, args, out mb))
			{
			case 0:
				throw ParseError(errorPos, "No applicable method '{0}' exists in type '{1}'", id, GetTypeName(type));
			case 1:
			{
				MethodInfo method = (MethodInfo)mb;
				if (!IsPredefinedType(method.DeclaringType))
				{
					throw ParseError(errorPos, "Methods on type '{0}' are not accessible", GetTypeName(method.DeclaringType));
				}
				if (method.ReturnType == typeof(void))
				{
					throw ParseError(errorPos, "Method '{0}' in type '{1}' does not return a value", id, GetTypeName(method.DeclaringType));
				}
				return Expression.Call(instance, method, args);
			}
			default:
				throw ParseError(errorPos, "Ambiguous invocation of method '{0}' in type '{1}'", id, GetTypeName(type));
			}
		}
		MemberInfo member = FindPropertyOrField(type, id, instance == null);
		if (member == null)
		{
			throw ParseError(errorPos, "No property or field '{0}' exists in type '{1}'", id, GetTypeName(type));
		}
		return (member is PropertyInfo) ? Expression.Property(instance, (PropertyInfo)member) : Expression.Field(instance, (FieldInfo)member);
	}

	private static Type FindGenericType(Type generic, Type type)
	{
		while (type != null && type != typeof(object))
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == generic)
			{
				return type;
			}
			if (generic.IsInterface)
			{
				Type[] interfaces = type.GetInterfaces();
				foreach (Type intfType in interfaces)
				{
					Type found = FindGenericType(generic, intfType);
					if (found != null)
					{
						return found;
					}
				}
			}
			type = type.BaseType;
		}
		return null;
	}

	private Expression ParseAggregate(Expression instance, Type elementType, string methodName, int errorPos)
	{
		ParameterExpression outerIt = it;
		ParameterExpression innerIt = (it = Expression.Parameter(elementType, ""));
		Expression[] args = ParseArgumentList();
		it = outerIt;
		if (FindMethod(typeof(IEnumerableSignatures), methodName, staticAccess: false, args, out var signature) != 1)
		{
			throw ParseError(errorPos, "No applicable aggregate method '{0}' exists", methodName);
		}
		return Expression.Call(typeArguments: (!(signature.Name == "Min") && !(signature.Name == "Max")) ? new Type[1] { elementType } : new Type[2]
		{
			elementType,
			args[0].Type
		}, arguments: (args.Length != 0) ? new Expression[2]
		{
			instance,
			Expression.Lambda(args[0], innerIt)
		} : new Expression[1] { instance }, type: typeof(Enumerable), methodName: signature.Name);
	}

	private Expression[] ParseArgumentList()
	{
		ValidateToken(TokenId.OpenParen, "'(' expected");
		NextToken();
		Expression[] args = ((token.id != TokenId.CloseParen) ? ParseArguments() : new Expression[0]);
		ValidateToken(TokenId.CloseParen, "')' or ',' expected");
		NextToken();
		return args;
	}

	private Expression[] ParseArguments()
	{
		List<Expression> argList = new List<Expression>();
		while (true)
		{
			bool flag = true;
			argList.Add(ParseExpression());
			if (token.id != TokenId.Comma)
			{
				break;
			}
			NextToken();
		}
		return argList.ToArray();
	}

	private Expression ParseElementAccess(Expression expr)
	{
		int errorPos = token.pos;
		ValidateToken(TokenId.OpenBracket, "'(' expected");
		NextToken();
		Expression[] args = ParseArguments();
		ValidateToken(TokenId.CloseBracket, "']' or ',' expected");
		NextToken();
		if (expr.Type.IsArray)
		{
			if (expr.Type.GetArrayRank() != 1 || args.Length != 1)
			{
				throw ParseError(errorPos, "Indexing of multi-dimensional arrays is not supported");
			}
			Expression index = PromoteExpression(args[0], typeof(int), exact: true);
			if (index == null)
			{
				throw ParseError(errorPos, "Array index must be an integer expression");
			}
			return Expression.ArrayIndex(expr, index);
		}
		MethodBase mb;
		return FindIndexer(expr.Type, args, out mb) switch
		{
			0 => throw ParseError(errorPos, "No applicable indexer exists in type '{0}'", GetTypeName(expr.Type)), 
			1 => Expression.Call(expr, (MethodInfo)mb, args), 
			_ => throw ParseError(errorPos, "Ambiguous invocation of indexer in type '{0}'", GetTypeName(expr.Type)), 
		};
	}

	private static bool IsPredefinedType(Type type)
	{
		Type[] array = predefinedTypes;
		foreach (Type t in array)
		{
			if (t == type)
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsNullableType(Type type)
	{
		return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
	}

	private static Type GetNonNullableType(Type type)
	{
		return IsNullableType(type) ? type.GetGenericArguments()[0] : type;
	}

	private static string GetTypeName(Type type)
	{
		Type baseType = GetNonNullableType(type);
		string s = baseType.Name;
		if (type != baseType)
		{
			s += '?';
		}
		return s;
	}

	private static bool IsNumericType(Type type)
	{
		return GetNumericTypeKind(type) != 0;
	}

	private static bool IsSignedIntegralType(Type type)
	{
		return GetNumericTypeKind(type) == 2;
	}

	private static bool IsUnsignedIntegralType(Type type)
	{
		return GetNumericTypeKind(type) == 3;
	}

	private static int GetNumericTypeKind(Type type)
	{
		type = GetNonNullableType(type);
		if (type.IsEnum)
		{
			return 0;
		}
		switch (Type.GetTypeCode(type))
		{
		case TypeCode.Char:
		case TypeCode.Single:
		case TypeCode.Double:
		case TypeCode.Decimal:
			return 1;
		case TypeCode.SByte:
		case TypeCode.Int16:
		case TypeCode.Int32:
		case TypeCode.Int64:
			return 2;
		case TypeCode.Byte:
		case TypeCode.UInt16:
		case TypeCode.UInt32:
		case TypeCode.UInt64:
			return 3;
		default:
			return 0;
		}
	}

	private static bool IsEnumType(Type type)
	{
		return GetNonNullableType(type).IsEnum;
	}

	private void CheckAndPromoteOperand(Type signatures, string opName, ref Expression expr, int errorPos)
	{
		Expression[] args = new Expression[1] { expr };
		if (FindMethod(signatures, "F", staticAccess: false, args, out var _) != 1)
		{
			throw ParseError(errorPos, "Operator '{0}' incompatible with operand type '{1}'", opName, GetTypeName(args[0].Type));
		}
		expr = args[0];
	}

	private void CheckAndPromoteOperands(Type signatures, string opName, ref Expression left, ref Expression right, int errorPos)
	{
		Expression[] args = new Expression[2] { left, right };
		if (FindMethod(signatures, "F", staticAccess: false, args, out var _) != 1)
		{
			throw IncompatibleOperandsError(opName, left, right, errorPos);
		}
		left = args[0];
		right = args[1];
	}

	private Exception IncompatibleOperandsError(string opName, Expression left, Expression right, int pos)
	{
		return ParseError(pos, "Operator '{0}' incompatible with operand types '{1}' and '{2}'", opName, GetTypeName(left.Type), GetTypeName(right.Type));
	}

	private MemberInfo FindPropertyOrField(Type type, string memberName, bool staticAccess)
	{
		BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | (staticAccess ? BindingFlags.Static : BindingFlags.Instance);
		foreach (Type t in SelfAndBaseTypes(type))
		{
			MemberInfo[] members = t.FindMembers(MemberTypes.Field | MemberTypes.Property, flags, Type.FilterNameIgnoreCase, memberName);
			if (members.Length != 0)
			{
				return members[0];
			}
		}
		return null;
	}

	private int FindMethod(Type type, string methodName, bool staticAccess, Expression[] args, out MethodBase method)
	{
		BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | (staticAccess ? BindingFlags.Static : BindingFlags.Instance);
		foreach (Type t in SelfAndBaseTypes(type))
		{
			MemberInfo[] members = t.FindMembers(MemberTypes.Method, flags, Type.FilterNameIgnoreCase, methodName);
			int count = FindBestMethod(members.Cast<MethodBase>(), args, out method);
			if (count != 0)
			{
				return count;
			}
		}
		method = null;
		return 0;
	}

	private int FindIndexer(Type type, Expression[] args, out MethodBase method)
	{
		foreach (Type t in SelfAndBaseTypes(type))
		{
			MemberInfo[] members = t.GetDefaultMembers();
			if (members.Length != 0)
			{
				IEnumerable<MethodBase> methods = from m in members.OfType<PropertyInfo>().Select((Func<PropertyInfo, MethodBase>)((PropertyInfo p) => p.GetGetMethod()))
					where m != null
					select m;
				int count = FindBestMethod(methods, args, out method);
				if (count != 0)
				{
					return count;
				}
			}
		}
		method = null;
		return 0;
	}

	private static IEnumerable<Type> SelfAndBaseTypes(Type type)
	{
		if (type.IsInterface)
		{
			List<Type> types = new List<Type>();
			AddInterface(types, type);
			return types;
		}
		return SelfAndBaseClasses(type);
	}

	private static IEnumerable<Type> SelfAndBaseClasses(Type type)
	{
		while (type != null)
		{
			yield return type;
			type = type.BaseType;
		}
	}

	private static void AddInterface(List<Type> types, Type type)
	{
		if (!types.Contains(type))
		{
			types.Add(type);
			Type[] interfaces = type.GetInterfaces();
			foreach (Type t in interfaces)
			{
				AddInterface(types, t);
			}
		}
	}

	private int FindBestMethod(IEnumerable<MethodBase> methods, Expression[] args, out MethodBase method)
	{
		MethodData[] applicable = (from m in methods
			select new MethodData
			{
				MethodBase = m,
				Parameters = m.GetParameters()
			} into m
			where IsApplicable(m, args)
			select m).ToArray();
		if (applicable.Length > 1)
		{
			applicable = applicable.Where((MethodData m) => applicable.All((MethodData n) => m == n || IsBetterThan(args, m, n))).ToArray();
		}
		if (applicable.Length == 1)
		{
			MethodData md = applicable[0];
			for (int i = 0; i < args.Length; i++)
			{
				args[i] = md.Args[i];
			}
			method = md.MethodBase;
		}
		else
		{
			method = null;
		}
		return applicable.Length;
	}

	private bool IsApplicable(MethodData method, Expression[] args)
	{
		if (method.Parameters.Length != args.Length)
		{
			return false;
		}
		Expression[] promotedArgs = new Expression[args.Length];
		for (int i = 0; i < args.Length; i++)
		{
			ParameterInfo pi = method.Parameters[i];
			if (pi.IsOut)
			{
				return false;
			}
			Expression promoted = PromoteExpression(args[i], pi.ParameterType, exact: false);
			if (promoted == null)
			{
				return false;
			}
			promotedArgs[i] = promoted;
		}
		method.Args = promotedArgs;
		return true;
	}

	private Expression PromoteExpression(Expression expr, Type type, bool exact)
	{
		if (expr.Type == type)
		{
			return expr;
		}
		if (expr is ConstantExpression)
		{
			ConstantExpression ce = (ConstantExpression)expr;
			string text;
			if (ce == nullLiteral)
			{
				if (!type.IsValueType || IsNullableType(type))
				{
					return Expression.Constant(null, type);
				}
			}
			else if (literals.TryGetValue(ce, out text))
			{
				Type target = GetNonNullableType(type);
				object value = null;
				switch (Type.GetTypeCode(ce.Type))
				{
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
					value = ParseNumber(text, target);
					break;
				case TypeCode.Double:
					if (target == typeof(decimal))
					{
						value = ParseNumber(text, target);
					}
					break;
				case TypeCode.String:
					value = ParseEnum(text, target);
					break;
				}
				if (value != null)
				{
					return Expression.Constant(value, type);
				}
			}
		}
		if (IsCompatibleWith(expr.Type, type))
		{
			if (type.IsValueType || exact)
			{
				return Expression.Convert(expr, type);
			}
			return expr;
		}
		return null;
	}

	private static object ParseNumber(string text, Type type)
	{
		switch (Type.GetTypeCode(GetNonNullableType(type)))
		{
		case TypeCode.SByte:
		{
			if (sbyte.TryParse(text, out var sb))
			{
				return sb;
			}
			break;
		}
		case TypeCode.Byte:
		{
			if (byte.TryParse(text, out var b))
			{
				return b;
			}
			break;
		}
		case TypeCode.Int16:
		{
			if (short.TryParse(text, out var s))
			{
				return s;
			}
			break;
		}
		case TypeCode.UInt16:
		{
			if (ushort.TryParse(text, out var us))
			{
				return us;
			}
			break;
		}
		case TypeCode.Int32:
		{
			if (int.TryParse(text, out var i))
			{
				return i;
			}
			break;
		}
		case TypeCode.UInt32:
		{
			if (uint.TryParse(text, out var ui))
			{
				return ui;
			}
			break;
		}
		case TypeCode.Int64:
		{
			if (long.TryParse(text, out var j))
			{
				return j;
			}
			break;
		}
		case TypeCode.UInt64:
		{
			if (ulong.TryParse(text, out var ul))
			{
				return ul;
			}
			break;
		}
		case TypeCode.Single:
		{
			if (float.TryParse(text, out var f))
			{
				return f;
			}
			break;
		}
		case TypeCode.Double:
		{
			if (double.TryParse(text, out var d))
			{
				return d;
			}
			break;
		}
		case TypeCode.Decimal:
		{
			if (decimal.TryParse(text, out var e))
			{
				return e;
			}
			break;
		}
		}
		return null;
	}

	private static object ParseEnum(string name, Type type)
	{
		if (type.IsEnum)
		{
			MemberInfo[] memberInfos = type.FindMembers(MemberTypes.Field, BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public, Type.FilterNameIgnoreCase, name);
			if (memberInfos.Length != 0)
			{
				return ((FieldInfo)memberInfos[0]).GetValue(null);
			}
		}
		return null;
	}

	private static bool IsCompatibleWith(Type source, Type target)
	{
		if (source == target)
		{
			return true;
		}
		if (!target.IsValueType)
		{
			return target.IsAssignableFrom(source);
		}
		Type st = GetNonNullableType(source);
		Type tt = GetNonNullableType(target);
		if (st != source && tt == target)
		{
			return false;
		}
		TypeCode sc = (st.IsEnum ? TypeCode.Object : Type.GetTypeCode(st));
		TypeCode tc = (tt.IsEnum ? TypeCode.Object : Type.GetTypeCode(tt));
		switch (sc)
		{
		case TypeCode.SByte:
			switch (tc)
			{
			case TypeCode.SByte:
			case TypeCode.Int16:
			case TypeCode.Int32:
			case TypeCode.Int64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return true;
			}
			break;
		case TypeCode.Byte:
			switch (tc)
			{
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return true;
			}
			break;
		case TypeCode.Int16:
			switch (tc)
			{
			case TypeCode.Int16:
			case TypeCode.Int32:
			case TypeCode.Int64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return true;
			}
			break;
		case TypeCode.UInt16:
			switch (tc)
			{
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return true;
			}
			break;
		case TypeCode.Int32:
			switch (tc)
			{
			case TypeCode.Int32:
			case TypeCode.Int64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return true;
			}
			break;
		case TypeCode.UInt32:
			switch (tc)
			{
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return true;
			}
			break;
		case TypeCode.Int64:
			switch (tc)
			{
			case TypeCode.Int64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return true;
			}
			break;
		case TypeCode.UInt64:
			switch (tc)
			{
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return true;
			}
			break;
		case TypeCode.Single:
			switch (tc)
			{
			case TypeCode.Single:
			case TypeCode.Double:
				return true;
			}
			break;
		default:
			if (st == tt)
			{
				return true;
			}
			break;
		}
		return false;
	}

	private static bool IsBetterThan(Expression[] args, MethodData m1, MethodData m2)
	{
		bool better = false;
		for (int i = 0; i < args.Length; i++)
		{
			int c = CompareConversions(args[i].Type, m1.Parameters[i].ParameterType, m2.Parameters[i].ParameterType);
			if (c < 0)
			{
				return false;
			}
			if (c > 0)
			{
				better = true;
			}
		}
		return better;
	}

	private static int CompareConversions(Type s, Type t1, Type t2)
	{
		if (t1 == t2)
		{
			return 0;
		}
		if (s == t1)
		{
			return 1;
		}
		if (s == t2)
		{
			return -1;
		}
		bool t1t2 = IsCompatibleWith(t1, t2);
		bool t2t1 = IsCompatibleWith(t2, t1);
		if (t1t2 && !t2t1)
		{
			return 1;
		}
		if (t2t1 && !t1t2)
		{
			return -1;
		}
		if (IsSignedIntegralType(t1) && IsUnsignedIntegralType(t2))
		{
			return 1;
		}
		if (IsSignedIntegralType(t2) && IsUnsignedIntegralType(t1))
		{
			return -1;
		}
		return 0;
	}

	private Expression GenerateEqual(Expression left, Expression right)
	{
		return Expression.Equal(left, right);
	}

	private Expression GenerateNotEqual(Expression left, Expression right)
	{
		return Expression.NotEqual(left, right);
	}

	private Expression GenerateGreaterThan(Expression left, Expression right)
	{
		if (left.Type == typeof(string))
		{
			return Expression.GreaterThan(GenerateStaticMethodCall("Compare", left, right), Expression.Constant(0));
		}
		return Expression.GreaterThan(left, right);
	}

	private Expression GenerateGreaterThanEqual(Expression left, Expression right)
	{
		if (left.Type == typeof(string))
		{
			return Expression.GreaterThanOrEqual(GenerateStaticMethodCall("Compare", left, right), Expression.Constant(0));
		}
		return Expression.GreaterThanOrEqual(left, right);
	}

	private Expression GenerateLessThan(Expression left, Expression right)
	{
		if (left.Type == typeof(string))
		{
			return Expression.LessThan(GenerateStaticMethodCall("Compare", left, right), Expression.Constant(0));
		}
		return Expression.LessThan(left, right);
	}

	private Expression GenerateLessThanEqual(Expression left, Expression right)
	{
		if (left.Type == typeof(string))
		{
			return Expression.LessThanOrEqual(GenerateStaticMethodCall("Compare", left, right), Expression.Constant(0));
		}
		return Expression.LessThanOrEqual(left, right);
	}

	private Expression GenerateAdd(Expression left, Expression right)
	{
		if (left.Type == typeof(string) && right.Type == typeof(string))
		{
			return GenerateStaticMethodCall("Concat", left, right);
		}
		return Expression.Add(left, right);
	}

	private Expression GenerateSubtract(Expression left, Expression right)
	{
		return Expression.Subtract(left, right);
	}

	private Expression GenerateStringConcat(Expression left, Expression right)
	{
		return Expression.Call(null, typeof(string).GetMethod("Concat", new Type[2]
		{
			typeof(object),
			typeof(object)
		}), new Expression[2] { left, right });
	}

	private MethodInfo GetStaticMethod(string methodName, Expression left, Expression right)
	{
		return left.Type.GetMethod(methodName, new Type[2] { left.Type, right.Type });
	}

	private Expression GenerateStaticMethodCall(string methodName, Expression left, Expression right)
	{
		return Expression.Call(null, GetStaticMethod(methodName, left, right), new Expression[2] { left, right });
	}

	private void SetTextPos(int pos)
	{
		textPos = pos;
		ch = ((textPos < textLen) ? text[textPos] : '\0');
	}

	private void NextChar()
	{
		if (textPos < textLen)
		{
			textPos++;
		}
		ch = ((textPos < textLen) ? text[textPos] : '\0');
	}

	private void NextToken()
	{
		while (char.IsWhiteSpace(ch))
		{
			NextChar();
		}
		int tokenPos = textPos;
		TokenId t;
		switch (ch)
		{
		case '!':
			NextChar();
			if (ch == '=')
			{
				NextChar();
				t = TokenId.ExclamationEqual;
			}
			else
			{
				t = TokenId.Exclamation;
			}
			break;
		case '%':
			NextChar();
			t = TokenId.Percent;
			break;
		case '&':
			NextChar();
			if (ch == '&')
			{
				NextChar();
				t = TokenId.DoubleAmphersand;
			}
			else
			{
				t = TokenId.Amphersand;
			}
			break;
		case '(':
			NextChar();
			t = TokenId.OpenParen;
			break;
		case ')':
			NextChar();
			t = TokenId.CloseParen;
			break;
		case '*':
			NextChar();
			t = TokenId.Asterisk;
			break;
		case '+':
			NextChar();
			t = TokenId.Plus;
			break;
		case ',':
			NextChar();
			t = TokenId.Comma;
			break;
		case '-':
			NextChar();
			t = TokenId.Minus;
			break;
		case '.':
			NextChar();
			t = TokenId.Dot;
			break;
		case '/':
			NextChar();
			t = TokenId.Slash;
			break;
		case ':':
			NextChar();
			t = TokenId.Colon;
			break;
		case '<':
			NextChar();
			if (ch == '=')
			{
				NextChar();
				t = TokenId.LessThanEqual;
			}
			else if (ch == '>')
			{
				NextChar();
				t = TokenId.LessGreater;
			}
			else
			{
				t = TokenId.LessThan;
			}
			break;
		case '=':
			NextChar();
			if (ch == '=')
			{
				NextChar();
				t = TokenId.DoubleEqual;
			}
			else
			{
				t = TokenId.Equal;
			}
			break;
		case '>':
			NextChar();
			if (ch == '=')
			{
				NextChar();
				t = TokenId.GreaterThanEqual;
			}
			else
			{
				t = TokenId.GreaterThan;
			}
			break;
		case '?':
			NextChar();
			t = TokenId.Question;
			break;
		case '[':
			NextChar();
			t = TokenId.OpenBracket;
			break;
		case ']':
			NextChar();
			t = TokenId.CloseBracket;
			break;
		case '|':
			NextChar();
			if (ch == '|')
			{
				NextChar();
				t = TokenId.DoubleBar;
			}
			else
			{
				t = TokenId.Bar;
			}
			break;
		case '"':
		case '\'':
		{
			char quote = ch;
			do
			{
				NextChar();
				while (textPos < textLen && ch != quote)
				{
					NextChar();
				}
				if (textPos == textLen)
				{
					throw ParseError(textPos, "Unterminated string literal");
				}
				NextChar();
			}
			while (ch == quote);
			t = TokenId.StringLiteral;
			break;
		}
		default:
			if (char.IsLetter(ch) || ch == '@' || ch == '_')
			{
				do
				{
					NextChar();
				}
				while (char.IsLetterOrDigit(ch) || ch == '_');
				t = TokenId.Identifier;
			}
			else if (char.IsDigit(ch))
			{
				t = TokenId.IntegerLiteral;
				do
				{
					NextChar();
				}
				while (char.IsDigit(ch));
				if (ch == '.')
				{
					t = TokenId.RealLiteral;
					NextChar();
					ValidateDigit();
					do
					{
						NextChar();
					}
					while (char.IsDigit(ch));
				}
				if (ch == 'E' || ch == 'e')
				{
					t = TokenId.RealLiteral;
					NextChar();
					if (ch == '+' || ch == '-')
					{
						NextChar();
					}
					ValidateDigit();
					do
					{
						NextChar();
					}
					while (char.IsDigit(ch));
				}
				if (ch == 'F' || ch == 'f')
				{
					NextChar();
				}
			}
			else
			{
				if (textPos != textLen)
				{
					throw ParseError(textPos, "Syntax error '{0}'", ch);
				}
				t = TokenId.End;
			}
			break;
		}
		token.id = t;
		token.text = text.Substring(tokenPos, textPos - tokenPos);
		token.pos = tokenPos;
	}

	private bool TokenIdentifierIs(string id)
	{
		return token.id == TokenId.Identifier && string.Equals(id, token.text, StringComparison.OrdinalIgnoreCase);
	}

	private string GetIdentifier()
	{
		ValidateToken(TokenId.Identifier, "Identifier expected");
		string id = token.text;
		if (id.Length > 1 && id[0] == '@')
		{
			id = id.Substring(1);
		}
		return id;
	}

	private void ValidateDigit()
	{
		if (!char.IsDigit(ch))
		{
			throw ParseError(textPos, "Digit expected");
		}
	}

	private void ValidateToken(TokenId t, string errorMessage)
	{
		if (token.id != t)
		{
			throw ParseError(errorMessage);
		}
	}

	private void ValidateToken(TokenId t)
	{
		if (token.id != t)
		{
			throw ParseError("Syntax error");
		}
	}

	private Exception ParseError(string format, params object[] args)
	{
		return ParseError(token.pos, format, args);
	}

	private Exception ParseError(int pos, string format, params object[] args)
	{
		return new ParseException(string.Format(CultureInfo.CurrentCulture, format, args), pos);
	}

	private static Dictionary<string, object> CreateKeywords()
	{
		Dictionary<string, object> d = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		d.Add("true", trueLiteral);
		d.Add("false", falseLiteral);
		d.Add("null", nullLiteral);
		d.Add(keywordIt, keywordIt);
		d.Add(keywordIif, keywordIif);
		d.Add(keywordNew, keywordNew);
		Type[] array = predefinedTypes;
		foreach (Type type in array)
		{
			d.Add(type.Name, type);
		}
		return d;
	}
}
