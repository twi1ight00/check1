using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using ns16;
using ns33;
using ns56;

namespace ns24;

internal class Class516
{
	public static readonly Class1151 class1151_0 = new Class1151("close", "moveTo", "lnTo", "arcTo", "quadBezTo", "cubicBezTo");

	private long[] long_0;

	private Enum115[] enum115_0;

	private long long_1;

	private long long_2;

	private Enum271 enum271_0 = Enum271.const_1;

	private bool bool_0 = true;

	private bool bool_1 = true;

	public long[] Data
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	public long Width
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	public long Height
	{
		get
		{
			return long_2;
		}
		set
		{
			long_2 = value;
		}
	}

	public bool ExtrusionOk
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Enum271 FillMode
	{
		get
		{
			return enum271_0;
		}
		set
		{
			enum271_0 = value;
		}
	}

	public bool Stroke
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Enum115[] Commands
	{
		get
		{
			return enum115_0;
		}
		set
		{
			enum115_0 = value;
		}
	}

	public Class516(List<int[]> odpPath, long width, long height)
	{
		enum115_0 = new Enum115[odpPath.Count];
		long_0 = new long[odpPath.Count * 2];
		int num = 0;
		int num2 = 0;
		int[] array = new int[2];
		for (int i = 0; i < odpPath.Count; i++)
		{
			if (i == 0)
			{
				enum115_0[num++] = Enum115.const_1;
			}
			else
			{
				enum115_0[num++] = Enum115.const_2;
			}
			array = odpPath[i];
			long_0[num2++] = array[0];
			long_0[num2++] = array[1];
		}
		long_1 = width;
		long_2 = height;
	}

