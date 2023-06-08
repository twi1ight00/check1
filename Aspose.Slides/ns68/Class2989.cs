namespace ns68;

internal sealed class Class2989
{
	private double double_0;

	private double double_1;

	private Class3019 class3019_0;

	private double double_2;

	internal double Scale => double_2;

	public Class2989(Class3019 normalizedBackBuffer, Class2996 structuralEdgesBox, double scale)
	{
		class3019_0 = normalizedBackBuffer;
		double_0 = structuralEdgesBox.XOrigin;
		double_1 = structuralEdgesBox.YOrigin;
		double_2 = scale;
	}

	internal void method_0(int xBuffer, int yBuffer, out double xOrigin, out double yOrigin, out int pixelValue)
	{
		xOrigin = double_0 + (double)xBuffer * Scale;
		yOrigin = double_1 + (double)yBuffer * Scale;
		pixelValue = class3019_0.Pixels[xBuffer, yBuffer].short_0;
	}

	internal double method_1(double xBuffer)
	{
		return double_0 + xBuffer * Scale;
	}

	internal double method_2(double yBuffer)
	{
		return double_1 + yBuffer * Scale;
	}

	internal double method_3(double xOrigin)
	{
		return (xOrigin - double_0) / Scale;
	}

	internal double method_4(double yOrigin)
	{
		return (yOrigin - double_1) / Scale;
	}
}
