using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2550
{
	private static readonly Class1151 class1151_0 = new Class1151("unknown", "pct5", "pct10", "pct20", "pct25", "pct30", "pct40", "pct50", "pct60", "pct70", "pct75", "pct80", "pct90", "dkHorz", "dkVert", "dkDnDiag", "dkUpDiag", "smCheck", "trellis", "ltHorz", "ltVert", "ltDnDiag", "ltUpDiag", "smGrid", "dotDmnd", "wdDnDiag", "wdUpDiag", "dashUpDiag", "dashDnDiag", "narVert", "narHorz", "dashVert", "dashHorz", "lgConfetti", "lgGrid", "horzBrick", "lgCheck", "smConfetti", "zigZag", "solidDmnd", "diagBrick", "openDmnd", "plaid", "sphere", "weave", "dotGrid", "divot", "shingle", "wave", "horz", "vert", "cross", "dnDiag", "upDiag", "diagCross");

	public static PatternStyle smethod_0(string xmlValue)
	{
		return (PatternStyle)class1151_0[xmlValue];
	}

	public static string smethod_1(PatternStyle domValue)
	{
		return class1151_0[(int)domValue];
	}
}
