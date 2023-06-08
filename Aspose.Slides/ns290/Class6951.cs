using System;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6951 : Interface354
{
	public void imethod_0(Class6845 container)
	{
	}

	public void imethod_1(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6855 @class))
		{
			throw new ArgumentException("should be WordBox", "box");
		}
		string wordDecoded = @class.WordDecoded;
		SizeF size = Class6971.Instance.method_0(wordDecoded, @class.Style.FontFamilyName, @class.Style.FontSize, @class.Style.FontStyle);
		if (@class.IsSpaceBox)
		{
			if (@class.Style.WordSpacing.IsAuto)
			{
				SizeF sizeF = Class6971.Instance.method_0(" ", @class.Style.FontFamilyName, @class.Style.FontSize, @class.Style.FontStyle);
				@class.Style.WordSpacing = new Class6959(sizeF.Width, Enum955.const_0);
			}
			float width = Class6969.smethod_9(@class.Style.WordSpacing, 4f);
			@class.Size = new SizeF(width, size.Height);
		}
		else
		{
			@class.Size = size;
		}
		if (@class.IsUnicode)
		{
			@class.Size = new SizeF(5f, @class.Size.Height);
		}
		@class.float_0 = (@class.float_1 = Class6971.smethod_1(@class.Style.FontFamilyName, @class.Style.FontSize, @class.Style.FontStyle));
		@class.float_2 = Class6971.smethod_2(@class.Style.FontFamilyName, @class.Style.FontSize, @class.Style.FontStyle);
	}

	public void imethod_2(Class6844 box, SizeF size)
	{
	}

	public void imethod_3(Class6844 box)
	{
	}
}
