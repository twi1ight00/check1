using System;
using System.Collections;
using System.Text;

namespace ns194;

internal class Class5772 : Class5174.Interface164
{
	internal class Class5773 : Class5174.Interface165
	{
		public Class5174.Interface164 imethod_0(string fieldName, string values)
		{
			return new Class5772(fieldName);
		}

		public string imethod_1()
		{
			return "glyph-name";
		}
	}

	private string string_0;

	public Class5772(string fieldName)
	{
		string_0 = fieldName;
	}

	public bool imethod_1(Hashtable @params)
	{
		object obj = @params[string_0];
		if (obj != null)
		{
			return method_0(obj).Length > 0;
		}
		return false;
	}

	private string method_0(object obj)
	{
		if (!(obj is char c))
		{
			throw new ArgumentException("Value for glyph name part must be a Character but was: " + obj.GetType().Name);
		}
		return Class5774.smethod_1(c.ToString());
	}

	public void imethod_0(StringBuilder sb, Hashtable @params)
	{
		if (!@params.ContainsKey(string_0))
		{
			throw new ArgumentException("Message pattern contains unsupported field name: " + string_0);
		}
		object obj = @params[string_0];
		sb.Append(method_0(obj));
	}

	public string method_1()
	{
		return "{" + string_0 + ",glyph-name}";
	}
}
