using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Markup;
using Aspose.Words.Math;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;
using xf989f31a236ff98c;
using xfbd1009a0cbb9842;

namespace x2182451cabb5c30d;

internal class x4ba0e0b20eeff53c
{
	private static readonly xeedad81aaed42a76 x3a73dee84e0a9c16 = new xeedad81aaed42a76();

	private readonly xe5e546ef5f0503b2 x8cedcaa9a62c6e39;

	private readonly Stack xf8f23af472995af8 = new Stack();

	private readonly Stack xd48deb218af504df = new Stack();

	private bool x03725a0780edf469;

	private readonly Run xd0c7939d904920d7;

	private readonly x12d551e21425ffee x04562d8eb06323c7;

	private xedb0eb766e25e0c9 x65a7d6b2d7d591ac;

	private static readonly char[] xdeadbda6c88fe8dc = new char[2] { '\r', '\n' };

	private readonly ArrayList x8c14637c2f2070c2 = new ArrayList();

	private readonly ArrayList x9a5166a3417038a1 = new ArrayList();

	internal CompositeNode xc255c495fd9232ca => (CompositeNode)xf8f23af472995af8.Peek();

	internal xf8311f89980f27b1 xde27e91a248c4c90 => x8cedcaa9a62c6e39.xde27e91a248c4c90;

	internal FieldChar x3336ddd58ad28d89
	{
		get
		{
			if (xd48deb218af504df.Count <= 0)
			{
				return null;
			}
			return (FieldChar)xd48deb218af504df.Peek();
		}
	}

	private bool x96c280a5c67d7df3
	{
		get
		{
			if (xffbea9fd9d484c1f != NodeType.Paragraph && xffbea9fd9d484c1f != NodeType.SmartTag)
			{
				return xffbea9fd9d484c1f == NodeType.OfficeMath;
			}
			return true;
		}
	}

	private NodeType xffbea9fd9d484c1f => xc255c495fd9232ca.NodeType;

	private Document x2c8c6741422a1298 => x8cedcaa9a62c6e39.x2c8c6741422a1298;

	private x52108cac3d36b123 xffb3238a8fd59aa7 => x8cedcaa9a62c6e39.xa3a0cc3e91617aca.xffb3238a8fd59aa7;

	internal x4ba0e0b20eeff53c(xe5e546ef5f0503b2 context)
	{
		x04562d8eb06323c7 = new x12d551e21425ffee(context.xf69ca7a9bb4a4a51, WarningSource.Rtf);
		x8cedcaa9a62c6e39 = context;
		xd0c7939d904920d7 = new Run(context.x2c8c6741422a1298);
		xffdeeab52bfac6bd(x2c8c6741422a1298);
	}

	internal void xf3a409990d06c568()
	{
	}

	internal void x3c06113138282067()
	{
		if (xffbea9fd9d484c1f == NodeType.Paragraph)
		{
			x2c8c6741422a1298.x6cb2cfca19c7adb6 = true;
		}
		xfdbe40d109da78d3(x43ca0f73fa00a937: true);
		x04562d8eb06323c7.x79f7fd8368ae8a71();
	}

	internal void xfdbe40d109da78d3(bool x43ca0f73fa00a937)
	{
		if (xffbea9fd9d484c1f == NodeType.HeaderFooter && !x43ca0f73fa00a937)
		{
			x93a8c149d218a60f(ControlChar.PageBreak);
			return;
		}
		x03725a0780edf469 = x43ca0f73fa00a937;
		xa5e2284bda2bc317();
		if (xffbea9fd9d484c1f == NodeType.Section)
		{
			Section section = (Section)xc255c495fd9232ca;
			section.xfc72d4c9b765cad7 = (xfc72d4c9b765cad7)xffb3238a8fd59aa7.xfc72d4c9b765cad7.x8b61531c8ea35b85();
			xf5b0b9b6ff7ac462();
		}
	}

	internal void xe7d4c5256fad03b7(HeaderFooterType xa685fef1a31f5d4d)
	{
		x03725a0780edf469 = false;
		if (xffbea9fd9d484c1f == NodeType.Document)
		{
			xe95664527db59e6e();
		}
		Section section = ((xffbea9fd9d484c1f == NodeType.Section) ? ((Section)xc255c495fd9232ca) : ((Section)xc255c495fd9232ca.GetAncestor(NodeType.Section)));
		HeaderFooter headerFooter = new HeaderFooter(x2c8c6741422a1298, xa685fef1a31f5d4d);
		xffdeeab52bfac6bd(headerFooter);
		xde27e91a248c4c90.xdcae50fcd3683487();
		Story story = section.xe5cdc2a3cec80364(xb7dbd7bb3ed97d5b.x3bcc8e857eb29ca0(xa685fef1a31f5d4d));
		if (story != null)
		{
			section.RemoveChild(story);
		}
		section.xdf7453d9fdf3f262(headerFooter);
	}

