using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("23581e97-1388-48a8-bd01-63ac009fb199")]
[ComVisible(true)]
public interface IFillFormatCollection : IEnumerable<IFillFormat>, ICollection, IEnumerable
{
	IFillFormat this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
