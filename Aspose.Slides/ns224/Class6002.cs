using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns218;

namespace ns224;

internal class Class6002
{
	private const int int_0 = -1;

	public const int int_1 = 0;

	public const int int_2 = 1;

	public const int int_3 = 2;

	public const int int_4 = 4;

	public const int int_5 = 6;

	public const int int_6 = 64;

	public const int int_7 = 8;

	public const int int_8 = 16;

	public const int int_9 = 24;

	public const int int_10 = 32;

	private const int int_11 = 0;

	private const int int_12 = 1;

	private const int int_13 = 2;

	private const int int_14 = 4;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private int int_15;

	private int int_16;

	private static readonly int[] int_17 = new int[8] { 4, 5, 4, 5, 2, 3, 6, 7 };

	public bool IsIdentity
	{
		get
		{
			if (float_0 == 1f && float_1 == 0f && float_2 == 0f && float_3 == 1f && float_4 == 0f)
			{
				return float_5 == 0f;
			}
			return false;
		}
	}

	public float M11 => float_0;

	public float M12 => float_1;

	public float M21 => float_2;

	public float M22 => float_3;

	public float M31 => float_4;

	public float M32 => float_5;

	public Class6002()
	{
		float num = 1f;
		float_3 = 1f;
		float_0 = num;
	}

	public Class6002(float M11, float M12, float M21, float M22, float M31, float M32)
	{
		float_0 = M11;
		float_1 = M12;
		float_2 = M21;
		float_3 = M22;
		float_4 = M31;
		float_5 = M32;
		method_21();
	}

	public float[] method_0()
	{
		return new float[6] { float_0, float_1, float_2, float_3, float_4, float_5 };
	}

	public static bool smethod_0(Class6002 matrix)
	{
		if (!(matrix == null))
		{
			return matrix.IsIdentity;
		}
		return true;
	}

	public static Class6002 smethod_1(RectangleF from, RectangleF to)
	{
		Class6002 @class = new Class6002();
		float num = from.X + from.Width / 2f;
		float num2 = from.Y + from.Height / 2f;
		@class.method_8(0f - num, 0f - num2);
		float scaleX = to.Width / from.Width;
		float scaleY = to.Height / from.Height;
		@class.method_5(scaleX, scaleY, MatrixOrder.Append);
		float offsetX = to.X + to.Width / 2f;
		float offsetY = to.Y + to.Height / 2f;
		@class.method_7(offsetX, offsetY, MatrixOrder.Append);
		return @class;
	}

	public void method_1(PointF[] points, int startIndex, int numberOfPoints)
	{
		int num = int_15;
		int num2 = startIndex + numberOfPoints;
		if (num2 > points.Length)
		{
			num2 = points.Length;
		}
		for (int i = startIndex; i < num2; i++)
		{
			float x = points[i].X;
			float y = points[i].Y;
			switch (num)
			{
			default:
				smethod_2();
				break;
			case 1:
			{
				ref PointF reference7 = ref points[i];
				reference7 = new PointF(x + float_4, y + float_5);
				break;
			}
			case 2:
			{
				ref PointF reference6 = ref points[i];
				reference6 = new PointF(x * float_0, y * float_3);
				break;
			}
			case 3:
			{
				ref PointF reference5 = ref points[i];
				reference5 = new PointF(x * float_0 + float_4, y * float_3 + float_5);
				break;
			}
			case 4:
			{
				ref PointF reference4 = ref points[i];
				reference4 = new PointF(y * float_2, x * float_1);
				break;
			}
			case 5:
			{
				ref PointF reference3 = ref points[i];
				reference3 = new PointF(y * float_2 + float_4, x * float_1 + float_5);
				break;
			}
			case 6:
			{
				ref PointF reference2 = ref points[i];
				reference2 = new PointF(x * float_0 + y * float_2, x * float_1 + y * float_3);
				break;
			}
			case 7:
			{
				ref PointF reference = ref points[i];
				reference = new PointF(x * float_0 + y * float_2 + float_4, x * float_1 + y * float_3 + float_5);
				break;
			}
			case 0:
				break;
			}
		}
	}

