using System;
using System.Drawing;

namespace ns316;

internal class Class7139 : Class7138
{
	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	public override bool IsConstant => true;

	public virtual float Azimuth => float_1;

	public virtual float Elevation => float_2;

	public Class7139(float angle, float elevation, Color lightColor)
		: base(lightColor)
	{
		float_1 = angle;
		float_2 = elevation;
		float_3 = (float)Math.Cos(Math.PI / 180.0 * (double)angle) * (float)Math.Cos(Math.PI / 180.0 * (double)elevation);
		float_4 = (float)Math.Sin(Math.PI / 180.0 * (double)angle) * (float)Math.Cos(Math.PI / 180.0 * (double)elevation);
		float_5 = (float)Math.Sin(Math.PI / 180.0 * (double)elevation);
	}

	public virtual void vmethod_0(float x, float y, float z, float[] resultSet)
	{
		resultSet[0] = float_3;
		resultSet[1] = float_4;
		resultSet[2] = float_5;
	}

	public override float[][] imethod_2(float x, float y, float dx, int width, float[][] z, float[][] lightRow)
	{
		float[][] array = lightRow;
		if (array == null)
		{
			array = new float[width][];
			float[] array2 = new float[3] { float_3, float_4, float_5 };
			for (int i = 0; i < width; i++)
			{
				array[i] = array2;
			}
		}
		else
		{
			float num = float_3;
			float num2 = float_4;
			float num3 = float_5;
			for (int j = 0; j < width; j++)
			{
				array[j][0] = num;
				array[j][1] = num2;
				array[j][2] = num3;
			}
		}
		return array;
	}
}
