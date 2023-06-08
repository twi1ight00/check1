using System.Collections;

namespace x2a6f63b6650e76c4;

internal class x496b40ebe5ff5626
{
	private Queue x63aaf3ff4d51622e = new Queue();

	internal int xd44988f225497f3a => x63aaf3ff4d51622e.Count;

	internal void xca34506722145a85(xddb28bb303a8678b xccb63ca5f63dc470)
	{
		x63aaf3ff4d51622e.Enqueue(xccb63ca5f63dc470);
	}

	internal xddb28bb303a8678b x1536749f629911ac()
	{
		return (xddb28bb303a8678b)x63aaf3ff4d51622e.Dequeue();
	}
}
