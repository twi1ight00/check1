using Aspose.Slides.Warnings;

namespace ns49;

internal sealed class Class1174 : Class1172, IWarningInfo, IKnownIssueWarningInfo
{
	private readonly WarningType warningType_0;

	public override WarningType WarningType => warningType_0;

	IWarningInfo IKnownIssueWarningInfo.AsIWarningInfo => this;

	internal Class1174(WarningType warningType, string issueId)
		: base($"The result of this operation may be affected by known issue {issueId}")
	{
		warningType_0 = warningType;
	}
}
