using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using ns47;

namespace ns18;

internal class Class955 : Class954
{
	private bool[] bool_0 = new bool[257];

	private char char_0 = 'Ā';

	private char char_1;

	private Class957 class957_0;

	private Class962 class962_0;

	internal Class955(Class1440 class1440_1, string string_3, FontStyle fontStyle_1)
		: base(class1440_1, string_3, fontStyle_1, bool_0: false)
	{
		class957_0 = new Class957(class1440_1, this);
	}

	internal void method_14(string string_3)
	{
		foreach (char c in string_3)
		{
			bool_0[(uint)c] = true;
			if (c < char_0)
			{
				char_0 = c;
			}
			if (c > char_1)
			{
				char_1 = c;
			}
		}
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		method_15(class1447_0);
		class962_0.vmethod_1(class1447_0);
		class957_0.vmethod_1(class1447_0);
	}

	private void method_15(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/Font");
		class1447_0.method_11("/Subtype", "/TypeType");
		class1447_0.method_11("/BaseFont", $"/{string_2}");
		class1447_0.method_16("/FirstChar", char_0);
		class1447_0.method_16("/LastChar", char_1);
		class962_0 = new Class962(class1440_0, vmethod_4());
		class1447_0.method_11("/Widths", class962_0.method_1());
		class1447_0.method_11("/FontDescriptor", class957_0.method_1());
		class1447_0.method_11("/Encoding", "/WinAnsiEncoding");
		class1447_0.method_10();
		class1447_0.method_25();
	}

	protected override void vmethod_5()
	{
		StringBuilder stringBuilder = new StringBuilder(method_16());
		if ((fontStyle_0 & (FontStyle.Bold | FontStyle.Italic)) == (FontStyle.Bold | FontStyle.Italic))
		{
			stringBuilder.Append(",BoldItalic");
		}
		else if ((fontStyle_0 & FontStyle.Bold) == FontStyle.Bold)
		{
			stringBuilder.Append(",Bold");
		}
		else if ((fontStyle_0 & FontStyle.Italic) == FontStyle.Italic)
		{
			stringBuilder.Append(",Italic");
		}
		string_2 = stringBuilder.ToString();
	}

	internal override string vmethod_4()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		for (char c = char_0; c <= char_1; c = (char)(c + 1))
		{
			if (bool_0[(uint)c])
			{
				Class1463 @class = class1460_0.method_7().method_1(c);
				stringBuilder.Append(method_4(@class.method_2()));
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

	private string method_16()
	{
		string text = class1460_0.method_5();
		if (text == null)
		{
			text = class1460_0.method_3().Replace(" ", "#20");
		}
		return text;
	}

	[SpecialName]
	internal override bool vmethod_6()
	{
		return false;
	}
}
