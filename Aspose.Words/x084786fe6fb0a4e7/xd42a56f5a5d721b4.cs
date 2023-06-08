using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words.Saving;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xce0136f05681c5e9;
using xf989f31a236ff98c;
using xf9a9481c3f63a419;

namespace x084786fe6fb0a4e7;

internal class xd42a56f5a5d721b4 : x3d2908992e1d1667
{
	private x8556eed81191af11 xb36c250515e408ad;

	private StreamWriter x06aeac6c18880fd3;

	private xba5f2e8a212f838a xd37540ce8366fbc3;

	private static readonly Encoding xe7f2457ef0127808 = Encoding.ASCII;

	private static readonly string x0b3bab6f49ef3aba = "=boundary.Aspose.Words=--";

	private HtmlSaveOptions xf57de0fd37d5e97d => (HtmlSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d;

	private SaveOutputParameters x8cac5adfe79bc025(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		xb36c250515e408ad = x5ac1382edb7bf2c2;
		if (xf57de0fd37d5e97d.DocumentSplitCriteria != 0)
		{
			throw new InvalidOperationException("Document cannot be split when saving in MHTML format.");
		}
		x06aeac6c18880fd3 = new StreamWriter(x5ac1382edb7bf2c2.xb8a774e0111d0fbe, xe7f2457ef0127808);
		xd37540ce8366fbc3 = new xba5f2e8a212f838a(x06aeac6c18880fd3);
		ArrayList xd6abb2ab950b4d;
		bool flag;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			xb388353c23101505 xb388353c = new xb388353c23101505();
			x754017e579b6a8ff x754017e579b6a8ff = new x754017e579b6a8ff(xb36c250515e408ad.x2c8c6741422a1298, memoryStream, null, xf57de0fd37d5e97d, xb36c250515e408ad.x158c955c749c5e5b, xb388353c, null);
			x754017e579b6a8ff.xa2e0b7f7da663553();
			memoryStream.Position = 0L;
			xd6abb2ab950b4d = xb388353c.xd6abb2ab950b4d22;
			flag = xd6abb2ab950b4d.Count != 0;
			xc25d1580b49dab9a(flag);
			Encoding encoding = xf57de0fd37d5e97d.Encoding;
			if (x3b287ad46217a101(encoding.CodePage))
			{
				xe5e28c15571512ae(flag, "text/html", encoding.HeaderName, "base64", "document.html");
				xd37540ce8366fbc3.xe24c4103102bcb90(memoryStream);
			}
			else
			{
				xe5e28c15571512ae(flag, "text/html", encoding.HeaderName, "quoted-printable", "document.html");
				xd37540ce8366fbc3.xd068481bae111913(memoryStream);
			}
		}
		if (flag)
		{
			foreach (xd59a0d3f8248c4e8 item in xd6abb2ab950b4d)
			{
				xe25b4aee13041a71(item);
			}
			x991abdd1b5aab395();
		}
		x06aeac6c18880fd3.Flush();
		return new SaveOutputParameters("multipart/related");
	}