	public PointF method_2(PointF point)
	{
		PointF result = new PointF(point.X, point.Y);
		int num = int_15;
		float x = result.X;
		float y = result.Y;
		switch (num)
		{
		default:
			smethod_2();
			break;
		case 1:
			result = new PointF(x + float_4, y + float_5);
			break;
		case 2:
			result = new PointF(x * float_0, y * float_3);
			break;
		case 3:
			result = new PointF(x * float_0 + float_4, y * float_3 + float_5);
			break;
		case 4:
			result = new PointF(y * float_2, x * float_1);
			break;
		case 5:
			result = new PointF(y * float_2 + float_4, x * float_1 + float_5);
			break;
		case 6:
			result = new PointF(x * float_0 + y * float_2, x * float_1 + y * float_3);
			break;
		case 7:
			result = new PointF(x * float_0 + y * float_2 + float_4, x * float_1 + y * float_3 + float_5);
			break;
		case 0:
			break;
		}
		return result;
	}

	public void method_3(PointF[] points)
	{
		method_1(points, 0, points.Length);
	}

	public RectangleF method_4(RectangleF rect)
	{
		PointF pointF = method_2(new PointF(rect.Left, rect.Top));
		PointF pointF2 = method_2(new PointF(rect.Right, rect.Bottom));
		return RectangleF.FromLTRB(pointF.X, pointF.Y, pointF2.X, pointF2.Y);
	}

	public void method_5(float scaleX, float scaleY, MatrixOrder order)
	{
		if (order == MatrixOrder.Prepend)
		{
			method_6(scaleX, scaleY);
			return;
		}
		if (int_15 == 1 || int_15 == 0)
		{
			int_15 |= 2;
		}
		if (((uint)int_15 & 4u) != 0)
		{
			float_2 *= scaleX;
			float_1 *= scaleY;
			if (((uint)int_15 & 2u) != 0)
			{
				float_0 *= scaleX;
				float_3 *= scaleY;
			}
		}
		else
		{
			float_0 *= scaleX;
			float_3 *= scaleY;
		}
		if (((uint)int_15 & (true ? 1u : 0u)) != 0)
		{
			float_4 *= scaleX;
			float_5 *= scaleY;
		}
		int_16 = -1;
	}

	public void method_6(float sx, float sy)
	{
		int num = int_15;
		if (((uint)num & 2u) != 0)
		{
			float_0 *= sx;
			float_3 *= sy;
		}
		switch (num)
		{
		default:
			smethod_2();
			break;
		case 0:
		case 1:
			float_0 = sx;
			float_3 = sy;
			if (sx != 1f || sy != 1f)
			{
				int_15 = num | 2;
				int_16 = -1;
			}
			break;
		case 2:
		case 3:
			if (float_0 == 1f && float_3 == 1f)
			{
				int_16 = (((int_15 = num & 1) != 0) ? 1 : 0);
			}
			else
			{
				int_16 = -1;
			}
			break;
		case 4:
		case 5:
		case 6:
		case 7:
			float_2 *= sy;
			float_1 *= sx;
			if (float_2 == 0f && float_1 == 0f)
			{
				num &= 1;
				if (float_0 == 1f && float_3 == 1f)
				{
					int_16 = ((num != 0) ? 1 : 0);
				}
				else
				{
					num |= 2;
					int_16 = -1;
				}
				int_15 = num;
			}
			break;
		}
	}

	public void method_7(float offsetX, float offsetY, MatrixOrder order)
	{
		if (order == MatrixOrder.Prepend)
		{
			method_8(offsetX, offsetY);
			return;
		}
		switch (int_15)
		{
		case 0:
		case 2:
		case 4:
		case 6:
			float_4 = offsetX;
			float_5 = offsetY;
			int_15 |= 1;
			int_16 |= 1;
			break;
		case 1:
		case 3:
		case 5:
		case 7:
			float_4 += offsetX;
			float_5 += offsetY;
			break;
		}
	}

