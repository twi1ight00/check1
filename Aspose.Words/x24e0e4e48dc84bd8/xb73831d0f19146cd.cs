using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace x24e0e4e48dc84bd8;

internal class xb73831d0f19146cd
{
	private readonly x278c5f28f6803529 x6b5225aa18ecaa03;

	private long x8034a70bc0fc90d1;

	private int x3afe1d621db6d118;

	private readonly x4e88096751fad171 xd995695f8e3419d6;

	private Stream xa49cef274042e702;

	private readonly x9cbf8b59bdd6cd61 x8b3a5df55d403152;

	private bool xe425ae3330d92318;

	public bool x8b4b6fcc891336ca => xe425ae3330d92318;

	public x7cf45d99b6b735e8 xe3e99d3417159bec => xd995695f8e3419d6.xe3e99d3417159bec;

	public x28a5d52551b64191 xf86de1bd2f396938 => xd995695f8e3419d6.xf86de1bd2f396938;

	protected x25d42836be873e27 x6abca3fb6644b272 => xd995695f8e3419d6.x6abca3fb6644b272;

	private x81d646646b73f340 x145e3af29556cafe => xd995695f8e3419d6.x145e3af29556cafe;

	private xa00620cbf72482ab x68fb2ece97c0feef => xd995695f8e3419d6.x68fb2ece97c0feef;

	private xf67b8f3d5352fefb x9deec9457dc2451d => xd995695f8e3419d6.x9deec9457dc2451d;

	public xb73831d0f19146cd(x4e88096751fad171 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
		x6b5225aa18ecaa03 = new x278c5f28f6803529(xd995695f8e3419d6);
		x8b3a5df55d403152 = new x9cbf8b59bdd6cd61(xd995695f8e3419d6);
	}

	public void x0613827d1b6c81c9(x28a5d52551b64191 xe134235b3526fa75, bool x48c97d04abed82b6)
	{
		if (!xd586e0c16bdae7fc())
		{
			return;
		}
		xe425ae3330d92318 = false;
		while (xa49cef274042e702.Position < x3afe1d621db6d118 && (!xd995695f8e3419d6.x28fcdc775a1d069c.xec8728ceac69f279 || !x48c97d04abed82b6) && xa49cef274042e702.Position + 8 <= xa49cef274042e702.Length)
		{
			xe3e99d3417159bec.x2785b0923dba0723();
			if (xe3e99d3417159bec.xd9e89f699f91918a < 8 || !xb820878a71fbe650())
			{
				break;
			}
			xe3e99d3417159bec.x0863f2d944829994();
		}
	}

	private bool xd586e0c16bdae7fc()
	{
		int num = xf86de1bd2f396938.ReadInt32();
		if (num < 4)
		{
			return false;
		}
		int num2 = xf86de1bd2f396938.ReadInt32();
		if (726027589 != num2)
		{
			return false;
		}
		x8034a70bc0fc90d1 = num;
		xa49cef274042e702 = xf86de1bd2f396938.BaseStream;
		x3afe1d621db6d118 = (int)(xa49cef274042e702.Position + x8034a70bc0fc90d1 - 4);
		if (x3afe1d621db6d118 > xa49cef274042e702.Length)
		{
			x3afe1d621db6d118 = (int)xa49cef274042e702.Length;
		}
		return true;
	}

