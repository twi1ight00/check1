using System;
using System.Collections;
using Aspose.Words.BuildingBlocks;
using Aspose.Words.Drawing;
using Aspose.Words.Markup;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x28925c9b27b37a46;

namespace Aspose.Words;

public class NodeImporter
{
	private readonly x7f4fa84f489f40ab x8cedcaa9a62c6e39;

	private readonly bool x9b756e017c567ca5;

	private readonly bool x6484d42b73aeb883;

	private readonly Hashtable x0f5bfcfc68361538 = new Hashtable();

	public NodeImporter(DocumentBase srcDoc, DocumentBase dstDoc, ImportFormatMode importFormatMode)
	{
		if (srcDoc == null)
		{
			throw new ArgumentNullException("srcDoc");
		}
		if (dstDoc == null)
		{
			throw new ArgumentNullException("dstDoc");
		}
		x8cedcaa9a62c6e39 = new x7f4fa84f489f40ab(srcDoc, dstDoc, importFormatMode);
		x9b756e017c567ca5 = !srcDoc.Styles.x27096df7ca0cfe2e.Equals(dstDoc.Styles.x27096df7ca0cfe2e, null);
		x6484d42b73aeb883 = !srcDoc.Styles.xf4eb04b8b9073eeb.Equals(dstDoc.Styles.xf4eb04b8b9073eeb, null);
		x25bec7d927ff69cb();
		dstDoc.FontInfos.xd5da23b762ce52a2(srcDoc.FontInfos);
	}

	public Node ImportNode(Node srcNode, bool isImportChildren)
	{
		return xd25152ffa2656dfc(srcNode, isImportChildren, null);
	}

	internal Node xd25152ffa2656dfc(Node x1725b053e96f3d2c, bool xdd3cf019c39dff8d, x15a33f6d96885286 x5ebbc4e56d2a7304)
	{
		Node result = xdc9716a272924158(x1725b053e96f3d2c, xdd3cf019c39dff8d, x5ebbc4e56d2a7304);
		x17047098d616a1cd();
		return result;
	}

	private void x17047098d616a1cd()
	{
		int num = x8cedcaa9a62c6e39.x5bb80c9bb5e94e7e.xc726a4cdc433ae49();
		int num2 = num;
		foreach (DictionaryEntry item in x0f5bfcfc68361538)
		{
			Shape shape = (Shape)item.Value;
			shape.xea1e81378298fa81 += num;
			num2 = System.Math.Max(num2, shape.xea1e81378298fa81);
			if (shape.xdf3d5f8941ea27a6 != 0)
			{
				if (x0f5bfcfc68361538[shape.xdf3d5f8941ea27a6] == null)
				{
					shape.xdf3d5f8941ea27a6 = 0;
					continue;
				}
				shape.xdf3d5f8941ea27a6 += num;
				num2 = System.Math.Max(num2, shape.xdf3d5f8941ea27a6);
			}
		}
		x8cedcaa9a62c6e39.x5bb80c9bb5e94e7e.x49f94af7002e0485(num2);
		x0f5bfcfc68361538.Clear();
	}

	private Node xdc9716a272924158(Node x1725b053e96f3d2c, bool xdd3cf019c39dff8d, x15a33f6d96885286 x5ebbc4e56d2a7304)
	{
		if (x1725b053e96f3d2c == null)
		{
			throw new ArgumentNullException("srcNode");
		}
		Node node = x1725b053e96f3d2c.x8b61531c8ea35b85(x7a5f12b98e34a590: false, x5ebbc4e56d2a7304);
		node.x3e229cd2762a6ef5(x8cedcaa9a62c6e39.x5bb80c9bb5e94e7e);
		if (xdd3cf019c39dff8d && x1725b053e96f3d2c.IsComposite)
		{
			xad9033169d1f2c54((CompositeNode)x1725b053e96f3d2c, (CompositeNode)node, x5ebbc4e56d2a7304);
		}
		x0ee761cb196059ef(x1725b053e96f3d2c, node);
		return node;
	}

	internal void xb7f923c74a5f39e0(CompositeNode x7ca0944187f19172, CompositeNode x9b17afe29ac398ab)
	{
		xad9033169d1f2c54(x7ca0944187f19172, x9b17afe29ac398ab, null);
		x17047098d616a1cd();
	}

