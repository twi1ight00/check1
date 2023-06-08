using Aspose.Words;
using Aspose.Words.Fields;
using x381fb081d11d6275;
using xf989f31a236ff98c;

namespace xdbe3cd173bd00464;

internal class xd4314a24b94f0688 : x6868017fd9012087
{
	private readonly xb7c37a50632d7dd3 xa056586c1f99e199;

	internal xd4314a24b94f0688(Document document, x08802e9e984cd3ee runWriter, x05df33911093beb0 hyperlinkWriter, xb7c37a50632d7dd3 warningCallback)
		: base(document, exportTocPageNumbers: false, exportTextInputFormFieldAsText: true, runWriter, hyperlinkWriter)
	{
		xa056586c1f99e199 = warningCallback;
	}

	internal override VisitorAction x85599597a4d57020(FormField x0ab8fc6e4b8e829c)
	{
		xa056586c1f99e199.xbbf9a1ead81dd3a1(WarningType.DataLoss, "FormField nodes are not supported in XAML yet.");
		return VisitorAction.Continue;
	}
}