	public void method_8(float tx, float ty)
	{
		switch (int_15)
		{
		default:
			smethod_2();
			break;
		case 0:
			float_4 = tx;
			float_5 = ty;
			if (tx != 0f || ty != 0f)
			{
				int_15 = 1;
				int_16 = 1;
			}
			break;
		case 1:
			float_4 = tx + float_4;
			float_5 = ty + float_5;
			if (float_4 == 0f && float_5 == 0f)
			{
				int_15 = 0;
				int_16 = 0;
			}
			break;
		case 2:
			float_4 = tx * float_0;
			float_5 = ty * float_3;
			if ((double)float_4 != 0.0 || (double)float_5 != 0.0)
			{
				int_15 = 3;
				int_16 |= 1;
			}
			break;
		case 3:
			float_4 = tx * float_0 + float_4;
			float_5 = ty * float_3 + float_5;
			if ((double)float_4 == 0.0 && (double)float_5 == 0.0)
			{
				int_15 = 2;
				if (int_16 != -1)
				{
					int_16--;
				}
			}
			break;
		case 4:
			float_4 = ty * float_2;
			float_5 = tx * float_1;
			if ((double)float_4 != 0.0 || (double)float_5 != 0.0)
			{
				int_15 = 5;
				int_16 |= 1;
			}
			break;
		case 5:
			float_4 = ty * float_2 + float_4;
			float_5 = tx * float_1 + float_5;
			if ((double)float_4 == 0.0 && (double)float_5 == 0.0)
			{
				int_15 = 4;
				if (int_16 != -1)
				{
					int_16--;
				}
			}
			break;
		case 6:
			float_4 = tx * float_0 + ty * float_2;
			float_5 = tx * float_1 + ty * float_3;
			if ((double)float_4 != 0.0 || (double)float_5 != 0.0)
			{
				int_15 = 7;
				int_16 |= 1;
			}
			break;
		case 7:
			float_4 = tx * float_0 + ty * float_2 + float_4;
			float_5 = tx * float_1 + ty * float_3 + float_5;
			if ((double)float_4 == 0.0 && (double)float_5 == 0.0)
			{
				int_15 = 6;
				if (int_16 != -1)
				{
					int_16--;
				}
			}
			break;
		}
	}

	public void method_9(Class6002 Tx, MatrixOrder order)
	{
		if (order == MatrixOrder.Prepend)
		{
			method_10(Tx);
			return;
		}
		int num = int_15;
		int num2 = Tx.int_15;
		float num6;
		float num3;
		float num4;
		float num7;
		switch (num2)
		{
		case 0:
			return;
		case 1:
			switch (num)
			{
			case 0:
			case 2:
			case 4:
			case 6:
				float_4 = Tx.float_4;
				float_5 = Tx.float_5;
				int_15 = num | 1;
				int_16 |= 1;
				break;
			case 1:
			case 3:
			case 5:
			case 7:
				float_4 += Tx.float_4;
				float_5 += Tx.float_5;
				break;
			}
			return;
		case 2:
			if (num == 1 || num == 0)
			{
				int_15 = num | 2;
			}
			num6 = Tx.float_0;
			num7 = Tx.float_3;
			if (((uint)num & 4u) != 0)
			{
				float_2 *= num6;
				float_1 *= num7;
				if (((uint)num & 2u) != 0)
				{
					float_0 *= num6;
					float_3 *= num7;
				}
			}
			else
			{
				float_0 *= num6;
				float_3 *= num7;
			}
			if (((uint)num & (true ? 1u : 0u)) != 0)
			{
				float_4 *= num6;
				float_5 *= num7;
			}
			int_16 = -1;
			return;
		case 4:
		{
			if (num == 5 || num == 4)
			{
				num |= 2;
				int_15 = num ^ 4;
			}
			if (num == 1 || num == 0 || num == 3 || num == 2)
			{
				int_15 = num ^ 4;
			}
			num3 = Tx.float_2;
			num4 = Tx.float_1;
			float num5 = float_0;
			float_0 = float_1 * num3;
			float_1 = num5 * num4;
			num5 = float_2;
			float_2 = float_3 * num3;
			float_3 = num5 * num4;
			num5 = float_4;
			float_4 = float_5 * num3;
			float_5 = num5 * num4;
			int_16 = -1;
			return;
		}
		}
		num6 = Tx.float_0;
		num3 = Tx.float_2;
		float num8 = Tx.float_4;
		num4 = Tx.float_1;
		num7 = Tx.float_3;
		float num9 = Tx.float_5;
		if (((uint)num & (true ? 1u : 0u)) != 0)
		{
			float num5 = float_4;
			float num10 = float_5;
			num8 = num8 + num5 * num6 + num10 * num3;
			num9 = num9 + num5 * num4 + num10 * num7;
		}
		switch (num)
		{
		default:
			smethod_2();
			break;
		case 0:
		case 1:
			float_4 = num8;
			float_5 = num9;
			float_0 = num6;
			float_1 = num4;
			float_2 = num3;
			float_3 = num7;
			int_15 = num | num2;
			int_16 = -1;
			return;
		case 2:
		case 3:
		{
			float_4 = num8;
			float_5 = num9;
			float num5 = float_0;
			float_0 = num5 * num6;
			float_1 = num5 * num4;
			num5 = float_3;
			float_2 = num5 * num3;
			float_3 = num5 * num7;
			break;
		}
		case 4:
		case 5:
		{
			float_4 = num8;
			float_5 = num9;
			float num5 = float_1;
			float_0 = num5 * num3;
			float_1 = num5 * num7;
			num5 = float_2;
			float_2 = num5 * num6;
			float_3 = num5 * num4;
			break;
		}
		case 6:
		case 7:
		{
			float_4 = num8;
			float_5 = num9;
			float num5 = float_0;
			float num10 = float_1;
			float_0 = num5 * num6 + num10 * num3;
			float_1 = num5 * num4 + num10 * num7;
			num5 = float_2;
			num10 = float_3;
			float_2 = num5 * num6 + num10 * num3;
			float_3 = num5 * num4 + num10 * num7;
			break;
		}
		}
		method_21();
	}

