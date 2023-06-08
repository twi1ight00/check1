using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns2;
using ns56;

namespace Aspose.Slides.Charts;

public class AxesManager : IAxesManager
{
	private Chart chart_0;

	private Axis axis_0;

	private Axis axis_1;

	private Axis axis_2;

	private Axis axis_3;

	private Axis axis_4;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	[CompilerGenerated]
	private Class2056 class2056_0;

	public IAxis HorizontalAxis
	{
		get
		{
			if (bool_0)
			{
				if (axis_0 == null)
				{
					axis_0 = new Axis(chart_0);
					axis_0.Position = AxisPositionType.Bottom;
				}
				return axis_0;
			}
			return null;
		}
	}

	public IAxis SecondaryHorizontalAxis
	{
		get
		{
			if (bool_1)
			{
				if (axis_1 == null)
				{
					method_0();
				}
				return axis_1;
			}
			return null;
		}
	}

	public IAxis VerticalAxis
	{
		get
		{
			if (bool_2)
			{
				if (axis_2 == null)
				{
					axis_2 = new Axis(chart_0);
					axis_2.Position = AxisPositionType.Left;
				}
				return axis_2;
			}
			return null;
		}
	}

	public IAxis SecondaryVerticalAxis
	{
		get
		{
			if (bool_3)
			{
				if (axis_3 == null)
				{
					method_0();
				}
				return axis_3;
			}
			return null;
		}
	}

	public IAxis SeriesAxis
	{
		get
		{
			if (bool_4)
			{
				if (axis_4 == null)
				{
					axis_4 = new Axis(chart_0);
				}
				return axis_4;
			}
			return null;
		}
	}

	internal Class2056 SeriesAxisUnsupported
	{
		[CompilerGenerated]
		get
		{
			return class2056_0;
		}
		[CompilerGenerated]
		set
		{
			class2056_0 = value;
		}
	}

	private void method_0()
	{
		axis_1 = new Axis(chart_0);
		axis_1.CrossType = CrossesType.Maximum;
		axis_1.Position = AxisPositionType.Top;
		axis_3 = new Axis(chart_0);
		axis_3.CrossType = CrossesType.Maximum;
		axis_3.Position = AxisPositionType.Right;
		axis_3.PPTXUnsupportedProps.CrossAxId = axis_1.PPTXUnsupportedProps.AxisId;
		axis_1.PPTXUnsupportedProps.CrossAxId = axis_3.PPTXUnsupportedProps.AxisId;
	}

	internal AxesManager(Chart parent)
	{
		chart_0 = parent;
	}

	internal void method_1()
	{
		chart_0.method_25();
		method_2();
	}

	internal void method_2()
	{
		IChartSeriesCollection series = chart_0.ChartData.Series;
		if (series.Count != 1 && series.Count != 0)
		{
			if (series.Count <= 1)
			{
				return;
			}
			List<Enum169> list = new List<Enum169>();
			List<Enum169> list2 = new List<Enum169>();
			foreach (ChartSeries item2 in series)
			{
				Enum169 item = ChartTypeCharacterizer.smethod_0(item2.Type);
				if (!item2.PlotOnSecondAxis && !list.Contains(item))
				{
					list.Add(item);
				}
				if (item2.PlotOnSecondAxis && !list2.Contains(item))
				{
					list2.Add(item);
				}
			}
			if (list.Count != 0)
			{
				Enum169? @enum = method_3(list);
				if (!@enum.HasValue)
				{
					throw new ArgumentException("Unsupported primary axis composition");
				}
				switch (@enum)
				{
				case Enum169.const_0:
					method_5(horizontalAxisIsPresent: false, secondaryHorizontalAxisIsPresent: false, verticalAxisIsPresent: false, secondaryVerticalAxisIsPresent: false, seriesAxisIsPresent: false);
					break;
				case Enum169.const_1:
				case Enum169.const_2:
				case Enum169.const_3:
				case Enum169.const_4:
					method_5(horizontalAxisIsPresent: true, secondaryHorizontalAxisIsPresent: false, verticalAxisIsPresent: true, secondaryVerticalAxisIsPresent: false, seriesAxisIsPresent: false);
					break;
				case Enum169.const_5:
					method_5(horizontalAxisIsPresent: true, secondaryHorizontalAxisIsPresent: false, verticalAxisIsPresent: true, secondaryVerticalAxisIsPresent: false, seriesAxisIsPresent: true);
					break;
				default:
					throw new Exception();
				}
			}
			if (list2.Count != 0)
			{
				Enum169? enum2 = method_3(list2);
				if (!enum2.HasValue)
				{
					throw new ArgumentException("Unsupported secondary axis composition");
				}
				switch (enum2)
				{
				case Enum169.const_1:
				case Enum169.const_2:
				case Enum169.const_3:
				case Enum169.const_4:
					method_6(horizontalAxisIsPresent: false, secondaryHorizontalAxisIsPresent: true, verticalAxisIsPresent: false, secondaryVerticalAxisIsPresent: true, seriesAxisIsPresent: false);
					break;
				case Enum169.const_5:
					throw new Exception();
				default:
					throw new Exception();
				case Enum169.const_0:
					break;
				}
			}
		}
		else
		{
			_ = series.Count;
			switch (ChartTypeCharacterizer.smethod_0(chart_0.Type))
			{
			default:
				throw new Exception();
			case Enum169.const_0:
				method_5(horizontalAxisIsPresent: false, secondaryHorizontalAxisIsPresent: false, verticalAxisIsPresent: false, secondaryVerticalAxisIsPresent: false, seriesAxisIsPresent: false);
				break;
			case Enum169.const_1:
			case Enum169.const_2:
			case Enum169.const_3:
			case Enum169.const_4:
				method_5(horizontalAxisIsPresent: true, secondaryHorizontalAxisIsPresent: false, verticalAxisIsPresent: true, secondaryVerticalAxisIsPresent: false, seriesAxisIsPresent: false);
				break;
			case Enum169.const_5:
				method_5(horizontalAxisIsPresent: true, secondaryHorizontalAxisIsPresent: false, verticalAxisIsPresent: true, secondaryVerticalAxisIsPresent: false, seriesAxisIsPresent: true);
				break;
			}
		}
	}

