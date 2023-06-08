using System.Collections;

namespace ns33;

internal class Class1169 : IEnumerator
{
	public delegate bool Delegate16(object item, object userData);

	private readonly IEnumerator ienumerator_0;

	private readonly Delegate16 delegate16_0;

	private readonly object object_0;

	public object Current => ienumerator_0.Current;

	public Class1169(IEnumerator baseEnumerator, Delegate16 canReturn, object userData)
	{
		ienumerator_0 = baseEnumerator;
		delegate16_0 = canReturn;
		object_0 = userData;
	}

	public void Reset()
	{
		ienumerator_0.Reset();
	}

	public bool MoveNext()
	{
		do
		{
			if (!ienumerator_0.MoveNext())
			{
				return false;
			}
		}
		while (!delegate16_0(ienumerator_0.Current, object_0));
		return true;
	}
}
