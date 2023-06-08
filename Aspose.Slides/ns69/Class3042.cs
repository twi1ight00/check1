using System.Collections;

namespace ns69;

internal sealed class Class3042
{
	private Queue queue_0 = new Queue();

	public int Count => queue_0.Count;

	public Class3042()
	{
		queue_0 = new Queue();
	}

	public Class3042(int capasity)
	{
		queue_0 = new Queue(capasity);
	}

	public void Clear()
	{
		queue_0.Clear();
	}

	public void method_0(Class3040 triangle)
	{
		queue_0.Enqueue(triangle);
	}

	public Class3040 method_1()
	{
		return (Class3040)queue_0.Dequeue();
	}
}
