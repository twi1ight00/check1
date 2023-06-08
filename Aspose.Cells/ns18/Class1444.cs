using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1444
{
	private Class1440 class1440_0;

	private Class1443 class1443_0;

	private Stack stack_0 = new Stack();

	private Class1444()
	{
	}

	internal Class1444(Class1440 class1440_1)
	{
		class1440_0 = class1440_1;
	}

	internal void ResetGraphicState()
	{
		class1443_0 = new Class1443();
	}

	internal void method_0(Class939 class939_0)
	{
		class939_0.method_8("q");
		stack_0.Push(class1443_0.Clone());
	}

	internal void method_1(Class939 class939_0)
	{
		class939_0.method_8("Q");
		class1443_0 = stack_0.Pop() as Class1443;
	}

	internal void method_2(Matrix matrix_0, Class939 class939_0)
	{
		class939_0.method_13(matrix_0, "cm");
		class1443_0.method_0().Multiply(matrix_0);
	}

	internal void method_3(Class458 class458_0, Class939 class939_0)
	{
		foreach (Class459 item in class458_0.method_1())
		{
			class939_0.method_9("{0} m", Class1446.smethod_2(item.method_2()));
			foreach (Class452 item2 in item.method_1())
			{
				if (item2 is Class467)
				{
					Class467 class3 = (Class467)item2;
					ArrayList points = class3.Points;
					for (int i = 0; i < points.Count; i++)
					{
						class939_0.method_9("{0} l", Class1446.smethod_2((PointF)points[i]));
					}
				}
				else if (item2 is Class462)
				{
					Class462 class4 = (Class462)item2;
					Struct89[] array = class4.method_3();
					PointF[] array2 = new PointF[3];
					Struct89[] array3 = array;
					for (int j = 0; j < array3.Length; j++)
					{
						Struct89 @struct = array3[j];
						ref PointF reference = ref array2[0];
						reference = @struct.method_2();
						ref PointF reference2 = ref array2[1];
						reference2 = @struct.method_4();
						ref PointF reference3 = ref array2[2];
						reference3 = @struct.method_6();
						class939_0.method_9("{0} c", Class1446.smethod_3(array2));
					}
				}
				else
				{
					if (!(item2 is Class466))
					{
						continue;
					}
					Class466 class5 = (Class466)item2;
					PointF[] array4 = new PointF[3];
					foreach (Struct89 item3 in class5.method_2())
					{
						ref PointF reference4 = ref array4[0];
						reference4 = item3.method_2();
						ref PointF reference5 = ref array4[1];
						reference5 = item3.method_4();
						ref PointF reference6 = ref array4[2];
						reference6 = item3.method_6();
					}
					class939_0.method_9("{0} c", Class1446.smethod_3(array4));
				}
			}
		}
		if (class458_0.method_1().Count > 0)
		{
			class939_0.method_8("h W n");
		}
	}

	internal void method_4(Class1439 class1439_0, bool bool_0, Class939 class939_0)
	{
		if (bool_0)
		{
			if (class1439_0 == class1443_0.method_1())
			{
				return;
			}
			class1443_0.method_2(class1439_0);
		}
		else
		{
			if (class1439_0 == class1443_0.method_3())
			{
				return;
			}
			class1443_0.method_4(class1439_0);
		}
		class939_0.method_10("/{0} {1}", class1439_0.method_0(), bool_0 ? "CS" : "cs");
	}

	internal void method_5(Color color_0, bool bool_0, Class939 class939_0)
	{
		if (bool_0)
		{
			if (class1443_0.method_1() == Class1439.smethod_1() && color_0.ToArgb() == class1443_0.method_5().ToArgb())
			{
				return;
			}
			class1443_0.method_2(Class1439.smethod_1());
			class1443_0.method_6(color_0);
		}
		else
		{
			if (class1443_0.method_3() == Class1439.smethod_1() && color_0.ToArgb() == class1443_0.method_7().ToArgb())
			{
				return;
			}
			class1443_0.method_4(Class1439.smethod_1());
			class1443_0.method_8(color_0);
		}
		if (color_0.A < byte.MaxValue)
		{
			Class953 @class = class1440_0.method_2().method_4();
			float float_ = (float)(int)color_0.A / 255f;
			if (bool_0)
			{
				@class.method_5(float_);
			}
			else
			{
				@class.method_7(float_);
			}
			method_15(@class, class939_0);
		}
		class939_0.method_10("{0} {1}", Class1446.smethod_9(color_0), bool_0 ? "RG" : "rg");
	}

	internal void method_6(float float_0, Class939 class939_0)
	{
		if (float_0 != class1443_0.method_9())
		{
			class1443_0.method_10(float_0);
			class939_0.method_9("{0} TL", Class1446.smethod_5(float_0));
		}
	}

	internal void method_7(Class954 class954_0, float float_0, Class939 class939_0)
	{
		if (class954_0 != class1443_0.TextFont || float_0 != class1443_0.method_12())
		{
			class1443_0.method_11(class954_0);
			class1443_0.method_13(float_0);
			class939_0.method_10("/{0} {1} Tf", class954_0.method_3(), Class1446.smethod_5(float_0));
		}
	}

	internal void method_8(int int_0, Class939 class939_0)
	{
		if (int_0 != class1443_0.method_14())
		{
			class1443_0.method_15(int_0);
			class939_0.method_9("{0} Tr", int_0);
		}
	}

	internal void method_9(float float_0, Class939 class939_0)
	{
		class939_0.method_9("{0} Tc", Class1446.smethod_5(float_0));
	}

	internal void method_10(float float_0, Class939 class939_0)
	{
		if (float_0 != class1443_0.method_16())
		{
			class1443_0.method_17(float_0);
			class939_0.method_9("{0} w", Class1446.smethod_5(float_0));
		}
	}

	internal void method_11(int int_0, Class939 class939_0)
	{
		if (int_0 != class1443_0.method_18())
		{
			class1443_0.method_19(int_0);
			class939_0.method_9("{0} J", int_0);
		}
	}

	internal void method_12(int int_0, Class939 class939_0)
	{
		if (int_0 != class1443_0.method_20())
		{
			class1443_0.method_21(int_0);
			class939_0.method_9("{0} j", int_0);
		}
	}

	internal void method_13(float float_0, Class939 class939_0)
	{
		if (float_0 != class1443_0.method_22())
		{
			class1443_0.method_23(float_0);
			class939_0.method_9("{0} M", Class1446.smethod_5(float_0));
		}
	}

	internal void method_14(float[] float_0, float float_1, Class939 class939_0)
	{
		class939_0.method_10("[{0}] {1} d", Class1446.smethod_8(float_0), Class1446.smethod_5(float_1));
	}

	private void method_15(Class953 class953_0, Class939 class939_0)
	{
		if (!class953_0.Equals(class1443_0.method_24()))
		{
			class1443_0.method_25(class953_0);
			class939_0.method_9("/{0} gs", class953_0.method_3());
		}
	}

	internal RectangleF method_16(RectangleF rectangleF_0)
	{
		PointF[] array = new PointF[2]
		{
			new PointF(rectangleF_0.Left, rectangleF_0.Top),
			new PointF(rectangleF_0.Right, rectangleF_0.Bottom)
		};
		class1443_0.method_0().TransformPoints(array);
		RectangleF result = default(RectangleF);
		result.X = Math.Min(array[0].X, array[1].X);
		result.Y = Math.Min(array[0].Y, array[1].Y);
		result.Width = Math.Abs(array[0].X - array[1].X);
		result.Height = Math.Abs(array[0].Y - array[1].Y);
		return result;
	}

	[SpecialName]
	internal Class1443 method_17()
	{
		return class1443_0;
	}
}
