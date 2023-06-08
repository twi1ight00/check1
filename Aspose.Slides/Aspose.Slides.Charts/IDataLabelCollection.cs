using System.Collections;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("64f87a24-5cba-47fa-bd47-6329f1821678")]
[ComVisible(true)]
public interface IDataLabelCollection : IEnumerable, IPresentationComponent, ISlideComponent, IChartComponent
{
	IDataLabel this[int index] { get; }

	IDataLabelFormat DefaultDataLabelFormat { get; }

	bool IsVisible { get; }

	int CountOfVisibleDataLabels { get; }

	int Count { get; }

	IChartSeries ParentSeries { get; }

	IChartComponent AsIChartComponent { get; }

	IEnumerable AsIEnumerable { get; }

	void Hide();

	int IndexOf(IDataLabel value);
}
