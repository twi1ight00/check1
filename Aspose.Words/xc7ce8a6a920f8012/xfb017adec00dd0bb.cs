using System;
using System.Collections;
using System.IO;
using System.Text;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class xfb017adec00dd0bb : x0096796e2eb81db6
{
	public xfb017adec00dd0bb(x34b34bf589d8ec1e context)
		: base(context)
	{
	}

	public void x508813524f81e22d()
	{
		short num = base.x28fcdc775a1d069c.xa315ee2085b502cf();
		xb4e6bcae51300e9c xb4e6bcae51300e9c2 = new xb4e6bcae51300e9c(base.x28fcdc775a1d069c);
		xb4e6bcae51300e9c2.xacf4b9ddf32bef06();
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(num);
		base.x5aa326f374b3d0ef.x6ff7c65ed4805c27(0);
		base.x5aa326f374b3d0ef.x4c116b70372a3c6d(x996fb2ecd3ce7c88());
		xb4e6bcae51300e9c2.xc463dec5a3ab6e2d(xf066f1f57515a14c.x4dd4167c8981f337);
		x05e3cedc50cf7315(num);
	}

	private byte[] x996fb2ecd3ce7c88()
	{
		using MemoryStream memoryStream = new MemoryStream();
		Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
		x3c74b3c4f21844f9 x3c74b3c4f21844f = new x3c74b3c4f21844f9(memoryStream, encoding, isPrettyFormat: false);
		x3c74b3c4f21844f.x9b9ed0109b743e3b("document");
		x3c74b3c4f21844f.x2307058321cdb62f("locales");
		x3c74b3c4f21844f.x2307058321cdb62f("locale");
		x3c74b3c4f21844f.xff520a0047c27122("name", "en_US");
		x3c74b3c4f21844f.xff520a0047c27122("font", base.x28fcdc775a1d069c.x568b8b069e73c3db.x0a4b32fbe2e5933b + "_AW");
		x32a23a856538ee72(x3c74b3c4f21844f, "topPane", base.x28fcdc775a1d069c.x73979cef1002ed01.x6a8a9f2ff4fc1d0f);
		x32a23a856538ee72(x3c74b3c4f21844f, "leftPane", base.x28fcdc775a1d069c.x73979cef1002ed01.xe1db7b892c589ded);
		x32a23a856538ee72(x3c74b3c4f21844f, "bottomPane", base.x28fcdc775a1d069c.x73979cef1002ed01.x29d60fe32b323b87);
		x32a23a856538ee72(x3c74b3c4f21844f, "readModePane", base.x28fcdc775a1d069c.x73979cef1002ed01.xbcfe068aba956ed6);
		x32a23a856538ee72(x3c74b3c4f21844f, "dialogs", base.x28fcdc775a1d069c.x73979cef1002ed01.x3aa391d1ccc79b17);
		x3c74b3c4f21844f.x2dfde153f4ef96d0();
		x3c74b3c4f21844f.x2dfde153f4ef96d0();
		x77d0d7d853f66718(x3c74b3c4f21844f);
		base.x28fcdc775a1d069c.x93e68a44438355fd.xa2d0834a5d3e1a19(x3c74b3c4f21844f);
		for (int i = 0; i < base.x28fcdc775a1d069c.x09ed8d79c4ca4609.Count; i++)
		{
			xc21f590a19daad27 xc21f590a19daad28 = (xc21f590a19daad27)base.x28fcdc775a1d069c.x09ed8d79c4ca4609[i];
			x3c74b3c4f21844f.x2307058321cdb62f("page");
			x3c74b3c4f21844f.xff520a0047c27122("width", xc21f590a19daad28.x3114e27f80122981.ToString());
			x3c74b3c4f21844f.xff520a0047c27122("height", xc21f590a19daad28.x995a78d99ada0d0c.ToString());
			foreach (DictionaryEntry item in xc21f590a19daad28.x1345d104bcfaae69)
			{
				xa702b771604efc86 xa702b771604efc = (xa702b771604efc86)item.Value;
				string key = (xa702b771604efc.x23ae6e0c44b8e6a2 ? xa702b771604efc.x42f4c234c9358072.Trim('#') : "");
				if (!xa702b771604efc.x23ae6e0c44b8e6a2 || base.x28fcdc775a1d069c.xeafe18c850ae3127[key] != null)
				{
					x3c74b3c4f21844f.x2307058321cdb62f("hyperlink");
					x3c74b3c4f21844f.xff520a0047c27122("id", item.Key.ToString());
					x3c74b3c4f21844f.xff520a0047c27122("islocal", xa702b771604efc.x23ae6e0c44b8e6a2.ToString());
					x3c74b3c4f21844f.x5222f4285e37d66b.WriteCData(xa702b771604efc.x23ae6e0c44b8e6a2 ? base.x28fcdc775a1d069c.xeafe18c850ae3127[key].ToString() : xa702b771604efc.x42f4c234c9358072);
					x3c74b3c4f21844f.x2dfde153f4ef96d0();
				}
			}
			x3c74b3c4f21844f.x2dfde153f4ef96d0();
		}
		x3c74b3c4f21844f.xa0dfc102c691b11f();
		return x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
	}

	private void x77d0d7d853f66718(x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("config");
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "showFullScreen", base.x28fcdc775a1d069c.x73979cef1002ed01.xf87cb1395914575c.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "showPageStepper", base.x28fcdc775a1d069c.x73979cef1002ed01.x95d9e8797e4cd333.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "showSearch", base.x28fcdc775a1d069c.x73979cef1002ed01.x33444f9326ac61fb.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "showTopPane", base.x28fcdc775a1d069c.x73979cef1002ed01.x3e2affdc39719136.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "showBottomPane", base.x28fcdc775a1d069c.x73979cef1002ed01.xbd9ac706e3f1b075.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "showLeftPane", base.x28fcdc775a1d069c.x73979cef1002ed01.xb21850ba8e249cba.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "startOpenLeftPane", base.x28fcdc775a1d069c.x73979cef1002ed01.x279102e917642b7e.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "allowReadMode", base.x28fcdc775a1d069c.x73979cef1002ed01.xa4866abd29e857a4.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "enableContextMenu", base.x28fcdc775a1d069c.x73979cef1002ed01.x98366ee248c13eda.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "controlFlags", base.x28fcdc775a1d069c.x73979cef1002ed01.x594c3b7ff1a9e3ee.ToString(), x1c13b183d06796fe: true);
		x38b9e81d340a3c46(xd07ce4b74c5774a7, "leftPaneTabs", base.x28fcdc775a1d069c.x73979cef1002ed01.x1b7f1e60fe3e4d73.ToString(), x1c13b183d06796fe: true);
		if (base.x28fcdc775a1d069c.x73979cef1002ed01.x7ebe0c078042f9e8 != null)
		{
			x38b9e81d340a3c46(xd07ce4b74c5774a7, "logoImage", Convert.ToBase64String(base.x28fcdc775a1d069c.x73979cef1002ed01.x7ebe0c078042f9e8), x1c13b183d06796fe: false);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(base.x28fcdc775a1d069c.x73979cef1002ed01.x423a4f3f3de80da8))
		{
			x38b9e81d340a3c46(xd07ce4b74c5774a7, "logoLink", base.x28fcdc775a1d069c.x73979cef1002ed01.x423a4f3f3de80da8, x1c13b183d06796fe: true);
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x38b9e81d340a3c46(x3c74b3c4f21844f9 xd07ce4b74c5774a7, string xae050273e3024171, string x5fd020424a32006a, bool x1c13b183d06796fe)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("param");
		xd07ce4b74c5774a7.xff520a0047c27122("name", xae050273e3024171);
		xd07ce4b74c5774a7.xff520a0047c27122("allowOverride", x1c13b183d06796fe.ToString());
		xd07ce4b74c5774a7.x5222f4285e37d66b.WriteCData(x5fd020424a32006a);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x32a23a856538ee72(x3c74b3c4f21844f9 xd07ce4b74c5774a7, string x3d648efde9f34101, Hashtable xac1c850120b1f254)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("bundle");
		xd07ce4b74c5774a7.xff520a0047c27122("name", x3d648efde9f34101);
		foreach (DictionaryEntry item in xac1c850120b1f254)
		{
			string xbcea506a33cf = (string)item.Key;
			string xbcea506a33cf2 = (string)item.Value;
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf2))
			{
				xd07ce4b74c5774a7.x2307058321cdb62f("item");
				xd07ce4b74c5774a7.xff520a0047c27122("id", xbcea506a33cf);
				xd07ce4b74c5774a7.xff520a0047c27122("tip", xbcea506a33cf2);
				xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			}
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private void x05e3cedc50cf7315(short xbe4a60d4d01e2087)
	{
		xb4e6bcae51300e9c xb4e6bcae51300e9c2 = new xb4e6bcae51300e9c(base.x28fcdc775a1d069c);
		xb4e6bcae51300e9c2.xacf4b9ddf32bef06();
		base.x5aa326f374b3d0ef.x6ff7c65ed4805c27(1);
		base.x5aa326f374b3d0ef.xf2c2dbac0bb24ba0("DocumentDescriptor");
		base.x5aa326f374b3d0ef.x4c116b70372a3c6d(xac4ff1047b721aff.xb2b05fdc63164cc3);
		xb4e6bcae51300e9c2.xc463dec5a3ab6e2d(xf066f1f57515a14c.x650d6c3eb9ebd398);
		xb4e6bcae51300e9c2.xacf4b9ddf32bef06();
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(1);
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(xbe4a60d4d01e2087);
		base.x5aa326f374b3d0ef.xf2c2dbac0bb24ba0("DocumentDescriptor");
		xb4e6bcae51300e9c2.xc463dec5a3ab6e2d(xf066f1f57515a14c.x5ce205a253094b03);
	}
}
