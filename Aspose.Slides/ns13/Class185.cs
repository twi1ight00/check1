using System.IO;
using System.Security.Cryptography;

namespace ns13;

internal class Class185
{
	internal enum Enum15
	{
		const_0,
		const_1,
		const_2
	}

	private ICryptoTransform icryptoTransform_0;

	private ICryptoTransform icryptoTransform_1;

	private RijndaelManaged rijndaelManaged_0;

	public CipherMode CipherMode
	{
		set
		{
			rijndaelManaged_0.Mode = value;
		}
	}

	public Class185(Enum15 keySize, byte[] keyBytes, CipherMode mode)
	{
		rijndaelManaged_0 = new RijndaelManaged();
		rijndaelManaged_0.Padding = PaddingMode.None;
		rijndaelManaged_0.Mode = mode;
		int num = 0;
		switch (keySize)
		{
		case Enum15.const_0:
			num = 16;
			break;
		case Enum15.const_1:
			num = 24;
			break;
		case Enum15.const_2:
			num = 32;
			break;
		}
		icryptoTransform_0 = rijndaelManaged_0.CreateDecryptor(keyBytes, new byte[num]);
		icryptoTransform_1 = rijndaelManaged_0.CreateEncryptor(keyBytes, new byte[num]);
	}

	public void method_0(byte[] input, byte[] output)
	{
		MemoryStream stream = new MemoryStream(output);
		CryptoStream cryptoStream = new CryptoStream(stream, icryptoTransform_1, CryptoStreamMode.Write);
		cryptoStream.Write(input, 0, input.Length);
		cryptoStream.Close();
	}

	public void method_1(byte[] input, byte[] output)
	{
		MemoryStream stream = new MemoryStream(input);
		CryptoStream cryptoStream = new CryptoStream(stream, icryptoTransform_0, CryptoStreamMode.Read);
		cryptoStream.Read(output, 0, input.Length);
		cryptoStream.Close();
	}
}
