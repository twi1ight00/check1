using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;
using ns7;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates the font object used in a spreadsheet.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///
///       //Obtaining the reference of the newly added worksheet by passing its sheet index
///       Worksheet worksheet = workbook.Worksheets[0];
///
///       //Accessing the "A1" cell from the worksheet
///       Aspose.Cells.Cell cell = worksheet.Cells["A1"];
///
///       //Adding some value to the "A1" cell
///       cell.PutValue("Hello Aspose!");
///
///       Aspose.Cells.Font font = cell.Style.Font;
///
///       //Setting the font name to "Times New Roman"
///       font.Name = "Times New Roman";
///
///       //Setting font size to 14
///       font.Size = 14;
///
///       //setting font color as Red
///       font.Color = System.Drawing.Color.Red;           
///
///       //Saving the Excel file
///       workbook.Save(@"d:\dest.xls");
///
///       [VB.NET]
///
///       'Instantiating a Workbook object
///       Dim workbook As New Workbook()
///
///       'Obtaining the reference of the newly added worksheet by passing its sheet index
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///       'Accessing the "A1" cell from the worksheet
///       Dim cell As Aspose.Cells.Cell = worksheet.Cells("A1")
///
///       'Adding some value to the "A1" cell
///       cell.PutValue("Hello Aspose!")
///
///       Dim font As Aspose.Cells.Font = cell.Style.Font
///
///       'Setting the font name to "Times New Roman"
///       font.Name = "Times New Roman"
///
///       'Setting font size to 14
///       font.Size = 14
///
///       'setting font color as Red
///       font.Color = System.Drawing.Color.Red
///
///       'Saving the Excel file
///       workbook.Save("d:\dest.xls")
///       </code>
/// </example>
[Serializable]
public class Font
{
	private byte charset;

	internal InternalColor InternalColor;

	internal WorksheetCollection Sheets;

	private object m_CellFormat;

	private ushort fontHeight;

	private int m_BaseLine;

	private short weight = 400;

	private byte family;

	private string fontName;

	private int fontIndex = -1;

	private int m_Options;

	private short SetFlags;

