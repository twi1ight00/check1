using System.Collections;
using System.Drawing;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns18;
using ns2;

namespace ns44;

internal class Class986 : Class984
{
	internal DataBar dataBar_0;

	internal Class1658 class1658_0;

	internal Cell cell_0;

	internal CellArea cellArea_0;

	public Class986(DataBar dataBar_1, Class1658 class1658_1, Cell cell_1, CellArea cellArea_1)
	{
		dataBar_0 = dataBar_1;
		class1658_0 = class1658_1;
		cell_0 = cell_1;
		cellArea_0 = cellArea_1;
	}

	public override Class454 vmethod_0(RectangleF rectangleF_0, double[] double_0, TextAlignmentType textAlignmentType_0)
	{
		new ArrayList();
		try
		{
			double num = (double)Class984.Calculate(cell_0, dataBar_0.MaxCfvo, cellArea_0, class1658_0);
			double num2 = (double)Class984.Calculate(cell_0, dataBar_0.MinCfvo, cellArea_0, class1658_0);
			float num3 = 0f;
			num3 = ((num != num2) ? ((float)((cell_0.DoubleValue - num2) / (num - num2))) : ((cell_0.DoubleValue == num) ? 0.5f : ((!(cell_0.DoubleValue > num)) ? 0f : 1f)));
			num3 = (num3 * (float)(dataBar_0.MaxLength - dataBar_0.MinLength) + (float)dataBar_0.MinLength) / 100f;
			if (num3 > (float)dataBar_0.MaxLength / 100f)
			{
				num3 = (float)dataBar_0.MaxLength / 100f;
			}
			if (num3 < (float)dataBar_0.MinLength / 100f)
			{
				num3 = (float)dataBar_0.MinLength / 100f;
			}
			Color color_ = Color.FromArgb(255, dataBar_0.Color);
			Color color_2 = Color.FromArgb(255, 255, 255, 255);
			RectangleF rectangleF_ = new RectangleF(new PointF(rectangleF_0.Location.X, rectangleF_0.Location.Y + 1f), new SizeF(rectangleF_0.Width * num3, rectangleF_0.Height - 2f));
			ArrayList arrayList = Class1200.smethod_0(color_, color_2, rectangleF_, GradientStyleType.Vertical, 1);
			Class454 @class = new Class454();
			@class.vmethod_2(new Class458(rectangleF_));
			foreach (Class458 item in arrayList)
			{
				@class.Add(item);
			}
			return @class;
		}
		catch
		{
			return null;
		}
	}

	public override bool vmethod_1()
	{
		return dataBar_0.ShowValue;
	}
}