	private Enum169? method_3(List<Enum169> axesCompositions)
	{
		if (axesCompositions.Count == 0)
		{
			throw new Exception();
		}
		do
		{
			if (axesCompositions.Count <= 1)
			{
				return axesCompositions[0];
			}
		}
		while (method_4(axesCompositions));
		return null;
	}

	private bool method_4(List<Enum169> axesCompositions)
	{
		if (axesCompositions.Count != 0 && axesCompositions.Count != 1)
		{
			int count = axesCompositions.Count;
			Enum169 @enum = axesCompositions[count - 2];
			Enum169 enum2 = axesCompositions[count - 1];
			if (@enum != enum2 && enum2 != 0)
			{
				if ((@enum == Enum169.const_1 && enum2 == Enum169.const_4) || (enum2 == Enum169.const_1 && @enum == Enum169.const_4))
				{
					@enum = Enum169.const_1;
					axesCompositions[count - 2] = Enum169.const_1;
					axesCompositions.RemoveAt(count - 1);
				}
				else if ((@enum == Enum169.const_3 && enum2 == Enum169.const_4) || (enum2 == Enum169.const_3 && @enum == Enum169.const_4))
				{
					@enum = Enum169.const_3;
					axesCompositions[count - 2] = Enum169.const_3;
					axesCompositions.RemoveAt(count - 1);
				}
				else
				{
					if (@enum != 0)
					{
						return false;
					}
					@enum = enum2;
					axesCompositions[count - 2] = @enum;
					axesCompositions.RemoveAt(count - 1);
				}
			}
			else
			{
				axesCompositions.RemoveAt(count - 1);
			}
			return true;
		}
		throw new ArgumentException();
	}

	private void method_5(bool horizontalAxisIsPresent, bool secondaryHorizontalAxisIsPresent, bool verticalAxisIsPresent, bool secondaryVerticalAxisIsPresent, bool seriesAxisIsPresent)
	{
		bool_0 = horizontalAxisIsPresent;
		bool_1 = secondaryHorizontalAxisIsPresent;
		bool_2 = verticalAxisIsPresent;
		bool_3 = secondaryVerticalAxisIsPresent;
		bool_4 = seriesAxisIsPresent;
	}

	private void method_6(bool horizontalAxisIsPresent, bool secondaryHorizontalAxisIsPresent, bool verticalAxisIsPresent, bool secondaryVerticalAxisIsPresent, bool seriesAxisIsPresent)
	{
		if (horizontalAxisIsPresent)
		{
			bool_0 = true;
		}
		if (secondaryHorizontalAxisIsPresent)
		{
			bool_1 = true;
		}
		if (verticalAxisIsPresent)
		{
			bool_2 = true;
		}
		if (secondaryVerticalAxisIsPresent)
		{
			bool_3 = true;
		}
		if (seriesAxisIsPresent)
		{
			bool_4 = true;
		}
	}

	internal bool method_7(ChartType seriesType, bool secondaryAxes)
	{
		IChartSeriesCollection series = chart_0.ChartData.Series;
		if (series.Count == 0)
		{
			return true;
		}
		List<Enum169> list = new List<Enum169>();
		List<Enum169> list2 = new List<Enum169>();
		foreach (ChartSeries item2 in series)
		{
			Enum169 item = ChartTypeCharacterizer.smethod_0(item2.Type);
			if (!item2.PlotOnSecondAxis && !list.Contains(item))
			{
				list.Add(item);
			}
			if (item2.PlotOnSecondAxis && !list2.Contains(item))
			{
				list2.Add(item);
			}
		}
		if (!secondaryAxes)
		{
			list.Add(ChartTypeCharacterizer.smethod_0(seriesType));
		}
		else
		{
			list2.Add(ChartTypeCharacterizer.smethod_0(seriesType));
		}
		if (!secondaryAxes)
		{
			if (list.Count != 0)
			{
				return method_3(list).HasValue;
			}
			return true;
		}
		if (list2.Count != 0)
		{
			return method_3(list2).HasValue;
		}
		return true;
	}
}
