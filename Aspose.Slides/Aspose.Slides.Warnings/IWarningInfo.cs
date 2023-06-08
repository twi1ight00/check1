using System.Runtime.InteropServices;

namespace Aspose.Slides.Warnings;

[Guid("D18C1E67-9769-4C03-98A5-16A03A0C0135")]
[ComVisible(true)]
public interface IWarningInfo
{
	WarningType WarningType { get; }

	string Description { get; }

	void SendWarning(IWarningCallback receiver);
}
