using Aspose.Slides.Charts;

namespace ns36;

internal interface Interface22
{
	Interface21 ASeries { get; }

	Interface23 this[int index] { get; }

	int Add(TrendlineType type);

	int Add(TrendlineType type, string name);
}
