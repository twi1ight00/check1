using System;
using System.Collections;
using System.Drawing;

namespace ns310;

internal abstract class Class7120 : Interface378
{
	internal const float float_0 = 3.5527137E-15f;

	internal const float float_1 = 1.4210855E-14f;

	private const int int_0 = 1000;

	private const float float_2 = 0.70710677f;

	private const float float_3 = 0.41421357f;

	public static int smethod_0(float pointFirst, float pointMid, float pointEnd, float[] start)
	{
		if (pointFirst == 0f)
		{
			return smethod_3(pointMid, pointEnd, start);
		}
		float num = pointMid * pointMid - 4f * pointFirst * pointEnd;
		if (Math.Abs(num) <= 1.4210855E-14f * pointMid * pointMid)
		{
			start[0] = (0f - pointMid) / (2f * pointFirst);
			return 1;
		}
		if (num < 0f)
		{
			return 0;
		}
		num = (float)Math.Sqrt(num);
		float num2 = 0f - (pointMid + smethod_1(num, pointMid));
		start[0] = 2f * pointEnd / num2;
		start[1] = num2 / (2f * pointFirst);
		return 2;
	}

	public static float smethod_1(float firstPoint, float secondPoint)
	{
		if (secondPoint < 0f)
		{
			if (!(firstPoint < 0f))
			{
				return 0f - firstPoint;
			}
			return firstPoint;
		}
		if (!(firstPoint > 0f))
		{
			return 0f - firstPoint;
		}
		return firstPoint;
	}

	public static int smethod_2(float pointFirst, float pointSecond, float pointMiddle, float pointEnd, float[] start)
	{
		float[] array = new float[2];
		float[] array2 = array;
		int num = smethod_0(3f * pointFirst, 2f * pointSecond, pointMiddle, array2);
		float[] array3 = new float[4];
		float[] array4 = array3;
		float[] array5 = new float[4];
		float[] array6 = array5;
		int num2 = 0;
		array4[0] = pointEnd;
		num2 = 1;
		array6[0] = 0f;
		switch (num)
		{
		case 1:
		{
			float num4 = array2[0];
			if (num4 > 0f && num4 < 1f)
			{
				array4[num2] = ((pointFirst * num4 + pointSecond) * num4 + pointMiddle) * num4 + pointEnd;
				array6[num2++] = num4;
			}
			break;
		}
		case 2:
		{
			if (array2[0] > array2[1])
			{
				float num3 = array2[0];
				array2[0] = array2[1];
				array2[1] = num3;
			}
			float num4 = array2[0];
			if (num4 > 0f && num4 < 1f)
			{
				array4[num2] = ((pointFirst * num4 + pointSecond) * num4 + pointMiddle) * num4 + pointEnd;
				array6[num2++] = num4;
			}
			num4 = array2[1];
			if (num4 > 0f && num4 < 1f)
			{
				array4[num2] = ((pointFirst * num4 + pointSecond) * num4 + pointMiddle) * num4 + pointEnd;
				array6[num2++] = num4;
			}
			break;
		}
		}
		array4[num2] = pointFirst + pointSecond + pointMiddle + pointEnd;
		array6[num2++] = 1f;
		int result = 0;
		for (int i = 0; i < num2 - 1; i++)
		{
			float num5 = array4[i];
			float num6 = array6[i];
			float num7 = array4[i + 1];
			float num8 = array6[i + 1];
			if ((num5 < 0f && num7 < 0f) || (num5 > 0f && num7 > 0f))
			{
				continue;
			}
			if (num5 > num7)
			{
				float num9 = num5;
				num5 = num7;
				num7 = num9;
				num9 = num6;
				num6 = num8;
				num8 = num9;
			}
			if (0f - num5 < 1.4210855E-14f * num7)
			{
				start[result++] = num6;
				continue;
			}
			if (num7 < -1.4210855E-14f * num5)
			{
				start[result++] = num8;
				i++;
				continue;
			}
			float num10 = 1.4210855E-14f * (num7 - num5);
			int j;
			for (j = 0; j < 20; j++)
			{
				float num11 = num8 - num6;
				float num12 = num7 - num5;
				float num13 = num6 + (float)((double)(Math.Abs(num5 / num12) * 99f) + 0.5) * num11 / 100f;
				float num14 = ((pointFirst * num13 + pointSecond) * num13 + pointMiddle) * num13 + pointEnd;
				if (Math.Abs(num14) >= num10)
				{
					if (num14 < 0f)
					{
						num6 = num13;
						num5 = num14;
					}
					else
					{
						num8 = num13;
						num7 = num14;
					}
					continue;
				}
				start[result++] = num13;
				break;
			}
			if (j == 20)
			{
				start[result++] = (num6 + num8) / 2f;
			}
		}
		return result;
	}

