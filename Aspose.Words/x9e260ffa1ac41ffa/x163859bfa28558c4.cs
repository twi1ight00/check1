using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.BuildingBlocks;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Markup;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x1ba3a5ce73d4b39d;
using x28925c9b27b37a46;
using x650fee20d618512c;
using x681ccae5509c120d;
using x6c95d9cf46ff5f25;
using x6f978ba1e7522832;
using x79578da6a8a3ae37;
using x884584cc69c5c378;
using xa604c4d210ae0581;
using xb92b7270f78a4e8d;
using xc8ef30c5dc53a453;
using xdc4a6e3b10426ae2;
using xf989f31a236ff98c;
using xfbd1009a0cbb9842;

namespace x9e260ffa1ac41ffa;

internal class x163859bfa28558c4 : DocumentVisitor, x3d2908992e1d1667, x7d1c3cf590044820
{
	private const int x574d60e76c8427b7 = 2048;

	private const int x840f0682785efa25 = 512;

	private const int xeaf9ef8ec49ce4ea = 52;

	private Document x232be220f517f721;

	private x8556eed81191af11 xb36c250515e408ad;

	private readonly Stack xcfc2e975409c798f = new Stack();

	private Stream x360620a398807923;

	private BinaryWriter x80f57697b4c811e9;

	private Stream x45cd25510b3594a3;

	private BinaryWriter xb9e6b034b22e403e;

	private Stream x537e1a6d567799a1;

	private BinaryWriter x3054eb7434148cfa;

	private xd47c6c7442eb8033 xaca3428582882d9d;

	private xc0c3e7a02d862604 xcb7fe852d2583003;

	private xa55b88ee4e81381b x17258deefeb290b7;

	private x82985a3d7a64e540 x172509d410571cfd;

	private x3af03f5f12c5ee73 x326d2c4737b8a926;

	private xe397b5e25a350375 x3d1e23f776308a10;

	private x4d66abcb6ba362b4 xb62384534c3b4daa;

	private x846eeecacc00f82b x2a8c54cec2ed34c4;

	private xd452a5f78fa06e8b x3613df8e6a658a81;

	private xd452a5f78fa06e8b xc5c7ba24502dc004;

	private xe91a1cdf262fe886 x96f19c22613114cd;

	private x1238479da7c66191 xa71a1ee23c38552d;

	private x1238479da7c66191 xc335834826922c5b;

	private x8aeace2bf92692ab xa6172040dc8d693f;

	private xc9072e4c3fa520ad x92b07040c889a19b;

	private xc9072e4c3fa520ad x26682442e5155e8a;

	private xeedad81aaed42a76 xc50228abe02b4236;

	private x8b8ab0cf32b35f3c x50fd2f87dafc0d07;

	private int xdbd7ea0e47c93621;

	private static readonly Guid xe1945254f189e0ed = new Guid("00020906-0000-0000-C000-000000000046");

	private static readonly xa52f2632c0ffdfaf x308ec08169534dcb = new xa52f2632c0ffdfaf();

	internal static readonly xa52f2632c0ffdfaf x70f4aa19e59d65fd = xa52f2632c0ffdfaf.x4d40fe7248d54a12();

	private static readonly x6ace28180a74825a xfffbfdc8a8982120 = new x6ace28180a74825a();

	private x2d5c6b020426990c x5658018be97d0c02;

	private x414106297e729800 x6e9a51819a170c0d;

	private bool xadfa33361ab36175;

	private static readonly byte[] x7745dbafc8739775 = new byte[48]
	{
		255, 255, 1, 0, 8, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 255, 255, 1, 0,
		0, 0, 0, 0, 255, 255, 0, 0, 2, 0,
		255, 255, 0, 0, 0, 0, 255, 255, 0, 0,
		2, 0, 255, 255, 0, 0, 0, 0
	};

	internal x846eeecacc00f82b x846eeecacc00f82b => x2a8c54cec2ed34c4;

	internal BinaryWriter xbb10bb9e03e33a16 => x3054eb7434148cfa;

	internal x9e131021ba70185c x9e131021ba70185c => x3d1e23f776308a10.x9e131021ba70185c;

	internal Document x2c8c6741422a1298 => x232be220f517f721;

	internal x8556eed81191af11 x8556eed81191af11 => xb36c250515e408ad;

	private IWarningCallback xf69ca7a9bb4a4a51 => xb36c250515e408ad.xf57de0fd37d5e97d.WarningCallback;

	private x08cf144d2bc4c341 x544693467ef27aac
	{
		get
		{
			if (xcfc2e975409c798f.Count <= 0)
			{
				return null;
			}
			return (x08cf144d2bc4c341)xcfc2e975409c798f.Peek();
		}
	}

	private bool xa4167addc9c6947c => x0d299f323d241756.x5959bccb67bbf051(((DocSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d).Password);

	internal bool x5124b2bcc12d5218 => xadfa33361ab36175;

	private SaveOutputParameters x8cac5adfe79bc025(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		try
		{
			x5658018be97d0c02 = new x2d5c6b020426990c(x5ac1382edb7bf2c2);
			xb36c250515e408ad = x5ac1382edb7bf2c2;
			x232be220f517f721 = x5ac1382edb7bf2c2.x2c8c6741422a1298;
			xd586e0c16bdae7fc();
			x160a0bf4de8f6bd0();
			xd8c3135513b9115b xd8c3135513b9115b = x73a0dd74a28af617();
			xd8c3135513b9115b.x0acd3c2012ea2ee8(x5ac1382edb7bf2c2.xb8a774e0111d0fbe);
		}
		finally
		{
			x5658018be97d0c02.x618890967a836e8b();
		}
		return new SaveOutputParameters("application/msword");
	}

	SaveOutputParameters x3d2908992e1d1667.xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8cac5adfe79bc025
		return this.x8cac5adfe79bc025(x5ac1382edb7bf2c2);
	}

