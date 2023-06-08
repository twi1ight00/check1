using System;
using System.Collections;
using x28925c9b27b37a46;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;

namespace x611adfb9b9d21a97;

internal class x78127fc231459d47 : xb00f4ba8788bbec8
{
	private const string xe2ecd66abb7dded6 = "ncx";

	private readonly IEnumerable x178ddd705e9f9e3a;

	private readonly IEnumerable x28ff454763e2f336;

	private readonly bool xcd5437e9c018b4ce;

	private IDictionary xa31881898539d48c;

	internal x78127fc231459d47(string documentBaseName, x8556eed81191af11 saveInfo, IEnumerable documentParts, IEnumerable realSubsidiaryParts, bool doesCoverExist)
		: base(xb00f4ba8788bbec8.x845b43043aba36eb(documentBaseName), documentBaseName, saveInfo)
	{
		x178ddd705e9f9e3a = documentParts;
		x28ff454763e2f336 = realSubsidiaryParts;
		xcd5437e9c018b4ce = doesCoverExist;
	}

	internal void x95d1f647e5465823()
	{
		base.x5222f4285e37d66b.WriteStartDocument();
		x2307058321cdb62f("package");
		xff520a0047c27122("xmlns", "http://www.idpf.org/2007/opf");
		xff520a0047c27122("version", "2.0");
		xff520a0047c27122("unique-identifier", "uid");
		xadfb6a0f6196041c();
		x78b7cf01544dc56d();
		x32dff6e2603de502();
		x5dc9a0c111d5fe69();
		x8bbf8127485b9267();
		xa0dfc102c691b11f();
	}

	private void xadfb6a0f6196041c()
	{
		x2307058321cdb62f("metadata");
		xff520a0047c27122("xmlns:opf", "http://www.idpf.org/2007/opf");
		xff520a0047c27122("xmlns:dc", "http://purl.org/dc/elements/1.1/");
		x6d7247ebbf9a7643("dc:title", xb00f4ba8788bbec8.x4f579785e809375e(base.xbd43463cc8d073a3.BuiltInDocumentProperties.Title));
		x20cc788cf9f8d542();
		x6d7247ebbf9a7643("dc:publisher", base.xbd43463cc8d073a3.BuiltInDocumentProperties.Company);
		x05e6e2c11290d2b0("dc:date", "opf:event", "creation", x6c5a8155986f57f0(base.xbd43463cc8d073a3.BuiltInDocumentProperties.CreatedTime));
		x05e6e2c11290d2b0("dc:date", "opf:event", "modification", x6c5a8155986f57f0(base.xbd43463cc8d073a3.BuiltInDocumentProperties.LastSavedTime));
		if (base.xf57de0fd37d5e97d.x259fc7094d171627)
		{
			x05e6e2c11290d2b0("dc:date", "opf:event", "publication", x6c5a8155986f57f0(x7546e38fbb25d738.xc044302ca1c0d3c7().ToUniversalTime()));
		}
		x6d7247ebbf9a7643("dc:subject", base.xbd43463cc8d073a3.BuiltInDocumentProperties.Subject);
		x6d7247ebbf9a7643("dc:description", base.xbd43463cc8d073a3.BuiltInDocumentProperties.Comments);
		x05e6e2c11290d2b0("dc:identifier", "id", "uid", "urn:uuid:" + xa19c1513d8b80a8b.xdf7c5a607de91fb9());
		x6d7247ebbf9a7643("dc:language", x0a758a5b915637a6());
		if (base.xf57de0fd37d5e97d.xbfa4c2c3efbf56fd)
		{
			x05e6e2c11290d2b0("dc:contributor", "opf:role", "bkp", "Aspose.Words for .NET 11.9.0.0");
			x4495d55170e56e28("generator", "Aspose.Words for .NET 11.9.0.0");
		}
		x538f0e0fb2bf15ab();
	}

	private void x32dff6e2603de502()
	{
		x2307058321cdb62f("manifest");
		xd7291e61669f7d2f("ncx", xb00f4ba8788bbec8.xc40d5fe84864cc92(base.xf1929ebebc6226d4, x6c20b1df8047763a: true), "application/x-dtbncx+xml");
		x97abb5dc2596ccc0();
		x538f0e0fb2bf15ab();
	}

