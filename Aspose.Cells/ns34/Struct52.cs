using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns3;
using ns33;
using ns35;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct52
{
	internal static void smethod_0(Class821 class821_0, Rectangle rectangle_0, bool bool_0)
	{
		if (smethod_7(class821_0))
		{
			return;
		}
		double num = (double)class821_0.DepthPercent / 100.0;
		double num2 = (double)class821_0.GapDepth / 100.0;
		double num3 = (double)class821_0.GapWidth / 100.0;
		int num4 = 0;
		int num5 = class821_0.method_7().method_10();
		int num6 = class821_0.method_7().Count;
		if (smethod_1(class821_0.Type))
		{
			num6 = 1;
		}
		if (class821_0.method_1().CategoryType == Enum64.const_2)
		{
			if (smethod_2(class821_0.Type))
			{
				if (!class821_0.method_1().AxisBetweenCategories && !class821_0.IsDataTableShown)
				{
					num4 = Struct44.smethod_29(class821_0.method_1().BaseUnitScale, (int)class821_0.method_1().MaxValue, (int)class821_0.method_1().MinValue, class821_0.vmethod_0());
					if (num4 == 0)
					{
						num4 = 1;
					}
				}
				else
				{
					num4 = Struct44.smethod_29(class821_0.method_1().BaseUnitScale, (int)class821_0.method_1().MaxValue, (int)class821_0.method_1().MinValue, class821_0.vmethod_0()) + 1;
				}
			}
			else
			{
				num4 = Struct44.smethod_29(class821_0.method_1().BaseUnitScale, (int)class821_0.method_1().MaxValue, (int)class821_0.method_1().MinValue, class821_0.vmethod_0()) + 1;
			}
		}
		else if (smethod_2(class821_0.Type))
		{
			if (!class821_0.method_1().AxisBetweenCategories && !class821_0.IsDataTableShown)
			{
				num4 = num5 - 1;
				if (num4 == 0)
				{
					num4 = 1;
				}
			}
			else
			{
				num4 = num5;
			}
		}
		else
		{
			num4 = num5;
		}
		double num7 = 0.0;
		num7 = (smethod_8(class821_0) ? ((double)num4 / ((double)num6 * num)) : ((double)num4 * ((double)num6 + num3) / (num + num2 * num)));
		double num8 = Math.Abs(Math.Sin((double)class821_0.Elevation * Math.PI / 180.0));
		int num9 = class821_0.Rotation % 90;
		if (num9 >= 45)
		{
			num9 = 90 - num9;
		}
		double num10 = Math.Sin((double)num9 * Math.PI / 180.0);
		int num11 = class821_0.Rotation / 45;
		if (class821_0.AutoScaling)
		{
			float num12 = 1f;
			if (class821_0.method_7().Count == 1 && (class821_0.Type == ChartType_Chart.Column3D || class821_0.Type == ChartType_Chart.ConicalColumn3D || class821_0.Type == ChartType_Chart.CylindricalColumn3D || class821_0.Type == ChartType_Chart.PyramidColumn3D))
			{
				num12 = 0.67f;
			}
			if (class821_0.Type == ChartType_Chart.Area3D || class821_0.Type == ChartType_Chart.Area3D100PercentStacked || class821_0.Type == ChartType_Chart.Area3DStacked)
			{
				num12 = 0.65f;
			}
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			switch (num11)
			{
			case 1:
			case 2:
			case 5:
			case 6:
				num13 = (double)rectangle_0.Width / (1.0 / num7 + num10);
				num15 = (double)(rectangle_0.Height * rectangle_0.Width) / ((double)rectangle_0.Width * num8 + (double)rectangle_0.Height);
				break;
			case 0:
			case 3:
			case 4:
			case 7:
			case 8:
				if (!bool_0)
				{
					num13 = (double)rectangle_0.Width / (1.0 + num10 / num7);
					num15 = (double)(rectangle_0.Height * rectangle_0.Width) / ((double)rectangle_0.Width * num8 / num7 + (double)rectangle_0.Height);
				}
				else
				{
					num13 = (double)(rectangle_0.Width * rectangle_0.Width) / ((double)rectangle_0.Height * num10 / num7 + (double)rectangle_0.Width);
					num15 = (double)rectangle_0.Width / (1.0 + num8 / num7);
				}
				break;
			}
			num14 = num13 * (double)rectangle_0.Height / (double)rectangle_0.Width;
			num16 = num15 * (double)rectangle_0.Height / (double)rectangle_0.Width;
			if (num14 < num16)
			{
				class821_0.method_13().Width = (float)num13;
				class821_0.method_13().Height = (float)num14;
			}
			else
			{
				class821_0.method_13().Width = (float)num15;
				class821_0.method_13().Height = (float)num16;
			}
			class821_0.method_13().Height = class821_0.method_13().Height * num12;
			class821_0.method_13().Depth = ((!bool_0) ? ((float)((double)class821_0.method_13().Width / num7)) : ((float)((double)class821_0.method_13().Height / num7)));
			class821_0.method_13().X = (float)rectangle_0.X + ((float)rectangle_0.Width - class821_0.method_13().Width) / 2f;
			class821_0.method_13().Y = (float)(rectangle_0.Y + rectangle_0.Height) - ((float)rectangle_0.Height - class821_0.method_13().Height) / 2f;
			return;
		}
		double num17 = (double)class821_0.HeightPercent / 100.0;
		if (class821_0.method_7().Count == 1 && (class821_0.Type == ChartType_Chart.Column3D || class821_0.Type == ChartType_Chart.ConicalColumn3D || class821_0.Type == ChartType_Chart.CylindricalColumn3D || class821_0.Type == ChartType_Chart.PyramidColumn3D))
		{
			float num18 = 0.67f;
			num17 *= (double)num18;
		}
		if (class821_0.Type == ChartType_Chart.Area3D || class821_0.Type == ChartType_Chart.Area3D100PercentStacked || class821_0.Type == ChartType_Chart.Area3DStacked)
		{
			float num19 = 0.65f;
			num17 *= (double)num19;
		}
		double num20 = 0.0;
		double num21 = 0.0;
		double num22 = 0.0;
		double num23 = 0.0;
		switch (num11)
		{
		case 1:
		case 2:
		case 5:
		case 6:
			num20 = (double)rectangle_0.Width / (1.0 / num7 + num10);
			num22 = (double)rectangle_0.Height / (num8 + num17);
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			if (!bool_0)
			{
				num20 = (double)rectangle_0.Width / (1.0 + num10 / num7);
				num22 = (double)rectangle_0.Height / (num17 + num8 / num7);
			}
			else
			{
				num20 = (double)rectangle_0.Width / (1.0 + num10 / num7 / num17);
				num22 = (double)rectangle_0.Height * num17 / (1.0 + num8 / num7);
			}
			break;
		}
		if (!bool_0)
		{
			num21 = num20 * num17;
			num23 = num22 * num17;
		}
		else
		{
			num21 = num20 / num17;
			num23 = num22 / num17;
		}
		if (num21 < num23)
		{
			class821_0.method_13().Width = (float)num20;
			class821_0.method_13().Height = (float)num21;
		}
		else
		{
			class821_0.method_13().Width = (float)num22;
			class821_0.method_13().Height = (float)num23;
		}
		class821_0.method_13().Depth = ((!bool_0) ? ((float)((double)class821_0.method_13().Width / num7)) : ((float)((double)class821_0.method_13().Height / num7)));
		class821_0.method_13().X = (float)rectangle_0.X + ((float)rectangle_0.Width - class821_0.method_13().Width) / 2f;
		class821_0.method_13().Y = (float)rectangle_0.Bottom - ((float)rectangle_0.Height - class821_0.method_13().Height) / 2f;
	}

	private static bool smethod_1(ChartType_Chart chartType_Chart_0)
	{
		switch (chartType_Chart_0)
		{
		default:
			return false;
		case ChartType_Chart.Bar3DStacked:
		case ChartType_Chart.Bar3D100PercentStacked:
		case ChartType_Chart.Column3DStacked:
		case ChartType_Chart.Column3D100PercentStacked:
		case ChartType_Chart.ConeStacked:
		case ChartType_Chart.Cone100PercentStacked:
		case ChartType_Chart.ConicalBarStacked:
		case ChartType_Chart.ConicalBar100PercentStacked:
		case ChartType_Chart.CylinderStacked:
		case ChartType_Chart.Cylinder100PercentStacked:
		case ChartType_Chart.CylindricalBarStacked:
		case ChartType_Chart.CylindricalBar100PercentStacked:
		case ChartType_Chart.PyramidStacked:
		case ChartType_Chart.Pyramid100PercentStacked:
		case ChartType_Chart.PyramidBarStacked:
		case ChartType_Chart.PyramidBar100PercentStacked:
			return true;
		}
	}

	private static bool smethod_2(ChartType_Chart chartType_Chart_0)
	{
		switch (chartType_Chart_0)
		{
		default:
			return false;
		case ChartType_Chart.Area3D:
		case ChartType_Chart.Area3DStacked:
		case ChartType_Chart.Area3D100PercentStacked:
		case ChartType_Chart.Line3D:
			return true;
		}
	}

	internal static void smethod_3(Interface42 interface42_0, Class821 class821_0, bool bool_0)
	{
		if (smethod_7(class821_0) || class821_0.method_8().method_16())
		{
			return;
		}
		float x = class821_0.method_13().method_2();
		float y = class821_0.method_13().Y;
		PointF pointF = new PointF(x, y);
		int num = class821_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = class821_0.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = class821_0.method_13().Depth;
			num4 = class821_0.method_13().Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = class821_0.method_13().Width;
			num4 = class821_0.method_13().Depth;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)class821_0.Elevation * Math.PI / 180.0);
		PointF[] array = new PointF[8];
		switch (num2)
		{
		case 1:
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 2:
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 3:
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			break;
		case 4:
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			break;
		case 5:
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 6:
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 7:
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			break;
		case 0:
		case 8:
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[0].X + num5;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			break;
		}
		array[4].X = array[0].X;
		array[5].X = array[1].X;
		array[6].X = array[2].X;
		array[7].X = array[3].X;
		array[4].Y = array[0].Y - class821_0.method_13().Height;
		array[5].Y = array[1].Y - class821_0.method_13().Height;
		array[6].Y = array[2].Y - class821_0.method_13().Height;
		array[7].Y = array[3].Y - class821_0.method_13().Height;
		PointF[] array2 = new PointF[6];
		float float_ = 0.7f;
		if (bool_0)
		{
			if (class821_0.Elevation >= 0)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddPolygon(new PointF[4]
				{
					array[0],
					array[3],
					array[7],
					array[4]
				});
				class821_0.method_5().method_1().method_10(graphicsPath, float_);
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPolygon(new PointF[4]
			{
				array[0],
				array[1],
				array[2],
				array[3]
			});
			class821_0.method_14().method_1().method_10(graphicsPath2, float_);
			GraphicsPath graphicsPath3 = new GraphicsPath();
			graphicsPath3.AddPolygon(new PointF[4]
			{
				array[2],
				array[3],
				array[7],
				array[6]
			});
			class821_0.method_15().method_1().method_9(graphicsPath3);
			if (!class821_0.method_9().IsPlotOrderReversed)
			{
				ref PointF reference = ref array2[0];
				reference = array[0];
				ref PointF reference2 = ref array2[1];
				reference2 = array[1];
				ref PointF reference3 = ref array2[2];
				reference3 = array[3];
				ref PointF reference4 = ref array2[3];
				reference4 = array[2];
				ref PointF reference5 = ref array2[4];
				reference5 = array[7];
				ref PointF reference6 = ref array2[5];
				reference6 = array[6];
			}
			else
			{
				ref PointF reference7 = ref array2[0];
				reference7 = array[1];
				ref PointF reference8 = ref array2[1];
				reference8 = array[0];
				ref PointF reference9 = ref array2[2];
				reference9 = array[2];
				ref PointF reference10 = ref array2[3];
				reference10 = array[3];
				ref PointF reference11 = ref array2[4];
				reference11 = array[6];
				ref PointF reference12 = ref array2[5];
				reference12 = array[7];
			}
			smethod_6(interface42_0, class821_0.method_9(), array2);
			if (!class821_0.method_1().IsPlotOrderReversed)
			{
				ref PointF reference13 = ref array2[0];
				reference13 = array[0];
				ref PointF reference14 = ref array2[1];
				reference14 = array[4];
				ref PointF reference15 = ref array2[2];
				reference15 = array[3];
				ref PointF reference16 = ref array2[3];
				reference16 = array[7];
				ref PointF reference17 = ref array2[4];
				reference17 = array[2];
				ref PointF reference18 = ref array2[5];
				reference18 = array[6];
			}
			else
			{
				ref PointF reference19 = ref array2[0];
				reference19 = array[4];
				ref PointF reference20 = ref array2[1];
				reference20 = array[0];
				ref PointF reference21 = ref array2[2];
				reference21 = array[7];
				ref PointF reference22 = ref array2[3];
				reference22 = array[3];
				ref PointF reference23 = ref array2[4];
				reference23 = array[6];
				ref PointF reference24 = ref array2[5];
				reference24 = array[2];
			}
			smethod_6(interface42_0, class821_0.method_1(), array2);
			smethod_5(interface42_0, class821_0, array, bool_0);
			class821_0.method_15().method_0().method_11(graphicsPath3);
			class821_0.method_14().method_0().method_11(graphicsPath2);
		}
		else
		{
			GraphicsPath graphicsPath4 = null;
			GraphicsPath graphicsPath5 = null;
			if (class821_0.Elevation > 0)
			{
				GraphicsPath graphicsPath6 = new GraphicsPath();
				graphicsPath6.AddPolygon(new PointF[4]
				{
					array[0],
					array[1],
					array[2],
					array[3]
				});
				class821_0.method_5().method_1().method_10(graphicsPath6, float_);
			}
			switch (num2)
			{
			case 2:
			case 3:
				graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddPolygon(new PointF[4]
				{
					array[0],
					array[3],
					array[7],
					array[4]
				});
				class821_0.method_14().method_1().method_10(graphicsPath5, float_);
				graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddPolygon(new PointF[4]
				{
					array[0],
					array[1],
					array[5],
					array[4]
				});
				class821_0.method_15().method_1().method_9(graphicsPath4);
				if (!class821_0.method_9().IsPlotOrderReversed)
				{
					ref PointF reference133 = ref array2[0];
					reference133 = array[1];
					ref PointF reference134 = ref array2[1];
					reference134 = array[5];
					ref PointF reference135 = ref array2[2];
					reference135 = array[0];
					ref PointF reference136 = ref array2[3];
					reference136 = array[4];
					ref PointF reference137 = ref array2[4];
					reference137 = array[3];
					ref PointF reference138 = ref array2[5];
					reference138 = array[7];
				}
				else
				{
					ref PointF reference139 = ref array2[0];
					reference139 = array[5];
					ref PointF reference140 = ref array2[1];
					reference140 = array[1];
					ref PointF reference141 = ref array2[2];
					reference141 = array[4];
					ref PointF reference142 = ref array2[3];
					reference142 = array[0];
					ref PointF reference143 = ref array2[4];
					reference143 = array[7];
					ref PointF reference144 = ref array2[5];
					reference144 = array[3];
				}
				smethod_6(interface42_0, class821_0.method_9(), array2);
				if (!class821_0.method_1().IsPlotOrderReversed)
				{
					ref PointF reference145 = ref array2[0];
					reference145 = array[3];
					ref PointF reference146 = ref array2[1];
					reference146 = array[2];
					ref PointF reference147 = ref array2[2];
					reference147 = array[0];
					ref PointF reference148 = ref array2[3];
					reference148 = array[1];
					ref PointF reference149 = ref array2[4];
					reference149 = array[4];
					ref PointF reference150 = ref array2[5];
					reference150 = array[5];
				}
				else
				{
					ref PointF reference151 = ref array2[0];
					reference151 = array[2];
					ref PointF reference152 = ref array2[1];
					reference152 = array[3];
					ref PointF reference153 = ref array2[2];
					reference153 = array[1];
					ref PointF reference154 = ref array2[3];
					reference154 = array[0];
					ref PointF reference155 = ref array2[4];
					reference155 = array[5];
					ref PointF reference156 = ref array2[5];
					reference156 = array[4];
				}
				smethod_6(interface42_0, class821_0.method_1(), array2);
				if (!class821_0.method_11().IsPlotOrderReversed)
				{
					ref PointF reference157 = ref array2[0];
					reference157 = array[1];
					ref PointF reference158 = ref array2[1];
					reference158 = array[2];
					ref PointF reference159 = ref array2[2];
					reference159 = array[0];
					ref PointF reference160 = ref array2[3];
					reference160 = array[3];
					ref PointF reference161 = ref array2[4];
					reference161 = array[4];
					ref PointF reference162 = ref array2[5];
					reference162 = array[7];
				}
				else
				{
					ref PointF reference163 = ref array2[0];
					reference163 = array[2];
					ref PointF reference164 = ref array2[1];
					reference164 = array[1];
					ref PointF reference165 = ref array2[2];
					reference165 = array[3];
					ref PointF reference166 = ref array2[3];
					reference166 = array[0];
					ref PointF reference167 = ref array2[4];
					reference167 = array[7];
					ref PointF reference168 = ref array2[5];
					reference168 = array[4];
				}
				smethod_6(interface42_0, class821_0.method_11(), array2);
				smethod_5(interface42_0, class821_0, array, bool_0);
				class821_0.method_15().method_0().method_11(graphicsPath4);
				class821_0.method_14().method_0().method_11(graphicsPath5);
				break;
			case 4:
			case 5:
				graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddPolygon(new PointF[4]
				{
					array[0],
					array[1],
					array[5],
					array[4]
				});
				class821_0.method_15().method_1().method_9(graphicsPath4);
				graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddPolygon(new PointF[4]
				{
					array[1],
					array[2],
					array[6],
					array[5]
				});
				class821_0.method_14().method_1().method_10(graphicsPath5, float_);
				if (!class821_0.method_9().IsPlotOrderReversed)
				{
					ref PointF reference97 = ref array2[0];
					reference97 = array[0];
					ref PointF reference98 = ref array2[1];
					reference98 = array[4];
					ref PointF reference99 = ref array2[2];
					reference99 = array[1];
					ref PointF reference100 = ref array2[3];
					reference100 = array[5];
					ref PointF reference101 = ref array2[4];
					reference101 = array[2];
					ref PointF reference102 = ref array2[5];
					reference102 = array[6];
				}
				else
				{
					ref PointF reference103 = ref array2[0];
					reference103 = array[4];
					ref PointF reference104 = ref array2[1];
					reference104 = array[0];
					ref PointF reference105 = ref array2[2];
					reference105 = array[5];
					ref PointF reference106 = ref array2[3];
					reference106 = array[1];
					ref PointF reference107 = ref array2[4];
					reference107 = array[6];
					ref PointF reference108 = ref array2[5];
					reference108 = array[2];
				}
				smethod_6(interface42_0, class821_0.method_9(), array2);
				if (!class821_0.method_1().IsPlotOrderReversed)
				{
					ref PointF reference109 = ref array2[0];
					reference109 = array[3];
					ref PointF reference110 = ref array2[1];
					reference110 = array[2];
					ref PointF reference111 = ref array2[2];
					reference111 = array[0];
					ref PointF reference112 = ref array2[3];
					reference112 = array[1];
					ref PointF reference113 = ref array2[4];
					reference113 = array[4];
					ref PointF reference114 = ref array2[5];
					reference114 = array[5];
				}
				else
				{
					ref PointF reference115 = ref array2[0];
					reference115 = array[2];
					ref PointF reference116 = ref array2[1];
					reference116 = array[3];
					ref PointF reference117 = ref array2[2];
					reference117 = array[1];
					ref PointF reference118 = ref array2[3];
					reference118 = array[0];
					ref PointF reference119 = ref array2[4];
					reference119 = array[5];
					ref PointF reference120 = ref array2[5];
					reference120 = array[4];
				}
				smethod_6(interface42_0, class821_0.method_1(), array2);
				if (!class821_0.method_11().IsPlotOrderReversed)
				{
					ref PointF reference121 = ref array2[0];
					reference121 = array[3];
					ref PointF reference122 = ref array2[1];
					reference122 = array[0];
					ref PointF reference123 = ref array2[2];
					reference123 = array[2];
					ref PointF reference124 = ref array2[3];
					reference124 = array[1];
					ref PointF reference125 = ref array2[4];
					reference125 = array[6];
					ref PointF reference126 = ref array2[5];
					reference126 = array[5];
				}
				else
				{
					ref PointF reference127 = ref array2[0];
					reference127 = array[0];
					ref PointF reference128 = ref array2[1];
					reference128 = array[3];
					ref PointF reference129 = ref array2[2];
					reference129 = array[1];
					ref PointF reference130 = ref array2[3];
					reference130 = array[2];
					ref PointF reference131 = ref array2[4];
					reference131 = array[5];
					ref PointF reference132 = ref array2[5];
					reference132 = array[6];
				}
				smethod_6(interface42_0, class821_0.method_11(), array2);
				smethod_5(interface42_0, class821_0, array, bool_0);
				class821_0.method_15().method_0().method_11(graphicsPath4);
				class821_0.method_14().method_0().method_11(graphicsPath5);
				break;
			case 6:
			case 7:
				graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddPolygon(new PointF[4]
				{
					array[1],
					array[2],
					array[6],
					array[5]
				});
				class821_0.method_14().method_1().method_10(graphicsPath5, float_);
				graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddPolygon(new PointF[4]
				{
					array[2],
					array[3],
					array[7],
					array[6]
				});
				class821_0.method_15().method_1().method_9(graphicsPath4);
				if (!class821_0.method_9().IsPlotOrderReversed)
				{
					ref PointF reference61 = ref array2[0];
					reference61 = array[3];
					ref PointF reference62 = ref array2[1];
					reference62 = array[7];
					ref PointF reference63 = ref array2[2];
					reference63 = array[2];
					ref PointF reference64 = ref array2[3];
					reference64 = array[6];
					ref PointF reference65 = ref array2[4];
					reference65 = array[1];
					ref PointF reference66 = ref array2[5];
					reference66 = array[5];
				}
				else
				{
					ref PointF reference67 = ref array2[0];
					reference67 = array[7];
					ref PointF reference68 = ref array2[1];
					reference68 = array[3];
					ref PointF reference69 = ref array2[2];
					reference69 = array[6];
					ref PointF reference70 = ref array2[3];
					reference70 = array[2];
					ref PointF reference71 = ref array2[4];
					reference71 = array[5];
					ref PointF reference72 = ref array2[5];
					reference72 = array[1];
				}
				smethod_6(interface42_0, class821_0.method_9(), array2);
				if (!class821_0.method_1().IsPlotOrderReversed)
				{
					ref PointF reference73 = ref array2[0];
					reference73 = array[0];
					ref PointF reference74 = ref array2[1];
					reference74 = array[1];
					ref PointF reference75 = ref array2[2];
					reference75 = array[3];
					ref PointF reference76 = ref array2[3];
					reference76 = array[2];
					ref PointF reference77 = ref array2[4];
					reference77 = array[7];
					ref PointF reference78 = ref array2[5];
					reference78 = array[6];
				}
				else
				{
					ref PointF reference79 = ref array2[0];
					reference79 = array[1];
					ref PointF reference80 = ref array2[1];
					reference80 = array[0];
					ref PointF reference81 = ref array2[2];
					reference81 = array[2];
					ref PointF reference82 = ref array2[3];
					reference82 = array[3];
					ref PointF reference83 = ref array2[4];
					reference83 = array[6];
					ref PointF reference84 = ref array2[5];
					reference84 = array[7];
				}
				smethod_6(interface42_0, class821_0.method_1(), array2);
				if (!class821_0.method_11().IsPlotOrderReversed)
				{
					ref PointF reference85 = ref array2[0];
					reference85 = array[3];
					ref PointF reference86 = ref array2[1];
					reference86 = array[0];
					ref PointF reference87 = ref array2[2];
					reference87 = array[2];
					ref PointF reference88 = ref array2[3];
					reference88 = array[1];
					ref PointF reference89 = ref array2[4];
					reference89 = array[6];
					ref PointF reference90 = ref array2[5];
					reference90 = array[5];
				}
				else
				{
					ref PointF reference91 = ref array2[0];
					reference91 = array[0];
					ref PointF reference92 = ref array2[1];
					reference92 = array[3];
					ref PointF reference93 = ref array2[2];
					reference93 = array[1];
					ref PointF reference94 = ref array2[3];
					reference94 = array[2];
					ref PointF reference95 = ref array2[4];
					reference95 = array[5];
					ref PointF reference96 = ref array2[5];
					reference96 = array[6];
				}
				smethod_6(interface42_0, class821_0.method_11(), array2);
				smethod_5(interface42_0, class821_0, array, bool_0);
				class821_0.method_15().method_0().method_11(graphicsPath4);
				class821_0.method_14().method_0().method_11(graphicsPath5);
				break;
			case 0:
			case 1:
			case 8:
				graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddPolygon(new PointF[4]
				{
					array[0],
					array[3],
					array[7],
					array[4]
				});
				class821_0.method_14().method_1().method_10(graphicsPath5, float_);
				graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddPolygon(new PointF[4]
				{
					array[2],
					array[3],
					array[7],
					array[6]
				});
				class821_0.method_15().method_1().method_9(graphicsPath4);
				if (!class821_0.method_9().IsPlotOrderReversed)
				{
					ref PointF reference25 = ref array2[0];
					reference25 = array[0];
					ref PointF reference26 = ref array2[1];
					reference26 = array[4];
					ref PointF reference27 = ref array2[2];
					reference27 = array[3];
					ref PointF reference28 = ref array2[3];
					reference28 = array[7];
					ref PointF reference29 = ref array2[4];
					reference29 = array[2];
					ref PointF reference30 = ref array2[5];
					reference30 = array[6];
				}
				else
				{
					ref PointF reference31 = ref array2[0];
					reference31 = array[4];
					ref PointF reference32 = ref array2[1];
					reference32 = array[0];
					ref PointF reference33 = ref array2[2];
					reference33 = array[7];
					ref PointF reference34 = ref array2[3];
					reference34 = array[3];
					ref PointF reference35 = ref array2[4];
					reference35 = array[6];
					ref PointF reference36 = ref array2[5];
					reference36 = array[2];
				}
				smethod_6(interface42_0, class821_0.method_9(), array2);
				if (!class821_0.method_1().IsPlotOrderReversed)
				{
					ref PointF reference37 = ref array2[0];
					reference37 = array[0];
					ref PointF reference38 = ref array2[1];
					reference38 = array[1];
					ref PointF reference39 = ref array2[2];
					reference39 = array[3];
					ref PointF reference40 = ref array2[3];
					reference40 = array[2];
					ref PointF reference41 = ref array2[4];
					reference41 = array[7];
					ref PointF reference42 = ref array2[5];
					reference42 = array[6];
				}
				else
				{
					ref PointF reference43 = ref array2[0];
					reference43 = array[1];
					ref PointF reference44 = ref array2[1];
					reference44 = array[0];
					ref PointF reference45 = ref array2[2];
					reference45 = array[2];
					ref PointF reference46 = ref array2[3];
					reference46 = array[3];
					ref PointF reference47 = ref array2[4];
					reference47 = array[6];
					ref PointF reference48 = ref array2[5];
					reference48 = array[7];
				}
				smethod_6(interface42_0, class821_0.method_1(), array2);
				if (!class821_0.method_11().IsPlotOrderReversed)
				{
					ref PointF reference49 = ref array2[0];
					reference49 = array[1];
					ref PointF reference50 = ref array2[1];
					reference50 = array[2];
					ref PointF reference51 = ref array2[2];
					reference51 = array[0];
					ref PointF reference52 = ref array2[3];
					reference52 = array[3];
					ref PointF reference53 = ref array2[4];
					reference53 = array[4];
					ref PointF reference54 = ref array2[5];
					reference54 = array[7];
				}
				else
				{
					ref PointF reference55 = ref array2[0];
					reference55 = array[2];
					ref PointF reference56 = ref array2[1];
					reference56 = array[1];
					ref PointF reference57 = ref array2[2];
					reference57 = array[3];
					ref PointF reference58 = ref array2[3];
					reference58 = array[0];
					ref PointF reference59 = ref array2[4];
					reference59 = array[7];
					ref PointF reference60 = ref array2[5];
					reference60 = array[4];
				}
				smethod_6(interface42_0, class821_0.method_11(), array2);
				smethod_5(interface42_0, class821_0, array, bool_0);
				class821_0.method_15().method_0().method_11(graphicsPath4);
				class821_0.method_14().method_0().method_11(graphicsPath5);
				break;
			}
		}
		int num7 = smethod_4(class821_0.method_9(), bool_0);
		if (num7 != 0)
		{
			PointF[] array3 = Struct48.smethod_2(class821_0);
			if (bool_0)
			{
				class821_0.method_1().method_5().method_7(array3[2].X + (float)num7, array3[2].Y, array3[2].X + (float)num7, array3[2].Y - class821_0.method_13().Height);
			}
			else
			{
				class821_0.method_1().method_5().method_7(array3[2].X, array3[2].Y - (float)num7, array3[3].X, array3[3].Y - (float)num7);
			}
		}
	}

	private static int smethod_4(Class823 class823_0, bool bool_0)
	{
		Class821 chart = class823_0.Chart;
		double num = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.CrossAt) : class823_0.CrossAt);
		double num2 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
		double num3 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
		num = ((!class823_0.IsPlotOrderReversed) ? (num - num3) : (num2 - num));
		float num4 = chart.method_13().Height;
		if (bool_0)
		{
			num4 = chart.method_13().Width;
		}
		return (int)(num / (num2 - num3) * (double)num4);
	}

	private static void smethod_5(Interface42 interface42_0, Class821 class821_0, PointF[] pointF_0, bool bool_0)
	{
		if (class821_0.Elevation > 0)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (bool_0)
			{
				graphicsPath.AddLine(pointF_0[0], pointF_0[3]);
				graphicsPath.AddLine(pointF_0[3], pointF_0[7]);
				graphicsPath.AddLine(pointF_0[7], pointF_0[4]);
				graphicsPath.AddLine(pointF_0[4], pointF_0[0]);
			}
			else
			{
				graphicsPath.AddLine(pointF_0[0], pointF_0[1]);
				graphicsPath.AddLine(pointF_0[1], pointF_0[2]);
				graphicsPath.AddLine(pointF_0[2], pointF_0[3]);
				graphicsPath.AddLine(pointF_0[3], pointF_0[0]);
			}
			class821_0.method_5().method_0().method_11(graphicsPath);
		}
	}

	private static void smethod_6(Interface42 interface42_0, Class823 class823_0, PointF[] pointF_0)
	{
		Class821 chart = class823_0.Chart;
		Enum87 baseUnitScale = class823_0.BaseUnitScale;
		double num = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
		double num2 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
		double num3 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MajorUnit) : class823_0.MajorUnit);
		double num4 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinorUnit) : class823_0.MinorUnit);
		double num5 = ((class823_0.method_4() != 0 || class823_0.CategoryType != Enum64.const_2) ? (num - num2) : ((double)(Struct44.smethod_29(baseUnitScale, (int)num, (int)num2, chart.vmethod_0()) + 1)));
		double num6 = (double)(pointF_0[1].X - pointF_0[0].X) / num5;
		double num7 = (double)(pointF_0[1].Y - pointF_0[0].Y) / num5;
		if (class823_0.method_8().IsVisible && num3 > 0.0)
		{
			double num8 = ((class823_0.method_4() != 0 || class823_0.CategoryType != Enum64.const_2) ? num2 : ((double)Struct44.smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)num3, (int)num2, chart.vmethod_0())));
			PointF pointF_ = Class872.smethod_1(pointF_0[0]);
			PointF pointF = Class872.smethod_1(pointF_0[2]);
			PointF pointF_2 = Class872.smethod_1(pointF_0[4]);
			while (num8 <= num || (class823_0.method_4() == Enum61.const_0 && class823_0.CategoryType == Enum64.const_2 && num8 <= num))
			{
				double num9 = ((class823_0.method_4() != 0 || class823_0.CategoryType != Enum64.const_2) ? (num8 - num2) : ((double)Struct44.smethod_29(baseUnitScale, (int)num8, (int)num2, chart.vmethod_0())));
				pointF_.X = pointF_0[0].X + (float)(num6 * num9);
				pointF_.Y = pointF_0[0].Y + (float)(num7 * num9);
				pointF.X = pointF_0[2].X + (float)(num6 * num9);
				pointF.Y = pointF_0[2].Y + (float)(num7 * num9);
				pointF_2.X = pointF_0[4].X + (float)(num6 * num9);
				pointF_2.Y = pointF_0[4].Y + (float)(num7 * num9);
				class823_0.method_8().method_8(pointF_, pointF);
				class823_0.method_8().method_8(pointF, pointF_2);
				num8 = ((class823_0.method_4() != 0 || class823_0.CategoryType != Enum64.const_2) ? (num8 + num3) : ((double)Struct44.smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)num3, (int)num8, chart.vmethod_0())));
			}
		}
		if (class823_0.method_9().IsVisible && num4 > 0.0)
		{
			double num10 = ((class823_0.method_4() != 0 || class823_0.CategoryType != Enum64.const_2) ? (num2 + num4) : ((double)Struct44.smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)num4, (int)num2, chart.vmethod_0())));
			PointF pointF_3 = Class872.smethod_1(pointF_0[0]);
			PointF pointF2 = Class872.smethod_1(pointF_0[2]);
			PointF pointF_4 = Class872.smethod_1(pointF_0[4]);
			while (num10 <= num || (class823_0.method_4() == Enum61.const_0 && class823_0.CategoryType == Enum64.const_2 && num10 <= num))
			{
				double num11 = ((class823_0.method_4() != 0 || class823_0.CategoryType != Enum64.const_2) ? (num10 - num2) : ((double)Struct44.smethod_29(baseUnitScale, (int)num10, (int)num2, chart.vmethod_0())));
				pointF_3.X = pointF_0[0].X + (float)(num6 * num11);
				pointF_3.Y = pointF_0[0].Y + (float)(num7 * num11);
				pointF2.X = pointF_0[2].X + (float)(num6 * num11);
				pointF2.Y = pointF_0[2].Y + (float)(num7 * num11);
				pointF_4.X = pointF_0[4].X + (float)(num6 * num11);
				pointF_4.Y = pointF_0[4].Y + (float)(num7 * num11);
				class823_0.method_9().method_8(pointF_3, pointF2);
				class823_0.method_9().method_8(pointF2, pointF_4);
				num10 = ((class823_0.method_4() != 0 || class823_0.CategoryType != Enum64.const_2) ? (num10 + num4) : ((double)Struct44.smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)num4, (int)num10, class823_0.Chart.vmethod_0())));
			}
		}
	}

	private static bool smethod_7(Class821 class821_0)
	{
		ChartType_Chart type = class821_0.Type;
		if (type != ChartType_Chart.Pie3D && type != ChartType_Chart.Pie3DExploded)
		{
			return false;
		}
		return true;
	}

	internal static bool smethod_8(Class821 class821_0)
	{
		switch (class821_0.Type)
		{
		default:
			return false;
		case ChartType_Chart.Area3D:
		case ChartType_Chart.Column3D:
		case ChartType_Chart.ConicalColumn3D:
		case ChartType_Chart.CylindricalColumn3D:
		case ChartType_Chart.Line3D:
		case ChartType_Chart.PyramidColumn3D:
			return true;
		}
	}
}
