using Aspose.Cells;

namespace ns16;

internal class Class1525
{
	internal string string_0;

	internal string string_1;

	internal int int_0;

	internal bool bool_0;

	internal int int_1;

	internal bool bool_1;

	internal TextDirectionType textDirectionType_0;

	internal TextAlignmentType textAlignmentType_0;

	internal TextAlignmentType textAlignmentType_1;

	internal Class1525()
	{
		string_0 = null;
		string_1 = null;
		int_0 = 0;
		bool_0 = false;
		int_1 = 0;
		bool_1 = false;
	}

	internal bool method_0(Class1525 class1525_0)
	{
		if (string_0 == class1525_0.string_0 && string_1 == class1525_0.string_1 && bool_0 == class1525_0.bool_0 && bool_1 == class1525_0.bool_1 && int_0 == class1525_0.int_0)
		{
			return textDirectionType_0 == class1525_0.textDirectionType_0;
		}
		return false;
	}

	internal void method_1(Style style_0, bool bool_2)
	{
		if (string_0 != null)
		{
			style_0.HorizontalAlignment = Class1618.smethod_38(string_0);
		}
		if (string_1 != null)
		{
			style_0.VerticalAlignment = Class1618.smethod_40(string_1);
		}
		if (int_1 > 0)
		{
			if (bool_2)
			{
				style_0.method_39(int_1);
			}
			else
			{
				style_0.IndentLevel = int_1;
			}
		}
		style_0.IsTextWrapped = bool_0;
		style_0.ShrinkToFit = bool_1;
		if (int_0 != 255 && int_0 > 90)
		{
			style_0.RotationAngle = 90 - int_0;
		}
		else
		{
			style_0.RotationAngle = int_0;
		}
		style_0.TextDirection = textDirectionType_0;
	}

	internal static Class1525 smethod_0(Style style_0)
	{
		bool flag;
		if (!(flag = style_0.method_21()) && style_0.method_12() > 0 && style_0.method_12() < style_0.method_5().method_58().Count)
		{
			Style style = style_0.method_5().method_58()[style_0.method_12()];
			flag = style.method_21();
		}
		if (flag)
		{
			Class1525 @class = new Class1525();
			if (style_0.IsModified(StyleModifyFlag.HorizontalAlignment))
			{
				@class.string_0 = Class1618.smethod_37(style_0.HorizontalAlignment);
			}
			if (style_0.IsModified(StyleModifyFlag.VerticalAlignment))
			{
				@class.string_1 = Class1618.smethod_39(style_0.VerticalAlignment);
			}
			int rotationAngle = style_0.RotationAngle;
			if (rotationAngle >= 0)
			{
				@class.int_0 = rotationAngle;
			}
			else
			{
				@class.int_0 = 90 - rotationAngle;
			}
			@class.bool_0 = style_0.IsTextWrapped;
			@class.int_1 = style_0.IndentLevel;
			@class.bool_1 = style_0.ShrinkToFit;
			@class.textDirectionType_0 = style_0.TextDirection;
			@class.textAlignmentType_0 = style_0.HorizontalAlignment;
			@class.textAlignmentType_1 = style_0.VerticalAlignment;
			return @class;
		}
		return null;
	}
}
