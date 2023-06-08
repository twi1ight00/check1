using System;
using System.Diagnostics;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class TextColumnCollection
{
	private const int xf0a3523bf16ce322 = 45;

	private readonly PageSetup x39f6a06ec4dcfb69;

	public bool EvenlySpaced
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(2360);
		}
		set
		{
			xae20093bed1e48a8(2360, value);
		}
	}

	public double Spacing
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2370));
		}
		set
		{
			xae20093bed1e48a8(2370, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double Width
	{
		get
		{
			double num = (double)x39f6a06ec4dcfb69.x887b872a95caaab5 - Spacing * (double)(Count - 1);
			return num / (double)Count;
		}
	}

	public bool LineBetween
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(2060);
		}
		set
		{
			x39f6a06ec4dcfb69.x332a8eedb847940d.xa2dc0badd30e7585(2060, value);
		}
	}

	public int Count => x6e1eb96b81362ebc;

	public TextColumn this[int index] => xbd7bb54d8760ed0a.get_xe6d4b1b411ed94b5(index);

	private int x6e1eb96b81362ebc
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2350);
		}
		set
		{
			x39f6a06ec4dcfb69.x332a8eedb847940d.xa2dc0badd30e7585(2350, value);
		}
	}

	private x28980d9c5ec3f471 xbd7bb54d8760ed0a
	{
		get
		{
			x28980d9c5ec3f471 x28980d9c5ec3f = (x28980d9c5ec3f471)x39f6a06ec4dcfb69.x332a8eedb847940d.xb25c0862ce36b53c(2380);
			if (x28980d9c5ec3f == null)
			{
				x28980d9c5ec3f = new x28980d9c5ec3f471();
				x28980d9c5ec3f.x22d10a164c7c096f(x6e1eb96b81362ebc);
				x39f6a06ec4dcfb69.x332a8eedb847940d.xa2dc0badd30e7585(2380, x28980d9c5ec3f);
			}
			return x28980d9c5ec3f;
		}
	}

	internal TextColumnCollection(PageSetup pageSetup)
	{
		x39f6a06ec4dcfb69 = pageSetup;
	}

	public void SetCount(int newCount)
	{
		if (newCount < 1 || newCount > 45)
		{
			throw new ArgumentOutOfRangeException("newCount");
		}
		xae20093bed1e48a8(2350, newCount);
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		object obj = x39f6a06ec4dcfb69.x332a8eedb847940d.xb25c0862ce36b53c(xba08ce632055a1d9);
		if (obj == null)
		{
			return x39f6a06ec4dcfb69.x332a8eedb847940d.xe5b82b9f0104471f(xba08ce632055a1d9);
		}
		return obj;
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xb2406b27de450835(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void x25bb86d35040d531(params object[] xcd31b50c43a96e21)
	{
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (xba08ce632055a1d9 == 2350)
		{
			int x5593b5699d = (x6e1eb96b81362ebc = (int)xbcea506a33cf9111);
			xbd7bb54d8760ed0a.x22d10a164c7c096f(x5593b5699d);
		}
		else
		{
			x39f6a06ec4dcfb69.x332a8eedb847940d.xa2dc0badd30e7585(xba08ce632055a1d9, xbcea506a33cf9111);
		}
	}
}
