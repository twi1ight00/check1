using System;
using System.Collections;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class xe21bbe9dfab6c4dd
{
	private readonly x4882ae789be6e2ef x8cedcaa9a62c6e39;

	private readonly SortedList x0723a61e89e53dc1 = new xd345c73dd1b16b74();

	private readonly SortedList xfbe83c8636791ce1 = new xd345c73dd1b16b74();

	private readonly SortedList xa0d193df0c3b5bfc = new xd345c73dd1b16b74();

	private readonly SortedList x893797d52fc099fa = new SortedList();

	private readonly SortedList x495c4d957e3927b4 = new xd345c73dd1b16b74();

	private static readonly Hashtable x3979a28745f852cc;

	private static readonly string[] xcea12c3d7ea99013;

	internal xe21bbe9dfab6c4dd(x4882ae789be6e2ef context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal int x7029e474053b751e(x3499f937de5622bc x43163d22e8cd5a71)
	{
		return x067ce2229b5f9880(x43163d22e8cd5a71).Count;
	}

	internal xba2f911354958a68 xdc2247c8d4648ae8(string xba08ce632055a1d9)
	{
		return (xba2f911354958a68)x0723a61e89e53dc1[xba08ce632055a1d9];
	}

	internal xba2f911354958a68 xc81af5eb660ec310(xe39d06eee35dd23d x26094932cf7a9139)
	{
		return x9059a3203c8fc855(x26094932cf7a9139, null);
	}

	internal xba2f911354958a68 x9059a3203c8fc855(xe39d06eee35dd23d x26094932cf7a9139, string xb41faee6912a2313)
	{
		x01181e685b9364da xdfde339da46db = xb27d5c9a2e96bea2(x26094932cf7a9139.x29f65b3e7616f6b3, xb41faee6912a2313);
		string key = x80e7ae9fee26a332(x26094932cf7a9139, xdfde339da46db);
		xba2f911354958a68 xba2f911354958a69 = (xba2f911354958a68)x0723a61e89e53dc1[key];
		if (xba2f911354958a69 == null)
		{
			xba2f911354958a69 = x591851da5cac8490(x26094932cf7a9139, xdfde339da46db);
			x0723a61e89e53dc1[key] = xba2f911354958a69;
		}
		return xba2f911354958a69;
	}

	private x01181e685b9364da xb27d5c9a2e96bea2(x6b1a899052c71a60 x26094932cf7a9139, string xb41faee6912a2313)
	{
		xe46bb6746ed49193 fontType;
		bool isFontDataEmbedded;
		if (x26094932cf7a9139.xba2310b1d8e576ad)
		{
			fontType = xe46bb6746ed49193.x477b07c00da59873;
			isFontDataEmbedded = true;
		}
		else if (x26094932cf7a9139.xadc83cc585a89881)
		{
			if (x8cedcaa9a62c6e39.x73979cef1002ed01.x71274a3323f4303d && x00ecacea06b9b181.xe28de3e3c9d9d2f4(x26094932cf7a9139))
			{
				fontType = xe46bb6746ed49193.x26aa02ced06dcaa8;
				isFontDataEmbedded = false;
			}
			else
			{
				fontType = xe46bb6746ed49193.x477b07c00da59873;
				isFontDataEmbedded = true;
			}
		}
		else if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313) && x7819ee089c842c62.xc15c34808d3f62ec(xb41faee6912a2313))
		{
			if (x8cedcaa9a62c6e39.x73979cef1002ed01.x71274a3323f4303d && x00ecacea06b9b181.xe28de3e3c9d9d2f4(x26094932cf7a9139))
			{
				fontType = xe46bb6746ed49193.x26aa02ced06dcaa8;
				isFontDataEmbedded = false;
			}
			else if (!x8cedcaa9a62c6e39.x73979cef1002ed01.xd2c8b9d8784ba23d && xfdbdf3ca90de99ad(x26094932cf7a9139))
			{
				fontType = xe46bb6746ed49193.x4ebce33c03ddbf4b;
				isFontDataEmbedded = false;
			}
			else
			{
				fontType = xe46bb6746ed49193.x4ebce33c03ddbf4b;
				isFontDataEmbedded = true;
			}
		}
		else
		{
			fontType = xe46bb6746ed49193.x477b07c00da59873;
			isFontDataEmbedded = true;
		}
		return new x01181e685b9364da(fontType, isFontDataEmbedded);
	}

	private static bool xfdbdf3ca90de99ad(x6b1a899052c71a60 x26094932cf7a9139)
	{
		string[] array = xcea12c3d7ea99013;
		foreach (string text in array)
		{
			if (x26094932cf7a9139.x6054c4379c01a50d == text)
			{
				return true;
			}
		}
		return false;
	}

	private static string x80e7ae9fee26a332(xe39d06eee35dd23d x26094932cf7a9139, x01181e685b9364da xdfde339da46db651)
	{
		return $"{x26094932cf7a9139.x29f65b3e7616f6b3.x6054c4379c01a50d}-{(int)x26094932cf7a9139.xfe2178c1f916f36c}-{(int)x26094932cf7a9139.x29f65b3e7616f6b3.xfe2178c1f916f36c}-{(int)xdfde339da46db651.x24c0b95ca4903845}";
	}

	private xba2f911354958a68 x591851da5cac8490(xe39d06eee35dd23d x26094932cf7a9139, x01181e685b9364da xdfde339da46db651)
	{
		xcb3d00e64f2216e5 xcb3d00e64f2216e6 = (xdfde339da46db651.xcdf9181a9832a88b ? x8523e6f3984c047f(x26094932cf7a9139.x29f65b3e7616f6b3) : new xc26f034be79053b7(x26094932cf7a9139.x29f65b3e7616f6b3));
		return xdfde339da46db651.x24c0b95ca4903845 switch
		{
			xe46bb6746ed49193.x477b07c00da59873 => new x0c228b6673bb03aa(x8cedcaa9a62c6e39, x26094932cf7a9139.xfe2178c1f916f36c, (xd99feecae3b0ba7a)xcb3d00e64f2216e6), 
			xe46bb6746ed49193.x4ebce33c03ddbf4b => new xef517e98648f82e3(x8cedcaa9a62c6e39, x26094932cf7a9139.xfe2178c1f916f36c, xcb3d00e64f2216e6), 
			xe46bb6746ed49193.x26aa02ced06dcaa8 => new x00ecacea06b9b181(x8cedcaa9a62c6e39, x26094932cf7a9139.xfe2178c1f916f36c, xcb3d00e64f2216e6, x00ecacea06b9b181.x050b26a5b6e831ac(x26094932cf7a9139.x29f65b3e7616f6b3)), 
			_ => throw new InvalidOperationException("Unexpected font type."), 
		};
	}

	private xcb3d00e64f2216e5 x8523e6f3984c047f(x6b1a899052c71a60 x26094932cf7a9139)
	{
		string key = x70ca813ebb64329b(x26094932cf7a9139);
		xd99feecae3b0ba7a xd99feecae3b0ba7a2 = (xd99feecae3b0ba7a)x495c4d957e3927b4[key];
		if (xd99feecae3b0ba7a2 == null)
		{
			xd99feecae3b0ba7a2 = new xd99feecae3b0ba7a(x26094932cf7a9139, x8cedcaa9a62c6e39);
			x495c4d957e3927b4.Add(key, xd99feecae3b0ba7a2);
		}
		return xd99feecae3b0ba7a2;
	}

	private static string x70ca813ebb64329b(x6b1a899052c71a60 x26094932cf7a9139)
	{
		return $"{x26094932cf7a9139.x6054c4379c01a50d}-{(int)x26094932cf7a9139.xfe2178c1f916f36c}";
	}

	internal x02cd5c9c8d54330e xf7268a8a4e82d147(x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		x02cd5c9c8d54330e x02cd5c9c8d54330e2 = x02cd5c9c8d54330e.xa934c26af07952ed(xd8f1949f8950238a, x8cedcaa9a62c6e39);
		if (x02cd5c9c8d54330e2 == null)
		{
			return null;
		}
		int num = xfbe83c8636791ce1.IndexOfValue(x02cd5c9c8d54330e2);
		if (num != -1)
		{
			x8cedcaa9a62c6e39.x4e4dab3a2d164159();
			return (x02cd5c9c8d54330e)xfbe83c8636791ce1.GetByIndex(num);
		}
		xfbe83c8636791ce1[x02cd5c9c8d54330e2.xd160355ae2167ae9] = x02cd5c9c8d54330e2;
		return x02cd5c9c8d54330e2;
	}

	internal xab3c72a18f0329ac x6d1483ac033919d3()
	{
		xab3c72a18f0329ac xab3c72a18f0329ac2 = new xab3c72a18f0329ac(x8cedcaa9a62c6e39);
		xa0d193df0c3b5bfc[xab3c72a18f0329ac2.xd160355ae2167ae9] = xab3c72a18f0329ac2;
		return xab3c72a18f0329ac2;
	}

	internal x9c3b5a148fe3d694 x94682a775258c6c8(byte[] x43e181e083db6cdf, x02df97c06afacbf3 x5edc4e0499c937b4, xf276f6a75b584d31 xe4eb37da4d22423c)
	{
		int num = x02df97c06afacbf3.x1c3a4a07dc224a14(x43e181e083db6cdf, x5edc4e0499c937b4, xe4eb37da4d22423c);
		x9c3b5a148fe3d694 x9c3b5a148fe3d695 = (x9c3b5a148fe3d694)x893797d52fc099fa[num];
		if (x9c3b5a148fe3d695 == null)
		{
			x9c3b5a148fe3d695 = new x9c3b5a148fe3d694(x8cedcaa9a62c6e39, x43e181e083db6cdf, x5edc4e0499c937b4, xe4eb37da4d22423c);
			x893797d52fc099fa[num] = x9c3b5a148fe3d695;
		}
		return x9c3b5a148fe3d695;
	}

	internal void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xa4dc0ad8886e23a2(x3499f937de5622bc.xc2d4efc42998d87b, xbdfb620b7167944b);
		xa4dc0ad8886e23a2(x3499f937de5622bc.xd265a220a45d3124, xbdfb620b7167944b);
		xa4dc0ad8886e23a2(x3499f937de5622bc.xf70cb55d58c64a9c, xbdfb620b7167944b);
		xa4dc0ad8886e23a2(x3499f937de5622bc.xbdabc9cb8ec34c83, xbdfb620b7167944b);
	}

	internal void x17c56662e4294017(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		x79442125d578605f(x0723a61e89e53dc1, xbdfb620b7167944b);
		x79442125d578605f(xfbe83c8636791ce1, xbdfb620b7167944b);
		x79442125d578605f(xa0d193df0c3b5bfc, xbdfb620b7167944b);
		x79442125d578605f(x893797d52fc099fa, xbdfb620b7167944b);
		xf1a3a3915069b1e3(xbdfb620b7167944b);
	}

	private void xf1a3a3915069b1e3(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		foreach (xd99feecae3b0ba7a value in x495c4d957e3927b4.GetValueList())
		{
			value.xe8b46cb1a427b4f6.WriteToPdf(xbdfb620b7167944b);
		}
	}

	private void xa4dc0ad8886e23a2(x3499f937de5622bc x43163d22e8cd5a71, x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		SortedList sortedList = x067ce2229b5f9880(x43163d22e8cd5a71);
		if (sortedList.Count == 0)
		{
			return;
		}
		xbdfb620b7167944b.x6210059f049f0d48("/{0}", x7bd37868e614cb96(x43163d22e8cd5a71));
		xbdfb620b7167944b.xafb7e6f79ed43681();
		foreach (object value in sortedList.GetValueList())
		{
			x264ba3b7aca691be x264ba3b7aca691be2 = (x264ba3b7aca691be)value;
			xbdfb620b7167944b.xa4dc0ad8886e23a2($"/{x264ba3b7aca691be2.xd160355ae2167ae9}", x264ba3b7aca691be2.x899a2110a8a35fda);
		}
		xbdfb620b7167944b.x693a8d6d020474f2();
	}

	private static void x79442125d578605f(SortedList x3733a99ccc7ac0a3, x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		if (x3733a99ccc7ac0a3.Count == 0)
		{
			return;
		}
		foreach (object value in x3733a99ccc7ac0a3.GetValueList())
		{
			x264ba3b7aca691be x264ba3b7aca691be2 = (x264ba3b7aca691be)value;
			x264ba3b7aca691be2.WriteToPdf(xbdfb620b7167944b);
		}
	}

	internal static string x7bd37868e614cb96(x3499f937de5622bc x43163d22e8cd5a71)
	{
		return ((xaa4ae7b457562f4a)x3979a28745f852cc[x43163d22e8cd5a71]).x759aa16c2016a289;
	}

	internal static string x096d740b861b7ce8(x3499f937de5622bc x43163d22e8cd5a71)
	{
		return ((xaa4ae7b457562f4a)x3979a28745f852cc[x43163d22e8cd5a71]).xa35d4959e20888cf;
	}

	private SortedList x067ce2229b5f9880(x3499f937de5622bc x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			x3499f937de5622bc.xc2d4efc42998d87b => x0723a61e89e53dc1, 
			x3499f937de5622bc.xd265a220a45d3124 => xfbe83c8636791ce1, 
			x3499f937de5622bc.xf70cb55d58c64a9c => xa0d193df0c3b5bfc, 
			x3499f937de5622bc.xbdabc9cb8ec34c83 => x893797d52fc099fa, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ncppdegandnandebldlbaeccedjcdopccdhdccodncfegcmejcdfdckfbbbgabigimogjbghlbnhpaeibalihmbj", 1321008856))), 
		};
	}

	static xe21bbe9dfab6c4dd()
	{
		x3979a28745f852cc = new Hashtable();
		xcea12c3d7ea99013 = new string[2] { "Arial", "Times New Roman" };
		x3979a28745f852cc.Add(x3499f937de5622bc.xc2d4efc42998d87b, new xaa4ae7b457562f4a("Font", "F"));
		x3979a28745f852cc.Add(x3499f937de5622bc.xd265a220a45d3124, new xaa4ae7b457562f4a("Pattern", "P"));
		x3979a28745f852cc.Add(x3499f937de5622bc.xf70cb55d58c64a9c, new xaa4ae7b457562f4a("ExtGState", "GS"));
		x3979a28745f852cc.Add(x3499f937de5622bc.xbdabc9cb8ec34c83, new xaa4ae7b457562f4a("XObject", "X"));
	}
}
