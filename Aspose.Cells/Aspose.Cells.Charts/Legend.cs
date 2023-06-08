using System.Runtime.CompilerServices;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates the object that represents the chart legend.
///       </summary>
/// <example>
///   <code>
///       [C#]
///
///       //Set Legend's width and height
///       Legend legend = chart.Legend;
///
///       //Legend is at right side of chart by default.
///       //If the legend is at left or right side of the chart, setting Legend.X property will not take effect.
///       //If the legend is at top or bottom side of the chart, setting Legend.Y property will not take effect.
///       legend.Y = 1500;
///       legend.Width = 50;
///       legend.Height = 50; 
///       //Set legend's position
///       legend.Position = LegendPositionType.Left;
///
///       [Visual Basic]
///
///       'Set Legend's width and height
///       Dim legend as Legend = chart.Legend
///
///       'Legend is at right side of chart by default.
///       'If the legend is at left or right side of the chart, setting Legend.X property will not take effect.
///       'If the legend is at top or bottom side of the chart, setting Legend.Y property will not take effect.
///       legend.Y = 1500
///       legend.Width = 50
///       legend.Height = 50
///       'Set legend's position
///       legend.Position = LegendPositionType.Left
///       </code>
/// </example>
public class Legend : ChartFrame
{
	internal byte[] byte_1;

	internal byte[] byte_2;

	private LegendPositionType legendPositionType_0 = LegendPositionType.Right;

	private LegendEntryCollection legendEntryCollection_0;

	private int int_12;

	private int int_13;

	private bool bool_5;

	private bool bool_6;

	internal bool bool_7;

	/// <summary>
	///       Gets or sets the legend position type.
	///       </summary>
	/// <remarks>
	///   <br>Default position is right.</br>
	///   <br>If the legend is at left or right side of the chart, setting Legend.X property will not take effect.</br>
	///   <br>If the legend is at top or bottom side of the chart, setting Legend.Y property will not take effect.</br>
	/// </remarks>
	public LegendPositionType Position
	{
		get
		{
			return legendPositionType_0;
		}
		set
		{
			if (value == LegendPositionType.NotDocked)
			{
				if (legendPositionType_0 == LegendPositionType.Left || legendPositionType_0 == LegendPositionType.Right || legendPositionType_0 == LegendPositionType.Corner)
				{
					bool_5 = true;
				}
				base.Chart.PlotArea.method_42(bool_6: true);
			}
			else
			{
				method_19(bool_5: true);
				method_21(bool_5: true);
				base.IsAutoSize = true;
			}
			legendPositionType_0 = value;
		}
	}

	/// <summary>
	///       Gets a collection of all the LegendEntry objects in the specified chart legend.
	///       Setting the legend entries of the surface chart is not supported.
	///       So it will return null if the chart type is surface chart type.
	///       </summary>
	public LegendEntryCollection LegendEntries
	{
		get
		{
			if (legendEntryCollection_0 == null)
			{
				legendEntryCollection_0 = new LegendEntryCollection(base.Chart);
			}
			return legendEntryCollection_0;
		}
	}

	internal Legend(Chart chart_1)
		: base(chart_1)
	{
		if (chart_1.ChartArea != null)
		{
			m_AutoScaleFont = chart_1.ChartArea.AutoScaleFont;
		}
		method_8(Enum18.const_2);
	}

	internal void method_39(LegendPositionType legendPositionType_1)
	{
		legendPositionType_0 = legendPositionType_1;
	}

	[SpecialName]
	internal int method_40()
	{
		return int_12;
	}

	[SpecialName]
	internal void method_41(int int_14)
	{
		int_12 = int_14;
	}

	[SpecialName]
	internal int method_42()
	{
		return int_13;
	}

	[SpecialName]
	internal void method_43(int int_14)
	{
		int_13 = int_14;
	}

	internal LegendEntryCollection method_44()
	{
		return legendEntryCollection_0;
	}

	[SpecialName]
	internal bool method_45()
	{
		return bool_5;
	}

	[SpecialName]
	internal void method_46(bool bool_8)
	{
		bool_5 = bool_8;
	}

	internal void method_47()
	{
		legendEntryCollection_0 = null;
	}

	internal void Copy(Legend legend_0)
	{
		Copy((ChartFrame)legend_0);
		legendPositionType_0 = legend_0.legendPositionType_0;
		bool_5 = legend_0.bool_5;
		if (legend_0.legendEntryCollection_0 != null && legend_0.legendEntryCollection_0.Count != 0)
		{
			legendEntryCollection_0 = new LegendEntryCollection(base.Chart);
			legendEntryCollection_0.Copy(legend_0.legendEntryCollection_0);
		}
	}

	[SpecialName]
	internal bool method_48()
	{
		return bool_6;
	}

	[SpecialName]
	internal void method_49(bool bool_8)
	{
		bool_6 = bool_8;
		bool_7 = true;
	}
}
