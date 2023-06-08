using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class153 : Class18
{
	internal Class153(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		Interface42 @interface = interface42_0;
		@interface.imethod_55(SmoothingMode.AntiAlias);
		Class894 @class = class898_0.method_2();
		Class896 class2 = class898_0.method_0();
		FontStyle fontStyle_ = FontStyle.Regular;
		if (class2.FontItalic)
		{
			fontStyle_ = FontStyle.Italic;
		}
		int alpha = (int)(255.0 * @class.method_2());
		int int_ = (int)(@class.method_4() - @class.method_16());
		class898_0.Fill.FillFormat.method_1();
		Class917 class3 = new Class917();
		class3.vmethod_0(class898_0.Fill.method_2(), class898_0.Line.ForeColor, (int)class898_0.Line.Weight);
		if (@class.method_19())
		{
			class3.vmethod_3(bool_4: true);
			class3.vmethod_2();
			class3.method_0(Color.FromArgb(alpha, @class.ForeColor.R, @class.ForeColor.G, @class.ForeColor.B), int_, new Point((int)@class.method_4(), (int)@class.method_6()));
		}
		else
		{
			class3.vmethod_3(bool_4: false);
		}
		FontFamily fontFamily_ = new FontFamily(class2.FontName);
		StringFormat stringFormat_ = new StringFormat();
		float width = 0f;
		float height = 0f;
		class3.vmethod_5(@interface, fontFamily_, fontStyle_, class2.FontSize + 12, class2.Text, new Point(-10, 0), stringFormat_, ref width, ref height);
		RectangleF rect = new RectangleF(0f, 0f, width, height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		class3.vmethod_1(brush_, class898_0.Line.ForeColor, (int)class898_0.Line.Weight);
		class3.vmethod_4(@interface, fontFamily_, fontStyle_, class2.FontSize + 12, class2.Text, new Point(-10, 0), stringFormat_);
	}
}
