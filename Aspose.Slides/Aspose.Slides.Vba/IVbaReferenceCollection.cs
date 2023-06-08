using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[Guid("89178F2E-6121-49E5-9EA7-179F437F4C80")]
[ComVisible(true)]
public interface IVbaReferenceCollection : ICollection, IEnumerable, IEnumerable<IVbaReference>
{
	IVbaReference this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	void Add(IVbaReference value);
}
