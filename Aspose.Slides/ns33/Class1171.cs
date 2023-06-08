using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;

namespace ns33;

internal class Class1171
{
	private static readonly IFormatProvider iformatProvider_0 = CultureInfo.InvariantCulture.NumberFormat;

	private int int_0;

	private char char_0;

	public static RectangleF smethod_0(string viewbox)
	{
		float x = 0f;
		float y = 0f;
		float width = 0f;
		float height = 0f;
		int i;
		for (i = 0; i < viewbox.Length && viewbox[i] <= ' '; i++)
		{
		}
		int num = i;
		if (i < viewbox.Length && (viewbox[i] == '-' || viewbox[i] == '+'))
		{
			for (i++; i < viewbox.Length && viewbox[i] <= ' '; i++)
			{
			}
		}
		for (; i < viewbox.Length && ((viewbox[i] >= '0' && viewbox[i] <= '9') || viewbox[i] == '.'); i++)
		{
		}
		if (num != i)
		{
			x = float.Parse(viewbox.Substring(num, i - num));
		}
		for (; i < viewbox.Length && viewbox[i] <= ' '; i++)
		{
		}
		if (i < viewbox.Length && viewbox[i] == ',')
		{
			i++;
		}
		for (; i < viewbox.Length && viewbox[i] <= ' '; i++)
		{
		}
		num = i;
		if (i < viewbox.Length && (viewbox[i] == '-' || viewbox[i] == '+'))
		{
			for (i++; i < viewbox.Length && viewbox[i] <= ' '; i++)
			{
			}
		}
		for (; i < viewbox.Length && ((viewbox[i] >= '0' && viewbox[i] <= '9') || viewbox[i] == '.'); i++)
		{
		}
		if (num != i)
		{
			y = float.Parse(viewbox.Substring(num, i - num));
		}
		for (; i < viewbox.Length && viewbox[i] <= ' '; i++)
		{
		}
		if (i < viewbox.Length && viewbox[i] == ',')
		{
			i++;
		}
		for (; i < viewbox.Length && viewbox[i] <= ' '; i++)
		{
		}
		num = i;
		if (i < viewbox.Length && (viewbox[i] == '-' || viewbox[i] == '+'))
		{
			for (i++; i < viewbox.Length && viewbox[i] <= ' '; i++)
			{
			}
		}
		for (; i < viewbox.Length && ((viewbox[i] >= '0' && viewbox[i] <= '9') || viewbox[i] == '.'); i++)
		{
		}
		if (num != i)
		{
			width = float.Parse(viewbox.Substring(num, i - num));
		}
		for (; i < viewbox.Length && viewbox[i] <= ' '; i++)
		{
		}
		if (i < viewbox.Length && viewbox[i] == ',')
		{
			i++;
		}
		for (; i < viewbox.Length && viewbox[i] <= ' '; i++)
		{
		}
		num = i;
		if (i < viewbox.Length && (viewbox[i] == '-' || viewbox[i] == '+'))
		{
			for (i++; i < viewbox.Length && viewbox[i] <= ' '; i++)
			{
			}
		}
		for (; i < viewbox.Length && ((viewbox[i] >= '0' && viewbox[i] <= '9') || viewbox[i] == '.'); i++)
		{
		}
		if (num != i)
		{
			height = float.Parse(viewbox.Substring(num, i - num));
		}
		return new RectangleF(x, y, width, height);
	}

	public static void smethod_1(GraphicsPath graphicsPath, StringBuilder closed, StringBuilder nonclosed)
	{
		smethod_3(graphicsPath, closed, nonclosed, 0f, 0f, 0f);
	}

	internal static void smethod_2(GraphicsPath graphicsPath, StringBuilder closed, StringBuilder nonclosed, bool integerCoordinates)
	{
		Class1171 @class = new Class1171();
		RectangleF bounds = graphicsPath.GetBounds();
		float num = Math.Max(Math.Abs(bounds.Width), Math.Abs(bounds.Height));
		int num2 = 1;
		if (!integerCoordinates)
		{
			while (1000.0 / (double)num2 > (double)num)
			{
				num2 *= 10;
			}
		}
		@class.int_0 = num2;
		@class.method_0(graphicsPath, closed, nonclosed, 0f, 0f, 0f);
	}

