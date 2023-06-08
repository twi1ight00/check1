using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates the object that represents the title of chart or axis.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Setting the title of a chart
///       chart.Title.Text = "Title";
///       //Setting the font color of the chart title to blue
///       chart.Title.TextFont.Color = Color.Blue;
///       //Setting the title of category axis of the chart
///       chart.CategoryAxis.Title.Text = "Category";
///       //Setting the title of value axis of the chart
///       chart.ValueAxis.Title.Text = "Value";
///
///       [Visual Basic]
///
///       'Setting the title of a chart
///       chart.Title.Text = "Title"
///       'Setting the font color of the chart title to blue
///       chart.Title.TextFont.Color = Color.Blue
///       'Setting the title of category axis of the chart
///       chart.CategoryAxis.Title.Text = "Category"
///       'Setting the title of value axis of the chart
///       chart.ValueAxis.Title.Text = "Value"
///
///       </code>
/// </example>
public class Title : ChartFrame
{
	internal Axis axis_0;

	private TextAlignmentType textAlignmentType_0 = TextAlignmentType.Center;

	private TextAlignmentType textAlignmentType_1 = TextAlignmentType.Center;

	private int int_12;

	private ArrayList arrayList_0;

	internal string string_0;

	private bool bool_5;

	private bool bool_6;

	private TextDirectionType textDirectionType_0;

	internal byte[] byte_1;

	private bool bool_7;

	internal bool bool_8;

