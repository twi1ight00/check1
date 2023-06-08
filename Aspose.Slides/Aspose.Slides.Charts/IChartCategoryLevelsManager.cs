using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("b0ea8451-e11a-4483-a153-5d8d32eb5f4f")]
[ComVisible(true)]
public interface IChartCategoryLevelsManager
{
	IChartDataCell this[int level] { get; }

	[Obsolete("Use SetGroupingItem(int level, object value) method instead. Will be removed after 01.05.2014.")]
	void SetValueOfLevel(int level, IChartDataCell value);

	[Obsolete("Use SetGroupingItem(int level, object value) method instead. Will be removed after 01.05.2014.")]
	void SetGroupingItem(int level, IChartDataCell value);

	void SetGroupingItem(int level, object value);

	[Obsolete("Use DeleteGroupingItem method instead. Will be removed after 01.05.2014.")]
	void DeleteValueOfLevel(int level);

	void DeleteGroupingItem(int level);
}