	internal void xac2ccec47108f993()
	{
		x03725a0780edf469 = true;
		if (xde27e91a248c4c90.x5b383c3eb24c7820)
		{
			xf18c706b6a050fda();
		}
		else
		{
			xa1237507e66611c4();
		}
		if (xffbea9fd9d484c1f == NodeType.HeaderFooter)
		{
			xde27e91a248c4c90.x92117b1aa2e0c555();
			xf5b0b9b6ff7ac462();
		}
		x03725a0780edf469 = false;
	}

	internal void x18f818c15e0066f1(x101cddc73c4f8cc2 x781135a02d5b7a22)
	{
		xffdeeab52bfac6bd(x2c8c6741422a1298);
		xa1e2a8ed32a026dd xa1e2a8ed32a026dd = new xa1e2a8ed32a026dd(x2c8c6741422a1298, x781135a02d5b7a22);
		x2c8c6741422a1298.x245aa7750b4a8072.set_xe6d4b1b411ed94b5(x781135a02d5b7a22, xa1e2a8ed32a026dd);
		xffdeeab52bfac6bd(xa1e2a8ed32a026dd);
	}

	internal void x4365e55d32fd2636()
	{
		if (xffbea9fd9d484c1f == NodeType.Paragraph)
		{
			xa1237507e66611c4();
		}
		xf5b0b9b6ff7ac462();
		xf5b0b9b6ff7ac462();
	}

	internal void xa1237507e66611c4()
	{
		if (xffbea9fd9d484c1f == NodeType.SmartTag)
		{
			xee59bcd855a217ab();
		}
		if (xffbea9fd9d484c1f != NodeType.Paragraph && !x03725a0780edf469)
		{
			xf17211360d71e9b8(null);
		}
		if (xffbea9fd9d484c1f == NodeType.Paragraph)
		{
			Paragraph paragraph = (Paragraph)xc255c495fd9232ca;
			Row row = paragraph.GetAncestor(NodeType.Row) as Row;
			paragraph.x1a78664fa10a3755 = xffb3238a8fd59aa7.x365c2d2e4d9ee5fe(row != null);
			paragraph.x344511c4e4ce09da = xffb3238a8fd59aa7.x08c0c7cb41c44cfd();
			xf5b0b9b6ff7ac462();
		}
	}

	internal void x93a8c149d218a60f(string xb41faee6912a2313)
	{
		xeedad81aaed42a76 xeedad81aaed42a = xffb3238a8fd59aa7.x5f35c5e3977af81d();
		if (!x86a90bf7f7d18ac7())
		{
			x03725a0780edf469 = false;
			if (x52657a442312b2e7(xb41faee6912a2313))
			{
				xc702936048918516(xb41faee6912a2313, xeedad81aaed42a);
			}
			else
			{
				x2037c969f8f81f97(xb41faee6912a2313, xeedad81aaed42a);
			}
		}
		else
		{
			x9a5166a3417038a1.Add(new Run(x2c8c6741422a1298, xb41faee6912a2313, xeedad81aaed42a));
		}
	}

	internal void xb5d34e6ee4c0fad1(SubDocument x099a571ab336faf8)
	{
		xfc1c33c63bf625fc(x099a571ab336faf8);
	}

	private void x2037c969f8f81f97(string xb41faee6912a2313, xeedad81aaed42a76 x789564759d365819)
	{
		if (xb41faee6912a2313 != " " || x96c280a5c67d7df3)
		{
			xfc1c33c63bf625fc(new Run(x2c8c6741422a1298, xb41faee6912a2313, x789564759d365819));
		}
		else
		{
			x9a5166a3417038a1.Add(new Run(x2c8c6741422a1298, xb41faee6912a2313, x789564759d365819));
		}
	}

	private static bool x52657a442312b2e7(string xb41faee6912a2313)
	{
		return xb41faee6912a2313.IndexOfAny(xdeadbda6c88fe8dc) >= 0;
	}

