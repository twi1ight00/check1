using System;
using System.Collections;
using System.Text;

namespace ns194;

internal class Class5766 : Class5174.Interface164
{
	internal class Class5767 : Class5174.Interface165
	{
		public Class5174.Interface164 imethod_0(string fieldName, string values)
		{
			return new Class5766(fieldName, values);
		}

		public string imethod_1()
		{
			return "choice";
		}
	}

	private static string string_0 = "\\{([^\\}]+)\\}";

	private string string_1;

	public Class5766(string fieldName, string choicesPattern)
	{
		string_1 = fieldName;
	}

	public bool imethod_1(Hashtable @params)
	{
		object obj = @params[string_1];
		return obj != null;
	}

	public void imethod_0(StringBuilder sb, Hashtable @params)
	{
		throw new NotImplementedException();
	}

	public override string ToString()
	{
		return "{" + string_1 + ",choice, ....}";
	}
}