	public static void smethod_3(GraphicsPath graphicsPath, StringBuilder closed, StringBuilder nonclosed, float beginInset, float endInset, float width)
	{
		Class1171 @class = new Class1171();
		RectangleF bounds = graphicsPath.GetBounds();
		float num = Math.Max(Math.Abs(bounds.Width), Math.Abs(bounds.Height));
		int num2 = 1;
		while (1000.0 / (double)num2 > (double)num)
		{
			num2 *= 10;
		}
		@class.int_0 = num2;
		@class.method_0(graphicsPath, closed, nonclosed, beginInset, endInset, width);
	}

	private void method_0(GraphicsPath graphicsPath, StringBuilder closed, StringBuilder nonclosed, float beginInset, float endInset, float width)
	{
		byte[] pathTypes = graphicsPath.PathTypes;
		PointF[] pathPoints = graphicsPath.PathPoints;
		int num = 0;
		bool flag = (double)(Math.Abs(beginInset) + Math.Abs(endInset)) < 0.01;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = ((width < 16f) ? (width / 2f) : (width / 4f));
		if (beginInset > 0f)
		{
			num2 = beginInset + num4;
			num2 *= num2;
		}
		if (endInset > 0f)
		{
			num3 = endInset + num4;
			num3 *= num3;
		}
		int pointCount = graphicsPath.PointCount;
		while (num < pathTypes.Length)
		{
			bool flag2 = false;
			int num5 = num;
			while (num < pointCount && !flag2 && ((pathTypes[num] & 0x1Fu) != 0 || num <= num5))
			{
				num = (pathTypes[num] & 0x1F) switch
				{
					2 => num + 2, 
					3 => num + 3, 
					_ => num + 1, 
				};
				if ((pathTypes[num - 1] & 0x80u) != 0)
				{
					flag2 = true;
				}
			}
			if (num > pointCount)
			{
				num = pointCount;
			}
			StringBuilder value;
			if (!flag2 && !flag && num - num5 != 1)
			{
				int num6 = num5 + 1;
				int num7 = num - 1;
				int num8 = num7;
				double num9 = -1.0;
				double num10 = -1.0;
				double num11 = pathPoints[num5].X;
				double num12 = pathPoints[num5].Y;
				double num13 = pathPoints[num7].X;
				double num14 = pathPoints[num7].Y;
				bool flag3 = (double)beginInset < 0.0001;
				while (num6 < num && !flag3)
				{
					switch (pathTypes[num6] & 0x1F)
					{
					default:
						if (smethod_4(pathPoints[num5], pathPoints[num6]) > num2)
						{
							double num31 = (double)pathPoints[num6 - 1].X - num11;
							double num32 = (double)pathPoints[num6 - 1].Y - num12;
							double num33 = (double)pathPoints[num6].X - num11 - num31;
							double num34 = (double)pathPoints[num6].Y - num12 - num32;
							double num35 = 2.0 * (num33 + num34);
							double num36 = num33 * num33 + num34 * num34;
							double d = num35 * num35 - 4.0 * num36 * (num31 * num31 + num32 * num32 - (double)num2);
							double num37 = Math.Sqrt(d);
							double num38 = (0.0 - num35 - num37) / 2.0 / num36;
							double num39 = (0.0 - num35 + num37) / 2.0 / num36;
							num9 = ((!(num38 >= 0.0) || num38 > 1.0) ? num39 : num38);
							flag3 = true;
						}
						else
						{
							num6++;
						}
						break;
					case 2:
					{
						if (!(smethod_4(pathPoints[num5], pathPoints[num6]) > num2) && smethod_4(pathPoints[num5], pathPoints[num6 + 1]) <= num2)
						{
							num6 += 2;
							break;
						}
						double num40 = (double)pathPoints[num6 - 1].X - num11;
						double num41 = (double)pathPoints[num6 - 1].Y - num12;
						double num42 = (double)pathPoints[num6].X - num11;
						double num43 = (double)pathPoints[num6].Y - num12;
						double num44 = (double)pathPoints[num6 + 1].X - num11;
						double num45 = (double)pathPoints[num6 + 1].Y - num12;
						double num46 = num40 - 2.0 * num42 + num44;
						double num47 = 2.0 * (num42 - num40);
						double num48 = num40;
						double num49 = num41 - 2.0 * num43 + num45;
						double num50 = 2.0 * (num43 - num41);
						double num51 = num41;
						double[] polynomialEquation2 = new double[5]
						{
							num48 * num48 + num51 * num51 - (double)num2,
							2.0 * (num48 * num47 + num51 * num50),
							num47 * num47 + 2.0 * (num48 * num46 + num51 * num50) + num50 * num50,
							2.0 * (num46 * num47 + num49 * num50),
							num46 * num46 + num49 * num49
						};
						double[] array2 = Class1166.smethod_9(polynomialEquation2, 0.0, 1.0);
						if (array2.Length > 0)
						{
							num9 = array2[0];
							flag3 = true;
						}
						else
						{
							num6 += 2;
						}
						break;
					}
					case 3:
					{
						if (!(smethod_4(pathPoints[num5], pathPoints[num6]) > num2) && !(smethod_4(pathPoints[num5], pathPoints[num6 + 1]) > num2) && smethod_4(pathPoints[num5], pathPoints[num6 + 2]) <= num2)
						{
							num6 += 3;
							break;
						}
						double num15 = (double)pathPoints[num6 - 1].X - num11;
						double num16 = (double)pathPoints[num6 - 1].Y - num12;
						double num17 = (double)pathPoints[num6].X - num11;
						double num18 = (double)pathPoints[num6].Y - num12;
						double num19 = (double)pathPoints[num6 + 1].X - num11;
						double num20 = (double)pathPoints[num6 + 1].Y - num12;
						double num21 = (double)pathPoints[num6 + 2].X - num11;
						double num22 = (double)pathPoints[num6 + 2].Y - num12;
						double num23 = num21 - 3.0 * num19 + 3.0 * num17 - num15;
						double num24 = 3.0 * (num19 - 2.0 * num17 + num15);
						double num25 = 3.0 * (num17 - num15);
						double num26 = num15;
						double num27 = num22 - 3.0 * num20 + 3.0 * num18 - num16;
						double num28 = 3.0 * (num20 - 2.0 * num18 + num16);
						double num29 = 3.0 * (num18 - num16);
						double num30 = num16;
						double[] polynomialEquation = new double[7]
						{
							num26 * num26 + num30 * num30 - (double)num2,
							2.0 * (num26 * num25 + num30 * num29),
							num25 * num25 + 2.0 * (num26 * num24 + num30 * num28) + num29 * num29,
							2.0 * (num23 * num26 + num25 * num24 + num27 * num30 + num29 * num28),
							num24 * num24 + 2.0 * (num23 * num25 + num27 * num29) + num28 * num28,
							2.0 * (num23 * num24 + num27 * num28),
							num23 * num23 + num27 * num27
						};
						double[] array = Class1166.smethod_9(polynomialEquation, 0.0, 1.0);
						if (array.Length > 0)
						{
							num9 = array[0];
							flag3 = true;
						}
						else
						{
							num6 += 3;
						}
						break;
					}
					}
				}
				flag3 = (double)endInset < 0.0001;
				while (num5 < num8 && !flag3)
				{
					switch (pathTypes[num8] & 0x1F)
					{
					default:
						if (smethod_4(pathPoints[num7], pathPoints[num8 - 1]) > num3)
						{
							double num68 = (double)pathPoints[num8].X - num13;
							double num69 = (double)pathPoints[num8].Y - num14;
							double num70 = (double)pathPoints[num8 - 1].X - num13 - num68;
							double num71 = (double)pathPoints[num8 - 1].Y - num14 - num69;
							double num72 = 2.0 * (num70 + num71);
							double num73 = num70 * num70 + num71 * num71;
							double d2 = num72 * num72 - 4.0 * num73 * (num68 * num68 + num69 * num69 - (double)num3);
							double num74 = Math.Sqrt(d2);
							double num75 = (0.0 - num72 - num74) / 2.0 / num73;
							double num76 = (0.0 - num72 + num74) / 2.0 / num73;
							num10 = ((!(num75 >= 0.0) || num75 > 1.0) ? num76 : num75);
							flag3 = true;
						}
						else
						{
							num8--;
						}
						break;
					case 2:
					{
						if (!(smethod_4(pathPoints[num7], pathPoints[num8 - 1]) > num3) && smethod_4(pathPoints[num7], pathPoints[num8 - 2]) <= num3)
						{
							num8 -= 2;
							break;
						}
						double num77 = (double)pathPoints[num8].X - num13;
						double num78 = (double)pathPoints[num8].Y - num14;
						double num79 = (double)pathPoints[num8 - 1].X - num13;
						double num80 = (double)pathPoints[num8 - 1].Y - num14;
						double num81 = (double)pathPoints[num8 - 2].X - num13;
						double num82 = (double)pathPoints[num8 - 2].Y - num14;
						double num83 = num77 - 2.0 * num79 + num81;
						double num84 = 2.0 * (num79 - num77);
						double num85 = num77;
						double num86 = num78 - 2.0 * num80 + num82;
						double num87 = 2.0 * (num80 - num78);
						double num88 = num78;
						double[] polynomialEquation4 = new double[5]
						{
							num85 * num85 + num88 * num88 - (double)num3,
							2.0 * (num85 * num84 + num88 * num87),
							num84 * num84 + 2.0 * (num85 * num83 + num88 * num87) + num87 * num87,
							2.0 * (num83 * num84 + num86 * num87),
							num83 * num83 + num86 * num86
						};
						double[] array4 = Class1166.smethod_9(polynomialEquation4, 0.0, 1.0);
						if (array4.Length > 0)
						{
							num10 = array4[0];
							flag3 = true;
						}
						else
						{
							num8 -= 2;
						}
						break;
					}
					case 3:
					{
						if (!(smethod_4(pathPoints[num7], pathPoints[num8 - 1]) > num3) && !(smethod_4(pathPoints[num7], pathPoints[num8 - 2]) > num3) && smethod_4(pathPoints[num7], pathPoints[num8 - 3]) <= num3)
						{
							num8 -= 3;
							break;
						}
						double num52 = (double)pathPoints[num8].X - num13;
						double num53 = (double)pathPoints[num8].Y - num14;
						double num54 = (double)pathPoints[num8 - 1].X - num13;
						double num55 = (double)pathPoints[num8 - 1].Y - num14;
						double num56 = (double)pathPoints[num8 - 2].X - num13;
						double num57 = (double)pathPoints[num8 - 2].Y - num14;
						double num58 = (double)pathPoints[num8 - 3].X - num13;
						double num59 = (double)pathPoints[num8 - 3].Y - num14;
						double num60 = num58 - 3.0 * num56 + 3.0 * num54 - num52;
						double num61 = 3.0 * (num56 - 2.0 * num54 + num52);
						double num62 = 3.0 * (num54 - num52);
						double num63 = num52;
						double num64 = num59 - 3.0 * num57 + 3.0 * num55 - num53;
						double num65 = 3.0 * (num57 - 2.0 * num55 + num53);
						double num66 = 3.0 * (num55 - num53);
						double num67 = num53;
						double[] polynomialEquation3 = new double[7]
						{
							num63 * num63 + num67 * num67 - (double)num3,
							2.0 * (num63 * num62 + num67 * num66),
							num62 * num62 + 2.0 * (num63 * num61 + num67 * num65) + num66 * num66,
							2.0 * (num60 * num63 + num62 * num61 + num64 * num67 + num66 * num65),
							num61 * num61 + 2.0 * (num60 * num62 + num64 * num66) + num65 * num65,
							2.0 * (num60 * num61 + num64 * num65),
							num60 * num60 + num64 * num64
						};
						double[] array3 = Class1166.smethod_9(polynomialEquation3, 0.0, 1.0);
						if (array3.Length > 0)
						{
							num10 = array3[0];
							flag3 = true;
						}
						else
						{
							num8 -= 3;
						}
						break;
					}
					}
				}
				if (num8 >= num6)
				{
					int num89 = num8 - num6 + 2;
					if (beginInset > 0f)
					{
						num89++;
					}
					if (endInset > 0f)
					{
						num89++;
					}
					PointF[] array5 = new PointF[num89];
					byte[] array6 = new byte[num89];
					int num90 = ((num9 >= 0.0) ? 1 : 0);
					int num91 = num6 - 1;
					while (num91 <= num8)
					{
						array6[num90] = pathTypes[num91];
						ref PointF reference = ref array5[num90];
						reference = pathPoints[num91];
						num91++;
						num90++;
					}
					array6[0] = 0;
					if (num9 >= 0.0)
					{
						switch (array6[2] & 3)
						{
						default:
						{
							ref PointF reference2 = ref array5[1];
							reference2 = new PointF((float)((1.0 - num9) * (double)array5[1].X + num9 * (double)array5[2].X), (float)((1.0 - num9) * (double)array5[1].Y + num9 * (double)array5[2].Y));
							break;
						}
						case 2:
						{
							double num100 = num9 * num9;
							double num101 = 1.0 - num9;
							double num102 = num101 * num101;
							double num103 = num9 * num101;
							PointF pointF4 = new PointF((float)(num102 * (double)array5[1].X + 2.0 * num103 * (double)array5[2].X + num100 * (double)array5[3].X), (float)(num102 * (double)array5[1].Y + 2.0 * num103 * (double)array5[2].Y + num100 * (double)array5[3].Y));
							PointF pointF5 = new PointF((float)(num101 * (double)array5[2].X + num9 * (double)array5[3].X), (float)(num101 * (double)array5[2].Y + num9 * (double)array5[3].Y));
							array5[1] = pointF4;
							array5[2] = pointF5;
							break;
						}
						case 3:
						{
							double num92 = 1.0 - num9;
							double num93 = num9 * num9;
							double num94 = num93 * num9;
							double num95 = num9 * num92;
							double num96 = num92 * num92;
							double num97 = num93 * num92;
							double num98 = num9 * num96;
							double num99 = num96 * num92;
							PointF pointF = new PointF((float)(num99 * (double)array5[1].X + 3.0 * num98 * (double)array5[2].X + 3.0 * num97 * (double)array5[3].X + num94 * (double)array5[4].X), (float)(num99 * (double)array5[1].Y + 3.0 * num98 * (double)array5[2].Y + 3.0 * num97 * (double)array5[3].Y + num94 * (double)array5[4].Y));
							PointF pointF2 = new PointF((float)(num96 * (double)array5[2].X + 2.0 * num95 * (double)array5[3].X + num93 * (double)array5[4].X), (float)(num96 * (double)array5[2].Y + 2.0 * num95 * (double)array5[3].Y + num93 * (double)array5[4].Y));
							PointF pointF3 = new PointF((float)(num92 * (double)array5[3].X + num9 * (double)array5[4].X), (float)(num92 * (double)array5[3].Y + num9 * (double)array5[4].Y));
							array5[1] = pointF;
							array5[2] = pointF2;
							array5[3] = pointF3;
							break;
						}
						}
						double num104 = pathPoints[num5].X - array5[1].X;
						double num105 = pathPoints[num5].Y - array5[1].Y;
						double num106 = Math.Sqrt(num104 * num104 + num105 * num105);
						ref PointF reference3 = ref array5[0];
						reference3 = new PointF((float)((double)array5[1].X + num104 / num106 * (double)num4), (float)((double)array5[1].Y + num105 / num106 * (double)num4));
						array6[1] = 1;
					}
					if (num10 >= 0.0)
					{
						if (num8 - num6 < (pathTypes[num8] & 3) && num9 >= 0.0)
						{
							num10 = num10 / (1.0 - num9) + 0.001;
						}
						int num107 = array6.Length - 2;
						switch (array6[num107] & 0x1F)
						{
						default:
						{
							ref PointF reference4 = ref array5[num107];
							reference4 = new PointF((float)((1.0 - num10) * (double)array5[num107].X + num10 * (double)array5[num107 - 1].X), (float)((1.0 - num10) * (double)array5[num107].Y + num10 * (double)array5[num107 - 1].Y));
							break;
						}
						case 2:
						{
							double num116 = num10 * num10;
							double num117 = 1.0 - num10;
							double num118 = num117 * num117;
							double num119 = num10 * num117;
							PointF pointF9 = new PointF((float)(num118 * (double)array5[num107].X + 2.0 * num119 * (double)array5[num107 - 1].X + num116 * (double)array5[num107 - 2].X), (float)(num118 * (double)array5[num107].Y + 2.0 * num119 * (double)array5[num107 - 1].Y + num116 * (double)array5[num107 - 2].Y));
							PointF pointF10 = new PointF((float)(num117 * (double)array5[num107 - 1].X + num10 * (double)array5[num107 - 2].X), (float)(num117 * (double)array5[num107 - 1].Y + num10 * (double)array5[num107 - 2].Y));
							array5[num107] = pointF9;
							array5[num107 - 1] = pointF10;
							break;
						}
						case 3:
						{
							double num108 = 1.0 - num10;
							double num109 = num10 * num10;
							double num110 = num109 * num10;
							double num111 = num10 * num108;
							double num112 = num108 * num108;
							double num113 = num109 * num108;
							double num114 = num10 * num112;
							double num115 = num112 * num108;
							PointF pointF6 = new PointF((float)(num115 * (double)array5[num107].X + 3.0 * num114 * (double)array5[num107 - 1].X + 3.0 * num113 * (double)array5[num107 - 2].X + num110 * (double)array5[num107 - 3].X), (float)(num115 * (double)array5[num107].Y + 3.0 * num114 * (double)array5[num107 - 1].Y + 3.0 * num113 * (double)array5[num107 - 2].Y + num110 * (double)array5[num107 - 3].Y));
							PointF pointF7 = new PointF((float)(num112 * (double)array5[num107 - 1].X + 2.0 * num111 * (double)array5[num107 - 2].X + num109 * (double)array5[num107 - 3].X), (float)(num112 * (double)array5[num107 - 1].Y + 2.0 * num111 * (double)array5[num107 - 2].Y + num109 * (double)array5[num107 - 3].Y));
							PointF pointF8 = new PointF((float)(num108 * (double)array5[num107 - 2].X + num10 * (double)array5[num107 - 3].X), (float)(num108 * (double)array5[num107 - 2].Y + num10 * (double)array5[num107 - 3].Y));
							array5[num107] = pointF6;
							array5[num107 - 1] = pointF7;
							array5[num107 - 2] = pointF8;
							break;
						}
						}
						double num120 = pathPoints[num7].X - array5[num107].X;
						double num121 = pathPoints[num7].Y - array5[num107].Y;
						double num122 = Math.Sqrt(num120 * num120 + num121 * num121);
						ref PointF reference5 = ref array5[num107 + 1];
						reference5 = new PointF((float)((double)array5[num107].X + num120 / num122 * (double)num4), (float)((double)array5[num107].Y + num121 / num122 * (double)num4));
						array6[num107 + 1] = 1;
					}
					value = method_1(array6, array5, 0, array6.Length);
				}
				else
				{
					byte[] array7 = new byte[4] { 0, 1, 1, 1 };
					PointF[] array8 = new PointF[4];
					if (num9 >= 0.0)
					{
						switch (pathTypes[num7] & 3)
						{
						default:
						{
							ref PointF reference8 = ref array8[1];
							reference8 = new PointF((float)((1.0 - num9) * (double)pathPoints[num6 - 1].X + num9 * (double)pathPoints[num6].X), (float)((1.0 - num9) * (double)pathPoints[num6 - 1].Y + num9 * (double)pathPoints[num6].Y));
							break;
						}
						case 2:
						{
							double num128 = 1.0 - num9;
							double num129 = num9 * num9;
							double num130 = num128 * num128;
							double num131 = num9 * num128;
							ref PointF reference7 = ref array8[1];
							reference7 = new PointF((float)(num130 * (double)pathPoints[num6 - 1].X + 2.0 * num131 * (double)pathPoints[num6].X + num129 * (double)pathPoints[num6 + 1].X), (float)(num130 * (double)pathPoints[num6 - 1].Y + 2.0 * num131 * (double)pathPoints[num6].Y + num129 * (double)pathPoints[num6 + 1].Y));
							break;
						}
						case 3:
						{
							double num123 = 1.0 - num9;
							double num124 = num9 * num9;
							double num125 = num123 * num123;
							double num126 = num124 * num9;
							double num127 = num125 * num123;
							ref PointF reference6 = ref array8[1];
							reference6 = new PointF((float)(num127 * (double)pathPoints[num6 - 1].X + 3.0 * num9 * num125 * (double)pathPoints[num6].X + 3.0 * num124 * num123 * (double)pathPoints[num6 + 1].X + num126 * (double)pathPoints[num6 + 2].X), (float)(num127 * (double)pathPoints[num6 - 1].Y + 3.0 * num9 * num125 * (double)pathPoints[num6].Y + 3.0 * num124 * num123 * (double)pathPoints[num6 + 1].Y + num126 * (double)pathPoints[num6 + 2].Y));
							break;
						}
						}
					}
					else
					{
						double num132 = pathPoints[num7].X - pathPoints[num5].X;
						double num133 = pathPoints[num7].Y - pathPoints[num5].Y;
						double num134 = Math.Sqrt(num132 * num132 + num133 * num133);
						double num135 = Math.Sqrt(num2);
						ref PointF reference9 = ref array8[1];
						reference9 = new PointF((float)((double)pathPoints[num5].X + num132 / num134 * num135), (float)((double)pathPoints[num5].Y + num133 / num134 * num135));
					}
					if (num10 >= 0.0)
					{
						switch (pathTypes[num7] & 3)
						{
						default:
						{
							ref PointF reference12 = ref array8[2];
							reference12 = new PointF((float)((1.0 - num10) * (double)pathPoints[num8].X + num10 * (double)pathPoints[num8 - 1].X), (float)((1.0 - num10) * (double)pathPoints[num8].Y + num10 * (double)pathPoints[num8 - 1].Y));
							break;
						}
						case 2:
						{
							double num141 = 1.0 - num10;
							double num142 = num10 * num10;
							double num143 = num141 * num141;
							double num144 = num10 * num141;
							ref PointF reference11 = ref array8[2];
							reference11 = new PointF((float)(num143 * (double)pathPoints[num8].X + 2.0 * num144 * (double)pathPoints[num8 - 1].X + num142 * (double)pathPoints[num8 - 2].X), (float)(num143 * (double)pathPoints[num8].Y + 2.0 * num144 * (double)pathPoints[num8 - 1].Y + num142 * (double)pathPoints[num8 - 2].Y));
							break;
						}
						case 3:
						{
							double num136 = 1.0 - num10;
							double num137 = num10 * num10;
							double num138 = num136 * num136;
							double num139 = num137 * num10;
							double num140 = num138 * num136;
							ref PointF reference10 = ref array8[2];
							reference10 = new PointF((float)(num140 * (double)pathPoints[num8].X + 3.0 * num10 * num138 * (double)pathPoints[num8 - 1].X + 3.0 * num137 * num136 * (double)pathPoints[num8 - 2].X + num139 * (double)pathPoints[num8 - 3].X), (float)(num140 * (double)pathPoints[num8].Y + 3.0 * num10 * num138 * (double)pathPoints[num8 - 1].Y + 3.0 * num137 * num136 * (double)pathPoints[num8 - 2].Y + num139 * (double)pathPoints[num8 - 3].Y));
							break;
						}
						}
					}
					else
					{
						double num145 = pathPoints[num5].X - pathPoints[num7].X;
						double num146 = pathPoints[num5].Y - pathPoints[num7].Y;
						double num147 = Math.Sqrt(num145 * num145 + num146 * num146);
						double num148 = Math.Sqrt(num3);
						ref PointF reference13 = ref array8[2];
						reference13 = new PointF((float)((double)pathPoints[num7].X + num145 / num147 * num148), (float)((double)pathPoints[num7].Y + num146 / num147 * num148));
					}
					double num149 = pathPoints[num5].X - array8[1].X;
					double num150 = pathPoints[num5].Y - array8[1].Y;
					double num151 = Math.Sqrt(num149 * num149 + num150 * num150);
					ref PointF reference14 = ref array8[0];
					reference14 = new PointF((float)((double)array8[1].X + num149 / num151 * (double)num4), (float)((double)array8[1].Y + num150 / num151 * (double)num4));
					num149 = pathPoints[num7].X - array8[2].X;
					num150 = pathPoints[num7].Y - array8[2].Y;
					num151 = Math.Sqrt(num149 * num149 + num150 * num150);
					ref PointF reference15 = ref array8[3];
					reference15 = new PointF((float)((double)array8[2].X + num149 / num151 * (double)num4), (float)((double)array8[2].Y + num150 / num151 * (double)num4));
					value = method_1(array7, array8, 0, array7.Length);
				}
			}
			else
			{
				value = method_1(pathTypes, pathPoints, num5, num);
			}
			if (flag2)
			{
				closed?.Append(value);
			}
			else
			{
				nonclosed?.Append(value);
			}
		}
	}