	public string method_0(Class541[] geometryGuides, Class341[] adjValues, string[] modifiersOrder)
	{
		int num = 0;
		string text = "";
		Enum115[] array = enum115_0;
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case Enum115.const_0:
				text += " Z";
				break;
			case Enum115.const_1:
				text += " M";
				text = text + " " + Class342.smethod_1(long_0[num], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 1], geometryGuides, adjValues, modifiersOrder);
				num += 2;
				break;
			case Enum115.const_2:
				text += " L";
				text = text + " " + Class342.smethod_1(long_0[num], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 1], geometryGuides, adjValues, modifiersOrder);
				num += 2;
				break;
			case Enum115.const_3:
				num += 4;
				break;
			case Enum115.const_4:
				text += " Q";
				text = text + " " + Class342.smethod_1(long_0[num], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 1], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 2], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 3], geometryGuides, adjValues, modifiersOrder);
				num += 4;
				break;
			case Enum115.const_5:
				text += " C";
				text = text + " " + Class342.smethod_1(long_0[num], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 1], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 2], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 3], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 4], geometryGuides, adjValues, modifiersOrder);
				text = text + " " + Class342.smethod_1(long_0[num + 5], geometryGuides, adjValues, modifiersOrder);
				num += 6;
				break;
			}
		}
		return text.Trim();
	}

	public Class516(string odpPath, long width, long height)
	{
		MatchCollection matchCollection = Regex.Matches(odpPath, "[mMZzLlHhVvCcSsQqTtAa][ 0-9?f-]*");
		char[] separator = new char[2] { ' ', ',' };
		char[] array = new char[matchCollection.Count];
		string[][] array2 = new string[matchCollection.Count][];
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < matchCollection.Count; i++)
		{
			array[i] = matchCollection[i].Value[0];
			string text = matchCollection[i].Value.Remove(0, 1).Replace("-", " -").Trim();
			array2[i] = text.Split(separator);
			switch (array[i])
			{
			case 'H':
			case 'h':
				num += array2[i].Length;
				num2 += array2[i].Length * 2;
				break;
			case 'A':
			case 'a':
				num += array2[i].Length / 6;
				num2 += array2[i].Length / 3;
				break;
			case 'C':
			case 'c':
				num += array2[i].Length / 6;
				num2 += array2[i].Length;
				break;
			case 'Z':
			case 'z':
				num++;
				break;
			case 'L':
			case 'l':
				num += array2[i].Length / 2;
				num2 += array2[i].Length;
				break;
			case 'M':
			case 'm':
				num += array2[i].Length / 2;
				num2 += array2[i].Length;
				break;
			case 'Q':
			case 'q':
				num += array2[i].Length / 4;
				num2 += array2[i].Length;
				break;
			case 'S':
			case 's':
				num += array2[i].Length / 4;
				num2 += array2[i].Length + 2;
				break;
			case 'T':
			case 't':
				num += array2[i].Length / 2;
				num2 += array2[i].Length + 2;
				break;
			case 'V':
			case 'v':
				num += array2[i].Length;
				num2 += array2[i].Length * 2;
				break;
			}
		}
		long_0 = new long[num2];
		enum115_0 = new Enum115[num];
		num2 = 0;
		num = 0;
		long num3 = 0L;
		long num4 = 0L;
		for (int i = 0; i < matchCollection.Count; i++)
		{
			array[i] = matchCollection[i].Value[0];
			string text = matchCollection[i].Value.Remove(0, 1).Replace("-", " -").Trim();
			array2[i] = text.Split(separator);
			switch (array[i])
			{
			case 'H':
			case 'h':
			{
				for (int k = 0; k < array2[i].Length; k++)
				{
					enum115_0[num++] = Enum115.const_2;
					long_0[num2++] = Convert.ToInt64(array2[i][k]) + ((array[i] == 'H') ? 0L : num3);
					num3 = long_0[num2 - 1];
					long_0[num2++] = num4;
				}
				break;
			}
			case 'C':
			case 'c':
			{
				for (int num5 = 0; num5 < array2[i].Length; num5++)
				{
					if (num5 % 6 == 0)
					{
						enum115_0[num++] = Enum115.const_5;
						if (num5 != 0)
						{
							num3 = long_0[num2 - 2];
							num4 = long_0[num2 - 1];
						}
					}
					if (num5 % 2 == 0)
					{
						long_0[num2++] = Convert.ToInt64(array2[i][num5]) + ((array[i] == 'C') ? 0L : num3);
					}
					else
					{
						long_0[num2++] = Convert.ToInt64(array2[i][num5]) + ((array[i] == 'C') ? 0L : num4);
					}
				}
				num3 = long_0[num2 - 2];
				num4 = long_0[num2 - 1];
				break;
			}
			case 'Z':
			case 'z':
				num++;
				break;
			case 'L':
			case 'l':
			{
				for (int num6 = 0; num6 < array2[i].Length; num6++)
				{
					if (num6 % 2 == 0)
					{
						enum115_0[num++] = Enum115.const_2;
						long_0[num2++] = Convert.ToInt64(array2[i][num6]) + ((array[i] == 'L') ? 0L : num3);
						num3 = long_0[num2 - 1];
					}
					else
					{
						long_0[num2++] = Convert.ToInt64(array2[i][num6]) + ((array[i] == 'L') ? 0L : num4);
						num4 += Convert.ToInt64(array2[i][num6]);
					}
				}
				break;
			}
			case 'M':
			case 'm':
			{
				for (int m = 0; m < array2[i].Length; m++)
				{
					if (m % 2 == 0)
					{
						enum115_0[num++] = Enum115.const_1;
						long_0[num2++] = Convert.ToInt64(array2[i][m]) + ((array[i] == 'M') ? 0L : num3);
						num3 = long_0[num2 - 1];
					}
					else
					{
						long_0[num2++] = Convert.ToInt64(array2[i][m]) + ((array[i] == 'M') ? 0L : num4);
						num4 += Convert.ToInt64(array2[i][m]);
					}
				}
				break;
			}
			case 'Q':
			case 'q':
			{
				for (int num7 = 0; num7 < array2[i].Length; num7++)
				{
					if (num7 % 4 == 0)
					{
						enum115_0[num++] = Enum115.const_4;
						if (num7 != 0)
						{
							num3 = long_0[num2 - 2];
							num4 = long_0[num2 - 1];
						}
					}
					if (num7 % 2 == 0)
					{
						long_0[num2++] = Convert.ToInt64(array2[i][num7]) + ((array[i] == 'Q') ? 0L : num3);
					}
					else
					{
						long_0[num2++] = Convert.ToInt64(array2[i][num7]) + ((array[i] == 'Q') ? 0L : num4);
					}
				}
				num3 = long_0[num2 - 2];
				num4 = long_0[num2 - 1];
				break;
			}
			case 'S':
			case 's':
			{
				for (int n = 0; n < array2[i].Length; n++)
				{
					if (n % 4 == 0)
					{
						enum115_0[num++] = Enum115.const_5;
						long_0[num2++] = num3;
						long_0[num2++] = num4;
						if (n != 0)
						{
							num3 = long_0[num2 - 2];
							num4 = long_0[num2 - 1];
						}
					}
					if (n % 2 == 0)
					{
						long_0[num2++] = Convert.ToInt64(array2[i][n]) + ((array[i] == 'S') ? 0L : num3);
					}
					else
					{
						long_0[num2++] = Convert.ToInt64(array2[i][n]) + ((array[i] == 'S') ? 0L : num4);
					}
				}
				num3 = long_0[num2 - 2];
				num4 = long_0[num2 - 1];
				break;
			}
			case 'T':
			case 't':
			{
				for (int l = 0; l < array2[i].Length; l++)
				{
					if (l % 2 == 0)
					{
						enum115_0[num++] = Enum115.const_4;
						long_0[num2++] = num3;
						long_0[num2++] = num4;
						if (l != 0)
						{
							num3 = long_0[num2 - 2];
							num4 = long_0[num2 - 1];
						}
						long_0[num2++] = Convert.ToInt64(array2[i][l]) + ((array[i] == 'T') ? 0L : num3);
					}
					else
					{
						long_0[num2++] = Convert.ToInt64(array2[i][l]) + ((array[i] == 'T') ? 0L : num4);
					}
				}
				num3 = long_0[num2 - 2];
				num4 = long_0[num2 - 1];
				break;
			}
			case 'V':
			case 'v':
			{
				for (int j = 0; j < array2[i].Length; j++)
				{
					enum115_0[num++] = Enum115.const_2;
					long_0[num2++] = num3;
					long_0[num2++] = Convert.ToInt64(array2[i][j]) + ((array[i] == 'V') ? 0L : num4);
					num4 += Convert.ToInt64(array2[i][j]);
				}
				break;
			}
			}
		}
		long_1 = width;
		long_2 = height;
	}

	public Class516 method_1()
	{
		return new Class516(enum115_0, long_0, long_1, long_2, enum271_0, bool_0, bool_1);
	}

	public Class516(Enum115[] pathCommands, long[] pathData, long width, long height, Enum271 fillMode, bool stroke, bool extrusionOk)
	{
		long_1 = width;
		long_2 = height;
		enum115_0 = pathCommands;
		long_0 = pathData;
		enum271_0 = fillMode;
		bool_0 = stroke;
		bool_1 = extrusionOk;
	}

	public Class516(Enum115[] pathCommands, List<long> data, int startIndex, int length, long width, long height, Enum271 fillMode, bool stroke, bool extrusionOk)
	{
		long_1 = width;
		long_2 = height;
		enum115_0 = pathCommands;
		long_0 = new long[length];
		data.CopyTo(startIndex, long_0, 0, length);
		enum271_0 = fillMode;
		bool_0 = stroke;
		bool_1 = extrusionOk;
	}

	public Class516(Class1894 path2DElementData, Dictionary<string, int> namesToIndex, List<Class541> geomGuides)
	{
		int num = 0;
		int num2 = 0;
		Class2605[] path2DCommandList = path2DElementData.Path2DCommandList;
		foreach (Class2605 @class in path2DCommandList)
		{
			switch (@class.Name)
			{
			case "moveTo":
				num2 += 2;
				break;
			case "lnTo":
				num2 += 2;
				break;
			case "arcTo":
				num2 += 4;
				break;
			case "quadBezTo":
				num2 += 4;
				break;
			case "cubicBezTo":
				num2 += 6;
				break;
			}
			num++;
		}
		long_0 = new long[num2];
		enum115_0 = new Enum115[num];
		num = 0;
		num2 = 0;
		Class2605[] path2DCommandList2 = path2DElementData.Path2DCommandList;
		foreach (Class2605 class2 in path2DCommandList2)
		{
			Enum115 @enum = (Enum115)class1151_0[class2.Name];
			enum115_0[num++] = @enum;
			switch (@enum)
			{
			case Enum115.const_1:
			{
				Class1782 pt = ((Class1897)class2.Object).Pt;
				long_0[num2++] = smethod_0(pt.X, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(pt.Y, namesToIndex, geomGuides);
				break;
			}
			case Enum115.const_2:
			{
				Class1782 pt = ((Class1895)class2.Object).Pt;
				long_0[num2++] = smethod_0(pt.X, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(pt.Y, namesToIndex, geomGuides);
				break;
			}
			case Enum115.const_3:
			{
				Class1891 class5 = (Class1891)class2.Object;
				long_0[num2++] = smethod_0(class5.WR, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class5.HR, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class5.StAng, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class5.SwAng, namesToIndex, geomGuides);
				break;
			}
			case Enum115.const_4:
			{
				Class1898 class4 = (Class1898)class2.Object;
				long_0[num2++] = smethod_0(class4.Pt1.X, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class4.Pt1.Y, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class4.Pt2.X, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class4.Pt2.Y, namesToIndex, geomGuides);
				break;
			}
			case Enum115.const_5:
			{
				Class1893 class3 = (Class1893)class2.Object;
				long_0[num2++] = smethod_0(class3.Pt1.X, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class3.Pt1.Y, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class3.Pt2.X, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class3.Pt2.Y, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class3.Pt3.X, namesToIndex, geomGuides);
				long_0[num2++] = smethod_0(class3.Pt3.Y, namesToIndex, geomGuides);
				break;
			}
			}
		}
		long_1 = (long)(path2DElementData.W * 12700.0);
		long_2 = (long)(path2DElementData.H * 12700.0);
		enum271_0 = path2DElementData.Fill;
		bool_0 = path2DElementData.Stroke;
		bool_1 = path2DElementData.ExtrusionOk;
	}

	private static long smethod_0(string value, Dictionary<string, int> namesToIndex, List<Class541> geomGuides)
	{
		return Class342.smethod_0(value, namesToIndex, geomGuides);
	}

	public GraphicsPath method_2(Class342 geometry, double[] guideValues, Class342.Enum164[] guideValueFlags, float sx, float sy, float width, float height, out bool hasClosedFigures)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		double num = (double)sx / 12700.0;
		double num2 = (double)sy / 12700.0;
		int num3 = 0;
		float num4 = 0f;
		float num5 = 0f;
		long num6 = ((long_1 > 0L) ? long_1 : 1L);
		long num7 = ((long_2 > 0L) ? long_2 : 1L);
		double num8 = 7.874015748031496E-05;
		double num9 = 7.874015748031496E-05;
		if (long_1 > 0L)
		{
			num8 = width / (float)num6 / 12700f;
		}
		if (long_2 > 0L)
		{
			num9 = height / (float)num7 / 12700f;
		}
		hasClosedFigures = false;
		Enum115[] array = enum115_0;
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case Enum115.const_0:
				graphicsPath.CloseFigure();
				hasClosedFigures = true;
				break;
			case Enum115.const_1:
				graphicsPath.StartFigure();
				num4 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num8 + num);
				num5 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num9 + num2);
				break;
			case Enum115.const_2:
			{
				float x = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num8 + num);
				float y = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num9 + num2);
				graphicsPath.AddLine(num4, num5, x, y);
				num4 = x;
				num5 = y;
				break;
			}
			case Enum115.const_3:
			{
				float num12 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num8);
				float num13 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num9);
				float num14 = geometry.method_1(guideValues, guideValueFlags, long_0[num3++]);
				float num15 = geometry.method_1(guideValues, guideValueFlags, long_0[num3++]);
				if (!((double)(Math.Abs(num12) + Math.Abs(num13)) < 0.005))
				{
					num13 = ((num13 == 0f) ? 1E-05f : num13);
					num12 = ((num12 == 0f) ? 1E-05f : num12);
					double num16 = (double)(num14 / 180f) * Math.PI;
					if (num8 / num9 < 0.9999 || num8 / num9 > 1.0001)
					{
						double num17 = (double)((num14 + num15) / 180f) * Math.PI;
						double x3 = Math.Cos(num16) * num8;
						double y3 = Math.Sin(num16) * num9;
						num16 = Math.Atan2(y3, x3);
						num14 = (float)(num16 * 180.0 / Math.PI);
						x3 = Math.Cos(num17) * num8;
						y3 = Math.Sin(num17) * num9;
						num17 = Math.Atan2(y3, x3);
						float num18 = (float)(num17 * 180.0 / Math.PI) - num14;
						num15 = ((num15 < 0f && num18 > 0f) ? (num18 - 360f) : ((!(num15 > 0f) || !(num18 < 0f)) ? num18 : (num18 + 360f)));
					}
					double num19 = Math.Cos(num16);
					double num20 = Math.Sin(num16);
					double num21 = Math.Sqrt(1.0 / (num19 * num19 / (double)num12 / (double)num12 + num20 * num20 / (double)num13 / (double)num13));
					float x = (float)((double)num4 - num19 * num21);
					float y = (float)((double)num5 - num20 * num21);
					graphicsPath.AddArc(x - num12, y - num13, num12 * 2f, num13 * 2f, num14, num15);
					if (graphicsPath.PointCount < 2)
					{
						num5 = 0f;
						num4 = 0f;
					}
					else
					{
						PointF pointF = graphicsPath.PathPoints[graphicsPath.PointCount - 1];
						num4 = pointF.X;
						num5 = pointF.Y;
					}
				}
				break;
			}
			case Enum115.const_4:
			{
				float x = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num8 + num);
				float y = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num9 + num2);
				float x2 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num8 + num);
				float y2 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num9 + num2);
				graphicsPath.AddBezier(num4, num5, num4 + (x - num4) * 2f / 3f, num5 + (y - num5) * 2f / 3f, x2 + (x - x2) * 2f / 3f, y2 + (y - y2) * 2f / 3f, x2, y2);
				num4 = x2;
				num5 = y2;
				break;
			}
			case Enum115.const_5:
			{
				float x = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num8 + num);
				float y = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num9 + num2);
				float x2 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num8 + num);
				float y2 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num9 + num2);
				float num10 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num8 + num);
				float num11 = (float)((double)geometry.method_0(guideValues, guideValueFlags, long_0[num3++]) * num9 + num2);
				graphicsPath.AddBezier(num4, num5, x, y, x2, y2, num10, num11);
				num4 = num10;
				num5 = num11;
				break;
			}
			}
		}
		return graphicsPath;
	}

	public void method_3(List<Class541> geomGuides, Class342.Enum164[] geometryFlags)
	{
		int num = 0;
		Class519 @class = new Class519(long_1, long_2);
		Enum115[] array = enum115_0;
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case Enum115.const_1:
			case Enum115.const_2:
				long_0[num] = @class.method_0(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_1(geomGuides, long_0[num], geometryFlags);
				num++;
				break;
			case Enum115.const_3:
				long_0[num] = @class.method_2(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_3(geomGuides, long_0[num], geometryFlags);
				num++;
				num += 2;
				break;
			case Enum115.const_4:
				long_0[num] = @class.method_0(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_1(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_0(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_1(geomGuides, long_0[num], geometryFlags);
				break;
			case Enum115.const_5:
				long_0[num] = @class.method_0(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_1(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_0(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_1(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_0(geomGuides, long_0[num], geometryFlags);
				num++;
				long_0[num] = @class.method_1(geomGuides, long_0[num], geometryFlags);
				num++;
				break;
			}
		}
		long_2 = 0L;
		long_1 = 0L;
	}

	public Class516(string odpPath, long width, long height, Dictionary<string, int> namesToIndex, List<Class541> geomGuides, Dictionary<string, long> functionSum)
	{
		MatchCollection matchCollection = Regex.Matches(odpPath, "[ABCFLMNQSTUVWXYZ][^ABCFLMNQSTUVWXYZ]+");
		char[] separator = new char[2] { ' ', ',' };
		char[] array = new char[matchCollection.Count];
		string[][] array2 = new string[matchCollection.Count][];
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < matchCollection.Count; i++)
		{
			array[i] = matchCollection[i].Value[0];
			array2[i] = matchCollection[i].Value.Substring(1).Trim().Split(separator);
			switch (array[i])
			{
			case 'A':
				num += array2[i].Length / 8;
				num2 += array2[i].Length / 2;
				break;
			case 'B':
				num += array2[i].Length / 8;
				num2 += array2[i].Length / 2;
				break;
			case 'C':
				num += array2[i].Length / 6;
				num2 += array2[i].Length;
				break;
			case 'L':
				num += array2[i].Length / 2;
				num2 += array2[i].Length;
				break;
			case 'M':
				num += array2[i].Length / 2;
				num2 += array2[i].Length;
				break;
			case 'Q':
				num += array2[i].Length / 2;
				num2 += array2[i].Length;
				break;
			case 'T':
				num += array2[i].Length / 6;
				num2 += array2[i].Length - 2;
				break;
			case 'U':
				num += array2[i].Length / 6;
				num2 += array2[i].Length - 2;
				break;
			case 'V':
				num += array2[i].Length / 8;
				num2 += array2[i].Length / 2;
				break;
			case 'W':
				num += array2[i].Length / 8;
				num2 += array2[i].Length / 2;
				break;
			case 'X':
				num += array2[i].Length / 2;
				num2 += array2[i].Length * 2;
				break;
			case 'Y':
				num += array2[i].Length / 2;
				num2 += array2[i].Length * 2;
				break;
			case 'Z':
				num++;
				break;
			}
		}
		long_0 = new long[num2];
		enum115_0 = new Enum115[num];
		num2 = 0;
		num = 0;
		long num3 = 0L;
		long num4 = 0L;
		long num5 = 0L;
		long num6 = 0L;
		bool flag = false;
		long[] array3 = new long[4] { 16200000L, 16200000L, 5400000L, 5400000L };
		long[] array4 = new long[4] { 0L, 10800000L, 10800000L, 0L };
		long[] array5 = new long[8];
		int num7 = 0;
		for (int i = 0; i < matchCollection.Count; i++)
		{
			array[i] = matchCollection[i].Value[0];
			array2[i] = matchCollection[i].Value.Substring(1).Trim().Split(separator);
			switch (array[i])
			{
			case 'C':
			{
				for (int m = 0; m < array2[i].Length; m++)
				{
					if (m % 6 == 0)
					{
						enum115_0[num++] = Enum115.const_5;
					}
					long_0[num2++] = Class342.smethod_0(array2[i][m], namesToIndex, geomGuides);
				}
				break;
			}
			case 'L':
			{
				for (int num12 = 0; num12 < array2[i].Length; num12++)
				{
					char c = array2[i][num12][0];
					flag = c < '0' || c > '9';
					if (num12 % 2 == 0)
					{
						enum115_0[num++] = Enum115.const_2;
					}
					long_0[num2++] = Class342.smethod_0(array2[i][num12], namesToIndex, geomGuides);
					if (num12 % 2 == 0)
					{
						num6 = (flag ? functionSum[array2[i][num12]] : Convert.ToInt32(array2[i][num12]));
					}
					else
					{
						num5 = (flag ? functionSum[array2[i][num12]] : Convert.ToInt32(array2[i][num12]));
					}
				}
				break;
			}
			case 'M':
			{
				enum115_0[num++] = Enum115.const_1;
				for (int num14 = 0; num14 < array2[i].Length; num14++)
				{
					char c = array2[i][num14][0];
					flag = c < '0' || c > '9';
					if (num14 > 1 && num14 % 2 == 0)
					{
						enum115_0[num++] = Enum115.const_2;
					}
					long_0[num2++] = Class342.smethod_0(array2[i][num14], namesToIndex, geomGuides);
					if (num14 % 2 == 0)
					{
						num6 = (flag ? functionSum[array2[i][num14]] : Convert.ToInt32(array2[i][num14]));
					}
					else
					{
						num5 = (flag ? functionSum[array2[i][num14]] : Convert.ToInt32(array2[i][num14]));
					}
				}
				break;
			}
			case 'Q':
			{
				for (int num11 = 0; num11 < array2[i].Length; num11++)
				{
					if (num11 % 2 == 0)
					{
						enum115_0[num++] = Enum115.const_4;
					}
					long_0[num2++] = Class342.smethod_0(array2[i][num11], namesToIndex, geomGuides);
				}
				break;
			}
			case 'T':
			{
				for (int k = 0; k < array2[i].Length; k++)
				{
					if (k % 6 == 0)
					{
						enum115_0[num++] = Enum115.const_3;
						k += 2;
					}
					long_0[num2++] = Class342.smethod_0(array2[i][k], namesToIndex, geomGuides);
				}
				break;
			}
			case 'U':
			{
				for (int num13 = 0; num13 < array2[i].Length; num13++)
				{
					if (num13 % 6 == 0)
					{
						enum115_0[num++] = Enum115.const_3;
						num13 += 2;
					}
					long_0[num2++] = Class342.smethod_0(array2[i][num13], namesToIndex, geomGuides);
				}
				break;
			}
			case 'A':
			case 'B':
			case 'V':
			case 'W':
			{
				int num8 = 0;
				for (int n = 0; n < array2[i].Length; n++)
				{
					char c = array2[i][n][0];
					flag = c < '0' || c > '9';
					array5[num8++] = (flag ? functionSum[array2[i][n]] : Convert.ToInt32(array2[i][n]));
				}
				enum115_0[num++] = Enum115.const_3;
				int num9 = method_4(array5[0], array5[1], array5[2], array5[3], array5[4], array5[5]);
				int num10 = method_4(array5[0], array5[1], array5[2], array5[3], array5[6], array5[7]);
				long_0[num2++] = array5[2] - array5[0];
				long_0[num2++] = array5[3] - array5[1];
				long_0[num2++] = num9 * 60000;
				long_0[num2++] = (num10 - num9) * 60000;
				break;
			}
			case 'X':
			{
				for (int l = 0; l < array2[i].Length; l++)
				{
					char c = array2[i][l][0];
					flag = c < '0' || c > '9';
					if (l % 2 == 0)
					{
						num3 = (flag ? functionSum[array2[i][l]] : Convert.ToInt32(array2[i][l]));
						enum115_0[num++] = Enum115.const_3;
						num7++;
						long_0[num2++] = Math.Abs(num6 - num3);
					}
					else
					{
						num4 = (flag ? functionSum[array2[i][l]] : Convert.ToInt32(array2[i][l]));
						long_0[num2++] = Math.Abs(num5 - num4);
						long_0[num2++] = ((num7 <= 4) ? array3[num7 - 1] : array3[num7 % 4 - 1]);
						long_0[num2++] = ((num7 % 2 == 0) ? 5400000 : (-5400000));
					}
				}
				break;
			}
			case 'Y':
			{
				for (int j = 0; j < array2[i].Length; j++)
				{
					char c = array2[i][j][0];
					flag = c < '0' || c > '9';
					if (j % 2 == 0)
					{
						num3 = (flag ? functionSum[array2[i][j]] : Convert.ToInt32(array2[i][j]));
						enum115_0[num++] = Enum115.const_3;
						num7++;
						long_0[num2++] = Math.Abs(num6 - num3);
					}
					else
					{
						num4 = (flag ? functionSum[array2[i][j]] : Convert.ToInt32(array2[i][j]));
						long_0[num2++] = Math.Abs(num5 - num4);
						long_0[num2++] = ((num7 <= 4) ? array4[num7 - 1] : array4[num7 % 4 - 1]);
						long_0[num2++] = ((num7 % 2 == 0) ? (-5400000) : 5400000);
					}
				}
				break;
			}
			case 'Z':
				enum115_0[num++] = Enum115.const_0;
				break;
			}
		}
		long_1 = ((width != 0L) ? width : 21600L);
		long_2 = ((height != 0L) ? height : 21600L);
	}

	internal int method_4(long leftTopX, long leftTopY, long RightBottomX, long RightBottomY, long X, long Y)
	{
		int[] array = new int[4] { 0, -180, 180, -360 };
		X = Math.Abs(X);
		Y = Math.Abs(Y);
		int num = (int)Math.Round((double)(RightBottomX + leftTopX) / 2.0);
		int num2 = (int)Math.Round((double)(RightBottomY + leftTopY) / 2.0);
		int num3 = 0;
		if (X > num && Y >= num2)
		{
			num3 = 1;
		}
		else if (X <= num && Y > num2)
		{
			num3 = 2;
		}
		else if (X < num && Y <= num2)
		{
			num3 = 3;
		}
		else if (X >= num && Y < num2)
		{
			num3 = 4;
		}
		int num4 = (int)Math.Abs(Y - num2);
		int num5 = (int)Math.Abs(X - num);
		if (num3 == 1 && num4 == 0)
		{
			return 0;
		}
		if (num3 == 2 && num5 == 0)
		{
			return 90;
		}
		if (num3 == 3 && num4 == 0)
		{
			return 180;
		}
		if (num3 == 4 && num5 == 0)
		{
			return 270;
		}
		if (num5 == 0)
		{
			return 0;
		}
		return (int)Math.Abs(Math.Atan(num4 / num5) * 180.0 / Math.PI + (double)array[num3 - 1]);
	}
}
