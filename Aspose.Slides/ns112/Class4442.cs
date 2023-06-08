using ns100;
using ns108;

namespace ns112;

internal class Class4442
{
	private Class4437 class4437_0;

	private Class4409 class4409_0;

	private byte byte_0;

	private Class4440 class4440_0;

	private Class4445 class4445_0;

	private Class4436 class4436_0;

	private Class4446 class4446_0;

	private Class4448 class4448_0;

	public Class4442(Class4437 reader, Class4409 font)
	{
		class4437_0 = reader;
		class4409_0 = font;
		class4440_0 = new Class4440(reader);
		class4445_0 = new Class4445(this, reader);
		class4436_0 = new Class4436(font, reader);
		class4446_0 = new Class4446(font, reader);
		class4448_0 = new Class4448(font, reader);
	}

	public Class4409 method_0()
	{
		class4437_0.method_0();
		class4437_0.method_0();
		byte_0 = class4437_0.method_0();
		class4437_0.method_3();
		class4437_0.Seek(byte_0);
		class4409_0.Internals.CustomParams.HeaderSize = byte_0;
		class4440_0.method_0(class4409_0.Internals.NameIndex);
		class4440_0.method_0(class4409_0.Internals.TopDictIndex);
		class4440_0.method_0(class4409_0.Internals.StringIndex);
		class4440_0.method_0(class4409_0.Internals.GlobalSubrsIndex);
		class4409_0.TopmostFont = new Class4444(isTopmost: true);
		class4409_0.Internals.TopDictIndex.method_0(0, out var offset, out var length);
		class4445_0.method_0(class4409_0.TopmostFont, class4409_0.Internals.TopDictIndex.IndexData, offset, length);
		class4437_0.Seek(class4409_0.TopmostFont.FontDictionary.long_7);
		class4440_0.method_0(class4409_0.Internals.CharstringsIndex);
		class4436_0.method_0(class4409_0.Internals.Charset);
		if (!class4409_0.IsCIDKeyedFont)
		{
			class4446_0.method_0(class4409_0.Internals.Encoding);
		}
		if (class4409_0.IsCIDKeyedFont)
		{
			class4437_0.Seek(class4409_0.TopmostFont.FontDictionary.long_17);
			class4440_0.method_0(class4409_0.Internals.FDArrayIndex);
			class4409_0.SubFonts = new Class4444[class4409_0.Internals.FDArrayIndex.ObjectsCount];
			for (int i = 0; i < class4409_0.Internals.FDArrayIndex.ObjectsCount; i++)
			{
				class4409_0.SubFonts[i] = new Class4444(isTopmost: false);
				class4409_0.Internals.FDArrayIndex.method_0(i, out offset, out length);
				class4445_0.method_0(class4409_0.SubFonts[i], class4409_0.Internals.FDArrayIndex.IndexData, offset, length);
			}
			class4448_0.method_0(class4409_0.Internals.FdSelect);
		}
		class4409_0.Internals.CustomParams.GlobalSubrsBias = method_1((ushort)class4409_0.Internals.GlobalSubrsIndex.ObjectsCount);
		return class4409_0;
	}

	internal int method_1(ushort numSubrs)
	{
		if (class4409_0.TopmostFont.FontDictionary.int_1 == 1)
		{
			return 0;
		}
		if (numSubrs < 1240)
		{
			return 107;
		}
		if (numSubrs < 33900)
		{
			return 1131;
		}
		return 32768;
	}
}
