using System;
using System.Collections;
using System.Globalization;
using ns176;
using ns183;
using ns187;
using ns195;

namespace ns186;

internal class Class5388 : Class5387
{
	private Class5750 class5750_0;

	private static string string_6;

	private static Hashtable hashtable_0;

	static Class5388()
	{
		string_6 = "em";
		hashtable_0 = new Hashtable();
		hashtable_0.Add("ceiling", new Class5016());
		hashtable_0.Add("floor", new Class5017());
		hashtable_0.Add("round", new Class5022());
		hashtable_0.Add("min", new Class5020());
		hashtable_0.Add("max", new Class5019());
		hashtable_0.Add("abs", new Class5015());
		hashtable_0.Add("rgb", new Class5021());
		hashtable_0.Add("system-color", new Class5023());
		hashtable_0.Add("from-table-column", new Class5018());
		hashtable_0.Add("inherited-property-value", new Class5010());
		hashtable_0.Add("from-parent", new Class5008());
		hashtable_0.Add("from-nearest-specified-value", new Class5013());
		hashtable_0.Add("proportional-column-width", new Class5014());
		hashtable_0.Add("label-end", new Class5011());
		hashtable_0.Add("body-start", new Class5005());
		hashtable_0.Add("rgb-icc", new Class5009());
		hashtable_0.Add("rgb-named-color", new Class5012());
		hashtable_0.Add("cie-lab-color", new Class5006());
		hashtable_0.Add("cmyk", new Class5007());
		hashtable_0.Add("rect", new Class5004());
	}

	public static Class5024 smethod_5(string expr, Class5750 propInfo)
	{
		try
		{
			return new Class5388(expr, propInfo).method_8();
		}
		catch (Exception55 exception)
		{
			exception.method_5(propInfo);
			throw exception;
		}
		catch (Exception)
		{
			throw;
		}
	}

	private Class5388(string propExpr, Class5750 pInfo)
		: base(propExpr)
	{
		class5750_0 = pInfo;
	}

	private Class5024 method_8()
	{
		method_0();
		if (int_18 == 0)
		{
			return Class5050.smethod_0(string.Empty);
		}
		Class5027 @class = null;
		Class5024 class2;
		while (true)
		{
			class2 = method_9();
			if (int_18 == 0)
			{
				break;
			}
			if (@class == null)
			{
				@class = new Class5027(class2);
			}
			else
			{
				@class.vmethod_14(class2);
			}
		}
		if (@class != null)
		{
			@class.vmethod_14(class2);
			return @class;
		}
		return class2;
	}

	private Class5024 method_9()
	{
		Class5024 @class = method_10();
		bool flag = false;
		while (!flag)
		{
			switch (int_18)
			{
			default:
				flag = true;
				break;
			case 8:
				method_0();
				@class = smethod_6(@class.vmethod_10(), method_10().vmethod_10());
				break;
			case 9:
				method_0();
				@class = smethod_7(@class.vmethod_10(), method_10().vmethod_10());
				break;
			}
		}
		return @class;
	}

	private Class5024 method_10()
	{
		Class5024 @class = method_11();
		bool flag = false;
		while (!flag)
		{
			switch (int_18)
			{
			default:
				flag = true;
				break;
			case 10:
				method_0();
				@class = smethod_11(Convert.ToDouble(@class.vmethod_9()), Convert.ToDouble(method_11().vmethod_9()));
				break;
			case 11:
				method_0();
				@class = smethod_10(@class.vmethod_10(), method_11().vmethod_10());
				break;
			case 2:
				method_0();
				@class = smethod_9(@class.vmethod_10(), method_11().vmethod_10());
				break;
			}
		}
		return @class;
	}

	private Class5024 method_11()
	{
		if (int_18 == 9)
		{
			method_0();
			return smethod_8(method_11().vmethod_10());
		}
		return method_13();
	}

	private void method_12()
	{
		if (int_18 != 4)
		{
			throw new Exception55("expected )");
		}
		method_0();
	}

