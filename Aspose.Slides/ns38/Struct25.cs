using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns2;
using ns35;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct25
{
	private static int int_0 = Struct24.int_0;

	private static int int_1 = 3;

	internal static void smethod_0(Class740 chart, Chart sourceChart, Class784 renderContext)
	{
		Interface32 graphics = chart.Graphics;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		if (chart.NSeriesInternal.Count == 0 || Struct24.smethod_23(chart.NSeriesInternal.ListSeries) == 0)
		{
			return;
		}
		if (chart.NSeries.CategoryLabels.Count > 0)
		{
			chart.NSeriesInternal.bool_0 = true;
		}
		if (chart.NSeries.Category2Labels.Count > 0)
		{
			chart.NSeriesInternal.bool_1 = true;
		}
		chart.NSeriesInternal.Categories = Struct24.smethod_64(chart.NSeriesInternal.CategoryLabels);
		chart.NSeriesInternal.Categories2 = Struct24.smethod_64(chart.NSeriesInternal.Category2Labels);
		chart.NSeriesInternal.CategoryLabelsInternal = Struct24.smethod_65(chart.NSeriesInternal.CategoryLabels);
		chart.NSeriesInternal.Category2LabelsInternal = Struct24.smethod_65(chart.NSeriesInternal.Category2Labels);
		string text = Struct24.smethod_2(chart);
		if (text != "")
		{
			throw new ArgumentException(text);
		}
		smethod_2(chart);
		smethod_12(chart);
		Struct41.smethod_8(chart.NSeriesInternal, chart.NSeriesInternal.method_0(0), x1AxisRenderContext, y1AxisRenderContext);
		bool flag = Struct24.smethod_8(chart.Type);
		bool flag2 = Struct29.smethod_8(chart);
		Class759 aSeries = chart.NSeriesInternal.method_9()[0];
		if (flag)
		{
			if (chart.Elevation < 0)
			{
				chart.Elevation = 0;
			}
			if (chart.Elevation > 44)
			{
				chart.Elevation = 44;
			}
			if (chart.Rotation < 0)
			{
				chart.Rotation = 0;
			}
			if (chart.Rotation > 44)
			{
				chart.Rotation = 44;
			}
		}
		int num = Struct24.int_1;
		Rectangle rect = new Rectangle(int_0 + chart.Position.X, int_0 + chart.Position.Y, chart.Position.Width - int_0 * 2, chart.Position.Height - int_0 * 2);
		if (sourceChart.HasTitle)
		{
			SizeF layoutArea = new SizeF((float)rect.Width * 0.8f, (float)rect.Height * 0.8f);
			Size size = renderContext.ChartTitleRenderContext.method_0(layoutArea, graphics);
			renderContext.ChartTitleRenderContext.rectangle_0 = new Rectangle((chart.Position.Width - size.Width) / 2, int_0, size.Width, size.Height);
			rect.Y += size.Height + num;
			rect.Height -= size.Height + num;
		}
		Struct24.smethod_6(chart);
		if (sourceChart.HasLegend)
		{
			if (chart.Type != ChartType.ExplodedPie3D && chart.Type != ChartType.Pie3D && !renderContext.LegendRenderContext.IsRenderedLegendByPoint)
			{
				Struct31.smethod_18(graphics, ref rect, (Legend)sourceChart.Legend, renderContext);
			}
			else
			{
				Class759 aSeries2 = chart.NSeriesInternal.method_9()[0];
				Struct31.smethod_17(graphics, aSeries2, ref rect, (Legend)sourceChart.Legend, renderContext);
			}
		}
		Struct29.smethod_0(chart, rect, flag, renderContext);
		Rectangle rectOriginal = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		if (x1AxisRenderContext.Axis != null && x1AxisRenderContext.Axis.HasTitle && x1AxisRenderContext.Axis.IsVisible)
		{
			smethod_8(x1AxisRenderContext, graphics, rectOriginal, ref rect, flag, renderContext);
		}
		if (y1AxisRenderContext.Axis != null && y1AxisRenderContext.Axis.HasTitle && y1AxisRenderContext.Axis.IsVisible)
		{
			smethod_8(y1AxisRenderContext, graphics, rectOriginal, ref rect, flag, renderContext);
		}
		Struct35.smethod_0(chart, ref rect, aSeries);
		chart.PlotAreaInternal.rectangle_1 = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		if (!chart.PlotAreaInternal.IsSizeAuto)
		{
			if (chart.PlotAreaInternal.Width + chart.PlotAreaInternal.X > 4000)
			{
				chart.PlotAreaInternal.Width = 4000 - chart.PlotAreaInternal.X;
			}
			if (chart.PlotAreaInternal.Height + chart.PlotAreaInternal.Y > 4000)
			{
				chart.PlotAreaInternal.Height = 4000 - chart.PlotAreaInternal.Y;
			}
			rect.X = chart.PlotAreaInternal.method_4();
			rect.Y = chart.PlotAreaInternal.method_5();
			rect.Width = chart.PlotAreaInternal.method_2();
			rect.Height = chart.PlotAreaInternal.method_3();
			if (rect.Right > chart.Width)
			{
				rect.Width = chart.Width - rect.X;
			}
			if (rect.Bottom > chart.Height)
			{
				rect.Height = chart.Height - rect.Y;
			}
		}
		chart.PlotAreaInternal.rectangle_1 = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		Struct24.smethod_24(nSeriesInternal.ListSeries, out var minValue, out var maxValue, y1AxisRenderContext);
		bool flag3 = y1AxisRenderContext.Axis == null || y1AxisRenderContext.IsAutoMajorUnit;
		bool isAutoMinorUnit = y1AxisRenderContext.Axis == null || y1AxisRenderContext.IsAutoMinorUnit;
		Struct24.smethod_33(graphics, maxValue, minValue, y1AxisRenderContext.arrayList_0, chart.Type, rect, flag, nSeriesInternal.method_0(0), renderContext.Y1AxisRenderContext);
		Struct24.smethod_46(graphics, x1AxisRenderContext.arrayList_0, rect, chart.Type, nSeriesInternal, flag, x1AxisRenderContext);
		if (flag2)
		{
			smethod_11(chart, renderContext);
		}
		if (!Struct41.smethod_21(rect))
		{
			rect.X += int_1;
			rect.Y += int_1;
			rect.Width -= 2 * int_1;
			rect.Height -= 2 * int_1;
			Struct29.smethod_0(chart, rect, flag, renderContext);
		}
		if (renderContext.SeriesAxisRenderContext.Axis != null && flag2 && renderContext.SeriesAxisRenderContext.Axis.HasTitle && renderContext.SeriesAxisRenderContext.Axis.IsVisible)
		{
			smethod_9(renderContext.SeriesAxisRenderContext, graphics, ref rect, renderContext);
		}
		bool flag4 = false;
		int num2 = chart.Rotation / 45;
		Class786 dataTableRenderContext = renderContext.DataTableRenderContext;
		if (!Struct41.smethod_21(rect) && renderContext.Chart.HasDataTable)
		{
			Size size3 = (dataTableRenderContext.LegendSize = Struct26.smethod_4(graphics, renderContext));
			int num4 = (dataTableRenderContext.CategoryLabelHeight = Struct26.smethod_6(graphics, rect, renderContext));
			int num5 = size3.Height + num4;
			dataTableRenderContext.rectangle_1.Height = num5;
			if (chart.Elevation > 0 && !flag)
			{
				switch (num2)
				{
				case 1:
				case 2:
				case 5:
				case 6:
					if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
					{
						dataTableRenderContext.rectangle_1.X = rect.X + size3.Width;
						dataTableRenderContext.rectangle_1.Y = rect.Bottom;
						dataTableRenderContext.rectangle_1.Width = rect.Width - size3.Width;
						rect.Height += num5;
					}
					else
					{
						rect.Height -= num5;
						dataTableRenderContext.rectangle_1.X = rect.X + size3.Width;
						dataTableRenderContext.rectangle_1.Y = rect.Bottom;
						dataTableRenderContext.rectangle_1.Width = rect.Width - size3.Width;
					}
					break;
				case 0:
				case 3:
				case 4:
				case 7:
				case 8:
					if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
					{
						rect.Height += num5 + int_1;
						rect.X -= size3.Width;
						rect.Width += size3.Width;
					}
					else
					{
						rect.Height -= num5 + int_1;
						rect.X += size3.Width;
						rect.Width -= size3.Width;
					}
					break;
				}
			}
			else if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
			{
				dataTableRenderContext.rectangle_1.X = rect.X + size3.Width;
				dataTableRenderContext.rectangle_1.Y = rect.Bottom;
				dataTableRenderContext.rectangle_1.Width = rect.Width - size3.Width;
				rect.Height += num5;
			}
			else
			{
				rect.Height -= num5;
				dataTableRenderContext.rectangle_1.X = rect.X + size3.Width;
				dataTableRenderContext.rectangle_1.Y = rect.Bottom;
				dataTableRenderContext.rectangle_1.Width = rect.Width - size3.Width;
			}
			if (chart.PlotAreaInternal.IsSizeAuto || !chart.IsInnerMode)
			{
				Struct29.smethod_0(chart, rect, flag, renderContext);
			}
		}
		int num6 = chart.NSeriesInternal.method_1();
		Size size4 = Struct21.smethod_48(graphics, renderContext.SeriesAxisRenderContext.arrayList_0, rect, renderContext.SeriesAxisRenderContext);
		int num7 = renderContext.SeriesAxisRenderContext.TickLabelsOffset * chart.Position.Height / 4000;
		if (!Struct41.smethod_21(rect) && renderContext.SeriesAxisRenderContext.Axis != null && renderContext.SeriesAxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && renderContext.SeriesAxisRenderContext.Axis.IsVisible)
		{
			Size size5 = new Size(0, 0);
			if (renderContext.SeriesAxisRenderContext.AxisTitleRenderContext != null)
			{
				size5 = renderContext.SeriesAxisRenderContext.AxisTitleRenderContext.rectangle_0.Size;
			}
			if (!flag)
			{
				PointF[] array = smethod_4(chart);
				int num8 = 0;
				if (array[0].Y < array[1].Y)
				{
					num8 = 1;
				}
				float num9 = Math.Abs((array[1].Y - array[0].Y) / (float)num6);
				int num10 = size4.Height + num7;
				if (chart.Elevation > 0)
				{
					if (array[0].Y == array[1].Y)
					{
						if (rect.Bottom - size5.Height - (int)array[0].Y < num10)
						{
							if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
							{
								rect.Height += num10 - (rect.Bottom - size5.Height - (int)array[0].Y);
							}
							else
							{
								rect.Height -= num10 - (rect.Bottom - size5.Height - (int)array[0].Y);
							}
						}
					}
					else
					{
						Size size6 = size4;
						if (renderContext.X1AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
						{
							size6.Width += num7;
						}
						int num11 = size5.Width + smethod_7(chart, size6);
						switch (num2)
						{
						case 3:
						case 7:
							if ((int)Math.Abs(array[0].X + array[1].X) / 2 - rect.X < num11)
							{
								int num13 = num11 - ((int)Math.Abs(array[0].X + array[1].X) / 2 - rect.X);
								if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
								{
									rect.X -= num13;
									rect.Width += num13;
								}
								else
								{
									rect.X += num13;
									rect.Width -= num13;
								}
							}
							break;
						case 0:
						case 4:
						case 8:
							if (rect.Right - (int)Math.Abs(array[0].X + array[1].X) / 2 < num11)
							{
								int num12 = num11 - (rect.Right - (int)Math.Abs(array[0].X + array[1].X) / 2);
								if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
								{
									rect.Width += num12;
								}
								else
								{
									rect.Width -= num12;
								}
							}
							break;
						}
						float num14 = num9 * (float)Math.Sin((double)chart.Elevation * Math.PI / 180.0);
						if ((int)((float)rect.Bottom - array[num8].Y + num14) < size4.Height)
						{
							if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
							{
								rect.Height += size4.Height - (int)((float)rect.Bottom - array[num8].Y + num14);
							}
							else
							{
								rect.Height -= size4.Height - (int)((float)rect.Bottom - array[num8].Y + num14);
							}
						}
					}
				}
			}
			else
			{
				PointF pointF = smethod_5(chart);
				int num15 = size4.Width + num7;
				int num16 = (int)(pointF.X - (float)rect.X);
				if (num16 < num15)
				{
					if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
					{
						rect.X -= num15;
						rect.Width += num15;
					}
					else
					{
						rect.X += num15;
						rect.Width -= num15;
					}
				}
			}
			if (chart.PlotAreaInternal.IsSizeAuto || !chart.IsInnerMode)
			{
				Struct29.smethod_0(chart, rect, isDisplayAxisSameAsBar: false, renderContext);
			}
		}
		Size yLabelSize = Struct21.smethod_21(y1AxisRenderContext, graphics, nSeriesInternal.method_0(0), flag);
		if (y1AxisRenderContext.Axis != null && !Struct41.smethod_21(rect) && y1AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && y1AxisRenderContext.Axis.IsVisible)
		{
			if (!flag)
			{
				PointF pointF2 = smethod_5(chart);
				if (pointF2.X < chart.WallsInternal.xCenter)
				{
					int num17 = (int)(pointF2.X - (float)rect.X);
					if (!flag4 && y1AxisRenderContext.AxisTitleRenderContext != null)
					{
						num17 -= y1AxisRenderContext.AxisTitleRenderContext.rectangle_0.Size.Width;
					}
					int num18 = yLabelSize.Width;
					if (renderContext.Chart.HasDataTable)
					{
						num18 -= dataTableRenderContext.LegendSize.Width;
					}
					if (num17 < num18)
					{
						if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
						{
							rect.X -= num18;
							rect.Width += num18;
						}
						else
						{
							rect.X += num18;
							rect.Width -= num18;
						}
					}
				}
				else
				{
					int num19 = (int)((float)rect.Right - pointF2.X);
					if (num19 < yLabelSize.Width)
					{
						if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
						{
							rect.Width += yLabelSize.Width;
						}
						else
						{
							rect.Width -= yLabelSize.Width;
						}
					}
				}
				if (chart.Elevation >= 0)
				{
					switch (num2)
					{
					case 1:
					case 2:
					case 5:
					case 6:
						if ((float)rect.Bottom - pointF2.Y < (float)(yLabelSize.Height / 2))
						{
							if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
							{
								rect.Height += yLabelSize.Height / 2;
							}
							else
							{
								rect.Height -= yLabelSize.Height / 2;
							}
						}
						break;
					}
				}
				else
				{
					if (pointF2.Y - chart.WallsInternal.Height - (float)rect.Y < (float)(yLabelSize.Height / 2))
					{
						if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
						{
							rect.Y -= yLabelSize.Height / 2;
						}
						else
						{
							rect.Y += yLabelSize.Height / 2;
						}
					}
					if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
					{
						rect.Height += yLabelSize.Height / 2;
					}
					else
					{
						rect.Height -= yLabelSize.Height / 2;
					}
				}
			}
			else
			{
				PointF[] array2 = smethod_3(chart);
				int height = yLabelSize.Height;
				if (rect.Bottom - (int)array2[0].Y < height)
				{
					if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
					{
						rect.Height += height - (rect.Bottom - (int)array2[0].Y);
					}
					else
					{
						rect.Height -= height - (rect.Bottom - (int)array2[0].Y);
					}
				}
			}
			if (chart.PlotAreaInternal.IsSizeAuto || !chart.IsInnerMode)
			{
				Struct29.smethod_0(chart, rect, flag, renderContext);
			}
		}
		Size size7 = Struct21.smethod_23(x1AxisRenderContext, graphics, rect, num6, flag, nSeriesInternal.method_0(0));
		float fontSize = ((x1AxisRenderContext.Axis != null) ? x1AxisRenderContext.TickLabelTextFont.Size : 0f);
		int num20 = (int)((double)((float)x1AxisRenderContext.TickLabelsOffsetPixel + Struct21.smethod_0(fontSize) + Struct21.smethod_1(fontSize)) + 0.5);
		if (chart.NSeriesInternal.Categories != null)
		{
			num20 += num20 * chart.NSeriesInternal.Categories.Length;
		}
		if (x1AxisRenderContext.Axis != null && !Struct41.smethod_21(rect) && x1AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && x1AxisRenderContext.Axis.IsVisible)
		{
			Size size8 = new Size(0, 0);
			if (x1AxisRenderContext.Axis != null && x1AxisRenderContext.Axis.HasTitle)
			{
				size8 = x1AxisRenderContext.AxisTitleRenderContext.rectangle_0.Size;
			}
			if (!flag)
			{
				PointF[] array3 = smethod_3(chart);
				int num21 = 0;
				if (array3[0].Y < array3[1].Y)
				{
					num21 = 1;
				}
				float num22 = Math.Abs((array3[1].Y - array3[0].Y) / (float)num6);
				int num23 = size7.Height + num20;
				if (chart.Elevation >= 0)
				{
					if (array3[0].Y == array3[1].Y)
					{
						if (rect.Bottom - size8.Height - (int)array3[0].Y < num23)
						{
							if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
							{
								rect.Height += num23 - (rect.Bottom - size8.Height - (int)array3[0].Y);
							}
							else
							{
								rect.Height -= num23 - (rect.Bottom - size8.Height - (int)array3[0].Y);
							}
						}
					}
					else
					{
						Size size9 = size7;
						if (x1AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
						{
							size9.Width += num20;
						}
						int num24 = size8.Width + smethod_7(chart, size9);
						switch (num2)
						{
						case 1:
						case 5:
							if ((int)Math.Abs(array3[0].X + array3[1].X) / 2 - rect.X < num24)
							{
								int num26 = num24 - ((int)Math.Abs(array3[0].X + array3[1].X) / 2 - rect.X);
								if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
								{
									rect.X -= num26;
									rect.Width += num26;
								}
								else
								{
									rect.X += num26;
									rect.Width -= num26;
								}
							}
							break;
						case 2:
						case 6:
							if (rect.Right - (int)Math.Abs(array3[0].X + array3[1].X) / 2 < num24)
							{
								int num25 = num24 - (rect.Right - (int)Math.Abs(array3[0].X + array3[1].X) / 2);
								if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
								{
									rect.Width += num25;
								}
								else
								{
									rect.Width -= num25;
								}
							}
							break;
						}
						float num27 = num22 * (float)Math.Sin((double)chart.Elevation * Math.PI / 180.0);
						if ((int)((float)rect.Bottom - array3[num21].Y + num27) < size7.Height)
						{
							if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
							{
								rect.Height += size7.Height - (int)((float)rect.Bottom - array3[num21].Y + num27);
							}
							else
							{
								rect.Height -= size7.Height - (int)((float)rect.Bottom - array3[num21].Y + num27);
							}
						}
					}
				}
			}
			else
			{
				PointF pointF3 = smethod_5(chart);
				int num28 = size7.Width + num20;
				int num29 = (int)(pointF3.X - (float)rect.X);
				if (num29 < num28)
				{
					if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
					{
						rect.X -= num28;
						rect.Width += num28;
					}
					else
					{
						rect.X += num28;
						rect.Width -= num28;
					}
				}
			}
			if (chart.PlotAreaInternal.IsSizeAuto || !chart.IsInnerMode)
			{
				Struct29.smethod_0(chart, rect, flag, renderContext);
			}
		}
		if (!Struct41.smethod_21(rect) && renderContext.Chart.HasDataTable)
		{
			int num30 = Struct26.smethod_6(graphics, rect, renderContext);
			if (num30 > dataTableRenderContext.CategoryLabelHeight)
			{
				dataTableRenderContext.CategoryLabelHeight = num30;
				int num31 = num30 - dataTableRenderContext.CategoryLabelHeight;
				dataTableRenderContext.rectangle_1.Height += num31;
				if (chart.Elevation > 0 && !flag)
				{
					switch (num2)
					{
					case 1:
					case 2:
					case 5:
					case 6:
						if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
						{
							dataTableRenderContext.rectangle_1.Y += num31;
							rect.Height += num31;
						}
						else
						{
							rect.Height -= num31;
							dataTableRenderContext.rectangle_1.Y -= num31;
						}
						break;
					case 0:
					case 3:
					case 4:
					case 7:
					case 8:
						if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
						{
							rect.Height += num31 + int_1;
						}
						else
						{
							rect.Height -= num31 + int_1;
						}
						break;
					}
				}
				else if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
				{
					dataTableRenderContext.rectangle_1.Y += num31;
					rect.Height += num31;
				}
				else
				{
					rect.Height -= num31;
					dataTableRenderContext.rectangle_1.Y -= num31;
				}
				if (chart.PlotAreaInternal.IsSizeAuto || !chart.IsInnerMode)
				{
					Struct29.smethod_0(chart, rect, flag, renderContext);
				}
			}
		}
		if (y1AxisRenderContext.Axis != null && y1AxisRenderContext.Axis.IsVisible)
		{
			float num32 = Struct24.smethod_37(graphics, flag, chart.NSeriesInternal.method_0(0), rect, renderContext.Y1AxisRenderContext);
			int num33 = 0;
			num33 = ((!flag) ? Struct41.smethod_3(chart.WallsInternal.Height) : Struct41.smethod_3(chart.WallsInternal.Width));
			if (flag3 && y1AxisRenderContext.arrayList_0.Count > 3 && num32 > (float)num33 && num33 != 0)
			{
				y1AxisRenderContext.arrayList_0.Clear();
				y1AxisRenderContext.IsAutoMajorUnit = flag3;
				y1AxisRenderContext.IsAutoMinorUnit = isAutoMinorUnit;
				Struct24.smethod_33(graphics, maxValue, minValue, y1AxisRenderContext.arrayList_0, chart.NSeriesInternal.method_0(0).ResembleType, rect, flag, chart.NSeriesInternal.method_0(0), y1AxisRenderContext);
			}
		}
		if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
		{
			Rectangle rectangle = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
			rect = new Rectangle(chart.PlotAreaInternal.rectangle_1.X, chart.PlotAreaInternal.rectangle_1.Y, chart.PlotAreaInternal.rectangle_1.Width, chart.PlotAreaInternal.rectangle_1.Height);
			chart.PlotAreaInternal.rectangle_1 = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
		}
		if (x1AxisRenderContext.Axis != null && x1AxisRenderContext.Axis.HasTitle && x1AxisRenderContext.Axis.IsVisible)
		{
			smethod_10(x1AxisRenderContext, rect, flag, yLabelSize, size7, num20);
		}
		if (y1AxisRenderContext.Axis != null && y1AxisRenderContext.Axis.HasTitle && y1AxisRenderContext.Axis.IsVisible)
		{
			smethod_10(y1AxisRenderContext, rect, flag, yLabelSize, size7, num20);
		}
		if (renderContext.SeriesAxisRenderContext.Axis != null && renderContext.SeriesAxisRenderContext.Axis.HasTitle && renderContext.SeriesAxisRenderContext.Axis.IsVisible)
		{
			Size size10 = size4;
			if (renderContext.SeriesAxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
			{
				size10.Width += num7;
			}
			PointF[] array4 = smethod_4(chart);
			if (array4[0].Y == array4[1].Y)
			{
				if (chart.Elevation >= 0)
				{
					renderContext.SeriesAxisRenderContext.AxisTitleRenderContext.rectangle_0.X = (int)((array4[0].X + array4[1].X) / 2f - (float)(renderContext.SeriesAxisRenderContext.AxisTitleRenderContext.rectangle_0.Width / 2));
				}
			}
			else
			{
				switch (num2)
				{
				case 3:
				case 7:
					renderContext.SeriesAxisRenderContext.AxisTitleRenderContext.rectangle_0.X = (int)(Math.Abs(array4[0].X + array4[1].X) / 2f - (float)renderContext.SeriesAxisRenderContext.AxisTitleRenderContext.rectangle_0.Width - (float)smethod_7(chart, size10));
					break;
				case 0:
				case 4:
				case 8:
					renderContext.SeriesAxisRenderContext.AxisTitleRenderContext.rectangle_0.X = (int)(Math.Abs(array4[0].X + array4[1].X) / 2f + (float)smethod_7(chart, size10));
					break;
				}
				renderContext.SeriesAxisRenderContext.AxisTitleRenderContext.rectangle_0.Y = (int)(Math.Abs(array4[0].Y + array4[1].Y) / 2f);
			}
		}
		if (!renderContext.Chart.HasDataTable || flag)
		{
			return;
		}
		PointF[] array5 = smethod_3(chart);
		if (chart.Elevation > 0)
		{
			switch (num2)
			{
			case 0:
			case 3:
			case 4:
			case 7:
			case 8:
			{
				int num34 = ((!(array5[0].X < array5[1].X)) ? 1 : 0);
				dataTableRenderContext.rectangle_1.X = (int)array5[num34].X;
				dataTableRenderContext.rectangle_1.Y = (int)array5[num34].Y;
				dataTableRenderContext.rectangle_1.Width = (int)Math.Abs(array5[1].X - array5[0].X);
				break;
			}
			case 1:
			case 2:
			case 5:
			case 6:
				break;
			}
		}
	}

	internal static void smethod_1(Class740 chart)
	{
		Interface32 graphics = chart.Graphics;
		Chart sourceChart = chart.SourceChart;
		Class784 @class = new Class784(sourceChart, graphics, chart);
		smethod_0(chart, sourceChart, @class);
		@class.method_1();
		TextRenderingHint textRenderingHint = chart.Graphics.TextRenderingHint;
		if (chart.NSeriesInternal.Count == 0 || Struct24.smethod_23(chart.NSeriesInternal.ListSeries) == 0)
		{
			return;
		}
		bool flag = Struct24.smethod_8(chart.Type);
		bool flag2 = chart.PlotAreaInternal.method_16();
		int maxPointsCount = chart.NSeriesInternal.method_1();
		float categoryAxisX = Struct24.smethod_14((int)chart.WallsInternal.X, (int)chart.WallsInternal.Width, flag, @class.Y1AxisRenderContext);
		double categoryAxisCrossAt = @class.Y1AxisRenderContext.CrossAt;
		float categoryAxisY = Struct24.smethod_14((int)(chart.WallsInternal.Y - chart.WallsInternal.Height), (int)chart.WallsInternal.Height, flag, @class.Y1AxisRenderContext);
		chart.PlotAreaInternal.method_17();
		Rectangle rectangle_ = chart.PlotAreaInternal.rectangle_0;
		Struct29.smethod_3(graphics, chart, flag, @class);
		Class759 class2 = chart.NSeriesInternal.method_9()[0];
		if (!flag2)
		{
			switch (chart.Type)
			{
			case ChartType.ClusteredColumn3D:
			case ChartType.ClusteredCylinder:
			case ChartType.ClusteredCone:
			case ChartType.ClusteredPyramid:
				Struct27.smethod_32(graphics, chart, categoryAxisY, categoryAxisCrossAt, maxPointsCount, @class);
				break;
			case ChartType.StackedColumn3D:
			case ChartType.StackedCylinder:
			case ChartType.StackedCone:
			case ChartType.StackedPyramid:
				Struct27.smethod_34(graphics, chart, categoryAxisCrossAt, maxPointsCount, @class);
				break;
			case ChartType.PercentsStackedColumn3D:
			case ChartType.PercentsStackedCylinder:
			case ChartType.PercentsStackedCone:
			case ChartType.PercentsStackedPyramid:
				Struct27.smethod_36(graphics, chart, categoryAxisCrossAt, maxPointsCount, @class);
				break;
			case ChartType.Column3D:
			case ChartType.Cylinder3D:
			case ChartType.Cone3D:
			case ChartType.Pyramid3D:
				Struct27.smethod_38(graphics, chart, categoryAxisY, categoryAxisCrossAt, maxPointsCount, @class);
				break;
			case ChartType.Line3D:
				Struct27.smethod_40(graphics, chart, categoryAxisY, categoryAxisCrossAt, maxPointsCount, @class);
				break;
			case ChartType.Pie3D:
			case ChartType.ExplodedPie3D:
				Struct35.smethod_2(graphics, chart, @class);
				break;
			case ChartType.ClusteredBar3D:
			case ChartType.ClusteredHorizontalCylinder:
			case ChartType.ClusteredHorizontalCone:
			case ChartType.ClusteredHorizontalPyramid:
				Struct22.smethod_10(graphics, chart, categoryAxisX, categoryAxisCrossAt, maxPointsCount, @class);
				break;
			case ChartType.StackedBar3D:
			case ChartType.StackedHorizontalCylinder:
			case ChartType.StackedHorizontalCone:
			case ChartType.StackedHorizontalPyramid:
				Struct22.smethod_12(graphics, chart, categoryAxisCrossAt, maxPointsCount, @class);
				break;
			case ChartType.PercentsStackedBar3D:
			case ChartType.PercentsStackedHorizontalCylinder:
			case ChartType.PercentsStackedHorizontalCone:
			case ChartType.PercentsStackedHorizontalPyramid:
				Struct22.smethod_14(graphics, chart, categoryAxisCrossAt, maxPointsCount, @class);
				break;
			case ChartType.Area3D:
				Struct20.smethod_10(graphics, chart, categoryAxisY, categoryAxisCrossAt, maxPointsCount, @class);
				break;
			case ChartType.StackedArea3D:
				Struct20.smethod_12(graphics, chart, categoryAxisY, categoryAxisCrossAt, maxPointsCount, isPercent: false, @class);
				break;
			case ChartType.PercentsStackedArea3D:
				Struct20.smethod_12(graphics, chart, categoryAxisY, categoryAxisCrossAt, maxPointsCount, isPercent: true, @class);
				break;
			}
		}
		if (chart.ChartAreaInternal.AreaInternal.IsTransparent && chart.PlotAreaInternal.AreaInternal.IsTransparent)
		{
			chart.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
		if (@class.Y1AxisRenderContext.Axis != null && @class.Y1AxisRenderContext.Axis.IsVisible)
		{
			if (flag)
			{
				Struct21.smethod_56(graphics, @class.Y1AxisRenderContext);
			}
			else
			{
				Struct21.smethod_49(graphics, @class.Y1AxisRenderContext, @class);
			}
		}
		if (@class.X1AxisRenderContext.Axis != null && @class.X1AxisRenderContext.Axis.IsVisible)
		{
			if (flag)
			{
				Struct21.smethod_58(graphics, maxPointsCount, rectangle_, @class.X1AxisRenderContext, @class);
			}
			else
			{
				Struct21.smethod_52(graphics, maxPointsCount, rectangle_, flag, @class.X1AxisRenderContext, @class);
			}
		}
		if (@class.SeriesAxisRenderContext.Axis != null && @class.SeriesAxisRenderContext.Axis.IsVisible)
		{
			Struct21.smethod_62(graphics, @class.SeriesAxisRenderContext, @class);
		}
		if (chart.ChartAreaInternal.AreaInternal.IsTransparent && chart.PlotAreaInternal.AreaInternal.IsTransparent)
		{
			chart.Graphics.TextRenderingHint = textRenderingHint;
		}
		if (@class.Y1AxisRenderContext.Axis != null && @class.Y1AxisRenderContext.Axis.HasTitle && @class.Y1AxisRenderContext.Axis.IsVisible)
		{
			smethod_6(chart, @class, @class.Y1AxisRenderContext);
		}
		if (@class.X1AxisRenderContext.Axis != null && @class.X1AxisRenderContext.Axis.HasTitle && @class.X1AxisRenderContext.Axis.IsVisible)
		{
			smethod_6(chart, @class, @class.X1AxisRenderContext);
		}
		if (@class.SeriesAxisRenderContext.Axis != null && @class.SeriesAxisRenderContext.Axis.HasTitle && @class.SeriesAxisRenderContext.Axis.IsVisible)
		{
			smethod_6(chart, @class, @class.SeriesAxisRenderContext);
		}
		if (sourceChart.HasTitle)
		{
			(sourceChart.ChartTitle as ChartTitle).method_2(@class, @class.ChartTitleRenderContext);
		}
		if (@class.Chart.HasDataTable)
		{
			Class786 dataTableRenderContext = @class.DataTableRenderContext;
			Struct26.smethod_0(graphics, dataTableRenderContext.rectangle_1.X, dataTableRenderContext.rectangle_1.Y, dataTableRenderContext.rectangle_1.Width, flag, @class);
		}
		if (sourceChart.HasLegend)
		{
			if (chart.ChartAreaInternal.AreaInternal.IsTransparent && @class.LegendRenderContext.IsTransparent)
			{
				chart.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			}
			if (chart.Type != ChartType.ExplodedPie3D && chart.Type != ChartType.Pie3D && !@class.LegendRenderContext.IsRenderedLegendByPoint)
			{
				Struct31.smethod_23(graphics, flag, class2, @class, (Legend)sourceChart.Legend);
			}
			else
			{
				Struct31.smethod_9(graphics, class2, @class, (Legend)sourceChart.Legend);
			}
			if (chart.ChartAreaInternal.AreaInternal.IsTransparent && @class.LegendRenderContext.IsTransparent)
			{
				chart.Graphics.TextRenderingHint = textRenderingHint;
			}
		}
	}

	private static void smethod_2(Class740 chart)
	{
		ChartType type = chart.Type;
		if (type != ChartType.Pie3D && type != ChartType.ExplodedPie3D)
		{
			return;
		}
		foreach (Class759 item in chart.NSeriesInternal)
		{
			if (item.IsColorVariedAuto)
			{
				item.IsColorVaried = true;
			}
		}
		if (chart.Elevation < 1)
		{
			chart.Elevation = 1;
		}
		if (chart.Elevation > 90)
		{
			chart.Elevation = 90;
		}
	}

	internal static PointF[] smethod_3(Class740 chart)
	{
		PointF pointF = new PointF(chart.WallsInternal.xCenter, chart.WallsInternal.Y);
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
		PointF[] array = new PointF[4];
		PointF[] array2 = new PointF[4];
		switch (num2)
		{
		case 1:
		{
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference29 = ref array2[0];
			reference29 = array[0];
			ref PointF reference30 = ref array2[1];
			reference30 = array[1];
			ref PointF reference31 = ref array2[2];
			reference31 = array[3];
			ref PointF reference32 = ref array2[3];
			reference32 = array[2];
			break;
		}
		case 2:
		{
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference25 = ref array2[0];
			reference25 = array[3];
			ref PointF reference26 = ref array2[1];
			reference26 = array[2];
			ref PointF reference27 = ref array2[2];
			reference27 = array[0];
			ref PointF reference28 = ref array2[3];
			reference28 = array[1];
			break;
		}
		case 3:
		{
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			ref PointF reference21 = ref array2[0];
			reference21 = array[3];
			ref PointF reference22 = ref array2[1];
			reference22 = array[2];
			ref PointF reference23 = ref array2[2];
			reference23 = array[0];
			ref PointF reference24 = ref array2[3];
			reference24 = array[1];
			break;
		}
		case 4:
		{
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			ref PointF reference17 = ref array2[0];
			reference17 = array[3];
			ref PointF reference18 = ref array2[1];
			reference18 = array[2];
			ref PointF reference19 = ref array2[2];
			reference19 = array[0];
			ref PointF reference20 = ref array2[3];
			reference20 = array[1];
			break;
		}
		case 5:
		{
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference13 = ref array2[0];
			reference13 = array[3];
			ref PointF reference14 = ref array2[1];
			reference14 = array[2];
			ref PointF reference15 = ref array2[2];
			reference15 = array[0];
			ref PointF reference16 = ref array2[3];
			reference16 = array[1];
			break;
		}
		case 6:
		{
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference9 = ref array2[0];
			reference9 = array[0];
			ref PointF reference10 = ref array2[1];
			reference10 = array[1];
			ref PointF reference11 = ref array2[2];
			reference11 = array[3];
			ref PointF reference12 = ref array2[3];
			reference12 = array[2];
			break;
		}
		case 7:
		{
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			ref PointF reference5 = ref array2[0];
			reference5 = array[0];
			ref PointF reference6 = ref array2[1];
			reference6 = array[1];
			ref PointF reference7 = ref array2[2];
			reference7 = array[3];
			ref PointF reference8 = ref array2[3];
			reference8 = array[2];
			break;
		}
		case 0:
		case 8:
		{
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[0].X + num5;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			ref PointF reference = ref array2[0];
			reference = array[0];
			ref PointF reference2 = ref array2[1];
			reference2 = array[1];
			ref PointF reference3 = ref array2[2];
			reference3 = array[3];
			ref PointF reference4 = ref array2[3];
			reference4 = array[2];
			break;
		}
		}
		return array2;
	}

	internal static PointF[] smethod_4(Class740 chart)
	{
		PointF pointF = new PointF(chart.WallsInternal.xCenter, chart.WallsInternal.Y);
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
		PointF[] array = new PointF[4];
		PointF[] array2 = new PointF[2];
		switch (num2)
		{
		case 1:
		{
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference15 = ref array2[0];
			reference15 = array[1];
			ref PointF reference16 = ref array2[1];
			reference16 = array[2];
			break;
		}
		case 2:
		{
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference13 = ref array2[0];
			reference13 = array[1];
			ref PointF reference14 = ref array2[1];
			reference14 = array[2];
			break;
		}
		case 3:
		{
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			ref PointF reference11 = ref array2[0];
			reference11 = array[1];
			ref PointF reference12 = ref array2[1];
			reference12 = array[2];
			break;
		}
		case 4:
		{
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			ref PointF reference9 = ref array2[0];
			reference9 = array[0];
			ref PointF reference10 = ref array2[1];
			reference10 = array[3];
			break;
		}
		case 5:
		{
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference7 = ref array2[0];
			reference7 = array[0];
			ref PointF reference8 = ref array2[1];
			reference8 = array[3];
			break;
		}
		case 6:
		{
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference5 = ref array2[0];
			reference5 = array[0];
			ref PointF reference6 = ref array2[1];
			reference6 = array[3];
			break;
		}
		case 7:
		{
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			ref PointF reference3 = ref array2[0];
			reference3 = array[0];
			ref PointF reference4 = ref array2[1];
			reference4 = array[3];
			break;
		}
		case 0:
		case 8:
		{
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[0].X + num5;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			ref PointF reference = ref array2[0];
			reference = array[1];
			ref PointF reference2 = ref array2[1];
			reference2 = array[2];
			break;
		}
		}
		return array2;
	}

	internal static PointF smethod_5(Class740 chart)
	{
		PointF pointF = new PointF(chart.WallsInternal.xCenter, chart.WallsInternal.Y);
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
		PointF[] array = new PointF[4];
		PointF result = PointF.Empty;
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
			result = array[2];
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
			result = array[1];
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
			result = array[3];
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
			result = array[2];
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
			result = array[0];
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
			result = array[3];
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
			result = array[1];
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
			result = array[0];
			break;
		}
		return result;
	}

	private static void smethod_6(Class740 chart, Class784 renderContext, Class783 axisRenderContext)
	{
		if (!chart.PlotAreaInternal.method_16())
		{
			(axisRenderContext.Axis.Title as ChartTitle).method_2(renderContext, axisRenderContext.AxisTitleRenderContext);
		}
	}

	private static int smethod_7(Class740 chart, Size size)
	{
		int num = chart.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2;
		int num3;
		switch (chart.Rotation / 45)
		{
		default:
			num2 = size.Height;
			num3 = size.Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num2 = size.Width;
			num3 = size.Height;
			break;
		}
		int num4 = (int)((double)num3 * Math.Sin((double)num * Math.PI / 180.0));
		return num2 + num4;
	}

	private static void smethod_8(Class783 axisRenderContext, Interface32 g, Rectangle rectOriginal, ref Rectangle rect, bool isDisplayAxisSameAsBar, Class784 renderContext)
	{
		bool flag = isDisplayAxisSameAsBar;
		Size empty = Size.Empty;
		Class740 chart = renderContext.Chart2007;
		if (axisRenderContext.AxisType == Enum160.const_2)
		{
			isDisplayAxisSameAsBar = !isDisplayAxisSameAsBar;
		}
		if (isDisplayAxisSameAsBar)
		{
			SizeF layoutArea = new SizeF((float)rect.Width * 0.8f, (float)rect.Height * 0.8f);
			empty = axisRenderContext.AxisTitleRenderContext.method_0(layoutArea, g);
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Size = empty;
			PointF pointF = smethod_5(chart);
			if (pointF.X < chart.WallsInternal.xCenter)
			{
				int num = (int)(pointF.X - (float)rectOriginal.X);
				if (num < empty.Width)
				{
					rect.X += empty.Width;
					rect.Width -= empty.Width;
				}
			}
			else
			{
				int num2 = (int)((float)rect.Right - pointF.X);
				if (num2 < empty.Width)
				{
					axisRenderContext.AxisTitleRenderContext.rectangle_0.X = rect.Right - empty.Width;
					axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rect.Y + (rect.Height - empty.Height) / 2;
					rect.Width -= empty.Width;
				}
			}
			Struct29.smethod_0(chart, rect, isDisplayAxisSameAsBar, renderContext);
			return;
		}
		PointF[] array = smethod_3(chart);
		if (chart.Elevation == 0)
		{
			SizeF layoutArea2 = new SizeF((float)rect.Width * 0.8f, (float)rect.Height * 0.7f);
			empty = axisRenderContext.AxisTitleRenderContext.method_0(layoutArea2, g);
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Size = empty;
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rect.Bottom - empty.Height - int_1;
			int num3 = rect.Bottom - (int)array[0].Y;
			if (num3 < empty.Height + int_1)
			{
				rect.Height -= empty.Height + int_1 - num3;
			}
		}
		else if (chart.Elevation > 0)
		{
			if (array[0].Y == array[1].Y)
			{
				SizeF layoutArea3 = new SizeF((float)rect.Width * 0.8f, (float)rect.Height * 0.7f);
				empty = axisRenderContext.AxisTitleRenderContext.method_0(layoutArea3, g);
				axisRenderContext.AxisTitleRenderContext.rectangle_0.Size = empty;
				int num4 = 0;
				if (flag)
				{
					axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rect.Bottom - empty.Height - int_1;
				}
				else
				{
					axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rectOriginal.Bottom - empty.Height - int_1 * 4;
				}
				num4 = rect.Bottom - (int)array[0].Y;
				if (num4 < empty.Height + int_1)
				{
					rect.Height -= empty.Height + int_1 - num4;
				}
			}
			else
			{
				SizeF layoutArea4 = new SizeF((float)rect.Width * 0.3f, (float)rect.Height * 0.3f);
				empty = axisRenderContext.AxisTitleRenderContext.method_0(layoutArea4, g);
				axisRenderContext.AxisTitleRenderContext.rectangle_0.Size = empty;
				switch (chart.Rotation / 45)
				{
				case 1:
				case 5:
					if ((int)Math.Abs(array[0].X + array[1].X) / 2 - rect.X < empty.Width)
					{
						int num6 = empty.Width - ((int)Math.Abs(array[0].X + array[1].X) / 2 - rect.X);
						rect.X += num6;
						rect.Width -= num6;
					}
					break;
				case 2:
				case 6:
					if (rect.Right - (int)Math.Abs(array[0].X + array[1].X) / 2 < empty.Width)
					{
						int num5 = empty.Width - (rect.Right - (int)Math.Abs(array[0].X + array[1].X) / 2);
						rect.Width -= num5;
					}
					break;
				}
				if (rect.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2 < empty.Height)
				{
					rect.Height -= empty.Height + int_1 - (rect.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2);
				}
			}
		}
		Struct29.smethod_0(chart, rect, isDisplayAxisSameAsBar, renderContext);
	}

	private static void smethod_9(Class783 axisRenderContext, Interface32 g, ref Rectangle rect, Class784 renderContext)
	{
		if (Struct41.smethod_21(rect))
		{
			return;
		}
		Size empty = Size.Empty;
		Class740 chart = renderContext.Chart2007;
		PointF[] array = smethod_4(chart);
		if (chart.Elevation == 0)
		{
			SizeF layoutArea = new SizeF((float)rect.Width * 0.8f, (float)rect.Height * 0.7f);
			empty = axisRenderContext.AxisTitleRenderContext.method_0(layoutArea, g);
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Size = empty;
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rect.Bottom - empty.Height - int_1;
			if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
			{
				int num = rect.Bottom - (int)array[0].Y;
				if (num < empty.Height + int_1)
				{
					rect.Height += empty.Height + int_1 - num;
				}
			}
			else
			{
				int num2 = rect.Bottom - (int)array[0].Y;
				if (num2 < empty.Height + int_1)
				{
					rect.Height -= empty.Height + int_1 - num2;
				}
			}
		}
		if (chart.Elevation <= 0)
		{
			return;
		}
		if (array[0].Y == array[1].Y)
		{
			SizeF layoutArea2 = new SizeF((float)rect.Width * 0.8f, (float)rect.Height * 0.7f);
			empty = axisRenderContext.AxisTitleRenderContext.method_0(layoutArea2, g);
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Size = empty;
			int num3 = 0;
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rect.Bottom - empty.Height - int_1;
			if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
			{
				num3 = rect.Bottom - (int)array[0].Y;
				if (num3 < empty.Height + int_1)
				{
					rect.Height += empty.Height + int_1 - num3;
				}
			}
			else
			{
				num3 = rect.Bottom - (int)array[0].Y;
				if (num3 < empty.Height + int_1)
				{
					rect.Height -= empty.Height + int_1 - num3;
				}
			}
		}
		else
		{
			SizeF layoutArea3 = new SizeF((float)rect.Width * 0.3f, (float)rect.Height * 0.3f);
			empty = axisRenderContext.AxisTitleRenderContext.method_0(layoutArea3, g);
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Size = empty;
			switch (chart.Rotation / 45)
			{
			case 3:
			case 7:
				if ((int)Math.Abs(array[0].X + array[1].X) / 2 - rect.X < empty.Width)
				{
					int num5 = empty.Width - ((int)Math.Abs(array[0].X + array[1].X) / 2 - rect.X);
					if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
					{
						rect.X -= num5;
						rect.Width += num5;
					}
					else
					{
						rect.X += num5;
						rect.Width -= num5;
					}
				}
				break;
			case 0:
			case 4:
			case 8:
				if (rect.Right - (int)Math.Abs(array[0].X + array[1].X) / 2 < empty.Width)
				{
					int num4 = empty.Width - (rect.Right - (int)Math.Abs(array[0].X + array[1].X) / 2);
					if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
					{
						rect.Width += num4;
					}
					else
					{
						rect.Width -= num4;
					}
				}
				break;
			}
			if (rect.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2 < empty.Height)
			{
				if (!chart.PlotAreaInternal.IsSizeAuto && chart.IsInnerMode)
				{
					rect.Height += empty.Height + int_1 - (rect.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2);
				}
				else
				{
					rect.Height -= empty.Height + int_1 - (rect.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2);
				}
			}
		}
		if (chart.PlotAreaInternal.IsSizeAuto || !chart.IsInnerMode)
		{
			Struct29.smethod_0(chart, rect, isDisplayAxisSameAsBar: false, renderContext);
		}
	}

	private static void smethod_10(Class783 axisRenderContext, Rectangle rect, bool isDisplayAxisSameAsBar, Size yLabelSize, Size xLabelSize, int xLabelOffset)
	{
		bool flag = isDisplayAxisSameAsBar;
		Size empty = Size.Empty;
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (axisRenderContext.AxisType == Enum160.const_2)
		{
			empty = yLabelSize;
			flag = !isDisplayAxisSameAsBar;
		}
		else
		{
			empty = xLabelSize;
			if (axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
			{
				empty.Width += xLabelOffset;
			}
		}
		if (flag)
		{
			Size size = axisRenderContext.AxisTitleRenderContext.rectangle_0.Size;
			PointF pointF = smethod_5(chart);
			if (pointF.X < chart.WallsInternal.xCenter)
			{
				axisRenderContext.AxisTitleRenderContext.rectangle_0.X = ((axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.None) ? ((int)(pointF.X - (float)size.Width)) : ((int)(pointF.X - (float)empty.Width - (float)size.Width)));
				axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = (int)(pointF.Y - chart.WallsInternal.Height / 2f - (float)(size.Height / 2));
				return;
			}
			int num = (int)((float)rect.Right - pointF.X);
			if (num >= size.Width)
			{
				axisRenderContext.AxisTitleRenderContext.rectangle_0.X = ((axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.None) ? ((int)pointF.X) : ((int)(pointF.X + (float)empty.Width)));
				axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = (int)(pointF.Y - chart.WallsInternal.Height / 2f - (float)(size.Height / 2));
			}
			return;
		}
		PointF[] array = smethod_3(chart);
		if (array[0].Y == array[1].Y)
		{
			if (chart.Elevation >= 0)
			{
				axisRenderContext.AxisTitleRenderContext.rectangle_0.X = (int)((array[0].X + array[1].X) / 2f - (float)(axisRenderContext.AxisTitleRenderContext.rectangle_0.Width / 2));
			}
			return;
		}
		if ((chart.Rotation >= 45 && chart.Rotation < 90) || (chart.Rotation >= 225 && chart.Rotation < 270))
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.X = (int)(Math.Abs(array[0].X + array[1].X) / 2f - (float)axisRenderContext.AxisTitleRenderContext.rectangle_0.Width - (float)smethod_7(chart, empty));
		}
		else
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.X = (int)(Math.Abs(array[0].X + array[1].X) / 2f + (float)smethod_7(chart, empty));
		}
		axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = (int)(Math.Abs(array[0].Y + array[1].Y) / 2f);
	}

	private static void smethod_11(Class740 chart, Class784 renderContext)
	{
		Class783 seriesAxisRenderContext = renderContext.SeriesAxisRenderContext;
		ArrayList arrayList_ = seriesAxisRenderContext.arrayList_0;
		IList list = chart.NSeriesInternal.method_9();
		for (int i = 0; i < list.Count; i++)
		{
			Class759 @class = (Class759)list[i];
			arrayList_.Add(@class.method_1());
		}
		seriesAxisRenderContext.MinValue = 0.0;
		seriesAxisRenderContext.MaxValue = list.Count;
		seriesAxisRenderContext.MajorUnit = seriesAxisRenderContext.TickMarkSpacing;
		seriesAxisRenderContext.MinorUnit = seriesAxisRenderContext.MajorUnit / 2.0;
	}

	private static void smethod_12(Class740 chart)
	{
		if (chart.Type == ChartType.StackedArea3D || chart.Type == ChartType.PercentsStackedArea3D)
		{
			chart.GapWidth = 20;
		}
	}
}
