using System.Collections;
using System.Collections.Generic;

namespace ns305;

internal abstract class Class7075 : IEnumerable, IEnumerable<Class6976>
{
	public abstract Class6976 this[int index] { get; }

	public abstract int Length { get; }

	public abstract IEnumerator<Class6976> GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
