using System.IO;
using System.Security.Cryptography;
using ns218;

namespace ns234;

internal static class Class6154
{
	public static ICryptoTransform smethod_0(byte[] key)
	{
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.BlockSize = 128;
		rijndaelManaged.KeySize = key.Length * 8;
		rijndaelManaged.Key = key;
		rijndaelManaged.IV = key;
		rijndaelManaged.Mode = CipherMode.ECB;
		rijndaelManaged.Padding = PaddingMode.None;
		return rijndaelManaged.CreateDecryptor();
	}

	public static void smethod_1(Stream srcStream, Stream dstStream, ICryptoTransform decryptor)
	{
		CryptoStream srcStream2 = new CryptoStream(srcStream, decryptor, CryptoStreamMode.Read);
		Class5964.smethod_9(srcStream2, dstStream);
	}
}
