using System;
using System.Drawing;

namespace ns310;

internal class Class7124 : Class7123
{
	public PointF pointF_0 = default(PointF);

	public PointF pointF_1 = default(PointF);

	public virtual RectangleF AreaBounds
	{
		get
		{
			float x;
			float width;
			if (pointF_0.X < pointF_1.X)
			{
				x = pointF_0.X;
				width = pointF_1.X - pointF_0.X;
			}
			else
			{
				x = pointF_1.X;
				width = pointF_0.X - pointF_1.X;
			}
			float y;
			float height;
			if (pointF_0.Y < pointF_1.Y)
			{
				y = pointF_0.Y;
				height = pointF_1.Y - pointF_0.Y;
			}
			else
			{
				y = pointF_1.Y;
				height = pointF_0.Y - pointF_1.Y;
			}
			return new RectangleF(x, y, width, height);
		}
	}

	public virtual float Length
	{
		get
		{
			float num = pointF_1.X - pointF_0.X;
			float num2 = pointF_1.Y - pointF_0.Y;
			return (float)Math.Sqrt(num * num + num2 * num2);
		}
	}

	public Class7124(float pointX, float pointY, float pointEndX, float pointEndY)
	{
		pointF_0 = new PointF(pointX, pointY);
		pointF_1 = new PointF(pointEndX, pointEndY);
	}

	public Class7124(PointF firstPoint, PointF secondPoint)
	{
		pointF_0 = firstPoint;
		pointF_1 = secondPoint;
	}

	public Class7124()
	{
		pointF_0 = default(PointF);
		pointF_1 = default(PointF);
	}

	public virtual Class7123 vmethod_4()
	{
		return new Class7124(new PointF(pointF_1.X, pointF_1.Y), new PointF(pointF_0.X, pointF_0.Y));
	}

	public virtual float vmethod_5()
	{
		if (pointF_0.X < pointF_1.X)
		{
			return pointF_0.X;
		}
		return pointF_1.X;
	}

	public virtual float vmethod_6()
	{
		if (pointF_0.X > pointF_1.X)
		{
			return pointF_0.X;
		}
		return pointF_1.X;
	}

	public virtual float vmethod_7()
	{
		if (pointF_0.Y < pointF_1.Y)
		{
			return pointF_0.Y;
		}
		return pointF_1.Y;
	}

	public virtual float vmethod_8()
	{
		if (pointF_0.Y > pointF_1.Y)
		{
			return pointF_1.Y;
		}
		return pointF_0.Y;
	}

	public virtual PointF vmethod_9(float part)
	{
		float x = pointF_1.X - pointF_0.X;
		float y = pointF_1.Y - pointF_0.Y;
		return new PointF(x, y);
	}

	public virtual PointF vmethod_10(float part)
	{
		float x = pointF_0.X + part * (pointF_1.X - pointF_0.X);
		float y = pointF_0.Y + part * (pointF_1.Y - pointF_0.Y);
		return new PointF(x, y);
	}

	public virtual float vmethod_11(float maxErr)
	{
		return Length;
	}

	public override Class7125 vmethod_1(float pointY)
	{
		if (pointY != pointF_0.Y && pointY != pointF_1.Y)
		{
			if (pointY <= pointF_0.Y && pointY <= pointF_1.Y)
			{
				return null;
			}
			if (pointY >= pointF_0.Y && pointY >= pointF_1.Y)
			{
				return null;
			}
			float num = (pointY - pointF_0.Y) / (pointF_1.Y - pointF_0.Y);
			Class7123[] array = new Class7123[1] { vmethod_12(0f, num) };
			Class7123[] array2 = new Class7123[1] { vmethod_12(num, 1f) };
			if (pointF_1.Y < pointY)
			{
				return new Class7125(array[0], array2[0]);
			}
			return new Class7125(array2[0], array[0]);
		}
		return null;
	}

	public virtual Class7123 vmethod_12(float partFirst, float partSecond)
	{
		PointF firstPoint = vmethod_10(partFirst);
		PointF secondPoint = vmethod_10(partSecond);
		return new Class7124(firstPoint, secondPoint);
	}

	public virtual Class7123 vmethod_13(float part)
	{
		return new Class7124(pointF_0, vmethod_10(part));
	}

	public virtual Class7123 vmethod_14(float part)
	{
		return new Class7124(vmethod_10(part), pointF_1);
	}

	public virtual void vmethod_15(Class7123 listFirst, Class7123 listSecond)
	{
		Class7124 listFirst2 = listFirst as Class7124;
		Class7124 listSecond2 = listSecond as Class7124;
		vmethod_17(listFirst2, listSecond2);
	}

	public virtual void vmethod_16(float part, Class7123 listFirst, Class7123 listSecond)
	{
		Class7124 listFirst2 = listFirst as Class7124;
		Class7124 listSecond2 = listSecond as Class7124;
		vmethod_18(part, listFirst2, listSecond2);
	}

	public virtual void vmethod_17(Class7124 listFirst, Class7124 listSecond)
	{
		if (listFirst != null || listSecond != null)
		{
			float x = (pointF_0.X + pointF_1.X) * 0.5f;
			float y = (pointF_0.Y + pointF_1.Y) * 0.5f;
			if (listFirst != null)
			{
				listFirst.pointF_0.X = pointF_0.X;
				listFirst.pointF_0.Y = pointF_0.Y;
				listFirst.pointF_1.X = x;
				listFirst.pointF_1.Y = y;
			}
			if (listSecond != null)
			{
				listSecond.pointF_0.X = x;
				listSecond.pointF_0.Y = y;
				listSecond.pointF_1.X = pointF_1.X;
				listSecond.pointF_1.Y = pointF_1.Y;
			}
		}
	}

	public virtual void vmethod_18(float part, Class7124 listFirst, Class7124 listSecond)
	{
		if (listFirst != null || listSecond != null)
		{
			float x = pointF_0.X + part * (pointF_1.X - pointF_0.X);
			float y = pointF_0.Y + part * (pointF_1.Y - pointF_0.Y);
			if (listFirst != null)
			{
				listFirst.pointF_0.X = pointF_0.X;
				listFirst.pointF_0.Y = pointF_0.Y;
				listFirst.pointF_1.X = x;
				listFirst.pointF_1.Y = y;
			}
			if (listSecond != null)
			{
				listSecond.pointF_0.X = x;
				listSecond.pointF_0.Y = y;
				listSecond.pointF_1.X = pointF_1.X;
				listSecond.pointF_1.Y = pointF_1.Y;
			}
		}
	}
}
