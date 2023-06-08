using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells.Drawing;
using ns16;
using ns2;
using ns22;
using ns27;

namespace Aspose.Cells;

/// <summary>
///       Represents display style of excel document,such as font,
///       color,alignment,border,etc.
///       </summary>	
///       The Style object contains all style attributes (font, number format, alignment, and so on) as properties.
///       There are two methods to set a cell's style.	
///       <example>	
///       //First method
///       <code>	
///       [C#]
///       int styleIndex = excel.CreateStyle();
///       Style style = excel.Styles[styleIndex];
///       style.Font.Name = "Times New Roman";
///       style.Font.Color = Color.Blue;
///       for(int i = 0; i &lt; 100; i ++)
///       {
///       	excel.Worksheets[0].Cells[0, i].SetStyle(style);
///       }
///       </code>
///       //Second method
///       <code>	
///       [C#]
///       Style style =  excel.Worksheets[0].Cells["A1"].GetStyle();
///       style.Font.Name = "Times New Roman";
///       style.Font.Color = Color.Blue;
///       excel.Worksheets[0].Cells["A1"].SetStyle(style);
///       </code>
///       First method is a fast and efficient way to change several cell-formatting properties on multiple cells at the same time.
///       If you want to change a single cell's style properties, second method can be used.
///       </example>
[Serializable]
public class Style
{
	internal InternalColor BackgroundInternalColor;

	internal InternalColor ForeInternalColor;

	private string name;

	private BackgroundType pattern;

	private BorderCollection m_Borders;

	private int parentXFIndex;

	private byte m_UsedFlag = byte.MaxValue;

	private uint m_SetFlag;

	private byte m_IndentLevel;

	private int number = -1;

	private Font font;

	private WorksheetCollection sheets;

	private int rotation;

	private byte m_aligment;

	private string custom = "";

	private ushort m_Zip = 18;

	private byte m_gradient;

	/// <summary>
	///       Gets and sets the background theme color.
	///       </summary>
	/// <remarks>
	///       If the background color is not a theme color, NULL will be returned.
	///       </remarks>
	public ThemeColor BackgroundThemeColor
	{
		get
		{
			if (BackgroundInternalColor.ColorType == ColorType.Theme)
			{
				ThemeColorType type = Class1673.smethod_1(BackgroundInternalColor.method_4());
				return new ThemeColor(type, BackgroundInternalColor.Tint);
			}
			return null;
		}
		set
		{
			BackgroundInternalColor.SetColor(ColorType.Theme, Class1673.smethod_2(value.ColorType));
			BackgroundInternalColor.Tint = value.Tint;
			method_36(StyleModifyFlag.BackgroundColor);
		}
	}

	/// <summary>
	///       Gets and sets the foreground theme color.
	///       </summary>
	/// <remarks>
	///       If the forground color is not a theme color, NULL will be returned.
	///       </remarks>
	public ThemeColor ForegroundThemeColor
	{
		get
		{
			if (ForeInternalColor.ColorType == ColorType.Theme)
			{
				ThemeColorType type = Class1673.smethod_1(ForeInternalColor.method_4());
				return new ThemeColor(type, ForeInternalColor.Tint);
			}
			return null;
		}
		set
		{
			ForeInternalColor.SetColor(ColorType.Theme, Class1673.smethod_2(value.ColorType));
			ForeInternalColor.Tint = value.Tint;
			method_36(StyleModifyFlag.ForegroundColor);
		}
	}