	private void x5dc9a0c111d5fe69()
	{
		x2307058321cdb62f("spine");
		xff520a0047c27122("toc", xe7c12e37a93df4a1("ncx"));
		foreach (xd59a0d3f8248c4e8 item in x178ddd705e9f9e3a)
		{
			x670c76293d9d1a7e(item.xb405a444ca77e2d4);
		}
		x538f0e0fb2bf15ab();
	}

	private void x8bbf8127485b9267()
	{
		if (xcd5437e9c018b4ce)
		{
			x2307058321cdb62f("guide");
			xc049ea80ee267201("reference", "href", "cover/cover-page.html", "type", "cover", "title", "Cover");
			x538f0e0fb2bf15ab();
		}
	}

	private void x97abb5dc2596ccc0()
	{
		foreach (xd59a0d3f8248c4e8 item in x178ddd705e9f9e3a)
		{
			xd7291e61669f7d2f(item);
		}
		foreach (xd59a0d3f8248c4e8 item2 in x28ff454763e2f336)
		{
			xd7291e61669f7d2f(item2);
		}
	}

	private void xd7291e61669f7d2f(string xeaf1b27180c0557b, string x585da4d9795fa783, string x9c1b9627c9a8cad5)
	{
		x2307058321cdb62f("item");
		xff520a0047c27122("id", xe7c12e37a93df4a1(xeaf1b27180c0557b));
		xff520a0047c27122("href", x585da4d9795fa783);
		xff520a0047c27122("media-type", x9c1b9627c9a8cad5);
		x2dfde153f4ef96d0();
	}

	private void x670c76293d9d1a7e(string x02d45996d46ac8a2)
	{
		x2307058321cdb62f("itemref");
		xff520a0047c27122("idref", xe7c12e37a93df4a1(x02d45996d46ac8a2));
		x2dfde153f4ef96d0();
	}

	private void xd7291e61669f7d2f(xd59a0d3f8248c4e8 xd7e5673853e47af4)
	{
		xd7291e61669f7d2f(xd7e5673853e47af4.xb405a444ca77e2d4, xd7e5673853e47af4.xb405a444ca77e2d4, xd7e5673853e47af4.x0b93856f95be30d0);
	}

	private static string x6c5a8155986f57f0(DateTime x38bda74a1c1f84d7)
	{
		return x38bda74a1c1f84d7.ToString("yyyy-MM-dd");
	}

	private void x78b7cf01544dc56d()
	{
		x94c83b1ca7961561 x94c83b1ca = x94c83b1ca7961561.x964c8ab59da5fc93();
		x94c83b1ca.xd6b6ed77479ef68c("ncx");
		foreach (xd59a0d3f8248c4e8 item in x178ddd705e9f9e3a)
		{
			x94c83b1ca.xd6b6ed77479ef68c(item.xb405a444ca77e2d4);
		}
		foreach (xd59a0d3f8248c4e8 item2 in x28ff454763e2f336)
		{
			x94c83b1ca.xd6b6ed77479ef68c(item2.xb405a444ca77e2d4);
		}
		xa31881898539d48c = x3c74b3c4f21844f9.x43dbf3137e50f2b1(x94c83b1ca);
	}

	private string xe7c12e37a93df4a1(string xeaf1b27180c0557b)
	{
		if (xa31881898539d48c != null)
		{
			object obj = xa31881898539d48c[xeaf1b27180c0557b];
			if (obj != null)
			{
				xeaf1b27180c0557b = (string)obj;
			}
		}
		return xeaf1b27180c0557b;
	}

	private void x20cc788cf9f8d542()
	{
		string[] array = base.xbd43463cc8d073a3.BuiltInDocumentProperties.Author.Split(';');
		string[] array2 = array;
		foreach (string text in array2)
		{
			x05e6e2c11290d2b0("dc:creator", "opf:role", "aut", text.Trim());
		}
	}
}
