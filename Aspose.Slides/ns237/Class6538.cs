using System.Drawing;
using System.IO;
using ns218;
using ns224;
using ns235;

namespace ns237;

internal class Class6538 : Class6535
{
	private const int int_2 = 0;

	private const byte byte_0 = 12;

	private const byte byte_1 = 25;

	private readonly bool bool_2;

	private readonly string string_12;

	private readonly Class5999 class5999_0;

	private readonly Class5998 class5998_0;

	private readonly int int_3;

	private readonly string string_13;

	private Class6520 class6520_0;

	private static readonly char[] char_0 = new char[2] { '\n', '\r' };

	internal string PlainText
	{
		get
		{
			if (!bool_2)
			{
				return string_12;
			}
			return string_13;
		}
	}

	internal Class6538(Class6546 hostPage, Class6210 source)
		: base(hostPage, source)
	{
		bool_2 = source.IsRichText;
		string_12 = source.Value;
		class5999_0 = source.DefaultFont;
		class5998_0 = source.FontColor;
		int_3 = source.MaxLength;
		string_13 = source.PlainText;
		method_4();
	}

	protected override Enum882 vmethod_2()
	{
		return Enum882.const_1;
	}

	protected override int vmethod_3()
	{
		int num = 0;
		num = 0 | ((bool_2 ? 1 : 0) << 25);
		return num | base.vmethod_3();
	}

	protected override void vmethod_4(Class6679 writer)
	{
		if (int_3 != 0)
		{
			writer.method_18("/MaxLen", int_3);
		}
		if (bool_2)
		{
			if (string_12.Length != 0)
			{
				writer.method_13("/RV", string_12);
				writer.method_13("/DS", "font: 12pt Arial");
			}
		}
		else
		{
			writer.method_14("/DA", method_1(class5999_0, class5998_0), isEscape: false);
			if (string_12.Length != 0)
			{
				writer.method_13("/DV", string_12);
			}
		}
		writer.method_13("/V", PlainText);
		writer.Write("/AP");
		writer.method_6();
		writer.method_0("/N");
		writer.Write(class6520_0.IndirectReference);
		writer.method_7();
	}

	protected override void vmethod_5(Class6679 writer)
	{
		class6520_0.vmethod_0(writer);
	}

	private void method_4()
	{
		class6520_0 = new Class6520(class6672_0);
		class6520_0.BoundingBox = new RectangleF(0f, 0f, base.BoundingBox.Width, base.BoundingBox.Height);
		class6520_0.Content = method_5();
	}

	private MemoryStream method_5()
	{
		MemoryStream memoryStream = new MemoryStream();
		Class6678 writer = new Class6678(memoryStream);
		Class6535.smethod_1(writer);
		Class6535.smethod_3(writer, class5998_0);
		Class6527 font = method_2(writer, class5999_0);
		Class6535.smethod_4(writer, base.BoundingBox.Height - class5999_0.SizePoints - 1f);
		float num = 0f;
		string[] array = string_13.Split(char_0);
		for (int i = 0; i < array.Length; i++)
		{
			if (num > base.BoundingBox.Height)
			{
				break;
			}
			if (Class5964.smethod_20(array[i]))
			{
				Class6535.smethod_5(writer, 0f, num);
				Class6535.smethod_6(writer, array[i], font);
			}
			num -= class5999_0.SizePoints;
		}
		Class6535.smethod_2(writer);
		return memoryStream;
	}
}
