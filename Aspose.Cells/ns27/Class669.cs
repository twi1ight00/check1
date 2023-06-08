using System;
using Aspose.Cells.Charts;
using ns7;

namespace ns27;

internal class Class669 : Class538
{
	internal Class669(bool bool_0)
	{
		method_2(4175);
		method_0(20);
		byte_0 = new byte[20];
		if (bool_0)
		{
			byte_0[0] = 5;
		}
		else
		{
			byte_0[0] = 2;
		}
		byte_0[2] = 2;
	}

	internal void method_4(ChartFrame chartFrame_0)
	{
		if (chartFrame_0.Width + chartFrame_0.Height == 0)
		{
			chartFrame_0.Chart.Calculate(bool_9: false, bool_10: false);
		}
		Array.Copy(BitConverter.GetBytes(chartFrame_0.X), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes(chartFrame_0.Y), 0, byte_0, 8, 4);
		Array.Copy(BitConverter.GetBytes(chartFrame_0.Width), 0, byte_0, 12, 4);
		Array.Copy(BitConverter.GetBytes(chartFrame_0.Height), 0, byte_0, 16, 4);
	}

	internal int[] method_5(Legend legend_0)
	{
		int[] array = new int[2];
		Array.Copy(BitConverter.GetBytes(legend_0.X), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(legend_0.Y), 0, byte_0, 8, 4);
		if (!legend_0.IsAutoSize)
		{
			array[0] = (int)((double)((float)legend_0.Width / 4000f) * legend_0.Chart.ChartObject.WidthPt - (double)legend_0.method_40());
			array[1] = (int)((double)((float)legend_0.Height / 4000f) * legend_0.Chart.ChartObject.HeightPt - (double)legend_0.method_42());
			Array.Copy(BitConverter.GetBytes(array[0]), 0, byte_0, 12, 4);
			Array.Copy(BitConverter.GetBytes(array[1]), 0, byte_0, 16, 4);
			byte_0[2] = 1;
		}
		return array;
	}

	internal void method_6(Title title_0)
	{
		if (title_0.method_7() == Enum18.const_3 && (title_0.method_1() || title_0.method_3()))
		{
			title_0.Chart.Calculate(bool_9: false, bool_10: false);
			int value = title_0.X - title_0.DefaultX;
			int value2 = title_0.Y - title_0.DefaultY;
			Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 4, 4);
			Array.Copy(BitConverter.GetBytes(value2), 0, byte_0, 8, 4);
		}
		else if (title_0.method_7() == Enum18.const_4 && (title_0.method_1() || title_0.method_3()) && title_0.axis_0 != null && title_0.axis_0 != null)
		{
			title_0.Chart.Calculate(bool_9: false, bool_10: false);
			int num = title_0.X - title_0.DefaultX;
			int num2 = title_0.Y - title_0.DefaultY;
			Axis axis_ = title_0.axis_0;
			float num3 = (float)(num * axis_.Chart.ChartObject.Width) / 4000f;
			float num4 = (float)(num2 * axis_.Chart.ChartObject.Height) / 4000f;
			float num5 = (float)(axis_.Chart.PlotArea.Width * axis_.Chart.ChartObject.Width) / 4000f;
			float num6 = (float)(axis_.Chart.PlotArea.Height * axis_.Chart.ChartObject.Height) / 4000f;
			int num7 = (int)((double)(num3 * 1000f / num5) + 0.5);
			int num8 = (int)((double)(num4 * 1000f / num6) + 0.5);
			int value3 = 0;
			int value4 = 0;
			if (axis_.method_0() == Enum17.const_0)
			{
				num8 = -num8;
				value3 = num7;
				value4 = num8;
			}
			else if (axis_.method_0() == Enum17.const_1)
			{
				num7 = -num7;
				num8 = -num8;
				value3 = num7;
				value4 = num8;
			}
			else if (axis_.method_0() == Enum17.const_3)
			{
				num8 = -num8;
				value3 = num8;
				value4 = num7;
			}
			else if (axis_.method_0() == Enum17.const_2)
			{
				value3 = num8;
				value4 = num7;
			}
			Array.Copy(BitConverter.GetBytes(value3), 0, byte_0, 4, 4);
			Array.Copy(BitConverter.GetBytes(value4), 0, byte_0, 8, 4);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(title_0.method_23()), 0, byte_0, 4, 4);
			Array.Copy(BitConverter.GetBytes(title_0.method_25()), 0, byte_0, 8, 4);
		}
		if (title_0.Width == 0)
		{
			byte_0[12] = 25;
			byte_0[16] = 23;
			return;
		}
		double num9 = (double)title_0.Width * title_0.Chart.ChartObject.WidthPt / 4000.0;
		double num10 = (double)title_0.Height * title_0.Chart.ChartObject.HeightPt / 4000.0;
		Array.Copy(BitConverter.GetBytes((int)num9), 0, byte_0, 12, 4);
		Array.Copy(BitConverter.GetBytes((int)num10), 0, byte_0, 16, 4);
	}

	internal void method_7(DataLabels dataLabels_0)
	{
		Array.Copy(BitConverter.GetBytes(dataLabels_0.method_23()), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(dataLabels_0.method_25()), 0, byte_0, 8, 4);
		Array.Copy(BitConverter.GetBytes(dataLabels_0.Width), 0, byte_0, 12, 4);
		Array.Copy(BitConverter.GetBytes(dataLabels_0.Height), 0, byte_0, 16, 4);
	}

	internal void method_8(DisplayUnitLabel displayUnitLabel_0)
	{
		Array.Copy(BitConverter.GetBytes(displayUnitLabel_0.method_23()), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(displayUnitLabel_0.method_25()), 0, byte_0, 8, 4);
		Array.Copy(BitConverter.GetBytes(displayUnitLabel_0.Width), 0, byte_0, 12, 4);
		Array.Copy(BitConverter.GetBytes(displayUnitLabel_0.Height), 0, byte_0, 16, 4);
	}
}
