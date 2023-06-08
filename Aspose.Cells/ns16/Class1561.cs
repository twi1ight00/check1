using Aspose.Cells;

namespace ns16;

internal class Class1561
{
	internal string string_0;

	internal InternalColor internalColor_0 = new InternalColor(bool_0: false);

	internal InternalColor internalColor_1 = new InternalColor(bool_0: false);

	internal static bool smethod_0(Class1561 class1561_0, Class1561 class1561_1)
	{
		if (class1561_0 == null && class1561_1 == null)
		{
			return true;
		}
		if (class1561_0 != null && class1561_1 != null)
		{
			if (class1561_0.internalColor_0.method_13(class1561_1.internalColor_0))
			{
				return false;
			}
			if (class1561_0.internalColor_1.method_13(class1561_1.internalColor_1))
			{
				return false;
			}
			if (!class1561_0.string_0.Equals(class1561_1.string_0))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	internal static Class1561 smethod_1(Style style_0)
	{
		Class1561 @class = new Class1561();
		@class.internalColor_1.method_19(style_0.BackgroundInternalColor);
		if (style_0.BackgroundInternalColor.method_2())
		{
			@class.internalColor_1.SetColor(ColorType.AutomaticIndex, style_0.method_0());
		}
		@class.internalColor_0.method_19(style_0.ForeInternalColor);
		if (style_0.ForeInternalColor.method_2())
		{
			@class.internalColor_0.SetColor(ColorType.AutomaticIndex, style_0.method_1());
		}
		@class.string_0 = Class1618.smethod_33(style_0.Pattern);
		return @class;
	}

	internal void method_0(Style style_0)
	{
		if (string_0 != null && string_0.Length > 0)
		{
			style_0.Pattern = Class1618.smethod_34(string_0);
		}
		if (!internalColor_0.method_2())
		{
			style_0.ForeInternalColor.method_19(internalColor_0);
			style_0.method_36(StyleModifyFlag.ForegroundColor);
		}
		if (!internalColor_1.method_2())
		{
			style_0.BackgroundInternalColor.method_19(internalColor_1);
			style_0.method_36(StyleModifyFlag.BackgroundColor);
		}
	}
}
