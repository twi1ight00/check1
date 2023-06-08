using System.Drawing;
using System.IO;
using Aspose.Words;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x9b5b1a17490bd5f3;

namespace xe9fa6af9e1184312;

internal class x95792ebebfd0979f : xc1dcd6189d01216e
{
	private readonly x6a39d29c361d653d x93ce70fb4ad3e4ab;

	private readonly x1fdc4491fb4c3ee8 x8cedcaa9a62c6e39;

	internal x1fdc4491fb4c3ee8 x28fcdc775a1d069c => x8cedcaa9a62c6e39;

	internal x6a39d29c361d653d x8a5fa4b54d19c49a => x93ce70fb4ad3e4ab;

	internal x95792ebebfd0979f(Stream stream, string baseUri, x0cd0eeb5ca95cea9 resourceLoader, IWarningCallback warningCallback)
		: base(stream)
	{
		x8cedcaa9a62c6e39 = new x1fdc4491fb4c3ee8(baseUri, resourceLoader, warningCallback);
		x93ce70fb4ad3e4ab = new x6a39d29c361d653d(this);
	}

	internal x95792ebebfd0979f(string svgString, string baseUri, x0cd0eeb5ca95cea9 resourceLoader, IWarningCallback warningCallback)
		: base(svgString, null)
	{
		x8cedcaa9a62c6e39 = new x1fdc4491fb4c3ee8(baseUri, resourceLoader, warningCallback);
		x93ce70fb4ad3e4ab = new x6a39d29c361d653d(this);
	}

	internal x4bb20e393c4d7846 x06b0e25aa6ad68a9()
	{
		float width = xf7e2753b1f50fb2b.xfd3c39adee96110c(xd68abcd61e368af9("width", "0"), x8cedcaa9a62c6e39);
		float height = xf7e2753b1f50fb2b.xfd3c39adee96110c(xd68abcd61e368af9("height", "0"), x8cedcaa9a62c6e39);
		SizeF size = new SizeF(width, height);
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		string text = xd68abcd61e368af9("viewBox", null);
		if (text != null)
		{
			float[] array = xf7e2753b1f50fb2b.x18509d4eed26e020(text);
			if (size.IsEmpty)
			{
				size = new SizeF(array[2], array[3]);
			}
			else
			{
				x54366fa5f75a02f.x5152a5707921c783(size.Width / array[2], size.Height / array[3]);
			}
		}
		x28fcdc775a1d069c.xc9443bca5b0a56d8.x52dde376accdec7d = x54366fa5f75a02f;
		x28fcdc775a1d069c.xc9443bca5b0a56d8.x52dde376accdec7d.x5152a5707921c783(x4574ea26106f0edb.x755f7ed650852c8b, x4574ea26106f0edb.x755f7ed650852c8b);
		while (x152cbadbfa8061b1("svg"))
		{
			string text2;
			if ((text2 = base.xa66385d80d4d296f) != null && text2 == "defs")
			{
				xae735e551e191376.x18f8d6d1a9fa2e58(this);
			}
			else
			{
				xae735e551e191376.x152cbadbfa8061b1(this);
			}
		}
		return new x4bb20e393c4d7846(x28fcdc775a1d069c.xc9443bca5b0a56d8, size);
	}

	internal void x785b2d167d8a3ca9(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		x28fcdc775a1d069c.xbbf9a1ead81dd3a1(x9f91de645a9fe01a, xc2358fbac7da3d45);
		IgnoreElement();
	}
}
