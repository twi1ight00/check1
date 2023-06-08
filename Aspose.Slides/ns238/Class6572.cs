using System.IO;
using ns271;

namespace ns238;

internal class Class6572 : Class6568
{
	public Class6572(Class6567 context)
		: base(context)
	{
	}

	public void method_0(Class6730 font)
	{
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_1(base.Context.method_3(font));
		base.Writer.method_4(bit: true, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: true, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: true, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: true);
		base.Writer.WriteByte(0);
		string text = font.FullFontName + "_AW";
		base.Writer.WriteByte((byte)text.Length);
		for (int i = 0; i < text.Length; i++)
		{
			base.Writer.WriteByte((byte)text[i]);
		}
		method_1(font);
		base.Writer.BaseWriter.BaseStream.Seek(0L, SeekOrigin.End);
		@class.method_1(Enum878.const_51);
	}

	private void method_1(Class6730 font)
	{
		Class6586 @class = base.Context.method_4(font);
		base.Writer.method_1((short)@class.Chars.Length);
		long position = base.Writer.BaseWriter.BaseStream.Position;
		short[] array = new short[@class.Chars.Length];
		for (int i = 0; i < array.Length; i++)
		{
			base.Writer.method_1(0);
		}
		long position2 = base.Writer.BaseWriter.BaseStream.Position;
		base.Writer.method_1(0);
		Class6573 class2 = new Class6573(base.Context);
		for (int j = 0; j < @class.Chars.Length; j++)
		{
			array[j] = (short)(base.Writer.BaseWriter.BaseStream.Position - position);
			char c = @class.Chars[j];
			if (c != ' ')
			{
				Class6658 glyphData = @class.method_2(c);
				class2.method_0(glyphData);
			}
			else
			{
				class2.method_1();
			}
		}
		short value = (short)(base.Writer.BaseWriter.BaseStream.Position - position);
		base.Writer.BaseWriter.BaseStream.Position = position2;
		base.Writer.method_1(value);
		base.Writer.BaseWriter.BaseStream.Position = position;
		for (int k = 0; k < array.Length; k++)
		{
			base.Writer.method_1(array[k]);
		}
		base.Writer.BaseWriter.BaseStream.Seek(0L, SeekOrigin.End);
		for (int l = 0; l < @class.Chars.Length; l++)
		{
			base.Writer.method_1((short)@class.Chars[l]);
		}
		base.Writer.method_1(@class.Ascent);
		base.Writer.method_1(@class.Descent);
		base.Writer.method_1(@class.Leading);
		for (int m = 0; m < @class.Chars.Length; m++)
		{
			short value2 = @class.method_3(@class.Chars[m]);
			base.Writer.method_1(value2);
		}
		for (int n = 0; n < @class.Chars.Length; n++)
		{
			base.Writer.method_13(0, 0, 0, 0);
		}
		base.Writer.method_1(0);
	}
}
