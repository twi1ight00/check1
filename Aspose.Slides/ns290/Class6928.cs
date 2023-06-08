using System;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6928 : Class6927
{
	private readonly Interface348 interface348_0;

	public Class6928(Interface348 aligner)
	{
		Class6892.smethod_0(aligner, "aligner");
		interface348_0 = aligner;
	}

	public override void imethod_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6845 @class))
		{
			throw new ArgumentException("box should be ContainerBox");
		}
		float num = 0f;
		float val = 0f;
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			if (@class.InnerBoxes[i] is Class6856 class2 && class2.IsBr)
			{
				num += @class.InnerBoxes[i].OuterBound.Height;
			}
			if (!(@class.InnerBoxes[i] is Class6845))
			{
				continue;
			}
			Class6845 class3 = (Class6845)@class.InnerBoxes[i];
			float x = interface348_0.imethod_0(class3, @class);
			num -= Math.Min(Class6969.smethod_10(class3.Style.MarginTop), val);
			class3.Location = new PointF(x, num);
			if (!method_0(class3))
			{
				method_1(class3, @class);
				@class.InnerBoxes.RemoveAt(i);
				i--;
				continue;
			}
			float num2 = Class6969.smethod_10(box.Style.PaddingTop);
			if ((box.Style.BorderWidthTop.Value == 0f || box.Style.BorderStyleTop == Enum951.const_0) && num2 == 0f)
			{
				Class6849 class4 = box as Class6849;
				if (i == 0 && box.Parent != null)
				{
					if (class4 == null)
					{
						box.Style.MarginTop = new Class6959(Math.Max(Class6969.smethod_10(box.Style.MarginTop), Class6969.smethod_10(class3.Style.MarginTop)));
					}
					class3.Style.MarginTop = new Class6959(0f);
				}
				if (i == @class.InnerBoxes.Count - 1)
				{
					if (class4 == null)
					{
						box.Style.MarginBottom = new Class6959(Math.Max(Class6969.smethod_10(class3.Style.MarginBottom), Class6969.smethod_10(box.Style.MarginBottom)));
					}
					class3.Style.MarginBottom = new Class6959(0f);
				}
			}
			num += class3.OuterBound.Height;
			val = Class6969.smethod_10(class3.Style.MarginBottom);
		}
		Interface354 @interface = Class6927.smethod_0(this);
		@interface.imethod_0(@class);
	}
}
