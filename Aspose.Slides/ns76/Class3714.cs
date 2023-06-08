using ns73;

namespace ns76;

internal class Class3714 : Class3707, Interface59, Interface74
{
	private Class3733 class3733_0;

	private Class3716 class3716_0;

	public Class3733 SelectorList
	{
		get
		{
			return class3733_0;
		}
		set
		{
			class3733_0 = value;
		}
	}

	public override string CSSText
	{
		get
		{
			return $"{SelectorText} {{ {Style} }}";
		}
		set
		{
			class3716_0.CSSText = value;
		}
	}

	public string SelectorText => class3733_0.ToString();

	public Interface58 Style => class3716_0;

	public Class3714(Class3735 styleSheet, Interface59 parentRule)
		: base(styleSheet, parentRule, 1)
	{
		class3733_0 = new Class3733(this);
		class3716_0 = new Class3720(this);
	}
}
