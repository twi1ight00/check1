using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x0a28863c804404d7 : xce798d32ec270dda
{
	private readonly Node xbd5b46a89d687e54;

	private readonly xe83a6b069ec8efc2 x8e1a7bd0ad3bbd55;

	private readonly DocumentBuilder x800085dd555f7711;

	private Node xebf7cc014960969e;

	private bool x27655c3a5dcf76d3;

	private bool xd4d77be587b3fcde;

	private x0a28863c804404d7(x7e263f21a73a027a sourceRange, Node referenceNode, xe83a6b069ec8efc2 modifier)
		: base(sourceRange)
	{
		xbd5b46a89d687e54 = referenceNode;
		x8e1a7bd0ad3bbd55 = modifier;
		xebf7cc014960969e = referenceNode.PreviousSibling;
		x800085dd555f7711 = new DocumentBuilder(referenceNode.x357c90b33d6bb8e6());
	}

	internal static void x775521112ede5e6f(x7e263f21a73a027a x5f36ad26e64b91c3, Node x98cacf1c34b53cca, xe83a6b069ec8efc2 xcbf24c118ac8aa0b)
	{
		x7e263f21a73a027a sourceRange = x5f36ad26e64b91c3;
		if (x5f36ad26e64b91c3.x9fd888e65466818c.x40212106aad8a8b0.IsComposite && x5f36ad26e64b91c3.x9fd888e65466818c.x375e8189a5358be0)
		{
			x98739d759efb5fe7 x98739d759efb5fe8 = x5f36ad26e64b91c3.x9fd888e65466818c.x8b61531c8ea35b85();
			x98739d759efb5fe8.x9e19f5bd0a6dd5b7(null, xa17853d20c8c42bd: true, x0d900d42b3598fde: false, x2709983bf2ac093e: false, xa5486b84e3604cca: false, xad9f70dbf5281236: false);
			sourceRange = new x7e263f21a73a027a(x5f36ad26e64b91c3.x12cb12b5d2cad53d, x98739d759efb5fe8);
		}
		x0a28863c804404d7 x0a28863c804404d8 = new x0a28863c804404d7(sourceRange, x98cacf1c34b53cca, xcbf24c118ac8aa0b);
		x0a28863c804404d8.x267efc5f6ada2866();
	}

	internal static void x5af2763689ebe731(x7e263f21a73a027a x5f36ad26e64b91c3, Node x98cacf1c34b53cca, xe83a6b069ec8efc2 xcbf24c118ac8aa0b, bool x29c774879be75f66)
	{
		x98739d759efb5fe7 x98739d759efb5fe8 = x98739d759efb5fe7.xf86191ae51e45118(x98cacf1c34b53cca);
		x98739d759efb5fe8.x9e19f5bd0a6dd5b7(null, xa17853d20c8c42bd: false, x0d900d42b3598fde: false, x2709983bf2ac093e: false, xa5486b84e3604cca: false, xad9f70dbf5281236: false);
		x775521112ede5e6f(x5f36ad26e64b91c3, x98cacf1c34b53cca, xcbf24c118ac8aa0b);
		x98739d759efb5fe7 end = x98739d759efb5fe7.xf86191ae51e45118(x98cacf1c34b53cca);
		x7e263f21a73a027a x9b10ace6509508c = new x7e263f21a73a027a(x98739d759efb5fe8, end);
		x5d2f40ff59e92969.x21fa987632cd6917(x9b10ace6509508c, x29c774879be75f66);
	}

	internal static void x5af2763689ebe731(x7e263f21a73a027a x5f36ad26e64b91c3, Node x98cacf1c34b53cca, xe83a6b069ec8efc2 xcbf24c118ac8aa0b)
	{
		x5af2763689ebe731(x5f36ad26e64b91c3, x98cacf1c34b53cca, xcbf24c118ac8aa0b, x29c774879be75f66: false);
	}

	protected override void OnMiddleParentNode()
	{
		switch (base.x3387295f12854dfd.NodeType)
		{
		case NodeType.Table:
		case NodeType.Paragraph:
			if (!base.x7d2e50686d249839.xae11a38e854312f4(NodeType.Section))
			{
				if (!base.x3387295f12854dfd.x16479f42fe4547f2 || !xbd5b46a89d687e54.IsComposite)
				{
					xc908785ba1810083();
				}
			}
			else
			{
				xa690e8b05769f902();
			}
			break;
		case NodeType.Section:
			xc908785ba1810083();
			break;
		}
		x452863527147987d();
	}

	protected override void OnLastParentNode()
	{
		switch (base.x3387295f12854dfd.NodeType)
		{
		case NodeType.Paragraph:
			xa690e8b05769f902();
			xebf7cc014960969e = xbd5b46a89d687e54;
			xebf7cc014960969e = x1828fa626e0b9c89();
			x27655c3a5dcf76d3 = true;
			break;
		case NodeType.Section:
			xc908785ba1810083();
			xebf7cc014960969e = xbd5b46a89d687e54;
			xebf7cc014960969e = x1828fa626e0b9c89();
			x27655c3a5dcf76d3 = true;
			break;
		}
	}

	protected override void OnChildNode()
	{
		if (!x2b1ee3a87b36a988.x0f86e763fa9a14ff(base.x3387295f12854dfd))
		{
			x452863527147987d();
		}
	}

	private void x452863527147987d()
	{
		if (xebf7cc014960969e == null || x27655c3a5dcf76d3)
		{
			xa8be3b23335b2c03();
		}
		else
		{
			xb3491b205d3b163a();
		}
	}

	protected override void OnMoved(x92efcb0dc4970661 movement)
	{
		switch (movement)
		{
		case x92efcb0dc4970661.x887a0c79ecbe5ee3:
		case x92efcb0dc4970661.x79a071bfba0c5e7d:
			xebf7cc014960969e = x1828fa626e0b9c89();
			break;
		}
	}

	private void xa690e8b05769f902()
	{
		if (!xd4d77be587b3fcde && xbd5b46a89d687e54.NodeType != base.x3387295f12854dfd.NodeType)
		{
			x800085dd555f7711.MoveTo(xbd5b46a89d687e54);
			x800085dd555f7711.InsertParagraph();
			xd4d77be587b3fcde = true;
		}
	}

	private void xc908785ba1810083()
	{
		if (xbd5b46a89d687e54.GetAncestor(NodeType.Body) != null && !xd4d77be587b3fcde)
		{
			x800085dd555f7711.MoveTo(xbd5b46a89d687e54);
			Section section = (Section)x2b1ee3a87b36a988.x6e7216533ee7db3e(base.x7d2e50686d249839.x9fd888e65466818c.x40212106aad8a8b0, NodeType.Section);
			SectionStart sectionStart = section.PageSetup.SectionStart;
			x800085dd555f7711.x421182dbe4852822(sectionStart);
			if (xbd5b46a89d687e54.NodeType == NodeType.Paragraph)
			{
				x800085dd555f7711.CurrentSection.Body.PrependChild(xbd5b46a89d687e54);
			}
			if (!x800085dd555f7711.CurrentParagraph.HasChildNodes)
			{
				x800085dd555f7711.CurrentParagraph.Remove();
			}
			xd4d77be587b3fcde = true;
		}
	}

	private void xb3491b205d3b163a()
	{
		Node node = x64ae56857b252b27(x8e1a7bd0ad3bbd55, x457efc87f780f707: true);
		if (node != null)
		{
			xebf7cc014960969e = x1828fa626e0b9c89();
			xebf7cc014960969e = xebf7cc014960969e.ParentNode.InsertAfter(node, xebf7cc014960969e);
		}
	}

	private void xa8be3b23335b2c03()
	{
		Node node = x64ae56857b252b27(x8e1a7bd0ad3bbd55, x457efc87f780f707: true);
		if (node != null)
		{
			bool flag = xebf7cc014960969e == null;
			xebf7cc014960969e = x1828fa626e0b9c89();
			xebf7cc014960969e.ParentNode.InsertBefore(node, xebf7cc014960969e);
			if (flag)
			{
				xebf7cc014960969e = node;
			}
		}
	}

	private Node x1828fa626e0b9c89()
	{
		Node node = ((base.x3387295f12854dfd != null) ? base.x3387295f12854dfd : base.x7d2e50686d249839.x12cb12b5d2cad53d.x40212106aad8a8b0);
		if (xebf7cc014960969e == null)
		{
			xebf7cc014960969e = xbd5b46a89d687e54;
		}
		if (node.x8e127cb7da826802 == xebf7cc014960969e.x8e127cb7da826802)
		{
			return xebf7cc014960969e;
		}
		if (!x27655c3a5dcf76d3)
		{
			Node node2 = x493cea49c46ed8b1(node, xebf7cc014960969e);
			if (node2 == null)
			{
				return x182f6f3424579667(node, xebf7cc014960969e);
			}
			return node2;
		}
		return x493cea49c46ed8b1(node, xbd5b46a89d687e54);
	}

	private static Node x493cea49c46ed8b1(Node x2e1df3070e13eca2, Node x98cacf1c34b53cca)
	{
		while (x98cacf1c34b53cca != null && x98cacf1c34b53cca.x8e127cb7da826802 != x2e1df3070e13eca2.x8e127cb7da826802)
		{
			x98cacf1c34b53cca = xb56968f92e308c8a.xa14d0084f5d1ce76(x98cacf1c34b53cca.ParentNode);
		}
		return x98cacf1c34b53cca;
	}

	private static Node x182f6f3424579667(Node x2e1df3070e13eca2, Node x98cacf1c34b53cca)
	{
		while (x98cacf1c34b53cca != null && x98cacf1c34b53cca.IsComposite && x98cacf1c34b53cca.x8e127cb7da826802 != x2e1df3070e13eca2.x8e127cb7da826802)
		{
			x98cacf1c34b53cca = xb56968f92e308c8a.x5de48b1c2cfe605c(((CompositeNode)x98cacf1c34b53cca).LastChild);
		}
		return x98cacf1c34b53cca;
	}
}
