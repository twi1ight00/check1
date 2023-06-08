using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ns218;
using ns223;

namespace ns237;

internal class Class6560
{
	internal const int int_0 = 32000;

	internal const int int_1 = 8000;

	internal const int int_2 = 16000;

	internal const int int_3 = 30;

	internal const int int_4 = 8;

	public static void smethod_0(Stream stream, int objId, X509Certificate2 cert, Enum875 hashAlgorithm)
	{
		RectangleF rectangleF = smethod_1(stream, objId);
		smethod_2(stream, rectangleF);
		Stream documentStream = smethod_3(stream, rectangleF);
		byte[] transformContext = smethod_4(documentStream, cert, hashAlgorithm);
		smethod_5(stream, transformContext, rectangleF);
	}

	private static RectangleF smethod_1(Stream context, int objId)
	{
		RectangleF empty = RectangleF.Empty;
		long position = context.Position;
		context.Position = 0L;
		string s = $"\r\n{objId} 0 obj\r\n";
		byte[] array = new byte[8];
		byte[] bytes = Encoding.ASCII.GetBytes("Contents");
		byte[] bytes2 = Encoding.ASCII.GetBytes(s);
		int num = bytes2.Length;
		int num2 = 0;
		byte[] array2 = new byte[num];
		for (int i = 0; i < context.Length - num; i++)
		{
			context.Position = i;
			context.Read(array2, 0, num);
			if (bytes2.Length == array2.Length && Class5948.smethod_9(bytes2, array2, bytes2.Length))
			{
				int length = $" <</ByteRange".Length;
				int num3 = i + num + length + 30 + 1;
				context.Position = num3;
				context.Read(array, 0, 8);
				if (bytes.Length == array.Length && Class5948.smethod_9(bytes, array, bytes.Length))
				{
					num3 += 9;
					num2 = num3;
					break;
				}
				context.Position = i;
			}
		}
		empty.Y = num2;
		empty.Width = num2 + 32000 + 2;
		empty.Height = (float)context.Length - empty.Width;
		context.Position = position;
		return empty;
	}

	private static void smethod_2(Stream context, RectangleF certHole)
	{
		int num = (int)certHole.Y;
		num += -40;
		long position = context.Position;
		string text = $"[{certHole.X} {certHole.Y} {certHole.Width} {certHole.Height}]".PadRight(30);
		byte[] array = new byte[text.Length];
		for (int i = 0; i < text.Length; i++)
		{
			array[i] = (byte)text[i];
		}
		context.Position = num;
		context.Write(array, 0, array.Length);
		context.Position = position;
	}

	private static Stream smethod_3(Stream context, RectangleF certHole)
	{
		long position = context.Position;
		byte[] array = new byte[(int)certHole.Y];
		byte[] array2 = new byte[(int)certHole.Height];
		context.Position = (int)certHole.X;
		context.Read(array, 0, array.Length);
		context.Position = (int)certHole.Width;
		context.Read(array2, 0, array2.Length);
		byte[] array3 = new byte[array.Length + array2.Length];
		array.CopyTo(array3, 0);
		array2.CopyTo(array3, array.Length);
		Stream result = new MemoryStream(array3);
		context.Position = position;
		return result;
	}

	private static byte[] smethod_4(Stream documentStream, X509Certificate2 certificate, Enum875 hashAlgorithm)
	{
		Class5987 @class = new Class5987();
		byte[] content = @class.method_0(Class5964.smethod_11(documentStream));
		ContentInfo contentInfo = new ContentInfo(content);
		SignedCms signedCms = new SignedCms(contentInfo, detached: false);
		CmsSigner cmsSigner = new CmsSigner(certificate);
		cmsSigner.IncludeOption = X509IncludeOption.EndCertOnly;
		cmsSigner.DigestAlgorithm = smethod_6(hashAlgorithm);
		signedCms.ComputeSignature(cmsSigner, silent: false);
		byte[] array = signedCms.Encode();
		if (array.Length > 16000)
		{
			throw new InvalidOperationException("Can't insert digital signature to the PDF document. The size of the digital signature exceeds allocated space.");
		}
		byte[] array2 = new byte[16000];
		Array.Copy(array, 0, array2, 0, array.Length);
		return array2;
	}

	private static void smethod_5(Stream context, byte[] transformContext, RectangleF certhole)
	{
		string text = BitConverter.ToString(transformContext).Replace("-", string.Empty);
		byte[] array = new byte[32000];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)text[i];
		}
		long position = context.Position;
		context.Position = (int)certhole.Y + 1;
		context.Write(array, 0, array.Length);
		context.Position = position;
	}

	private static Oid smethod_6(Enum875 hashAlgorithm)
	{
		return hashAlgorithm switch
		{
			Enum875.const_0 => new Oid("SHA1"), 
			Enum875.const_1 => new Oid("SHA256"), 
			Enum875.const_2 => new Oid("SHA384"), 
			Enum875.const_3 => new Oid("SHA512"), 
			Enum875.const_4 => new Oid("MD5"), 
			_ => throw new ArgumentException("Invalid hash algorithm."), 
		};
	}
}
