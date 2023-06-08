using System;
using System.Drawing.Drawing2D;

namespace ns321;

internal class Class7186 : Class7182
{
	private float float_0;

	private float float_1;

	internal override Matrix PointMatrix
	{
		get
		{
			Matrix matrix = new Matrix();
			matrix.Shear((float)Math.Tan((double)(AngleX / 180f) * Math.PI), (float)Math.Tan((double)(AngleY / 180f) * Math.PI));
			return matrix;
		}
	}

	public float AngleX
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

	public float AngleY
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

	public Class7186(float xAxis, float yAxis)
	{
		AngleX = xAxis;
		AngleY = yAxis;
	}
}
