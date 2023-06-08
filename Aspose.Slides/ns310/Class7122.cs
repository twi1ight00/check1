using System;
using System.Drawing;

namespace ns310;

internal class Class7122 : Class7120
{
	public PointF pointF_0;

	public PointF pointF_1;

	public PointF pointF_2;

	internal static int int_1;

	public virtual RectangleF BoundsArea
	{
		get
		{
			float[] array = new float[2];
			float[] array2 = array;
			smethod_12(pointF_0.X, pointF_1.X, pointF_2.X, array2);
			float[] array3 = new float[2];
			float[] array4 = array3;
			smethod_12(pointF_0.Y, pointF_1.Y, pointF_2.Y, array4);
			return new RectangleF(array2[0], array4[0], array2[1] - array2[0], array4[1] - array4[0]);
		}
	}

	public virtual float Length => vmethod_10(1E-06f);

	public Class7122()
	{
		pointF_0 = default(PointF);
		pointF_1 = default(PointF);
		pointF_2 = default(PointF);
	}

	public Class7122(float pointXFirst, float pointYFirst, float pointXMid, float pointYMid, float pointXEnd, float pointYEnd)
	{
		pointF_0 = new PointF(pointXFirst, pointYFirst);
		pointF_1 = new PointF(pointXMid, pointYMid);
		pointF_2 = new PointF(pointXEnd, pointYEnd);
	}

	public Class7122(PointF first, PointF mid, PointF end)
	{
		pointF_0 = first;
		pointF_1 = mid;
		pointF_2 = end;
	}

	public virtual object Clone()
	{
		return new Class7122(new PointF(pointF_0.X, pointF_0.Y), new PointF(pointF_1.X, pointF_1.Y), new PointF(pointF_2.X, pointF_2.Y));
	}

	public virtual Class7120 vmethod_0()
	{
		return new Class7122(new PointF(pointF_2.X, pointF_2.Y), new PointF(pointF_1.X, pointF_1.Y), new PointF(pointF_0.X, pointF_0.Y));
	}

	private static void smethod_12(float first, float mid, float end, float[] bound)
	{
		if (end > first)
		{
			bound[0] = first;
			bound[1] = end;
		}
		else
		{
			bound[0] = end;
			bound[1] = first;
		}
		float num = first - 2f * mid + end;
		float num2 = mid - first;
		if (num == 0f)
		{
			return;
		}
		float num3 = num2 / num;
		if (!(num3 <= 0f) && num3 < 1f)
		{
			num3 = ((first - 2f * mid + end) * num3 + 2f * (mid - first)) * num3 + first;
			if (num3 < bound[0])
			{
				bound[0] = num3;
			}
			else if (num3 > bound[1])
			{
				bound[1] = num3;
			}
		}
	}

	public virtual float vmethod_1()
	{
		float[] array = new float[2];
		float[] array2 = array;
		smethod_12(pointF_0.X, pointF_1.X, pointF_2.X, array2);
		return array2[0];
	}

	public virtual float vmethod_2()
	{
		float[] array = new float[2];
		float[] array2 = array;
		smethod_12(pointF_0.X, pointF_1.X, pointF_2.X, array2);
		return array2[1];
	}

	public virtual float vmethod_3()
	{
		float[] array = new float[2];
		float[] array2 = array;
		smethod_12(pointF_0.Y, pointF_1.Y, pointF_2.Y, array2);
		return array2[0];
	}

	public virtual float vmethod_4()
	{
		float[] array = new float[2];
		float[] array2 = array;
		smethod_12(pointF_0.Y, pointF_1.Y, pointF_2.Y, array2);
		return array2[1];
	}

	public virtual PointF vmethod_5(float part)
	{
		float x = 2f * (pointF_0.X - 2f * pointF_1.X + pointF_2.X) * part + 2f * (pointF_1.X - pointF_0.X);
		float y = 2f * (pointF_0.Y - 2f * pointF_1.Y + pointF_2.Y) * part + 2f * (pointF_1.Y - pointF_0.Y);
		return new PointF(x, y);
	}

	public virtual PointF vmethod_6(float part)
	{
		float x = ((pointF_0.X - 2f * pointF_1.X + pointF_2.X) * part + 2f * (pointF_1.X - pointF_0.X)) * part + pointF_0.X;
		float y = ((pointF_0.Y - 2f * pointF_1.Y + pointF_2.Y) * part + 2f * (pointF_1.Y - pointF_0.Y)) * part + pointF_0.Y;
		return new PointF(x, y);
	}

	public virtual Class7120 vmethod_7(float first, float second)
	{
		float num = second - first;
		PointF first2 = vmethod_6(first);
		PointF pointF = vmethod_5(first);
		PointF mid = new PointF(first2.X + 0.5f * num * pointF.X, first2.Y + 0.5f * num * pointF.Y);
		PointF end = vmethod_6(second);
		return new Class7122(first2, mid, end);
	}

