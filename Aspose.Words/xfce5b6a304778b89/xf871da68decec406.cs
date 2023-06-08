using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x55b2bd426d41d30c;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using xbe73d5820f7f4ae3;
using xcf014befd8b52c3b;
using xf9a9481c3f63a419;

namespace xfce5b6a304778b89;

internal class xf871da68decec406
{
	private readonly xb08af07e0a146853 x7e24ae8042d3886b;

	private readonly Document x232be220f517f721;

	private x536e1b48249b1390 xdc906c1563ddbbb7;

	private ArrayList x9226329bcfe35a59;

	private readonly x08afc512f69acef1 x18c770831ef0bf38;

	private readonly xb129d89e9ebefa31 x1a9c45e4b32c86ce;

	private readonly x9fad39f3e89231e8 x0c3c8987627f1a69;

	private string x1b6ac644b48cd180;

	private bool xcd47a2f0edc77480;

	private bool xa27a8f4422197a6d;

	private bool xe264fdc9c1437a75;

	private bool x163b4de13abc518d;

	private bool xc41abe3dad619e97;

	private bool xee010d3c91694126;

	private int xfe055880bdaec13d;

	private int x1fa4169cbf2b08e9;

	private double xbc2b7597d1642ad4;

	private double x0953b3fa82e477e6;

	private string xbe74a2c617783a09;

	private readonly Stack x1c3fe7ed6428d835 = new Stack();

	private readonly Hashtable x9a1f2a59ad254c56 = new Hashtable();

	private readonly Hashtable x0723a61e89e53dc1 = new Hashtable();

	private bool xdd069529d1cb3d75;

	private bool x7c5ae101fcc03b26;

	private string x0b9bb664f3b25c5c;

	private string xbe39036341e55b02;

	private x3b4e2cec591fc3bf xd93bcf0fe25213f7;

	private bool x1eaea7a5fe2fdbb5;

	private readonly IWarningCallback xa056586c1f99e199;

	internal static int xe7aec7217cdc7f54;

	internal static int xa1067e457bc8d35e;

	internal static double x257838bcbdeec4e9 = 1.0;

	internal static bool x09fe644179189b22;

	internal static bool xfe7eb210c7e884c4;

	private static readonly char[] x549f3fcea4f2d337 = new char[3] { '(', ')', '|' };

	internal static string x3da162cd5d0dd2a4;

	private int x131b40587d09cbe9;

	private bool x825223f3970f607f = true;

	internal Document x2c8c6741422a1298 => x232be220f517f721;

	internal xb08af07e0a146853 x39c7aeeec1af9dd0 => x7e24ae8042d3886b;

	internal x536e1b48249b1390 xca994afbcb9073a2
	{
		get
		{
			return xdc906c1563ddbbb7;
		}
		set
		{
			xdc906c1563ddbbb7 = value;
		}
	}

	internal x08afc512f69acef1 x37eb83f4e2a8fe56 => x18c770831ef0bf38;

	internal xb129d89e9ebefa31 x071d9b5ee3757e23 => x1a9c45e4b32c86ce;

	internal x9fad39f3e89231e8 x1673de9450d42ee5 => x0c3c8987627f1a69;

	internal string xe5ffcf1e3f9bd387
	{
		get
		{
			return x1b6ac644b48cd180;
		}
		set
		{
			x1b6ac644b48cd180 = value;
		}
	}

	internal bool x331aa0caef1d0657
	{
		get
		{
			return xa27a8f4422197a6d;
		}
		set
		{
			xa27a8f4422197a6d = value;
		}
	}

	internal bool xb9e32c79bd755ad8
	{
		get
		{
			return xe264fdc9c1437a75;
		}
		set
		{
			xe264fdc9c1437a75 = value;
		}
	}

	internal int xcc4ecf15e89f627e
	{
		get
		{
			return xfe055880bdaec13d;
		}
		set
		{
			xfe055880bdaec13d = value;
		}
	}

	internal int xf13a626e550cef8f
	{
		get
		{
			return x1fa4169cbf2b08e9;
		}
		set
		{
			x1fa4169cbf2b08e9 = value;
		}
	}

	internal string xcf39848e8372bf94
	{
		get
		{
			return xbe74a2c617783a09;
		}
		set
		{
			xbe74a2c617783a09 = value;
		}
	}

	internal Hashtable x315cb47baef59522 => x9a1f2a59ad254c56;

	internal Stack x025b4232f6267898 => x1c3fe7ed6428d835;

	internal bool xed48a3fa9b038203
	{
		get
		{
			return x163b4de13abc518d;
		}
		set
		{
			x163b4de13abc518d = value;
		}
	}

