using System.Drawing.Drawing2D;

namespace ns321;

internal class Class7183 : Class7182
{
	private float float_0;

	private float float_1;

	private float float_2;

	public float Angle
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

	public float MiddleX
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

	public float MiddleY
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	internal override Matrix PointMatrix
	{
		get
		{
			Matrix matrix = new Matrix();
			matrix.Translate(MiddleX, MiddleY);
			matrix.Rotate(Angle);
			matrix.Translate(0f - MiddleX, 0f - MiddleY);
			return matrix;
		}
	}

	public Class7183(float angle)
	{
		Angle = angle;
	}

	public Class7183(float angle, float xMiddle, float yMiddle)
		: this(angle)
	{
		MiddleX = xMiddle;
		MiddleY = yMiddle;
	}
}
