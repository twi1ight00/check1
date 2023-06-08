using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("7a7de933-a203-446c-bb7a-f24bda4dc0fb")]
[ComVisible(true)]
public interface IField : IPresentationComponent, ISlideComponent
{
	IFieldType Type { get; set; }

	ISlideComponent AsISlideComponent { get; }
}
