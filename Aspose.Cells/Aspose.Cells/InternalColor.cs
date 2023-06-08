using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns2;
using ns44;

namespace Aspose.Cells;

internal class InternalColor
{
	private uint uint_0;

	private byte byte_0;

	private Class1332 class1332_0;

	internal ColorType ColorType => (byte_0 & 0xF) switch
	{
		0 => ColorType.Automatic, 
		1 => ColorType.RGB, 
		2 => ColorType.Theme, 
		3 => ColorType.IndexedColor, 
		4 => ColorType.AutomaticIndex, 
		_ => ColorType.Automatic, 
	};

	internal bool IsShapeColor
	{
		get
		{
			return (byte_0 & 0x10) != 0;
		}
		set
		{
			byte_0 &= 239;
			if (value)
			{
				byte_0 |= 16;
			}
		}
	}

	internal double Tint
	{
		get
		{
			if (class1332_0 == null)
			{
				return 0.0;
			}
			if (IsShapeColor)
			{
				return method_15();
			}
			return (float)method_18().method_2(Enum196.const_0) / 100000f;
		}
		set
		{
			if (IsShapeColor)
			{
				method_16(value);
			}
			else
			{
				method_18().method_1(Enum196.const_0, (int)(value * 100000.0 + 0.5));
			}
		}
	}

	internal InternalColor(bool bool_0)
	{
		IsShapeColor = bool_0;
	}

	internal int method_0(WorksheetCollection sheets, int defaultIndex, out bool found)
	{
		found = true;
		switch (ColorType)
		{
		case ColorType.Automatic:
			return defaultIndex;
		case ColorType.AutomaticIndex:
			return method_4();
		default:
		{
			int num = method_5(sheets.Workbook);
			Palette palette = sheets.method_24();
			int num2 = 0;
			int num3 = 8;
			while (true)
			{
				if (num3 <= 63)
				{
					num2 = (int)palette.method_0()[num3];
					if (num == num2)
					{
						break;
					}
					num3++;
					continue;
				}
				int num4 = 0;
				while (true)
				{
					if (num4 < 8)
					{
						num2 = (int)palette.method_0()[num4];
						if (num == num2)
						{
							break;
						}
						num4++;
						continue;
					}
					found = false;
					return defaultIndex;
				}
				return num4;
			}
			return num3;
		}
		case ColorType.IndexedColor:
			return method_4();
		}
	}

	internal int method_1(WorksheetCollection sheets, int defaultIndex, out bool found)
	{
		found = true;
		switch (ColorType)
		{
		case ColorType.Automatic:
			return defaultIndex;
		case ColorType.AutomaticIndex:
			return method_4();
		default:
		{
			int num = method_5(sheets.Workbook);
			int num2 = 0;
			Palette palette = sheets.method_24();
			int num3 = 8;
			while (true)
			{
				if (num3 <= 63)
				{
					num2 = (int)palette.method_0()[num3];
					if (num == num2)
					{
						break;
					}
					num3++;
					continue;
				}
				int num4 = 0;
				while (true)
				{
					if (num4 < 8)
					{
						num2 = (int)palette.method_0()[num4];
						if (num == num2)
						{
							break;
						}
						num4++;
						continue;
					}
					found = false;
					return palette.method_5(num);
				}
				return num4;
			}
			return num3;
		}
		case ColorType.IndexedColor:
			return method_4();
		}
	}

	[SpecialName]
	internal bool method_2()
	{
		if (ColorType != 0)
		{
			return ColorType == ColorType.AutomaticIndex;
		}
		return true;
	}

	[SpecialName]
	internal void method_3(bool bool_0)
	{
		byte_0 &= 240;
		if (!bool_0)
		{
			byte_0 |= 1;
		}
	}

	[SpecialName]
	internal int method_4()
	{
		return (int)(uint_0 & 0xFFFFFF);
	}

	internal int method_5(Workbook workbook_0)
	{
		int num = (int)(uint_0 & 0xFFFFFF);
		int num2 = byte_0 & 0xF;
		if (num2 != 0 && num2 != 4)
		{
			num = method_7(workbook_0);
			int num3 = num & 0xFF;
			int num4 = (num & 0xFF00) >> 8;
			int num5 = (num & 0xFF0000) >> 16;
			return (num3 << 16) + (num4 << 8) + num5;
		}
		return -1;
	}

	internal Color method_6(Workbook workbook_0)
	{
		switch (ColorType)
		{
		default:
		{
			Color color = Color.Empty;
			int num = (int)(uint_0 & 0xFFFFFF);
			switch (byte_0 & 0xF)
			{
			case 1:
				color = Color.FromArgb(num);
				goto default;
			case 2:
				color = workbook_0.class1569_0.GetThemeColor(num);
				goto default;
			case 3:
				color = workbook_0.Worksheets.method_24().GetColor(num);
				goto default;
			default:
				if (class1332_0 != null && class1332_0.Count != 0)
				{
					return class1332_0.method_3(color, IsShapeColor);
				}
				return color;
			case 0:
			case 4:
				return Color.Empty;
			}
		}
		case ColorType.Automatic:
		case ColorType.AutomaticIndex:
			return Color.Empty;
		}
	}

