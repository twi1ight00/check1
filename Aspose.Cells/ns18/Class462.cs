using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class462 : Class452
{
	private PointF pointF_0;

	private SizeF sizeF_0;

	private float float_0;

	private float float_1;

	public SizeF Size
	{
		get
		{
			return sizeF_0;
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public PointF method_1()
	{
		return method_5((float)Class1397.smethod_0(method_9()));
	}

	public PointF method_2()
	{
		return method_5((float)Class1397.smethod_0(method_9() + method_11()));
	}

	public Struct89[] method_3()
	{
		float num = 45f;
		if (method_11() < 0f)
		{
			num = 0f - num;
		}
		int val = (int)(method_11() / num) + 1;
		val = Math.Min(val, 8);
		Struct89[] array = new Struct89[val];
		float num2 = method_9();
		for (int i = 0; i < val; i++)
		{
			float num3 = (float)Math.Sign(num) * Math.Min(Math.Abs(num), Math.Abs(method_9() + method_11() - num2));
			ref Struct89 reference = ref array[i];
			reference = method_4(num2, num3);
			num2 += num3;
		}
		return array;
	}

	private Struct89 method_4(float float_2, float float_3)
	{
		float_2 = (float)Class1397.smethod_0(float_2);
		float_3 = (float)Class1397.smethod_0(float_3);
		float num = method_6(float_2);
		float num2 = method_6(float_2 + float_3);
		float num3 = num2 - num;
		float num4 = num3 / 2f;
		float num5 = (float)(Math.Sin(num3) * (Math.Sqrt(4.0 + 3.0 * Math.Pow(Math.Tan(num4), 2.0)) - 1.0) / 3.0);
		Struct89 result = default(Struct89);
		result.method_1(method_5(float_2));
		result.method_7(method_5(float_2 + float_3));
		result.method_3(new PointF(result.method_0().X - num5 * method_13().Width * (float)Math.Sin(num), result.method_0().Y - num5 * method_13().Height * (float)Math.Cos(num)));
		result.method_5(new PointF(result.method_6().X + num5 * method_13().Width * (float)Math.Sin(num2), result.method_6().Y + num5 * method_13().Height * (float)Math.Cos(num2)));
		return result;
	}

	private PointF method_5(float float_2)
	{
		float num = method_6(float_2);
		return new PointF(method_14().X + method_13().Width * (float)Math.Cos(num), method_14().Y - method_13().Height * (float)Math.Sin(num));
	}

	private float method_6(float float_2)
	{
		return (float)Math.Atan2((double)(1f / method_13().Height) * Math.Sin(float_2), (double)(1f / method_13().Width) * Math.Cos(float_2));
	}

	[SpecialName]
	public PointF method_7()
	{
		return pointF_0;
	}

	[SpecialName]
	public void method_8(PointF pointF_1)
	{
		pointF_0 = pointF_1;
	}

	[SpecialName]
	public float method_9()
	{
		return float_0;
	}

	[SpecialName]
	public void method_10(float float_2)
	{
		float_0 = float_2;
	}

	[SpecialName]
	public float method_11()
	{
		return float_1;
	}

	[SpecialName]
	public void method_12(float float_2)
	{
		float_1 = float_2;
	}

	[SpecialName]
	public SizeF method_13()
	{
		return new SizeF(Size.Width / 2f, Size.Height / 2f);
	}

	[SpecialName]
	public PointF method_14()
	{
		return new PointF(method_7().X + method_13().Width, method_7().Y + method_13().Height);
	}

	public override void vmethod_0(Class468 class468_0)
	{
		class468_0.vmethod_12(this);
	}
}
