using System.Collections;
using System.Collections.Generic;
using ns322;

namespace ns323;

internal class Class7446 : Interface395, Interface396
{
	private Class7399 class7399_0;

	private Class7431 class7431_0;

	private Class7397 class7397_0;

	private List<string> list_0 = new List<string>();

	public bool DebugMode => false;

	public Class7397 Result
	{
		get
		{
			return class7397_0;
		}
		set
		{
			class7397_0 = value;
		}
	}

	public Class7398 CallTarget => null;

	public Interface401 Global => class7431_0;

	public Class7397 Returned => null;

	public Class7438 GlobalScope => null;

	public Class7446(Class7399 instance, Class7431 global)
	{
		class7399_0 = instance;
		class7431_0 = global;
	}

	public void imethod_0(Class7380 program)
	{
		foreach (Class7675 item in (IEnumerable)program.Statements)
		{
			Class7360 class2 = (Class7360)item.Data;
			class2.vmethod_0(this);
		}
		if (list_0.Count == 0)
		{
			return;
		}
		foreach (string item2 in list_0)
		{
			Class7400 class3 = (Class7400)class7399_0[item2];
			Interface395 visitor = new Class7447(list_0);
			class3.Statement.vmethod_0(visitor);
		}
	}

	public void imethod_1(Class7363 expression)
	{
		if (expression.AssignmentOperator == Enum982.const_0)
		{
			expression.Right.vmethod_0(this);
		}
		if (Result == null)
		{
			return;
		}
		Class7371 @class = expression.Left as Class7371;
		if (@class == null)
		{
			@class = new Class7371(expression.Left, null);
		}
		if (@class.Member is Class7367)
		{
			string text = ((Class7367)@class.Member).Text;
			if (Result is Interface399)
			{
				list_0.Add(text);
			}
			Class7397 result2 = (class7399_0[text] = Result);
			Result = result2;
		}
	}

	public void imethod_2(Class7379 expression)
	{
	}

	public void imethod_3(Class7381 expression)
	{
	}

	public void imethod_4(Class7382 expression)
	{
	}

	public void imethod_5(Class7383 expression)
	{
	}

	public void imethod_6(Class7384 expression)
	{
	}

	public void imethod_7(Class7385 expression)
	{
		expression.Expression.vmethod_0(this);
	}

	public void imethod_8(Class7386 expression)
	{
	}

	public void imethod_9(Class7387 expression)
	{
	}

	public void imethod_10(Class7388 expression)
	{
		class7399_0[expression.Name] = method_0(expression);
		list_0.Add(expression.Name);
	}

	public void imethod_11(Class7389 expression)
	{
	}

	public void imethod_12(Class7390 expression)
	{
	}

	public void imethod_13(Class7391 expression)
	{
	}

	public void imethod_14(Class7396 expression)
	{
	}

	public void imethod_15(Class7392 expression)
	{
	}

	public void imethod_16(Class7393 expression)
	{
	}

	public void imethod_17(Class7394 expression)
	{
	}

	public void imethod_18(Class7395 expression)
	{
	}

	public void imethod_19(Class7362 expression)
	{
	}

	public void imethod_20(Class7365 expression)
	{
	}

	public void imethod_21(Class7366 expression)
	{
		Result = method_0(expression);
	}

	public void imethod_22(Class7371 expression)
	{
	}

	public void imethod_23(Class7372 expression)
	{
	}

	public void imethod_24(Class7369 expression)
	{
	}

	public void imethod_25(Class7368 expression)
	{
	}

	public void imethod_26(Class7374 expression)
	{
	}

	public void imethod_27(Class7367 expression)
	{
	}

	public void imethod_28(Class7370 expression)
	{
	}

	public void imethod_29(Class7373 expression)
	{
	}

	public void imethod_30(Class7364 expression)
	{
	}

	public void imethod_31(Class7376 expression)
	{
	}

	public void imethod_32(Class7377 expression)
	{
	}

	public void imethod_33(Class7378 expression)
	{
	}

	public void imethod_34(Class7375 expression)
	{
	}

	public void imethod_35(Class7360 expression)
	{
	}

	public Class7397 imethod_36(Class7397 result)
	{
		return null;
	}

	public void imethod_37(Class7400 function, Class7398 _this, Class7397[] parameters)
	{
	}

	private Class7400 method_0(Interface399 functionDeclaration)
	{
		Class7400 @class = Global.FunctionClass.method_4();
		@class.Statement = functionDeclaration.Statement;
		@class.Name = functionDeclaration.Name;
		@class.Arguments = functionDeclaration.Parameters;
		return @class;
	}
}
