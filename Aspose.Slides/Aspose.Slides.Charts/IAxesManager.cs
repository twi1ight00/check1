using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("cefbe09f-a7eb-4312-adb2-7cd1211a91aa")]
[ComVisible(true)]
public interface IAxesManager
{
	IAxis HorizontalAxis { get; }

	IAxis SecondaryHorizontalAxis { get; }

	IAxis VerticalAxis { get; }

	IAxis SecondaryVerticalAxis { get; }

	IAxis SeriesAxis { get; }
}
