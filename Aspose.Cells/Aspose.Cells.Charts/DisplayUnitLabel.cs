using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Represents the display unit label.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///       //Adding a new worksheet to the Excel object
///       int sheetIndex = workbook.Worksheets.Add();
///       //Obtaining the reference of the newly added worksheet by passing its sheet index
///       Worksheet worksheet = workbook.Worksheets[sheetIndex];
///       //Adding a sample value to "A1" cell
///       worksheet.Cells["A1"].PutValue(50);
///       //Adding a sample value to "A2" cell
///       worksheet.Cells["A2"].PutValue(100);
///       //Adding a sample value to "A3" cell
///       worksheet.Cells["A3"].PutValue(150);
///       //Adding a sample value to "A4" cell
///       worksheet.Cells["A4"].PutValue(200);
///       //Adding a sample value to "B1" cell
///       worksheet.Cells["B1"].PutValue(60);
///       //Adding a sample value to "B2" cell
///       worksheet.Cells["B2"].PutValue(32);
///       //Adding a sample value to "B3" cell
///       worksheet.Cells["B3"].PutValue(50);
///       //Adding a sample value to "B4" cell
///       worksheet.Cells["B4"].PutValue(40);
///       //Adding a sample value to "C1" cell as category data
///       worksheet.Cells["C1"].PutValue("Q1");
///       //Adding a sample value to "C2" cell as category data
///       worksheet.Cells["C2"].PutValue("Q2");
///       //Adding a sample value to "C3" cell as category data
///       worksheet.Cells["C3"].PutValue("Y1");
///       //Adding a sample value to "C4" cell as category data
///       worksheet.Cells["C4"].PutValue("Y2");
///       //Adding a chart to the worksheet
///       int chartIndex = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5);
///       //Accessing the instance of the newly added chart
///       Chart chart = worksheet.Charts[chartIndex];
///       //Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B4"
///       chart.NSeries.Add("A1:B4", true);
///       //Setting the data source for the category data of NSeries
///       chart.NSeries.CategoryData = "C1:C4";
///       //Setting the display unit of value(Y) axis.
///       chart.ValueAxis.DisplayUnit = DisplayUnitType.Hundreds;
///       DisplayUnitLabel displayUnitLabel = chart.ValueAxis.DisplayUnitLabel;
///       //Setting the custom display unit label
///       displayUnitLabel.Text = "100";
///       //Saving the Excel file
///       workbook.Save("C:\\book1.xls");
///
///       [Visual Basic]
///
///       'Instantiating a Workbook object
///       Dim workbook As Workbook = New Workbook()
///       'Adding a new worksheet to the Excel object
///       Dim sheetIndex As Int32 = workbook.Worksheets.Add()
///       'Obtaining the reference of the newly added worksheet by passing its sheet index
///       Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)
///       'Adding a sample value to "A1" cell
///       worksheet.Cells("A1").PutValue(50)
///       'Adding a sample value to "A2" cell
///       worksheet.Cells("A2").PutValue(100)
///       'Adding a sample value to "A3" cell
///       worksheet.Cells("A3").PutValue(150)
///       'Adding a sample value to "A4" cell
///       worksheet.Cells("A4").PutValue(200)
///       'Adding a sample value to "B1" cell
///       worksheet.Cells("B1").PutValue(60)
///       'Adding a sample value to "B2" cell
///       worksheet.Cells("B2").PutValue(32)
///       'Adding a sample value to "B3" cell
///       worksheet.Cells("B3").PutValue(50)
///       'Adding a sample value to "B4" cell
///       worksheet.Cells("B4").PutValue(40)
///       'Adding a sample value to "C1" cell as category data
///       worksheet.Cells("C1").PutValue("Q1")
///       'Adding a sample value to "C2" cell as category data
///       worksheet.Cells("C2").PutValue("Q2")
///       'Adding a sample value to "C3" cell as category data
///       worksheet.Cells("C3").PutValue("Y1")
///       'Adding a sample value to "C4" cell as category data
///       worksheet.Cells("C4").PutValue("Y2")
///       'Adding a chart to the worksheet
///       Dim chartIndex As Int32 = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5)
///       'Accessing the instance of the newly added chart
///       Dim chart As Chart = worksheet.Charts(chartIndex)
///       'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B4"
///       chart.NSeries.Add("A1:B4", True)
///       'Setting the data source for the category data of NSeries
///       Chart.NSeries.CategoryData = "C1:C4"
///       'Setting the display unit of value(Y) axis.
///       chart.ValueAxis.DisplayUnit = DisplayUnitType.Hundreds
///       Dim displayUnitLabel As DisplayUnitLabel = chart.ValueAxis.DisplayUnitLabel
///       'Setting the custom display unit label
///       displayUnitLabel.Text = "100"
///       'Saving the Excel file
///       workbook.Save("C:\\book1.xls")
///       </code>
/// </example>
public class DisplayUnitLabel : ChartFrame
{
	private Axis axis_0;