	public void method_10(Class6002 Tx)
	{
		int num = int_15;
		int num2 = Tx.int_15;
		if (num == 0)
		{
			if (((uint)num2 & 2u) != 0)
			{
				float_0 = Tx.float_0;
				float_3 = Tx.float_3;
			}
			if (((uint)num2 & 4u) != 0)
			{
				float_2 = Tx.float_2;
				float_1 = Tx.float_1;
			}
			if (((uint)num2 & (true ? 1u : 0u)) != 0)
			{
				float_4 = Tx.float_4;
				float_5 = Tx.float_5;
			}
			int_15 = num2;
			int_16 = Tx.int_16;
			return;
		}
		float num3;
		float num4;
		float num5;
		switch (num2)
		{
		case 0:
			return;
		case 1:
			method_8(Tx.float_4, Tx.float_5);
			return;
		case 2:
			method_6(Tx.float_0, Tx.float_3);
			return;
		case 4:
			switch (num)
			{
			case 1:
				float_0 = 0f;
				float_2 = Tx.float_2;
				float_1 = Tx.float_1;
				float_3 = 0f;
				int_15 = 5;
				int_16 = -1;
				return;
			case 2:
			case 3:
				float_2 = float_0 * Tx.float_2;
				float_0 = 0f;
				float_1 = float_3 * Tx.float_1;
				float_3 = 0f;
				int_15 = num ^ 6;
				int_16 = -1;
				return;
			case 4:
			case 5:
				float_0 = float_2 * Tx.float_1;
				float_2 = 0f;
				float_3 = float_1 * Tx.float_2;
				float_1 = 0f;
				int_15 = num ^ 6;
				int_16 = -1;
				return;
			case 6:
			case 7:
				num3 = Tx.float_2;
				num4 = Tx.float_1;
				num5 = float_0;
				float_0 = float_2 * num4;
				float_2 = num5 * num3;
				num5 = float_1;
				float_1 = float_3 * num4;
				float_3 = num5 * num3;
				int_16 = -1;
				return;
			}
			break;
		}
		float num6 = Tx.float_0;
		num3 = Tx.float_2;
		float num7 = Tx.float_4;
		num4 = Tx.float_1;
		float num8 = Tx.float_3;
		float num9 = Tx.float_5;
		switch (num)
		{
		default:
			smethod_2();
			goto IL_0255;
		case 1:
			float_0 = num6;
			float_2 = num3;
			float_4 += num7;
			float_1 = num4;
			float_3 = num8;
			float_5 += num9;
			int_15 = num2 | 1;
			int_16 = -1;
			return;
		case 2:
		case 3:
			num5 = float_0;
			float_0 = num6 * num5;
			float_2 = num3 * num5;
			float_4 += num7 * num5;
			num5 = float_3;
			float_1 = num4 * num5;
			float_3 = num8 * num5;
			float_5 += num9 * num5;
			goto IL_0255;
		case 4:
		case 5:
			num5 = float_2;
			float_0 = num4 * num5;
			float_2 = num8 * num5;
			float_4 += num9 * num5;
			num5 = float_1;
			float_1 = num6 * num5;
			float_3 = num3 * num5;
			float_5 += num7 * num5;
			goto IL_0255;
		case 6:
			int_15 = num | num2;
			break;
		case 7:
			break;
			IL_0255:
			method_21();
			return;
		}
		num5 = float_0;
		float num10 = float_2;
		float_0 = num6 * num5 + num4 * num10;
		float_2 = num3 * num5 + num8 * num10;
		float_4 = float_4 + num7 * num5 + num9 * num10;
		num5 = float_1;
		num10 = float_3;
		float_1 = num6 * num5 + num4 * num10;
		float_3 = num3 * num5 + num8 * num10;
		float_5 = float_5 + num7 * num5 + num9 * num10;
		int_16 = -1;
	}

