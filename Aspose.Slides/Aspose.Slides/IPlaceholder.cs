using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("b084a704-95a7-4d68-95ad-239b957a9be6")]
public interface IPlaceholder
{
	Orientation Orientation { get; }

	PlaceholderSize Size { get; }

	PlaceholderType Type { get; }

	uint Index { get; }
}
