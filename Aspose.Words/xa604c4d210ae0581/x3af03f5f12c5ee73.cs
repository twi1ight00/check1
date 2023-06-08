using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fonts;
using x2845e7a1a7dc898b;
using x28925c9b27b37a46;
using xf989f31a236ff98c;

namespace xa604c4d210ae0581;

internal class x3af03f5f12c5ee73 : x485adbf5506556e8, x456c8b07916a8790
{
	private readonly FontInfoCollection xcf7aa3cc906cdb68;

	private readonly xd503583b32a53cea x7ff04dd244132d8e;

	private xa52f2632c0ffdfaf x49f284ee51507f12;

	private bool xa1a17ff33f670675;

	private xeedad81aaed42a76 xeedad81aaed42a76 => (xeedad81aaed42a76)x66c02128fdc6436a;

	internal x3af03f5f12c5ee73(FontInfoCollection fontInfos, xd47c6c7442eb8033 revisionAuthors, IWarningCallback warningCallback)
		: base(revisionAuthors, warningCallback)
	{
		xcf7aa3cc906cdb68 = fontInfos;
		x7ff04dd244132d8e = new xd503583b32a53cea(this, null);
	}

	internal void x06b0e25aa6ad68a9(byte[] x24c45257571ea504, xeedad81aaed42a76 x789564759d365819, xa52f2632c0ffdfaf xbd40d7ce3aca91e3)
	{
		x66c02128fdc6436a = x789564759d365819;
		x49f284ee51507f12 = xbd40d7ce3aca91e3;
		x7ff04dd244132d8e.x06b0e25aa6ad68a9(x24c45257571ea504);
	}

	internal void xf75fc5b2f257a111(byte[] x24c45257571ea504, TableStyle x13eeaa19b4289a25)
	{
		xe5ef82d048062925 = x13eeaa19b4289a25;
		x66c02128fdc6436a = x13eeaa19b4289a25.xeedad81aaed42a76;
		x7ff04dd244132d8e.x06b0e25aa6ad68a9(x24c45257571ea504);
	}

	internal x9dba795deb731d48 x6210059f049f0d48(xeedad81aaed42a76 x789564759d365819, xa52f2632c0ffdfaf xbd40d7ce3aca91e3, bool x0463a6b206bbf7e4)
	{
		x49f284ee51507f12 = xbd40d7ce3aca91e3;
		xa1a17ff33f670675 = x0463a6b206bbf7e4;
		return new x9dba795deb731d48(x6210059f049f0d48(x789564759d365819));
	}

	internal byte[] x746ca66f5c31e314(TableStyle x44ecfea61c937b8e)
	{
		x9b287b671d592594.BaseStream.Position = 0L;
		x66c02128fdc6436a = x44ecfea61c937b8e.xeedad81aaed42a76;
		WriteCore();
		foreach (xe12ab2f55355c7f0 item in x44ecfea61c937b8e.x7205cb42c2f994a4)
		{
			if (item.xeedad81aaed42a76 != null)
			{
				long x30cc7819189f11b = x6d582d881359c5db(x875aca5784596b73.xd64a5a84c98ddebe, item.x3146d638ec378671);
				x66c02128fdc6436a = item.xeedad81aaed42a76;
				WriteCore();
				xdff84d5a65b9347a(x30cc7819189f11b);
			}
		}
		return x6ca2fe3c7f213f3e();
	}

