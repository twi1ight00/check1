using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("e2fdedb5-d1f3-4030-b134-bb24b2594849")]
[ComVisible(true)]
public interface IMarker
{
	MarkerStyleType Symbol { get; set; }

	IFormat Format { get; }

	int Size { get; set; }
}
