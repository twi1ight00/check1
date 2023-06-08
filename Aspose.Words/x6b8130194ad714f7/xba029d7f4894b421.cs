using System;

namespace x6b8130194ad714f7;

internal class xba029d7f4894b421
{
	private string xd308f2330afde345;

	private int x35a5073ffeb125c5;

	private int x9ba6e2d568cd6468;

	public char xd8a0ce16f609a9e9 => x850d183921cdec0a(0);

	public bool x5959bccb67bbf051 => xd44988f225497f3a > 0;

	public char x0defee75348dbb6e => x850d183921cdec0a(xd44988f225497f3a - 1);

	public int x761445bca289bae4
	{
		get
		{
			return x9ba6e2d568cd6468;
		}
		set
		{
			int num = xef557afa150f7cb2;
			if (value <= xef557afa150f7cb2)
			{
				x9ba6e2d568cd6468 = value;
			}
			else
			{
				x9ba6e2d568cd6468 = xef557afa150f7cb2;
			}
			xd44988f225497f3a = num - x9ba6e2d568cd6468;
		}
	}

	public int xef557afa150f7cb2
	{
		get
		{
			return x9ba6e2d568cd6468 + xd44988f225497f3a;
		}
		set
		{
			if (value < x761445bca289bae4)
			{
				xd44988f225497f3a = 0;
			}
			else
			{
				xd44988f225497f3a = value - x9ba6e2d568cd6468;
			}
		}
	}

	public int xd44988f225497f3a
	{
		get
		{
			return x35a5073ffeb125c5;
		}
		set
		{
			if (x761445bca289bae4 + value > x4a498a651d07aefe.Length)
			{
				x35a5073ffeb125c5 = x4a498a651d07aefe.Length - x761445bca289bae4;
			}
			else
			{
				x35a5073ffeb125c5 = value;
			}
		}
	}

	public string x4a498a651d07aefe
	{
		get
		{
			return xd308f2330afde345;
		}
		set
		{
			xd308f2330afde345 = value;
		}
	}

	public xba029d7f4894b421(string str)
	{
		if (str == null)
		{
			throw new ArgumentNullException("str");
		}
		xd308f2330afde345 = str;
		x761445bca289bae4 = 0;
		xd44988f225497f3a = str.Length;
	}

	public override string ToString()
	{
		return xd308f2330afde345.Substring(x9ba6e2d568cd6468, x35a5073ffeb125c5);
	}

	public char x850d183921cdec0a(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= xd44988f225497f3a)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return xd308f2330afde345[x761445bca289bae4 + xc0c4c459c6ccbd00];
	}

	public void xcf25c2b572db7a4e(int x936f064216e4f75d)
	{
		x761445bca289bae4 += x936f064216e4f75d;
	}

	public void x003f89d2b0039c61(int x936f064216e4f75d)
	{
		xef557afa150f7cb2 -= x936f064216e4f75d;
	}

	public xba029d7f4894b421 x8b61531c8ea35b85()
	{
		return (xba029d7f4894b421)MemberwiseClone();
	}
}
