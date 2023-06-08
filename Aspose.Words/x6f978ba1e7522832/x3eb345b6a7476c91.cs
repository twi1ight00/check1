using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;
using xa604c4d210ae0581;
using xf989f31a236ff98c;

namespace x6f978ba1e7522832;

internal class x3eb345b6a7476c91 : xf77fd3dab66c510a
{
	private const int x224a1c1ecf2aa0c9 = 22;

	private BinaryReader x7450cc1e48712286;

	private x354e9ebad65eecc8 x9b287b671d592594;

	private xdb4d596cc6b8659f x782f7267634bb170;

	private static readonly Shading x1e39ad914933b0e5 = new Shading();

	private static readonly Border xec22c1109bee774c = new Border();

	internal xdb4d596cc6b8659f xeeac8c23df57dd1d
	{
		get
		{
			return x782f7267634bb170;
		}
		set
		{
			x782f7267634bb170 = value;
		}
	}

	internal BinaryReader xf86de1bd2f396938
	{
		set
		{
			x7450cc1e48712286 = value;
		}
	}

	internal x354e9ebad65eecc8 x5aa326f374b3d0ef
	{
		set
		{
			x9b287b671d592594 = value;
		}
	}

	private int x2e3049bafd71a386(x875aca5784596b73 x28180b3c3774af93, x8f1cf61f24a43e61 x4f217665270fa928)
	{
		return x28180b3c3774af93 switch
		{
			x875aca5784596b73.x380cfba887094f8c => x564ba49ea294fd2b(x4f217665270fa928), 
			x875aca5784596b73.x94b69c8312e9a843 => xbe5e6a68450cf406(x4f217665270fa928), 
			_ => throw new InvalidOperationException($"Not implemented for {x28180b3c3774af93} value."), 
		};
	}

