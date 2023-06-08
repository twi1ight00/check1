using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xf9a9481c3f63a419;

namespace xa2462df43988ffad;

internal class xefe741166bf97418
{
	private xaf19908a0dc2a02b x3b0808df568dbb69;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal xaf19908a0dc2a02b x60143d798b2de7de
	{
		get
		{
			return x3b0808df568dbb69;
		}
		set
		{
			x3b0808df568dbb69 = value;
		}
	}

	internal xefe741166bf97418(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
	}

	internal void x6210059f049f0d48(ShapeBase x5770cdefd8931aa9)
	{
		x3b0808df568dbb69 = new xaf19908a0dc2a02b();
		x6ca552dce57cba39(x5770cdefd8931aa9);
		x6210059f049f0d48(x5770cdefd8931aa9.IsInline);
	}

	internal void x6210059f049f0d48(bool x56f6837d0255d1c8)
	{
		if (x3b0808df568dbb69.xd44988f225497f3a <= 0)
		{
			return;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("style:graphic-properties");
		xe1410f585439c7d.x943f6be3acf634db("draw:marker-start-width", x3b0808df568dbb69.x35742d8781bd27a9);
		xe1410f585439c7d.x943f6be3acf634db("draw:marker-end-width", x3b0808df568dbb69.xb7a2ae35463d89d0);
		xe1410f585439c7d.x943f6be3acf634db("draw:marker-start", x3b0808df568dbb69.xea5391e1154f335c);
		xe1410f585439c7d.x943f6be3acf634db("draw:marker-end", x3b0808df568dbb69.x4d1185bee629d8db);
		xe1410f585439c7d.x943f6be3acf634db("draw:stroke", x3b0808df568dbb69.x0e397c84d3b79406);
		xe1410f585439c7d.x943f6be3acf634db("draw:stroke-dash", x3b0808df568dbb69.x86af65db5872cecd);
		xe1410f585439c7d.x943f6be3acf634db("svg:stroke-width", x3b0808df568dbb69.x302cb8ba350a61da);
		xe1410f585439c7d.x943f6be3acf634db("svg:stroke-color", x3b0808df568dbb69.x647455d3be1df648);
		xe1410f585439c7d.x943f6be3acf634db("svg:stroke-opacity", x3b0808df568dbb69.xaeddb2c9d22e1e9b);
		xe1410f585439c7d.x943f6be3acf634db("draw:fill", x3b0808df568dbb69.xcf49a18e709f5041 ? x3b0808df568dbb69.x6a81a30bcaf20a97 : "none");
		xe1410f585439c7d.x943f6be3acf634db("draw:fill-gradient-name", x3b0808df568dbb69.x40a949f82bfb8e32);
		xe1410f585439c7d.x943f6be3acf634db("draw:shadow-color", x3b0808df568dbb69.x1d980c0380fd7599);
		xe1410f585439c7d.x943f6be3acf634db("draw:shadow", x3b0808df568dbb69.xf398ffaf32ffe055);
		xe1410f585439c7d.x943f6be3acf634db("draw:shadow-opacity", x3b0808df568dbb69.xc63b235e1380754e);
		xe1410f585439c7d.x943f6be3acf634db("draw:shadow-offset-x", x3b0808df568dbb69.x4412b7b3fc13c152);
		xe1410f585439c7d.x943f6be3acf634db("draw:shadow-offset-y", x3b0808df568dbb69.x32e3c3f535e97c21);
		if (x3b0808df568dbb69.x6a81a30bcaf20a97 != "gradient")
		{
			xe1410f585439c7d.x943f6be3acf634db("draw:opacity", x3b0808df568dbb69.xd163a712710650fc);
			if (!x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11)
			{
				xe1410f585439c7d.x943f6be3acf634db("style:background-transparency", x3b0808df568dbb69.xa9e66da8da594524);
			}
			if (x3b0808df568dbb69.xcf49a18e709f5041)
			{
				xe1410f585439c7d.x943f6be3acf634db("draw:fill-color", x3b0808df568dbb69.x1b75e1aaf09e9fd8);
				xe1410f585439c7d.x943f6be3acf634db("fo:background-color", x3b0808df568dbb69.x83729c7ebf48ae24);
			}
		}
		xe1410f585439c7d.x943f6be3acf634db("draw:secondary-fill-color", x3b0808df568dbb69.x3ac8e949bb9dc5ed);
		xe1410f585439c7d.x943f6be3acf634db("draw:luminance", x3b0808df568dbb69.x5977e61981871b60);
		xe1410f585439c7d.x943f6be3acf634db("draw:contrast", x3b0808df568dbb69.x4f7155e57c89d548);
		xe1410f585439c7d.x943f6be3acf634db("draw:color-mode", x3b0808df568dbb69.x11a0eb5c9c3f84e0);
		x3b0808df568dbb69.x950295903e1e85d3.x6210059f049f0d48(xe1410f585439c7d);
		if (!x56f6837d0255d1c8)
		{
			xe1410f585439c7d.x943f6be3acf634db("style:horizontal-pos", x3b0808df568dbb69.xe4e660d4a7d6d4d8);
			xe1410f585439c7d.x943f6be3acf634db("style:horizontal-rel", x3b0808df568dbb69.x8fd43e520ced55ef);
			xe1410f585439c7d.x943f6be3acf634db("style:vertical-pos", x3b0808df568dbb69.x1792c7876d3f3359);
			xe1410f585439c7d.x943f6be3acf634db("style:vertical-rel", x3b0808df568dbb69.x0af5570a93f18215);
		}
		xe1410f585439c7d.x943f6be3acf634db("fo:clip", x3b0808df568dbb69.x069cc30e08571688);
		xe1410f585439c7d.x943f6be3acf634db("style:flow-with-text", x3b0808df568dbb69.xadd47ce4ddc8b701);
		xe1410f585439c7d.x943f6be3acf634db("style:wrap", x3b0808df568dbb69.x2fa36edd09e87b74);
		xe1410f585439c7d.x943f6be3acf634db("style:run-through", x3b0808df568dbb69.xed92e29da2610c30);
		xe1410f585439c7d.x943f6be3acf634db("fo:wrap-option", x3b0808df568dbb69.xaa600bcf11540f09);
		xe1410f585439c7d.x943f6be3acf634db("draw:auto-grow-height", x3b0808df568dbb69.x6467115e0b3350d8 ? "true" : "false");
		xe1410f585439c7d.x943f6be3acf634db("draw:auto-grow-width", x3b0808df568dbb69.x6467115e0b3350d8 ? "true" : "false");
		xe1410f585439c7d.x2dfde153f4ef96d0("style:graphic-properties");
	}

	private void x6ca552dce57cba39(ShapeBase x8739b0dd3627f37e)
	{
		if ((x8739b0dd3627f37e.x133a5347d32dce7a() || x8739b0dd3627f37e.IsWordArt) && !x8739b0dd3627f37e.IsGroup)
		{
			x3b0808df568dbb69.xaa600bcf11540f09 = "wrap";
		}
		x3b0808df568dbb69.x8fd43e520ced55ef = "paragraph";
		x3b0808df568dbb69.x0af5570a93f18215 = "paragraph";
		xf7125312c7ee115c xf7125312c7ee115c = x8739b0dd3627f37e.xf7125312c7ee115c;
		x425eec8888f9cefa x425eec8888f9cefa = new x425eec8888f9cefa();
		xf2c5ad4b4d2975c8 xf2c5ad4b4d2975c = null;
		ArrowWidth x1582c29a67732b = ArrowWidth.Medium;
		ArrowWidth x1582c29a67732b2 = ArrowWidth.Medium;
		string xfe2178c1f916f36c = null;
		x3b0808df568dbb69.xcf49a18e709f5041 = true;
		bool xf01e89c93c75ec = false;
		bool flag = x8739b0dd3627f37e is Shape && (x8739b0dd3627f37e as Shape).Stroked && !(x8739b0dd3627f37e as Shape).x169baa05e57bf312;
		int x20b8049cb52cdc = 0;
		bool x82d640a4012a8d = false;
		int num = 0;
		if (!flag)
		{
			x3b0808df568dbb69.x0e397c84d3b79406 = "none";
			x3b0808df568dbb69.x950295903e1e85d3.xa8c2637cc4888928.x51d60f077c5fc6e0 = "none";
			x3b0808df568dbb69.x950295903e1e85d3.x79d902473861f242.x51d60f077c5fc6e0 = "none";
			x3b0808df568dbb69.x950295903e1e85d3.xaea087ab32102492.x51d60f077c5fc6e0 = "none";
			x3b0808df568dbb69.x950295903e1e85d3.xd7a21e27974f626c.x51d60f077c5fc6e0 = "none";
		}
		if (x8739b0dd3627f37e.x3d318285d887cd3a && (bool)xf7125312c7ee115c.xfe91eeeafcb3026a(508))
		{
			x3b0808df568dbb69.x0e397c84d3b79406 = "solid";
		}
		for (int i = 0; i < xf7125312c7ee115c.xd44988f225497f3a; i++)
		{
			int num2 = xf7125312c7ee115c.xf15263674eb297bb(i);
			object obj = xf7125312c7ee115c.x6d3720b962bd3112(i);
			if (obj == null)
			{
				continue;
			}
			x3b0808df568dbb69.xd44988f225497f3a++;
			switch (num2)
			{
			case 190:
				x3b0808df568dbb69.x6467115e0b3350d8 = (bool)obj;
				break;
			case 459:
				x3b0808df568dbb69.x302cb8ba350a61da = xbb857c9fc36f5054.xacaf194810069dc6((int)obj);
				break;
			case 449:
				x3b0808df568dbb69.xaeddb2c9d22e1e9b = xbb857c9fc36f5054.xa2f3595b63dc1e85((int)obj);
				break;
			case 513:
				x3b0808df568dbb69.x1d980c0380fd7599 = xbb857c9fc36f5054.x5de8b3baf75f4df6((x26d9ecb4bdf0456d)obj);
				break;
			case 574:
				x3b0808df568dbb69.xf398ffaf32ffe055 = (((bool)obj) ? "visible" : "hidden");
				break;
			case 516:
				x3b0808df568dbb69.xc63b235e1380754e = xbb857c9fc36f5054.xa2f3595b63dc1e85((int)obj);
				break;
			case 517:
				x3b0808df568dbb69.x4412b7b3fc13c152 = xbb857c9fc36f5054.xacaf194810069dc6((int)obj);
				break;
			case 518:
				x3b0808df568dbb69.x32e3c3f535e97c21 = xbb857c9fc36f5054.xacaf194810069dc6((int)obj);
				break;
			case 264:
				x3b0808df568dbb69.x4f7155e57c89d548 = xbb857c9fc36f5054.xdea0334fd6e45e77((int)obj);
				break;
			case 265:
				x3b0808df568dbb69.x5977e61981871b60 = xbb857c9fc36f5054.x21d48ebe1add36d7((int)obj);
				break;
			case 385:
				x3b0808df568dbb69.x83729c7ebf48ae24 = xbb857c9fc36f5054.x5de8b3baf75f4df6((x26d9ecb4bdf0456d)obj);
				x3b0808df568dbb69.x1b75e1aaf09e9fd8 = x3b0808df568dbb69.x83729c7ebf48ae24;
				x425eec8888f9cefa.x7d2dc175c2f289c5 = x3b0808df568dbb69.x83729c7ebf48ae24;
				break;
			case 387:
				x425eec8888f9cefa.xf3874816968aabd7 = xbb857c9fc36f5054.x5de8b3baf75f4df6((x26d9ecb4bdf0456d)obj);
				break;
			case 647:
				x3b0808df568dbb69.x3ac8e949bb9dc5ed = xbb857c9fc36f5054.x5de8b3baf75f4df6((x26d9ecb4bdf0456d)obj);
				break;
			case 386:
				x3b0808df568dbb69.xd163a712710650fc = xbb857c9fc36f5054.xa2f3595b63dc1e85((int)obj);
				x3b0808df568dbb69.xa9e66da8da594524 = xbb857c9fc36f5054.xb1d5730bd3bfab62((int)obj);
				x425eec8888f9cefa.x869fb763fab11919 = x3b0808df568dbb69.xd163a712710650fc;
				break;
			case 443:
				x3b0808df568dbb69.xcf49a18e709f5041 = (bool)obj;
				break;
			case 384:
				x3b0808df568dbb69.x6a81a30bcaf20a97 = x0eb9a864413f34de.x27aadef0d0b5b322((xeba92971120d3e5a)obj);
				x425eec8888f9cefa.xfe2178c1f916f36c = x0eb9a864413f34de.x1f3ef07dedd13d25((xeba92971120d3e5a)obj);
				break;
			case 398:
				x425eec8888f9cefa.x9af8f492114408ed = xbb857c9fc36f5054.x663fc381a64fb64e((int)obj);
				break;
			case 397:
				x425eec8888f9cefa.xb5e5bf124e3ded2d = xbb857c9fc36f5054.x663fc381a64fb64e((int)obj);
				break;
			case 388:
				x425eec8888f9cefa.xfaf5ba04f7a15657 = xbb857c9fc36f5054.xa2f3595b63dc1e85((int)obj);
				break;
			case 396:
				x20b8049cb52cdc = (int)obj;
				x82d640a4012a8d = true;
				break;
			case 395:
				num = (int)obj;
				x425eec8888f9cefa.x6b1fe03343d9a6a4 = xbb857c9fc36f5054.xed668dab87818d34(num);
				break;
			case 412:
				xf01e89c93c75ec = (int)obj == 1073741835;
				break;
			case 317:
				if ((bool)obj)
				{
					x3b0808df568dbb69.x11a0eb5c9c3f84e0 = "greyscale";
				}
				else
				{
					x3b0808df568dbb69.xd44988f225497f3a--;
				}
				break;
			case 318:
				if ((bool)obj)
				{
					x3b0808df568dbb69.x11a0eb5c9c3f84e0 = "mono";
				}
				else
				{
					x3b0808df568dbb69.xd44988f225497f3a--;
				}
				break;
			case 914:
				x3b0808df568dbb69.x0af5570a93f18215 = x0eb9a864413f34de.x56430de7f4e96631((RelativeVerticalPosition)obj);
				break;
			case 913:
			{
				VerticalAlignment xbcea506a33cf = (VerticalAlignment)obj;
				x3b0808df568dbb69.x1792c7876d3f3359 = x0eb9a864413f34de.x95bf6cec5de8cec7(xbcea506a33cf);
				break;
			}
			case 912:
				x3b0808df568dbb69.x8fd43e520ced55ef = x0eb9a864413f34de.xa79e2cf81bd81a75((RelativeHorizontalPosition)obj);
				break;
			case 911:
				x3b0808df568dbb69.xe4e660d4a7d6d4d8 = x0eb9a864413f34de.x4da6a8cc075fb1bd((HorizontalAlignment)obj);
				break;
			case 258:
				x3b0808df568dbb69.x332a4841aef33498 = x4574ea26106f0edb.x97ab502db0c0e5c2((int)obj);
				break;
			case 259:
				x3b0808df568dbb69.x911fb1cc904ad8ee = x4574ea26106f0edb.x97ab502db0c0e5c2((int)obj);
				break;
			case 256:
				x3b0808df568dbb69.xda8d5e2df97ef739 = x4574ea26106f0edb.x97ab502db0c0e5c2((int)obj);
				break;
			case 257:
				x3b0808df568dbb69.xd7776f52196e7855 = x4574ea26106f0edb.x97ab502db0c0e5c2((int)obj);
				break;
			case 4106:
				x3b0808df568dbb69.x950295903e1e85d3.xa8c2637cc4888928.x03cb705fbd5700a4 = (Border)obj;
				x3b0808df568dbb69.xd44988f225497f3a--;
				break;
			case 4108:
				x3b0808df568dbb69.x950295903e1e85d3.x79d902473861f242.x03cb705fbd5700a4 = (Border)obj;
				x3b0808df568dbb69.xd44988f225497f3a--;
				break;
			case 4107:
				x3b0808df568dbb69.x950295903e1e85d3.xaea087ab32102492.x03cb705fbd5700a4 = (Border)obj;
				x3b0808df568dbb69.xd44988f225497f3a--;
				break;
			case 4109:
				x3b0808df568dbb69.x950295903e1e85d3.xd7a21e27974f626c.x03cb705fbd5700a4 = (Border)obj;
				x3b0808df568dbb69.xd44988f225497f3a--;
				break;
			case 901:
				xb741037c90b4e42f(x3b0808df568dbb69.x950295903e1e85d3.xa8c2637cc4888928, obj);
				break;
			case 903:
				xb741037c90b4e42f(x3b0808df568dbb69.x950295903e1e85d3.x79d902473861f242, obj);
				break;
			case 900:
				xb741037c90b4e42f(x3b0808df568dbb69.x950295903e1e85d3.xaea087ab32102492, obj);
				break;
			case 902:
				xb741037c90b4e42f(x3b0808df568dbb69.x950295903e1e85d3.xd7a21e27974f626c, obj);
				break;
			case 448:
			{
				x26d9ecb4bdf0456d x26d9ecb4bdf0456d = (x26d9ecb4bdf0456d)obj;
				if (x26d9ecb4bdf0456d.x7149c962c02931b3 || x26d9ecb4bdf0456d == x26d9ecb4bdf0456d.x66d844daa6e9f181)
				{
					x26d9ecb4bdf0456d = x26d9ecb4bdf0456d.x89fffa2751fdecbe;
				}
				string text = xbb857c9fc36f5054.x5de8b3baf75f4df6(x26d9ecb4bdf0456d);
				string x51d60f077c5fc6e = (x0d299f323d241756.x5959bccb67bbf051(text) ? string.Format("{0} {1}", text, "0.088cm solid") : "0.088cm solid");
				x3b0808df568dbb69.x950295903e1e85d3.xa8c2637cc4888928.x51d60f077c5fc6e0 = x51d60f077c5fc6e;
				x3b0808df568dbb69.x950295903e1e85d3.x79d902473861f242.x51d60f077c5fc6e0 = x51d60f077c5fc6e;
				x3b0808df568dbb69.x950295903e1e85d3.xaea087ab32102492.x51d60f077c5fc6e0 = x51d60f077c5fc6e;
				x3b0808df568dbb69.x950295903e1e85d3.xd7a21e27974f626c.x51d60f077c5fc6e0 = x51d60f077c5fc6e;
				x3b0808df568dbb69.x647455d3be1df648 = text;
				break;
			}
			case 4097:
				x3b0808df568dbb69.xab6edfb47ff0b74c = (WrapType)obj;
				break;
			case 4098:
				x3b0808df568dbb69.x400dff62c6cef57f = (WrapSide)obj;
				break;
			case 954:
				x3b0808df568dbb69.xed92e29da2610c30 = (((bool)obj) ? "background" : "foreground");
				break;
			case 471:
				xfe2178c1f916f36c = (((EndCap)x8739b0dd3627f37e.xf7125312c7ee115c.xf7866f89640a29a3(471) == EndCap.Round) ? "round" : "rect");
				break;
			case 462:
			{
				DashStyle dashStyle = (DashStyle)obj;
				if (dashStyle != 0 && dashStyle != 0)
				{
					int x710e06940d1179d;
					if (xdb0bf9f81de4b38c.xc8d1bb1390d5266d(x8739b0dd3627f37e))
					{
						x710e06940d1179d = x9b287b671d592594.xa74e18b54d0273fb.xcf2fd36bc07b78ec;
					}
					else
					{
						x710e06940d1179d = x9b287b671d592594.x48858fea1f761971;
						x9b287b671d592594.x48858fea1f761971++;
					}
					xf2c5ad4b4d2975c = x0eb9a864413f34de.x50ae2fd3acc88b8b(x8739b0dd3627f37e, x710e06940d1179d);
					x3b0808df568dbb69.x86af65db5872cecd = xf2c5ad4b4d2975c.x759aa16c2016a289;
					x3b0808df568dbb69.x0e397c84d3b79406 = "dash";
				}
				break;
			}
			case 508:
				if (x3b0808df568dbb69.x0e397c84d3b79406 != "dash")
				{
					x3b0808df568dbb69.x0e397c84d3b79406 = (((bool)obj) ? "solid" : "none");
				}
				else
				{
					x3b0808df568dbb69.xd44988f225497f3a--;
				}
				break;
			case 466:
				x1582c29a67732b = (ArrowWidth)obj;
				break;
			case 468:
				x1582c29a67732b2 = (ArrowWidth)obj;
				break;
			case 464:
				x3b0808df568dbb69.xea5391e1154f335c = x9b287b671d592594.xd402537927b451df(xf7125312c7ee115c, (ArrowType)obj, xa59013d234619c58: true);
				break;
			case 465:
				x3b0808df568dbb69.x4d1185bee629d8db = x9b287b671d592594.xd402537927b451df(xf7125312c7ee115c, (ArrowType)obj, xa59013d234619c58: false);
				break;
			case 133:
			{
				TextBoxWrapMode textBoxWrapMode = (TextBoxWrapMode)obj;
				if (textBoxWrapMode == TextBoxWrapMode.None)
				{
					x3b0808df568dbb69.xaa600bcf11540f09 = "no-wrap";
				}
				if (textBoxWrapMode == TextBoxWrapMode.Square)
				{
					x3b0808df568dbb69.xaa600bcf11540f09 = "wrap";
				}
				break;
			}
			default:
				x3b0808df568dbb69.xd44988f225497f3a--;
				break;
			}
		}
		if (x3b0808df568dbb69.xcf49a18e709f5041)
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(x3b0808df568dbb69.x1b75e1aaf09e9fd8))
			{
				x3b0808df568dbb69.x1b75e1aaf09e9fd8 = "#ffffff";
			}
			if (!x0d299f323d241756.x5959bccb67bbf051(x3b0808df568dbb69.x83729c7ebf48ae24))
			{
				x3b0808df568dbb69.x83729c7ebf48ae24 = "#ffffff";
			}
		}
		if (x3b0808df568dbb69.x950295903e1e85d3.x5f92400e1485c05c(flag, xa6651a0a6d059494: false))
		{
			x3b0808df568dbb69.xd44988f225497f3a++;
		}
		if (x3b0808df568dbb69.x0e397c84d3b79406 == "solid")
		{
			if (x3b0808df568dbb69.x950295903e1e85d3.xa8c2637cc4888928.x51d60f077c5fc6e0 == null || x3b0808df568dbb69.x950295903e1e85d3.xa8c2637cc4888928.x51d60f077c5fc6e0 == "none")
			{
				x3b0808df568dbb69.x950295903e1e85d3.xa8c2637cc4888928.x51d60f077c5fc6e0 = "#000000 0.018cm solid";
			}
			if (x3b0808df568dbb69.x950295903e1e85d3.x79d902473861f242.x51d60f077c5fc6e0 == null || x3b0808df568dbb69.x950295903e1e85d3.x79d902473861f242.x51d60f077c5fc6e0 == "none")
			{
				x3b0808df568dbb69.x950295903e1e85d3.x79d902473861f242.x51d60f077c5fc6e0 = "#000000 0.018cm solid";
			}
			if (x3b0808df568dbb69.x950295903e1e85d3.xaea087ab32102492.x51d60f077c5fc6e0 == null || x3b0808df568dbb69.x950295903e1e85d3.xaea087ab32102492.x51d60f077c5fc6e0 == "none")
			{
				x3b0808df568dbb69.x950295903e1e85d3.xaea087ab32102492.x51d60f077c5fc6e0 = "#000000 0.018cm solid";
			}
			if (x3b0808df568dbb69.x950295903e1e85d3.xd7a21e27974f626c.x51d60f077c5fc6e0 == null || x3b0808df568dbb69.x950295903e1e85d3.xd7a21e27974f626c.x51d60f077c5fc6e0 == "none")
			{
				x3b0808df568dbb69.x950295903e1e85d3.xd7a21e27974f626c.x51d60f077c5fc6e0 = "#000000 0.018cm solid";
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x3b0808df568dbb69.xea5391e1154f335c))
		{
			x3b0808df568dbb69.x35742d8781bd27a9 = x64b485f27e642f87(xf7125312c7ee115c, x1582c29a67732b, x25a99bd9f0091cba: true);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x3b0808df568dbb69.x4d1185bee629d8db))
		{
			x3b0808df568dbb69.xb7a2ae35463d89d0 = x64b485f27e642f87(xf7125312c7ee115c, x1582c29a67732b2, x25a99bd9f0091cba: false);
		}
		if (xf2c5ad4b4d2975c != null && xdb0bf9f81de4b38c.xc8d1bb1390d5266d(x8739b0dd3627f37e))
		{
			xf2c5ad4b4d2975c.xfe2178c1f916f36c = xfe2178c1f916f36c;
			if (x9b287b671d592594.xa74e18b54d0273fb.get_xe6d4b1b411ed94b5(xf2c5ad4b4d2975c.x759aa16c2016a289, (string)null, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false) == null)
			{
				x9b287b671d592594.xa74e18b54d0273fb.xd6b6ed77479ef68c(xf2c5ad4b4d2975c, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false);
			}
		}
		x5846084bb3a596db(x8739b0dd3627f37e);
		if (x3b0808df568dbb69.x1792c7876d3f3359 == null || x3b0808df568dbb69.x0af5570a93f18215 == "line")
		{
			x3b0808df568dbb69.x1792c7876d3f3359 = "from-top";
			if (x3b0808df568dbb69.x1792c7876d3f3359 == null)
			{
				x3b0808df568dbb69.xd44988f225497f3a++;
			}
		}
		if (x3b0808df568dbb69.x1792c7876d3f3359 == "from-top" && !x0d299f323d241756.x5959bccb67bbf051(x3b0808df568dbb69.x0af5570a93f18215))
		{
			x3b0808df568dbb69.x0af5570a93f18215 = "paragraph";
		}
		if (x3b0808df568dbb69.xe4e660d4a7d6d4d8 == null)
		{
			x3b0808df568dbb69.xe4e660d4a7d6d4d8 = "from-left";
			x3b0808df568dbb69.xd44988f225497f3a++;
		}
		x3b0808df568dbb69.x2fa36edd09e87b74 = x0eb9a864413f34de.xbdfff93b6ef512cf(x3b0808df568dbb69.xab6edfb47ff0b74c, x3b0808df568dbb69.x400dff62c6cef57f);
		if (x3b0808df568dbb69.x2fa36edd09e87b74 != null)
		{
			x3b0808df568dbb69.xd44988f225497f3a++;
		}
		if (x3b0808df568dbb69.xadd47ce4ddc8b701 == null)
		{
			x3b0808df568dbb69.xadd47ce4ddc8b701 = "false";
			x3b0808df568dbb69.xd44988f225497f3a++;
		}
		x957cddcfe8e5fc4f(x425eec8888f9cefa, num, x20b8049cb52cdc, x82d640a4012a8d, xf01e89c93c75ec);
	}

	private void x957cddcfe8e5fc4f(x425eec8888f9cefa x50710fbbded8f11a, int x81c3334e143bf122, int x20b8049cb52cdc93, bool x82d640a4012a8d01, bool xf01e89c93c75ec67)
	{
		if (!(x3b0808df568dbb69.x6a81a30bcaf20a97 == "gradient"))
		{
			return;
		}
		x50710fbbded8f11a.x759aa16c2016a289 = $"G{xca004f56614e2431.x754c3a5f03a2ce84(x9b287b671d592594.x9b244e0cae8e9ee1)}";
		x9b287b671d592594.x9b244e0cae8e9ee1++;
		x3b0808df568dbb69.x40a949f82bfb8e32 = x50710fbbded8f11a.x759aa16c2016a289;
		x9b287b671d592594.x9de31f20dd54f2d6.xd6b6ed77479ef68c(x50710fbbded8f11a, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false);
		if (x50710fbbded8f11a.xfe2178c1f916f36c == "square" && (x20b8049cb52cdc93 > 0 || x20b8049cb52cdc93 == -100))
		{
			string x7d2dc175c2f289c = x50710fbbded8f11a.x7d2dc175c2f289c5;
			x50710fbbded8f11a.x7d2dc175c2f289c5 = x50710fbbded8f11a.xf3874816968aabd7;
			x50710fbbded8f11a.xf3874816968aabd7 = x7d2dc175c2f289c;
		}
		if (x50710fbbded8f11a.xfe2178c1f916f36c == "linear")
		{
			if (x20b8049cb52cdc93 % 100 != 0)
			{
				x50710fbbded8f11a.xfe2178c1f916f36c = "axial";
			}
			if (x20b8049cb52cdc93 >= 0 && x20b8049cb52cdc93 < 100 && (x81c3334e143bf122 >= 0 || !x82d640a4012a8d01))
			{
				string x7d2dc175c2f289c2 = x50710fbbded8f11a.x7d2dc175c2f289c5;
				x50710fbbded8f11a.x7d2dc175c2f289c5 = x50710fbbded8f11a.xf3874816968aabd7;
				x50710fbbded8f11a.xf3874816968aabd7 = x7d2dc175c2f289c2;
				string x869fb763fab = x50710fbbded8f11a.x869fb763fab11919;
				x50710fbbded8f11a.x869fb763fab11919 = x50710fbbded8f11a.xfaf5ba04f7a15657;
				x50710fbbded8f11a.xfaf5ba04f7a15657 = x869fb763fab;
			}
		}
		x50710fbbded8f11a.x7d2dc175c2f289c5 = xe564ee464bac4896(x50710fbbded8f11a.x7d2dc175c2f289c5, xf01e89c93c75ec67);
		x50710fbbded8f11a.xf3874816968aabd7 = xe564ee464bac4896(x50710fbbded8f11a.xf3874816968aabd7, xf01e89c93c75ec67);
	}

	private static string xe564ee464bac4896(string x6c50a99faab7d741, bool xf01e89c93c75ec67)
	{
		if (x6c50a99faab7d741 == "#eff00266")
		{
			if (!xf01e89c93c75ec67)
			{
				return "#fbd8bb";
			}
			return "#ff9999";
		}
		return x6c50a99faab7d741;
	}

	private void x5846084bb3a596db(ShapeBase x8739b0dd3627f37e)
	{
		if (!x8739b0dd3627f37e.IsTopLevel || !(x8739b0dd3627f37e is Shape))
		{
			return;
		}
		Shape shape = (Shape)x8739b0dd3627f37e;
		if ((x3b0808df568dbb69.x332a4841aef33498 != 0.0 || x3b0808df568dbb69.x911fb1cc904ad8ee != 0.0 || x3b0808df568dbb69.xda8d5e2df97ef739 != 0.0 || x3b0808df568dbb69.xd7776f52196e7855 != 0.0) && shape.x169baa05e57bf312)
		{
			ImageSize imageSize = shape.ImageData.ImageSize;
			if (imageSize.x22ab5dfa6f12e902)
			{
				x3b0808df568dbb69.x069cc30e08571688 = $"rect({xbb857c9fc36f5054.x96d7e563211411f6(x3b0808df568dbb69.xda8d5e2df97ef739 * imageSize.HeightPoints)} {xbb857c9fc36f5054.x96d7e563211411f6(x3b0808df568dbb69.x911fb1cc904ad8ee * imageSize.WidthPoints)} {xbb857c9fc36f5054.x96d7e563211411f6(x3b0808df568dbb69.xd7776f52196e7855 * imageSize.HeightPoints)} {xbb857c9fc36f5054.x96d7e563211411f6(x3b0808df568dbb69.x332a4841aef33498 * imageSize.WidthPoints)})";
				x3b0808df568dbb69.xd44988f225497f3a++;
			}
		}
	}

	private void xb741037c90b4e42f(xd9f86432309317e4 xa8d8f7f744326e28, object xbcea506a33cf9111)
	{
		int num = (int)xbcea506a33cf9111;
		if (num == 0)
		{
			x3b0808df568dbb69.xd44988f225497f3a--;
		}
		else
		{
			xa8d8f7f744326e28.x6545d1f2c1b77773 = xbb857c9fc36f5054.x96d7e563211411f6(x4574ea26106f0edb.xa23e6b6c3169521d(num));
		}
	}

	private static string x64b485f27e642f87(xf7125312c7ee115c xa5e8b8b5991a4e1d, ArrowWidth x1582c29a67732b01, bool x25a99bd9f0091cba)
	{
		int xba08ce632055a1d = (x25a99bd9f0091cba ? 464 : 465);
		if (xa5e8b8b5991a4e1d.x263d579af1d0d43f(xba08ce632055a1d))
		{
			ArrowType x56e30755bce7e00e = (ArrowType)xa5e8b8b5991a4e1d.xf7866f89640a29a3(xba08ce632055a1d);
			return x1582c29a67732b01 switch
			{
				ArrowWidth.Wide => x64b485f27e642f87(x56e30755bce7e00e, "741", "617"), 
				ArrowWidth.Medium => x64b485f27e642f87(x56e30755bce7e00e, "556", "37"), 
				_ => x64b485f27e642f87(x56e30755bce7e00e, "432", "247"), 
			};
		}
		return null;
	}

	private static string x64b485f27e642f87(ArrowType x56e30755bce7e00e, string x7a6ae7bf3be8e715, string xbb4ba2d4c12b3c3a)
	{
		string arg = ((x56e30755bce7e00e == ArrowType.Open) ? x7a6ae7bf3be8e715 : xbb4ba2d4c12b3c3a);
		return $"0.{arg}cm";
	}
}
