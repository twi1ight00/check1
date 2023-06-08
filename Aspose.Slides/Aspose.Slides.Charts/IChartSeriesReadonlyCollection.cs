using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("3d32acae-7a7d-4eb2-aa59-c613715402b8")]
[ComVisible(true)]
public interface IChartSeriesReadonlyCollection : ICollection, IEnumerable, IEnumerable<IChartSeries>
{
	IChartSeries this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