	internal int method_7(Workbook workbook_0)
	{
		return method_6(workbook_0).ToArgb() & 0xFFFFFF;
	}

	internal void method_8()
	{
		class1332_0 = null;
	}

	internal void SetColor(ColorType colorType_0, int int_0)
	{
		byte_0 &= 240;
		uint_0 &= 4278190080u;
		switch (colorType_0)
		{
		case ColorType.Automatic:
			uint_0 |= (uint)int_0;
			break;
		case ColorType.AutomaticIndex:
			uint_0 |= (uint)int_0;
			byte_0 |= 4;
			break;
		case ColorType.RGB:
			uint_0 |= (uint)int_0;
			byte_0 |= 1;
			break;
		case ColorType.IndexedColor:
			uint_0 |= (uint)int_0;
			byte_0 |= 3;
			break;
		case ColorType.Theme:
			uint_0 |= (uint)int_0;
			byte_0 |= 2;
			break;
		}
	}

	internal bool method_9(InternalColor internalColor_0)
	{
		if (method_2())
		{
			return internalColor_0.method_2();
		}
		if (internalColor_0.method_2())
		{
			return false;
		}
		if (ColorType != internalColor_0.ColorType)
		{
			return false;
		}
		if ((uint_0 & 0xFFFFFF) == (internalColor_0.uint_0 & 0xFFFFFF))
		{
			return method_11(internalColor_0);
		}
		return false;
	}

	internal bool method_10(InternalColor internalColor_0, Workbook workbook_0, Workbook workbook_1)
	{
		ColorType colorType = ColorType;
		ColorType colorType2 = internalColor_0.ColorType;
		switch (colorType)
		{
		default:
			return true;
		case ColorType.Automatic:
		case ColorType.AutomaticIndex:
			switch (colorType2)
			{
			default:
				return false;
			case ColorType.Automatic:
			case ColorType.AutomaticIndex:
				return true;
			}
		case ColorType.RGB:
			switch (colorType2)
			{
			default:
				return false;
			case ColorType.Automatic:
			case ColorType.AutomaticIndex:
				return false;
			case ColorType.RGB:
				if ((uint_0 & 0xFFFFFF) == (internalColor_0.uint_0 & 0xFFFFFF))
				{
					return method_11(internalColor_0);
				}
				return false;
			case ColorType.IndexedColor:
				return method_7(workbook_0) == internalColor_0.method_7(workbook_1);
			}
		case ColorType.IndexedColor:
			switch (colorType2)
			{
			default:
				return false;
			case ColorType.Automatic:
			case ColorType.AutomaticIndex:
				return false;
			case ColorType.RGB:
				return method_7(workbook_0) == internalColor_0.method_7(workbook_1);
			case ColorType.IndexedColor:
				if (workbook_0 == workbook_1)
				{
					return (uint_0 & 0xFFFFFF) == (internalColor_0.uint_0 & 0xFFFFFF);
				}
				return method_7(workbook_0) == internalColor_0.method_7(workbook_1);
			}
		case ColorType.Theme:
			switch (colorType2)
			{
			case ColorType.Automatic:
			case ColorType.AutomaticIndex:
				return false;
			default:
				return false;
			case ColorType.Theme:
				if ((uint_0 & 0xFFFFFF) == (internalColor_0.uint_0 & 0xFFFFFF))
				{
					return method_11(internalColor_0);
				}
				return false;
			}
		}
	}

	internal bool method_11(InternalColor internalColor_0)
	{
		if (class1332_0 != null && class1332_0.Count != 0)
		{
			if (internalColor_0.class1332_0 != null && internalColor_0.class1332_0.Count != 0)
			{
				return class1332_0.method_4(internalColor_0.class1332_0);
			}
			return false;
		}
		if (internalColor_0.class1332_0 != null)
		{
			return internalColor_0.class1332_0.Count == 0;
		}
		return true;
	}

	internal bool method_12(Color color_0, Color color_1, Workbook workbook_0)
	{
		if (method_2())
		{
			if (!color_0.IsEmpty)
			{
				return color_0 == color_1;
			}
			return true;
		}
		Color color = method_6(workbook_0);
		if (color_0.IsEmpty)
		{
			return (color.ToArgb() & 0xFFFFFF) == (color_1.ToArgb() & 0xFFFFFF);
		}
		return (color.ToArgb() & 0xFFFFFF) == (color_0.ToArgb() & 0xFFFFFF);
	}

