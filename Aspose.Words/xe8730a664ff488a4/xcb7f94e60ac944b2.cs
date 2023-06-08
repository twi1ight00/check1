using System;
using System.IO;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class xcb7f94e60ac944b2 : Stream, IDisposable
{
	internal xd9b65f15958fe264 _x0e1a954073ecb077;

	private bool _x0e75cd3866dbb930;

	public virtual x89a5712fad624df9 FlushMode
	{
		get
		{
			return _x0e1a954073ecb077._xe4f0f2bc0db45668;
		}
		set
		{
			if (_x0e75cd3866dbb930)
			{
				throw new ObjectDisposedException("ZlibStream");
			}
			_x0e1a954073ecb077._xe4f0f2bc0db45668 = value;
		}
	}

	public int x648114bcf1499890
	{
		get
		{
			return _x0e1a954073ecb077._xb85b7645153fc718;
		}
		set
		{
			if (_x0e75cd3866dbb930)
			{
				throw new ObjectDisposedException("ZlibStream");
			}
			if (_x0e1a954073ecb077._x0cf41e0b23a9f822 != null)
			{
				throw new xd449352d3501c52f("The working buffer is already set.");
			}
			if (value < 128)
			{
				throw new xd449352d3501c52f($"Don't be silly. {value} bytes?? Use a bigger buffer.");
			}
			_x0e1a954073ecb077._xb85b7645153fc718 = value;
		}
	}

	public virtual long TotalIn => _x0e1a954073ecb077._x8cfbc105c29e356f.x4898fcfa8d5dd0b2;

	public virtual long TotalOut => _x0e1a954073ecb077._x8cfbc105c29e356f.x8d79d7f35d1df930;

	public override bool CanRead
	{
		get
		{
			if (_x0e75cd3866dbb930)
			{
				throw new ObjectDisposedException("ZlibStream");
			}
			return _x0e1a954073ecb077._xcf18e5243f8d5fd3.CanRead;
		}
	}

	public override bool CanSeek => false;

	public override bool CanWrite
	{
		get
		{
			if (_x0e75cd3866dbb930)
			{
				throw new ObjectDisposedException("ZlibStream");
			}
			return _x0e1a954073ecb077._xcf18e5243f8d5fd3.CanWrite;
		}
	}

	public override long Length
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override long Position
	{
		get
		{
			if (_x0e1a954073ecb077._x9f93aa7609d09c95 == xd9b65f15958fe264.xed4e6d4a5d08e817.x5aa326f374b3d0ef)
			{
				return _x0e1a954073ecb077._x8cfbc105c29e356f.x8d79d7f35d1df930;
			}
			if (_x0e1a954073ecb077._x9f93aa7609d09c95 == xd9b65f15958fe264.xed4e6d4a5d08e817.xf86de1bd2f396938)
			{
				return _x0e1a954073ecb077._x8cfbc105c29e356f.x4898fcfa8d5dd0b2;
			}
			return 0L;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public xcb7f94e60ac944b2(Stream stream, x1f770018e5e12789 mode)
		: this(stream, mode, x0bf508c6214e694f.xb9715d2f06b63cf0, leaveOpen: false)
	{
	}

	public xcb7f94e60ac944b2(Stream stream, x1f770018e5e12789 mode, x0bf508c6214e694f level)
		: this(stream, mode, level, leaveOpen: false)
	{
	}

	public xcb7f94e60ac944b2(Stream stream, x1f770018e5e12789 mode, bool leaveOpen)
		: this(stream, mode, x0bf508c6214e694f.xb9715d2f06b63cf0, leaveOpen)
	{
	}

	public xcb7f94e60ac944b2(Stream stream, x1f770018e5e12789 mode, x0bf508c6214e694f level, bool leaveOpen)
	{
		_x0e1a954073ecb077 = new xd9b65f15958fe264(stream, mode, level, x48d9147101a26c84.xee037a342a21cbfc, leaveOpen);
	}

	public override void Close()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected new virtual void Dispose(bool disposing)
	{
		if (!_x0e75cd3866dbb930)
		{
			if (disposing && _x0e1a954073ecb077 != null)
			{
				_x0e1a954073ecb077.Close();
			}
			_x0e75cd3866dbb930 = true;
		}
	}

	public override void Flush()
	{
		if (_x0e75cd3866dbb930)
		{
			throw new ObjectDisposedException("ZlibStream");
		}
		_x0e1a954073ecb077.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (_x0e75cd3866dbb930)
		{
			throw new ObjectDisposedException("ZlibStream");
		}
		return _x0e1a954073ecb077.Read(buffer, offset, count);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (_x0e75cd3866dbb930)
		{
			throw new ObjectDisposedException("ZlibStream");
		}
		_x0e1a954073ecb077.Write(buffer, offset, count);
	}

	public static byte[] x0e394068a594d384(string xe4115acdf4fbfccc)
	{
		return xd9b65f15958fe264.x0e394068a594d384(xe4115acdf4fbfccc, typeof(xcb7f94e60ac944b2));
	}

	public static byte[] xe760fb5661ebe89a(byte[] xe7ebe10fa44d8d49)
	{
		return xd9b65f15958fe264.xe760fb5661ebe89a(xe7ebe10fa44d8d49, typeof(xcb7f94e60ac944b2));
	}

	public static string x3389f8cbd9a4a6e2(byte[] x933b2a3444ec3bba)
	{
		return xd9b65f15958fe264.x3389f8cbd9a4a6e2(x933b2a3444ec3bba, typeof(xcb7f94e60ac944b2));
	}

	public static byte[] xea29da571ea64fa4(byte[] x933b2a3444ec3bba)
	{
		return xd9b65f15958fe264.xea29da571ea64fa4(x933b2a3444ec3bba, typeof(xcb7f94e60ac944b2));
	}

	private void x4852c3ca92ab200a()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4852c3ca92ab200a
		this.x4852c3ca92ab200a();
	}
}
