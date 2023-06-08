using System.Collections;

namespace ns234;

internal class Class6156 : Class6155
{
	public object Value => ((IDictionaryEnumerator)base.WrappedEnumerator).Value;

	public Class6156(IDictionaryEnumerator wrappedEnumerator)
		: base(wrappedEnumerator)
	{
	}
}
