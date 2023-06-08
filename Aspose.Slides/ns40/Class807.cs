using System.Globalization;
using System.Threading;

namespace ns40;

internal class Class807
{
	internal static CultureInfo smethod_0()
	{
		return Thread.CurrentThread.CurrentCulture;
	}

	internal static int smethod_1()
	{
		return Thread.CurrentThread.CurrentCulture.TextInfo.OEMCodePage;
	}
}
