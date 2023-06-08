using System.Collections.Generic;
using System.Text;
using ns284;

namespace ns296;

internal class Class6812 : Class6806
{
	public Class6812(Class6983 element)
		: base(element)
	{
	}

	public override string vmethod_0()
	{
		StringBuilder stringBuilder = new StringBuilder();
		IList<string> family = base.StyleDeclaration.Font.Family;
		if (family.Count == 0)
		{
			return string.Empty;
		}
		string value = family[0];
		if (!smethod_0(value))
		{
			stringBuilder.Append(value);
		}
		else
		{
			stringBuilder.Append('\'').Append(value).Append('\'');
		}
		for (int i = 1; i < family.Count; i++)
		{
			stringBuilder.Append(", ");
			value = family[i];
			if (!smethod_0(value))
			{
				stringBuilder.Append(value);
			}
			else
			{
				stringBuilder.Append('\'').Append(value).Append('\'');
			}
		}
		return stringBuilder.ToString();
	}

	private static bool smethod_0(string value)
	{
		int num = 0;
		while (true)
		{
			if (num < value.Length)
			{
				char c = value[num];
				if (char.IsWhiteSpace(c))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}
}
