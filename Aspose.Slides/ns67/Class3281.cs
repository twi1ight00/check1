using System.Collections.Generic;

namespace ns67;

internal abstract class Class3281 : Class3280
{
	internal override Class3069[] vmethod_2(List<Class3376> paragraphs)
	{
		Class3381[] array = method_2();
		int num = array.Length / 2;
		List<Class3376> list = Class3376.smethod_1(paragraphs);
		int[] array2 = Class3280.smethod_14(list.Count, num);
		Class3376[] array3 = new Class3376[num];
		double[] array4 = new double[num];
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			int num3 = array2[i];
			Class3376[] array5 = new Class3376[num3];
			for (int j = 0; j < num3; j++)
			{
				array5[j] = list[num2];
				num2++;
			}
			array3[i] = Class3376.smethod_0(array5);
			array4[i] = (array[i * 2].Length + array[i * 2 + 1].Length) / 2.0;
		}
		Class3377[] array6 = method_6(array3, array4);
		List<Class3069> list2 = new List<Class3069>();
		for (int k = 0; k < num; k++)
		{
			Class3376 @class = array3[k];
			list2.AddRange(method_3(@class.Contours, array6[k], array[k * 2], array[k * 2 + 1]));
		}
		return list2.ToArray();
	}

	private Class3377[] method_6(Class3376[] contours, double[] guidelinesLengths)
	{
		Struct160[] array = new Struct160[contours.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ref Struct160 reference = ref array[i];
			reference = contours[i].ActualBounds.Rectangle;
		}
		if (contours.Length > 1)
		{
			double height = array[0].Height;
			double num = array[0].Width / guidelinesLengths[0];
			for (int j = 1; j < array.Length; j++)
			{
				Struct160 @struct = array[j];
				if (@struct.Height > height)
				{
					height = @struct.Height;
				}
				double num2 = @struct.Width / guidelinesLengths[j];
				if (num2 > num)
				{
					num = num2;
				}
			}
			for (int k = 0; k < array.Length; k++)
			{
				Struct160 struct2 = array[k];
				double num3 = height - struct2.Height;
				double num4 = num * guidelinesLengths[k] - struct2.Width;
				if (contours[k].Alignment == Enum468.const_1)
				{
					ref Struct160 reference2 = ref array[k];
					reference2 = new Struct160(struct2.Left - num4 / 2.0, struct2.Top - num3 / 2.0, struct2.Right + num4 / 2.0, struct2.Bottom + num3 / 2.0);
				}
				else if (contours[k].Alignment == Enum468.const_2)
				{
					ref Struct160 reference3 = ref array[k];
					reference3 = new Struct160(struct2.Left - num4, struct2.Top - num3 / 2.0, struct2.Right, struct2.Bottom + num3 / 2.0);
				}
				else
				{
					ref Struct160 reference4 = ref array[k];
					reference4 = new Struct160(struct2.Left, struct2.Top - num3 / 2.0, struct2.Right + num4, struct2.Bottom + num3 / 2.0);
				}
			}
		}
		Class3377[] array2 = new Class3377[array.Length];
		for (int l = 0; l < array.Length; l++)
		{
			array2[l] = new Class3377(array[l]);
		}
		return array2;
	}
}
