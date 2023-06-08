using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns19;
using ns5;

namespace ns4;

internal class Class14
{
	internal int[] int_0;

	private Class15 class15_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private Enum6 enum6_0;

	private Color color_0;

	private float float_0;

	private Color color_1;

	private bool bool_0;

	private bool bool_1;

	private float float_1;

	public float Rotation
	{
		set
		{
			float_1 = value;
		}
	}

	internal Class14(Enum6 enum6_1, int int_5, int int_6, int int_7, int int_8, Color color_2, float float_2, Color color_3, Class15 class15_1)
	{
		int_1 = int_5;
		int_2 = int_6;
		int_3 = int_7;
		int_4 = int_8;
		enum6_0 = enum6_1;
		color_0 = color_2;
		float_0 = float_2;
		color_1 = color_3;
		class15_0 = class15_1;
		if (class15_0 != null && class15_1.int_0 != null)
		{
			int_0 = (int[])class15_1.int_0.Clone();
		}
	}

	[SpecialName]
	internal Class15 method_0()
	{
		return class15_0;
	}

	[SpecialName]
	private int method_1()
	{
		int num = method_0().int_1;
		if (((uint)num & 0x80000000u) != 0 && num < -1073741824)
		{
			return (int)method_4((short)(num & 0xFFFF), method_9(), method_10());
		}
		return num;
	}

	[SpecialName]
	private int method_2()
	{
		int num = method_0().int_2;
		if (((uint)num & 0x80000000u) != 0 && num < -1073741824)
		{
			return (int)method_4((short)(num & 0xFFFF), method_9(), method_10());
		}
		return num;
	}

	private PointF[] method_3()
	{
		Point[] point_ = method_0().point_0;
		PointF[] array = new PointF[point_.Length];
		float float_ = method_9();
		float float_2 = method_10();
		for (int i = 0; i < point_.Length; i++)
		{
			Point point = point_[i];
			ref PointF reference = ref array[i];
			reference = new PointF(((point.X & int.MinValue) == 0 || point.X >= -1073741824) ? ((float)point.X) : method_4((short)(point.X & 0xFFFF), float_, float_2), ((point.Y & int.MinValue) == 0 || point.Y >= -1073741824) ? ((float)point.Y) : method_4((short)(point.Y & 0xFFFF), float_, float_2));
		}
		return array;
	}

	private float method_4(short short_0, float float_2, float float_3)
	{
		byte byte_ = 0;
		float num = method_0().method_0(short_0, int_0, ref byte_);
		if (float_2 > float_3)
		{
			float num2 = float_3 / float_2;
			if (((uint)byte_ & (true ? 1u : 0u)) != 0)
			{
				num = (((byte_ & 2u) != 0) ? ((num - 10800f) * num2 + 10800f) : (num * num2));
			}
			else if ((byte_ & 2u) != 0)
			{
				num = (float)method_1() - ((float)method_1() - num) * num2;
			}
		}
		else
		{
			float num3 = float_2 / float_3;
			if ((byte_ & 4u) != 0)
			{
				num = (((byte_ & 8u) != 0) ? ((num - 10800f) * num3 + 10800f) : (num * num3));
			}
			else if ((byte_ & 8u) != 0)
			{
				num = (float)method_2() - ((float)method_2() - num) * num3;
			}
		}
		return num;
	}