	public virtual void vmethod_8(Class7122 first, Class7122 second)
	{
		if (first != null || second != null)
		{
			float num = (pointF_0.X - 2f * pointF_1.X + pointF_2.X) * 0.25f + (pointF_1.X - pointF_0.X) + pointF_0.X;
			float num2 = (pointF_0.Y - 2f * pointF_1.Y + pointF_2.Y) * 0.25f + (pointF_1.Y - pointF_0.Y) + pointF_0.Y;
			float num3 = (pointF_0.X - 2f * pointF_1.X + pointF_2.X) * 0.25f + (pointF_1.X - pointF_0.X) * 0.5f;
			float num4 = (pointF_0.Y - 2f * pointF_1.Y + pointF_2.Y) * 0.25f + (pointF_1.Y - pointF_0.Y) * 0.5f;
			if (first != null)
			{
				first.pointF_0.X = pointF_0.X;
				first.pointF_0.Y = pointF_0.Y;
				first.pointF_1.X = num - num3;
				first.pointF_1.Y = num2 - num4;
				first.pointF_2.X = num;
				first.pointF_2.Y = num2;
			}
			if (second != null)
			{
				second.pointF_0.X = num;
				second.pointF_0.Y = num2;
				second.pointF_1.X = num + num3;
				second.pointF_1.Y = num2 + num4;
				second.pointF_2.X = pointF_2.X;
				second.pointF_2.Y = pointF_2.Y;
			}
		}
	}

	internal virtual float vmethod_9(float left, float right, float number)
	{
		int_1++;
		float num = pointF_2.X - pointF_0.X;
		float num2 = pointF_2.Y - pointF_0.Y;
		float num3 = (float)Math.Sqrt(num * num + num2 * num2);
		float num4 = left + right;
		if (num4 < number)
		{
			return (num4 + num3) * 0.5f;
		}
		float num5 = num4 - num3;
		if (num5 < number)
		{
			return (num4 + num3) * 0.5f;
		}
		Class7122 @class = new Class7122();
		float num6 = (pointF_0.X + 2f * pointF_1.X + pointF_2.X) * 0.25f;
		float num7 = (pointF_0.Y + 2f * pointF_1.Y + pointF_2.Y) * 0.25f;
		num = 0.25f * num;
		num2 = 0.25f * num2;
		@class.pointF_0.X = pointF_0.X;
		@class.pointF_0.Y = pointF_0.Y;
		@class.pointF_1.X = num6 - num;
		@class.pointF_1.Y = num7 - num2;
		@class.pointF_2.X = num6;
		@class.pointF_2.Y = num7;
		float result = 0f;
		@class.pointF_0.X = num6;
		@class.pointF_0.Y = num7;
		@class.pointF_1.X = num6 + num;
		@class.pointF_1.Y = num7 + num2;
		@class.pointF_2.X = pointF_2.X;
		@class.pointF_2.Y = pointF_2.Y;
		return result;
	}

	public virtual float vmethod_10(float number)
	{
		float num = pointF_1.X - pointF_0.X;
		float num2 = pointF_1.Y - pointF_0.Y;
		float num3 = (float)Math.Sqrt(num * num + num2 * num2);
		num = pointF_2.X - pointF_1.X;
		num2 = pointF_2.Y - pointF_1.Y;
		float num4 = (float)Math.Sqrt(num * num + num2 * num2);
		float number2 = number * (num3 + num4);
		return vmethod_9(num3, num4, number2);
	}

	public virtual void vmethod_11(Class7120 first, Class7120 second)
	{
		Class7122 first2 = first as Class7122;
		Class7122 second2 = second as Class7122;
		vmethod_8(first2, second2);
	}

	public virtual void vmethod_12(float part, Class7120 first, Class7120 second)
	{
		Class7122 first2 = first as Class7122;
		Class7122 second2 = second as Class7122;
		vmethod_13(part, first2, second2);
	}

	public virtual void vmethod_13(float part, Class7122 first, Class7122 second)
	{
		PointF pointF = vmethod_6(part);
		PointF pointF2 = vmethod_5(part);
		if (first != null)
		{
			first.pointF_0.X = pointF_0.X;
			first.pointF_0.Y = pointF_0.Y;
			first.pointF_1.X = pointF.X - pointF2.X * part * 0.5f;
			first.pointF_1.Y = pointF.Y - pointF2.Y * part * 0.5f;
			first.pointF_2.X = pointF.X;
			first.pointF_2.Y = pointF.Y;
		}
		if (second != null)
		{
			second.pointF_0.X = pointF.X;
			second.pointF_0.Y = pointF.Y;
			second.pointF_1.X = pointF.X + pointF2.X * (1f - part) * 0.5f;
			second.pointF_1.Y = pointF.Y + pointF2.Y * (1f - part) * 0.5f;
			second.pointF_2.X = pointF_2.X;
			second.pointF_2.Y = pointF_2.Y;
		}
	}
}
