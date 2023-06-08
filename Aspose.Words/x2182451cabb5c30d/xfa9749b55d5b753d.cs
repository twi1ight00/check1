using System;
using Aspose.Words;
using Aspose.Words.Math;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;
using xe5b37aee2c2a4d4e;
using xf9a9481c3f63a419;

namespace x2182451cabb5c30d;

internal class xfa9749b55d5b753d : x3b57052406b93b82, x59a1e7b7667e1e09
{
	private readonly x8ee18b8f4295c535 x41df766edde5529a;

	private int x7d938a2a2e9e2398;

	private x9d761ee3eb0e5b6d xa733a3e012670689;

	private x25099a8bbbd55d1c x0c644a47f9e5a7c2 => x28fcdc775a1d069c.xa3a0cc3e91617aca.xffb3238a8fd59aa7.x1a55de3a01c1c82d.x3146d638ec378671;

	private x52642f91ccdeeb35 x52642f91ccdeeb35
	{
		get
		{
			if (!(base.xe1410f585439c7d4.xc255c495fd9232ca is OfficeMath))
			{
				return null;
			}
			return ((OfficeMath)base.xe1410f585439c7d4.xc255c495fd9232ca).x52642f91ccdeeb35;
		}
	}

	public xeedad81aaed42a76 xeedad81aaed42a76
	{
		get
		{
			xeedad81aaed42a76 result = new xeedad81aaed42a76();
			if (base.xe1410f585439c7d4.xc255c495fd9232ca is OfficeMath)
			{
				result = ((OfficeMath)base.xe1410f585439c7d4.xc255c495fd9232ca).xeedad81aaed42a76;
			}
			return result;
		}
	}

	public x1a78664fa10a3755 x1a78664fa10a3755 => new x1a78664fa10a3755();

