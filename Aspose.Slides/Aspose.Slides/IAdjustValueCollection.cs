using System.Collections;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("43018c27-5739-4d78-9666-3d34bff7eb17")]
[ComVisible(true)]
public interface IAdjustValueCollection : ICollection, IEnumerable
{
	IAdjustValue this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