	internal bool x513275af5c756949
	{
		get
		{
			return xc41abe3dad619e97;
		}
		set
		{
			xc41abe3dad619e97 = value;
		}
	}

	internal bool x186e5825c720d6b2
	{
		get
		{
			return xee010d3c91694126;
		}
		set
		{
			xee010d3c91694126 = value;
		}
	}

	internal ArrayList x6147b51b34c29eea
	{
		get
		{
			return x9226329bcfe35a59;
		}
		set
		{
			x9226329bcfe35a59 = value;
		}
	}

	internal bool x5886c1038090f427
	{
		get
		{
			return xcd47a2f0edc77480;
		}
		set
		{
			xcd47a2f0edc77480 = value;
		}
	}

	internal bool x49e385128b291987
	{
		get
		{
			return xdd069529d1cb3d75;
		}
		set
		{
			xdd069529d1cb3d75 = value;
		}
	}

	internal bool xf0012596d13ab3f3
	{
		get
		{
			return x7c5ae101fcc03b26;
		}
		set
		{
			x7c5ae101fcc03b26 = value;
		}
	}

	private double x204414017cf54f95 => x0953b3fa82e477e6;

	private double xa932600d61ea7dd8 => xbc2b7597d1642ad4;

	internal string x58c712b0d1d1c39b
	{
		get
		{
			return x0b9bb664f3b25c5c;
		}
		set
		{
			x0b9bb664f3b25c5c = value;
		}
	}

	internal string x42f4c234c9358072
	{
		get
		{
			return xbe39036341e55b02;
		}
		set
		{
			xbe39036341e55b02 = value;
		}
	}

	internal x3b4e2cec591fc3bf x3b4e2cec591fc3bf
	{
		get
		{
			return xd93bcf0fe25213f7;
		}
		set
		{
			xd93bcf0fe25213f7 = value;
		}
	}

	public Hashtable xa2bae26554bf2a93 => x0723a61e89e53dc1;

	public bool x51811c878dba9ce3
	{
		get
		{
			return x1eaea7a5fe2fdbb5;
		}
		set
		{
			x1eaea7a5fe2fdbb5 = value;
		}
	}

	public int xd9c2f8178451a779
	{
		get
		{
			return x131b40587d09cbe9;
		}
		set
		{
			x131b40587d09cbe9 = value;
		}
	}

	internal bool xf3a0f9e4e429f8f2
	{
		get
		{
			return x825223f3970f607f;
		}
		set
		{
			x825223f3970f607f = value;
		}
	}

	internal xf871da68decec406(Stream stream, Document doc, IWarningCallback warningCallback)
	{
		x9226329bcfe35a59 = new ArrayList();
		x18c770831ef0bf38 = new x08afc512f69acef1();
		x1a9c45e4b32c86ce = new xb129d89e9ebefa31();
		x0c3c8987627f1a69 = new x9fad39f3e89231e8();
		x7e24ae8042d3886b = new xb08af07e0a146853(stream);
		xa056586c1f99e199 = warningCallback;
		x232be220f517f721 = doc;
		x232be220f517f721.Sections.Clear();
		x0ca5e8b532953a51 x0ca5e8b532953a = x7e24ae8042d3886b.x5621ebad67e4df79("/META-INF/documentsignatures.xml");
		if (x0ca5e8b532953a != null)
		{
			x616fc5ae23ca7e6e.x06b0e25aa6ad68a9(x0ca5e8b532953a.xb8a774e0111d0fbe, new x01fa75f224fa8053(x7e24ae8042d3886b), x232be220f517f721.DigitalSignatures, warningCallback);
		}
		x131b40587d09cbe9 = 0;
		xfe055880bdaec13d = 1;
		x1fa4169cbf2b08e9 = -1;
		xbc2b7597d1642ad4 = double.NaN;
		x0953b3fa82e477e6 = double.NaN;
		xa056586c1f99e199 = warningCallback;
	}