	SaveOutputParameters x3d2908992e1d1667.xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8cac5adfe79bc025
		return this.x8cac5adfe79bc025(x5ac1382edb7bf2c2);
	}

	private void xc25d1580b49dab9a(bool x8d421b99b43ca205)
	{
		string arg = "";
		string arg2 = "";
		string arg3 = "";
		if (!xf57de0fd37d5e97d.x73268d8924ff940d)
		{
			arg = (xf57de0fd37d5e97d.xbfa4c2c3efbf56fd ? "Aspose.Words for .NET 11.9.0.0" : "MHTML Document");
			arg = $"From: <{arg}>\r\n";
			arg2 = xb36c250515e408ad.x2c8c6741422a1298.BuiltInDocumentProperties.Title;
			arg2 = (x0d299f323d241756.x5959bccb67bbf051(arg2) ? x1be080418da9d379(arg2) : "Untitled");
			arg2 = $"Subject: {arg2}\r\n";
			if (xf57de0fd37d5e97d.x259fc7094d171627)
			{
				arg3 = $"Date: {xca004f56614e2431.x5fb241430a53ba3b(x7546e38fbb25d738.xc044302ca1c0d3c7())}\r\n";
			}
		}
		x06aeac6c18880fd3.Write("{0}{1}{2}MIME-Version: 1.0\r\n", arg, arg2, arg3);
		if (x8d421b99b43ca205)
		{
			x06aeac6c18880fd3.Write("Content-Type: multipart/related;\r\n\ttype=\"text/html\";\r\n\tboundary=\"{0}\"\r\n\r\nThis is a multi-part message in MIME format.\r\n", x0b3bab6f49ef3aba);
		}
	}

	private static bool x3b287ad46217a101(int x72a2103e9ae2c33f)
	{
		if (x72a2103e9ae2c33f != 1200 && x72a2103e9ae2c33f != 1201 && x72a2103e9ae2c33f != 12000)
		{
			return x72a2103e9ae2c33f == 12001;
		}
		return true;
	}

	private void xe5e28c15571512ae(bool x8d421b99b43ca205, string xe1d3286d17e44a37, string x1ec8d3808cca2695, string x1807bef890c9b567, string xb9c2cfae130d9256)
	{
		string text = (x0d299f323d241756.x5959bccb67bbf051(x1ec8d3808cca2695) ? $";\r\n\tcharset=\"{x1ec8d3808cca2695}\"" : "");
		if (x8d421b99b43ca205)
		{
			x06aeac6c18880fd3.Write("\r\n--{0}\r\n", x0b3bab6f49ef3aba);
		}
		x06aeac6c18880fd3.Write("Content-Disposition: inline;\r\n\tfilename=\"{3}\"\r\nContent-Type: {0}{1}\r\nContent-Transfer-Encoding: {2}\r\nContent-Location: {3}\r\n\r\n", xe1d3286d17e44a37, text, x1807bef890c9b567, xb9c2cfae130d9256);
	}

	private void x991abdd1b5aab395()
	{
		x06aeac6c18880fd3.Write("\r\n--{0}--\r\n", x0b3bab6f49ef3aba);
	}

	private void xe25b4aee13041a71(xd59a0d3f8248c4e8 xd7e5673853e47af4)
	{
		using Stream x337e217cb3ba = xd7e5673853e47af4.x878afbafb98bf640();
		if (xd7e5673853e47af4.x1ede37fe2e573750 && !x3b287ad46217a101(xd7e5673853e47af4.xb5305bb23e4178cb.CodePage))
		{
			xe5e28c15571512ae(x8d421b99b43ca205: true, xd7e5673853e47af4.x0b93856f95be30d0, xd7e5673853e47af4.xb5305bb23e4178cb.HeaderName, "quoted-printable", xd7e5673853e47af4.xb405a444ca77e2d4);
			xd37540ce8366fbc3.xd068481bae111913(x337e217cb3ba);
		}
		else
		{
			xe5e28c15571512ae(x8d421b99b43ca205: true, xd7e5673853e47af4.x0b93856f95be30d0, null, "base64", xd7e5673853e47af4.xb405a444ca77e2d4);
			xd37540ce8366fbc3.xe24c4103102bcb90(x337e217cb3ba);
		}
	}

	private static string x1be080418da9d379(string xb41faee6912a2313)
	{
		int length = xb41faee6912a2313.Length;
		for (int i = 0; i < length; i++)
		{
			if (xb41faee6912a2313[i] > '\u007f')
			{
				return x6ac8320f7e51457e(xb41faee6912a2313);
			}
		}
		return xb41faee6912a2313;
	}

	private static string x6ac8320f7e51457e(string xb41faee6912a2313)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using StreamWriter streamWriter = new StreamWriter(memoryStream);
		streamWriter.Write(xb41faee6912a2313);
		streamWriter.Flush();
		memoryStream.Position = 0L;
		int num = (int)memoryStream.Length;
		byte[] array = new byte[num];
		int num2 = 0;
		int num3 = num;
		int num4;
		while ((num4 = memoryStream.Read(array, num2, num3)) != 0)
		{
			num2 += num4;
			num3 -= num4;
		}
		string arg = Convert.ToBase64String(array);
		return $"=?utf-8?B?{arg}?=";
	}
}