	public virtual Class7126 imethod_0(float pointY)
	{
		float[] array = new float[3];
		float[] array2 = array;
		int num = 0;
		Array.Sort(array2, 0, 0);
		float[] array3 = new float[2];
		int num2 = 0;
		num2 = 1;
		array3[0] = 0f;
		for (int i = 0; i < num; i++)
		{
			float num3 = array2[i];
			if (!((double)num3 <= 0.0))
			{
				if ((double)num3 >= 1.0)
				{
					break;
				}
				if (array3[num2 - 1] != num3)
				{
					array3[num2++] = num3;
				}
			}
		}
		array3[num2++] = 1f;
		return null;
	}

	public static int smethod_3(float pointFirst, float pointSecond, float[] start)
	{
		if (pointFirst == 0f)
		{
			if (pointSecond != 0f)
			{
				return 0;
			}
			start[0] = 0f;
			return 1;
		}
		start[0] = (0f - pointSecond) / pointFirst;
		return 1;
	}

	public static float[] smethod_4(float[] quadratic)
	{
		if (quadratic.Length != 6)
		{
			return new float[0];
		}
		return new float[8]
		{
			quadratic[0],
			quadratic[1],
			1f / 3f * quadratic[0] + 2f / 3f * quadratic[2],
			1f / 3f * quadratic[1] + 2f / 3f * quadratic[3],
			2f / 3f * quadratic[2] + 1f / 3f * quadratic[4],
			2f / 3f * quadratic[3] + 1f / 3f * quadratic[5],
			quadratic[4],
			quadratic[5]
		};
	}

	internal static PointF smethod_5(PointF aPoint, PointF bPoint, float ratio)
	{
		PointF result = default(PointF);
		result.X = aPoint.X + (bPoint.X - aPoint.X) * ratio;
		result.Y = aPoint.Y + (bPoint.Y - aPoint.Y) * ratio;
		return result;
	}

	public static PointF smethod_6(PointF a, PointF b, PointF c, PointF d, float ratio)
	{
		PointF pointF = default(PointF);
		PointF aPoint = smethod_5(a, b, ratio);
		PointF pointF2 = smethod_5(b, c, ratio);
		PointF bPoint = smethod_5(c, d, ratio);
		PointF aPoint2 = smethod_5(aPoint, pointF2, ratio);
		PointF bPoint2 = smethod_5(pointF2, bPoint, ratio);
		return smethod_5(aPoint2, bPoint2, ratio);
	}

