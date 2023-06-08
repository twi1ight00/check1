using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using Aspose;
using x13f1efc79617a47b;
using x45a758cd6bdecee3;
using x4e7ae5a4b27b0834;
using x6c95d9cf46ff5f25;
using xeb665d1aeef09d64;
using xf9a9481c3f63a419;

namespace x66dd9eaee57cfba4;

internal class x6412d0c71c34c05c
{
	private xb9381f7c20d1401f x552dcaea09c9eb8c;

	private xd3f6a3354dad6708 xe5806508b99b4271;

	private xcfe8f756bd6386e3 x7481c01aab7a7ae8;

	private x52be9978b7030549 xc99e7b2f3b86ef10;

	private xd369be2fe9fecb8f xe905f7b98c1c65f8;

	private x544bfb321207189e xdbae18b86b90a18d;

	private x49a6906320d20269 x82c8b9fd84e1be0e;

	private x62bf5fe8b95eb273 x5ec253c14df6e7d5;

	private x1ece977f7d959313 x35586a6d4a124db9;

	private x89129abe6fed968f x95162d9d08feb9b0;

	private MemoryStream xfa9338b24a8ae193;

	private MemoryStream xe369b832801df70f;

	private MemoryStream x71029bd9bd7cc7db;

	private int x6d07d37f31ad3410;

	private readonly IDictionary xe0c94964fa843aff;

	private uint[] x7948f202c4196a35;

	private bool xf4e6ccc261843f82;

	private static readonly string[] xbcb3b327d67918a3 = new string[8] { "head", "hhea", "hmtx", "maxp", "cmap", "OS/2", "name", "post" };

	internal x6b1a899052c71a60 x06b0e25aa6ad68a9(x25998da3963930e9 x0db5e88527e18b81, string x9e9070c6c983bbc0)
	{
		using Stream xcf18e5243f8d5fd = x0db5e88527e18b81.OpenStream();
		x6b1a899052c71a60 x6b1a899052c71a61 = x06b0e25aa6ad68a9(xcf18e5243f8d5fd, x9e9070c6c983bbc0);
		x6b1a899052c71a61.x6b73aa01aa019d3a = x0db5e88527e18b81;
		return x6b1a899052c71a61;
	}

	internal x6b1a899052c71a60 x06b0e25aa6ad68a9(string xafe2f3653ee64ebc, string x9e9070c6c983bbc0)
	{
		return x06b0e25aa6ad68a9(new xda6c010448467ed0(xafe2f3653ee64ebc), x9e9070c6c983bbc0);
	}

	internal x6b1a899052c71a60 x06b0e25aa6ad68a9(byte[] x0db5e88527e18b81, string x9e9070c6c983bbc0)
	{
		return x06b0e25aa6ad68a9(new x6033a882faba96b0(x0db5e88527e18b81), x9e9070c6c983bbc0);
	}

	private x6b1a899052c71a60 x06b0e25aa6ad68a9(Stream xcf18e5243f8d5fd3, string x9e9070c6c983bbc0)
	{
		x552dcaea09c9eb8c = new xb9381f7c20d1401f(xcf18e5243f8d5fd3);
		xd3986a9a696750ef(x9e9070c6c983bbc0);
		x49e790376f69655f();
		xec873a747e2d31e9();
		x296d467371e987ca();
		x068568c492d69ec9();
		x161ff565a8bb0a60();
		x14e0c491b2fcc9c5();
		x91bbfcfd0659047b();
		xacd181be2475020c();
		return xe4d510ea988cdfc6();
	}

	internal x8989ff189b375934[] x0c269939c278bc2d(string xafe2f3653ee64ebc)
	{
		return x0c269939c278bc2d(new xda6c010448467ed0(xafe2f3653ee64ebc));
	}

