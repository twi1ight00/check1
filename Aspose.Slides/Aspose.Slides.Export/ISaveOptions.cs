using System.Runtime.InteropServices;
using Aspose.Slides.Warnings;

namespace Aspose.Slides.Export;

[ComVisible(true)]
[Guid("dcc148b8-faf1-4cdf-9515-f0bd457fd456")]
public interface ISaveOptions
{
	IWarningCallback WarningCallback { get; set; }
}
