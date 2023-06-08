using Aspose.Cells;

namespace ns16;

internal class Class1527
{
	internal string string_0;

	internal InternalColor internalColor_0 = new InternalColor(bool_0: false);

	internal CellBorderType cellBorderType_0;

	internal static Class1527 smethod_0(Style style_0, BorderType borderType_0)
	{
		Class1527 @class = new Class1527();
		@class.internalColor_0.method_19(style_0.Borders[borderType_0].InternalColor);
		if (@class.internalColor_0.method_2())
		{
			@class.internalColor_0.SetColor(ColorType.AutomaticIndex, 64);
		}
		@class.string_0 = Class1618.smethod_35(style_0.Borders[borderType_0].LineStyle);
		@class.cellBorderType_0 = style_0.Borders[borderType_0].LineStyle;
		return @class;
	}

	internal static Class1527 smethod_1(Border border_0)
	{
		Class1527 @class = new Class1527();
		@class.internalColor_0.method_19(border_0.InternalColor);
		if (@class.internalColor_0.method_2())
		{
			@class.internalColor_0.SetColor(ColorType.AutomaticIndex, 64);
		}
		@class.string_0 = Class1618.smethod_35(border_0.LineStyle);
		@class.cellBorderType_0 = border_0.LineStyle;
		return @class;
	}

	internal static bool smethod_2(Class1527 class1527_0, Class1527 class1527_1)
	{
		if (class1527_0 == null && class1527_1 == null)
		{
			return true;
		}
		if (class1527_0 != null && class1527_1 != null)
		{
			if (class1527_0.internalColor_0.method_13(class1527_1.internalColor_0))
			{
				return false;
			}
			if (!class1527_0.string_0.Equals(class1527_1.string_0))
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