	private bool bool_9 = true;

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
	///       please use Title.RotationAngle property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Title.RotationAngle property instead.")]
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
			if (byte_1 != null)
			{
				Chart chart = base.Chart;
				Interface45 @interface = Class1195.smethod_0(chart.method_14(), chart.method_15());
				@interface.imethod_5(byte_1);
				string_0 = @interface.imethod_9();
			}
			return string_0;
		}
		set
		{
			if (value != null && value.Length > 255)
			{
				throw new CellsException(ExceptionType.Limitation, "The text length of the chart title should be less than 256.");
			}
			string_0 = value;
			bool_5 = false;
			if (value == null)
			{
				bool_6 = true;
			}
			else
			{
				bool_6 = false;
			}
			arrayList_0 = null;
			byte_1 = null;
		}
	}

	public bool IsVisible
	{
		get
		{
			if (bool_6)
			{
				return false;
			}
			string text = Text;
			if (text != null && !(text == ""))
			{
				return true;
			}
			return false;
		}
		set
		{
			if (value)
			{
				bool_6 = false;
				string text = Text;
				if (text == null || text == "")
				{
					bool_5 = true;
				}
			}
			else
			{
				Text = null;
			}
		}
	}

	/// <summary>
	///       Gets or sets the x coordinate of the upper left corne in units of 1/4000 of the chart area.
	///       </summary>
	public override int X
	{
		get
		{
			return method_23();
		}
		set
		{
			method_22(value);
			method_4(bool_5: true);
			method_31(bool_5: false);
			method_19(bool_5: false);
		}
	}

	/// <summary>
	///       Gets or sets the y coordinate of the upper left corner in units of 1/4000 of the chart area.		
	///       </summary>
	public override int Y
	{
		get
		{
			return method_25();
		}
		set
		{
			method_24(value);
			method_2(bool_5: true);
			method_31(bool_5: false);
			method_21(bool_5: false);
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

	internal bool IsAutoText
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

	internal bool IsDeleted
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

	internal Title(Chart chart_1)
		: base(chart_1)
	{
		method_8(Enum18.const_3);
	}

	internal Title(Axis axis_1)
		: base(axis_1.Chart)
	{
		axis_0 = axis_1;
		method_8(Enum18.const_4);
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

	/// <summary>
	///       Remove all Character sets.
	///       </summary>
	public void RemoveCharacters()
	{
		arrayList_0 = null;
	}

	/// <summary>
	///       Returns a Characters object that represents a range of characters within the title.
	///       </summary>
	/// <param name="startIndex">The index of the start of the character.</param>
	/// <param name="length">The number of characters.</param>
	/// <returns>Characters object.</returns>
	public FontSetting Characters(int startIndex, int length)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		int num = 0;
		FontSetting fontSetting;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				fontSetting = (FontSetting)arrayList_0[num];
				if (fontSetting.Length == length && fontSetting.StartIndex == startIndex)
				{
					break;
				}
				num++;
				continue;
			}
			fontSetting = new FontSetting(startIndex, length, base.Chart.method_14(), bool_1: true);
			arrayList_0.Add(fontSetting);
			return fontSetting;
		}
		return fontSetting;
	}

	internal void method_41(string string_1)
	{
		string_0 = string_1;
		bool_5 = false;
		if (string_1 == null)
		{
			bool_6 = true;
		}
	}

	internal static void smethod_0(Chart chart_1, Font font_0, bool bool_10)
	{
		Font font = chart_1.ChartArea.Font;
		font_0.Copy(font);
		font_0.method_25();
		if (bool_10)
		{
			if (!chart_1.ChartArea.Font.IsModified(StyleModifyFlag.FontWeight))
			{
				font_0.method_7(bool_0: true);
			}
			if (chart_1.ChartArea.Font.IsModified(StyleModifyFlag.FontSize))
			{
				font_0.method_15(chart_1.ChartArea.Font.DoubleSize * 1.2);
				return;
			}
			switch (chart_1.Style)
			{
			default:
				font_0.method_15(18.0);
				break;
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
				font_0.method_15(18.0);
				font_0.InternalColor.SetColor(ColorType.RGB, Color.White.ToArgb());
				break;
			case -1:
			case 2:
				font_0.method_15(18.0);
				break;
			}
		}
		else
		{
			if (!chart_1.ChartArea.Font.IsModified(StyleModifyFlag.FontWeight))
			{
				font_0.method_7(bool_0: true);
			}
			if (chart_1.ChartArea.Font.IsModified(StyleModifyFlag.FontSize))
			{
				font_0.method_15(chart_1.ChartArea.Font.DoubleSize);
			}
			switch (chart_1.Style)
			{
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
				font_0.InternalColor.SetColor(ColorType.RGB, Color.White.ToArgb());
				break;
			}
		}
	}

	internal void Copy(Title title_0, CopyOptions copyOptions_0)
	{
		Copy(title_0);
		IsDeleted = title_0.IsDeleted;
		int_12 = title_0.int_12;
		textAlignmentType_0 = title_0.textAlignmentType_0;
		textAlignmentType_1 = title_0.textAlignmentType_1;
		textDirectionType_0 = title_0.textDirectionType_0;
		string_0 = title_0.string_0;
		_ = title_0.LinkedSource;
		if (title_0.method_39() != null && title_0.method_39().Count > 0)
		{
			arrayList_0 = new ArrayList();
			for (int i = 0; i < title_0.arrayList_0.Count; i++)
			{
				FontSetting fontSetting = (FontSetting)title_0.arrayList_0[i];
				FontSetting fontSetting2 = new FontSetting(fontSetting.StartIndex, fontSetting.Length, base.Chart.method_14(), bool_1: true);
				fontSetting2.Font.Copy(fontSetting.Font);
				arrayList_0.Add(fontSetting2);
			}
		}
		if (title_0.byte_1 != null)
		{
			Worksheet worksheet = title_0.Chart.method_15();
			Worksheet worksheet2 = base.Chart.method_15();
			Interface45 @interface = Class1195.smethod_0(worksheet.method_2(), worksheet);
			@interface.imethod_5(title_0.byte_1);
			Interface45 interface2 = Class1195.smethod_0(worksheet2.method_2(), worksheet2);
			interface2.Copy(@interface, worksheet.SheetIndex, copyOptions_0);
			byte_1 = interface2.imethod_4();
		}
		bool_5 = title_0.bool_5;
		bool_9 = title_0.bool_9;
	}

	[SpecialName]
	internal bool method_42()
	{
		if (!base.Border.IsVisible && base.Area.Formatting == FormattingType.None)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_43()
	{
		return bool_7;
	}

	[SpecialName]
	internal void method_44(bool bool_10)
	{
		bool_7 = bool_10;
		bool_8 = true;
	}

	[SpecialName]
	internal bool method_45()
	{
		return bool_9;
	}

	[SpecialName]
	internal void method_46(bool bool_10)
	{
		bool_9 = bool_10;
	}
}
