using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace ns22;

internal class Class1027
{
	private MD5 md5_0;

	public Class1027()
	{
		md5_0 = new MD5CryptoServiceProvider();
	}

	public void Initialize()
	{
		md5_0.Initialize();
	}

	public void method_0(byte[] byte_0, int int_0, int int_1, byte[] byte_1, int int_2)
	{
		md5_0.TransformBlock(byte_0, int_0, int_1, byte_1, int_2);
	}

	public void method_1(byte[] byte_0, int int_0, int int_1)
	{
		md5_0.TransformFinalBlock(byte_0, int_0, int_1);
	}

	[SpecialName]
	public byte[] method_2()
	{
		return md5_0.Hash;
	}

	public byte[] method_3(byte[] byte_0)
	{
		return md5_0.ComputeHash(byte_0);
	}
}
