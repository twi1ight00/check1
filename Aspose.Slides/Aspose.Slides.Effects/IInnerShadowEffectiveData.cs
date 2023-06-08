using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("a80a7e48-4389-4655-9c92-63401a571662")]
[ComVisible(true)]
public interface IInnerShadowEffectiveData
{
	double BlurRadius { get; }

	float Direction { get; }

	double Distance { get; }

	Color ShadowColor { get; }
}
