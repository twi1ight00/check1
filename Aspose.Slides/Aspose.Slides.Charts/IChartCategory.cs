using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("f0725f99-05fa-4904-aebd-36f0368944be")]
public interface IChartCategory
{
	bool UseCell { get; }

	IChartDataCell AsCell { get; set; }

	object AsLiteral { get; set; }

	object Value { get; set; }

	[Obsolete("Use GroupingLevels property instead. Will be removed after 01.05.2014.")]
	IChartCategoryLevelsManager Levels { get; }

	IChartCategoryLevelsManager GroupingLevels { get; }

	void Remove();
}