	internal void x06b0e25aa6ad68a9()
	{
		x37eb83f4e2a8fe56.xa9d636b00ff486b7();
		x071d9b5ee3757e23.Clear();
		x232be220f517f721.xdade2366eaa6f915.xd72f9bc5cc53fc1c = 1134;
		x232be220f517f721.xdade2366eaa6f915.x14fd633e1477f9de = false;
		x255ae964ece09fa0.x06b0e25aa6ad68a9(this);
		x369b1abb8947a244.x06b0e25aa6ad68a9(this);
		x36a491f4ff352ec5.x06b0e25aa6ad68a9(this);
		if (x071d9b5ee3757e23.get_xe6d4b1b411ed94b5("Standard") == null)
		{
			x737859ad275ea32d();
		}
		xad966e639ad49650.x06b0e25aa6ad68a9(this);
		xcadc354ab6a177f1 xcadc354ab6a177f = x232be220f517f721.xdade2366eaa6f915.xcadc354ab6a177f1;
		if (x7c5ae101fcc03b26)
		{
			xcadc354ab6a177f.x0cbff01514c02c1b = true;
			xcadc354ab6a177f.x5410a63599038a04 = ProtectionType.AllowOnlyFormFields;
		}
		foreach (Section section in x232be220f517f721.Sections)
		{
			if (x7c5ae101fcc03b26 && section.xfc72d4c9b765cad7.xf7866f89640a29a3(2390) == null)
			{
				section.xfc72d4c9b765cad7.x3f5233cee263582a = true;
			}
			if (!section.x16479f42fe4547f2 && !section.Body.x74f5d3c8c1c169b6)
			{
				section.Body.Paragraphs.Add(new Paragraph(x232be220f517f721));
			}
		}
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Odt, xc2358fbac7da3d45));
		}
	}

	internal void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, xc2358fbac7da3d45);
	}

	private void x737859ad275ea32d()
	{
		xb77bc1b681ac1354 xb77bc1b681ac1355 = new xb77bc1b681ac1354();
		xb77bc1b681ac1355.x759aa16c2016a289 = "pm0";
		xb77bc1b681ac1355.xfc72d4c9b765cad7 = new xfc72d4c9b765cad7();
		x18c770831ef0bf38.xd6b6ed77479ef68c(xb77bc1b681ac1355, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: true);
		x899ab188166aec2d x899ab188166aec2d2 = new x899ab188166aec2d();
		x899ab188166aec2d2.x759aa16c2016a289 = "Standard";
		x899ab188166aec2d2.x4fc90f517816f531 = xb77bc1b681ac1355.x759aa16c2016a289;
		x899ab188166aec2d2.x10d7a1cae426b158 = new Section(x232be220f517f721);
		x1a9c45e4b32c86ce.Add(x899ab188166aec2d2);
	}

	internal static bool x1d481f2ddf720611(x536e1b48249b1390 xd19f1b93a822ffb3, x38c672d671ef22c7 x44ecfea61c937b8e, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
		{
		case "break-before":
			if (xd19f1b93a822ffb3.xd2f68ee6f47e9dfb == "page")
			{
				x062aae8c9613eeaa.xb6157b6da9895c0d(1060, true);
				x44ecfea61c937b8e.xbed6d6330712f0f2 = true;
			}
			if (xd19f1b93a822ffb3.xd2f68ee6f47e9dfb == "auto")
			{
				x062aae8c9613eeaa.xb6157b6da9895c0d(1060, false);
				x44ecfea61c937b8e.xbed6d6330712f0f2 = false;
			}
			x44ecfea61c937b8e.x182d2ff0a0cf9645 = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb == "column";
			return true;
		case "break-after":
			x44ecfea61c937b8e.x331aa0caef1d0657 = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb == "page";
			x44ecfea61c937b8e.x32214f13df983792 = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb == "column";
			return true;
		default:
			return false;
		}
	}

	internal static bool xe486365cb08165a7(x536e1b48249b1390 xd19f1b93a822ffb3, x6a3b9cbff75fd927 x241924dcc793876e)
	{
		switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
		{
		case "border":
			x241924dcc793876e.xa8c2637cc4888928 = x533663bbcdc757a9.x28f49f0eeecaafb7(x241924dcc793876e.xa8c2637cc4888928, xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			x241924dcc793876e.x79d902473861f242 = x533663bbcdc757a9.x28f49f0eeecaafb7(x241924dcc793876e.x79d902473861f242, xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			x241924dcc793876e.xaea087ab32102492 = x533663bbcdc757a9.x28f49f0eeecaafb7(x241924dcc793876e.xaea087ab32102492, xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			x241924dcc793876e.xd7a21e27974f626c = x533663bbcdc757a9.x28f49f0eeecaafb7(x241924dcc793876e.xd7a21e27974f626c, xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		case "border-top":
			x241924dcc793876e.xa8c2637cc4888928 = x533663bbcdc757a9.x28f49f0eeecaafb7(x241924dcc793876e.xa8c2637cc4888928, xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		case "border-bottom":
			x241924dcc793876e.x79d902473861f242 = x533663bbcdc757a9.x28f49f0eeecaafb7(x241924dcc793876e.x79d902473861f242, xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		case "border-left":
			x241924dcc793876e.xaea087ab32102492 = x533663bbcdc757a9.x28f49f0eeecaafb7(x241924dcc793876e.xaea087ab32102492, xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		case "border-right":
			x241924dcc793876e.xd7a21e27974f626c = x533663bbcdc757a9.x28f49f0eeecaafb7(x241924dcc793876e.xd7a21e27974f626c, xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		default:
			return false;
		}
	}

	internal static bool xb8a5c0590fac08ae(x536e1b48249b1390 xd19f1b93a822ffb3, x1ba0adbe4f846c39 x6e5ae614ae422322)
	{
		switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
		{
		case "padding":
			x6e5ae614ae422322.x41c7a253dffab96d = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			x6e5ae614ae422322.xf2f0e85a6d5b32fb = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			x6e5ae614ae422322.x1fce31db7994633f = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			x6e5ae614ae422322.x5035ade17b9c6f87 = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		case "padding-top":
			x6e5ae614ae422322.x41c7a253dffab96d = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		case "padding-bottom":
			x6e5ae614ae422322.xf2f0e85a6d5b32fb = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		case "padding-left":
			x6e5ae614ae422322.x1fce31db7994633f = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		case "padding-right":
			x6e5ae614ae422322.x5035ade17b9c6f87 = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		default:
			return false;
		}
	}

	internal bool x42e780a8d918ac91(x536e1b48249b1390 xd19f1b93a822ffb3, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		if (x1d2bfdcef0fccba5(xd19f1b93a822ffb3, xa5e8b8b5991a4e1d))
		{
			return true;
		}
		return xcc3885d9d7ef14a9(xd19f1b93a822ffb3, xa5e8b8b5991a4e1d);
	}

	private static bool xcc3885d9d7ef14a9(x536e1b48249b1390 xd19f1b93a822ffb3, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
		{
		case "x":
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4129, xbb857c9fc36f5054.xc42baa2576960ea5(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb));
			return true;
		case "y":
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4130, xbb857c9fc36f5054.xc42baa2576960ea5(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb));
			return true;
		default:
			return false;
		}
	}

	internal static void xc8cbf0c64adea241(xf7125312c7ee115c xa5e8b8b5991a4e1d, string x8b0a6a8c69ab5cff)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x8b0a6a8c69ab5cff))
		{
			return;
		}
		string[] array = x8b0a6a8c69ab5cff.Replace(" ", "").Replace("cm", "cm|").Replace("mm", "mm|")
			.Replace("in", "in|")
			.Replace("pt", "pt|")
			.Replace("pc", "pc|")
			.Replace("px", "px|")
			.Split(x549f3fcea4f2d337);
		double num = ((xa5e8b8b5991a4e1d.xf7866f89640a29a3(4129) == null) ? 0.0 : ((double)xa5e8b8b5991a4e1d.xf7866f89640a29a3(4129)));
		double num2 = ((xa5e8b8b5991a4e1d.xf7866f89640a29a3(4130) == null) ? 0.0 : ((double)xa5e8b8b5991a4e1d.xf7866f89640a29a3(4130)));
		double num3 = ((xa5e8b8b5991a4e1d.xf7866f89640a29a3(4) == null) ? 0.0 : x4574ea26106f0edb.x97ab502db0c0e5c2((int)xa5e8b8b5991a4e1d.xf7866f89640a29a3(4)));
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				if (text == "translate")
				{
					num += xbb857c9fc36f5054.xc42baa2576960ea5(array[++i]);
					num2 += xbb857c9fc36f5054.xc42baa2576960ea5(array[++i]);
				}
				else if (text == "rotate")
				{
					num3 += (0.0 - 180.0 * xca004f56614e2431.xec25d08a2af152f0(array[++i])) / Math.PI;
				}
			}
		}
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4129, num);
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4130, num2);
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4, x4574ea26106f0edb.x091b250f00534aae(num3));
	}

	private bool x1d2bfdcef0fccba5(x536e1b48249b1390 xd19f1b93a822ffb3, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
		{
		case "width":
			xbc2b7597d1642ad4 = xbb857c9fc36f5054.xc42baa2576960ea5(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4131, xbc2b7597d1642ad4);
			return true;
		case "height":
			x0953b3fa82e477e6 = xbb857c9fc36f5054.xc42baa2576960ea5(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4132, x0953b3fa82e477e6);
			return true;
		default:
			return false;
		}
	}

	internal static bool x082ded0c9904f37b(x536e1b48249b1390 xd19f1b93a822ffb3, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
		{
		case "rel-width":
		case "rel-height":
			return true;
		default:
			return false;
		}
	}

	internal static bool xec2649804854d946(xf871da68decec406 xe134235b3526fa75, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		x536e1b48249b1390 x536e1b48249b1391 = xe134235b3526fa75.xca994afbcb9073a2;
		switch (x536e1b48249b1391.xa66385d80d4d296f)
		{
		case "anchor-type":
			if (x536e1b48249b1391.xd2f68ee6f47e9dfb == "as-char")
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(4097, WrapType.Inline);
			}
			if (x536e1b48249b1391.xd2f68ee6f47e9dfb == "page")
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(912, RelativeHorizontalPosition.Page);
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(914, RelativeVerticalPosition.Page);
			}
			return true;
		case "anchor-page-number":
			return false;
		default:
			return false;
		}
	}

	internal static bool x46e6752379e6650e(xf871da68decec406 xe134235b3526fa75, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		x536e1b48249b1390 x536e1b48249b1391 = xe134235b3526fa75.xca994afbcb9073a2;
		if (xe134235b3526fa75.x81c468031b83f5fc(x536e1b48249b1391))
		{
			return true;
		}
		switch (x536e1b48249b1391.xa66385d80d4d296f)
		{
		case "z-index":
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4154, x536e1b48249b1391.xbba6773b8ce56a01);
			return true;
		case "transform":
		case "text-style-name":
		case "id":
		case "layer":
		case "class-names":
		case "name":
		case "end-cell-address":
		case "end-x":
		case "end-y":
		case "table-background":
		case "anchor-page-number":
			return false;
		default:
			return false;
		}
	}

	internal static bool x8125d547dbbe8218(x536e1b48249b1390 xd19f1b93a822ffb3, x95973895507fea32 x44ecfea61c937b8e)
	{
		switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
		{
		case "name":
			x44ecfea61c937b8e.x759aa16c2016a289 = xbb857c9fc36f5054.x94045081801bb82d(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		case "display-name":
			x44ecfea61c937b8e.xba89ca2127612c56 = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb;
			return true;
		default:
			return false;
		}
	}

	internal bool x81c468031b83f5fc(x536e1b48249b1390 xd19f1b93a822ffb3)
	{
		if (xd19f1b93a822ffb3.xa66385d80d4d296f == "style-name")
		{
			xe5ffcf1e3f9bd387 = xbb857c9fc36f5054.x94045081801bb82d(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			return true;
		}
		return false;
	}

	internal static bool xb0473d4afe16cb4d(x536e1b48249b1390 xd19f1b93a822ffb3, xaf975f26d67e34e8 xef9bc48270a0c987)
	{
		if (xabeb55ee33705aa9(xd19f1b93a822ffb3, xef9bc48270a0c987.x71043d5524bf9d58) || x7c26d523c3b050f5(xd19f1b93a822ffb3, xef9bc48270a0c987.xa3e94d39710969ea))
		{
			return true;
		}
		if (xd19f1b93a822ffb3.xa66385d80d4d296f == "margin")
		{
			double num = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			xef9bc48270a0c987.x71043d5524bf9d58.x83551eb97a16bb65 = num;
			xef9bc48270a0c987.x71043d5524bf9d58.xa671de6a1e9bcaae = num;
			xef9bc48270a0c987.xa3e94d39710969ea.xc334118c782d9421 = num;
			xef9bc48270a0c987.xa3e94d39710969ea.xc6c700120c59c6b8 = num;
			xef9bc48270a0c987.xa3e94d39710969ea.x5bd10369f179217c = true;
			xef9bc48270a0c987.xa3e94d39710969ea.x87d950866dbc19f7 = true;
			xef9bc48270a0c987.x71043d5524bf9d58.x33ec425398367777 = true;
			xef9bc48270a0c987.x71043d5524bf9d58.x1148d335a6671b0c = true;
			return true;
		}
		return false;
	}

	internal static bool xfe4f7dca36c0076c(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		if (x8b2c3c076d5a7daf is Shape)
		{
			return false;
		}
		x536e1b48249b1390 x536e1b48249b1391 = xe134235b3526fa75.xca994afbcb9073a2;
		CompositeNode x8b2c3c076d5a7daf2 = x8b2c3c076d5a7daf;
		string xd8a1c7c41bfbcde = x536e1b48249b1391.xd8a1c7c41bfbcde0;
		string xa66385d80d4d296f = x536e1b48249b1391.xa66385d80d4d296f;
		if (x8b2c3c076d5a7daf is Body)
		{
			if (!(xd8a1c7c41bfbcde == "draw") || !(xa66385d80d4d296f == "a"))
			{
				switch (xa66385d80d4d296f)
				{
				case "g":
				case "line":
				case "connector":
				case "rect":
				case "circle":
				case "ellipse":
				case "polyline":
				case "polygon":
				case "regular-polygon":
				case "path":
				case "page-thumbnail":
				case "measure":
				case "caption":
				case "scene":
				case "custom-shape":
					break;
				default:
					goto IL_018d;
				}
			}
			if (xe134235b3526fa75.x6147b51b34c29eea.Count == 0)
			{
				Body body = (Body)x8b2c3c076d5a7daf;
				if (body.LastParagraph == null)
				{
					body.AppendChild(new Paragraph(xe134235b3526fa75.x2c8c6741422a1298));
					xe134235b3526fa75.x6147b51b34c29eea.Add(body.LastParagraph);
				}
				x8b2c3c076d5a7daf2 = body.LastParagraph;
			}
			else
			{
				x8b2c3c076d5a7daf2 = (Paragraph)xe134235b3526fa75.x6147b51b34c29eea[xe134235b3526fa75.x6147b51b34c29eea.Count - 1];
			}
		}
		goto IL_018d;
		IL_018d:
		switch (x536e1b48249b1391.xa66385d80d4d296f)
		{
		case "g":
			xcc2382b7ff53fc08.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf2, x789564759d365819);
			return true;
		case "a":
			return xb3cbf39b03c7986e(xe134235b3526fa75, x8b2c3c076d5a7daf2);
		case "frame":
			x253dc1c25dfd49a2.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf2, x789564759d365819);
			return true;
		case "control":
			x96a5aac2efa9fd8a.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf2, x789564759d365819, xce987d84406b1bfc);
			return true;
		case "line":
			x2f70f4b50b541c08.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf2, x789564759d365819);
			return true;
		case "connector":
			x274144058ca540ae.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf2, x789564759d365819);
			return true;
		case "rect":
			xe134235b3526fa75.x51811c878dba9ce3 = true;
			xaaf01948fa183576.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf2, x789564759d365819);
			xe134235b3526fa75.x51811c878dba9ce3 = false;
			return true;
		case "circle":
		case "ellipse":
			xe134235b3526fa75.x51811c878dba9ce3 = true;
			xb10aca627e9bdedc.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf2, x789564759d365819);
			xe134235b3526fa75.x51811c878dba9ce3 = false;
			return true;
		case "custom-shape":
		case "polyline":
		case "polygon":
		{
			xe134235b3526fa75.x51811c878dba9ce3 = true;
			xa9639c96f6308c75 xa9639c96f6308c76 = new xa9639c96f6308c75();
			xa9639c96f6308c76.x13e058df34e523fc = x536e1b48249b1391.xa66385d80d4d296f == "polyline";
			xa9639c96f6308c76.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf2, x789564759d365819);
			xe134235b3526fa75.x51811c878dba9ce3 = false;
			return true;
		}
		case "path":
		{
			xe134235b3526fa75.x51811c878dba9ce3 = true;
			xa6dfe060743f7e59 xa6dfe060743f7e60 = new xa6dfe060743f7e59();
			xa6dfe060743f7e60.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf2, x789564759d365819);
			xe134235b3526fa75.x51811c878dba9ce3 = false;
			return true;
		}
		case "regular-polygon":
			xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Import of regular-polygon element is not supported.");
			break;
		case "page-thumbnail":
		case "measure":
		case "caption":
		case "scene":
			return true;
		}
		return false;
	}

	internal bool xb18e918c8e329f66(xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		x536e1b48249b1390 x536e1b48249b1391 = xca994afbcb9073a2;
		if (x536e1b48249b1391.xa66385d80d4d296f == "desc")
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(897, x536e1b48249b1391.x2a1ea9d24e62bf84());
			return true;
		}
		return false;
	}

	private static bool xb3cbf39b03c7986e(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf)
	{
		x536e1b48249b1390 x536e1b48249b1391 = xe134235b3526fa75.xca994afbcb9073a2;
		if (x536e1b48249b1391.xd8a1c7c41bfbcde0 != "draw")
		{
			return false;
		}
		string text = "";
		string text2 = "";
		while (x536e1b48249b1391.x1ac1960adc8c4c39())
		{
			switch (x536e1b48249b1391.xa66385d80d4d296f)
			{
			case "href":
				text = xbb857c9fc36f5054.x573fbc1b32ee4645(x536e1b48249b1391.xd2f68ee6f47e9dfb);
				break;
			case "target-frame-name":
				text2 = x536e1b48249b1391.xd2f68ee6f47e9dfb;
				break;
			}
		}
		xe134235b3526fa75.x58c712b0d1d1c39b = text;
		xe134235b3526fa75.x42f4c234c9358072 = text2;
		while (x536e1b48249b1391.x152cbadbfa8061b1("a"))
		{
			if (x536e1b48249b1391.xa66385d80d4d296f == "frame")
			{
				x253dc1c25dfd49a2.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf, null);
				continue;
			}
			x536e1b48249b1391.IgnoreElement();
			xe134235b3526fa75.x3dc950453374051a(x536e1b48249b1391.xa66385d80d4d296f);
		}
		xe134235b3526fa75.x58c712b0d1d1c39b = null;
		xe134235b3526fa75.x42f4c234c9358072 = null;
		return true;
	}

	internal static void x08b1f2bf85ce1fc8(xf871da68decec406 xe134235b3526fa75, string xbcea506a33cf9111, bool xbee336e5a17b0d53, bool x74a48429afea3d90, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		x09fe644179189b22 = false;
		xfe7eb210c7e884c4 = false;
		x257838bcbdeec4e9 = 1.0;
		if (!x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			return;
		}
		string[] array = xbcea506a33cf9111.Trim().Split(' ');
		int[] array2 = new int[4];
		for (int i = 0; i < array.Length && i < 4; i++)
		{
			int num = xca004f56614e2431.x912616ee70b2d94d(array[i]);
			if (num != int.MinValue)
			{
				array2[i] = num;
				continue;
			}
			return;
		}
		int num2 = array2[2] - array2[0];
		int num3 = array2[3] - array2[1];
		xe7aec7217cdc7f54 = array2[2];
		xa1067e457bc8d35e = array2[3];
		if (num3 > 0)
		{
			double num4 = (double)num2 / (double)num3;
			double num5 = xe134235b3526fa75.xa932600d61ea7dd8 / xe134235b3526fa75.x204414017cf54f95;
			if (xbee336e5a17b0d53 && num4 < num5)
			{
				num2 = (int)((double)num2 * num5);
				x257838bcbdeec4e9 = num5;
				x09fe644179189b22 = true;
			}
			if (x74a48429afea3d90 && num4 > num5)
			{
				num3 = (int)((double)num3 / num5);
				x257838bcbdeec4e9 = num5;
				xfe7eb210c7e884c4 = true;
			}
		}
		if (xbb857c9fc36f5054.x67ec5097b5f33a4e(num2, num3))
		{
			xbb857c9fc36f5054.x943cf6ea563cd0a9(num2, num3);
			num2 = xbb857c9fc36f5054.x01c5989f49b62737(num2);
			num3 = xbb857c9fc36f5054.x01c5989f49b62737(num3);
		}
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4125, array2[0]);
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4126, array2[1]);
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4127, num2);
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(4128, num3);
	}

	internal static bool x52b97b00d3a73947(xf871da68decec406 xe134235b3526fa75, Shape x5770cdefd8931aa9)
	{
		x536e1b48249b1390 x536e1b48249b1391 = xe134235b3526fa75.xca994afbcb9073a2;
		switch (x536e1b48249b1391.xa66385d80d4d296f)
		{
		case "p":
			xef3217fa00e6d2ba.x06b0e25aa6ad68a9(xe134235b3526fa75, x536e1b48249b1391.xa66385d80d4d296f, x5770cdefd8931aa9);
			return true;
		case "list":
			x51bdb35997d05bcf.x06b0e25aa6ad68a9(xe134235b3526fa75, x5770cdefd8931aa9, null);
			return true;
		default:
			return false;
		}
	}

	private static bool x7c26d523c3b050f5(x536e1b48249b1390 xd19f1b93a822ffb3, xf149185ec031e580 x957fe1ff22caec73)
	{
		switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
		{
		case "margin-left":
			x957fe1ff22caec73.xc334118c782d9421 = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			x957fe1ff22caec73.x5bd10369f179217c = true;
			return true;
		case "margin-right":
			x957fe1ff22caec73.xc6c700120c59c6b8 = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			x957fe1ff22caec73.x87d950866dbc19f7 = true;
			return true;
		default:
			return false;
		}
	}

	private static bool xabeb55ee33705aa9(x536e1b48249b1390 xd19f1b93a822ffb3, x2be21853d6598dd1 xb4c5498ed1c4ea4e)
	{
		switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
		{
		case "margin-top":
			xb4c5498ed1c4ea4e.x83551eb97a16bb65 = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			xb4c5498ed1c4ea4e.x33ec425398367777 = true;
			return true;
		case "margin-bottom":
			xb4c5498ed1c4ea4e.xa671de6a1e9bcaae = xbb857c9fc36f5054.x85ddf5f63df4b542(xd19f1b93a822ffb3.xd2f68ee6f47e9dfb);
			xb4c5498ed1c4ea4e.x1148d335a6671b0c = true;
			return true;
		default:
			return false;
		}
	}

	internal void x49cbb572afb26d4b(bool x2a7214f600b3f97c, bool x2598783a06246741)
	{
		int num = x18c770831ef0bf38.xcf2fd36bc07b78ec;
		if (!x2a7214f600b3f97c)
		{
			num = x18c770831ef0bf38.xde4dcae228e536db;
		}
		else if (x2598783a06246741)
		{
			num = x18c770831ef0bf38.x21b629d0d9bfc031;
		}
		for (int i = 0; i < num; i++)
		{
			x95973895507fea32 x95973895507fea = (x2a7214f600b3f97c ? (x2598783a06246741 ? x18c770831ef0bf38.x039f29e111117566(i) : x18c770831ef0bf38.xe12908afde76bfa4(i)) : x18c770831ef0bf38.x9351b86239699645(i));
			if (!(x95973895507fea is x5668c8829b7abcee))
			{
				continue;
			}
			x5668c8829b7abcee x5668c8829b7abcee2 = x95973895507fea as x5668c8829b7abcee;
			if (x5668c8829b7abcee2.x87e47b848b0093cb <= 0.0 || x5668c8829b7abcee2.xeedad81aaed42a76 == null || x5668c8829b7abcee2.xeedad81aaed42a76.x263d579af1d0d43f(190))
			{
				continue;
			}
			int num2 = -1;
			string text = x5668c8829b7abcee2.x6901ea11a338ff2b;
			string x759aa16c2016a;
			do
			{
				x5668c8829b7abcee x5668c8829b7abcee3 = (x5668c8829b7abcee)x18c770831ef0bf38.get_xe6d4b1b411ed94b5(text, x5668c8829b7abcee2.x4ccc2e5631b8ba9c);
				if (x5668c8829b7abcee3 == null)
				{
					break;
				}
				if (x5668c8829b7abcee3.xeedad81aaed42a76 != null && x5668c8829b7abcee3.xeedad81aaed42a76.x263d579af1d0d43f(190))
				{
					num2 = x5668c8829b7abcee3.xeedad81aaed42a76.x437e3b626c0fdd43;
					text = null;
				}
				else
				{
					text = ((text == "Standard") ? null : x5668c8829b7abcee3.x6901ea11a338ff2b);
				}
				x759aa16c2016a = x5668c8829b7abcee3.x759aa16c2016a289;
			}
			while (x0d299f323d241756.x5959bccb67bbf051(x759aa16c2016a) && num2 == -1);
			if (num2 == -1)
			{
				num2 = 20;
			}
			x5668c8829b7abcee2.xeedad81aaed42a76.xae20093bed1e48a8(190, x15e971129fd80714.x43fcc3f62534530b((double)num2 * x5668c8829b7abcee2.x87e47b848b0093cb / 100.0));
		}
	}

	internal static void x7440208dce82f530(Inline x31545d7c306a55e4, Style xce987d84406b1bfc)
	{
		if (xce987d84406b1bfc != null)
		{
			x31545d7c306a55e4.Font.x8301ab10c226b0c2 = xce987d84406b1bfc.x8301ab10c226b0c2;
		}
	}

	internal static bool x727228e6a08acf61(Stream xd8b34625ad33446a)
	{
		x536e1b48249b1390 x536e1b48249b1391 = new x536e1b48249b1390(xd8b34625ad33446a);
		while (x536e1b48249b1391.x152cbadbfa8061b1("document-signatures"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x536e1b48249b1391.xa66385d80d4d296f) != null && xa66385d80d4d296f == "Signature")
			{
				return true;
			}
			x536e1b48249b1391.IgnoreElement();
		}
		return false;
	}

	internal static bool xa4167addc9c6947c(Stream x6a4c7e89450ee0a0)
	{
		x536e1b48249b1390 x536e1b48249b1391 = new x536e1b48249b1390(x6a4c7e89450ee0a0);
		while (x536e1b48249b1391.x152cbadbfa8061b1("manifest"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x536e1b48249b1391.xa66385d80d4d296f) != null && xa66385d80d4d296f == "file-entry")
			{
				while (x536e1b48249b1391.x152cbadbfa8061b1("file-entry"))
				{
					string xa66385d80d4d296f2;
					if ((xa66385d80d4d296f2 = x536e1b48249b1391.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "encryption-data")
					{
						return true;
					}
					x536e1b48249b1391.IgnoreElement();
				}
			}
			else
			{
				x536e1b48249b1391.IgnoreElement();
			}
		}
		return false;
	}

	internal static LoadFormat x6c4f542a03d83ce6(Stream xd57b8dff92eed562)
	{
		StreamReader streamReader = new StreamReader(xd57b8dff92eed562);
		return streamReader.ReadLine() switch
		{
			"application/vnd.oasis.opendocument.text" => LoadFormat.Odt, 
			"application/vnd.oasis.opendocument.text-template" => LoadFormat.Ott, 
			_ => LoadFormat.Unknown, 
		};
	}
}
