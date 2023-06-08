using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("3680a168-855e-42d7-83dd-e8cd707e1dcf")]
public interface IGlow
{
	double Radius { get; set; }

	IColorFormat Color { get; }
}
