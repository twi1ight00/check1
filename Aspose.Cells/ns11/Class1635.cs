using System.IO;
using System.Security.Cryptography;

namespace ns11;

internal class Class1635
{
	internal enum Enum219
	{
		const_0,
		const_1,
		const_2
	}

	private ICryptoTransform icryptoTransform_0;

	private ICryptoTransform icryptoTransform_1;

	private RijndaelManaged rijndaelManaged_0;

	public Class1635(Enum219 enum219_0, byte[] byte_0, CipherMode cipherMode_0)
	{
		rijndaelManaged_0 = new RijndaelManaged();
		rijndaelManaged_0.Padding = PaddingMode.None;
		rijndaelManaged_0.Mode = cipherMode_0;
		int num = 0;
		switch (enum219_0)
		{
		case Enum219.const_0:
			num = 16;
			break;
		case Enum219.const_1:
			num = 24;
			break;
		case Enum219.const_2:
			num = 32;
			break;
		}
		icryptoTransform_0 = rijndaelManaged_0.CreateDecryptor(byte_0, new byte[num]);
		icryptoTransform_1 = rijndaelManaged_0.CreateEncryptor(byte_0, new byte[num]);
	}

	public void method_0(byte[] byte_0, byte[] byte_1)
	{
		MemoryStream stream = new MemoryStream(byte_1);
		CryptoStream cryptoStream = new CryptoStream(stream, icryptoTransform_1, CryptoStreamMode.Write);
		cryptoStream.Write(byte_0, 0, byte_0.Length);
		cryptoStream.Close();
	}

	public void method_1(byte[] byte_0, byte[] byte_1)
	{
		MemoryStream stream = new MemoryStream(byte_0);
		CryptoStream cryptoStream = new CryptoStream(stream, icryptoTransform_0, CryptoStreamMode.Read);
		cryptoStream.Read(byte_1, 0, byte_0.Length);
		cryptoStream.Close();
	}
}
