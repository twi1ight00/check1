using System;
using System.Drawing;
using System.Text;

namespace ns183;

internal class Class5393
{
	private int int_0;

	private int int_1;

	private int int_2;

	private double double_0;

	private double double_1;

	public Class5393(int widthPx, int heightPx, double dpiHorizontal, double dpiVertical)
	{
		method_0(widthPx, heightPx);
		method_2(dpiHorizontal, dpiVertical);
	}

	public Class5393(int widthPx, int heightPx, double dpi)
		: this(widthPx, heightPx, dpi, dpi)
	{
	}

	public Class5393()
	{
	}

	public void method_0(int width, int height)
	{
		int_0 = width;
		int_1 = height;
	}

	public void method_1(int width, int height)
	{
		int_0 = (int)smethod_0(width);
		int_1 = (int)smethod_0(height);
	}

	public void method_2(double horizontal, double vertical)
	{
		double_0 = horizontal;
		double_1 = vertical;
	}

	public void method_3(double resolution)
	{
		method_2(resolution, resolution);
	}

	public void method_4(int distance)
	{
		int_2 = distance;
	}

	public int method_5()
	{
		return int_2;
	}

	public int method_6()
	{
		return int_0;
	}

	public int method_7()
	{
		return int_1;
	}

	public int method_8()
	{
		return (int)Math.Round(smethod_1((double)int_0 / double_0));
	}

	public int method_9()
	{
		return (int)Math.Round(smethod_1((double)int_1 / double_1));
	}

	public double method_10()
	{
		return double_0;
	}

	public double method_11()
	{
		return double_1;
	}

	public Size method_12()
	{
		return new Size(method_8(), method_9());
	}

	public SizeF method_13()
	{
		return new SizeF((float)method_8() / 1000f, (float)method_9() / 1000f);
	}

	public Size method_14()
	{
		return new Size(method_6(), method_7());
	}

	private void method_15()
	{
		if (double_0 == 0.0 || double_1 == 0.0)
		{
			throw new InvalidOperationException("The resolution must be set");
		}
	}

	private static double smethod_0(double mpt)
	{
		return mpt / 72.0 / 1000.0;
	}

	private static double smethod_1(double @in)
	{
		return @in * 72.0 * 1000.0;
	}

	public void method_16()
	{
		method_15();
		int_0 = (int)Math.Round(smethod_1((double)int_0 / double_0));
		int_1 = (int)Math.Round(smethod_1((double)int_1 / double_1));
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Size: ");
		stringBuilder.Append(method_8()).Append('x').Append(method_9())
			.Append(" mpt");
		stringBuilder.Append(" (");
		stringBuilder.Append(method_6()).Append('x').Append(method_7())
			.Append(" px");
		stringBuilder.Append(" at ").Append(method_10()).Append('x')
			.Append(method_11());
		stringBuilder.Append(" dpi");
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}
}
