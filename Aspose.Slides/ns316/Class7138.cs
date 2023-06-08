using System;
using System.Drawing;

namespace ns316;

internal abstract class Class7138 : Interface382
{
	private float[] float_0 = new float[0];

	public virtual Color LightColor
	{
		set
		{
			float_0 = new float[3];
			float_0[0] = (float)(int)value.R / 255f;
			float_0[1] = (float)(int)value.G / 255f;
			float_0[2] = (float)(int)value.B / 255f;
		}
	}

	public virtual bool IsConstant => true;

	public Class7138()
	{
	}

	public Class7138(Color color)
	{
		LightColor = color;
	}

	public void imethod_0(float xPos, float yPos, float zPos, float[] vectorData)
	{
	}

	public static float smethod_0(float colorValue)
	{
		if ((double)colorValue <= 0.003928)
		{
			return colorValue / 12.92f;
		}
		return (float)Math.Pow((colorValue + 0.055f) / 1.055f, 2.4000000953674316);
	}

	public virtual float[] imethod_3(bool isLinear)
	{
		float[] array = new float[3];
		if (float_0.Length == 3)
		{
			if (!isLinear)
			{
				array[0] = float_0[0];
				array[1] = float_0[1];
				array[2] = float_0[2];
			}
			else
			{
				array[0] = smethod_0(float_0[0]);
				array[1] = smethod_0(float_0[1]);
				array[2] = smethod_0(float_0[2]);
			}
		}
		return array;
	}

	public virtual float[][][] imethod_1(float x, float y, float dx, float dy, int width, int height, float[][][] z)
	{
		float[][][] array = new float[height][][];
		for (int i = 0; i < height; i++)
		{
			array[i] = imethod_2(x, y, dx, width, z[i], null);
		}
		y += dy;
		return array;
	}

	public virtual float[][] imethod_2(float x, float y, float dx, int width, float[][] z, float[][] row)
	{
		float[][] array = row;
		if (array == null)
		{
			array = Class7176.smethod_0(width, 3);
		}
		for (int i = 0; i < width; i++)
		{
			imethod_0(x, y, z[i][3], array[i]);
		}
		x += dx;
		return array;
	}
}
