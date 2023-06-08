using System;
using System.Collections;

namespace ns322;

internal class Class7401 : Class7400
{
	private Interface401 interface401_0;

	private Class7397 method_4(Class7399 that)
	{
		return interface401_0.NumberClass.method_4(that.Length);
	}

	private Class7397 method_5(Class7399 that, Class7397[] parameters)
	{
		that.Length = (int)parameters[0].vmethod_3();
		return parameters[0];
	}

	public Class7397 method_6(Class7427 target, Class7397[] parameters)
	{
		Class7427 @class = interface401_0.ArrayClass.method_4();
		for (int i = 0; i < target.Length; i++)
		{
			Class7398 class2 = (Class7398)target[i.ToString()];
			if (Class7678.smethod_0(class2))
			{
				@class[i.ToString()] = interface401_0.StringClass.method_4();
			}
			else if (class2["toString"] is Class7400 function)
			{
				interface401_0.Visitor.imethod_37(function, class2, parameters);
				@class[i.ToString()] = interface401_0.Visitor.Returned;
			}
			else
			{
				@class[i.ToString()] = interface401_0.StringClass.method_4();
			}
		}
		return interface401_0.StringClass.method_5(@class.ToString());
	}

	public Class7397 method_7(Class7427 target, Class7397[] parameters)
	{
		Class7427 @class = interface401_0.ArrayClass.method_4();
		for (int i = 0; i < target.Length; i++)
		{
			Class7398 class2 = (Class7398)target[i.ToString()];
			interface401_0.Visitor.imethod_37((Class7400)class2["toLocaleString"], class2, parameters);
			@class[i.ToString()] = interface401_0.Visitor.Returned;
		}
		return interface401_0.StringClass.method_5(@class.ToString());
	}

	public Class7397 method_8(Class7399 target, Class7397[] parameters)
	{
		return ((Class7427)target).method_10(interface401_0, parameters);
	}

	public Class7397 method_9(Class7399 target, Class7397[] parameters)
	{
		return ((Class7427)target).method_11(interface401_0, (parameters.Length > 0) ? parameters[0] : Class7437.class7437_0);
	}

	public static Class7397 smethod_0(Class7399 target, Class7397[] parameters)
	{
		uint num = Convert.ToUInt32(target.Length);
		if (num == 0)
		{
			return Class7437.class7437_0;
		}
		string index = (num - 1).ToString();
		Class7397 result = target[index];
		target.vmethod_17(index);
		target.Length--;
		return result;
	}

	public Class7397 method_10(Class7398 target, Class7397[] parameters)
	{
		int num = (int)target["length"].vmethod_3();
		foreach (Class7397 value in parameters)
		{
			target[interface401_0.NumberClass.method_4(num)] = value;
			num++;
		}
		return interface401_0.NumberClass.method_4(num);
	}

	public static Class7397 smethod_1(Class7399 target, Class7397[] parameters)
	{
		int length = target.Length;
		int num = length / 2;
		for (int i = 0; i != num; i++)
		{
			string index = (length - i - 1).ToString();
			string index2 = i.ToString();
			Class7397 result = null;
			Class7397 result2 = null;
			bool flag = target.vmethod_15(index2, out result);
			bool flag2 = target.vmethod_15(index, out result2);
			if (flag)
			{
				target[index] = result;
			}
			else
			{
				target.vmethod_17(index);
			}
			if (flag2)
			{
				target[index2] = result2;
			}
			else
			{
				target.vmethod_17(index2);
			}
		}
		return target;
	}

	public static Class7397 smethod_2(Class7398 target, Class7397[] parameters)
	{
		if (target.Length == 0)
		{
			return Class7437.class7437_0;
		}
		Class7397 result = target[0.ToString()];
		for (int i = 1; i < target.Length; i++)
		{
			Class7397 result2 = null;
			string index = i.ToString();
			string index2 = (i - 1).ToString();
			if (target.vmethod_15(index, out result2))
			{
				target[index2] = result2;
			}
			else
			{
				target.vmethod_17(index2);
			}
		}
		target.vmethod_17((target.Length - 1).ToString());
		target.Length--;
		return result;
	}

