using System;
using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;
using xfbd1009a0cbb9842;

namespace x4adf554d20d941a6;

internal class x4e2f8bff72d83f71 : xc63cc34daaa2e2d9
{
	private readonly xa268fdb9ca040dde x800085dd555f7711;

	private x7c5d33e87d9dfc05 x0dafc1ea081e54b2;

	private xb3182f54aafe1dd9 x24931eac10106982;

	private xbb128850ab6e3d33 xa86a4aa59a6cca8f;

	private xc5116a632a92d22c xb80d110a4f8df4a9;

	private xdeb77ea37ad74c56 xd5f4d4b5bdd8e58a;

	private x17dcbf5fe3c0d2d2 x3d3ebc31b37b2a88;

	private Hashtable x4bd039d469a1155d;

	private Hashtable xf4534a93f13f6ff3;

	private Hashtable xae99497208179488;

	private x4af2add38e634ad4 x54ba23be3ab01223;

	private xd410c9b07f3bc70b xedda6ffaac616530;

	internal override x5a5e07e9fa12451a x5a5e07e9fa12451a => x5a5e07e9fa12451a.x2c8c6741422a1298;

	internal override x4e2f8bff72d83f71 x2c8c6741422a1298 => this;

	internal override xac6c82c74ce247fb x53111d6596d16a99 => null;

	internal x7c5d33e87d9dfc05 x80f061859cd048ae => (x7c5d33e87d9dfc05)xe5cdc2a3cec80364(StoryType.MainText, x5aa7d09b258e0f23: true);

	internal xb3182f54aafe1dd9 x31b433cb13e4aa24 => (xb3182f54aafe1dd9)xe5cdc2a3cec80364(StoryType.Footnotes, x5aa7d09b258e0f23: true);

	internal xbb128850ab6e3d33 xe427d253f517c8ee => (xbb128850ab6e3d33)xe5cdc2a3cec80364(StoryType.Endnotes, x5aa7d09b258e0f23: true);

	internal xc5116a632a92d22c xe6f13b2cfaddaa67 => (xc5116a632a92d22c)xe5cdc2a3cec80364(StoryType.Comments, x5aa7d09b258e0f23: true);

	internal Hashtable x62463f2402f0120e
	{
		get
		{
			if (xae99497208179488 == null)
			{
				xae99497208179488 = new Hashtable();
				xac6c82c74ce247fb xac6c82c74ce247fb2 = xe5cdc2a3cec80364(StoryType.Comments, x5aa7d09b258e0f23: false);
				if (xac6c82c74ce247fb2 != null && xac6c82c74ce247fb2.xb3a79d506b0e2f7f.xd44988f225497f3a > 0)
				{
					xe0e644109215bf44 xe0e644109215bf45 = (x12f4230247e4ca42)xe6f13b2cfaddaa67.xa51d8d9790431b2b;
					xc7f90d9c7c51cede xc7f90d9c7c51cede2 = null;
					ArrayList arrayList = null;
					for (xe0e644109215bf44 xe0e644109215bf46 = xe0e644109215bf45; xe0e644109215bf46 != null; xe0e644109215bf46 = xe0e644109215bf46.x185a13a95379e46d)
					{
						xe66ac07cc471e42e xe66ac07cc471e42e2 = (xe66ac07cc471e42e)xe0e644109215bf46.x8b8a0a04b3aeaf3a;
						xc7f90d9c7c51cede xc7f90d9c7c51cede3 = (xc7f90d9c7c51cede)xe66ac07cc471e42e2.xc255c495fd9232ca;
						if (xc7f90d9c7c51cede3 != xc7f90d9c7c51cede2)
						{
							arrayList = new ArrayList();
							xc7f90d9c7c51cede2 = xc7f90d9c7c51cede3;
						}
						arrayList.Add(xe66ac07cc471e42e2);
						if (arrayList.Count == 1)
						{
							xae99497208179488.Add(xc7f90d9c7c51cede2, arrayList);
						}
					}
				}
			}
			return xae99497208179488;
		}
	}

	internal xa268fdb9ca040dde xe1410f585439c7d4 => x800085dd555f7711;

	internal x4af2add38e634ad4 x4af2add38e634ad4
	{
		get
		{
			return x54ba23be3ab01223;
		}
		set
		{
			x54ba23be3ab01223 = value;
		}
	}

