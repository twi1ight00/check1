using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("07ee1e6d-f6bf-46ee-9b99-1d61936d45cb")]
[ComVisible(true)]
public interface ITextAnimationCollection : ICollection, IEnumerable, IEnumerable<ITextAnimation>
{
	ITextAnimation this[int index] { get; }

	ITextAnimation[] this[IShape shape] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
