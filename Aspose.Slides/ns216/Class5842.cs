using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;
using ns217;
using ns224;
using ns235;

namespace ns216;

internal class Class5842 : Class5783
{
	internal static string Tag => "rectangle";

	public Class5842()
	{
		Class5906.smethod_6(this, "hand", XfaEnums.Enum680.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_138(this);
		base.vmethod_4(visitor);
		visitor.vmethod_139(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5842();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[3]
		{
			Class5803.Tag,
			Class5810.Tag,
			Class5818.Tag
		};
	}

	internal static void smethod_2(Class5783 contatiner, XfaEnums.Enum680 rectHand, Class6213 canvas, PointF pos, SizeF size)
	{
		Class5908 @class = contatiner.method_3($"#{Class5810.Tag}[*]");
		if (@class == null)
		{
			return;
		}
		if (contatiner.method_6(Class5818.Tag) is Class5818 class2)
		{
			class2.method_8(canvas, pos, size);
		}
		RectangleF rectangleF = new RectangleF(pos, size);
		if (@class.Length <= 0)
		{
			return;
		}
		Class5810 class3 = null;
		float[] array = new float[4];
		for (int i = 0; i < 4; i++)
		{
			if (i < @class.Length)
			{
				class3 = @class.method_1(i) as Class5810;
			}
			array[i] = class3.Thickness;
		}
		float num = 0f;
		switch (rectHand)
		{
		case XfaEnums.Enum680.const_1:
			num = 0.5f;
			break;
		case XfaEnums.Enum680.const_2:
			num = -0.5f;
			break;
		}
		RectangleF rectangleF2 = RectangleF.FromLTRB(rectangleF.Left - num * array[3], rectangleF.Top - num * array[0], rectangleF.Right + num * array[1], rectangleF.Bottom + num * array[2]);
		for (int j = 0; j < 4; j++)
		{
			if (j < @class.Length)
			{
				class3 = @class.method_1(j) as Class5810;
			}
			if (class3 != null && class3.Presence != XfaEnums.Enum687.const_1 && class3.Presence != XfaEnums.Enum687.const_3)
			{
				switch (j)
				{
				case 0:
				{
					Class6217 class10 = new Class6217(new Class6003(Class5998.class5998_7, class3.Thickness));
					Class6218 class11 = new Class6218();
					class10.Add(class11);
					class11.method_2(new PointF(rectangleF2.Left, rectangleF2.Top), new PointF(rectangleF2.Right, rectangleF2.Top));
					canvas.Add(class10);
					break;
				}
				case 1:
				{
					Class6217 class8 = new Class6217(new Class6003(Class5998.class5998_7, class3.Thickness));
					Class6218 class9 = new Class6218();
					class8.Add(class9);
					class9.method_2(new PointF(rectangleF2.Right, rectangleF2.Top), new PointF(rectangleF2.Right, rectangleF2.Bottom));
					canvas.Add(class8);
					break;
				}
				case 2:
				{
					Class6217 class6 = new Class6217(new Class6003(Class5998.class5998_7, class3.Thickness));
					Class6218 class7 = new Class6218();
					class6.Add(class7);
					class7.method_2(new PointF(rectangleF2.Right, rectangleF2.Bottom), new PointF(rectangleF2.Left, rectangleF2.Bottom));
					canvas.Add(class6);
					break;
				}
				case 3:
				{
					Class6217 class4 = new Class6217(new Class6003(Class5998.class5998_7, class3.Thickness));
					Class6218 class5 = new Class6218();
					class4.Add(class5);
					class5.method_2(new PointF(rectangleF2.Left, rectangleF2.Bottom), new PointF(rectangleF2.Left, rectangleF2.Top));
					canvas.Add(class4);
					break;
				}
				}
			}
		}
	}

	internal void method_8(Class6213 canvas, PointF pos, SizeF size)
	{
		smethod_2(this, (XfaEnums.Enum680)method_5("hand").Value, canvas, pos, size);
	}
}