	private void xc702936048918516(string xb41faee6912a2313, xeedad81aaed42a76 x789564759d365819)
	{
		string[] array = xb41faee6912a2313.Split(xdeadbda6c88fe8dc);
		for (int i = 0; i < array.Length; i++)
		{
			xfc1c33c63bf625fc(new Run(x2c8c6741422a1298, array[i], x789564759d365819));
			if (i < array.Length - 1)
			{
				xa1237507e66611c4();
			}
		}
	}

	internal void x27442410230d2b1f(char x12f11d52c2c4d003)
	{
		xfc1c33c63bf625fc(new SpecialChar(x2c8c6741422a1298, x12f11d52c2c4d003, xffb3238a8fd59aa7.x5f35c5e3977af81d()));
	}

	internal void xd438a3a8968e57e1(x58bf2a36f9adf9a9 x3db8cf25c83af70b)
	{
		xfc1c33c63bf625fc(new FormField(x2c8c6741422a1298, x3db8cf25c83af70b, xffb3238a8fd59aa7.x5f35c5e3977af81d()));
	}

	internal FieldStart xcf72734b7092bebe()
	{
		FieldStart fieldStart = new FieldStart(x2c8c6741422a1298, x3a73dee84e0a9c16, FieldType.FieldNone);
		xfc1c33c63bf625fc(fieldStart);
		xd48deb218af504df.Push(fieldStart);
		return fieldStart;
	}

	internal void x094e1db5f87bb62b(x71d39fdf56861cca xb7b1409b12ce2ee3)
	{
		FieldSeparator fieldSeparator = new FieldSeparator(x2c8c6741422a1298, x3a73dee84e0a9c16, FieldType.FieldNone, xb7b1409b12ce2ee3);
		xfc1c33c63bf625fc(fieldSeparator);
		xd48deb218af504df.Push(fieldSeparator);
	}

	internal FieldEnd x3bb349c77392b35c()
	{
		FieldEnd fieldEnd = new FieldEnd(x2c8c6741422a1298, x3a73dee84e0a9c16, FieldType.FieldNone, hasSeparator: false);
		xfc1c33c63bf625fc(fieldEnd);
		x928b31adb20d5cc6 xe01ae93d9fe5a = xa52828dc23fddd4d(fieldEnd);
		xe01ae93d9fe5a.x8fdbe5468986594f(x5c29822913be33c1.x338a5159d9aa7162(xe01ae93d9fe5a.x29815ca66d57cfae()));
		bool flag = x5c29822913be33c1.xd668adf9377c05ee(xe01ae93d9fe5a.xc96d173d58dd8a20) != x5576a2206c3fc746.xf99e3386924fbeb6;
		if (flag && xe01ae93d9fe5a.x43604484a3deae4f == null)
		{
			xe01ae93d9fe5a.x43604484a3deae4f = new FieldSeparator(x2c8c6741422a1298, x3a73dee84e0a9c16, xe01ae93d9fe5a.xc96d173d58dd8a20);
			xc255c495fd9232ca.InsertBefore(xe01ae93d9fe5a.x43604484a3deae4f, xe01ae93d9fe5a.x9fd888e65466818c);
		}
		else if (!flag && xe01ae93d9fe5a.x43604484a3deae4f != null)
		{
			x5699f8523a546a42.x7088fd15062d931f(xe01ae93d9fe5a.x43604484a3deae4f, xe01ae93d9fe5a.x9fd888e65466818c);
			xe01ae93d9fe5a.x43604484a3deae4f = null;
		}
		xe01ae93d9fe5a.x9fd888e65466818c.x254cab982e9946b2(xe01ae93d9fe5a.x43604484a3deae4f != null);
		if (xe01ae93d9fe5a.x12cb12b5d2cad53d.x03a9a1b8afdf52f9(NodeType.Run) is Run run)
		{
			xe01ae93d9fe5a.x12cb12b5d2cad53d.xeedad81aaed42a76 = (xeedad81aaed42a76)run.xeedad81aaed42a76.x8b61531c8ea35b85();
			xe01ae93d9fe5a.x9fd888e65466818c.xeedad81aaed42a76 = (xeedad81aaed42a76)run.xeedad81aaed42a76.x8b61531c8ea35b85();
			if (xe01ae93d9fe5a.x43604484a3deae4f != null)
			{
				xe01ae93d9fe5a.x43604484a3deae4f.xeedad81aaed42a76 = (xeedad81aaed42a76)run.xeedad81aaed42a76.x8b61531c8ea35b85();
			}
		}
		xe01ae93d9fe5a.x6e0f5b69ee5c3db9();
		x3f78a18d30ea7a7f.x55c809ab6c9605c7(xe01ae93d9fe5a, xa8c3566f95fa8995(xe01ae93d9fe5a.x43604484a3deae4f), x8cedcaa9a62c6e39.x1e4394fcb6d34948);
		return fieldEnd;
	}

