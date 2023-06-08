using System;
using System.Drawing;

namespace ns310;

internal class Class7121 : Class7120
{
	public PointF pointF_0;

	public PointF pointF_1;

	public PointF pointF_2;

	public PointF pointF_3;

	private static int int_1;

	public virtual RectangleF BoundsArea
	{
		get
		{
			float[] array = new float[2];
			float[] array2 = array;
			smethod_12(pointF_0.X, pointF_1.X, pointF_2.X, pointF_3.X, array2);
			float[] array3 = new float[2];
			float[] array4 = array3;
			smethod_12(pointF_0.Y, pointF_1.Y, pointF_2.Y, pointF_3.Y, array4);
			return new RectangleF(array2[0], array4[0], array2[1] - array2[0], array4[1] - array4[0]);
		}
	}

	public virtual float Length => vmethod_12(1E-06f);

	public Class7121(PointF pointStart, PointF pointSecond, PointF pointMid, PointF pointEnd)
	{
		pointF_0 = pointStart;
		pointF_1 = pointSecond;
		pointF_2 = pointMid;
		pointF_3 = pointEnd;
	}

	public virtual object Clone()
	{
		return new Class7121(new PointF(pointF_0.X, pointF_0.Y), new PointF(pointF_1.X, pointF_1.Y), new PointF(pointF_2.X, pointF_2.Y), new PointF(pointF_3.X, pointF_3.Y));
	}

	public virtual Interface378 vmethod_0()
	{
		return new Class7121(new PointF(pointF_3.X, pointF_3.Y), new PointF(pointF_2.X, pointF_2.Y), new PointF(pointF_1.X, pointF_1.Y), new PointF(pointF_0.X, pointF_0.Y));
	}

	private static void smethod_12(float pointStartX, float pointStartY, float pointEndX, float pointEndY, float[] bounds)
	{
		if (pointEndY > pointStartX)
		{
			bounds[0] = pointStartX;
			bounds[1] = pointEndY;
		}
		else
		{
			bounds[0] = pointEndY;
			bounds[1] = pointStartX;
		}
		float num = 3f * (pointStartY - pointStartX);
		float num2 = 6f * (pointEndX - pointStartY);
		float num3 = 3f * (pointEndY - pointEndX);
		float[] array = new float[3]
		{
			num,
			num2 - 2f * num,
			num3 - num2 + num
		};
		int num4 = -1;
		for (int i = 0; i < num4; i++)
		{
			float num5 = array[i];
			if (!(num5 <= 0f) && !(num5 >= 1f))
			{
				num5 = (1f - num5) * (1f - num5) * (1f - num5) * pointStartX + 3f * num5 * (1f - num5) * (1f - num5) * pointStartY + 3f * num5 * num5 * (1f - num5) * pointEndX + num5 * num5 * num5 * pointEndY;
				if (num5 < bounds[0])
				{
					bounds[0] = num5;
				}
				else if (num5 > bounds[1])
				{
					bounds[1] = num5;
				}
			}
		}
	}

	public Class7121()
	{
		pointF_0 = default(PointF);
		pointF_1 = default(PointF);
		pointF_2 = default(PointF);
		pointF_3 = default(PointF);
	}

	public Class7121(float pointStartX, float pointStartY, float pointMidStartX, float pointMidStartY, float pointMidStartSecondX, float pointMidStartSecondY, float pointEndX, float pointEndY)
	{
		pointF_0 = new PointF(pointStartX, pointStartY);
		pointF_1 = new PointF(pointMidStartX, pointMidStartY);
		pointF_2 = new PointF(pointMidStartSecondX, pointMidStartSecondY);
		pointF_3 = new PointF(pointEndX, pointEndY);
	}

	public virtual float vmethod_1()
	{
		float[] array = new float[2];
		float[] array2 = array;
		smethod_12(pointF_0.X, pointF_1.X, pointF_2.X, pointF_3.X, array2);
		return array2[0];
	}

	public virtual float vmethod_2()
	{
		float[] array = new float[2];
		float[] array2 = array;
		smethod_12(pointF_0.X, pointF_1.X, pointF_2.X, pointF_3.X, array2);
		return array2[1];
	}

	public virtual float vmethod_3()
	{
		float[] array = new float[2];
		float[] array2 = array;
		smethod_12(pointF_0.Y, pointF_1.Y, pointF_2.Y, pointF_3.Y, array2);
		return array2[0];
	}

