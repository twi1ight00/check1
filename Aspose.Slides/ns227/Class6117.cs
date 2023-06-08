using System.IO;
using ns226;
using ns232;

namespace ns227;

internal class Class6117
{
	public static void smethod_0(Stream ttfStream, Stream eotStream, bool compress, out Class6121 prefix)
	{
		Class6020 font = smethod_1(ttfStream);
		Class6122 @class = new Class6122(compress);
		Class6017 class2 = @class.method_0(font, out prefix);
		class2.CopyTo(new StreamWriter(eotStream));
	}

	internal static Class6020 smethod_1(Stream ttfStream)
	{
		Class6022 @class = Class6022.smethod_0();
		@class.method_0(fingerprint: false);
		return @class.method_2(new StreamReader(ttfStream))[0];
	}
}