	internal void xa00b7e8964d655b2(ShapeBase x5770cdefd8931aa9)
	{
		if (xffbea9fd9d484c1f != NodeType.GroupShape)
		{
			xfc1c33c63bf625fc(x5770cdefd8931aa9);
		}
		else
		{
			x490834a62c46f14d(x5770cdefd8931aa9);
		}
		x5770cdefd8931aa9.xeedad81aaed42a76 = xffb3238a8fd59aa7.x5f35c5e3977af81d();
		x5770cdefd8931aa9.x87119342b85a2a43 = false;
	}

	internal void x63fb29d61f50770e(ShapeBase x5770cdefd8931aa9)
	{
		xf5b0b9b6ff7ac462();
		if (x5770cdefd8931aa9.x8934557a18f73b70)
		{
			x5770cdefd8931aa9.Remove();
		}
	}

	internal void xb2930715346a6867()
	{
		xde27e91a248c4c90.xdcae50fcd3683487();
	}

	internal void x6c71b8bd0c5c4b9a()
	{
		x03725a0780edf469 = true;
		if (xde27e91a248c4c90.xc5da8300b6251a76 || xffbea9fd9d484c1f == NodeType.Table)
		{
			x53b4f2fd609bbe9b();
		}
		else
		{
			xa1237507e66611c4();
		}
		xde27e91a248c4c90.x92117b1aa2e0c555();
		x03725a0780edf469 = false;
	}

	internal void x1f4dededb9314c98(Footnote x897ec71a9f9588a0)
	{
		xde27e91a248c4c90.xdcae50fcd3683487();
		xfc1c33c63bf625fc(x897ec71a9f9588a0);
	}

	internal void x08d6c67017518c71()
	{
		xa1237507e66611c4();
		xf5b0b9b6ff7ac462();
		xde27e91a248c4c90.x92117b1aa2e0c555();
	}

	internal void x508bedf5d0984ae8(Comment x77c5a31ec0891f38)
	{
		xde27e91a248c4c90.xdcae50fcd3683487();
		if (xffbea9fd9d484c1f != NodeType.Table)
		{
			xf17211360d71e9b8(x77c5a31ec0891f38);
			x490834a62c46f14d(x77c5a31ec0891f38);
		}
		else
		{
			Table table = (Table)xc255c495fd9232ca;
			table.LastRow.LastCell.xdf7453d9fdf3f262(x77c5a31ec0891f38);
			xffdeeab52bfac6bd(x77c5a31ec0891f38);
		}
	}

	internal void x0d5864f2522edf7f()
	{
		xa1237507e66611c4();
		xf5b0b9b6ff7ac462();
		xde27e91a248c4c90.x92117b1aa2e0c555();
	}

	internal void xdd60a22c09048adc(Node x10aaa7cdfa38f254)
	{
		xfc1c33c63bf625fc(x10aaa7cdfa38f254);
	}

	internal void x2bb903ec31d0096a(Node xca09b6c2b5b18485)
	{
		if (x86a90bf7f7d18ac7())
		{
			Row row = (Row)xc255c495fd9232ca;
			Cell lastCell = row.LastCell;
			Paragraph paragraph = (Paragraph)lastCell.xc0f45b01af564b77;
			paragraph.xdf7453d9fdf3f262(xca09b6c2b5b18485);
		}
		else
		{
			xfc1c33c63bf625fc(xca09b6c2b5b18485);
		}
	}

	internal void xa5c8bd4eb8264c5b(BookmarkStart x10aaa7cdfa38f254)
	{
		x3ad9c75be343492b(x10aaa7cdfa38f254);
	}

	internal void x6d5145c03507a8ad(BookmarkEnd xca09b6c2b5b18485)
	{
		x3ad9c75be343492b(xca09b6c2b5b18485);
	}

	internal void xf18c706b6a050fda()
	{
		while (xde27e91a248c4c90.x5b383c3eb24c7820)
		{
			x48bcfa796334770b();
		}
	}

	internal void x48bcfa796334770b()
	{
		if (xffbea9fd9d484c1f == NodeType.Cell)
		{
			xf5b0b9b6ff7ac462();
		}
		xd53d2436fa960ff6();
		if (xffbea9fd9d484c1f == NodeType.Table)
		{
			xf5b0b9b6ff7ac462();
			xde27e91a248c4c90.x92117b1aa2e0c555();
		}
	}

