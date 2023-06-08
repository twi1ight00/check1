using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns16;
using ns2;
using ns21;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates the object that represents the frame object in a chart. 
///       </summary>
public class ChartFrame
{
	internal Class1559 class1559_0;

	protected internal bool m_IsAutoXPos = true;

	protected internal bool m_IsAutoYPos = true;

	private byte byte_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private Enum18 enum18_0;

	private Chart chart_0;

	private Line line_0;

	private Area area_0;

	protected Font m_font;

	protected int m_fontIndex = -1;

	protected bool m_AutoScaleFont = true;

	protected BackgroundMode m_BackgroundMode;

	protected internal bool m_isAutoSize = true;

	internal bool bool_3;

	private bool bool_4 = true;

	private Class1694 class1694_0;

	private ShapePropertyCollection shapePropertyCollection_0;

	/// <summary>
	///       Indicates whether the size of the plot area size includes the tick marks, and the axis labels.
	///       False specifies that the size shall determine the size of the plot area, the tick marks, and the axis labels.
	///       </summary>
	/// <remarks>
	///       Only for Xlsx file.
	///       </remarks>
	public bool IsInnerMode
	{
		get
		{
			return (byte_0 & 0x10) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 16;
			}
			else
			{
				byte_0 &= 239;
			}
		}
	}

	/// <summary>
	///       Gets or sets the border <see cref="T:Aspose.Cells.Drawing.Line" />.
	///       </summary>
	public Line Border
	{
		get
		{
			if (line_0 == null)
			{
				bool flag = bool_4;
				line_0 = new Line(chart_0, this);
				if (this is DataLabels)
				{
					line_0.IsVisible = false;
				}
				bool_4 = flag;
			}
			return line_0;
		}
	}

	/// <summary>
	///       Gets or sets the <see cref="P:Aspose.Cells.Charts.ChartFrame.Area" />.
	///       </summary>
	public Area Area
	{
		get
		{
			if (area_0 == null)
			{
				bool flag = bool_4;
				area_0 = new Area(chart_0, this);
				if (this is DataLabels)
				{
					area_0.Formatting = FormattingType.None;
				}
				bool_4 = flag;
			}
			return area_0;
		}
	}

	/// <summary>
	///       Gets a <see cref="T:Aspose.Cells.Font" /> object of the specified ChartFrame object.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use ChartFrame.Font property instead.")]
	[Browsable(false)]
	public virtual Font TextFont => Font;

	public virtual Font Font
	{
		get
		{
			if (m_font == null)
			{
				m_font = new Font(chart_0.method_14(), null, bool_0: true);
				m_font.method_15(10.0);
				Font font = null;
				if (m_fontIndex != -1)
				{
					font = Chart.method_14().method_53(m_fontIndex);
					m_font.Copy(font);
					m_font.InternalColor.IsShapeColor = true;
					Class1383 @class = Chart.method_41(m_fontIndex);
					if (@class != null)
					{
						Class1383 class2 = new Class1383(@class.chart_0, 0, bool_0: false);
						class2.Copy(@class);
						m_font.method_5(class2);
					}
				}
				else
				{
					if (chart_0.method_14().Workbook.method_24() && this is Title)
					{
						Title.smethod_0(chart_0, m_font, ((Title)this).axis_0 == null);
						return m_font;
					}
					font = chart_0.ChartArea.Font;
					m_font.Copy(font);
					if (AutoScaleFont)
					{
						m_font.method_5(new Class1383(Chart, 10, bool_0: true));
					}
				}
				return m_font;
			}
			return m_font;
		}
	}

	/// <summary>
	///       True if the text in the object changes font size when the object size changes. The default value is True. 
	///       </summary>
	public virtual bool AutoScaleFont
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
					Class1383 object_ = new Class1383(chart_0, m_font.Size, bool_0: true);
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
	///       Gets and sets the display mode of the background
	///       </summary>
	public BackgroundMode BackgroundMode
	{
		get
		{
			return m_BackgroundMode;
		}
		set
		{
			m_BackgroundMode = value;
		}
	}

	/// <summary>
	///       Gets and sets the display mode of the background
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use ChartFrame.BackgroundMode property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[Obsolete("Use ChartFrame.BackgroundMode property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BackgroundMode Background
	{
		get
		{
			return m_BackgroundMode;
		}
		set
		{
			m_BackgroundMode = value;
		}
	}

	/// <summary>
	///       Indicates whether the chart frame is automatic sized.
	///       </summary>
	public bool IsAutomaticSize
	{
		get
		{
			return m_isAutoSize;
		}
		set
		{
			IsAutoSize = value;
		}
	}

	/// <summary>
	///       Gets or sets the x coordinate of the upper left corne in units of 1/4000 of the chart area.
	///       </summary>
	public virtual int X
	{
		get
		{
			return int_8;
		}
		set
		{
			int_8 = value;
			method_31(bool_5: false);
			m_IsAutoXPos = false;
			method_2(bool_5: true);
			bool_0 = true;
		}
	}

	/// <summary>
	///       Gets or sets the y coordinate of the upper left corner in units of 1/4000 of the chart area.		
	///       </summary>
	public virtual int Y
	{
		get
		{
			return int_9;
		}
		set
		{
			int_9 = value;
			method_31(bool_5: false);
			m_IsAutoYPos = false;
			m_IsAutoXPos = false;
			method_2(bool_5: true);
			bool_0 = true;
		}
	}

	/// <summary>
	///       Gets or sets the height of frame.
	///       </summary>
	/// <remarks>
	///   <br>Height is in units of 1/4000 of the chart area. </br>
	///       For legend, the unit is point.
	///       </remarks>
	public virtual int Height
	{
		get
		{
			return int_10;
		}
		set
		{
			int_10 = value;
			method_31(bool_5: false);
			m_isAutoSize = false;
			bool_0 = true;
		}
	}

	/// <summary>
	///       Gets or sets the width of frame.
	///       </summary>
	/// <remarks>
	///   <br>Width is in units of 1/4000 of the chart area. </br>
	///       For legend, the unit is point.
	///       </remarks>
	public virtual int Width
	{
		get
		{
			return int_11;
		}
		set
		{
			int_11 = value;
			method_31(bool_5: false);
			m_isAutoSize = false;
			bool_0 = true;
		}
	}

	/// <summary>
	///       True if the frame has a shadow. 
	///       </summary>
	public bool Shadow
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (bool_3 != value)
			{
				method_31(bool_5: false);
			}
			bool_3 = value;
		}
	}

	/// <summary>
	///       Gets the <see cref="P:Aspose.Cells.Charts.ChartFrame.ShapeProperties" /> object.
	///       </summary>
	public ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (shapePropertyCollection_0 == null)
			{
				shapePropertyCollection_0 = new ShapePropertyCollection(chart_0, this, Enum178.const_11);
			}
			return shapePropertyCollection_0;
		}
	}

	public bool IsDefaultPosBeSet => bool_2;

	public int DefaultX => int_4;

	public int DefaultY => int_5;

	public int DefaultWidth => int_6;

	public int DefaultHeight => int_7;

	internal Chart Chart => chart_0;

	internal bool IsAutoSize
	{
		get
		{
			return m_isAutoSize;
		}
		set
		{
			m_isAutoSize = value;
			if (!value)
			{
				method_31(bool_5: false);
			}
		}
	}

	internal bool IsAuto => bool_4;

	internal int OffsetX
	{
		get
		{
			return int_0;
		}
		set
		{
			bool_1 = true;
			int_0 = value;
		}
	}

	internal int OffsetY
	{
		get
		{
			return int_1;
		}
		set
		{
			bool_1 = true;
			int_1 = value;
		}
	}

	internal void method_0(object object_0)
	{
		bool_4 = false;
	}

	[SpecialName]
	internal bool method_1()
	{
		return (byte_0 & 1) != 0;
	}

	[SpecialName]
	internal void method_2(bool bool_5)
	{
		if (bool_5)
		{
			byte_0 |= 1;
		}
		else
		{
			byte_0 &= 254;
		}
	}

	[SpecialName]
	internal bool method_3()
	{
		return (byte_0 & 2) != 0;
	}

	[SpecialName]
	internal void method_4(bool bool_5)
	{
		if (bool_5)
		{
			byte_0 |= 2;
		}
		else
		{
			byte_0 &= 253;
		}
	}

	[SpecialName]
	internal void method_5(bool bool_5)
	{
		if (bool_5)
		{
			byte_0 |= 4;
		}
		else
		{
			byte_0 &= 251;
		}
	}

	[SpecialName]
	internal void method_6(bool bool_5)
	{
		if (bool_5)
		{
			byte_0 |= 8;
		}
		else
		{
			byte_0 &= 247;
		}
	}

	internal ChartFrame(Chart chart_1)
	{
		chart_0 = chart_1;
	}

	[SpecialName]
	internal Enum18 method_7()
	{
		return enum18_0;
	}

	[SpecialName]
	internal void method_8(Enum18 enum18_1)
	{
		enum18_0 = enum18_1;
	}

	internal void method_9()
	{
		int_8 = 365;
		int_9 = 213;
		int_10 = 3270;
		int_11 = 3574;
	}

	internal Line method_10()
	{
		return line_0;
	}

	internal Area method_11()
	{
		return area_0;
	}

	internal Font method_12()
	{
		if (m_font == null && m_fontIndex != -1)
		{
			return chart_0.method_14().method_53(m_fontIndex);
		}
		return m_font;
	}

	[SpecialName]
	internal int method_13()
	{
		return m_fontIndex;
	}

	[SpecialName]
	internal void method_14(int int_12)
	{
		m_fontIndex = int_12;
	}

	internal void method_15(bool bool_5, Class1383 class1383_0)
	{
		m_AutoScaleFont = bool_5;
		if (bool_5)
		{
			if (m_font != null)
			{
				m_font.method_5(class1383_0);
			}
		}
		else if (m_font != null)
		{
			m_font.method_5(null);
		}
	}

	internal void method_16(BackgroundMode backgroundMode_0)
	{
		m_BackgroundMode = backgroundMode_0;
	}

	[SpecialName]
	internal bool method_17()
	{
		if (!m_IsAutoXPos)
		{
			return m_IsAutoYPos;
		}
		return true;
	}

	[SpecialName]
	internal bool method_18()
	{
		return m_IsAutoXPos;
	}

	[SpecialName]
	internal void method_19(bool bool_5)
	{
		m_IsAutoXPos = bool_5;
	}

	[SpecialName]
	internal bool method_20()
	{
		return m_IsAutoYPos;
	}

	[SpecialName]
	internal void method_21(bool bool_5)
	{
		m_IsAutoYPos = bool_5;
	}

	internal void method_22(int int_12)
	{
		int_8 = int_12;
	}

	internal int method_23()
	{
		return int_8;
	}

	internal void method_24(int int_12)
	{
		int_9 = int_12;
	}

	internal int method_25()
	{
		return int_9;
	}

	internal int method_26()
	{
		return int_10;
	}

	internal void method_27(int int_12)
	{
		int_10 = int_12;
	}

	internal void method_28(int int_12)
	{
		int_11 = int_12;
	}

	internal int method_29()
	{
		return int_11;
	}

	internal void method_30(int int_12, int int_13, int int_14, int int_15)
	{
		int_8 = int_12;
		int_9 = int_13;
		int_11 = int_14;
		int_10 = int_15;
	}

	internal void method_31(bool bool_5)
	{
		bool_4 = bool_5;
	}

	internal void Copy(ChartFrame chartFrame_0)
	{
		bool_4 = chartFrame_0.bool_4;
		if (chartFrame_0.area_0 != null)
		{
			area_0 = null;
			Area.Copy(chartFrame_0.area_0);
		}
		else
		{
			area_0 = null;
		}
		if (chartFrame_0.line_0 != null)
		{
			line_0 = null;
			Border.Copy(chartFrame_0.line_0);
		}
		else
		{
			line_0 = null;
		}
		m_AutoScaleFont = chartFrame_0.m_AutoScaleFont;
		m_BackgroundMode = chartFrame_0.m_BackgroundMode;
		m_fontIndex = -1;
		if (chartFrame_0.m_font != null || chartFrame_0.m_fontIndex != -1)
		{
			m_font = new Font(chart_0.method_14(), null, bool_0: true);
			m_font.Copy(chartFrame_0.Font);
			if (chartFrame_0.Font.method_4() != null && chartFrame_0.m_AutoScaleFont)
			{
				Class1383 class1383_ = (Class1383)chartFrame_0.Font.method_4();
				Class1383 @class = new Class1383(chart_0, 0, bool_0: false);
				@class.Copy(class1383_);
				m_font.method_5(@class);
			}
		}
		int_10 = chartFrame_0.int_10;
		int_11 = chartFrame_0.int_11;
		int_8 = chartFrame_0.int_8;
		int_9 = chartFrame_0.int_9;
		m_IsAutoXPos = chartFrame_0.m_IsAutoXPos;
		m_IsAutoYPos = chartFrame_0.m_IsAutoYPos;
		m_isAutoSize = chartFrame_0.m_isAutoSize;
		bool_3 = chartFrame_0.bool_3;
		byte_0 = chartFrame_0.byte_0;
		int_4 = chartFrame_0.int_4;
		int_5 = chartFrame_0.int_5;
		int_6 = chartFrame_0.int_6;
		int_7 = chartFrame_0.int_7;
		bool_2 = chartFrame_0.bool_2;
		int_0 = chartFrame_0.int_0;
		int_1 = chartFrame_0.int_1;
		int_2 = chartFrame_0.int_2;
		int_3 = chartFrame_0.int_3;
		bool_1 = chartFrame_0.bool_1;
		bool_0 = chartFrame_0.bool_0;
		if (chartFrame_0.class1694_0 != null)
		{
			class1694_0 = new Class1694();
			class1694_0.int_0 = chartFrame_0.class1694_0.int_0;
			class1694_0.int_1 = chartFrame_0.class1694_0.int_1;
			class1694_0.int_2 = chartFrame_0.class1694_0.int_2;
			class1694_0.int_3 = chartFrame_0.class1694_0.int_3;
		}
		if (chartFrame_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(chart_0, this, Enum178.const_11);
			shapePropertyCollection_0.Copy(chartFrame_0.shapePropertyCollection_0);
		}
	}

	[SpecialName]
	internal Class1694 method_32()
	{
		return class1694_0;
	}

	[SpecialName]
	internal void method_33(Class1694 class1694_1)
	{
		class1694_0 = class1694_1;
	}

	[SpecialName]
	internal bool method_34()
	{
		return bool_0;
	}

	internal void method_35(int int_12, int int_13, int int_14, int int_15)
	{
		bool_2 = true;
		int_4 = int_12;
		int_5 = int_13;
		int_6 = int_14;
		int_7 = int_15;
	}

	[SpecialName]
	internal bool method_36()
	{
		return bool_1;
	}

	[SpecialName]
	internal int method_37()
	{
		return int_2;
	}

	[SpecialName]
	internal int method_38()
	{
		return int_3;
	}
}
