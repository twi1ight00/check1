using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface ISequenced<T> : ICollection<T>, IExtensible<T>, ICloneable, System.Collections.Generic.ICollection<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	int GetSequencedHashCode();

	[ComVisible(true)]
	bool SequencedEquals(ISequenced<T> otherCollection);
}
