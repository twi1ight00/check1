using System;
using System.Collections;

namespace x6b8130194ad714f7;

internal class x9725f23333d8c1d6
{
	private ArrayList x078aaeafd3c14275;

	private int x35a5073ffeb125c5;

	private int x9ba6e2d568cd6468;

	public object x5bcf371cf6e8144d => xe84e6ff66aac2a0e(0);

	public bool x97fbc3cdb3cadcc8 => xd44988f225497f3a > 0;

	public object xc3806d802c319dc2 => xe84e6ff66aac2a0e(xd44988f225497f3a - 1);

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
			if (x761445bca289bae4 + value > xd4e45a1fccac675d.Count)
			{
				x35a5073ffeb125c5 = xd4e45a1fccac675d.Count - x761445bca289bae4;
			}
			else
			{
				x35a5073ffeb125c5 = value;
			}
		}
	}

	public ArrayList xd4e45a1fccac675d
	{
		get
		{
			return x078aaeafd3c14275;
		}
		set
		{
			x078aaeafd3c14275 = value;
		}
	}

	public x9725f23333d8c1d6(ArrayList array)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		x078aaeafd3c14275 = array;
		x761445bca289bae4 = 0;
		xd44988f225497f3a = array.Count;
	}

	public object xe84e6ff66aac2a0e(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= xd44988f225497f3a)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return x078aaeafd3c14275[x761445bca289bae4 + xc0c4c459c6ccbd00];
	}

	public void xcf25c2b572db7a4e(int x936f064216e4f75d)
	{
		x761445bca289bae4 += x936f064216e4f75d;
	}

	public void x003f89d2b0039c61(int x936f064216e4f75d)
	{
		xef557afa150f7cb2 -= x936f064216e4f75d;
	}

	public x9725f23333d8c1d6 x8b61531c8ea35b85()
	{
		return (x9725f23333d8c1d6)MemberwiseClone();
	}
}
