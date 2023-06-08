using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class187 : Class160
{
	internal Class187(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		Class878 @class = new Class878();
		@class.method_0(Enum93.const_77);
		float x = float_3;
		float y = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rectangleF = new RectangleF(x, y, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		GraphicsPath[] array = @class.method_1(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		int num = array.Length;
		if (num == 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			if (!class913_0.Fill.method_0())
			{
				Brush brush_ = Struct72.smethod_21(class913_0.Fill, array[i]);
				interface42_0.imethod_33(brush_, array[i]);
			}
			if (!class913_0.Line.method_0())
			{
				interface42_0.imethod_18(pen_, array[i]);
			}
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
