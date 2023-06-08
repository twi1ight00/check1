using System.Runtime.InteropServices;

namespace Aspose.Slides.Warnings;

[ComVisible(true)]
[Guid("E3BD3862-BA41-4737-9B76-EB5532547E36")]
public enum WarningType
{
	SourceFileCorruption = 0,
	DataLoss = 1,
	MajorFormattingLoss = 2,
	MinorFormattingLoss = 3,
	CompatibilityIssue = 4,
	UnexpectedContent = 99
}
