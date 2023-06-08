using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("8cf1e538-0e68-43b6-84aa-94073440d486")]
public interface IChartSeriesCollection : ICollection, IEnumerable, IEnumerable<IChartSeries>
{
	IChartSeries this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IChartSeries Add(ChartType type);

	IChartSeries Insert(int index, ChartType type);

	IChartSeries Add(IChartDataCell cellWithSeriesName, ChartType type);

	IChartSeries Add(IChartCellCollection cellsWithSeriesName, ChartType type);

	IChartSeries Add(string name, ChartType type);

	int IndexOf(IChartSeries value);

	void Remove(IChartSeries value);

	void RemoveAt(int index);

	void Clear();
}
