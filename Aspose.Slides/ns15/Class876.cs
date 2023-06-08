using System;
using Aspose.Slides.Effects;
using ns33;
using ns4;
using ns62;

namespace ns15;

internal class Class876
{
	internal static void smethod_0()
	{
	}

	internal static void smethod_1(IImageTransformOperationCollection imageTransform, Class2834 fopt)
	{
		int num = -1;
		for (int i = 0; i < imageTransform.Count; i++)
		{
			if (imageTransform[i] is ColorChange colorChange)
			{
				uint num2 = Class1165.smethod_9(colorChange.FromColor.Color);
				uint num3 = Class1165.smethod_9(colorChange.ToColor.Color);
				if (num2 == num3 && colorChange.ToColor.Color.A == 0)
				{
					num = (int)num2;
					break;
				}
			}
		}
		if (num > 0)
		{
			Class2911 property = new Class2911(Enum426.const_434, isBid: false, (uint)num);
			fopt.Properties.Add(property);
		}
		uint num4 = 0u;
		uint num5 = 65536u;
		for (int j = 0; j < imageTransform.Count; j++)
		{
			if (imageTransform[j] is Luminance luminance)
			{
				num4 = Class1162.smethod_36(luminance.Brightness / 200f);
				num5 = smethod_2(luminance.Contrast);
				break;
			}
		}
		if (num4 != 0)
		{
			Class2911 property2 = new Class2911(Enum426.const_436, isBid: false, num4);
			fopt.Properties.Add(property2);
		}
		if (num5 != 65536)
		{
			Class2911 property3 = new Class2911(Enum426.const_435, isBid: false, num5);
			fopt.Properties.Add(property3);
		}
	}

	private static uint smethod_2(double value)
	{
		if (value == 0.0)
		{
			return 65536u;
		}
		if (value == 100.0)
		{
			return 2147483647u;
		}
		if (value > 0.0)
		{
			return (uint)Math.Round(6553600.0 / (100.0 - value));
		}
		return (uint)Math.Round((value + 100.0) * 65536.0 / 100.0);
	}
}