	public void method_11(float angle, MatrixOrder order)
	{
		if (angle == 0f)
		{
			return;
		}
		if (order == MatrixOrder.Prepend)
		{
			method_12(angle);
		}
		else if (angle != 90f && angle != -270f)
		{
			if (angle != -90f && angle != 270f)
			{
				if (angle != 180f && angle != -180f)
				{
					double num = Class5963.smethod_0(angle);
					double num2 = Math.Sin(num);
					double num3 = Math.Cos(num);
					if (num3 != 1.0)
					{
						float num4 = float_0;
						float num5 = float_1;
						float_0 = (float)(num3 * (double)num4 - num2 * (double)num5);
						float_1 = (float)(num2 * (double)num4 + num3 * (double)num5);
						num4 = float_2;
						num5 = float_3;
						float_2 = (float)(num3 * (double)num4 - num2 * (double)num5);
						float_3 = (float)(num2 * (double)num4 + num3 * (double)num5);
						num4 = float_4;
						num5 = float_5;
						float_4 = (float)(num3 * (double)num4 - num2 * (double)num5);
						float_5 = (float)(num2 * (double)num4 + num3 * (double)num5);
						method_21();
					}
				}
				else
				{
					method_19();
				}
			}
			else
			{
				method_20();
			}
		}
		else
		{
			method_18();
		}
	}

	public void method_12(float angle)
	{
		if (angle == 0f)
		{
			return;
		}
		if (angle != 90f && angle != -270f)
		{
			if (angle != -90f && angle != 270f)
			{
				if (angle != 180f && angle != -180f)
				{
					double num = Class5963.smethod_0(angle);
					double num2 = Math.Sin(num);
					double num3 = Math.Cos(num);
					if (num3 != 1.0)
					{
						float num4 = float_0;
						float num5 = float_2;
						float_0 = (float)(num3 * (double)num4 + num2 * (double)num5);
						float_2 = (float)((0.0 - num2) * (double)num4 + num3 * (double)num5);
						num4 = float_1;
						num5 = float_3;
						float_1 = (float)(num3 * (double)num4 + num2 * (double)num5);
						float_3 = (float)((0.0 - num2) * (double)num4 + num3 * (double)num5);
						method_21();
					}
				}
				else
				{
					method_16();
				}
			}
			else
			{
				method_17();
			}
		}
		else
		{
			method_15();
		}
	}

	public void method_13(float angle, PointF point, MatrixOrder order)
	{
		if (order == MatrixOrder.Prepend)
		{
			method_14(angle, point);
			return;
		}
		method_7(0f - point.X, 0f - point.Y, MatrixOrder.Append);
		method_11(angle, MatrixOrder.Append);
		method_7(point.X, point.Y, MatrixOrder.Append);
	}

	public void method_14(float angle, PointF point)
	{
		method_8(point.X, point.Y);
		method_12(angle);
		method_8(0f - point.X, 0f - point.Y);
	}

	private void method_15()
	{
		float num = float_0;
		float_0 = float_2;
		float_2 = 0f - num;
		num = float_1;
		float_1 = float_3;
		float_3 = 0f - num;
		int num2 = int_17[int_15];
		if ((num2 & 6) == 2 && float_0 == 1f && float_3 == 1f)
		{
			num2 -= 2;
		}
		int_15 = num2;
		int_16 = -1;
	}

	private void method_16()
	{
		float_0 = 0f - float_0;
		float_3 = 0f - float_3;
		int num = int_15;
		if (((uint)num & 4u) != 0)
		{
			float_2 = 0f - float_2;
			float_1 = 0f - float_1;
		}
		else if (float_0 == 1f && float_3 == 1f)
		{
			int_15 = num & -3;
		}
		else
		{
			int_15 = num | 2;
		}
		int_16 = -1;
	}

	private void method_17()
	{
		float num = float_0;
		float_0 = 0f - float_2;
		float_2 = num;
		num = float_1;
		float_1 = 0f - float_3;
		float_3 = num;
		int num2 = int_17[int_15];
		if ((num2 & 6) == 2 && float_0 == 1f && float_3 == 1f)
		{
			num2 -= 2;
		}
		int_15 = num2;
		int_16 = -1;
	}

