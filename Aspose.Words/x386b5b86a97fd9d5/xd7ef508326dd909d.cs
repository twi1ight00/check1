using System;
using System.Reflection;
using System.Text;
using x6c95d9cf46ff5f25;

namespace x386b5b86a97fd9d5;

[DefaultMember("Item")]
internal class xd7ef508326dd909d
{
	private const int _x9c038637e293d841 = 16;

	private byte[] _xf8b54ce7724a27f2;

	private int _x0ceec69a97f73617;

	public int xe7dd8ddc8b289241
	{
		get
		{
			return _xf8b54ce7724a27f2.Length;
		}
		set
		{
			if (value == _xf8b54ce7724a27f2.Length)
			{
				return;
			}
			if (value < _x0ceec69a97f73617)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			if (value > 0)
			{
				byte[] array = new byte[value];
				if (_x0ceec69a97f73617 > 0)
				{
					Array.Copy(_xf8b54ce7724a27f2, 0, array, 0, _x0ceec69a97f73617);
				}
				_xf8b54ce7724a27f2 = array;
			}
			else
			{
				_xf8b54ce7724a27f2 = new byte[16];
			}
		}
	}

	public int xd44988f225497f3a => _x0ceec69a97f73617;

	public bool x27fd830979b477ac => false;

	public bool xdf3d8f13acb97655 => false;

	public bool x4fc099782caec3f0 => false;

	public object x311a70556a8e6e5e => this;

