using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns16;
using ns2;
using ns35;
using ns37;
using ns39;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct29
{
	internal static void smethod_0(Class740 chart, Rectangle rect, bool isDisplayAxisSameAsBar, Class784 renderContext)
	{
		if (smethod_7(chart))
		{
			return;
		}
		double num = (double)chart.DepthPercent / 100.0;
		double num2 = (double)chart.GapDepth / 100.0;
		double num3 = (double)chart.GapWidth / 100.0;
		int num4 = 0;
		int num5 = chart.NSeriesInternal.method_1();
		int num6 = chart.NSeriesInternal.Count;
		if (smethod_1(chart.Type))
		{
			num6 = 1;
		}
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			if (smethod_2(chart.Type))
			{
				if (!renderContext.X1AxisRenderContext.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
				{
					num4 = Struct21.smethod_35(renderContext.X1AxisRenderContext.Axis.BaseUnitScale, (int)renderContext.X1AxisRenderContext.MaxValue, (int)renderContext.X1AxisRenderContext.MinValue, chart.IsDate1904);
					if (num4 == 0)
					{
						num4 = 1;
					}
				}
				else
				{
					num4 = Struct21.smethod_35(renderContext.X1AxisRenderContext.Axis.BaseUnitScale, (int)renderContext.X1AxisRenderContext.MaxValue, (int)renderContext.X1AxisRenderContext.MinValue, chart.IsDate1904) + 1;
				}
			}
			else
			{
				num4 = Struct21.smethod_35(renderContext.X1AxisRenderContext.Axis.BaseUnitScale, (int)renderContext.X1AxisRenderContext.MaxValue, (int)renderContext.X1AxisRenderContext.MinValue, chart.IsDate1904) + 1;
			}
		}
		else if (smethod_2(chart.Type))
		{
			if (!renderContext.X1AxisRenderContext.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
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
		num7 = (smethod_8(chart) ? ((double)num4 / ((double)num6 * num)) : ((double)num4 * ((double)num6 + num3) / (num + num2 * num)));
		double num8 = Math.Abs(Math.Sin((double)chart.Elevation * Math.PI / 180.0));
		int num9 = chart.Rotation % 90;
		if (num9 >= 45)
		{
			num9 = 90 - num9;
		}
		double num10 = Math.Sin((double)num9 * Math.PI / 180.0);
		int num11 = chart.Rotation / 45;
		if (chart.AutoScaling)
		{
			float num12 = 1f;
			if (chart.NSeriesInternal.Count == 1 && (chart.Type == ChartType.Column3D || chart.Type == ChartType.Cone3D || chart.Type == ChartType.Cylinder3D || chart.Type == ChartType.Pyramid3D))
			{
				num12 = 0.67f;
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
				num13 = (double)rect.Width / (1.0 / num7 + num10);
				num15 = (double)(rect.Height * rect.Width) / ((double)rect.Width * num8 + (double)rect.Height);
				break;
			case 0:
			case 3:
			case 4:
			case 7:
			case 8:
				if (!isDisplayAxisSameAsBar)
				{
					num13 = (double)rect.Width / (1.0 + num10 / num7);
					num15 = (double)(rect.Height * rect.Width) / ((double)rect.Width * num8 / num7 + (double)rect.Height);
				}
				else
				{
					num13 = (double)(rect.Width * rect.Width) / ((double)rect.Height * num10 / num7 + (double)rect.Width);
					num15 = (double)rect.Width / (1.0 + num8 / num7);
				}
				break;
			}
			num14 = num13 * (double)rect.Height / (double)rect.Width;
			num16 = num15 * (double)rect.Height / (double)rect.Width;
			if (num14 < num16)
			{
				chart.WallsInternal.Width = (float)num13;
				chart.WallsInternal.Height = (float)num14;
			}
			else
			{
				chart.WallsInternal.Width = (float)num15;
				chart.WallsInternal.Height = (float)num16;
			}
			chart.WallsInternal.Height = chart.WallsInternal.Height * num12;
			chart.WallsInternal.Depth = ((!isDisplayAxisSameAsBar) ? ((float)((double)chart.WallsInternal.Width / num7)) : ((float)((double)chart.WallsInternal.Height / num7)));
			chart.WallsInternal.X = (float)rect.X + ((float)rect.Width - chart.WallsInternal.Width) / 2f;
			chart.WallsInternal.Y = (float)(rect.Y + rect.Height) - ((float)rect.Height - chart.WallsInternal.Height) / 2f;
			return;
		}
		double num17 = (double)chart.HeightPercent / 100.0;
		if (chart.NSeriesInternal.Count == 1 && (chart.Type == ChartType.Column3D || chart.Type == ChartType.Cone3D || chart.Type == ChartType.Cylinder3D || chart.Type == ChartType.Pyramid3D))
		{
			num17 *= 0.6700000166893005;
		}
		double num18 = 0.0;
		double num19 = 0.0;
		double num20 = 0.0;
		double num21 = 0.0;
		switch (num11)
		{
		case 1:
		case 2:
		case 5:
		case 6:
			num18 = (double)rect.Width / (1.0 / num7 + num10);
			num20 = (double)rect.Height / (num8 + num17);
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			if (!isDisplayAxisSameAsBar)
			{
				num18 = (double)rect.Width / (1.0 + num10 / num7);
				num20 = (double)rect.Height / (num17 + num8 / num7);
			}
			else
			{
				num18 = (double)rect.Width / (1.0 + num10 / num7 / num17);
				num20 = (double)rect.Height * num17 / (1.0 + num8 / num7);
			}
			break;
		}
		if (!isDisplayAxisSameAsBar)
		{
			num19 = num18 * num17;
			num21 = num20 * num17;
		}
		else
		{
			num19 = num18 / num17;
			num21 = num20 / num17;
		}
		if (num19 < num21)
		{
			chart.WallsInternal.Width = (float)num18;
			chart.WallsInternal.Height = (float)num19;
		}
		else
		{
			chart.WallsInternal.Width = (float)num20;
			chart.WallsInternal.Height = (float)num21;
		}
		chart.WallsInternal.Depth = ((!isDisplayAxisSameAsBar) ? ((float)((double)chart.WallsInternal.Width / num7)) : ((float)((double)chart.WallsInternal.Height / num7)));
		chart.WallsInternal.X = (float)rect.X + ((float)rect.Width - chart.WallsInternal.Width) / 2f;
		chart.WallsInternal.Y = (float)(rect.Y + rect.Height) - ((float)rect.Height - chart.WallsInternal.Height) / 2f;
	}

	private static bool smethod_1(ChartType type)
	{
		switch (type)
		{
		default:
			return false;
		case ChartType.StackedColumn3D:
		case ChartType.PercentsStackedColumn3D:
		case ChartType.StackedCylinder:
		case ChartType.PercentsStackedCylinder:
		case ChartType.StackedCone:
		case ChartType.PercentsStackedCone:
		case ChartType.StackedPyramid:
		case ChartType.PercentsStackedPyramid:
		case ChartType.StackedBar3D:
		case ChartType.PercentsStackedBar3D:
		case ChartType.StackedHorizontalCylinder:
		case ChartType.PercentsStackedHorizontalCylinder:
		case ChartType.StackedHorizontalCone:
		case ChartType.PercentsStackedHorizontalCone:
		case ChartType.StackedHorizontalPyramid:
		case ChartType.PercentsStackedHorizontalPyramid:
			return true;
		}
	}

	private static bool smethod_2(ChartType type)
	{
		switch (type)
		{
		default:
			return false;
		case ChartType.Line3D:
		case ChartType.Area3D:
		case ChartType.StackedArea3D:
		case ChartType.PercentsStackedArea3D:
			return true;
		}
	}

	internal static void smethod_3(Interface32 g, Class740 chart, bool isDisplayAxisSameAsBar, Class784 renderContext)
	{
		if (smethod_7(chart) || chart.PlotAreaInternal.method_16())
		{
			return;
		}
		float xCenter = chart.WallsInternal.xCenter;
		float y = chart.WallsInternal.Y;
		PointF pointF = new PointF(xCenter, y);
		int num = chart.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = chart.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = chart.WallsInternal.Depth;
			num4 = chart.WallsInternal.Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = chart.WallsInternal.Width;
			num4 = chart.WallsInternal.Depth;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)chart.Elevation * Math.PI / 180.0);
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
		array[4].Y = array[0].Y - chart.WallsInternal.Height;
		array[5].Y = array[1].Y - chart.WallsInternal.Height;
		array[6].Y = array[2].Y - chart.WallsInternal.Height;
		array[7].Y = array[3].Y - chart.WallsInternal.Height;
		PointF[] array2 = new PointF[6];
		float colorGene = 0.7f;
		if (isDisplayAxisSameAsBar)
		{
			if (chart.Elevation >= 0)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddPolygon(new PointF[4]
				{
					array[0],
					array[3],
					array[7],
					array[4]
				});
				chart.FloorInternal.AreaInternal.method_7(graphicsPath, colorGene);
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPolygon(new PointF[4]
			{
				array[0],
				array[1],
				array[2],
				array[3]
			});
			chart.SideWallsInternal.AreaInternal.method_7(graphicsPath2, colorGene);
			GraphicsPath graphicsPath3 = new GraphicsPath();
			graphicsPath3.AddPolygon(new PointF[4]
			{
				array[2],
				array[3],
				array[7],
				array[6]
			});
			chart.BackWallsInternal.AreaInternal.method_6(graphicsPath3);
			if (renderContext.Y1AxisRenderContext.Axis != null)
			{
				if (!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
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
				smethod_6(g, array2, renderContext.Y1AxisRenderContext);
			}
			if (renderContext.X1AxisRenderContext.Axis != null)
			{
				if (!renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
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
				smethod_6(g, array2, renderContext.X1AxisRenderContext);
			}
			smethod_5(g, chart, array, isDisplayAxisSameAsBar);
			chart.BackWallsInternal.BorderInternal.method_8(graphicsPath3);
			chart.SideWallsInternal.BorderInternal.method_8(graphicsPath2);
		}
		else
		{
			GraphicsPath graphicsPath4 = null;
			GraphicsPath graphicsPath5 = null;
			if (chart.Elevation > 0)
			{
				GraphicsPath graphicsPath6 = new GraphicsPath();
				graphicsPath6.AddPolygon(new PointF[4]
				{
					array[0],
					array[1],
					array[2],
					array[3]
				});
				chart.FloorInternal.AreaInternal.method_7(graphicsPath6, colorGene);
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
				chart.SideWallsInternal.AreaInternal.method_7(graphicsPath5, colorGene);
				graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddPolygon(new PointF[4]
				{
					array[0],
					array[1],
					array[5],
					array[4]
				});
				chart.BackWallsInternal.AreaInternal.method_6(graphicsPath4);
				if (renderContext.Y1AxisRenderContext.Axis != null)
				{
					if (!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						ref PointF reference97 = ref array2[0];
						reference97 = array[1];
						ref PointF reference98 = ref array2[1];
						reference98 = array[5];
						ref PointF reference99 = ref array2[2];
						reference99 = array[0];
						ref PointF reference100 = ref array2[3];
						reference100 = array[4];
						ref PointF reference101 = ref array2[4];
						reference101 = array[3];
						ref PointF reference102 = ref array2[5];
						reference102 = array[7];
					}
					else
					{
						ref PointF reference103 = ref array2[0];
						reference103 = array[5];
						ref PointF reference104 = ref array2[1];
						reference104 = array[1];
						ref PointF reference105 = ref array2[2];
						reference105 = array[4];
						ref PointF reference106 = ref array2[3];
						reference106 = array[0];
						ref PointF reference107 = ref array2[4];
						reference107 = array[7];
						ref PointF reference108 = ref array2[5];
						reference108 = array[3];
					}
					smethod_6(g, array2, renderContext.Y1AxisRenderContext);
				}
				if (renderContext.X1AxisRenderContext.Axis != null)
				{
					if (!renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
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
					smethod_6(g, array2, renderContext.X1AxisRenderContext);
				}
				if (renderContext.SeriesAxisRenderContext.Axis != null)
				{
					if (!renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
					{
						ref PointF reference121 = ref array2[0];
						reference121 = array[1];
						ref PointF reference122 = ref array2[1];
						reference122 = array[2];
						ref PointF reference123 = ref array2[2];
						reference123 = array[0];
						ref PointF reference124 = ref array2[3];
						reference124 = array[3];
						ref PointF reference125 = ref array2[4];
						reference125 = array[4];
						ref PointF reference126 = ref array2[5];
						reference126 = array[7];
					}
					else
					{
						ref PointF reference127 = ref array2[0];
						reference127 = array[2];
						ref PointF reference128 = ref array2[1];
						reference128 = array[1];
						ref PointF reference129 = ref array2[2];
						reference129 = array[3];
						ref PointF reference130 = ref array2[3];
						reference130 = array[0];
						ref PointF reference131 = ref array2[4];
						reference131 = array[7];
						ref PointF reference132 = ref array2[5];
						reference132 = array[4];
					}
					smethod_6(g, array2, renderContext.SeriesAxisRenderContext);
				}
				smethod_5(g, chart, array, isDisplayAxisSameAsBar);
				chart.BackWallsInternal.BorderInternal.method_8(graphicsPath4);
				chart.SideWallsInternal.BorderInternal.method_8(graphicsPath5);
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
				chart.BackWallsInternal.AreaInternal.method_6(graphicsPath4);
				graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddPolygon(new PointF[4]
				{
					array[1],
					array[2],
					array[6],
					array[5]
				});
				chart.SideWallsInternal.AreaInternal.method_7(graphicsPath5, colorGene);
				if (renderContext.Y1AxisRenderContext.Axis != null)
				{
					if (!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						ref PointF reference133 = ref array2[0];
						reference133 = array[0];
						ref PointF reference134 = ref array2[1];
						reference134 = array[4];
						ref PointF reference135 = ref array2[2];
						reference135 = array[1];
						ref PointF reference136 = ref array2[3];
						reference136 = array[5];
						ref PointF reference137 = ref array2[4];
						reference137 = array[2];
						ref PointF reference138 = ref array2[5];
						reference138 = array[6];
					}
					else
					{
						ref PointF reference139 = ref array2[0];
						reference139 = array[4];
						ref PointF reference140 = ref array2[1];
						reference140 = array[0];
						ref PointF reference141 = ref array2[2];
						reference141 = array[5];
						ref PointF reference142 = ref array2[3];
						reference142 = array[1];
						ref PointF reference143 = ref array2[4];
						reference143 = array[6];
						ref PointF reference144 = ref array2[5];
						reference144 = array[2];
					}
					smethod_6(g, array2, renderContext.Y1AxisRenderContext);
				}
				if (renderContext.X1AxisRenderContext.Axis != null)
				{
					if (!renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
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
					smethod_6(g, array2, renderContext.X1AxisRenderContext);
				}
				if (renderContext.SeriesAxisRenderContext.Axis != null)
				{
					if (!renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
					{
						ref PointF reference157 = ref array2[0];
						reference157 = array[3];
						ref PointF reference158 = ref array2[1];
						reference158 = array[0];
						ref PointF reference159 = ref array2[2];
						reference159 = array[2];
						ref PointF reference160 = ref array2[3];
						reference160 = array[1];
						ref PointF reference161 = ref array2[4];
						reference161 = array[6];
						ref PointF reference162 = ref array2[5];
						reference162 = array[5];
					}
					else
					{
						ref PointF reference163 = ref array2[0];
						reference163 = array[0];
						ref PointF reference164 = ref array2[1];
						reference164 = array[3];
						ref PointF reference165 = ref array2[2];
						reference165 = array[1];
						ref PointF reference166 = ref array2[3];
						reference166 = array[2];
						ref PointF reference167 = ref array2[4];
						reference167 = array[5];
						ref PointF reference168 = ref array2[5];
						reference168 = array[6];
					}
					smethod_6(g, array2, renderContext.SeriesAxisRenderContext);
				}
				smethod_5(g, chart, array, isDisplayAxisSameAsBar);
				chart.BackWallsInternal.BorderInternal.method_8(graphicsPath4);
				chart.SideWallsInternal.BorderInternal.method_8(graphicsPath5);
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
				chart.SideWallsInternal.AreaInternal.method_7(graphicsPath5, colorGene);
				graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddPolygon(new PointF[4]
				{
					array[2],
					array[3],
					array[7],
					array[6]
				});
				chart.BackWallsInternal.AreaInternal.method_6(graphicsPath4);
				if (renderContext.Y1AxisRenderContext.Axis != null)
				{
					if (!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
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
					smethod_6(g, array2, renderContext.Y1AxisRenderContext);
				}
				if (renderContext.X1AxisRenderContext.Axis != null)
				{
					if (!renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
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
					smethod_6(g, array2, renderContext.X1AxisRenderContext);
				}
				if (renderContext.SeriesAxisRenderContext.Axis != null)
				{
					if (!renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
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
					smethod_6(g, array2, renderContext.SeriesAxisRenderContext);
				}
				smethod_5(g, chart, array, isDisplayAxisSameAsBar);
				chart.BackWallsInternal.BorderInternal.method_8(graphicsPath4);
				chart.SideWallsInternal.BorderInternal.method_8(graphicsPath5);
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
				chart.SideWallsInternal.AreaInternal.method_7(graphicsPath5, colorGene);
				graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddPolygon(new PointF[4]
				{
					array[2],
					array[3],
					array[7],
					array[6]
				});
				chart.BackWallsInternal.AreaInternal.method_6(graphicsPath4);
				if (renderContext.Y1AxisRenderContext.Axis != null)
				{
					if (!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
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
					smethod_6(g, array2, renderContext.Y1AxisRenderContext);
				}
				if (renderContext.X1AxisRenderContext.Axis != null)
				{
					if (!renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
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
					smethod_6(g, array2, renderContext.X1AxisRenderContext);
				}
				if (renderContext.SeriesAxisRenderContext.Axis != null)
				{
					if (!renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
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
					smethod_6(g, array2, renderContext.SeriesAxisRenderContext);
				}
				smethod_5(g, chart, array, isDisplayAxisSameAsBar);
				chart.BackWallsInternal.BorderInternal.method_8(graphicsPath4);
				chart.SideWallsInternal.BorderInternal.method_8(graphicsPath5);
				break;
			}
		}
		int num7 = smethod_4(isDisplayAxisSameAsBar, renderContext.Y1AxisRenderContext);
		if (num7 != 0)
		{
			PointF[] array3 = Struct25.smethod_3(chart);
			if (isDisplayAxisSameAsBar)
			{
				renderContext.X1AxisRenderContext.method_3(array3[2].X + (float)num7, array3[2].Y, array3[2].X + (float)num7, array3[2].Y - chart.WallsInternal.Height);
			}
			else
			{
				renderContext.X1AxisRenderContext.method_3(array3[2].X, array3[2].Y - (float)num7, array3[3].X, array3[3].Y - (float)num7);
			}
		}
	}

	private static int smethod_4(bool isDisplayAxisSameAsBar, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		double logCrossAt = axisRenderContext.LogCrossAt;
		double logMaxValue = axisRenderContext.LogMaxValue;
		double logMinValue = axisRenderContext.LogMinValue;
		logCrossAt = (axisRenderContext.Axis.IsPlotOrderReversed ? (logMaxValue - logCrossAt) : (logCrossAt - logMinValue));
		float num = chart.WallsInternal.Height;
		if (isDisplayAxisSameAsBar)
		{
			num = chart.WallsInternal.Width;
		}
		return (int)(logCrossAt / (logMaxValue - logMinValue) * (double)num);
	}

	private static void smethod_5(Interface32 g, Class740 chart, PointF[] points, bool isDisplayAxisSameAsBar)
	{
		if (chart.Elevation > 0)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (isDisplayAxisSameAsBar)
			{
				graphicsPath.AddLine(points[0], points[3]);
				graphicsPath.AddLine(points[3], points[7]);
				graphicsPath.AddLine(points[7], points[4]);
				graphicsPath.AddLine(points[4], points[0]);
			}
			else
			{
				graphicsPath.AddLine(points[0], points[1]);
				graphicsPath.AddLine(points[1], points[2]);
				graphicsPath.AddLine(points[2], points[3]);
				graphicsPath.AddLine(points[3], points[0]);
			}
			chart.FloorInternal.BorderInternal.method_8(graphicsPath);
		}
	}

	private static void smethod_6(Interface32 g, PointF[] points, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		TimeUnitType baseUnitScale = axisRenderContext.Axis.BaseUnitScale;
		double logMaxValue = axisRenderContext.LogMaxValue;
		double logMinValue = axisRenderContext.LogMinValue;
		double num = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
		double num2 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MinorUnit) : axisRenderContext.MinorUnit);
		double num3 = ((axisRenderContext.AxisType != 0 || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2) ? (logMaxValue - logMinValue) : ((double)(Struct21.smethod_35(baseUnitScale, (int)logMaxValue, (int)logMinValue, chart.IsDate1904) + 1)));
		double num4 = (double)(points[1].X - points[0].X) / num3;
		double num5 = (double)(points[1].Y - points[0].Y) / num3;
		if (axisRenderContext.Axis.ShowMajorGridLines && num > 0.0)
		{
			double num6 = ((axisRenderContext.AxisType != 0 || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2) ? logMinValue : ((double)Struct21.smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)num, (int)logMinValue, chart.IsDate1904)));
			PointF pointF = Class782.smethod_2(points[0]);
			PointF pointF2 = Class782.smethod_2(points[2]);
			PointF pointF3 = Class782.smethod_2(points[4]);
			while (num6 <= logMaxValue || (axisRenderContext.AxisType == Enum160.const_0 && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2 && num6 <= logMaxValue))
			{
				double num7 = ((axisRenderContext.AxisType != 0 || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2) ? (num6 - logMinValue) : ((double)Struct21.smethod_35(baseUnitScale, (int)num6, (int)logMinValue, chart.IsDate1904)));
				pointF.X = points[0].X + (float)(num4 * num7);
				pointF.Y = points[0].Y + (float)(num5 * num7);
				pointF2.X = points[2].X + (float)(num4 * num7);
				pointF2.Y = points[2].Y + (float)(num5 * num7);
				pointF3.X = points[4].X + (float)(num4 * num7);
				pointF3.Y = points[4].Y + (float)(num5 * num7);
				axisRenderContext.method_4(pointF.X, pointF.Y, pointF2.X, pointF2.Y);
				axisRenderContext.method_4(pointF2.X, pointF2.Y, pointF3.X, pointF3.Y);
				num6 = ((axisRenderContext.AxisType != 0 || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2) ? (num6 + num) : ((double)Struct21.smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)num, (int)num6, chart.IsDate1904)));
			}
		}
		if (axisRenderContext.Axis.ShowMinorGridLines && num2 > 0.0)
		{
			double num8 = ((axisRenderContext.AxisType != 0 || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2) ? (logMinValue + num2) : ((double)Struct21.smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)num2, (int)logMinValue, chart.IsDate1904)));
			PointF pointF4 = Class782.smethod_2(points[0]);
			PointF pointF5 = Class782.smethod_2(points[2]);
			PointF pointF6 = Class782.smethod_2(points[4]);
			while (num8 <= logMaxValue || (axisRenderContext.AxisType == Enum160.const_0 && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2 && num8 <= logMaxValue))
			{
				double num9 = ((axisRenderContext.AxisType != 0 || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2) ? (num8 - logMinValue) : ((double)Struct21.smethod_35(baseUnitScale, (int)num8, (int)logMinValue, chart.IsDate1904)));
				pointF4.X = points[0].X + (float)(num4 * num9);
				pointF4.Y = points[0].Y + (float)(num5 * num9);
				pointF5.X = points[2].X + (float)(num4 * num9);
				pointF5.Y = points[2].Y + (float)(num5 * num9);
				pointF6.X = points[4].X + (float)(num4 * num9);
				pointF6.Y = points[4].Y + (float)(num5 * num9);
				axisRenderContext.method_5(pointF4.X, pointF4.Y, pointF5.X, pointF5.Y);
				axisRenderContext.method_5(pointF5.X, pointF5.Y, pointF6.X, pointF6.Y);
				num8 = ((axisRenderContext.AxisType != 0 || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2) ? (num8 + num2) : ((double)Struct21.smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)num2, (int)num8, chart.IsDate1904)));
			}
		}
	}

	private static bool smethod_7(Class740 chart)
	{
		ChartType type = chart.Type;
		if (type != ChartType.Pie3D && type != ChartType.ExplodedPie3D)
		{
			return false;
		}
		return true;
	}

	internal static bool smethod_8(Class740 chart)
	{
		switch (chart.Type)
		{
		default:
			return false;
		case ChartType.Column3D:
		case ChartType.Cylinder3D:
		case ChartType.Cone3D:
		case ChartType.Pyramid3D:
		case ChartType.Line3D:
		case ChartType.Area3D:
			return true;
		}
	}
}