	internal xdeb77ea37ad74c56 xdeb77ea37ad74c56
	{
		get
		{
			if (xd5f4d4b5bdd8e58a == null)
			{
				xd5f4d4b5bdd8e58a = new xdeb77ea37ad74c56();
				xd5f4d4b5bdd8e58a.x4e3a197ead77ddae = true;
				xd5f4d4b5bdd8e58a.x7383a35ee8adbcce = true;
				xd5f4d4b5bdd8e58a.xc140e3669091ae41 = true;
				xd5f4d4b5bdd8e58a.x999996a7e5332e5e = x26d9ecb4bdf0456d.x45260ad4b94166f2;
				xd5f4d4b5bdd8e58a.x4523544367ce6992 = x26d9ecb4bdf0456d.x45260ad4b94166f2;
			}
			return xd5f4d4b5bdd8e58a;
		}
		set
		{
			xd5f4d4b5bdd8e58a = value;
		}
	}

	internal x17dcbf5fe3c0d2d2 x17dcbf5fe3c0d2d2
	{
		get
		{
			if (x3d3ebc31b37b2a88 == null && (xd5f4d4b5bdd8e58a == null || !xd5f4d4b5bdd8e58a.xa7631b031eaad810))
			{
				x3d3ebc31b37b2a88 = new x17dcbf5fe3c0d2d2();
			}
			return x3d3ebc31b37b2a88;
		}
	}

	internal Hashtable xeafe18c850ae3127
	{
		get
		{
			if (x4bd039d469a1155d == null)
			{
				x4bd039d469a1155d = new Hashtable();
			}
			return x4bd039d469a1155d;
		}
	}

	internal Hashtable x84aa3570d857bec4
	{
		get
		{
			if (xf4534a93f13f6ff3 == null)
			{
				xf4534a93f13f6ff3 = new Hashtable();
			}
			return xf4534a93f13f6ff3;
		}
	}

	internal xd410c9b07f3bc70b xd410c9b07f3bc70b
	{
		get
		{
			if (xedda6ffaac616530 == null)
			{
				xedda6ffaac616530 = new xd410c9b07f3bc70b();
			}
			return xedda6ffaac616530;
		}
	}

	internal x4e2f8bff72d83f71(xa268fdb9ca040dde builder)
	{
		x800085dd555f7711 = builder;
	}

	internal override void x0680d4cf02fbe4e3(object xe0292b9ed559da7d, x9352d7e557b05f9e xfbf34718e704c6bc)
	{
		throw new InvalidOperationException("DocumentLayout.SendAsync");
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.xdf01197795713233(this);
	}

	internal xac6c82c74ce247fb xe5cdc2a3cec80364(StoryType xdbbf47b5e620c262, bool x5aa7d09b258e0f23)
	{
		switch (xdbbf47b5e620c262)
		{
		case StoryType.MainText:
			if (x0dafc1ea081e54b2 == null && x5aa7d09b258e0f23)
			{
				x0dafc1ea081e54b2 = new x7c5d33e87d9dfc05(this);
			}
			return x0dafc1ea081e54b2;
		case StoryType.Footnotes:
			if (x24931eac10106982 == null && x5aa7d09b258e0f23)
			{
				x24931eac10106982 = new xb3182f54aafe1dd9(this);
			}
			return x24931eac10106982;
		case StoryType.Endnotes:
			if (xa86a4aa59a6cca8f == null && x5aa7d09b258e0f23)
			{
				xa86a4aa59a6cca8f = new xbb128850ab6e3d33(this);
			}
			return xa86a4aa59a6cca8f;
		case StoryType.Comments:
			if (xb80d110a4f8df4a9 == null && x5aa7d09b258e0f23)
			{
				xb80d110a4f8df4a9 = new xc5116a632a92d22c(this);
			}
			return xb80d110a4f8df4a9;
		default:
			return null;
		}
	}

	internal void xc3819e13f60dd8e6()
	{
		xe1410f585439c7d4.xc3819e13f60dd8e6(xfad304b5f8f3bb5b: true);
		x17e48e42e094d16c(xe1410f585439c7d4);
	}

