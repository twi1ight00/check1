using System.Collections;
using x381fb081d11d6275;

namespace xce0136f05681c5e9;

internal class x0de10523530ef89b : x22033edbeead0f61
{
	private readonly x9e83e90818260fa5 x230c333abfdbfccd;

	private readonly xe2ff3c3cd396cfd9 x18ddd758cd8495e3;

	private readonly IDictionary x15637d65c176fc79;

	private readonly bool xce303370c7ab5679;

	internal x0de10523530ef89b(x9e83e90818260fa5 hyperlinkWriter, xe2ff3c3cd396cfd9 writerCommon, IDictionary bookmarkNamesToValidXmlIds, bool exportBookmarkIdInsteadOfName)
	{
		x230c333abfdbfccd = hyperlinkWriter;
		x18ddd758cd8495e3 = writerCommon;
		x15637d65c176fc79 = bookmarkNamesToValidXmlIds;
		xce303370c7ab5679 = exportBookmarkIdInsteadOfName;
	}

	internal override void x334f73a0b642051d(string xd17ec8f278d25c87)
	{
		if (x230c333abfdbfccd.x9d9e341ca28e413c)
		{
			return;
		}
		if (x15637d65c176fc79 != null)
		{
			object obj = x15637d65c176fc79[xd17ec8f278d25c87];
			if (obj != null)
			{
				xd17ec8f278d25c87 = (string)obj;
			}
		}
		x18ddd758cd8495e3.xe1410f585439c7d4.xd52401bdf5aacef6(xce303370c7ab5679 ? "<a id=\"" : "<a name=\"");
		x18ddd758cd8495e3.xe1410f585439c7d4.x3d1be38abe5723e3(xd17ec8f278d25c87);
		x18ddd758cd8495e3.xe1410f585439c7d4.xd52401bdf5aacef6("\"></a>");
	}
}
