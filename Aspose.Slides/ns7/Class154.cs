using Aspose.Slides;

namespace ns7;

internal class Class154
{
	private double double_0 = double.NaN;

	private double double_1 = double.NaN;

	private double double_2 = double.NaN;

	private double double_3 = double.NaN;

	private float float_0 = float.NaN;

	private NullableBool nullableBool_0 = NullableBool.NotDefined;

	private NullableBool nullableBool_1 = NullableBool.NotDefined;

	private double double_4 = double.NaN;

	private double double_5 = double.NaN;

	public double X => double_0;

	public double Y => double_1;

	public double Width => double_2;

	public double Height => double_3;

	public float Rotation
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public NullableBool FlipH
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
		}
	}

	public NullableBool FlipV
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
		}
	}

	public double CenterX => double_4;

	public double CenterY => double_5;

	internal Class154()
	{
	}

	public Class154(double x, double y, double width, double height, float rotationAngle, NullableBool flipH, NullableBool flipV)
	{
		method_1(x, y, width, height, rotationAngle, flipH, flipV);
	}

	public virtual void vmethod_0(double x, double y, double width, double height)
	{
		double_0 = x;
		double_1 = y;
		double_2 = width;
		double_3 = height;
		double_4 = x + width / 2.0;
		double_5 = y + height / 2.0;
	}

	public void method_0(double x, double y, double width, double height, float rotationAngle)
	{
		vmethod_0(x, y, width, height);
		float_0 = rotationAngle;
	}

	public void method_1(double x, double y, double width, double height, float rotationAngle, NullableBool flipH, NullableBool flipV)
	{
		method_0(x, y, width, height, rotationAngle);
		nullableBool_0 = flipH;
		nullableBool_1 = flipV;
	}

	public virtual void Reset()
	{
		method_1(double.NaN, double.NaN, double.NaN, double.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined);
	}
}
