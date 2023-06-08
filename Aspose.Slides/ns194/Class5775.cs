using System;
using System.Collections;
using System.Text;

namespace ns194;

internal class Class5775 : Class5174.Interface164
{
	internal class Class5776 : Class5174.Interface165
	{
		public Class5174.Interface164 imethod_0(string fieldName, string values)
		{
			return new Class5775(fieldName);
		}

		public string imethod_1()
		{
			return "hex";
		}
	}

	private string string_0;

	public Class5775(string fieldName)
	{
		string_0 = fieldName;
	}

	public bool imethod_1(Hashtable @params)
	{
		object obj = @params[string_0];
		return obj != null;
	}

	public void imethod_0(StringBuilder sb, Hashtable @params)
	{
		if (!@params.ContainsKey(string_0))
		{
			throw new ArgumentException("Message pattern contains unsupported field name: " + string_0);
		}
		object obj = @params[string_0];
		if (obj is char)
		{
			sb.Append(((int)obj).ToString("X"));
			return;
		}
		if (!(obj is int))
		{
			throw new ArgumentException("Incompatible value for hex field part: " + obj.GetType().Name);
		}
		sb.Append(((int)obj).ToString("X"));
	}

	public string method_0()
	{
		return "{" + string_0 + ",hex}";
	}
}
