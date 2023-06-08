using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("8780a5aa-2263-4462-a768-44400cb3be35")]
[ComVisible(true)]
public interface IChartCategoryCollection : ICollection, IEnumerable, IEnumerable<IChartCategory>
{
	IChartCategory this[int index] { get; }

	bool UseCells { get; set; }

	[Obsolete("Use GroupingLevelCount property instead. Will be removed after 01.05.2014.")]
	int LevelCount { get; }

	int GroupingLevelCount { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IChartCategory Add(IChartDataCell chartDataCell);

	IChartCategory Add(object value);

	int IndexOf(IChartCategory value);

	void Remove(IChartCategory value);

	void Clear();
}
