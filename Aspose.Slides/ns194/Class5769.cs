using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace ns194;

internal class Class5769 : Class5768
{
	internal class Class5771 : Class5174.Interface165
	{
		public Class5174.Interface164 imethod_0(string fieldName, string values)
		{
			return new Class5769(fieldName, values);
		}

		public string imethod_1()
		{
			return "equals";
		}
	}

	private string string_3;

	public Class5769(string fieldName, string values)
		: base(fieldName, values)
	{
	}

	protected override void vmethod_0(string values)
	{
		string[] array = Regex.Split(values, Class5174.string_0);
		string_3 = array[0];
		if (array.Length == 1)
		{
			throw new ArgumentException("'equals' format must have at least 2 parameters");
		}
		if (array.Length >= 3)
		{
			string_1 = Class5174.smethod_2(array[1]);
			string_2 = Class5174.smethod_2(array[2]);
		}
		else
		{
			string_1 = Class5174.smethod_2(array[1]);
		}
	}

	protected override bool vmethod_1(Hashtable @params)
	{
		return @params[string_0]?.Equals(string_3) ?? false;
	}

	public string method_0()
	{
		return "{" + string_0 + ", equals " + string_3 + "}";
	}
}
