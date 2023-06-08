using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("ad7ba6ea-9eb0-47a1-9c58-d56b8c22c942")]
[ComVisible(true)]
public interface IEffectStyleCollectionEffectiveData : IEnumerable<IEffectStyleEffectiveData>, ICollection, IEnumerable
{
	IEffectStyleEffectiveData this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
