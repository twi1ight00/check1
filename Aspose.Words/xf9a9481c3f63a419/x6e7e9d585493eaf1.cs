using System.IO;
using System.Security.Cryptography;
using Aspose;
using x6c95d9cf46ff5f25;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class x6e7e9d585493eaf1
{
	public static ICryptoTransform x2acbb59cffafa5cf(byte[] xba08ce632055a1d9)
	{
		return xd586e0c16bdae7fc(xba08ce632055a1d9).CreateDecryptor();
	}

	public static ICryptoTransform xdc602ee8a05ba9ef(byte[] xba08ce632055a1d9)
	{
		return xd586e0c16bdae7fc(xba08ce632055a1d9).CreateEncryptor();
	}

	private static RijndaelManaged xd586e0c16bdae7fc(byte[] xba08ce632055a1d9)
	{
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.BlockSize = 128;
		rijndaelManaged.KeySize = xba08ce632055a1d9.Length * 8;
		rijndaelManaged.Key = xba08ce632055a1d9;
		rijndaelManaged.IV = xba08ce632055a1d9;
		rijndaelManaged.Mode = CipherMode.ECB;
		rijndaelManaged.Padding = PaddingMode.None;
		return rijndaelManaged;
	}

	public static void xaccac17571a8d9fa(Stream x23cda4cfdf81f2cf, Stream xedc894794186020d, ICryptoTransform x678241938de24d81)
	{
		CryptoStream x23cda4cfdf81f2cf2 = new CryptoStream(x23cda4cfdf81f2cf, x678241938de24d81, CryptoStreamMode.Read);
		x0d299f323d241756.x3ad8e53785c39acd(x23cda4cfdf81f2cf2, xedc894794186020d);
	}
}