	public byte xe6d4b1b411ed94b5
	{
		get
		{
			if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= _x0ceec69a97f73617)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return _xf8b54ce7724a27f2[xc0c4c459c6ccbd00];
		}
		set
		{
			if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= _x0ceec69a97f73617)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			_xf8b54ce7724a27f2[xc0c4c459c6ccbd00] = value;
		}
	}

	public xd7ef508326dd909d()
	{
		_xf8b54ce7724a27f2 = new byte[16];
	}

	public xd7ef508326dd909d(int capacity)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		_xf8b54ce7724a27f2 = new byte[capacity];
	}

	public int xd6b6ed77479ef68c(byte xbcea506a33cf9111)
	{
		if (_x0ceec69a97f73617 == _xf8b54ce7724a27f2.Length)
		{
			x258c9e9203a01f61(_x0ceec69a97f73617 + 1);
		}
		_xf8b54ce7724a27f2[_x0ceec69a97f73617] = xbcea506a33cf9111;
		return _x0ceec69a97f73617++;
	}

	public int x792b6f092cbf4bb1(int xc0c4c459c6ccbd00, int x10f4d88af727adbc, byte xbcea506a33cf9111)
	{
		if (xc0c4c459c6ccbd00 < 0 || x10f4d88af727adbc < 0)
		{
			throw new ArgumentOutOfRangeException((xc0c4c459c6ccbd00 < 0) ? "index" : "count");
		}
		if (_x0ceec69a97f73617 - xc0c4c459c6ccbd00 < x10f4d88af727adbc)
		{
			throw new ArgumentException("index and count");
		}
		return xcd4bd3abd72ff2da.x792b6f092cbf4bb1(_xf8b54ce7724a27f2, xc0c4c459c6ccbd00, x10f4d88af727adbc, xbcea506a33cf9111);
	}

	public int x792b6f092cbf4bb1(byte xbcea506a33cf9111)
	{
		return x792b6f092cbf4bb1(0, xd44988f225497f3a, xbcea506a33cf9111);
	}

	public void xa9d636b00ff486b7()
	{
		Array.Clear(_xf8b54ce7724a27f2, 0, _x0ceec69a97f73617);
		_x0ceec69a97f73617 = 0;
	}

	public xd7ef508326dd909d x8b61531c8ea35b85()
	{
		xd7ef508326dd909d xd7ef508326dd909d2 = new xd7ef508326dd909d(_x0ceec69a97f73617);
		xd7ef508326dd909d2._x0ceec69a97f73617 = _x0ceec69a97f73617;
		Array.Copy(_xf8b54ce7724a27f2, 0, xd7ef508326dd909d2._xf8b54ce7724a27f2, 0, _x0ceec69a97f73617);
		return xd7ef508326dd909d2;
	}

	public bool x263d579af1d0d43f(byte xccb63ca5f63dc470)
	{
		for (int i = 0; i < _x0ceec69a97f73617; i++)
		{
			if (xccb63ca5f63dc470 == _xf8b54ce7724a27f2[i])
			{
				return true;
			}
		}
		return false;
	}

	private void x258c9e9203a01f61(int xd088075e67f6ea91)
	{
		if (_xf8b54ce7724a27f2.Length < xd088075e67f6ea91)
		{
			int num = ((_xf8b54ce7724a27f2.Length == 0) ? 16 : (_xf8b54ce7724a27f2.Length * 2));
			if (num < xd088075e67f6ea91)
			{
				num = xd088075e67f6ea91;
			}
			xe7dd8ddc8b289241 = num;
		}
	}

	public int x2ee5ad3d826ed0fe(byte xbcea506a33cf9111)
	{
		return Array.IndexOf(_xf8b54ce7724a27f2, xbcea506a33cf9111, 0, _x0ceec69a97f73617);
	}

	public int x2ee5ad3d826ed0fe(byte xbcea506a33cf9111, int xd4f974c06ffa392b)
	{
		if (xd4f974c06ffa392b > _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return Array.IndexOf(_xf8b54ce7724a27f2, xbcea506a33cf9111, xd4f974c06ffa392b, _x0ceec69a97f73617 - xd4f974c06ffa392b);
	}

	public int x2ee5ad3d826ed0fe(byte xbcea506a33cf9111, int xd4f974c06ffa392b, int x10f4d88af727adbc)
	{
		if (xd4f974c06ffa392b + x10f4d88af727adbc > _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		return Array.IndexOf(_xf8b54ce7724a27f2, xbcea506a33cf9111, xd4f974c06ffa392b, x10f4d88af727adbc);
	}

	public void xef23aa45e7612fdd(int xc0c4c459c6ccbd00, byte xbcea506a33cf9111)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 > _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (_x0ceec69a97f73617 == _xf8b54ce7724a27f2.Length)
		{
			x258c9e9203a01f61(_x0ceec69a97f73617 + 1);
		}
		if (xc0c4c459c6ccbd00 < _x0ceec69a97f73617)
		{
			Array.Copy(_xf8b54ce7724a27f2, xc0c4c459c6ccbd00, _xf8b54ce7724a27f2, xc0c4c459c6ccbd00 + 1, _x0ceec69a97f73617 - xc0c4c459c6ccbd00);
		}
		_xf8b54ce7724a27f2[xc0c4c459c6ccbd00] = xbcea506a33cf9111;
		_x0ceec69a97f73617++;
	}

	public int x3b20b85bcd955f42(byte xbcea506a33cf9111)
	{
		return x3b20b85bcd955f42(xbcea506a33cf9111, _x0ceec69a97f73617 - 1, _x0ceec69a97f73617);
	}

	public int x3b20b85bcd955f42(byte xbcea506a33cf9111, int xd4f974c06ffa392b)
	{
		if (xd4f974c06ffa392b >= _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return x3b20b85bcd955f42(xbcea506a33cf9111, xd4f974c06ffa392b, xd4f974c06ffa392b + 1);
	}

	public int x3b20b85bcd955f42(byte xbcea506a33cf9111, int xd4f974c06ffa392b, int x10f4d88af727adbc)
	{
		if (_x0ceec69a97f73617 == 0)
		{
			return -1;
		}
		if (xd4f974c06ffa392b < 0 || x10f4d88af727adbc < 0)
		{
			throw new ArgumentOutOfRangeException((xd4f974c06ffa392b < 0) ? "startIndex" : "count");
		}
		if (xd4f974c06ffa392b >= _x0ceec69a97f73617 || x10f4d88af727adbc > xd4f974c06ffa392b + 1)
		{
			throw new ArgumentOutOfRangeException((xd4f974c06ffa392b >= _x0ceec69a97f73617) ? "startIndex" : "count");
		}
		return Array.LastIndexOf(_xf8b54ce7724a27f2, xbcea506a33cf9111, xd4f974c06ffa392b, x10f4d88af727adbc);
	}

	public void x52b190e626f65140(byte xa59bff7708de3a18)
	{
		int num = x2ee5ad3d826ed0fe(xa59bff7708de3a18);
		if (num >= 0)
		{
			x7121e9e177952651(num);
		}
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
			Array.Copy(_xf8b54ce7724a27f2, xc0c4c459c6ccbd00 + 1, _xf8b54ce7724a27f2, xc0c4c459c6ccbd00, _x0ceec69a97f73617 - xc0c4c459c6ccbd00);
		}
		_xf8b54ce7724a27f2[_x0ceec69a97f73617] = 0;
	}

	public void xa79151ec088f1e4d(int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		if (xc0c4c459c6ccbd00 < 0 || x10f4d88af727adbc < 0)
		{
			throw new ArgumentOutOfRangeException((xc0c4c459c6ccbd00 < 0) ? "index" : "count");
		}
		if (_x0ceec69a97f73617 - xc0c4c459c6ccbd00 < x10f4d88af727adbc)
		{
			throw new ArgumentException("index and count");
		}
		if (x10f4d88af727adbc > 0)
		{
			int num = _x0ceec69a97f73617;
			_x0ceec69a97f73617 -= x10f4d88af727adbc;
			if (xc0c4c459c6ccbd00 < _x0ceec69a97f73617)
			{
				Array.Copy(_xf8b54ce7724a27f2, xc0c4c459c6ccbd00 + x10f4d88af727adbc, _xf8b54ce7724a27f2, xc0c4c459c6ccbd00, _x0ceec69a97f73617 - xc0c4c459c6ccbd00);
			}
			while (num > _x0ceec69a97f73617)
			{
				_xf8b54ce7724a27f2[--num] = 0;
			}
		}
	}

	public void xdc59939bf9bab11b()
	{
		xdc59939bf9bab11b(0, xd44988f225497f3a);
	}

	public void xdc59939bf9bab11b(int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		if (xc0c4c459c6ccbd00 < 0 || x10f4d88af727adbc < 0)
		{
			throw new ArgumentOutOfRangeException((xc0c4c459c6ccbd00 < 0) ? "index" : "count");
		}
		if (_x0ceec69a97f73617 - xc0c4c459c6ccbd00 < x10f4d88af727adbc)
		{
			throw new ArgumentException("index and count");
		}
		Array.Reverse(_xf8b54ce7724a27f2, xc0c4c459c6ccbd00, x10f4d88af727adbc);
	}

	public void xee9aac96ed24c7f9()
	{
		xee9aac96ed24c7f9(0, xd44988f225497f3a);
	}

	public void xee9aac96ed24c7f9(int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		if (xc0c4c459c6ccbd00 < 0 || x10f4d88af727adbc < 0)
		{
			throw new ArgumentOutOfRangeException((xc0c4c459c6ccbd00 < 0) ? "index" : "count");
		}
		if (_x0ceec69a97f73617 - xc0c4c459c6ccbd00 < x10f4d88af727adbc)
		{
			throw new ArgumentException("index and count");
		}
		Array.Sort(_xf8b54ce7724a27f2, xc0c4c459c6ccbd00, x10f4d88af727adbc);
	}

	public byte[] x543681a74a4a8026()
	{
		byte[] array = new byte[_x0ceec69a97f73617];
		Array.Copy(_xf8b54ce7724a27f2, 0, array, 0, _x0ceec69a97f73617);
		return array;
	}

	public void x9fba28333f1b9fd6()
	{
		xe7dd8ddc8b289241 = _x0ceec69a97f73617;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < xd44988f225497f3a; i++)
		{
			stringBuilder.Append(this.get_xe6d4b1b411ed94b5(i));
			if (i < xd44988f225497f3a - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}
}
