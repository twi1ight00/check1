namespace ns67;

internal sealed class Class3071
{
	private Struct160 struct160_0;

	private Struct160 struct160_1;

	private Class3069 class3069_0;

	public double LeftSideBearing => struct160_0.Left - struct160_1.Left;

	public double RightSideBearing => struct160_1.Right - struct160_0.Right;

	public double ActualWidth => struct160_0.Right - struct160_0.Left;

	public double Height => struct160_1.Bottom - struct160_1.Top;

	public Struct160 Bounds => struct160_1;

	public Struct160 ActualBounds => struct160_0;

	public Class3069 TextContourList => class3069_0;

	public Class3071(Class3069 list, Struct160 glyphBoundingBox)
	{
		class3069_0 = list;
		struct160_1 = glyphBoundingBox;
		method_1();
	}

	internal void method_0(Struct159 origin, double ratio)
	{
		foreach (Class3031 contour in class3069_0.ContourList)
		{
			int pointsCount = contour.PointsCount;
			for (int i = 0; i < pointsCount; i++)
			{
				Struct158 a = Struct159.smethod_0(contour[i], origin);
				contour[i] = Struct158.smethod_3(origin, Struct158.smethod_5(a, ratio));
			}
		}
		struct160_1 = struct160_1.method_0(origin, ratio);
		method_1();
	}

	private void method_1()
	{
		bool flag = false;
		if (class3069_0.ContourList.Count > 0)
		{
			Class3031[] array = class3069_0.ContourList.method_0();
			double num = double.MaxValue;
			double num2 = double.MinValue;
			double num3 = double.MaxValue;
			double num4 = double.MinValue;
			if (array.Length > 0)
			{
				foreach (Class3031 @class in array)
				{
					if (@class.PointsCount > 0)
					{
						if (!flag)
						{
							flag = true;
						}
						Struct160 @struct = @class.method_1();
						if (@struct.Left < num)
						{
							num = @struct.Left;
						}
						if (@struct.Top < num3)
						{
							num3 = @struct.Top;
						}
						if (@struct.Right > num2)
						{
							num2 = @struct.Right;
						}
						if (@struct.Bottom > num4)
						{
							num4 = @struct.Bottom;
						}
					}
				}
			}
			struct160_0 = new Struct160(num, num3, num2, num4);
		}
		if (!flag)
		{
			struct160_0 = struct160_1;
		}
	}
}
