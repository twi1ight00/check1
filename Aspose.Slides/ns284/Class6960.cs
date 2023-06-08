using ns290;

namespace ns284;

internal class Class6960
{
	public static void smethod_0(Interface329 wordStyle, Interface329 containerStyle)
	{
		wordStyle.FontFamilyName = containerStyle.FontFamilyName;
		wordStyle.FontSize = containerStyle.FontSize;
		wordStyle.FontStyle = containerStyle.FontStyle;
		wordStyle.Color = containerStyle.Color;
		wordStyle.TextTransform = containerStyle.TextTransform;
		wordStyle.WordSpacing = containerStyle.WordSpacing;
	}

	public static Interface329 smethod_1(Interface329 containerStyle)
	{
		return containerStyle.imethod_0(string.Empty);
	}

	public static Interface329 smethod_2(Interface329 style, bool isLeftSideBroken, bool isRightSideBroken)
	{
		style = style.Clone() as Interface329;
		if (style == null)
		{
			return null;
		}
		if (isLeftSideBroken)
		{
			style.MarginLeft = new Class6959(0f);
			style.PaddingLeft = new Class6959(0f);
			style.BorderWidthLeft = new Class6959(0f);
		}
		if (isRightSideBroken)
		{
			style.MarginRight = new Class6959(0f);
			style.PaddingRight = new Class6959(0f);
			style.BorderWidthRight = new Class6959(0f);
		}
		return style;
	}

	public static Interface329 smethod_3(Class6845 container)
	{
		Interface329 @interface = (Interface329)container.Style.Clone();
		@interface.Display = Enum952.const_1;
		Class6959 class2 = (@interface.MarginTop = new Class6959(0f));
		Class6959 class4 = (@interface.MarginRight = class2);
		Class6959 marginBottom = (@interface.MarginLeft = class4);
		@interface.MarginBottom = marginBottom;
		return @interface;
	}

	public static void smethod_4(Class6845 anonimous, Class6845 container)
	{
		anonimous.Style.TextAlign = container.Style.TextAlign;
	}

	public static Interface329 smethod_5(Interface329 style, bool isTopEdgeBroken, bool isBottomEdgeBroken)
	{
		style = style.Clone() as Interface329;
		if (style == null)
		{
			return null;
		}
		if (isTopEdgeBroken)
		{
			style.MarginTop = new Class6959(0f);
			style.PaddingTop = new Class6959(0f);
			style.BorderWidthTop = new Class6959(0f);
		}
		if (isBottomEdgeBroken)
		{
			style.MarginBottom = new Class6959(0f);
			style.PaddingBottom = new Class6959(0f);
			style.BorderWidthBottom = new Class6959(0f);
		}
		return style;
	}

	public static Interface329 smethod_6(Interface329 style)
	{
		style.BorderStyleTop = Enum951.const_0;
		style.BorderStyleRight = Enum951.const_0;
		style.BorderStyleLeft = Enum951.const_0;
		style.BorderStyleBottom = Enum951.const_0;
		return style;
	}
}
