using ns56;

namespace ns24;

internal class Class297 : Class296
{
	private bool bool_0 = true;

	private bool bool_1 = true;

	private string string_0 = "";

	private bool bool_2;

	private bool bool_3;

	private Class1885 class1885_3;

	private Class494 class494_0 = new Class494();

	public bool ShowMasterShapes
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool ShowMasterPlaceholderAnimations
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public string MatchingName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool Preserve
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public Class494 HeaderFooter => class494_0;

	public bool IsUserDrawn
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_3;
		}
		set
		{
			class1885_3 = value;
		}
	}
}
