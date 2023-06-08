using System;
using System.Collections;
using System.Drawing;

namespace ns161;

internal class Class4817
{
	private class Class4818 : IComparer
	{
		public int Compare(object x, object y)
		{
			int num = (int)x;
			int num2 = (int)y;
			if (num > num2)
			{
				return -1;
			}
			if (num < num2)
			{
				return 1;
			}
			return 0;
		}
	}

	private const int int_0 = 1;

	internal static float smethod_0(float value, float maxBound)
	{
		if (!(value > maxBound))
		{
			return value;
		}
		return maxBound;
	}

	internal static float smethod_1(float value, float minBound)
	{
		if (!(value < minBound))
		{
			return value;
		}
		return minBound;
	}

	internal static PointF smethod_2(RectangleF rect)
	{
		if (rect.IsEmpty)
		{
			throw new ArgumentNullException("Please report exception. Empty rectangle.");
		}
		return new PointF(rect.Location.X + rect.Width / 2f, rect.Location.Y + rect.Height / 2f);
	}

	internal static int[] smethod_3(float[] values)
	{
		int[] array = new int[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			array[i] = i;
		}
		Array.Sort(values, array, 0, values.Length);
		return array;
	}

	internal static void smethod_4(Graphics g, Pen pen, RectangleF rect)
	{
		g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
	}

	internal static bool smethod_5(Color c1, Color c2)
	{
		if (Math.Abs(c1.R - c2.R) < 1 && Math.Abs(c1.G - c2.G) < 1)
		{
			return Math.Abs(c1.B - c2.B) < 1;
		}
		return false;
	}

	internal static IComparer smethod_6()
	{
		return new Class4818();
	}
}