	private bool xb820878a71fbe650()
	{
		switch (xe3e99d3417159bec.xca723db1b703243f)
		{
		case xb1d54f2a80cb4dfb.x5d65916fe40c1927:
			x43325fdd19b94194();
			break;
		case xb1d54f2a80cb4dfb.x892ff3726ea92ce3:
			return false;
		case xb1d54f2a80cb4dfb.x5c9cc0d59e908538:
			xe425ae3330d92318 = true;
			break;
		case xb1d54f2a80cb4dfb.x0214cb4eb287c6d7:
			x5a5c5f2c7b273d4f();
			break;
		case xb1d54f2a80cb4dfb.x6e464f9ce073f0d2:
			x145e3af29556cafe.x7862da8b83f1b6b8.x3ef26574dd6a5679(null, x0ccf5a71249ef4a6.xd7dde027c81bb9a6);
			break;
		case xb1d54f2a80cb4dfb.x340d74ea6b598cb6:
			x007b98882ce56d16();
			break;
		case xb1d54f2a80cb4dfb.x02c57085ad6dc731:
			xdd5dfc3df3763354();
			break;
		case xb1d54f2a80cb4dfb.x36ddb0198f786203:
			x40491bfd4e30d639();
			break;
		case xb1d54f2a80cb4dfb.xbcff44f759c9e407:
			x0b02a2fb0462c9e5();
			break;
		case xb1d54f2a80cb4dfb.x6ddc453520762681:
			xd84a07f373fdfcb3();
			break;
		case xb1d54f2a80cb4dfb.x6d16e0eaa3f610d3:
			xa9d636b00ff486b7();
			break;
		case xb1d54f2a80cb4dfb.x544180e1d171628b:
			x4dcef20793cdfd8f();
			break;
		case xb1d54f2a80cb4dfb.x19fbb83d3eeb2ba2:
			xe045f890ee52ad85();
			break;
		case xb1d54f2a80cb4dfb.xfa1d945dd870afb2:
			x137a2804f8aecfc7();
			break;
		case xb1d54f2a80cb4dfb.x2b26d3b319296207:
			x7d51dcb6b065e391();
			break;
		case xb1d54f2a80cb4dfb.x7d41abd95981437f:
			x5bd690fbaae89142();
			break;
		case xb1d54f2a80cb4dfb.x3479d382a4c17ddf:
			x9a467b942d1912fd();
			break;
		case xb1d54f2a80cb4dfb.x78bb0e3576af7c3b:
			x254aff2e5f908724();
			break;
		case xb1d54f2a80cb4dfb.x89d122768aa27f4b:
			xae4070ce534a41dc();
			break;
		case xb1d54f2a80cb4dfb.x4b83d32032b49062:
			x32152637f0ba8c85();
			break;
		case xb1d54f2a80cb4dfb.xfa7265278871c571:
			x0adb8187293e05dc();
			break;
		case xb1d54f2a80cb4dfb.xbb64e7ea69706439:
			xb86bf0a75f09aae9();
			break;
		case xb1d54f2a80cb4dfb.xfa49855a46f8a021:
			xd2546c282e6f199a();
			break;
		case xb1d54f2a80cb4dfb.x9b1e41f4d2f06e7d:
			xfb225f960750d56b();
			break;
		case xb1d54f2a80cb4dfb.xcdc84b94a9be0bb8:
			xbc1851aed8cb6236();
			break;
		case xb1d54f2a80cb4dfb.xc6a16cd352244434:
			xb2ccd710080ac64b();
			break;
		case xb1d54f2a80cb4dfb.xd24a26dfe580d2b3:
			x9609f90f13149bac();
			break;
		case xb1d54f2a80cb4dfb.xade6baf6bc0454e8:
			xd0fd70d2cda0abb7();
			break;
		case xb1d54f2a80cb4dfb.x05689acc10fa3fb8:
			x558cc83610335d8b();
			break;
		case xb1d54f2a80cb4dfb.x12dd92ee0302248d:
			x42f479c70a274c21();
			break;
		case xb1d54f2a80cb4dfb.x0aea0e1912cf56e9:
			x5b198f85704beb8e();
			break;
		case xb1d54f2a80cb4dfb.xaed517ebbb930ef6:
			x8b3a5df55d403152.xd944399e85e1af75();
			break;
		case xb1d54f2a80cb4dfb.x80ed09125846b959:
			x145e3af29556cafe.x42b847293bd729a1();
			break;
		case xb1d54f2a80cb4dfb.x9946d29074806309:
			x98787ed7fdf0605f();
			break;
		case xb1d54f2a80cb4dfb.x70d2789177185901:
			xd08421bb72c7313a();
			break;
		case xb1d54f2a80cb4dfb.x19b5f150d2295b59:
			x3ba89ef66ec1bfc3();
			break;
		case xb1d54f2a80cb4dfb.xc2a68586f0d4c36f:
			x35f14820eeee9fe9();
			break;
		case xb1d54f2a80cb4dfb.xfd9ecf1e6060bf18:
			xc8d7d79f1381f48d();
			break;
		case xb1d54f2a80cb4dfb.xed74f3d831891fd0:
			x3e63d695795553a7();
			break;
		case xb1d54f2a80cb4dfb.x0ac80c0942742deb:
			x655e2ab738dffef0();
			break;
		case xb1d54f2a80cb4dfb.xa511fb7b1ee6a3ab:
			xfb39eacd9153e6d3();
			break;
		case xb1d54f2a80cb4dfb.x4dcf5e1eb55ce176:
			x72d23433127b2d3b();
			break;
		default:
			xd995695f8e3419d6.xddce54eaf1607c56(xe3e99d3417159bec.xca723db1b703243f);
			break;
		case xb1d54f2a80cb4dfb.x154adc0badd273f5:
		case xb1d54f2a80cb4dfb.x5239dd73fdb4475d:
		case xb1d54f2a80cb4dfb.x611a5cefb4553ec4:
		case xb1d54f2a80cb4dfb.x41e4b87bdc3078c2:
		case xb1d54f2a80cb4dfb.xf0ee4994bdc473f8:
		case xb1d54f2a80cb4dfb.x4f90989658dd08a9:
		case xb1d54f2a80cb4dfb.x55deab81a040edb8:
		case xb1d54f2a80cb4dfb.x95aef53980dc9a9b:
		case xb1d54f2a80cb4dfb.x29c75329f13e6203:
		case xb1d54f2a80cb4dfb.x5347aba8a6fef5d5:
		case xb1d54f2a80cb4dfb.x4a5392f1053a2f70:
		case xb1d54f2a80cb4dfb.xac89bc1e8da5fd7a:
		case xb1d54f2a80cb4dfb.xde3a112bdf27d718:
		case xb1d54f2a80cb4dfb.x34fa0bacd8b1c942:
		case xb1d54f2a80cb4dfb.x7ab6e059087f4959:
			break;
		}
		return true;
	}

