using System;
using System.Drawing;

namespace ns316;

internal class Class7142 : Class7138
{
	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	private float float_8;

	private float float_9;

	private readonly float[] float_10 = new float[3];

	public override bool IsConstant => false;

	public virtual float LightX => float_1;

	public virtual float LightY => float_2;

	public virtual float LightZ => float_3;

	public virtual float PointAtX => float_4;

	public virtual float PointAtY => float_5;

	public virtual float PointAtZ => float_6;

	public virtual float Focus => float_7;

	public virtual float BoundingConeAngle => float_8;

	public Class7142(float lightX, float lightY, float lightZ, float pointAtX, float pointAtY, float pointAtZ, float focus, float boundingConeAngle, Color lightColor)
		: base(lightColor)
	{
		float_1 = lightX;
		float_2 = lightY;
		float_3 = lightZ;
		float_4 = pointAtX;
		float_5 = pointAtY;
		float_6 = pointAtZ;
		float_7 = focus;
		float_8 = boundingConeAngle;
		float_9 = (float)Math.Cos(Math.PI / 180.0 * (double)boundingConeAngle);
		float_10[0] = pointAtX - lightX;
		float_10[1] = pointAtY - lightY;
		float_10[2] = pointAtZ - lightZ;
		float num = 1f / (float)Math.Sqrt(float_10[0] * float_10[0] + float_10[1] * float_10[1] + float_10[2] * float_10[2]);
		float_10[0] *= num;
		float_10[1] *= num;
		float_10[2] *= num;
	}

	public float method_0(float x, float y, float z, float[] resultSet)
	{
		float num = float_1 - x;
		float num2 = float_2 - y;
		float num3 = float_3 - z;
		float num4 = 1f / (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		num *= num4;
		num2 *= num4;
		num3 *= num4;
		float num5 = 0f - (num * float_10[0] + num2 * float_10[1] + num3 * float_10[2]);
		resultSet[0] = num;
		resultSet[1] = num2;
		resultSet[2] = num3;
		if (num5 <= float_9)
		{
			return 0f;
		}
		float num6 = float_9 / num5;
		num6 *= num6;
		num6 *= num6;
		num6 *= num6;
		num6 *= num6;
		num6 *= num6;
		num6 *= num6;
		num6 = 1f - num6;
		return num6 * (float)Math.Pow(num5, float_7);
	}

	public void method_1(float x, float y, float z, float[] resultSet)
	{
		float num = method_0(x, y, z, resultSet);
		resultSet[0] *= num;
		resultSet[1] *= num;
		resultSet[2] *= num;
	}

	public void method_2(float x, float y, float z, float[] resultSet)
	{
		resultSet[3] = method_0(x, y, z, resultSet);
	}

	public virtual float[][] vmethod_0(float x, float y, float dx, int width, float[][] z, float[][] lightRow)
	{
		float[][] array = lightRow;
		if (array == null)
		{
			array = Class7176.smethod_0(width, 4);
		}
		for (int i = 0; i < width; i++)
		{
			method_2(x, y, z[i][3], array[i]);
			x += dx;
		}
		return array;
	}
}
