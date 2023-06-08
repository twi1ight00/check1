using System;
using System.Collections;

namespace x6c95d9cf46ff5f25;

internal class x115139807e6482f7 : IEnumerator, IEnumerable
{
	private readonly string xed4a7b1500064e12;

	private int x4e58f4e7533c657a;

	private int x6d0df3179ab204fc;

	public object Current
	{
		get
		{
			if (x4e58f4e7533c657a == 0)
			{
				throw new InvalidOperationException("Enumerator has not been started.");
			}
			return x6d0df3179ab204fc;
		}
	}

	public x115139807e6482f7(string text)
	{
		xed4a7b1500064e12 = text;
		Reset();
	}

	public IEnumerator GetEnumerator()
	{
		return this;
	}

	public bool MoveNext()
	{
		if (x4e58f4e7533c657a >= xed4a7b1500064e12.Length)
		{
			return false;
		}
		if (xdf3a1f89dca325a3.xe47befda53dc8577(xed4a7b1500064e12, x4e58f4e7533c657a))
		{
			x6d0df3179ab204fc = xdf3a1f89dca325a3.xee6b5ee7b01be5bb(xed4a7b1500064e12, x4e58f4e7533c657a);
			x4e58f4e7533c657a += 2;
			return true;
		}
		x6d0df3179ab204fc = xed4a7b1500064e12[x4e58f4e7533c657a];
		x4e58f4e7533c657a++;
		return true;
	}

	public void Reset()
	{
		x4e58f4e7533c657a = 0;
	}

	public static int xc768481624e3badf(string xb41faee6912a2313)
	{
		int num = 0;
		x115139807e6482f7 x115139807e6482f8 = new x115139807e6482f7(xb41faee6912a2313);
		while (x115139807e6482f8.MoveNext())
		{
			num++;
		}
		return num;
	}
}
