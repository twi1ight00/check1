using Aspose.Cells;

namespace ns16;

internal class Class1535
{
	internal int int_0;

	internal Class1561 class1561_0;

	internal Class1528 class1528_0;

	internal static Class1535 smethod_0(Style style_0)
	{
		Class1535 @class = new Class1535();
		if (style_0.IsGradient)
		{
			@class.class1528_0 = Class1528.smethod_2(style_0);
		}
		else
		{
			@class.class1561_0 = Class1561.smethod_1(style_0);
		}
		return @class;
	}

	internal static bool smethod_1(Class1535 class1535_0, Class1535 class1535_1)
	{
		if (class1535_0 == null && class1535_1 == null)
		{
			return true;
		}
		if (class1535_0 != null && class1535_1 != null)
		{
			if (!Class1561.smethod_0(class1535_0.class1561_0, class1535_1.class1561_0))
			{
				return false;
			}
			if (!Class1528.smethod_0(class1535_0.class1528_0, class1535_1.class1528_0))
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
