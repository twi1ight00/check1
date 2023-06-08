using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("0c1ca0d5-dc56-46af-9139-8fb464076bda")]
public interface IExtraColorSchemeCollection : IEnumerable<IExtraColorScheme>, ICollection, IEnumerable
{
	IExtraColorScheme this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
