using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("910B8ADB-70C6-4115-B901-727EA03819CA")]
public interface IPoint
{
	float Time { get; set; }

	object Value { get; set; }

	string Formula { get; set; }
}
