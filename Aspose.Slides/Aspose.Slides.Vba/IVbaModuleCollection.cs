using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[ComVisible(true)]
[Guid("B1368DF3-F881-48B2-BDDD-30FA70AD4781")]
public interface IVbaModuleCollection : ICollection, IEnumerable, IEnumerable<IVbaModule>
{
	IVbaModule this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IVbaModule AddEmptyModule(string name);

	void Remove(IVbaModule value);
}