	private void x43325fdd19b94194()
	{
		xf86de1bd2f396938.ReadInt32();
		xf86de1bd2f396938.ReadInt32();
		xd995695f8e3419d6.x5b13e3ca46964e0d.xfcad41fa51b4114e = xf86de1bd2f396938.ReadUInt32();
		xd995695f8e3419d6.x5b13e3ca46964e0d.xacc339743dffe4c0 = xf86de1bd2f396938.ReadUInt32();
	}

	private void x72d23433127b2d3b()
	{
		int x0c131de6e4b = xf86de1bd2f396938.ReadInt32();
		x145e3af29556cafe.x72d23433127b2d3b(x0c131de6e4b);
	}

	private void xfb39eacd9153e6d3()
	{
		int x0c131de6e4b = xf86de1bd2f396938.ReadInt32();
		x145e3af29556cafe.x655e2ab738dffef0(x0c131de6e4b);
	}

	private void x655e2ab738dffef0()
	{
		RectangleF x6b8e154b42d5c1e = xf86de1bd2f396938.x3b0757d2103a91b5();
		RectangleF x50a18ad2656e = xf86de1bd2f396938.x3b0757d2103a91b5();
		int x0c131de6e4b = xf86de1bd2f396938.ReadInt32();
		x145e3af29556cafe.x655e2ab738dffef0(x6b8e154b42d5c1e, x50a18ad2656e, x0c131de6e4b);
	}

	private void x3e63d695795553a7()
	{
		int x0c131de6e4b = xf86de1bd2f396938.ReadInt32();
		x145e3af29556cafe.x53fe2787f0b104c4(x0c131de6e4b);
	}

	private void xc8d7d79f1381f48d()
	{
		int x0c131de6e4b = xf86de1bd2f396938.ReadInt32();
		x145e3af29556cafe.x0acd3c2012ea2ee8(x0c131de6e4b);
	}

	private void x35f14820eeee9fe9()
	{
		SizeF x374ea4fe62468d0f = new SizeF(xf86de1bd2f396938.ReadSingle(), xf86de1bd2f396938.ReadSingle());
		x145e3af29556cafe.x35f14820eeee9fe9(x374ea4fe62468d0f);
	}

	private void x3ba89ef66ec1bfc3()
	{
		int x5f821c736ab = xe3e99d3417159bec.x586b7652ac7cefe0.x02995f229cff83b4(8, 15);
		CombineMode xa4aa8b4150b = (CombineMode)xe3e99d3417159bec.x586b7652ac7cefe0.x02995f229cff83b4(4, 7);
		x145e3af29556cafe.x3ba89ef66ec1bfc3(x5f821c736ab, xa4aa8b4150b);
	}

