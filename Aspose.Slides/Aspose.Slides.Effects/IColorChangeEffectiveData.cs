using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("1204cb16-8736-41cc-8cb0-dff268ccbe39")]
public interface IColorChangeEffectiveData
{
	Color FromColor { get; }

	Color ToColor { get; }

	bool UseAlpha { get; }
}
