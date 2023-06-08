using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;
using ns217;
using ns224;
using ns235;
using ns271;

namespace ns216;

internal class Class5804 : Class5783, Interface253
{
	private bool bool_1;

	private Class6210 class6210_0;

	private float float_0;

	private XfaEnums.Enum691 enum691_0;

	public Class6210 TextField => class6210_0;

	internal static string Tag => "textEdit";

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_164(this);
		base.vmethod_4(visitor);
		visitor.vmethod_165(this);
	}

	internal static Class5817 smethod_2(Class5781 parent)
	{
		if (parent == null)
		{
			return null;
		}
		if (parent is Class5817 result)
		{
			return result;
		}
		return smethod_2(parent.Parent);
	}

	internal static Class5999 smethod_3(Class5783 container)
	{
		Class5817 @class = smethod_2(container.Parent);
		if (@class != null && @class.method_6(Class5820.Tag) is Class5820 class2)
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (class2.Posture == XfaEnums.Enum709.const_1)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (class2.Weight == XfaEnums.Enum710.const_1)
			{
				fontStyle |= FontStyle.Bold;
			}
			return Class6652.Instance.method_1(class2.Typeface, class2.Size, fontStyle);
		}
		return Class6652.Instance.method_1("Arial", 10f, FontStyle.Regular);
	}

	public Class5804()
	{
		Class5906.smethod_3(this, "allowRichText", @default: false);
		Class5906.smethod_3(this, "multiLine", @default: false);
		Class5906.smethod_6(this, "hScrollPolicy", XfaEnums.Enum714.const_0);
		Class5906.smethod_6(this, "vScrollPolicy", XfaEnums.Enum714.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5804();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal static RectangleF smethod_4(Class5783 element, Class5912 builder, PointF pos, SizeF size)
	{
		Class5817 @class = smethod_2(element.Parent);
		if (@class != null)
		{
			float num = 0f;
			XfaEnums.Enum691 @enum = XfaEnums.Enum691.const_0;
			if (@class.method_6(Class5796.Tag) is Class5796 class2)
			{
				num = class2.Reserve;
				@enum = class2.Placement;
			}
			Class5829 class3 = @class.method_6(Class5829.Tag) as Class5829;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			if (class3 != null)
			{
				num2 = class3.LeftInset;
				num3 = class3.RightInset;
				num4 = class3.TopInset;
				num5 = class3.BottomInset;
			}
			if (num != 0f)
			{
				switch (@enum)
				{
				case XfaEnums.Enum691.const_0:
					num2 += num;
					break;
				case XfaEnums.Enum691.const_1:
					num5 += num;
					break;
				case XfaEnums.Enum691.const_3:
					num3 += num;
					break;
				case XfaEnums.Enum691.const_4:
					num4 += num;
					break;
				}
			}
			RectangleF rectangleF = new RectangleF(pos, size);
			rectangleF = RectangleF.FromLTRB(rectangleF.Left + num2, rectangleF.Top + num4, rectangleF.Right - num3, rectangleF.Bottom - num5);
			if (element.method_6(Class5790.Tag) is Class5790 class4)
			{
				Class6213 canvas = new Class6213();
				class4.method_8(canvas, rectangleF.Location, rectangleF.Size);
				builder.method_5(canvas);
				rectangleF.Inflate(-0.5f, -0.5f);
			}
			return rectangleF;
		}
		return new RectangleF(pos, size);
	}

	public void imethod_0(Class6213 canvas, Class6213 textCanvas, Class5912 builder, PointF pos, SizeF size)
	{
		if (!bool_1)
		{
			Class5817 @class = smethod_2(base.Parent);
			if (@class != null)
			{
				class6210_0 = new Class6210(PointF.Empty, string.Empty, Size.Empty, isRichText: false);
				if (@class.method_6(Class5893.Tag) is Class5893 value)
				{
					vmethod_11(value);
				}
				class6210_0.IsEnabled = @class.Access != XfaEnums.Enum705.const_3 && @class.Access != XfaEnums.Enum705.const_1;
				if (@class.method_6(Class5836.Tag) is Class5836 class2)
				{
					float_0 = class2.LineHeight;
				}
			}
			bool_1 = true;
		}
		if (class6210_0 != null)
		{
			class6210_0.DefaultFont = smethod_3(this);
			class6210_0.IsMultiline = (bool)method_5("multiLine").Value;
			RectangleF rectangleF = smethod_4(this, builder, pos, size);
			class6210_0.Size = rectangleF.Size;
			class6210_0.Origin = rectangleF.Location;
			class6210_0.CustomDraw = canvas;
			class6210_0.LineHeight = float_0;
			builder.method_2(class6210_0);
		}
		builder.method_5(canvas);
		if (class6210_0 == null && textCanvas != null)
		{
			builder.method_5(textCanvas);
		}
	}

	protected virtual void vmethod_11(Class5893 value)
	{
		if (value.Nodes.method_3("exData") is Class5869 @class && @class.ContentType == "text/html")
		{
			class6210_0.Value = @class.Value;
		}
		else if (value.Nodes.method_3("text") is Class5889 class2)
		{
			class6210_0.PlainText = class2.Value ?? string.Empty;
		}
	}

	internal override string[] vmethod_10()
	{
		return new string[4]
		{
			Class5790.Tag,
			Class5863.Tag,
			Class5816.Tag,
			Class5829.Tag
		};
	}
}
