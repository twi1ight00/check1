namespace ns67;

internal class Class3377
{
	private Struct160 struct160_0;

	public Struct160 Rectangle => struct160_0;

	public Class3377(Struct160 bounds)
	{
		struct160_0 = bounds;
	}

	public Class3377(Class3071[] lists)
	{
		if (lists.Length == 0)
		{
			struct160_0 = default(Struct160);
			return;
		}
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		foreach (Class3071 @class in lists)
		{
			Struct160 actualBounds = @class.ActualBounds;
			if (actualBounds.Left < num)
			{
				num = actualBounds.Left;
			}
			if (actualBounds.Right > num2)
			{
				num2 = actualBounds.Right;
			}
			if (@class.TextContourList.ContourList.Count > 0)
			{
				if (actualBounds.Top < num3)
				{
					num3 = actualBounds.Top;
				}
				if (actualBounds.Bottom > num4)
				{
					num4 = actualBounds.Bottom;
				}
			}
		}
		struct160_0 = new Struct160(num, num3, num2, num4);
	}

	public Class3031 method_0()
	{
		Class3031 @class = new Class3031(Enum492.const_0, stroke: true);
		@class.method_0(new Struct159(struct160_0.Left, struct160_0.Top));
		@class.method_0(new Struct159(struct160_0.Left, struct160_0.Bottom));
		@class.method_0(new Struct159(struct160_0.Right, struct160_0.Bottom));
		@class.method_0(new Struct159(struct160_0.Right, struct160_0.Top));
		@class.Close();
		return @class;
	}

	public double method_1(double x)
	{
		double num = (struct160_0.Right - x) / struct160_0.Width;
		if (num == 1.0)
		{
			num -= 1E-10;
		}
		return 1.0 - num;
	}

	public double method_2(double y)
	{
		double num = (struct160_0.Bottom - y) / struct160_0.Height;
		if (num == 1.0)
		{
			num -= 1E-10;
		}
		return 1.0 - num;
	}
}
