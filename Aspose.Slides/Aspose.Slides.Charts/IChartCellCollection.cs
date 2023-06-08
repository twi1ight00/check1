using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("8cd3803e-0216-4d96-8867-ff521827d9e8")]
public interface IChartCellCollection : IEnumerable, IEnumerable<IChartDataCell>
{
	IChartDataCell this[int index] { get; }

	int Count { get; }

	IEnumerable AsIEnumerable { get; }

	string GetCellsAddress();

	string GetConcatenatedValuesFromCells();

	void Add(IChartDataCell chartDataCell);

	void Add(object value);

	void RemoveAt(int index);
}
