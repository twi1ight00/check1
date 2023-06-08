using System.Drawing.Drawing2D;

namespace ns321;

internal class Class7184 : Class7182
{
	private float float_0;

	private float float_1;

	internal override Matrix PointMatrix
	{
		get
		{
			Matrix matrix = new Matrix();
			matrix.Scale(ValueX, ValueY);
			return matrix;
		}
	}

	public float ValueX
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

	public float ValueY
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public Class7184(float xAxis)
		: this(xAxis, xAxis)
	{
	}

	public Class7184(float xAxis, float yAxis)
	{
		float_0 = xAxis;
		float_1 = yAxis;
	}
}
