using System;
using System.IO;
using x5f3520a4b31ea90f;

namespace x4f4df92b75ba3b67;

internal class xdb975c70fd3d8ff7 : x8fbf0a5e230a8cae
{
	private readonly x005b3497e4ca1670 x6270feb36bdcb1ba;

	private readonly byte[] xe03fe6f8c5ec4071;

	public xdb975c70fd3d8ff7(Stream outputStream, byte[] key)
		: this(outputStream, key, 0, key.Length)
	{
	}

	public xdb975c70fd3d8ff7(Stream outputStream, byte[] key, int offset, int length)
		: base(outputStream)
	{
		xe03fe6f8c5ec4071 = new byte[1];
		x6270feb36bdcb1ba = new x005b3497e4ca1670();
		x6270feb36bdcb1ba.xb04c56f3a10310d3(key, offset, length);
	}

	public override void Write(byte[] b, int offset, int length)
	{
		byte[] array = new byte[Math.Min(length, 4192)];
		while (length > 0)
		{
			int num = Math.Min(length, array.Length);
			x6270feb36bdcb1ba.x246b032720dd4c0d(b, offset, num, array, 0);
			x6169576fb3c218d3.Write(array, 0, num);
			length -= num;
			offset += num;
		}
	}

	public override void WriteByte(byte value)
	{
		xe03fe6f8c5ec4071[0] = value;
		Write(xe03fe6f8c5ec4071, 0, 1);
	}
}
