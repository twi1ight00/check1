using ns301;

namespace ns284;

internal class Class6897 : Class6895
{
	public override Class6959 Height
	{
		get
		{
			if (base.Display == Enum952.const_0)
			{
				return new Class6959(isAuto: true);
			}
			return class6959_21;
		}
		set
		{
			class6959_21 = value;
		}
	}

	public Class6897()
	{
		base.BorderWidthBottom = (base.BorderWidthLeft = (base.BorderWidthTop = (base.BorderWidthRight = new Class6959(Class6969.smethod_6(5f)))));
	}

	public override Interface329 imethod_0(string tagName)
	{
		Interface329 @interface = new Class6897();
		@interface.CharSpace = base.CharSpace;
		@interface.Color = base.Color;
		@interface.FontFamilyName = base.FontFamilyName;
		@interface.FontSize = base.FontSize;
		@interface.FontLarger = base.FontLarger;
		@interface.FontStyle = base.FontStyle;
		@interface.TextAlign = base.TextAlign;
		@interface.Height = Height;
		@interface.IsTextOverlined = base.IsTextOverlined;
		@interface.WhiteSpace = base.WhiteSpace;
		@interface.WordSpacing = base.WordSpacing;
		@interface.TextIndent = base.TextIndent;
		@interface.TextTransform = base.TextTransform;
		@interface.LineHeight = base.LineHeight;
		@interface.IsBordered = base.IsBordered;
		@interface.BorderCollapse = base.BorderCollapse;
		@interface.BorderSpacingHorisontal = base.BorderSpacingHorisontal;
		@interface.BorderSpacingVertical = base.BorderSpacingVertical;
		@interface.EmptyCells = base.EmptyCells;
		@interface.ListStylePosition = base.ListStylePosition;
		@interface.ListStyle = base.ListStyle;
		@interface.Direction = base.Direction;
		return @interface;
	}

	public override object Clone()
	{
		Interface329 @interface = new Class6897();
		method_0(@interface);
		return @interface;
	}
}