	private void xd08421bb72c7313a()
	{
		int x1b17d2598850aa3a = xe3e99d3417159bec.x586b7652ac7cefe0.x02995f229cff83b4(8, 15);
		CombineMode xa4aa8b4150b = (CombineMode)xe3e99d3417159bec.x586b7652ac7cefe0.x02995f229cff83b4(4, 7);
		x145e3af29556cafe.xd08421bb72c7313a(x1b17d2598850aa3a, xa4aa8b4150b);
	}

	private void x98787ed7fdf0605f()
	{
		RectangleF x26545669838eb36e = xf86de1bd2f396938.x3b0757d2103a91b5();
		CombineMode xa4aa8b4150b = (CombineMode)xe3e99d3417159bec.x586b7652ac7cefe0.x02995f229cff83b4(4, 7);
		x145e3af29556cafe.x201332625b9cb8f0(x26545669838eb36e, xa4aa8b4150b);
	}

	private void x558cc83610335d8b()
	{
		x273fb960e2b0a823 x273fb960e2b0a824 = x9a1b7eeeee8396a0(xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3());
		if (x273fb960e2b0a824 != null)
		{
			int x7a1ab02e747a8dd = xf86de1bd2f396938.ReadInt32();
			x60f0a0028c81b61c xb4169e5863031add = (x60f0a0028c81b61c)xf86de1bd2f396938.ReadInt32();
			RectangleF x0d1d762ec380db = xf86de1bd2f396938.x3b0757d2103a91b5();
			RectangleF x47807e698c6282d = x862864c1b5ef26d9();
			xb8e7e788f6d59708 xda5bf54deb817e = x68fb2ece97c0feef.x044fc87d6c0611b7(x273fb960e2b0a824, x7a1ab02e747a8dd, x0d1d762ec380db, xb4169e5863031add, x47807e698c6282d);
			x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
		}
	}

	private void x42f479c70a274c21()
	{
		x273fb960e2b0a823 x273fb960e2b0a824 = x9a1b7eeeee8396a0(xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3());
		if (x273fb960e2b0a824 != null)
		{
			int x7a1ab02e747a8dd = xf86de1bd2f396938.ReadInt32();
			x60f0a0028c81b61c xb4169e5863031add = (x60f0a0028c81b61c)xf86de1bd2f396938.ReadInt32();
			RectangleF x0d1d762ec380db = xf86de1bd2f396938.x3b0757d2103a91b5();
			int x10f4d88af727adbc = xf86de1bd2f396938.ReadInt32();
			PointF[] xe5be0219e97bc6c = x6abca3fb6644b272.x321be38d1b51099b(x10f4d88af727adbc, xe3e99d3417159bec.x586b7652ac7cefe0.x4e9908888e512fd5, xe3e99d3417159bec.x586b7652ac7cefe0.xaf09b1a5e6d60a5c);
			xb8e7e788f6d59708 xda5bf54deb817e = x68fb2ece97c0feef.x044fc87d6c0611b7(x273fb960e2b0a824, x7a1ab02e747a8dd, x0d1d762ec380db, xb4169e5863031add, xe5be0219e97bc6c);
			x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
		}
	}

	private void x5b198f85704beb8e()
	{
		int x5f821c736ab = xe3e99d3417159bec.x586b7652ac7cefe0.x02995f229cff83b4(8, 15);
		x6b5225aa18ecaa03.x706c726a8e9cc23f();
		x145e3af29556cafe.x51d3a13ecd447601(x68fb2ece97c0feef.xa2498ec14d12aaf5(x5f821c736ab, x6b5225aa18ecaa03));
	}

	private x273fb960e2b0a823 x9a1b7eeeee8396a0(int xe680f7e4e9e521a9)
	{
		x273fb960e2b0a823 x273fb960e2b0a824 = (x273fb960e2b0a823)x9deec9457dc2451d.x38758cbbee49e4cb(xe680f7e4e9e521a9);
		if (x273fb960e2b0a824 == null)
		{
			return null;
		}
		return x273fb960e2b0a824;
	}