	internal xfa9749b55d5b753d(xe5e546ef5f0503b2 context)
		: base(context)
	{
		x41df766edde5529a = new x8ee18b8f4295c535(context, this);
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x25099a8bbbd55d1c2 = x0c644a47f9e5a7c2;
		if (x25099a8bbbd55d1c2 == x25099a8bbbd55d1c.xe78fc66270b1dc33)
		{
			x7d938a2a2e9e2398 = 1;
			xa733a3e012670689 = new x9d761ee3eb0e5b6d();
		}
		else
		{
			base.x41e7a76e7e854e6e(x153c99a852375422);
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.xd7655a10a0e3a579:
		{
			foreach (Node childNode in base.xe1410f585439c7d4.xc255c495fd9232ca.ChildNodes)
			{
				if (childNode is Run run)
				{
					run.xeedad81aaed42a76.x51cf23ce6e71b84c = base.x2c8c6741422a1298.xdade2366eaa6f915.x1c605672f036e9e1.xddffcb24e864cfcc;
					run.xeedad81aaed42a76.xd08cbc518cf39317 = base.x2c8c6741422a1298.xdade2366eaa6f915.x1c605672f036e9e1.xddffcb24e864cfcc;
				}
			}
			break;
		}
		case x25099a8bbbd55d1c.xe78fc66270b1dc33:
		{
			xa097a2be55e6fe20 xa097a2be55e6fe = (xa097a2be55e6fe20)x52642f91ccdeeb35;
			xa097a2be55e6fe.xe9e7cd52b91094f9.xd6b6ed77479ef68c(xa733a3e012670689, x7d938a2a2e9e2398);
			break;
		}
		default:
			base.xa4085ff83f9ddeeb();
			break;
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\mjc":
			if (x52642f91ccdeeb35 is x25cf79997767c318 x25cf79997767c)
			{
				x25cf79997767c.x3b35c3f6e109fb3e = (x2cdbcd6273a149f1)x153c99a852375422.xd6f9e3c5ae6509d7();
			}
			break;
		case "\\maln":
			if (x52642f91ccdeeb35 is xf338a8521eba3175 xf338a8521eba)
			{
				xf338a8521eba.x0c7cf16220cbe742 = true;
			}
			break;
		default:
			if (x0c644a47f9e5a7c2 == x25099a8bbbd55d1c.xc468fe28554f1d3c)
			{
				x41df766edde5529a.x06b0e25aa6ad68a9(x153c99a852375422);
			}
			else
			{
				base.xa2d8e36cb99ac0f4(x153c99a852375422);
			}
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		if (x25099a8bbbd55d1c.xf150ff11fc3cf8c4 < x8d3f74e5f925679c.x3146d638ec378671 && x8d3f74e5f925679c.x3146d638ec378671 < x25099a8bbbd55d1c.x9daa3732b871f326)
		{
			return this;
		}
		return base.x3e0bce851c12a688(x8d3f74e5f925679c);
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x890a027c82a36a95:
			xaae20adb212185a8((x77c73b53c376655e)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xa57bed60117d2558:
		case x25099a8bbbd55d1c.xd2255147bfba174e:
		case x25099a8bbbd55d1c.x150f15c3ac9da530:
		case x25099a8bbbd55d1c.x7d2800a12dad81e7:
		case x25099a8bbbd55d1c.x5700a9c3e9752993:
			x4145dd1be0886eeb((x2a5175731d41f1b1)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x6546d7e9e65b95ad:
		case x25099a8bbbd55d1c.x683882291a35d26e:
		case x25099a8bbbd55d1c.xd223e9c236b1492a:
		case x25099a8bbbd55d1c.x352d7f58434ee788:
		case x25099a8bbbd55d1c.x36984651b78e6e56:
		case x25099a8bbbd55d1c.x5217131bb616d2f7:
		case x25099a8bbbd55d1c.x24440e1c06bf22b3:
		case x25099a8bbbd55d1c.xa5c6da56f9ce8298:
			x4c439efca67566da((xfef3245bedba6f2c)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xfba57c13beea1b4c:
		case x25099a8bbbd55d1c.xefb32da23881960f:
		case x25099a8bbbd55d1c.x68ee951d744eb7f4:
			x037e4c97650bfd74((xf338a8521eba3175)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x1c74d6e47abfcc56:
		case x25099a8bbbd55d1c.xcf69ddc8f0faf959:
		case x25099a8bbbd55d1c.x0bdd2bcbd319cd58:
			x1251ffbdb0de649d((x6dd1552d6eb89e4e)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x4962e604bcaad17c:
			xc5b19fa3c63d2415(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xb24389a82e3f3917:
			x8d4d3b3c12339b84(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x34f88c58c9554578:
		case x25099a8bbbd55d1c.xb0c39e4ef1f26113:
			x9679836f266f419e((xad19b25167c52eb8)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xa0c58af19f6dd708:
		case x25099a8bbbd55d1c.x0649bca0700581fa:
			x18c047e64b3cb02b(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xb474f98b96852a6e:
			x6412f994a1600a41(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xdef8679bf1aad53e:
		case x25099a8bbbd55d1c.xe0506156c74e3c3f:
		case x25099a8bbbd55d1c.x85a64b7d1cbf96d2:
		case x25099a8bbbd55d1c.x1bd53062069ae87b:
			x082318eaebfce7cc((x8f75f1da124d37a8)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x00a1a650c8398e0b:
		case x25099a8bbbd55d1c.xa83c84c286aaca9d:
		case x25099a8bbbd55d1c.x4f0a44ed6e61058f:
		case x25099a8bbbd55d1c.x31673ebc6fd23429:
			xe303ed84d73d63d2((xa097a2be55e6fe20)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xf1bcd6a55d54328d:
			x5948307e9b1e86a9((xe0ab87872ac16292)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xce8b2ce767b2485c:
			xad70e80c53534ff5(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x9437baf3292ccaf4:
			x423d5743d65589e6((x099cae110a815841)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x722b8a029c4311c2:
			xf33dadb07829eeb6((xfd62ce7f2b6769d5)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x00a450f80cdca252:
		case x25099a8bbbd55d1c.x009c399d2f14e2a1:
			x772c1e686b7a43d1(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x488a5f49abd86bb8:
			x3357808157f83a41(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x6efe0dc00696056d:
			x6b1bb96b35bbde01(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x52c2b3ecc2ef186d:
			xc72a8acb971a82d6((xb4dde217cd172a7b)x52642f91ccdeeb35, x153c99a852375422);
			break;
		default:
			base.xbd6083b329527c4e(x153c99a852375422);
			break;
		}
	}

	private static bool x3f2cb3ba0f144136(x03f56b37a0050a82 x153c99a852375422)
	{
		return x153c99a852375422.x9f1a6a3451a38d10() == "on";
	}

	private static char x4e84fee22992fd26(x03f56b37a0050a82 x153c99a852375422)
	{
		string text = x153c99a852375422.x9f1a6a3451a38d10();
		if (text.Length <= 0)
		{
			return '\0';
		}
		return text[0];
	}

	private static int x72189516320b0dea(x03f56b37a0050a82 x153c99a852375422)
	{
		return xca004f56614e2431.x912616ee70b2d94d(x153c99a852375422.x9f1a6a3451a38d10());
	}

	private void x4145dd1be0886eeb(x2a5175731d41f1b1 x9c744cfd18267b8f, x03f56b37a0050a82 x153c99a852375422)
	{
		bool flag = x3f2cb3ba0f144136(x153c99a852375422);
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.xa57bed60117d2558:
			x9c744cfd18267b8f.x6f068d44e0e83706 = flag;
			break;
		case x25099a8bbbd55d1c.xd2255147bfba174e:
			x9c744cfd18267b8f.x009cb1da90c5afd0 = flag;
			break;
		case x25099a8bbbd55d1c.x150f15c3ac9da530:
			x9c744cfd18267b8f.xb0e0759ff352b2e5 = flag;
			break;
		case x25099a8bbbd55d1c.x7d2800a12dad81e7:
			x9c744cfd18267b8f.x1c938670e5e4b483 = flag;
			break;
		case x25099a8bbbd55d1c.x5700a9c3e9752993:
			x9c744cfd18267b8f.x4dc21387c15e58e7 = flag;
			break;
		}
	}

	private void xaae20adb212185a8(x77c73b53c376655e x27b336b929c0851c, x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x25099a8bbbd55d1c2 = x0c644a47f9e5a7c2;
		if (x25099a8bbbd55d1c2 == x25099a8bbbd55d1c.x890a027c82a36a95)
		{
			x27b336b929c0851c.x4001c46e1a6e7522 = xc62574be95c1c918.xabd3359cac621e01(x153c99a852375422.x9f1a6a3451a38d10());
		}
	}

	private void x3357808157f83a41(x03f56b37a0050a82 x153c99a852375422)
	{
		x3e68720d12325f49 x3e68720d12325f = x52642f91ccdeeb35.x3e68720d12325f49;
		if (x3e68720d12325f == x3e68720d12325f49.x2ae4473a93ca9b64)
		{
			x037e4c97650bfd74((xf338a8521eba3175)x52642f91ccdeeb35, x153c99a852375422);
			return;
		}
		if (x28fcdc775a1d069c.xa3a0cc3e91617aca.xcfc42ef22e03d2ce.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xd7655a10a0e3a579)
		{
			x6b1bb96b35bbde01(x153c99a852375422);
			return;
		}
		throw new InvalidOperationException("Unexpected MathObject type for MathLineBreak.");
	}

	private void x6b1bb96b35bbde01(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x28fcdc775a1d069c.xa3a0cc3e91617aca.xcfc42ef22e03d2ce.x1a55de3a01c1c82d.x3146d638ec378671 != x25099a8bbbd55d1c.xd7655a10a0e3a579)
		{
			throw new InvalidOperationException("Unexpected token for MathRunProperty.");
		}
		x41df766edde5529a.x06b0e25aa6ad68a9(x153c99a852375422);
	}

	private void x037e4c97650bfd74(xf338a8521eba3175 xbbb567823982f390, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.xfba57c13beea1b4c:
			xbbb567823982f390.xdc802487ace35154 = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xefb32da23881960f:
			xbbb567823982f390.xbb2ffb58311526cb = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x68ee951d744eb7f4:
			xbbb567823982f390.x3b01b9ee79bdfdf1 = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x488a5f49abd86bb8:
		{
			x488a5f49abd86bb8 x488a5f49abd86bb = new x488a5f49abd86bb8();
			x488a5f49abd86bb.x9ba359ff37a3a63b = x72189516320b0dea(x153c99a852375422);
			xbbb567823982f390.xc6ff30169310daba = x488a5f49abd86bb;
			break;
		}
		}
	}

	private void x423d5743d65589e6(x099cae110a815841 x091aa39e17062971, x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x25099a8bbbd55d1c2 = x0c644a47f9e5a7c2;
		if (x25099a8bbbd55d1c2 == x25099a8bbbd55d1c.x9437baf3292ccaf4)
		{
			x091aa39e17062971.xf9b3d1f631a6acf7 = x3f2cb3ba0f144136(x153c99a852375422);
		}
	}

	private void x4c439efca67566da(xfef3245bedba6f2c x06b4849f65f5a9e4, x03f56b37a0050a82 x153c99a852375422)
	{
		bool flag = x3f2cb3ba0f144136(x153c99a852375422);
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.x6546d7e9e65b95ad:
			x06b4849f65f5a9e4.x795d756c45cddeec = flag;
			break;
		case x25099a8bbbd55d1c.x683882291a35d26e:
			x06b4849f65f5a9e4.x224b187f1627f61c = flag;
			break;
		case x25099a8bbbd55d1c.xd223e9c236b1492a:
			x06b4849f65f5a9e4.x0d399e53ae7a180a = flag;
			break;
		case x25099a8bbbd55d1c.x352d7f58434ee788:
			x06b4849f65f5a9e4.x1d72c9e455edb0c1 = flag;
			break;
		case x25099a8bbbd55d1c.x36984651b78e6e56:
			x06b4849f65f5a9e4.xb6be2923de366a38 = flag;
			break;
		case x25099a8bbbd55d1c.x5217131bb616d2f7:
			x06b4849f65f5a9e4.xe14c67c2d42b0d99 = flag;
			break;
		case x25099a8bbbd55d1c.x24440e1c06bf22b3:
			x06b4849f65f5a9e4.xde23098f9048aad1 = flag;
			break;
		case x25099a8bbbd55d1c.xa5c6da56f9ce8298:
			x06b4849f65f5a9e4.x21086958d43019dd = flag;
			break;
		}
	}

	private void x1251ffbdb0de649d(x6dd1552d6eb89e4e x168070fa1ef31d59, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.xb24389a82e3f3917:
			x168070fa1ef31d59.xe316f972e75b51de = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x1c74d6e47abfcc56:
			x168070fa1ef31d59.xe3e2b72900be18d6 = xc62574be95c1c918.xbc8913cc2c4a85ed(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		case x25099a8bbbd55d1c.xcf69ddc8f0faf959:
			x168070fa1ef31d59.x42d0b8bb3dc018f1 = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x0bdd2bcbd319cd58:
			x168070fa1ef31d59.x6e65f77ea9696a75 = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x4962e604bcaad17c:
			x168070fa1ef31d59.x067d56aec20cdd99 = x4e84fee22992fd26(x153c99a852375422);
			break;
		}
	}

	private void x9679836f266f419e(xad19b25167c52eb8 x9d5750eb2d6373bc, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.xb474f98b96852a6e:
			x9d5750eb2d6373bc.x233310de5ce401a5 = xa0d3611565b2a1f2.xb44d60c6a50cc790(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		case x25099a8bbbd55d1c.x34f88c58c9554578:
			x9d5750eb2d6373bc.xd4a1602c6ff2213e = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xb0c39e4ef1f26113:
			x9d5750eb2d6373bc.x4e7022c12aac33fc = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xa0c58af19f6dd708:
			x9d5750eb2d6373bc.x5c2893a9ae3a9fc2 = x72189516320b0dea(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x0649bca0700581fa:
			x9d5750eb2d6373bc.x8359894e750846dc = x776302d216c4513b(x153c99a852375422);
			break;
		}
	}

	private void x082318eaebfce7cc(x8f75f1da124d37a8 x4c3e8680a15658ef, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.xdef8679bf1aad53e:
			x4c3e8680a15658ef.x074be147c1a0278b = x4e84fee22992fd26(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xe0506156c74e3c3f:
			x4c3e8680a15658ef.x8af0582bac09cece = x4e84fee22992fd26(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xb24389a82e3f3917:
			x4c3e8680a15658ef.xe316f972e75b51de = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x85a64b7d1cbf96d2:
			x4c3e8680a15658ef.x49b37abfabd470d8 = x4e84fee22992fd26(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x1bd53062069ae87b:
			x4c3e8680a15658ef.x5cc484d417fb4934 = xc62574be95c1c918.xdeaa127216cb1437(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		}
	}

	private void x80f369bfd15e877c(xc7b86a71e45628c2 x2ee8392f53a01b93, x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x25099a8bbbd55d1c2 = x0c644a47f9e5a7c2;
		if (x25099a8bbbd55d1c2 == x25099a8bbbd55d1c.xce8b2ce767b2485c)
		{
			x2ee8392f53a01b93.xbe1e23e7d5b43370 = xc62574be95c1c918.xc2015ac1099ed470(x153c99a852375422.x9f1a6a3451a38d10());
		}
	}

	private void x5948307e9b1e86a9(xe0ab87872ac16292 xf5467570841aab00, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.xce8b2ce767b2485c:
			xf5467570841aab00.xbe1e23e7d5b43370 = xc62574be95c1c918.xc2015ac1099ed470(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		case x25099a8bbbd55d1c.xf1bcd6a55d54328d:
			xf5467570841aab00.x60d255f9948e4b2e = xc62574be95c1c918.x8e7c6209ce53566e(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		case x25099a8bbbd55d1c.x4962e604bcaad17c:
			xf5467570841aab00.x067d56aec20cdd99 = x4e84fee22992fd26(x153c99a852375422);
			break;
		}
	}

	private void xe303ed84d73d63d2(xa097a2be55e6fe20 xa801ccff44b0c7eb, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.xb474f98b96852a6e:
			xa801ccff44b0c7eb.x233310de5ce401a5 = xa0d3611565b2a1f2.xb44d60c6a50cc790(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		case x25099a8bbbd55d1c.x00a1a650c8398e0b:
			xa801ccff44b0c7eb.x1cf0124cf79a79b8 = x3f2cb3ba0f144136(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xa83c84c286aaca9d:
			xa801ccff44b0c7eb.x042eb39cc7d00f5c = x72189516320b0dea(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x4f0a44ed6e61058f:
			xa801ccff44b0c7eb.xad645df76d47a6b8 = x776302d216c4513b(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x31673ebc6fd23429:
			xa801ccff44b0c7eb.x1f59e65bdad06006 = x72189516320b0dea(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xa0c58af19f6dd708:
			xa801ccff44b0c7eb.x5c2893a9ae3a9fc2 = x72189516320b0dea(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x0649bca0700581fa:
			xa801ccff44b0c7eb.x8359894e750846dc = x776302d216c4513b(x153c99a852375422);
			break;
		}
	}

	private void x772c1e686b7a43d1(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x0c644a47f9e5a7c2)
		{
		case x25099a8bbbd55d1c.x00a450f80cdca252:
			x7d938a2a2e9e2398 = x72189516320b0dea(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x009c399d2f14e2a1:
			xa733a3e012670689.xab67cb9464a3325b = x72a0c846678ecaf9.x15b3d0aaa5b4546f(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		}
	}

	private void x2ad2394b6c3c0189(x38058b386e92a0ef xdf60c8c8f020769c, x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x25099a8bbbd55d1c2 = x0c644a47f9e5a7c2;
		if (x25099a8bbbd55d1c2 == x25099a8bbbd55d1c.x4962e604bcaad17c)
		{
			xdf60c8c8f020769c.x067d56aec20cdd99 = x4e84fee22992fd26(x153c99a852375422);
		}
	}

	private void xc72a8acb971a82d6(xb4dde217cd172a7b x8d3df4ba8cafcb22, x03f56b37a0050a82 x153c99a852375422)
	{
		int num = x72189516320b0dea(x153c99a852375422);
		if (num != 0)
		{
			x8d3df4ba8cafcb22.x31f7427e3db1c1a8 = num;
		}
	}

	private void xf33dadb07829eeb6(xfd62ce7f2b6769d5 x692e72d323fc8d00, x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x25099a8bbbd55d1c2 = x0c644a47f9e5a7c2;
		if (x25099a8bbbd55d1c2 == x25099a8bbbd55d1c.x722b8a029c4311c2)
		{
			x692e72d323fc8d00.x20117d07e1b6d632 = x3f2cb3ba0f144136(x153c99a852375422);
		}
	}

	private void x8d4d3b3c12339b84(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x0dbbcf3105452f20:
			x082318eaebfce7cc((x8f75f1da124d37a8)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x3e68720d12325f49.x2ffb9ed185cafd85:
			x1251ffbdb0de649d((x6dd1552d6eb89e4e)x52642f91ccdeeb35, x153c99a852375422);
			break;
		default:
			throw new InvalidOperationException("Unexpected MathObject type for MathGrow.");
		}
	}

	private void xad70e80c53534ff5(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.xced856c17df679c5:
			x80f369bfd15e877c((xc7b86a71e45628c2)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x3e68720d12325f49.x2709f18576762ece:
			x5948307e9b1e86a9((xe0ab87872ac16292)x52642f91ccdeeb35, x153c99a852375422);
			break;
		default:
			throw new InvalidOperationException("Unexpected MathObject type for MathPosition.");
		}
	}

	private void x6412f994a1600a41(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.xd4e45a1fccac675d:
			x9679836f266f419e((xad19b25167c52eb8)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x3e68720d12325f49.x30727a59b1643735:
			xe303ed84d73d63d2((xa097a2be55e6fe20)x52642f91ccdeeb35, x153c99a852375422);
			break;
		default:
			throw new InvalidOperationException("Unexpected MathObject type for MathBaseJustification.");
		}
	}

	private void xc5b19fa3c63d2415(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x2ffb9ed185cafd85:
			x1251ffbdb0de649d((x6dd1552d6eb89e4e)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x3e68720d12325f49.x9b63794dfed849a8:
			x2ad2394b6c3c0189((x38058b386e92a0ef)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x3e68720d12325f49.x2709f18576762ece:
			x5948307e9b1e86a9((xe0ab87872ac16292)x52642f91ccdeeb35, x153c99a852375422);
			break;
		default:
			throw new InvalidOperationException("Unexpected MathObject type for MathChar.");
		}
	}

	private void x18c047e64b3cb02b(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x30727a59b1643735:
			xe303ed84d73d63d2((xa097a2be55e6fe20)x52642f91ccdeeb35, x153c99a852375422);
			break;
		case x3e68720d12325f49.xd4e45a1fccac675d:
			x9679836f266f419e((xad19b25167c52eb8)x52642f91ccdeeb35, x153c99a852375422);
			break;
		default:
			throw new InvalidOperationException("Unexpected MathObject type for MathSpace.");
		}
	}

	private static x77581da1860d0f9e x776302d216c4513b(x03f56b37a0050a82 x153c99a852375422)
	{
		int num = x72189516320b0dea(x153c99a852375422);
		if (num >= 0)
		{
			if (num <= 4)
			{
				return (x77581da1860d0f9e)num;
			}
			return x77581da1860d0f9e.x91043c6e17767336;
		}
		return x77581da1860d0f9e.x63374d6ffed4adeb;
	}
}
