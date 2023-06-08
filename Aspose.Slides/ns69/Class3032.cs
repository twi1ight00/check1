namespace ns69;

internal sealed class Class3032
{
	private double double_0;

	private double double_1;

	private double double_2;

	public double XCenter => double_0;

	public double YCenter => double_1;

	public double RadiusSqr => double_2;

	public Class3032(Class3040 triangle)
	{
		double x = triangle.Vertices[0].X;
		double y = triangle.Vertices[0].Y;
		double x2 = triangle.Vertices[1].X;
		double y2 = triangle.Vertices[1].Y;
		double x3 = triangle.Vertices[2].X;
		double y3 = triangle.Vertices[2].Y;
		double num = x * x + y * y;
		double num2 = x2 * x2 + y2 * y2;
		double num3 = x3 * x3 + y3 * y3;
		double num4 = x * (y2 - y3) - y * (x2 - x3) + (x2 * y3 - y2 * x3);
		double num5 = num * (y2 - y3) - y * (num2 - num3) + (num2 * y3 - y2 * num3);
		double num6 = num * (x2 - x3) - x * (num2 - num3) + (num2 * x3 - x2 * num3);
		double_0 = num5 / (2.0 * num4);
		double_1 = (0.0 - num6) / (2.0 * num4);
		double num7 = XCenter - x;
		double num8 = YCenter - y;
		double_2 = num7 * num7 + num8 * num8;
	}
}