	private void x9609f90f13149bac()
	{
		x6b5225aa18ecaa03.x706c726a8e9cc23f();
		int x115120198ec39b = xf86de1bd2f396938.ReadInt32();
		int xb4ec4aba4b97eacf = xf86de1bd2f396938.ReadInt32();
		RectangleF x573f10cfae8c57b = xf86de1bd2f396938.x3b0757d2103a91b5();
		string xb41faee6912a = xf86de1bd2f396938.x2a1ea9d24e62bf84(xb4ec4aba4b97eacf);
		int xcb4cd906ca3eb6fe = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		xb8e7e788f6d59708 xda5bf54deb817e = x68fb2ece97c0feef.x7c25ad656b516c85(xb41faee6912a, x573f10cfae8c57b, x115120198ec39b, x6b5225aa18ecaa03, xcb4cd906ca3eb6fe);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void xd0fd70d2cda0abb7()
	{
		int xe680f7e4e9e521a = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		xe39d06eee35dd23d xe39d06eee35dd23d = (xe39d06eee35dd23d)x9deec9457dc2451d.x38758cbbee49e4cb(xe680f7e4e9e521a);
		if (xe39d06eee35dd23d != null)
		{
			x6b5225aa18ecaa03.x706c726a8e9cc23f();
			x2410d07540cef09e x2410d07540cef09e = (x2410d07540cef09e)xf86de1bd2f396938.ReadInt32();
			bool flag = xf86de1bd2f396938.ReadInt32() > 0;
			int num = xf86de1bd2f396938.ReadInt32();
			string xb41faee6912a;
			if ((x2410d07540cef09e & x2410d07540cef09e.x158bc2b01e633464) != 0)
			{
				xb41faee6912a = xf86de1bd2f396938.x2a1ea9d24e62bf84(num);
			}
			else
			{
				int[] x199c511544621683 = xf86de1bd2f396938.x097eb7ae41ab0024(num);
				xb41faee6912a = x6bfabe8088d94b36(xe39d06eee35dd23d, x199c511544621683);
			}
			PointF[] xc3026669cd660bea = xf86de1bd2f396938.x87f464b3767301f7(num);
			x54366fa5f75a02f7 x678241938de24d = (flag ? xf86de1bd2f396938.x8c1dae79b4f085c4() : new x54366fa5f75a02f7());
			xb8e7e788f6d59708 xda5bf54deb817e = x68fb2ece97c0feef.x40b96308a5c749d1(xb41faee6912a, xe39d06eee35dd23d, xc3026669cd660bea, x6b5225aa18ecaa03, x2410d07540cef09e, x678241938de24d);
			x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
		}
	}

	private string x6bfabe8088d94b36(xe39d06eee35dd23d x26094932cf7a9139, int[] x199c511544621683)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (int x7a6027e2e9a in x199c511544621683)
		{
			stringBuilder.Append(xdf3a1f89dca325a3.x251dbcb3221739c5(x26094932cf7a9139.x29f65b3e7616f6b3.x1e6da4134d115607.x6ecaa0bbab86f311(x7a6027e2e9a).xfea0b9f75f567474));
		}
		return stringBuilder.ToString();
	}

