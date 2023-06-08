using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("e9413adf-f4dd-4477-ba53-c3efe0176a98")]
public interface IGradientStop
{
	float Position { get; set; }

	IColorFormat Color { get; }
}
