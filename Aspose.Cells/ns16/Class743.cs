using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns16;

internal class Class743
{
	private uint[] uint_0 = new uint[3] { 305419896u, 591751049u, 878082192u };

	private Class741 class741_0 = new Class741();

	private Class743()
	{
	}

	public static Class743 smethod_0(string string_0)
	{
		Class743 @class = new Class743();
		if (string_0 == null)
		{
			throw new Exception2("This entry requires a password.");
		}
		@class.method_3(string_0);
		return @class;
	}

	public static Class743 smethod_1(string string_0, Class744 class744_0)
	{
		Stream stream_ = class744_0.stream_0;
		class744_0.byte_3 = new byte[12];
		byte[] byte_ = class744_0.byte_3;
		Class743 @class = new Class743();
		if (string_0 == null)
		{
			throw new Exception2("This entry requires a password.");
		}
		@class.method_3(string_0);
		Class744.smethod_9(stream_, byte_);
		byte[] array = @class.method_1(byte_, byte_.Length);
		if (array[11] != (byte)((class744_0.int_2 >> 24) & 0xFF))
		{
			if ((class744_0.short_6 & 8) != 8)
			{
				throw new Exception2("The password did not match.");
			}
			if (array[11] != (byte)((class744_0.int_1 >> 8) & 0xFF))
			{
				throw new Exception2("The password did not match.");
			}
		}
		return @class;
	}

	[SpecialName]
	private byte method_0()
	{
		ushort num = (ushort)((ushort)(uint_0[2] & 0xFFFFu) | 2u);
		return (byte)(num * (num ^ 1) >> 8);
	}

	public byte[] method_1(byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("cipherText");
		}
		if (int_0 > byte_0.Length)
		{
			throw new ArgumentOutOfRangeException("length", "Bad length during Decryption: the length parameter must be smaller than or equal to the size of the destination array.");
		}
		byte[] array = new byte[int_0];
		for (int i = 0; i < int_0; i++)
		{
			byte b = (byte)(byte_0[i] ^ method_0());
			method_4(b);
			array[i] = b;
		}
		return array;
	}

	public byte[] method_2(byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("plaintext");
		}
		if (int_0 > byte_0.Length)
		{
			throw new ArgumentOutOfRangeException("length", "Bad length during Encryption: The length parameter must be smaller than or equal to the size of the destination array.");
		}
		byte[] array = new byte[int_0];
		for (int i = 0; i < int_0; i++)
		{
			byte byte_ = byte_0[i];
			array[i] = (byte)(byte_0[i] ^ method_0());
			method_4(byte_);
		}
		return array;
	}

	public void method_3(string string_0)
	{
		byte[] array = Class742.smethod_3(string_0);
		for (int i = 0; i < string_0.Length; i++)
		{
			method_4(array[i]);
		}
	}

	private void method_4(byte byte_0)
	{
		uint_0[0] = (uint)class741_0.method_4((int)uint_0[0], byte_0);
		uint_0[1] = uint_0[1] + (byte)uint_0[0];
		uint_0[1] = uint_0[1] * 134775813 + 1;
		uint_0[2] = (uint)class741_0.method_4((int)uint_0[2], (byte)(uint_0[1] >> 24));
	}
}
