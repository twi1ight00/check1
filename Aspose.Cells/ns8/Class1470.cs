using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using ns16;

namespace ns8;

internal class Class1470
{
	private Class1487 class1487_0;

	private Workbook workbook_0;

	private Worksheet worksheet_0;

	private ArrayList arrayList_0;

	private double double_0;

	private int int_0;

	private Class1478 class1478_0;

	private Class1482 class1482_0;

	private bool bool_0 = true;

	private HtmlSaveOptions htmlSaveOptions_0;

	private string string_0;

	[SpecialName]
	public void method_0(string string_1)
	{
		string_0 = string_1;
	}

	internal Class1470(Class1478 class1478_1, Worksheet worksheet_1, Class1487 class1487_1, string string_1, string string_2, string string_3, string string_4, HtmlSaveOptions htmlSaveOptions_1)
	{
		htmlSaveOptions_0 = htmlSaveOptions_1;
		class1478_0 = class1478_1;
		string_0 = string_2;
		worksheet_0 = worksheet_1;
		class1487_0 = class1487_1;
		class1482_0 = new Class1482(class1478_0, worksheet_1, class1487_1, string_1, string_0, string_3, string_4, htmlSaveOptions_1);
		workbook_0 = class1478_0.workbook_0;
		arrayList_0 = new ArrayList();
		double_0 = worksheet_0.Cells.StandardHeight;
		int_0 = worksheet_0.Cells.StandardWidthPixels;
	}

	internal void Write()
	{
		method_10();
		method_8();
		method_1();
		class1487_0.method_8("</table>");
	}

	private void method_1()
	{
		Cells cells = worksheet_0.Cells;
		_ = cells.Count;
		int num = -1;
		for (int i = 0; i < cells.Rows.Count; i++)
		{
			workbook_0.method_30();
			Row rowByIndex = cells.Rows.GetRowByIndex(i);
			int num2 = rowByIndex.int_0;
			if (num2 > num + 1)
			{
				method_2(num, num2);
			}
			method_5(rowByIndex);
			num = num2;
		}
		if (num < class1482_0.method_2())
		{
			method_2(num, class1482_0.method_2() + 1);
		}
		method_4();
	}

	private void method_2(int int_1, int int_2)
	{
		Class1480 @class = null;
		for (int i = int_1 + 1; i < int_2; i++)
		{
			Class1480 class2 = class1482_0.method_22(null, i);
			class2.method_0(string_0);
			if (method_3(@class, class2))
			{
				Class1480 class3 = @class;
				class3.method_2(class3.method_1() + 1);
				continue;
			}
			if (@class != null)
			{
				method_6(@class);
			}
			@class = class2;
		}
		if (@class != null)
		{
			method_6(@class);
		}
	}

