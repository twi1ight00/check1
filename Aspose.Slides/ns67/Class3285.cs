using System.Collections.Generic;

namespace ns67;

internal abstract class Class3285 : Class3280
{
	internal override Class3069[] vmethod_2(List<Class3376> paragraphs)
	{
		Class3381[] array = method_2();
		int[] array2 = Class3280.smethod_14(paragraphs.Count, array.Length);
		double num = method_7(paragraphs, array, array2);
		if (num < 1.0)
		{
			method_6(paragraphs, num);
		}
		List<Class3069> list = new List<Class3069>();
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			Class3381 @class = array[i];
			int num3 = array2[i];
			double num4 = 0.0;
			double num5 = 0.0;
			for (int j = 0; j < num3; j++)
			{
				Class3376 class2 = paragraphs[num2 + j];
				num4 += class2.MaxHeight;
				if (class2.MaxFontSize > num5)
				{
					num5 = class2.MaxFontSize;
				}
			}
			switch (i)
			{
			case 2:
				num4 *= -1.0;
				break;
			case 1:
				if (num3 > 1)
				{
					num4 *= 0.75;
				}
				break;
			}
			for (int k = 0; k < num3; k++)
			{
				Class3376 class3 = paragraphs[num2];
				num4 += ((i == 2) ? class3.MaxHeight : (0.0 - class3.MaxHeight));
				list.AddRange(method_8(class3, @class.method_1(num4), num5));
				num2++;
			}
		}
		return list.ToArray();
	}

	private void method_6(List<Class3376> paragraphs, double ratio)
	{
		Class3376 @class = Class3376.smethod_0(paragraphs);
		Struct159 center = @class.Bounds.Center;
		foreach (Class3376 paragraph in paragraphs)
		{
			paragraph.method_1(center, ratio);
		}
	}

	private double method_7(IList<Class3376> paragraphs, Class3381[] guidelines, int[] paragraphsPerGuideline)
	{
		double num = 1.0;
		int num2 = 0;
		for (int i = 0; i < guidelines.Length; i++)
		{
			Class3381 @class = guidelines[i];
			int num3 = paragraphsPerGuideline[i];
			for (int j = 0; j < num3; j++)
			{
				Class3376 class2 = paragraphs[num2];
				double num4 = @class.Length / class2.HorizontalLength;
				if (num4 < num)
				{
					num = num4;
				}
				num2++;
			}
		}
		return num;
	}

	private Class3069[] method_8(Class3376 paragraph, Class3381 guideline, double maxFontSize)
	{
		List<Class3069> list = new List<Class3069>();
		double num = 0.0;
		if (paragraph.Alignment == Enum468.const_1)
		{
			num = (guideline.Length - paragraph.HorizontalLength) / 2.0;
		}
		else if (paragraph.Alignment == Enum468.const_2)
		{
			num = guideline.Length - paragraph.HorizontalLength;
		}
		Struct158 right = new Struct158(base.Transform2D.Offset.X, base.Transform2D.Offset.Y);
		Class3071[] contours = paragraph.Contours;
		foreach (Class3071 @class in contours)
		{
			_ = num / guideline.Length;
			double percent = (num + @class.Bounds.Width / 2.0) / guideline.Length;
			Struct159 left = guideline.method_2(percent);
			Struct158 a = guideline.method_3(percent, 1.0, isOutside: true);
			Struct158 a2 = Struct158.smethod_7(a.method_2());
			left = Struct158.smethod_3(left, right);
			Class3031[] array = @class.TextContourList.ContourList.method_0();
			foreach (Class3031 class2 in array)
			{
				Struct159 left2 = new Struct159(@class.Bounds.Left + @class.Bounds.Width / 2.0, @class.Bounds.Bottom - maxFontSize * 127.0 * 0.5);
				for (int k = 0; k < class2.PointsCount; k++)
				{
					Struct158 @struct = Struct159.smethod_0(left2, class2[k]);
					Struct158 right2 = Struct158.smethod_1(Struct158.smethod_5(a2, @struct.Dx), Struct158.smethod_5(a, @struct.Dy));
					class2[k] = Struct158.smethod_3(left, right2);
				}
			}
			list.Add(@class.TextContourList);
			num += @class.Bounds.Width;
		}
		return list.ToArray();
	}
}
