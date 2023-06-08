using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("8D7B285A-144F-4B5E-866F-8DB4A5CDE2D6")]
[ComVisible(true)]
public interface IGlobalLayoutSlideCollection : IEnumerable<ILayoutSlide>, ICollection, IEnumerable, ILayoutSlideCollection
{
	ILayoutSlideCollection AsILayoutSlideCollection { get; }

	ILayoutSlide AddClone(ILayoutSlide sourceLayout);

	ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster);

	ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName);
}
