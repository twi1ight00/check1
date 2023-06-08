using System;
using ns305;

namespace ns81;

internal class Class4012 : Class4011
{
	private const string string_3 = "class";

	private const string string_4 = " ";

	private bool bool_0;

	public override string ConditionText => "." + base.Value;

	public override short ConditionType => 9;

	public Class4012(string namespaceURI, string value)
		: base(namespaceURI, "class", value)
	{
		bool_0 = base.Value.IndexOf(" ") == -1;
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!bool_0)
		{
			return false;
		}
		if (!method_1(e))
		{
			return false;
		}
		StringComparison comparisonType = (base.Rule.ParentStyleSheet.Engine.Context.Settings.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
		string text = method_0(e);
		string value = base.Value;
		int length = text.Length;
		int length2 = value.Length;
		int num = text.IndexOf(value, comparisonType);
		while (true)
		{
			if (num != -1)
			{
				if ((num == 0 || char.IsSeparator(text[num - 1])) && (num + length2 == length || char.IsSeparator(text[num + length2])))
				{
					break;
				}
				num = text.IndexOf(value, num + length2, comparisonType);
				continue;
			}
			return false;
		}
		return true;
	}
}
