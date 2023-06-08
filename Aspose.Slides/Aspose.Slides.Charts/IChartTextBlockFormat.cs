using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("5146f28b-f8e9-4fc1-93c0-5d1a0434b2b0")]
[ComVisible(true)]
public interface IChartTextBlockFormat
{
	TextAnchorType AnchoringType { get; set; }

	NullableBool CenterText { get; set; }

	TextVerticalType TextVerticalType { get; set; }
}
