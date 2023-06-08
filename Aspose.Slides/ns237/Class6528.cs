using System.Drawing;
using System.Text;
using ns271;

namespace ns237;

internal abstract class Class6528 : Class6527
{
	private bool[] bool_1;

	private char char_0;

	private char char_1;

	private Class6543 class6543_0;

	private Class6531 class6531_0;

	internal static int int_1 = 255;

	protected bool[] UsedChars
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

	protected char FirstChar
	{
		get
		{
			return char_0;
		}
		set
		{
			char_0 = value;
		}
	}

	protected char LastChar
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
		}
	}

	protected Class6531 WidthArray
	{
		get
		{
			return class6531_0;
		}
		set
		{
			class6531_0 = value;
		}
	}

	protected Class6543 FontDescriptor
	{
		get
		{
			return class6543_0;
		}
		set
		{
			class6543_0 = value;
		}
	}

	protected Class6528(Class6672 context, FontStyle requestedStyle, Class6730 font, Enum873 fontType)
		: base(context, requestedStyle, font, fontType)
	{
	}

	internal virtual void vmethod_4(string text)
	{
		foreach (char c in text)
		{
			if (c <= int_1)
			{
				UsedChars[(uint)c] = true;
				if (c < FirstChar)
				{
					FirstChar = c;
				}
				if (c > LastChar)
				{
					LastChar = c;
				}
			}
		}
	}

	public override void vmethod_0(Class6679 writer)
	{
		method_4(writer);
		class6531_0.vmethod_0(writer);
		class6543_0.vmethod_0(writer);
	}

	internal virtual void vmethod_5()
	{
		char_0 = '\0';
		char_1 = (char)int_1;
		for (int i = 0; i <= char_1; i++)
		{
			bool_1[i] = true;
		}
	}

	internal string method_3()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		for (char c = char_0; c <= char_1; c = (char)(c + 1))
		{
			if (bool_1[(uint)c])
			{
				Class6734 @class = class6730_0.Glyphs.method_0(c);
				stringBuilder.Append(method_1(@class.AdvanceWidth));
			}
			else
			{
				stringBuilder.Append("0");
			}
			if (c < char_1)
			{
				stringBuilder.Append(" ");
			}
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	protected void method_4(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/Font");
		writer.method_8("/Subtype", vmethod_6());
		writer.method_8("/BaseFont", $"/{string_1}");
		writer.method_18("/FirstChar", FirstChar);
		writer.method_18("/LastChar", LastChar);
		WidthArray = new Class6531(class6672_0, method_3());
		writer.method_8("/Widths", WidthArray.IndirectReference);
		writer.method_8("/FontDescriptor", FontDescriptor.IndirectReference);
		writer.method_8("/Encoding", "/WinAnsiEncoding");
		writer.method_7();
		writer.method_30();
	}

	internal abstract string vmethod_6();
}
