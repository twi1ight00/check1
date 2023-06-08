using System.Runtime.InteropServices;

namespace Aspose.Slides.Warnings;

[Guid("535FD29D-556F-47DB-A2B8-F3759CB4E7EC")]
[ComVisible(true)]
public interface IWarningCallback
{
	ReturnAction Warning(IWarningInfo warning);
}