	protected override void WriteCore()
	{
		if (!base.x4de4e1e9aeaada1f)
		{
			x66c02128fdc6436a.x43c6155e35f47d2b(16);
			x66c02128fdc6436a.x43c6155e35f47d2b(202);
		}
		x66c02128fdc6436a.x43c6155e35f47d2b(402);
		if (xa1a17ff33f670675)
		{
			x992a87e8a159fe04(x875aca5784596b73.x7cd2ca97e2c953b7, true);
		}
		try
		{
			for (int i = 0; i < x66c02128fdc6436a.xd44988f225497f3a; i++)
			{
				int num = x66c02128fdc6436a.xf15263674eb297bb(i);
				object obj = x66c02128fdc6436a.x6d3720b962bd3112(i);
				switch (num)
				{
				case 10:
					xdd694ce55709aeca(x875aca5784596b73.x85598a867b282f06, obj);
					break;
				case 12:
					xecb2d7893396dd84(xb014472551e4d416: false);
					break;
				case 14:
					xecb2d7893396dd84(xb014472551e4d416: true);
					break;
				case 16:
					if (x49f284ee51507f12 != null)
					{
						if (x49f284ee51507f12.xf1d9b91c9700c401 != -1)
						{
							x9b287b671d592594.x138617e45a6d57be(x875aca5784596b73.xf42be5458163cbdb, x49f284ee51507f12.xf1d9b91c9700c401);
						}
						if (x49f284ee51507f12.xc26441db92a14e8e)
						{
							x9b287b671d592594.x1680160a63ff3e0b(x875aca5784596b73.x0cd3293b128dd60c, 1);
						}
						if (x49f284ee51507f12.x1b36d8d878eccfb5)
						{
							x9b287b671d592594.x1680160a63ff3e0b(x875aca5784596b73.xfbe306582099ca65, 1);
						}
					}
					break;
				case 20:
					x6805c2c452bad830(x875aca5784596b73.x0c44978be03b06d9, obj);
					break;
				case 30:
					xdcd54ad49250a806(x875aca5784596b73.x897fe03bc942d051, obj);
					break;
				case 40:
					xdcd54ad49250a806(x875aca5784596b73.xabbd13c6a36f8059, obj);
					break;
				case 50:
					x2819fd3ae48985bb(x875aca5784596b73.xc8c2060bb9b3c0e0, obj);
					break;
				case 60:
					xdd694ce55709aeca(x875aca5784596b73.x04ef85548a953e94, obj);
					break;
				case 70:
					xdd694ce55709aeca(x875aca5784596b73.x7489e1c499f14ab9, obj);
					break;
				case 80:
					xdd694ce55709aeca(x875aca5784596b73.x72279532830ff2da, obj);
					break;
				case 90:
					xdd694ce55709aeca(x875aca5784596b73.x8ad382fe477c1c55, obj);
					break;
				case 100:
					xdd694ce55709aeca(x875aca5784596b73.xb17714aa9e1c3acb, obj);
					break;
				case 110:
					xdd694ce55709aeca(x875aca5784596b73.x84f4a5b9c2ad3bf4, obj);
					break;
				case 120:
					xdd694ce55709aeca(x875aca5784596b73.x68b25a9cd876eadf, obj);
					break;
				case 130:
					xdd694ce55709aeca(x875aca5784596b73.xc9d130da69374d65, obj);
					break;
				case 140:
					xdd694ce55709aeca(x875aca5784596b73.xd148ef22a9fad1eb, obj);
					break;
				case 150:
					x2819fd3ae48985bb(x875aca5784596b73.xefd4711a64aeb1df, obj);
					break;
				case 160:
					x6805c2c452bad830(x875aca5784596b73.x25f139f8f24a7039, obj);
					break;
				case 170:
					xdd694ce55709aeca(x875aca5784596b73.x7297db8347331c85, obj);
					break;
				case 180:
					xdd694ce55709aeca(x875aca5784596b73.x385326ed570b4642, obj);
					break;
				case 190:
					x2819fd3ae48985bb(x875aca5784596b73.x63cc2e207f723b7c, obj);
					break;
				case 200:
					x2819fd3ae48985bb(x875aca5784596b73.x5f2639ae8bc287ad, obj);
					break;
				case 202:
					if (x49f284ee51507f12 != null)
					{
						if (x49f284ee51507f12.xa1a25be53d0a44c8)
						{
							x9b287b671d592594.x1680160a63ff3e0b(x875aca5784596b73.xa5a319e04d77c344, 1);
						}
						if (x49f284ee51507f12.x9316383434e67238)
						{
							x9b287b671d592594.x1680160a63ff3e0b(x875aca5784596b73.xb8d6f385c91265f9, 1);
						}
					}
					break;
				case 210:
					xdd694ce55709aeca(x875aca5784596b73.x85b37cfcfdf39643, obj);
					break;
				case 220:
					x2819fd3ae48985bb(x875aca5784596b73.x34e5c3276f4c0905, obj);
					break;
				case 230:
					xc11827a6120faa8b(x875aca5784596b73.xf1e8157159ad64a2, obj);
					break;
				case 240:
					xc11827a6120faa8b(x875aca5784596b73.x8ffb9b2a88b78f25, obj);
					break;
				case 250:
					xdd694ce55709aeca(x875aca5784596b73.xfd605137c124a22a, obj);
					break;
				case 260:
					xdd694ce55709aeca(x875aca5784596b73.xfa2f0d701b1e042e, obj);
					break;
				case 270:
					xc11827a6120faa8b(x875aca5784596b73.x8c5db9e141338048, obj);
					break;
				case 235:
					xc11827a6120faa8b(x875aca5784596b73.x7e721aac6f79cc68, obj);
					break;
				case 290:
					x2819fd3ae48985bb(x875aca5784596b73.xaebe7047b7a976e1, obj);
					break;
				case 300:
					xdd694ce55709aeca(x875aca5784596b73.x6cab459f1b24b08e, obj);
					break;
				case 310:
					xdd694ce55709aeca(x875aca5784596b73.xa0297581a8c47d49, obj);
					break;
				case 265:
					xdd694ce55709aeca(x875aca5784596b73.x5d67e0590c6f3378, obj);
					break;
				case 268:
					xdd694ce55709aeca(x875aca5784596b73.x3cb3e787bc923efb, obj);
					break;
				case 330:
					xdd694ce55709aeca(x875aca5784596b73.x79a3fb0c19dbf1d5, obj);
					break;
				case 340:
					x2819fd3ae48985bb(x875aca5784596b73.x39531f3e22372d1e, obj);
					break;
				case 350:
					x2819fd3ae48985bb(x875aca5784596b73.x352b977b8f6aab7a, obj);
					break;
				case 360:
					xf4829300ee2ded8a(x875aca5784596b73.x3e1c6fae54c0e9a7, obj);
					break;
				case 370:
					xc8950caaebdd16ee(x875aca5784596b73.xabda0eac963906cf, obj);
					break;
				case 380:
					if (xeedad81aaed42a76.xf01bc3bed63a693e.x4e98cd0cf854343f())
					{
						x2819fd3ae48985bb(x875aca5784596b73.x7a1e4daa5822e1f5, 1024);
						x2819fd3ae48985bb(x875aca5784596b73.xcf91262979671195, 1024);
						break;
					}
					x2819fd3ae48985bb(x875aca5784596b73.x7a1e4daa5822e1f5, (int)obj);
					if (xeedad81aaed42a76.x2928b54f20b91723 != xeedad81aaed42a76.xbdfe108412062dd5)
					{
						x2819fd3ae48985bb(x875aca5784596b73.xcf91262979671195, xeedad81aaed42a76.xf7866f89640a29a3(390));
					}
					break;
				case 400:
					xdd694ce55709aeca(x875aca5784596b73.x2709657aa87b374f, obj);
					break;
				case 402:
					x61431dc20e80763f(x875aca5784596b73.xb9097619ef9f1bad, 160);
					x254ca7c3e16cd9eb(x875aca5784596b73.x8c63dce62e038bc8, 370);
					x5f45ba3056182cdb(x875aca5784596b73.xe77f715fb7a33e2e, 360);
					x2819fd3ae48985bb(x875aca5784596b73.xdd159e2c6d98aa54, xeedad81aaed42a76.xf7866f89640a29a3(380));
					x2819fd3ae48985bb(x875aca5784596b73.x8644bd61081df374, xeedad81aaed42a76.xf7866f89640a29a3(390));
					break;
				case 440:
					xdd694ce55709aeca(x875aca5784596b73.x8fedec6eb8e1e343, obj);
					break;
				case 450:
					xa79654a7a96ec0c8(x875aca5784596b73.xa082e87b24b9801e, obj);
					break;
				case 460:
					if (x66c02128fdc6436a.xbc5dc59d0d9b620d(460))
					{
						x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.x7efc32638ed2fbce);
						x7bc150a164904c56 x7bc150a164904c = (x7bc150a164904c56)x66c02128fdc6436a.xfe91eeeafcb3026a(460);
						x9b287b671d592594.Write((byte)x7bc150a164904c);
						int num2 = (int)x66c02128fdc6436a.xfe91eeeafcb3026a(470);
						x9b287b671d592594.Write((byte)num2);
					}
					break;
				case 480:
					xdcd54ad49250a806(x875aca5784596b73.xa55911b9412d53b6, obj);
					break;
				case 490:
					x2819fd3ae48985bb(x875aca5784596b73.x492c1f017f9de562, obj);
					break;
				case 45:
					xdd694ce55709aeca(x875aca5784596b73.x42dca843b80ab453, obj);
					break;
				case 770:
				{
					x4a2f68a519ee2183 x4a2f68a519ee = (x4a2f68a519ee2183)obj;
					if (x4a2f68a519ee != 0)
					{
						xdd694ce55709aeca(x875aca5784596b73.x2925e0472c062d8a, (byte)x4a2f68a519ee);
					}
					break;
				}
				case 780:
					x3df5c0539d1dc929((xf80d6ac0b6a56f39)obj);
					break;
				}
			}
			x9566f11596f04e72(x875aca5784596b73.xde03a93c114f3d2f, x875aca5784596b73.x252406cfbd84d909);
		}
		finally
		{
			if (!base.x4de4e1e9aeaada1f)
			{
				x66c02128fdc6436a.x52b190e626f65140(16);
				x66c02128fdc6436a.x52b190e626f65140(202);
			}
			x66c02128fdc6436a.x52b190e626f65140(402);
		}
	}

	private void xc11827a6120faa8b(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			string xc15bd84e = (string)xbcea506a33cf9111;
			x9b287b671d592594.xd776ae6f68bc4d9c(x9035cf16181332fc, base.x4de4e1e9aeaada1f ? xa188b1d3d8eee54e.x04327ff503798cdd(xc15bd84e) : xcf7aa3cc906cdb68.x04327ff503798cdd(xc15bd84e));
		}
	}

	private void xecb2d7893396dd84(bool xb014472551e4d416)
	{
		xc1b2bac943a0f541 xc1b2bac943a0f = (xb014472551e4d416 ? xeedad81aaed42a76.x18bb4aa7903ffced : xeedad81aaed42a76.x83da691dd3d974a6);
		if (xc1b2bac943a0f != null)
		{
			x9b287b671d592594.x1680160a63ff3e0b(xb014472551e4d416 ? x875aca5784596b73.x4e877f01b8a21c1b : x875aca5784596b73.x72da617e10f660fd, 129);
			int xbcea506a33cf = xaca3428582882d9d.x157cb2cfc16453ee(xc1b2bac943a0f.xb063bbfcfeade526);
			x9b287b671d592594.xd776ae6f68bc4d9c(xb014472551e4d416 ? x875aca5784596b73.xb99fb5cd3999932c : x875aca5784596b73.x59914329db95d0b0, xbcea506a33cf);
			x9b287b671d592594.x3a52c4e37999b16e(xb014472551e4d416 ? x875aca5784596b73.x35f91cd242dc536c : x875aca5784596b73.x34d501d3e0ce9d38);
			xed28c1e5772a17ea.x6210059f049f0d48(xc1b2bac943a0f.x242851e6278ed355, x9b287b671d592594);
		}
	}

	private bool x9b1a5fd2bd42bd55(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		if (xe780cde24dcce6f2 != x8de82539c936c298.x9db41a60ca0e46ee)
		{
			return true;
		}
		x7450cc1e48712286 = xe134235b3526fa75;
		switch (x28180b3c3774af93)
		{
		case x875aca5784596b73.xd64a5a84c98ddebe:
			x7da53fcf55413cb5(this, xe134235b3526fa75, x0d4f7f21e78721d6, x70d40b77e7fb14d0.x160a0bf4de8f6bd0);
			break;
		case x875aca5784596b73.x897fe03bc942d051:
			x66c02128fdc6436a.xae20093bed1e48a8(30, x7450cc1e48712286.ReadInt32());
			break;
		case x875aca5784596b73.xabbd13c6a36f8059:
			x66c02128fdc6436a.xae20093bed1e48a8(40, x7450cc1e48712286.ReadInt32());
			break;
		case x875aca5784596b73.xde7ecaeab87ad821:
			xd28f53fd94b9c0e4("Text formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.xfc00c664466b0380:
		case x875aca5784596b73.xff9fe4935b410864:
			xd28f53fd94b9c0e4("Text formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.x63cc2e207f723b7c:
		case x875aca5784596b73.xbcd101e6d700f407:
			x66c02128fdc6436a.xae20093bed1e48a8(190, (int)x7450cc1e48712286.ReadUInt16());
			break;
		case x875aca5784596b73.x352b977b8f6aab7a:
			x66c02128fdc6436a.xae20093bed1e48a8(350, (int)x7450cc1e48712286.ReadUInt16());
			break;
		case x875aca5784596b73.x25f139f8f24a7039:
			x66c02128fdc6436a.xae20093bed1e48a8(160, x195cb055715b526e.x5ab07bb8554e00d9((x88d38775104122b8)x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.xb9097619ef9f1bad:
			x66c02128fdc6436a.xae20093bed1e48a8(160, x195cb055715b526e.xfa7086ee0c6b6330(x7450cc1e48712286.ReadInt32()));
			break;
		case x875aca5784596b73.xf86c92cd5715e92c:
		{
			string xbcea506a33cf = xcf7aa3cc906cdb68.x7bcd2fb72fb7aae6(x7450cc1e48712286.ReadInt16());
			x66c02128fdc6436a.xae20093bed1e48a8(230, xbcea506a33cf);
			x66c02128fdc6436a.xae20093bed1e48a8(270, xbcea506a33cf);
			x66c02128fdc6436a.xae20093bed1e48a8(235, xbcea506a33cf);
			x66c02128fdc6436a.xae20093bed1e48a8(240, xbcea506a33cf);
			break;
		}
		case x875aca5784596b73.xf1e8157159ad64a2:
			x799e7416bbfffcfb(230, x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x8c5db9e141338048:
			x799e7416bbfffcfb(270, x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x7e721aac6f79cc68:
			x799e7416bbfffcfb(235, x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x8ffb9b2a88b78f25:
			x799e7416bbfffcfb(240, x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x04ef85548a953e94:
			x66c02128fdc6436a.xae20093bed1e48a8(60, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.xfd605137c124a22a:
			x66c02128fdc6436a.xae20093bed1e48a8(250, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x7489e1c499f14ab9:
			x66c02128fdc6436a.xae20093bed1e48a8(70, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.xfa2f0d701b1e042e:
			x66c02128fdc6436a.xae20093bed1e48a8(260, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x72279532830ff2da:
			x66c02128fdc6436a.xae20093bed1e48a8(80, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x6cab459f1b24b08e:
			x66c02128fdc6436a.xae20093bed1e48a8(300, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.xb17714aa9e1c3acb:
			x66c02128fdc6436a.xae20093bed1e48a8(100, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x8ad382fe477c1c55:
			x66c02128fdc6436a.xae20093bed1e48a8(90, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x7297db8347331c85:
			x66c02128fdc6436a.xae20093bed1e48a8(170, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x385326ed570b4642:
			x66c02128fdc6436a.xae20093bed1e48a8(180, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x85b37cfcfdf39643:
			x66c02128fdc6436a.xae20093bed1e48a8(210, (x7af53bbecc5ccdd5)x7450cc1e48712286.ReadByte());
			break;
		case x875aca5784596b73.x84f4a5b9c2ad3bf4:
			x66c02128fdc6436a.xae20093bed1e48a8(110, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x68b25a9cd876eadf:
			x66c02128fdc6436a.xae20093bed1e48a8(120, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.xc9d130da69374d65:
			x66c02128fdc6436a.xae20093bed1e48a8(130, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.xd148ef22a9fad1eb:
			x66c02128fdc6436a.xae20093bed1e48a8(140, xb290d4b363bd3333(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.xa082e87b24b9801e:
			x66c02128fdc6436a.xae20093bed1e48a8(450, x195cb055715b526e.xfa7086ee0c6b6330(x7450cc1e48712286.ReadInt32()));
			break;
		case x875aca5784596b73.xaebe7047b7a976e1:
			x66c02128fdc6436a.xae20093bed1e48a8(290, (int)x7450cc1e48712286.ReadUInt16());
			break;
		case x875aca5784596b73.xefd4711a64aeb1df:
			x66c02128fdc6436a.xae20093bed1e48a8(150, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x5f2639ae8bc287ad:
			x66c02128fdc6436a.xae20093bed1e48a8(200, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x34e5c3276f4c0905:
			x66c02128fdc6436a.xae20093bed1e48a8(220, (int)x7450cc1e48712286.ReadUInt16());
			break;
		case x875aca5784596b73.x0c44978be03b06d9:
		{
			x88d38775104122b8 x268aef2fda7d49d = (x88d38775104122b8)x7450cc1e48712286.ReadByte();
			x66c02128fdc6436a.xae20093bed1e48a8(20, x195cb055715b526e.x5ab07bb8554e00d9(x268aef2fda7d49d));
			break;
		}
		case x875aca5784596b73.xa0297581a8c47d49:
			x66c02128fdc6436a.xae20093bed1e48a8(310, (TextEffect)x7450cc1e48712286.ReadByte());
			break;
		case x875aca5784596b73.x5d67e0590c6f3378:
			x66c02128fdc6436a.xae20093bed1e48a8(265, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x3cb3e787bc923efb:
			x66c02128fdc6436a.xae20093bed1e48a8(268, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x79a3fb0c19dbf1d5:
			x66c02128fdc6436a.xae20093bed1e48a8(330, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x8fedec6eb8e1e343:
			x66c02128fdc6436a.xae20093bed1e48a8(440, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x839b36d58ff93ce3:
		{
			int num3 = x7450cc1e48712286.ReadUInt16();
			x66c02128fdc6436a.xae20093bed1e48a8(380, num3);
			x66c02128fdc6436a.xae20093bed1e48a8(340, num3);
			x66c02128fdc6436a.xae20093bed1e48a8(390, num3);
			break;
		}
		case x875aca5784596b73.x7a1e4daa5822e1f5:
		{
			int num2 = x7450cc1e48712286.ReadUInt16();
			if (num2 != 1024)
			{
				x66c02128fdc6436a.xae20093bed1e48a8(380, num2);
			}
			break;
		}
		case x875aca5784596b73.xcf91262979671195:
		{
			int num = x7450cc1e48712286.ReadUInt16();
			if (num != 1024)
			{
				x66c02128fdc6436a.xae20093bed1e48a8(390, num);
			}
			break;
		}
		case x875aca5784596b73.x39531f3e22372d1e:
			x66c02128fdc6436a.xae20093bed1e48a8(340, (int)x7450cc1e48712286.ReadUInt16());
			break;
		case x875aca5784596b73.xdd159e2c6d98aa54:
			x66c02128fdc6436a.xae20093bed1e48a8(380, (int)x7450cc1e48712286.ReadUInt16());
			break;
		case x875aca5784596b73.x8644bd61081df374:
			x66c02128fdc6436a.xae20093bed1e48a8(390, (int)x7450cc1e48712286.ReadUInt16());
			break;
		case x875aca5784596b73.xc8c2060bb9b3c0e0:
			x66c02128fdc6436a.xae20093bed1e48a8(50, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x2709657aa87b374f:
			x66c02128fdc6436a.xae20093bed1e48a8(400, (int)x7450cc1e48712286.ReadByte());
			break;
		case x875aca5784596b73.x7efc32638ed2fbce:
			x66c02128fdc6436a.xae20093bed1e48a8(460, (x7bc150a164904c56)x7450cc1e48712286.ReadByte());
			x66c02128fdc6436a.xae20093bed1e48a8(470, (int)x7450cc1e48712286.ReadByte());
			break;
		case x875aca5784596b73.x3e1c6fae54c0e9a7:
			x2640c2c8da422cb3(360);
			break;
		case x875aca5784596b73.xe77f715fb7a33e2e:
			x263126e767bb1792(360);
			break;
		case x875aca5784596b73.xabda0eac963906cf:
			x7d7320edca68565e(370);
			break;
		case x875aca5784596b73.x8c63dce62e038bc8:
			x19ce25c3c13b0c39(370);
			break;
		case x875aca5784596b73.x85598a867b282f06:
			x66c02128fdc6436a.xae20093bed1e48a8(10, x01564270bd68d6de(x7450cc1e48712286.ReadByte()));
			break;
		case x875aca5784596b73.x7887888923b16627:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.x286bc11c91310715 = xcf7aa3cc906cdb68.x7bcd2fb72fb7aae6(x7450cc1e48712286.ReadUInt16());
				x49f284ee51507f12.xe59d6d35c76d70aa = (char)x7450cc1e48712286.ReadUInt16();
				x49f284ee51507f12.xa1a25be53d0a44c8 = true;
			}
			break;
		case x875aca5784596b73.xf42be5458163cbdb:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.xf1d9b91c9700c401 = x7450cc1e48712286.ReadInt32();
				x49f284ee51507f12.xa1a25be53d0a44c8 = true;
			}
			break;
		case x875aca5784596b73.xa5a319e04d77c344:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.xa1a25be53d0a44c8 = x7450cc1e48712286.ReadByte() == 1;
			}
			break;
		case x875aca5784596b73.xfbe306582099ca65:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.x1b36d8d878eccfb5 = x7450cc1e48712286.ReadByte() == 1;
			}
			break;
		case x875aca5784596b73.x0cd3293b128dd60c:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.xc26441db92a14e8e = x7450cc1e48712286.ReadByte() == 1;
			}
			break;
		case x875aca5784596b73.xb8d6f385c91265f9:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.x9316383434e67238 = x7450cc1e48712286.ReadByte() == 1;
			}
			break;
		case x875aca5784596b73.x68add247a1af43f7:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.xf1d9b91c9700c401 = x7450cc1e48712286.ReadInt32();
			}
			break;
		case x875aca5784596b73.x4e877f01b8a21c1b:
			if (x7450cc1e48712286.ReadByte() != 0)
			{
				xeedad81aaed42a76.x18bb4aa7903ffced = new xc1b2bac943a0f541(x91bb72ac77aa7230.xf059562f878b500e);
			}
			break;
		case x875aca5784596b73.x72da617e10f660fd:
			if (x7450cc1e48712286.ReadByte() != 0)
			{
				xeedad81aaed42a76.x83da691dd3d974a6 = new xc1b2bac943a0f541(x91bb72ac77aa7230.x1f522a512716a2ae);
			}
			break;
		case x875aca5784596b73.xb99fb5cd3999932c:
			x5ed1464f234464d2(xeedad81aaed42a76.x18bb4aa7903ffced);
			break;
		case x875aca5784596b73.x59914329db95d0b0:
			x5ed1464f234464d2(xeedad81aaed42a76.x83da691dd3d974a6);
			break;
		case x875aca5784596b73.x35f91cd242dc536c:
			x76a097aef131251f(xeedad81aaed42a76.x18bb4aa7903ffced);
			break;
		case x875aca5784596b73.x34d501d3e0ce9d38:
			x76a097aef131251f(xeedad81aaed42a76.x83da691dd3d974a6);
			break;
		case x875aca5784596b73.xde03a93c114f3d2f:
			xf9b50472de6f2a55(new xeedad81aaed42a76());
			break;
		case x875aca5784596b73.x252406cfbd84d909:
			x7450cc1e48712286.ReadByte();
			break;
		case x875aca5784596b73.x3dc8f0e05187da1a:
			xd28f53fd94b9c0e4("Text formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.x700712357050fbbc:
			xd28f53fd94b9c0e4("Text formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.x42dca843b80ab453:
			x66c02128fdc6436a.xae20093bed1e48a8(45, (xb298f2d4a3b9607a)x7450cc1e48712286.ReadByte());
			break;
		case x875aca5784596b73.x61e91d10094abc58:
			xd28f53fd94b9c0e4("Text formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.xa55911b9412d53b6:
			x66c02128fdc6436a.xae20093bed1e48a8(480, x7450cc1e48712286.ReadInt32());
			break;
		case x875aca5784596b73.x492c1f017f9de562:
			x66c02128fdc6436a.xae20093bed1e48a8(490, (x9c3f027bfeb42e13)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.xbf3852d4e6f0df83:
			xd28f53fd94b9c0e4("Text formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.x46e93af06e5b0192:
			xd28f53fd94b9c0e4("Text formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.x2925e0472c062d8a:
			x66c02128fdc6436a.xae20093bed1e48a8(770, (x4a2f68a519ee2183)xe134235b3526fa75.ReadByte());
			break;
		case x875aca5784596b73.x1f97ed0f2b589e9e:
			x99dfa097f123587e(xe134235b3526fa75);
			break;
		case x875aca5784596b73.x1e5401ca83e4926d:
		case x875aca5784596b73.x798d5a92d0246012:
		case x875aca5784596b73.xc4f031d47f4def70:
		case x875aca5784596b73.xa33e83d207f88308:
			xd28f53fd94b9c0e4("Text formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		default:
			x3dc950453374051a("Unknown formatting modifier 0x{0:x4} occurred while reading DOC file.", (int)x28180b3c3774af93);
			return false;
		case x875aca5784596b73.xce434c95a20c9392:
		case x875aca5784596b73.x7cd2ca97e2c953b7:
		case x875aca5784596b73.x57f4ff3d002565e3:
			break;
		}
		return true;
	}

	bool x456c8b07916a8790.x09a3d4a7eac8f520(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9b1a5fd2bd42bd55
		return this.x9b1a5fd2bd42bd55(x28180b3c3774af93, xe780cde24dcce6f2, x0d4f7f21e78721d6, xe134235b3526fa75);
	}

	private void x799e7416bbfffcfb(int x6cc530a2cd983862, int x9d06f8cacc9dbcc6)
	{
		x66c02128fdc6436a.xae20093bed1e48a8(x6cc530a2cd983862, base.x4de4e1e9aeaada1f ? xa188b1d3d8eee54e.x7bcd2fb72fb7aae6(x9d06f8cacc9dbcc6) : xcf7aa3cc906cdb68.x7bcd2fb72fb7aae6(x9d06f8cacc9dbcc6));
	}

	private void x99dfa097f123587e(BinaryReader xe134235b3526fa75)
	{
		xf80d6ac0b6a56f39 xf80d6ac0b6a56f = new xf80d6ac0b6a56f39();
		int num = xe134235b3526fa75.ReadUInt16();
		xf80d6ac0b6a56f.x61c108cc44ef385a = (num & 1) != 0;
		xf80d6ac0b6a56f.xcc75e504ef58a07f = (num & 2) != 0;
		xf80d6ac0b6a56f.x69ec038defa753a8 = (x69ec038defa753a8)((num & 0x500) >> 8);
		xf80d6ac0b6a56f.x8983dff00ce7e17a = (num & 0x1000) != 0;
		xf80d6ac0b6a56f.xd9c2f8178451a779 = xe134235b3526fa75.ReadInt32();
		x66c02128fdc6436a.xae20093bed1e48a8(780, xf80d6ac0b6a56f);
	}

	private void x3df5c0539d1dc929(xf80d6ac0b6a56f39 x76cfa3dae9eed735)
	{
		x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.x1f97ed0f2b589e9e);
		x9b287b671d592594.Write((byte)6);
		int num = 0;
		num |= (x76cfa3dae9eed735.x61c108cc44ef385a ? 1 : 0);
		num |= (x76cfa3dae9eed735.xcc75e504ef58a07f ? 2 : 0);
		num |= (int)x76cfa3dae9eed735.x69ec038defa753a8 << 8;
		num |= (x76cfa3dae9eed735.x8983dff00ce7e17a ? 4096 : 0);
		x9b287b671d592594.Write((ushort)num);
		x9b287b671d592594.Write(x76cfa3dae9eed735.xd9c2f8178451a779);
	}

	private void x5ed1464f234464d2(xc1b2bac943a0f541 xde2016e90885f436)
	{
		int x9f442fb6cbea238c = x7450cc1e48712286.ReadInt16();
		if (xde2016e90885f436 != null)
		{
			xde2016e90885f436.xb063bbfcfeade526 = xaca3428582882d9d.x8f3a8caf455fbd75(x9f442fb6cbea238c);
		}
	}

	private void x76a097aef131251f(xc1b2bac943a0f541 xde2016e90885f436)
	{
		DateTime x242851e6278ed = xed28c1e5772a17ea.x06b0e25aa6ad68a9(x7450cc1e48712286);
		if (xde2016e90885f436 != null)
		{
			xde2016e90885f436.x242851e6278ed355 = x242851e6278ed;
		}
	}

	private x9b28b1f7f0cc963f x01564270bd68d6de(int xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case 0:
			return x9b28b1f7f0cc963f.x12642456c7bf0815;
		case 1:
			return x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
		case 128:
			return x9b28b1f7f0cc963f.x05c66da89af89aac;
		case 129:
			return x9b28b1f7f0cc963f.x10a64d88e6f4fac9;
		default:
			x3dc950453374051a("Invalid BoolEx value occurred, ignored.");
			return x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
		}
	}

	private Underline xb290d4b363bd3333(int xbcea506a33cf9111)
	{
		switch ((Underline)xbcea506a33cf9111)
		{
		case Underline.None:
		case Underline.Single:
		case Underline.Words:
		case Underline.Double:
		case Underline.Dotted:
		case Underline.Thick:
		case Underline.Dash:
		case Underline.DotDash:
		case Underline.DotDotDash:
		case Underline.Wavy:
		case Underline.DottedHeavy:
		case Underline.DashHeavy:
		case Underline.DotDashHeavy:
		case Underline.DotDotDashHeavy:
		case Underline.WavyHeavy:
		case Underline.DashLong:
		case Underline.WavyDouble:
		case Underline.DashLongHeavy:
			return (Underline)xbcea506a33cf9111;
		default:
			x3dc950453374051a("Invalid underline type read, used defaults.");
			return Underline.None;
		}
	}
}