	private void xd2546c282e6f199a()
	{
		int x1345d7804b1bedd = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		int x10f4d88af727adbc = xf86de1bd2f396938.ReadInt32();
		PointF[] x6fa2570084b2ad = x6abca3fb6644b272.x321be38d1b51099b(x10f4d88af727adbc, xe3e99d3417159bec.x586b7652ac7cefe0.x4e9908888e512fd5, xe3e99d3417159bec.x586b7652ac7cefe0.xaf09b1a5e6d60a5c);
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.xa8555875131ef259(x6fa2570084b2ad, x1345d7804b1bedd, null);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void xb86bf0a75f09aae9()
	{
		int x1345d7804b1bedd = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		float x32bf744f8e9a8c = xf86de1bd2f396938.ReadSingle();
		float x4b7a727a9fc = xf86de1bd2f396938.ReadSingle();
		RectangleF xda73fcb97c77d = x862864c1b5ef26d9();
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.xb82c6b14852077e9(xda73fcb97c77d, x32bf744f8e9a8c, x4b7a727a9fc, x1345d7804b1bedd, null);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private RectangleF x862864c1b5ef26d9()
	{
		return x862864c1b5ef26d9(xe3e99d3417159bec.x586b7652ac7cefe0.xaf09b1a5e6d60a5c);
	}

	private void xfb225f960750d56b()
	{
		int x1345d7804b1bedd = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		float xe1cf08c4fd1c0f = xf86de1bd2f396938.ReadSingle();
		int num = xf86de1bd2f396938.ReadInt32();
		int num2 = xf86de1bd2f396938.ReadInt32();
		int num3 = xf86de1bd2f396938.ReadInt32();
		if (num + num2 + 1 <= num3)
		{
			PointF[] x6fa2570084b2ad = x6abca3fb6644b272.x321be38d1b51099b(num3, x2cb185189be14c4e: false, xe3e99d3417159bec.x586b7652ac7cefe0.xaf09b1a5e6d60a5c);
			xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.x8d65dd427d9f1032(x6fa2570084b2ad, num, num2, xe1cf08c4fd1c0f, x1345d7804b1bedd);
			x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
		}
	}

	private void xb2ccd710080ac64b()
	{
		int x1345d7804b1bedd = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		float xe1cf08c4fd1c0f = xf86de1bd2f396938.ReadSingle();
		int x10f4d88af727adbc = xf86de1bd2f396938.ReadInt32();
		PointF[] x6fa2570084b2ad = x6abca3fb6644b272.x321be38d1b51099b(x10f4d88af727adbc, xe3e99d3417159bec.x586b7652ac7cefe0.x4e9908888e512fd5, xe3e99d3417159bec.x586b7652ac7cefe0.xaf09b1a5e6d60a5c);
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.x9511dabeb619a1f9(x6fa2570084b2ad, xe1cf08c4fd1c0f, x1345d7804b1bedd, null);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void xbc1851aed8cb6236()
	{
		FillMode x4eada1f74f43bddb = (xe3e99d3417159bec.x586b7652ac7cefe0.x375aed0ef1326002(2) ? FillMode.Winding : FillMode.Alternate);
		x6b5225aa18ecaa03.x706c726a8e9cc23f();
		float xe1cf08c4fd1c0f = xf86de1bd2f396938.ReadSingle();
		int x10f4d88af727adbc = xf86de1bd2f396938.ReadInt32();
		PointF[] x6fa2570084b2ad = x6abca3fb6644b272.x321be38d1b51099b(x10f4d88af727adbc, xe3e99d3417159bec.x586b7652ac7cefe0.x4e9908888e512fd5, xe3e99d3417159bec.x586b7652ac7cefe0.xaf09b1a5e6d60a5c);
		xab391c46ff9a0a38 xab391c46ff9a0a = x68fb2ece97c0feef.x9511dabeb619a1f9(x6fa2570084b2ad, xe1cf08c4fd1c0f, int.MaxValue, x6b5225aa18ecaa03);
		xab391c46ff9a0a.x4eada1f74f43bddb = x4eada1f74f43bddb;
		x145e3af29556cafe.x51d3a13ecd447601(xab391c46ff9a0a);
	}

	private void x32152637f0ba8c85()
	{
		x6b5225aa18ecaa03.x706c726a8e9cc23f();
		float x32bf744f8e9a8c = xf86de1bd2f396938.ReadSingle();
		float x4b7a727a9fc = xf86de1bd2f396938.ReadSingle();
		RectangleF xda73fcb97c77d = x862864c1b5ef26d9();
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.xb5bbf5dc79bae0cf(xda73fcb97c77d, x32bf744f8e9a8c, x4b7a727a9fc, int.MaxValue, x6b5225aa18ecaa03);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void x0adb8187293e05dc()
	{
		int x1345d7804b1bedd = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		float x32bf744f8e9a8c = xf86de1bd2f396938.ReadSingle();
		float x4b7a727a9fc = xf86de1bd2f396938.ReadSingle();
		RectangleF xda73fcb97c77d = x862864c1b5ef26d9();
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.xb5bbf5dc79bae0cf(xda73fcb97c77d, x32bf744f8e9a8c, x4b7a727a9fc, x1345d7804b1bedd, null);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void xae4070ce534a41dc()
	{
		int x1345d7804b1bedd = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		RectangleF xda73fcb97c77d = x862864c1b5ef26d9();
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.x8b8e40a8d42e4c69(xda73fcb97c77d, x1345d7804b1bedd, null);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void x254aff2e5f908724()
	{
		x6b5225aa18ecaa03.x706c726a8e9cc23f();
		RectangleF xda73fcb97c77d = x862864c1b5ef26d9();
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.x8b8e40a8d42e4c69(xda73fcb97c77d, int.MaxValue, x6b5225aa18ecaa03);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void x9a467b942d1912fd()
	{
		int x1345d7804b1bedd = xf86de1bd2f396938.ReadInt32();
		int x1b17d2598850aa3a = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.xd118bdfd155d71de(x1b17d2598850aa3a, x1345d7804b1bedd, null);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void x5bd690fbaae89142()
	{
		x6b5225aa18ecaa03.x706c726a8e9cc23f();
		int x1b17d2598850aa3a = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.xd118bdfd155d71de(x1b17d2598850aa3a, int.MaxValue, x6b5225aa18ecaa03);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void x7d51dcb6b065e391()
	{
		int x1345d7804b1bedd = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		int x10f4d88af727adbc = xf86de1bd2f396938.ReadInt32();
		PointF[] x6fa2570084b2ad = x6abca3fb6644b272.x321be38d1b51099b(x10f4d88af727adbc, xe3e99d3417159bec.x586b7652ac7cefe0.x4e9908888e512fd5, xe3e99d3417159bec.x586b7652ac7cefe0.xaf09b1a5e6d60a5c);
		bool x7a848427f2a9a3b = xe3e99d3417159bec.x586b7652ac7cefe0.x375aed0ef1326002(2);
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.x76fd4418ef6e0ad9(x6fa2570084b2ad, x7a848427f2a9a3b, x1345d7804b1bedd, null);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void x137a2804f8aecfc7()
	{
		x6b5225aa18ecaa03.x706c726a8e9cc23f();
		int x10f4d88af727adbc = xf86de1bd2f396938.ReadInt32();
		PointF[] x6fa2570084b2ad = x6abca3fb6644b272.x321be38d1b51099b(x10f4d88af727adbc, xe3e99d3417159bec.x586b7652ac7cefe0.x4e9908888e512fd5, xe3e99d3417159bec.x586b7652ac7cefe0.xaf09b1a5e6d60a5c);
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.x76fd4418ef6e0ad9(x6fa2570084b2ad, x7a848427f2a9a3b5: true, int.MaxValue, x6b5225aa18ecaa03);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void x4dcef20793cdfd8f()
	{
		x6b5225aa18ecaa03.x706c726a8e9cc23f();
		int x10f4d88af727adbc = xf86de1bd2f396938.ReadInt32();
		RectangleF[] x09d9444f882ac = x7e8bb1ba721556ce(x10f4d88af727adbc);
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.x530eb28229985474(x09d9444f882ac, int.MaxValue, x6b5225aa18ecaa03);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private void xe045f890ee52ad85()
	{
		int x1345d7804b1bedd = xe3e99d3417159bec.x586b7652ac7cefe0.x2341221de20e9ed3();
		int x10f4d88af727adbc = xf86de1bd2f396938.ReadInt32();
		RectangleF[] x09d9444f882ac = x7e8bb1ba721556ce(x10f4d88af727adbc);
		xab391c46ff9a0a38 xda5bf54deb817e = x68fb2ece97c0feef.x530eb28229985474(x09d9444f882ac, x1345d7804b1bedd, null);
		x145e3af29556cafe.x51d3a13ecd447601(xda5bf54deb817e);
	}

	private RectangleF[] x7e8bb1ba721556ce(int x10f4d88af727adbc)
	{
		RectangleF[] array = new RectangleF[x10f4d88af727adbc];
		for (int i = 0; i < x10f4d88af727adbc; i++)
		{
			ref RectangleF reference = ref array[i];
			reference = x862864c1b5ef26d9(xe3e99d3417159bec.x586b7652ac7cefe0.xaf09b1a5e6d60a5c);
		}
		return array;
	}

	private RectangleF x862864c1b5ef26d9(bool x06b3cea3a3b6fc59)
	{
		if (x06b3cea3a3b6fc59)
		{
			short num = xf86de1bd2f396938.ReadInt16();
			short num2 = xf86de1bd2f396938.ReadInt16();
			short num3 = xf86de1bd2f396938.ReadInt16();
			short num4 = xf86de1bd2f396938.ReadInt16();
			return new RectangleF(num, num2, num3, num4);
		}
		return xf86de1bd2f396938.x3b0757d2103a91b5();
	}

	private void xa9d636b00ff486b7()
	{
		x26d9ecb4bdf0456d x6c50a99faab7d = xf86de1bd2f396938.x458cbe2343cf2fba();
		x145e3af29556cafe.xa9d636b00ff486b7(x6c50a99faab7d);
	}

	private void xd84a07f373fdfcb3()
	{
		x60f0a0028c81b61c xd2f68ee6f47e9dfb = (x60f0a0028c81b61c)xe3e99d3417159bec.x586b7652ac7cefe0.xd2f68ee6f47e9dfb;
		float num = xf86de1bd2f396938.ReadSingle();
		x145e3af29556cafe.x7862da8b83f1b6b8.xd84a07f373fdfcb3(xd995695f8e3419d6.x5b13e3ca46964e0d.x645cd44df6f04941(num, xd2f68ee6f47e9dfb));
	}

	private void x0b02a2fb0462c9e5()
	{
		x0ccf5a71249ef4a6 xa4aa8b4150b = x13e2dd08054e8ccf();
		float xcb83cdf6822fc99d = xf86de1bd2f396938.ReadSingle();
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xa77087bb05d9ef76(xcb83cdf6822fc99d);
		x145e3af29556cafe.x7862da8b83f1b6b8.x3ef26574dd6a5679(x54366fa5f75a02f, xa4aa8b4150b);
	}

	private void x40491bfd4e30d639()
	{
		x0ccf5a71249ef4a6 xa4aa8b4150b = x13e2dd08054e8ccf();
		float xbcdf0fa27ad = xf86de1bd2f396938.ReadSingle();
		float x1e0724360f9c = xf86de1bd2f396938.ReadSingle();
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.x5152a5707921c783(xbcdf0fa27ad, x1e0724360f9c);
		x145e3af29556cafe.x7862da8b83f1b6b8.x3ef26574dd6a5679(x54366fa5f75a02f, xa4aa8b4150b);
	}

	private void x5a5c5f2c7b273d4f()
	{
		x54366fa5f75a02f7 xa801ccff44b0c7eb = xdf982515b2b3a349();
		x145e3af29556cafe.x7862da8b83f1b6b8.x3ef26574dd6a5679(xa801ccff44b0c7eb, x0ccf5a71249ef4a6.x90fda48194fc6b9a);
	}

	private void xdd5dfc3df3763354()
	{
		x0ccf5a71249ef4a6 xa4aa8b4150b = x13e2dd08054e8ccf();
		float x0e0da4ab3344491a = xf86de1bd2f396938.ReadSingle();
		float xc606b8e75847f7ba = xf86de1bd2f396938.ReadSingle();
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(x0e0da4ab3344491a, xc606b8e75847f7ba);
		x145e3af29556cafe.x7862da8b83f1b6b8.x3ef26574dd6a5679(x54366fa5f75a02f, xa4aa8b4150b);
	}

	private void x007b98882ce56d16()
	{
		x54366fa5f75a02f7 xa801ccff44b0c7eb = xdf982515b2b3a349();
		x0ccf5a71249ef4a6 xa4aa8b4150b = x13e2dd08054e8ccf();
		x145e3af29556cafe.x7862da8b83f1b6b8.x3ef26574dd6a5679(xa801ccff44b0c7eb, xa4aa8b4150b);
	}

	private x0ccf5a71249ef4a6 x13e2dd08054e8ccf()
	{
		if (xe3e99d3417159bec.x586b7652ac7cefe0.x375aed0ef1326002(2))
		{
			return x0ccf5a71249ef4a6.x73ec591f716ac6c5;
		}
		return x0ccf5a71249ef4a6.x9dcbb68afa7678b9;
	}

	private x54366fa5f75a02f7 xdf982515b2b3a349()
	{
		return xf86de1bd2f396938.x8c1dae79b4f085c4();
	}
}
