using System;
using System.Security.Cryptography;
using System.Text;
using ns56;

namespace ns24;

internal class Class513
{
	private Class2241 class2241_0;

	public bool IsWriteProtected => class2241_0 != null;

	public void SetWriteProtection(string password)
	{
		byte[] array = new byte[16];
		RandomNumberGenerator randomNumberGenerator = new RNGCryptoServiceProvider();
		randomNumberGenerator.GetNonZeroBytes(array);
		byte[] bytes = Encoding.Unicode.GetBytes(password);
		byte[] array2 = new byte[array.Length + bytes.Length];
		Buffer.BlockCopy(array, 0, array2, 0, array.Length);
		Buffer.BlockCopy(bytes, 0, array2, array.Length, bytes.Length);
		uint num = 100000u;
		HashAlgorithm hashAlgorithm = new SHA1Managed();
		array2 = hashAlgorithm.ComputeHash(array2);
		byte[] array3 = new byte[4];
		for (int i = 0; i < num; i++)
		{
			array3 = BitConverter.GetBytes(i);
			array2 = method_0(array3, array2);
			array2 = hashAlgorithm.ComputeHash(array2);
		}
		class2241_0 = new Class2241();
		class2241_0.CryptProviderType = Enum356.const_2;
		class2241_0.CryptAlgorithmClass = Enum354.const_1;
		class2241_0.CryptAlgorithmType = Enum355.const_1;
		class2241_0.CryptAlgorithmSid = 4u;
		class2241_0.SpinCount = num;
		class2241_0.SaltData = Convert.ToBase64String(array);
		class2241_0.HashData = Convert.ToBase64String(array2);
	}

	public void RemoveWriteProtection()
	{
		class2241_0 = null;
	}

	internal Class513()
	{
	}

	private byte[] method_0(byte[] array1, byte[] array2)
	{
		byte[] array3 = new byte[array1.Length + array2.Length];
		Buffer.BlockCopy(array2, 0, array3, 0, array2.Length);
		Buffer.BlockCopy(array1, 0, array3, array2.Length, array1.Length);
		return array3;
	}

	public void method_1(Class2241 elementData)
	{
		class2241_0 = elementData;
	}

	public void Write(Class2241.Delegate2469 set)
	{
		set(class2241_0);
	}
}
