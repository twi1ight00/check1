using System;
using System.Drawing;

namespace ns316;

internal class Class7141 : Class7138
{
	private float float_1;

	private float float_2;

	private float float_3;

	public override bool IsConstant => false;

	public virtual float LightX => float_1;

	public virtual float LightY => float_2;

	public virtual float LightZ => float_3;

	public Class7141(float lightX, float lightY, float lightZ, Color lightColor)
		: base(lightColor)
	{
		float_1 = lightX;
		float_2 = lightY;
		float_3 = lightZ;
	}

	public void method_0(float x, float y, float z, float[] resultSet)
	{
		float num = float_1 - x;
		float num2 = float_2 - y;
		float num3 = float_3 - z;
		float num4 = (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		if (num4 > 0f)
		{
			float num5 = 1f / num4;
			num *= num5;
			num2 *= num5;
			num3 *= num5;
		}
		resultSet[0] = num;
		resultSet[1] = num2;
		resultSet[2] = num3;
	}
}
