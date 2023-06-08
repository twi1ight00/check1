using System.Collections;
using Aspose.Cells;
using ns25;

namespace ns2;

internal abstract class Class978
{
	internal readonly WorksheetCollection worksheetCollection_0;

	internal readonly LightCellsDataProvider lightCellsDataProvider_0;

	internal readonly Class521 class521_0;

	private readonly int int_0;

	private readonly Class1301 class1301_0;

	private readonly Class1683 class1683_0;

	private readonly int int_1;

	internal readonly int int_2;

	internal readonly int int_3;

	internal readonly Hashtable hashtable_0 = new Hashtable();

	internal readonly ArrayList arrayList_0 = new ArrayList();

	internal readonly ArrayList arrayList_1 = new ArrayList();

	internal uint uint_0;

	public Class978(Class521 class521_1, LightCellsDataProvider lightCellsDataProvider_1)
	{
		class521_0 = class521_1;
		worksheetCollection_0 = class521_1.workbook_0.Worksheets;
		lightCellsDataProvider_0 = lightCellsDataProvider_1;
		if (Class972.smethod_0() != 0)
		{
			int_0 = worksheetCollection_0.Count - 1;
		}
		else
		{
			int_0 = worksheetCollection_0.Count - 2;
		}
		class1301_0 = worksheetCollection_0.class1301_0;
		int_2 = class1301_0.method_3();
		class1683_0 = worksheetCollection_0.method_58();
		int_3 = class1683_0.Count;
		uint_0 = class1301_0.method_2();
		int_1 = class521_1.int_1 - int_3;
	}

	public Interface0 method_0(Worksheet worksheet_0)
	{
		int index = worksheet_0.Index;
		if (index <= int_0 && lightCellsDataProvider_0.StartSheet(index))
		{
			return new Class976(worksheet_0, lightCellsDataProvider_0, this);
		}
		return null;
	}

	public Style method_1(int int_4)
	{
		if (int_4 < 0)
		{
			return class1683_0[15];
		}
		if (int_4 < int_3)
		{
			return class1683_0[int_4];
		}
		return (Style)arrayList_1[int_4 - int_3];
	}

	public int method_2(Style style_0)
	{
		if (style_0.Name != null)
		{
			return method_3(class1683_0.method_3(style_0));
		}
		int num = arrayList_1.Count - 1;
		while (true)
		{
			if (num > -1)
			{
				if (style_0.method_31((Style)arrayList_1[num]))
				{
					break;
				}
				num--;
				continue;
			}
			int num2 = class1683_0.method_2(style_0);
			if (num2 > -1 && num2 < int_3)
			{
				return num2;
			}
			Style style = new Style(worksheetCollection_0);
			style.Copy(style_0);
			return method_4(style);
		}
		return int_3 + num;
	}

	public int method_3(int int_4)
	{
		if (int_4 < int_3)
		{
			return int_4;
		}
		Style style = class1683_0[int_4];
		int num = arrayList_1.Count - 1;
		while (true)
		{
			if (num > -1)
			{
				if (style.method_31((Style)arrayList_1[num]))
				{
					break;
				}
				num--;
				continue;
			}
			if (style.method_12() >= int_3)
			{
				Style style2 = class1683_0[style.method_12()];
				bool flag = true;
				int num2 = arrayList_1.Count - 1;
				while (num2 > -1)
				{
					if (!style2.method_31((Style)arrayList_1[num2]))
					{
						num2--;
						continue;
					}
					flag = false;
					break;
				}
				if (flag)
				{
					method_4(style2);
				}
			}
			return method_4(style);
		}
		return int_3 + num;
	}

	private int method_4(Style style_0)
	{
		int num = int_3 + arrayList_1.Count;
		if (num >= int_1)
		{
			throw new CellsException(ExceptionType.Limitation, "You have used too many different styles.");
		}
		Font font = style_0.method_40();
		if (font != null)
		{
			worksheetCollection_0.method_63(font);
		}
		string custom = style_0.Custom;
		if (custom != null && custom != "")
		{
			style_0.method_45(worksheetCollection_0.method_65(custom));
		}
		vmethod_0(style_0, num);
		arrayList_1.Add(style_0);
		return num;
	}

	internal abstract void vmethod_0(Style style_0, int int_4);

	public int method_5(string string_0)
	{
		return method_6(string_0, lightCellsDataProvider_0.IsGatherString());
	}

	public int method_6(string string_0, bool bool_0)
	{
		uint_0++;
		Class1719 @class = (Class1719)class1301_0.method_0()[string_0];
		if (@class != null && @class.int_1 < int_2)
		{
			return @class.int_1;
		}
		object obj = hashtable_0[string_0];
		if (obj != null)
		{
			return (int)obj;
		}
		int num = int_2 + arrayList_0.Count;
		if (bool_0)
		{
			hashtable_0.Add(string_0, num);
		}
		arrayList_0.Add(string_0);
		return num;
	}
}
