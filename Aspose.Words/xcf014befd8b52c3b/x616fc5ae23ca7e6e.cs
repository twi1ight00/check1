using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using Aspose;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace xcf014befd8b52c3b;

[JavaManual("Port it manually because of DOM XML")]
internal class x616fc5ae23ca7e6e
{
	private DigitalSignature x69997a0ce8a9d0f8;

	private xc1dcd6189d01216e x7450cc1e48712286;

	private readonly IWarningCallback xa056586c1f99e199;

	private static readonly string[] xbfba1f432f5e8c90 = new string[3] { "yyyy-MM-ddTHH:mm:ss,FF", "yyyy-MM-ddTHH:mm:ssZ", "yyyy-MM-ddTHH:mm:sszzz" };

	private x616fc5ae23ca7e6e(IWarningCallback warningCallback)
	{
		xa056586c1f99e199 = warningCallback;
	}

	internal static void x06b0e25aa6ad68a9(Stream xcf18e5243f8d5fd3, x7eeece7aa20be881 xe3546285b5bdc9c7, DigitalSignatureCollection x35a024439e5c0797, IWarningCallback x57fef5933b41d0c2)
	{
		x616fc5ae23ca7e6e x616fc5ae23ca7e6e2 = new x616fc5ae23ca7e6e(x57fef5933b41d0c2);
		x616fc5ae23ca7e6e2.x197a76fd29b1245d(xcf18e5243f8d5fd3, xe3546285b5bdc9c7, x35a024439e5c0797);
	}

	private void x197a76fd29b1245d(Stream xcf18e5243f8d5fd3, x7eeece7aa20be881 xe3546285b5bdc9c7, DigitalSignatureCollection x35a024439e5c0797)
	{
		if (xcf18e5243f8d5fd3 == null)
		{
			return;
		}
		x7450cc1e48712286 = new xc1dcd6189d01216e(xcf18e5243f8d5fd3);
		if (x7450cc1e48712286.xa66385d80d4d296f == "Signature")
		{
			bool x3e82704cf05a9efe = x9c88087e8e1ba6de(xcf18e5243f8d5fd3, 0);
			x35a024439e5c0797.xd6b6ed77479ef68c(x79779d7255a91725(xe3546285b5bdc9c7, x3e82704cf05a9efe));
			return;
		}
		int num = 0;
		while (x7450cc1e48712286.x152cbadbfa8061b1("document-signatures"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "Signature")
			{
				bool x3e82704cf05a9efe2 = x9c88087e8e1ba6de(xcf18e5243f8d5fd3, num++);
				x35a024439e5c0797.xd6b6ed77479ef68c(x79779d7255a91725(xe3546285b5bdc9c7, x3e82704cf05a9efe2));
			}
			else
			{
				xe1813892c007071d();
			}
		}
	}

	private static bool x9c88087e8e1ba6de(Stream xcf18e5243f8d5fd3, int x07e19eca07a0c1c7)
	{
		long position = xcf18e5243f8d5fd3.Position;
		xcf18e5243f8d5fd3.Position = 0L;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = true;
		xmlDocument.Load(xcf18e5243f8d5fd3);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Signature");
		if (elementsByTagName.Count <= 0)
		{
			return false;
		}
		SignedXml signedXml = new SignedXml();
		signedXml.LoadXml((XmlElement)elementsByTagName[x07e19eca07a0c1c7]);
		int num = 0;
		while (num < signedXml.SignedInfo.References.Count)
		{
			Reference reference = (Reference)signedXml.SignedInfo.References[num];
			if (!reference.Uri.StartsWith("#"))
			{
				signedXml.SignedInfo.References.RemoveAt(num);
			}
			else
			{
				num++;
			}
		}
		xcf18e5243f8d5fd3.Position = position;
		return signedXml.CheckSignature();
	}

