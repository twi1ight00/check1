using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("1585bf4b-6504-4ce5-a9a7-984f8ee85684")]
public interface IUpDownBarsManager
{
	IFormat UpBarsFormat { get; }

	IFormat DownBarsFormat { get; }

	bool HasUpDownBars { get; set; }

	int GapWidth { get; set; }
}
