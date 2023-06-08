using Aspose.Words;
using Aspose.Words.Saving;
using x28925c9b27b37a46;

namespace x13cd31bb39e0b7ea;

internal class xfed58eabcc10ae18
{
	private readonly bool x91db619c0fb1f024;

	private readonly IWarningCallback xa056586c1f99e199;

	internal xfed58eabcc10ae18(SaveOptions saveOptions, IWarningCallback warningCallback)
	{
		OoxmlSaveOptions ooxmlSaveOptions = saveOptions as OoxmlSaveOptions;
		x91db619c0fb1f024 = ooxmlSaveOptions != null && ooxmlSaveOptions.Compliance != OoxmlCompliance.Ecma376_2006;
		xa056586c1f99e199 = warningCallback;
	}

	internal void x2b044873d442f783(Section x94a5047f14145553)
	{
		x9a0723ab706dc475(x94a5047f14145553.xfc72d4c9b765cad7.xa8c2637cc4888928);
		x9a0723ab706dc475(x94a5047f14145553.xfc72d4c9b765cad7.x79d902473861f242);
		x9a0723ab706dc475(x94a5047f14145553.xfc72d4c9b765cad7.xaea087ab32102492);
		x9a0723ab706dc475(x94a5047f14145553.xfc72d4c9b765cad7.xd7a21e27974f626c);
	}

	private void x9a0723ab706dc475(Border x14cf9593b86ecbaa)
	{
		if (x14cf9593b86ecbaa.xbca512cb9f5a451a)
		{
			x14cf9593b86ecbaa.LineStyle = xf31fa29f88bca20b(x14cf9593b86ecbaa.LineStyle);
		}
	}

	private LineStyle xf31fa29f88bca20b(LineStyle x26516bbd7ae94699)
	{
		bool flag = false;
		LineStyle result = x26516bbd7ae94699;
		if (x91db619c0fb1f024)
		{
			switch ((xd28385f788b65737)x26516bbd7ae94699)
			{
			case xd28385f788b65737.x6ffb366e5c799290:
			case xd28385f788b65737.xd7f7b769a29bd215:
			case xd28385f788b65737.xaf8677f6e6ddf25e:
			case xd28385f788b65737.x501412a9801428a5:
			case xd28385f788b65737.xd017fbd34c994f2f:
			case xd28385f788b65737.x8db3e0f1b533bd06:
				result = (LineStyle)207;
				flag = true;
				break;
			}
		}
		else
		{
			switch (x26516bbd7ae94699)
			{
			case (LineStyle)228:
				flag = true;
				result = (LineStyle)121;
				break;
			case (LineStyle)229:
			case (LineStyle)230:
			case (LineStyle)231:
			case (LineStyle)232:
				flag = true;
				result = (LineStyle)207;
				break;
			case (LineStyle)233:
			case (LineStyle)234:
			case (LineStyle)235:
				flag = true;
				result = (LineStyle)214;
				break;
			}
		}
		if (flag)
		{
			xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Replaced PageBorderArt value with ISO29500-compliant.");
		}
		return result;
	}

	private void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Docx, xc2358fbac7da3d45));
		}
	}
}
