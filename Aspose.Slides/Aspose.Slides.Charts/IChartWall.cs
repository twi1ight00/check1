using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("3d540dd2-cd2b-4407-baba-fdc2fe0e8910")]
[ComVisible(true)]
public interface IChartWall
{
	int Thickness { get; set; }

	IFormat Format { get; }

	PictureType PictureType { get; set; }
}
