using System.Runtime.InteropServices;

namespace Aspose.Slides.Warnings;

[Guid("7d8472c9-7877-46a0-a045-b0c5bb1b1096")]
[ComVisible(true)]
public interface INotImplementedWarningInfo : IWarningInfo
{
	IWarningInfo AsIWarningInfo { get; }
}
