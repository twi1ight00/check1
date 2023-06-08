using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Aspose.JavaScript;

namespace ns322;

internal class Class7678 : Interface395, Interface396
{
	public const int int_0 = 100;

	private Interface401 interface401_0;

	private Class7438 class7438_0;

	private Class7360 class7360_0;

	private StringBuilder stringBuilder_0 = new StringBuilder();

	private string string_0 = string.Empty;

	private Struct262 struct262_0;

	private Stack stack_0 = new Stack();

	protected Stack<Class7438> stack_1 = new Stack<Class7438>();

	private Stack<string> stack_2;

	protected bool bool_0;

	protected Class7397 class7397_0;

	protected int int_1;

	protected Class7382 class7382_0;

	protected Class7381 class7381_0;

	public Stack<string> CallStack
	{
		get
		{
			return stack_2;
		}
		set
		{
			stack_2 = value;
		}
	}

	public Interface401 Global => interface401_0;

	public Class7438 GlobalScope => class7438_0;

	public Class7360 CurrentStatement
	{
		get
		{
			return class7360_0;
		}
		set
		{
			class7360_0 = value;
		}
	}

	public Class7397 Returned => class7397_0;

	public Class7398 CallTarget => struct262_0.class7398_0;

	public Class7397 Result
	{
		get
		{
			return struct262_0.class7397_0;
		}
		set
		{
			struct262_0.class7397_0 = value;
			struct262_0.class7398_0 = null;
		}
	}

	public Class7438 CurrentScope => stack_1.Peek();

	protected void method_0(Class7398 scope)
	{
		stack_1.Push(new Class7438(CurrentScope, scope));
	}

	protected void method_1(Class7438 scope)
	{
		stack_1.Push(scope);
	}

	protected void method_2()
	{
		stack_1.Pop();
	}

	protected void method_3(string label)
	{
		if (class7382_0 != null && class7382_0.Label == label)
		{
			class7382_0 = null;
		}
	}

	protected bool method_4()
	{
		if (!bool_0 && class7381_0 == null)
		{
			return class7382_0 != null;
		}
		return true;
	}

	public void method_5(Class7397 value, Class7398 baseObject)
	{
		struct262_0.class7397_0 = value;
		struct262_0.class7398_0 = baseObject;
	}

	public void imethod_0(Class7380 program)
	{
		stringBuilder_0 = new StringBuilder();
		bool_0 = false;
		string_0 = string.Empty;
		foreach (Class7675 item in (IEnumerable)program.Statements)
		{
			Class7360 class2 = (class7360_0 = (Class7360)item.Data);
			Result = null;
			class2.vmethod_0(this);
			if (bool_0)
			{
				bool_0 = false;
				break;
			}
		}
	}

