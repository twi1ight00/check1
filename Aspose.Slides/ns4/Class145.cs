using Aspose.Slides;
using Aspose.Slides.Theme;
using ns11;
using ns16;
using ns224;

namespace ns4;

internal class Class145
{
	private Class63 class63_0;

	private Class66 class66_0;

	private Class66 class66_1;

	private Class66 class66_2;

	private Class66 class66_3;

	private Class66 class66_4;

	private Class66 class66_5;

	private Class66 class66_6;

	private Class66 class66_7;

	private Class142 class142_0;

	private BaseSlide baseSlide_0;

	private Class143 class143_0;

	private ShapeFrame shapeFrame_0;

	private IThemeEffectiveData ithemeEffectiveData_0;

	private Class169 class169_0;

	private Enum9 enum9_0;

	internal Enum9 ParamType => enum9_0;

	internal Class63 CellFillFormat
	{
		get
		{
			if (class63_0 != null)
			{
				return class63_0;
			}
			class63_0 = method_3(class143_0.FillFormat);
			return class63_0;
		}
	}

	internal Class66 LeftBorder
	{
		get
		{
			if (class66_0 != null)
			{
				return class66_0;
			}
			class66_0 = method_4(class143_0.LeftBorder);
			return class66_0;
		}
	}

	internal Class66 TopBorder
	{
		get
		{
			if (class66_1 != null)
			{
				return class66_1;
			}
			class66_1 = method_4(class143_0.TopBorder);
			return class66_1;
		}
	}

	internal Class66 RightBorder
	{
		get
		{
			if (class66_2 != null)
			{
				return class66_2;
			}
			class66_2 = method_4(class143_0.RightBorder);
			return class66_2;
		}
	}

	internal Class66 BottomBorder
	{
		get
		{
			if (class66_3 != null)
			{
				return class66_3;
			}
			class66_3 = method_4(class143_0.BottomBorder);
			return class66_3;
		}
	}

	internal Class66 InsideH
	{
		get
		{
			if (class66_4 != null)
			{
				return class66_4;
			}
			class66_4 = method_4(class143_0.InsideHorizontalBorder);
			return class66_4;
		}
	}

	internal Class66 InsideV
	{
		get
		{
			if (class66_5 != null)
			{
				return class66_5;
			}
			class66_5 = method_4(class143_0.InsideVerticalBorder);
			return class66_5;
		}
	}

	internal Class66 TL2BRBorder
	{
		get
		{
			if (class66_6 != null)
			{
				return class66_6;
			}
			class66_6 = method_4(class143_0.TopLeftToBottomRightBorder);
			return class66_6;
		}
	}

	internal Class66 TR2BLBorder
	{
		get
		{
			if (class66_7 != null)
			{
				return class66_7;
			}
			class66_7 = method_4(class143_0.TopRightToBottomLeftBorder);
			return class66_7;
		}
	}

	internal Class142 CellTextStyle
	{
		get
		{
			if (class142_0 != null && class142_0.NeedElement)
			{
				return class142_0;
			}
			return null;
		}
	}

	internal Class145(IBaseSlide parentSlide, Class169 rc, IThemeEffectiveData theme, Class143 tablePartStyle, Class142 tableCellTextStyle, Enum9 paramType)
		: this(parentSlide, tablePartStyle, tableCellTextStyle)
	{
		ithemeEffectiveData_0 = theme;
		class169_0 = rc;
		enum9_0 = paramType;
	}

	private Class145(IBaseSlide parentSlide, Class143 tablePartStyle, Class142 tableCellTextStyle)
	{
		baseSlide_0 = (BaseSlide)parentSlide;
		class143_0 = tablePartStyle;
		shapeFrame_0 = new ShapeFrame(0f, 0f, 72f, 72f, NullableBool.False, NullableBool.False, 0f);
		method_0();
		class142_0 = tableCellTextStyle;
	}

	internal void method_0()
	{
		class63_0 = null;
		class66_0 = null;
		class66_1 = null;
		class66_2 = null;
		class66_3 = null;
		class66_4 = null;
		class66_5 = null;
		class66_6 = null;
		class66_7 = null;
		class142_0 = null;
	}

	internal Class67 method_1(Class6002 userToDevice)
	{
		return new Class67(shapeFrame_0, userToDevice, null, baseSlide_0, class169_0);
	}

	private Class67 method_2()
	{
		return new Class67(shapeFrame_0, null, null, baseSlide_0, class169_0);
	}

	private Class63 method_3(Class148 fillFormat)
	{
		if (fillFormat.Source == Enum273.const_0)
		{
			return null;
		}
		return new Class63(method_2(), fillFormat.method_0(baseSlide_0, ithemeEffectiveData_0));
	}

	private Class66 method_4(Class149 lineFormat)
	{
		if (lineFormat.Source == Enum275.const_0)
		{
			return null;
		}
		return new Class66(method_2(), lineFormat.method_0(baseSlide_0, ithemeEffectiveData_0));
	}
}
