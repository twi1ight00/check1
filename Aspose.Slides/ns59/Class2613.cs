using System;
using System.IO;
using System.Security.Cryptography;
using ns4;

namespace ns59;

internal class Class2613
{
	public uint uint_0;

	public byte[] byte_0;

	public byte[] byte_1;

	public uint uint_1;

	public byte[] byte_2;

	public Class2613()
	{
	}

	public Class2613(string password, uint keySize)
	{
		uint_0 = 16u;
		byte_0 = Guid.NewGuid().ToByteArray();
		Class2615 class2;
		using (Class2616 @class = new Class2616(password, byte_0, keySize))
		{
			class2 = @class.method_0(0u);
		}
		byte[] array = Guid.NewGuid().ToByteArray();
		byte_1 = class2.Encrypt(array);
		uint_1 = 20u;
		using SHA1 sHA = new SHA1CryptoServiceProvider();
		byte_2 = class2.Encrypt(sHA.ComputeHash(array));
	}

	internal int method_0()
	{
		return (int)(40 + uint_1);
	}

	public void method_1(BinaryWriter writer)
	{
		writer.Write((int)uint_0);
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write((int)uint_1);
		writer.Write(byte_2);
	}

	public static Class2613 smethod_0(Stream stream, int cbEncryptedVerifierHash)
	{
		Class2613 @class = new Class2613();
		@class.uint_0 = (uint)Class1162.smethod_24(stream);
		@class.byte_0 = Class1162.smethod_28(stream, 16);
		@class.byte_1 = Class1162.smethod_28(stream, 16);
		@class.uint_1 = (uint)Class1162.smethod_24(stream);
		@class.byte_2 = Class1162.smethod_28(stream, cbEncryptedVerifierHash);
		return @class;
	}
}
