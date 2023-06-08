using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("6b5d49cf-7267-4622-9fc2-560ae98fba4a")]
[ComVisible(true)]
public interface IChartComponent : IPresentationComponent, ISlideComponent
{
	IChart Chart { get; }

	ISlideComponent AsISlideComponent { get; }
}
