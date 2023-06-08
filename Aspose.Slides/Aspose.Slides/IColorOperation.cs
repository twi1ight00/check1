using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("d9e1c445-a827-40a7-b093-d301dbaf0130")]
[ComVisible(true)]
public interface IColorOperation
{
	ColorTransformOperation OperationType { get; }

	float Parameter { get; }
}
