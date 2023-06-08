using System;
using System.IO;

namespace ns276;

internal class Class6750
{
	private uint[] uint_0 = new uint[3] { 305419896u, 591751049u, 878082192u };

	private Class6740 class6740_0 = new Class6740();

	private byte MagicByte
	{
		get
		{
			ushort num = (ushort)((ushort)(uint_0[2] & 0xFFFFu) | 2u);
			return (byte)(num * (num ^ 1) >> 8);
		}
	}

	private Class6750()
	{
	}

	public static Class6750 smethod_0(string password)
	{
		Class6750 @class = new Class6750();
		if (password == null)
		{
			throw new Exception62("This entry requires a password.");
		}
		@class.method_2(password);
		return @class;
	}

	public static Class6750 smethod_1(string password, Class6751 e)
	{
		Stream stream_ = e.stream_0;
		e.byte_3 = new byte[12];
		byte[] byte_ = e.byte_3;
		Class6750 @class = new Class6750();
		if (password == null)
		{
			throw new Exception62("This entry requires a password.");
		}
		@class.method_2(password);
		Class6751.smethod_7(stream_, byte_);
		byte[] array = @class.method_0(byte_, byte_.Length);
		if (array[11] != (byte)((e.int_1 >> 24) & 0xFF))
		{
			if ((e.short_1 & 8) != 8)
			{
				throw new Exception62("The password did not match.");
			}
			if (array[11] != (byte)((e.int_0 >> 8) & 0xFF))
			{
				throw new Exception62("The password did not match.");
			}
		}
		return @class;
	}

	public byte[] method_0(byte[] cipherText, int length)
	{
		if (cipherText == null)
		{
			throw new Exception61("Cannot decrypt.", new ArgumentException("Bad length during Decryption: cipherText must be non-null.", "cipherText"));
		}
		if (length > cipherText.Length)
		{
			throw new Exception61("Cannot decrypt.", new ArgumentException("Bad length during Decryption: the length parameter must be smaller than or equal to the size of the destination array.", "length"));
		}
		byte[] array = new byte[length];
		for (int i = 0; i < length; i++)
		{
			byte b = (byte)(cipherText[i] ^ MagicByte);
			method_3(b);
			array[i] = b;
		}
		return array;
	}

	public byte[] method_1(byte[] plaintext, int length)
	{
		if (plaintext == null)
		{
			throw new Exception61("Cannot encrypt.", new ArgumentException("Bad length during Encryption: the plainText must be non-null.", "plaintext"));
		}
		if (length > plaintext.Length)
		{
			throw new Exception61("Cannot encrypt.", new ArgumentException("Bad length during Encryption: The length parameter must be smaller than or equal to the size of the destination array.", "length"));
		}
		byte[] array = new byte[length];
		for (int i = 0; i < length; i++)
		{
			byte byteValue = plaintext[i];
			array[i] = (byte)(plaintext[i] ^ MagicByte);
			method_3(byteValue);
		}
		return array;
	}

	public void method_2(string passphrase)
	{
		byte[] array = Class6748.smethod_4(passphrase);
		for (int i = 0; i < passphrase.Length; i++)
		{
			method_3(array[i]);
		}
	}

	private void method_3(byte byteValue)
	{
		uint_0[0] = (uint)class6740_0.method_2((int)uint_0[0], byteValue);
		uint_0[1] = uint_0[1] + (byte)uint_0[0];
		uint_0[1] = uint_0[1] * 134775813 + 1;
		uint_0[2] = (uint)class6740_0.method_2((int)uint_0[2], (byte)(uint_0[1] >> 24));
	}
}
