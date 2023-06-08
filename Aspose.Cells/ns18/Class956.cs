using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ns47;

namespace ns18;

internal class Class956 : Class954
{
	private Class952 class952_0;

	private Class939 class939_0;

	private Class1398 class1398_0 = new Class1398();

	private Class1398 class1398_1 = new Class1398();

	public Class956(Class1440 class1440_1, string string_3, FontStyle fontStyle_1)
		: base(class1440_1, string_3, fontStyle_1, bool_0: true)
	{
		class952_0 = new Class952(class1440_1, this);
		class939_0 = new Class939(class1440_1, bool_1: false);
		class1398_1.Add(0, 0);
		class1398_0.Add(0, 0);
	}

	public byte[] method_14(string string_3)
	{
		byte[] array = new byte[string_3.Length * 2];
		int num = 0;
		foreach (char c in string_3)
		{
			object obj = class1398_0[c];
			int num2;
			if (obj != null)
			{
				num2 = (int)obj;
			}
			else
			{
				int int_ = class1460_0.method_39(c);
				obj = class1398_1[int_];
				if (obj != null)
				{
					num2 = (int)obj;
					class1398_0.Add(c, num2);
				}
				else
				{
					num2 = class1398_1.Count;
					class1398_1.Add(int_, num2);
					class1398_0.Add(c, num2);
				}
			}
			array[num++] = (byte)((uint)(num2 >> 8) & 0xFFu);
			array[num++] = (byte)((uint)num2 & 0xFFu);
		}
		return array;
	}

	public override void vmethod_3(Stream stream_0)
	{
		Class1462 @class = new Class1462(bool_0: false);
		@class.method_2(class1460_0, class1398_1, stream_0, bool_0: false, bool_1: false);
	}

	internal override string vmethod_4()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		for (int i = 0; i < class1398_0.Count; i++)
		{
			char char_ = (char)class1398_0.method_3(i);
			int num = (int)class1398_0.GetByIndex(i);
			Class1463 @class = class1460_0.method_7().method_1(char_);
			string value = num.ToString(NumberFormatInfo.InvariantInfo) + "[" + method_4(@class.method_2()).ToString(NumberFormatInfo.InvariantInfo) + "]";
			stringBuilder.Append(value);
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		method_15(class1447_0);
		class952_0.vmethod_1(class1447_0);
		method_16(class1447_0);
	}

	internal override string vmethod_2()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("F");
		string text = $"{method_0():D05}";
		for (int i = 0; i < text.Length; i++)
		{
			stringBuilder.Append((char)(text[i] + 17));
		}
		return stringBuilder.ToString();
	}

	private void method_15(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/Font");
		class1447_0.method_11("/Subtype", "/Type0");
		class1447_0.method_11("/Encoding", "/Identity-H");
		class1447_0.method_11("/BaseFont", $"/{string_2}");
		class1447_0.method_11("/DescendantFonts", $"[{class952_0.method_1()}]");
		class1447_0.method_11("/ToUnicode", class939_0.method_1());
		class1447_0.method_10();
		class1447_0.method_25();
	}

	private void method_16(Class1447 class1447_0)
	{
		class939_0.method_5("/CIDInit /ProcSet findresource begin");
		class939_0.method_5("11 dict begin");
		class939_0.method_5("begincmap");
		class939_0.method_5("/CIDSystemInfo");
		class939_0.method_5("<< /Registry (Adobe)");
		class939_0.method_5("/Ordering (UCS)");
		class939_0.method_5("/Supplement 0");
		class939_0.method_5(">> def");
		class939_0.method_5("/CMapName /Adobe-Identity-UCS def");
		class939_0.method_5("/CMapType 2 def");
		class939_0.method_5("1 begincodespacerange");
		class939_0.method_5("<0000><FFFF>");
		class939_0.method_5("endcodespacerange");
		method_17();
		class939_0.method_5("endcmap");
		class939_0.method_5("CMapName currentdict /CMap defineresource pop");
		class939_0.method_5("end");
		class939_0.method_5("end");
		class939_0.vmethod_1(class1447_0);
	}

	private void method_17()
	{
		Class1398 @class = method_18();
		class939_0.method_6("{0} beginbfchar", @class.Count);
		for (int i = 0; i < @class.Count; i++)
		{
			int num = @class.method_3(i);
			int num2 = (int)@class.GetByIndex(i);
			class939_0.method_7("<{0:X4}><{1:X4}>", num, num2);
		}
		class939_0.method_5("endbfchar");
	}

	private Class1398 method_18()
	{
		Class1398 @class = new Class1398();
		for (int i = 0; i < class1398_0.Count; i++)
		{
			int num = class1398_0.method_3(i);
			int int_ = (int)class1398_0.GetByIndex(i);
			@class[int_] = num;
		}
		return @class;
	}

	protected override void vmethod_5()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string_0);
		stringBuilder.Append("+");
		stringBuilder.Append(class1460_0.method_5());
		if (method_6() && method_5())
		{
			stringBuilder.Append(",BoldItalic");
		}
		else if (method_6())
		{
			stringBuilder.Append(",Bold");
		}
		else if (method_5())
		{
			stringBuilder.Append(",Italic");
		}
		string_2 = stringBuilder.ToString();
	}

	[SpecialName]
	internal override bool vmethod_6()
	{
		return true;
	}
}
