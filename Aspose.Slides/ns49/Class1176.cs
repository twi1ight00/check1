using Aspose.Slides.Warnings;

namespace ns49;

internal sealed class Class1176 : Class1172, IWarningInfo, INotImplementedWarningInfo
{
	private WarningType warningType_0;

	public override WarningType WarningType => warningType_0;

	IWarningInfo INotImplementedWarningInfo.AsIWarningInfo => this;

	public Class1176(string description, WarningType warningType)
		: base(description)
	{
		warningType_0 = warningType;
	}
}
