using System.Runtime.InteropServices;
using Aspose.Slides.Warnings;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("69a7487b-7a45-4228-bbf5-c35f16831394")]
public interface ILoadOptions
{
	LoadFormat LoadFormat { get; set; }

	string DefaultRegularFont { get; set; }

	string DefaultSymbolFont { get; set; }

	string DefaultAsianFont { get; set; }

	string Password { get; set; }

	bool OnlyLoadDocumentProperties { get; set; }

	IWarningCallback WarningCallback { get; set; }
}
