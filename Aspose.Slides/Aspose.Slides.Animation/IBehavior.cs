using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("cf485dfa-7880-4d6f-a9ff-03971721bdbc")]
[ComVisible(true)]
public interface IBehavior
{
	NullableBool Accumulate { get; set; }

	BehaviorAdditiveType Additive { get; set; }

	IBehaviorProperties Properties { get; }

	ITiming Timing { get; set; }
}