	private bool method_3(Class1480 class1480_0, Class1480 class1480_1)
	{
		if (class1480_0 != null && class1480_1 != null)
		{
			if (class1480_0.Row == null && class1480_0.method_30() && class1480_1.Row == null && class1480_1.method_30())
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private void method_4()
	{
		class1487_0.method_8("<![if supportMisalignedColumns]>");
		class1487_0.method_8(" <tr height=0 style='display:none'>");
		for (int i = 0; i <= class1482_0.method_1(); i++)
		{
			int columnWidthPixel = class1482_0.GetColumnWidthPixel(i);
			double num = class1478_0.method_3().method_7(columnWidthPixel);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("  <td width=").Append(Class1618.smethod_80(columnWidthPixel)).Append(" style='width:")
				.Append(Class1618.smethod_79(num))
				.Append("pt'></td>");
			class1487_0.method_8(stringBuilder.ToString());
		}
		class1487_0.method_8(" </tr>");
		class1487_0.method_8(" <![endif]>");
	}

	private void method_5(Row row_0)
	{
		Class1480 @class = class1482_0.method_22(row_0, row_0.Index);
		int num = -1;
		for (int i = 0; i <= worksheet_0.Cells.MaxColumn; i++)
		{
			Cell cell = worksheet_0.Cells[row_0.Index, i];
			if (num != cell.Column)
			{
				@class.method_6(cell);
				num = cell.Column;
			}
		}
		@class.method_7(class1482_0.method_1());
		method_6(@class);
	}

	private void method_6(Class1480 class1480_0)
	{
		if (bool_0)
		{
			class1480_0.bool_0 = true;
			bool_0 = false;
		}
		if (!method_7(class1480_0))
		{
			ArrayList arrayList = class1480_0.method_14();
			for (int i = 0; i < arrayList.Count; i++)
			{
				string text = (string)arrayList[i];
				class1487_0.method_8(text);
			}
			class1487_0.method_8(" </tr>");
		}
	}

	private bool method_7(Class1480 class1480_0)
	{
		double num = class1480_0.method_32();
		StringBuilder stringBuilder = new StringBuilder(100);
		StringBuilder stringBuilder2 = new StringBuilder(100);
		if (num > 1E-07)
		{
			stringBuilder.Append(" <tr height=");
			stringBuilder2.Append(" style='mso-height-source:userset;height:");
			stringBuilder.Append(class1478_0.method_3().method_6(num));
			stringBuilder2.Append(Class1618.smethod_79(num)).Append("pt");
		}
		else
		{
			if (htmlSaveOptions_0.HiddenRowDisplayType == HtmlHiddenRowDisplayType.Remove)
			{
				return true;
			}
			stringBuilder.Append(" <tr height=0");
			stringBuilder2.Append(" style='display:none");
		}
		if (class1480_0.method_1() > 1)
		{
			stringBuilder2.Append(";mso-xlrowspan:").Append(Class1618.smethod_80(class1480_0.method_1()));
		}
		Row row = class1480_0.Row;
		if (row != null && row.method_10() != -1 && row.method_10() != 15)
		{
			stringBuilder.Append(" class=x").Append(Class1618.smethod_80(row.method_10()));
		}
		stringBuilder.Append(stringBuilder2.ToString()).Append("'>");
		class1487_0.method_8(stringBuilder.ToString());
		return false;
	}

	private void method_8()
	{
		ArrayList arrayList = class1482_0.method_13();
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1477 class1477_ = (Class1477)arrayList[i];
			method_9(class1477_);
		}
	}

	private void method_9(Class1477 class1477_0)
	{
		StringBuilder stringBuilder = new StringBuilder(100);
		if (class1477_0.bool_1)
		{
			stringBuilder.Append(" <col");
			stringBuilder.Append(" width=").Append(Class1618.smethod_80(int_0));
			if (class1477_0.int_1 > 1)
			{
				stringBuilder.Append(" span=").Append(Class1618.smethod_80(class1477_0.int_1));
			}
			stringBuilder.Append(" style='width:").Append(Class1618.smethod_79(class1478_0.method_3().method_7(int_0))).Append("pt'>");
		}
		else if (class1477_0.bool_0)
		{
			int int_ = class1477_0.int_3;
			stringBuilder.Append(" <col");
			if (int_ != 15)
			{
				stringBuilder.Append(" class=x").Append(Class1618.smethod_80(int_));
			}
			stringBuilder.Append(" width=0");
			if (class1477_0.int_1 > 1)
			{
				stringBuilder.Append(" span=").Append(Class1618.smethod_80(class1477_0.int_1));
			}
			if (htmlSaveOptions_0.HiddenColDisplayType == HtmlHiddenColDisplayType.Remove)
			{
				stringBuilder.Append(" style='mso-width-source:userset;mso-width-alt:0'>");
			}
			else
			{
				stringBuilder.Append(" style='display:none;mso-width-source:userset;mso-width-alt:0'>");
			}
		}
		else
		{
			int int_2 = class1477_0.int_3;
			stringBuilder.Append(" <col");
			if (int_2 != 15)
			{
				stringBuilder.Append(" class=x").Append(Class1618.smethod_80(int_2));
			}
			stringBuilder.Append(" width=").Append(Class1618.smethod_80(class1477_0.int_2));
			if (class1477_0.int_1 > 1)
			{
				stringBuilder.Append(" span=").Append(Class1618.smethod_80(class1477_0.int_1));
			}
			stringBuilder.Append(" style='mso-width-source:userset;width:").Append(Class1618.smethod_80(class1477_0.int_2 * 3 / 4)).Append("pt'>");
		}
		class1487_0.method_8(stringBuilder.ToString());
	}

	private void method_10()
	{
		long num = class1482_0.method_14();
		long num2 = num * 3 / 4;
		string text = "<table border=0 cellpadding=0 cellspacing=0 width=" + Class1618.smethod_82(num) + " style='border-collapse: ";
		class1487_0.method_8(text.ToString());
		text = " collapse;table-layout:fixed;width:" + Class1618.smethod_82(num2) + "pt'>";
		class1487_0.method_8(text.ToString());
	}
}
