using System;

namespace ns67;

internal class Class3379 : Class3378
{
	private Struct159 struct159_0;

	private Struct159 struct159_1;

	private double double_0;

	public override double Length => double_0;

	public override Class3378 vmethod_0()
	{
		return new Class3379(struct159_0, struct159_1);
	}

	public override Class3378 vmethod_1(double distance)
	{
		Struct158 right = Struct158.smethod_5(Struct159.smethod_0(struct159_0, struct159_1).method_2(), distance);
		return new Class3379(Struct158.smethod_3(struct159_0, right), Struct158.smethod_3(struct159_1, right));
	}

	public override Struct159 vmethod_2(double percent)
	{
		double x = struct159_0.X + (struct159_1.X - struct159_0.X) * percent;
		double y = struct159_0.Y + (struct159_1.Y - struct159_0.Y) * percent;
		return new Struct159(x, y);
	}

	public override Struct158 vmethod_3(double percent, double length, bool isOutside)
	{
		Struct158 @struct = Struct159.smethod_0(struct159_0, struct159_1).method_1();
		if (!isOutside)
		{
			return new Struct158(@struct.Dy * length, (0.0 - @struct.Dx) * length);
		}
		return new Struct158((0.0 - @struct.Dy) * length, @struct.Dx * length);
	}

	public Class3379(Struct159 start, Struct159 end)
	{
		struct159_0 = start;
		struct159_1 = end;
		double_0 = method_0(struct159_0, struct159_1);
	}

	private double method_0(Struct159 start, Struct159 end)
	{
		double num = start.X - end.X;
		double num2 = start.Y - end.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}
}
