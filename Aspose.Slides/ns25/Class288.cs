using ns24;
using ns56;
using ns9;

namespace ns25;

internal class Class288 : Class287
{
	private bool bool_2;

	private string string_1;

	private bool bool_3;

	private Class1460 class1460_0;

	private Class1462 class1462_0;

	private Class1461 class1461_0;

	private Class1459 class1459_0;

	private Class1885 class1885_5;

	private Class1885 class1885_6;

	private bool bool_4 = true;

	private Class153 class153_0 = new Class153();

	private Class2074 class2074_0;

	public bool Use1904DateSystem
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

	public string EditingLanguage
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public bool RoundedCorners
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

	public Class1460 PivotSource
	{
		get
		{
			return class1460_0;
		}
		set
		{
			class1460_0 = value;
		}
	}

	public Class1462 Protection
	{
		get
		{
			return class1462_0;
		}
		set
		{
			class1462_0 = value;
		}
	}

	public Class1461 PrintSettings
	{
		get
		{
			return class1461_0;
		}
		set
		{
			class1461_0 = value;
		}
	}

	public Class1459 PivotFormats
	{
		get
		{
			return class1459_0;
		}
		set
		{
			class1459_0 = value;
		}
	}

	public Class1885 ExtensionListOfChartSpace
	{
		get
		{
			return class1885_5;
		}
		set
		{
			class1885_5 = value;
		}
	}

	public Class1885 ExtensionListOfChart
	{
		get
		{
			return class1885_6;
		}
		set
		{
			class1885_6 = value;
		}
	}

	public bool ShowDataLabelsOverMaximum
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public Class153 ColorMappingOverride => class153_0;

	public Class2074 ExternalData
	{
		get
		{
			return class2074_0;
		}
		set
		{
			class2074_0 = value;
		}
	}
}