	private GraphicsPath method_5(ref Struct13 context, ushort[] segments, PointF[] points, out Struct13.Enum3 fillType, out Struct13.Enum4 strokeType, out bool useAsContour, out bool canCastShadow)
	{
		fillType = Struct13.Enum3.const_3;
		strokeType = Struct13.Enum4.const_1;
		useAsContour = false;
		canCastShadow = true;
		if (segments != null && segments.Length != 0)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int num = context.int_0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			int num2 = context.int_1;
			int num3 = context.int_1;
			int num4 = context.int_1;
			while (num < segments.Length)
			{
				try
				{
					ushort num5 = segments[num++];
					switch ((byte)(num5 >> 12))
					{
					case 0:
					{
						int num6 = num5 & 0xFFF;
						if (flag || graphicsPath.PointCount == 0)
						{
							num2++;
						}
						flag = false;
						num3 = num2 + num6;
						for (int i = 0; i < num6; i++)
						{
							graphicsPath.AddLine(points[num2 - 1], points[num2]);
							num2++;
						}
						break;
					}
					case 2:
					{
						int num6 = num5 & 0xFFF;
						if (flag || graphicsPath.PointCount == 0)
						{
							num2++;
						}
						flag = false;
						num3 = num2 + num6 * 3;
						for (int j = 0; j < num6; j++)
						{
							graphicsPath.AddBezier(points[num2 - 1], points[num2], points[num2 + 1], points[num2 + 2]);
							num2 += 3;
						}
						break;
					}
					case 4:
						if (flag)
						{
							num3++;
						}
						graphicsPath.StartFigure();
						flag2 = flag2 || flag3;
						flag3 = false;
						num4 = num2;
						flag = true;
						break;
					case 6:
						graphicsPath.CloseFigure();
						flag3 = true;
						if (graphicsPath.PointCount > 0)
						{
							flag2 = true;
						}
						break;
					case 8:
						if (graphicsPath.PointCount == 0)
						{
							break;
						}
						if (!flag3 && graphicsPath.PointCount > 1 && graphicsPath.PathPoints[graphicsPath.PointCount - 1] == points[num4])
						{
							flag3 = true;
							graphicsPath.CloseFigure();
						}
						flag2 = flag2 || flag3;
						if (!flag4)
						{
							switch (num5 & 0xF)
							{
							default:
								fillType = Struct13.Enum3.const_3;
								break;
							case 1:
								fillType = Struct13.Enum3.const_2;
								break;
							case 2:
								fillType = Struct13.Enum3.const_4;
								break;
							case 3:
								fillType = Struct13.Enum3.const_0;
								break;
							case 4:
								fillType = Struct13.Enum3.const_3;
								useAsContour = true;
								break;
							case 5:
								fillType = Struct13.Enum3.const_1;
								break;
							case 6:
								fillType = Struct13.Enum3.const_5;
								break;
							}
						}
						else
						{
							fillType = Struct13.Enum3.const_0;
						}
						if ((num5 & 0x10) == 0 && !flag5)
						{
							strokeType = (((num5 & 0x20) == 0) ? Struct13.Enum4.const_1 : Struct13.Enum4.const_2);
						}
						else
						{
							strokeType = Struct13.Enum4.const_0;
						}
						canCastShadow = (num5 & 0x100) == 0;
						context.int_1 = num3;
						context.int_0 = num;
						return graphicsPath;
					case 10:
					case 11:
					{
						int num6 = num5 & 0xFF;
						byte b = (byte)((num5 & 0xF00) >> 8);
						switch (b)
						{
						case 3:
						case 4:
						case 5:
							if (num6 == 0)
							{
								break;
							}
							num3 = num2 + num6;
							if (num6 == 2)
							{
								if (flag)
								{
									num2++;
									num3++;
									graphicsPath.AddLine(points[num2 - 1], points[num2 - 1]);
								}
								flag = false;
								graphicsPath.AddEllipse(points[num2].X, points[num2].Y, points[num2 + 1].X - points[num2].X, points[num2 + 1].Y - points[num2].Y);
								num2 += 2;
								flag3 = true;
								break;
							}
							if (num6 % 4 != 0)
							{
								throw new Exception("Invalid data autoshape segment" + num5);
							}
							if (flag)
							{
								num2++;
								num3++;
								graphicsPath.AddLine(points[num2 - 1], points[num2 - 1]);
							}
							flag = false;
							while (num6 > 0)
							{
								RectangleF rect = new RectangleF(points[num2].X, points[num2].Y, points[num2 + 1].X - points[num2].X, points[num2 + 1].Y - points[num2].Y);
								PointF pointF = points[num2 + 2];
								PointF pointF2 = points[num2 + 3];
								PointF pointF3 = new PointF(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
								float float_ = pointF.X - pointF3.X;
								float float_2 = pointF.Y - pointF3.Y;
								float num10 = smethod_0(float_, float_2);
								float_ = pointF2.X - pointF3.X;
								float_2 = pointF2.Y - pointF3.Y;
								float num11 = smethod_0(float_, float_2);
								float startAngle = num10;
								float num12 = num11 - num10;
								if (num12 < 0f)
								{
									num12 += 360f;
								}
								if (b != 5)
								{
									num12 -= 360f;
								}
								graphicsPath.AddArc(rect, startAngle, num12);
								num2 += 4;
								num6 -= 4;
							}
							break;
						default:
						{
							if (num6 == 0)
							{
								break;
							}
							if (flag || graphicsPath.PointCount == 0)
							{
								num2++;
							}
							flag = false;
							num3 = num2 + num6;
							bool flag6 = Math.Sign(points[num2].X - points[num2 - 1].X) == Math.Sign(points[num2].Y - points[num2 - 1].Y);
							int num7 = 0;
							while (num7 < num6)
							{
								PointF pt = points[num2 - 1];
								PointF pt2 = points[num2];
								float num8 = pt2.X - pt.X;
								float num9 = pt2.Y - pt.Y;
								bool flag7 = flag6 != (Math.Sign(num8) == Math.Sign(num9));
								if (b == 7)
								{
									flag7 = !flag7;
								}
								if (flag7)
								{
									graphicsPath.AddBezier(pt, new PointF(pt.X + num8 / 2f, pt.Y), new PointF(pt2.X, pt2.Y - num9 / 2f), pt2);
								}
								else
								{
									graphicsPath.AddBezier(pt, new PointF(pt.X, pt.Y + num9 / 2f), new PointF(pt2.X - num8 / 2f, pt2.Y), pt2);
								}
								num7++;
								num2++;
							}
							break;
						}
						case 10:
							flag4 = true;
							break;
						case 11:
							flag5 = true;
							break;
						}
						break;
					}
					case 1:
					case 3:
					case 5:
					case 7:
					case 9:
						break;
					}
				}
				catch (Exception)
				{
				}
				num2 = num3;
			}
			if (graphicsPath.PointCount > 0)
			{
				fillType = (flag2 ? Struct13.Enum3.const_3 : Struct13.Enum3.const_0);
				context.int_1 = points.Length;
				context.int_0 = segments.Length;
				return graphicsPath;
			}
			return null;
		}
		if (points != null && points.Length != 0 && context.int_0 == 0)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLines(points);
			graphicsPath.CloseFigure();
			context.int_0 = 1;
			context.int_1 = points.Length;
			return graphicsPath;
		}
		return null;
	}

	internal void Draw(Interface42 interface42_0, Class898 class898_0, RectangleF rectangleF_0)
	{
		interface42_0.imethod_55(SmoothingMode.HighQuality);
		new Pen(color_0, float_0);
		Pen pen = new Pen(color_0, float_0);
		pen.StartCap = LineCap.Flat;
		pen.EndCap = LineCap.Flat;
		new SolidBrush(color_1);
		new SolidBrush(Color.FromArgb(color_1.A, (int)((double)(int)color_1.R * 0.8 + 0.5), (int)((double)(int)color_1.G * 0.8 + 0.5), (int)((double)(int)color_1.B * 0.8 + 0.5)));
		new SolidBrush(Color.FromArgb(color_1.A, 255 - (int)((double)(255 - color_1.R) * 0.8 + 0.5), 255 - (int)((double)(255 - color_1.G) * 0.8 + 0.5), 255 - (int)((double)(255 - color_1.B) * 0.8 + 0.5)));
		new SolidBrush(Color.FromArgb(color_1.A, (int)((double)(int)color_1.R * 0.6 + 0.5), (int)((double)(int)color_1.G * 0.6 + 0.5), (int)((double)(int)color_1.B * 0.6 + 0.5)));
		new SolidBrush(Color.FromArgb(color_1.A, 255 - (int)((double)(255 - color_1.R) * 0.6 + 0.5), 255 - (int)((double)(255 - color_1.G) * 0.6 + 0.5), 255 - (int)((double)(255 - color_1.B) * 0.6 + 0.5)));
		try
		{
			ushort[] ushort_ = method_0().ushort_0;
			float num = method_1();
			float num2 = method_2();
			Matrix matrix = new Matrix();
			matrix.Translate(method_11(), method_12(), MatrixOrder.Prepend);
			matrix.Scale((float)method_9() / num, method_10() / num2, MatrixOrder.Prepend);
			PointF[] array = method_3();
			if (method_6() == Enum6.const_23)
			{
				method_8(array);
			}
			matrix.TransformPoints(array);
			ArrayList arrayList = new ArrayList();
			Struct13 context = new Struct13(0);
			while (true)
			{
				Struct13.Enum3 fillType;
				Struct13.Enum4 strokeType;
				bool useAsContour;
				bool canCastShadow;
				GraphicsPath graphicsPath = method_5(ref context, ushort_, array, out fillType, out strokeType, out useAsContour, out canCastShadow);
				if (graphicsPath == null)
				{
					break;
				}
				Brush brush_ = null;
				if (!color_1.IsEmpty)
				{
					switch (fillType)
					{
					case Struct13.Enum3.const_1:
						brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
						break;
					case Struct13.Enum3.const_2:
						brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
						break;
					default:
						brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
						break;
					case Struct13.Enum3.const_4:
						brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
						break;
					case Struct13.Enum3.const_5:
						brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
						break;
					case Struct13.Enum3.const_0:
						break;
					}
				}
				Pen pen_ = null;
				if (!color_0.IsEmpty)
				{
					switch (strokeType)
					{
					default:
						pen_ = Struct69.smethod_4(class898_0.Line);
						break;
					case Struct13.Enum4.const_2:
						pen_ = pen;
						break;
					case Struct13.Enum4.const_0:
						break;
					}
				}
				arrayList.Add(new Class16(graphicsPath, brush_, pen_, canCastShadow));
			}
			foreach (Class16 item in arrayList)
			{
				if (item.brush_0 != null)
				{
					interface42_0.imethod_33(item.brush_0, item.graphicsPath_0);
				}
			}
			foreach (Class16 item2 in arrayList)
			{
				if (item2.pen_0 != null)
				{
					interface42_0.imethod_18(item2.pen_0, item2.graphicsPath_0);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	[SpecialName]
	public Enum6 method_6()
	{
		return enum6_0;
	}

	[SpecialName]
	internal Class13 method_7()
	{
		if (int_0 == null)
		{
			return null;
		}
		return new Class13(this);
	}

	private static float smethod_0(float float_2, float float_3)
	{
		float num = (float)Class17.smethod_1(Math.Atan2(float_3, float_2));
		if (num < 0f)
		{
			num += 360f;
		}
		return num;
	}

	private void method_8(PointF[] pointF_0)
	{
		float num = method_7()[0] / 65536 % 360;
		float num2 = method_7()[1] / 65536 % 360;
		if (num < 0f)
		{
			num += 360f;
		}
		if (num2 < 0f)
		{
			num2 += 360f;
		}
		float val;
		float val2;
		float val3;
		float val4;
		if (num < num2)
		{
			val = ((!(num < 270f) || num2 <= 270f) ? Math.Min(pointF_0[2].Y, pointF_0[3].Y) : pointF_0[0].Y);
			val2 = ((!(num < 180f) || num2 <= 180f) ? Math.Min(pointF_0[2].X, pointF_0[3].X) : pointF_0[0].X);
			val3 = ((!(num < 90f) || num2 <= 90f) ? Math.Max(pointF_0[2].Y, pointF_0[3].Y) : pointF_0[1].Y);
			val4 = Math.Max(pointF_0[2].X, pointF_0[3].X);
		}
		else
		{
			val = ((num < 270f || num2 > 270f) ? pointF_0[0].Y : Math.Min(pointF_0[2].Y, pointF_0[3].Y));
			val2 = ((num < 180f || num2 > 180f) ? pointF_0[0].X : Math.Min(pointF_0[2].X, pointF_0[3].X));
			val3 = ((num < 90f || num2 > 90f) ? pointF_0[1].Y : Math.Max(pointF_0[2].Y, pointF_0[3].Y));
			val4 = pointF_0[1].X;
		}
		val = Math.Min(val, 10800f);
		val2 = Math.Min(val2, 10800f);
		val3 = Math.Max(val3, 10800f);
		val4 = Math.Max(val4, 10800f);
		float num3 = val4 - val2;
		float num4 = val3 - val;
		float x = pointF_0[1].X;
		float y = pointF_0[1].Y;
		if (!(num4 < 1f) && num3 >= 1f)
		{
			for (int i = 0; i < pointF_0.Length; i++)
			{
				pointF_0[i].X = (pointF_0[i].X - val2) / num3 * x;
				pointF_0[i].Y = (pointF_0[i].Y - val) / num4 * y;
			}
		}
	}

	[SpecialName]
	public int method_9()
	{
		return int_3;
	}

	[SpecialName]
	public float method_10()
	{
		return int_4;
	}

	[SpecialName]
	public float method_11()
	{
		return int_1;
	}

	[SpecialName]
	public float method_12()
	{
		return int_2;
	}

	[SpecialName]
	public void method_13(bool bool_2)
	{
		bool_1 = bool_2;
	}

	[SpecialName]
	public void method_14(bool bool_2)
	{
		bool_0 = bool_2;
	}
}
