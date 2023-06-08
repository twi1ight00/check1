using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///        Encapsulates a collection of all the DataLabel objects for the specified Series.
///        </summary>
/// <example>
///   <code>
///
///        [C#]
///
///        //Set the DataLabels in the chart
///        DataLabels datalabels;
///        for (int i = 0; i  &lt;chart.NSeries.Count; i++)
///        {
///            datalabels = chart.NSeries[i].DataLabels;
///            //Set the position of DataLabels
///            datalabels.Position = LabelPositionType.InsideBase;
///            //Show the category name in the DataLabels
///            datalabels.IsCategoryNameShown = true;
///            //Show the value in the DataLabels
///            datalabels.IsValueShown = true;
///            //Not show the percentage in the DataLabels
///            datalabels.IsPercentageShown = false;
///            //Not show the legend key.
///            datalabels.IsLegendKeyShown = false;
///        }
///
///        [Visual Basic]
///
///        'Set the DataLabels in the chart
///        Dim datalabels As DataLabels
///        Dim i As Integer
///        For i = 0 To chart.NSeries.Count - 1 Step 1
///            datalabels = chart.NSeries(i).DataLabels
///            'Set the position of DataLabels
///            datalabels.Postion = LabelPositionType.InsideBase
///            'Show the category name in the DataLabels
///            datalabels.IsCategoryNameShown = True
///            'Show the value in the DataLabels
///            datalabels.IsValueShown = True
///            'Not show the percentage in the DataLabels
///            datalabels.IsPercentageShown = False
///            'Not show the legend key.
///            datalabels.IsLegendKeyShown = False
///        Next
///        </code>
/// </example>
public class DataLabels : ChartFrame
{
	private object object_0;

	private byte byte_1;

	internal byte[] byte_2;

	private bool bool_5 = true;

	private bool bool_6;

	private TextAlignmentType textAlignmentType_0 = TextAlignmentType.Center;

	private TextAlignmentType textAlignmentType_1 = TextAlignmentType.Center;

	private int int_12;

	private ArrayList arrayList_0;

	private string string_0;

	internal byte[] byte_3;

	private TextDirectionType textDirectionType_0;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private string string_1;

	private int int_13;

	private bool bool_13 = true;

	private DataLablesSeparatorType dataLablesSeparatorType_0;

	internal bool bool_14;

	private LabelPositionType labelPositionType_0 = LabelPositionType.OutsideEnd;

	internal bool bool_15 = true;

	/// <summary>
	///       Indicates the text is auto generated.
	///       </summary>
	public bool IsAutoText
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	/// <summary>
	///       Indicates whether this data lables is deleted.
	///       </summary>
	public bool IsDeleted
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

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
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use DataLabels.RotationAngle property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use DataLabels.RotationAngle property instead.")]
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
	///       Gets or sets the text of a frame's title.
	///       </summary>
	public string Text
	{
		get
		{
			if (byte_3 != null)
			{
				Chart chart = base.Chart;
				Interface45 @interface = Class1195.smethod_0(chart.method_14(), chart.method_15());
				@interface.imethod_5(byte_3);
				string_0 = @interface.imethod_9();
			}
			return string_0;
		}
		set
		{
			string_0 = value;
			bool_5 = false;
			if (value == null)
			{
				bool_6 = true;
			}
			arrayList_0 = null;
		}
	}