	internal x8989ff189b375934[] x0c269939c278bc2d(x25998da3963930e9 x0db5e88527e18b81)
	{
		if (!x0db5e88527e18b81.DoesDataExist())
		{
			return new x8989ff189b375934[0];
		}
		using Stream stream = x0db5e88527e18b81.OpenStream();
		x552dcaea09c9eb8c = new xb9381f7c20d1401f(stream);
		if (x4844fc2da9a685e0())
		{
			x8989ff189b375934[] array = xba3fd659a76bd0e7();
			x8989ff189b375934[] array2 = array;
			foreach (x8989ff189b375934 x8989ff189b in array2)
			{
				x8989ff189b.x6b73aa01aa019d3a = x0db5e88527e18b81;
				x8989ff189b.xbdb46eca7415042d = true;
			}
			return array;
		}
		if (xf12998db6164da10(0))
		{
			xec873a747e2d31e9();
			x8989ff189b375934[] array3 = xe905f7b98c1c65f8.x0033df3de08eb797();
			x8989ff189b375934[] array4 = array3;
			foreach (x8989ff189b375934 x8989ff189b2 in array4)
			{
				x8989ff189b2.x6b73aa01aa019d3a = x0db5e88527e18b81;
				x8989ff189b2.xbdb46eca7415042d = false;
			}
			return array3;
		}
		return null;
	}

	internal void x81f3fe7a911999bc(x6b1a899052c71a60 x26094932cf7a9139, Stream xedc894794186020d)
	{
		if (x26094932cf7a9139 == null)
		{
			throw new ArgumentNullException("font");
		}
		using Stream stream = x26094932cf7a9139.x6b73aa01aa019d3a.OpenStream();
		x552dcaea09c9eb8c = new xb9381f7c20d1401f(stream);
		xd3986a9a696750ef(x26094932cf7a9139.x0a4b32fbe2e5933b);
		x483dcea572fd1c73 x483dcea572fd1c = new x483dcea572fd1c73(x552dcaea09c9eb8c.xc3be943b246eeabb.x77fa6322561797a0);
		foreach (string key in x552dcaea09c9eb8c.x5eab864c00224c02.Keys)
		{
			x483dcea572fd1c.x53eb838d813e202e(key, x552dcaea09c9eb8c.xed7d554f6c638fb0(key));
		}
		x483dcea572fd1c.x631c3b95a074f9f3(xedc894794186020d);
	}

