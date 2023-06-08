using System.Collections;
using System.Collections.Specialized;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1a62aaf14e3c5909;
using x28925c9b27b37a46;
using x650fee20d618512c;
using x79578da6a8a3ae37;
using xa604c4d210ae0581;
using xb92b7270f78a4e8d;
using xd02fa72a7d2ee8f7;
using xdc4a6e3b10426ae2;
using xf9a9481c3f63a419;

namespace x16f9a31f749b8bb1;

internal class x0f8a9a895bdf560e : xd565534916f7312b
{
	private readonly Document x232be220f517f721;

	private readonly xa3ed3b2cd8f77351 x36d78faca8ad62db;

	private xc0c3e7a02d862604 xcb7fe852d2583003;

	private x3af03f5f12c5ee73 x326d2c4737b8a926;

	private x1ae9945b169ad9b2 xc121b425b57d61c8;

	private x7e738ecc9d58b06d x48d9a991d0b583f9;

	private bool x4787dab929a14d08;

	private readonly LoadOptions xd545ef71ef25db52;

	internal bool x6cb2cfca19c7adb6
	{
		get
		{
			if (base.x4d66abcb6ba362b4.x23719734cf1f138c > 0)
			{
				xb7b1bf2d89bd7ff4 xb7b1bf2d89bd7ff = base.x4d66abcb6ba362b4.get_xe6d4b1b411ed94b5(base.x4d66abcb6ba362b4.x23719734cf1f138c - 1);
				return xb7b1bf2d89bd7ff.x562a56f0d1df5917 == 1;
			}
			return false;
		}
	}

	internal Document x2c8c6741422a1298 => x232be220f517f721;

	internal xa3ed3b2cd8f77351 xffb32620593acdf2 => x36d78faca8ad62db;

	internal bool xb4fa721cfeafcddd
	{
		get
		{
			return x4787dab929a14d08;
		}
		set
		{
			x4787dab929a14d08 = value;
		}
	}

	internal x7e738ecc9d58b06d x7e738ecc9d58b06d => x48d9a991d0b583f9;

	private IWarningCallback xf69ca7a9bb4a4a51 => xd545ef71ef25db52.WarningCallback;

	internal x0f8a9a895bdf560e(xd8c3135513b9115b fs, string password, Document doc, LoadOptions loadOptions)
		: base(fs, password, loadOptions.WarningCallback)
	{
		x232be220f517f721 = doc;
		x36d78faca8ad62db = new x73fe5008aa2120db(doc, loadOptions);
		xd545ef71ef25db52 = loadOptions;
	}

	internal x0f8a9a895bdf560e(xd8c3135513b9115b fs, string password, Document doc)
		: this(fs, password, doc, new LoadOptions())
	{
	}

