using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("7c9ffae1-a154-4e21-834f-cbd3fd3510c9")]
public interface IDataSourceTypeForErrorBarsCustomValues
{
	DataSourceType DataSourceTypeForXMinusValues { get; set; }

	DataSourceType DataSourceTypeForXPlusValues { get; set; }

	DataSourceType DataSourceTypeForYMinusValues { get; set; }

	DataSourceType DataSourceTypeForYPlusValues { get; set; }
}
