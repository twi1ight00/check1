using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("9123DB43-ECB8-4B40-8227-751BB0D2BA83")]
[ComVisible(true)]
public interface ICommandEffect : IBehavior
{
	CommandEffectType Type { get; set; }

	string CommandString { get; set; }

	IShape ShapeTarget { get; set; }

	IBehavior AsIBehavior { get; }
}