	/// <summary>
	///       Gets or sets the name of the style.
	///       </summary>
	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
			if (value != null && value != "")
			{
				method_11(bool_0: false);
				sheets.method_58().method_7(this);
				sheets.Styles.method_0(this);
			}
		}
	}

	/// <summary>
	///       Gets or sets the cell background pattern type.
	///       </summary>
	public BackgroundType Pattern
	{
		get
		{
			return pattern;
		}
		set
		{
			pattern = value;
			method_26(bool_0: true);
			m_SetFlag |= 524288u;
		}
	}

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.BorderCollection" /> of the style.
	///       </summary>
	public BorderCollection Borders
	{
		get
		{
			if (m_Borders == null)
			{
				m_Borders = new BorderCollection(this);
			}
			return m_Borders;
		}
	}

	/// <summary>
	///       Gets or sets a style's background color.
	///       </summary>
	/// <remarks>If you want to set a cell's color, please use Style.ForegroundColor property. 
	///       Only if the cell style pattern is other than none or solid, this property will take effect.</remarks>
	public Color BackgroundColor
	{
		get
		{
			if (BackgroundInternalColor.method_2())
			{
				if (pattern == BackgroundType.None)
				{
					return Color.Empty;
				}
				if (pattern == BackgroundType.Solid)
				{
					return Color.White;
				}
				return Color.Black;
			}
			return BackgroundInternalColor.method_6(sheets.Workbook);
		}
		set
		{
			if (value.IsEmpty)
			{
				method_26(bool_0: true);
				BackgroundInternalColor.method_3(bool_0: true);
			}
			else
			{
				BackgroundInternalColor.SetColor(ColorType.RGB, value.ToArgb());
				BackgroundInternalColor.method_8();
				method_26(bool_0: true);
			}
			m_SetFlag |= 4096u;
		}
	}

	/// <summary>
	///       Gets or sets a style's foreground color.
	///       </summary>
	/// <remarks>It means no color setting if Color.Empty is returned.</remarks>
	public Color ForegroundColor
	{
		get
		{
			if (ForeInternalColor.method_2())
			{
				return Color.Empty;
			}
			return ForeInternalColor.method_6(sheets.Workbook);
		}
		set
		{
			if (value.IsEmpty)
			{
				ForeInternalColor.method_3(bool_0: true);
				ForeInternalColor.method_8();
			}
			else
			{
				ForeInternalColor.SetColor(ColorType.RGB, value.ToArgb());
				ForeInternalColor.method_8();
			}
			m_SetFlag |= 8192u;
			method_26(bool_0: true);
		}
	}

	/// <summary>
	///       Gets the parent style of this style.
	///       </summary>
	public Style ParentStyle
	{
		get
		{
			if (parentXFIndex > 0 && parentXFIndex < sheets.method_58().Count)
			{
				return method_5().method_58()[parentXFIndex];
			}
			return null;
		}
	}

	/// <summary>
	///       Represents the m_IndentLevel level for the cell or range. Can only be an integer from 0 to 15.
	///       </summary>
	/// <remarks>
	///       If text horizontal alignment type is set to value other than left or right, m_IndentLevel level will
	///       be reset to zero.
	///       </remarks>
	public int IndentLevel
	{
		get
		{
			return m_IndentLevel & 0xFF;
		}
		set
		{
			if (value >= 0 && value <= 250)
			{
				if (HorizontalAlignment != TextAlignmentType.Right && HorizontalAlignment != TextAlignmentType.Left && HorizontalAlignment != TextAlignmentType.Distributed)
				{
					HorizontalAlignment = TextAlignmentType.Left;
				}
				m_IndentLevel = (byte)value;
				if (!method_21())
				{
					method_22(bool_0: true);
				}
				m_SetFlag |= 32768u;
				return;
			}
			throw new ArgumentException("Indent level must be between 0 and 250.");
		}
	}

	/// <summary>
	///       Gets a <see cref="P:Aspose.Cells.Style.Font" /> object.
	///       </summary>
	public Font Font
	{
		get
		{
			if (font == null)
			{
				if (sheets == null)
				{
					font = new Font(sheets, this, bool_0: false);
					return font;
				}
				font = new Font(sheets, this, bool_0: false);
				if (sheets.method_58().Count > 15)
				{
					font.Copy(sheets.DefaultFont);
					font.method_25();
				}
			}
			return font;
		}
	}

	/// <summary>
	///       Represents text rotation angle.
	///       </summary>
	/// <remarks>
	///   <p>0: Not rotated.</p>
	///   <p>255: Top to Bottom.</p>
	///   <p>-90: Downward.</p>
	///   <p>90: Upward.</p>
	///       You can set 255 or value ranged from -90 to 90.</remarks>
	public int RotationAngle
	{
		get
		{
			return rotation;
		}
		set
		{
			if ((value >= -90 && value <= 90) || value == 255)
			{
				rotation = value;
				if (!method_21())
				{
					method_22(bool_0: true);
				}
				m_SetFlag |= 1048576u;
			}
		}
	}

	/// <summary>
	///       Represents text rotation angle.
	///       </summary>
	/// <remarks>
	///   <p>0: Not rotated.</p>
	///   <p>255: Top to Bottom.</p>
	///   <p>-90: Downward.</p>
	///   <p>90: Upward.</p>
	///       You can set 255 or value ranged from -90 to 90.</remarks>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Style.RotationAngle property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Style.RotationAngle property instead.")]
	public int Rotation
	{
		get
		{
			return rotation;
		}
		set
		{
			RotationAngle = value;
		}
	}

	/// <summary>
	///        Gets or sets the vertical alignment type of the text in a cell. 
	///        </summary>
	public TextAlignmentType VerticalAlignment
	{
		get
		{
			return ((m_aligment & 0x38) >> 3) switch
			{
				0 => TextAlignmentType.Top, 
				1 => TextAlignmentType.Center, 
				2 => TextAlignmentType.Bottom, 
				3 => TextAlignmentType.Justify, 
				4 => TextAlignmentType.Distributed, 
				_ => TextAlignmentType.Center, 
			};
		}
		set
		{
			byte b = 1;
			switch (value)
			{
			case TextAlignmentType.Bottom:
				b = 2;
				break;
			case TextAlignmentType.Center:
				b = 1;
				break;
			case TextAlignmentType.Distributed:
				b = 4;
				break;
			case TextAlignmentType.Justify:
				b = 3;
				break;
			case TextAlignmentType.Left:
			case TextAlignmentType.Right:
				return;
			case TextAlignmentType.Top:
				b = 0;
				break;
			}
			m_aligment &= 199;
			m_aligment |= (byte)(b << 3);
			if (!method_21())
			{
				method_22(bool_0: true);
			}
			m_SetFlag |= 8388608u;
		}
	}

	/// <summary>
	///        Gets or sets the horizontal alignment type of the text in a cell. 
	///        </summary>
	public TextAlignmentType HorizontalAlignment
	{
		get
		{
			return (m_aligment & 7) switch
			{
				0 => TextAlignmentType.General, 
				1 => TextAlignmentType.Left, 
				2 => TextAlignmentType.Center, 
				3 => TextAlignmentType.Right, 
				4 => TextAlignmentType.Fill, 
				5 => TextAlignmentType.Justify, 
				6 => TextAlignmentType.CenterAcross, 
				7 => TextAlignmentType.Distributed, 
				_ => TextAlignmentType.General, 
			};
		}
		set
		{
			byte b = 0;
			switch (value)
			{
			case TextAlignmentType.Center:
				m_IndentLevel = 0;
				b = 2;
				break;
			case TextAlignmentType.CenterAcross:
				m_IndentLevel = 0;
				b = 6;
				break;
			case TextAlignmentType.Distributed:
				b = 7;
				break;
			case TextAlignmentType.Fill:
				m_IndentLevel = 0;
				b = 4;
				break;
			case TextAlignmentType.General:
				m_IndentLevel = 0;
				break;
			case TextAlignmentType.Justify:
				m_IndentLevel = 0;
				b = 5;
				break;
			case TextAlignmentType.Left:
				b = 1;
				break;
			case TextAlignmentType.Right:
				b = 3;
				break;
			case TextAlignmentType.Bottom:
			case TextAlignmentType.Top:
				return;
			}
			m_aligment &= 248;
			m_aligment |= b;
			if (!method_21())
			{
				method_22(bool_0: true);
			}
			m_SetFlag |= 16384u;
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the text within a cell is wrapped.
	///       </summary>
	public bool IsTextWrapped
	{
		get
		{
			if ((m_Zip & 4) == 0)
			{
				return false;
			}
			return true;
		}
		set
		{
			if (value)
			{
				m_Zip |= 4;
			}
			else
			{
				m_Zip &= 65531;
			}
			if (!method_21())
			{
				method_22(bool_0: true);
			}
			m_SetFlag |= 262144u;
		}
	}

	/// <summary>
	///        Gets or sets the display format of numbers and dates.
	///        </summary>
	/// <remarks>
	///   <table class="dtTABLE" cellspacing="0">
	///     <tr>
	///       <td width="33%">
	///         <font color="gray">
	///           <b>Value</b>
	///         </font>　</td>
	///       <td width="33%">
	///         <font color="gray">
	///           <b>Type</b>
	///         </font>　</td>
	///       <td width="33%">
	///         <font color="gray">
	///           <b>Format String</b>
	///         </font>　</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">0</td>
	///       <td width="33%">General</td>
	///       <td width="33%">General</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">1</td>
	///       <td width="33%">Decimal</td>
	///       <td width="33%">0</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">2</td>
	///       <td width="33%">Decimal</td>
	///       <td width="33%">0.00</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">3</td>
	///       <td width="33%">Decimal</td>
	///       <td width="33%">#,##0</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">4</td>
	///       <td width="33%">Decimal</td>
	///       <td width="33%">#,##0.00</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">5</td>
	///       <td width="33%">Currency</td>
	///       <td width="33%">$#,##0;($#,##0)</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">6</td>
	///       <td width="33%">Currency</td>
	///       <td width="33%">$#,##0;[Red]($#,##0)</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">7</td>
	///       <td width="33%">Currency</td>
	///       <td width="33%">$#,##0.00;($#,##0.00)</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">8</td>
	///       <td width="33%">Currency</td>
	///       <td width="33%">$#,##0.00;[Red]($#,##0.00)</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">9</td>
	///       <td width="33%">Percentage</td>
	///       <td width="33%">0%</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">10</td>
	///       <td width="33%">Percentage</td>
	///       <td width="33%">0.00%</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">11</td>
	///       <td width="33%">Scientific</td>
	///       <td width="33%">0.00E+00</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">12</td>
	///       <td width="33%">Fraction</td>
	///       <td width="33%"># ?/?</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">13</td>
	///       <td width="33%">Fraction</td>
	///       <td width="33%"># ??/??</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">14</td>
	///       <td width="33%">Date</td>
	///       <td width="33%">m/d/yyyy</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">15</td>
	///       <td width="33%">Date</td>
	///       <td width="33%">d-mmm-yy</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">16</td>
	///       <td width="33%">Date</td>
	///       <td width="33%">d-mmm</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">17</td>
	///       <td width="33%">Date</td>
	///       <td width="33%">mmm-yy</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">18</td>
	///       <td width="33%">Time</td>
	///       <td width="33%">h:mm AM/PM</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">19</td>
	///       <td width="33%">Time</td>
	///       <td width="33%">h:mm:ss AM/PM</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">20</td>
	///       <td width="33%">Time</td>
	///       <td width="33%">h:mm</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">21</td>
	///       <td width="33%">Time</td>
	///       <td width="33%">h:mm:ss</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">22</td>
	///       <td width="33%">Time</td>
	///       <td width="33%">m/d/yyyy h:mm</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">37</td>
	///       <td width="33%">Accounting</td>
	///       <td width="33%">#,##0;(#,##0)</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">38</td>
	///       <td width="33%">Accounting</td>
	///       <td width="33%">#,##0;[Red](#,##0)</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">39</td>
	///       <td width="33%">Accounting</td>
	///       <td width="33%">#,##0.00;(#,##0.00)</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">40</td>
	///       <td width="33%">Accounting</td>
	///       <td width="33%">#,##0.00;[Red](#,##0.00)</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">41</td>
	///       <td width="33%">Accounting</td>
	///       <td width="33%">_ * #,##0_ ;_ * (#,##0)_ ;_ * "-"_ ;_ @_</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">42</td>
	///       <td width="33%">Currency</td>
	///       <td width="33%">_ $* #,##0_ ;_ $* (#,##0)_ ;_ $* "-"_ ;_ @_</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">43</td>
	///       <td width="33%">Accounting</td>
	///       <td width="33%">_ * #,##0.00_ ;_ * (#,##0.00)_ ;_ * "-"??_ ;_ @_</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">44</td>
	///       <td width="33%">Currency</td>
	///       <td width="33%">_ $* #,##0.00_ ;_ $* (#,##0.00)_ ;_ $* "-"??_ ;_ @_</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">45</td>
	///       <td width="33%">Time</td>
	///       <td width="33%">mm:ss</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">46</td>
	///       <td width="33%">Time</td>
	///       <td width="33%">[h]:mm:ss</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">47</td>
	///       <td width="33%">Time</td>
	///       <td width="33%">mm:ss.0</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">48</td>
	///       <td width="33%">Scientific</td>
	///       <td width="33%">##0.0E+00</td>
	///     </tr>
	///     <tr>
	///       <td width="33%">49</td>
	///       <td width="33%">Text</td>
	///       <td width="33%">@</td>
	///     </tr>
	///   </table>
	/// </remarks>
	public int Number
	{
		get
		{
			if (number >= 0 && number < 59)
			{
				return (byte)number;
			}
			return 0;
		}
		set
		{
			if (value < 59 && value >= 0)
			{
				custom = "";
				number = value;
			}
			else
			{
				number = value;
			}
			method_18(bool_0: true);
			m_SetFlag |= 1u;
		}
	}

	/// <summary>
	///        Gets or sets a value indicating whether a cell can be modified or not.
	///        </summary>
	/// <remarks>Locking cells has no effect unless the worksheet is protected. </remarks>
	public bool IsLocked
	{
		get
		{
			if ((m_Zip & 2) == 0)
			{
				return false;
			}
			return true;
		}
		set
		{
			if (value)
			{
				m_Zip |= 2;
			}
			else
			{
				m_Zip &= 65533;
			}
			method_28(bool_0: true);
			m_SetFlag |= 131072u;
		}
	}

	/// <summary>
	///       Represents the custom number format string of a cell.
	///       If the custom number format is not set,we will return "".
	///       </summary>
	/// <remarks>
	///       It should be InvariantCulture .
	///       </remarks>
	public string Custom
	{
		get
		{
			return custom;
		}
		set
		{
			if (value != null && !(value == ""))
			{
				if (value.Length > 255)
				{
					throw new CellsException(ExceptionType.InvalidData, "The custom number format string is too long.");
				}
				custom = value;
				string input = Class1386.smethod_2(custom);
				if (Regex.IsMatch(input, Class1386.string_1, RegexOptions.IgnoreCase))
				{
					m_Zip |= 128;
				}
				else
				{
					m_Zip &= 65407;
				}
			}
			else
			{
				custom = "";
				m_Zip &= 65407;
			}
			number = -1;
			method_18(bool_0: true);
			m_SetFlag |= 1u;
		}
	}

	/// <summary>
	///       Gets and sets the culture custom number format.
	///       </summary>
	public string CultureCustom
	{
		get
		{
			if (custom == null)
			{
				return null;
			}
			return Class1345.smethod_2(custom, sheets.Workbook.Settings);
		}
		set
		{
			if (value == null || value == "")
			{
				Custom = "";
			}
			Custom = Class1345.smethod_1(value, sheets.Workbook.Settings);
		}
	}

	/// <summary>
	///       Represents if the formula will be hidden when the worksheet is protected.
	///       </summary>
	public bool IsFormulaHidden
	{
		get
		{
			if ((m_Zip & 1) == 0)
			{
				return false;
			}
			return true;
		}
		set
		{
			if (value)
			{
				m_Zip |= 1;
			}
			else
			{
				m_Zip &= 65534;
			}
			method_28(bool_0: true);
			m_SetFlag |= 65536u;
		}
	}

	/// <summary>
	///       Represents if text automatically shrinks to fit in the available column width.
	///       </summary>
	public bool ShrinkToFit
	{
		get
		{
			if ((m_Zip & 8) == 0)
			{
				return false;
			}
			return true;
		}
		set
		{
			if (value)
			{
				m_Zip |= 8;
			}
			else
			{
				m_Zip &= 65527;
			}
			if (!method_21())
			{
				method_22(bool_0: true);
			}
			m_SetFlag |= 2097152u;
		}
	}

	/// <summary>
	///        Represents text reading order.
	///       </summary>
	public TextDirectionType TextDirection
	{
		get
		{
			return (m_aligment & 0xC0) switch
			{
				128 => TextDirectionType.RightToLeft, 
				64 => TextDirectionType.LeftToRight, 
				_ => TextDirectionType.Context, 
			};
		}
		set
		{
			m_aligment &= 63;
			switch (value)
			{
			case TextDirectionType.LeftToRight:
				m_aligment |= 64;
				break;
			case TextDirectionType.RightToLeft:
				m_aligment |= 128;
				break;
			}
			m_SetFlag |= 4194304u;
			if (!method_21())
			{
				method_22(bool_0: true);
			}
		}
	}

	/// <summary>
	///       Indicates whether the cell shading is a gradient pattern.
	///       </summary>
	public bool IsGradient
	{
		get
		{
			return (m_gradient & 0x80) != 0;
		}
		set
		{
			if (value)
			{
				m_gradient |= 128;
			}
			else
			{
				m_gradient &= 127;
			}
		}
	}

	/// <summary>
	///       Indicates whether the number format is a percent format.
	///       </summary>
	public bool IsPercent
	{
		get
		{
			string text = custom;
			if (text != null && !text.Equals(""))
			{
				return text.IndexOf("%") > -1;
			}
			switch (number)
			{
			default:
				return false;
			case 9:
			case 10:
				return true;
			}
		}
	}

	/// <summary>
	///       Indicates whether the number format is a date format.
	///       </summary>
	public bool IsDateTime
	{
		get
		{
			string text = custom;
			if (text != "")
			{
				return (m_Zip & 0x80) != 0;
			}
			switch (number)
			{
			default:
				return false;
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
			case 36:
			case 45:
			case 46:
			case 47:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
			case 58:
				return true;
			}
		}
	}

	[SpecialName]
	internal int method_0()
	{
		return pattern switch
		{
			BackgroundType.None => 65, 
			BackgroundType.Solid => 64, 
			_ => method_7(BackgroundInternalColor, 65), 
		};
	}

	[SpecialName]
	internal int method_1()
	{
		if (pattern == BackgroundType.None)
		{
			return 64;
		}
		if (pattern == BackgroundType.Solid)
		{
			return method_7(ForeInternalColor, 65);
		}
		return method_7(ForeInternalColor, 64);
	}

	internal string method_2()
	{
		return name;
	}

	internal void method_3(string string_0)
	{
		name = string_0;
	}

	internal BorderCollection method_4()
	{
		return m_Borders;
	}

	/// <summary>
	/// </summary>
	public Style()
	{
		sheets = null;
		pattern = BackgroundType.None;
		ForeInternalColor = new InternalColor(bool_0: false);
		BackgroundInternalColor = new InternalColor(bool_0: false);
		BackgroundInternalColor.method_3(bool_0: true);
		ForeInternalColor.method_3(bool_0: true);
		m_aligment = 8;
	}

	internal Style(WorksheetCollection worksheetCollection_0)
	{
		sheets = worksheetCollection_0;
		pattern = BackgroundType.None;
		ForeInternalColor = new InternalColor(bool_0: false);
		BackgroundInternalColor = new InternalColor(bool_0: false);
		BackgroundInternalColor.method_3(bool_0: true);
		ForeInternalColor.method_3(bool_0: true);
		m_aligment = 8;
	}

	[SpecialName]
	internal WorksheetCollection method_5()
	{
		return sheets;
	}

	[SpecialName]
	internal void method_6(WorksheetCollection worksheetCollection_0)
	{
		sheets = worksheetCollection_0;
		if (font != null)
		{
			font.Sheets = sheets;
		}
	}

	internal int method_7(InternalColor internalColor_0, int int_0)
	{
		bool found = false;
		return method_8(internalColor_0, int_0, out found);
	}

	internal int method_8(InternalColor color, int defaultIndex, out bool found)
	{
		return color.method_0(sheets, defaultIndex, out found);
	}

	/// <summary>
	///       Copies data from another style object
	///       </summary>
	/// <param name="style">Source Style object</param>
	/// <remarks>
	///       This method does not copy the name of the style.
	///       If you want to copy the name ,please call the following codes after copying style:
	///       destStyle.Name = style.Name.</remarks>
	public void Copy(Style style)
	{
		if (sheets == null)
		{
			sheets = style.sheets;
		}
		m_SetFlag = style.m_SetFlag;
		m_UsedFlag = style.m_UsedFlag;
		if (style.font != null)
		{
			if (font == null)
			{
				font = new Font(sheets, this, bool_0: false);
			}
			font.Copy(style.font);
		}
		m_Zip = style.m_Zip;
		number = style.number;
		rotation = style.rotation;
		m_aligment = style.m_aligment;
		custom = style.custom;
		m_IndentLevel = style.m_IndentLevel;
		pattern = style.pattern;
		if (style.BackgroundInternalColor.ColorType == ColorType.IndexedColor && style.sheets != sheets)
		{
			BackgroundInternalColor.SetColor(ColorType.RGB, style.BackgroundInternalColor.method_7(style.sheets.Workbook));
		}
		else
		{
			BackgroundInternalColor.method_19(style.BackgroundInternalColor);
		}
		if (style.ForeInternalColor.ColorType == ColorType.IndexedColor && style.sheets != sheets)
		{
			ForeInternalColor.SetColor(ColorType.RGB, style.ForeInternalColor.method_7(style.sheets.Workbook));
		}
		else
		{
			ForeInternalColor.method_19(style.ForeInternalColor);
		}
		m_gradient = style.m_gradient;
		if (style.method_9())
		{
			m_Borders = new BorderCollection(this);
			m_Borders.Copy(style.Borders);
		}
		if (style.sheets == sheets)
		{
			parentXFIndex = style.parentXFIndex;
		}
	}

	[SpecialName]
	internal bool method_9()
	{
		if (m_Borders != null)
		{
			return m_Borders.method_4();
		}
		return false;
	}

	[SpecialName]
	internal bool method_10()
	{
		return (m_Zip & 0x10) != 0;
	}

	[SpecialName]
	internal void method_11(bool bool_0)
	{
		if (bool_0)
		{
			m_Zip |= 16;
			parentXFIndex = 0;
		}
		else
		{
			m_Zip &= 65519;
		}
	}

	[SpecialName]
	internal int method_12()
	{
		return parentXFIndex;
	}

	[SpecialName]
	internal void method_13(int int_0)
	{
		parentXFIndex = int_0;
	}

	internal void GetStyle(WorksheetCollection worksheetCollection_0, int int_0)
	{
		Style style = null;
		style = ((int_0 < 0 || int_0 > worksheetCollection_0.method_58().Count) ? worksheetCollection_0.method_58()[15] : worksheetCollection_0.method_58()[int_0]);
		Copy(style);
	}

	/// <summary>
	///       Apply the named style to the styles of the cells which use this named style.
	///       It works like clicking the "ok" button after you finished modifying the style.
	///       Only applies for named style.
	///       </summary>
	public void Update()
	{
		if (name == null || name == "")
		{
			return;
		}
		if (name == "Normal")
		{
			sheets.method_52()[0] = Font;
			sheets.method_74();
		}
		Class1683 @class = sheets.method_58();
		bool flag = false;
		int num = 0;
		for (num = 0; num < @class.Count; num++)
		{
			Style style = @class[num];
			if (style != null && (style == this || style.Name == Name))
			{
				if (style != this)
				{
					@class[num] = this;
				}
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			method_11(bool_0: false);
			@class.method_0(this);
			return;
		}
		int num2 = num;
		for (num++; num < @class.Count; num++)
		{
			Style style2 = @class[num];
			if (style2 != null && style2.method_12() == num2)
			{
				method_14(style2);
			}
		}
	}

	internal void method_14(Style style_0)
	{
		if (method_17() && !style_0.method_17())
		{
			style_0.number = number;
			style_0.custom = custom;
			if ((m_Zip & 0x80u) != 0)
			{
				style_0.m_Zip |= 128;
			}
			else
			{
				style_0.m_Zip &= 65407;
			}
		}
		if (method_19() && !style_0.method_19())
		{
			style_0.Font.Copy(Font);
		}
		if (method_21() && !style_0.method_21())
		{
			style_0.m_aligment = m_aligment;
			style_0.rotation = rotation;
			style_0.m_IndentLevel = m_IndentLevel;
			style_0.m_Zip &= 65523;
			style_0.m_Zip = (ushort)(style_0.m_Zip | (byte)(m_Zip & 0xCu));
		}
		if (method_23() && !style_0.method_23())
		{
			style_0.Borders.Copy(Borders);
		}
		if (method_25() && !style_0.method_25())
		{
			style_0.pattern = pattern;
			style_0.ForeInternalColor.method_19(ForeInternalColor);
			style_0.BackgroundInternalColor.method_19(BackgroundInternalColor);
		}
		if (method_27() && !style_0.method_27())
		{
			style_0.m_Zip &= 65532;
			style_0.m_Zip = (ushort)(style_0.m_Zip | (byte)(m_Zip & 3u));
		}
	}

	[SpecialName]
	internal byte method_15()
	{
		return m_UsedFlag;
	}

	[SpecialName]
	internal void method_16(byte byte_0)
	{
		m_UsedFlag = byte_0;
	}

	[SpecialName]
	internal bool method_17()
	{
		return (m_UsedFlag & 4) != 0;
	}

	[SpecialName]
	internal void method_18(bool bool_0)
	{
		if (bool_0)
		{
			m_UsedFlag |= 4;
		}
		else
		{
			m_UsedFlag &= 251;
		}
	}

	[SpecialName]
	internal bool method_19()
	{
		return (m_UsedFlag & 8) != 0;
	}

	[SpecialName]
	internal void method_20(bool bool_0)
	{
		if (bool_0)
		{
			m_UsedFlag |= 8;
		}
		else
		{
			m_UsedFlag &= 247;
		}
	}

	[SpecialName]
	internal bool method_21()
	{
		return (m_UsedFlag & 0x10) != 0;
	}

	[SpecialName]
	internal void method_22(bool bool_0)
	{
		if (bool_0)
		{
			m_UsedFlag |= 16;
		}
		else
		{
			m_UsedFlag &= 239;
		}
	}

	[SpecialName]
	internal bool method_23()
	{
		return (m_UsedFlag & 0x20) != 0;
	}

	[SpecialName]
	internal void method_24(bool bool_0)
	{
		if (bool_0)
		{
			m_UsedFlag |= 32;
		}
		else
		{
			m_UsedFlag &= 223;
		}
	}

	[SpecialName]
	internal bool method_25()
	{
		return (m_UsedFlag & 0x40) != 0;
	}

	[SpecialName]
	internal void method_26(bool bool_0)
	{
		if (bool_0)
		{
			m_UsedFlag |= 64;
		}
		else
		{
			m_UsedFlag &= 191;
		}
	}

	[SpecialName]
	internal bool method_27()
	{
		return (m_UsedFlag & 0x80) != 0;
	}

	[SpecialName]
	internal void method_28(bool bool_0)
	{
		if (bool_0)
		{
			m_UsedFlag |= 128;
		}
		else
		{
			m_UsedFlag &= 127;
		}
	}

	internal void GetStyle(byte[] byte_0)
	{
		ushort num = BitConverter.ToUInt16(byte_0, 0);
		if (num > 4)
		{
			num = (ushort)(num - 1);
		}
		if (num >= sheets.method_52().Count)
		{
			num = 0;
		}
		Font.Copy((Font)sheets.method_52()[num]);
		ushort num2 = BitConverter.ToUInt16(byte_0, 2);
		for (int i = 0; i < sheets.method_55().Count; i++)
		{
			Class639 @class = (Class639)sheets.method_55()[i];
			if (@class.Index != num2)
			{
				continue;
			}
			if (@class.Custom != null && !(@class.Custom == ""))
			{
				custom = @class.Custom;
				string input = Class1386.smethod_2(custom);
				if (Regex.IsMatch(input, Class1386.string_1, RegexOptions.IgnoreCase))
				{
					m_Zip |= 128;
				}
				else
				{
					m_Zip &= 65407;
				}
			}
			else
			{
				custom = "";
				m_Zip &= 65407;
			}
		}
		number = num2;
		if ((byte_0[4] & 1) == 0)
		{
			IsLocked = false;
		}
		else
		{
			IsLocked = true;
		}
		if ((byte_0[4] & 2) == 0)
		{
			IsFormulaHidden = false;
		}
		else
		{
			IsFormulaHidden = true;
		}
		if ((byte_0[4] & 8u) != 0)
		{
			method_48(bool_0: true);
		}
		int num3 = byte_0[6] & 7;
		bool flag = false;
		m_aligment = 0;
		m_aligment |= (byte)num3;
		if (HorizontalAlignment != TextAlignmentType.General)
		{
			method_36(StyleModifyFlag.HorizontalAlignment);
			flag = true;
		}
		if (VerticalAlignment != 0)
		{
			method_36(StyleModifyFlag.VerticalAlignment);
			flag = true;
		}
		if ((byte_0[6] & 8) == 0)
		{
			IsTextWrapped = false;
		}
		else
		{
			IsTextWrapped = true;
			flag = true;
		}
		num3 = (byte_0[6] & 0x70) >> 4;
		m_aligment |= (byte)(num3 << 3);
		if (byte_0[7] > 90 && byte_0[7] != byte.MaxValue)
		{
			rotation = 90 - byte_0[7];
		}
		else
		{
			rotation = byte_0[7];
		}
		m_IndentLevel = (byte)(byte_0[8] & 0xFu);
		if ((byte_0[8] & 0x10) == 0)
		{
			ShrinkToFit = false;
		}
		else
		{
			ShrinkToFit = true;
		}
		num3 = byte_0[8] & 0xC0;
		m_aligment |= (byte)num3;
		if ((byte_0[4] & 4) == 0)
		{
			method_11(bool_0: true);
		}
		else
		{
			method_11(bool_0: false);
		}
		if (!method_10())
		{
			parentXFIndex = 4095;
		}
		else if (byte_0[5] == byte.MaxValue)
		{
			num3 = byte_0[4] & 0xF0;
			if (num3 == 240)
			{
				parentXFIndex = 0;
			}
			else
			{
				parentXFIndex = ((byte_0[4] & 0xF0) >> 4) + (byte_0[5] << 4);
			}
		}
		else
		{
			parentXFIndex = ((byte_0[4] & 0xF0) >> 4) + (byte_0[5] << 4);
		}
		num3 = byte_0[10] & 0xF;
		method_29(num3, BorderType.LeftBorder);
		num3 = (byte_0[10] & 0xF0) >> 4;
		method_29(num3, BorderType.RightBorder);
		num3 = byte_0[11] & 0xF;
		method_29(num3, BorderType.TopBorder);
		num3 = (byte_0[11] & 0xF0) >> 4;
		method_29(num3, BorderType.BottomBorder);
		int num4 = byte_0[12] & 0x7F;
		if (num4 >= 0 && num4 < 64)
		{
			Borders[BorderType.LeftBorder].InternalColor.SetColor(ColorType.IndexedColor, num4);
		}
		else
		{
			Borders[BorderType.LeftBorder].InternalColor.SetColor(ColorType.AutomaticIndex, num4);
		}
		num4 = ((byte_0[12] & 0x80) >> 7) + ((byte_0[13] & 0x3F) << 1);
		if (num4 >= 0 && num4 < 64)
		{
			Borders[BorderType.RightBorder].InternalColor.SetColor(ColorType.IndexedColor, num4);
		}
		else
		{
			Borders[BorderType.RightBorder].InternalColor.SetColor(ColorType.AutomaticIndex, num4);
		}
		int num5 = (byte_0[13] & 0xC0) >> 6;
		num4 = byte_0[14] & 0x7F;
		if (num4 >= 0 && num4 < 64)
		{
			Borders[BorderType.TopBorder].InternalColor.SetColor(ColorType.IndexedColor, num4);
		}
		else
		{
			Borders[BorderType.TopBorder].InternalColor.SetColor(ColorType.AutomaticIndex, num4);
		}
		num4 = ((byte_0[14] & 0x80) >> 7) + ((byte_0[15] & 0x3F) << 1);
		if (num4 >= 0 && num4 < 64)
		{
			Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.IndexedColor, num4);
		}
		else
		{
			Borders[BorderType.BottomBorder].InternalColor.SetColor(ColorType.AutomaticIndex, num4);
		}
		num4 = ((byte_0[15] & 0xC0) >> 6) + ((byte_0[16] & 0x1F) << 2);
		InternalColor internalColor = new InternalColor(bool_0: false);
		if (num4 >= 0 && num4 < 64)
		{
			internalColor.SetColor(ColorType.IndexedColor, num4);
		}
		else
		{
			internalColor.SetColor(ColorType.AutomaticIndex, num4);
		}
		num3 = ((byte_0[16] & 0xE0) >> 5) + ((byte_0[17] & 1) << 3);
		switch (num5)
		{
		case 1:
			Borders[BorderType.DiagonalDown].InternalColor = internalColor;
			method_29(num3, BorderType.DiagonalDown);
			break;
		case 2:
			Borders[BorderType.DiagonalUp].InternalColor = internalColor;
			method_29(num3, BorderType.DiagonalUp);
			break;
		case 3:
			Borders[BorderType.DiagonalDown].InternalColor = internalColor;
			method_29(num3, BorderType.DiagonalDown);
			Borders[BorderType.DiagonalUp].InternalColor = internalColor;
			method_29(num3, BorderType.DiagonalUp);
			break;
		}
		num3 = (byte_0[17] & 0xFC) >> 2;
		pattern = (BackgroundType)num3;
		if (pattern == BackgroundType.None)
		{
			ForeInternalColor.method_3(bool_0: true);
			BackgroundInternalColor.method_3(bool_0: true);
		}
		else
		{
			num4 = byte_0[18] & 0x7F;
			if (num4 >= 0 && num4 < 64)
			{
				ForeInternalColor.SetColor(ColorType.IndexedColor, num4);
			}
			else
			{
				ForeInternalColor.method_3(bool_0: true);
			}
			num4 = ((byte_0[18] & 0x80) >> 7) + ((byte_0[19] & 0x3F) << 1);
			if (num4 >= 0 && num4 < 64)
			{
				BackgroundInternalColor.SetColor(ColorType.IndexedColor, num4);
			}
			else
			{
				BackgroundInternalColor.method_3(bool_0: true);
			}
		}
		if ((byte_0[19] & 0x40u) != 0)
		{
			method_50(bool_0: true);
		}
		if (method_10())
		{
			m_UsedFlag = byte_0[9];
			if (method_21() || !flag)
			{
				return;
			}
			if (parentXFIndex > 0 && parentXFIndex < method_5().method_58().Count)
			{
				Style style = method_5().method_58()[parentXFIndex];
				if (!style.method_21())
				{
					method_22(bool_0: true);
				}
			}
			else
			{
				method_22(bool_0: true);
			}
		}
		else
		{
			m_UsedFlag = (byte)((uint)(~byte_0[9]) & 0xFCu);
		}
	}

	private void method_29(int int_0, BorderType borderType_0)
	{
		switch (int_0)
		{
		case 1:
			Borders[borderType_0].method_2(CellBorderType.Thin);
			return;
		case 2:
			Borders[borderType_0].method_2(CellBorderType.Medium);
			return;
		case 3:
			Borders[borderType_0].method_2(CellBorderType.Dashed);
			return;
		case 4:
			Borders[borderType_0].method_2(CellBorderType.Dotted);
			return;
		case 5:
			Borders[borderType_0].method_2(CellBorderType.Thick);
			return;
		case 6:
			Borders[borderType_0].method_2(CellBorderType.Double);
			return;
		case 7:
			Borders[borderType_0].method_2(CellBorderType.Hair);
			return;
		case 8:
			Borders[borderType_0].method_2(CellBorderType.MediumDashed);
			return;
		case 9:
			Borders[borderType_0].method_2(CellBorderType.DashDot);
			return;
		case 10:
			Borders[borderType_0].method_2(CellBorderType.MediumDashDot);
			return;
		case 11:
			Borders[borderType_0].method_2(CellBorderType.DashDotDot);
			return;
		case 12:
			Borders[borderType_0].method_2(CellBorderType.MediumDashDotDot);
			return;
		case 13:
			Borders[borderType_0].method_2(CellBorderType.SlantedDashDot);
			return;
		}
		if (m_Borders != null)
		{
			m_Borders[borderType_0].method_2(CellBorderType.None);
		}
	}

	internal bool method_30(Style style_0)
	{
		Workbook workbook = sheets.Workbook;
		Workbook workbook2 = style_0.sheets.Workbook;
		if (m_SetFlag != style_0.m_SetFlag)
		{
			return false;
		}
		if (m_Zip != style_0.m_Zip)
		{
			return false;
		}
		if (m_aligment != style_0.m_aligment)
		{
			return false;
		}
		if (m_IndentLevel != style_0.m_IndentLevel)
		{
			return false;
		}
		if (rotation != style_0.rotation)
		{
			return false;
		}
		if (m_gradient != style_0.m_gradient)
		{
			return false;
		}
		if (IsGradient)
		{
			if (ForeInternalColor.method_14(style_0.ForeInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
			if (BackgroundInternalColor.method_14(style_0.BackgroundInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
		}
		if (method_25())
		{
			if (IsModified(StyleModifyFlag.Pattern) && Pattern != style_0.Pattern)
			{
				return false;
			}
			if (IsModified(StyleModifyFlag.ForegroundColor) && ForeInternalColor.method_14(style_0.ForeInternalColor, workbook, workbook2))
			{
				return false;
			}
			if (IsModified(StyleModifyFlag.BackgroundColor) && BackgroundInternalColor.method_14(style_0.BackgroundInternalColor, workbook, workbook2))
			{
				return false;
			}
		}
		if (method_19() && !Font.method_20(style_0.Font, sheets.Workbook, style_0.sheets.Workbook))
		{
			return false;
		}
		if (IsModified(StyleModifyFlag.NumberFormat))
		{
			if (custom != null && !(custom == ""))
			{
				if (style_0.custom == null || custom != style_0.custom)
				{
					return false;
				}
			}
			else if (style_0.custom != null && style_0.custom != "")
			{
				return false;
			}
			if ((custom == null || custom == "") && (style_0.custom == null || style_0.custom == ""))
			{
				if (number <= 0)
				{
					if (style_0.number > 0)
					{
						return false;
					}
				}
				else if (number != style_0.number)
				{
					return false;
				}
			}
		}
		if (method_23())
		{
			if (IsModified(StyleModifyFlag.LeftBorder) && !Borders[BorderType.LeftBorder].method_3(style_0.Borders[BorderType.LeftBorder], workbook, workbook2))
			{
				return false;
			}
			if (IsModified(StyleModifyFlag.RightBorder) && !Borders[BorderType.RightBorder].method_3(style_0.Borders[BorderType.RightBorder], workbook, workbook2))
			{
				return false;
			}
			if (IsModified(StyleModifyFlag.TopBorder) && !Borders[BorderType.TopBorder].method_3(style_0.Borders[BorderType.TopBorder], workbook, workbook2))
			{
				return false;
			}
			if (IsModified(StyleModifyFlag.BottomBorder) && !Borders[BorderType.BottomBorder].method_3(style_0.Borders[BorderType.BottomBorder], workbook, workbook2))
			{
				return false;
			}
			if (IsModified(StyleModifyFlag.DiagonalDownBorder) && !Borders[BorderType.DiagonalDown].method_3(style_0.Borders[BorderType.DiagonalDown], workbook, workbook2))
			{
				return false;
			}
			if (IsModified(StyleModifyFlag.DiagonalUpBorder) && !Borders[BorderType.DiagonalUp].method_3(style_0.Borders[BorderType.DiagonalUp], workbook, workbook2))
			{
				return false;
			}
			if (IsModified(StyleModifyFlag.HorizontalBorder) && !Borders[BorderType.Horizontal].method_3(style_0.Borders[BorderType.Horizontal], workbook, workbook2))
			{
				return false;
			}
			if (IsModified(StyleModifyFlag.VerticalBorder) && !Borders[BorderType.Vertical].method_3(style_0.Borders[BorderType.Vertical], workbook, workbook2))
			{
				return false;
			}
		}
		return true;
	}

	internal bool method_31(Style style_0)
	{
		if (m_UsedFlag != style_0.m_UsedFlag)
		{
			return false;
		}
		if (m_Zip != style_0.m_Zip)
		{
			return false;
		}
		if (m_aligment != style_0.m_aligment)
		{
			return false;
		}
		if (m_IndentLevel != style_0.m_IndentLevel)
		{
			return false;
		}
		if (rotation != style_0.rotation)
		{
			return false;
		}
		if (pattern != style_0.pattern)
		{
			return false;
		}
		if (m_gradient != style_0.m_gradient)
		{
			return false;
		}
		if (IsGradient)
		{
			if (ForeInternalColor.method_14(style_0.ForeInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
			if (BackgroundInternalColor.method_14(style_0.BackgroundInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
		}
		switch (pattern)
		{
		default:
			if (ForeInternalColor.method_14(style_0.ForeInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
			if (BackgroundInternalColor.method_14(style_0.BackgroundInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
			break;
		case BackgroundType.Solid:
			if (ForeInternalColor.method_14(style_0.ForeInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
			break;
		case BackgroundType.None:
			break;
		}
		if (font == null)
		{
			if (style_0.font != null && !style_0.font.method_20(sheets.DefaultFont, style_0.sheets.Workbook, sheets.Workbook))
			{
				return false;
			}
		}
		else if (style_0.font == null)
		{
			if (!font.method_20(sheets.DefaultFont, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
		}
		else if (!font.method_20(style_0.font, sheets.Workbook, style_0.sheets.Workbook))
		{
			return false;
		}
		if (custom != null && !(custom == ""))
		{
			if (style_0.custom == null || custom != style_0.custom)
			{
				return false;
			}
		}
		else if (style_0.custom != null && style_0.custom != "")
		{
			return false;
		}
		if ((custom == null || custom == "") && (style_0.custom == null || style_0.custom == ""))
		{
			if (number <= 0)
			{
				if (style_0.number > 0)
				{
					return false;
				}
			}
			else if (number != style_0.number)
			{
				return false;
			}
		}
		if (style_0.m_Borders == null)
		{
			if (method_9())
			{
				return false;
			}
		}
		else if (m_Borders == null)
		{
			if (style_0.method_9())
			{
				return false;
			}
		}
		else if (!m_Borders.method_5(style_0.m_Borders, sheets.Workbook, style_0.sheets.Workbook))
		{
			return false;
		}
		return true;
	}

	internal bool method_32(Style style_0, byte byte_0)
	{
		if (m_Zip != style_0.m_Zip)
		{
			return false;
		}
		if (m_aligment != style_0.m_aligment)
		{
			return false;
		}
		if (m_IndentLevel != style_0.m_IndentLevel)
		{
			return false;
		}
		if (rotation != style_0.rotation)
		{
			return false;
		}
		if (pattern != style_0.pattern)
		{
			return false;
		}
		if (m_gradient != style_0.m_gradient)
		{
			return false;
		}
		switch (pattern)
		{
		default:
			if (ForeInternalColor.method_14(style_0.ForeInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
			if (BackgroundInternalColor.method_14(style_0.BackgroundInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
			break;
		case BackgroundType.Solid:
			if (ForeInternalColor.method_14(style_0.ForeInternalColor, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
			break;
		case BackgroundType.None:
			break;
		}
		if (font == null)
		{
			if (style_0.font != null && !style_0.font.method_20(sheets.DefaultFont, style_0.sheets.Workbook, sheets.Workbook))
			{
				return false;
			}
		}
		else if (style_0.font == null)
		{
			if (!font.method_20(sheets.DefaultFont, sheets.Workbook, style_0.sheets.Workbook))
			{
				return false;
			}
		}
		else if (!font.method_20(style_0.font, sheets.Workbook, style_0.sheets.Workbook))
		{
			return false;
		}
		if (custom != null && !(custom == ""))
		{
			if (style_0.custom == null || custom != style_0.custom)
			{
				return false;
			}
		}
		else if (style_0.custom != null && style_0.custom != "")
		{
			return false;
		}
		if ((custom == null || custom == "") && (style_0.custom == null || style_0.custom == ""))
		{
			if (number <= 0)
			{
				if (style_0.number > 0)
				{
					return false;
				}
			}
			else if (number != style_0.number)
			{
				return false;
			}
		}
		if (style_0.m_Borders == null)
		{
			if (method_9())
			{
				return false;
			}
		}
		else if (m_Borders == null)
		{
			if (style_0.method_9())
			{
				return false;
			}
		}
		else if (!m_Borders.method_5(style_0.m_Borders, sheets.Workbook, style_0.sheets.Workbook))
		{
			return false;
		}
		return true;
	}

	internal bool method_33(Style style_0)
	{
		if (m_Zip != style_0.m_Zip)
		{
			return false;
		}
		if (m_aligment != style_0.m_aligment)
		{
			return false;
		}
		if (m_IndentLevel != style_0.m_IndentLevel)
		{
			return false;
		}
		if (font == null)
		{
			if (style_0.font != null && style_0.font.method_21() != 0)
			{
				return false;
			}
		}
		else if (style_0.font == null)
		{
			if (font.method_21() != 0)
			{
				return false;
			}
		}
		else if (!font.method_18(style_0.font))
		{
			return false;
		}
		if (custom != null && !(custom == ""))
		{
			if (style_0.custom == null || custom != style_0.custom)
			{
				return false;
			}
		}
		else if (style_0.custom != null && style_0.custom != "")
		{
			return false;
		}
		if ((custom == null || custom == "") && (style_0.custom == null || style_0.custom == "") && number != style_0.number)
		{
			return false;
		}
		if (rotation != style_0.rotation)
		{
			return false;
		}
		if ((BackgroundColor.ToArgb() & 0xFFFFFF) != (style_0.BackgroundColor.ToArgb() & 0xFFFFFF))
		{
			return false;
		}
		if (style_0.m_Borders == null)
		{
			if (m_Borders != null)
			{
				return false;
			}
		}
		else
		{
			if (m_Borders == null)
			{
				return false;
			}
			Border border = Borders[BorderType.BottomBorder];
			Border border2 = style_0.Borders[BorderType.BottomBorder];
			if (!smethod_0(border.Color, border2.Color))
			{
				return false;
			}
			if (border.LineStyle != border2.LineStyle)
			{
				return false;
			}
			border = Borders[BorderType.DiagonalDown];
			border2 = style_0.Borders[BorderType.DiagonalDown];
			if (!smethod_0(border.Color, border2.Color))
			{
				return false;
			}
			if (border.LineStyle != border2.LineStyle)
			{
				return false;
			}
			border = Borders[BorderType.DiagonalUp];
			border2 = style_0.Borders[BorderType.DiagonalUp];
			if (!smethod_0(border.Color, border2.Color))
			{
				return false;
			}
			if (border.LineStyle != border2.LineStyle)
			{
				return false;
			}
			border = Borders[BorderType.LeftBorder];
			border2 = style_0.Borders[BorderType.LeftBorder];
			if (!smethod_0(border.Color, border2.Color))
			{
				return false;
			}
			if (border.LineStyle != border2.LineStyle)
			{
				return false;
			}
			border = Borders[BorderType.RightBorder];
			border2 = style_0.Borders[BorderType.RightBorder];
			if (!smethod_0(border.Color, border2.Color))
			{
				return false;
			}
			if (border.LineStyle != border2.LineStyle)
			{
				return false;
			}
			border = Borders[BorderType.TopBorder];
			border2 = style_0.Borders[BorderType.TopBorder];
			if (!smethod_0(border.Color, border2.Color))
			{
				return false;
			}
			if (border.LineStyle != border2.LineStyle)
			{
				return false;
			}
		}
		if ((ForegroundColor.ToArgb() & 0xFFFFFF) != (style_0.ForegroundColor.ToArgb() & 0xFFFFFF))
		{
			return false;
		}
		if (pattern != style_0.pattern)
		{
			return false;
		}
		return true;
	}

	private static bool smethod_0(Color color_0, Color color_1)
	{
		if (!Class1178.smethod_4(color_0, color_1))
		{
			if (Class1178.smethod_0(color_0))
			{
				if (!Class1178.smethod_4(color_1, Color.Black))
				{
					return false;
				}
			}
			else
			{
				if (!Class1178.smethod_4(color_0, Color.Black))
				{
					return false;
				}
				if (!Class1178.smethod_0(color_1))
				{
					return false;
				}
			}
		}
		return true;
	}

	[SpecialName]
	internal uint method_34()
	{
		return m_SetFlag;
	}

	[SpecialName]
	internal void method_35(uint uint_0)
	{
		m_SetFlag = uint_0;
	}

	/// <summary>
	///       Gets which property of the style is modified.
	///       </summary>
	/// <param name="modifyFlag">
	/// </param>
	/// <returns>
	/// </returns>
	public bool IsModified(StyleModifyFlag modifyFlag)
	{
		switch (modifyFlag)
		{
		default:
			return false;
		case StyleModifyFlag.All:
			if (m_SetFlag == 0)
			{
				if (font == null)
				{
					return false;
				}
				return font.IsModified(StyleModifyFlag.Font);
			}
			return m_SetFlag != 0;
		case StyleModifyFlag.Borders:
			return (m_SetFlag & 0xFF000000u) != 0;
		case StyleModifyFlag.LeftBorder:
			return (m_SetFlag & 0x1000000) != 0;
		case StyleModifyFlag.RightBorder:
			return (m_SetFlag & 0x2000000) != 0;
		case StyleModifyFlag.TopBorder:
			return (m_SetFlag & 0x4000000) != 0;
		case StyleModifyFlag.BottomBorder:
			return (m_SetFlag & 0x8000000) != 0;
		case StyleModifyFlag.HorizontalBorder:
			return (m_SetFlag & 0x10000000) != 0;
		case StyleModifyFlag.VerticalBorder:
			return (m_SetFlag & 0x80000000u) != 0;
		case StyleModifyFlag.Diagonal:
			return (m_SetFlag & 0x60000000) != 0;
		case StyleModifyFlag.DiagonalDownBorder:
			return (m_SetFlag & 0x40000000) != 0;
		case StyleModifyFlag.DiagonalUpBorder:
			return (m_SetFlag & 0x20000000) != 0;
		case StyleModifyFlag.Font:
		case StyleModifyFlag.FontSize:
		case StyleModifyFlag.FontName:
		case StyleModifyFlag.FontFamily:
		case StyleModifyFlag.FontCharset:
		case StyleModifyFlag.FontColor:
		case StyleModifyFlag.FontWeight:
		case StyleModifyFlag.FontItalic:
		case StyleModifyFlag.FontUnderline:
		case StyleModifyFlag.FontStrike:
		case StyleModifyFlag.FontSubscript:
		case StyleModifyFlag.FontSuperscript:
		case StyleModifyFlag.FontScript:
			if (font == null)
			{
				return false;
			}
			return font.IsModified(modifyFlag);
		case StyleModifyFlag.NumberFormat:
			return (m_SetFlag & 1) != 0;
		case StyleModifyFlag.HorizontalAlignment:
			return (m_SetFlag & 0x4000) != 0;
		case StyleModifyFlag.VerticalAlignment:
			return (m_SetFlag & 0x800000) != 0;
		case StyleModifyFlag.Indent:
			return (m_SetFlag & 0x8000) != 0;
		case StyleModifyFlag.Rotation:
			return (m_SetFlag & 0x100000) != 0;
		case StyleModifyFlag.WrapText:
			return (m_SetFlag & 0x40000) != 0;
		case StyleModifyFlag.ShrinkToFit:
			return (m_SetFlag & 0x200000) != 0;
		case StyleModifyFlag.TextDirection:
			return (m_SetFlag & 0x400000) != 0;
		case StyleModifyFlag.CellShading:
			return (m_SetFlag & 0x83000) != 0;
		case StyleModifyFlag.Pattern:
			return (m_SetFlag & 0x80000) != 0;
		case StyleModifyFlag.ForegroundColor:
			return (m_SetFlag & 0x2000) != 0;
		case StyleModifyFlag.BackgroundColor:
			return (m_SetFlag & 0x1000) != 0;
		case StyleModifyFlag.Locked:
			return (m_SetFlag & 0x20000) != 0;
		case StyleModifyFlag.HideFormula:
			return (m_SetFlag & 0x10000) != 0;
		case StyleModifyFlag.AlignmentSettings:
			return (m_SetFlag & 0xF4C000) != 0;
		}
	}

	internal void method_36(StyleModifyFlag styleModifyFlag_0)
	{
		switch (styleModifyFlag_0)
		{
		case StyleModifyFlag.All:
			m_SetFlag = 2147483647u;
			Font.method_29(StyleModifyFlag.Font);
			break;
		case StyleModifyFlag.Borders:
			m_SetFlag |= 2130706432u;
			break;
		case StyleModifyFlag.LeftBorder:
			m_SetFlag |= 16777216u;
			break;
		case StyleModifyFlag.RightBorder:
			m_SetFlag |= 33554432u;
			break;
		case StyleModifyFlag.TopBorder:
			m_SetFlag |= 67108864u;
			break;
		case StyleModifyFlag.BottomBorder:
			m_SetFlag |= 134217728u;
			break;
		case StyleModifyFlag.HorizontalBorder:
			m_SetFlag |= 268435456u;
			break;
		case StyleModifyFlag.VerticalBorder:
			m_SetFlag |= 2147483648u;
			break;
		case StyleModifyFlag.Diagonal:
			m_SetFlag |= 1610612736u;
			break;
		case StyleModifyFlag.DiagonalDownBorder:
			m_SetFlag |= 1073741824u;
			break;
		case StyleModifyFlag.DiagonalUpBorder:
			m_SetFlag |= 536870912u;
			break;
		case StyleModifyFlag.Font:
		case StyleModifyFlag.FontSize:
		case StyleModifyFlag.FontName:
		case StyleModifyFlag.FontFamily:
		case StyleModifyFlag.FontCharset:
		case StyleModifyFlag.FontColor:
		case StyleModifyFlag.FontWeight:
		case StyleModifyFlag.FontItalic:
		case StyleModifyFlag.FontUnderline:
		case StyleModifyFlag.FontStrike:
		case StyleModifyFlag.FontScript:
			Font.method_29(styleModifyFlag_0);
			break;
		case StyleModifyFlag.NumberFormat:
			m_SetFlag |= 1u;
			break;
		case StyleModifyFlag.HorizontalAlignment:
			m_SetFlag |= 16384u;
			break;
		case StyleModifyFlag.VerticalAlignment:
			m_SetFlag |= 8388608u;
			break;
		case StyleModifyFlag.Indent:
			m_SetFlag |= 32768u;
			break;
		case StyleModifyFlag.Rotation:
			m_SetFlag |= 1048576u;
			break;
		case StyleModifyFlag.WrapText:
			m_SetFlag |= 262144u;
			break;
		case StyleModifyFlag.ShrinkToFit:
			m_SetFlag |= 2097152u;
			break;
		case StyleModifyFlag.TextDirection:
			m_SetFlag |= 4194304u;
			break;
		case StyleModifyFlag.CellShading:
			m_SetFlag |= 536576u;
			break;
		case StyleModifyFlag.Pattern:
			m_SetFlag |= 524288u;
			break;
		case StyleModifyFlag.ForegroundColor:
			m_SetFlag |= 8192u;
			break;
		case StyleModifyFlag.BackgroundColor:
			m_SetFlag |= 4096u;
			break;
		case StyleModifyFlag.Locked:
			m_SetFlag |= 131072u;
			break;
		case StyleModifyFlag.FontSubscript:
		case StyleModifyFlag.FontSuperscript:
			break;
		case StyleModifyFlag.HideFormula:
			m_SetFlag |= 65536u;
			break;
		}
	}

	/// <summary>
	///       Determines whether two Style instances are equal.
	///       </summary>
	/// <param name="obj">The Style object to compare with the current Style object. </param>
	/// <returns>true if the specified Object is equal to the current Object; otherwise, false.
	///       </returns>
	public override bool Equals(object obj)
	{
		if (obj != null && GetType() == obj.GetType())
		{
			return method_31((Style)obj);
		}
		return false;
	}

	/// <summary>
	///       Serves as a hash function for a Style object.
	///       </summary>
	/// <returns>A hash code for the current Object.</returns>
	/// <remarks>This method is only for internal use.</remarks>
	public override int GetHashCode()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(BackgroundInternalColor.ToString());
		if (method_4() != null)
		{
			method_37(stringBuilder);
		}
		stringBuilder.Append(m_IndentLevel.ToString());
		if (font != null)
		{
			font.method_27(stringBuilder);
		}
		stringBuilder.Append(ForeInternalColor.ToString());
		stringBuilder.Append(m_aligment.ToString());
		stringBuilder.Append(m_IndentLevel.ToString());
		stringBuilder.Append(number.ToString());
		stringBuilder.Append(Class1130.smethod_5(pattern));
		stringBuilder.Append(rotation.ToString());
		stringBuilder.Append(parentXFIndex.ToString());
		stringBuilder.Append(m_Zip.ToString());
		return stringBuilder.ToString().GetHashCode();
	}

	private void method_37(StringBuilder stringBuilder_0)
	{
		Border border_ = Borders[BorderType.BottomBorder];
		method_38(border_, stringBuilder_0);
		border_ = Borders[BorderType.DiagonalDown];
		method_38(border_, stringBuilder_0);
		border_ = Borders[BorderType.DiagonalUp];
		method_38(border_, stringBuilder_0);
		border_ = Borders[BorderType.LeftBorder];
		method_38(border_, stringBuilder_0);
		border_ = Borders[BorderType.RightBorder];
		method_38(border_, stringBuilder_0);
		border_ = Borders[BorderType.TopBorder];
		method_38(border_, stringBuilder_0);
	}

	private void method_38(Border border_0, StringBuilder stringBuilder_0)
	{
		stringBuilder_0.Append(Class1130.smethod_3(border_0.method_0()));
		stringBuilder_0.Append(border_0.Color.ToString());
		stringBuilder_0.Append(Class1130.smethod_4(border_0.LineStyle));
	}

	internal void method_39(int int_0)
	{
		m_IndentLevel = (byte)int_0;
		if (!method_21())
		{
			method_22(bool_0: true);
		}
		m_SetFlag |= 32768u;
	}

	internal Font method_40()
	{
		return font;
	}

	internal void method_41(out int number, out string custom)
	{
		number = this.number;
		custom = this.custom;
	}

	internal void method_42(int int_0, string string_0)
	{
		number = int_0;
		custom = string_0;
	}

	internal void method_43(int int_0, string string_0, bool bool_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			if (string_0.Length > 255)
			{
				throw new CellsException(ExceptionType.InvalidData, "The custom number format string is too long.");
			}
			custom = string_0;
			if (bool_0)
			{
				m_Zip |= 128;
			}
			else
			{
				m_Zip &= 65407;
			}
		}
		else
		{
			custom = "";
			m_Zip &= 65407;
		}
		number = int_0;
		method_18(bool_0: true);
		m_SetFlag |= 1u;
	}

	internal int method_44()
	{
		return number;
	}

	internal void method_45(int int_0)
	{
		number = int_0;
	}

	/// <summary>
	///       Sets the border of the style.
	///       </summary>
	/// <param name="borderEdge">
	/// </param>
	/// <param name="borderStyle">
	/// </param>
	/// <param name="borderColor">
	/// </param>
	/// <returns>
	/// </returns>
	public bool SetBorder(BorderType borderEdge, CellBorderType borderStyle, Color borderColor)
	{
		Border border = null;
		if (borderStyle == CellBorderType.None)
		{
			if (m_Borders != null && m_Borders[borderEdge].LineStyle != 0)
			{
				border = Borders[borderEdge];
				border.LineStyle = borderStyle;
				border.Color = borderColor;
				return true;
			}
			return false;
		}
		border = Borders[borderEdge];
		if (borderStyle == border.LineStyle && border.InternalColor.method_12(borderColor, Color.Black, sheets.Workbook))
		{
			return false;
		}
		border = Borders[borderEdge];
		border.LineStyle = borderStyle;
		border.Color = borderColor;
		return true;
	}

	internal string method_46()
	{
		return custom;
	}

	[SpecialName]
	internal bool method_47()
	{
		return (m_Zip & 0x100) != 0;
	}

	[SpecialName]
	internal void method_48(bool bool_0)
	{
		if (bool_0)
		{
			m_Zip |= 256;
		}
		else
		{
			m_Zip &= 65279;
		}
	}

	[SpecialName]
	internal bool method_49()
	{
		return (m_Zip & 0x40) != 0;
	}

	[SpecialName]
	internal void method_50(bool bool_0)
	{
		if (bool_0)
		{
			m_Zip |= 64;
		}
		else
		{
			m_Zip &= 65471;
		}
	}

	[SpecialName]
	internal GradientStyleType method_51()
	{
		return (m_gradient & 0xF) switch
		{
			1 => GradientStyleType.Horizontal, 
			2 => GradientStyleType.Vertical, 
			3 => GradientStyleType.DiagonalUp, 
			4 => GradientStyleType.DiagonalDown, 
			5 => GradientStyleType.FromCenter, 
			6 => GradientStyleType.FromCorner, 
			_ => GradientStyleType.Unknown, 
		};
	}

	[SpecialName]
	internal void method_52(GradientStyleType gradientStyleType_0)
	{
		m_gradient &= 240;
		byte b = 0;
		switch (gradientStyleType_0)
		{
		case GradientStyleType.DiagonalDown:
			b = 4;
			break;
		case GradientStyleType.DiagonalUp:
			b = 3;
			break;
		case GradientStyleType.FromCenter:
			b = 5;
			break;
		case GradientStyleType.FromCorner:
			b = 6;
			break;
		case GradientStyleType.Horizontal:
			b = 1;
			break;
		case GradientStyleType.Vertical:
			b = 2;
			break;
		}
		m_gradient |= b;
	}

	[SpecialName]
	internal int method_53()
	{
		return (m_gradient & 0x70) >> 4;
	}

	[SpecialName]
	internal void method_54(int int_0)
	{
		if (int_0 < 0 || int_0 > 4)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid style gradient Variant");
		}
		m_gradient &= 143;
		m_gradient |= (byte)(int_0 << 4);
	}

	/// <summary>
	///       Sets the specified fill to a two-color gradient.
	///       </summary>
	/// <param name="color1">One gradient color.</param>
	/// <param name="color2">Two gradient color.</param>
	/// <param name="gradientStyleType">Gradient shading style.</param>
	/// <param name="variant">The gradient variant. Can be a value from 1 through 4, corresponding to one of the four variants on the Gradient tab in the Fill Effects dialog box. If style is GradientStyle.FromCenter, the Variant argument can only be 1 or 2.</param>
	public void SetTwoColorGradient(Color color1, Color color2, GradientStyleType gradientStyleType, int variant)
	{
		ForeInternalColor.SetColor(ColorType.RGB, color1.ToArgb());
		BackgroundInternalColor.SetColor(ColorType.RGB, color2.ToArgb());
		method_52(gradientStyleType);
		method_54(variant);
		IsGradient = true;
		Pattern = BackgroundType.Solid;
	}

	internal void SetTwoColorGradient(InternalColor internalColor_0, InternalColor internalColor_1, GradientStyleType gradientStyleType_0, int int_0)
	{
		ForeInternalColor = internalColor_0;
		BackgroundInternalColor = internalColor_1;
		method_52(gradientStyleType_0);
		method_54(int_0);
		IsGradient = true;
		Pattern = BackgroundType.Solid;
	}

	/// <summary>
	///       Get the two-color gradient setting.
	///       </summary>
	/// <param name="color1">One gradient color.</param>
	/// <param name="color2">Two gradient color.</param>
	/// <param name="gradientStyleType">Gradient shading style.</param>
	/// <param name="variant">The gradient variant.</param>
	public void GetTwoColorGradient(out Color color1, out Color color2, out GradientStyleType gradientStyleType, out int variant)
	{
		if (IsGradient)
		{
			color1 = ForegroundColor;
			color2 = BackgroundColor;
			gradientStyleType = method_51();
			variant = method_53();
		}
		else
		{
			color1 = (color2 = Color.Empty);
			gradientStyleType = GradientStyleType.Unknown;
			variant = 0;
		}
	}

	internal void method_55(bool bool_0)
	{
		if (bool_0)
		{
			m_Zip |= 128;
		}
	}

	internal void method_56(int int_0, string string_0)
	{
		switch (int_0)
		{
		case 0:
			if (string_0 != null)
			{
				Borders[BorderType.BottomBorder].LineStyle = Class1618.smethod_36(string_0);
			}
			break;
		case 1:
			if (string_0 != null)
			{
				Borders[BorderType.DiagonalDown].LineStyle = Class1618.smethod_36(string_0);
			}
			break;
		case 2:
			if (string_0 != null)
			{
				Borders[BorderType.DiagonalUp].LineStyle = Class1618.smethod_36(string_0);
			}
			break;
		case 3:
			if (string_0 != null)
			{
				Borders[BorderType.LeftBorder].LineStyle = Class1618.smethod_36(string_0);
			}
			break;
		case 4:
			if (string_0 != null)
			{
				Borders[BorderType.RightBorder].LineStyle = Class1618.smethod_36(string_0);
			}
			break;
		case 5:
			if (string_0 != null)
			{
				Borders[BorderType.TopBorder].LineStyle = Class1618.smethod_36(string_0);
			}
			break;
		case 6:
			if (string_0 != null)
			{
				Borders.DiagonalStyle = Class1618.smethod_36(string_0);
			}
			break;
		case 7:
			if (string_0 != null)
			{
				Borders.method_1(new Border(Borders, BorderType.Horizontal));
				Borders.method_0().LineStyle = Class1618.smethod_36(string_0);
			}
			break;
		case 8:
			if (string_0 != null)
			{
				Borders.method_3(new Border(Borders, BorderType.Vertical));
				Borders.method_2().LineStyle = Class1618.smethod_36(string_0);
			}
			break;
		}
	}

	internal void method_57(int int_0, string string_0, ColorType colorType_0, int int_1, double double_0)
	{
		switch (int_0)
		{
		case 0:
			if (string_0 != null)
			{
				Borders[BorderType.BottomBorder].LineStyle = Class1618.smethod_36(string_0);
			}
			Borders[BorderType.BottomBorder].InternalColor.SetColor(colorType_0, int_1);
			Borders[BorderType.BottomBorder].InternalColor.Tint = double_0;
			method_36(StyleModifyFlag.BottomBorder);
			break;
		case 1:
			if (string_0 != null)
			{
				Borders[BorderType.DiagonalDown].LineStyle = Class1618.smethod_36(string_0);
			}
			Borders[BorderType.DiagonalDown].InternalColor.SetColor(colorType_0, int_1);
			Borders[BorderType.DiagonalDown].InternalColor.Tint = double_0;
			method_36(StyleModifyFlag.DiagonalDownBorder);
			break;
		case 2:
			if (string_0 != null)
			{
				Borders[BorderType.DiagonalUp].LineStyle = Class1618.smethod_36(string_0);
			}
			Borders[BorderType.DiagonalUp].InternalColor.SetColor(colorType_0, int_1);
			Borders[BorderType.DiagonalUp].InternalColor.Tint = double_0;
			method_36(StyleModifyFlag.DiagonalUpBorder);
			break;
		case 3:
			if (string_0 != null)
			{
				Borders[BorderType.LeftBorder].LineStyle = Class1618.smethod_36(string_0);
			}
			Borders[BorderType.LeftBorder].InternalColor.SetColor(colorType_0, int_1);
			Borders[BorderType.LeftBorder].InternalColor.Tint = double_0;
			method_36(StyleModifyFlag.LeftBorder);
			break;
		case 4:
			if (string_0 != null)
			{
				Borders[BorderType.RightBorder].LineStyle = Class1618.smethod_36(string_0);
			}
			Borders[BorderType.RightBorder].InternalColor.SetColor(colorType_0, int_1);
			Borders[BorderType.RightBorder].InternalColor.Tint = double_0;
			method_36(StyleModifyFlag.RightBorder);
			break;
		case 5:
			if (string_0 != null)
			{
				Borders[BorderType.TopBorder].LineStyle = Class1618.smethod_36(string_0);
			}
			Borders[BorderType.TopBorder].InternalColor.SetColor(colorType_0, int_1);
			Borders[BorderType.TopBorder].InternalColor.Tint = double_0;
			method_36(StyleModifyFlag.TopBorder);
			break;
		case 6:
		{
			if (string_0 != null)
			{
				Borders.DiagonalStyle = Class1618.smethod_36(string_0);
			}
			InternalColor internalColor = new InternalColor(bool_0: false);
			internalColor.SetColor(colorType_0, int_1);
			internalColor.Tint = double_0;
			Borders[BorderType.DiagonalDown].InternalColor = internalColor;
			Borders[BorderType.DiagonalUp].InternalColor = internalColor;
			method_36(StyleModifyFlag.Diagonal);
			break;
		}
		case 7:
			Borders.method_1(new Border(Borders, BorderType.Horizontal));
			if (string_0 != null)
			{
				Borders.method_0().LineStyle = Class1618.smethod_36(string_0);
			}
			Borders.method_0().InternalColor.SetColor(colorType_0, int_1);
			Borders.method_0().InternalColor.Tint = double_0;
			method_36(StyleModifyFlag.HorizontalBorder);
			break;
		case 8:
			Borders.method_3(new Border(Borders, BorderType.Vertical));
			if (string_0 != null)
			{
				Borders.method_2().LineStyle = Class1618.smethod_36(string_0);
			}
			Borders.method_2().InternalColor.SetColor(colorType_0, int_1);
			Borders.method_2().InternalColor.Tint = double_0;
			method_36(StyleModifyFlag.VerticalBorder);
			break;
		}
	}

	internal void SetColor(int int_0, ColorType colorType_0, int int_1, double double_0)
	{
		InternalColor internalColor = new InternalColor(bool_0: false);
		internalColor.SetColor(colorType_0, int_1);
		internalColor.Tint = double_0;
		switch (int_0)
		{
		case 0:
			Font.InternalColor = internalColor;
			method_36(StyleModifyFlag.FontColor);
			break;
		case 1:
			ForeInternalColor = internalColor;
			method_36(StyleModifyFlag.ForegroundColor);
			break;
		case 2:
			BackgroundInternalColor = internalColor;
			method_36(StyleModifyFlag.BackgroundColor);
			break;
		}
	}
}