	public Class7397 method_11(Class7399 target, Class7397[] parameters)
	{
		int num = (int)parameters[0].vmethod_3();
		int num2 = target.Length;
		if (parameters.Length > 1)
		{
			num2 = (int)parameters[1].vmethod_3();
		}
		if (num < 0)
		{
			num += target.Length;
		}
		if (num2 < 0)
		{
			num2 += target.Length;
		}
		if (num > target.Length)
		{
			num = target.Length;
		}
		if (num2 > target.Length)
		{
			num2 = target.Length;
		}
		Class7427 @class = interface401_0.ArrayClass.method_4();
		for (int i = num; i < num2; i++)
		{
			method_10(@class, new Class7397[1] { target[interface401_0.NumberClass.method_4(i)] });
		}
		return @class;
	}

	public Class7397 method_12(Class7399 target, Class7397[] parameters)
	{
		if (target.Length <= 1)
		{
			return target;
		}
		Class7400 @class = null;
		if (parameters.Length > 0)
		{
			@class = parameters[0] as Class7400;
		}
		ArrayList arrayList = new ArrayList();
		int num = (int)target["length"].vmethod_3();
		for (int i = 0; i < num; i++)
		{
			arrayList.Add(target[i.ToString()]);
		}
		if (@class == null)
		{
			@class = new Class7425(interface401_0);
		}
		try
		{
			arrayList.Sort(new Class7684(interface401_0.Visitor, @class));
		}
		catch (Exception ex)
		{
			if (ex.InnerException is Exception88)
			{
				throw ex.InnerException;
			}
			throw;
		}
		for (int j = 0; j < num; j++)
		{
			target[j.ToString()] = (Class7397)arrayList[j];
		}
		return target;
	}

	public Class7397 method_13(Class7399 target, Class7397[] parameters)
	{
		Class7427 @class = interface401_0.ArrayClass.method_4();
		int num = Convert.ToInt32(parameters[0].vmethod_3());
		int num2 = ((num < 0) ? Math.Max(target.Length + num, 0) : Math.Min(num, target.Length));
		int num3 = Math.Min(Math.Max(Convert.ToInt32(parameters[1].vmethod_3()), 0), target.Length - num2);
		int length = target.Length;
		for (int i = 0; i < num3; i++)
		{
			string index = (num + i).ToString();
			Class7397 result = null;
			if (target.vmethod_15(index, out result))
			{
				@class.method_7(i, result);
			}
		}
		ArrayList arrayList = new ArrayList();
		for (int j = 0; j < parameters.Length; j++)
		{
			arrayList.Add(parameters[j]);
		}
		arrayList.RemoveAt(0);
		arrayList.RemoveAt(0);
		if (arrayList.Count < num3)
		{
			for (int k = num2; k < length - num3; k++)
			{
				Class7397 result2 = null;
				string index2 = (k + num3).ToString();
				string index3 = (k + arrayList.Count).ToString();
				if (target.vmethod_15(index2, out result2))
				{
					target[index3] = result2;
				}
				else
				{
					target.vmethod_17(index3);
				}
			}
			for (int num4 = target.Length; num4 > length - num3 + arrayList.Count; num4--)
			{
				target.vmethod_17((num4 - 1).ToString());
			}
			target.Length = length - num3 + arrayList.Count;
		}
		else
		{
			for (int num5 = length - num3; num5 > num2; num5--)
			{
				Class7397 result3 = null;
				string index4 = (num5 + num3 - 1).ToString();
				string index5 = (num5 + arrayList.Count - 1).ToString();
				if (target.vmethod_15(index4, out result3))
				{
					target[index5] = result3;
				}
				else
				{
					target.vmethod_17(index5);
				}
			}
		}
		for (int l = 0; l < arrayList.Count; l++)
		{
			target[l.ToString()] = (Class7397)arrayList[l];
		}
		return @class;
	}

	public Class7397 method_14(Class7399 target, Class7397[] parameters)
	{
		for (int num = target.Length; num > 0; num--)
		{
			Class7397 result = null;
			string index = (num - 1).ToString();
			string index2 = (num + parameters.Length - 1).ToString();
			if (target.vmethod_15(index, out result))
			{
				target[index2] = result;
			}
			else
			{
				target.vmethod_17(index2);
			}
		}
		ArrayList arrayList = new ArrayList(parameters);
		int num2 = 0;
		while (arrayList.Count > 0)
		{
			Class7397 value = (Class7397)arrayList[0];
			arrayList.RemoveAt(0);
			target[num2.ToString()] = value;
			num2++;
		}
		return interface401_0.NumberClass.method_4(target.Length);
	}

