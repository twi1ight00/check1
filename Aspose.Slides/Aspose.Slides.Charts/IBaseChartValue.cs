using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("0abf141a-1c14-4dcd-a0ee-f1c9218ba8cc")]
public interface IBaseChartValue
{
	DataSourceType DataSourceType { get; set; }

	object Data { get; set; }
}