	/// <summary>
	///       Gets and sets a reference to the worksheet.
	///       </summary>
	public string LinkedSource
	{
		get
		{
			if (byte_3 == null)
			{
				return null;
			}
			Chart chart = base.Chart;
			Interface45 @interface = Class1195.smethod_0(chart.method_14(), chart.method_15());
			@interface.imethod_5(byte_3);
			@interface.imethod_14(Enum126.const_2);
			return @interface.Values;
		}
		set
		{
			Chart chart = base.Chart;
			Interface45 @interface = Class1195.smethod_1(chart.method_14(), chart.method_15(), value);
			byte_3 = @interface.imethod_4();
			string_0 = @interface.imethod_9();
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

	/// <summary>
	///       Gets and sets the display mode of the background
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use DataLabels.BackgroundMode property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[Obsolete("Use DataLabels.BackgroundMode property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new BackgroundMode Background
	{
		get
		{
			return m_BackgroundMode;
		}
		set
		{
			BackgroundMode = value;
		}
	}

	/// <summary>
	///       Gets and sets the display mode of the background
	///       </summary>
	public new BackgroundMode BackgroundMode
	{
		get
		{
			return m_BackgroundMode;
		}
		set
		{
			if (object_0 != null && object_0 is Series)
			{
				Series series = (Series)object_0;
				if (series.method_3() != null)
				{
					for (int i = 0; i < series.Points.method_4(); i++)
					{
						ChartPoint chartPoint = series.Points.method_7(i);
						if (chartPoint.method_9() != null)
						{
							chartPoint.DataLabels.BackgroundMode = value;
						}
					}
				}
			}
			m_BackgroundMode = value;
		}
	}

	/// <summary>
	///       Represents a specified chart's data label values display behavior. True displays the values. False to hide. 
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use DataLabels.ShowValue property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use DataLabels.ShowValue property instead.")]
	public bool IsValueShown
	{
		get
		{
			return bool_7;
		}
		set
		{
			ShowValue = value;
		}
	}

	/// <summary>
	///       Represents a specified chart's data label values display behavior. True displays the values. False to hide. 
	///       </summary>
	public bool ShowValue
	{
		get
		{
			if (!bool_14 && method_60() != null && method_60() is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				Series series = chartPoint.method_0();
				if (series.method_24() != null && series.DataLabels.bool_14)
				{
					return series.DataLabels.ShowValue;
				}
			}
			return bool_7;
		}
		set
		{
			method_46(0, value);
			if (bool_7 != value)
			{
				bool_7 = value;
				bool_14 = true;
			}
		}
	}

	/// <summary>
	///       Represents a specified chart's data label percentage value display behavior. 
	///       True displays the percentage value. False to hide. 
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use DataLabels.ShowPercentage property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use DataLabels.ShowPercentage property instead.")]
	public bool IsPercentageShown
	{
		get
		{
			return bool_8;
		}
		set
		{
			ShowPercentage = value;
		}
	}

	/// <summary>
	///       Represents a specified chart's data label percentage value display behavior. True displays the percentage value. False to hide. 
	///       </summary>
	public bool ShowPercentage
	{
		get
		{
			if (!bool_14 && method_60() != null && method_60() is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				Series series = chartPoint.method_0();
				if (series.method_24() != null && series.DataLabels.bool_14)
				{
					return series.DataLabels.ShowPercentage;
				}
			}
			return bool_8;
		}
		set
		{
			method_46(1, value);
			if (bool_8 != value)
			{
				switch (Type)
				{
				case ChartType.Doughnut:
				case ChartType.DoughnutExploded:
				case ChartType.Pie:
				case ChartType.Pie3D:
				case ChartType.PiePie:
				case ChartType.PieExploded:
				case ChartType.Pie3DExploded:
				case ChartType.PieBar:
					bool_8 = value;
					bool_14 = true;
					break;
				case ChartType.Line:
				case ChartType.LineStacked:
				case ChartType.Line100PercentStacked:
				case ChartType.LineWithDataMarkers:
				case ChartType.LineStackedWithDataMarkers:
				case ChartType.Line100PercentStackedWithDataMarkers:
				case ChartType.Line3D:
					break;
				}
			}
		}
	}

	/// <summary>
	///       Represents a specified chart's data label percentage value display behavior. True displays the percentage value. False to hide. 
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use DataLabels.ShowBubbleSize property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use DataLabels.ShowBubbleSize property instead.")]
	[Browsable(false)]
	public bool IsBubbleSizeShown
	{
		get
		{
			return bool_9;
		}
		set
		{
			ShowBubbleSize = value;
		}
	}

	/// <summary>
	///       Represents a specified chart's data label percentage value display behavior. True displays the percentage value. False to hide. 
	///       </summary>
	public bool ShowBubbleSize
	{
		get
		{
			if (!bool_14 && method_60() != null && method_60() is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				Series series = chartPoint.method_0();
				if (series.method_24() != null && series.DataLabels.bool_14)
				{
					return series.DataLabels.ShowBubbleSize;
				}
			}
			return bool_9;
		}
		set
		{
			method_46(3, value);
			if (bool_9 != value)
			{
				switch (Type)
				{
				case ChartType.Bubble:
				case ChartType.Bubble3D:
					bool_9 = value;
					bool_14 = true;
					break;
				}
			}
		}
	}

	/// <summary>
	///       Represents a specified chart's data label category name display behavior.True to display the category name for the data labels on a chart. False to hide.
	///       </summary>
	public bool ShowCategoryName
	{
		get
		{
			if (!bool_14 && method_60() != null && method_60() is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				Series series = chartPoint.method_0();
				if (series.method_24() != null && series.DataLabels.bool_14)
				{
					return series.DataLabels.ShowCategoryName;
				}
			}
			return bool_10;
		}
		set
		{
			method_46(2, value);
			if (bool_10 != value)
			{
				bool_10 = value;
				bool_14 = true;
			}
		}
	}

	/// <summary>
	///       Represents a specified chart's data label category name display behavior.True to display the category name for the data labels on a chart. False to hide.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use DataLabels.ShowCategoryName property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use DataLabels.ShowCategoryName property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsCategoryNameShown
	{
		get
		{
			return bool_10;
		}
		set
		{
			ShowCategoryName = value;
		}
	}

	/// <summary>
	///       Returns or sets a Boolean to indicate the series name display behavior for the data labels on a chart.
	///       True to show the series name. False to hide.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use DataLabels.ShowSeriesName property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use DataLabels.ShowSeriesName property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsSeriesNameShown
	{
		get
		{
			return bool_11;
		}
		set
		{
			ShowSeriesName = value;
		}
	}

	/// <summary>
	///       Returns or sets a Boolean to indicate the series name display behavior for the data labels on a chart.
	///       True to show the series name. False to hide.
	///       </summary>
	public bool ShowSeriesName
	{
		get
		{
			if (!bool_14 && method_60() != null && method_60() is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				Series series = chartPoint.method_0();
				if (series.method_24() != null && series.DataLabels.bool_14)
				{
					return series.DataLabels.ShowSeriesName;
				}
			}
			return bool_11;
		}
		set
		{
			method_46(4, value);
			bool_11 = value;
			bool_14 = true;
		}
	}

	/// <summary>
	///       Represents a specified chart's data label legend key display behavior.True if the data label legend key is visible.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use DataLabels.ShowLegendKey property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use DataLabels.ShowLegendKey property instead.")]
	public bool IsLegendKeyShown
	{
		get
		{
			if (!bool_14 && method_60() != null && method_60() is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				Series series = chartPoint.method_0();
				if (series.method_24() != null && series.DataLabels.bool_14)
				{
					return series.DataLabels.ShowLegendKey;
				}
			}
			return bool_12;
		}
		set
		{
			ShowLegendKey = value;
		}
	}

	/// <summary>
	///       Represents a specified chart's data label legend key display behavior.
	///       True if the data label legend key is visible.
	///       </summary>
	public bool ShowLegendKey
	{
		get
		{
			return bool_12;
		}
		set
		{
			method_46(5, value);
			bool_12 = value;
			bool_14 = true;
		}
	}

	/// <summary>
	///       Represents the format string for the DataLabels object. 
	///       </summary>
	public string NumberFormat
	{
		get
		{
			if (!method_54() && object_0 != null && object_0 is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				DataLabels dataLabels = chartPoint.method_0().method_24();
				if (dataLabels != null && dataLabels.method_54())
				{
					return dataLabels.string_1;
				}
			}
			return string_1;
		}
		set
		{
			byte_1 |= 1;
			string_1 = value;
			int_13 = 0;
			bool_13 = false;
			if (object_0 == null || !(object_0 is Series))
			{
				return;
			}
			Series series = (Series)object_0;
			if (series.method_3() == null)
			{
				return;
			}
			for (int i = 0; i < series.Points.method_4(); i++)
			{
				ChartPoint chartPoint = series.Points.method_7(i);
				if (chartPoint.method_9() != null)
				{
					chartPoint.DataLabels.NumberFormat = value;
				}
			}
		}
	}

	/// <summary>
	///       Gets ans sets the built-in number format.
	///       </summary>
	public int Number
	{
		get
		{
			if (!method_54() && object_0 != null && object_0 is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				DataLabels dataLabels = chartPoint.method_0().method_24();
				if (dataLabels != null && dataLabels.method_54())
				{
					if (dataLabels.int_13 >= 0 && dataLabels.int_13 < 59)
					{
						return (byte)dataLabels.int_13;
					}
					return 0;
				}
			}
			if (int_13 >= 0 && int_13 < 59)
			{
				return (byte)int_13;
			}
			return 0;
		}
		set
		{
			if (value < 59 && value >= 0)
			{
				string_1 = null;
				int_13 = value;
			}
			else
			{
				int_13 = value;
			}
			bool_13 = false;
			byte_1 |= 1;
		}
	}

	/// <summary>
	///       True if the number format is linked to the cells 
	///       (so that the number format changes in the labels when it changes in the cells). 
	///       </summary>
	public bool NumberFormatLinked
	{
		get
		{
			if (!method_54() && object_0 != null && object_0 is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				DataLabels dataLabels = chartPoint.method_0().method_24();
				if (dataLabels != null && dataLabels.method_54())
				{
					return dataLabels.bool_13;
				}
			}
			return bool_13;
		}
		set
		{
			bool_13 = value;
			byte_1 |= 1;
		}
	}

	public override Font Font
	{
		get
		{
			Chart chart = base.Chart;
			if (m_font == null && method_13() == -1 && object_0 != null && object_0 is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				DataLabels dataLabels = chartPoint.method_0().method_24();
				if (dataLabels != null)
				{
					if (dataLabels.m_font != null || dataLabels.method_13() != -1)
					{
						m_font = new Font(chart.method_14(), null, bool_0: true);
						Font font = dataLabels.Font;
						m_font.Copy(font);
						if (AutoScaleFont)
						{
							m_font.method_5(new Class1383(base.Chart, font.Size, bool_0: true));
						}
						return m_font;
					}
					if (dataLabels.method_54() && !method_54())
					{
						int_13 = dataLabels.int_13;
						string_1 = dataLabels.string_1;
						method_55(bool_16: true);
					}
				}
			}
			if (m_font == null)
			{
				m_font = new Font(chart.method_14(), null, bool_0: true);
				m_font.Size = 10;
				Font font2 = null;
				if (m_fontIndex != -1)
				{
					font2 = base.Chart.method_14().method_53(m_fontIndex);
					m_font.Copy(font2);
					m_font.InternalColor.IsShapeColor = true;
					Class1383 @class = base.Chart.method_41(m_fontIndex);
					if (@class != null)
					{
						Class1383 class2 = new Class1383(@class.chart_0, 0, bool_0: false);
						class2.Copy(@class);
						m_font.method_5(class2);
					}
				}
				else
				{
					font2 = chart.ChartArea.Font;
					m_font.Copy(font2);
					if (AutoScaleFont)
					{
						m_font.method_5(new Class1383(base.Chart, 10, bool_0: true));
					}
				}
			}
			return m_font;
		}
	}

	/// <summary>
	///       Sets or returns a Variant representing the separator used for the data labels on a chart.
	///       </summary>
	public DataLablesSeparatorType Separator
	{
		get
		{
			if (!method_58() && method_60() is ChartPoint)
			{
				ChartPoint chartPoint = (ChartPoint)method_60();
				DataLabels dataLabels = chartPoint.method_0().method_24();
				if (dataLabels != null && dataLabels.method_58())
				{
					return dataLabels.dataLablesSeparatorType_0;
				}
			}
			return dataLablesSeparatorType_0;
		}
		set
		{
			dataLablesSeparatorType_0 = value;
			byte_1 |= 2;
		}
	}

	/// <summary>
	///       Represents the position of the data lable.
	///       </summary>
	/// <remarks>This property will be removed 12 months later since October 2008. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use DataLables.Position property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public LabelPositionType Postion
	{
		get
		{
			return labelPositionType_0;
		}
		set
		{
			Position = value;
		}
	}

	/// <summary>
	///       Represents the position of the data lable.
	///       </summary>
	public LabelPositionType Position
	{
		get
		{
			if (bool_15 && ChartCollection.smethod_3(base.Chart.Type))
			{
				return LabelPositionType.BestFit;
			}
			return labelPositionType_0;
		}
		set
		{
			if (labelPositionType_0 == value)
			{
				bool_15 = false;
				return;
			}
			switch (value)
			{
			case LabelPositionType.Center:
				bool_15 = false;
				labelPositionType_0 = value;
				break;
			case LabelPositionType.InsideBase:
			case LabelPositionType.InsideEnd:
				if (ChartCollection.smethod_7(Type) || ChartCollection.smethod_3(Type))
				{
					bool_15 = false;
					labelPositionType_0 = value;
				}
				break;
			case LabelPositionType.OutsideEnd:
				if ((ChartCollection.smethod_7(Type) && !ChartCollection.smethod_9(Type)) || ChartCollection.smethod_3(Type))
				{
					bool_15 = false;
					labelPositionType_0 = value;
				}
				break;
			case LabelPositionType.Above:
			case LabelPositionType.Below:
			case LabelPositionType.Left:
			case LabelPositionType.Right:
				if (ChartCollection.smethod_14(Type) || ChartCollection.smethod_11(Type) || ChartCollection.smethod_17(Type))
				{
					bool_15 = false;
					labelPositionType_0 = value;
				}
				break;
			case LabelPositionType.BestFit:
				if (ChartCollection.smethod_3(Type))
				{
					bool_15 = false;
					labelPositionType_0 = value;
				}
				break;
			}
		}
	}

	internal ChartType Type
	{
		get
		{
			if (object_0 is ChartPoint)
			{
				return ((ChartPoint)object_0).method_1();
			}
			if (object_0 is Series)
			{
				return ((Series)object_0).Type;
			}
			return ChartType.Column;
		}
	}

	internal DataLabels(object object_1, Chart chart_1)
		: base(chart_1)
	{
		object_0 = object_1;
		if (chart_1 != null && chart_1.ChartArea != null)
		{
			m_AutoScaleFont = chart_1.ChartArea.AutoScaleFont;
		}
		if (ChartCollection.smethod_7(chart_1.Type) && ChartCollection.smethod_9(chart_1.Type))
		{
			labelPositionType_0 = LabelPositionType.Center;
		}
		if (object_1 != null && object_1 is Trendline)
		{
			method_8(Enum18.const_6);
		}
		else
		{
			method_8(Enum18.const_5);
		}
	}

	[SpecialName]
	internal ArrayList method_39()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_40(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	internal string method_41()
	{
		return string_0;
	}

	internal void method_42(string string_2)
	{
		string_0 = string_2;
	}

	[SpecialName]
	internal bool method_43()
	{
		if (!base.Border.IsVisible && base.Area.Formatting == FormattingType.None)
		{
			return false;
		}
		return true;
	}

	internal Font method_44()
	{
		return method_12();
	}

	internal void method_45(Enum127 enum127_0, bool bool_16)
	{
		if (bool_16)
		{
			bool_14 = true;
		}
		switch (enum127_0)
		{
		case Enum127.const_1:
			bool_7 = bool_16;
			break;
		case Enum127.const_2:
			bool_8 = bool_16;
			break;
		case Enum127.const_3:
			bool_10 = bool_16;
			break;
		case Enum127.const_4:
			bool_9 = bool_16;
			break;
		case Enum127.const_5:
			bool_11 = bool_16;
			break;
		}
	}

	private void method_46(byte byte_4, bool bool_16)
	{
		if (!(object_0 is Series))
		{
			return;
		}
		Series series = (Series)object_0;
		if (series.method_3() == null)
		{
			return;
		}
		int count = series.method_3().Count;
		for (int i = 0; i < count; i++)
		{
			ChartPoint chartPoint = series.method_3()[i];
			if (chartPoint.method_9() != null && !chartPoint.method_9().bool_14)
			{
				switch (byte_4)
				{
				case 0:
					chartPoint.DataLabels.ShowValue = bool_16;
					break;
				case 1:
					chartPoint.DataLabels.ShowPercentage = bool_16;
					break;
				case 2:
					chartPoint.DataLabels.ShowCategoryName = bool_16;
					break;
				case 3:
					chartPoint.DataLabels.ShowBubbleSize = bool_16;
					break;
				case 4:
					chartPoint.DataLabels.ShowSeriesName = bool_16;
					break;
				case 5:
					chartPoint.DataLabels.ShowLegendKey = bool_16;
					break;
				}
			}
		}
	}

	internal void method_47(bool bool_16)
	{
		bool_12 = bool_16;
	}

	internal string method_48()
	{
		return string_1;
	}

	internal void method_49(string string_2)
	{
		string_1 = string_2;
		int_13 = 0;
		bool_13 = false;
		byte_1 |= 1;
	}

	internal int method_50()
	{
		return int_13;
	}

	internal void method_51(int int_14)
	{
		int_13 = int_14;
	}

	internal void method_52(bool bool_16)
	{
		bool_13 = bool_16;
		byte_1 |= 1;
	}

	internal bool method_53()
	{
		return bool_13;
	}

	[SpecialName]
	internal bool method_54()
	{
		return (byte_1 & 1) != 0;
	}

	[SpecialName]
	internal void method_55(bool bool_16)
	{
		if (bool_16)
		{
			byte_1 |= 1;
		}
		else
		{
			byte_1 &= 254;
		}
	}

	internal void method_56(DataLablesSeparatorType dataLablesSeparatorType_1)
	{
		dataLablesSeparatorType_0 = dataLablesSeparatorType_1;
		byte_1 |= 2;
	}

	internal DataLablesSeparatorType method_57()
	{
		return dataLablesSeparatorType_0;
	}

	[SpecialName]
	internal bool method_58()
	{
		return (byte_1 & 2) != 0;
	}

	internal void Copy(DataLabels dataLabels_0)
	{
		Copy((ChartFrame)dataLabels_0);
		byte_1 = dataLabels_0.byte_1;
		dataLablesSeparatorType_0 = dataLabels_0.dataLablesSeparatorType_0;
		int_12 = dataLabels_0.int_12;
		textAlignmentType_0 = dataLabels_0.textAlignmentType_0;
		textAlignmentType_1 = dataLabels_0.textAlignmentType_1;
		textDirectionType_0 = dataLabels_0.textDirectionType_0;
		string_0 = dataLabels_0.string_0;
		bool_10 = dataLabels_0.bool_10;
		bool_8 = dataLabels_0.bool_8;
		bool_7 = dataLabels_0.bool_7;
		bool_12 = dataLabels_0.bool_12;
		bool_9 = dataLabels_0.bool_9;
		bool_11 = dataLabels_0.bool_11;
		bool_14 = dataLabels_0.bool_14;
		labelPositionType_0 = dataLabels_0.labelPositionType_0;
		bool_15 = dataLabels_0.bool_15;
		string_1 = dataLabels_0.string_1;
		int_13 = dataLabels_0.int_13;
		bool_13 = dataLabels_0.bool_13;
		bool_5 = dataLabels_0.bool_5;
		bool_6 = dataLabels_0.bool_6;
	}

	internal bool method_59(DataLabels dataLabels_0)
	{
		if (byte_1 != dataLabels_0.byte_1)
		{
			return false;
		}
		if (dataLablesSeparatorType_0 != dataLabels_0.dataLablesSeparatorType_0)
		{
			return false;
		}
		if (int_12 != dataLabels_0.int_12)
		{
			return false;
		}
		if (textAlignmentType_0 != dataLabels_0.textAlignmentType_0)
		{
			return false;
		}
		if (textAlignmentType_1 != dataLabels_0.textAlignmentType_1)
		{
			return false;
		}
		if (textDirectionType_0 != dataLabels_0.textDirectionType_0)
		{
			return false;
		}
		if (string_0 != dataLabels_0.string_0)
		{
			return false;
		}
		if (bool_10 != dataLabels_0.bool_10)
		{
			return false;
		}
		if (bool_8 != dataLabels_0.bool_8)
		{
			return false;
		}
		if (bool_7 != dataLabels_0.bool_7)
		{
			return false;
		}
		if (bool_12 != dataLabels_0.bool_12)
		{
			return false;
		}
		if (bool_9 != dataLabels_0.bool_9)
		{
			return false;
		}
		if (bool_11 != dataLabels_0.bool_11)
		{
			return false;
		}
		if (labelPositionType_0 != dataLabels_0.labelPositionType_0)
		{
			return false;
		}
		if (bool_15 != dataLabels_0.bool_15)
		{
			return false;
		}
		if (string_1 != dataLabels_0.string_1)
		{
			return false;
		}
		if (int_13 != dataLabels_0.int_13)
		{
			return false;
		}
		if (bool_13 != dataLabels_0.bool_13)
		{
			return false;
		}
		if (bool_5 != dataLabels_0.bool_5)
		{
			return false;
		}
		if (bool_6 = dataLabels_0.bool_6)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal object method_60()
	{
		return object_0;
	}

	[SpecialName]
	internal bool method_61()
	{
		return object_0 is Series;
	}

	[SpecialName]
	internal bool method_62()
	{
		if (bool_11)
		{
			return true;
		}
		int num = 0;
		if (bool_7)
		{
			num++;
		}
		if (ShowCategoryName)
		{
			num++;
		}
		if (ShowPercentage)
		{
			num++;
		}
		if (bool_9)
		{
			num++;
		}
		if (num == 2 && ShowCategoryName && ShowPercentage)
		{
			return false;
		}
		return num > 1;
	}

	[SpecialName]
	internal bool method_63()
	{
		bool flag;
		if (flag = ChartCollection.smethod_16(base.Chart.Type))
		{
			if (bool_10)
			{
				return true;
			}
		}
		else if (bool_11)
		{
			return true;
		}
		int num = 0;
		if (bool_7)
		{
			num++;
		}
		if (flag)
		{
			if (bool_11)
			{
				num++;
			}
		}
		else if (bool_10)
		{
			num++;
		}
		if (bool_8)
		{
			num++;
		}
		if (bool_9)
		{
			num++;
		}
		if (num == 2 && ShowCategoryName && ShowPercentage && dataLablesSeparatorType_0 == DataLablesSeparatorType.Auto)
		{
			return false;
		}
		return num > 1;
	}

	[SpecialName]
	internal bool method_64()
	{
		if (!bool_9 && !bool_10 && !bool_8)
		{
			return bool_7;
		}
		return true;
	}

	[SpecialName]
	internal bool method_65()
	{
		if (!method_64())
		{
			return ShowSeriesName;
		}
		return true;
	}

	[SpecialName]
	internal bool method_66()
	{
		if (ChartCollection.smethod_3(Type))
		{
			if (!ShowSeriesName && !bool_10 && !bool_7)
			{
				return bool_8;
			}
			return true;
		}
		if (ChartCollection.smethod_17(Type))
		{
			if (!ShowSeriesName && !bool_10 && !bool_7)
			{
				return bool_9;
			}
			return true;
		}
		if (!ShowSeriesName && !bool_10)
		{
			return bool_7;
		}
		return true;
	}

	internal void method_67(LabelPositionType labelPositionType_1)
	{
		labelPositionType_0 = labelPositionType_1;
		bool_15 = false;
	}
}
