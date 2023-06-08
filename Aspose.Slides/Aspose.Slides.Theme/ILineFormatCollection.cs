using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("41861141-c524-475e-9e7d-4c5f61e46fea")]
public interface ILineFormatCollection : ICollection, IEnumerable<ILineFormat>, IEnumerable
{
	ILineFormat this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
