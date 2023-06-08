using System;
using System.Security.Cryptography;
using System.Text;

namespace ns59;

internal class Class2616 : IDisposable
{
	private readonly SHA1 sha1_0 = new SHA1CryptoServiceProvider();

	private readonly byte[] byte_0;

	private readonly uint uint_0;

	private readonly uint uint_1;

	public Class2616(string password, byte[] salt, uint keySizeInBits)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(password);
		byte[] array = new byte[salt.Length + bytes.Length];
		Array.Copy(salt, array, salt.Length);
		Array.Copy(bytes, 0, array, salt.Length, bytes.Length);
		byte_0 = sha1_0.ComputeHash(array);
		uint num = keySizeInBits / 8u;
		if (keySizeInBits == 40)
		{
			num = 16u;
		}
		uint_0 = num;
		uint_1 = keySizeInBits;
	}

	public Class2615 method_0(uint blockNumber)
	{
		byte[] key = method_1(blockNumber);
		return new Class2615(key);
	}

	public byte[] method_1(uint blockNumber)
	{
		byte[] bytes = BitConverter.GetBytes(blockNumber);
		byte[] array = new byte[byte_0.Length + 4];
		Array.Copy(byte_0, array, byte_0.Length);
		Array.Copy(bytes, 0, array, byte_0.Length, bytes.Length);
		byte[] sourceArray = sha1_0.ComputeHash(array);
		byte[] array2 = new byte[uint_0];
		Array.Copy(sourceArray, array2, uint_0);
		if (uint_1 == 40)
		{
			for (int i = 5; i < array2.Length; i++)
			{
				array2[i] = 0;
			}
		}
		return array2;
	}

	public void Dispose()
	{
		((IDisposable)sha1_0).Dispose();
	}
}
