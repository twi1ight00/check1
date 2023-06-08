using System;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns21;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///        Represents error bar of data series.
///        </summary>
/// <example>
///   <code>
///        [C#]
///        Workbook workbook = new Workbook();
///        Cells cells = workbook.Worksheets[0].Cells;
///        cells["a1"].PutValue(2);
///        cells["a2"].PutValue(5);
///        cells["a3"].PutValue(3);
///        cells["a4"].PutValue(6);
///        cells["b1"].PutValue(4);
///        cells["b2"].PutValue(3);
///        cells["b3"].PutValue(6);
///        cells["b4"].PutValue(7);
///
///        cells["C1"].PutValue("Q1");
///        cells["C2"].PutValue("Q2");
///        cells["C3"].PutValue("Y1");
///        cells["C4"].PutValue("Y2");
///
///        int chartIndex = excel.Worksheets[0].Charts.Add(ChartType.Column, 11, 0, 27, 10);
///
///        Chart chart = excel.Worksheets[0].Charts[chartIndex];
///        chart.NSeries.Add("A1:B4", true);
///
///        chart.NSeries.CategoryData = "C1:C4";
///
///        for(int i = 0; i &lt; chart.NSeries.Count; i ++)
///        {
///       		ASeries aseries = chart.NSeries[i];
///       		aseries.ErrorBar.DisplayType = ErrorBarDisplayType.Minus;
///       		aseries.ErrorBar.Type = ErrorBarType.FixedValue;
///       		aseries.ErrorBar.Amount = 5;
///        }
///
///        [Visual Basic]
///        Dim workbook As Workbook =  New Workbook() 
///        Dim cells As Cells =  workbook.Worksheets(0).Cells 
///        cells("a1").PutValue(2)
///        cells("a2").PutValue(5)
///        cells("a3").PutValue(3)
///        cells("a4").PutValue(6)
///        cells("b1").PutValue(4)
///        cells("b2").PutValue(3)
///        cells("b3").PutValue(6)
///        cells("b4").PutValue(7)
///
///        cells("C1").PutValue("Q1")
///        cells("C2").PutValue("Q2")
///        cells("C3").PutValue("Y1")
///        cells("C4").PutValue("Y2")
///
///        Dim chartIndex As Integer =  excel.Worksheets(0).Charts.Add(ChartType.Column,11,0,27,10) 
///
///        Dim chart As Chart =  excel.Worksheets(0).Charts(chartIndex) 
///        chart.NSeries.Add("A1:B4", True)
///
///        chart.NSeries.CategoryData = "C1:C4"
///
///        Dim i As Integer
///        For  i = 0 To chart.NSeries.Count - 1
///        Dim aseries As ASeries =  chart.NSeries(i) 
///        aseries.ErrorBar.DisplayType = ErrorBarDisplayType.Minus
///        aseries.ErrorBar.Type = ErrorBarType.FixedValue
///        aseries.ErrorBar.Amount = 5
///        Next
///        </code>
/// </example>
public class ErrorBar : Line
{
	private Series series_0;

	private ErrorBarType errorBarType_0 = ErrorBarType.FixedValue;

	private ErrorBarDisplayType errorBarDisplayType_0 = ErrorBarDisplayType.None;

	private double double_0;

	private bool bool_0 = true;

	private bool bool_1 = true;

	private Interface45 interface45_0;

	private Interface45 interface45_1;

	private ShapePropertyCollection shapePropertyCollection_0;

	/// <summary>
	///       Represents error bar amount type.
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///       //Sets custom error bar type
	///       aseries.ErrorBar.Type = ErrorBarType.Custom;
	///       aseries.ErrorBar.PlusValue = "=Sheet1!A1";
	///       aseries.ErrorBar.MinusValue = "=Sheet1!A2";
	///
	///       [Visual Basic]
	///       'Sets custom error bar type
	///       aseries.ErrorBar.Type = ErrorBarType.Custom
	///       aseries.ErrorBar.PlusValue = "=Sheet1!A1"
	///       aseries.ErrorBar.MinusValue = "=Sheet1!A2"
	///       </code>
	/// </example>
	public ErrorBarType Type
	{
		get
		{
			return errorBarType_0;
		}
		set
		{
			errorBarType_0 = value;
		}
	}