	internal void xb1a5e9f516a373ea(Document x3664041d21d73fdc, xa268fdb9ca040dde xd07ce4b74c5774a7)
	{
		if (x24931eac10106982 != null)
		{
			x9c504c58a57f624c(x3664041d21d73fdc, xd07ce4b74c5774a7, x101cddc73c4f8cc2.xa1e2a8ed32a026dd, StoryType.FootnoteSeparator, '\u0003');
			x9c504c58a57f624c(x3664041d21d73fdc, xd07ce4b74c5774a7, x101cddc73c4f8cc2.xeab6532eb0797a6e, StoryType.FootnoteContinuationSeparator, '\u0004');
		}
		if (xa86a4aa59a6cca8f != null)
		{
			x9c504c58a57f624c(x3664041d21d73fdc, xd07ce4b74c5774a7, x101cddc73c4f8cc2.x0affbe34bb1f8b8b, StoryType.EndnoteSeparator, '\u0003');
			x9c504c58a57f624c(x3664041d21d73fdc, xd07ce4b74c5774a7, x101cddc73c4f8cc2.x354a2c7b596483f1, StoryType.EndnoteContinuationSeparator, '\u0004');
		}
	}

	private static void x17e48e42e094d16c(xa268fdb9ca040dde xd07ce4b74c5774a7)
	{
		Hashtable x9883c720593ff2cd = new Hashtable();
		for (xc7f90d9c7c51cede xc7f90d9c7c51cede2 = xd07ce4b74c5774a7.x4e2f8bff72d83f71.x80f061859cd048ae.x86a0dde4c22f516b; xc7f90d9c7c51cede2 != null; xc7f90d9c7c51cede2 = xc7f90d9c7c51cede2.x3d695937fd09df4b)
		{
			x84448f134fcddce5(xc7f90d9c7c51cede2.x1ea60bde2b5d0d28, x9883c720593ff2cd);
			x84448f134fcddce5(xc7f90d9c7c51cede2.x1d7b771e95a9abb5, x9883c720593ff2cd);
		}
		xd07ce4b74c5774a7.xc3819e13f60dd8e6(xfad304b5f8f3bb5b: true);
	}

	private static void x84448f134fcddce5(x398b3bd0acd94b61 xd7e5673853e47af4, Hashtable x9883c720593ff2cd)
	{
		if (xd7e5673853e47af4 != null)
		{
			xc7f90d9c7c51cede xc7f90d9c7c51cede2 = xd7e5673853e47af4.x776fd7c2f7270172();
			xac6c82c74ce247fb key = x2c0c9a4fb5b11521.x0484e9c10bfbc40a(xc7f90d9c7c51cede2.x3c1c340351d94fbd, xd7e5673853e47af4.x53111d6596d16a99.xfe6cdb7c00822bd9, x5aa7d09b258e0f23: false);
			object obj = x9883c720593ff2cd[key];
			if (obj == null)
			{
				obj = !x836cc4d43484aecd(xd7e5673853e47af4.x53111d6596d16a99);
				x9883c720593ff2cd[key] = (bool)obj;
			}
			else if (!(bool)obj)
			{
				x836cc4d43484aecd(xd7e5673853e47af4.x53111d6596d16a99);
			}
		}
	}

	private static bool x836cc4d43484aecd(xac6c82c74ce247fb x2612f62f94df47de)
	{
		if (x2612f62f94df47de == null || x2612f62f94df47de.x909dc38ec7fc4d71 || x2612f62f94df47de.xb3a79d506b0e2f7f.x7149c962c02931b3)
		{
			return false;
		}
		ArrayList arrayList = xd098fecd461cd28c(x2612f62f94df47de);
		for (int i = 0; i < arrayList.Count; i++)
		{
			ArrayList arrayList2 = (ArrayList)arrayList[i];
			((x5c28fdcd27dee7d9)arrayList2[arrayList2.Count - 1]).x295cb4a1df7a5add();
		}
		return arrayList.Count > 0;
	}