	/// <summary>
	///       Gets or sets a value indicating whether the font is italic.
	///       </summary>
	public bool IsItalic
	{
		get
		{
			return (m_Options & 4) != 0;
		}
		set
		{
			if (value)
			{
				m_Options |= 4;
			}
			else
			{
				m_Options &= -5;
			}
			method_29(StyleModifyFlag.FontItalic);
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the font is bold.
	///       </summary>
	public bool IsBold
	{
		get
		{
			return weight >= 700;
		}
		set
		{
			if (value)
			{
				weight = 700;
			}
			else
			{
				weight = 400;
			}
			method_29(StyleModifyFlag.FontWeight);
		}
	}

	public TextCapsType CapsType
	{
		get
		{
			return ((m_Options & 0x60) >> 5) switch
			{
				0 => TextCapsType.None, 
				1 => TextCapsType.Small, 
				2 => TextCapsType.All, 
				_ => TextCapsType.None, 
			};
		}
		set
		{
			m_Options &= -97;
			switch (value)
			{
			case TextCapsType.All:
				m_Options |= 64;
				break;
			case TextCapsType.None:
				break;
			case TextCapsType.Small:
				m_Options |= 32;
				break;
			}
		}
	}

	public TextStrikeType StrikeType
	{
		get
		{
			return ((m_Options & 0x18) >> 3) switch
			{
				0 => TextStrikeType.None, 
				1 => TextStrikeType.Single, 
				2 => TextStrikeType.Double, 
				_ => TextStrikeType.None, 
			};
		}
		set
		{
			m_Options &= -25;
			switch (value)
			{
			case TextStrikeType.Single:
				m_Options |= 8;
				break;
			case TextStrikeType.Double:
				m_Options |= 16;
				break;
			}
			method_29(StyleModifyFlag.FontStrike);
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the font is strikeout.
	///       </summary>
	public bool IsStrikeout
	{
		get
		{
			return StrikeType == TextStrikeType.Single;
		}
		set
		{
			if (value)
			{
				StrikeType = TextStrikeType.Single;
			}
			else if (StrikeType == TextStrikeType.Single)
			{
				StrikeType = TextStrikeType.None;
			}
			else
			{
				method_29(StyleModifyFlag.FontStrike);
			}
		}
	}

	public double ScriptOffset
	{
		get
		{
			return (double)m_BaseLine / (double)Class1391.int_1 * 100.0;
		}
		set
		{
			m_BaseLine = (int)(value / 100.0 * (double)Class1391.int_1);
			method_29(StyleModifyFlag.FontScript);
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the font is super script.
	///       </summary>
	public bool IsSuperscript
	{
		get
		{
			return m_BaseLine > 0;
		}
		set
		{
			if (value)
			{
				if (m_BaseLine <= 0)
				{
					m_BaseLine = 30 * Class1391.int_1 / 100;
				}
			}
			else if (m_BaseLine > 0)
			{
				m_BaseLine = 0;
			}
			method_29(StyleModifyFlag.FontScript);
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the font is subscript.
	///       </summary>
	public bool IsSubscript
	{
		get
		{
			return m_BaseLine < 0;
		}
		set
		{
			if (value)
			{
				if (m_BaseLine >= 0)
				{
					m_BaseLine = -25 * Class1391.int_1 / 100;
				}
			}
			else if (m_BaseLine < 0)
			{
				m_BaseLine = 0;
			}
			method_29(StyleModifyFlag.FontScript);
		}
	}

	/// <summary>
	///       Gets or sets the font underline type.
	///       </summary>
	public FontUnderlineType Underline
	{
		get
		{
			return (FontUnderlineType)((m_Options & 0x1F000) >> 12);
		}
		set
		{
			byte b = (byte)value;
			m_Options &= -126977;
			m_Options |= b << 12;
			method_29(StyleModifyFlag.FontUnderline);
		}
	}

	/// <summary>
	///       Gets  or sets the name of the <see cref="T:Aspose.Cells.Font" />.
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       Style style;
	///       ..........
	///       Font font = style.Font;
	///       font.Name = "Times New Roman";
	///
	///       [Visual Basic]
	///
	///       Dim style As Style
	///       ..........
	///       Dim font As Font =  style.Font 
	///       font.Name = "Times New Roman"
	///       </code>
	/// </example>
	public string Name
	{
		get
		{
			return fontName;
		}
		set
		{
			fontName = value;
			method_29(StyleModifyFlag.FontName);
			switch (fontName)
			{
			case "隶书":
			case "宋体":
			case "黑体":
				charset = 134;
				break;
			default:
				charset = 0;
				break;
			}
			method_24(Enum193.const_0);
		}
	}

	/// <summary>
	///       Gets and sets the double size of the font.
	///       </summary>
	public double DoubleSize
	{
		get
		{
			return (double)(int)fontHeight / 20.0;
		}
		set
		{
			if (!(value >= 1.0) || value > 409.0)
			{
				throw new CellsException(ExceptionType.InvalidData, "Font size is out of range.");
			}
			fontHeight = (ushort)(value * 20.0);
			method_29(StyleModifyFlag.FontSize);
		}
	}

	/// <summary>
	///       Gets or sets the size of the font.
	///       </summary>
	public int Size
	{
		get
		{
			return (short)((int)fontHeight / 20);
		}
		set
		{
			if (value < 1 || value > 409)
			{
				throw new CellsException(ExceptionType.InvalidData, "Font size is out of range.");
			}
			fontHeight = (ushort)(value * 20);
			method_29(StyleModifyFlag.FontSize);
		}
	}

	/// <summary>
	///       Gets and sets the theme color.
	///       </summary>
	/// <remarks>
	///       If the font color is not a theme color, NULL will be returned.
	///       </remarks>
	public ThemeColor ThemeColor
	{
		get
		{
			if (InternalColor.ColorType == ColorType.Theme)
			{
				ThemeColorType type = Class1673.smethod_1(InternalColor.method_4());
				return new ThemeColor(type, InternalColor.Tint);
			}
			return null;
		}
		set
		{
			InternalColor.SetColor(ColorType.Theme, Class1673.smethod_2(value.ColorType));
			InternalColor.Tint = value.Tint;
			method_29(StyleModifyFlag.FontColor);
		}
	}

	/// <summary>
	///       Gets or sets the <see cref="T:System.Drawing.Color" /> of the font.
	///       </summary>
	public Color Color
	{
		get
		{
			if (InternalColor.method_2())
			{
				return Color.Black;
			}
			return InternalColor.method_6(Sheets.Workbook);
		}
		set
		{
			if (value.IsEmpty)
			{
				InternalColor.method_3(bool_0: true);
			}
			else
			{
				InternalColor.SetColor(ColorType.RGB, value.ToArgb());
			}
			InternalColor.method_8();
			method_29(StyleModifyFlag.FontColor);
		}
	}

	public bool IsNormalizeHeights
	{
		get
		{
			return (m_Options & 0x20000) != 0;
		}
		set
		{
			if (value)
			{
				m_Options |= 131072;
			}
			else
			{
				m_Options &= -131073;
			}
		}
	}

	internal int ColorIndex
	{
		get
		{
			if (InternalColor.method_2())
			{
				return 32767;
			}
			bool found = false;
			return InternalColor.method_0(Sheets, 32767, out found);
		}
	}

	internal int Weight
	{
		get
		{
			return weight;
		}
		set
		{
			if (value >= 0 && value <= 900)
			{
				if (value == 0)
				{
					weight = 400;
				}
				else
				{
					weight = (short)(value / 100 * 100);
				}
				method_29(StyleModifyFlag.FontWeight);
			}
		}
	}

	[SpecialName]
	internal string method_0()
	{
		return method_23() switch
		{
			Enum193.const_1 => "major", 
			Enum193.const_2 => "minor", 
			_ => null, 
		};
	}

	[SpecialName]
	internal void method_1(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			switch (string_0.ToLower())
			{
			case "none":
				method_24(Enum193.const_0);
				break;
			case "minor":
				method_24(Enum193.const_2);
				break;
			case "major":
				method_24(Enum193.const_1);
				break;
			}
		}
		else
		{
			method_24(Enum193.const_0);
		}
	}

	[SpecialName]
	internal byte method_2()
	{
		return charset;
	}

	[SpecialName]
	internal void method_3(byte byte_0)
	{
		charset = byte_0;
		method_29(StyleModifyFlag.FontCharset);
	}

	internal Font(WorksheetCollection worksheetCollection_0, object object_0)
	{
		fontName = "Arial";
		fontHeight = 200;
		Sheets = worksheetCollection_0;
		m_CellFormat = object_0;
		InternalColor = new InternalColor(bool_0: false);
		InternalColor.method_3(bool_0: true);
		family = 2;
	}

	internal Font(WorksheetCollection worksheetCollection_0, object object_0, bool bool_0)
	{
		if (worksheetCollection_0 != null)
		{
			if (worksheetCollection_0.method_52().Count == 0)
			{
				fontName = worksheetCollection_0.Workbook.Settings.StandardFont;
				fontHeight = worksheetCollection_0.Workbook.Settings.method_11();
			}
			else
			{
				Font font = (Font)worksheetCollection_0.method_52()[0];
				fontName = font.Name;
				fontHeight = font.fontHeight;
			}
			Sheets = worksheetCollection_0;
		}
		else
		{
			fontName = "Arial";
			fontHeight = 200;
		}
		m_CellFormat = object_0;
		InternalColor = new InternalColor(bool_0);
		InternalColor.method_3(bool_0: true);
		family = 2;
	}

	[SpecialName]
	internal object method_4()
	{
		return m_CellFormat;
	}

	[SpecialName]
	internal void method_5(object object_0)
	{
		m_CellFormat = object_0;
	}

	[SpecialName]
	internal bool method_6()
	{
		if (m_CellFormat != null)
		{
			return m_CellFormat is Class1383;
		}
		return false;
	}

	internal void method_7(bool bool_0)
	{
		if (bool_0)
		{
			weight = 700;
		}
		else
		{
			weight = 400;
		}
	}

	[SpecialName]
	internal byte method_8()
	{
		if (m_BaseLine < 0)
		{
			return 2;
		}
		if (m_BaseLine > 0)
		{
			return 1;
		}
		return 0;
	}

	[SpecialName]
	internal int method_9()
	{
		return m_BaseLine;
	}

	[SpecialName]
	internal void method_10(int int_0)
	{
		m_BaseLine = int_0;
		method_29(StyleModifyFlag.FontScript);
	}

	[SpecialName]
	internal byte method_11()
	{
		return family;
	}

	[SpecialName]
	internal void method_12(byte byte_0)
	{
		family = byte_0;
		method_29(StyleModifyFlag.FontFamily);
	}

	internal void method_13(string string_0)
	{
		fontName = string_0;
		method_29(StyleModifyFlag.FontName);
		switch (fontName)
		{
		case "隶书":
		case "宋体":
		case "黑体":
			charset = 134;
			break;
		default:
			charset = 0;
			break;
		}
	}

	internal void method_14(string string_0, Enum193 enum193_0)
	{
		fontName = string_0;
		method_29(StyleModifyFlag.FontName);
		switch (fontName)
		{
		case "隶书":
		case "宋体":
		case "黑体":
			charset = 134;
			break;
		default:
			charset = 0;
			break;
		}
		method_24(enum193_0);
	}

	internal void method_15(double double_0)
	{
		fontHeight = (ushort)(double_0 * 20.0);
	}

	[SpecialName]
	internal int method_16()
	{
		return fontHeight;
	}

	[SpecialName]
	internal void method_17(int int_0)
	{
		fontHeight = (ushort)int_0;
		method_29(StyleModifyFlag.FontSize);
	}

	/// <summary>
	///       Checks if two fonts are equals.
	///       </summary>
	/// <param name="font">Compared font object.</param>
	/// <returns>True if equal to the compared font object.</returns>
	public bool Equals(Font font)
	{
		if (InternalColor.method_9(font.InternalColor) && fontHeight == font.fontHeight && fontName == font.fontName && m_Options == font.m_Options && weight == font.weight)
		{
			return true;
		}
		return false;
	}

	internal bool method_18(Font font_0)
	{
		if (InternalColor.method_9(font_0.InternalColor) && fontHeight == font_0.fontHeight && fontName == font_0.fontName && m_Options == font_0.m_Options && weight == font_0.weight && m_BaseLine == font_0.m_BaseLine)
		{
			return true;
		}
		return false;
	}

	internal bool method_19(Font font_0)
	{
		if (InternalColor.method_9(font_0.InternalColor) && fontHeight == font_0.fontHeight && fontName == font_0.fontName && m_Options == font_0.m_Options && SetFlags == font_0.SetFlags && weight == font_0.weight && m_BaseLine == font_0.m_BaseLine)
		{
			return true;
		}
		return false;
	}

	internal bool method_20(Font font_0, Workbook workbook_0, Workbook workbook_1)
	{
		if (InternalColor.method_10(font_0.InternalColor, workbook_0, workbook_1) && fontHeight == font_0.fontHeight && fontName == font_0.fontName && m_Options == font_0.m_Options && weight == font_0.weight && m_BaseLine == font_0.m_BaseLine)
		{
			return true;
		}
		return false;
	}

	internal void Copy(Font font_0)
	{
		charset = font_0.charset;
		if (Sheets != font_0.Sheets && font_0.InternalColor.ColorType == ColorType.IndexedColor)
		{
			InternalColor.SetColor(ColorType.RGB, font_0.InternalColor.method_7(font_0.Sheets.Workbook));
		}
		else
		{
			InternalColor.method_19(font_0.InternalColor);
		}
		family = font_0.family;
		fontHeight = font_0.fontHeight;
		fontName = font_0.fontName;
		SetFlags = font_0.SetFlags;
		m_Options = font_0.m_Options;
		weight = font_0.weight;
		fontIndex = font_0.fontIndex;
		m_BaseLine = font_0.m_BaseLine;
	}

	[SpecialName]
	internal int method_21()
	{
		return fontIndex;
	}

	[SpecialName]
	internal void method_22(int int_0)
	{
		fontIndex = int_0;
	}

	[SpecialName]
	internal Enum193 method_23()
	{
		return ((m_Options >> 7) & 3) switch
		{
			0 => Enum193.const_0, 
			1 => Enum193.const_1, 
			2 => Enum193.const_2, 
			_ => Enum193.const_0, 
		};
	}

	[SpecialName]
	internal void method_24(Enum193 enum193_0)
	{
		short num = 0;
		switch (enum193_0)
		{
		case Enum193.const_1:
			num = 1;
			break;
		case Enum193.const_2:
			num = 2;
			break;
		}
		m_Options &= -385;
		if (num != 0)
		{
			m_Options |= num << 7;
			method_29(StyleModifyFlag.FontScheme);
		}
	}

	internal void method_25()
	{
		SetFlags = 0;
	}

	internal void method_26(Font font_0)
	{
		if (font_0.IsModified(StyleModifyFlag.FontName))
		{
			method_13(font_0.fontName);
		}
		if (font_0.IsModified(StyleModifyFlag.FontSize))
		{
			Size = font_0.Size;
		}
		if (font_0.IsModified(StyleModifyFlag.FontColor))
		{
			InternalColor.method_19(font_0.InternalColor);
			method_29(StyleModifyFlag.FontColor);
		}
		if (font_0.IsModified(StyleModifyFlag.FontItalic))
		{
			IsItalic = font_0.IsItalic;
		}
		if (font_0.IsModified(StyleModifyFlag.FontStrike))
		{
			IsStrikeout = font_0.IsStrikeout;
		}
		if (IsModified(StyleModifyFlag.FontScript))
		{
			method_10(font_0.method_9());
		}
		if (font_0.IsModified(StyleModifyFlag.FontUnderline))
		{
			Underline = font_0.Underline;
		}
		if (font_0.IsModified(StyleModifyFlag.FontWeight))
		{
			Weight = font_0.Weight;
		}
	}

	internal void method_27(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.Append(charset.ToString());
		stringBuilder_0.Append(Color.ToString());
		stringBuilder_0.Append(family.ToString());
		stringBuilder_0.Append(fontHeight.ToString());
		stringBuilder_0.Append(m_Options.ToString());
		stringBuilder_0.Append(fontName);
		stringBuilder_0.Append(weight.ToString());
	}

	internal void method_28(byte[] byte_0)
	{
		fontHeight = BitConverter.ToUInt16(byte_0, 0);
		method_29(StyleModifyFlag.FontSize);
		int num = byte_0[2] & 1;
		if (num == 1)
		{
			weight = 700;
		}
		else
		{
			weight = 400;
		}
		num = byte_0[2] & 2;
		IsItalic = num != 0;
		num = byte_0[2] & 8;
		IsStrikeout = num != 0;
		int num2 = BitConverter.ToUInt16(byte_0, 4);
		if (num2 < 64 && num2 >= 0)
		{
			InternalColor.SetColor(ColorType.IndexedColor, num2);
		}
		else
		{
			InternalColor.method_3(bool_0: true);
		}
		Weight = BitConverter.ToUInt16(byte_0, 6);
		switch (byte_0[8])
		{
		case 1:
			IsSuperscript = true;
			break;
		case 2:
			IsSubscript = true;
			break;
		}
		switch (byte_0[10])
		{
		default:
			Underline = FontUnderlineType.None;
			break;
		case 33:
			Underline = FontUnderlineType.Accounting;
			break;
		case 34:
			Underline = FontUnderlineType.DoubleAccounting;
			break;
		case 1:
			Underline = FontUnderlineType.Single;
			break;
		case 2:
			Underline = FontUnderlineType.Double;
			break;
		}
		family = byte_0[11];
		charset = byte_0[12];
		switch (byte_0[15])
		{
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid font.");
		case 0:
			fontName = Encoding.ASCII.GetString(byte_0, 16, byte_0[14]);
			break;
		case 1:
			fontName = Encoding.Unicode.GetString(byte_0, 16, byte_0[14] * 2);
			break;
		}
		switch (fontName)
		{
		case "Brush Script MT":
		case "Monotype Corsiva":
			IsItalic = true;
			break;
		case "Berlin Sans FB Demi":
		case "Aharoni":
			weight = 700;
			break;
		}
	}

	internal bool IsModified(StyleModifyFlag styleModifyFlag_0)
	{
		switch (styleModifyFlag_0)
		{
		case StyleModifyFlag.Font:
			return SetFlags != 0;
		case StyleModifyFlag.FontSize:
			return (SetFlags & 0x100) != 0;
		case StyleModifyFlag.FontName:
			return (SetFlags & 0x80) != 0;
		case StyleModifyFlag.FontFamily:
			return (SetFlags & 2) != 0;
		case StyleModifyFlag.FontCharset:
			return (SetFlags & 4) != 0;
		case StyleModifyFlag.FontColor:
			return (SetFlags & 0x200) != 0;
		case StyleModifyFlag.FontWeight:
			return (SetFlags & 0x400) != 0;
		case StyleModifyFlag.FontItalic:
			return (SetFlags & 0x800) != 0;
		case StyleModifyFlag.FontUnderline:
			return (SetFlags & 0x2000) != 0;
		case StyleModifyFlag.FontStrike:
			return (SetFlags & 0x1000) != 0;
		case StyleModifyFlag.FontSubscript:
			if (((uint)SetFlags & (true ? 1u : 0u)) != 0)
			{
				return IsSubscript;
			}
			return false;
		case StyleModifyFlag.FontSuperscript:
			if (((uint)SetFlags & (true ? 1u : 0u)) != 0)
			{
				return IsSuperscript;
			}
			return false;
		case StyleModifyFlag.FontScript:
			return (SetFlags & 1) != 0;
		default:
			return false;
		case StyleModifyFlag.FontScheme:
			return (SetFlags & 8) != 0;
		case StyleModifyFlag.FontShadow:
			return (SetFlags & 0x10) != 0;
		case StyleModifyFlag.FontCondense:
			return (SetFlags & 0x20) != 0;
		case StyleModifyFlag.FontExtend:
			return (SetFlags & 0x40) != 0;
		}
	}

	internal void method_29(StyleModifyFlag styleModifyFlag_0)
	{
		switch (styleModifyFlag_0)
		{
		case StyleModifyFlag.FontScheme:
			SetFlags |= 8;
			break;
		case StyleModifyFlag.FontShadow:
			SetFlags |= 16;
			break;
		case StyleModifyFlag.FontCondense:
			SetFlags |= 32;
			break;
		case StyleModifyFlag.FontExtend:
			SetFlags |= 64;
			break;
		case StyleModifyFlag.FontSize:
			SetFlags |= 256;
			break;
		case StyleModifyFlag.FontName:
			SetFlags |= 128;
			break;
		case StyleModifyFlag.FontFamily:
			SetFlags |= 2;
			break;
		case StyleModifyFlag.FontCharset:
			SetFlags |= 4;
			break;
		case StyleModifyFlag.FontColor:
			SetFlags |= 512;
			break;
		case StyleModifyFlag.FontWeight:
			SetFlags |= 1024;
			break;
		case StyleModifyFlag.FontItalic:
			SetFlags |= 2048;
			break;
		case StyleModifyFlag.FontUnderline:
			SetFlags |= 8192;
			break;
		case StyleModifyFlag.FontStrike:
			SetFlags |= 4096;
			break;
		case StyleModifyFlag.FontScript:
			SetFlags |= 1;
			break;
		}
		if (m_CellFormat == null)
		{
			return;
		}
		if (m_CellFormat is Style)
		{
			Style style = (Style)m_CellFormat;
			if (!style.method_19())
			{
				style.method_20(bool_0: true);
			}
		}
		else if (m_CellFormat is Class1383)
		{
			Class1383 @class = (Class1383)m_CellFormat;
			switch (styleModifyFlag_0)
			{
			case StyleModifyFlag.FontSize:
			case StyleModifyFlag.FontFamily:
			case StyleModifyFlag.FontWeight:
			case StyleModifyFlag.FontItalic:
				@class.Resize(Size);
				break;
			case StyleModifyFlag.FontName:
			case StyleModifyFlag.FontCharset:
			case StyleModifyFlag.FontColor:
				break;
			}
		}
	}

	internal FontStyle method_30()
	{
		return (IsBold ? FontStyle.Bold : FontStyle.Regular) | (IsItalic ? FontStyle.Italic : FontStyle.Regular) | (IsStrikeout ? FontStyle.Strikeout : FontStyle.Regular) | ((Underline != 0) ? FontStyle.Underline : FontStyle.Regular);
	}

	/// <summary>
	///       Returns a string represents the current Cell object.
	///       </summary>
	/// <returns>
	/// </returns>
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Aspose.Cells.Font [ ");
		stringBuilder.Append(fontName);
		stringBuilder.Append("; " + DoubleSize);
		if (!IsBold && !IsItalic)
		{
			stringBuilder.Append("; Regular");
		}
		else
		{
			if (IsBold)
			{
				stringBuilder.Append("; Bold");
			}
			if (IsItalic)
			{
				stringBuilder.Append("; Italic");
			}
		}
		if (Underline != 0)
		{
			switch (Underline)
			{
			case FontUnderlineType.Single:
				stringBuilder.Append("; Underline");
				break;
			case FontUnderlineType.Double:
				stringBuilder.Append("; Double Underline");
				break;
			case FontUnderlineType.Accounting:
				stringBuilder.Append("; Accounting Underline");
				break;
			case FontUnderlineType.DoubleAccounting:
				stringBuilder.Append("; Double Accounting Underline");
				break;
			}
		}
		stringBuilder.Append("; " + Color);
		stringBuilder.Append(" ]");
		return stringBuilder.ToString();
	}
}
