using System;
using System.Threading;

namespace Enyim.Caching;

public class CountdownEvent : IDisposable
{
	private int count;

	private ManualResetEvent mre;

	public CountdownEvent(int count)
	{
		this.count = count;
		mre = new ManualResetEvent(initialState: false);
	}

	public void Signal()
	{
		if (count == 0)
		{
			throw new InvalidOperationException("Counter underflow");
		}
		int tmp = Interlocked.Decrement(ref count);
		if (tmp == 0)
		{
			if (!mre.Set())
			{
				throw new InvalidOperationException("couldn't signal");
			}
		}
		else if (tmp < 0)
		{
			throw new InvalidOperationException("Counter underflow");
		}
	}

	public void Wait()
	{
		if (count != 0)
		{
			mre.WaitOne();
		}
	}

	~CountdownEvent()
	{
		Dispose();
	}

	void IDisposable.Dispose()
	{
		Dispose();
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		if (mre != null)
		{
			mre.Close();
			mre = null;
		}
	}
}
