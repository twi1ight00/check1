using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[ComVisible(true)]
[Guid("352b25a8-e6e8-4387-9bb7-8ea1747d97ba")]
public interface IPptOptions : ISaveOptions
{
	ISaveOptions AsISaveOptions { get; }
}
