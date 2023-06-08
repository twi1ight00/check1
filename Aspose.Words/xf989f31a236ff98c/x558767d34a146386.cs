using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;

namespace xf989f31a236ff98c;

internal class x558767d34a146386
{
	private x558767d34a146386()
	{
	}

	internal static Node[] x2163dabd23663d1e(DocumentBase x6beba47238e0ade6, xeedad81aaed42a76 x789564759d365819)
	{
		return x2c880a43e59505de(x6beba47238e0ade6, x789564759d365819, FieldType.FieldPage, "PAGE");
	}

	internal static Node[] x2c880a43e59505de(DocumentBase x6beba47238e0ade6, xeedad81aaed42a76 x789564759d365819, FieldType x77ce91e5324df734, string x4a3f0a05c02f235f)
	{
		return new Node[5]
		{
			new FieldStart(x6beba47238e0ade6, (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85(), x77ce91e5324df734),
			new Run(x6beba47238e0ade6, x4a3f0a05c02f235f, (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85()),
			new FieldSeparator(x6beba47238e0ade6, (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85(), x77ce91e5324df734, null),
			new Run(x6beba47238e0ade6, "XXX", (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85()),
			new FieldEnd(x6beba47238e0ade6, (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85(), x77ce91e5324df734, hasSeparator: true)
		};
	}
}
