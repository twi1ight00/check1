using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("5e4ee281-9df1-4a49-a314-f437121dc57e")]
[ComVisible(true)]
public interface ILineFormatCollectionEffectiveData : ICollection, IEnumerable, IEnumerable<ILineFormatEffectiveData>
{
	ILineFormatEffectiveData this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
