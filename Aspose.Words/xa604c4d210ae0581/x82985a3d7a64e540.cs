using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6f978ba1e7522832;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace xa604c4d210ae0581;

internal class x82985a3d7a64e540 : x485adbf5506556e8, x456c8b07916a8790, xf77fd3dab66c510a
{
	private xedb0eb766e25e0c9 x249035ea44f3b76d;

	private int xb277c46192ba7caa;

	private readonly x3a9e25666c8d1ee1 xbeb1e01b2eca6e56;

	private readonly xd503583b32a53cea x7ff04dd244132d8e;

	private bool x355994d5a027a7ae;

	private xedb0eb766e25e0c9 x8eea9678dfc771b5;

	private x08cf144d2bc4c341 x8cedcaa9a62c6e39;

	private readonly x3eb345b6a7476c91 x82ee2fb0c13b5ccc;

	private readonly xf8cef531dae89ea3 x79882c75cde6984a = new xf8cef531dae89ea3();

	private static readonly IComparer x9eeefdcbaf83e46f = new xedd61bb6f0457286();

	private static readonly IComparer x5a718be23974f165 = new xbac664ebc33878a7();

	private xedb0eb766e25e0c9 xedb0eb766e25e0c9 => (xedb0eb766e25e0c9)x66c02128fdc6436a;

	private xdb4d596cc6b8659f xeeac8c23df57dd1d => xedb0eb766e25e0c9.xeeac8c23df57dd1d;

	internal bool xd2f1f3523585ff1e
	{
		set
		{
			x7ff04dd244132d8e.xd2f1f3523585ff1e = value;
		}
	}

	private bool xbe0f5861df0de58f => xbeb1e01b2eca6e56 >= x3a9e25666c8d1ee1.xa62b987919cd982e;

	internal x82985a3d7a64e540(BinaryReader dataReader, xd47c6c7442eb8033 revisionAuthors, x3a9e25666c8d1ee1 nFib, IWarningCallback warningCallback)
		: base(revisionAuthors, warningCallback)
	{
		x7ff04dd244132d8e = new xd503583b32a53cea(this, dataReader);
		xbeb1e01b2eca6e56 = nFib;
		x82ee2fb0c13b5ccc = new x3eb345b6a7476c91();
	}

	private int x2e3049bafd71a386(x875aca5784596b73 x28180b3c3774af93, x8f1cf61f24a43e61 x4f217665270fa928)
	{
		return x4f217665270fa928 switch
		{
			x8f1cf61f24a43e61.x72d92bd1aff02e37 => 4020, 
			x8f1cf61f24a43e61.x419ba17a5322627b => 4320, 
			x8f1cf61f24a43e61.xe360b1885d8d4a41 => 4300, 
			x8f1cf61f24a43e61.x9bcb07e204e30218 => 4310, 
			_ => 0, 
		};
	}

