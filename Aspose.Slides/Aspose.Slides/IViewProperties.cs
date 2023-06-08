using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("50FF25D3-2000-42B7-9E2C-D270A1D1520F")]
[ComVisible(true)]
public interface IViewProperties
{
	ViewType LastView { get; set; }

	NullableBool ShowComments { get; set; }
}