	internal void x06b0e25aa6ad68a9()
	{
		xa68b7097d25ac20d.x06b0e25aa6ad68a9(x232be220f517f721.FontInfos, base.x8aeace2bf92692ab, base.x4f6bee9d11d5b851, base.x0f8a9a895bdf560e, xf69ca7a9bb4a4a51);
		xd47c6c7442eb8033 revisionAuthors = new xd47c6c7442eb8033(base.x8aeace2bf92692ab, base.x4f6bee9d11d5b851);
		xcb7fe852d2583003 = new xc0c3e7a02d862604(revisionAuthors, xf69ca7a9bb4a4a51);
		x326d2c4737b8a926 = new x3af03f5f12c5ee73(x232be220f517f721.FontInfos, revisionAuthors, xf69ca7a9bb4a4a51);
		xc121b425b57d61c8 = new x1ae9945b169ad9b2(base.x6215066365db5120, revisionAuthors, base.x8aeace2bf92692ab.x4debd6958bcd2b55, xf69ca7a9bb4a4a51);
		x48d9a991d0b583f9 = new x7e738ecc9d58b06d(x232be220f517f721, xf69ca7a9bb4a4a51);
		x48d9a991d0b583f9.x06b0e25aa6ad68a9(base.x4f6bee9d11d5b851, base.x8aeace2bf92692ab.x955a03f821588c52.xce577ad5c3409328.xe53f0e68147463d1, base.x8aeace2bf92692ab.x955a03f821588c52.xce577ad5c3409328.x04c290dc4d04369c, base.x0f8a9a895bdf560e);
		if (Shape.x2e634d5c614a25de(x48d9a991d0b583f9.x5ab5a058833da74f))
		{
			x232be220f517f721.xffc75a489655380b(x48d9a991d0b583f9.x5ab5a058833da74f);
		}
		x44ac55e8c9dbd30d x44ac55e8c9dbd30d = new x44ac55e8c9dbd30d(x232be220f517f721.FontInfos, revisionAuthors, x232be220f517f721.Styles, xf69ca7a9bb4a4a51);
		x44ac55e8c9dbd30d.x06b0e25aa6ad68a9(base.x4f6bee9d11d5b851, base.x8aeace2bf92692ab, xf69ca7a9bb4a4a51);
		x4e41835376268d39 x4e41835376268d = new x4e41835376268d39(x232be220f517f721.FontInfos, revisionAuthors, x232be220f517f721.Lists, xf69ca7a9bb4a4a51);
		x4e41835376268d.x06b0e25aa6ad68a9(base.x8aeace2bf92692ab, base.x4f6bee9d11d5b851);
		x232be220f517f721.x227665e444fb500a = xe6daf81eea39f8f3.x06b0e25aa6ad68a9(base.x8aeace2bf92692ab, base.x4f6bee9d11d5b851, x232be220f517f721.Lists);
		x1f93754c360623ac.x06b0e25aa6ad68a9(base.x4f6bee9d11d5b851, base.x8aeace2bf92692ab.x955a03f821588c52.x3dfed1bed9738813, x232be220f517f721, xf69ca7a9bb4a4a51);
		x232be220f517f721.xdade2366eaa6f915.xc57807e17cfa13d2.ReadOnlyRecommended = base.x8aeace2bf92692ab.x240eec731225c48e;
		if (base.x8aeace2bf92692ab.x955a03f821588c52.x6e417902046283c7)
		{
			x232be220f517f721.x5408c1b8277b7b1a = new x5408c1b8277b7b1a(base.x8aeace2bf92692ab, base.x4f6bee9d11d5b851, x232be220f517f721.xdade2366eaa6f915.x64d2067aa07ebd4f);
		}
		xb4278d25e0406614 xb4278d25e = new xb4278d25e0406614();
		xb4278d25e.x06b0e25aa6ad68a9(base.x4f6bee9d11d5b851, base.x8aeace2bf92692ab.x955a03f821588c52.xb4278d25e0406614.xe53f0e68147463d1, base.x8aeace2bf92692ab.x955a03f821588c52.xb4278d25e0406614.x04c290dc4d04369c);
		xc74d3b8b1891696d xc74d3b8b1891696d2 = new xc74d3b8b1891696d();
		xc74d3b8b1891696d2.x06b0e25aa6ad68a9(base.x4f6bee9d11d5b851, base.x8aeace2bf92692ab, xb4278d25e, x232be220f517f721.xdade2366eaa6f915.xe690cef2446c7d46);
		base.xd078c45cd488fe12.x93b0c46ec754e6da(xb4278d25e, x232be220f517f721.OriginalFileName);
		xe6d08044467dd57c xe6d08044467dd57c = new xe6d08044467dd57c();
		xe6d08044467dd57c.x06b0e25aa6ad68a9(base.xd5113ab23c2feda8.x29e7ace4c90f74cd, x232be220f517f721.BuiltInDocumentProperties, x232be220f517f721.CustomDocumentProperties, xf69ca7a9bb4a4a51);
		x2bf53ec7fd033de5();
		xeeaa3d6ac3c637d7();
		xbb46aed21c671200();
		base.x4f6bee9d11d5b851.BaseStream.Position = base.x8aeace2bf92692ab.x955a03f821588c52.xf486349ad5db7bec.xe53f0e68147463d1;
		x232be220f517f721.xa3c04447aa84f70f = base.x4f6bee9d11d5b851.ReadBytes(base.x8aeace2bf92692ab.x955a03f821588c52.xf486349ad5db7bec.x04c290dc4d04369c);
		base.x4f6bee9d11d5b851.BaseStream.Position = base.x8aeace2bf92692ab.x955a03f821588c52.xc3533e44c5d8afad.xe53f0e68147463d1;
		x82218fbaaecee34a x82218fbaaecee34a = new x82218fbaaecee34a();
		x82218fbaaecee34a.x06b0e25aa6ad68a9(base.x4f6bee9d11d5b851, base.x8aeace2bf92692ab.x955a03f821588c52.xc3533e44c5d8afad.x04c290dc4d04369c, x232be220f517f721);
		x7afea2b34821ae67.x06b0e25aa6ad68a9(base.x8aeace2bf92692ab, base.x4f6bee9d11d5b851, x232be220f517f721);
		x232be220f517f721.x70813fadbf467780 = base.xd5113ab23c2feda8.x29e7ace4c90f74cd.x3e19bf48aeaa5779("\u0001CompObj");
		x232be220f517f721.x92e2e3377da135e8 = base.xd5113ab23c2feda8.x29e7ace4c90f74cd.x03c5de1b1357f136("Macros");
		x32eac27632acc346 x32eac27632acc347 = new x32eac27632acc346(this);
		x32eac27632acc347.x1f490eac106aee12();
		if (base.x8aeace2bf92692ab.x4debd6958bcd2b55 <= x3a9e25666c8d1ee1.x6078bd5cfc666c9f)
		{
			x254fcff8c95dead4();
		}
		x7ebe9b59271a9f3d.x06b0e25aa6ad68a9(base.xd5113ab23c2feda8, x232be220f517f721.DigitalSignatures, xf69ca7a9bb4a4a51);
		x4fe6ba040498cc67.x06b0e25aa6ad68a9(base.xd5113ab23c2feda8, x232be220f517f721.CustomXmlParts);
	}

