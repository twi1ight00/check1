using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns22;

namespace ns18;

internal class Class1445
{
	private readonly Class1440 class1440_0;

	private readonly Class939 class939_0;

	private readonly Class1451 class1451_0;

	private static readonly float[] float_0 = new float[0];

	private static readonly float[] float_1 = new float[2] { 3f, 1f };

	private static readonly float[] float_2 = new float[2] { 1f, 1f };

	private static readonly float[] float_3 = new float[4] { 3f, 1f, 1f, 1f };

	private static readonly float[] float_4 = new float[6] { 3f, 1f, 1f, 1f, 1f, 1f };

	private Class1445()
	{
	}

	internal Class1445(Class1440 class1440_1, Class1451 class1451_1, Class939 class939_1)
	{
		class1440_0 = class1440_1;
		class1451_0 = class1451_1;
		class939_0 = class939_1;
	}

	internal void method_0(Class770 class770_0)
	{
		if (class770_0.penType_0 == PenType.SolidColor)
		{
			class1440_0.method_6().method_5(class770_0.color_0, bool_0: true, class939_0);
		}
		else
		{
			method_1(class770_0.brush_0, bool_0: true);
		}
		class1440_0.method_6().method_10(class770_0.float_0, class939_0);
		int num = smethod_0(class770_0);
		class1440_0.method_6().method_11(num, class939_0);
		int int_ = smethod_1(class770_0);
		class1440_0.method_6().method_12(int_, class939_0);
		if (class770_0.lineJoin_0 == LineJoin.MiterClipped)
		{
			class1440_0.method_6().method_13(class770_0.float_2, class939_0);
		}
		if (class770_0.dashStyle_0 != 0)
		{
			int num2 = 0;
			if (num == 0)
			{
				num2 = smethod_2(class770_0);
				class1440_0.method_6().method_11(num2, class939_0);
			}
			float[] array = smethod_3(class770_0, num != 0 || num2 != 0);
			class1440_0.method_6().method_14(array, class770_0.float_3, class939_0);
		}
	}

	internal void method_1(Brush brush_0, bool bool_0)
	{
		if (brush_0 is SolidBrush solidBrush)
		{
			class1440_0.method_6().method_5(solidBrush.Color, bool_0, class939_0);
			return;
		}
		TextureBrush textureBrush = brush_0 as TextureBrush;
		HatchBrush hatchBrush = brush_0 as HatchBrush;
		if (hatchBrush != null || textureBrush != null)
		{
			Class943 @class = class1451_0.method_3(brush_0);
			class1440_0.method_6().method_4(Class1439.Pattern, bool_0, class939_0);
			class939_0.method_10("/{0} {1}", @class.method_3(), bool_0 ? "SCN" : "scn");
		}
	}

	internal void method_2(byte[] byte_0, PointF pointF_0, SizeF sizeF_0, long long_0)
	{
		Size size;
		using (MemoryStream stream = new MemoryStream(byte_0))
		{
			Image image = Image.FromStream(stream);
			size = image.Size;
		}
		Class1202 class1201_ = new Class1202(byte_0, size);
		class1440_0.method_1().method_2(Enum208.const_4);
		method_5(class1201_, pointF_0, sizeF_0, long_0);
	}

	internal void method_3(Bitmap bitmap_0, PointF pointF_0, SizeF sizeF_0, long long_0)
	{
		Class1203 class1201_ = new Class1203(bitmap_0);
		method_5(class1201_, pointF_0, sizeF_0, long_0);
	}

	internal void method_4(Class1201 class1201_0, PointF pointF_0, SizeF sizeF_0)
	{
		class1440_0.method_6().method_0(class939_0);
		Matrix matrix_ = new Matrix(sizeF_0.Width, 0f, 0f, 0f - sizeF_0.Height, pointF_0.X, pointF_0.Y + sizeF_0.Height);
		class1440_0.method_6().method_2(matrix_, class939_0);
		if (class1201_0.vmethod_3() && class1201_0.vmethod_1() != Class1439.smethod_2())
		{
			Class942.smethod_0(class939_0, class1201_0);
		}
		else
		{
			Class942 @class = class1451_0.method_5(class1201_0);
			class939_0.method_9("/{0} Do", @class.method_3());
		}
		class1440_0.method_6().method_1(class939_0);
		matrix_ = null;
	}

	internal void method_5(Class1201 class1201_0, PointF pointF_0, SizeF sizeF_0, long long_0)
	{
		class1440_0.method_6().method_0(class939_0);
		Matrix matrix_ = new Matrix(sizeF_0.Width, 0f, 0f, 0f - sizeF_0.Height, pointF_0.X, pointF_0.Y + sizeF_0.Height);
		class1440_0.method_6().method_2(matrix_, class939_0);
		if (class1201_0.vmethod_3() && class1201_0.vmethod_1() != Class1439.smethod_2())
		{
			Class942.smethod_0(class939_0, class1201_0);
		}
		else
		{
			Class942 @class = class1451_0.method_6(class1201_0, long_0);
			class939_0.method_9("/{0} Do", @class.method_3());
		}
		class1440_0.method_6().method_1(class939_0);
	}

	private static int smethod_0(Class770 class770_0)
	{
		return class770_0.lineCap_0 switch
		{
			LineCap.Square => 2, 
			LineCap.Round => 1, 
			_ => class770_0.lineCap_1 switch
			{
				LineCap.Square => 2, 
				LineCap.Round => 1, 
				_ => 0, 
			}, 
		};
	}

	private static int smethod_1(Class770 class770_0)
	{
		return class770_0.lineJoin_0 switch
		{
			LineJoin.Bevel => 2, 
			LineJoin.Round => 1, 
			_ => 0, 
		};
	}

	private static int smethod_2(Class770 class770_0)
	{
		DashCap dashCap_ = class770_0.dashCap_0;
		if (dashCap_ == DashCap.Round)
		{
			return 1;
		}
		return 0;
	}

	[Attribute0(true)]
	private static float[] smethod_3(Class770 class770_0, bool bool_0)
	{
		float[] array = (class770_0.dashStyle_0 switch
		{
			DashStyle.Solid => float_0, 
			DashStyle.Dash => float_1, 
			DashStyle.Dot => float_2, 
			DashStyle.DashDot => float_3, 
			DashStyle.DashDotDot => float_4, 
			DashStyle.Custom => class770_0.method_0(), 
			_ => throw new Exception("Unknown dash style."), 
		}).Clone() as float[];
		smethod_4(class770_0, array, bool_0);
		return array;
	}

	private static void smethod_4(Class770 class770_0, float[] float_5, bool bool_0)
	{
		float num = Math.Max(class770_0.float_0, 1f);
		for (int i = 0; i < float_5.Length; i++)
		{
			if (Class1015.smethod_5(i))
			{
				float num2 = float_5[i];
				if (bool_0)
				{
					num2 += 1f;
				}
				float_5[i] = num2 * num;
			}
			else
			{
				float num3 = float_5[i];
				if (bool_0)
				{
					num3 -= 1f;
				}
				float_5[i] = num3 * num;
			}
		}
	}
}