	internal static ArrayList xd098fecd461cd28c(xac6c82c74ce247fb x2612f62f94df47de)
	{
		xf3f447691ab38eee xf3f447691ab38eee2 = x2612f62f94df47de.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		xf3f447691ab38eee2.x74f5a1ef3906e23c();
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = null;
		x3a43ccb489970add x3a43ccb489970add2 = new x3a43ccb489970add();
		int num = 0;
		while (xf3f447691ab38eee2.x47f176deff0d42e2())
		{
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
			x3a43ccb489970add2.xbc13914359462815(x56410a8dd70087c6);
			if (x56410a8dd70087c6 is xa67197c42bddc7dc && x56410a8dd70087c6.x8c84b6fad60c11f5 && !x3a43ccb489970add2.xf599d2ce268e77d8)
			{
				xac6c82c74ce247fb xac6c82c74ce247fb2 = x56410a8dd70087c6.x0cdfd951d792f320(x5aa7d09b258e0f23: false);
				if (xac6c82c74ce247fb2 != null)
				{
					ArrayList arrayList3 = xd098fecd461cd28c(xac6c82c74ce247fb2);
					if (arrayList3.Count > 0)
					{
						arrayList.AddRange(arrayList3);
					}
				}
			}
			else
			{
				if (!(x56410a8dd70087c6 is x5c28fdcd27dee7d9))
				{
					continue;
				}
				x5c28fdcd27dee7d9 x5c28fdcd27dee7d10 = (x5c28fdcd27dee7d9)x56410a8dd70087c6;
				switch (x5c28fdcd27dee7d10.x6e414db5d060a816)
				{
				case x6e414db5d060a816.x12cb12b5d2cad53d:
					if (num == 0)
					{
						arrayList2 = new ArrayList();
					}
					num++;
					if (x5c29822913be33c1.x6caf38183f332e86(x5c28fdcd27dee7d10.xc96d173d58dd8a20))
					{
						arrayList2.Add(x5c28fdcd27dee7d10);
					}
					break;
				case x6e414db5d060a816.x9fd888e65466818c:
					num--;
					if (num == 0 && x5c29822913be33c1.x04b61a8a6225198f(x5c28fdcd27dee7d10.xc96d173d58dd8a20))
					{
						if (arrayList2.Count <= 0 || arrayList2[arrayList2.Count - 1] != x5c28fdcd27dee7d10.x9a05d8dab0f0619f)
						{
							arrayList2.Add(x5c28fdcd27dee7d10.x9a05d8dab0f0619f);
						}
						arrayList.Add(arrayList2);
					}
					break;
				}
			}
		}
		return arrayList;
	}

	private void x9c504c58a57f624c(Document x3664041d21d73fdc, xa268fdb9ca040dde xd07ce4b74c5774a7, x101cddc73c4f8cc2 x781135a02d5b7a22, StoryType xdbbf47b5e620c262, char xd238ad6abbf200ed)
	{
		xa1e2a8ed32a026dd xa1e2a8ed32a026dd = x3664041d21d73fdc.x245aa7750b4a8072.get_xe6d4b1b411ed94b5(x781135a02d5b7a22);
		if (xa1e2a8ed32a026dd == null)
		{
			xa1e2a8ed32a026dd = x8d50d0e5290e8b16(x3664041d21d73fdc, x781135a02d5b7a22, xd238ad6abbf200ed);
		}
		xd410c9b07f3bc70b.x51b3590e861af38f(this, xdbbf47b5e620c262);
		x487cdc969fefe3d6 x487cdc969fefe3d = new x487cdc969fefe3d6(xa1e2a8ed32a026dd, xdeb77ea37ad74c56, x17dcbf5fe3c0d2d2, xeafe18c850ae3127, xdbbf47b5e620c262);
		while (x487cdc969fefe3d.x83f07df6a659e05b())
		{
			xd07ce4b74c5774a7.xef23aa45e7612fdd(x487cdc969fefe3d.xbe1e23e7d5b43370, x487cdc969fefe3d.x56410a8dd70087c5);
		}
	}

	private static xa1e2a8ed32a026dd x8d50d0e5290e8b16(Document x3664041d21d73fdc, x101cddc73c4f8cc2 x781135a02d5b7a22, char xbb1f26815471606a)
	{
		xa1e2a8ed32a026dd xa1e2a8ed32a026dd = new xa1e2a8ed32a026dd(x3664041d21d73fdc, x781135a02d5b7a22);
		Paragraph paragraph = new Paragraph(x3664041d21d73fdc, new x1a78664fa10a3755(), new xeedad81aaed42a76());
		xa1e2a8ed32a026dd.AppendChild(paragraph);
		SpecialChar newChild = new SpecialChar(x3664041d21d73fdc, xbb1f26815471606a, new xeedad81aaed42a76());
		paragraph.AppendChild(newChild);
		return xa1e2a8ed32a026dd;
	}
}
