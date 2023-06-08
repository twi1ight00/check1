using System.Drawing;

namespace ns277;

internal interface Interface321
{
	bool IsBaselineVisible { get; set; }

	bool AreWordBoxBordersVisible { get; set; }

	bool IsFilledWordBox { get; set; }

	Color WordBoxColor { get; set; }

	Color WordBoxBorderColor { get; set; }

	bool IsFilledSpaceBoxes { get; set; }

	Color SpaceBoxColor { get; set; }
}
