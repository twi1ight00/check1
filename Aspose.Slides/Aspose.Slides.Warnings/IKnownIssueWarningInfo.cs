using System.Runtime.InteropServices;

namespace Aspose.Slides.Warnings;

[Guid("0788213a-17b3-4e8f-a475-1df4c291da35")]
[ComVisible(true)]
public interface IKnownIssueWarningInfo : IWarningInfo
{
	IWarningInfo AsIWarningInfo { get; }
}