	private DigitalSignature x79779d7255a91725(x7eeece7aa20be881 xca1318b98a23060e, bool x3e82704cf05a9efe)
	{
		x69997a0ce8a9d0f8 = new DigitalSignature(DigitalSignatureType.XmlDsig);
		x69997a0ce8a9d0f8.xb515b28da60b35db = x3e82704cf05a9efe;
		while (x7450cc1e48712286.x152cbadbfa8061b1("Signature"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "SignedInfo":
				x3b7032d7a2fad49c();
				break;
			case "KeyInfo":
				xb3f4f7e2f5c2f38e();
				break;
			case "Object":
				x5645da3ef786a86f();
				break;
			default:
				xe1813892c007071d();
				break;
			}
		}
		bool flag = x3e82704cf05a9efe;
		SHA1 sHA = new SHA1CryptoServiceProvider();
		foreach (x465c7a263669f01c item in x69997a0ce8a9d0f8.xdf0c8cea9b2d73a3)
		{
			if (item.x0552da4f5c09bde5)
			{
				Stream stream = xca1318b98a23060e.x79f7fd8368ae8a71(item);
				foreach (xaccac17571a8d9fa item2 in item.x31d70360be76ba60)
				{
					stream = item2.x550781f8db1cf5f2(stream);
				}
				stream.Position = 0L;
				string text = Convert.ToBase64String(sHA.ComputeHash(stream));
				bool flag3 = (item.x22ab5dfa6f12e902 = text == item.xdf22e372ee592a9e);
				flag = flag && flag3;
			}
			else
			{
				item.x22ab5dfa6f12e902 = x3e82704cf05a9efe;
			}
		}
		x69997a0ce8a9d0f8.xb84489d1134cdb3c(flag);
		if (!x69997a0ce8a9d0f8.IsValid && xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(WarningType.UnexpectedContent, WarningSource.Unknown, "Digital signature is invalid, document content was tampered."));
		}
		return x69997a0ce8a9d0f8;
	}

	private void xb3f4f7e2f5c2f38e()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("KeyInfo"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "X509Data")
			{
				xc9d080a0700bb657();
			}
			else
			{
				xe1813892c007071d();
			}
		}
	}

	private void xc9d080a0700bb657()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("X509Data"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "X509Certificate")
			{
				x69997a0ce8a9d0f8.xb126629734b482a4(new X509Certificate2(Encoding.UTF8.GetBytes(x7450cc1e48712286.x2a1ea9d24e62bf84())));
			}
			else
			{
				xe1813892c007071d();
			}
		}
	}

	private void x5645da3ef786a86f()
	{
		string text = x7450cc1e48712286.xd68abcd61e368af9("Id", null);
		if (text == null)
		{
			x1737caf7c27bab0c();
			return;
		}
		switch (text)
		{
		case "idPackageObject":
			x1737caf7c27bab0c();
			break;
		case "idOfficeObject":
			x53e3962a6f3de282();
			break;
		case "idValidSigLnImg":
			x69997a0ce8a9d0f8.xfb5048ebfc118445 = Convert.FromBase64String(x7450cc1e48712286.x2a1ea9d24e62bf84());
			break;
		case "idInvalidSigLnImg":
			x69997a0ce8a9d0f8.x96b293f7587d2033 = Convert.FromBase64String(x7450cc1e48712286.x2a1ea9d24e62bf84());
			break;
		default:
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContentCategory, WarningSource.Unknown, $"Unexpected id of Object element {text}");
			break;
		}
	}

	private void x1737caf7c27bab0c()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("Object"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "Manifest":
				x3b7032d7a2fad49c();
				break;
			case "SignatureProperties":
				xd7164788d6073781();
				break;
			default:
				xe1813892c007071d();
				break;
			}
		}
	}

	private void x53e3962a6f3de282()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("Object"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "SignatureProperties")
			{
				xd7164788d6073781();
			}
			else
			{
				xe1813892c007071d();
			}
		}
	}

	private void x3b7032d7a2fad49c()
	{
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			string xa66385d80d4d296f2;
			if ((xa66385d80d4d296f2 = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "Reference")
			{
				x69997a0ce8a9d0f8.xdf0c8cea9b2d73a3.Add(x5db5d47b197d2ff9());
			}
			else
			{
				xe1813892c007071d();
			}
		}
	}

	private void xd7164788d6073781()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("SignatureProperties"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "SignatureProperty")
			{
				x27e3e5f851d07a1d();
			}
			else
			{
				xe1813892c007071d();
			}
		}
	}

	private void x27e3e5f851d07a1d()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("SignatureProperty"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "SignatureTime":
				xe41483f66137d14b();
				break;
			case "SignatureInfoV1":
				xf9369e71ec1ede70();
				break;
			case "date":
				x69997a0ce8a9d0f8.x2da4bc39c98a8695(xa9d1cea4950d7687(x7450cc1e48712286.x2a1ea9d24e62bf84()));
				break;
			default:
				xe1813892c007071d();
				break;
			}
		}
	}

	private void xe41483f66137d14b()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("SignatureTime"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "Value")
			{
				x69997a0ce8a9d0f8.x2da4bc39c98a8695(xa9d1cea4950d7687(x7450cc1e48712286.x2a1ea9d24e62bf84()));
			}
			else
			{
				xe1813892c007071d();
			}
		}
	}

	private static DateTime xa9d1cea4950d7687(string xbcea506a33cf9111)
	{
		return DateTime.ParseExact(xbcea506a33cf9111, xbfba1f432f5e8c90, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
	}

	private void xf9369e71ec1ede70()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("SignatureInfoV1"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "SignatureComments":
				x69997a0ce8a9d0f8.xafe9b6061e340c76(x7450cc1e48712286.x2a1ea9d24e62bf84());
				break;
			case "SetupID":
			{
				string text2 = x7450cc1e48712286.x2a1ea9d24e62bf84();
				x69997a0ce8a9d0f8.x7c739bac7cd13266 = (x0d299f323d241756.x5959bccb67bbf051(text2) ? new Guid(text2) : Guid.Empty);
				break;
			}
			case "SignatureText":
				x69997a0ce8a9d0f8.xf9ad6fb78355fe13 = x7450cc1e48712286.x2a1ea9d24e62bf84();
				break;
			case "SignatureType":
				x69997a0ce8a9d0f8.x5c9e4e2dc9b12067 = x7450cc1e48712286.x2a1ea9d24e62bf84() == "2";
				break;
			case "SignatureImage":
			{
				string text = x7450cc1e48712286.x2a1ea9d24e62bf84();
				x69997a0ce8a9d0f8.xcc18177a965e0313 = (x0d299f323d241756.x5959bccb67bbf051(text) ? Convert.FromBase64String(text) : null);
				break;
			}
			default:
				xe1813892c007071d();
				break;
			}
		}
	}

	private x465c7a263669f01c x5db5d47b197d2ff9()
	{
		string uri = x7450cc1e48712286.xd68abcd61e368af9("URI", null);
		ArrayList arrayList = new ArrayList();
		string digestValue = "";
		while (x7450cc1e48712286.x152cbadbfa8061b1("Reference"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "DigestValue":
				digestValue = x7450cc1e48712286.x2a1ea9d24e62bf84();
				break;
			case "Transforms":
				xb07e230897f3bcb9(arrayList);
				break;
			default:
				xe1813892c007071d();
				break;
			}
		}
		return new x465c7a263669f01c(uri, arrayList, digestValue);
	}

	private void xb07e230897f3bcb9(ArrayList x00a4383001d0817a)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("Transforms"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "Transform")
			{
				x00a4383001d0817a.Add(new xaccac17571a8d9fa(x7450cc1e48712286));
			}
			else
			{
				xe1813892c007071d();
			}
		}
	}

	private void xbbf9a1ead81dd3a1(WarningType x43163d22e8cd5a71, WarningSource x337e217cb3ba0627, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x43163d22e8cd5a71, x337e217cb3ba0627, xc2358fbac7da3d45));
		}
	}

	private void xe1813892c007071d()
	{
		string xc2358fbac7da3d = $"Import of element '{x7450cc1e48712286.xa66385d80d4d296f}' is not supported by Aspose.Words.";
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContentCategory, WarningSource.Unknown, xc2358fbac7da3d);
		x7450cc1e48712286.IgnoreElement();
	}
}
