using System.Drawing;
using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;
using ns217;
using ns224;
using ns235;

namespace ns216;

internal class Class5798 : Class5783, Interface253
{
	private Class6205 class6205_0;

	internal static string Tag => "checkButton";

	public float Size => (float)method_5("size").Value;

	public Class5798()
	{
		Class5906.smethod_6(this, "mark", XfaEnums.Enum693.const_0);
		Class5906.smethod_6(this, "shape", XfaEnums.Enum694.const_0);
		Class5906.smethod_1(this, "size", 10f);
		Class5906.smethod_4(this, "allowNeutral", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_31(this);
		base.vmethod_4(visitor);
		visitor.vmethod_32(this);
	}

	private Class5814 method_8(Class5781 parent)
	{
		if (parent == null)
		{
			return null;
		}
		if (parent is Class5814 result)
		{
			return result;
		}
		return method_8(parent.Parent);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		base.vmethod_5(reader, node);
		Class5814 @class = method_8(base.Parent);
		if (@class != null)
		{
			class6205_0 = new Class6208(PointF.Empty, string.Empty, Size);
			class6205_0.Action = @class.GetHashCode().ToString();
		}
		else
		{
			class6205_0 = new Class6207(PointF.Empty, string.Empty, Size);
		}
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5798();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	public void imethod_0(Class6213 canvas, Class6213 textCanvas, Class5912 builder, PointF pos, SizeF size)
	{
		Class5817 @class = Class5804.smethod_2(base.Parent);
		if (@class == null)
		{
			return;
		}
		bool value = false;
		if (@class.method_6(Class5824.Tag) is Class5824 class2 && class2.method_6("text") is Class5889 class3 && @class.Value != null && class3.Value == @class.Value)
		{
			value = true;
		}
		if (class6205_0 != null)
		{
			class6205_0.Origin = pos;
			class6205_0.CustomDraw = canvas;
			if (class6205_0 is Class6207 class4)
			{
				class4.Value = value;
			}
			else if (class6205_0 is Class6208 class5)
			{
				class5.Value = value;
			}
			builder.method_2(class6205_0);
		}
		if (@class.method_6(Class5829.Tag) is Class5829 class6)
		{
			PointF pointF = pos;
			if (class6.LeftInset + Size + class6.RightInset > size.Width)
			{
				pos.X = pointF.X + size.Width - class6.RightInset - Size;
			}
			pos.Y += class6.TopInset;
			if (class6.TopInset + Size + class6.BottomInset > size.Height)
			{
				pos.Y = pointF.Y + size.Height - class6.BottomInset - Size;
			}
		}
		if (method_6(Class5790.Tag) is Class5790 class7 && class7.Presence != XfaEnums.Enum687.const_1 && class7.Presence != XfaEnums.Enum687.const_3)
		{
			XfaEnums.Enum694 @enum = (XfaEnums.Enum694)method_5("shape").Value;
			if (@enum == XfaEnums.Enum694.const_1)
			{
				smethod_2(pos.X + Size / 2f, pos.Y + Size / 2f, Size / 2f, canvas, fill: false);
			}
			else
			{
				Class6217 class8 = new Class6217(new Class6003(Class5998.class5998_7, 0.5f));
				Class6218 class9 = new Class6218();
				class8.Add(class9);
				class9.method_3(new RectangleF(pos, new SizeF(Size, Size)));
				class9.IsClosed = true;
				canvas.Add(class8);
			}
		}
		builder.method_5(canvas);
		if (textCanvas != null)
		{
			builder.method_5(textCanvas);
		}
	}

	internal override string[] vmethod_10()
	{
		return new string[3]
		{
			Class5790.Tag,
			Class5816.Tag,
			Class5829.Tag
		};
	}

	internal static void smethod_2(float midX, float midY, float radius, Class6213 canvas, bool fill)
	{
		Class6217 @class = new Class6217(new Class6003(Class5998.class5998_7, 0.5f));
		@class.RenderTransform = new Class6002(1f, 0f, 0f, 1f, midX, midY);
		Class6218 class2 = new Class6218();
		class2.IsClosed = true;
		@class.Add(class2);
		float num = 0.55228f;
		float num2 = 0f;
		float y = 0f + radius;
		float num3 = 0f + radius;
		float num4 = 0f;
		float x = num2 + radius * num;
		float y2 = radius;
		float x2 = num3;
		float y3 = num4 + radius * num;
		Class6222 node = new Class6222(new PointF(num2, y), new PointF(x, y2), new PointF(x2, y3), new PointF(num3, num4));
		class2.Add(node);
		num2 = num3;
		y = num4;
		num3 = 0f;
		num4 = 0f - radius;
		x = num2;
		y2 = y - radius * num;
		x2 = num3 + radius * num;
		y3 = num4;
		node = new Class6222(new PointF(num2, y), new PointF(x, y2), new PointF(x2, y3), new PointF(num3, num4));
		class2.Add(node);
		num2 = num3;
		y = num4;
		num3 = 0f - radius;
		num4 = 0f;
		x = num2 - radius * num;
		y2 = y;
		x2 = num3;
		y3 = num4 - radius * num;
		node = new Class6222(new PointF(num2, y), new PointF(x, y2), new PointF(x2, y3), new PointF(num3, num4));
		class2.Add(node);
		num2 = num3;
		y = num4;
		num3 = 0f;
		num4 = 0f + radius;
		x = num2;
		y2 = y + radius * num;
		x2 = num3 - radius * num;
		y3 = num4;
		node = new Class6222(new PointF(num2, y), new PointF(x, y2), new PointF(x2, y3), new PointF(num3, num4));
		class2.Add(node);
		if (fill)
		{
			@class.Brush = new Class5997(Class5998.class5998_7);
		}
		canvas.Add(@class);
	}
}
