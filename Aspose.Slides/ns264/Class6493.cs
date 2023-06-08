using System;
using System.Drawing;
using System.Text;
using ns218;
using ns224;
using ns271;

namespace ns264;

internal class Class6493 : Interface318
{
	public const string string_0 = "Microsoft Sans Serif";

	public const float float_0 = 12f;

	private int int_0;

	private FontStyle fontStyle_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private int int_4;

	private string string_1;

	Enum866 Interface318.Type => Enum866.const_6;

	public int Handle
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

	internal Encoding Encoding
	{
		get
		{
			int codepage = Class5954.smethod_0(CharSet, 1252);
			return Encoding.GetEncoding(codepage);
		}
	}

	internal float Escapement => (float)int_2 / 10f;

	internal string FaceName
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	internal int CharSet => int_4;

	internal Class6493()
	{
		int_1 = 0;
		int_2 = 0;
		int_3 = 0;
		fontStyle_0 = FontStyle.Regular;
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		string_1 = "Microsoft Sans Serif";
	}

	internal void method_0(Class6501 reader)
	{
		int_1 = reader.ReadInt16();
		reader.ReadInt16();
		int_2 = reader.ReadInt16();
		reader.ReadInt16();
		int_3 = reader.ReadInt16();
		bool_0 = reader.ReadBoolean();
		bool_1 = reader.ReadBoolean();
		bool_2 = reader.ReadBoolean();
		int_4 = reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
		string_1 = Class5958.smethod_1(reader.method_2(32, Encoding));
		method_5();
	}

	internal void method_1(Class6498 reader)
	{
		int_0 = reader.ReadInt32();
		int_1 = reader.ReadInt32();
		reader.ReadInt32();
		int_2 = reader.ReadInt32();
		reader.ReadInt32();
		int_3 = reader.ReadInt32();
		bool_0 = reader.ReadBoolean();
		bool_1 = reader.ReadBoolean();
		bool_2 = reader.ReadBoolean();
		int_4 = reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
		string_1 = Class5958.smethod_1(reader.method_5(32));
		method_5();
	}

	internal Class5999 method_2()
	{
		return Class6652.Instance.method_3(string_1, method_4(), method_3(), "Microsoft Sans Serif");
	}

	private FontStyle method_3()
	{
		if (fontStyle_0 != 0)
		{
			return fontStyle_0;
		}
		if (int_3 >= 700)
		{
			fontStyle_0 |= FontStyle.Bold;
		}
		if (bool_0)
		{
			fontStyle_0 |= FontStyle.Italic;
		}
		if (bool_1)
		{
			fontStyle_0 |= FontStyle.Underline;
		}
		if (bool_2)
		{
			fontStyle_0 |= FontStyle.Strikeout;
		}
		return fontStyle_0;
	}

	private float method_4()
	{
		if (int_1 != 0)
		{
			return Math.Abs(int_1);
		}
		return 12f;
	}

	private void method_5()
	{
		if (string_1.StartsWith("@"))
		{
			int_1 = (int)Math.Round((double)int_1 * 0.8);
			string_1 = string_1.Substring(1, string_1.Length - 1);
		}
	}
}