	public Class7397 method_15(Class7399 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			return interface401_0.NumberClass.method_4(-1.0);
		}
		int num = (int)target["length"].vmethod_3();
		if (num == 0)
		{
			return interface401_0.NumberClass.method_4(-1.0);
		}
		int num2 = 0;
		if (parameters.Length > 1)
		{
			num2 = Convert.ToInt32(parameters[1].vmethod_3());
		}
		if (num2 >= num)
		{
			return interface401_0.NumberClass.method_4(-1.0);
		}
		Class7397 obj = parameters[0];
		int num3 = ((num2 < 0) ? (num - Math.Abs(num2)) : num2);
		while (true)
		{
			if (num3 < num)
			{
				Class7397 result = null;
				if (target.vmethod_15(num3.ToString(), out result) && result.Equals(obj))
				{
					break;
				}
				num3++;
				continue;
			}
			return interface401_0.NumberClass.method_4(-1.0);
		}
		return interface401_0.NumberClass.method_4(num3);
	}

	public Class7397 method_16(Class7399 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			return interface401_0.NumberClass.method_4(-1.0);
		}
		int length = target.Length;
		if (length == 0)
		{
			return interface401_0.NumberClass.method_4(-1.0);
		}
		int num = length;
		if (parameters.Length > 1)
		{
			num = Convert.ToInt32(parameters[1].vmethod_3());
		}
		Class7397 obj = parameters[0];
		int num2 = ((num < 0) ? (length - Math.Abs(num - 1)) : Math.Min(num, length - 1));
		while (true)
		{
			if (num2 >= 0)
			{
				Class7397 result = null;
				if (target.vmethod_15(num2.ToString(), out result) && result.Equals(obj))
				{
					break;
				}
				num2--;
				continue;
			}
			return interface401_0.NumberClass.method_4(-1.0);
		}
		return interface401_0.NumberClass.method_4(num2);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result;
		if (string_21 == "get_length")
		{
			result = method_4(that as Class7399);
		}
		else if (string_21 == "set_length")
		{
			result = method_5(that as Class7399, parameters);
		}
		else if (string_21 == "toString")
		{
			result = method_6(that as Class7427, parameters);
		}
		else if (string_21 == "toLocaleString")
		{
			result = method_7(that as Class7427, parameters);
		}
		else if (string_21 == "concat")
		{
			result = method_8(that as Class7399, parameters);
		}
		else if (string_21 == "join")
		{
			result = method_9(that as Class7399, parameters);
		}
		else if (string_21 == "pop")
		{
			result = smethod_0(that as Class7399, parameters);
		}
		else if (string_21 == "push")
		{
			result = method_10(that, parameters);
		}
		else if (string_21 == "reverse")
		{
			result = smethod_1(that as Class7399, parameters);
		}
		else if (string_21 == "shift")
		{
			result = smethod_2(that, parameters);
		}
		else if (string_21 == "slice")
		{
			result = method_11(that as Class7399, parameters);
		}
		else if (string_21 == "sort")
		{
			result = method_12(that as Class7399, parameters);
		}
		else if (string_21 == "splice")
		{
			result = method_13(that as Class7399, parameters);
		}
		else if (string_21 == "unshift")
		{
			result = method_14(that as Class7399, parameters);
		}
		else if (string_21 == "indexOf")
		{
			result = method_15(that as Class7399, parameters);
		}
		else
		{
			if (!(string_21 == "lastIndexOf"))
			{
				throw new Exception89("unknown array function");
			}
			result = method_16(that as Class7399, parameters);
		}
		visitor.imethod_36(result);
		return result;
	}

	public override string ToString()
	{
		return $"function {base.Name}";
	}

	public Class7401(Interface401 global, string name, Class7399 prototype)
		: base(prototype)
	{
		string_21 = name;
		interface401_0 = global;
	}
}
