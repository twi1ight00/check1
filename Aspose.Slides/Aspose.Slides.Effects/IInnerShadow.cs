using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("682be3b9-4e7a-441d-b87f-a3b31eeca08d")]
[ComVisible(true)]
public interface IInnerShadow
{
	double BlurRadius { get; set; }

	float Direction { get; set; }

	double Distance { get; set; }

	IColorFormat ShadowColor { get; }
}
