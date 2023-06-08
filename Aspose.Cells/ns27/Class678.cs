using System;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns59;
using ns7;

namespace ns27;

internal class Class678 : Class538
{
	internal Class678()
	{
		method_2(2129);
	}

	internal void method_4(Font font_0, FileFormatType fileFormatType_1)
	{
		Class637 @class = new Class637();
		@class.method_5(font_0, fileFormatType_1);
		method_18(@class);
	}

	internal void method_5(Class1383 class1383_0)
	{
		Class634 @class = new Class634();
		@class.method_4(class1383_0);
		method_18(@class);
	}

	internal void method_6(Axis axis_0, DisplayUnitLabel displayUnitLabel_0, FileFormatType fileFormatType_1)
	{
		Class713 @class = new Class713(fileFormatType_1);
		@class.method_8(axis_0, displayUnitLabel_0);
		method_18(@class);
	}

	internal void method_7()
	{
		method_0(12);
		byte_0 = new byte[12]
		{
			81, 8, 0, 0, 51, 16, 0, 0, 0, 0,
			0, 0
		};
	}

	internal void method_8(DisplayUnitLabel displayUnitLabel_0)
	{
		Class669 @class = new Class669(bool_0: false);
		@class.method_8(displayUnitLabel_0);
		method_18(@class);
	}

	internal bool method_9(Font font_0, int int_0)
	{
		if (font_0 == null && int_0 == -1)
		{
			return false;
		}
		if (font_0 != null)
		{
			int_0 = font_0.method_21();
		}
		if (int_0 != -1)
		{
			Class638 class538_ = new Class638(int_0);
			method_18(class538_);
			return true;
		}
		return false;
	}

	internal void method_10(byte[] byte_1)
	{
		Class592 @class = new Class592();
		@class.method_6(byte_1);
		method_18(@class);
	}

	internal void method_11(FileFormatType fileFormatType_1, string string_0)
	{
		Class700 class538_ = new Class700(fileFormatType_1, string_0);
		method_18(class538_);
	}

	internal void method_12(bool bool_0, ChartFrame chartFrame_0)
	{
		Class641 @class = ((!bool_0) ? new Class641(2) : new Class641(3));
		@class.method_4(chartFrame_0);
		method_18(@class);
	}

	internal void method_13(Line line_0, FileFormatType fileFormatType_1, Palette palette_0)
	{
		Class651 @class = new Class651(fileFormatType_1, palette_0);
		@class.method_6(line_0, bool_0: false);
		method_18(@class);
	}

	internal void method_14(Area area_0, FileFormatType fileFormatType_1, Palette palette_0)
	{
		Class594 @class = new Class594(fileFormatType_1, palette_0);
		@class.method_4(area_0);
		method_18(@class);
	}

	internal void method_15(Area area_0, Palette palette_0, Class1725 class1725_0)
	{
		if (area_0 != null && area_0.method_0() && area_0.FillFormat.SetType != 0)
		{
			Class643 @class = new Class643();
			@class.method_4(area_0.FillFormat);
			method_18(@class);
			vmethod_0(class1725_0);
		}
	}

	internal void method_16()
	{
		Class662 @class = new Class662();
		@class.method_5(12, 0, 0);
		method_18(@class);
	}

	internal void method_17()
	{
		method_0(12);
		byte_0 = new byte[12]
		{
			81, 8, 0, 0, 52, 16, 0, 0, 0, 0,
			0, 0
		};
	}

	private void method_18(Class538 class538_0)
	{
		if (class538_0.Length < 4)
		{
			method_0(12);
		}
		else
		{
			method_0((short)(8 + class538_0.Length));
		}
		byte_0 = new byte[base.Length];
		byte_0[0] = 81;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes(class538_0.method_1()), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes(class538_0.Length), 0, byte_0, 6, 2);
		Array.Copy(class538_0.Data, 0, byte_0, 8, class538_0.Length);
	}
}