	private StringBuilder method_1(byte[] types, PointF[] points, int firstIndex, int endIndex)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = firstIndex;
		double num2 = 0.0;
		double num3 = 0.0;
		char_0 = '*';
		while (num < endIndex)
		{
			switch (types[num] & 0x1F)
			{
			case 0:
			{
				double coord = method_2(points[num].X);
				double coord2 = method_2(points[num].Y);
				num++;
				string text = $"M{method_3(coord)}{method_4(coord2)}";
				string text2 = $"m{method_3(coord - num2)}{method_4(coord2 - num3)}";
				num2 = coord;
				num3 = coord2;
				if (text.Length <= text2.Length)
				{
					stringBuilder.Append(text);
					char_0 = 'M';
				}
				else
				{
					stringBuilder.Append(text2);
					char_0 = 'm';
				}
				break;
			}
			case 1:
			{
				double coord = method_2(points[num].X);
				double coord2 = method_2(points[num].Y);
				num++;
				string text = ((char_0 == 'L') ? (method_4(coord) + method_4(coord2)) : $"L{method_3(coord)}{method_4(coord2)}");
				string text2 = ((char_0 == 'l') ? (method_4(coord) + method_4(coord2)) : $"l{method_3(coord)}{method_4(coord2)}");
				num2 = coord;
				num3 = coord2;
				if (text.Length <= text2.Length)
				{
					stringBuilder.Append(text);
					char_0 = 'L';
				}
				else
				{
					stringBuilder.Append(text2);
					char_0 = 'l';
				}
				break;
			}
			case 2:
			{
				double coord = method_2(points[num].X);
				double coord2 = method_2(points[num].Y);
				num++;
				double coord3 = method_2(points[num].X);
				double coord4 = method_2(points[num].Y);
				num++;
				string text = ((char_0 == 'Q') ? $"{method_4(coord)}{method_4(coord2)}{method_4(coord3)}{method_4(coord4)}" : $"Q{method_3(coord)}{method_4(coord2)}{method_4(coord3)}{method_4(coord4)}");
				string text2 = ((char_0 == 'q') ? $"{method_4(coord)}{method_4(coord2)}{method_4(coord3)}{method_4(coord4)}" : $"q{method_3(coord)}{method_4(coord2)}{method_4(coord3)}{method_4(coord4)}");
				num2 = coord3;
				num3 = coord4;
				if (text.Length <= text2.Length)
				{
					stringBuilder.Append(text);
					char_0 = 'Q';
				}
				else
				{
					stringBuilder.Append(text2);
					char_0 = 'q';
				}
				num += 2;
				break;
			}
			case 3:
			{
				double coord = method_2(points[num].X);
				double coord2 = method_2(points[num].Y);
				num++;
				double coord3 = method_2(points[num].X);
				double coord4 = method_2(points[num].Y);
				num++;
				double num4 = method_2(points[num].X);
				double num5 = method_2(points[num].Y);
				num++;
				string text = ((char_0 == 'C') ? $"{method_4(coord)}{method_4(coord2)}{method_4(coord3)}{method_4(coord4)}{method_4(num4)}{method_4(num5)}" : $"C{method_3(coord)}{method_4(coord2)}{method_4(coord3)}{method_4(coord4)}{method_4(num4)}{method_4(num5)}");
				string text2 = ((char_0 == 'c') ? $"{method_4(coord)}{method_4(coord2)}{method_4(coord3)}{method_4(coord4)}{method_4(num4)}{method_4(num5)}" : $"c{method_3(coord)}{method_4(coord2)}{method_4(coord3)}{method_4(coord4)}{method_4(num4)}{method_4(num5)}");
				num2 = num4;
				num3 = num5;
				if (text.Length <= text2.Length)
				{
					stringBuilder.Append(text);
					char_0 = 'C';
				}
				else
				{
					stringBuilder.Append(text2);
					char_0 = 'c';
				}
				break;
			}
			}
			if ((types[num - 1] & 0x80u) != 0)
			{
				stringBuilder.Append("z");
				char_0 = 'z';
			}
		}
		return stringBuilder;
	}

	private double method_2(double coord)
	{
		return Math.Round(coord * (double)int_0) / (double)int_0;
	}

	private string method_3(double coord)
	{
		return coord.ToString(iformatProvider_0);
	}

	private string method_4(double coord)
	{
		if (!(coord < 0.0))
		{
			return " " + coord.ToString(iformatProvider_0);
		}
		return coord.ToString(iformatProvider_0);
	}

	private static float smethod_4(PointF point1, PointF point2)
	{
		float num = point1.X - point2.X;
		float num2 = point1.Y - point2.Y;
		return num * num + num2 * num2;
	}
}
