using System;
using System.Drawing;
using ns218;

namespace ns271;

internal class Class6730
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private Class6636 class6636_0;

	private string[] string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private Class6735 class6735_0;

	private FontStyle fontStyle_0;

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

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private float float_0;

	private Class6654 class6654_0;

	private byte[] byte_0;

	private short short_0;

	public string FamilyName => string_1;

	public string SubFamilyName => string_2;

	public string FullFontName => string_3;

	public string PostscriptName => string_4;

	public string FileName
	{
		get
		{
			if (Data == null)
			{
				return null;
			}
			if (!(Data is Class6655))
			{
				return method_7();
			}
			return ((Class6655)Data).FileName;
		}
	}

	public Class6735 Glyphs
	{
		get
		{
			return class6735_0;
		}
		set
		{
			class6735_0 = value;
		}
	}

	public FontStyle Style
	{
		get
		{
			return fontStyle_0;
		}
		set
		{
			fontStyle_0 = value;
		}
	}

	public int EmHeight
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int Ascent
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

	public int Descent
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int Height => int_1 + int_2;

	public int LineSpacing
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public int StrikeoutSize
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	public int SuperscriptSize
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
		}
	}

	public int SuperscriptOffset
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
		}
	}

	public int SubscriptSize
	{
		get
		{
			return int_8;
		}
		set
		{
			int_8 = value;
		}
	}

	public int SubscriptOffset
	{
		get
		{
			return int_9;
		}
		set
		{
			int_9 = value;
		}
	}

	public int StrikeoutPosition
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
		}
	}

	public int XMin
	{
		get
		{
			return int_10;
		}
		set
		{
			int_10 = value;
		}
	}

	public int YMin
	{
		get
		{
			return int_11;
		}
		set
		{
			int_11 = value;
		}
	}

	public int XMax
	{
		get
		{
			return int_12;
		}
		set
		{
			int_12 = value;
		}
	}

	public int YMax
	{
		get
		{
			return int_13;
		}
		set
		{
			int_13 = value;
		}
	}

	public int CapHeight
	{
		get
		{
			return int_14;
		}
		set
		{
			int_14 = value;
		}
	}

	public int XHeight
	{
		get
		{
			return int_15;
		}
		set
		{
			int_15 = value;
		}
	}

	public float ItalicAngle
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	internal Class6636 Cmap
	{
		get
		{
			return class6636_0;
		}
		set
		{
			class6636_0 = value;
		}
	}

	internal bool IsPrintPreview
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

	internal bool IsCff
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

	internal bool IsCffTopDict
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

	public Class6654 Data
	{
		get
		{
			return class6654_0;
		}
		set
		{
			class6654_0 = value;
		}
	}

	public bool IsSymbolic => class6636_0.IsSymbolicFont;

	public byte[] Panose
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public short FamilyClass
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	public float method_0(string text, float fontSize)
	{
		return method_1(text, 0, text.Length, fontSize);
	}

	public float method_1(string text, int startIndex, int charCount, float fontSize)
	{
		int num = startIndex + charCount;
		if (num > text.Length)
		{
			num = text.Length;
		}
		int num2 = 0;
		for (int i = startIndex; i < num; i++)
		{
			num2 += method_3(text[i]);
		}
		return method_4(num2, fontSize);
	}

	public float method_2(char c, float fontSize)
	{
		return method_4(method_3(c), fontSize);
	}

	private int method_3(char c)
	{
		Class6734 @class = class6735_0.method_0(c);
		return @class.AdvanceWidth;
	}

	public float method_4(float designUnits, float fontSize)
	{
		float num = (float)EmHeight / fontSize;
		return designUnits / num;
	}

	public void method_5(Class6724 fontName)
	{
		string_1 = fontName.method_0(Enum896.const_1);
		string_2 = fontName.method_0(Enum896.const_2);
		string_3 = fontName.method_0(Enum896.const_4);
		string_4 = fontName.method_1(Enum896.const_6);
		string_0 = fontName.method_3(Enum896.const_1);
	}

	public bool method_6(string familyName)
	{
		string[] array = string_0;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				string a = array[num];
				if (Class5964.smethod_42(a, familyName))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private string method_7()
	{
		byte[] array = new byte[16];
		Class5964.smethod_1(FamilyName.GetHashCode(), array, 0);
		Class5964.smethod_1((int)Style, array, 4);
		string arg = new Guid(array).ToString("D");
		string arg2 = (bool_0 ? "otf" : "ttf");
		return $"{arg}.{arg2}";
	}
}