	public virtual float vmethod_4()
	{
		float[] array = new float[2];
		float[] array2 = array;
		smethod_12(pointF_0.Y, pointF_1.Y, pointF_2.Y, pointF_3.Y, array2);
		return array2[1];
	}

	public virtual PointF vmethod_5(float value)
	{
		float x = 3f * ((pointF_1.X - pointF_0.X) * (1f - value) * (1f - value) + 2f * (pointF_2.X - pointF_1.X) * (1f - value) * value + (pointF_3.X - pointF_2.X) * value * value);
		float y = 3f * ((pointF_1.Y - pointF_0.Y) * (1f - value) * (1f - value) + 2f * (pointF_2.Y - pointF_1.Y) * (1f - value) * value + (pointF_3.Y - pointF_2.Y) * value * value);
		return new PointF(x, y);
	}

	public virtual PointF vmethod_6(float value)
	{
		float x = (1f - value) * (1f - value) * (1f - value) * pointF_0.X + 3f * (value * (1f - value) * (1f - value) * pointF_1.X + value * value * (1f - value) * pointF_2.X) + value * value * value * pointF_3.X;
		float y = (1f - value) * (1f - value) * (1f - value) * pointF_0.Y + 3f * (value * (1f - value) * (1f - value) * pointF_1.Y + value * value * (1f - value) * pointF_2.Y) + value * value * value * pointF_3.Y;
		return new PointF(x, y);
	}

	public virtual void vmethod_7(Interface378 firstPart, Interface378 secondPart)
	{
		Class7121 firstPart2 = firstPart as Class7121;
		Class7121 secondPart2 = secondPart as Class7121;
		vmethod_9(firstPart2, secondPart2);
	}

	public virtual void vmethod_8(float value, Interface378 firstPart, Interface378 secondPart)
	{
		Class7121 firstPart2 = firstPart as Class7121;
		Class7121 secondPart2 = secondPart as Class7121;
		vmethod_10(value, firstPart2, secondPart2);
	}

	public virtual void vmethod_9(Class7121 firstPart, Class7121 secondPart)
	{
		if (firstPart != null || secondPart != null)
		{
			float num = (pointF_0.X + 3f * (pointF_1.X + pointF_2.X) + pointF_3.X) * 0.125f;
			float num2 = (pointF_0.Y + 3f * (pointF_1.Y + pointF_2.Y) + pointF_3.Y) * 0.125f;
			float num3 = (pointF_1.X - pointF_0.X + 2f * (pointF_2.X - pointF_1.X) + (pointF_3.X - pointF_2.X)) * 0.125f;
			float num4 = (pointF_1.Y - pointF_0.Y + 2f * (pointF_2.Y - pointF_1.Y) + (pointF_3.Y - pointF_2.Y)) * 0.125f;
			if (firstPart != null)
			{
				firstPart.pointF_0.X = pointF_0.X;
				firstPart.pointF_0.Y = pointF_0.Y;
				firstPart.pointF_1.X = (pointF_1.X + pointF_0.X) * 0.5f;
				firstPart.pointF_1.Y = (pointF_1.Y + pointF_0.Y) * 0.5f;
				firstPart.pointF_2.X = num - num3;
				firstPart.pointF_2.Y = num2 - num4;
				firstPart.pointF_3.X = num;
				firstPart.pointF_3.Y = num2;
			}
			if (secondPart != null)
			{
				secondPart.pointF_0.X = num;
				secondPart.pointF_0.Y = num2;
				secondPart.pointF_1.X = num + num3;
				secondPart.pointF_1.Y = num2 + num4;
				secondPart.pointF_2.X = (pointF_3.X + pointF_2.X) * 0.5f;
				secondPart.pointF_2.Y = (pointF_3.Y + pointF_2.Y) * 0.5f;
				secondPart.pointF_3.X = pointF_3.X;
				secondPart.pointF_3.Y = pointF_3.Y;
			}
		}
	}

