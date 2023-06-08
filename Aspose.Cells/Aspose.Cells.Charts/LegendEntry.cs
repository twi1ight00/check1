using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Represents a legend entry in a chart legend. 
///       </summary>
public class LegendEntry
{
	private Legend legend_0;

	private bool bool_0;

	private Font font_0;

	private int int_0 = -1;

	private int int_1;

	private bool bool_1 = true;

	private BackgroundMode backgroundMode_0;

	/// <summary>
	///       Gets and sets whether the legend entry is deleted.
	///       </summary>
	public bool IsDeleted
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = new Font(legend_0.Chart.method_14(), null, bool_0: true);
				font_0.Size = 10;
				if (int_0 != -1)
				{
					Font font = (Font)legend_0.Chart.method_14().method_52()[(int_0 > 4) ? (int_0 - 1) : int_0];
					font_0.Copy(font);
					Class1383 @class = legend_0.Chart.method_41(int_0);
					if (@class != null)
					{
						Class1383 class2 = new Class1383(@class.chart_0, 0, bool_0: false);
						class2.Copy(@class);
						font_0.method_5(class2);
					}
				}
				else
				{
					if (legend_0.method_12() != null)
					{
						font_0.Copy(legend_0.Font);
					}
					if (AutoScaleFont)
					{
						font_0.method_5(new Class1383(legend_0.Chart, font_0.Size, bool_0: true));
					}
				}
			}
			return font_0;
		}
	}

	/// <summary>
	///       Gets a <see cref="T:Aspose.Cells.Font" /> object of the specified ChartFrame object.
	///       </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use LegendEntry.Font property instead.")]
	public virtual Font TextFont => Font;

	/// <summary>
	///       True if the text in the object changes font size when the object size changes. 
	///       The default value is True. 
	///       </summary>
	public bool AutoScaleFont
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (bool_1 == value)
			{
				return;
			}
			if (value)
			{
				if (font_0 != null)
				{
					font_0.method_5(new Class1383(legend_0.Chart, font_0.Size, bool_0: true));
				}
			}
			else
			{
				Font.method_5(null);
			}
			bool_1 = value;
		}
	}

	/// <summary>
	///       Gets and sets the display mode of the background
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use LegendEntry.BackgroundMode property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use LegendEntry.BackgroundMode property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
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
	///       Gets and sets the display mode of the background
	///       </summary>
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

	internal int Index
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	internal LegendEntry(Legend legend_1, int int_2)
	{
		legend_0 = legend_1;
		int_1 = int_2;
	}

	internal Font method_0()
	{
		if (font_0 == null && int_0 != -1)
		{
			return legend_0.Chart.method_14().method_53(int_0);
		}
		return font_0;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_2(int int_2)
	{
		int_0 = int_2;
	}

	internal void method_3(bool bool_2)
	{
		bool_1 = bool_2;
	}

	internal void Copy(LegendEntry legendEntry_0)
	{
		bool_1 = legendEntry_0.bool_1;
		backgroundMode_0 = legendEntry_0.backgroundMode_0;
		int_0 = -1;
		if (legendEntry_0.font_0 == null && legendEntry_0.int_0 == -1)
		{
			font_0 = null;
			return;
		}
		font_0 = new Font(legend_0.Chart.method_14(), null, bool_0: true);
		font_0.Copy(legendEntry_0.Font);
		if (legendEntry_0.Font.method_4() != null && legendEntry_0.bool_1)
		{
			Class1383 class1383_ = (Class1383)legendEntry_0.Font.method_4();
			Class1383 @class = new Class1383(legend_0.Chart, 0, bool_0: false);
			@class.Copy(class1383_);
			font_0.method_5(@class);
		}
	}
}
