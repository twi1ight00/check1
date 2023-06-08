using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("20ecdcd7-92b4-4bc7-b5ba-5296633a96ac")]
[ComVisible(true)]
public interface ILegendEntryCollection
{
	ILegendEntryProperties this[int index] { get; }

	int Count { get; }
}
