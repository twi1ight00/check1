using System;
using System.IO;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class xc65b5343382bdcf8 : Stream
{
	private xed28787af62b195b _x39d921119affa3f4;

	private Stream _xe4115acdf4fbfccc;

	private x0c752eb8af884509 _xa4aa8b4150b11435;

	public override bool CanRead => _xa4aa8b4150b11435 == x0c752eb8af884509.xcc381ffa3ede662f;

	public override bool CanSeek => false;

	public override bool CanWrite => _xa4aa8b4150b11435 == x0c752eb8af884509.x246b032720dd4c0d;

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
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public xc65b5343382bdcf8(Stream s, xed28787af62b195b cipher, x0c752eb8af884509 mode)
	{
		_x39d921119affa3f4 = cipher;
		_xe4115acdf4fbfccc = s;
		_xa4aa8b4150b11435 = mode;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (_xa4aa8b4150b11435 == x0c752eb8af884509.x246b032720dd4c0d)
		{
			throw new NotImplementedException();
		}
		byte[] array = new byte[count];
		int num = _xe4115acdf4fbfccc.Read(array, 0, count);
		byte[] array2 = _x39d921119affa3f4.xa9083cd230b926ce(array, num);
		for (int i = 0; i < num; i++)
		{
			buffer[offset + i] = array2[i];
		}
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (_xa4aa8b4150b11435 == x0c752eb8af884509.xcc381ffa3ede662f)
		{
			throw new NotImplementedException();
		}
		if (count == 0)
		{
			return;
		}
		byte[] array;
		if (offset != 0)
		{
			array = new byte[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = buffer[offset + i];
			}
		}
		else
		{
			array = buffer;
		}
		byte[] array2 = _x39d921119affa3f4.x510fa7633d236c28(array, count);
		_xe4115acdf4fbfccc.Write(array2, 0, array2.Length);
	}

	public override void Flush()
	{
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}
}
