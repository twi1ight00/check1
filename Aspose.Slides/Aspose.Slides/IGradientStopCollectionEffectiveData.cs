using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("a8a37f95-ad07-4d18-921d-6387dc01a6f7")]
[ComVisible(true)]
public interface IGradientStopCollectionEffectiveData : ICollection, IEnumerable, IEnumerable<IGradientStopEffectiveData>
{
	IGradientStopEffectiveData this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
