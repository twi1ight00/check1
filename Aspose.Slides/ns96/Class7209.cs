using System.Collections;

namespace ns96;

internal class Class7209 : ArrayList
{
	public void method_0(object item)
	{
		Add(item);
	}

	public object method_1()
	{
		object result = this[Count - 1];
		RemoveAt(Count - 1);
		return result;
	}

	public object Peek()
	{
		return this[Count - 1];
	}
}
