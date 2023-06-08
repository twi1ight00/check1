using ns56;

namespace ns24;

internal class Class494
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private Class1885 class1885_0;

	public bool IsDateTimeVisible
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

	public bool IsFooterVisible
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

	public bool IsHeaderVisible
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

	public bool IsSlideNumberVisible
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

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	internal Class494()
	{
	}

	public void Remove()
	{
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		class1885_0 = null;
	}
}
