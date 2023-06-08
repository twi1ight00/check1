using System;
using System.Text;

namespace x6c95d9cf46ff5f25;

internal class x05426b792478523c
{
	private const int _x9c038637e293d841 = 16;

	private float[] _xf8b54ce7724a27f2;

	private int _x0ceec69a97f73617;

	public virtual int Capacity
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
				float[] array = new float[value];
				if (_x0ceec69a97f73617 > 0)
				{
					Array.Copy(_xf8b54ce7724a27f2, 0, array, 0, _x0ceec69a97f73617);
				}
				_xf8b54ce7724a27f2 = array;
			}
			else
			{
				_xf8b54ce7724a27f2 = new float[16];
			}
		}
	}

	public virtual int Count => _x0ceec69a97f73617;

	public virtual bool IsFixedSize => false;

	public virtual bool IsReadOnly => false;

	public virtual bool IsSynchronized => false;

	public virtual object SyncRoot => this;

	public virtual float this[int index]
	{
		get
		{
			if (index < 0 || index >= _x0ceec69a97f73617)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return _xf8b54ce7724a27f2[index];
		}
		set
		{
			if (index < 0 || index >= _x0ceec69a97f73617)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			_xf8b54ce7724a27f2[index] = value;
		}
	}

	public x05426b792478523c()
	{
		_xf8b54ce7724a27f2 = new float[16];
	}

	public x05426b792478523c(int capacity)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		_xf8b54ce7724a27f2 = new float[capacity];
	}

	public virtual int Add(float value)
	{
		if (_x0ceec69a97f73617 == _xf8b54ce7724a27f2.Length)
		{
			x258c9e9203a01f61(_x0ceec69a97f73617 + 1);
		}
		_xf8b54ce7724a27f2[_x0ceec69a97f73617] = value;
		return _x0ceec69a97f73617++;
	}

	public virtual float BinarySearch(int index, int count, float value)
	{
		if (index < 0 || count < 0)
		{
			throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
		}
		if (_x0ceec69a97f73617 - index < count)
		{
			throw new ArgumentException("index and count");
		}
		return xcd4bd3abd72ff2da.x792b6f092cbf4bb1(_xf8b54ce7724a27f2, index, count, value);
	}

	public virtual float BinarySearch(float value)
	{
		return BinarySearch(0, Count, value);
	}

	public virtual void Clear()
	{
		Array.Clear(_xf8b54ce7724a27f2, 0, _x0ceec69a97f73617);
		_x0ceec69a97f73617 = 0;
	}

	public virtual x05426b792478523c Clone()
	{
		x05426b792478523c x05426b792478523c2 = new x05426b792478523c(_x0ceec69a97f73617);
		x05426b792478523c2._x0ceec69a97f73617 = _x0ceec69a97f73617;
		Array.Copy(_xf8b54ce7724a27f2, 0, x05426b792478523c2._xf8b54ce7724a27f2, 0, _x0ceec69a97f73617);
		return x05426b792478523c2;
	}

	public virtual bool Contains(int item)
	{
		for (int i = 0; i < _x0ceec69a97f73617; i++)
		{
			if ((float)item == _xf8b54ce7724a27f2[i])
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
			Capacity = num;
		}
	}

	public virtual int IndexOf(float value)
	{
		return Array.IndexOf(_xf8b54ce7724a27f2, value, 0, _x0ceec69a97f73617);
	}

	public virtual int IndexOf(float value, int startIndex)
	{
		if (startIndex > _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return Array.IndexOf(_xf8b54ce7724a27f2, value, startIndex, _x0ceec69a97f73617 - startIndex);
	}

	public virtual int IndexOf(float value, int startIndex, int count)
	{
		if (startIndex + count > _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		return Array.IndexOf(_xf8b54ce7724a27f2, value, startIndex, count);
	}

	public virtual void Insert(int index, float value)
	{
		if (index < 0 || index > _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (_x0ceec69a97f73617 == _xf8b54ce7724a27f2.Length)
		{
			x258c9e9203a01f61(_x0ceec69a97f73617 + 1);
		}
		if (index < _x0ceec69a97f73617)
		{
			Array.Copy(_xf8b54ce7724a27f2, index, _xf8b54ce7724a27f2, index + 1, _x0ceec69a97f73617 - index);
		}
		_xf8b54ce7724a27f2[index] = value;
		_x0ceec69a97f73617++;
	}

	public virtual int LastIndexOf(float value)
	{
		return LastIndexOf(value, _x0ceec69a97f73617 - 1, _x0ceec69a97f73617);
	}

	public virtual int LastIndexOf(float value, int startIndex)
	{
		if (startIndex >= _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return LastIndexOf(value, startIndex, startIndex + 1);
	}

	public virtual int LastIndexOf(float value, int startIndex, int count)
	{
		if (_x0ceec69a97f73617 == 0)
		{
			return -1;
		}
		if (startIndex < 0 || count < 0)
		{
			throw new ArgumentOutOfRangeException((startIndex < 0) ? "startIndex" : "count");
		}
		if (startIndex >= _x0ceec69a97f73617 || count > startIndex + 1)
		{
			throw new ArgumentOutOfRangeException((startIndex >= _x0ceec69a97f73617) ? "startIndex" : "count");
		}
		return Array.LastIndexOf(_xf8b54ce7724a27f2, value, startIndex, count);
	}

	public virtual void Remove(float obj)
	{
		int num = IndexOf(obj);
		if (num >= 0)
		{
			RemoveAt(num);
		}
	}

	public virtual void RemoveAt(int index)
	{
		if (index < 0 || index >= _x0ceec69a97f73617)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		_x0ceec69a97f73617--;
		if (index < _x0ceec69a97f73617)
		{
			Array.Copy(_xf8b54ce7724a27f2, index + 1, _xf8b54ce7724a27f2, index, _x0ceec69a97f73617 - index);
		}
		_xf8b54ce7724a27f2[_x0ceec69a97f73617] = 0f;
	}

	public virtual void RemoveRange(int index, int count)
	{
		if (index < 0 || count < 0)
		{
			throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
		}
		if (_x0ceec69a97f73617 - index < count)
		{
			throw new ArgumentException("index and count");
		}
		if (count > 0)
		{
			int num = _x0ceec69a97f73617;
			_x0ceec69a97f73617 -= count;
			if (index < _x0ceec69a97f73617)
			{
				Array.Copy(_xf8b54ce7724a27f2, index + count, _xf8b54ce7724a27f2, index, _x0ceec69a97f73617 - index);
			}
			while (num > _x0ceec69a97f73617)
			{
				_xf8b54ce7724a27f2[--num] = 0f;
			}
		}
	}

	public virtual void Reverse()
	{
		Reverse(0, Count);
	}

	public virtual void Reverse(int index, int count)
	{
		if (index < 0 || count < 0)
		{
			throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
		}
		if (_x0ceec69a97f73617 - index < count)
		{
			throw new ArgumentException("index and count");
		}
		Array.Reverse(_xf8b54ce7724a27f2, index, count);
	}

	public virtual void Sort()
	{
		Sort(0, Count);
	}

	public virtual void Sort(int index, int count)
	{
		if (index < 0 || count < 0)
		{
			throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
		}
		if (_x0ceec69a97f73617 - index < count)
		{
			throw new ArgumentException("index and count");
		}
		Array.Sort(_xf8b54ce7724a27f2, index, count);
	}

	public virtual float[] ToArray()
	{
		float[] array = new float[_x0ceec69a97f73617];
		Array.Copy(_xf8b54ce7724a27f2, 0, array, 0, _x0ceec69a97f73617);
		return array;
	}

	public virtual void TrimToSize()
	{
		Capacity = _x0ceec69a97f73617;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < Count; i++)
		{
			stringBuilder.Append(this[i]);
			if (i < Count - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}
}
