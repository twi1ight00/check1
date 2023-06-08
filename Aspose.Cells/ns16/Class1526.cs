using Aspose.Cells;

namespace ns16;

internal class Class1526
{
	internal int int_0;

	internal Class1527 class1527_0;

	internal Class1527 class1527_1;

	internal Class1527 class1527_2;

	internal Class1527 class1527_3;

	internal Class1527 class1527_4;

	internal Class1527 class1527_5;

	internal Class1527 class1527_6;

	internal bool bool_0;

	internal bool bool_1;

	private void method_0(Class1527 class1527_7, Border border_0)
	{
		if (class1527_7.string_0 != null && class1527_7.string_0.Length > 0)
		{
			border_0.LineStyle = Class1618.smethod_36(class1527_7.string_0);
		}
		border_0.InternalColor.method_19(class1527_7.internalColor_0);
	}

	internal void method_1(Style style_0)
	{
		if (class1527_0 != null)
		{
			method_0(class1527_0, style_0.Borders[BorderType.TopBorder]);
		}
		if (class1527_2 != null)
		{
			method_0(class1527_2, style_0.Borders[BorderType.BottomBorder]);
		}
		if (class1527_1 != null)
		{
			method_0(class1527_1, style_0.Borders[BorderType.LeftBorder]);
		}
		if (class1527_3 != null)
		{
			method_0(class1527_3, style_0.Borders[BorderType.RightBorder]);
		}
		if (class1527_5 != null || class1527_6 != null)
		{
			if (class1527_5 != null)
			{
				style_0.Borders.method_1(new Border(style_0.Borders, BorderType.Horizontal));
				method_0(class1527_5, style_0.Borders.method_0());
			}
			if (class1527_6 != null)
			{
				style_0.Borders.method_3(new Border(style_0.Borders, BorderType.Vertical));
				method_0(class1527_6, style_0.Borders.method_2());
			}
		}
		if (class1527_4 != null)
		{
			if (bool_0)
			{
				method_0(class1527_4, style_0.Borders[BorderType.DiagonalDown]);
			}
			if (bool_1)
			{
				method_0(class1527_4, style_0.Borders[BorderType.DiagonalUp]);
			}
		}
	}

	internal static Class1526 smethod_0(Style style_0)
	{
		Class1526 @class = new Class1526();
		@class.class1527_0 = Class1527.smethod_0(style_0, BorderType.TopBorder);
		@class.class1527_1 = Class1527.smethod_0(style_0, BorderType.LeftBorder);
		@class.class1527_2 = Class1527.smethod_0(style_0, BorderType.BottomBorder);
		@class.class1527_3 = Class1527.smethod_0(style_0, BorderType.RightBorder);
		if (style_0.Borders.method_0() != null)
		{
			@class.class1527_5 = Class1527.smethod_1(style_0.Borders.method_0());
		}
		if (style_0.Borders.method_2() != null)
		{
			@class.class1527_6 = Class1527.smethod_1(style_0.Borders.method_2());
		}
		switch (style_0.Borders.method_8())
		{
		case 0:
			@class.bool_0 = false;
			@class.bool_1 = false;
			break;
		case 1:
			@class.bool_0 = true;
			@class.bool_1 = false;
			break;
		case 2:
			@class.bool_0 = false;
			@class.bool_1 = true;
			break;
		case 3:
			@class.bool_0 = true;
			@class.bool_1 = true;
			break;
		}
		if (@class.bool_0)
		{
			@class.class1527_4 = Class1527.smethod_0(style_0, BorderType.DiagonalDown);
		}
		else if (@class.bool_1)
		{
			@class.class1527_4 = Class1527.smethod_0(style_0, BorderType.DiagonalUp);
		}
		return @class;
	}

	internal static bool smethod_1(Class1526 class1526_0, Class1526 class1526_1)
	{
		if (class1526_0 == null && class1526_1 == null)
		{
			return true;
		}
		if (class1526_0 != null && class1526_1 != null)
		{
			if (!Class1527.smethod_2(class1526_0.class1527_2, class1526_1.class1527_2))
			{
				return false;
			}
			if (!Class1527.smethod_2(class1526_0.class1527_0, class1526_1.class1527_0))
			{
				return false;
			}
			if (!Class1527.smethod_2(class1526_0.class1527_1, class1526_1.class1527_1))
			{
				return false;
			}
			if (!Class1527.smethod_2(class1526_0.class1527_3, class1526_1.class1527_3))
			{
				return false;
			}
			if (!Class1527.smethod_2(class1526_0.class1527_4, class1526_1.class1527_4))
			{
				return false;
			}
			if (!Class1527.smethod_2(class1526_0.class1527_5, class1526_1.class1527_5))
			{
				return false;
			}
			if (!Class1527.smethod_2(class1526_0.class1527_6, class1526_1.class1527_6))
			{
				return false;
			}
			if (class1526_0.bool_0 != class1526_1.bool_0)
			{
				return false;
			}
			if (class1526_0.bool_1 != class1526_1.bool_1)
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
