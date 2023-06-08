using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("ddef617c-dc28-4582-9ed6-86e276634e50")]
[ComVisible(true)]
public interface IFormat
{
	IFillFormat Fill { get; }

	ILineFormat Line { get; }

	IEffectFormat Effect { get; }

	IThreeDFormat Effect3D { get; }
}