	private void method_18()
	{
		float num = float_0;
		float_0 = 0f - float_1;
		float_1 = num;
		num = float_2;
		float_2 = 0f - float_3;
		float_3 = num;
		num = float_4;
		float_4 = 0f - float_5;
		float_5 = num;
		method_21();
	}

	private void method_19()
	{
		float_0 = 0f - float_0;
		float_2 = 0f - float_2;
		float_1 = 0f - float_1;
		float_3 = 0f - float_3;
		float_4 = 0f - float_4;
		float_5 = 0f - float_5;
		method_21();
	}

	private void method_20()
	{
		float num = float_0;
		float_0 = float_1;
		float_1 = 0f - num;
		num = float_2;
		float_2 = float_3;
		float_3 = 0f - num;
		num = float_4;
		float_4 = float_5;
		float_5 = 0f - num;
		method_21();
	}

	public void Reset()
	{
		float num = 1f;
		float_3 = 1f;
		float_0 = num;
		float num2 = 0f;
		float_5 = 0f;
		float num3 = 0f;
		float_4 = num2;
		float num4 = 0f;
		float_2 = num3;
		float_1 = num4;
		int_15 = 0;
		int_16 = 0;
	}

	public Class6002 Clone()
	{
		Class6002 @class = new Class6002();
		@class.float_0 = float_0;
		@class.float_1 = float_1;
		@class.float_2 = float_2;
		@class.float_3 = float_3;
		@class.float_4 = float_4;
		@class.float_5 = float_5;
		@class.int_15 = int_15;
		@class.int_16 = int_16;
		return @class;
	}

	public override int GetHashCode()
	{
		long num = float_0.GetHashCode();
		num = num * 31L + float_2.GetHashCode();
		num = num * 31L + float_4.GetHashCode();
		num = num * 31L + float_1.GetHashCode();
		num = num * 31L + float_3.GetHashCode();
		num = num * 31L + float_5.GetHashCode();
		return (int)num ^ (int)(num >> 32);
	}

	public override bool Equals(object obj)
	{
		Class6002 @class = obj as Class6002;
		if (@class == null)
		{
			return false;
		}
		return Equals(this, @class);
	}

	public static bool Equals(Class6002 a, Class6002 b)
	{
		if (object.ReferenceEquals(a, b))
		{
			return true;
		}
		if (object.ReferenceEquals(null, a))
		{
			return false;
		}
		if (object.ReferenceEquals(null, b))
		{
			return false;
		}
		if (a.float_0 == b.float_0 && a.float_1 == b.float_1 && a.float_2 == b.float_2 && a.float_3 == b.float_3 && a.float_4 == b.float_4)
		{
			return a.float_5 == b.float_5;
		}
		return false;
	}

	public static bool operator ==(Class6002 a, Class6002 b)
	{
		return Equals(a, b);
	}

	public static bool operator !=(Class6002 a, Class6002 b)
	{
		return !Equals(a, b);
	}

	public override string ToString()
	{
		return $"{float_0}, {float_1}, {float_2}, {float_3}, {float_4}, {float_5}";
	}

	private void method_21()
	{
		if (float_2 == 0f && float_1 == 0f)
		{
			if (float_0 == 1f && float_3 == 1f)
			{
				if (float_4 == 0f && float_5 == 0f)
				{
					int_15 = 0;
					int_16 = 0;
				}
				else
				{
					int_15 = 1;
					int_16 = 1;
				}
			}
			else if (float_4 == 0f && float_5 == 0f)
			{
				int_15 = 2;
				int_16 = -1;
			}
			else
			{
				int_15 = 3;
				int_16 = -1;
			}
		}
		else if (float_0 == 0f && float_3 == 0f)
		{
			if (float_4 == 0f && float_5 == 0f)
			{
				int_15 = 4;
				int_16 = -1;
			}
			else
			{
				int_15 = 5;
				int_16 = -1;
			}
		}
		else if (float_4 == 0f && float_5 == 0f)
		{
			int_15 = 6;
			int_16 = -1;
		}
		else
		{
			int_15 = 7;
			int_16 = -1;
		}
	}

	private static void smethod_2()
	{
		throw new ExecutionEngineException("missing case in transform state switch");
	}
}
