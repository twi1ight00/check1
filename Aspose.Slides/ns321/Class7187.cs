using System.Drawing.Drawing2D;

namespace ns321;

internal class Class7187 : Class7182
{
	private float float_0;

	private float float_1;

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

	internal override Matrix PointMatrix
	{
		get
		{
			Matrix matrix = new Matrix();
			matrix.Translate(ValueX, ValueY);
			return matrix;
		}
	}

	public Class7187(float xAxis, float yAxis)
	{
		float_0 = xAxis;
		float_1 = yAxis;
	}

	public Class7187(float xAxis)
		: this(xAxis, 0f)
	{
	}
}
