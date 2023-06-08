using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using x6c95d9cf46ff5f25;

namespace x5794c252ba25e723;

internal class x54366fa5f75a02f7
{
	private const int x508b8787029b09a6 = -1;

	public const int x264ad896de2ae8c6 = 0;

	public const int x35241d2f8874eb07 = 1;

	public const int x7c61a3eaa14cc1bc = 2;

	public const int x920584ccbe3a29f2 = 4;

	public const int x5f727627e524ea79 = 6;

	public const int x6a4fe81f81939b39 = 64;

	public const int x6f03d3d7b3dc9693 = 8;

	public const int x9cfa02b4906c8248 = 16;

	public const int xe7d6806a915a48d4 = 24;

	public const int x622ec9ba23d6bc8c = 32;

	private const int x41a5291e549fbf37 = 0;

	private const int x0a8b7f06ae09a22c = 1;

	private const int x69d1b0423ea829bd = 2;

	private const int xb207ae97f1e7e2e6 = 4;

	private float x8e1e5d7ac41c148a;

	private float xfc7a054ab2ab7fb7;

	private float x1ba1feec87cdb33c;

	private float x011388a63eb09115;

	private float xbbda52e1bda14713;

	private float x2fb6ade0109b8efa;

	private int x9b529da35d1032aa;

	private int xf263b01e2956834c;

	private static readonly int[] xdb826f07eecf6ce8 = new int[8] { 4, 5, 4, 5, 2, 3, 6, 7 };

	public bool xc245ff41684c03b8
	{
		get
		{
			if (x8e1e5d7ac41c148a == 1f && xfc7a054ab2ab7fb7 == 0f && x1ba1feec87cdb33c == 0f && x011388a63eb09115 == 1f && xbbda52e1bda14713 == 0f)
			{
				return x2fb6ade0109b8efa == 0f;
			}
			return false;
		}
	}

	public double x3122d79fa5906409 => x8e1e5d7ac41c148a * x011388a63eb09115 - x1ba1feec87cdb33c * xfc7a054ab2ab7fb7;

	public float xb4f54e8f080ddae5 => x8e1e5d7ac41c148a;

	public float xdde8182ef4f9942b => xfc7a054ab2ab7fb7;

	public float xa71255917a9143ca => x1ba1feec87cdb33c;

	public float xcd7062a84a8f3162 => x011388a63eb09115;

	public float x35fa2f38e277fdee => xbbda52e1bda14713;

	public float x93f6f49bd53e2628 => x2fb6ade0109b8efa;

	public x54366fa5f75a02f7()
	{
		x8e1e5d7ac41c148a = (x011388a63eb09115 = 1f);
	}

	public x54366fa5f75a02f7(float M11, float M12, float M21, float M22, float M31, float M32)
	{
		x8e1e5d7ac41c148a = M11;
		xfc7a054ab2ab7fb7 = M12;
		x1ba1feec87cdb33c = M21;
		x011388a63eb09115 = M22;
		xbbda52e1bda14713 = M31;
		x2fb6ade0109b8efa = M32;
		x3da203c4ca1dec38();
	}

	public float[] x615b20ca96b61e88()
	{
		return new float[6] { x8e1e5d7ac41c148a, xfc7a054ab2ab7fb7, x1ba1feec87cdb33c, x011388a63eb09115, xbbda52e1bda14713, x2fb6ade0109b8efa };
	}

	public static bool x704ca7f31e9f093b(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		if (!(xa801ccff44b0c7eb == null))
		{
			return xa801ccff44b0c7eb.xc245ff41684c03b8;
		}
		return true;
	}