	public void imethod_1(Class7363 statement)
	{
		switch (statement.AssignmentOperator)
		{
		default:
			throw new NotSupportedException();
		case Enum982.const_0:
			statement.Right.vmethod_0(this);
			break;
		case Enum982.const_1:
			new Class7364(BinaryExpressionType.Times, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_2:
			new Class7364(BinaryExpressionType.Div, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_3:
			new Class7364(BinaryExpressionType.Modulo, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_4:
			new Class7364(BinaryExpressionType.Plus, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_5:
			new Class7364(BinaryExpressionType.Minus, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_6:
			new Class7364(BinaryExpressionType.LeftShift, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_7:
			new Class7364(BinaryExpressionType.RightShift, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_8:
			new Class7364(BinaryExpressionType.UnsignedRightShift, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_9:
			new Class7364(BinaryExpressionType.BitwiseAnd, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_10:
			new Class7364(BinaryExpressionType.BitwiseOr, statement.Left, statement.Right).vmethod_0(this);
			break;
		case Enum982.const_11:
			new Class7364(BinaryExpressionType.BitwiseXOr, statement.Left, statement.Right).vmethod_0(this);
			break;
		}
		Class7397 result = Result;
		Class7371 @class = statement.Left as Class7371;
		if (@class == null)
		{
			@class = new Class7371(statement.Left, null);
		}
		method_6(@class, result);
		Result = result;
	}

	public void method_6(Class7371 left, Class7397 value)
	{
		Class7352 result = null;
		if (!(left.Member is Interface400))
		{
			throw new Exception89("The left member of an assignment must be a member");
		}
		method_8(value);
		Class7398 @class;
		if (left.Previous != null)
		{
			left.Previous.vmethod_0(this);
			@class = Result as Class7398;
			if (@class == null)
			{
				throw new Exception89("Attempt to assign to an undefined variable.");
			}
		}
		else
		{
			@class = CurrentScope;
			string text = ((Class7367)left.Member).Text;
			CurrentScope.vmethod_13(text, out result);
		}
		if (left.Member is Class7367)
		{
			string text = ((Class7367)left.Member).Text;
			Class7397 result2 = (@class[text] = value);
			Result = result2;
			return;
		}
		Class7369 class3 = left.Member as Class7369;
		class3.Index.vmethod_0(this);
		if (@class is Class7399 class4 && class4.Indexer != null)
		{
			class4.Indexer.imethod_1(class4, Result, value);
			Result = value;
		}
		else
		{
			Class7397 result3 = (@class[Result] = value);
			Result = result3;
		}
	}

	public void imethod_20(Class7365 statement)
	{
		foreach (Class7360 statement2 in statement.Statements)
		{
			statement2.vmethod_0(this);
			if (method_4())
			{
				break;
			}
		}
	}

	public void imethod_2(Class7379 statement)
	{
		Class7360 currentStatement = CurrentStatement;
		foreach (Class7675 item in (IEnumerable)statement.Statements)
		{
			Class7360 class2 = (Class7360)item.Data;
			CurrentStatement = (Class7360)item.Data;
			Result = null;
			class2.vmethod_0(this);
			if (method_4())
			{
				return;
			}
		}
		CurrentStatement = currentStatement;
	}

	public void imethod_4(Class7382 statement)
	{
		class7382_0 = statement;
	}

	public void imethod_3(Class7381 statement)
	{
		class7381_0 = statement;
	}

	public void imethod_5(Class7383 statement)
	{
		while (true)
		{
			statement.Statement.vmethod_0(this);
			method_3(statement.Label);
			if (method_4())
			{
				break;
			}
			statement.Condition.vmethod_0(this);
			method_8(Result);
			if (!Result.vmethod_2())
			{
				return;
			}
		}
		if (class7381_0 != null && statement.Label == class7381_0.Label)
		{
			class7381_0 = null;
		}
	}

	public void imethod_6(Class7384 statement)
	{
	}

	public void imethod_7(Class7385 statement)
	{
		statement.Expression.vmethod_0(this);
	}

	public void imethod_8(Class7386 statement)
	{
		string empty = string.Empty;
		if (statement.InitialisationStatement is Class7394)
		{
			_ = ((Class7394)statement.InitialisationStatement).Global;
			empty = ((Class7394)statement.InitialisationStatement).Identifier;
		}
		else
		{
			if (!(statement.InitialisationStatement is Class7367))
			{
				throw new NotSupportedException("Only variable declaration are allowed in a for in loop");
			}
			empty = ((Class7367)statement.InitialisationStatement).Text;
		}
		statement.Expression.vmethod_0(this);
		Class7398 @class = Result as Class7398;
		if (Result.Value is IEnumerable)
		{
			foreach (object item in (IEnumerable)Result.Value)
			{
				CurrentScope[empty] = (Class7397)item;
				statement.Statement.vmethod_0(this);
				method_3(statement.Label);
				if (method_4())
				{
					if (class7381_0 != null && statement.Label == class7381_0.Label)
					{
						class7381_0 = null;
					}
					break;
				}
				method_3(statement.Label);
			}
			return;
		}
		if (@class != null)
		{
			ArrayList arrayList = new ArrayList(@class.Length);
			foreach (string item2 in @class.vmethod_19())
			{
				arrayList.Add(item2);
			}
			arrayList.Sort();
			int num = 0;
			while (true)
			{
				if (num < arrayList.Count)
				{
					string value2 = (string)arrayList[num];
					CurrentScope[empty] = Global.StringClass.method_5(value2);
					statement.Statement.vmethod_0(this);
					method_3(statement.Label);
					if (method_4())
					{
						break;
					}
					method_3(statement.Label);
					num++;
					continue;
				}
				return;
			}
			if (class7381_0 != null && statement.Label == class7381_0.Label)
			{
				class7381_0 = null;
			}
			return;
		}
		throw new InvalidOperationException("The property can't be enumerated");
	}

	public void imethod_14(Class7396 statement)
	{
		statement.Expression.vmethod_0(this);
		if (!(Result is Class7398))
		{
			throw new Exception88(interface401_0.StringClass.method_5("Invalid expression in 'with' statement"));
		}
		method_0((Class7398)Result);
		try
		{
			statement.Statement.vmethod_0(this);
		}
		finally
		{
			method_2();
		}
	}

	public void imethod_9(Class7387 statement)
	{
		if (statement.InitialisationStatement != null)
		{
			statement.InitialisationStatement.vmethod_0(this);
		}
		if (statement.ConditionExpression != null)
		{
			statement.ConditionExpression.vmethod_0(this);
		}
		else
		{
			Result = Global.BooleanClass.method_4(value: true);
		}
		method_8(Result);
		while (true)
		{
			if (Result.vmethod_2())
			{
				statement.Statement.vmethod_0(this);
				method_3(statement.Label);
				if (method_4())
				{
					break;
				}
				if (statement.IncrementExpression != null)
				{
					statement.IncrementExpression.vmethod_0(this);
				}
				if (statement.ConditionExpression != null)
				{
					statement.ConditionExpression.vmethod_0(this);
				}
				else
				{
					Result = Global.BooleanClass.method_4(value: true);
				}
				continue;
			}
			return;
		}
		if (class7381_0 != null && statement.Label == class7381_0.Label)
		{
			class7381_0 = null;
		}
	}

	public Class7400 method_7(Interface399 functionDeclaration)
	{
		Class7400 @class = Global.FunctionClass.method_4();
		@class.Statement = functionDeclaration.Statement;
		@class.Name = functionDeclaration.Name;
		@class.Scope = CurrentScope;
		@class.Arguments = functionDeclaration.Parameters;
		if (method_9(Enum987.flag_0))
		{
			foreach (string argument in @class.Arguments)
			{
				if (argument == "eval" || argument == "arguments")
				{
					throw new Exception88(Global.StringClass.method_5("The parameters do not respect strict mode"));
				}
			}
		}
		return @class;
	}

	public void imethod_10(Class7388 statement)
	{
		Class7400 value = method_7(statement);
		CurrentScope.method_1(statement.Name, value);
	}

	public void imethod_11(Class7389 statement)
	{
		statement.Expression.vmethod_0(this);
		method_8(Result);
		if (Result.vmethod_2())
		{
			statement.Then.vmethod_0(this);
		}
		else if (statement.Else != null)
		{
			statement.Else.vmethod_0(this);
		}
	}

	public void imethod_12(Class7390 statement)
	{
		class7397_0 = null;
		if (statement.Expression != null)
		{
			statement.Expression.vmethod_0(this);
			imethod_36(Result);
		}
		bool_0 = true;
	}

	public Class7397 imethod_36(Class7397 instance)
	{
		class7397_0 = instance;
		return class7397_0;
	}

	public void imethod_13(Class7391 statement)
	{
		CurrentStatement = statement.Expression;
		bool flag = false;
		if (statement.CaseClauses != null)
		{
			foreach (Class7444 caseClause in statement.CaseClauses)
			{
				CurrentStatement = caseClause.Expression;
				if (flag)
				{
					caseClause.Statement.vmethod_0(this);
					if (bool_0)
					{
						break;
					}
				}
				else
				{
					new Class7364(BinaryExpressionType.Equal, (Class7361)statement.Expression, caseClause.Expression).vmethod_0(this);
					if (Result.vmethod_2())
					{
						caseClause.Statement.vmethod_0(this);
						flag = true;
						if (bool_0)
						{
							break;
						}
					}
				}
				if (class7381_0 != null)
				{
					class7381_0 = null;
					break;
				}
			}
		}
		if (!flag && statement.DefaultStatement != null)
		{
			statement.DefaultStatement.vmethod_0(this);
			if (class7381_0 != null)
			{
				class7381_0 = null;
			}
		}
	}

	public void imethod_15(Class7392 statement)
	{
		Result = Class7437.class7437_0;
		if (statement.Expression != null)
		{
			statement.Expression.vmethod_0(this);
		}
		throw new Exception88(Result);
	}

	public void imethod_16(Class7393 statement)
	{
		try
		{
			statement.Statement.vmethod_0(this);
		}
		catch (Exception ex)
		{
			if (statement.Catch != null)
			{
				Exception88 exception = ex as Exception88;
				if (exception == null)
				{
					exception = new Exception88(Global.ErrorClass.method_4(ex.Message));
				}
				if (statement.Catch.Identifier != null)
				{
					method_6(new Class7371(new Class7368(statement.Catch.Identifier), null), exception.Value);
				}
				statement.Catch.Statement.vmethod_0(this);
				return;
			}
			throw;
		}
		finally
		{
			if (statement.Finally != null)
			{
				new Class7399();
				statement.Finally.Statement.vmethod_0(this);
			}
		}
	}

	public void imethod_17(Class7394 statement)
	{
		Result = Class7437.class7437_0;
		if (statement.Expression != null)
		{
			statement.Expression.vmethod_0(this);
			if (statement.Global)
			{
				throw new InvalidOperationException("Cant declare a global variable");
			}
			if (!CurrentScope.vmethod_8(statement.Identifier))
			{
				CurrentScope.method_1(statement.Identifier, Result);
			}
			else
			{
				CurrentScope[statement.Identifier] = Result;
			}
		}
		else if (!CurrentScope.vmethod_8(statement.Identifier))
		{
			CurrentScope.method_1(statement.Identifier, Class7437.class7437_0);
		}
	}

	public void imethod_18(Class7395 statement)
	{
		statement.Condition.vmethod_0(this);
		method_8(Result);
		while (true)
		{
			if (Result.vmethod_2())
			{
				statement.Statement.vmethod_0(this);
				method_3(statement.Label);
				if (method_4())
				{
					break;
				}
				statement.Condition.vmethod_0(this);
				continue;
			}
			return;
		}
		if (class7381_0 != null && statement.Label == class7381_0.Label)
		{
			class7381_0 = null;
		}
	}

	public void imethod_29(Class7373 expression)
	{
		Result = null;
		expression.Expression.vmethod_0(this);
		if (Result != null && Result is Class7400)
		{
			Class7400 @class = (Class7400)Result;
			Class7397[] array = new Class7397[expression.Arguments.Count];
			for (int i = 0; i < expression.Arguments.Count; i++)
			{
				((Class7361)expression.Arguments[i]).vmethod_0(this);
				array[i] = Result;
			}
			Result = @class.vmethod_24(array, null, this);
		}
		else if (!(Result is Class7400))
		{
			throw new Exception88(Global.ErrorClass.method_4("Function expected."));
		}
	}

	public void imethod_31(Class7376 expression)
	{
		Result = null;
		expression.LeftExpression.vmethod_0(this);
		Class7397 result = Result;
		Result = null;
		method_8(result);
		if (result.vmethod_2())
		{
			expression.MiddleExpression.vmethod_0(this);
		}
		else
		{
			expression.RightExpression.vmethod_0(this);
		}
	}

	public static bool smethod_0(Class7397 o)
	{
		if (o != Class7437.class7437_0)
		{
			return o == Class7433.class7433_0;
		}
		return true;
	}

	public Class7428 Compare(Class7397 x, Class7397 y)
	{
		if (x.Type == y.Type)
		{
			if (x == Class7437.class7437_0)
			{
				return Global.BooleanClass.True;
			}
			if (x == Class7433.class7433_0)
			{
				return Global.BooleanClass.True;
			}
			if (x.Type == "number")
			{
				if (x.vmethod_3() == double.NaN)
				{
					return Global.BooleanClass.False;
				}
				if (y.vmethod_3() == double.NaN)
				{
					return Global.BooleanClass.False;
				}
				if (x.vmethod_3() == y.vmethod_3())
				{
					return Global.BooleanClass.True;
				}
				return Global.BooleanClass.False;
			}
			if (x.Type == "string")
			{
				return Global.BooleanClass.method_4(x.ToString() == y.ToString());
			}
			if (x.Type == "boolean")
			{
				return Global.BooleanClass.method_4(x.vmethod_2() == y.vmethod_2());
			}
			if (x.Type == "object")
			{
				return Global.BooleanClass.method_4(x == y);
			}
			return Global.BooleanClass.method_4(x.Value.Equals(y.Value));
		}
		if (x == Class7433.class7433_0 && y == Class7437.class7437_0)
		{
			return Global.BooleanClass.True;
		}
		if (x == Class7437.class7437_0 && y == Class7433.class7433_0)
		{
			return Global.BooleanClass.True;
		}
		if (x.Type == "number" && y.Type == "string")
		{
			return Global.BooleanClass.method_4(x.vmethod_3() == y.vmethod_3());
		}
		if (x.Type == "string" && y.Type == "number")
		{
			return Global.BooleanClass.method_4(x.vmethod_3() == y.vmethod_3());
		}
		if (!(x.Type == "boolean") && !(y.Type == "boolean"))
		{
			if (y.Type == "object" && (x.Type == "string" || x.Type == "number"))
			{
				return Compare(x, y.vmethod_1(Global));
			}
			if (x.Type == "object" && (y.Type == "string" || y.Type == "number"))
			{
				return Compare(x.vmethod_1(Global), y);
			}
			return Global.BooleanClass.False;
		}
		return Global.BooleanClass.method_4(x.vmethod_3() == y.vmethod_3());
	}

	public static bool CompareTo(Class7397 x, Class7397 y, out int result)
	{
		result = 0;
		double num = x.vmethod_3();
		double num2 = y.vmethod_3();
		if (!double.IsNaN(num) && !double.IsNaN(num2))
		{
			if (num < num2)
			{
				result = -1;
			}
			else if (num == num2)
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return true;
		}
		return false;
	}

	public void imethod_30(Class7364 expression)
	{
		expression.LeftExpression.vmethod_0(this);
		method_8(Result);
		Class7397 result = Result;
		if (expression.Type == BinaryExpressionType.And && !result.vmethod_2())
		{
			Result = result;
			return;
		}
		if (expression.Type == BinaryExpressionType.Or && result.vmethod_2())
		{
			Result = result;
			return;
		}
		expression.RightExpression.vmethod_0(this);
		method_8(Result);
		Class7397 result2 = Result;
		int result3;
		switch (expression.Type)
		{
		default:
			throw new NotSupportedException("Unkown binary operator");
		case BinaryExpressionType.And:
			if (result.vmethod_2())
			{
				Result = result2;
			}
			else
			{
				Result = Global.BooleanClass.False;
			}
			break;
		case BinaryExpressionType.Or:
			if (result.vmethod_2())
			{
				Result = result;
			}
			else
			{
				Result = result2;
			}
			break;
		case BinaryExpressionType.NotEqual:
			Result = Global.BooleanClass.method_4(!Compare(result, result2).vmethod_2());
			break;
		case BinaryExpressionType.LesserOrEqual:
			Result = ((!CompareTo(result, result2, out result3) || result3 > 0) ? Global.BooleanClass.False : Global.BooleanClass.True);
			break;
		case BinaryExpressionType.GreaterOrEqual:
			Result = ((!CompareTo(result, result2, out result3) || result3 < 0) ? Global.BooleanClass.False : Global.BooleanClass.True);
			break;
		case BinaryExpressionType.Lesser:
			Result = ((!CompareTo(result, result2, out result3) || result3 >= 0) ? Global.BooleanClass.False : Global.BooleanClass.True);
			break;
		case BinaryExpressionType.Greater:
			Result = ((!CompareTo(result, result2, out result3) || result3 <= 0) ? Global.BooleanClass.False : Global.BooleanClass.True);
			break;
		case BinaryExpressionType.Equal:
			Result = Compare(result, result2);
			break;
		case BinaryExpressionType.Minus:
			Result = Global.NumberClass.method_4(result.vmethod_3() - result2.vmethod_3());
			break;
		case BinaryExpressionType.Plus:
			if (!(result._Class == "String") && !(result2._Class == "String"))
			{
				Result = Global.NumberClass.method_4(result.vmethod_3() + result2.vmethod_3());
			}
			else
			{
				Result = Global.StringClass.method_5(result.ToString() + result2.ToString());
			}
			break;
		case BinaryExpressionType.Modulo:
			if (result2 != Global.NumberClass["NEGATIVE_INFINITY"] && result2 != Global.NumberClass["POSITIVE_INFINITY"])
			{
				if (result2.vmethod_3() == 0.0)
				{
					Result = Global.NumberClass["NaN"];
				}
				else
				{
					Result = Global.NumberClass.method_4(result.vmethod_3() % result2.vmethod_3());
				}
			}
			else
			{
				Result = Global.NumberClass["POSITIVE_INFINITY"];
			}
			break;
		case BinaryExpressionType.Div:
		{
			double num = result2.vmethod_3();
			double num2 = result.vmethod_3();
			if (result2 != Global.NumberClass["NEGATIVE_INFINITY"] && result2 != Global.NumberClass["POSITIVE_INFINITY"])
			{
				if (num == 0.0)
				{
					Result = ((num2 > 0.0) ? Global.NumberClass["POSITIVE_INFINITY"] : Global.NumberClass["NEGATIVE_INFINITY"]);
				}
				else
				{
					Result = Global.NumberClass.method_4(num2 / num);
				}
			}
			else
			{
				Result = Global.NumberClass.method_4(0.0);
			}
			break;
		}
		case BinaryExpressionType.Times:
			Result = Global.NumberClass.method_4(result.vmethod_3() * result2.vmethod_3());
			break;
		case BinaryExpressionType.Pow:
			Result = Global.NumberClass.method_4(Math.Pow(result.vmethod_3(), result2.vmethod_3()));
			break;
		case BinaryExpressionType.BitwiseAnd:
			if (result != Class7437.class7437_0 && result2 != Class7437.class7437_0)
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()) & Convert.ToInt64(result2.vmethod_3()));
			}
			else
			{
				Result = Global.NumberClass.method_4(0.0);
			}
			break;
		case BinaryExpressionType.BitwiseOr:
			if (result == Class7437.class7437_0)
			{
				if (result2 == Class7437.class7437_0)
				{
					Result = Global.NumberClass.method_4(1.0);
				}
				else
				{
					Result = Global.NumberClass.method_4(Convert.ToInt64(result2.vmethod_3()));
				}
			}
			else if (result2 == Class7437.class7437_0)
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()));
			}
			else
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()) | Convert.ToInt64(result2.vmethod_3()));
			}
			break;
		case BinaryExpressionType.BitwiseXOr:
			if (result == Class7437.class7437_0)
			{
				if (result2 == Class7437.class7437_0)
				{
					Result = Global.NumberClass.method_4(1.0);
				}
				else
				{
					Result = Global.NumberClass.method_4(Convert.ToInt64(result2.vmethod_3()));
				}
			}
			else if (result2 == Class7437.class7437_0)
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()));
			}
			else
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()) ^ Convert.ToInt64(result2.vmethod_3()));
			}
			break;
		case BinaryExpressionType.Same:
			if (result.Type != result2.Type)
			{
				Result = Global.BooleanClass.False;
			}
			else if (result is Class7437)
			{
				Result = Global.BooleanClass.True;
			}
			else if (result is Class7433)
			{
				Result = Global.BooleanClass.True;
			}
			else if (result.Type == "number")
			{
				if (result != Global.NumberClass["NaN"] && result2 != Global.NumberClass["NaN"])
				{
					if (result.vmethod_3() == result2.vmethod_3())
					{
						Result = Global.BooleanClass.True;
					}
					else
					{
						Result = Global.BooleanClass.False;
					}
				}
				else
				{
					Result = Global.BooleanClass.False;
				}
			}
			else if (result.Type == "string")
			{
				Result = Global.BooleanClass.method_4(result.ToString() == result2.ToString());
			}
			else if (result.Type == "boolean")
			{
				Result = Global.BooleanClass.method_4(result.vmethod_2() == result2.vmethod_2());
			}
			else if (result == result2)
			{
				Result = Global.BooleanClass.True;
			}
			else
			{
				Result = Global.BooleanClass.False;
			}
			break;
		case BinaryExpressionType.NotSame:
			new Class7364(BinaryExpressionType.Same, expression.LeftExpression, expression.RightExpression).vmethod_0(this);
			Result = Global.BooleanClass.method_4(!Result.vmethod_2());
			break;
		case BinaryExpressionType.LeftShift:
			if (result == Class7437.class7437_0)
			{
				Result = Global.NumberClass.method_4(0.0);
			}
			else if (result2 == Class7437.class7437_0)
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()));
			}
			else
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()) << (int)Convert.ToUInt16(result2.vmethod_3()));
			}
			break;
		case BinaryExpressionType.RightShift:
			if (result == Class7437.class7437_0)
			{
				Result = Global.NumberClass.method_4(0.0);
			}
			else if (result2 == Class7437.class7437_0)
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()));
			}
			else
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()) >> (int)Convert.ToUInt16(result2.vmethod_3()));
			}
			break;
		case BinaryExpressionType.UnsignedRightShift:
			if (result == Class7437.class7437_0)
			{
				Result = Global.NumberClass.method_4(0.0);
			}
			else if (result2 == Class7437.class7437_0)
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()));
			}
			else
			{
				Result = Global.NumberClass.method_4(Convert.ToInt64(result.vmethod_3()) >> (int)Convert.ToUInt16(result2.vmethod_3()));
			}
			break;
		case BinaryExpressionType.InstanceOf:
		{
			Class7400 @class = result2 as Class7400;
			Class7399 class2 = result as Class7399;
			if (@class == null)
			{
				throw new Exception88(Global.TypeErrorClass.method_4("Right argument should be a function: " + expression.RightExpression.ToString()));
			}
			if (class2 == null)
			{
				throw new Exception88(Global.TypeErrorClass.method_4("Left argument should be an object: " + expression.LeftExpression.ToString()));
			}
			Result = Global.BooleanClass.method_4(@class.vmethod_23(class2));
			break;
		}
		case BinaryExpressionType.In:
			if (result2 is Interface402)
			{
				throw new Exception88(Global.ErrorClass.method_4("Cannot apply 'in' operator to the specified member."));
			}
			Result = Global.BooleanClass.method_4(((Class7398)result2).vmethod_9(result));
			break;
		}
	}

	public void imethod_32(Class7377 expression)
	{
		switch (expression.Type)
		{
		case Enum986.const_0:
			expression.Expression.vmethod_0(this);
			if (Result == null)
			{
				Result = Global.StringClass.method_5(Class7437.class7437_0.Type);
			}
			else if (Result is Class7433)
			{
				Result = Global.StringClass.method_5("object");
			}
			else if (Result is Class7400)
			{
				Result = Global.StringClass.method_5("function");
			}
			else
			{
				Result = Global.StringClass.method_5(Result.Type);
			}
			break;
		case Enum986.const_2:
			expression.Expression.vmethod_0(this);
			method_8(Result);
			Result = Global.BooleanClass.method_4(!Result.vmethod_2());
			break;
		case Enum986.const_3:
			expression.Expression.vmethod_0(this);
			method_8(Result);
			Result = Global.NumberClass.method_4(0.0 - Result.vmethod_3());
			break;
		case Enum986.const_4:
			expression.Expression.vmethod_0(this);
			method_8(Result);
			Result = Global.NumberClass.method_4(Result.vmethod_3());
			break;
		case Enum986.const_5:
		{
			expression.Expression.vmethod_0(this);
			method_8(Result);
			Class7397 result = Global.NumberClass.method_4(Result.vmethod_3() + 1.0);
			Class7371 left = ((expression.Expression is Class7371) ? (expression.Expression as Class7371) : new Class7371(expression.Expression, null));
			method_6(left, result);
			break;
		}
		case Enum986.const_6:
		{
			expression.Expression.vmethod_0(this);
			method_8(Result);
			Class7397 result = Global.NumberClass.method_4(Result.vmethod_3() - 1.0);
			Class7371 left = ((expression.Expression is Class7371) ? (expression.Expression as Class7371) : new Class7371(expression.Expression, null));
			method_6(left, result);
			break;
		}
		case Enum986.const_7:
		{
			expression.Expression.vmethod_0(this);
			method_8(Result);
			Class7397 result = Result;
			Class7371 left = ((expression.Expression is Class7371) ? (expression.Expression as Class7371) : new Class7371(expression.Expression, null));
			method_6(left, Global.NumberClass.method_4(result.vmethod_3() + 1.0));
			Result = result;
			break;
		}
		case Enum986.const_8:
		{
			expression.Expression.vmethod_0(this);
			method_8(Result);
			Class7397 result = Result;
			Class7371 left = ((expression.Expression is Class7371) ? (expression.Expression as Class7371) : new Class7371(expression.Expression, null));
			method_6(left, Global.NumberClass.method_4(result.vmethod_3() - 1.0));
			Result = result;
			break;
		}
		case Enum986.const_9:
		{
			if (!(expression.Expression is Class7371 @class))
			{
				throw new NotImplementedException("delete");
			}
			@class.Previous.vmethod_0(this);
			method_8(Result);
			Class7397 result = Result;
			string text = null;
			if (@class.Member is Class7368)
			{
				text = ((Class7368)@class.Member).Text;
			}
			if (@class.Member is Class7369)
			{
				((Class7369)@class.Member).Index.vmethod_0(this);
				text = Result.ToString();
			}
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception88(Global.TypeErrorClass.method_5());
			}
			try
			{
				((Class7398)result).vmethod_17(text);
			}
			catch (Exception89)
			{
				throw new Exception88(Global.TypeErrorClass.method_5());
			}
			((Class7398)result).vmethod_17(text);
			Result = result;
			break;
		}
		case Enum986.const_10:
			expression.Expression.vmethod_0(this);
			Result = Class7437.class7437_0;
			break;
		case Enum986.const_11:
			expression.Expression.vmethod_0(this);
			method_8(Result);
			Result = Global.NumberClass.method_4(0.0 - Result.vmethod_3() - 1.0);
			break;
		case Enum986.const_1:
			break;
		}
	}

	public void imethod_33(Class7378 expression)
	{
		switch (expression.TypeCode)
		{
		case TypeCode.Boolean:
			Result = Global.BooleanClass.method_4((bool)expression.Value);
			break;
		default:
			Result = expression.Value as Class7397;
			break;
		case TypeCode.String:
			Result = Global.StringClass.method_5((string)expression.Value);
			break;
		case TypeCode.Int32:
		case TypeCode.Single:
		case TypeCode.Double:
			Result = Global.NumberClass.method_4(Convert.ToDouble(expression.Value));
			break;
		}
	}

	public void imethod_21(Class7366 fe)
	{
		Result = method_7(fe);
	}

	public void imethod_35(Class7360 expression)
	{
		throw new NotImplementedException();
	}

	public void imethod_22(Class7371 expression)
	{
		if (expression.Previous != null)
		{
			expression.Previous.vmethod_0(this);
		}
		expression.Member.vmethod_0(this);
	}

	public void method_8(object value)
	{
		if (value == null)
		{
			throw new Exception88(Global.ReferenceErrorClass.method_4(string_0 + " is not defined"));
		}
	}

	public void imethod_24(Class7369 indexer)
	{
		method_8(Result);
		Class7399 @class = (Class7399)Result;
		indexer.Index.vmethod_0(this);
		if (@class._Class == "String")
		{
			method_5(Global.StringClass.method_5(@class.ToString()[Convert.ToInt32(Result.vmethod_3())].ToString()), @class);
		}
		else if (@class.Indexer != null)
		{
			method_5(@class.Indexer.imethod_0(@class, Result), @class);
		}
		else
		{
			method_5(@class[Result], @class);
		}
	}

	public void imethod_23(Class7372 methodCall)
	{
		Class7398 callTarget = CallTarget;
		Class7397 result = Result;
		if ((result == Class7437.class7437_0 || Result == null) && string.IsNullOrEmpty(string_0))
		{
			throw new Exception88(Global.TypeErrorClass.method_4("Method isn't defined"));
		}
		Class7397[] array = new Class7397[methodCall.Arguments.Count];
		if (methodCall.Arguments.Count > 0)
		{
			for (int i = 0; i < methodCall.Arguments.Count; i++)
			{
				((Class7361)methodCall.Arguments[i]).vmethod_0(this);
				array[i] = Result;
			}
		}
		if (result is Class7400)
		{
			Class7400 @class = (Class7400)result;
			string text = @class.Name + "(";
			string[] array2 = new string[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] != null)
				{
					array2[j] = array[j].vmethod_6();
				}
				else
				{
					array2[j] = "null";
				}
			}
			text += string.Join(", ", array2);
			text += ")";
			CallStack.Push(text);
			class7397_0 = Class7437.class7437_0;
			Class7397[] array3 = new Class7397[array.Length];
			array.CopyTo(array3, 0);
			imethod_37(@class, callTarget, array);
			for (int k = 0; k < array3.Length; k++)
			{
				if (array3[k] != array[k])
				{
					if (methodCall.Arguments[k] is Class7371 && ((Class7371)methodCall.Arguments[k]).Member is Interface400)
					{
						method_6((Class7371)methodCall.Arguments[k], array[k]);
					}
					else if (methodCall.Arguments[k] is Class7367)
					{
						method_6(new Class7371((Class7361)methodCall.Arguments[k], null), array[k]);
					}
				}
			}
			CallStack.Pop();
			Result = class7397_0;
			class7397_0 = Class7437.class7437_0;
			return;
		}
		throw new Exception88(Global.ErrorClass.method_4("Function expected."));
	}

	public void imethod_37(Class7400 function, Class7398 that, Class7397[] parameters)
	{
		if (function == null)
		{
			return;
		}
		if (int_1++ > 100)
		{
			throw new Exception88(Global.ErrorClass.method_4("Too many recursions in the script."));
		}
		Class7426 @class = new Class7426(Global, function, parameters);
		Class7438 class2 = new Class7438((function.Scope != null) ? function.Scope : GlobalScope);
		for (int i = 0; i < function.Arguments.Count; i++)
		{
			if (i < parameters.Length)
			{
				class2.vmethod_18(new Class7358(class2, (string)function.Arguments[i], @class.vmethod_11(i.ToString()), @class));
			}
			else
			{
				class2.vmethod_18(new Class7359(class2, (string)function.Arguments[i], Class7437.class7437_0));
			}
		}
		if (method_9(Enum987.flag_0))
		{
			class2.method_1(Class7438.string_22, @class);
		}
		else
		{
			@class.method_1(Class7438.string_22, @class);
		}
		if (that != null)
		{
			class2.method_1(Class7438.string_21, that);
		}
		else
		{
			class2.method_1(Class7438.string_21, that = Global as Class7399);
		}
		method_1(class2);
		try
		{
			Result = function.vmethod_25(this, that, parameters);
			if (bool_0)
			{
				bool_0 = false;
			}
		}
		finally
		{
			method_2();
			int_1--;
		}
	}

	private bool method_9(Enum987 options)
	{
		return Global.imethod_0(options);
	}

	public void imethod_25(Class7368 expression)
	{
		Class7398 @class = Result as Class7398;
		Result = null;
		string text = (string_0 = expression.Text);
		Class7397 result = null;
		if (@class != null && @class.vmethod_15(text, out result))
		{
			method_5(result, @class);
			return;
		}
		if (Result == null && stringBuilder_0.Length > 0)
		{
			stringBuilder_0.Append('.').Append(text);
		}
		method_5(Class7437.class7437_0, @class);
	}

	public void imethod_26(Class7374 expression)
	{
		Class7398 @class = Result as Class7398;
		switch (expression.Mode)
		{
		case Enum985.const_0:
			expression.Expression.vmethod_0(this);
			@class.vmethod_18(new Class7359(@class, expression.Name, Result));
			break;
		case Enum985.const_1:
		case Enum985.const_2:
		{
			Class7400 getFunction = null;
			Class7400 setFunction = null;
			if (expression.GetExpression != null)
			{
				expression.GetExpression.vmethod_0(this);
				getFunction = (Class7400)Result;
			}
			if (expression.SetExpression != null)
			{
				expression.SetExpression.vmethod_0(this);
				setFunction = (Class7400)Result;
			}
			Class7353 class2 = new Class7353(Global, @class, expression.Name);
			class2.GetFunction = getFunction;
			class2.SetFunction = setFunction;
			class2.Enumerable = true;
			@class.vmethod_18(class2);
			break;
		}
		}
	}

	public void imethod_27(Class7367 expression)
	{
		Result = null;
		string text = (string_0 = expression.Text);
		Class7352 result = null;
		if (CurrentScope.vmethod_13(text, out result))
		{
			if (!result.isReference)
			{
				Result = result.vmethod_1(CurrentScope);
			}
			else
			{
				Class7358 @class = result as Class7358;
				method_5(@class.vmethod_1(CurrentScope), @class.targetObject);
			}
			if (Result != null)
			{
				return;
			}
		}
		if (text == "null")
		{
			Result = Class7433.class7433_0;
		}
		if (text == "undefined")
		{
			Result = Class7437.class7437_0;
		}
		if (Result == null)
		{
			stringBuilder_0.Append(text);
		}
	}

	public void imethod_28(Class7370 json)
	{
		Class7399 result = Global.ObjectClass.method_6();
		foreach (DictionaryEntry value in json.Values)
		{
			Result = result;
			((Class7361)value.Value).vmethod_0(this);
		}
		Result = result;
	}

	public void imethod_19(Class7362 expression)
	{
		Class7427 @class = Global.ArrayClass.method_4();
		_ = expression.Parameters.Count;
		for (int i = 0; i < expression.Parameters.Count; i++)
		{
			((Class7360)expression.Parameters[i]).vmethod_0(this);
			@class[i.ToString()] = Result;
		}
		Result = @class;
	}

	public void imethod_34(Class7375 expression)
	{
		Result = Global.RegExpClass.method_5(expression.Regexp, expression.Options.IndexOf("g") != -1, expression.Options.IndexOf("i") != -1, expression.Options.IndexOf("m") != -1);
	}

	public Class7678(Enum987 options)
	{
		interface401_0 = new Class7431(this, options);
		class7438_0 = new Class7438(Global as Class7399);
		method_1(GlobalScope);
		CallStack = new Stack<string>();
	}
}
