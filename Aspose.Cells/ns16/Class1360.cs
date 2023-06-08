using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns2;

namespace ns16;

internal class Class1360
{
	internal TextAlignmentType textAlignmentType_0 = TextAlignmentType.Left;

	internal TextDirectionType textDirectionType_0 = TextDirectionType.LeftToRight;

	internal Font font_0;

	internal string string_0;

	internal ArrayList arrayList_0;

	internal Workbook workbook_0;

	internal bool bool_0;

	internal Class1363 class1363_0;

	internal static Class1360 smethod_0(Title title_0, Workbook workbook_1)
	{
		Class1360 @class = new Class1360();
		@class.textAlignmentType_0 = title_0.TextHorizontalAlignment;
		@class.textDirectionType_0 = title_0.TextDirection;
		if (title_0.method_12() != null || title_0.method_13() != -1)
		{
			@class.font_0 = title_0.Font;
		}
		@class.string_0 = title_0.Text;
		if (title_0.method_39() != null && title_0.Text != null)
		{
			Class1131.smethod_1(title_0.method_39(), title_0.Text.Length, title_0.Font, bool_0: true);
			@class.arrayList_0 = title_0.method_39();
		}
		@class.workbook_0 = workbook_1;
		return @class;
	}

	internal static Class1360 smethod_1(DataLabels dataLabels_0, Workbook workbook_1)
	{
		Class1360 @class = new Class1360();
		@class.textAlignmentType_0 = dataLabels_0.TextHorizontalAlignment;
		@class.textDirectionType_0 = dataLabels_0.TextDirection;
		if (dataLabels_0.method_13() != -1)
		{
			@class.font_0 = dataLabels_0.Font;
		}
		else if (dataLabels_0.method_44() != null)
		{
			@class.font_0 = dataLabels_0.Font;
		}
		@class.string_0 = dataLabels_0.method_41();
		if (dataLabels_0.method_39() != null && dataLabels_0.method_41() != null)
		{
			Class1131.smethod_1(dataLabels_0.method_39(), dataLabels_0.method_41().Length, dataLabels_0.Font, bool_0: true);
			@class.arrayList_0 = dataLabels_0.method_39();
		}
		@class.workbook_0 = workbook_1;
		return @class;
	}

	internal static Class1360 smethod_2(Class1737 class1737_0, Workbook workbook_1)
	{
		Class1360 @class = new Class1360();
		@class.textAlignmentType_0 = class1737_0.TextHorizontalAlignment;
		@class.font_0 = class1737_0.Font;
		@class.string_0 = class1737_0.Text;
		if (class1737_0.method_12() != null)
		{
			class1737_0.method_11();
		}
		@class.arrayList_0 = class1737_0.method_12();
		@class.workbook_0 = workbook_1;
		@class.class1363_0 = class1737_0.class1363_0;
		return @class;
	}

	internal static Class1360 smethod_3(TextBox textBox_0, Workbook workbook_1)
	{
		Class1360 @class = smethod_2(textBox_0.method_63(), workbook_1);
		if (textBox_0.LinkedCell != null)
		{
			@class.bool_0 = true;
		}
		return @class;
	}

	internal static Class1360 smethod_4(DisplayUnitLabel displayUnitLabel_0, Workbook workbook_1)
	{
		Class1360 @class = new Class1360();
		@class.textAlignmentType_0 = displayUnitLabel_0.TextHorizontalAlignment;
		@class.textDirectionType_0 = displayUnitLabel_0.TextDirection;
		if (displayUnitLabel_0.method_13() != -1)
		{
			@class.font_0 = displayUnitLabel_0.Font;
		}
		@class.string_0 = displayUnitLabel_0.Text;
		@class.workbook_0 = workbook_1;
		return @class;
	}
}