	int xf77fd3dab66c510a.x607ca7b6672ba4ae(x875aca5784596b73 x28180b3c3774af93, x8f1cf61f24a43e61 x4f217665270fa928)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x2e3049bafd71a386
		return this.x2e3049bafd71a386(x28180b3c3774af93, x4f217665270fa928);
	}

	private void xbf1d99489325c72d(x875aca5784596b73 x28180b3c3774af93, int x62584df2cb5d40dd, int xd0af4642d624ddbd, x8f1cf61f24a43e61 x2356aaca890347a5, object xbcea506a33cf9111)
	{
		switch (x28180b3c3774af93)
		{
		case x875aca5784596b73.x22e960eb8c924c14:
		{
			TextOrientation textOrientation = (TextOrientation)xbcea506a33cf9111;
			if (textOrientation != 0)
			{
				x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.x22e960eb8c924c14);
				x9b287b671d592594.Write((byte)x62584df2cb5d40dd);
				x9b287b671d592594.Write((byte)xd0af4642d624ddbd);
				x9b287b671d592594.Write((ushort)textOrientation);
			}
			break;
		}
		case x875aca5784596b73.xcf2758d7588bbebe:
		{
			CellVerticalAlignment cellVerticalAlignment = (CellVerticalAlignment)xbcea506a33cf9111;
			if (cellVerticalAlignment != 0)
			{
				x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.xcf2758d7588bbebe);
				x9b287b671d592594.Write((byte)3);
				x9b287b671d592594.Write((byte)x62584df2cb5d40dd);
				x9b287b671d592594.Write((byte)xd0af4642d624ddbd);
				x9b287b671d592594.Write((byte)cellVerticalAlignment);
			}
			break;
		}
		case x875aca5784596b73.xddc39c60bdf04b05:
			if ((bool)xbcea506a33cf9111)
			{
				x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.xddc39c60bdf04b05);
				x9b287b671d592594.Write((byte)x62584df2cb5d40dd);
				x9b287b671d592594.Write((byte)xd0af4642d624ddbd);
				x9b287b671d592594.Write((byte)1);
			}
			break;
		case x875aca5784596b73.xc97a97b699010560:
			if ((bool)xbcea506a33cf9111)
			{
				x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.xc97a97b699010560);
				x9b287b671d592594.Write((byte)3);
				x9b287b671d592594.Write((byte)x62584df2cb5d40dd);
				x9b287b671d592594.Write((byte)xd0af4642d624ddbd);
				x9b287b671d592594.Write((byte)1);
			}
			break;
		case x875aca5784596b73.xe7047c23118df3f9:
			if (!(bool)xbcea506a33cf9111)
			{
				x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.xe7047c23118df3f9);
				x9b287b671d592594.Write((byte)3);
				x9b287b671d592594.Write((byte)x62584df2cb5d40dd);
				x9b287b671d592594.Write((byte)xd0af4642d624ddbd);
				x9b287b671d592594.Write((byte)1);
			}
			break;
		case x875aca5784596b73.x380cfba887094f8c:
			x4d2a08efa110f18f(x62584df2cb5d40dd, xd0af4642d624ddbd, (Border)xbcea506a33cf9111, x2356aaca890347a5, x875aca5784596b73.x380cfba887094f8c);
			break;
		case x875aca5784596b73.x5e986dd230990edb:
		{
			int num = (int)xbcea506a33cf9111;
			x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.x5e986dd230990edb);
			x9b287b671d592594.Write((byte)x62584df2cb5d40dd);
			x9b287b671d592594.Write((byte)xd0af4642d624ddbd);
			x9b287b671d592594.Write((short)num);
			break;
		}
		case x875aca5784596b73.x94b69c8312e9a843:
			xcc817919573a5995.x76f56033ed683860(x9b287b671d592594, x875aca5784596b73.x94b69c8312e9a843, x62584df2cb5d40dd, xd0af4642d624ddbd, x2356aaca890347a5, (int)xbcea506a33cf9111);
			break;
		case x875aca5784596b73.xe4ade3f63c788219:
			x796dd24c5e188868(x62584df2cb5d40dd, xd0af4642d624ddbd, (int)x782f7267634bb170.get_xe6d4b1b411ed94b5(x62584df2cb5d40dd).xce5b83b714f11fba.Type, x782f7267634bb170.get_xe6d4b1b411ed94b5(x62584df2cb5d40dd).xce5b83b714f11fba.x7680505e84ce0354);
			break;
		default:
			throw new InvalidOperationException($"Not implemented for {x28180b3c3774af93} value.");
		}
	}

	void xf77fd3dab66c510a.xe9decf879352095e(x875aca5784596b73 x28180b3c3774af93, int x62584df2cb5d40dd, int xd0af4642d624ddbd, x8f1cf61f24a43e61 x2356aaca890347a5, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xbf1d99489325c72d
		this.xbf1d99489325c72d(x28180b3c3774af93, x62584df2cb5d40dd, xd0af4642d624ddbd, x2356aaca890347a5, xbcea506a33cf9111);
	}

	internal void x8e38d371def849c2(int xcfaa4292e98075c6, int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (x782f7267634bb170 != null)
		{
			int val = xcfaa4292e98075c6 & 0xFF;
			int val2 = xcfaa4292e98075c6 >> 8;
			val = Math.Min(val, x782f7267634bb170.Count);
			val2 = Math.Min(val2, x782f7267634bb170.Count);
			for (int i = val; i < val2; i++)
			{
				x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
			}
		}
	}

	internal void x6cc32ac1ecd2a523(xedb0eb766e25e0c9 xe193ceb565ecaa0a, int x0d4f7f21e78721d6, x3a9e25666c8d1ee1 x4debd6958bcd2b55)
	{
		x782f7267634bb170 = new xdb4d596cc6b8659f();
		xe193ceb565ecaa0a.xae20093bed1e48a8(5100, x782f7267634bb170);
		int num = (int)x7450cc1e48712286.BaseStream.Position;
		int num2 = x7450cc1e48712286.ReadByte();
		int[] array = new int[num2 + 1];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = x7450cc1e48712286.ReadInt16();
		}
		xe193ceb565ecaa0a.xae20093bed1e48a8(5102, array[0]);
		for (int j = 0; j < num2; j++)
		{
			xf8cef531dae89ea3 xf8cef531dae89ea = new xf8cef531dae89ea3();
			int num3 = (int)x7450cc1e48712286.BaseStream.Position - num;
			if (num3 < x0d4f7f21e78721d6)
			{
				xcc817919573a5995.x06b0e25aa6ad68a9(x7450cc1e48712286, xf8cef531dae89ea);
			}
			int xf6495da3f9ed2d9c = (xf8cef531dae89ea.xdc1bf80853046136 = array[j + 1] - array[j]);
			if (x4debd6958bcd2b55 <= x3a9e25666c8d1ee1.xe3cb3ab95828933e)
			{
				xf8cef531dae89ea.xce5b83b714f11fba = PreferredWidth.xf6bcf515ffcb5cc9(xf6495da3f9ed2d9c);
			}
			else if (x4debd6958bcd2b55 <= x3a9e25666c8d1ee1.x6078bd5cfc666c9f && !xf8cef531dae89ea.x263d579af1d0d43f(3020))
			{
				xf8cef531dae89ea.xce5b83b714f11fba = PreferredWidth.xf6bcf515ffcb5cc9(xf6495da3f9ed2d9c);
			}
			x782f7267634bb170.Add(xf8cef531dae89ea);
		}
	}

	internal void xc8938b67bfbe60c3(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		x782f7267634bb170 = new xdb4d596cc6b8659f();
		xe193ceb565ecaa0a.xae20093bed1e48a8(5100, x782f7267634bb170);
		int num = x7450cc1e48712286.ReadByte();
		int num2 = x7450cc1e48712286.ReadByte();
		int xdc1bf80853046136 = x7450cc1e48712286.ReadInt16();
		for (int i = num; i < num2; i++)
		{
			xf8cef531dae89ea3 xf8cef531dae89ea = new xf8cef531dae89ea3();
			xf8cef531dae89ea.xae20093bed1e48a8(3060, CellVerticalAlignment.Top);
			xf8cef531dae89ea.xae20093bed1e48a8(3180, true);
			xf8cef531dae89ea.xdc1bf80853046136 = xdc1bf80853046136;
			x782f7267634bb170.Add(xf8cef531dae89ea);
		}
	}

	internal void xdd21b05856a3d168()
	{
		int num = x7450cc1e48712286.ReadByte();
		int val = x7450cc1e48712286.ReadByte();
		val = Math.Min(val, x782f7267634bb170.Count);
		x782f7267634bb170.get_xe6d4b1b411ed94b5(num).xae20093bed1e48a8(3040, CellMerge.First);
		for (int i = num + 1; i < val; i++)
		{
			x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xae20093bed1e48a8(3040, CellMerge.Previous);
		}
	}

	internal void x2986430b97a5e6b0()
	{
		int xc0c4c459c6ccbd = x7450cc1e48712286.ReadByte();
		int num = x7450cc1e48712286.ReadByte();
		bool flag = num == 1;
		CellMerge cellMerge = ((num == 3) ? CellMerge.First : (flag ? CellMerge.Previous : CellMerge.None));
		x782f7267634bb170.get_xe6d4b1b411ed94b5(xc0c4c459c6ccbd).xae20093bed1e48a8(3030, cellMerge);
	}

	internal void xf738afa41d843b52()
	{
		int val = x7450cc1e48712286.ReadByte();
		int val2 = x7450cc1e48712286.ReadByte();
		x8f1cf61f24a43e61 x8f1cf61f24a43e62 = (x8f1cf61f24a43e61)x7450cc1e48712286.ReadByte();
		PreferredWidth preferredWidth = xb87166435bc48cc2(x7450cc1e48712286);
		if (!preferredWidth.x08428aa3999da322)
		{
			return;
		}
		val = Math.Min(val, x782f7267634bb170.Count);
		val2 = Math.Min(val2, x782f7267634bb170.Count);
		int xdf4645c89f0e47f = preferredWidth.xdf4645c89f0e47f6;
		for (int i = val; i < val2; i++)
		{
			xf8cef531dae89ea3 xf8cef531dae89ea = x782f7267634bb170.get_xe6d4b1b411ed94b5(i);
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.x72d92bd1aff02e37) != 0)
			{
				xf8cef531dae89ea.xae20093bed1e48a8(3090, xdf4645c89f0e47f);
			}
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.xe360b1885d8d4a41) != 0)
			{
				xf8cef531dae89ea.xae20093bed1e48a8(3070, xdf4645c89f0e47f);
			}
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.x9bcb07e204e30218) != 0)
			{
				xf8cef531dae89ea.xae20093bed1e48a8(3080, xdf4645c89f0e47f);
			}
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.x419ba17a5322627b) != 0)
			{
				xf8cef531dae89ea.xae20093bed1e48a8(3100, xdf4645c89f0e47f);
			}
		}
	}

	internal void x08855b6cb54aed5c(x875aca5784596b73 x28180b3c3774af93, int x0d4f7f21e78721d6)
	{
		if (x28180b3c3774af93 == x875aca5784596b73.x9117cc40a2ec5d68)
		{
			int num = x0d4f7f21e78721d6 / 2;
			for (int i = 0; i < num; i++)
			{
				x8e2bd36fcdee9a28(x7450cc1e48712286, x782f7267634bb170.get_xe6d4b1b411ed94b5(i), x28180b3c3774af93);
			}
			return;
		}
		switch (x0d4f7f21e78721d6 % 10)
		{
		case 4:
			x0d4f7f21e78721d6 += 256;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("okmdnmdebnkeombfphifpmpfbmgghlnghlehjllhllcibljihgajnkhjpkojoffkalmkgkdlakklakbmojimdkpmhjgngennjieopilopicphijpihaaiihabdoahhfbohmbicdckgkcahbdcgidlgpdoggeegnehgeffflfpfcgpejgleahcbhh", 1652636779)));
		case 0:
			break;
		}
		int num2 = x0e2b62cd3c1d873d(x28180b3c3774af93) * 22;
		int num3 = x0d4f7f21e78721d6 / 10;
		int num4 = num2 + num3;
		for (int j = num2; j < num4; j++)
		{
			x8e2bd36fcdee9a28(x7450cc1e48712286, x782f7267634bb170.get_xe6d4b1b411ed94b5(j), x28180b3c3774af93);
		}
	}

	internal void xb33f778ead2893c4(int x0d4f7f21e78721d6)
	{
		int num = x0d4f7f21e78721d6 / 4;
		for (int i = 0; i < num; i++)
		{
			xf8cef531dae89ea3 x51dd02ffcbaa972d = x782f7267634bb170.get_xe6d4b1b411ed94b5(i);
			x6c3cb69d45279441(x51dd02ffcbaa972d, 3110, (LineStyle)x7450cc1e48712286.ReadByte());
			x6c3cb69d45279441(x51dd02ffcbaa972d, 3120, (LineStyle)x7450cc1e48712286.ReadByte());
			x6c3cb69d45279441(x51dd02ffcbaa972d, 3130, (LineStyle)x7450cc1e48712286.ReadByte());
			x6c3cb69d45279441(x51dd02ffcbaa972d, 3140, (LineStyle)x7450cc1e48712286.ReadByte());
		}
	}

	internal void xce2f85544b004e38(x875aca5784596b73 x28180b3c3774af93)
	{
		int val = x7450cc1e48712286.ReadByte();
		int val2 = x7450cc1e48712286.ReadByte();
		x8f1cf61f24a43e61 x8f1cf61f24a43e62 = (x8f1cf61f24a43e61)x7450cc1e48712286.ReadByte();
		Border x14cf9593b86ecbaa = ((x28180b3c3774af93 == x875aca5784596b73.x380cfba887094f8c) ? x1df55585ec1be056.x9b448ca00ed9c929(x7450cc1e48712286, null) : x1df55585ec1be056.x002fafae3e338912(x7450cc1e48712286, null));
		val = Math.Min(val, x782f7267634bb170.Count);
		val2 = Math.Min(val2, x782f7267634bb170.Count);
		for (int i = val; i < val2; i++)
		{
			xf8cef531dae89ea3 x51dd02ffcbaa972d = x782f7267634bb170.get_xe6d4b1b411ed94b5(i);
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.x72d92bd1aff02e37) != 0)
			{
				x2cf1761602871e10(x51dd02ffcbaa972d, 3120, x14cf9593b86ecbaa);
			}
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.xe360b1885d8d4a41) != 0)
			{
				x2cf1761602871e10(x51dd02ffcbaa972d, 3110, x14cf9593b86ecbaa);
			}
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.x9bcb07e204e30218) != 0)
			{
				x2cf1761602871e10(x51dd02ffcbaa972d, 3130, x14cf9593b86ecbaa);
			}
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.x419ba17a5322627b) != 0)
			{
				x2cf1761602871e10(x51dd02ffcbaa972d, 3140, x14cf9593b86ecbaa);
			}
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.x694a7e0cabea79b6) != 0)
			{
				x2cf1761602871e10(x51dd02ffcbaa972d, 3150, x14cf9593b86ecbaa);
			}
			if ((x8f1cf61f24a43e62 & x8f1cf61f24a43e61.xc22f71a5b8ad0027) != 0)
			{
				x2cf1761602871e10(x51dd02ffcbaa972d, 3160, x14cf9593b86ecbaa);
			}
		}
	}

	internal void xc1ad5d1e500cd4d9(x875aca5784596b73 x28180b3c3774af93, int x0d4f7f21e78721d6)
	{
		int xba08ce632055a1d = 0;
		switch (x28180b3c3774af93)
		{
		case x875aca5784596b73.x823ea0c39409cbf4:
			xba08ce632055a1d = 3110;
			break;
		case x875aca5784596b73.xc5f03c1e3457ac2a:
			xba08ce632055a1d = 3130;
			break;
		case x875aca5784596b73.xb14da3b9b9b29bdc:
			xba08ce632055a1d = 3120;
			break;
		case x875aca5784596b73.xb70638f89b996acf:
			xba08ce632055a1d = 3140;
			break;
		}
		int num = x0d4f7f21e78721d6 / 4;
		for (int i = 0; i < num; i++)
		{
			int xf5b6377cba = x7450cc1e48712286.ReadInt32();
			if (x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xbc5dc59d0d9b620d(xba08ce632055a1d))
			{
				Border border = (Border)x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xfe91eeeafcb3026a(xba08ce632055a1d);
				border.x63b1a7c31a962459 = x195cb055715b526e.xfa7086ee0c6b6330(xf5b6377cba);
			}
		}
	}

	internal void xc48df985f627a09e(bool x63e5f130e6c83531)
	{
		if (!x63e5f130e6c83531)
		{
			x9b287b671d592594.x138617e45a6d57be(x875aca5784596b73.x8b67f322c0d8cfe2, (xeeac8c23df57dd1d.Count << 8) + 23592960);
		}
	}

	internal void x7ed317b88c753dea()
	{
		int num = -1;
		for (int i = 0; i < x782f7267634bb170.Count; i++)
		{
			CellMerge x338a5e6ab7c5595e = x782f7267634bb170.get_xe6d4b1b411ed94b5(i).x338a5e6ab7c5595e;
			if (x338a5e6ab7c5595e == CellMerge.First || x338a5e6ab7c5595e == CellMerge.None)
			{
				if (num >= 0)
				{
					x3ee1b39aee6af76a(num, i);
				}
				num = ((x338a5e6ab7c5595e == CellMerge.First) ? i : (-1));
			}
		}
		if (num >= 0)
		{
			x3ee1b39aee6af76a(num, x782f7267634bb170.Count);
		}
	}

	internal void x7022dda43ba0eb15(bool x7f9fd7171efccf23)
	{
		if (x7f9fd7171efccf23)
		{
			xa4487e396b4885c9.xd25ac1f77750d4b5(x782f7267634bb170, 3020, x875aca5784596b73.xe4ade3f63c788219, this);
			return;
		}
		for (int i = 0; i < x782f7267634bb170.Count; i++)
		{
			if (x782f7267634bb170.get_xe6d4b1b411ed94b5(i).x263d579af1d0d43f(3020))
			{
				x796dd24c5e188868(i, i + 1, 3, x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xdc1bf80853046136);
			}
		}
	}

	internal void xbfffdf36c8911f8c()
	{
		for (int i = 0; i < x782f7267634bb170.Count; i++)
		{
			if (x782f7267634bb170.get_xe6d4b1b411ed94b5(i).x1a1dda35b3ae703d == CellMerge.First)
			{
				xddca4f3cb12c9f88(i, 3);
			}
			else if (x782f7267634bb170.get_xe6d4b1b411ed94b5(i).x1a1dda35b3ae703d == CellMerge.Previous)
			{
				xddca4f3cb12c9f88(i, 1);
			}
		}
	}

	internal void x64efb227623ea3ff(xdb4d596cc6b8659f x62947fad1bd23bff, x875aca5784596b73 x28180b3c3774af93)
	{
		xdb4d596cc6b8659f xdb4d596cc6b8659f = x782f7267634bb170;
		x782f7267634bb170 = x62947fad1bd23bff;
		x64efb227623ea3ff(x28180b3c3774af93);
		x782f7267634bb170 = xdb4d596cc6b8659f;
	}

	internal void x64efb227623ea3ff(x875aca5784596b73 x28180b3c3774af93)
	{
		if (!x9048f7c108db5ecd(x28180b3c3774af93))
		{
			return;
		}
		int num = x0e2b62cd3c1d873d(x28180b3c3774af93);
		bool flag = x28180b3c3774af93 != x875aca5784596b73.x9117cc40a2ec5d68;
		int num2;
		int num3;
		if (flag)
		{
			num2 = num * 22;
			if (num2 >= x782f7267634bb170.Count)
			{
				return;
			}
			num3 = Math.Min(x782f7267634bb170.Count, (num + 1) * 22);
		}
		else
		{
			num2 = 0;
			num3 = x782f7267634bb170.Count;
		}
		int num4 = num3 - num2;
		int num5 = num4 * x075263c82f5cad54.x97fb3720381ebd96(flag);
		if (num5 > 220)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ncpcmegdafndneeeopkeoecfaejfgdaggdhgidogkdfhadmhgocigdkiadbjpcijhcpjhnfknbnkecelomklpbcmhbjmebancmgnlaonlafohamonpcpbmjp", 1229270762)));
		}
		x9b287b671d592594.x3a52c4e37999b16e(x28180b3c3774af93);
		x9b287b671d592594.Write((byte)num5);
		for (int i = num2; i < num3; i++)
		{
			Shading shading = (Shading)x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xf7866f89640a29a3(3170);
			if (shading == null || shading.xa157de8185757b11)
			{
				shading = x1e39ad914933b0e5;
			}
			x075263c82f5cad54.x6210059f049f0d48(shading, x9b287b671d592594, flag);
		}
	}

	private static int x0e2b62cd3c1d873d(x875aca5784596b73 x28180b3c3774af93)
	{
		switch (x28180b3c3774af93)
		{
		case x875aca5784596b73.x9117cc40a2ec5d68:
		case x875aca5784596b73.x55e4199f9d8c0034:
		case x875aca5784596b73.x1834af1a4308ffef:
			return 0;
		case x875aca5784596b73.xeed7f2788f5fd860:
		case x875aca5784596b73.xabcf0cc1786a4080:
			return 1;
		case x875aca5784596b73.x17c5d81674722d26:
		case x875aca5784596b73.x7248ddb2334fa478:
			return 2;
		default:
			throw new InvalidOperationException("Unknown sprm code.");
		}
	}

	private bool x9048f7c108db5ecd(x875aca5784596b73 x28180b3c3774af93)
	{
		int num = x0e2b62cd3c1d873d(x28180b3c3774af93);
		int num2 = num * 22;
		int num3 = Math.Min(x782f7267634bb170.Count, (num + 1) * 22);
		for (int i = num2; i < num3; i++)
		{
			if (x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xbc5dc59d0d9b620d(3170))
			{
				return true;
			}
		}
		return false;
	}

	internal void x2f5c310a794eb2eb(bool x8275ecc069245efa, int x45cc703590eb0826, int x732262e16ed80c94, int x16dec284c7e3e3da)
	{
		x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.x79d0fad9e29c9f31);
		int num = 1 + (x782f7267634bb170.Count + 1) * 2 + x782f7267634bb170.Count * 20 + 1;
		x9b287b671d592594.Write((short)num);
		x9b287b671d592594.Write((byte)x782f7267634bb170.Count);
		int num2 = (x8275ecc069245efa ? x732262e16ed80c94 : x45cc703590eb0826) + x16dec284c7e3e3da;
		x9b287b671d592594.Write((short)num2);
		for (int i = 0; i < x782f7267634bb170.Count; i++)
		{
			num2 += x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xdc1bf80853046136;
			x9b287b671d592594.Write((short)num2);
		}
		for (int j = 0; j < x782f7267634bb170.Count; j++)
		{
			xcc817919573a5995.x6210059f049f0d48(x782f7267634bb170.get_xe6d4b1b411ed94b5(j), x9b287b671d592594);
		}
	}

	internal void xd1b6c75476692aff()
	{
		xd1b6c75476692aff(x875aca5784596b73.x823ea0c39409cbf4, 3110);
		xd1b6c75476692aff(x875aca5784596b73.xb14da3b9b9b29bdc, 3120);
		xd1b6c75476692aff(x875aca5784596b73.xc5f03c1e3457ac2a, 3130);
		xd1b6c75476692aff(x875aca5784596b73.xb70638f89b996acf, 3140);
	}

	private void xd1b6c75476692aff(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		if (x782f7267634bb170 == null)
		{
			return;
		}
		x9b287b671d592594.x3a52c4e37999b16e(x9035cf16181332fc);
		x9b287b671d592594.Write((byte)(x782f7267634bb170.Count * 4));
		for (int i = 0; i < x782f7267634bb170.Count; i++)
		{
			Border border = (Border)x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xf7866f89640a29a3(xba08ce632055a1d9);
			if (border == null || border.xa157de8185757b11)
			{
				border = xec22c1109bee774c;
			}
			x9b287b671d592594.Write(x195cb055715b526e.x103636c839f725d7(border.x63b1a7c31a962459));
		}
	}

	private void x796dd24c5e188868(int x62584df2cb5d40dd, int xd0af4642d624ddbd, int x43163d22e8cd5a71, int x9b0739496f8b5475)
	{
		x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.xe4ade3f63c788219);
		x9b287b671d592594.Write((byte)5);
		x9b287b671d592594.Write((byte)x62584df2cb5d40dd);
		x9b287b671d592594.Write((byte)xd0af4642d624ddbd);
		x9b287b671d592594.Write((byte)x43163d22e8cd5a71);
		x9b287b671d592594.Write((short)x9b0739496f8b5475);
	}

	private void x3ee1b39aee6af76a(int x62584df2cb5d40dd, int xd0af4642d624ddbd)
	{
		x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.x7e6e5d18c3231796);
		x9b287b671d592594.Write((byte)x62584df2cb5d40dd);
		x9b287b671d592594.Write((byte)xd0af4642d624ddbd);
	}

	private void xddca4f3cb12c9f88(int xc0c4c459c6ccbd00, int x83e8fad16b94df48)
	{
		x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.x9059482aee2e840b);
		x9b287b671d592594.Write((byte)2);
		x9b287b671d592594.Write((byte)xc0c4c459c6ccbd00);
		x9b287b671d592594.Write((byte)x83e8fad16b94df48);
	}

	internal void x5ff6219674b44f13()
	{
		if (x782f7267634bb170 != null)
		{
			for (int i = 0; i < x782f7267634bb170.Count; i++)
			{
				x4d2a08efa110f18f(i, i + 1, (Border)x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xf7866f89640a29a3(3150), x8f1cf61f24a43e61.x694a7e0cabea79b6, x875aca5784596b73.x4ac67d9c794ef0e6);
				x4d2a08efa110f18f(i, i + 1, (Border)x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xf7866f89640a29a3(3150), x8f1cf61f24a43e61.x694a7e0cabea79b6, x875aca5784596b73.x380cfba887094f8c);
				x4d2a08efa110f18f(i, i + 1, (Border)x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xf7866f89640a29a3(3160), x8f1cf61f24a43e61.xc22f71a5b8ad0027, x875aca5784596b73.x4ac67d9c794ef0e6);
				x4d2a08efa110f18f(i, i + 1, (Border)x782f7267634bb170.get_xe6d4b1b411ed94b5(i).xf7866f89640a29a3(3160), x8f1cf61f24a43e61.xc22f71a5b8ad0027, x875aca5784596b73.x380cfba887094f8c);
			}
		}
	}

	private void x4d2a08efa110f18f(int x62584df2cb5d40dd, int xd0af4642d624ddbd, Border x14cf9593b86ecbaa, x8f1cf61f24a43e61 x4f217665270fa928, x875aca5784596b73 x28180b3c3774af93)
	{
		if (x14cf9593b86ecbaa != null)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x28180b3c3774af93);
			int num = 3 + x1df55585ec1be056.x97fb3720381ebd96(x28180b3c3774af93 == x875aca5784596b73.x380cfba887094f8c);
			x9b287b671d592594.Write((byte)num);
			x9b287b671d592594.Write((byte)x62584df2cb5d40dd);
			x9b287b671d592594.Write((byte)xd0af4642d624ddbd);
			x9b287b671d592594.Write((byte)x4f217665270fa928);
			x1df55585ec1be056.x6210059f049f0d48(x14cf9593b86ecbaa.Equals(Border.x45260ad4b94166f2) ? null : x14cf9593b86ecbaa, x9b287b671d592594, x10e248b4013349b1: false, x28180b3c3774af93 == x875aca5784596b73.x380cfba887094f8c);
		}
	}

	private static void x8e2bd36fcdee9a28(BinaryReader xe134235b3526fa75, x7f77ea92be0d9042 xe9707cb1ec88db49, x875aca5784596b73 x28180b3c3774af93)
	{
		Shading x12b7f8e5698b30a = (Shading)xe9707cb1ec88db49.xf7866f89640a29a3(3170);
		Shading shading = ((x28180b3c3774af93 == x875aca5784596b73.x9117cc40a2ec5d68) ? x075263c82f5cad54.x002fafae3e338912(xe134235b3526fa75, x12b7f8e5698b30a) : x075263c82f5cad54.x9b448ca00ed9c929(xe134235b3526fa75, x12b7f8e5698b30a));
		if (shading != null)
		{
			xe9707cb1ec88db49.xae20093bed1e48a8(3170, shading);
		}
	}

	private static PreferredWidth xb87166435bc48cc2(BinaryReader xe134235b3526fa75)
	{
		PreferredWidthType x43163d22e8cd5a = (PreferredWidthType)xe134235b3526fa75.ReadByte();
		int x5b1c8ddab0846b = xe134235b3526fa75.ReadInt16();
		return PreferredWidth.x6b44e3efc21fd5b4(x43163d22e8cd5a, x5b1c8ddab0846b);
	}

	private static void x2cf1761602871e10(xf8cef531dae89ea3 x51dd02ffcbaa972d, int xad5ee812e0b28f28, Border x14cf9593b86ecbaa)
	{
		Border xbcea506a33cf = ((x14cf9593b86ecbaa == null) ? Border.x45260ad4b94166f2 : x14cf9593b86ecbaa.x8b61531c8ea35b85());
		x51dd02ffcbaa972d.xae20093bed1e48a8(xad5ee812e0b28f28, xbcea506a33cf);
	}

	private static void x6c3cb69d45279441(xf8cef531dae89ea3 x51dd02ffcbaa972d, int xba08ce632055a1d9, LineStyle x26516bbd7ae94699)
	{
		Border border = (Border)x51dd02ffcbaa972d.xf7866f89640a29a3(xba08ce632055a1d9);
		if (border != null)
		{
			border.LineStyle = x26516bbd7ae94699;
		}
	}

	private static int x564ba49ea294fd2b(x8f1cf61f24a43e61 x4f217665270fa928)
	{
		return x4f217665270fa928 switch
		{
			x8f1cf61f24a43e61.x72d92bd1aff02e37 => 3120, 
			x8f1cf61f24a43e61.x419ba17a5322627b => 3140, 
			x8f1cf61f24a43e61.xe360b1885d8d4a41 => 3110, 
			x8f1cf61f24a43e61.x9bcb07e204e30218 => 3130, 
			x8f1cf61f24a43e61.xc22f71a5b8ad0027 => 3160, 
			x8f1cf61f24a43e61.x694a7e0cabea79b6 => 3150, 
			_ => throw new InvalidOperationException(), 
		};
	}

	private static int xbe5e6a68450cf406(x8f1cf61f24a43e61 x4f217665270fa928)
	{
		switch (x4f217665270fa928)
		{
		case x8f1cf61f24a43e61.x72d92bd1aff02e37:
			return 3090;
		case x8f1cf61f24a43e61.x419ba17a5322627b:
			return 3100;
		case x8f1cf61f24a43e61.xe360b1885d8d4a41:
			return 3070;
		case x8f1cf61f24a43e61.x9bcb07e204e30218:
			return 3080;
		case x8f1cf61f24a43e61.x694a7e0cabea79b6:
		case x8f1cf61f24a43e61.xc22f71a5b8ad0027:
			return 0;
		default:
			throw new InvalidOperationException();
		}
	}
}