	public static x54366fa5f75a02f7 x6698fc0971e66ffb(RectangleF x7f8a886f51b477eb, RectangleF x3ed4f4f0195b98d7)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f8 = new x54366fa5f75a02f7();
		float num = x7f8a886f51b477eb.X + x7f8a886f51b477eb.Width / 2f;
		float num2 = x7f8a886f51b477eb.Y + x7f8a886f51b477eb.Height / 2f;
		x54366fa5f75a02f8.xce92de628aa023cf(0f - num, 0f - num2);
		float xb5c369f64ea369e = x3ed4f4f0195b98d7.Width / x7f8a886f51b477eb.Width;
		float x9b8af180a4e21ec = x3ed4f4f0195b98d7.Height / x7f8a886f51b477eb.Height;
		x54366fa5f75a02f8.x5152a5707921c783(xb5c369f64ea369e, x9b8af180a4e21ec, MatrixOrder.Append);
		float x3758cf4ee715d = x3ed4f4f0195b98d7.X + x3ed4f4f0195b98d7.Width / 2f;
		float x6842879318972d9e = x3ed4f4f0195b98d7.Y + x3ed4f4f0195b98d7.Height / 2f;
		x54366fa5f75a02f8.xce92de628aa023cf(x3758cf4ee715d, x6842879318972d9e, MatrixOrder.Append);
		return x54366fa5f75a02f8;
	}

	public static x54366fa5f75a02f7 xed1284b895d73140(RectangleF x0d1d762ec380db87, PointF[] xe5be0219e97bc6c9)
	{
		if (xe5be0219e97bc6c9 == null)
		{
			throw new ArgumentNullException("dstParallelogram");
		}
		if (xe5be0219e97bc6c9.Length != 3)
		{
			throw new ArgumentException("Parallelogram points array should contain 3 points.");
		}
		PointF pointF = xe5be0219e97bc6c9[0];
		PointF pointF2 = xe5be0219e97bc6c9[1];
		PointF pointF3 = xe5be0219e97bc6c9[2];
		float num = (pointF2.X - pointF.X) / x0d1d762ec380db87.Width;
		float num2 = (pointF2.Y - pointF.Y) / x0d1d762ec380db87.Width;
		float num3 = (pointF3.X - pointF.X) / x0d1d762ec380db87.Height;
		float num4 = (pointF3.Y - pointF.Y) / x0d1d762ec380db87.Height;
		float m = pointF.X - (num * x0d1d762ec380db87.Left + num3 * x0d1d762ec380db87.Top);
		float m2 = pointF.Y - (num2 * x0d1d762ec380db87.Left + num4 * x0d1d762ec380db87.Top);
		return new x54366fa5f75a02f7(num, num2, num3, num4, m, m2);
	}

	public void xa4b699bd47eb7372(PointF[] x6fa2570084b2ad39, int xd4f974c06ffa392b, int x9e0157add3830c36)
	{
		int num = xd4f974c06ffa392b + x9e0157add3830c36;
		if (num > x6fa2570084b2ad39.Length)
		{
			num = x6fa2570084b2ad39.Length;
		}
		for (int i = xd4f974c06ffa392b; i < num; i++)
		{
			ref PointF reference = ref x6fa2570084b2ad39[i];
			reference = x5c785f1d561da269(x6fa2570084b2ad39[i]);
		}
	}

	public PointF x5c785f1d561da269(PointF x2f7096dac971d6ec)
	{
		PointF result = new PointF(x2f7096dac971d6ec.X, x2f7096dac971d6ec.Y);
		int num = x9b529da35d1032aa;
		float x = result.X;
		float y = result.Y;
		switch (num)
		{
		case 7:
			result = new PointF(x * x8e1e5d7ac41c148a + y * x1ba1feec87cdb33c + xbbda52e1bda14713, x * xfc7a054ab2ab7fb7 + y * x011388a63eb09115 + x2fb6ade0109b8efa);
			break;
		case 6:
			result = new PointF(x * x8e1e5d7ac41c148a + y * x1ba1feec87cdb33c, x * xfc7a054ab2ab7fb7 + y * x011388a63eb09115);
			break;
		case 5:
			result = new PointF(y * x1ba1feec87cdb33c + xbbda52e1bda14713, x * xfc7a054ab2ab7fb7 + x2fb6ade0109b8efa);
			break;
		case 4:
			result = new PointF(y * x1ba1feec87cdb33c, x * xfc7a054ab2ab7fb7);
			break;
		case 3:
			result = new PointF(x * x8e1e5d7ac41c148a + xbbda52e1bda14713, y * x011388a63eb09115 + x2fb6ade0109b8efa);
			break;
		case 2:
			result = new PointF(x * x8e1e5d7ac41c148a, y * x011388a63eb09115);
			break;
		case 1:
			result = new PointF(x + xbbda52e1bda14713, y + x2fb6ade0109b8efa);
			break;
		default:
			x938f936af1a8b91c();
			break;
		case 0:
			break;
		}
		return result;
	}

	public void xa4b699bd47eb7372(PointF[] x6fa2570084b2ad39)
	{
		xa4b699bd47eb7372(x6fa2570084b2ad39, 0, x6fa2570084b2ad39.Length);
	}

	public x54366fa5f75a02f7 x437786253537a519()
	{
		double num = x3122d79fa5906409;
		if (num == 0.0)
		{
			throw new InvalidOperationException("Can't invert transform");
		}
		double num2 = (double)x011388a63eb09115 / num;
		double num3 = (double)(0f - xfc7a054ab2ab7fb7) / num;
		double num4 = (double)(0f - x1ba1feec87cdb33c) / num;
		double num5 = (double)x8e1e5d7ac41c148a / num;
		double num6 = (double)(x1ba1feec87cdb33c * x2fb6ade0109b8efa - xbbda52e1bda14713 * x011388a63eb09115) / num;
		double num7 = (double)((0f - x8e1e5d7ac41c148a) * x2fb6ade0109b8efa + xfc7a054ab2ab7fb7 * xbbda52e1bda14713) / num;
		return new x54366fa5f75a02f7((float)num2, (float)num3, (float)num4, (float)num5, (float)num6, (float)num7);
	}

	public RectangleF xaccac17571a8d9fa(RectangleF x26545669838eb36e)
	{
		PointF pointF = x5c785f1d561da269(new PointF(x26545669838eb36e.Left, x26545669838eb36e.Top));
		PointF pointF2 = x5c785f1d561da269(new PointF(x26545669838eb36e.Right, x26545669838eb36e.Bottom));
		return RectangleF.FromLTRB(pointF.X, pointF.Y, pointF2.X, pointF2.Y);
	}

	public void x5152a5707921c783(float xb5c369f64ea369e5, float x9b8af180a4e21ec1, MatrixOrder x7bc95a6c91d75cef)
	{
		if (x7bc95a6c91d75cef == MatrixOrder.Prepend)
		{
			x5152a5707921c783(xb5c369f64ea369e5, x9b8af180a4e21ec1);
			return;
		}
		if (x9b529da35d1032aa == 1 || x9b529da35d1032aa == 0)
		{
			x9b529da35d1032aa |= 2;
		}
		if (((uint)x9b529da35d1032aa & 4u) != 0)
		{
			x1ba1feec87cdb33c *= xb5c369f64ea369e5;
			xfc7a054ab2ab7fb7 *= x9b8af180a4e21ec1;
			if (((uint)x9b529da35d1032aa & 2u) != 0)
			{
				x8e1e5d7ac41c148a *= xb5c369f64ea369e5;
				x011388a63eb09115 *= x9b8af180a4e21ec1;
			}
		}
		else
		{
			x8e1e5d7ac41c148a *= xb5c369f64ea369e5;
			x011388a63eb09115 *= x9b8af180a4e21ec1;
		}
		if (((uint)x9b529da35d1032aa & (true ? 1u : 0u)) != 0)
		{
			xbbda52e1bda14713 *= xb5c369f64ea369e5;
			x2fb6ade0109b8efa *= x9b8af180a4e21ec1;
		}
		xf263b01e2956834c = -1;
	}

	public void x5152a5707921c783(float xbcdf0fa27ad63184, float x1e0724360f9c6587)
	{
		int num = x9b529da35d1032aa;
		if (((uint)num & 2u) != 0)
		{
			x8e1e5d7ac41c148a *= xbcdf0fa27ad63184;
			x011388a63eb09115 *= x1e0724360f9c6587;
		}
		switch (num)
		{
		case 4:
		case 5:
		case 6:
		case 7:
			x1ba1feec87cdb33c *= x1e0724360f9c6587;
			xfc7a054ab2ab7fb7 *= xbcdf0fa27ad63184;
			if (x1ba1feec87cdb33c == 0f && xfc7a054ab2ab7fb7 == 0f)
			{
				num &= 1;
				if (x8e1e5d7ac41c148a == 1f && x011388a63eb09115 == 1f)
				{
					xf263b01e2956834c = ((num != 0) ? 1 : 0);
				}
				else
				{
					num |= 2;
					xf263b01e2956834c = -1;
				}
				x9b529da35d1032aa = num;
			}
			break;
		case 2:
		case 3:
			if (x8e1e5d7ac41c148a == 1f && x011388a63eb09115 == 1f)
			{
				xf263b01e2956834c = (((x9b529da35d1032aa = num & 1) != 0) ? 1 : 0);
			}
			else
			{
				xf263b01e2956834c = -1;
			}
			break;
		case 0:
		case 1:
			x8e1e5d7ac41c148a = xbcdf0fa27ad63184;
			x011388a63eb09115 = x1e0724360f9c6587;
			if (xbcdf0fa27ad63184 != 1f || x1e0724360f9c6587 != 1f)
			{
				x9b529da35d1032aa = num | 2;
				xf263b01e2956834c = -1;
			}
			break;
		default:
			x938f936af1a8b91c();
			break;
		}
	}

	public void xce92de628aa023cf(float x3758cf4ee715d797, float x6842879318972d9e, MatrixOrder x7bc95a6c91d75cef)
	{
		if (x7bc95a6c91d75cef == MatrixOrder.Prepend)
		{
			xce92de628aa023cf(x3758cf4ee715d797, x6842879318972d9e);
			return;
		}
		switch (x9b529da35d1032aa)
		{
		case 0:
		case 2:
		case 4:
		case 6:
			xbbda52e1bda14713 = x3758cf4ee715d797;
			x2fb6ade0109b8efa = x6842879318972d9e;
			x9b529da35d1032aa |= 1;
			xf263b01e2956834c |= 1;
			break;
		case 1:
		case 3:
		case 5:
		case 7:
			xbbda52e1bda14713 += x3758cf4ee715d797;
			x2fb6ade0109b8efa += x6842879318972d9e;
			break;
		}
	}

	public void xce92de628aa023cf(float x0e0da4ab3344491a, float xc606b8e75847f7ba)
	{
		switch (x9b529da35d1032aa)
		{
		case 7:
			xbbda52e1bda14713 = x0e0da4ab3344491a * x8e1e5d7ac41c148a + xc606b8e75847f7ba * x1ba1feec87cdb33c + xbbda52e1bda14713;
			x2fb6ade0109b8efa = x0e0da4ab3344491a * xfc7a054ab2ab7fb7 + xc606b8e75847f7ba * x011388a63eb09115 + x2fb6ade0109b8efa;
			if ((double)xbbda52e1bda14713 == 0.0 && (double)x2fb6ade0109b8efa == 0.0)
			{
				x9b529da35d1032aa = 6;
				if (xf263b01e2956834c != -1)
				{
					xf263b01e2956834c--;
				}
			}
			break;
		case 6:
			xbbda52e1bda14713 = x0e0da4ab3344491a * x8e1e5d7ac41c148a + xc606b8e75847f7ba * x1ba1feec87cdb33c;
			x2fb6ade0109b8efa = x0e0da4ab3344491a * xfc7a054ab2ab7fb7 + xc606b8e75847f7ba * x011388a63eb09115;
			if ((double)xbbda52e1bda14713 != 0.0 || (double)x2fb6ade0109b8efa != 0.0)
			{
				x9b529da35d1032aa = 7;
				xf263b01e2956834c |= 1;
			}
			break;
		case 5:
			xbbda52e1bda14713 = xc606b8e75847f7ba * x1ba1feec87cdb33c + xbbda52e1bda14713;
			x2fb6ade0109b8efa = x0e0da4ab3344491a * xfc7a054ab2ab7fb7 + x2fb6ade0109b8efa;
			if ((double)xbbda52e1bda14713 == 0.0 && (double)x2fb6ade0109b8efa == 0.0)
			{
				x9b529da35d1032aa = 4;
				if (xf263b01e2956834c != -1)
				{
					xf263b01e2956834c--;
				}
			}
			break;
		case 4:
			xbbda52e1bda14713 = xc606b8e75847f7ba * x1ba1feec87cdb33c;
			x2fb6ade0109b8efa = x0e0da4ab3344491a * xfc7a054ab2ab7fb7;
			if ((double)xbbda52e1bda14713 != 0.0 || (double)x2fb6ade0109b8efa != 0.0)
			{
				x9b529da35d1032aa = 5;
				xf263b01e2956834c |= 1;
			}
			break;
		case 3:
			xbbda52e1bda14713 = x0e0da4ab3344491a * x8e1e5d7ac41c148a + xbbda52e1bda14713;
			x2fb6ade0109b8efa = xc606b8e75847f7ba * x011388a63eb09115 + x2fb6ade0109b8efa;
			if ((double)xbbda52e1bda14713 == 0.0 && (double)x2fb6ade0109b8efa == 0.0)
			{
				x9b529da35d1032aa = 2;
				if (xf263b01e2956834c != -1)
				{
					xf263b01e2956834c--;
				}
			}
			break;
		case 2:
			xbbda52e1bda14713 = x0e0da4ab3344491a * x8e1e5d7ac41c148a;
			x2fb6ade0109b8efa = xc606b8e75847f7ba * x011388a63eb09115;
			if ((double)xbbda52e1bda14713 != 0.0 || (double)x2fb6ade0109b8efa != 0.0)
			{
				x9b529da35d1032aa = 3;
				xf263b01e2956834c |= 1;
			}
			break;
		case 1:
			xbbda52e1bda14713 = x0e0da4ab3344491a + xbbda52e1bda14713;
			x2fb6ade0109b8efa = xc606b8e75847f7ba + x2fb6ade0109b8efa;
			if (xbbda52e1bda14713 == 0f && x2fb6ade0109b8efa == 0f)
			{
				x9b529da35d1032aa = 0;
				xf263b01e2956834c = 0;
			}
			break;
		case 0:
			xbbda52e1bda14713 = x0e0da4ab3344491a;
			x2fb6ade0109b8efa = xc606b8e75847f7ba;
			if (x0e0da4ab3344491a != 0f || xc606b8e75847f7ba != 0f)
			{
				x9b529da35d1032aa = 1;
				xf263b01e2956834c = 1;
			}
			break;
		default:
			x938f936af1a8b91c();
			break;
		}
	}

	public void x490e30087768649f(x54366fa5f75a02f7 x470ecea91abfd1aa, MatrixOrder x7bc95a6c91d75cef)
	{
		if (x7bc95a6c91d75cef == MatrixOrder.Prepend)
		{
			x490e30087768649f(x470ecea91abfd1aa);
			return;
		}
		int num = x9b529da35d1032aa;
		int num2 = x470ecea91abfd1aa.x9b529da35d1032aa;
		float num3;
		float num5;
		float num6;
		float num4;
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
				xbbda52e1bda14713 = x470ecea91abfd1aa.xbbda52e1bda14713;
				x2fb6ade0109b8efa = x470ecea91abfd1aa.x2fb6ade0109b8efa;
				x9b529da35d1032aa = num | 1;
				xf263b01e2956834c |= 1;
				break;
			case 1:
			case 3:
			case 5:
			case 7:
				xbbda52e1bda14713 += x470ecea91abfd1aa.xbbda52e1bda14713;
				x2fb6ade0109b8efa += x470ecea91abfd1aa.x2fb6ade0109b8efa;
				break;
			}
			return;
		case 2:
			if (num == 1 || num == 0)
			{
				x9b529da35d1032aa = num | 2;
			}
			num3 = x470ecea91abfd1aa.x8e1e5d7ac41c148a;
			num4 = x470ecea91abfd1aa.x011388a63eb09115;
			if (((uint)num & 4u) != 0)
			{
				x1ba1feec87cdb33c *= num3;
				xfc7a054ab2ab7fb7 *= num4;
				if (((uint)num & 2u) != 0)
				{
					x8e1e5d7ac41c148a *= num3;
					x011388a63eb09115 *= num4;
				}
			}
			else
			{
				x8e1e5d7ac41c148a *= num3;
				x011388a63eb09115 *= num4;
			}
			if (((uint)num & (true ? 1u : 0u)) != 0)
			{
				xbbda52e1bda14713 *= num3;
				x2fb6ade0109b8efa *= num4;
			}
			xf263b01e2956834c = -1;
			return;
		case 4:
		{
			if (num == 5 || num == 4)
			{
				num |= 2;
				x9b529da35d1032aa = num ^ 4;
			}
			if (num == 1 || num == 0 || num == 3 || num == 2)
			{
				x9b529da35d1032aa = num ^ 4;
			}
			num5 = x470ecea91abfd1aa.x1ba1feec87cdb33c;
			num6 = x470ecea91abfd1aa.xfc7a054ab2ab7fb7;
			float num7 = x8e1e5d7ac41c148a;
			x8e1e5d7ac41c148a = xfc7a054ab2ab7fb7 * num5;
			xfc7a054ab2ab7fb7 = num7 * num6;
			num7 = x1ba1feec87cdb33c;
			x1ba1feec87cdb33c = x011388a63eb09115 * num5;
			x011388a63eb09115 = num7 * num6;
			num7 = xbbda52e1bda14713;
			xbbda52e1bda14713 = x2fb6ade0109b8efa * num5;
			x2fb6ade0109b8efa = num7 * num6;
			xf263b01e2956834c = -1;
			return;
		}
		}
		num3 = x470ecea91abfd1aa.x8e1e5d7ac41c148a;
		num5 = x470ecea91abfd1aa.x1ba1feec87cdb33c;
		float num8 = x470ecea91abfd1aa.xbbda52e1bda14713;
		num6 = x470ecea91abfd1aa.xfc7a054ab2ab7fb7;
		num4 = x470ecea91abfd1aa.x011388a63eb09115;
		float num9 = x470ecea91abfd1aa.x2fb6ade0109b8efa;
		if (((uint)num & (true ? 1u : 0u)) != 0)
		{
			float num7 = xbbda52e1bda14713;
			float num10 = x2fb6ade0109b8efa;
			num8 = num8 + num7 * num3 + num10 * num5;
			num9 = num9 + num7 * num6 + num10 * num4;
		}
		switch (num)
		{
		case 6:
		case 7:
		{
			xbbda52e1bda14713 = num8;
			x2fb6ade0109b8efa = num9;
			float num7 = x8e1e5d7ac41c148a;
			float num10 = xfc7a054ab2ab7fb7;
			x8e1e5d7ac41c148a = num7 * num3 + num10 * num5;
			xfc7a054ab2ab7fb7 = num7 * num6 + num10 * num4;
			num7 = x1ba1feec87cdb33c;
			num10 = x011388a63eb09115;
			x1ba1feec87cdb33c = num7 * num3 + num10 * num5;
			x011388a63eb09115 = num7 * num6 + num10 * num4;
			break;
		}
		case 4:
		case 5:
		{
			xbbda52e1bda14713 = num8;
			x2fb6ade0109b8efa = num9;
			float num7 = xfc7a054ab2ab7fb7;
			x8e1e5d7ac41c148a = num7 * num5;
			xfc7a054ab2ab7fb7 = num7 * num4;
			num7 = x1ba1feec87cdb33c;
			x1ba1feec87cdb33c = num7 * num3;
			x011388a63eb09115 = num7 * num6;
			break;
		}
		case 2:
		case 3:
		{
			xbbda52e1bda14713 = num8;
			x2fb6ade0109b8efa = num9;
			float num7 = x8e1e5d7ac41c148a;
			x8e1e5d7ac41c148a = num7 * num3;
			xfc7a054ab2ab7fb7 = num7 * num6;
			num7 = x011388a63eb09115;
			x1ba1feec87cdb33c = num7 * num5;
			x011388a63eb09115 = num7 * num4;
			break;
		}
		case 0:
		case 1:
			xbbda52e1bda14713 = num8;
			x2fb6ade0109b8efa = num9;
			x8e1e5d7ac41c148a = num3;
			xfc7a054ab2ab7fb7 = num6;
			x1ba1feec87cdb33c = num5;
			x011388a63eb09115 = num4;
			x9b529da35d1032aa = num | num2;
			xf263b01e2956834c = -1;
			return;
		default:
			x938f936af1a8b91c();
			break;
		}
		x3da203c4ca1dec38();
	}

	public void x490e30087768649f(x54366fa5f75a02f7 x470ecea91abfd1aa)
	{
		int num = x9b529da35d1032aa;
		int num2 = x470ecea91abfd1aa.x9b529da35d1032aa;
		if (num == 0)
		{
			if (((uint)num2 & 2u) != 0)
			{
				x8e1e5d7ac41c148a = x470ecea91abfd1aa.x8e1e5d7ac41c148a;
				x011388a63eb09115 = x470ecea91abfd1aa.x011388a63eb09115;
			}
			if (((uint)num2 & 4u) != 0)
			{
				x1ba1feec87cdb33c = x470ecea91abfd1aa.x1ba1feec87cdb33c;
				xfc7a054ab2ab7fb7 = x470ecea91abfd1aa.xfc7a054ab2ab7fb7;
			}
			if (((uint)num2 & (true ? 1u : 0u)) != 0)
			{
				xbbda52e1bda14713 = x470ecea91abfd1aa.xbbda52e1bda14713;
				x2fb6ade0109b8efa = x470ecea91abfd1aa.x2fb6ade0109b8efa;
			}
			x9b529da35d1032aa = num2;
			xf263b01e2956834c = x470ecea91abfd1aa.xf263b01e2956834c;
			return;
		}
		float num3;
		float num4;
		switch (num2)
		{
		case 0:
			return;
		case 1:
			xce92de628aa023cf(x470ecea91abfd1aa.xbbda52e1bda14713, x470ecea91abfd1aa.x2fb6ade0109b8efa);
			return;
		case 2:
			x5152a5707921c783(x470ecea91abfd1aa.x8e1e5d7ac41c148a, x470ecea91abfd1aa.x011388a63eb09115);
			return;
		case 4:
			switch (num)
			{
			case 6:
			case 7:
			{
				num3 = x470ecea91abfd1aa.x1ba1feec87cdb33c;
				num4 = x470ecea91abfd1aa.xfc7a054ab2ab7fb7;
				float num5 = x8e1e5d7ac41c148a;
				x8e1e5d7ac41c148a = x1ba1feec87cdb33c * num4;
				x1ba1feec87cdb33c = num5 * num3;
				num5 = xfc7a054ab2ab7fb7;
				xfc7a054ab2ab7fb7 = x011388a63eb09115 * num4;
				x011388a63eb09115 = num5 * num3;
				xf263b01e2956834c = -1;
				return;
			}
			case 4:
			case 5:
				x8e1e5d7ac41c148a = x1ba1feec87cdb33c * x470ecea91abfd1aa.xfc7a054ab2ab7fb7;
				x1ba1feec87cdb33c = 0f;
				x011388a63eb09115 = xfc7a054ab2ab7fb7 * x470ecea91abfd1aa.x1ba1feec87cdb33c;
				xfc7a054ab2ab7fb7 = 0f;
				x9b529da35d1032aa = num ^ 6;
				xf263b01e2956834c = -1;
				return;
			case 2:
			case 3:
				x1ba1feec87cdb33c = x8e1e5d7ac41c148a * x470ecea91abfd1aa.x1ba1feec87cdb33c;
				x8e1e5d7ac41c148a = 0f;
				xfc7a054ab2ab7fb7 = x011388a63eb09115 * x470ecea91abfd1aa.xfc7a054ab2ab7fb7;
				x011388a63eb09115 = 0f;
				x9b529da35d1032aa = num ^ 6;
				xf263b01e2956834c = -1;
				return;
			case 1:
				x8e1e5d7ac41c148a = 0f;
				x1ba1feec87cdb33c = x470ecea91abfd1aa.x1ba1feec87cdb33c;
				xfc7a054ab2ab7fb7 = x470ecea91abfd1aa.xfc7a054ab2ab7fb7;
				x011388a63eb09115 = 0f;
				x9b529da35d1032aa = 5;
				xf263b01e2956834c = -1;
				return;
			}
			break;
		}
		float num6 = x470ecea91abfd1aa.x8e1e5d7ac41c148a;
		num3 = x470ecea91abfd1aa.x1ba1feec87cdb33c;
		float num7 = x470ecea91abfd1aa.xbbda52e1bda14713;
		num4 = x470ecea91abfd1aa.xfc7a054ab2ab7fb7;
		float num8 = x470ecea91abfd1aa.x011388a63eb09115;
		float num9 = x470ecea91abfd1aa.x2fb6ade0109b8efa;
		switch (num)
		{
		case 6:
			x9b529da35d1032aa = num | num2;
			goto case 7;
		case 7:
		{
			float num5 = x8e1e5d7ac41c148a;
			float num10 = x1ba1feec87cdb33c;
			x8e1e5d7ac41c148a = num6 * num5 + num4 * num10;
			x1ba1feec87cdb33c = num3 * num5 + num8 * num10;
			xbbda52e1bda14713 = xbbda52e1bda14713 + num7 * num5 + num9 * num10;
			num5 = xfc7a054ab2ab7fb7;
			num10 = x011388a63eb09115;
			xfc7a054ab2ab7fb7 = num6 * num5 + num4 * num10;
			x011388a63eb09115 = num3 * num5 + num8 * num10;
			x2fb6ade0109b8efa = x2fb6ade0109b8efa + num7 * num5 + num9 * num10;
			xf263b01e2956834c = -1;
			return;
		}
		case 4:
		case 5:
		{
			float num5 = x1ba1feec87cdb33c;
			x8e1e5d7ac41c148a = num4 * num5;
			x1ba1feec87cdb33c = num8 * num5;
			xbbda52e1bda14713 += num9 * num5;
			num5 = xfc7a054ab2ab7fb7;
			xfc7a054ab2ab7fb7 = num6 * num5;
			x011388a63eb09115 = num3 * num5;
			x2fb6ade0109b8efa += num7 * num5;
			break;
		}
		case 2:
		case 3:
		{
			float num5 = x8e1e5d7ac41c148a;
			x8e1e5d7ac41c148a = num6 * num5;
			x1ba1feec87cdb33c = num3 * num5;
			xbbda52e1bda14713 += num7 * num5;
			num5 = x011388a63eb09115;
			xfc7a054ab2ab7fb7 = num4 * num5;
			x011388a63eb09115 = num8 * num5;
			x2fb6ade0109b8efa += num9 * num5;
			break;
		}
		case 1:
			x8e1e5d7ac41c148a = num6;
			x1ba1feec87cdb33c = num3;
			xbbda52e1bda14713 += num7;
			xfc7a054ab2ab7fb7 = num4;
			x011388a63eb09115 = num8;
			x2fb6ade0109b8efa += num9;
			x9b529da35d1032aa = num2 | 1;
			xf263b01e2956834c = -1;
			return;
		default:
			x938f936af1a8b91c();
			break;
		}
		x3da203c4ca1dec38();
	}

	public void xa77087bb05d9ef76(float xcb83cdf6822fc99d, MatrixOrder x7bc95a6c91d75cef)
	{
		if (xcb83cdf6822fc99d == 0f)
		{
			return;
		}
		if (x7bc95a6c91d75cef == MatrixOrder.Prepend)
		{
			xa77087bb05d9ef76(xcb83cdf6822fc99d);
			return;
		}
		if (xcb83cdf6822fc99d == 90f || xcb83cdf6822fc99d == -270f)
		{
			xe8f3a96021aa8a83();
			return;
		}
		if (xcb83cdf6822fc99d == -90f || xcb83cdf6822fc99d == 270f)
		{
			xcece9d6c6fd3aba8();
			return;
		}
		if (xcb83cdf6822fc99d == 180f || xcb83cdf6822fc99d == -180f)
		{
			x413ea72c6c5186ef();
			return;
		}
		double num = x15e971129fd80714.xcdc7b29a812dd7df(xcb83cdf6822fc99d);
		double num2 = Math.Sin(num);
		double num3 = Math.Cos(num);
		if (num3 != 1.0)
		{
			float num4 = x8e1e5d7ac41c148a;
			float num5 = xfc7a054ab2ab7fb7;
			x8e1e5d7ac41c148a = (float)(num3 * (double)num4 - num2 * (double)num5);
			xfc7a054ab2ab7fb7 = (float)(num2 * (double)num4 + num3 * (double)num5);
			num4 = x1ba1feec87cdb33c;
			num5 = x011388a63eb09115;
			x1ba1feec87cdb33c = (float)(num3 * (double)num4 - num2 * (double)num5);
			x011388a63eb09115 = (float)(num2 * (double)num4 + num3 * (double)num5);
			num4 = xbbda52e1bda14713;
			num5 = x2fb6ade0109b8efa;
			xbbda52e1bda14713 = (float)(num3 * (double)num4 - num2 * (double)num5);
			x2fb6ade0109b8efa = (float)(num2 * (double)num4 + num3 * (double)num5);
			x3da203c4ca1dec38();
		}
	}

	public void xa77087bb05d9ef76(float xcb83cdf6822fc99d)
	{
		if (xcb83cdf6822fc99d == 0f)
		{
			return;
		}
		if (xcb83cdf6822fc99d == 90f || xcb83cdf6822fc99d == -270f)
		{
			x80ea1cf464434828();
			return;
		}
		if (xcb83cdf6822fc99d == -90f || xcb83cdf6822fc99d == 270f)
		{
			x3993c61158fc3f47();
			return;
		}
		if (xcb83cdf6822fc99d == 180f || xcb83cdf6822fc99d == -180f)
		{
			x675ffaa8f377d544();
			return;
		}
		double num = x15e971129fd80714.xcdc7b29a812dd7df(xcb83cdf6822fc99d);
		double num2 = Math.Sin(num);
		double num3 = Math.Cos(num);
		if (num3 != 1.0)
		{
			float num4 = x8e1e5d7ac41c148a;
			float num5 = x1ba1feec87cdb33c;
			x8e1e5d7ac41c148a = (float)(num3 * (double)num4 + num2 * (double)num5);
			x1ba1feec87cdb33c = (float)((0.0 - num2) * (double)num4 + num3 * (double)num5);
			num4 = xfc7a054ab2ab7fb7;
			num5 = x011388a63eb09115;
			xfc7a054ab2ab7fb7 = (float)(num3 * (double)num4 + num2 * (double)num5);
			x011388a63eb09115 = (float)((0.0 - num2) * (double)num4 + num3 * (double)num5);
			x3da203c4ca1dec38();
		}
	}

	public void x49d618948c467be6(float xcb83cdf6822fc99d, PointF x2f7096dac971d6ec, MatrixOrder x7bc95a6c91d75cef)
	{
		if (x7bc95a6c91d75cef == MatrixOrder.Prepend)
		{
			x49d618948c467be6(xcb83cdf6822fc99d, x2f7096dac971d6ec);
			return;
		}
		xce92de628aa023cf(0f - x2f7096dac971d6ec.X, 0f - x2f7096dac971d6ec.Y, MatrixOrder.Append);
		xa77087bb05d9ef76(xcb83cdf6822fc99d, MatrixOrder.Append);
		xce92de628aa023cf(x2f7096dac971d6ec.X, x2f7096dac971d6ec.Y, MatrixOrder.Append);
	}

	public void x49d618948c467be6(float xcb83cdf6822fc99d, PointF x2f7096dac971d6ec)
	{
		xce92de628aa023cf(x2f7096dac971d6ec.X, x2f7096dac971d6ec.Y);
		xa77087bb05d9ef76(xcb83cdf6822fc99d);
		xce92de628aa023cf(0f - x2f7096dac971d6ec.X, 0f - x2f7096dac971d6ec.Y);
	}

	private void x80ea1cf464434828()
	{
		float num = x8e1e5d7ac41c148a;
		x8e1e5d7ac41c148a = x1ba1feec87cdb33c;
		x1ba1feec87cdb33c = 0f - num;
		num = xfc7a054ab2ab7fb7;
		xfc7a054ab2ab7fb7 = x011388a63eb09115;
		x011388a63eb09115 = 0f - num;
		int num2 = xdb826f07eecf6ce8[x9b529da35d1032aa];
		if ((num2 & 6) == 2 && x8e1e5d7ac41c148a == 1f && x011388a63eb09115 == 1f)
		{
			num2 -= 2;
		}
		x9b529da35d1032aa = num2;
		xf263b01e2956834c = -1;
	}

	private void x675ffaa8f377d544()
	{
		x8e1e5d7ac41c148a = 0f - x8e1e5d7ac41c148a;
		x011388a63eb09115 = 0f - x011388a63eb09115;
		int num = x9b529da35d1032aa;
		if (((uint)num & 4u) != 0)
		{
			x1ba1feec87cdb33c = 0f - x1ba1feec87cdb33c;
			xfc7a054ab2ab7fb7 = 0f - xfc7a054ab2ab7fb7;
		}
		else if (x8e1e5d7ac41c148a == 1f && x011388a63eb09115 == 1f)
		{
			x9b529da35d1032aa = num & -3;
		}
		else
		{
			x9b529da35d1032aa = num | 2;
		}
		xf263b01e2956834c = -1;
	}

	private void x3993c61158fc3f47()
	{
		float num = x8e1e5d7ac41c148a;
		x8e1e5d7ac41c148a = 0f - x1ba1feec87cdb33c;
		x1ba1feec87cdb33c = num;
		num = xfc7a054ab2ab7fb7;
		xfc7a054ab2ab7fb7 = 0f - x011388a63eb09115;
		x011388a63eb09115 = num;
		int num2 = xdb826f07eecf6ce8[x9b529da35d1032aa];
		if ((num2 & 6) == 2 && x8e1e5d7ac41c148a == 1f && x011388a63eb09115 == 1f)
		{
			num2 -= 2;
		}
		x9b529da35d1032aa = num2;
		xf263b01e2956834c = -1;
	}

	private void xe8f3a96021aa8a83()
	{
		float num = x8e1e5d7ac41c148a;
		x8e1e5d7ac41c148a = 0f - xfc7a054ab2ab7fb7;
		xfc7a054ab2ab7fb7 = num;
		num = x1ba1feec87cdb33c;
		x1ba1feec87cdb33c = 0f - x011388a63eb09115;
		x011388a63eb09115 = num;
		num = xbbda52e1bda14713;
		xbbda52e1bda14713 = 0f - x2fb6ade0109b8efa;
		x2fb6ade0109b8efa = num;
		x3da203c4ca1dec38();
	}

	private void x413ea72c6c5186ef()
	{
		x8e1e5d7ac41c148a = 0f - x8e1e5d7ac41c148a;
		x1ba1feec87cdb33c = 0f - x1ba1feec87cdb33c;
		xfc7a054ab2ab7fb7 = 0f - xfc7a054ab2ab7fb7;
		x011388a63eb09115 = 0f - x011388a63eb09115;
		xbbda52e1bda14713 = 0f - xbbda52e1bda14713;
		x2fb6ade0109b8efa = 0f - x2fb6ade0109b8efa;
		x3da203c4ca1dec38();
	}

	private void xcece9d6c6fd3aba8()
	{
		float num = x8e1e5d7ac41c148a;
		x8e1e5d7ac41c148a = xfc7a054ab2ab7fb7;
		xfc7a054ab2ab7fb7 = 0f - num;
		num = x1ba1feec87cdb33c;
		x1ba1feec87cdb33c = x011388a63eb09115;
		x011388a63eb09115 = 0f - num;
		num = xbbda52e1bda14713;
		xbbda52e1bda14713 = x2fb6ade0109b8efa;
		x2fb6ade0109b8efa = 0f - num;
		x3da203c4ca1dec38();
	}

	public void x74f5a1ef3906e23c()
	{
		x8e1e5d7ac41c148a = (x011388a63eb09115 = 1f);
		xfc7a054ab2ab7fb7 = (x1ba1feec87cdb33c = (xbbda52e1bda14713 = (x2fb6ade0109b8efa = 0f)));
		x9b529da35d1032aa = 0;
		xf263b01e2956834c = 0;
	}

	public x54366fa5f75a02f7 x8b61531c8ea35b85()
	{
		x54366fa5f75a02f7 x54366fa5f75a02f8 = new x54366fa5f75a02f7();
		x54366fa5f75a02f8.x8e1e5d7ac41c148a = x8e1e5d7ac41c148a;
		x54366fa5f75a02f8.xfc7a054ab2ab7fb7 = xfc7a054ab2ab7fb7;
		x54366fa5f75a02f8.x1ba1feec87cdb33c = x1ba1feec87cdb33c;
		x54366fa5f75a02f8.x011388a63eb09115 = x011388a63eb09115;
		x54366fa5f75a02f8.xbbda52e1bda14713 = xbbda52e1bda14713;
		x54366fa5f75a02f8.x2fb6ade0109b8efa = x2fb6ade0109b8efa;
		x54366fa5f75a02f8.x9b529da35d1032aa = x9b529da35d1032aa;
		x54366fa5f75a02f8.xf263b01e2956834c = xf263b01e2956834c;
		return x54366fa5f75a02f8;
	}

	public override int GetHashCode()
	{
		long num = x8e1e5d7ac41c148a.GetHashCode();
		num = num * 31 + x1ba1feec87cdb33c.GetHashCode();
		num = num * 31 + xbbda52e1bda14713.GetHashCode();
		num = num * 31 + xfc7a054ab2ab7fb7.GetHashCode();
		num = num * 31 + x011388a63eb09115.GetHashCode();
		num = num * 31 + x2fb6ade0109b8efa.GetHashCode();
		return (int)num ^ (int)(num >> 32);
	}

	public override bool Equals(object obj)
	{
		if (obj is x54366fa5f75a02f7)
		{
			return Equals(this, (x54366fa5f75a02f7)obj);
		}
		return false;
	}

	public static bool Equals(x54366fa5f75a02f7 a, x54366fa5f75a02f7 b)
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
		if (a.x8e1e5d7ac41c148a == b.x8e1e5d7ac41c148a && a.xfc7a054ab2ab7fb7 == b.xfc7a054ab2ab7fb7 && a.x1ba1feec87cdb33c == b.x1ba1feec87cdb33c && a.x011388a63eb09115 == b.x011388a63eb09115 && a.xbbda52e1bda14713 == b.xbbda52e1bda14713)
		{
			return a.x2fb6ade0109b8efa == b.x2fb6ade0109b8efa;
		}
		return false;
	}

	public static bool operator ==(x54366fa5f75a02f7 a, x54366fa5f75a02f7 b)
	{
		return Equals(a, b);
	}

	public static bool operator !=(x54366fa5f75a02f7 a, x54366fa5f75a02f7 b)
	{
		return !Equals(a, b);
	}

	public override string ToString()
	{
		return $"{x8e1e5d7ac41c148a}, {xfc7a054ab2ab7fb7}, {x1ba1feec87cdb33c}, {x011388a63eb09115}, {xbbda52e1bda14713}, {x2fb6ade0109b8efa}";
	}

	private void x3da203c4ca1dec38()
	{
		if (x1ba1feec87cdb33c == 0f && xfc7a054ab2ab7fb7 == 0f)
		{
			if (x8e1e5d7ac41c148a == 1f && x011388a63eb09115 == 1f)
			{
				if (xbbda52e1bda14713 == 0f && x2fb6ade0109b8efa == 0f)
				{
					x9b529da35d1032aa = 0;
					xf263b01e2956834c = 0;
				}
				else
				{
					x9b529da35d1032aa = 1;
					xf263b01e2956834c = 1;
				}
			}
			else if (xbbda52e1bda14713 == 0f && x2fb6ade0109b8efa == 0f)
			{
				x9b529da35d1032aa = 2;
				xf263b01e2956834c = -1;
			}
			else
			{
				x9b529da35d1032aa = 3;
				xf263b01e2956834c = -1;
			}
		}
		else if (x8e1e5d7ac41c148a == 0f && x011388a63eb09115 == 0f)
		{
			if (xbbda52e1bda14713 == 0f && x2fb6ade0109b8efa == 0f)
			{
				x9b529da35d1032aa = 4;
				xf263b01e2956834c = -1;
			}
			else
			{
				x9b529da35d1032aa = 5;
				xf263b01e2956834c = -1;
			}
		}
		else if (xbbda52e1bda14713 == 0f && x2fb6ade0109b8efa == 0f)
		{
			x9b529da35d1032aa = 6;
			xf263b01e2956834c = -1;
		}
		else
		{
			x9b529da35d1032aa = 7;
			xf263b01e2956834c = -1;
		}
	}

	private void x938f936af1a8b91c()
	{
		throw new ExecutionEngineException("missing case in transform state switch");
	}
}
