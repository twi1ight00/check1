using Aspose.Slides.Charts;

namespace ns36;

internal interface Interface20
{
	Interface7 CategoryLabels { get; }

	Interface7 Category2Labels { get; }

	int Count { get; }

	Interface21 this[int index] { get; }

	Interface21 Add(ChartType seriesType);

	void RemoveAt(int index);
}