	private TextAlignmentType textAlignmentType_0 = TextAlignmentType.Center;

	private TextAlignmentType textAlignmentType_1 = TextAlignmentType.Center;

	private int int_12;

	private string string_0;

	internal byte[] byte_1;

	private TextDirectionType textDirectionType_0;

	/// <summary>
	///       Ges or sets the text horizontal alignment.
	///       </summary>
	public TextAlignmentType TextHorizontalAlignment
	{
		get
		{
			return textAlignmentType_0;
		}
		set
		{
			switch (value)
			{
			case TextAlignmentType.Center:
			case TextAlignmentType.Distributed:
			case TextAlignmentType.Justify:
			case TextAlignmentType.Left:
			case TextAlignmentType.Right:
				textAlignmentType_0 = value;
				break;
			case TextAlignmentType.CenterAcross:
			case TextAlignmentType.Fill:
			case TextAlignmentType.General:
				break;
			}
		}
	}

	/// <summary>
	///       Gets or sets the text vertical alignment of text.
	///       </summary>
	public TextAlignmentType TextVerticalAlignment
	{
		get
		{
			return textAlignmentType_1;
		}
		set
		{
			switch (value)
			{
			case TextAlignmentType.Bottom:
			case TextAlignmentType.Center:
			case TextAlignmentType.Distributed:
			case TextAlignmentType.Justify:
			case TextAlignmentType.Top:
				textAlignmentType_1 = value;
				break;
			}
		}
	}

	/// <summary>
	///       Represents text rotation angle.
	///       </summary>
	/// <remarks>
	///   <br>0: Not rotated.</br>
	///   <br>255: Top to Bottom.</br>
	///   <br>-90: Downward.</br>
	///   <br>90: Upward.</br>
	/// </remarks>
	public int RotationAngle
	{
		get
		{
			return int_12;
		}
		set
		{
			if ((value < -90 || value > 90) && value != 255)
			{
				throw new ArgumentException("Invalid rotation : it must be between -90 and 90 or equal 255");
			}
			int_12 = value;
		}
	}

	/// <summary>
	///       Represents text rotation angle.
	///       </summary>
	/// <remarks>
	///   <br>0: Not rotated.</br>
	///   <br>255: Top to Bottom.</br>
	///   <br>-90: Downward.</br>
	///   <br>90: Upward.</br>
	/// </remarks>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use DisplayUnitLabel.RotationAngle property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use DisplayUnitLabel.RotationAngle property instead.")]
	public int Rotation
	{
		get
		{
			return int_12;
		}
		set
		{
			RotationAngle = value;
		}
	}

