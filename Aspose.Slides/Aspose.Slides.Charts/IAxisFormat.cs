using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("478afa99-dc97-4f7a-814b-5b33fad89ea8")]
[ComVisible(true)]
public interface IAxisFormat
{
	IFillFormat Fill { get; }

	ILineFormat Line { get; }

	IEffectFormat Effect { get; }
}
