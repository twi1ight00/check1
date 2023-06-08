using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("35469424-84ae-4ce6-80f0-1ec7141aa779")]
public interface IImageTransformOCollectionEffectiveData : ICollection, IEnumerable, IEnumerable<IEffectEffectiveData>
{
	IEffectEffectiveData this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