	internal void xd53d2436fa960ff6()
	{
		x1785831ddfa89322();
		if (xffbea9fd9d484c1f == NodeType.Row)
		{
			Row row = (Row)xc255c495fd9232ca;
			x04fb6e3d2f4c6680(row);
			xde27e91a248c4c90.xc7ae5256463a3132();
			row.x47ab0b351d6caf1e();
			xf5b0b9b6ff7ac462();
		}
	}

	internal void x2f8ca1d7ce36e5c9()
	{
		if (xffbea9fd9d484c1f == NodeType.Table)
		{
			xf18c706b6a050fda();
		}
		xa1237507e66611c4();
		if (xffbea9fd9d484c1f == NodeType.Cell)
		{
			xf5b0b9b6ff7ac462();
			if (xffbea9fd9d484c1f == NodeType.Row)
			{
				xadc00c9014e71478((Row)xc255c495fd9232ca);
			}
		}
	}

	internal void xdd43764a658cd8b8(SmartTag xdc6161a296532e34)
	{
		xfc1c33c63bf625fc(xdc6161a296532e34);
	}

	internal void x7006763b9e6195b1(CustomXmlMarkup x2f992229ae4fc9a1)
	{
		NodeType nodeType = xffbea9fd9d484c1f;
		if (nodeType == NodeType.Document)
		{
			xbaeac8c4c56306fe();
		}
		xf17211360d71e9b8(xd0c7939d904920d7);
		if (!x04562d8eb06323c7.xa5f46b37320268ac(x2f992229ae4fc9a1, xc255c495fd9232ca))
		{
			xfc1c33c63bf625fc(x2f992229ae4fc9a1);
		}
	}

	internal void xee59bcd855a217ab()
	{
		if (xffbea9fd9d484c1f != NodeType.SmartTag && x04562d8eb06323c7.x37e7de9a80315177)
		{
			xf17211360d71e9b8(xd0c7939d904920d7);
			if (!x04562d8eb06323c7.x8d4abec08bebbd61(xc255c495fd9232ca))
			{
				xf5b0b9b6ff7ac462();
			}
		}
		else if (x2b1ee3a87b36a988.x0302c7317ec57e52(xc255c495fd9232ca))
		{
			xf5b0b9b6ff7ac462();
		}
	}

	internal void xfc1c33c63bf625fc(Node x2e1df3070e13eca2)
	{
		xf17211360d71e9b8(x2e1df3070e13eca2);
		if (x2e1df3070e13eca2.IsComposite)
		{
			x490834a62c46f14d((CompositeNode)x2e1df3070e13eca2);
		}
		else
		{
			xc255c495fd9232ca.xdf7453d9fdf3f262(x2e1df3070e13eca2);
		}
	}

	internal void xb584ac72599993b7(OfficeMath x203bd7b4a3be8d02)
	{
		xfc1c33c63bf625fc(x203bd7b4a3be8d02);
	}

	internal void xa45ce0f4d762eaba()
	{
		xf5b0b9b6ff7ac462();
	}

