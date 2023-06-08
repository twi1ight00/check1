using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class1108
{
	private DataSorter dataSorter_0;

	private int int_0 = -1;

	private SortOrder sortOrder_0;

	private Enum135 enum135_0;

	private Style style_0;

	private int int_1 = -1;

	private IconSetType iconSetType_0;

	private int int_2;

	private string string_0;

	public SortOrder Order
	{
		get
		{
			return sortOrder_0;
		}
		set
		{
			sortOrder_0 = value;
		}
	}

	public int Index
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Enum135 Type => enum135_0;

	public string Value
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			enum135_0 = Enum135.const_0;
		}
	}

	public IconSetType IconSetType => iconSetType_0;

	public int IconId => int_2;

	internal Class1108(DataSorter dataSorter_1)
	{
		dataSorter_0 = dataSorter_1;
	}

	internal void Copy(Class1108 class1108_0)
	{
		int_0 = class1108_0.int_0;
		sortOrder_0 = class1108_0.sortOrder_0;
		enum135_0 = class1108_0.enum135_0;
		if (class1108_0.style_0 != null)
		{
			style_0 = new Style(dataSorter_0.workbook_0.Worksheets);
			style_0.Copy(class1108_0.style_0);
		}
		iconSetType_0 = class1108_0.iconSetType_0;
		int_2 = class1108_0.int_2;
		string_0 = class1108_0.string_0;
	}

	[SpecialName]
	internal DataSorter method_0()
	{
		return dataSorter_0;
	}

	internal void method_1(Enum135 enum135_1)
	{
		enum135_0 = enum135_1;
	}

	internal void method_2(Style style_1)
	{
		style_0 = style_1;
	}

	[SpecialName]
	internal int method_3()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_4(int int_3)
	{
		int_1 = int_3;
	}

	internal void method_5(IconSetType iconSetType_1, int int_3)
	{
		enum135_0 = Enum135.const_3;
		iconSetType_0 = iconSetType_1;
		int_2 = int_3;
	}

	[SpecialName]
	public Style method_6()
	{
		return style_0;
	}

	[SpecialName]
	public void method_7(Style style_1)
	{
		style_0 = style_1;
		enum135_0 = Enum135.const_1;
	}

	[SpecialName]
	public Style method_8()
	{
		return style_0;
	}

	[SpecialName]
	public void method_9(Style style_1)
	{
		style_0 = style_1;
		enum135_0 = Enum135.const_2;
	}
}
