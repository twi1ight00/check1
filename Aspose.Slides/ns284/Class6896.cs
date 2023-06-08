using System.Collections.Generic;
using ns301;

namespace ns284;

internal class Class6896 : Class6895
{
	private static List<string> list_0 = new List<string>(new string[3] { "tr", "td", "th" });

	public Class6896()
	{
		base.BorderWidthBottom = (base.BorderWidthLeft = (base.BorderWidthTop = (base.BorderWidthRight = new Class6959(Class6969.smethod_6(0f)))));
	}

	public override object Clone()
	{
		Interface329 @interface = new Class6896();
		method_0(@interface);
		return @interface;
	}

	public override Interface329 imethod_0(string tagName)
	{
		Interface329 @interface = new Class6896();
		@interface.CharSpace = base.CharSpace;
		@interface.Color = base.Color;
		@interface.FontFamilyName = base.FontFamilyName;
		@interface.FontSize = base.FontSize;
		@interface.FontStyle = base.FontStyle;
		@interface.TextAlign = base.TextAlign;
		@interface.Align = base.Align;
		@interface.Height = Height;
		@interface.IsTextOverlined = base.IsTextOverlined;
		@interface.TextVAlign = base.TextVAlign;
		@interface.WhiteSpace = base.WhiteSpace;
		@interface.WordSpacing = base.WordSpacing;
		@interface.TextIndent = base.TextIndent;
		@interface.TextTransform = base.TextTransform;
		@interface.LineHeight = base.LineHeight;
		if (!list_0.Contains(tagName) && tagName != "#PCDATA")
		{
			@interface.BorderWidthLeft = base.BorderWidthLeft;
			@interface.BorderWidthRight = base.BorderWidthRight;
			@interface.BorderWidthTop = base.BorderWidthTop;
			@interface.BorderWidthBottom = base.BorderWidthBottom;
		}
		@interface.IsBordered = base.IsBordered;
		@interface.BorderCollapse = base.BorderCollapse;
		@interface.BorderSpacingHorisontal = base.BorderSpacingHorisontal;
		@interface.BorderSpacingVertical = base.BorderSpacingVertical;
		@interface.EmptyCells = base.EmptyCells;
		@interface.ListStylePosition = base.ListStylePosition;
		@interface.ListStyle = base.ListStyle;
		@interface.Direction = base.Direction;
		@interface.BackgroundColor = base.BackgroundColor;
		return @interface;
	}
}
