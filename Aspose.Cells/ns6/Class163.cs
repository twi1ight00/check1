using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class163 : Class160
{
	internal Class163(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		Class878 @class = new Class878(new Class875[0], new Class879[0], null, null, new Class881[1]
		{
			new Class881(new Enum91[3]
			{
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2
			}, new long[6] { -27273042329608L, -27273042329609L, -27273042329610L, -27273042329609L, -27273042329610L, -27273042329611L }, 0L, 0L, Enum92.const_0, bool_2: true, bool_3: true)
		}, new Class874(-27273042329608L, -27273042329609L), new Class874(-27273042329610L, -27273042329611L));
		@class.method_0(Enum93.const_1);
		float num = 0f;
		float num2 = 0f;
		if (!class913_0.bool_4 && !class913_0.bool_6)
		{
			num = 0f - class913_0.method_6().X;
			num2 = 0f - class913_0.method_6().Y;
		}
		else
		{
			num = float_3;
			num2 = float_4;
		}
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rect = new RectangleF(num, num2, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		GraphicsPath[] array = @class.method_1(rect.X, rect.Y, rect.Width, rect.Height);
		int num3 = array.Length;
		if (num3 == 0)
		{
			return;
		}
		for (int i = 0; i < num3; i++)
		{
			if (!class913_0.Line.method_0())
			{
				interface42_0.imethod_18(pen_, array[i]);
			}
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
