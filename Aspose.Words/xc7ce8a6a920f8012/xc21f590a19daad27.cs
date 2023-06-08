using System;
using System.Collections;
using System.Drawing;
using System.Text;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class xc21f590a19daad27 : x0096796e2eb81db6
{
	private Hashtable xadc1b9de040e1748 = new Hashtable();

	private Hashtable xc72ddcbcaca479e2 = new Hashtable();

	private Hashtable x1e8b6a441b5d8b9a = new Hashtable();

	private ArrayList x0723a61e89e53dc1 = new ArrayList();

	private Hashtable x4bf8aed831f2591e = new Hashtable();

	private Hashtable xfa8cb242cbfc862c = new Hashtable();

	private short x7f5cf3a9f3176d0c;

	private int xf5dc3fa40a40ad11;

	private int x73bb25d25ff65ad3;

	public short xc557154492011522 => x7f5cf3a9f3176d0c;

	public int x3114e27f80122981 => xf5dc3fa40a40ad11;

	public int x995a78d99ada0d0c => x73bb25d25ff65ad3;

	public Hashtable x1345d104bcfaae69 => xfa8cb242cbfc862c;

	public xc21f590a19daad27(x34b34bf589d8ec1e context, short pageSpriteId, SizeF pageSize)
		: base(context)
	{
		x7f5cf3a9f3176d0c = pageSpriteId;
		xf5dc3fa40a40ad11 = x4574ea26106f0edb.x88bf16f2386d633e(pageSize.Width);
		x73bb25d25ff65ad3 = x4574ea26106f0edb.x88bf16f2386d633e(pageSize.Height);
	}

	public void x6210059f049f0d48(int xbf13a47a02af0066, bool x2d4c735f4e46f7c0)
	{
		x5d2a005e0aeac7cc x5d2a005e0aeac7cc2 = new x5d2a005e0aeac7cc(base.x28fcdc775a1d069c);
		foreach (x6b1a899052c71a60 item in x0723a61e89e53dc1)
		{
			x5d2a005e0aeac7cc2.x31eb6524f38f9495(item);
		}
		x065ad32e076bfe5a x065ad32e076bfe5a2 = new x065ad32e076bfe5a(base.x28fcdc775a1d069c);
		foreach (DictionaryEntry item2 in x4bf8aed831f2591e)
		{
			x065ad32e076bfe5a2.x1ead1e22b3b46f61((byte[])item2.Value, (short)item2.Key);
		}
		x3e7987c9d0c27db0 x3e7987c9d0c27db = new x3e7987c9d0c27db0(base.x28fcdc775a1d069c);
		foreach (DictionaryEntry item3 in xadc1b9de040e1748)
		{
			x3e7987c9d0c27db.xd2adeaddbd02b4c6((xcc8c7739d82c63ba)item3.Value, (short)item3.Key);
		}
		xbd0c817e0e93d2d9 xbd0c817e0e93d2d10 = new xbd0c817e0e93d2d9(base.x28fcdc775a1d069c);
		foreach (DictionaryEntry item4 in xc72ddcbcaca479e2)
		{
			xbd0c817e0e93d2d10.x384c762bf873d79f((xab391c46ff9a0a38)item4.Value, (short)item4.Key);
		}
		foreach (DictionaryEntry item5 in x1e8b6a441b5d8b9a)
		{
			xfaa0b71704009335 xfaa0b717040093352 = (xfaa0b71704009335)item5.Value;
			xfaa0b717040093352.x6210059f049f0d48();
		}
		string text = $"page{xbf13a47a02af0066:D9}";
		if (x2d4c735f4e46f7c0)
		{
			x1e8016adf195d09b(text, x7f5cf3a9f3176d0c);
		}
		else
		{
			x36ed93bceea22bd2 x5b94cc2d11c = new x36ed93bceea22bd2(x7f5cf3a9f3176d0c, null, (short)xbf13a47a02af0066, text);
			xa8cbe6d157a3b60f xa8cbe6d157a3b60f2 = new xa8cbe6d157a3b60f(base.x28fcdc775a1d069c);
			xa8cbe6d157a3b60f2.x23deaf2a36abf030(x5b94cc2d11c);
		}
		base.x5aa326f374b3d0ef.x4eadf767e5f91a38(xf066f1f57515a14c.xcb09e66e779b210e, 0);
	}

	public short x2037c969f8f81f97(xcc8c7739d82c63ba x199c511544621683)
	{
		x6b1a899052c71a60 x29f65b3e7616f6b = x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3;
		if (!base.x28fcdc775a1d069c.x90d89bab6f61ec78(x29f65b3e7616f6b))
		{
			x0723a61e89e53dc1.Add(x29f65b3e7616f6b);
		}
		x6ba9063ea0f44561 x6ba9063ea0f44562 = base.x28fcdc775a1d069c.x5fa376febd884803(x29f65b3e7616f6b);
		x6ba9063ea0f44562.x27872d02dfb99793(x199c511544621683.Text);
		short num = base.x28fcdc775a1d069c.xa315ee2085b502cf();
		xadc1b9de040e1748.Add(num, x199c511544621683);
		return num;
	}

	public short x9f280d9f6d9d4ccb(xab391c46ff9a0a38 xe125219852864557)
	{
		short num = base.x28fcdc775a1d069c.xa315ee2085b502cf();
		xc72ddcbcaca479e2.Add(num, xe125219852864557);
		if (xe125219852864557.x60465f602599d327 != null)
		{
			xb48cbf541b9cc86b(xe125219852864557.x60465f602599d327);
		}
		if (xe125219852864557.x9e5d5f9128c69a8f != null && xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327 != null)
		{
			xb48cbf541b9cc86b(xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327);
		}
		return num;
	}

	private void xb48cbf541b9cc86b(x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		switch (xd8f1949f8950238a.x4bc21f84846f912d)
		{
		case x0b257a9fb413b6c3.x7b6a6d281546db99:
			xa9557f69810d0afe(((x5e9754e56a4f759f)xd8f1949f8950238a).xcc18177a965e0313);
			break;
		case x0b257a9fb413b6c3.x1b1f1b9a5f55b7ee:
			xa9557f69810d0afe(x973c394bd6a899a2.xb19c72971505e3ca((x5bdb4ba66c23277c)xd8f1949f8950238a));
			break;
		}
	}

	public void xa9557f69810d0afe(byte[] x43e181e083db6cdf)
	{
		if (!base.x28fcdc775a1d069c.xcacc5caa945df72d(x43e181e083db6cdf))
		{
			short num = base.x28fcdc775a1d069c.xf41382d350a87348(x43e181e083db6cdf);
			x8b653c16f41cf04f x8b653c16f41cf04f2 = new x8b653c16f41cf04f(base.x28fcdc775a1d069c.x73979cef1002ed01.xf7575b7b1ee35d49, base.x28fcdc775a1d069c.x73979cef1002ed01.x4d2cf6c77ee521cd(), x3959df40367ac8a3.xffe454f29a855c10);
			x43e181e083db6cdf = x8b653c16f41cf04f2.x601e9a2243ca6720(x43e181e083db6cdf);
			x4bf8aed831f2591e[num] = x43e181e083db6cdf;
		}
	}

	public void x12acf473349bbd57(xfaa0b71704009335 xc68d1afbafbe71be)
	{
		x1e8b6a441b5d8b9a.Add(xc68d1afbafbe71be.xde89252455da1b3c, xc68d1afbafbe71be);
	}

	public void x3ca3595aa1a88d4b(short xbe4a60d4d01e2087, xa702b771604efc86 xe0abc8f59346647b)
	{
		xfa8cb242cbfc862c[xbe4a60d4d01e2087] = xe0abc8f59346647b;
	}

	private void x1e8016adf195d09b(string x923ba5384d68e3d8, short x72571efac13fdbff)
	{
		xb4e6bcae51300e9c xb4e6bcae51300e9c2 = new xb4e6bcae51300e9c(base.x28fcdc775a1d069c);
		xb4e6bcae51300e9c2.xacf4b9ddf32bef06();
		base.x5aa326f374b3d0ef.x6ff7c65ed4805c27(1);
		base.x5aa326f374b3d0ef.xf2c2dbac0bb24ba0(x923ba5384d68e3d8);
		string text = Convert.ToBase64String(xac4ff1047b721aff.x25c0263bd07a71a1);
		string text2 = Convert.ToBase64String(Encoding.UTF8.GetBytes("TemplatePages"));
		string text3 = Convert.ToBase64String(Encoding.UTF8.GetBytes(x923ba5384d68e3d8));
		text = text.Replace(text2.Substring(0, text2.Length - 2), text3.Substring(0, text3.Length - 2));
		base.x5aa326f374b3d0ef.x4c116b70372a3c6d(Convert.FromBase64String(text));
		xb4e6bcae51300e9c2.xc463dec5a3ab6e2d(xf066f1f57515a14c.x650d6c3eb9ebd398);
		xb4e6bcae51300e9c2.xacf4b9ddf32bef06();
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(1);
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(x72571efac13fdbff);
		base.x5aa326f374b3d0ef.xf2c2dbac0bb24ba0(x923ba5384d68e3d8);
		xb4e6bcae51300e9c2.xc463dec5a3ab6e2d(xf066f1f57515a14c.x5ce205a253094b03);
	}
}
