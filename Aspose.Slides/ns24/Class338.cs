using System;

namespace ns24;

internal class Class338 : Class278
{
	private byte byte_0;

	private byte byte_1 = 1;

	private byte[] byte_2;

	public byte PitchFamily
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public byte Charset
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public byte[] Panose
	{
		get
		{
			return byte_2;
		}
		set
		{
			if (byte_2 != null && byte_2.Length != 0 && byte_2.Length != 10)
			{
				throw new ArgumentException("PANOSE array must be length of 0 or 10.");
			}
			byte_2 = value;
		}
	}

	public Class338()
	{
	}

	public Class338(Class338 fontData)
	{
		byte_1 = fontData.byte_1;
		byte_2 = fontData.byte_2;
		byte_0 = fontData.byte_0;
	}
}