	internal void x0acd3c2012ea2ee8(Document x3664041d21d73fdc, string xafe2f3653ee64ebc)
	{
		using Stream stream = File.OpenWrite(xafe2f3653ee64ebc);
		x8556eed81191af11 x5ac1382edb7bf2c = new x8556eed81191af11(x3664041d21d73fdc, stream, xafe2f3653ee64ebc, new DocSaveOptions());
		((x3d2908992e1d1667)this).xa2e0b7f7da663553(x5ac1382edb7bf2c);
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xf69ca7a9bb4a4a51 != null)
		{
			xf69ca7a9bb4a4a51.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Doc, xc2358fbac7da3d45));
		}
	}

	internal void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, xc2358fbac7da3d45);
	}

	private void xd586e0c16bdae7fc()
	{
		x360620a398807923 = x5658018be97d0c02.x6795cf98c786308b();
		x80f57697b4c811e9 = new BinaryWriter(x360620a398807923, Encoding.Unicode);
		x45cd25510b3594a3 = x5658018be97d0c02.x6795cf98c786308b();
		xb9e6b034b22e403e = new BinaryWriter(x45cd25510b3594a3, Encoding.Unicode);
		x537e1a6d567799a1 = x5658018be97d0c02.x6795cf98c786308b();
		x3054eb7434148cfa = new BinaryWriter(x537e1a6d567799a1, Encoding.Unicode);
		xaca3428582882d9d = new xd47c6c7442eb8033();
		xcb7fe852d2583003 = new xc0c3e7a02d862604(xaca3428582882d9d, xf69ca7a9bb4a4a51);
		x17258deefeb290b7 = new xa55b88ee4e81381b(null, xaca3428582882d9d, xf69ca7a9bb4a4a51);
		x172509d410571cfd = new x82985a3d7a64e540(null, xaca3428582882d9d, x3a9e25666c8d1ee1.x1ab0f9731505945e, xf69ca7a9bb4a4a51);
		x326d2c4737b8a926 = new x3af03f5f12c5ee73(x232be220f517f721.FontInfos, xaca3428582882d9d, xf69ca7a9bb4a4a51);
		x3d1e23f776308a10 = new xe397b5e25a350375();
		xb62384534c3b4daa = new x4d66abcb6ba362b4();
		x2a8c54cec2ed34c4 = new x846eeecacc00f82b();
		x3613df8e6a658a81 = new xd452a5f78fa06e8b(FootnoteType.Footnote);
		xc5c7ba24502dc004 = new xd452a5f78fa06e8b(FootnoteType.Endnote);
		x96f19c22613114cd = new xe91a1cdf262fe886();
		xa71a1ee23c38552d = new x1238479da7c66191(x9e131021ba70185c.xc447809891322395);
		xc335834826922c5b = new x1238479da7c66191(x9e131021ba70185c.x1ea60bde2b5d0d28);
		x50fd2f87dafc0d07 = new x8b8ab0cf32b35f3c(this);
		x50fd2f87dafc0d07.xbf993c53e1cbdfb1.x5ab5a058833da74f = x232be220f517f721.BackgroundShape;
		xa6172040dc8d693f = new x8aeace2bf92692ab();
		xa6172040dc8d693f.x76a664845d700102 = true;
	}

	private xd8c3135513b9115b x73a0dd74a28af617()
	{
		xdade2366eaa6f915 xdade2366eaa6f = x232be220f517f721.xdade2366eaa6f915;
		switch (xb36c250515e408ad.x707d72c3570dbf2d)
		{
		case SaveFormat.Doc:
			xa6172040dc8d693f.x6e7b4319da225d18 = false;
			break;
		case SaveFormat.Dot:
			xa6172040dc8d693f.x6e7b4319da225d18 = true;
			break;
		default:
			throw new InvalidOperationException("Unexpected save format.");
		}
		xa6172040dc8d693f.x240eec731225c48e = xdade2366eaa6f.xc57807e17cfa13d2.ReadOnlyRecommended;
		xa6172040dc8d693f.x61144b80cccda275 = x0d299f323d241756.x5959bccb67bbf051(xdade2366eaa6f.xc57807e17cfa13d2.x72213a2a58cf72d7());
		xa6172040dc8d693f.x9c1eabb9200f04a0 = true;
		xa6172040dc8d693f.x6210059f049f0d48(x360620a398807923);
		x636457dda93ec7a1();
		x0d299f323d241756.xb66a70c14b63a912(x360620a398807923, 512);
		x537196dfb08681e8();
		x6f235ed179e6fb4e();
		xb62384534c3b4daa.x105c8f2ef9d7db1b(x80f57697b4c811e9);
		x64048ad4d39c9f2a();
		xa6172040dc8d693f.x80d8e916f0118723 = (int)x360620a398807923.Length;
		x360620a398807923.Seek(0L, SeekOrigin.Begin);
		if (xa4167addc9c6947c)
		{
			xa6172040dc8d693f.xa07212033002e423 = true;
			xa6172040dc8d693f.x9729e21f6f99ff8e = false;
			xa6172040dc8d693f.x7f6d57b052cf10a1 = 52;
		}
		xa6172040dc8d693f.x6210059f049f0d48(x360620a398807923);
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(xe1945254f189e0ed);
		xd8c3135513b9115b.x29e7ace4c90f74cd.Add("WordDocument", x360620a398807923);
		xd8c3135513b9115b.x29e7ace4c90f74cd.Add(xa6172040dc8d693f.xa20346a1e3c44f1b, x45cd25510b3594a3);
		if (x537e1a6d567799a1.Length > 0)
		{
			xd8c3135513b9115b.x29e7ace4c90f74cd.Add("Data", x537e1a6d567799a1);
		}
		if (xa4167addc9c6947c)
		{
			x6e9a51819a170c0d.x246b032720dd4c0d(xd8c3135513b9115b, xa6172040dc8d693f.xa20346a1e3c44f1b);
		}
		if (x232be220f517f721.x70813fadbf467780 != null)
		{
			xd8c3135513b9115b.x29e7ace4c90f74cd.xd6b6ed77479ef68c("\u0001CompObj", x232be220f517f721.x70813fadbf467780);
		}
		if (x232be220f517f721.HasMacros)
		{
			xd8c3135513b9115b.x29e7ace4c90f74cd.xd6b6ed77479ef68c("Macros", x232be220f517f721.x92e2e3377da135e8);
		}
		if (xb36c250515e408ad.x7c3f3666365efbc6.Count > 0)
		{
			xd8c3135513b9115b.x29e7ace4c90f74cd.xd6b6ed77479ef68c("ObjectPool", xb36c250515e408ad.x7c3f3666365efbc6);
		}
		xe7be411416cfcd54 xe7be411416cfcd = x4fe6ba040498cc67.x6210059f049f0d48(x232be220f517f721.CustomXmlParts);
		if (xe7be411416cfcd != null)
		{
			xd8c3135513b9115b.x29e7ace4c90f74cd.xd6b6ed77479ef68c("MsoDataStore", xe7be411416cfcd);
		}
		xe6d08044467dd57c xe6d08044467dd57c = new xe6d08044467dd57c();
		xe6d08044467dd57c.x6210059f049f0d48(x232be220f517f721.BuiltInDocumentProperties, x232be220f517f721.CustomDocumentProperties, xd8c3135513b9115b.x29e7ace4c90f74cd);
		return xd8c3135513b9115b;
	}

	private void x160a0bf4de8f6bd0()
	{
		x6075c9125351e131(x232be220f517f721.x245aa7750b4a8072.get_xe6d4b1b411ed94b5(x101cddc73c4f8cc2.xa1e2a8ed32a026dd));
		x6075c9125351e131(x232be220f517f721.x245aa7750b4a8072.get_xe6d4b1b411ed94b5(x101cddc73c4f8cc2.xeab6532eb0797a6e));
		x6075c9125351e131(x232be220f517f721.x245aa7750b4a8072.get_xe6d4b1b411ed94b5(x101cddc73c4f8cc2.x1e0d716fba95db43));
		x6075c9125351e131(x232be220f517f721.x245aa7750b4a8072.get_xe6d4b1b411ed94b5(x101cddc73c4f8cc2.x0affbe34bb1f8b8b));
		x6075c9125351e131(x232be220f517f721.x245aa7750b4a8072.get_xe6d4b1b411ed94b5(x101cddc73c4f8cc2.x354a2c7b596483f1));
		x6075c9125351e131(x232be220f517f721.x245aa7750b4a8072.get_xe6d4b1b411ed94b5(x101cddc73c4f8cc2.x281934d7c2c96a88));
		x3d1e23f776308a10.xb264ad2ce3daa0a4(x9e131021ba70185c.xc447809891322395);
		for (Node node = x232be220f517f721.FirstChild; node != null; node = node.NextSibling)
		{
			x51ee56decc29a9da((Section)node);
		}
		x3d1e23f776308a10.xc4104b442b4f6eb6();
		bool flag = false;
		flag |= x1309751f24618f6c(FootnoteType.Footnote);
		flag |= x1e75b9fd5a56c497();
		flag |= x08a3c71a2757edb3();
		flag |= x1309751f24618f6c(FootnoteType.Endnote);
		flag |= xf5cf72897196b966(x9e131021ba70185c.xf79eacb7dc6313bb);
		if (flag | xf5cf72897196b966(x9e131021ba70185c.xda79e5b626eda365))
		{
			x694103d4c8487701();
		}
		x3d1e23f776308a10.x8ffe90e7fbccfccd(2048);
		int x94a76e3a5bbb5ca = x3d1e23f776308a10.x94a76e3a5bbb5ca6;
		xb62384534c3b4daa.xd6b6ed77479ef68c(x94a76e3a5bbb5ca);
		x3613df8e6a658a81.xdf0c8cea9b2d73a3.xd6b6ed77479ef68c(x94a76e3a5bbb5ca);
		x96f19c22613114cd.xeaa001c8a56a5789.xd6b6ed77479ef68c(x94a76e3a5bbb5ca);
		int x13d4cb8d1bd = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.xc447809891322395).x1be93eed8950d961 + 2;
		x96f19c22613114cd.x1213e861660862e7.xd6b6ed77479ef68c(x13d4cb8d1bd);
		x96f19c22613114cd.x8a4e50b3272d2d52.xd6b6ed77479ef68c(x13d4cb8d1bd);
		xc5c7ba24502dc004.xdf0c8cea9b2d73a3.xd6b6ed77479ef68c(x94a76e3a5bbb5ca);
		xa71a1ee23c38552d.x4a74ca8842ca69ab.xd6b6ed77479ef68c(x94a76e3a5bbb5ca);
		xa71a1ee23c38552d.x6d996d87ff4d558d.xd6b6ed77479ef68c(x94a76e3a5bbb5ca);
		xc335834826922c5b.x4a74ca8842ca69ab.xd6b6ed77479ef68c(x2a8c54cec2ed34c4.xe7417f6a11716af5);
		xc335834826922c5b.x6d996d87ff4d558d.xd6b6ed77479ef68c(x94a76e3a5bbb5ca);
	}

	private void x694103d4c8487701()
	{
		x3d1e23f776308a10.xb264ad2ce3daa0a4(x9e131021ba70185c.xda79e5b626eda365);
		Paragraph lastParagraph = x232be220f517f721.LastSection.Body.LastParagraph;
		Paragraph paragraph = new Paragraph(x232be220f517f721, lastParagraph.x1a78664fa10a3755, lastParagraph.x344511c4e4ce09da);
		paragraph.Accept(this);
		x3d1e23f776308a10.xc4104b442b4f6eb6();
	}

	private void x51ee56decc29a9da(Section xb32f8dd719a105db)
	{
		xb7b1bf2d89bd7ff4 xb7b1bf2d89bd7ff = new xb7b1bf2d89bd7ff4();
		xb7b1bf2d89bd7ff.x34e183d0e3285c7e = xcb7fe852d2583003.x6210059f049f0d48(xb32f8dd719a105db.xfc72d4c9b765cad7);
		xb62384534c3b4daa.xd6b6ed77479ef68c(x3d1e23f776308a10.x3e287ef15dc898f3, xb7b1bf2d89bd7ff);
		xb32f8dd719a105db.Body.Accept(this);
		x6075c9125351e131(xb32f8dd719a105db.HeadersFooters[HeaderFooterType.HeaderEven]);
		x6075c9125351e131(xb32f8dd719a105db.HeadersFooters[HeaderFooterType.HeaderPrimary]);
		x6075c9125351e131(xb32f8dd719a105db.HeadersFooters[HeaderFooterType.FooterEven]);
		x6075c9125351e131(xb32f8dd719a105db.HeadersFooters[HeaderFooterType.FooterPrimary]);
		x6075c9125351e131(xb32f8dd719a105db.HeadersFooters[HeaderFooterType.HeaderFirst]);
		x6075c9125351e131(xb32f8dd719a105db.HeadersFooters[HeaderFooterType.FooterFirst]);
	}

	private void x6075c9125351e131(CompositeNode x03e7e66b1eecc96f)
	{
		x3d1e23f776308a10.xb264ad2ce3daa0a4(x9e131021ba70185c.x1ea60bde2b5d0d28);
		x2a8c54cec2ed34c4.xd6b6ed77479ef68c(x3d1e23f776308a10.x3e287ef15dc898f3, null);
		if (x03e7e66b1eecc96f != null)
		{
			for (Node node = x03e7e66b1eecc96f.FirstChild; node != null; node = node.NextSibling)
			{
				node.Accept(this);
			}
			if (x03e7e66b1eecc96f.HasChildNodes)
			{
				Paragraph paragraph = new Paragraph(x232be220f517f721);
				paragraph.Accept(this);
			}
		}
		x3d1e23f776308a10.xc4104b442b4f6eb6();
	}

	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		x6ace28180a74825a x6ace28180a74825a = xfffbfdc8a8982120;
		if (x3d1e23f776308a10.xb8414804f39a9e90 > 0)
		{
			x6ace28180a74825a = new x6ace28180a74825a();
			x6ace28180a74825a.xb8414804f39a9e90 = x3d1e23f776308a10.xb8414804f39a9e90;
			if (para.IsEndOfCell && x3d1e23f776308a10.xb8414804f39a9e90 > 1)
			{
				x6ace28180a74825a.x521051256585691d = true;
			}
		}
		para.x1a78664fa10a3755.xcedf9c82728ad579 = para.ParagraphFormat.Bidi;
		x3ff949c473a702d2 x03ef0b0129c670a = x17258deefeb290b7.x6210059f049f0d48((x1a78664fa10a3755)x9913a2fbad46cb1a(para.x1a78664fa10a3755), x6ace28180a74825a);
		x3d1e23f776308a10.x959bfe125105856a(x03ef0b0129c670a);
		xe0dcd40792266ce3.xe15b410a3a002f4d(para, this);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphEnd(Paragraph para)
	{
		if (para.IsEndOfDocument && x232be220f517f721.Lists.xe10f375b4290d48f > 0)
		{
			xa23a9cf7d03725c8();
		}
		xe0dcd40792266ce3.x53ca22156bcc3784(para, this);
		x811fbd3fde91eb05(x399ba569ef6c57d9(para), (xeedad81aaed42a76)x9913a2fbad46cb1a(para.x344511c4e4ce09da), x308ec08169534dcb);
		return VisitorAction.Continue;
	}

	private void xa23a9cf7d03725c8()
	{
		VisitBookmarkStart(new BookmarkStart(x232be220f517f721, "_PictureBullets"));
		for (int i = 0; i < x232be220f517f721.Lists.xe10f375b4290d48f; i++)
		{
			Shape shape = x232be220f517f721.Lists.x4916e8670feefe58(i);
			shape.Font.Hidden = true;
			shape.Accept(this);
		}
		VisitBookmarkEnd(new BookmarkEnd(x232be220f517f721, "_PictureBullets"));
	}

	private string x399ba569ef6c57d9(Paragraph x41baca1d6c0c2e8e)
	{
		if (x41baca1d6c0c2e8e.IsEndOfCell)
		{
			if (x3d1e23f776308a10.xb8414804f39a9e90 <= 1)
			{
				return ControlChar.Cell;
			}
			return ControlChar.ParagraphBreak;
		}
		if (x41baca1d6c0c2e8e.IsEndOfSection)
		{
			if (!x41baca1d6c0c2e8e.ParentSection.x16479f42fe4547f2)
			{
				return ControlChar.SectionBreak;
			}
			return ControlChar.ParagraphBreak;
		}
		return ControlChar.ParagraphBreak;
	}

	public override VisitorAction VisitTableStart(Table table)
	{
		xcfc2e975409c798f.Push(new x08cf144d2bc4c341(x232be220f517f721, table));
		if (x544693467ef27aac.xdb8d101b58051732 && table.FirstRow.xedb0eb766e25e0c9.x8301ab10c226b0c2 != 11)
		{
			xbbf9a1ead81dd3a1(WarningType.MinorFormattingLoss, $"Table style 0x{table.FirstRow.xedb0eb766e25e0c9.x8301ab10c226b0c2:x2} can not be preserved and will be converted to direct formatting.");
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitTableEnd(Table table)
	{
		xcfc2e975409c798f.Pop();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowStart(Row row)
	{
		x3d1e23f776308a10.x5e3f44647fcfb8fc();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowEnd(Row row)
	{
		x3ff949c473a702d2 x03ef0b0129c670a = x172509d410571cfd.x6210059f049f0d48(row, xfc53bd8a6982db4c(), x3054eb7434148cfa, x544693467ef27aac);
		xab27741117c4a74b(x03ef0b0129c670a);
		x3d1e23f776308a10.xbdbbc98113b6b783();
		return VisitorAction.Continue;
	}

	private x3ff949c473a702d2 xfc53bd8a6982db4c()
	{
		x6ace28180a74825a x6ace28180a74825a = new x6ace28180a74825a();
		x6ace28180a74825a.xb8414804f39a9e90 = x3d1e23f776308a10.xb8414804f39a9e90;
		if (x3d1e23f776308a10.xb8414804f39a9e90 > 1)
		{
			x6ace28180a74825a.x521051256585691d = true;
			x6ace28180a74825a.xd7d26444f1f80de0 = true;
		}
		else
		{
			x6ace28180a74825a.x26614a31f1c1d1df = true;
		}
		return x17258deefeb290b7.x6210059f049f0d48(new x1a78664fa10a3755(), x6ace28180a74825a);
	}

	private void xab27741117c4a74b(x3ff949c473a702d2 x03ef0b0129c670a6)
	{
		x3d1e23f776308a10.x959bfe125105856a(x03ef0b0129c670a6);
		string xb41faee6912a = ((x3d1e23f776308a10.xb8414804f39a9e90 == 1) ? ControlChar.Cell : ControlChar.ParagraphBreak);
		x811fbd3fde91eb05(xb41faee6912a, null, x308ec08169534dcb);
	}

	public override VisitorAction VisitRun(Run run)
	{
		xa52f2632c0ffdfaf xe08a26cc2b49f3aa = x308ec08169534dcb;
		if (run.Text == FormField.xb8fa1e789c415fba)
		{
			xe08a26cc2b49f3aa = x70f4aa19e59d65fd;
		}
		x811fbd3fde91eb05(run.Text, (xeedad81aaed42a76)x9913a2fbad46cb1a(run.xeedad81aaed42a76), xe08a26cc2b49f3aa);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		x811fbd3fde91eb05(specialChar.GetText(), specialChar.xeedad81aaed42a76, x70f4aa19e59d65fd);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFormField(FormField formField)
	{
		if (!x5c29822913be33c1.x7f8b7c1c90735bcf(formField.Type))
		{
			return VisitorAction.SkipThisNode;
		}
		xa52f2632c0ffdfaf xa52f2632c0ffdfaf = new xa52f2632c0ffdfaf();
		xa52f2632c0ffdfaf.xa1a25be53d0a44c8 = true;
		xa52f2632c0ffdfaf.x1b36d8d878eccfb5 = true;
		xa52f2632c0ffdfaf.xf1d9b91c9700c401 = (int)x537e1a6d567799a1.Position;
		xdbd7ea0e47c93621++;
		x811fbd3fde91eb05(formField.GetText(), formField.xeedad81aaed42a76, xa52f2632c0ffdfaf);
		xdbd7ea0e47c93621--;
		xf2b9ab75a7571713.x377854a89e2ddb81(formField, x3054eb7434148cfa);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		return x50fd2f87dafc0d07.x1f70c910ab814928(shape);
	}

	public override VisitorAction VisitShapeEnd(Shape shape)
	{
		return x50fd2f87dafc0d07.xd96c4f9a469ee575(shape);
	}

	public override VisitorAction VisitGroupShapeStart(GroupShape groupShape)
	{
		return x50fd2f87dafc0d07.xe158ae61ac75f37d(groupShape);
	}

	public override VisitorAction VisitGroupShapeEnd(GroupShape groupShape)
	{
		return x50fd2f87dafc0d07.x964d9841100f787a(groupShape);
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		xd452a5f78fa06e8b xd452a5f78fa06e8b = xe1d0e02959854092(footnote.FootnoteType);
		xd452a5f78fa06e8b.x3027cf4169823691(x3d1e23f776308a10.x3e287ef15dc898f3, footnote.xa72bf798a679c0aa);
		if (footnote.xa72bf798a679c0aa)
		{
			x811fbd3fde91eb05(ControlChar.xf4a399b5bb9c2b9e, footnote.xeedad81aaed42a76, x70f4aa19e59d65fd);
		}
		else
		{
			x811fbd3fde91eb05(footnote.x715a8c5c33fdc1a6, footnote.xeedad81aaed42a76, x308ec08169534dcb);
		}
		x3d1e23f776308a10.xb264ad2ce3daa0a4(xd452a5f78fa06e8b.xa339e023ec82f1e3(footnote.FootnoteType));
		xd452a5f78fa06e8b.x0c36c422d27fe185(x3d1e23f776308a10.x3e287ef15dc898f3);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		x3d1e23f776308a10.xc4104b442b4f6eb6();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		x96f19c22613114cd.xc33ad5bca70a78bb(x3d1e23f776308a10.x3e287ef15dc898f3, comment);
		x811fbd3fde91eb05(ControlChar.x52a843d47a26d1df, comment.xeedad81aaed42a76, x70f4aa19e59d65fd);
		x3d1e23f776308a10.xb264ad2ce3daa0a4(x9e131021ba70185c.x937e050c63ea1527);
		x96f19c22613114cd.x997a4489160115e0(x3d1e23f776308a10.x3e287ef15dc898f3);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentEnd(Comment comment)
	{
		x3d1e23f776308a10.xc4104b442b4f6eb6();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentRangeStart(CommentRangeStart commentRangeStart)
	{
		x96f19c22613114cd.x97cec16df8d915d2(x3d1e23f776308a10.x3e287ef15dc898f3, commentRangeStart.Id);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentRangeEnd(CommentRangeEnd commentRangeEnd)
	{
		x96f19c22613114cd.x3db79c2fd9382b7b(x3d1e23f776308a10.x3e287ef15dc898f3, commentRangeEnd.Id);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		x544c864b2d73388d(fieldStart.FieldType, fieldStart.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		if (fieldSeparator.FieldType == FieldType.FieldIncludePicture)
		{
			xadfa33361ab36175 = true;
		}
		if (x5c29822913be33c1.x4880d896f2583270(fieldSeparator.FieldType))
		{
			xfd30c9fe530c9b34(fieldSeparator);
		}
		else if (fieldSeparator.x71d39fdf56861cca != null)
		{
			xf1f82fcde3b22573(fieldSeparator.xeedad81aaed42a76, fieldSeparator.x71d39fdf56861cca.xea1e81378298fa81);
		}
		else
		{
			x2e2bbf4db242427d(fieldSeparator.xeedad81aaed42a76);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		if (fieldEnd.FieldType == FieldType.FieldIncludePicture)
		{
			xadfa33361ab36175 = false;
		}
		xfc282418f4ca7fa7(fieldEnd);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBookmarkStart(BookmarkStart node)
	{
		x3d1e23f776308a10.xa5c8bd4eb8264c5b(node.Name, node.x586b7652ac7cefe0);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBookmarkEnd(BookmarkEnd node)
	{
		x3d1e23f776308a10.x6d5145c03507a8ad(node.Name);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSmartTagStart(SmartTag smartTag)
	{
		if (x0b7d4e74b9ac7a04())
		{
			return VisitorAction.Continue;
		}
		x3d1e23f776308a10.xdfafe7603e2ef7d0(smartTag);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSmartTagEnd(SmartTag smartTag)
	{
		if (x0b7d4e74b9ac7a04())
		{
			return VisitorAction.Continue;
		}
		x3d1e23f776308a10.x386937ee946030a9(smartTag);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCustomXmlMarkupStart(CustomXmlMarkup customXml)
	{
		if (customXml.Level == MarkupLevel.Inline)
		{
			x18c776ebc56d8212(customXml);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCustomXmlMarkupEnd(CustomXmlMarkup customXml)
	{
		if (customXml.Level == MarkupLevel.Inline)
		{
			x0a79c02b4c66999f(customXml);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitStructuredDocumentTagStart(StructuredDocumentTag sdt)
	{
		xbbf9a1ead81dd3a1(WarningType.DataLoss, "Structured Document Tags feature is not supported in DOC.");
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGlossaryDocumentStart(GlossaryDocument glossary)
	{
		xbbf9a1ead81dd3a1(WarningType.DataLoss, "Glossary Document feature is not supported in DOC.");
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSubDocument(SubDocument subDocument)
	{
		x3d1e23f776308a10.xa2cd36b80ce91fbe(subDocument);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitAbsolutePositionTab(AbsolutePositionTab tab)
	{
		xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Absolute position tabs are not supported in DOC, using regular tab character.");
		x811fbd3fde91eb05(new string('\t', 1), tab.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	private bool x0b7d4e74b9ac7a04()
	{
		if (x9e131021ba70185c == x9e131021ba70185c.x1ea60bde2b5d0d28)
		{
			return xb36c250515e408ad.xdff795aea0409829;
		}
		return false;
	}

	private void x636457dda93ec7a1()
	{
		xa6172040dc8d693f.xfc37d20436abe4da = 2048;
		x360620a398807923.Seek(2048L, SeekOrigin.Begin);
		xa6172040dc8d693f.x3ab228b2748114ba = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.xc447809891322395).x6210059f049f0d48(x80f57697b4c811e9);
		xa6172040dc8d693f.xb2064fa1fb7ec49d = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.x69d28a4aeef83a6f).x6210059f049f0d48(x80f57697b4c811e9);
		xa6172040dc8d693f.xb7cf421883a1056d = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.x1ea60bde2b5d0d28).x6210059f049f0d48(x80f57697b4c811e9);
		xa6172040dc8d693f.xe912105fd2ce9a26 = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.x937e050c63ea1527).x6210059f049f0d48(x80f57697b4c811e9);
		xa6172040dc8d693f.xe424d5fa33780ef0 = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.xd90ac7fcbe961761).x6210059f049f0d48(x80f57697b4c811e9);
		xa6172040dc8d693f.x104e0eb43d042a92 = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.xf79eacb7dc6313bb).x6210059f049f0d48(x80f57697b4c811e9);
		xa6172040dc8d693f.x0e27fa6d83e7f186 = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.xda79e5b626eda365).x6210059f049f0d48(x80f57697b4c811e9);
		if (xa6172040dc8d693f.xb2064fa1fb7ec49d > 0 || xa6172040dc8d693f.xb7cf421883a1056d > 0 || xa6172040dc8d693f.xe912105fd2ce9a26 > 0 || xa6172040dc8d693f.xe424d5fa33780ef0 > 0 || xa6172040dc8d693f.x104e0eb43d042a92 > 0 || xa6172040dc8d693f.x0e27fa6d83e7f186 > 0)
		{
			xa6172040dc8d693f.x0e27fa6d83e7f186--;
		}
		xa6172040dc8d693f.xac503f724179767e = (int)x360620a398807923.Position;
	}

	private void x64048ad4d39c9f2a()
	{
		if (xa4167addc9c6947c)
		{
			x6e9a51819a170c0d = new x414106297e729800();
			x6e9a51819a170c0d.x34c2fd9630dc4e80(xb9e6b034b22e403e, ((DocSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d).Password);
		}
		xa6172040dc8d693f.x955a03f821588c52.x9865ed3780825cad.xe53f0e68147463d1 = (xa6172040dc8d693f.x955a03f821588c52.x31959440f3d354a7.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position);
		x44ac55e8c9dbd30d x44ac55e8c9dbd30d = new x44ac55e8c9dbd30d(x232be220f517f721.FontInfos, xaca3428582882d9d, x232be220f517f721.Styles, xf69ca7a9bb4a4a51);
		xa6172040dc8d693f.x955a03f821588c52.x9865ed3780825cad.x04c290dc4d04369c = (xa6172040dc8d693f.x955a03f821588c52.x31959440f3d354a7.x04c290dc4d04369c = x44ac55e8c9dbd30d.x6210059f049f0d48(xb9e6b034b22e403e));
		xa6172040dc8d693f.x955a03f821588c52.x55ca9798f02b1f37.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.x55ca9798f02b1f37.x04c290dc4d04369c = xb62384534c3b4daa.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.xed30beec15e68cab((int)x45cd25510b3594a3.Position);
		xa6172040dc8d693f.x955a03f821588c52.xe9e3d679ffb87468.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xe9e3d679ffb87468.x04c290dc4d04369c = x2a8c54cec2ed34c4.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.x03f990c30d457af3.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.x03f990c30d457af3.x04c290dc4d04369c = x92b07040c889a19b.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.xdbb3d6f783bebba7.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xdbb3d6f783bebba7.x04c290dc4d04369c = x26682442e5155e8a.x6210059f049f0d48(xb9e6b034b22e403e);
		x3613df8e6a658a81.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e);
		xc5c7ba24502dc004.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e);
		x96f19c22613114cd.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.x4e5af45e90e86266.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.x4e5af45e90e86266.x04c290dc4d04369c = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.xc447809891322395).x84aa3570d857bec4.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.xd42cf51f01c25e54.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xd42cf51f01c25e54.x04c290dc4d04369c = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.x1ea60bde2b5d0d28).x84aa3570d857bec4.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.x9cc70b5da3f30539.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.x9cc70b5da3f30539.x04c290dc4d04369c = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.x69d28a4aeef83a6f).x84aa3570d857bec4.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.x266b4e5c7534e0a8.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.x266b4e5c7534e0a8.x04c290dc4d04369c = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.x937e050c63ea1527).x84aa3570d857bec4.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.xc85e1fbe5c0265f9.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xc85e1fbe5c0265f9.x04c290dc4d04369c = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.xd90ac7fcbe961761).x84aa3570d857bec4.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.xf21a0a6a898debc2.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xf21a0a6a898debc2.x04c290dc4d04369c = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.xf79eacb7dc6313bb).x84aa3570d857bec4.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.xe38f741b7cacc4ff.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xe38f741b7cacc4ff.x04c290dc4d04369c = x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x9e131021ba70185c.xda79e5b626eda365).x84aa3570d857bec4.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.xce577ad5c3409328.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		bool x9c3d5a1ae48b1ea = xa6172040dc8d693f.xb7cf421883a1056d > 0;
		xa6172040dc8d693f.x955a03f821588c52.xce577ad5c3409328.x04c290dc4d04369c = x50fd2f87dafc0d07.xbf993c53e1cbdfb1.x6210059f049f0d48(xb9e6b034b22e403e, x80f57697b4c811e9, x9c3d5a1ae48b1ea);
		xa71a1ee23c38552d.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e);
		xc335834826922c5b.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e);
		x3d1e23f776308a10.xeafe18c850ae3127.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e, x3d1e23f776308a10.x94a76e3a5bbb5ca6);
		x3d1e23f776308a10.xd0816c20f484d380.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e);
		x3d1e23f776308a10.x79d596439da1c44b.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e);
		if (x232be220f517f721.xa3c04447aa84f70f != null)
		{
			xa6172040dc8d693f.x955a03f821588c52.xf486349ad5db7bec.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
			xb9e6b034b22e403e.Write(x232be220f517f721.xa3c04447aa84f70f);
			xa6172040dc8d693f.x955a03f821588c52.xf486349ad5db7bec.x04c290dc4d04369c = x232be220f517f721.xa3c04447aa84f70f.Length;
		}
		x4e41835376268d39 x4e41835376268d = new x4e41835376268d39(x232be220f517f721.FontInfos, xaca3428582882d9d, x232be220f517f721.Lists, xf69ca7a9bb4a4a51);
		x4e41835376268d.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e);
		xe6daf81eea39f8f3.x6210059f049f0d48(xa6172040dc8d693f, xb9e6b034b22e403e, x232be220f517f721.Lists, x232be220f517f721.x227665e444fb500a);
		if (x232be220f517f721.x5408c1b8277b7b1a != null)
		{
			xa6172040dc8d693f.x955a03f821588c52.x5408c1b8277b7b1a.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
			xa6172040dc8d693f.x955a03f821588c52.x5408c1b8277b7b1a.x04c290dc4d04369c = x232be220f517f721.x5408c1b8277b7b1a.x6210059f049f0d48(xb9e6b034b22e403e, x232be220f517f721.xdade2366eaa6f915.x64d2067aa07ebd4f);
		}
		xd579be970f60ebcb xd579be970f60ebcb = new xd579be970f60ebcb();
		xa6172040dc8d693f.x955a03f821588c52.xc3533e44c5d8afad.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xc3533e44c5d8afad.x04c290dc4d04369c = xd579be970f60ebcb.x6210059f049f0d48(x232be220f517f721, xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.xd6d54512da92fc89.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xd6d54512da92fc89.x04c290dc4d04369c = x7afea2b34821ae67.x6210059f049f0d48(x232be220f517f721, xb9e6b034b22e403e);
		xa6172040dc8d693f.x01bd3f0735eb5899.xed30beec15e68cab((int)x45cd25510b3594a3.Position);
		x8f4cc590b89c730d x8f4cc590b89c730d = new x8f4cc590b89c730d();
		xc77edd00162b84f4 xbfdac581682856b = new xc77edd00162b84f4(0, x3d1e23f776308a10.x94a76e3a5bbb5ca6, 2048, isUnicode: true);
		x8f4cc590b89c730d.xd6b6ed77479ef68c(xbfdac581682856b);
		xa6172040dc8d693f.x955a03f821588c52.x84d66a6d1fa468c7.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		x8f4cc590b89c730d.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.x84d66a6d1fa468c7.x04c290dc4d04369c = (int)x45cd25510b3594a3.Position - xa6172040dc8d693f.x955a03f821588c52.x84d66a6d1fa468c7.xe53f0e68147463d1;
		xa6172040dc8d693f.xa9455751659fce9a = false;
		xa6172040dc8d693f.xdfcd77c301257abf = 15;
		xa68b7097d25ac20d.x6210059f049f0d48(x232be220f517f721.FontInfos, xa6172040dc8d693f, xb9e6b034b22e403e, x80f57697b4c811e9);
		xa6172040dc8d693f.x955a03f821588c52.x3dfed1bed9738813.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.x3dfed1bed9738813.x04c290dc4d04369c = x1f93754c360623ac.x6210059f049f0d48(x232be220f517f721, xb9e6b034b22e403e, xf69ca7a9bb4a4a51);
		xa6172040dc8d693f.x61c3ae0ca90c00b3.x0f731a94af712eba.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x61c3ae0ca90c00b3.x0f731a94af712eba.x04c290dc4d04369c = x2b6c31cefc5cb221();
		xa6172040dc8d693f.x955a03f821588c52.xaeecc4859c1418bf.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xaeecc4859c1418bf.x04c290dc4d04369c = x3eeabf00e1108d97();
		xa6172040dc8d693f.x955a03f821588c52.x440deb16ce197f30.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.x440deb16ce197f30.x04c290dc4d04369c = xaca3428582882d9d.x6210059f049f0d48(xb9e6b034b22e403e);
		xb4278d25e0406614 xb4278d25e = new xb4278d25e0406614();
		x0bd8cf7f8e7e6606 x0bd8cf7f8e7e6607 = new x0bd8cf7f8e7e6606();
		x0bd8cf7f8e7e6607.x6210059f049f0d48(x232be220f517f721.xdade2366eaa6f915.xe690cef2446c7d46, xa6172040dc8d693f, xb4278d25e, xb9e6b034b22e403e);
		x3d1e23f776308a10.x32cf407a95cab3cd.x6210059f049f0d48(xa6172040dc8d693f, xb4278d25e, xb9e6b034b22e403e);
		xa6172040dc8d693f.x955a03f821588c52.xb4278d25e0406614.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x955a03f821588c52.xb4278d25e0406614.x04c290dc4d04369c = xb4278d25e.x6210059f049f0d48(xb9e6b034b22e403e);
		xa6172040dc8d693f.x01bd3f0735eb5899.xf05e822d292058ad.xe53f0e68147463d1 = (int)x45cd25510b3594a3.Position;
		xa6172040dc8d693f.x01bd3f0735eb5899.xf05e822d292058ad.x04c290dc4d04369c = x7745dbafc8739775.Length;
		xb9e6b034b22e403e.Write(x7745dbafc8739775);
	}

	private int x2b6c31cefc5cb221()
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x232be220f517f721.xdade2366eaa6f915.x57a3ba5e84591507))
		{
			return 0;
		}
		byte[] bytes = Encoding.Unicode.GetBytes(x232be220f517f721.xdade2366eaa6f915.x57a3ba5e84591507);
		xb9e6b034b22e403e.Write(bytes);
		return bytes.Length;
	}

	private int x3eeabf00e1108d97()
	{
		StringCollection stringCollection = new StringCollection();
		stringCollection.Add(xebe9aafd87e65086(""));
		stringCollection.Add(xebe9aafd87e65086(x232be220f517f721.xdade2366eaa6f915.x8c0ad447fda248da));
		stringCollection.Add(xebe9aafd87e65086(x232be220f517f721.BuiltInDocumentProperties.Title));
		stringCollection.Add(xebe9aafd87e65086(x232be220f517f721.BuiltInDocumentProperties.Subject));
		stringCollection.Add(xebe9aafd87e65086(x232be220f517f721.BuiltInDocumentProperties.Keywords));
		stringCollection.Add(xebe9aafd87e65086(""));
		stringCollection.Add(xebe9aafd87e65086(x232be220f517f721.BuiltInDocumentProperties.Author));
		stringCollection.Add(xebe9aafd87e65086(x232be220f517f721.BuiltInDocumentProperties.LastSavedBy));
		stringCollection.Add(xebe9aafd87e65086(x232be220f517f721.xdade2366eaa6f915.xe690cef2446c7d46.DataSource));
		stringCollection.Add(xebe9aafd87e65086(x232be220f517f721.xdade2366eaa6f915.xe690cef2446c7d46.HeaderSource));
		for (int i = 0; i < 7; i++)
		{
			stringCollection.Add(xebe9aafd87e65086(""));
		}
		stringCollection.Add(xebe9aafd87e65086(x232be220f517f721.xdade2366eaa6f915.xc57807e17cfa13d2.x72213a2a58cf72d7()));
		return xaf807f6784ee1743.x6210059f049f0d48(xb9e6b034b22e403e, stringCollection);
	}

	private static string xebe9aafd87e65086(string xe4115acdf4fbfccc)
	{
		if (xe4115acdf4fbfccc.Length <= 255)
		{
			return xe4115acdf4fbfccc;
		}
		return "";
	}

	private void x6f235ed179e6fb4e()
	{
		xd556710597374e01 xd556710597374e2 = new xd556710597374e01();
		foreach (x34324dde15a17bf1 item in x3d1e23f776308a10)
		{
			xf8b5e62cf3165594 xf8b5e62cf = item.xf8b5e62cf3165594;
			for (int i = 0; i < xf8b5e62cf.x23719734cf1f138c; i++)
			{
				x3ff949c473a702d2 x3ff949c473a702d = xf8b5e62cf.get_xe6d4b1b411ed94b5(i);
				if (x3ff949c473a702d2.x6f3e3e0c92cba9ab(x3ff949c473a702d))
				{
					x3ff949c473a702d = x3ff949c473a702d2.x41e3dda3ab60a5ba(x537e1a6d567799a1, x3ff949c473a702d);
				}
				xd556710597374e2.xd6b6ed77479ef68c(xf8b5e62cf.xed8a0d4499d6f292(i), xf8b5e62cf.xed8a0d4499d6f292(i + 1), x3ff949c473a702d);
			}
		}
		x26682442e5155e8a = xd556710597374e2.xdc1f68583974b7db(x360620a398807923);
	}

	private void x537196dfb08681e8()
	{
		x093c0f4af0020c3c x093c0f4af0020c3c2 = new x093c0f4af0020c3c();
		int xb55016094f0bf0bc = 0;
		int num = 0;
		x9dba795deb731d48 x9dba795deb731d = null;
		foreach (x34324dde15a17bf1 item in x3d1e23f776308a10)
		{
			xdb6ea7a460485a97 xdb6ea7a460485a = item.xdb6ea7a460485a97;
			for (int i = 0; i < xdb6ea7a460485a.x23719734cf1f138c; i++)
			{
				int num2 = xdb6ea7a460485a.xed8a0d4499d6f292(i);
				int num3 = xdb6ea7a460485a.xed8a0d4499d6f292(i + 1);
				x9dba795deb731d48 x9dba795deb731d2 = xdb6ea7a460485a.get_xe6d4b1b411ed94b5(i);
				if (x9dba795deb731d == null)
				{
					xb55016094f0bf0bc = num2;
					num = num3;
					x9dba795deb731d = x9dba795deb731d2;
				}
				else if (x9dba795deb731d.Equals(x9dba795deb731d2))
				{
					if (num != num2)
					{
						throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("njkndmbogmiomlpopkgpignpgkeacglagkcbnjjbjkacgfhcfjocfjfdbkmdbkdemikejibfpiifodpfbiggbingbiehhhlhpcciohjiohajehhjghojocfk", 1435753047)));
					}
					num = num3;
				}
				else
				{
					x093c0f4af0020c3c2.xd6b6ed77479ef68c(xb55016094f0bf0bc, num, x9dba795deb731d);
					xb55016094f0bf0bc = num2;
					num = num3;
					x9dba795deb731d = x9dba795deb731d2;
				}
			}
		}
		if (x9dba795deb731d != null)
		{
			x093c0f4af0020c3c2.xd6b6ed77479ef68c(xb55016094f0bf0bc, num, x9dba795deb731d);
		}
		x92b07040c889a19b = x093c0f4af0020c3c2.xdc1f68583974b7db(x360620a398807923);
	}

	private bool xf5cf72897196b966(x9e131021ba70185c x77b06614416ee4d3)
	{
		if (x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x77b06614416ee4d3).x1be93eed8950d961 > 0)
		{
			x1238479da7c66191 x1238479da7c = x56e5a2c6f7ef0a50(x77b06614416ee4d3);
			x10b00fc1d89e308c x10b00fc1d89e308c = new x10b00fc1d89e308c();
			x10b00fc1d89e308c.x5db45988d4e40802 = -1;
			x1238479da7c.x6d996d87ff4d558d.xd6b6ed77479ef68c(x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x77b06614416ee4d3).x1be93eed8950d961, x10b00fc1d89e308c);
			x93bd964be1cf898b x93bd964be1cf898b = new x93bd964be1cf898b();
			x93bd964be1cf898b.xd81f84c63877d333 = 65535;
			xa2d227fe32eaf9f1(x77b06614416ee4d3, x1238479da7c.xe34a3fe7b2d83a85, x93bd964be1cf898b);
			return true;
		}
		return false;
	}

	private bool x1e75b9fd5a56c497()
	{
		return xa2d227fe32eaf9f1(x9e131021ba70185c.x1ea60bde2b5d0d28, x2a8c54cec2ed34c4, null);
	}

	private bool x1309751f24618f6c(FootnoteType xd3526c7313d75391)
	{
		x9e131021ba70185c x77b06614416ee4d = xd452a5f78fa06e8b.xa339e023ec82f1e3(xd3526c7313d75391);
		xd452a5f78fa06e8b xd452a5f78fa06e8b = xe1d0e02959854092(xd3526c7313d75391);
		return xa2d227fe32eaf9f1(x77b06614416ee4d, xd452a5f78fa06e8b.x0747bb83818026da, null);
	}

	private bool x08a3c71a2757edb3()
	{
		return xa2d227fe32eaf9f1(x9e131021ba70185c.x937e050c63ea1527, x96f19c22613114cd.x3368fdcc844084ff, null);
	}

	private bool xa2d227fe32eaf9f1(x9e131021ba70185c x77b06614416ee4d3, x6fa6e31d93cf837a xe83fbae1e983d207, xf67718a36ff889c3 x177a4864b73c3621)
	{
		if (x3d1e23f776308a10.get_xe6d4b1b411ed94b5(x77b06614416ee4d3).x1be93eed8950d961 > 0)
		{
			x3d1e23f776308a10.xb264ad2ce3daa0a4(x77b06614416ee4d3);
			xe83fbae1e983d207.xd6b6ed77479ef68c(x3d1e23f776308a10.x3e287ef15dc898f3, x177a4864b73c3621);
			Paragraph paragraph = new Paragraph(x232be220f517f721);
			paragraph.Accept(this);
			xe83fbae1e983d207.xd6b6ed77479ef68c(x3d1e23f776308a10.x3e287ef15dc898f3 + 2);
			x3d1e23f776308a10.xc4104b442b4f6eb6();
			return true;
		}
		xe83fbae1e983d207.xa9d636b00ff486b7();
		return false;
	}

	internal void x811fbd3fde91eb05(string xb41faee6912a2313, xeedad81aaed42a76 x789564759d365819)
	{
		x811fbd3fde91eb05(xb41faee6912a2313, x789564759d365819, x308ec08169534dcb);
	}

	internal void x811fbd3fde91eb05(string xb41faee6912a2313, xeedad81aaed42a76 x789564759d365819, xa52f2632c0ffdfaf xe08a26cc2b49f3aa)
	{
		if (!(xb41faee6912a2313 == string.Empty))
		{
			int x3e287ef15dc898f = x3d1e23f776308a10.x3e287ef15dc898f3;
			x3d1e23f776308a10.x917b69030691beda(xb41faee6912a2313);
			int x3e287ef15dc898f2 = x3d1e23f776308a10.x3e287ef15dc898f3;
			if (x789564759d365819 == null)
			{
				x789564759d365819 = xc50228abe02b4236;
			}
			x9dba795deb731d48 x95ebd6ae2e7f8ff = x326d2c4737b8a926.x6210059f049f0d48(x789564759d365819, xe08a26cc2b49f3aa, xdbd7ea0e47c93621 > 0);
			x3d1e23f776308a10.x811fbd3fde91eb05(x3e287ef15dc898f, x3e287ef15dc898f2, x95ebd6ae2e7f8ff);
			xc50228abe02b4236 = x789564759d365819;
		}
	}

	internal void x544c864b2d73388d(FieldType x77ce91e5324df734, xeedad81aaed42a76 x789564759d365819)
	{
		if (x5c29822913be33c1.xc53b1fb81a461c42(x77ce91e5324df734))
		{
			xdbd7ea0e47c93621++;
		}
		else
		{
			byte b = 19;
			if (x77ce91e5324df734 == FieldType.FieldShape)
			{
				b = (byte)(b | 0x80u);
			}
			xb96b10c688c10ef2 xbecee44ffb4c67ff = new xb96b10c688c10ef2(b, (byte)x77ce91e5324df734);
			x3d1e23f776308a10.x69dc2014b9eea9e3(xbecee44ffb4c67ff);
		}
		x811fbd3fde91eb05(ControlChar.xcf72734b7092bebe, x789564759d365819, x70f4aa19e59d65fd);
	}

	internal void x2e2bbf4db242427d(xeedad81aaed42a76 x789564759d365819)
	{
		x68f1ceeee8e07202(x789564759d365819, x70f4aa19e59d65fd);
	}

	internal void xf1f82fcde3b22573(xeedad81aaed42a76 x789564759d365819, int xe680f7e4e9e521a9)
	{
		xa52f2632c0ffdfaf xa52f2632c0ffdfaf = xa52f2632c0ffdfaf.x4d40fe7248d54a12();
		xa52f2632c0ffdfaf.xc26441db92a14e8e = true;
		xa52f2632c0ffdfaf.x9316383434e67238 = true;
		xa52f2632c0ffdfaf.xf1d9b91c9700c401 = xe680f7e4e9e521a9;
		x68f1ceeee8e07202(x789564759d365819, xa52f2632c0ffdfaf);
	}

	internal void xfd30c9fe530c9b34(FieldSeparator xed9a565596a6ae3f)
	{
		string text = x5c29822913be33c1.x130349ecd69ef30b(xed9a565596a6ae3f);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x6d4549ea3e2a7a2c(text, xed9a565596a6ae3f.xeedad81aaed42a76);
		}
		x2e2bbf4db242427d(xed9a565596a6ae3f.xeedad81aaed42a76);
	}

	private void x6d4549ea3e2a7a2c(string xa490ad5ef1682691, xeedad81aaed42a76 x789564759d365819)
	{
		xa52f2632c0ffdfaf xa52f2632c0ffdfaf = new xa52f2632c0ffdfaf();
		xa52f2632c0ffdfaf.xa1a25be53d0a44c8 = true;
		xa52f2632c0ffdfaf.x1b36d8d878eccfb5 = true;
		xa52f2632c0ffdfaf.xf1d9b91c9700c401 = (int)x537e1a6d567799a1.Position;
		xdbd7ea0e47c93621++;
		x811fbd3fde91eb05('\u0001'.ToString(), x789564759d365819, xa52f2632c0ffdfaf);
		xdbd7ea0e47c93621--;
		long position = x537e1a6d567799a1.Position;
		x3054eb7434148cfa.Write(0);
		x3054eb7434148cfa.Write((short)68);
		x3054eb7434148cfa.Write(new byte[62]);
		x3054eb7434148cfa.Write(xef515ac4d57187c2.xed1b33c4a41501bf(xa490ad5ef1682691));
		long position2 = x537e1a6d567799a1.Position;
		x537e1a6d567799a1.Position = position;
		x3054eb7434148cfa.Write((int)(position2 - position));
		x537e1a6d567799a1.Position = position2;
	}

	private void x68f1ceeee8e07202(xeedad81aaed42a76 x789564759d365819, xa52f2632c0ffdfaf xe08a26cc2b49f3aa)
	{
		x3d1e23f776308a10.x69dc2014b9eea9e3(new xb96b10c688c10ef2(20, 255));
		x811fbd3fde91eb05(ControlChar.x094e1db5f87bb62b, x789564759d365819, xe08a26cc2b49f3aa);
	}

	internal void xfc282418f4ca7fa7(FieldType x77ce91e5324df734, xeedad81aaed42a76 x789564759d365819, bool x4797cf69c5ec19ff)
	{
		xfc282418f4ca7fa7(new FieldEnd(x2c8c6741422a1298, x789564759d365819, x77ce91e5324df734, x4797cf69c5ec19ff));
	}

	internal void xfc282418f4ca7fa7(FieldEnd xc87e4e475724f9c3)
	{
		if (!x5c29822913be33c1.xc53b1fb81a461c42(xc87e4e475724f9c3.FieldType))
		{
			xb96b10c688c10ef2 xb96b10c688c10ef = new xb96b10c688c10ef2(21, 0);
			xb96b10c688c10ef.xc077cfa8d6f9e3c5 = xc87e4e475724f9c3.HasSeparator;
			if (xc87e4e475724f9c3.FieldType == FieldType.FieldShape)
			{
				xb96b10c688c10ef.x991897f13cf6aadc = true;
				xb96b10c688c10ef.x6e94079169d5a06e = true;
				xb96b10c688c10ef.xeb7fdc71f3103e2e = true;
			}
			else
			{
				xb96b10c688c10ef.x991897f13cf6aadc = xc87e4e475724f9c3.IsLocked;
				xb96b10c688c10ef.x6e94079169d5a06e = xc87e4e475724f9c3.x6e94079169d5a06e;
			}
			x3d1e23f776308a10.x69dc2014b9eea9e3(xb96b10c688c10ef);
		}
		x811fbd3fde91eb05(ControlChar.x3bb349c77392b35c, xc87e4e475724f9c3.xeedad81aaed42a76, x70f4aa19e59d65fd);
		if (x5c29822913be33c1.xc53b1fb81a461c42(xc87e4e475724f9c3.FieldType))
		{
			xdbd7ea0e47c93621--;
		}
	}

	internal void x51bc52e131b1c9e3(xac083244a6c1aa10 x88b222290ee177b4)
	{
		x1238479da7c66191 x1238479da7c = x56e5a2c6f7ef0a50(x3d1e23f776308a10.x9e131021ba70185c);
		x1238479da7c.x4a74ca8842ca69ab.xd6b6ed77479ef68c(x3d1e23f776308a10.x3e287ef15dc898f3, x88b222290ee177b4);
	}

	internal int x91774896a6f5023b(x10b00fc1d89e308c xe617a5f89540b1fd)
	{
		x1238479da7c66191 x1238479da7c = x56e5a2c6f7ef0a50(x3d1e23f776308a10.x9e131021ba70185c);
		return x1238479da7c.x6d996d87ff4d558d.xd6b6ed77479ef68c(x3d1e23f776308a10.x3e287ef15dc898f3, xe617a5f89540b1fd);
	}

	internal void x0f9832554a20d1bb(x93bd964be1cf898b x2c6e540617b25d71)
	{
		x1238479da7c66191 x1238479da7c = x56e5a2c6f7ef0a50(x3d1e23f776308a10.x9e131021ba70185c);
		x1238479da7c.xe34a3fe7b2d83a85.xd6b6ed77479ef68c(x3d1e23f776308a10.x3e287ef15dc898f3, x2c6e540617b25d71);
	}

	internal void xb264ad2ce3daa0a4(x9e131021ba70185c x77b06614416ee4d3)
	{
		x3d1e23f776308a10.xb264ad2ce3daa0a4(x77b06614416ee4d3);
	}

	internal void xc4104b442b4f6eb6()
	{
		x3d1e23f776308a10.xc4104b442b4f6eb6();
	}

	public void x18c776ebc56d8212(CustomXmlMarkup x2f992229ae4fc9a1)
	{
		x3d1e23f776308a10.x2a6a39361495c83c(x2f992229ae4fc9a1);
		x811fbd3fde91eb05(ControlChar.x8d2c1165b1fe4efd, new xeedad81aaed42a76(), x70f4aa19e59d65fd);
	}

	public void x0a79c02b4c66999f(CustomXmlMarkup x2f992229ae4fc9a1)
	{
		x811fbd3fde91eb05(ControlChar.x57d0e414238eb872, new xeedad81aaed42a76(), x70f4aa19e59d65fd);
		x3d1e23f776308a10.x69b2ede4917298d1(x2f992229ae4fc9a1);
	}

	private x1238479da7c66191 x56e5a2c6f7ef0a50(x9e131021ba70185c x77b06614416ee4d3)
	{
		switch (x77b06614416ee4d3)
		{
		case x9e131021ba70185c.xc447809891322395:
		case x9e131021ba70185c.xf79eacb7dc6313bb:
			return xa71a1ee23c38552d;
		case x9e131021ba70185c.x1ea60bde2b5d0d28:
		case x9e131021ba70185c.xda79e5b626eda365:
			return xc335834826922c5b;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ippkoahlcaolcbfmhammjpcnepjncaboaphomooofkfpfpmpepdaonkannbbfoibgnpbfogcknncpmedfnldincebijecnafenhfimofklfgaimg", 587771811)));
		}
	}

	private xd452a5f78fa06e8b xe1d0e02959854092(FootnoteType xd3526c7313d75391)
	{
		return xd3526c7313d75391 switch
		{
			FootnoteType.Footnote => x3613df8e6a658a81, 
			FootnoteType.Endnote => xc5c7ba24502dc004, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cgjiihajchhjchojahfkfhmkjgdlibkllfbmbgimofpmaggnhfnnffeohflofecpnpipoeaaafhaeeoagdfbmplb", 780568845))), 
		};
	}

	private x7f77ea92be0d9042 x9913a2fbad46cb1a(x7f77ea92be0d9042 xad5ee812e0b28f28)
	{
		if (x544693467ef27aac == null)
		{
			return xad5ee812e0b28f28;
		}
		if (!x544693467ef27aac.xdb8d101b58051732)
		{
			return xad5ee812e0b28f28.x75eab24f5629a618;
		}
		return xad5ee812e0b28f28;
	}
}
