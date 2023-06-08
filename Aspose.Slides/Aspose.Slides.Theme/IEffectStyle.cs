using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("b112bf59-5a82-4556-bcd7-c9bf427cdb1a")]
public interface IEffectStyle
{
	IEffectFormat EffectFormat { get; }

	IThreeDFormat ThreeDFormat { get; }
}