	private Class5024 method_13()
	{
		if (int_18 == 13)
		{
			method_0();
		}
		Class5024 result;
		switch (int_18)
		{
		case 1:
			result = new Class5047(string_4);
			break;
		case 3:
			method_0();
			result = method_9();
			method_12();
			return result;
		case 5:
			result = Class5050.smethod_0(string_4);
			break;
		case 7:
		{
			Interface162 interface3 = (Interface162)hashtable_0[string_4];
			if (interface3 == null)
			{
				throw new Exception55("no such function: " + string_4);
			}
			method_0();
			class5750_0.method_5(interface3);
			result = ((interface3.imethod_0() >= 0) ? interface3.imethod_2(method_14(interface3), class5750_0) : interface3.imethod_2(method_15(interface3), class5750_0));
			class5750_0.method_6();
			return result;
		}
		case 12:
		{
			int num2 = string_4.Length - int_19;
			string text = string_4.Substring(num2);
			double num3 = double.Parse(Class5479.smethod_0(string_4, 0, num2), NumberStyles.Any, Class4985.smethod_0().Ci);
			if (string_6.Equals(text))
			{
				result = (Class5024)Class5747.smethod_4(Class5048.smethod_0(num3), class5750_0.method_1());
			}
			else if ("px".Equals(text))
			{
				float num4 = class5750_0.method_3().method_0().method_2()
					.method_38();
				result = Class5036.smethod_0(num3, text, 72f / num4);
			}
			else
			{
				result = Class5036.smethod_1(num3, text);
			}
			break;
		}
		default:
			throw new Exception55("syntax error");
		case 14:
		{
			double num = double.Parse(Class5479.smethod_0(string_4, 0, string_4.Length - 1), NumberStyles.Any, Class4985.smethod_0().Ci) / 100.0;
			Interface180 @interface = class5750_0.method_0();
			if (@interface != null)
			{
				if (@interface.imethod_0() == 0)
				{
					result = Class5048.smethod_0(num * @interface.imethod_1());
					break;
				}
				if (@interface.imethod_0() != 1)
				{
					throw new Exception55("Illegal percent dimension value");
				}
				if (@interface is Class5743)
				{
					if (num == 0.0)
					{
						result = Class5036.class5036_0;
						break;
					}
					Interface182 interface2 = ((Class5743)@interface).method_0();
					if (interface2 != null && interface2.imethod_4())
					{
						result = Class5036.smethod_2(num * (double)interface2.imethod_5());
						break;
					}
				}
				result = new Class5037(num, @interface);
			}
			else
			{
				result = Class5048.smethod_0(num);
			}
			break;
		}
		case 15:
			result = Class5040.smethod_0(class5750_0.method_7(), string_4);
			break;
		case 16:
			result = Class5048.smethod_0(double.Parse(string_4, NumberStyles.Any, Class4985.smethod_0().Ci));
			break;
		case 17:
			result = Class5048.smethod_1(int.Parse(string_4));
			break;
		}
		method_0();
		return result;
	}

	private Class5024[] method_14(Interface162 function)
	{
		int num = function.imethod_0();
		Class5024[] array = new Class5024[num];
		int num2 = 0;
		if (int_18 == 4)
		{
			method_0();
		}
		else
		{
			while (true)
			{
				Class5024 @class = method_9();
				if (num2 < num)
				{
					array[num2++] = @class;
				}
				if (int_18 != 13)
				{
					break;
				}
				method_0();
			}
			method_12();
		}
		if (num2 == num - 1 && function.imethod_3())
		{
			array[num2++] = Class5050.smethod_0(class5750_0.method_4().method_17());
		}
		if (num != num2)
		{
			throw new Exception55("Expected " + num + ", but got " + num2 + " args for function");
		}
		return array;
	}

	private Class5024[] method_15(Interface162 function)
	{
		int num = -function.imethod_0();
		ArrayList arrayList = new ArrayList();
		if (int_18 == 4)
		{
			method_0();
		}
		else
		{
			while (true)
			{
				Class5024 value = method_9();
				arrayList.Add(value);
				if (int_18 != 13)
				{
					break;
				}
				method_0();
			}
			method_12();
		}
		if (num > arrayList.Count)
		{
			throw new Exception55("Expected at least " + num + ", but got " + arrayList.Count + " args for function");
		}
		return (Class5024[])arrayList.ToArray(typeof(Class5024));
	}

	private static Class5024 smethod_6(Interface181 op1, Interface181 op2)
	{
		if (op1 == null || op2 == null)
		{
			throw new Exception55("Non numeric operand in addition");
		}
		return (Class5024)Class5747.smethod_0(op1, op2);
	}

	private static Class5024 smethod_7(Interface181 op1, Interface181 op2)
	{
		if (op1 == null || op2 == null)
		{
			throw new Exception55("Non numeric operand in subtraction");
		}
		return (Class5024)Class5747.smethod_2(op1, op2);
	}

	private static Class5024 smethod_8(Interface181 op)
	{
		if (op == null)
		{
			throw new Exception55("Non numeric operand to unary minus");
		}
		return (Class5024)Class5747.smethod_12(op);
	}

	private static Class5024 smethod_9(Interface181 op1, Interface181 op2)
	{
		if (op1 == null || op2 == null)
		{
			throw new Exception55("Non numeric operand in multiplication");
		}
		return (Class5024)Class5747.smethod_4(op1, op2);
	}

	private static Class5024 smethod_10(Interface181 op1, Interface181 op2)
	{
		if (op1 == null || op2 == null)
		{
			throw new Exception55("Non numeric operand in division");
		}
		return (Class5024)Class5747.smethod_6(op1, op2);
	}

	private static Class5024 smethod_11(double op1, double op2)
	{
		return Class5048.smethod_0(op1 % op2);
	}
}
