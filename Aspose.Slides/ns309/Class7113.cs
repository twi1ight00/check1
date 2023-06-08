using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns311;

namespace ns309;

internal class Class7113 : Interface376
{
	internal int int_0;

	internal Interface376[] interface376_0;

	internal int[] int_1;

	internal int[] int_2;

	public virtual int GlyphsLength => int_0;

	public virtual RectangleF ActualBounds
	{
		get
		{
			RectangleF result = default(RectangleF);
			for (int i = 0; i < interface376_0.Length; i++)
			{
				RectangleF actualBounds = interface376_0[i].ActualBounds;
				if (result.IsEmpty)
				{
					result = actualBounds;
				}
				else
				{
					result.Inflate(actualBounds.Width, actualBounds.Height);
				}
			}
			return result;
		}
	}

	public virtual GraphicsPath Outline
	{
		get
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			for (int i = 0; i < interface376_0.Length; i++)
			{
				GraphicsPath outline = interface376_0[i].Outline;
				graphicsPath.AddPath(outline, connect: false);
			}
			return graphicsPath;
		}
	}

	public virtual RectangleF GeometricBounds
	{
		get
		{
			RectangleF result = default(RectangleF);
			for (int i = 0; i < interface376_0.Length; i++)
			{
				RectangleF geometricBounds = interface376_0[i].GeometricBounds;
				if (result.IsEmpty)
				{
					result = geometricBounds;
				}
				else
				{
					result.Inflate(geometricBounds.Width, geometricBounds.Height);
				}
			}
			return result;
		}
	}

	public virtual Interface375 Font => null;

	public Class7113(IList vectorList)
	{
		int count = vectorList.Count;
		interface376_0 = new Interface376[count];
		int_1 = new int[count];
		int_2 = new int[count];
		IEnumerator enumerator = vectorList.GetEnumerator();
		int num = 0;
		while (enumerator.MoveNext())
		{
			int_2[num] = int_0;
			Interface376 @interface = (Interface376)enumerator.Current;
			interface376_0[num] = @interface;
			int_1[num] = @interface.GlyphsLength;
			int_0 += int_1[num];
			num++;
		}
		if (num > 0)
		{
			int_1[num - 1]++;
		}
	}

	public virtual int imethod_3(int index)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			return interface376_0[num].imethod_3(index - int_2[num]);
		}
		return -1;
	}

	public virtual GraphicsPath imethod_0(int index)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			return interface376_0[num].imethod_0(index - int_2[num]);
		}
		return new GraphicsPath();
	}

	public virtual GraphicsPath imethod_1(int index)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			return interface376_0[num].imethod_1(index - int_2[num]);
		}
		return new GraphicsPath();
	}

	public virtual RectangleF imethod_2(int index)
	{
		return imethod_0(index).GetBounds();
	}

	public virtual PointF imethod_5(int index)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			return interface376_0[num].imethod_5(index - int_2[num]);
		}
		return default(PointF);
	}

	public virtual Matrix imethod_7(int index)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			return interface376_0[num].imethod_7(index - int_2[num]);
		}
		return new Matrix();
	}

	public virtual GraphicsPath imethod_8(int index)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			return interface376_0[num].imethod_8(index - int_2[num]);
		}
		return new GraphicsPath();
	}

	public virtual void imethod_9(int index, PointF position)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			interface376_0[num].imethod_9(index - int_2[num], position);
		}
	}

	public virtual void imethod_10(int index, Matrix transformation)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			interface376_0[num].imethod_10(index - int_2[num], transformation);
		}
	}

	public virtual void imethod_11(int index, bool visible)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			interface376_0[num].imethod_11(index - int_2[num], visible);
		}
	}

	public virtual bool imethod_12(int index)
	{
		int num = vmethod_0(index);
		if (num >= 0)
		{
			return interface376_0[num].imethod_12(index - int_2[num]);
		}
		return false;
	}

	public virtual int[] imethod_4(int start, int length, int[] result)
	{
		int[] array = result;
		if (array == null)
		{
			array = new int[length];
		}
		int[] array2 = null;
		int num = vmethod_0(start);
		int num2 = 0;
		if (num >= 0)
		{
			num2 = start - int_2[num];
		}
		int num3 = 0;
		if (num >= 0)
		{
			while (length != 0)
			{
				int num4 = length;
				if (num2 + num4 > int_1[num])
				{
					num4 = int_1[num] - num2;
				}
				Interface376 @interface = interface376_0[num];
				if (num3 == 0)
				{
					@interface.imethod_4(num2, num4, array);
				}
				else
				{
					if (array2 == null || array2.Length < num4)
					{
						array2 = new int[num4];
					}
					@interface.imethod_4(num2, num4, array2);
					Array.Copy(array2, 0, array, num3, num4);
				}
				num2 = 0;
				num++;
				length -= num4;
				num3 += num4;
			}
		}
		return array;
	}

	public virtual float[] imethod_6(int start, int lenght, float[] result)
	{
		float[] array = result;
		if (array == null)
		{
			array = new float[lenght * 2];
		}
		float[] array2 = null;
		int num = vmethod_0(start);
		int num2 = 0;
		if (num >= 0)
		{
			num2 = start - int_2[num];
		}
		int num3 = 0;
		if (num >= 0)
		{
			while (lenght != 0)
			{
				int num4 = lenght;
				if (num2 + num4 > int_1[num])
				{
					num4 = int_1[num] - num2;
				}
				Interface376 @interface = interface376_0[num];
				if (num3 == 0)
				{
					@interface.imethod_6(num2, num4, array);
				}
				else
				{
					if (array2 == null || array2.Length < num4 * 2)
					{
						array2 = new float[num4 * 2];
					}
					@interface.imethod_6(num2, num4, array2);
					Array.Copy(array2, 0, array, num3, num4 * 2);
				}
				num2 = 0;
				num++;
				lenght -= num4;
				num3 += num4 * 2;
			}
		}
		return array;
	}

	public virtual GraphicsPath imethod_13(float x, float y)
	{
		GraphicsPath outline = Outline;
		Matrix matrix = new Matrix();
		matrix.Translate(x, y);
		outline.Transform(matrix);
		return outline;
	}

	public virtual RectangleF imethod_14(Class7127 iterator)
	{
		RectangleF result = default(RectangleF);
		_ = iterator.BeginIndex;
		for (int i = 0; i < interface376_0.Length; i++)
		{
			Interface376 @interface = interface376_0[i];
			_ = @interface.GlyphsLength + 1;
			RectangleF rectangleF = interface376_0[i].imethod_14(new Class7127());
			if (result.Height <= 0f && result.Width <= 0f)
			{
				result = rectangleF;
			}
			else
			{
				result.Inflate(rectangleF.Width, rectangleF.Height);
			}
		}
		return result;
	}

	internal virtual int vmethod_0(int index)
	{
		if (index > int_0)
		{
			return -1;
		}
		if (index == int_0)
		{
			return interface376_0.Length - 1;
		}
		int num = 0;
		while (true)
		{
			if (num < int_1.Length)
			{
				if (index - int_2[num] < int_1[num])
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}
}