	private void xad9033169d1f2c54(CompositeNode x7ca0944187f19172, CompositeNode x9b17afe29ac398ab, x15a33f6d96885286 x5ebbc4e56d2a7304)
	{
		if (x7ca0944187f19172 == null)
		{
			throw new ArgumentNullException("srcContainer");
		}
		if (x7ca0944187f19172.Document != x8cedcaa9a62c6e39.xbd43463cc8d073a3)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gjoncjfoaimonfdpgikpcibafiiapgpaehgbghnbkgecehlcpbcdpgjdbgaefgheigoemfffbfmfkadgjekgjebhneihnephjegipdnifpdjgeljodckmoikndalochlicolaoemadmmjcdnmckngcboebiodbpolmfpmanpebeafalaebcbjajboppbeahchaocoled", 772660771)));
		}
		if (x9b17afe29ac398ab == null)
		{
			throw new ArgumentNullException("dstContainer");
		}
		if (x9b17afe29ac398ab.Document != x8cedcaa9a62c6e39.x5bb80c9bb5e94e7e)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("idbleeilceploagmhdnmddengdlnaccofcjohcaplbhpfcopaneaacmacbdbgbkbjbbcnaiccapcllfdkpmdkpdeopkeopbfkpifappfgkgghpngpoehnjlhoocipnjijnajbjhjcnojanfklnmkjndllmklnmbmnlimnmpmplgncmnnoleonglookcpgljphkaaglhalkoaakfbgkmbjkdcagkc", 655601876)));
		}
		for (Node node = x7ca0944187f19172.FirstChild; node != null; node = node.NextSibling)
		{
			x9b17afe29ac398ab.AppendChild(xdc9716a272924158(node, xdd3cf019c39dff8d: true, x5ebbc4e56d2a7304));
		}
	}

	private void x0ee761cb196059ef(Node x1725b053e96f3d2c, Node xb39ac3acdf65ad5d)
	{
		if (x1725b053e96f3d2c is Shape)
		{
			int xea1e81378298fa = ((Shape)xb39ac3acdf65ad5d).xea1e81378298fa81;
			if (x0f5bfcfc68361538[xea1e81378298fa] == null)
			{
				x0f5bfcfc68361538.Add(xea1e81378298fa, xb39ac3acdf65ad5d);
			}
		}
		else if (x1725b053e96f3d2c is xcf3b0f04424de818)
		{
			x0a0a4cea00fc6191((xcf3b0f04424de818)x1725b053e96f3d2c, (xcf3b0f04424de818)xb39ac3acdf65ad5d);
		}
		else if (x1725b053e96f3d2c is Paragraph)
		{
			xca5a16fd349e4e76((Paragraph)x1725b053e96f3d2c, (Paragraph)xb39ac3acdf65ad5d);
		}
		else if (x1725b053e96f3d2c is Row)
		{
			x81f78ebaaa78ed06(((Row)xb39ac3acdf65ad5d).xedb0eb766e25e0c9, 4005, 11);
		}
		else if (x1725b053e96f3d2c is StructuredDocumentTag)
		{
			x20e7c8932583b6ab((StructuredDocumentTag)x1725b053e96f3d2c, (StructuredDocumentTag)xb39ac3acdf65ad5d);
		}
		if (x1725b053e96f3d2c is x8ad0c0863d1cd403)
		{
			x69df7bcb6989b7ce((x8ad0c0863d1cd403)x1725b053e96f3d2c, (x8ad0c0863d1cd403)xb39ac3acdf65ad5d);
		}
	}

	private void x0a0a4cea00fc6191(xcf3b0f04424de818 x7e632b2250baa0d6, xcf3b0f04424de818 xb833d59c5b393ddb)
	{
		xeedad81aaed42a76 xf71234fc914eccad = null;
		if (x9b756e017c567ca5)
		{
			xf71234fc914eccad = x7e632b2250baa0d6.x75cbc81364d91526(xecac24b19ed3a2b7.xe9e531d1a6725226);
		}
		x66c7e603fa9a813c(xf71234fc914eccad, xb833d59c5b393ddb.xc87649c48f7756d2);
		if (x7e632b2250baa0d6.xc87649c48f7756d2.x0f53f53f15b61ef5)
		{
			xeedad81aaed42a76 xc87649c48f7756d = (xeedad81aaed42a76)x7e632b2250baa0d6.xc87649c48f7756d2.x5fb16e270c21db2e.xdf4bcc85da8f85b2;
			xeedad81aaed42a76 x4ac4562403543b7a = (xeedad81aaed42a76)xb833d59c5b393ddb.xc87649c48f7756d2.x5fb16e270c21db2e.xdf4bcc85da8f85b2;
			xeedad81aaed42a76 xf71234fc914eccad2 = null;
			if (x9b756e017c567ca5)
			{
				xeedad81aaed42a76 xc87649c48f7756d2 = x7e632b2250baa0d6.xc87649c48f7756d2;
				x7e632b2250baa0d6.xc87649c48f7756d2 = xc87649c48f7756d;
				xf71234fc914eccad2 = x7e632b2250baa0d6.x75cbc81364d91526(xecac24b19ed3a2b7.xe9e531d1a6725226);
				x7e632b2250baa0d6.xc87649c48f7756d2 = xc87649c48f7756d2;
			}
			x66c7e603fa9a813c(xf71234fc914eccad2, x4ac4562403543b7a);
		}
	}

	private void xca5a16fd349e4e76(Paragraph x50a18ad2656e7181, Paragraph x9e4d7279252bee4a)
	{
		if (x6484d42b73aeb883)
		{
			xb63613e598635765(x50a18ad2656e7181.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x5a060c44426263f6), x9e4d7279252bee4a.x1a78664fa10a3755);
		}
		x171291708f8edcf8(x50a18ad2656e7181.x1a78664fa10a3755, x9e4d7279252bee4a.x1a78664fa10a3755, x50a18ad2656e7181.Document == x9e4d7279252bee4a.Document);
		if (x50a18ad2656e7181.x1a78664fa10a3755.x0f53f53f15b61ef5)
		{
			x1a78664fa10a3755 x1a78664fa10a = (x1a78664fa10a3755)x50a18ad2656e7181.x1a78664fa10a3755.x5fb16e270c21db2e.xdf4bcc85da8f85b2;
			x1a78664fa10a3755 x1a78664fa10a2 = (x1a78664fa10a3755)x9e4d7279252bee4a.x1a78664fa10a3755.x5fb16e270c21db2e.xdf4bcc85da8f85b2;
			if (x6484d42b73aeb883)
			{
				x1a78664fa10a3755 x1a78664fa10a3 = (x1a78664fa10a3755)x50a18ad2656e7181.x1a78664fa10a3755.x8b61531c8ea35b85();
				x50a18ad2656e7181.x1a78664fa10a3755 = x1a78664fa10a;
				xb63613e598635765(x50a18ad2656e7181.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x5a060c44426263f6), x1a78664fa10a2);
				x50a18ad2656e7181.x1a78664fa10a3755 = x1a78664fa10a3;
			}
			x171291708f8edcf8(x1a78664fa10a, x1a78664fa10a2, x50a18ad2656e7181.Document == x9e4d7279252bee4a.Document);
		}
		xeedad81aaed42a76 xf71234fc914eccad = null;
		if (x9b756e017c567ca5)
		{
			xf71234fc914eccad = x50a18ad2656e7181.x3a7e67268c1cb407(xecac24b19ed3a2b7.xe9e531d1a6725226);
		}
		x66c7e603fa9a813c(xf71234fc914eccad, x9e4d7279252bee4a.x344511c4e4ce09da);
		if (x50a18ad2656e7181.x344511c4e4ce09da.x0f53f53f15b61ef5)
		{
			xeedad81aaed42a76 x344511c4e4ce09da = (xeedad81aaed42a76)x50a18ad2656e7181.x344511c4e4ce09da.x5fb16e270c21db2e.xdf4bcc85da8f85b2;
			xeedad81aaed42a76 x4ac4562403543b7a = (xeedad81aaed42a76)x9e4d7279252bee4a.x344511c4e4ce09da.x5fb16e270c21db2e.xdf4bcc85da8f85b2;
			xeedad81aaed42a76 xf71234fc914eccad2 = null;
			if (x9b756e017c567ca5)
			{
				xeedad81aaed42a76 x344511c4e4ce09da2 = (xeedad81aaed42a76)x50a18ad2656e7181.x344511c4e4ce09da.x8b61531c8ea35b85();
				x50a18ad2656e7181.x344511c4e4ce09da = x344511c4e4ce09da;
				xf71234fc914eccad2 = x50a18ad2656e7181.x3a7e67268c1cb407(xecac24b19ed3a2b7.xe9e531d1a6725226);
				x50a18ad2656e7181.x344511c4e4ce09da = x344511c4e4ce09da2;
			}
			x66c7e603fa9a813c(xf71234fc914eccad2, x4ac4562403543b7a);
		}
	}

	private void x171291708f8edcf8(x1a78664fa10a3755 xb8792a1426e7920b, x1a78664fa10a3755 xb3e285984f5ad9d1, bool x35ba426170379e71)
	{
		x81f78ebaaa78ed06(xb3e285984f5ad9d1, 1000, 0);
		int x71c63f7e57f7ede = xb8792a1426e7920b.x71c63f7e57f7ede5;
		if (x71c63f7e57f7ede != 0)
		{
			xb3e285984f5ad9d1.x71c63f7e57f7ede5 = (x35ba426170379e71 ? xb8792a1426e7920b.x71c63f7e57f7ede5 : x8cedcaa9a62c6e39.xfb9dbcd4f0daf938.x26885624294ecfb1(x8cedcaa9a62c6e39, x71c63f7e57f7ede));
		}
	}

	private void x20e7c8932583b6ab(StructuredDocumentTag xa6571231dc677ce4, StructuredDocumentTag x3fbe7ab3cba83b6c)
	{
		if (xa6571231dc677ce4.Document != x3fbe7ab3cba83b6c.Document)
		{
			x3fbe7ab3cba83b6c.xbf02a69b0d230435(xa6571231dc677ce4.Id);
		}
		if (xa6571231dc677ce4.xde86b50786169450.xd44988f225497f3a != 0)
		{
			x66c7e603fa9a813c(xa6571231dc677ce4.xde86b50786169450, x3fbe7ab3cba83b6c.xde86b50786169450);
		}
		if (xa6571231dc677ce4.xa29d931f51e74fb3.xd44988f225497f3a != 0)
		{
			x66c7e603fa9a813c(xa6571231dc677ce4.xa29d931f51e74fb3, x3fbe7ab3cba83b6c.xa29d931f51e74fb3);
		}
		x29d264fa21219872(x3fbe7ab3cba83b6c, x3fbe7ab3cba83b6c.Placeholder);
	}

	private static void x29d264fa21219872(StructuredDocumentTag x3fbe7ab3cba83b6c, BuildingBlock xb92420e231971f3e)
	{
		if (xb92420e231971f3e != null)
		{
			GlossaryDocument glossaryDocument = x7d63e0b9e7adbb53(x3fbe7ab3cba83b6c.Document);
			if (xb92420e231971f3e.Document != glossaryDocument)
			{
				BuildingBlock newChild = (BuildingBlock)glossaryDocument.ImportNode(xb92420e231971f3e, isImportChildren: true);
				glossaryDocument.AppendChild(newChild);
				x3fbe7ab3cba83b6c.x3c0af6fbd91b1638(x2e5cc5728d3cf72d: true);
			}
			else
			{
				x3fbe7ab3cba83b6c.x3c0af6fbd91b1638(x2e5cc5728d3cf72d: false);
			}
		}
	}

	private static GlossaryDocument x7d63e0b9e7adbb53(DocumentBase x6beba47238e0ade6)
	{
		GlossaryDocument glossaryDocument = ((x6beba47238e0ade6.NodeType == NodeType.GlossaryDocument) ? ((GlossaryDocument)x6beba47238e0ade6) : ((Document)x6beba47238e0ade6).GlossaryDocument);
		if (glossaryDocument == null)
		{
			Document document = (Document)x6beba47238e0ade6;
			document.GlossaryDocument = new GlossaryDocument();
			glossaryDocument = document.GlossaryDocument;
		}
		return glossaryDocument;
	}

	private void x69df7bcb6989b7ce(x8ad0c0863d1cd403 xadbffda10de476d0, x8ad0c0863d1cd403 x2ec5bacd4a00f3e6)
	{
		object obj = x8cedcaa9a62c6e39.x8454a02527cde8d7[xadbffda10de476d0.x417a0a94031e7e8b];
		if (obj == null)
		{
			obj = x8cedcaa9a62c6e39.x5bb80c9bb5e94e7e.x8ef8795c4475a0e3();
			x8cedcaa9a62c6e39.x8454a02527cde8d7[xadbffda10de476d0.x417a0a94031e7e8b] = obj;
		}
		x2ec5bacd4a00f3e6.x417a0a94031e7e8b = (int)obj;
	}

	private void x25bec7d927ff69cb()
	{
		if (x8cedcaa9a62c6e39.xbd43463cc8d073a3 is Document document && x8cedcaa9a62c6e39.x5bb80c9bb5e94e7e is Document document2 && document.x9bb3f6e28fa55f34() != null && document2.x9bb3f6e28fa55f34() == null)
		{
			document2.x18ee99b6e1fced19(document.x9bb3f6e28fa55f34().x8b61531c8ea35b85());
		}
	}

	private void x66c7e603fa9a813c(xeedad81aaed42a76 xf71234fc914eccad, xeedad81aaed42a76 x4ac4562403543b7a)
	{
		if (x9b756e017c567ca5)
		{
			x40e14b2ac1f279c2(xf71234fc914eccad, x4ac4562403543b7a);
		}
		x81f78ebaaa78ed06(x4ac4562403543b7a, 50, 10);
	}

	private void xb63613e598635765(x1a78664fa10a3755 xb006d07a00366c50, x1a78664fa10a3755 x413ad57881c238a0)
	{
		x1a78664fa10a3755 xf4eb04b8b9073eeb = x8cedcaa9a62c6e39.x0470af4c45101cb7.xf4eb04b8b9073eeb;
		for (int i = 0; i < xf4eb04b8b9073eeb.xd44988f225497f3a; i++)
		{
			int xba08ce632055a1d = xf4eb04b8b9073eeb.xf15263674eb297bb(i);
			if (!xb006d07a00366c50.xbc5dc59d0d9b620d(xba08ce632055a1d))
			{
				x413ad57881c238a0.xae20093bed1e48a8(xba08ce632055a1d, xf4eb04b8b9073eeb.x6d3720b962bd3112(i));
			}
		}
	}

	private void x40e14b2ac1f279c2(xeedad81aaed42a76 xb006d07a00366c50, xeedad81aaed42a76 x413ad57881c238a0)
	{
		xeedad81aaed42a76 x27096df7ca0cfe2e = x8cedcaa9a62c6e39.x0470af4c45101cb7.x27096df7ca0cfe2e;
		for (int i = 0; i < x27096df7ca0cfe2e.xd44988f225497f3a; i++)
		{
			int xba08ce632055a1d = x27096df7ca0cfe2e.xf15263674eb297bb(i);
			if (!x58a9097546dfa08f(xba08ce632055a1d, xb006d07a00366c50))
			{
				x413ad57881c238a0.xae20093bed1e48a8(xba08ce632055a1d, x27096df7ca0cfe2e.x6d3720b962bd3112(i));
			}
		}
	}

	private void x81f78ebaaa78ed06(x4c1e058c67948d6a x9e4d7279252bee4a, int x67e055991ce839a1, int x81d973eeafae2be3)
	{
		int xddd12ddd8b1e4a = (int)x9e4d7279252bee4a.xfe91eeeafcb3026a(x67e055991ce839a1);
		Style x464349d05eb2b57c = x8cedcaa9a62c6e39.x0470af4c45101cb7.xf194004582627ed5(xddd12ddd8b1e4a, x81d973eeafae2be3);
		Style style = x8cedcaa9a62c6e39.x7ad0923dc651ebad.x81f78ebaaa78ed06(x8cedcaa9a62c6e39, x464349d05eb2b57c);
		switch (x67e055991ce839a1)
		{
		case 50:
			if (style.Type == StyleType.Paragraph)
			{
				style = style.xe617ec963a7004e3();
			}
			if (style != null)
			{
				x9e4d7279252bee4a.xae20093bed1e48a8(x67e055991ce839a1, style.x8301ab10c226b0c2);
			}
			break;
		case 1000:
		case 4005:
			x9e4d7279252bee4a.xae20093bed1e48a8(x67e055991ce839a1, style.x8301ab10c226b0c2);
			break;
		default:
			throw new InvalidOperationException("Unexpected istdKey value.");
		}
		x0b310572e0761a5e(x464349d05eb2b57c, style);
	}

	private void x0b310572e0761a5e(Style x464349d05eb2b57c, Style x63e78703e64bb044)
	{
		if (x63e78703e64bb044 != null)
		{
			x0b310572e0761a5e(x464349d05eb2b57c, x63e78703e64bb044, x22d4d2e04401ba0e: false);
			x0b310572e0761a5e(x464349d05eb2b57c, x63e78703e64bb044, x22d4d2e04401ba0e: true);
		}
	}

	private void x0b310572e0761a5e(Style x464349d05eb2b57c, Style x63e78703e64bb044, bool x22d4d2e04401ba0e)
	{
		if (x8cedcaa9a62c6e39.xcea1c437a94c4d02 != ImportFormatMode.KeepSourceFormatting || x464349d05eb2b57c.StyleIdentifier == StyleIdentifier.DefaultParagraphFont || x464349d05eb2b57c.StyleIdentifier == StyleIdentifier.TableNormal)
		{
			return;
		}
		x4c1e058c67948d6a x4c1e058c67948d6a = (x22d4d2e04401ba0e ? ((x7f77ea92be0d9042)x8cedcaa9a62c6e39.x0470af4c45101cb7.x27096df7ca0cfe2e) : ((x7f77ea92be0d9042)x8cedcaa9a62c6e39.x0470af4c45101cb7.xf4eb04b8b9073eeb));
		x4c1e058c67948d6a x4c1e058c67948d6a2 = (x22d4d2e04401ba0e ? ((x7f77ea92be0d9042)x8cedcaa9a62c6e39.x7ad0923dc651ebad.x27096df7ca0cfe2e) : ((x7f77ea92be0d9042)x8cedcaa9a62c6e39.x7ad0923dc651ebad.xf4eb04b8b9073eeb));
		x4c1e058c67948d6a x4c1e058c67948d6a3 = (x22d4d2e04401ba0e ? ((x7f77ea92be0d9042)x63e78703e64bb044.xeedad81aaed42a76) : ((x7f77ea92be0d9042)x63e78703e64bb044.x1a78664fa10a3755));
		for (int i = 0; i < x4c1e058c67948d6a2.xd44988f225497f3a; i++)
		{
			int xba08ce632055a1d = x4c1e058c67948d6a2.xf15263674eb297bb(i);
			if (x4c1e058c67948d6a3.xbc5dc59d0d9b620d(xba08ce632055a1d))
			{
				continue;
			}
			object obj = x4c1e058c67948d6a2.xf7866f89640a29a3(xba08ce632055a1d);
			if (x4c1e058c67948d6a.xbc5dc59d0d9b620d(xba08ce632055a1d))
			{
				object obj2 = x4c1e058c67948d6a.xf7866f89640a29a3(xba08ce632055a1d);
				if (!obj2.Equals(obj))
				{
					x4c1e058c67948d6a3.xae20093bed1e48a8(xba08ce632055a1d, obj2);
				}
				continue;
			}
			if (x22d4d2e04401ba0e)
			{
				object obj3 = xeedad81aaed42a76.x0095b789d636f3ae(xba08ce632055a1d);
				if (!obj3.Equals(obj))
				{
					x4c1e058c67948d6a3.xae20093bed1e48a8(xba08ce632055a1d, obj3);
				}
				continue;
			}
			object obj4 = x464349d05eb2b57c.xd085e5852dc496c7(xba08ce632055a1d);
			if (obj4 == null)
			{
				obj4 = x1a78664fa10a3755.x0095b789d636f3ae(xba08ce632055a1d);
			}
			if (!obj4.Equals(obj))
			{
				x4c1e058c67948d6a3.xae20093bed1e48a8(xba08ce632055a1d, obj4);
			}
		}
	}

	private static bool x58a9097546dfa08f(int xba08ce632055a1d9, xeedad81aaed42a76 x2ccc28e45eea6445)
	{
		if (x2ccc28e45eea6445.xbc5dc59d0d9b620d(xba08ce632055a1d9))
		{
			return true;
		}
		xba08ce632055a1d9 = xba08ce632055a1d9 switch
		{
			530 => 230, 
			560 => 270, 
			550 => 235, 
			540 => 240, 
			_ => -1, 
		};
		if (xba08ce632055a1d9 >= 0)
		{
			return x2ccc28e45eea6445.xbc5dc59d0d9b620d(xba08ce632055a1d9);
		}
		return false;
	}
}
