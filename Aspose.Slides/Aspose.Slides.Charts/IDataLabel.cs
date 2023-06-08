using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("2ed29d6c-a659-403a-8f59-54153ea2f03b")]
public interface IDataLabel : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IOverridableText, ILayoutable
{
	bool IsVisible { get; }

	IDataLabelFormat DataLabelFormat { get; }

	ILayoutable AsILayoutable { get; }

	IOverridableText AsIOverridableText { get; }

	void Hide();
}
