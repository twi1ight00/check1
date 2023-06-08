using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class x93619359a213c4b3
{
	internal const int xfa5667446d3f7022 = 32000;

	internal const int xa98d9c6cbd0ee6f5 = 8000;

	internal const int x5a3d33dc2244066f = 16000;

	internal const int xd08bae3ce7812ddd = 30;

	internal const int xcf6e82a6d979d874 = 8;

	public static void xca99e0aebcf34c85(Stream xcf18e5243f8d5fd3, int xa6fa92839a392f8c, X509Certificate2 x0708ffc6efe2b1f3, xc102c6e35aff75b1 x4e599cb76e2435b4)
	{
		RectangleF rectangleF = xeef2953998f779cc(xcf18e5243f8d5fd3, xa6fa92839a392f8c);
		xa8bfd2b289bd6b18(xcf18e5243f8d5fd3, rectangleF);
		Stream x3f9e1d48f6c754fe = xd383c419fd722938(xcf18e5243f8d5fd3, rectangleF);
		byte[] xd6b625d499e70c4e = x73bb2b40010c1ca8(x3f9e1d48f6c754fe, x0708ffc6efe2b1f3, x4e599cb76e2435b4);
		xb159e6aa3391c20f(xcf18e5243f8d5fd3, xd6b625d499e70c4e, rectangleF);
	}

	private static RectangleF xeef2953998f779cc(Stream x0f7b23d1c393aed9, int xa6fa92839a392f8c)
	{
		long position = x0f7b23d1c393aed9.Position;
		x0f7b23d1c393aed9.Position = 0L;
		string s = $"\r\n{xa6fa92839a392f8c} 0 obj\r\n";
		byte[] array = new byte[8];
		byte[] bytes = Encoding.ASCII.GetBytes("Contents");
		byte[] bytes2 = Encoding.ASCII.GetBytes(s);
		int num = bytes2.Length;
		int num2 = 0;
		byte[] array2 = new byte[num];
		for (int i = 0; i < x0f7b23d1c393aed9.Length - num; i++)
		{
			x0f7b23d1c393aed9.Position = i;
			x0f7b23d1c393aed9.Read(array2, 0, num);
			if (bytes2.Length == array2.Length && xcd4bd3abd72ff2da.x5fa70910f253aafa(bytes2, array2, bytes2.Length))
			{
				int length = $" <</ByteRange".Length;
				int num3 = i + num + length + 30 + 1;
				x0f7b23d1c393aed9.Position = num3;
				x0f7b23d1c393aed9.Read(array, 0, 8);
				if (bytes.Length == array.Length && xcd4bd3abd72ff2da.x5fa70910f253aafa(bytes, array, bytes.Length))
				{
					num3 += 9;
					num2 = num3;
					break;
				}
				x0f7b23d1c393aed9.Position = i;
			}
		}
		float num4 = num2 + 32000 + 2;
		float height = (float)x0f7b23d1c393aed9.Length - num4;
		RectangleF result = new RectangleF(0f, num2, num4, height);
		x0f7b23d1c393aed9.Position = position;
		return result;
	}

	private static void xa8bfd2b289bd6b18(Stream x0f7b23d1c393aed9, RectangleF x1b536cdcb0873cc1)
	{
		int num = (int)x1b536cdcb0873cc1.Y;
		num += -40;
		long position = x0f7b23d1c393aed9.Position;
		string text = $"[{(int)x1b536cdcb0873cc1.X} {(int)x1b536cdcb0873cc1.Y} {(int)x1b536cdcb0873cc1.Width} {(int)x1b536cdcb0873cc1.Height}]";
		text = text.PadRight(30);
		byte[] array = new byte[text.Length];
		for (int i = 0; i < text.Length; i++)
		{
			array[i] = (byte)text[i];
		}
		x0f7b23d1c393aed9.Position = num;
		x0f7b23d1c393aed9.Write(array, 0, array.Length);
		x0f7b23d1c393aed9.Position = position;
	}

	private static Stream xd383c419fd722938(Stream x0f7b23d1c393aed9, RectangleF x1b536cdcb0873cc1)
	{
		long position = x0f7b23d1c393aed9.Position;
		byte[] array = new byte[(int)x1b536cdcb0873cc1.Y];
		byte[] array2 = new byte[(int)x1b536cdcb0873cc1.Height];
		x0f7b23d1c393aed9.Position = (int)x1b536cdcb0873cc1.X;
		x0f7b23d1c393aed9.Read(array, 0, array.Length);
		x0f7b23d1c393aed9.Position = (int)x1b536cdcb0873cc1.Width;
		x0f7b23d1c393aed9.Read(array2, 0, array2.Length);
		byte[] array3 = new byte[array.Length + array2.Length];
		array.CopyTo(array3, 0);
		array2.CopyTo(array3, array.Length);
		Stream result = new MemoryStream(array3);
		x0f7b23d1c393aed9.Position = position;
		return result;
	}

	private static byte[] x73bb2b40010c1ca8(Stream x3f9e1d48f6c754fe, X509Certificate2 x93bf26bc80edc72e, xc102c6e35aff75b1 x4e599cb76e2435b4)
	{
		x406f09bc1d85feb2 x406f09bc1d85feb = new x406f09bc1d85feb2();
		byte[] content = x406f09bc1d85feb.xc6df3c48d7ea1182(x0d299f323d241756.xa0aed4cd3b3d5d92(x3f9e1d48f6c754fe));
		ContentInfo contentInfo = new ContentInfo(content);
		SignedCms signedCms = new SignedCms(contentInfo, detached: false);
		CmsSigner cmsSigner = new CmsSigner(x93bf26bc80edc72e);
		cmsSigner.IncludeOption = X509IncludeOption.EndCertOnly;
		cmsSigner.DigestAlgorithm = x2daf7a7b12778d5f(x4e599cb76e2435b4);
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

	private static void xb159e6aa3391c20f(Stream x0f7b23d1c393aed9, byte[] xd6b625d499e70c4e, RectangleF x360365d036384dc7)
	{
		string text = BitConverter.ToString(xd6b625d499e70c4e).Replace("-", "");
		byte[] array = new byte[32000];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)text[i];
		}
		long position = x0f7b23d1c393aed9.Position;
		x0f7b23d1c393aed9.Position = (int)x360365d036384dc7.Y + 1;
		x0f7b23d1c393aed9.Write(array, 0, array.Length);
		x0f7b23d1c393aed9.Position = position;
	}

	private static Oid x2daf7a7b12778d5f(xc102c6e35aff75b1 x4e599cb76e2435b4)
	{
		return x4e599cb76e2435b4 switch
		{
			xc102c6e35aff75b1.xb4a576d45a201dc0 => new Oid("MD5"), 
			xc102c6e35aff75b1.x5635e6b837b4f331 => new Oid("SHA1"), 
			xc102c6e35aff75b1.xe1e4eb9663e6cca3 => new Oid("SHA256"), 
			xc102c6e35aff75b1.x9d0756ca154c5d48 => new Oid("SHA384"), 
			xc102c6e35aff75b1.xc2a3a1f9f43b83c7 => new Oid("SHA512"), 
			_ => throw new ArgumentException("Invalid hash algorithm."), 
		};
	}
}
