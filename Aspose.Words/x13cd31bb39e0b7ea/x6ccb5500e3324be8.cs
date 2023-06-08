using System.Collections;
using Aspose.Words;
using Aspose.Words.Math;
using xe5b37aee2c2a4d4e;

namespace x13cd31bb39e0b7ea;

internal class x6ccb5500e3324be8
{
	private readonly DocumentBase x232be220f517f721;

	private readonly Stack x0331d35c858de61b = new Stack();

	internal x6ccb5500e3324be8(DocumentBase doc)
	{
		x232be220f517f721 = doc;
	}

	internal VisitorAction xe2d69851fb4d6421(OfficeMath x203bd7b4a3be8d02)
	{
		if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x30727a59b1643735)
		{
			x0331d35c858de61b.Push(new xa35c50772d20813a(reconstructMissingArguments: true, x232be220f517f721));
		}
		else if (x0331d35c858de61b.Count != 0 && xa35c50772d20813a.x824a132df9284c08(x203bd7b4a3be8d02))
		{
			((xa35c50772d20813a)x0331d35c858de61b.Peek()).xe2d69851fb4d6421(x203bd7b4a3be8d02);
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction xb678a1dd33952080(OfficeMath x203bd7b4a3be8d02)
	{
		if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x30727a59b1643735)
		{
			((xa35c50772d20813a)x0331d35c858de61b.Pop()).xb678a1dd33952080(x203bd7b4a3be8d02);
		}
		else if (x0331d35c858de61b.Count != 0 && xa35c50772d20813a.x824a132df9284c08(x203bd7b4a3be8d02))
		{
			((xa35c50772d20813a)x0331d35c858de61b.Peek()).xb678a1dd33952080(x203bd7b4a3be8d02);
		}
		return VisitorAction.Continue;
	}
}
