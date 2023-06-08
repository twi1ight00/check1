using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("c3a6d851-e528-4c0e-b149-7f71db222eb4")]
public interface IShapeBevel
{
	double Width { get; set; }

	double Height { get; set; }

	BevelPresetType BevelType { get; set; }
}
