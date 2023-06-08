using System;
using System.Globalization;
using System.IO;
using System.Text;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class x007194a88446d25e : Stream, IDisposable
{
	public DateTime xf3d2608616d7641a = DateTime.MinValue;

	private int _x4f603acd9ecb4772;

	internal xd9b65f15958fe264 _x0e1a954073ecb077;

	private bool _x0e75cd3866dbb930;

	private bool _xbf6f8d776c9bc555;

	private string _xa39af5a82860a9a3;

	private string _x937e050c63ea1527;

	private int _x5e4059a15fb5fca5;

	internal static DateTime _x7b854fa04f4ba476 = new DateTime(1970, 1, 1, 0, 0, 0, CultureInfo.InvariantCulture.Calendar);

	internal static Encoding x995dd334075189ca = Encoding.GetEncoding("iso-8859-1");

	public string x937e050c63ea1527
	{
		get
		{
			return _x937e050c63ea1527;
		}
		set
		{
			if (_x0e75cd3866dbb930)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			_x937e050c63ea1527 = value;
		}
	}

	public string xa39af5a82860a9a3
	{
		get
		{
			return _xa39af5a82860a9a3;
		}
		set
		{
			if (_x0e75cd3866dbb930)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			_xa39af5a82860a9a3 = value;
			if (_xa39af5a82860a9a3 != null)
			{
				if (_xa39af5a82860a9a3.IndexOf("/") != -1)
				{
					_xa39af5a82860a9a3 = _xa39af5a82860a9a3.Replace("/", "\\");
				}
				if (_xa39af5a82860a9a3.EndsWith("\\"))
				{
					throw new InvalidOperationException("Illegal filename");
				}
				if (_xa39af5a82860a9a3.IndexOf("\\") != -1)
				{
					_xa39af5a82860a9a3 = Path.GetFileName(_xa39af5a82860a9a3);
				}
			}
		}
	}

	public int x5e4059a15fb5fca5 => _x5e4059a15fb5fca5;

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
				throw new ObjectDisposedException("GZipStream");
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
				throw new ObjectDisposedException("GZipStream");
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
				throw new ObjectDisposedException("GZipStream");
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
				throw new ObjectDisposedException("GZipStream");
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
				return _x0e1a954073ecb077._x8cfbc105c29e356f.x8d79d7f35d1df930 + _x4f603acd9ecb4772;
			}
			if (_x0e1a954073ecb077._x9f93aa7609d09c95 == xd9b65f15958fe264.xed4e6d4a5d08e817.xf86de1bd2f396938)
			{
				return _x0e1a954073ecb077._x8cfbc105c29e356f.x4898fcfa8d5dd0b2 + _x0e1a954073ecb077._x11a637a86a1dcdce;
			}
			return 0L;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public x007194a88446d25e(Stream stream, x1f770018e5e12789 mode)
		: this(stream, mode, x0bf508c6214e694f.xb9715d2f06b63cf0, leaveOpen: false)
	{
	}

	public x007194a88446d25e(Stream stream, x1f770018e5e12789 mode, x0bf508c6214e694f level)
		: this(stream, mode, level, leaveOpen: false)
	{
	}

	public x007194a88446d25e(Stream stream, x1f770018e5e12789 mode, bool leaveOpen)
		: this(stream, mode, x0bf508c6214e694f.xb9715d2f06b63cf0, leaveOpen)
	{
	}

	public x007194a88446d25e(Stream stream, x1f770018e5e12789 mode, x0bf508c6214e694f level, bool leaveOpen)
	{
		_x0e1a954073ecb077 = new xd9b65f15958fe264(stream, mode, level, x48d9147101a26c84.x8b7fb4cb1b65e3e5, leaveOpen);
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
				_x5e4059a15fb5fca5 = _x0e1a954073ecb077.x5e4059a15fb5fca5;
			}
			_x0e75cd3866dbb930 = true;
		}
	}

	public override void Flush()
	{
		if (_x0e75cd3866dbb930)
		{
			throw new ObjectDisposedException("GZipStream");
		}
		_x0e1a954073ecb077.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (_x0e75cd3866dbb930)
		{
			throw new ObjectDisposedException("GZipStream");
		}
		int result = _x0e1a954073ecb077.Read(buffer, offset, count);
		if (!_xbf6f8d776c9bc555)
		{
			_xbf6f8d776c9bc555 = true;
			xa39af5a82860a9a3 = _x0e1a954073ecb077._x2e1d6311f931bd7c;
			x937e050c63ea1527 = _x0e1a954073ecb077._x4ab9f4c3986f4f51;
		}
		return result;
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
			throw new ObjectDisposedException("GZipStream");
		}
		if (_x0e1a954073ecb077._x9f93aa7609d09c95 == xd9b65f15958fe264.xed4e6d4a5d08e817.x236cb0a4295bc034)
		{
			if (!_x0e1a954073ecb077._x9519345a4228ed90)
			{
				throw new InvalidOperationException();
			}
			_x4f603acd9ecb4772 = x772a6d80a26cc373();
		}
		_x0e1a954073ecb077.Write(buffer, offset, count);
	}

	private int x772a6d80a26cc373()
	{
		byte[] array = ((x937e050c63ea1527 == null) ? null : x995dd334075189ca.GetBytes(x937e050c63ea1527));
		byte[] array2 = ((xa39af5a82860a9a3 == null) ? null : x995dd334075189ca.GetBytes(xa39af5a82860a9a3));
		int num = ((x937e050c63ea1527 != null) ? (array.Length + 1) : 0);
		int num2 = ((xa39af5a82860a9a3 != null) ? (array2.Length + 1) : 0);
		int num3 = 10 + num + num2;
		byte[] array3 = new byte[num3];
		int num4 = 0;
		array3[num4++] = 31;
		array3[num4++] = 139;
		array3[num4++] = 8;
		byte b = 0;
		if (x937e050c63ea1527 != null)
		{
			b = (byte)(b ^ 0x10u);
		}
		if (xa39af5a82860a9a3 != null)
		{
			b = (byte)(b ^ 8u);
		}
		array3[num4++] = b;
		if (xf3d2608616d7641a == DateTime.MinValue)
		{
			xf3d2608616d7641a = DateTime.Now;
		}
		int value = (int)(xf3d2608616d7641a - _x7b854fa04f4ba476).TotalSeconds;
		Array.Copy(BitConverter.GetBytes(value), 0, array3, num4, 4);
		num4 += 4;
		array3[num4++] = 0;
		array3[num4++] = byte.MaxValue;
		if (num2 != 0)
		{
			Array.Copy(array2, 0, array3, num4, num2 - 1);
			num4 += num2 - 1;
			array3[num4++] = 0;
		}
		if (num != 0)
		{
			Array.Copy(array, 0, array3, num4, num - 1);
			num4 += num - 1;
			array3[num4++] = 0;
		}
		_x0e1a954073ecb077._xcf18e5243f8d5fd3.Write(array3, 0, array3.Length);
		return array3.Length;
	}

	public static byte[] x0e394068a594d384(string xe4115acdf4fbfccc)
	{
		return xd9b65f15958fe264.x0e394068a594d384(xe4115acdf4fbfccc, typeof(x007194a88446d25e));
	}

	public static byte[] xe760fb5661ebe89a(byte[] xe7ebe10fa44d8d49)
	{
		return xd9b65f15958fe264.xe760fb5661ebe89a(xe7ebe10fa44d8d49, typeof(x007194a88446d25e));
	}

	public static string x3389f8cbd9a4a6e2(byte[] x933b2a3444ec3bba)
	{
		return xd9b65f15958fe264.x3389f8cbd9a4a6e2(x933b2a3444ec3bba, typeof(x007194a88446d25e));
	}

	public static byte[] xea29da571ea64fa4(byte[] x933b2a3444ec3bba)
	{
		return xd9b65f15958fe264.xea29da571ea64fa4(x933b2a3444ec3bba, typeof(x007194a88446d25e));
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
