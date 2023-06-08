using System;
using System.Collections;

namespace ns167;

internal class Class4820
{
	private const int int_0 = -1;

	private int int_1;

	private IEnumerator ienumerator_0;

	private Queue queue_0 = new Queue();

	private Class4845 class4845_0;

	internal Class4845 Current
	{
		get
		{
			if (!(class4845_0 != null))
			{
				throw new InvalidOperationException("Please report exception. Current PlanePointer undefined.");
			}
			return class4845_0;
		}
	}

	internal Class4820(IEnumerator iterator)
	{
		ienumerator_0 = iterator;
		Reset();
	}

	internal void Reset()
	{
		queue_0.Clear();
		ienumerator_0.Reset();
		int_1 = -1;
		class4845_0 = null;
	}

	internal bool method_0()
	{
		class4845_0 = null;
		queue_0.Clear();
		bool flag = true;
		if (int_1 == -1 && (flag = ienumerator_0.MoveNext()))
		{
			int_1 = ((Class4845)ienumerator_0.Current).Row;
		}
		while (flag)
		{
			queue_0.Enqueue(ienumerator_0.Current);
			if (!(flag = ienumerator_0.MoveNext()) || int_1 != ((Class4845)ienumerator_0.Current).Row)
			{
				break;
			}
		}
		if (!flag)
		{
			int_1 = -1;
		}
		else
		{
			int_1 = ((Class4845)ienumerator_0.Current).Row;
		}
		if (!flag)
		{
			return queue_0.Count != 0;
		}
		return true;
	}

	internal bool method_1()
	{
		if (queue_0.Count != 0)
		{
			class4845_0 = (Class4845)queue_0.Dequeue();
			return true;
		}
		class4845_0 = null;
		return false;
	}
}
