using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2557
{
	internal static readonly Class1151 class1151_0 = new Class1151(-1, "cust", "title", "tx", "twoColTx", "tbl", "txAndChart", "chartAndTx", "dgm", "chart", "txAndClipArt", "clipArtAndTx", "titleOnly", "blank", "txAndObj", "objAndTx", "objOnly", "obj", "txAndMedia", "mediaAndTx", "objOverTx", "txOverObj", "txAndTwoObj", "twoObjAndTx", "twoObjOverTx", "fourObj", "vertTx", "clipArtAndVertTx", "vertTitleAndTx", "vertTitleAndTxOverChart", "twoObj", "objAndTwoObj", "twoObjAndObj", "secHead", "twoTxTwoObj", "objTx", "picTx");

	public static SlideLayoutType smethod_0(string xmlValue)
	{
		return (SlideLayoutType)class1151_0[xmlValue];
	}

	public static string smethod_1(SlideLayoutType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
