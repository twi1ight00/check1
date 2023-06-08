using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Represents the tick-mark labels associated with tick marks on a chart axis.
///       </summary>
public class TickLabels
{
	private Axis axis_0;

	private Font font_0;

	private int int_0 = -1;

	private bool bool_0 = true;

	private BackgroundMode backgroundMode_0;

	private int int_1;

	private bool bool_1 = true;

	private string string_0;

	private int int_2;

	private bool bool_2 = true;

	private int int_3 = 100;

	private TextDirectionType textDirectionType_0;

	/// <summary>
	///       Returns a <see cref="P:Aspose.Cells.Charts.TickLabels.Font" /> object that represents the font of the specified TickLabels object.
	///       </summary>
	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = new Font(axis_0.Chart.method_14(), null, bool_0: true);
				font_0.Size = 10;
				Font font = null;
				if (int_0 != -1)
				{
					font = axis_0.Chart.method_14().method_53(int_0);
					font_0.Copy(font);
					font_0.InternalColor.IsShapeColor = true;
					Class1383 @class = axis_0.Chart.method_41(int_0);
					if (@class != null)
					{
						Class1383 class2 = new Class1383(@class.chart_0, 0, bool_0: false);
						class2.Copy(@class);
						font_0.method_5(class2);
					}
				}
				else
				{
					font = axis_0.Chart.ChartArea.Font;
					font_0.Copy(font);
					if (AutoScaleFont)
					{
						font_0.method_5(new Class1383(axis_0.Chart, font_0.Size, bool_0: true));
					}
				}
			}
			return font_0;
		}
	}

	/// <summary>
	///       True if the text in the object changes font size when the object size changes. The default value is True. 
	///       </summary>
	public bool AutoScaleFont
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 == value)
			{
				return;
			}
			if (value)
			{
				if (font_0 != null)
				{
					font_0.method_5(new Class1383(axis_0.Chart, font_0.Size, bool_0: true));
				}
			}
			else
			{
				Font.method_5(null);
			}
			bool_0 = value;
		}
	}

	public BackgroundMode BackgroundMode
	{
		get
		{
			return backgroundMode_0;
		}
		set
		{
			backgroundMode_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the display mode of the background
	///       </summary>
	[Obsolete("Use TickLabels.BackgroundMode property instead.")]
	public BackgroundMode Background
	{
		get
		{
			return backgroundMode_0;
		}
		set
		{
			backgroundMode_0 = value;
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
	///       please use TickLabels.RotationAngle property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use TickLabels.RotationAngle property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public int Rotation
	{
		get
		{
			return int_1;
		}
		set
		{
			if ((value < -90 || value > 90) && value != 255)
			{
				throw new ArgumentException("Invalid tick labels rotation.");
			}
			int_1 = value;
			bool_1 = false;
		}
	}

	/// <summary>
	///       Represents text rotation angle in clockwise.
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
			return int_1;
		}
		set
		{
			if ((value < -90 || value > 90) && value != 255)
			{
				throw new CellsException(ExceptionType.Chart, "Invalid tick labels rotation.");
			}
			int_1 = value;
			bool_1 = false;
		}
	}

	/// <summary>
	///       Represents the format string for the TickLabels object.
	///       </summary>
	/// <remarks>The formating string is same as a custom format string setting to a cell. For example, "$0".</remarks>
	public string NumberFormat
	{
		get
		{
			return string_0;
		}
		set
		{
			int_2 = 0;
			string_0 = value;
			bool_2 = false;
		}
	}

	/// <summary>
	///       Represents the format number for the TickLabels object.
	///       </summary>
	public int Number
	{
		get
		{
			if (int_2 >= 0 && int_2 < 59)
			{
				return (byte)int_2;
			}
			return 0;
		}
		set
		{
			if (value < 59 && value >= 0)
			{
				string_0 = null;
				int_2 = value;
			}
			else
			{
				int_2 = value;
			}
			NumberFormatLinked = false;
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
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	/// <summary>
	///       Represents the distance between the levels of labels, and the distance between the first level and the axis line.  
	///       </summary>
	/// <remarks>
	///       The default distance is 100 percent, which represents the default spacing between the axis labels and the axis line.
	///       The value can be an integer percentage from 0 through 1000, relative to the axis label’s font size.
	///       </remarks>
	public int Offset
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value < 0 || value > 1000)
			{
				throw new ArgumentException("The tick offset must be between 0 and 1000.");
			}
			int_3 = value;
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

	internal TickLabels(Axis axis_1)
	{
		axis_0 = axis_1;
		if (axis_1.Chart.ChartArea != null)
		{
			bool_0 = axis_1.Chart.ChartArea.AutoScaleFont;
		}
	}

	internal Font method_0()
	{
		if (font_0 == null && int_0 != -1)
		{
			return axis_0.Chart.method_14().method_53(int_0);
		}
		return font_0;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_2(int int_4)
	{
		int_0 = int_4;
	}

	internal void method_3(bool bool_3)
	{
		bool_0 = bool_3;
	}

	internal void method_4(int int_4)
	{
		int_1 = int_4;
		bool_1 = false;
	}

	[SpecialName]
	internal bool method_5()
	{
		return bool_1;
	}

	internal int method_6()
	{
		return int_2;
	}

	internal void method_7(int int_4)
	{
		int_2 = int_4;
	}

	internal void Copy(TickLabels tickLabels_0)
	{
		bool_0 = tickLabels_0.bool_0;
		int_0 = -1;
		if (tickLabels_0.font_0 == null && tickLabels_0.int_0 == -1)
		{
			font_0 = null;
		}
		else
		{
			font_0 = new Font(axis_0.Chart.method_14(), null, bool_0: true);
			font_0.Copy(tickLabels_0.Font);
			if (tickLabels_0.Font.method_4() != null && tickLabels_0.bool_0)
			{
				Class1383 class1383_ = (Class1383)tickLabels_0.Font.method_4();
				Class1383 @class = new Class1383(axis_0.Chart, 0, bool_0: false);
				@class.Copy(class1383_);
				font_0.method_5(@class);
			}
		}
		string_0 = tickLabels_0.string_0;
		int_2 = tickLabels_0.int_2;
		bool_2 = tickLabels_0.bool_2;
		int_1 = tickLabels_0.int_1;
		bool_1 = tickLabels_0.bool_1;
		int_3 = tickLabels_0.int_3;
		backgroundMode_0 = tickLabels_0.backgroundMode_0;
	}
}
