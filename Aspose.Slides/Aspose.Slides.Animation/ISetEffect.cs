using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("CC1A4D7F-0860-4B66-9F75-2537896277DF")]
public interface ISetEffect : IBehavior
{
	object To { get; set; }

	IBehavior AsIBehavior { get; }
}
