using System;
using System.Diagnostics;
using System.Reflection;

namespace x6c95d9cf46ff5f25;

[DefaultMember("Item")]
[DebuggerStepThrough]
internal class x09ce2c02826e31a6
{
	private const int _x9c038637e293d841 = 16;

	private int[] x83f3ea1d0a03c7e1;

	private object[] x0788cd5a9865fc16;

	private int _x0ceec69a97f73617;

	public int xe7dd8ddc8b289241
	{
		get
		{
			return x83f3ea1d0a03c7e1.Length;
		}
		set
		{
			if (value == x83f3ea1d0a03c7e1.Length)
			{
				return;
			}
			if (value < _x0ceec69a97f73617)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			if (value > 0)
			{
				int[] destinationArray = new int[value];
				object[] destinationArray2 = new object[value];
				if (_x0ceec69a97f73617 > 0)
				{
					Array.Copy(x83f3ea1d0a03c7e1, 0, destinationArray, 0, _x0ceec69a97f73617);
					Array.Copy(x0788cd5a9865fc16, 0, destinationArray2, 0, _x0ceec69a97f73617);
				}
				x83f3ea1d0a03c7e1 = destinationArray;
				x0788cd5a9865fc16 = destinationArray2;
			}
			else
			{
				x83f3ea1d0a03c7e1 = new int[16];
				x0788cd5a9865fc16 = new object[16];
			}
		}
	}

	public int xd44988f225497f3a => _x0ceec69a97f73617;

	public object xe6d4b1b411ed94b5
	{
		get
		{
			int num = xf8af57cefd692401(xba08ce632055a1d9);
			if (num < 0)
			{
				return null;
			}
			return x0788cd5a9865fc16[num];
		}
		set
		{
			int num = xcd4bd3abd72ff2da.x792b6f092cbf4bb1(x83f3ea1d0a03c7e1, 0, _x0ceec69a97f73617, xba08ce632055a1d9);
			if (num >= 0)
			{
				x0788cd5a9865fc16[num] = value;
			}
			else
			{
				xef23aa45e7612fdd(~num, xba08ce632055a1d9, value);
			}
		}
	}

	public x09ce2c02826e31a6()
	{
		x83f3ea1d0a03c7e1 = new int[16];
		x0788cd5a9865fc16 = new object[16];
	}

	public x09ce2c02826e31a6(int initialCapacity)
	{
		if (initialCapacity < 0)
		{
			throw new ArgumentOutOfRangeException("initialCapacity");
		}
		x83f3ea1d0a03c7e1 = new int[initialCapacity];
		x0788cd5a9865fc16 = new object[initialCapacity];
	}

	public void xd6b6ed77479ef68c(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		int num = xcd4bd3abd72ff2da.x792b6f092cbf4bb1(x83f3ea1d0a03c7e1, 0, _x0ceec69a97f73617, xba08ce632055a1d9);
		if (num >= 0)
		{
			throw new ArgumentException("duplicate");
		}
		xef23aa45e7612fdd(~num, xba08ce632055a1d9, xbcea506a33cf9111);
	}

	public void xa9d636b00ff486b7()
	{
		_x0ceec69a97f73617 = 0;
		x83f3ea1d0a03c7e1 = new int[16];
		x0788cd5a9865fc16 = new object[16];
	}

	protected x09ce2c02826e31a6 x676cdebdb54fa6f0()
	{
		x09ce2c02826e31a6 x09ce2c02826e31a7 = (x09ce2c02826e31a6)MemberwiseClone();
		x09ce2c02826e31a7._x0ceec69a97f73617 = 0;
		x09ce2c02826e31a7.x83f3ea1d0a03c7e1 = new int[x83f3ea1d0a03c7e1.Length];
		x09ce2c02826e31a7.x0788cd5a9865fc16 = new object[x0788cd5a9865fc16.Length];
		return x09ce2c02826e31a7;
	}

	public bool x263d579af1d0d43f(int xba08ce632055a1d9)
	{
		return xf8af57cefd692401(xba08ce632055a1d9) >= 0;
	}