	private xedb0eb766e25e0c9 xadc00c9014e71478(Row xa806b754814b9ae0)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = xde27e91a248c4c90.x3fd9d01b90f5c1ac;
		if (xedb0eb766e25e0c.xd44988f225497f3a == 0 && x65a7d6b2d7d591ac != null)
		{
			xedb0eb766e25e0c = (xedb0eb766e25e0c9)x65a7d6b2d7d591ac.x8b61531c8ea35b85();
		}
		x20eec3666a2dc8d0.x945c00cb2f79f4ea(xedb0eb766e25e0c);
		xa806b754814b9ae0.xedb0eb766e25e0c9 = xedb0eb766e25e0c;
		return xedb0eb766e25e0c;
	}

	private void xe95664527db59e6e()
	{
		if (xffbea9fd9d484c1f == NodeType.Document)
		{
			x490834a62c46f14d(new Section(x2c8c6741422a1298, (xfc72d4c9b765cad7)xffb3238a8fd59aa7.xfc72d4c9b765cad7.x8b61531c8ea35b85()));
		}
	}

	private void xbaeac8c4c56306fe()
	{
		x03725a0780edf469 = false;
		xe95664527db59e6e();
		if (xffbea9fd9d484c1f == NodeType.Section)
		{
			x490834a62c46f14d(new Body(x2c8c6741422a1298));
		}
	}

	private void xa5e2284bda2bc317()
	{
		if (xde27e91a248c4c90.xc5da8300b6251a76 || xffbea9fd9d484c1f == NodeType.Table)
		{
			x53b4f2fd609bbe9b();
		}
		else
		{
			xa1237507e66611c4();
		}
		if (xffbea9fd9d484c1f == NodeType.Body)
		{
			xf5b0b9b6ff7ac462();
		}
	}

	private void xf17211360d71e9b8(Node x2e1df3070e13eca2)
	{
		if (xde27e91a248c4c90.xc5da8300b6251a76 && xde27e91a248c4c90.x5b383c3eb24c7820)
		{
			xf18c706b6a050fda();
		}
		if (x15562db24e83e4a0(x2e1df3070e13eca2))
		{
			if (xde27e91a248c4c90.xa1dfad6564b5e2e7)
			{
				xa1237507e66611c4();
				x5ba6236f33f12f0c();
				x589e3ca1328e77a9();
				x490834a62c46f14d(new Paragraph(x2c8c6741422a1298));
			}
			return;
		}
		if (!xde27e91a248c4c90.xc5da8300b6251a76)
		{
			if (xffbea9fd9d484c1f == NodeType.Row)
			{
				x589e3ca1328e77a9();
			}
			else if (xffbea9fd9d484c1f == NodeType.Table)
			{
				x53b4f2fd609bbe9b();
			}
		}
		if (xde27e91a248c4c90.xc5da8300b6251a76)
		{
			x5ba6236f33f12f0c();
			x589e3ca1328e77a9();
		}
		else
		{
			xbaeac8c4c56306fe();
		}
		x490834a62c46f14d(new Paragraph(x2c8c6741422a1298));
	}

	private bool x15562db24e83e4a0(Node x2e1df3070e13eca2)
	{
		if (x2e1df3070e13eca2 != null && xc255c495fd9232ca.x8a4414b7d9d4073f(x2e1df3070e13eca2))
		{
			return !(xc255c495fd9232ca is xa1e2a8ed32a026dd);
		}
		return false;
	}

	private bool x86a90bf7f7d18ac7()
	{
		if (xffbea9fd9d484c1f != NodeType.Row)
		{
			return false;
		}
		if (xde27e91a248c4c90.xe388359ed363cdcf)
		{
			return false;
		}
		Row row = (Row)xc255c495fd9232ca;
		if (xde27e91a248c4c90.xedb0eb766e25e0c9.xeeac8c23df57dd1d != null)
		{
			return row.ChildNodes.Count == xde27e91a248c4c90.xedb0eb766e25e0c9.xeeac8c23df57dd1d.Count;
		}
		return false;
	}

	internal void xc35ba23c63a33fd3(FieldType x77ce91e5324df734, string x4a3f0a05c02f235f)
	{
		xeedad81aaed42a76 xeedad81aaed42a = xffb3238a8fd59aa7.x5f35c5e3977af81d();
		Node[] array = x558767d34a146386.x2c880a43e59505de(x2c8c6741422a1298, (xeedad81aaed42a76)xeedad81aaed42a.x8b61531c8ea35b85(), x77ce91e5324df734, x4a3f0a05c02f235f);
		xf17211360d71e9b8(array[0]);
		Node[] array2 = array;
		foreach (Node x40e458b3a58f in array2)
		{
			xc255c495fd9232ca.xdf7453d9fdf3f262(x40e458b3a58f);
		}
	}

	private x928b31adb20d5cc6 xa52828dc23fddd4d(FieldEnd xc87e4e475724f9c3)
	{
		x928b31adb20d5cc6 result = default(x928b31adb20d5cc6);
		result.x9fd888e65466818c = xc87e4e475724f9c3;
		if (xfd11b32344386bfa(NodeType.FieldSeparator))
		{
			result.x43604484a3deae4f = (FieldSeparator)xd48deb218af504df.Pop();
		}
		if (xfd11b32344386bfa(NodeType.FieldStart))
		{
			result.x12cb12b5d2cad53d = (FieldStart)xd48deb218af504df.Pop();
		}
		return result;
	}

	private bool xfd11b32344386bfa(NodeType x1a523190ff9254e6)
	{
		if (xd48deb218af504df.Count == 0)
		{
			return false;
		}
		Node node = (Node)xd48deb218af504df.Peek();
		return node.NodeType == x1a523190ff9254e6;
	}

	private static Shape xa8c3566f95fa8995(FieldSeparator xed9a565596a6ae3f)
	{
		if (xed9a565596a6ae3f != null)
		{
			return xed9a565596a6ae3f.NextSibling as Shape;
		}
		return null;
	}

	private void x5ba6236f33f12f0c()
	{
		while (xde27e91a248c4c90.xa1dfad6564b5e2e7)
		{
			x751f41e8113776ff();
		}
	}

	private void x53b4f2fd609bbe9b()
	{
		while (xffbea9fd9d484c1f == NodeType.Table)
		{
			x48bcfa796334770b();
		}
	}

	private void x751f41e8113776ff()
	{
		if (xffbea9fd9d484c1f == NodeType.Row || xffbea9fd9d484c1f == NodeType.Table)
		{
			x589e3ca1328e77a9();
		}
		else
		{
			xbaeac8c4c56306fe();
		}
		x490834a62c46f14d(new Table(x2c8c6741422a1298));
		if (xde27e91a248c4c90.xedb0eb766e25e0c9.xd44988f225497f3a > 0)
		{
			x65a7d6b2d7d591ac = xde27e91a248c4c90.xedb0eb766e25e0c9;
		}
		xde27e91a248c4c90.xc842919e05bdedb6();
	}

	private void xf3361c3f6ab6e2ba()
	{
		if (xffbea9fd9d484c1f != NodeType.Row)
		{
			if (xffbea9fd9d484c1f != NodeType.Table)
			{
				x5ba6236f33f12f0c();
			}
			x490834a62c46f14d(new Row(x2c8c6741422a1298, null));
		}
	}

	private void x04fb6e3d2f4c6680(Row xa806b754814b9ae0)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = xadc00c9014e71478(xa806b754814b9ae0);
		if (xedb0eb766e25e0c.xeeac8c23df57dd1d != null)
		{
			x079628a2d66cebda(xa806b754814b9ae0);
		}
		else
		{
			x2d6a5f9e809452f6(xa806b754814b9ae0);
		}
		x3bd914c1d934af81(xa806b754814b9ae0);
		xa806b754814b9ae0.xedb0eb766e25e0c9.xd835e6f8c37a91bb();
	}

	private void x1785831ddfa89322()
	{
		if (xffbea9fd9d484c1f != NodeType.Table && xde27e91a248c4c90.xedb0eb766e25e0c9.xeeac8c23df57dd1d != null && xc255c495fd9232ca is Cell cell)
		{
			x610a32c50804c2de(cell.ParentRow);
			while (xffbea9fd9d484c1f != NodeType.Row)
			{
				xf5b0b9b6ff7ac462();
			}
		}
	}

	private void x610a32c50804c2de(Row xa806b754814b9ae0)
	{
		if (xa806b754814b9ae0.Cells.Count > xde27e91a248c4c90.xedb0eb766e25e0c9.xeeac8c23df57dd1d.Count)
		{
			int num = xde27e91a248c4c90.xedb0eb766e25e0c9.xeeac8c23df57dd1d.Count - 1;
			for (int num2 = xa806b754814b9ae0.Cells.Count - 1; num2 > num; num2--)
			{
				CompositeNode compositeNode = xa806b754814b9ae0.Cells[num2];
				compositeNode.RemoveAllChildren();
				compositeNode.Remove();
			}
		}
	}

	private static void x2d6a5f9e809452f6(Row xa806b754814b9ae0)
	{
		CellCollection cells = xa806b754814b9ae0.Cells;
		Row row = (Row)xa806b754814b9ae0.x90463af0c741fac1;
		if (row != null && row.Cells.Count == cells.Count)
		{
			row.x7fd07ffddcb70376(cells);
			return;
		}
		foreach (Cell item in xa806b754814b9ae0)
		{
			item.xf8cef531dae89ea3 = new xf8cef531dae89ea3();
		}
	}

	private static void x079628a2d66cebda(Row xa806b754814b9ae0)
	{
		xdb4d596cc6b8659f xeeac8c23df57dd1d = xa806b754814b9ae0.xedb0eb766e25e0c9.xeeac8c23df57dd1d;
		Cell cell = xa806b754814b9ae0.FirstCell;
		int num = 0;
		while (cell != null && num < xeeac8c23df57dd1d.Count)
		{
			cell.xf8cef531dae89ea3 = xeeac8c23df57dd1d.get_xe6d4b1b411ed94b5(num);
			cell = cell.xb2e852052ab1c1be;
			num++;
		}
		if (cell != null)
		{
			x5699f8523a546a42.x7088fd15062d931f(cell, null);
		}
	}

	private static void x3bd914c1d934af81(Row xa806b754814b9ae0)
	{
		if (!xa806b754814b9ae0.xedb0eb766e25e0c9.x0f53f53f15b61ef5)
		{
			return;
		}
		x5fb16e270c21db2e x5fb16e270c21db2e = xa806b754814b9ae0.xedb0eb766e25e0c9.x5fb16e270c21db2e;
		xedb0eb766e25e0c9 xedb0eb766e25e0c = (xedb0eb766e25e0c9)x5fb16e270c21db2e.xdf4bcc85da8f85b2;
		xdb4d596cc6b8659f xeeac8c23df57dd1d = xedb0eb766e25e0c.xeeac8c23df57dd1d;
		if (xeeac8c23df57dd1d == null)
		{
			xa806b754814b9ae0.xedb0eb766e25e0c9.x097e4f3c708bd29c();
			return;
		}
		int num = 0;
		for (Cell cell = xa806b754814b9ae0.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
		{
			xf8cef531dae89ea3 revPr = xeeac8c23df57dd1d.get_xe6d4b1b411ed94b5(num);
			x5fb16e270c21db2e x5fb16e270c21db2e2 = new x5fb16e270c21db2e(revPr, x5fb16e270c21db2e.xb063bbfcfeade526, x5fb16e270c21db2e.x242851e6278ed355);
			cell.xf8cef531dae89ea3.x5fb16e270c21db2e = x5fb16e270c21db2e2;
			num++;
		}
		if (num == xeeac8c23df57dd1d.Count)
		{
			return;
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bhjkfjalkihlmholmhfmgimmbddnnhknbhboicioigpohggplgnpigeamglagbcbhfjbpfaccfhcnfochafdcfmdafdecfkelpaffeifgdpfgeggcdngedehjokhkdcilcjifcajnngjicojmcfkbcmkdbdldbklnbbmimhmebpmiagnplmnppdoopkocacpppipdaaankgakpnajpebdplbbpccdojcnoadmohdonodhnfecomekjdf", 1358997795)));
	}

	private void x589e3ca1328e77a9()
	{
		if (xffbea9fd9d484c1f != NodeType.Cell)
		{
			xf3361c3f6ab6e2ba();
			x490834a62c46f14d(new Cell(x2c8c6741422a1298, null));
		}
	}

	private void x3ad9c75be343492b(Node xda5bf54deb817e37)
	{
		if (xc255c495fd9232ca.x8a4414b7d9d4073f(xda5bf54deb817e37))
		{
			xc255c495fd9232ca.xdf7453d9fdf3f262(xda5bf54deb817e37);
		}
		else
		{
			x8c14637c2f2070c2.Add(xda5bf54deb817e37);
		}
	}

	private void x09336fb36ad0e376()
	{
		if (x8c14637c2f2070c2.Count == 0)
		{
			return;
		}
		Paragraph paragraph = ((xffbea9fd9d484c1f == NodeType.Paragraph) ? ((Paragraph)xc255c495fd9232ca) : (xc255c495fd9232ca.LastChild as Paragraph));
		if (paragraph == null)
		{
			return;
		}
		foreach (Node item in x8c14637c2f2070c2)
		{
			paragraph.xdf7453d9fdf3f262(item);
		}
		x8c14637c2f2070c2.Clear();
	}

	private void xfdf85521513b31c7()
	{
		if (x9a5166a3417038a1.Count == 0 || !x96c280a5c67d7df3)
		{
			return;
		}
		foreach (Node item in x9a5166a3417038a1)
		{
			xc255c495fd9232ca.xdf7453d9fdf3f262(item);
		}
		x9a5166a3417038a1.Clear();
	}

	private void x490834a62c46f14d(CompositeNode x1abafc112c220cac)
	{
		xc255c495fd9232ca.xdf7453d9fdf3f262(x1abafc112c220cac);
		xffdeeab52bfac6bd(x1abafc112c220cac);
	}

	private void xffdeeab52bfac6bd(CompositeNode x1abafc112c220cac)
	{
		xf8f23af472995af8.Push(x1abafc112c220cac);
		x09336fb36ad0e376();
		xfdf85521513b31c7();
	}

	private void xf5b0b9b6ff7ac462()
	{
		x09336fb36ad0e376();
		xf8f23af472995af8.Pop();
	}
}