	int xf77fd3dab66c510a.x607ca7b6672ba4ae(x875aca5784596b73 x28180b3c3774af93, x8f1cf61f24a43e61 x4f217665270fa928)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x2e3049bafd71a386
		return this.x2e3049bafd71a386(x28180b3c3774af93, x4f217665270fa928);
	}

	private void xbf1d99489325c72d(x875aca5784596b73 x28180b3c3774af93, int x62584df2cb5d40dd, int xd0af4642d624ddbd, x8f1cf61f24a43e61 x2356aaca890347a5, object xbcea506a33cf9111)
	{
		xcc817919573a5995.x76f56033ed683860(x9b287b671d592594, x875aca5784596b73.x9fc257da11bc0f63, 0, 1, x2356aaca890347a5, xbcea506a33cf9111);
	}

	void xf77fd3dab66c510a.xe9decf879352095e(x875aca5784596b73 x28180b3c3774af93, int x62584df2cb5d40dd, int xd0af4642d624ddbd, x8f1cf61f24a43e61 x2356aaca890347a5, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xbf1d99489325c72d
		this.xbf1d99489325c72d(x28180b3c3774af93, x62584df2cb5d40dd, xd0af4642d624ddbd, x2356aaca890347a5, xbcea506a33cf9111);
	}

	internal void x06b0e25aa6ad68a9(byte[] x24c45257571ea504, xedb0eb766e25e0c9 xe193ceb565ecaa0a, int x08a29f5fec956da0)
	{
		x53d3302394a93aa5(xe193ceb565ecaa0a, x08a29f5fec956da0);
		x7ff04dd244132d8e.x06b0e25aa6ad68a9(x24c45257571ea504);
		x3301471272508313();
	}

	internal void xf75fc5b2f257a111(byte[] x24c45257571ea504, TableStyle x13eeaa19b4289a25)
	{
		xe5ef82d048062925 = x13eeaa19b4289a25;
		x66c02128fdc6436a = x13eeaa19b4289a25.xedb0eb766e25e0c9;
		x7ff04dd244132d8e.x06b0e25aa6ad68a9(x24c45257571ea504);
		x13eeaa19b4289a25.xedb0eb766e25e0c9.x52b190e626f65140(4005);
	}

	internal void x53d3302394a93aa5(xedb0eb766e25e0c9 xe193ceb565ecaa0a, int x08a29f5fec956da0)
	{
		x66c02128fdc6436a = xe193ceb565ecaa0a;
		x249035ea44f3b76d = xe193ceb565ecaa0a;
		xedb0eb766e25e0c9.xae20093bed1e48a8(4140, TableStyleOptions.Default2003);
	}

	internal void x3301471272508313()
	{
		x66c02128fdc6436a = x249035ea44f3b76d;
		if (xeeac8c23df57dd1d == null || xeeac8c23df57dd1d.Count == 0)
		{
			x3dc950453374051a("Cell properties is missing.");
		}
		else
		{
			xbb29e875893772b3();
		}
	}

	internal x3ff949c473a702d2 x6210059f049f0d48(Row xa806b754814b9ae0, x3ff949c473a702d2 x0e8a35956345f93b, BinaryWriter x1d146d2daef2efea, x08cf144d2bc4c341 x0f7b23d1c393aed9)
	{
		CellCollection cells = xa806b754814b9ae0.Cells;
		xedb0eb766e25e0c9 xe193ceb565ecaa0a = xa806b754814b9ae0.xedb0eb766e25e0c9;
		x113035ffca5e6e23(cells, xe193ceb565ecaa0a, x6256d0d7b611e975: false);
		x413a75acd2f37ae0(cells, xe193ceb565ecaa0a);
		if (!x0f7b23d1c393aed9.xdb8d101b58051732)
		{
			xe193ceb565ecaa0a = (xedb0eb766e25e0c9)xa806b754814b9ae0.xedb0eb766e25e0c9.x75eab24f5629a618;
			x113035ffca5e6e23(cells, xe193ceb565ecaa0a, x6256d0d7b611e975: true);
			x413a75acd2f37ae0(cells, xe193ceb565ecaa0a);
		}
		x32939c68497cb083 x32939c68497cb84 = x6210059f049f0d48(xa806b754814b9ae0.xedb0eb766e25e0c9, x2d2b638850b16ff1: true, x0f7b23d1c393aed9);
		int x31a47fa9d0eb2c = (int)x1d146d2daef2efea.BaseStream.Position;
		int num = x32939c68497cb84.x6b73aa01aa019d3a.Length + x0e8a35956345f93b.x6b73aa01aa019d3a.Length;
		x1d146d2daef2efea.Write((ushort)num);
		x1d146d2daef2efea.Write(x0e8a35956345f93b.x6b73aa01aa019d3a);
		x1d146d2daef2efea.Write(x32939c68497cb84.x6b73aa01aa019d3a);
		x32939c68497cb083 x32939c68497cb85 = xeecb429619e58d29(x31a47fa9d0eb2c);
		x3ff949c473a702d2 x3ff949c473a702d3 = new x3ff949c473a702d2(0, x32939c68497cb85.x6b73aa01aa019d3a);
		x3ff949c473a702d3.x917b69030691beda(x0e8a35956345f93b);
		x32939c68497cb083 x24c45257571ea = x6210059f049f0d48(xa806b754814b9ae0.xedb0eb766e25e0c9, x2d2b638850b16ff1: false, x0f7b23d1c393aed9);
		x3ff949c473a702d3.x917b69030691beda(x24c45257571ea);
		xa806b754814b9ae0.xedb0eb766e25e0c9.xd835e6f8c37a91bb();
		return x3ff949c473a702d3;
	}

	internal x32939c68497cb083 x6210059f049f0d48(xedb0eb766e25e0c9 xc966c0aefbe06012, bool x2d2b638850b16ff1, x08cf144d2bc4c341 x0f7b23d1c393aed9)
	{
		x355994d5a027a7ae = x2d2b638850b16ff1;
		x8cedcaa9a62c6e39 = x0f7b23d1c393aed9;
		x82ee2fb0c13b5ccc.x5aa326f374b3d0ef = x9b287b671d592594;
		x8eea9678dfc771b5 = xc966c0aefbe06012;
		xedb0eb766e25e0c9 x94aec03cf2ae750b = ((x2d2b638850b16ff1 && !x0f7b23d1c393aed9.xdb8d101b58051732) ? ((xedb0eb766e25e0c9)xc966c0aefbe06012.x75eab24f5629a618) : xc966c0aefbe06012);
		return new x32939c68497cb083(x6210059f049f0d48(x94aec03cf2ae750b));
	}

	internal x5c12f3cc90da0a84 x746ca66f5c31e314(TableStyle x13eeaa19b4289a25)
	{
		x9b287b671d592594.BaseStream.Position = 0L;
		x66c02128fdc6436a = x13eeaa19b4289a25.xedb0eb766e25e0c9;
		if (x13eeaa19b4289a25.x8301ab10c226b0c2 >= 15)
		{
			x9b287b671d592594.xd776ae6f68bc4d9c(x875aca5784596b73.x847506dd874513a2, x13eeaa19b4289a25.x8301ab10c226b0c2);
		}
		xb3bb56a55b81f681(x7c4bd54fe1ef29c6: true);
		xa44d6ca03ba4dda3(x875aca5784596b73.xf7daf20fe529fa5a, 4250);
		xa4487e396b4885c9.xca30019ffb591c2f(xedb0eb766e25e0c9, x875aca5784596b73.x9fc257da11bc0f63, this, x5a718be23974f165);
		xa44d6ca03ba4dda3(x875aca5784596b73.x985c511e1aae5008, 4340);
		for (int i = 0; i < x13eeaa19b4289a25.x7205cb42c2f994a4.Count; i++)
		{
			xe12ab2f55355c7f0 xe12ab2f55355c7f = (xe12ab2f55355c7f0)x13eeaa19b4289a25.x7205cb42c2f994a4[i];
			xf8cef531dae89ea3 xf8cef531dae89ea = xe12ab2f55355c7f.xf8cef531dae89ea3;
			if (xf8cef531dae89ea != null)
			{
				long x30cc7819189f11b = x6d582d881359c5db(x875aca5784596b73.x7ae0e2d3a8dfaf2c, xe12ab2f55355c7f.x3146d638ec378671);
				if (xf8cef531dae89ea.x263d579af1d0d43f(3060))
				{
					x9b287b671d592594.x1680160a63ff3e0b(x875aca5784596b73.x410cb2b49057b29e, (byte)xf8cef531dae89ea.xf6ce0e8106e6a1d8);
				}
				xa46408338e704d99(x875aca5784596b73.x6629777538f3fdd4, xf8cef531dae89ea.xa8c2637cc4888928);
				xa46408338e704d99(x875aca5784596b73.x119b02fa92cbd30e, xf8cef531dae89ea.x79d902473861f242);
				xa46408338e704d99(x875aca5784596b73.xa3cc4daca8b86f4c, xf8cef531dae89ea.xaea087ab32102492);
				xa46408338e704d99(x875aca5784596b73.xa406fc6c904fab76, xf8cef531dae89ea.xd7a21e27974f626c);
				xa46408338e704d99(x875aca5784596b73.xf4190574178a9824, xf8cef531dae89ea.x8ef7f9589a0a0945);
				xa46408338e704d99(x875aca5784596b73.x0c23be1fdf3fc243, xf8cef531dae89ea.xbccf8ac0eed2b937);
				xa46408338e704d99(x875aca5784596b73.x0a7aa79eaeafac53, xf8cef531dae89ea.xb5d07e936a4ada49);
				xa46408338e704d99(x875aca5784596b73.xe2a5907f328cfd4b, xf8cef531dae89ea.xbf9846a75147a8a9);
				x81340dc16c92f474(x875aca5784596b73.x3ad9baf9dcce0aa7, xf8cef531dae89ea.xf7866f89640a29a3(3170));
				xdff84d5a65b9347a(x30cc7819189f11b);
			}
		}
		if (x66c02128fdc6436a.x263d579af1d0d43f(4500))
		{
			x9b287b671d592594.x1680160a63ff3e0b(x875aca5784596b73.x0df705e4ae9653c1, (int)x66c02128fdc6436a.xf7866f89640a29a3(4500));
		}
		if (x66c02128fdc6436a.x263d579af1d0d43f(4510))
		{
			x9b287b671d592594.x1680160a63ff3e0b(x875aca5784596b73.x9a228fceefb5676d, (int)x66c02128fdc6436a.xf7866f89640a29a3(4510));
		}
		x81340dc16c92f474(x875aca5784596b73.x3ad9baf9dcce0aa7, x13eeaa19b4289a25.xf8cef531dae89ea3.xf7866f89640a29a3(3170));
		return new x5c12f3cc90da0a84(x6ca2fe3c7f213f3e());
	}

	public bool x09a3d4a7eac8f520(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		if (xe780cde24dcce6f2 != x8de82539c936c298.xc760d3c548350954)
		{
			return true;
		}
		x7450cc1e48712286 = xe134235b3526fa75;
		x82ee2fb0c13b5ccc.xf86de1bd2f396938 = xe134235b3526fa75;
		x82ee2fb0c13b5ccc.xeeac8c23df57dd1d = (base.x4de4e1e9aeaada1f ? null : xeeac8c23df57dd1d);
		switch (x28180b3c3774af93)
		{
		case x875aca5784596b73.x847506dd874513a2:
			xedb0eb766e25e0c9.x8301ab10c226b0c2 = xe134235b3526fa75.ReadUInt16();
			break;
		case x875aca5784596b73.x7ae0e2d3a8dfaf2c:
			x7da53fcf55413cb5(this, xe134235b3526fa75, x0d4f7f21e78721d6, x70d40b77e7fb14d0.x11db8fc7f469a2fc);
			break;
		case x875aca5784596b73.x3ad9baf9dcce0aa7:
		{
			Shading xbcea506a33cf = x075263c82f5cad54.x9b448ca00ed9c929(xe134235b3526fa75, null);
			if (base.x4de4e1e9aeaada1f)
			{
				x66c02128fdc6436a.xae20093bed1e48a8(3170, xbcea506a33cf);
			}
			else if (xe5ef82d048062925 == null)
			{
				x3dc950453374051a("Unexpected shading information occurred outside table style definition while reading DOC file.");
			}
			else
			{
				xe5ef82d048062925.xf8cef531dae89ea3.xae20093bed1e48a8(3170, xbcea506a33cf);
			}
			break;
		}
		case x875aca5784596b73.x0df705e4ae9653c1:
			x66c02128fdc6436a.xae20093bed1e48a8(4500, (int)xe134235b3526fa75.ReadByte());
			break;
		case x875aca5784596b73.x9a228fceefb5676d:
			x66c02128fdc6436a.xae20093bed1e48a8(4510, (int)xe134235b3526fa75.ReadByte());
			break;
		case x875aca5784596b73.x6629777538f3fdd4:
		case x875aca5784596b73.x119b02fa92cbd30e:
		case x875aca5784596b73.xa3cc4daca8b86f4c:
		case x875aca5784596b73.xa406fc6c904fab76:
		case x875aca5784596b73.xf4190574178a9824:
		case x875aca5784596b73.x0c23be1fdf3fc243:
		case x875aca5784596b73.x0a7aa79eaeafac53:
		case x875aca5784596b73.xe2a5907f328cfd4b:
			x263126e767bb1792(x4c8ed3058a579838(x28180b3c3774af93));
			break;
		case x875aca5784596b73.x410cb2b49057b29e:
			x66c02128fdc6436a.xae20093bed1e48a8(3060, (CellVerticalAlignment)xe134235b3526fa75.ReadByte());
			break;
		case x875aca5784596b73.x547e8f141bf79388:
			x66c02128fdc6436a.xae20093bed1e48a8(5101, (TableAlignment)xe134235b3526fa75.ReadInt16());
			break;
		case x875aca5784596b73.xe1840c23890aea9e:
			if (x66c02128fdc6436a is xedb0eb766e25e0c9)
			{
				xedb0eb766e25e0c9.x9ba359ff37a3a63b = (TableAlignment)xe134235b3526fa75.ReadInt16();
			}
			break;
		case x875aca5784596b73.x45d84ee9b173b612:
			xb277c46192ba7caa = xe134235b3526fa75.ReadInt16();
			break;
		case x875aca5784596b73.x9059482aee2e840b:
			x82ee2fb0c13b5ccc.x2986430b97a5e6b0();
			break;
		case x875aca5784596b73.xd959dd2c7aa008cc:
		{
			int num2 = xe134235b3526fa75.ReadInt16();
			if (xbeb1e01b2eca6e56 == x3a9e25666c8d1ee1.xe3cb3ab95828933e)
			{
				xedb0eb766e25e0c9.xcad2e59522947ede = num2;
				xedb0eb766e25e0c9.x41c99cca24bc80be = num2;
			}
			break;
		}
		case x875aca5784596b73.xfb8395d572198618:
		{
			bool flag5 = !xe134235b3526fa75.ReadBoolean();
			if (xbeb1e01b2eca6e56 < x3a9e25666c8d1ee1.xa62b987919cd982e)
			{
				x66c02128fdc6436a.xae20093bed1e48a8(4360, flag5);
			}
			break;
		}
		case x875aca5784596b73.x7d28c9201219c923:
		{
			bool flag4 = !xe134235b3526fa75.ReadBoolean();
			x66c02128fdc6436a.xae20093bed1e48a8(4360, flag4);
			break;
		}
		case x875aca5784596b73.x1fca2c5def8b085d:
			x66c02128fdc6436a.xae20093bed1e48a8(4040, xe134235b3526fa75.ReadByte() == 1);
			break;
		case x875aca5784596b73.x79d0fad9e29c9f31:
			x82ee2fb0c13b5ccc.x6cc32ac1ecd2a523(xedb0eb766e25e0c9, x0d4f7f21e78721d6, xbeb1e01b2eca6e56);
			if (!xedb0eb766e25e0c9.x263d579af1d0d43f(4020) && !xedb0eb766e25e0c9.x263d579af1d0d43f(4320))
			{
				xedb0eb766e25e0c9.xcad2e59522947ede = 0;
				xedb0eb766e25e0c9.x41c99cca24bc80be = 0;
			}
			break;
		case x875aca5784596b73.x8b67f322c0d8cfe2:
			x82ee2fb0c13b5ccc.xc8938b67bfbe60c3(xedb0eb766e25e0c9);
			break;
		case x875aca5784596b73.x5e986dd230990edb:
		{
			int xcfaa4292e98075c7 = xe134235b3526fa75.ReadInt16();
			x82ee2fb0c13b5ccc.x8e38d371def849c2(xcfaa4292e98075c7, 3010, (int)xe134235b3526fa75.ReadInt16());
			break;
		}
		case x875aca5784596b73.xe4ade3f63c788219:
		{
			int xcfaa4292e98075c6 = xe134235b3526fa75.ReadInt16();
			x82ee2fb0c13b5ccc.x8e38d371def849c2(xcfaa4292e98075c6, 3020, xb87166435bc48cc2());
			break;
		}
		case x875aca5784596b73.x7bfbca27661f65b1:
			x19ce25c3c13b0c39(4330);
			break;
		case x875aca5784596b73.x9117cc40a2ec5d68:
		case x875aca5784596b73.x17c5d81674722d26:
		case x875aca5784596b73.x55e4199f9d8c0034:
		case x875aca5784596b73.xeed7f2788f5fd860:
			if (!xbe0f5861df0de58f)
			{
				x82ee2fb0c13b5ccc.x08855b6cb54aed5c(x28180b3c3774af93, x0d4f7f21e78721d6);
			}
			break;
		case x875aca5784596b73.x1834af1a4308ffef:
		case x875aca5784596b73.xabcf0cc1786a4080:
		case x875aca5784596b73.x7248ddb2334fa478:
			x82ee2fb0c13b5ccc.x08855b6cb54aed5c(x28180b3c3774af93, x0d4f7f21e78721d6);
			break;
		case x875aca5784596b73.x823ea0c39409cbf4:
		case x875aca5784596b73.xb14da3b9b9b29bdc:
		case x875aca5784596b73.xc5f03c1e3457ac2a:
		case x875aca5784596b73.xb70638f89b996acf:
			x82ee2fb0c13b5ccc.xc1ad5d1e500cd4d9(x28180b3c3774af93, x0d4f7f21e78721d6);
			break;
		case x875aca5784596b73.xeddee5f2d90a5550:
		{
			int num = xe134235b3526fa75.ReadInt16();
			HeightRule heightRule = ((num == 0) ? HeightRule.Auto : ((num <= 0) ? HeightRule.Exactly : HeightRule.AtLeast));
			x66c02128fdc6436a.xae20093bed1e48a8(4110, heightRule);
			x66c02128fdc6436a.xae20093bed1e48a8(4120, Math.Abs(num));
			break;
		}
		case x875aca5784596b73.x976d89bbdc0a95da:
			xe134235b3526fa75.ReadInt16();
			x66c02128fdc6436a.xae20093bed1e48a8(4140, x4cf3b47199c96529.xb7e770c54c5f7404(xe134235b3526fa75.ReadInt16()));
			break;
		case x875aca5784596b73.xa056fbb8a5fcb368:
		case x875aca5784596b73.x01a90f83a58e869a:
			x578ff4ecf150579e(x28180b3c3774af93);
			break;
		case x875aca5784596b73.x4ac67d9c794ef0e6:
		case x875aca5784596b73.x380cfba887094f8c:
			x82ee2fb0c13b5ccc.xce2f85544b004e38(x28180b3c3774af93);
			break;
		case x875aca5784596b73.x460dd269a2e88889:
			x82ee2fb0c13b5ccc.xb33f778ead2893c4(x0d4f7f21e78721d6);
			break;
		case x875aca5784596b73.x3d30e5a4e3e20843:
			x66c02128fdc6436a.xae20093bed1e48a8(4230, xb87166435bc48cc2());
			break;
		case x875aca5784596b73.x82add1e88b540b28:
			x66c02128fdc6436a.xae20093bed1e48a8(4240, xe134235b3526fa75.ReadByte() == 1);
			break;
		case x875aca5784596b73.xf7daf20fe529fa5a:
			x955900cdfe72531d(4250);
			break;
		case x875aca5784596b73.xfb3f83aa5c420d35:
			x955900cdfe72531d(4260);
			break;
		case x875aca5784596b73.x985c511e1aae5008:
			x955900cdfe72531d(4340);
			break;
		case x875aca5784596b73.x44baafe534057c0b:
			x66c02128fdc6436a.xae20093bed1e48a8(4380, xe134235b3526fa75.ReadInt16() != 0);
			break;
		case x875aca5784596b73.x9fc257da11bc0f63:
			x1e1fda2f04324fa5();
			break;
		case x875aca5784596b73.x94b69c8312e9a843:
			x82ee2fb0c13b5ccc.xf738afa41d843b52();
			break;
		case x875aca5784596b73.x6bc3b732a6f23770:
			x61d883fea6969649();
			break;
		case x875aca5784596b73.xdf2252b1742be249:
			xfcbfa618cffcaf3b(4150, 4160);
			break;
		case x875aca5784596b73.x8cfe23976ee3209f:
			x2b63788f541b61ed(4170, 4180, x063dc23d24025556: true);
			break;
		case x875aca5784596b73.x5eb35e22b6a70c9d:
			xe58888a235038afd(4190, 4200, x063dc23d24025556: true);
			break;
		case x875aca5784596b73.x7ae9067d0a5e6929:
			x66c02128fdc6436a.xae20093bed1e48a8(4210, (int)xe134235b3526fa75.ReadInt16());
			break;
		case x875aca5784596b73.x2edb444045966f11:
			x66c02128fdc6436a.xae20093bed1e48a8(4220, (int)xe134235b3526fa75.ReadInt16());
			break;
		case x875aca5784596b73.x8d3ea56ffb767cb4:
			x66c02128fdc6436a.xae20093bed1e48a8(4270, (int)xe134235b3526fa75.ReadInt16());
			break;
		case x875aca5784596b73.xc5cca07ea905051b:
			x66c02128fdc6436a.xae20093bed1e48a8(4280, (int)xe134235b3526fa75.ReadInt16());
			break;
		case x875aca5784596b73.x15dc82a2726b03d6:
			x66c02128fdc6436a.xae20093bed1e48a8(4350, xe134235b3526fa75.ReadByte() == 0);
			break;
		case x875aca5784596b73.x7a81d5c898fc7690:
			xf9b50472de6f2a55(new xedb0eb766e25e0c9(), x677e602d930f9cfb: false);
			break;
		case x875aca5784596b73.x2dece4956ef2a459:
			xf4c07e593d05bb15();
			break;
		case x875aca5784596b73.xdd2e41878d16119e:
			xd28f53fd94b9c0e4($"Table formatting modifier 0x{(int)x28180b3c3774af93:x4} is not supported for DOC format by Aspose.Words.");
			break;
		case x875aca5784596b73.x23b80be40708ee83:
			x66c02128fdc6436a.xae20093bed1e48a8(4400, xe134235b3526fa75.ReadInt32());
			break;
		case x875aca5784596b73.xddc39c60bdf04b05:
		{
			int xcfaa4292e98075c5 = xe134235b3526fa75.ReadUInt16();
			bool flag3 = xe134235b3526fa75.ReadBoolean();
			x82ee2fb0c13b5ccc.x8e38d371def849c2(xcfaa4292e98075c5, 3190, flag3);
			break;
		}
		case x875aca5784596b73.xe7047c23118df3f9:
		{
			int xcfaa4292e98075c4 = xe134235b3526fa75.ReadUInt16();
			bool flag2 = !xe134235b3526fa75.ReadBoolean();
			x82ee2fb0c13b5ccc.x8e38d371def849c2(xcfaa4292e98075c4, 3180, flag2);
			break;
		}
		case x875aca5784596b73.xc97a97b699010560:
		{
			int xcfaa4292e98075c3 = xe134235b3526fa75.ReadUInt16();
			bool flag = xe134235b3526fa75.ReadBoolean();
			x82ee2fb0c13b5ccc.x8e38d371def849c2(xcfaa4292e98075c3, 3220, flag);
			break;
		}
		case x875aca5784596b73.x22e960eb8c924c14:
		{
			int xcfaa4292e98075c2 = xe134235b3526fa75.ReadUInt16();
			TextOrientation textOrientation = (TextOrientation)xe134235b3526fa75.ReadUInt16();
			x82ee2fb0c13b5ccc.x8e38d371def849c2(xcfaa4292e98075c2, 3050, textOrientation);
			break;
		}
		case x875aca5784596b73.xcf2758d7588bbebe:
		{
			int xcfaa4292e98075c = xe134235b3526fa75.ReadUInt16();
			CellVerticalAlignment cellVerticalAlignment = (CellVerticalAlignment)xe134235b3526fa75.ReadByte();
			x82ee2fb0c13b5ccc.x8e38d371def849c2(xcfaa4292e98075c, 3060, cellVerticalAlignment);
			break;
		}
		case x875aca5784596b73.x7e6e5d18c3231796:
			x82ee2fb0c13b5ccc.xdd21b05856a3d168();
			break;
		default:
			if (x28180b3c3774af93 != 0)
			{
				x3dc950453374051a($"Unknown formatting modifier 0x{(int)x28180b3c3774af93:x4} occurred while reading DOC file.");
			}
			return false;
		}
		return true;
	}

	private void xdeeab4ee20421f7a(int xba08ce632055a1d9, bool x7c4bd54fe1ef29c6)
	{
		if (x7c4bd54fe1ef29c6)
		{
			x263126e767bb1792(xba08ce632055a1d9);
		}
		else
		{
			x2640c2c8da422cb3(xba08ce632055a1d9);
		}
	}

	private void x578ff4ecf150579e(x875aca5784596b73 x28180b3c3774af93)
	{
		bool x7c4bd54fe1ef29c = x28180b3c3774af93 == x875aca5784596b73.x01a90f83a58e869a;
		xdeeab4ee20421f7a(4050, x7c4bd54fe1ef29c);
		xdeeab4ee20421f7a(4060, x7c4bd54fe1ef29c);
		xdeeab4ee20421f7a(4070, x7c4bd54fe1ef29c);
		xdeeab4ee20421f7a(4080, x7c4bd54fe1ef29c);
		xdeeab4ee20421f7a(4090, x7c4bd54fe1ef29c);
		xdeeab4ee20421f7a(4100, x7c4bd54fe1ef29c);
	}

	private void xf4c07e593d05bb15()
	{
		if (!x7450cc1e48712286.ReadBoolean())
		{
			return;
		}
		xedb0eb766e25e0c9 xedb0eb766e25e0c = (xedb0eb766e25e0c9)xedb0eb766e25e0c9.x5fb16e270c21db2e.xdf4bcc85da8f85b2;
		if (!xedb0eb766e25e0c.x263d579af1d0d43f(5100))
		{
			xdb4d596cc6b8659f xdb4d596cc6b8659f = new xdb4d596cc6b8659f();
			xedb0eb766e25e0c.xae20093bed1e48a8(5100, xdb4d596cc6b8659f);
			for (int i = 0; i < ((xedb0eb766e25e0c9)x66c02128fdc6436a).xeeac8c23df57dd1d.Count; i++)
			{
				xf8cef531dae89ea3 value = new xf8cef531dae89ea3();
				xdb4d596cc6b8659f.Add(value);
			}
		}
		x66c02128fdc6436a = xedb0eb766e25e0c;
	}

	private void x61d883fea6969649()
	{
		x7450cc1e48712286.ReadByte();
		x7450cc1e48712286.ReadByte();
		x8f1cf61f24a43e61 x8f1cf61f24a43e = (x8f1cf61f24a43e61)x7450cc1e48712286.ReadByte();
		PreferredWidth preferredWidth = xb87166435bc48cc2();
		if (x8f1cf61f24a43e == x8f1cf61f24a43e61.x2ae4473a93ca9b64 && preferredWidth.x08428aa3999da322)
		{
			x3dc950453374051a("Invalid cell spacing read, replaced with defaults.");
			x66c02128fdc6436a.xae20093bed1e48a8(4290, preferredWidth.xdf4645c89f0e47f6);
		}
	}

	private void x1e1fda2f04324fa5()
	{
		x7450cc1e48712286.ReadByte();
		x7450cc1e48712286.ReadByte();
		x8f1cf61f24a43e61 x8f1cf61f24a43e = (x8f1cf61f24a43e61)x7450cc1e48712286.ReadByte();
		PreferredWidth preferredWidth = xb87166435bc48cc2();
		int num;
		if (preferredWidth.x08428aa3999da322)
		{
			num = preferredWidth.xdf4645c89f0e47f6;
		}
		else
		{
			x3dc950453374051a("Invalid table padding spacing read, replaced with defaults.");
			x8f1cf61f24a43e &= x8f1cf61f24a43e61.x72d92bd1aff02e37 | x8f1cf61f24a43e61.x419ba17a5322627b;
			num = 0;
		}
		if ((x8f1cf61f24a43e & x8f1cf61f24a43e61.x72d92bd1aff02e37) != 0)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(base.x4de4e1e9aeaada1f ? 3090 : 4020, num);
		}
		if ((x8f1cf61f24a43e & x8f1cf61f24a43e61.xe360b1885d8d4a41) != 0)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(base.x4de4e1e9aeaada1f ? 3070 : 4300, num);
		}
		if ((x8f1cf61f24a43e & x8f1cf61f24a43e61.x9bcb07e204e30218) != 0)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(base.x4de4e1e9aeaada1f ? 3080 : 4310, num);
		}
		if ((x8f1cf61f24a43e & x8f1cf61f24a43e61.x419ba17a5322627b) != 0)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(base.x4de4e1e9aeaada1f ? 3100 : 4320, num);
		}
	}

	private static int x4c8ed3058a579838(x875aca5784596b73 x5f74831d836da0b2)
	{
		return x5f74831d836da0b2 switch
		{
			x875aca5784596b73.x0a7aa79eaeafac53 => 3150, 
			x875aca5784596b73.xe2a5907f328cfd4b => 3160, 
			x875aca5784596b73.x119b02fa92cbd30e => 3130, 
			x875aca5784596b73.x6629777538f3fdd4 => 3110, 
			x875aca5784596b73.xa3cc4daca8b86f4c => 3120, 
			x875aca5784596b73.xa406fc6c904fab76 => 3140, 
			x875aca5784596b73.xf4190574178a9824 => 3200, 
			x875aca5784596b73.x0c23be1fdf3fc243 => 3210, 
			_ => 0, 
		};
	}

	private PreferredWidth xb87166435bc48cc2()
	{
		PreferredWidthType x43163d22e8cd5a = (PreferredWidthType)x7450cc1e48712286.ReadByte();
		int x5b1c8ddab0846b = x7450cc1e48712286.ReadInt16();
		return PreferredWidth.x6b44e3efc21fd5b4(x43163d22e8cd5a, x5b1c8ddab0846b);
	}

	private void x955900cdfe72531d(int xba08ce632055a1d9)
	{
		PreferredWidth preferredWidth = xb87166435bc48cc2();
		if (preferredWidth.x08428aa3999da322)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(xba08ce632055a1d9, preferredWidth.xdf4645c89f0e47f6);
		}
	}

	protected override void WriteCore()
	{
		if (x355994d5a027a7ae)
		{
			x70d27912df6a71ba();
		}
		else
		{
			xc8fe59f2637587fd();
		}
	}

	private void xc8fe59f2637587fd()
	{
		x82ee2fb0c13b5ccc.xeeac8c23df57dd1d = xeeac8c23df57dd1d;
		x119a7971280a87d2(xf912b6413deb2a9a: false);
		if (xedb0eb766e25e0c9.xbc5dc59d0d9b620d(4020) && !base.x48388be4dc888d53)
		{
			x9b287b671d592594.xd776ae6f68bc4d9c(x875aca5784596b73.xd959dd2c7aa008cc, (xedb0eb766e25e0c9.xcad2e59522947ede + xedb0eb766e25e0c9.x41c99cca24bc80be) / 2);
		}
		x1226a978e5b06095();
		x8af4cf76757a2ae7(x875aca5784596b73.x1fca2c5def8b085d, 4040);
		xb3bb56a55b81f681(x7c4bd54fe1ef29c6: false);
		xad4abe09c7029566();
		x82ee2fb0c13b5ccc.x2f5c310a794eb2eb(base.x48388be4dc888d53, x8cedcaa9a62c6e39.x4e12a7dca3260989, x8cedcaa9a62c6e39.x34bbd3e888646999, xedb0eb766e25e0c9.x90aab2cbd2f48623);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.x9117cc40a2ec5d68);
		xbdc51cf157821ea1();
		xab5f6b7526efa5be(x875aca5784596b73.x44baafe534057c0b, 4380);
		x8911bca820bfab79(x875aca5784596b73.xdf2252b1742be249, 4150, 4160);
		x1ca1a6c61763ad66(x875aca5784596b73.x8cfe23976ee3209f, 4170, 4180, x063dc23d24025556: true);
		x21d53041f795334c(x875aca5784596b73.x5eb35e22b6a70c9d, 4190, 4200, x063dc23d24025556: true);
		xab5f6b7526efa5be(x875aca5784596b73.x7ae9067d0a5e6929, 4210);
		xab5f6b7526efa5be(x875aca5784596b73.x2edb444045966f11, 4220);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.x17c5d81674722d26);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.x55e4199f9d8c0034);
		xb3bb56a55b81f681(x7c4bd54fe1ef29c6: true);
		xc64c92cf02bbbc2b(x875aca5784596b73.x3d30e5a4e3e20843, 4230);
		x8af4cf76757a2ae7(x875aca5784596b73.x82add1e88b540b28, 4240);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.xeed7f2788f5fd860);
		xa44d6ca03ba4dda3(x875aca5784596b73.xf7daf20fe529fa5a, 4250);
		xa44d6ca03ba4dda3(x875aca5784596b73.xfb3f83aa5c420d35, 4260);
		x82ee2fb0c13b5ccc.xd1b6c75476692aff();
		xab5f6b7526efa5be(x875aca5784596b73.x8d3ea56ffb767cb4, 4270);
		xab5f6b7526efa5be(x875aca5784596b73.xc5cca07ea905051b, 4280);
		xa4487e396b4885c9.xc18fefd1c2317979(xeeac8c23df57dd1d, x875aca5784596b73.x94b69c8312e9a843, x82ee2fb0c13b5ccc);
		xcc817919573a5995.x76f56033ed683860(x9b287b671d592594, x875aca5784596b73.x6bc3b732a6f23770, x8f1cf61f24a43e61.x2ae4473a93ca9b64, xedb0eb766e25e0c9.xf7866f89640a29a3(4290));
		if (!base.x48388be4dc888d53)
		{
			xa4487e396b4885c9.xca30019ffb591c2f(xedb0eb766e25e0c9, x875aca5784596b73.x9fc257da11bc0f63, this);
		}
		x82ee2fb0c13b5ccc.x5ff6219674b44f13();
		x254ca7c3e16cd9eb(x875aca5784596b73.x7bfbca27661f65b1, 4330);
		xa44d6ca03ba4dda3(x875aca5784596b73.x985c511e1aae5008, 4340);
		x2ab845eb152478b4(x875aca5784596b73.x15dc82a2726b03d6, 4350);
		x2ab845eb152478b4(x875aca5784596b73.x7d28c9201219c923, 4360);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.x1834af1a4308ffef);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.xabcf0cc1786a4080);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.x7248ddb2334fa478);
		x6ff7c65ed4805c27(x875aca5784596b73.x23b80be40708ee83, 4400);
		xab5f6b7526efa5be(x875aca5784596b73.xe1840c23890aea9e, 4010);
		x9566f11596f04e72(x875aca5784596b73.x7a81d5c898fc7690, x875aca5784596b73.x2dece4956ef2a459);
	}

	private void x70d27912df6a71ba()
	{
		x82ee2fb0c13b5ccc.xeeac8c23df57dd1d = xeeac8c23df57dd1d;
		int num = (xedb0eb766e25e0c9.xcad2e59522947ede + xedb0eb766e25e0c9.x41c99cca24bc80be) / 2;
		x9b287b671d592594.xd776ae6f68bc4d9c(x875aca5784596b73.x45d84ee9b173b612, x8cedcaa9a62c6e39.x4e12a7dca3260989 + num + xedb0eb766e25e0c9.x90aab2cbd2f48623);
		x82ee2fb0c13b5ccc.xc48df985f627a09e(base.x48388be4dc888d53);
		x82ee2fb0c13b5ccc.x7022dda43ba0eb15(x7f9fd7171efccf23: false);
		xa4487e396b4885c9.xd25ac1f77750d4b5(xeeac8c23df57dd1d, 3010, x875aca5784596b73.x5e986dd230990edb, x82ee2fb0c13b5ccc);
		if (xbfda1ddadfbf0aa6())
		{
			x9b287b671d592594.xd776ae6f68bc4d9c(x875aca5784596b73.x847506dd874513a2, xedb0eb766e25e0c9.x8301ab10c226b0c2);
		}
		if (!base.x48388be4dc888d53 && num != 0)
		{
			x9b287b671d592594.xd776ae6f68bc4d9c(x875aca5784596b73.xd959dd2c7aa008cc, num);
		}
		x1226a978e5b06095();
		x8af4cf76757a2ae7(x875aca5784596b73.x1fca2c5def8b085d, 4040);
		xad4abe09c7029566();
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x8eea9678dfc771b5.xeeac8c23df57dd1d, x875aca5784596b73.x9117cc40a2ec5d68);
		xab5f6b7526efa5be(x875aca5784596b73.x44baafe534057c0b, 4380);
		xbdc51cf157821ea1();
		x8911bca820bfab79(x875aca5784596b73.xdf2252b1742be249, 4150, 4160);
		x1ca1a6c61763ad66(x875aca5784596b73.x8cfe23976ee3209f, 4170, 4180, x063dc23d24025556: true);
		x21d53041f795334c(x875aca5784596b73.x5eb35e22b6a70c9d, 4190, 4200, x063dc23d24025556: true);
		xab5f6b7526efa5be(x875aca5784596b73.x7ae9067d0a5e6929, 4210);
		xab5f6b7526efa5be(x875aca5784596b73.x2edb444045966f11, 4220);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x8eea9678dfc771b5.xeeac8c23df57dd1d, x875aca5784596b73.x17c5d81674722d26);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x8eea9678dfc771b5.xeeac8c23df57dd1d, x875aca5784596b73.x55e4199f9d8c0034);
		x82ee2fb0c13b5ccc.x7ed317b88c753dea();
		xb3bb56a55b81f681(x7c4bd54fe1ef29c6: true);
		xc64c92cf02bbbc2b(x875aca5784596b73.x3d30e5a4e3e20843, 4230);
		x8af4cf76757a2ae7(x875aca5784596b73.x82add1e88b540b28, 4240);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x8eea9678dfc771b5.xeeac8c23df57dd1d, x875aca5784596b73.xeed7f2788f5fd860);
		xa44d6ca03ba4dda3(x875aca5784596b73.xf7daf20fe529fa5a, 4250);
		xa44d6ca03ba4dda3(x875aca5784596b73.xfb3f83aa5c420d35, 4260);
		xa4487e396b4885c9.xd25ac1f77750d4b5(xeeac8c23df57dd1d, 3050, x875aca5784596b73.x22e960eb8c924c14, x82ee2fb0c13b5ccc);
		xa4487e396b4885c9.xd25ac1f77750d4b5(xeeac8c23df57dd1d, 3060, x875aca5784596b73.xcf2758d7588bbebe, x82ee2fb0c13b5ccc);
		xab5f6b7526efa5be(x875aca5784596b73.x8d3ea56ffb767cb4, 4270);
		xab5f6b7526efa5be(x875aca5784596b73.xc5cca07ea905051b, 4280);
		x82ee2fb0c13b5ccc.xbfffdf36c8911f8c();
		x82ee2fb0c13b5ccc.x7022dda43ba0eb15(x7f9fd7171efccf23: true);
		xa4487e396b4885c9.xd25ac1f77750d4b5(xeeac8c23df57dd1d, 3190, x875aca5784596b73.xddc39c60bdf04b05, x82ee2fb0c13b5ccc);
		xa4487e396b4885c9.xd25ac1f77750d4b5(xeeac8c23df57dd1d, 3180, x875aca5784596b73.xe7047c23118df3f9, x82ee2fb0c13b5ccc);
		xa4487e396b4885c9.xc18fefd1c2317979(xeeac8c23df57dd1d, x875aca5784596b73.x380cfba887094f8c, x82ee2fb0c13b5ccc, x9eeefdcbaf83e46f);
		xa4487e396b4885c9.xd25ac1f77750d4b5(xeeac8c23df57dd1d, 3220, x875aca5784596b73.xc97a97b699010560, x82ee2fb0c13b5ccc);
		x82ee2fb0c13b5ccc.x5ff6219674b44f13();
		x2ab845eb152478b4(x875aca5784596b73.x15dc82a2726b03d6, 4350);
		x9566f11596f04e72(x875aca5784596b73.x7a81d5c898fc7690, x875aca5784596b73.x2dece4956ef2a459);
		xa4487e396b4885c9.xc18fefd1c2317979(xeeac8c23df57dd1d, x875aca5784596b73.x94b69c8312e9a843, x82ee2fb0c13b5ccc);
		xcc817919573a5995.x76f56033ed683860(x9b287b671d592594, x875aca5784596b73.x6bc3b732a6f23770, x8f1cf61f24a43e61.x2ae4473a93ca9b64, xedb0eb766e25e0c9.xf7866f89640a29a3(4290));
		x254ca7c3e16cd9eb(x875aca5784596b73.x7bfbca27661f65b1, 4330);
		xa4487e396b4885c9.xca30019ffb591c2f(xedb0eb766e25e0c9, x875aca5784596b73.x9fc257da11bc0f63, this);
		x2ab845eb152478b4(x875aca5784596b73.x7d28c9201219c923, 4360);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.x1834af1a4308ffef);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.xabcf0cc1786a4080);
		x82ee2fb0c13b5ccc.x64efb227623ea3ff(x875aca5784596b73.x7248ddb2334fa478);
		xa44d6ca03ba4dda3(x875aca5784596b73.x985c511e1aae5008, 4340);
		x6ff7c65ed4805c27(x875aca5784596b73.x23b80be40708ee83, 4400);
		x119a7971280a87d2(xf912b6413deb2a9a: true);
	}

	private bool xe0f046416d89e24d()
	{
		for (int i = 0; i < xeeac8c23df57dd1d.Count; i++)
		{
			if (xeeac8c23df57dd1d.get_xe6d4b1b411ed94b5(i).x338a5e6ab7c5595e != 0 || xeeac8c23df57dd1d.get_xe6d4b1b411ed94b5(i).x1a1dda35b3ae703d != 0)
			{
				return true;
			}
		}
		return false;
	}

	private void x1226a978e5b06095()
	{
		if (xe0f046416d89e24d())
		{
			x9b287b671d592594.x9d91059a64953e89(x875aca5784596b73.xfb8395d572198618, xbcea506a33cf9111: true);
		}
		else
		{
			x2ab845eb152478b4(x875aca5784596b73.xfb8395d572198618, 4360);
		}
	}

	private bool xbfda1ddadfbf0aa6()
	{
		bool flag = true;
		return flag & !base.x48388be4dc888d53;
	}

	private static void x113035ffca5e6e23(CellCollection x77bb6a53fbd162d0, xedb0eb766e25e0c9 xe193ceb565ecaa0a, bool x6256d0d7b611e975)
	{
		xdb4d596cc6b8659f xdb4d596cc6b8659f = new xdb4d596cc6b8659f();
		xe193ceb565ecaa0a.xae20093bed1e48a8(5100, xdb4d596cc6b8659f);
		foreach (Cell item in x77bb6a53fbd162d0)
		{
			xdb4d596cc6b8659f.Add(x6256d0d7b611e975 ? item.xf8cef531dae89ea3.x75eab24f5629a618 : item.xf8cef531dae89ea3);
		}
	}

	private void x413a75acd2f37ae0(CellCollection x77bb6a53fbd162d0, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		if (!xe193ceb565ecaa0a.x0f53f53f15b61ef5)
		{
			return;
		}
		x5fb16e270c21db2e x5fb16e270c21db2e = xe193ceb565ecaa0a.x5fb16e270c21db2e;
		xedb0eb766e25e0c9 xedb0eb766e25e0c = (xedb0eb766e25e0c9)x5fb16e270c21db2e.xdf4bcc85da8f85b2;
		xdb4d596cc6b8659f xdb4d596cc6b8659f = new xdb4d596cc6b8659f();
		xedb0eb766e25e0c.xae20093bed1e48a8(5100, xdb4d596cc6b8659f);
		foreach (Cell item in x77bb6a53fbd162d0)
		{
			x5fb16e270c21db2e x5fb16e270c21db2e2 = item.xf8cef531dae89ea3.x5fb16e270c21db2e;
			xdb4d596cc6b8659f.Add((x5fb16e270c21db2e2 != null) ? x5fb16e270c21db2e2.xdf4bcc85da8f85b2 : x79882c75cde6984a);
		}
	}

	private x32939c68497cb083 xeecb429619e58d29(int x31a47fa9d0eb2c40)
	{
		x9b287b671d592594.BaseStream.Position = 0L;
		x9b287b671d592594.x138617e45a6d57be(x875aca5784596b73.xe300e699444c1f39, x31a47fa9d0eb2c40);
		return new x32939c68497cb083(x6ca2fe3c7f213f3e());
	}

	private void x119a7971280a87d2(bool xf912b6413deb2a9a)
	{
		object obj = xedb0eb766e25e0c9.xf7866f89640a29a3(4010);
		if (obj != null)
		{
			if (xedb0eb766e25e0c9.xcedf9c82728ad579)
			{
				obj = xedb0eb766e25e0c9.xbf8ba56877f02689((TableAlignment)obj);
			}
			x9b287b671d592594.xd776ae6f68bc4d9c(xf912b6413deb2a9a ? x875aca5784596b73.xe1840c23890aea9e : x875aca5784596b73.x547e8f141bf79388, (int)obj);
		}
	}

	private void xb3bb56a55b81f681(bool x7c4bd54fe1ef29c6)
	{
		if (xedb0eb766e25e0c9.xc8908f2ec0165580)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x7c4bd54fe1ef29c6 ? x875aca5784596b73.x01a90f83a58e869a : x875aca5784596b73.xa056fbb8a5fcb368);
			x9b287b671d592594.Write((byte)(x1df55585ec1be056.x97fb3720381ebd96(x7c4bd54fe1ef29c6) * 6));
			x1df55585ec1be056.x6210059f049f0d48(xedb0eb766e25e0c9.xa8c2637cc4888928, x9b287b671d592594, x10e248b4013349b1: false, x7c4bd54fe1ef29c6);
			x1df55585ec1be056.x6210059f049f0d48(xedb0eb766e25e0c9.xaea087ab32102492, x9b287b671d592594, x10e248b4013349b1: false, x7c4bd54fe1ef29c6);
			x1df55585ec1be056.x6210059f049f0d48(xedb0eb766e25e0c9.x79d902473861f242, x9b287b671d592594, x10e248b4013349b1: false, x7c4bd54fe1ef29c6);
			x1df55585ec1be056.x6210059f049f0d48(xedb0eb766e25e0c9.xd7a21e27974f626c, x9b287b671d592594, x10e248b4013349b1: false, x7c4bd54fe1ef29c6);
			x1df55585ec1be056.x6210059f049f0d48(xedb0eb766e25e0c9.x8ef7f9589a0a0945, x9b287b671d592594, x10e248b4013349b1: false, x7c4bd54fe1ef29c6);
			x1df55585ec1be056.x6210059f049f0d48(xedb0eb766e25e0c9.xbccf8ac0eed2b937, x9b287b671d592594, x10e248b4013349b1: false, x7c4bd54fe1ef29c6);
		}
	}

	private void xad4abe09c7029566()
	{
		if (xedb0eb766e25e0c9.xbc5dc59d0d9b620d(4110) || xedb0eb766e25e0c9.xbc5dc59d0d9b620d(4120))
		{
			int num = xedb0eb766e25e0c9.xb0f146032f47c24e;
			if (xedb0eb766e25e0c9.x85e9ab4255d7e70c == HeightRule.Exactly)
			{
				num = -num;
			}
			x9b287b671d592594.xd776ae6f68bc4d9c(x875aca5784596b73.xeddee5f2d90a5550, num);
		}
	}

	private void xbdc51cf157821ea1()
	{
		if (!base.x48388be4dc888d53 && xedb0eb766e25e0c9.x4be85718a3fc5cac != TableStyleOptions.Default2003)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.x976d89bbdc0a95da);
			x9b287b671d592594.Write((short)0);
			x9b287b671d592594.Write((short)x4cf3b47199c96529.x48bdf8f97244c548(xedb0eb766e25e0c9.x4be85718a3fc5cac));
		}
	}

	private void xc64c92cf02bbbc2b(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		object obj = xedb0eb766e25e0c9.xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj != null)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x9035cf16181332fc);
			PreferredWidth preferredWidth = (PreferredWidth)obj;
			x9b287b671d592594.Write((byte)preferredWidth.Type);
			x9b287b671d592594.Write((short)preferredWidth.x7680505e84ce0354);
		}
	}

	private void xa44d6ca03ba4dda3(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		object obj = xedb0eb766e25e0c9.xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj != null)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x9035cf16181332fc);
			x9b287b671d592594.Write((byte)3);
			int num = (int)obj;
			x9b287b671d592594.Write((short)num);
		}
	}

	private void xbb29e875893772b3()
	{
		if (xedb0eb766e25e0c9.xce5b83b714f11fba.x08428aa3999da322)
		{
			int num = xedb0eb766e25e0c9.x90aab2cbd2f48623 + xedb0eb766e25e0c9.xd29e69906712391d;
			for (int i = 0; i < xedb0eb766e25e0c9.xeeac8c23df57dd1d.Count; i++)
			{
				num += xedb0eb766e25e0c9.xeeac8c23df57dd1d.get_xe6d4b1b411ed94b5(i).xdc1bf80853046136;
			}
			if (xedb0eb766e25e0c9.xce5b83b714f11fba.xdf4645c89f0e47f6 > num && xb277c46192ba7caa > 0)
			{
				xedb0eb766e25e0c9.x90aab2cbd2f48623 = xedb0eb766e25e0c9.xce5b83b714f11fba.xdf4645c89f0e47f6 - num;
			}
		}
	}
}
