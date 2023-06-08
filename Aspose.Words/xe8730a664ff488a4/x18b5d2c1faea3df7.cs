using System;
using System.IO;

namespace xe8730a664ff488a4;

internal class x18b5d2c1faea3df7 : Stream, IDisposable
{
	private static readonly long x99330b0f8ee2dedd = -99L;

	private Stream _xd9df0dae0e115171;

	private x41fcadcc0506e331 _x5e4059a15fb5fca5;

	private long _x8bdaf29470ac6e06 = -99L;

	private bool _x879e17d89d89eda8;

	public long x74f037c714389a81 => _x5e4059a15fb5fca5.x6d0b3ba2ab87aa92;

	public int x4267aa67a0bb35b8 => _x5e4059a15fb5fca5.x882f8c1265bb8e85;

	public bool xef9acb5ee9b79b57
	{
		get
		{
			return _x879e17d89d89eda8;
		}
		set
		{
			_x879e17d89d89eda8 = value;
		}
	}

	public override bool CanRead => _xd9df0dae0e115171.CanRead;

	public override bool CanSeek => _xd9df0dae0e115171.CanSeek;

	public override bool CanWrite => _xd9df0dae0e115171.CanWrite;

	public override long Length
	{
		get
		{
			if (_x8bdaf29470ac6e06 == x99330b0f8ee2dedd)
			{
				return _xd9df0dae0e115171.Length;
			}
			return _x8bdaf29470ac6e06;
		}
	}

	public override long Position
	{
		get
		{
			return _x5e4059a15fb5fca5.x6d0b3ba2ab87aa92;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public x18b5d2c1faea3df7(Stream stream)
		: this(leaveOpen: true, x99330b0f8ee2dedd, stream)
	{
	}

	public x18b5d2c1faea3df7(Stream stream, bool leaveOpen)
		: this(leaveOpen, x99330b0f8ee2dedd, stream)
	{
	}

	public x18b5d2c1faea3df7(Stream stream, long length)
		: this(leaveOpen: true, length, stream)
	{
		if (length < 0)
		{
			throw new ArgumentException("length");
		}
	}

	public x18b5d2c1faea3df7(Stream stream, long length, bool leaveOpen)
		: this(leaveOpen, length, stream)
	{
		if (length < 0)
		{
			throw new ArgumentException("length");
		}
	}

	private x18b5d2c1faea3df7(bool leaveOpen, long length, Stream stream)
	{
		_xd9df0dae0e115171 = stream;
		_x5e4059a15fb5fca5 = new x41fcadcc0506e331();
		_x8bdaf29470ac6e06 = length;
		_x879e17d89d89eda8 = leaveOpen;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int count2 = count;
		if (_x8bdaf29470ac6e06 != x99330b0f8ee2dedd)
		{
			if (_x5e4059a15fb5fca5.x6d0b3ba2ab87aa92 >= _x8bdaf29470ac6e06)
			{
				return 0;
			}
			long num = _x8bdaf29470ac6e06 - _x5e4059a15fb5fca5.x6d0b3ba2ab87aa92;
			if (num < count)
			{
				count2 = (int)num;
			}
		}
		int num2 = _xd9df0dae0e115171.Read(buffer, offset, count2);
		if (num2 > 0)
		{
			_x5e4059a15fb5fca5.x8ebfa48686a2fc0c(buffer, offset, num2);
		}
		return num2;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (count > 0)
		{
			_x5e4059a15fb5fca5.x8ebfa48686a2fc0c(buffer, offset, count);
		}
		_xd9df0dae0e115171.Write(buffer, offset, count);
	}

	public override void Flush()
	{
		_xd9df0dae0e115171.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	private void x4852c3ca92ab200a()
	{
		Close();
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4852c3ca92ab200a
		this.x4852c3ca92ab200a();
	}

	public override void Close()
	{
		base.Close();
		if (!_x879e17d89d89eda8)
		{
			_xd9df0dae0e115171.Close();
		}
	}
}