	public static ArrayList smethod_7(float radius, float xPos, float yPos)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(smethod_4(new float[6]
		{
			xPos + radius,
			yPos,
			radius + xPos,
			-0.41421357f * radius + yPos,
			0.70710677f * radius + xPos,
			-0.70710677f * radius + yPos
		}));
		arrayList.Add(smethod_4(new float[6]
		{
			0.70710677f * radius + xPos,
			-0.70710677f * radius + yPos,
			0.41421357f * radius + xPos,
			0f - radius + yPos,
			xPos,
			0f - radius + yPos
		}));
		arrayList.Add(smethod_4(new float[6]
		{
			xPos,
			0f - radius + yPos,
			-0.41421357f * radius + xPos,
			0f - radius + yPos,
			-0.70710677f * radius + xPos,
			-0.70710677f * radius + yPos
		}));
		arrayList.Add(smethod_4(new float[6]
		{
			-0.70710677f * radius + xPos,
			-0.70710677f * radius + yPos,
			0f - radius + xPos,
			-0.41421357f * radius + yPos,
			0f - radius + xPos,
			yPos
		}));
		arrayList.Add(smethod_4(new float[6]
		{
			0f - radius + xPos,
			yPos,
			0f - radius + xPos,
			0.41421357f * radius + yPos,
			-0.70710677f * radius + xPos,
			0.70710677f * radius + yPos
		}));
		arrayList.Add(smethod_4(new float[6]
		{
			-0.70710677f * radius + xPos,
			0.70710677f * radius + yPos,
			-0.41421357f * radius + xPos,
			radius + yPos,
			xPos,
			radius + yPos
		}));
		arrayList.Add(smethod_4(new float[6]
		{
			xPos,
			radius + yPos,
			0.41421357f * radius + xPos,
			radius + yPos,
			0.70710677f * radius + xPos,
			0.70710677f * radius + yPos
		}));
		arrayList.Add(smethod_4(new float[6]
		{
			0.70710677f * radius + xPos,
			0.70710677f * radius + yPos,
			radius + xPos,
			0.41421357f * radius + yPos,
			radius + xPos,
			yPos
		}));
		return arrayList;
	}

	internal static float smethod_8(float startPos, float endPos, float partSize)
	{
		if (!(partSize < 0f) && partSize <= 1f)
		{
			if (startPos > endPos)
			{
				return endPos + (startPos - endPos) * (1f - partSize);
			}
			return startPos + (endPos - startPos) * partSize;
		}
		return 0f;
	}

	public static float[] smethod_9(float[] curve, float splitPoint, bool firstPart)
	{
		if (curve.Length == 8 && !(splitPoint < 0f) && splitPoint <= 1f)
		{
			float num = curve[0];
			float num2 = curve[1];
			float num3 = curve[2];
			float num4 = curve[3];
			float num5 = curve[4];
			float num6 = curve[5];
			float num7 = curve[6];
			float num8 = curve[7];
			float num9 = smethod_8(num, num3, splitPoint);
			float num10 = smethod_8(num4, num2, 1f - splitPoint);
			float num11 = smethod_8(num3, num5, splitPoint);
			float num12 = smethod_8(num6, num4, 1f - splitPoint);
			float num13 = smethod_8(num9, num11, splitPoint);
			float num14 = smethod_8(num12, num10, 1f - splitPoint);
			float num15 = smethod_8(num5, num7, splitPoint);
			float num16 = smethod_8(num8, num6, 1f - splitPoint);
			float num17 = smethod_8(num11, num15, splitPoint);
			float num18 = smethod_8(num16, num12, 1f - splitPoint);
			float num19 = smethod_8(num13, num17, splitPoint);
			float num20 = smethod_8(num18, num14, 1f - splitPoint);
			if (firstPart)
			{
				return new float[8] { num, num2, num9, num10, num13, num14, num19, num20 };
			}
			return new float[8] { num19, num20, num17, num18, num15, num16, num7, num8 };
		}
		return new float[8];
	}

	public static ArrayList smethod_10(float left, float bottom, float width, float height)
	{
		float num = left + width / 2f;
		float num2 = bottom + height / 2f;
		float num3 = width / 2f;
		float num4 = height / 2f;
		float num5 = 0.5522848f;
		float num6 = num3 * num5;
		float num7 = num4 * num5;
		float num8 = num + num3;
		float num9 = num2 + num4;
		ArrayList arrayList = new ArrayList();
		arrayList.Add(new float[8]
		{
			num - num3,
			num2,
			num - num3,
			num2 - num7,
			num - num6,
			num2 - num4,
			num,
			num2 - num4
		});
		arrayList.Add(new float[8]
		{
			num,
			num2 - num4,
			num + num6,
			num2 - num4,
			num8,
			num2 - num7,
			num8,
			num2
		});
		arrayList.Add(new float[8]
		{
			num8,
			num2,
			num8,
			num2 + num7,
			num + num6,
			num9,
			num,
			num9
		});
		arrayList.Add(new float[8]
		{
			num,
			num9,
			num - num6,
			num9,
			num - num3,
			num2 + num7,
			num - num3,
			num2
		});
		return arrayList;
	}

	internal static PointF smethod_11(PointF controlPoint, PointF sourcePoint, float angle)
	{
		double num = Math.Abs(controlPoint.X - sourcePoint.X);
		double num2 = Math.Abs(controlPoint.Y - sourcePoint.Y);
		double num3 = Math.Atan(num2 / num) * 180.0 / Math.PI;
		double num4 = Math.Sqrt(Math.Pow(Convert.ToDouble(controlPoint.X - sourcePoint.X), 2.0) + Math.Pow(Convert.ToDouble(controlPoint.Y - sourcePoint.Y), 2.0));
		double num5 = num4 * Math.Cos((num3 + (double)angle) * Math.PI / 180.0);
		double num6 = num4 * Math.Sin((num3 + (double)angle) * Math.PI / 180.0);
		return new PointF((float)num5, (float)num6);
	}
}
