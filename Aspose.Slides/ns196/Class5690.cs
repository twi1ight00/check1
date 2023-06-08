using System.Drawing;
using ns173;
using ns190;

namespace ns196;

internal class Class5690
{
	private Class5171 class5171_0;

	private Class4974 class4974_0;

	public Class5690(Class5171 spm, int pageNumber, string pageNumberStr, bool blank, bool spanAll)
	{
		class5171_0 = spm;
		class4974_0 = new Class4974(spm, pageNumber, pageNumberStr, blank, spanAll);
	}

	public Class5690(RectangleF viewArea, int pageNumber, string pageNumberStr, bool blank)
	{
		class5171_0 = null;
		class4974_0 = new Class4974(viewArea, pageNumber, pageNumberStr, null, blank);
	}

	public Class5171 method_0()
	{
		return class5171_0;
	}

	public Class4974 method_1()
	{
		return class4974_0;
	}
}