	/// <summary>
	///       Represents error bar display type.
	///       </summary>
	public ErrorBarDisplayType DisplayType
	{
		get
		{
			return errorBarDisplayType_0;
		}
		set
		{
			errorBarDisplayType_0 = value;
		}
	}

	/// <summary>
	///       Represents amount of error bar.
	///       <remarks> The amount must be greater than and equal to zero.</remarks></summary>
	public double Amount
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentException("Invalid amount value of error bar: it must be greater than and equal to zero.");
			}
			double_0 = value;
		}
	}

	/// <summary>
	///       Indicates if formatting error bars with a T-top.
	///       </summary>
	public bool ShowMarkerTTop
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

	/// <summary>
	///       Represents positive error amount when error bar type is Custom.
	///       </summary>
	public string PlusValue
	{
		get
		{
			if (interface45_0 != null)
			{
				return interface45_0.Values;
			}
			return null;
		}
		set
		{
			string text = method_34(value);
			if (text != null && !(text == ""))
			{
				interface45_0 = Class1195.smethod_1(series_0.method_10(), series_0.method_11(), text);
			}
			else
			{
				interface45_0 = null;
			}
		}
	}

	/// <summary>
	///       Represents negative error amount when error bar type is Custom.
	///       </summary>
	public string MinusValue
	{
		get
		{
			if (interface45_1 == null)
			{
				return null;
			}
			return interface45_1.Values;
		}
		set
		{
			string text = method_34(value);
			if (text != null && !(text == ""))
			{
				interface45_1 = Class1195.smethod_1(series_0.method_10(), series_0.method_11(), text);
			}
			else
			{
				interface45_1 = null;
			}
		}
	}

	internal ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (shapePropertyCollection_0 == null)
			{
				shapePropertyCollection_0 = new ShapePropertyCollection(series_0.method_28().method_0().Chart, this, Enum178.const_7);
			}
			return shapePropertyCollection_0;
		}
	}

	internal ErrorBar(Series series_1, bool bool_2)
		: base(series_1.NSeries.Chart, series_1)
	{
		series_0 = series_1;
		bool_0 = bool_2;
	}

	internal void Copy(ErrorBar errorBar_0)
	{
		Copy((Line)errorBar_0);
		errorBarType_0 = errorBar_0.errorBarType_0;
		double_0 = errorBar_0.double_0;
		errorBarDisplayType_0 = errorBar_0.errorBarDisplayType_0;
		interface45_1 = errorBar_0.interface45_1;
		interface45_0 = errorBar_0.interface45_0;
		bool_1 = errorBar_0.bool_1;
		bool_0 = errorBar_0.bool_0;
		if (errorBar_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(series_0.method_28().method_0().Chart, this, Enum178.const_7);
			shapePropertyCollection_0.Copy(errorBar_0.shapePropertyCollection_0);
		}
	}

	internal void method_31(ErrorBarDisplayType errorBarDisplayType_1)
	{
		errorBarDisplayType_0 = errorBarDisplayType_1;
	}

	internal void method_32(double double_1)
	{
		double_0 = double_1;
	}

	[SpecialName]
	internal bool method_33()
	{
		return bool_0;
	}

	private string method_34(string string_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		string_0 = string_0.Trim();
		if (string_0 != null && !(string_0 == ""))
		{
			if (string_0[0] == '=')
			{
				string_0 = string_0.Substring(1);
			}
			if (string_0 != null && !(string_0 == ""))
			{
				return string_0;
			}
			return null;
		}
		return null;
	}

	[SpecialName]
	internal Interface45 method_35()
	{
		return interface45_0;
	}

	[SpecialName]
	internal void method_36(Interface45 interface45_2)
	{
		interface45_0 = interface45_2;
	}

	[SpecialName]
	internal Interface45 method_37()
	{
		return interface45_1;
	}

	[SpecialName]
	internal void method_38(Interface45 interface45_2)
	{
		interface45_1 = interface45_2;
	}

	[SpecialName]
	internal Series method_39()
	{
		return series_0;
	}
}
