using ns100;
using ns108;

namespace ns112;

internal class Class4448
{
	private Class4437 class4437_0;

	private Class4409 class4409_0;

	public Class4448(Class4409 font, Class4437 reader)
	{
		class4437_0 = reader;
		class4409_0 = font;
	}

	public void method_0(Class4435 fdSelect)
	{
		class4437_0.Seek(class4409_0.TopmostFont.FontDictionary.long_18);
		fdSelect.Format = class4437_0.method_0();
		int num = 0;
		switch (fdSelect.Format)
		{
		case 3:
		{
			int num2 = class4437_0.method_2();
			num = num2 * 3 + 2;
			break;
		}
		case 0:
			num = class4409_0.NumGlyphs;
			break;
		}
		fdSelect.Data = new byte[num];
		for (int i = 0; i < fdSelect.Data.Length; i++)
		{
			fdSelect.Data[i] = class4437_0.method_0();
		}
	}
}
