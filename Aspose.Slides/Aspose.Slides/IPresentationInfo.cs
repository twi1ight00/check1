using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("CA4682BB-0EE0-4B71-AB86-7230B21CE0E0")]
[ComVisible(true)]
public interface IPresentationInfo
{
	bool IsEncrypted { get; }

	LoadFormat LoadFormat { get; }
}