	/// <summary>
	///       Gets or sets the text of a frame's title.
	///       </summary>
	public string Text
	{
		get
		{
			if (!axis_0.IsDisplayUnitLabelShown)
			{
				return "";
			}
			if (string_0 == null)
			{
				switch (axis_0.DisplayUnit)
				{
				case DisplayUnitType.None:
					return "";
				case DisplayUnitType.Hundreds:
					return "Hundreds";
				case DisplayUnitType.Thousands:
					return "Thousands";
				case DisplayUnitType.Millions:
					return "Millions";
				case DisplayUnitType.Billions:
					return "Billions";
				case DisplayUnitType.Trillions:
					return "Trillions";
				}
			}
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets a reference to the worksheet.
	///       </summary>
	public string LinkedSource
	{
		get
		{
			if (byte_1 == null)
			{
				return null;
			}
			Chart chart = base.Chart;
			Interface45 @interface = Class1195.smethod_0(chart.method_14(), chart.method_15());
			@interface.imethod_5(byte_1);
			@interface.imethod_14(Enum126.const_2);
			return @interface.Values;
		}
		set
		{
			Chart chart = base.Chart;
			Interface45 @interface = Class1195.smethod_1(chart.method_14(), chart.method_15(), value);
			byte_1 = @interface.imethod_4();
			string_0 = @interface.imethod_9();
		}
	}

	public override Font Font
	{
		get
		{
			if (m_font == null)
			{
				m_font = new Font(base.Chart.method_14(), null, bool_0: true);
				if (axis_0.Chart.ChartArea != null)
				{
					m_font.Copy(axis_0.Chart.ChartArea.Font);
					m_font.method_25();
				}
				if (AutoScaleFont)
				{
					m_font.method_5(new Class1383(base.Chart, 10, bool_0: true));
				}
			}
			return m_font;
		}
	}

	/// <summary>
	///       True if the text in the object changes font size when the object size changes. The default value is True. 
	///       </summary>
	public override bool AutoScaleFont
	{
		get
		{
			return m_AutoScaleFont;
		}
		set
		{
			if (m_AutoScaleFont == value)
			{
				return;
			}
			if (value)
			{
				if (m_font != null)
				{
					Class1383 object_ = new Class1383(base.Chart, m_font.Size, bool_0: true);
					m_font.method_5(object_);
				}
			}
			else
			{
				Font.method_5(null);
			}
			m_AutoScaleFont = value;
		}
	}

	/// <summary>
	///        Represents text reading order.
	///       </summary>
	public TextDirectionType TextDirection
	{
		get
		{
			return textDirectionType_0;
		}
		set
		{
			textDirectionType_0 = value;
		}
	}

	internal DisplayUnitLabel(Axis axis_1)
		: base(axis_1.Chart)
	{
		axis_0 = axis_1;
		base.Border.IsVisible = false;
		base.Area.Formatting = FormattingType.None;
		if (!ChartCollection.smethod_8(axis_1.Chart.Type))
		{
			RotationAngle = 90;
		}
		if (axis_1.Chart.ChartArea != null)
		{
			m_AutoScaleFont = axis_1.Chart.ChartArea.AutoScaleFont;
		}
		Font.IsBold = true;
		method_8(Enum18.const_7);
	}

	internal string method_39()
	{
		return string_0;
	}

	internal void method_40(string string_1)
	{
		Chart chart = base.Chart;
		Interface45 @interface = Class1195.smethod_1(chart.method_14(), chart.method_15(), string_1);
		byte_1 = @interface.imethod_4();
	}

	internal void Copy(DisplayUnitLabel displayUnitLabel_0)
	{
		Copy((ChartFrame)displayUnitLabel_0);
		int_12 = displayUnitLabel_0.int_12;
		textAlignmentType_0 = displayUnitLabel_0.textAlignmentType_0;
		textAlignmentType_1 = displayUnitLabel_0.textAlignmentType_1;
		textDirectionType_0 = displayUnitLabel_0.textDirectionType_0;
		string_0 = displayUnitLabel_0.string_0;
	}

	[SpecialName]
	internal bool method_41()
	{
		if (!base.Border.IsVisible && base.Area.Formatting == FormattingType.None)
		{
			return false;
		}
		return true;
	}
}
