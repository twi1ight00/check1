using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Lists;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class xe5e546ef5f0503b2 : xeb0b4eb7a8e9f591
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly x785d57964efa4bd5 xe3136b4e0df7e7e5;

	private readonly xb06fc1bffc8a689b xa86f468fb82e63a7;

	private readonly x4ba0e0b20eeff53c x800085dd555f7711;

	private readonly x49d9c71d05ebee3d x3d4b1a1699f2d6a4;

	private readonly xf8311f89980f27b1 xcfc2e975409c798f;

	private readonly xe6e52668381bf9e6 xf49591a44359232f;

	private readonly x5e566bc77f5325de x1cb20e5365d954a7;

	private readonly Hashtable x9cb399945a71ccf7 = new Hashtable();

	private Border x3befc831c712898b;

	private string x677800d5e3106c0c = "";

	private string xa5eadf17c0ad69c8 = "";

	private readonly xfc72d4c9b765cad7 x02399a46a1120a24 = new xfc72d4c9b765cad7();

	private int xceb4995f65d5be33;

	private readonly Hashtable x99f65b40d6ed2d43 = new Hashtable();

	private readonly Hashtable x76209fd493f96946 = new Hashtable();

	private List x1474cfa239ca3b4f;

	private bool xf4d166dba645165d;

	private readonly LoadOptions xd545ef71ef25db52;

	private string x12cebdb788190c71;

	private DateTime xe74c98906df04217;

	internal Document x2c8c6741422a1298 => xd1424e1a0bb4a72b;

	internal x785d57964efa4bd5 x88bf28725f671e38 => xe3136b4e0df7e7e5;

	internal xb06fc1bffc8a689b x2086e697b5620586 => xa86f468fb82e63a7;

	internal x5e566bc77f5325de x6671391caefa5949 => x1cb20e5365d954a7;

	internal Hashtable x0f1b548a1d4927cb => x9cb399945a71ccf7;

	internal x4ba0e0b20eeff53c xe1410f585439c7d4 => x800085dd555f7711;

	internal bool xb778e4a87af27d7a
	{
		get
		{
			return xf4d166dba645165d;
		}
		set
		{
			xf4d166dba645165d = value;
		}
	}

	internal string x3c5cf62121f6ba42
	{
		get
		{
			return x12cebdb788190c71;
		}
		set
		{
			x12cebdb788190c71 = value;
		}
	}

	internal DateTime x125b1f8e1ea06d76
	{
		get
		{
			return xe74c98906df04217;
		}
		set
		{
			xe74c98906df04217 = value;
		}
	}

	internal x49d9c71d05ebee3d xa3a0cc3e91617aca => x3d4b1a1699f2d6a4;

	internal List xed3a4a9e0daaedc8
	{
		get
		{
			return x1474cfa239ca3b4f;
		}
		set
		{
			x1474cfa239ca3b4f = value;
		}
	}

	internal Border x51d60f077c5fc6e0
	{
		get
		{
			return x3befc831c712898b;
		}
		set
		{
			x3befc831c712898b = value;
		}
	}

	internal xe6e52668381bf9e6 x1ea60bde2b5d0d28 => xf49591a44359232f;

	internal string xe5f47478966fa764
	{
		get
		{
			return x677800d5e3106c0c;
		}
		set
		{
			x677800d5e3106c0c = value;
		}
	}

	internal string xe728a5f2c3443632
	{
		get
		{
			return xa5eadf17c0ad69c8;
		}
		set
		{
			xa5eadf17c0ad69c8 = value;
		}
	}

	internal xf8311f89980f27b1 xde27e91a248c4c90 => xcfc2e975409c798f;

	internal bool x515f532dcc4ad30e
	{
		get
		{
			x25099a8bbbd55d1c x3146d638ec = xa3a0cc3e91617aca.xffb3238a8fd59aa7.x1a55de3a01c1c82d.x3146d638ec378671;
			if (x3146d638ec != x25099a8bbbd55d1c.xfcffbd79482d97c7 && x3146d638ec != x25099a8bbbd55d1c.xcdd1fdba92902f20)
			{
				return x3146d638ec == x25099a8bbbd55d1c.x6c19282943d32085;
			}
			return true;
		}
	}

	internal IWarningCallback xf69ca7a9bb4a4a51
	{
		get
		{
			if (xd545ef71ef25db52 == null)
			{
				return null;
			}
			return xd545ef71ef25db52.WarningCallback;
		}
	}

	internal LoadOptions x1e4394fcb6d34948 => xd545ef71ef25db52;

	internal xe5e546ef5f0503b2(Document doc, LoadOptions loadOptions)
	{
		xd1424e1a0bb4a72b = doc;
		xd545ef71ef25db52 = loadOptions;
		xe3136b4e0df7e7e5 = new x785d57964efa4bd5(addFirstEntry: false);
		xa86f468fb82e63a7 = new xb06fc1bffc8a689b(addFirstEntry: false);
		x800085dd555f7711 = new x4ba0e0b20eeff53c(this);
		x3d4b1a1699f2d6a4 = new x49d9c71d05ebee3d(this);
		xcfc2e975409c798f = new xf8311f89980f27b1();
		xf49591a44359232f = new xe6e52668381bf9e6();
		x1cb20e5365d954a7 = new x5e566bc77f5325de(doc.FontInfos, xf49591a44359232f.x2ddab4ad01316604);
		x12cebdb788190c71 = string.Empty;
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xd545ef71ef25db52.WarningCallback != null)
		{
			xd545ef71ef25db52.WarningCallback.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Rtf, xc2358fbac7da3d45));
		}
	}

	internal void xbd5e5733680bbfc8(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, $"Import of element {xc2358fbac7da3d45} is not supported in Rtf by Aspose.Words.");
	}

	internal void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, xc2358fbac7da3d45);
	}

	internal void x2cf1761602871e10(x4c1e058c67948d6a xe9707cb1ec88db49, int xba08ce632055a1d9)
	{
		x3befc831c712898b = new Border();
		xe9707cb1ec88db49.xae20093bed1e48a8(xba08ce632055a1d9, x3befc831c712898b);
	}

	internal int x3031d94a4c859cd6()
	{
		return ++xceb4995f65d5be33;
	}

	internal string x241e429ca27700bc(int x3d2dde7c72e020a4)
	{
		return x1cb20e5365d954a7.x7bcd2fb72fb7aae6(x3d2dde7c72e020a4);
	}

	internal void xbfc3dda117a540e4(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		x02399a46a1120a24.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
		xa3a0cc3e91617aca.xffb3238a8fd59aa7.xfc72d4c9b765cad7.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	internal void x35f98fe7237b5ee4(xfc72d4c9b765cad7 x873e775b892867cf)
	{
		x02399a46a1120a24.xab3af626b1405ee8(x873e775b892867cf);
	}

	public int xc9b7340b035562c6(object x1bd44401d685915c, int x81d973eeafae2be3)
	{
		object obj = x99f65b40d6ed2d43[x1bd44401d685915c];
		if (obj == null)
		{
			return x81d973eeafae2be3;
		}
		return (int)obj;
	}

	public void x214a3d715a732d1d(object x1bd44401d685915c, int xddd12ddd8b1e4a90)
	{
		x99f65b40d6ed2d43[x1bd44401d685915c] = xddd12ddd8b1e4a90;
	}

	internal void xe2b98ec01d764f22(int xeaf1b27180c0557b, string xadeabb31ca5e0088)
	{
		x76209fd493f96946[xeaf1b27180c0557b] = xadeabb31ca5e0088;
	}

	internal string x16b059bd238cdf9d(int xeaf1b27180c0557b)
	{
		object obj = x76209fd493f96946[xeaf1b27180c0557b];
		if (obj == null)
		{
			return "";
		}
		return (string)obj;
	}

	internal int xe5e92784f3f9ed17()
	{
		int xad3f7e139bf1b10a = xa3a0cc3e91617aca.xffb3238a8fd59aa7.xad3f7e139bf1b10a;
		if (xad3f7e139bf1b10a == -1)
		{
			return x1ea60bde2b5d0d28.xf6968566e57d2798;
		}
		int x1370e69f = x1cb20e5365d954a7.x17e389ec6532245f(xad3f7e139bf1b10a);
		return xe4b3641e8e4ef359.x7e0944f4a3af6926(x1370e69f, x1ea60bde2b5d0d28.xf6968566e57d2798);
	}
}
