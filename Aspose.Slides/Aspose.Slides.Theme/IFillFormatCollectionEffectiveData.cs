using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("8ddc2e01-14c2-4203-90d0-91eae0ce2de0")]
public interface IFillFormatCollectionEffectiveData : ICollection, IEnumerable<IFillFormatEffectiveData>, IEnumerable
{
	IFillFormatEffectiveData this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
