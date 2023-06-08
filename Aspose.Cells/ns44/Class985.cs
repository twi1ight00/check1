using System.Collections;
using System.Drawing;
using Aspose.Cells;
using ns18;
using ns2;

namespace ns44;

internal class Class985 : Class984
{
	internal ColorScale colorScale_0;

	internal Class1658 class1658_0;

	internal Cell cell_0;

	internal CellArea cellArea_0;

	public Class985(ColorScale colorScale_1, Class1658 class1658_1, Cell cell_1, CellArea cellArea_1)
	{
		colorScale_0 = colorScale_1;
		class1658_0 = class1658_1;
		cell_0 = cell_1;
		cellArea_0 = cellArea_1;
	}

	private Class454 method_0(RectangleF rectangleF_0, double[] double_0, TextAlignmentType textAlignmentType_0)
	{
		double num = (double)Class984.Calculate(cell_0, colorScale_0.MaxCfvo, cellArea_0, class1658_0);
		double num2 = (double)Class984.Calculate(cell_0, colorScale_0.MinCfvo, cellArea_0, class1658_0);
		double num3 = 0.0;
		try
		{
			num3 = ((num != num2) ? ((double)(float)((cell_0.DoubleValue - num2) / (num - num2))) : ((!(cell_0.DoubleValue >= num)) ? 0.0 : 1.0));
			_ = colorScale_0.MaxColor.A;
			_ = colorScale_0.MinColor.A;
			_ = colorScale_0.MinColor.A;
			int red = (int)((double)(colorScale_0.MaxColor.R - colorScale_0.MinColor.R) * num3 + (double)(int)colorScale_0.MinColor.R);
			int green = (int)((double)(colorScale_0.MaxColor.G - colorScale_0.MinColor.G) * num3 + (double)(int)colorScale_0.MinColor.G);
			int blue = (int)((double)(colorScale_0.MaxColor.B - colorScale_0.MinColor.B) * num3 + (double)(int)colorScale_0.MinColor.B);
			Color color = Color.FromArgb(255, red, green, blue);
			Class454 @class = new Class454();
			Class458 class2 = new Class458(rectangleF_0);
			class2.method_3(new SolidBrush(color));
			@class.Add(class2);
			return @class;
		}
		catch
		{
			return null;
		}
	}

	private Class454 method_1(RectangleF rectangleF_0, double[] double_0, TextAlignmentType textAlignmentType_0)
	{
		double num = (double)Class984.Calculate(cell_0, colorScale_0.MaxCfvo, cellArea_0, class1658_0);
		double num2 = (double)Class984.Calculate(cell_0, colorScale_0.MinCfvo, cellArea_0, class1658_0);
		double num3 = (double)Class984.Calculate(cell_0, colorScale_0.MidCfvo, cellArea_0, class1658_0);
		double num4 = 0.0;
		try
		{
			Color color = colorScale_0.MaxColor;
			Color color2 = colorScale_0.MinColor;
			if (cell_0.DoubleValue >= num3)
			{
				num2 = num3;
				color2 = colorScale_0.MidColor;
			}
			else
			{
				num = num3;
				color = colorScale_0.MidColor;
			}
			num4 = ((num != num2) ? ((double)(float)((cell_0.DoubleValue - num2) / (num - num2))) : ((cell_0.DoubleValue == num) ? 0.5 : ((!(cell_0.DoubleValue > num)) ? 0.0 : 1.0)));
			_ = color.A;
			_ = color2.A;
			_ = color2.A;
			int red = (int)((double)(color.R - color2.R) * num4 + (double)(int)color2.R);
			int green = (int)((double)(color.G - color2.G) * num4 + (double)(int)color2.G);
			int blue = (int)((double)(color.B - color2.B) * num4 + (double)(int)color2.B);
			Color color3 = Color.FromArgb(255, red, green, blue);
			Class454 @class = new Class454();
			Class458 class2 = new Class458(rectangleF_0);
			class2.method_3(new SolidBrush(color3));
			@class.Add(class2);
			return @class;
		}
		catch
		{
			return null;
		}
	}

	public override Class454 vmethod_0(RectangleF rectangleF_0, double[] double_0, TextAlignmentType textAlignmentType_0)
	{
		new ArrayList();
		try
		{
			if (!colorScale_0.method_0())
			{
				return method_0(rectangleF_0, double_0, textAlignmentType_0);
			}
			return method_1(rectangleF_0, double_0, textAlignmentType_0);
		}
		catch
		{
			return null;
		}
	}

	public override bool vmethod_1()
	{
		return true;
	}
}
