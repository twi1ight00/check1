using Aspose.Slides.Warnings;

namespace ns49;

internal sealed class Class1175 : Class1172, IWarningInfo, IPresentationSignedWarningInfo
{
	public override WarningType WarningType => WarningType.DataLoss;

	IWarningInfo IPresentationSignedWarningInfo.AsIWarningInfo => this;

	public Class1175()
		: base("Reading signed presentation. Signature will be lost during processing.")
	{
	}
}
