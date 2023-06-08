using ns33;

namespace ns56;

internal class Class2468
{
	private static readonly Class1151 class1151_0 = new Class1151("alignTx", "ar", "autoTxRot", "begPts", "begSty", "bendPt", "bkpt", "bkPtFixedVal", "chAlign", "chDir", "connRout", "contDir", "ctrShpMap", "dim", "dstNode", "endPts", "endSty", "fallback", "flowDir", "grDir", "hierAlign", "horzAlign", "linDir", "lnSpAfChP", "lnSpAfParP", "lnSpCh", "lnSpPar", "nodeHorzAlign", "nodeVertAlign", "off", "parTxLTRAlign", "parTxRTLAlign", "pyraAcctBkgdNode", "pyraAcctPos", "pyraAcctTxMar", "pyraAcctTxNode", "pyraLvlNode", "rotPath", "rtShortDist", "secChAlign", "secLinDir", "shpTxLTRAlignCh", "shpTxRTLAlignCh", "spanAng", "srcNode", "stAng", "stBulletLvl", "stElem", "txAnchorHorz", "txAnchorHorzCh", "txAnchorVert", "txAnchorVertCh", "txBlDir", "txDir", "vertAlign");

	public static Enum304 smethod_0(string xmlValue)
	{
		return (Enum304)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum304 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
