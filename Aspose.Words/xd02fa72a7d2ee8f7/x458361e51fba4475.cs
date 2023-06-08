using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Aspose.Words;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace xd02fa72a7d2ee8f7;

internal class x458361e51fba4475
{
	private const int x1f875ed86e20ee9a = 16;

	private x458361e51fba4475()
	{
	}

	internal static DigitalSignature x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, byte[] xb42db422810fc3a2)
	{
		DigitalSignature digitalSignature = new DigitalSignature(DigitalSignatureType.CryptoApi);
		_ = DateTime.MinValue;
		bool x7d95d971d8923f4c;
		try
		{
			int num = xe134235b3526fa75.ReadInt32();
			int num2 = xe134235b3526fa75.ReadInt32();
			x0003059f1f13635c(xe134235b3526fa75);
			uint num3 = xe134235b3526fa75.ReadUInt32();
			uint num4 = xe134235b3526fa75.ReadUInt32();
			long num5 = num3;
			num5 <<= 32;
			num5 |= num4;
			digitalSignature.x2da4bc39c98a8695(DateTime.FromFileTimeUtc(num5));
			xe134235b3526fa75.ReadInt32();
			int count = xe134235b3526fa75.ReadInt32();
			int num6 = xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			int count2 = xe134235b3526fa75.ReadInt32();
			int count3 = xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			x93b05c1ad709a695.x79739b9c4ddc2495(xe134235b3526fa75, (num + 1) * 2);
			x93b05c1ad709a695.x79739b9c4ddc2495(xe134235b3526fa75, (num2 + 1) * 2);
			byte[] array = xe134235b3526fa75.ReadBytes(count);
			byte[] rawData = xe134235b3526fa75.ReadBytes(num6);
			xe134235b3526fa75.ReadBytes(count2);
			xe134235b3526fa75.ReadBytes(count3);
			if (num6 == 0)
			{
				throw new InvalidOperationException("There is no certificate embedded for a digital signature.");
			}
			X509Certificate2 x509Certificate = new X509Certificate2(rawData);
			digitalSignature.xb126629734b482a4(x509Certificate);
			RSACryptoServiceProvider rSACryptoServiceProvider = (RSACryptoServiceProvider)x509Certificate.PublicKey.Key;
			RSAParameters rSAParameters = rSACryptoServiceProvider.ExportParameters(includePrivateParameters: false);
			Array.Reverse(array);
			byte[] xe4115acdf4fbfccc = x2cf87a031823314d.xc99bf7542a430c74(array);
			x0c2c2ec0e5dfca9c x0c2c2ec0e5dfca9c = new x0c2c2ec0e5dfca9c(rSAParameters.Modulus, rSAParameters.Exponent);
			byte[] x08db3aeabb253cb = x2cf87a031823314d.x1add485e7984b4a9(x0c2c2ec0e5dfca9c, xe4115acdf4fbfccc);
			byte[] array2 = x2cf87a031823314d.xdf0b52945cea7d94(x08db3aeabb253cb, x0c2c2ec0e5dfca9c.x02f2e920b8f411d0.xce53a4f2835cab70() >> 3);
			byte[] array3 = new byte[16];
			Array.Copy(array2, array2.Length - 16, array3, 0, 16);
			x1e72f71e14224f7d x1e72f71e14224f7d = new x1e72f71e14224f7d();
			x1e72f71e14224f7d.x295cb4a1df7a5add(xb42db422810fc3a2, xb42db422810fc3a2.Length);
			x1e72f71e14224f7d.x295cb4a1df7a5add(BitConverter.GetBytes(num4), 4);
			x1e72f71e14224f7d.x295cb4a1df7a5add(BitConverter.GetBytes(num3), 4);
			x1e72f71e14224f7d.x20098fa15e62301f();
			x7d95d971d8923f4c = xcd4bd3abd72ff2da.xf920f15ca6067ada(array3, x1e72f71e14224f7d.x7a569e28d68fded6);
		}
		catch (Exception)
		{
			x7d95d971d8923f4c = false;
		}
		digitalSignature.xb84489d1134cdb3c(x7d95d971d8923f4c);
		return digitalSignature;
	}

	private static DateTime x0003059f1f13635c(BinaryReader xe134235b3526fa75)
	{
		long num = xe134235b3526fa75.ReadUInt32();
		num <<= 32;
		num |= xe134235b3526fa75.ReadUInt32();
		return DateTime.FromFileTimeUtc(num);
	}
}
