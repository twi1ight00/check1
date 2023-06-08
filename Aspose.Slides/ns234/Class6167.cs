using System.Threading;

namespace ns234;

internal abstract class Class6167
{
	private Thread thread_0;

	public bool IsAlive => thread_0.IsAlive;

	public void method_0()
	{
		thread_0 = new Thread(vmethod_0);
		thread_0.Start();
	}

	protected abstract void vmethod_0();
}
