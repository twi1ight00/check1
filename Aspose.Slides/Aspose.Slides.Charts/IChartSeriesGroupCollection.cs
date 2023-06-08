using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("df7f2244-5493-41a4-a98c-67ac49282bf6")]
public interface IChartSeriesGroupCollection : ICollection, IEnumerable, IEnumerable<IChartSeriesGroup>
{
	IChartSeriesGroup this[IChartSeries ofSeries] { get; }

	IChartSeriesGroup this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
