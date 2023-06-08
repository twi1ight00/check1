using System.IO;
using ns226;
using ns232;

namespace ns227;

internal class Class6118
{
	public static void smethod_0(Stream ttfStream, Stream woffStream)
	{
		Class6020 font = Class6117.smethod_1(ttfStream);
		Class6133 @class = new Class6133();
		Class6017 class2 = @class.method_0(font);
		class2.CopyTo(new StreamWriter(woffStream));
	}
}
