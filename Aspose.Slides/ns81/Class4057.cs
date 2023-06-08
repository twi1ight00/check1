using System;
using ns305;

namespace ns81;

internal class Class4057 : Class4055
{
	public const string string_2 = "first-line";

	public const string string_3 = "first-letter";

	public const string string_4 = "before";

	public const string string_5 = "after";

	public const string string_6 = "target";

	public const string string_7 = "selection";

	public const string string_8 = "hover";

	public const string string_9 = "focus";

	public const string string_10 = "link";

	public override int SelectorType => 9;

	public override string SelectorText => ":" + base.LocalName;

	public override int Specificity => 1000;

	public Class4057(string uri, string name)
		: base(uri, name)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		return base.LocalName.Equals(pseudoElement, StringComparison.InvariantCultureIgnoreCase);
	}

	public override bool vmethod_1()
	{
		return true;
	}
}
