using Aspose.Cells;

namespace ns16;

internal class Class1563
{
	internal bool bool_0;

	internal bool bool_1;

	internal Class1563()
	{
		bool_0 = true;
		bool_1 = false;
	}

	internal bool method_0(Class1563 class1563_0)
	{
		if (bool_0 == class1563_0.bool_0)
		{
			return bool_1 == class1563_0.bool_0;
		}
		return false;
	}

	internal void method_1(Style style_0)
	{
		style_0.IsLocked = bool_0;
		style_0.IsFormulaHidden = bool_1;
	}

	internal static Class1563 smethod_0(Style style_0)
	{
		if (!style_0.method_27())
		{
			Style parentStyle = style_0.ParentStyle;
			if (parentStyle == null || !parentStyle.method_27())
			{
				return null;
			}
		}
		Class1563 @class = new Class1563();
		@class.bool_0 = style_0.IsLocked;
		@class.bool_1 = style_0.IsFormulaHidden;
		return @class;
	}
}