	public virtual void vmethod_10(float value, Class7121 firstPart, Class7121 secondPart)
	{
		if (firstPart != null || secondPart != null)
		{
			PointF pointF = vmethod_6(value);
			PointF pointF2 = vmethod_5(value);
			if (firstPart != null)
			{
				firstPart.pointF_0.X = pointF_0.X;
				firstPart.pointF_0.Y = pointF_0.Y;
				firstPart.pointF_1.X = (pointF_1.X + pointF_0.X) * value;
				firstPart.pointF_1.Y = (pointF_1.Y + pointF_0.Y) * value;
				firstPart.pointF_2.X = pointF.X - pointF2.X * value / 3f;
				firstPart.pointF_2.Y = pointF.Y - pointF2.Y * value / 3f;
				firstPart.pointF_3.X = pointF.X;
				firstPart.pointF_3.Y = pointF.Y;
			}
			if (secondPart != null)
			{
				secondPart.pointF_0.X = pointF.X;
				secondPart.pointF_0.Y = pointF.Y;
				secondPart.pointF_1.X = pointF.X + pointF2.X * (1f - value) / 3f;
				secondPart.pointF_1.Y = pointF.Y + pointF2.Y * (1f - value) / 3f;
				secondPart.pointF_2.X = (pointF_3.X + pointF_2.X) * (1f - value);
				secondPart.pointF_2.Y = (pointF_3.Y + pointF_2.Y) * (1f - value);
				secondPart.pointF_3.X = pointF_3.X;
				secondPart.pointF_3.Y = pointF_3.Y;
			}
		}
	}

	public virtual Interface378 vmethod_11(float partFirst, float partSecond)
	{
		float num = partSecond - partFirst;
		PointF pointStart = vmethod_6(partFirst);
		PointF pointF = vmethod_5(partFirst);
		PointF pointSecond = new PointF(pointStart.X + num * pointF.X / 3f, pointStart.Y + num * pointF.Y / 3f);
		PointF pointEnd = vmethod_6(partSecond);
		PointF pointF2 = vmethod_5(partSecond);
		return new Class7121(pointMid: new PointF(pointEnd.X - num * pointF2.X / 3f, pointEnd.Y - num * pointF2.Y / 3f), pointStart: pointStart, pointSecond: pointSecond, pointEnd: pointEnd);
	}

	public virtual float vmethod_12(float number)
	{
		float num = pointF_1.X - pointF_0.X;
		float num2 = pointF_1.Y - pointF_0.Y;
		float num3 = (float)Math.Sqrt(num * num + num2 * num2);
		num = pointF_3.X - pointF_2.X;
		num2 = pointF_3.Y - pointF_2.Y;
		float num4 = (float)Math.Sqrt(num * num + num2 * num2);
		num = pointF_2.X - pointF_1.X;
		num2 = pointF_2.Y - pointF_1.Y;
		float num5 = (float)Math.Sqrt(num * num + num2 * num2);
		float number2 = number * (num3 + num4 + num5);
		return vmethod_13(num3, num4, number2);
	}

	internal virtual float vmethod_13(float leftLength, float rightLength, float number)
	{
		int_1++;
		float num = pointF_2.X - pointF_1.X;
		float num2 = pointF_2.Y - pointF_1.Y;
		float num3 = (float)Math.Sqrt(num * num + num2 * num2);
		float num4 = pointF_3.X - pointF_0.X;
		float num5 = pointF_3.Y - pointF_0.Y;
		float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
		float num7 = leftLength + rightLength + num3;
		if (num7 < number)
		{
			return (num7 + num6) / 2f;
		}
		float num8 = num7 - num6;
		if (num8 < number)
		{
			return (num7 + num6) / 2f;
		}
		Class7121 @class = new Class7121();
		float num9 = (pointF_0.X + 3f * (pointF_1.X + pointF_2.X) + pointF_3.X) * 0.125f;
		float num10 = (pointF_0.Y + 3f * (pointF_1.Y + pointF_2.Y) + pointF_3.Y) * 0.125f;
		float num11 = (num + num4) * 0.125f;
		float num12 = (num2 + num5) * 0.125f;
		@class.pointF_0.X = pointF_0.X;
		@class.pointF_0.Y = pointF_0.Y;
		@class.pointF_1.X = (pointF_1.X + pointF_0.X) * 0.5f;
		@class.pointF_1.Y = (pointF_1.Y + pointF_0.Y) * 0.5f;
		@class.pointF_2.X = num9 - num11;
		@class.pointF_2.Y = num10 - num12;
		@class.pointF_3.X = num9;
		@class.pointF_3.Y = num10;
		Math.Sqrt(num11 * num11 + num12 * num12);
		float result = 0f;
		@class.pointF_0.X = num9;
		@class.pointF_0.Y = num10;
		@class.pointF_1.X = num9 + num11;
		@class.pointF_1.Y = num10 + num12;
		@class.pointF_2.X = (pointF_3.X + pointF_2.X) * 0.5f;
		@class.pointF_2.Y = (pointF_3.Y + pointF_2.Y) * 0.5f;
		@class.pointF_3.X = pointF_3.X;
		@class.pointF_3.Y = pointF_3.Y;
		return result;
	}
}