	public bool xbc5dc59d0d9b620d(int xba08ce632055a1d9)
	{
		return xf8af57cefd692401(xba08ce632055a1d9) >= 0;
	}

	public bool x7fafcb376e0a3c46(object xbcea506a33cf9111)
	{
		return x298073470c4f233b(xbcea506a33cf9111) >= 0;
	}

	private void x258c9e9203a01f61(int xd088075e67f6ea91)
	{
		int num = ((x83f3ea1d0a03c7e1.Length == 0) ? 16 : (x83f3ea1d0a03c7e1.Length * 2));
		if (num < xd088075e67f6ea91)
		{
			num = xd088075e67f6ea91;
		}
		xe7dd8ddc8b289241 = num;
	}

	public object x6d3720b962bd3112(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return x0788cd5a9865fc16[xc0c4c459c6ccbd00];
	}

	public int xf15263674eb297bb(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return x83f3ea1d0a03c7e1[xc0c4c459c6ccbd00];
	}

	public int xf8af57cefd692401(int xba08ce632055a1d9)
	{
		int num = xcd4bd3abd72ff2da.x792b6f092cbf4bb1(x83f3ea1d0a03c7e1, 0, _x0ceec69a97f73617, xba08ce632055a1d9);
		if (num < 0)
		{
			return -1;
		}
		return num;
	}

	public int x298073470c4f233b(object xbcea506a33cf9111)
	{
		return Array.IndexOf(x0788cd5a9865fc16, xbcea506a33cf9111, 0, _x0ceec69a97f73617);
	}

	private void xef23aa45e7612fdd(int xc0c4c459c6ccbd00, int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (_x0ceec69a97f73617 == x83f3ea1d0a03c7e1.Length)
		{
			x258c9e9203a01f61(_x0ceec69a97f73617 + 1);
		}
		if (xc0c4c459c6ccbd00 < _x0ceec69a97f73617)
		{
			Array.Copy(x83f3ea1d0a03c7e1, xc0c4c459c6ccbd00, x83f3ea1d0a03c7e1, xc0c4c459c6ccbd00 + 1, _x0ceec69a97f73617 - xc0c4c459c6ccbd00);
			Array.Copy(x0788cd5a9865fc16, xc0c4c459c6ccbd00, x0788cd5a9865fc16, xc0c4c459c6ccbd00 + 1, _x0ceec69a97f73617 - xc0c4c459c6ccbd00);
		}
		x83f3ea1d0a03c7e1[xc0c4c459c6ccbd00] = xba08ce632055a1d9;
		x0788cd5a9865fc16[xc0c4c459c6ccbd00] = xbcea506a33cf9111;
		_x0ceec69a97f73617++;
	}

	public void x7121e9e177952651(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		_x0ceec69a97f73617--;
		if (xc0c4c459c6ccbd00 < _x0ceec69a97f73617)
		{
			Array.Copy(x83f3ea1d0a03c7e1, xc0c4c459c6ccbd00 + 1, x83f3ea1d0a03c7e1, xc0c4c459c6ccbd00, _x0ceec69a97f73617 - xc0c4c459c6ccbd00);
			Array.Copy(x0788cd5a9865fc16, xc0c4c459c6ccbd00 + 1, x0788cd5a9865fc16, xc0c4c459c6ccbd00, _x0ceec69a97f73617 - xc0c4c459c6ccbd00);
		}
		x83f3ea1d0a03c7e1[_x0ceec69a97f73617] = 0;
		x0788cd5a9865fc16[_x0ceec69a97f73617] = null;
	}

	public void x52b190e626f65140(int xba08ce632055a1d9)
	{
		int num = xf8af57cefd692401(xba08ce632055a1d9);
		if (num >= 0)
		{
			x7121e9e177952651(num);
		}
	}

	public void x19a17137bf433dd7(int xc0c4c459c6ccbd00, object xbcea506a33cf9111)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		x0788cd5a9865fc16[xc0c4c459c6ccbd00] = xbcea506a33cf9111;
	}

	public void x9fba28333f1b9fd6()
	{
		xe7dd8ddc8b289241 = _x0ceec69a97f73617;
	}
}