	internal bool method_13(InternalColor internalColor_0)
	{
		if (method_2())
		{
			return !internalColor_0.method_2();
		}
		if (internalColor_0.method_2())
		{
			return true;
		}
		if (ColorType != internalColor_0.ColorType)
		{
			return true;
		}
		if ((uint_0 & 0xFFFFFF) == (internalColor_0.uint_0 & 0xFFFFFF))
		{
			return !method_11(internalColor_0);
		}
		return true;
	}

	internal bool method_14(InternalColor internalColor_0, Workbook workbook_0, Workbook workbook_1)
	{
		ColorType colorType = ColorType;
		ColorType colorType2 = internalColor_0.ColorType;
		switch (colorType)
		{
		default:
			return false;
		case ColorType.Automatic:
		case ColorType.AutomaticIndex:
			switch (colorType2)
			{
			default:
				return true;
			case ColorType.Automatic:
			case ColorType.AutomaticIndex:
				return false;
			}
		case ColorType.RGB:
			switch (colorType2)
			{
			default:
				return true;
			case ColorType.Automatic:
			case ColorType.AutomaticIndex:
				return true;
			case ColorType.RGB:
				if ((uint_0 & 0xFFFFFF) == (internalColor_0.uint_0 & 0xFFFFFF))
				{
					return !method_11(internalColor_0);
				}
				return true;
			case ColorType.IndexedColor:
				return method_7(workbook_0) != internalColor_0.method_7(workbook_1);
			}
		case ColorType.IndexedColor:
			switch (colorType2)
			{
			default:
				return true;
			case ColorType.Automatic:
			case ColorType.AutomaticIndex:
				return true;
			case ColorType.RGB:
				return method_7(workbook_0) != internalColor_0.method_7(workbook_1);
			case ColorType.IndexedColor:
				if (workbook_0 == workbook_1)
				{
					return (uint_0 & 0xFFFFFF) != (internalColor_0.uint_0 & 0xFFFFFF);
				}
				return method_7(workbook_0) != internalColor_0.method_7(workbook_1);
			}
		case ColorType.Theme:
			switch (colorType2)
			{
			case ColorType.Automatic:
			case ColorType.AutomaticIndex:
				return true;
			default:
				return true;
			case ColorType.Theme:
				if ((uint_0 & 0xFFFFFF) == (internalColor_0.uint_0 & 0xFFFFFF))
				{
					return !method_11(internalColor_0);
				}
				return true;
			}
		}
	}

	internal double method_15()
	{
		Class1332 @class = method_18();
		if (@class.Count == 1)
		{
			Class1331 class2 = @class[0];
			if (class2.enum196_0 == Enum196.const_21)
			{
				return (double)(class2.int_0 - Class1391.int_1) * 1.0 / (double)Class1391.int_1;
			}
		}
		else if (@class.Count == 2)
		{
			Class1331 class3 = null;
			Class1331 class4 = null;
			for (int i = 0; i < @class.Count; i++)
			{
				Class1331 class5 = @class[i];
				if (class5.enum196_0 == Enum196.const_21)
				{
					class3 = class5;
				}
				else if (class5.enum196_0 == Enum196.const_22)
				{
					class4 = class5;
				}
			}
			if (class3 != null && class4 != null && class3.int_0 + class4.int_0 == Class1391.int_1)
			{
				return (double)(Class1391.int_1 - class3.int_0) * 1.0 / (double)Class1391.int_1;
			}
		}
		return 0.0;
	}

	internal void method_16(double double_0)
	{
		IsShapeColor = true;
		Class1332 @class = method_18();
		for (int i = 0; i < @class.Count; i++)
		{
			Class1331 class2 = @class[i];
			if (class2.enum196_0 == Enum196.const_23 || class2.enum196_0 == Enum196.const_24 || class2.enum196_0 == Enum196.const_21 || class2.enum196_0 == Enum196.const_22 || class2.enum196_0 == Enum196.const_1 || class2.enum196_0 == Enum196.const_0)
			{
				@class.RemoveAt(i--);
			}
		}
		if (double_0 != 0.0)
		{
			if (double_0 > 0.0)
			{
				@class.method_0(Enum196.const_21, 100000 - (int)(double_0 * 100000.0));
				@class.method_0(Enum196.const_22, (int)(double_0 * 100000.0));
			}
			else
			{
				@class.method_0(Enum196.const_21, 100000 - (int)(Math.Abs(double_0) * 100000.0));
			}
		}
	}

	internal Class1332 method_17()
	{
		return class1332_0;
	}

	[SpecialName]
	internal Class1332 method_18()
	{
		if (class1332_0 == null)
		{
			class1332_0 = new Class1332();
		}
		return class1332_0;
	}

	internal void method_19(InternalColor internalColor_0)
	{
		uint_0 = internalColor_0.uint_0;
		byte_0 = internalColor_0.byte_0;
		if (internalColor_0.class1332_0 != null)
		{
			class1332_0 = new Class1332();
			class1332_0.Copy(internalColor_0.class1332_0);
		}
		else
		{
			class1332_0 = null;
		}
	}
}
