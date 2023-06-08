using System;
using System.IO;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class x853ddd714d7aaa13 : Stream
{
	private Stream _xe4115acdf4fbfccc;

	private long _xa289f275e6a0e493;

	private long _x73ff96c61b2f324f;

	public long x1c86f1bc0157a1b8 => _xa289f275e6a0e493;

	public override bool CanRead => _xe4115acdf4fbfccc.CanRead;

	public override bool CanSeek => _xe4115acdf4fbfccc.CanSeek;

	public override bool CanWrite => _xe4115acdf4fbfccc.CanWrite;

	public override long Length => _xe4115acdf4fbfccc.Length;

	public override long Position
	{
		get
		{
			return _xe4115acdf4fbfccc.Position;
		}
		set
		{
			_xe4115acdf4fbfccc.Seek(value, SeekOrigin.Begin);
		}
	}

	public x853ddd714d7aaa13(Stream s)
	{
		_xe4115acdf4fbfccc = s;
	}

	public void xfaab97dd0218026f(long xf7845a6fecd5afc3)
	{
		_xa289f275e6a0e493 -= xf7845a6fecd5afc3;
		if (_xa289f275e6a0e493 < 0)
		{
			throw new InvalidOperationException();
		}
		if (_xe4115acdf4fbfccc is x853ddd714d7aaa13)
		{
			((x853ddd714d7aaa13)_xe4115acdf4fbfccc).xfaab97dd0218026f(xf7845a6fecd5afc3);
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = _xe4115acdf4fbfccc.Read(buffer, offset, count);
		_x73ff96c61b2f324f += num;
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		_xe4115acdf4fbfccc.Write(buffer, offset, count);
		_xa289f275e6a0e493 += count;
	}

	public override void Flush()
	{
		_xe4115acdf4fbfccc.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return _xe4115acdf4fbfccc.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		_xe4115acdf4fbfccc.SetLength(value);
	}
}