	[JavaThrows(true)]
	internal void x8451c08dacb59ada(x6b1a899052c71a60 x26094932cf7a9139, x09ce2c02826e31a6 xf587a89edd1bf25b, x09ce2c02826e31a6 xccf4043581d152c5, Stream xedc894794186020d)
	{
		if (x26094932cf7a9139 == null)
		{
			throw new ArgumentNullException("font");
		}
		if (xccf4043581d152c5 == null)
		{
			throw new ArgumentNullException("oldToNewGlyphIndexes");
		}
		if (xedc894794186020d == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		using Stream stream = x26094932cf7a9139.x6b73aa01aa019d3a.OpenStream();
		x552dcaea09c9eb8c = new xb9381f7c20d1401f(stream);
		xd3986a9a696750ef(x26094932cf7a9139.x0a4b32fbe2e5933b);
		x49e790376f69655f();
		x068568c492d69ec9();
		x161ff565a8bb0a60();
		x14e0c491b2fcc9c5();
		x91bbfcfd0659047b();
		x3e279516c28aacfc();
		x5144935bba1eeb83 x5144935bba1eeb84 = new x5144935bba1eeb83(x552dcaea09c9eb8c.x7468be44f5498f9f, xe5806508b99b4271.x3ac3494a627eff42);
		ushort num = (ushort)x5144935bba1eeb84.x44ee2c4f3463a01c(x20e84da7fe09eae6("loca"), x20e84da7fe09eae6("glyf"), x82c8b9fd84e1be0e, xccf4043581d152c5);
		if (num != xccf4043581d152c5.xd44988f225497f3a)
		{
			throw new InvalidOperationException("Unexpected used glyphs count!");
		}
		xfa9338b24a8ae193 = x5144935bba1eeb84.x8f64841d1796a33d;
		xe369b832801df70f = x5144935bba1eeb84.xe173d615c7a9da13;
		x71029bd9bd7cc7db = x5144935bba1eeb84.x25caa2389941bd02;
		xc99e7b2f3b86ef10.xf465816ce1e6196c = num;
		x7481c01aab7a7ae8.x68ab60d77e158693 = num;
		x5ec253c14df6e7d5.xbb283a1aa30876b0(xf587a89edd1bf25b);
		x35586a6d4a124db9.xbb283a1aa30876b0(xccf4043581d152c5);
		x4cfaa5254ea0d86a(xedc894794186020d);
	}

	internal void xb9dd1993971153a6(x6b1a899052c71a60 x26094932cf7a9139, x09ce2c02826e31a6 x1c6a97d3a496e7e2, Stream xedc894794186020d, bool x99dfcd8f51a71564)
	{
		if (x26094932cf7a9139 == null)
		{
			throw new ArgumentNullException("font");
		}
		if (x1c6a97d3a496e7e2 == null)
		{
			throw new ArgumentNullException("usedGlyphs");
		}
		if (xedc894794186020d == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		using Stream stream = x26094932cf7a9139.x6b73aa01aa019d3a.OpenStream();
		x552dcaea09c9eb8c = new xb9381f7c20d1401f(stream);
		xd3986a9a696750ef(x26094932cf7a9139.x0a4b32fbe2e5933b);
		x552dcaea09c9eb8c.x98741c31b7c91763("CFF ");
		x3a5e4dec5f70539d x3a5e4dec5f70539d = x3a5e4dec5f70539d.x06b0e25aa6ad68a9(x552dcaea09c9eb8c.x7468be44f5498f9f);
		x3a5e4dec5f70539d.Subset(x1c6a97d3a496e7e2);
		if (x99dfcd8f51a71564)
		{
			x3a5e4dec5f70539d.x8d81a984b7f0332e(xedc894794186020d);
			return;
		}
		x483dcea572fd1c73 x483dcea572fd1c = new x483dcea572fd1c73(x552dcaea09c9eb8c.xc3be943b246eeabb.x77fa6322561797a0);
		x483dcea572fd1c.x53eb838d813e202e("CFF ", x3a5e4dec5f70539d.xbdc1ba5a08db0865());
		string[] array = xbcb3b327d67918a3;
		foreach (string text in array)
		{
			if (x552dcaea09c9eb8c.x5eab864c00224c02.ContainsKey(text))
			{
				x483dcea572fd1c.x53eb838d813e202e(text, x552dcaea09c9eb8c.xed7d554f6c638fb0(text));
			}
		}
		x483dcea572fd1c.x631c3b95a074f9f3(xedc894794186020d);
	}

	[JavaThrows(true)]
	internal Hashtable x0154acd692bb64a0(x6b1a899052c71a60 x26094932cf7a9139, x09ce2c02826e31a6 xccf4043581d152c5, int xcb0ea7d30675ed7c)
	{
		if (x26094932cf7a9139 == null)
		{
			throw new ArgumentNullException("font");
		}
		if (xccf4043581d152c5 == null)
		{
			throw new ArgumentNullException("oldToNewGlyphIndexes");
		}
		using Stream stream = x26094932cf7a9139.x6b73aa01aa019d3a.OpenStream();
		x552dcaea09c9eb8c = new xb9381f7c20d1401f(stream);
		xd3986a9a696750ef(x26094932cf7a9139.x0a4b32fbe2e5933b);
		x49e790376f69655f();
		x5144935bba1eeb83 x5144935bba1eeb84 = new x5144935bba1eeb83(x552dcaea09c9eb8c.x7468be44f5498f9f, xe5806508b99b4271.x3ac3494a627eff42);
		return x5144935bba1eeb84.x134ce7d8db68e2e5(x20e84da7fe09eae6("loca"), x20e84da7fe09eae6("glyf"), xccf4043581d152c5, xcb0ea7d30675ed7c);
	}

	private void x3e279516c28aacfc()
	{
		x552dcaea09c9eb8c.x98741c31b7c91763("post");
		x35586a6d4a124db9 = new x1ece977f7d959313(x552dcaea09c9eb8c.x7468be44f5498f9f);
	}

	[JavaThrows(true)]
	private void xd3986a9a696750ef(string x9e9070c6c983bbc0)
	{
		xf4e6ccc261843f82 = false;
		if (x4844fc2da9a685e0())
		{
			xf4e6ccc261843f82 = true;
			xba3fd659a76bd0e7();
			uint x374ea4fe62468d0f = (uint)xe0c94964fa843aff[x9e9070c6c983bbc0];
			if (!xf12998db6164da10((int)x374ea4fe62468d0f))
			{
				throw new InvalidOperationException("The TTC font is invalid.");
			}
		}
		else if (!xf12998db6164da10(0))
		{
			throw new InvalidOperationException("The file is not recognized as a TTF or TTC font.");
		}
	}

	private bool xf12998db6164da10(int x374ea4fe62468d0f)
	{
		x552dcaea09c9eb8c.x9e418ad9a56d1cf5.Position = x374ea4fe62468d0f;
		return x552dcaea09c9eb8c.x4c69b151997c4a03();
	}

	private void x49e790376f69655f()
	{
		x552dcaea09c9eb8c.x98741c31b7c91763("head");
		xe5806508b99b4271 = xd3f6a3354dad6708.x06b0e25aa6ad68a9(x552dcaea09c9eb8c.x7468be44f5498f9f);
	}

	private void x068568c492d69ec9()
	{
		x552dcaea09c9eb8c.x98741c31b7c91763("hhea");
		x7481c01aab7a7ae8 = new xcfe8f756bd6386e3(x552dcaea09c9eb8c.x7468be44f5498f9f);
	}

	private void x161ff565a8bb0a60()
	{
		x552dcaea09c9eb8c.x98741c31b7c91763("maxp");
		xc99e7b2f3b86ef10 = new x52be9978b7030549(x552dcaea09c9eb8c.x7468be44f5498f9f);
	}

	[JavaThrows(true)]
	private void xec873a747e2d31e9()
	{
		x552dcaea09c9eb8c.x98741c31b7c91763("name");
		xa8b3ec28bb8af623();
	}

	private void x296d467371e987ca()
	{
		x552dcaea09c9eb8c.x98741c31b7c91763("OS/2");
		xdbae18b86b90a18d = new x544bfb321207189e(x552dcaea09c9eb8c.x7468be44f5498f9f);
	}

	[JavaThrows(true)]
	private void x14e0c491b2fcc9c5()
	{
		if (x7481c01aab7a7ae8 == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mmhpaoopnnfajnmacjdbdokblnbcjiicinpcimgdbmndbmeekhleplcfdmjfdmaghlhgfmoghlfhdlmhgldiakkiikbjjfijojpjijgkbjnkbjelpilljjcmeejmhianhihnnionlifojimoaedp", 1061156734)));
		}
		if (xc99e7b2f3b86ef10 == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hnfglomgiodheokhnjbiooiigopiejgjdonjdnekmmlkmmclfijlpmamamhmenomcmfndmmnimdonlkongbpklipjlppdlgahknahkebhklbnjccffjcijadijhdojodmjfekjmebfdf", 1721263497)));
		}
		x552dcaea09c9eb8c.x98741c31b7c91763("hmtx");
		x82c8b9fd84e1be0e = new x49a6906320d20269(x552dcaea09c9eb8c.x7468be44f5498f9f, x7481c01aab7a7ae8.x68ab60d77e158693, xc99e7b2f3b86ef10.xf465816ce1e6196c);
	}

	private void x91bbfcfd0659047b()
	{
		x552dcaea09c9eb8c.x98741c31b7c91763("cmap");
		x5ec253c14df6e7d5 = x62bf5fe8b95eb273.x06b0e25aa6ad68a9(x552dcaea09c9eb8c.x7468be44f5498f9f);
	}

	private void xacd181be2475020c()
	{
		if (x552dcaea09c9eb8c.x5eab864c00224c02.ContainsKey("kern"))
		{
			x552dcaea09c9eb8c.x98741c31b7c91763("kern");
			x95162d9d08feb9b0 = x89129abe6fed968f.x06b0e25aa6ad68a9(x552dcaea09c9eb8c.x7468be44f5498f9f);
		}
		else
		{
			x95162d9d08feb9b0 = new x89129abe6fed968f();
		}
	}

	private x6b1a899052c71a60 xe4d510ea988cdfc6()
	{
		x6b1a899052c71a60 x6b1a899052c71a61 = new x6b1a899052c71a60();
		x6b1a899052c71a61.xbdb46eca7415042d = xf4e6ccc261843f82;
		if (x552dcaea09c9eb8c.x5eab864c00224c02.ContainsKey("CFF "))
		{
			x6b1a899052c71a61.xba2310b1d8e576ad = true;
		}
		x6b1a899052c71a61.xa25a0348a20dc6ca = xe5806508b99b4271.x0b1ef6b23d680fe3;
		x6b1a899052c71a61.x9462c8df936efa39 = xe5806508b99b4271.x9462c8df936efa39;
		x6b1a899052c71a61.x5b051452efe1bbe3 = xe5806508b99b4271.x5b051452efe1bbe3;
		x6b1a899052c71a61.x11f73230b9b436a7 = xe5806508b99b4271.x11f73230b9b436a7;
		x6b1a899052c71a61.xbed6b6abe5a7fcce = xe5806508b99b4271.xbed6b6abe5a7fcce;
		x6b1a899052c71a61.xcfd74ea92eb72d29(xe905f7b98c1c65f8);
		if (x6b1a899052c71a61.xba2310b1d8e576ad)
		{
			x6b1a899052c71a61.x3f80ed349f729542 = xdbae18b86b90a18d.xd0b0427ee1010122;
			x6b1a899052c71a61.xc9f7bec53c29c691 = xdbae18b86b90a18d.x6b3b3a3faf27dfa9;
			x6b1a899052c71a61.x84bbacdc1fc0efd2 = xdbae18b86b90a18d.xd0b0427ee1010122 + xdbae18b86b90a18d.x6b3b3a3faf27dfa9;
		}
		else if (xdbae18b86b90a18d.x831246fb77132649)
		{
			x6b1a899052c71a61.x3f80ed349f729542 = xdbae18b86b90a18d.xe7f4daf2bffbe4bf;
			x6b1a899052c71a61.xc9f7bec53c29c691 = -xdbae18b86b90a18d.x3dc0f0b75cf5adfa;
			x6b1a899052c71a61.x84bbacdc1fc0efd2 = xdbae18b86b90a18d.xe7f4daf2bffbe4bf - xdbae18b86b90a18d.x3dc0f0b75cf5adfa + xdbae18b86b90a18d.xf63d44293279a976;
		}
		else
		{
			x6b1a899052c71a61.x3f80ed349f729542 = xdbae18b86b90a18d.xd0b0427ee1010122;
			x6b1a899052c71a61.xc9f7bec53c29c691 = xdbae18b86b90a18d.x6b3b3a3faf27dfa9;
			int num = Math.Max(0, x7481c01aab7a7ae8.x67e8548afda7b90c - (xdbae18b86b90a18d.xd0b0427ee1010122 + xdbae18b86b90a18d.x6b3b3a3faf27dfa9 - (x7481c01aab7a7ae8.xfd864ef60631ea73 - x7481c01aab7a7ae8.xfff52c3720db70a6)));
			x6b1a899052c71a61.x84bbacdc1fc0efd2 = xdbae18b86b90a18d.xd0b0427ee1010122 + xdbae18b86b90a18d.x6b3b3a3faf27dfa9 + num;
		}
		if (xdbae18b86b90a18d.xd6d3c04b6c9d936e)
		{
			int num2 = x6b1a899052c71a61.x3f80ed349f729542 + x6b1a899052c71a61.xc9f7bec53c29c691 - xe5806508b99b4271.x0b1ef6b23d680fe3;
			int num3 = num2 / 2;
			int num4 = num2 - num3;
			int num5 = (int)(0.3 * (double)(x6b1a899052c71a61.x3f80ed349f729542 + x6b1a899052c71a61.xc9f7bec53c29c691));
			num5 -= num2;
			num2 = ((num5 > 0) ? num5 : 0);
			x6b1a899052c71a61.x3f80ed349f729542 += num3;
			x6b1a899052c71a61.xc9f7bec53c29c691 += num4;
			x6b1a899052c71a61.x84bbacdc1fc0efd2 = x6b1a899052c71a61.x3f80ed349f729542 + x6b1a899052c71a61.xc9f7bec53c29c691 + num2;
		}
		x6b1a899052c71a61.xb874556d20cb64ce = (float)((0.0 - Math.Atan2(x7481c01aab7a7ae8.xb43e7c8589fea193, x7481c01aab7a7ae8.xbd59069cd9298a07)) * 180.0 / Math.PI);
		x6b1a899052c71a61.x567844ee92f39466 = xdbae18b86b90a18d.xb22216c7fc819d19;
		x6b1a899052c71a61.x1e20a853b265cde8 = xdbae18b86b90a18d.x9e62c39863c0c0d5;
		x6b1a899052c71a61.x963b10c892d3845d = xdbae18b86b90a18d.xdb66cf45215884e3;
		x6b1a899052c71a61.xb0b81ac8c8f9bb69 = xdbae18b86b90a18d.xb4d0f84025a3a6eb;
		x6b1a899052c71a61.x6cb0364e17e0007b = xdbae18b86b90a18d.xe0674d45db4757b9;
		x6b1a899052c71a61.xf68583791f1c6ec1 = xdbae18b86b90a18d.x0a910e98c67c27f6;
		x6b1a899052c71a61.xfe2178c1f916f36c = ((xdbae18b86b90a18d.x999b99e9928b906c == 0) ? xe5806508b99b4271.xfe2178c1f916f36c : xdbae18b86b90a18d.xfe2178c1f916f36c);
		if (x0d299f323d241756.x263d579af1d0d43f(x6b1a899052c71a61.x8eab654c3f64ae79, "Bold", x8b05b1454697839b: true))
		{
			x6b1a899052c71a61.xfe2178c1f916f36c |= FontStyle.Bold;
		}
		if (x0d299f323d241756.x263d579af1d0d43f(x6b1a899052c71a61.x8eab654c3f64ae79, "Italic", x8b05b1454697839b: true))
		{
			x6b1a899052c71a61.xfe2178c1f916f36c |= FontStyle.Italic;
		}
		x6b1a899052c71a61.x912ee4c8583acc0f = xdbae18b86b90a18d.x655848db2af557bc;
		x6b1a899052c71a61.xadc83cc585a89881 = x5ec253c14df6e7d5.IsSymbolEncoding | xdbae18b86b90a18d.x97a3eef828c0255f;
		x6b1a899052c71a61.x1e6da4134d115607 = x5ec253c14df6e7d5.x914b35472a606900(x82c8b9fd84e1be0e, x6b1a899052c71a61.xadc83cc585a89881);
		x6b1a899052c71a61.x62bf5fe8b95eb273 = x5ec253c14df6e7d5;
		x6b1a899052c71a61.xc8040096b176b4af = (xdbae18b86b90a18d.xf0c26ba5a725ab49 & 4u) != 0 && (xdbae18b86b90a18d.xf0c26ba5a725ab49 & 8) == 0;
		x6b1a899052c71a61.xc955b0b111c9581c = x95162d9d08feb9b0.xc955b0b111c9581c;
		return x6b1a899052c71a61;
	}

	[JavaThrows(true)]
	private x1d5a785c8d5b14ee x20e84da7fe09eae6(string xde5031b4f06bf874)
	{
		x1d5a785c8d5b14ee x1d5a785c8d5b14ee = (x1d5a785c8d5b14ee)x552dcaea09c9eb8c.x5eab864c00224c02[xde5031b4f06bf874];
		if (x1d5a785c8d5b14ee == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("odpgjfghdgnhageiofliagcjjajjmeakmehkoeokbeflkpllledmfdkmddbnkdinadpniofomomondeppokpjdcaaoiagnpambhbobobnmecobmcpaddjakdbmaeeaiekapegagfjanfcldgfpkgfpbhfpihlophblgi", 2103668475)), xde5031b4f06bf874));
		}
		return x1d5a785c8d5b14ee;
	}

	public x6412d0c71c34c05c()
	{
		xe0c94964fa843aff = xd51c34d05311eee3.xdb04a310bbb29cff();
	}

	private bool x4844fc2da9a685e0()
	{
		x552dcaea09c9eb8c.x7468be44f5498f9f.x9e418ad9a56d1cf5.Position = 0L;
		string text = new string(x552dcaea09c9eb8c.x7468be44f5498f9f.x9a839f0ae94bc95f(4));
		if (text != "ttcf")
		{
			return false;
		}
		int num = x552dcaea09c9eb8c.x7468be44f5498f9f.x95ea7d23cc8ee04d();
		if (num != 65536 && num != 131072)
		{
			return false;
		}
		x6d07d37f31ad3410 = x552dcaea09c9eb8c.x7468be44f5498f9f.x95ea7d23cc8ee04d();
		x7948f202c4196a35 = new uint[x6d07d37f31ad3410];
		for (int i = 0; i < x6d07d37f31ad3410; i++)
		{
			x7948f202c4196a35[i] = x552dcaea09c9eb8c.x7468be44f5498f9f.x2aa9a7ff4efa6ddf();
		}
		if (131072 == num)
		{
			x552dcaea09c9eb8c.x7468be44f5498f9f.x2aa9a7ff4efa6ddf();
			x552dcaea09c9eb8c.x7468be44f5498f9f.x2aa9a7ff4efa6ddf();
			x552dcaea09c9eb8c.x7468be44f5498f9f.x2aa9a7ff4efa6ddf();
		}
		return true;
	}

	[JavaThrows(true)]
	private x8989ff189b375934[] xba3fd659a76bd0e7()
	{
		if (x6d07d37f31ad3410 <= 0)
		{
			throw new InvalidOperationException("Can't read TTC entry.");
		}
		ArrayList x1227680f65afc6ed = new ArrayList();
		for (int i = 0; i < x6d07d37f31ad3410; i++)
		{
			x552dcaea09c9eb8c.x9e418ad9a56d1cf5.Position = x7948f202c4196a35[i];
			x552dcaea09c9eb8c.x43325fdd19b94194();
			x552dcaea09c9eb8c.x98741c31b7c91763("name");
			xa8b3ec28bb8af623();
			string[] array = xe905f7b98c1c65f8.x42d74655af47d6fb(x075846a119f47dd1.x0a4b32fbe2e5933b);
			string[] array2 = array;
			foreach (string key in array2)
			{
				xe0c94964fa843aff[key] = x7948f202c4196a35[i];
			}
			x8989ff189b375934[] array3 = xe905f7b98c1c65f8.x0033df3de08eb797();
			if (array3 != null)
			{
				x035ecd5b20472cb6(x1227680f65afc6ed, array3);
			}
		}
		return xdac10f2874916128(x1227680f65afc6ed);
	}

	[JavaThrows(true)]
	private void xa8b3ec28bb8af623()
	{
		long position = x552dcaea09c9eb8c.x7468be44f5498f9f.x9e418ad9a56d1cf5.Position;
		if (x552dcaea09c9eb8c.x7468be44f5498f9f.xdb264d863790ee7b() != 0)
		{
			throw new InvalidOperationException("Unsupported Name table format.");
		}
		ushort num = x552dcaea09c9eb8c.x7468be44f5498f9f.xdb264d863790ee7b();
		ushort num2 = x552dcaea09c9eb8c.x7468be44f5498f9f.xdb264d863790ee7b();
		xe905f7b98c1c65f8 = new xd369be2fe9fecb8f();
		for (int i = 0; i < num; i++)
		{
			int num3 = x552dcaea09c9eb8c.x7468be44f5498f9f.xdb264d863790ee7b();
			int num4 = x552dcaea09c9eb8c.x7468be44f5498f9f.xdb264d863790ee7b();
			int x7b0d599fbcbd = x552dcaea09c9eb8c.x7468be44f5498f9f.xdb264d863790ee7b();
			int x4fb5718687161b = x552dcaea09c9eb8c.x7468be44f5498f9f.xdb264d863790ee7b();
			int x10f4d88af727adbc = x552dcaea09c9eb8c.x7468be44f5498f9f.xdb264d863790ee7b();
			int num5 = x552dcaea09c9eb8c.x7468be44f5498f9f.xdb264d863790ee7b();
			Encoding encoding = null;
			switch (num3)
			{
			case 0:
				encoding = Encoding.BigEndianUnicode;
				break;
			case 1:
				if (num4 == 0 || num4 == 1 || num4 == 2 || num4 == 3 || num4 == 25)
				{
					encoding = Encoding.GetEncoding(1252);
				}
				break;
			case 3:
				if (num4 == 1 || num4 == 10 || num4 == 0)
				{
					encoding = Encoding.BigEndianUnicode;
				}
				break;
			}
			if (encoding != null)
			{
				int num6 = (int)x552dcaea09c9eb8c.x7468be44f5498f9f.x9e418ad9a56d1cf5.Position;
				x552dcaea09c9eb8c.x7468be44f5498f9f.x9e418ad9a56d1cf5.Position = position + num2 + num5;
				byte[] bytes = x552dcaea09c9eb8c.x7468be44f5498f9f.x0f6807cca84a8e5b(x10f4d88af727adbc);
				string @string = encoding.GetString(bytes);
				xe905f7b98c1c65f8.xd6b6ed77479ef68c((x075846a119f47dd1)x4fb5718687161b, x7b0d599fbcbd, @string);
				x552dcaea09c9eb8c.x7468be44f5498f9f.x9e418ad9a56d1cf5.Position = num6;
			}
		}
	}

	private static void x035ecd5b20472cb6(ArrayList x1227680f65afc6ed, x8989ff189b375934[] x9d5750eb2d6373bc)
	{
		for (int i = 0; i < x9d5750eb2d6373bc.Length; i++)
		{
			x1227680f65afc6ed.Add(x9d5750eb2d6373bc[i]);
		}
	}

	private static x8989ff189b375934[] xdac10f2874916128(ArrayList x1227680f65afc6ed)
	{
		x8989ff189b375934[] array = new x8989ff189b375934[x1227680f65afc6ed.Count];
		for (int i = 0; i < x1227680f65afc6ed.Count; i++)
		{
			array[i] = (x8989ff189b375934)x1227680f65afc6ed[i];
		}
		return array;
	}

	private void x4cfaa5254ea0d86a(Stream xedc894794186020d)
	{
		x483dcea572fd1c73 x483dcea572fd1c = new x483dcea572fd1c73(x552dcaea09c9eb8c.xc3be943b246eeabb.x77fa6322561797a0);
		xefe32cd9eb83bef8(x483dcea572fd1c, "head");
		xfea0a954b4cb9b62(x483dcea572fd1c, "hhea", x7481c01aab7a7ae8.x2797b998ab68f4ab());
		xfea0a954b4cb9b62(x483dcea572fd1c, "maxp", xc99e7b2f3b86ef10.x2797b998ab68f4ab());
		xfea0a954b4cb9b62(x483dcea572fd1c, "hmtx", x71029bd9bd7cc7db.ToArray());
		xefe32cd9eb83bef8(x483dcea572fd1c, "fpgm");
		xefe32cd9eb83bef8(x483dcea572fd1c, "prep");
		xefe32cd9eb83bef8(x483dcea572fd1c, "cvt ");
		xfea0a954b4cb9b62(x483dcea572fd1c, "loca", xfa9338b24a8ae193.ToArray());
		xfea0a954b4cb9b62(x483dcea572fd1c, "glyf", xe369b832801df70f.ToArray());
		xfea0a954b4cb9b62(x483dcea572fd1c, "cmap", x5ec253c14df6e7d5.x2797b998ab68f4ab());
		xefe32cd9eb83bef8(x483dcea572fd1c, "OS/2");
		xefe32cd9eb83bef8(x483dcea572fd1c, "name");
		xfea0a954b4cb9b62(x483dcea572fd1c, "post", x35586a6d4a124db9.x2797b998ab68f4ab());
		x483dcea572fd1c.x631c3b95a074f9f3(xedc894794186020d);
	}

	private void xefe32cd9eb83bef8(x483dcea572fd1c73 xd07ce4b74c5774a7, string xffe521cc76054baf)
	{
		if (x552dcaea09c9eb8c.x5eab864c00224c02.ContainsKey(xffe521cc76054baf))
		{
			xd07ce4b74c5774a7.x53eb838d813e202e(xffe521cc76054baf, x552dcaea09c9eb8c.xed7d554f6c638fb0(xffe521cc76054baf));
		}
	}

	private void xfea0a954b4cb9b62(x483dcea572fd1c73 xd07ce4b74c5774a7, string xffe521cc76054baf, byte[] x4a3f0a05c02f235f)
	{
		xd07ce4b74c5774a7.x53eb838d813e202e(xffe521cc76054baf, x4a3f0a05c02f235f);
	}
}
