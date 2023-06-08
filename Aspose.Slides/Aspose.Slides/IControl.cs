using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("f0d7746c-3365-478c-8b4f-a77ccc8c13ad")]
[ComVisible(true)]
public interface IControl : IPresentationComponent, ISlideComponent
{
	string Name { get; set; }

	Guid ClassId { get; }

	IPictureFillFormat SubstitutePictureFormat { get; }

	IShapeFrame Frame { get; set; }

	IControlPropertiesCollection Properties { get; }

	ISlideComponent AsISlideComponent { get; }
}
