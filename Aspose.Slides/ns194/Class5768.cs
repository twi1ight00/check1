using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace ns194;

internal class Class5768 : Class5174.Interface164
{
	internal class Class5770 : Class5174.Interface165
	{
		public Class5174.Interface164 imethod_0(string fieldName, string values)
		{
			return new Class5768(fieldName, values);
		}

		public string imethod_1()
		{
			return "if";
		}
	}

	protected string string_0;

	protected string string_1;

	protected string string_2;

	public Class5768(string fieldName, string values)
	{
		string_0 = fieldName;
		vmethod_0(values);
	}

	protected virtual void vmethod_0(string values)
	{
		string[] array = Regex.Split(values, Class5174.string_0);
		if (array.Length >= 2)
		{
			string_1 = Class5174.smethod_2(array[0]);
			string_2 = Class5174.smethod_2(array[1]);
		}
		else
		{
			string_1 = Class5174.smethod_2(values);
		}
	}

	public void imethod_0(StringBuilder sb, Hashtable @params)
	{
		if (vmethod_1(@params))
		{
			sb.Append(string_1);
		}
		else if (string_2 != null)
		{
			sb.Append(string_2);
		}
	}

	protected virtual bool vmethod_1(Hashtable @params)
	{
		object obj = @params[string_0];
		if (obj is bool)
		{
			return (bool)obj;
		}
		return obj != null;
	}

	public bool imethod_1(Hashtable @params)
	{
		if (!vmethod_1(@params))
		{
			return string_2 != null;
		}
		return true;
	}

	public override string ToString()
	{
		return "{" + string_0 + ", if...}";
	}
}
