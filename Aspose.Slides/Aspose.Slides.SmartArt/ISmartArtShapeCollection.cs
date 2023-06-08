using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.SmartArt;

[Guid("8C489B44-B181-4618-884D-F8D5FFC372F5")]
[ComVisible(true)]
public interface ISmartArtShapeCollection : IEnumerable<ISmartArtShape>, ICollection, IEnumerable
{
	ISmartArtShape this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