	private void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		x98b0e09ccece0a5a.xbbf9a1ead81dd3a1(xf69ca7a9bb4a4a51, x9f91de645a9fe01a, WarningSource.Doc, xc2358fbac7da3d45);
	}

	private void x3dc950453374051a(string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		x98b0e09ccece0a5a.x3dc950453374051a(xf69ca7a9bb4a4a51, WarningSource.Doc, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}

	private void x254fcff8c95dead4()
	{
		foreach (Section section in x232be220f517f721.Sections)
		{
			x232be220f517f721.xdade2366eaa6f915.xc8949e68d489222b.xab3af626b1405ee8(section.xfc72d4c9b765cad7);
		}
	}

	private void x2bf53ec7fd033de5()
	{
		if (base.x8aeace2bf92692ab.x61c3ae0ca90c00b3.x0f731a94af712eba.x04c290dc4d04369c != 0)
		{
			base.x4f6bee9d11d5b851.BaseStream.Position = base.x8aeace2bf92692ab.x61c3ae0ca90c00b3.x0f731a94af712eba.xe53f0e68147463d1;
			byte[] bytes = base.x4f6bee9d11d5b851.ReadBytes(base.x8aeace2bf92692ab.x61c3ae0ca90c00b3.x0f731a94af712eba.x04c290dc4d04369c);
			x232be220f517f721.xdade2366eaa6f915.x57a3ba5e84591507 = Encoding.Unicode.GetString(bytes);
		}
	}

	private void xeeaa3d6ac3c637d7()
	{
		if (base.x8aeace2bf92692ab.x955a03f821588c52.xaeecc4859c1418bf.x04c290dc4d04369c != 0)
		{
			StringCollection stringCollection = new StringCollection();
			xaf807f6784ee1743.x06b0e25aa6ad68a9(base.x4f6bee9d11d5b851, base.x8aeace2bf92692ab.x955a03f821588c52.xaeecc4859c1418bf, stringCollection);
			xdade2366eaa6f915 xdade2366eaa6f = x232be220f517f721.xdade2366eaa6f915;
			xdade2366eaa6f.x8c0ad447fda248da = xedff0c9cbeff2d26(stringCollection, xa61aa4481bb6aa55.xcc140ab9a0657bb9);
			if (base.x8aeace2bf92692ab.x61144b80cccda275)
			{
				xdade2366eaa6f.xc57807e17cfa13d2.SetPassword(xedff0c9cbeff2d26(stringCollection, xa61aa4481bb6aa55.x03be73312725bea8));
			}
		}
	}

	private string xedff0c9cbeff2d26(StringCollection xf8b54ce7724a27f2, xa61aa4481bb6aa55 x64a3e4840bd28b01)
	{
		if (x64a3e4840bd28b01 < xa61aa4481bb6aa55.x4d0b9d4447ba7566 || (int)x64a3e4840bd28b01 > xf8b54ce7724a27f2.Count - 1)
		{
			x98b0e09ccece0a5a.x3dc950453374051a(xf69ca7a9bb4a4a51, WarningSource.Doc, "Invalid associated string requested for 0x{0:x4}, replaced with empty string.", (int)x64a3e4840bd28b01);
			return "";
		}
		return xf8b54ce7724a27f2[(int)x64a3e4840bd28b01];
	}

	private void xbb46aed21c671200()
	{
		if (base.x8aeace2bf92692ab.x955a03f821588c52.x879309a2286722ac.x04c290dc4d04369c != 0)
		{
			StringCollection stringCollection = new StringCollection();
			xaf807f6784ee1743.x06b0e25aa6ad68a9(base.x4f6bee9d11d5b851, base.x8aeace2bf92692ab.x955a03f821588c52.x879309a2286722ac, stringCollection);
			x232be220f517f721.xdade2366eaa6f915.xb33c79064acb66c7 = stringCollection.Count;
		}
	}

	internal xfc72d4c9b765cad7 x9ff07c03a240dd5d(int x18d1054d82981887)
	{
		int num = base.x4d66abcb6ba362b4.xd888124d3245cd86(x18d1054d82981887);
		if (num < 0)
		{
			return null;
		}
		xb7b1bf2d89bd7ff4 xb7b1bf2d89bd7ff = base.x4d66abcb6ba362b4.get_xe6d4b1b411ed94b5(num);
		if (xb7b1bf2d89bd7ff.x34e183d0e3285c7e == null)
		{
			return null;
		}
		xfc72d4c9b765cad7 xfc72d4c9b765cad = new xfc72d4c9b765cad7();
		xcb7fe852d2583003.x06b0e25aa6ad68a9(xb7b1bf2d89bd7ff.x34e183d0e3285c7e.x6b73aa01aa019d3a, xfc72d4c9b765cad);
		int num2 = base.x4d66abcb6ba362b4.xed8a0d4499d6f292(num + 1);
		int num3 = base.x8f4cc590b89c730d.x6e603e71a5cebe44(num2 - 1);
		if (num3 != -1)
		{
			xc77edd00162b84f4 xc77edd00162b84f = base.x8f4cc590b89c730d.get_xe6d4b1b411ed94b5(num3);
			xcb7fe852d2583003.x06b0e25aa6ad68a9(xc77edd00162b84f.x32939c68497cb083.x6b73aa01aa019d3a, xfc72d4c9b765cad);
		}
		return xfc72d4c9b765cad;
	}

	internal xb3ad27290106eaf4 x3b355689ee7596e9(int x03e8ba449439270f, x32939c68497cb083 x887d78e87c5df078)
	{
		int xc0c4c459c6ccbd = base.xf8b5e62cf3165594.x11fb6e5bb55209b1(x03e8ba449439270f);
		xc121b425b57d61c8.x06b0e25aa6ad68a9(base.xf8b5e62cf3165594.get_xe6d4b1b411ed94b5(xc0c4c459c6ccbd), x887d78e87c5df078.x6b73aa01aa019d3a);
		return new xb3ad27290106eaf4(xc121b425b57d61c8.x1a78664fa10a3755, xc121b425b57d61c8.x12d5a57a1541e872, xc121b425b57d61c8.xedb0eb766e25e0c9);
	}

	internal int x0da3dbab8832b471(int xd59ec9a3f7a434cb, x32939c68497cb083 x887d78e87c5df078, out xeedad81aaed42a76 x789564759d365819, out xa52f2632c0ffdfaf xe08a26cc2b49f3aa)
	{
		int num = base.xdb6ea7a460485a97.x11fb6e5bb55209b1(xd59ec9a3f7a434cb);
		x9dba795deb731d48 x9dba795deb731d = base.xdb6ea7a460485a97.get_xe6d4b1b411ed94b5(num);
		x789564759d365819 = new xeedad81aaed42a76();
		xe08a26cc2b49f3aa = new xa52f2632c0ffdfaf();
		x326d2c4737b8a926.x06b0e25aa6ad68a9(x9dba795deb731d.x6b73aa01aa019d3a, x789564759d365819, xe08a26cc2b49f3aa);
		x326d2c4737b8a926.x06b0e25aa6ad68a9(x887d78e87c5df078.x6b73aa01aa019d3a, x789564759d365819, xe08a26cc2b49f3aa);
		return base.xdb6ea7a460485a97.xed8a0d4499d6f292(num + 1);
	}

	internal ShapeBase x344144ac57593f12(int x1f6ee650d037e627, xc40bef0fb61c8a3e x4d49889b5a27d1df)
	{
		ShapeBase result = x48d9a991d0b583f9.xb613f9c3a594bed5(x1f6ee650d037e627, x4d49889b5a27d1df);
		x48d9a991d0b583f9.x83a87b4a5ef1284e(x1f6ee650d037e627, x4d49889b5a27d1df);
		return result;
	}

	internal Shape xa5b547b6ce00aa54(int x9e4be1b404ab074b)
	{
		return x821732b125012c9e.xa5b547b6ce00aa54(x48d9a991d0b583f9, base.x6215066365db5120, x9e4be1b404ab074b, xf69ca7a9bb4a4a51);
	}

	internal x71d39fdf56861cca x027f422ae4e5ea22(int xe680f7e4e9e521a9)
	{
		xe7be411416cfcd54 xe7be411416cfcd = base.xd5113ab23c2feda8.x29e7ace4c90f74cd.x03c5de1b1357f136("ObjectPool");
		if (xe7be411416cfcd == null)
		{
			x3dc950453374051a("Document 'ObjectPool' stream is missed, OLE objects will be lost.");
			return null;
		}
		foreach (DictionaryEntry item in xe7be411416cfcd)
		{
			string text = (string)item.Key;
			text = text.TrimStart('_');
			int num = xca004f56614e2431.x912616ee70b2d94d(text);
			if (num != int.MinValue && xe680f7e4e9e521a9 == num)
			{
				return new x71d39fdf56861cca(xe680f7e4e9e521a9, (xe7be411416cfcd54)item.Value);
			}
		}
		x3dc950453374051a($"Embedded OLE object data is missed for ObjectID: 0x{xe680f7e4e9e521a9:x4}.");
		return null;
	}
}
