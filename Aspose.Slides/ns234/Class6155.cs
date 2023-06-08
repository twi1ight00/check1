using System.Collections;

namespace ns234;

internal class Class6155
{
	private readonly IEnumerator ienumerator_0;

	public object Current => ienumerator_0.Current;

	protected IEnumerator WrappedEnumerator => ienumerator_0;

	public Class6155(IEnumerator wrappedEnumerator)
	{
		ienumerator_0 = wrappedEnumerator;
	}

	public bool MoveNext()
	{
		return ienumerator_0.MoveNext();
	}

	public void Reset()
	{
		ienumerator_0.Reset();
	}
}
