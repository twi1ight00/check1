using System;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6932 : Class6927
{
	public override void imethod_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6851 @class))
		{
			throw new ArgumentOutOfRangeException("box", "box should have ListItemBox type");
		}
		if (box.Style.ListStylePosition == Enum938.const_0)
		{
			Class6845 class2 = @class.InnerBoxes[0] as Class6845;
			Class6845 contentBox = @class.ContentBox;
			float num = 0f;
			if (!@class.Style.PaddingLeft.IsAuto)
			{
				num = base.UnitConverter.imethod_0(@class.Style.PaddingLeft, @class);
			}
			class2.Size = new SizeF(class2.MaxWidth, class2.Size.Height);
			class2.Location = new PointF(0f - class2.Size.Width - num, 0f);
			contentBox.Location = new PointF(0f, 0f);
		}
		@class.Size = new SizeF(@class.Size.Width, @class.ContentBox.Size.Height);
	}
}
