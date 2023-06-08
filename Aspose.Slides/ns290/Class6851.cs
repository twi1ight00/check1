using ns284;

namespace ns290;

internal class Class6851 : Class6845
{
	private const string string_2 = "ListItem";

	private Class6845 class6845_0;

	private Class6855 class6855_0;

	public Class6845 ContentBox
	{
		get
		{
			return class6845_0;
		}
		set
		{
			class6845_0 = value;
		}
	}

	public Class6855 Marker
	{
		get
		{
			return class6855_0;
		}
		set
		{
			class6855_0 = value;
		}
	}

	public Class6851(Class6844 parent)
		: base(parent)
	{
		base.Tag = "ListItem";
		class6845_0 = new Class6845(this);
		class6845_0.Style.Display = Enum952.const_1;
		base.InnerBoxes.Add(class6845_0);
	}
}
