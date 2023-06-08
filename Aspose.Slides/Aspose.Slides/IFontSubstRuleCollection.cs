using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("43CAACCE-9C16-401A-BE9E-E3F9FCB941E0")]
[ComVisible(true)]
public interface IFontSubstRuleCollection : IEnumerable<IFontSubstRule>, ICollection, IEnumerable
{
	IFontSubstRule this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	void Add(IFontSubstRule value);

	void Remove(IFontSubstRule value);
}
