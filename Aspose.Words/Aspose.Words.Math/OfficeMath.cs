using System;
using System.Text;
using x28925c9b27b37a46;
using xe5b37aee2c2a4d4e;

namespace Aspose.Words.Math;

public class OfficeMath : CompositeNode, xf5ecf429e74b1c04, xcf3b0f04424de818
{
	private x52642f91ccdeeb35 xf1472bed58d7ef10;

	private xeedad81aaed42a76 xd0c44e5ae0011daa;

	int xf5ecf429e74b1c04.x5b8c6010012a5955 => xd0c44e5ae0011daa.xd44988f225497f3a;

	public override NodeType NodeType => NodeType.OfficeMath;

	public Paragraph ParentParagraph => (Paragraph)GetAncestor(NodeType.Paragraph);

	internal x52642f91ccdeeb35 x52642f91ccdeeb35 => xf1472bed58d7ef10;

	internal xeedad81aaed42a76 xeedad81aaed42a76 => xd0c44e5ae0011daa;

	Paragraph xcf3b0f04424de818.x6b298f029e4a1f68 => ParentParagraph;

	DocumentBase xcf3b0f04424de818.x17d1cdafb1f5c088 => base.Document;

	xeedad81aaed42a76 xcf3b0f04424de818.x2f8bb6c2cbd66330
	{
		get
		{
			return xd0c44e5ae0011daa;
		}
		set
		{
			xd0c44e5ae0011daa = value;
		}
	}

	internal OfficeMath(DocumentBase doc, x52642f91ccdeeb35 mathObject, xeedad81aaed42a76 runPr)
		: base(doc)
	{
		xf1472bed58d7ef10 = mathObject;
		if (runPr == null)
		{
			throw new ArgumentNullException("runPr");
		}
		xd0c44e5ae0011daa = runPr;
	}

	internal OfficeMath(DocumentBase doc, x52642f91ccdeeb35 mathObject)
		: this(doc, mathObject, new xeedad81aaed42a76())
	{
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		OfficeMath officeMath = (OfficeMath)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		officeMath.xd0c44e5ae0011daa = (xeedad81aaed42a76)xd0c44e5ae0011daa.x8b61531c8ea35b85();
		officeMath.xf1472bed58d7ef10 = (x52642f91ccdeeb35)xf1472bed58d7ef10.x8b61531c8ea35b85();
		return officeMath;
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitOfficeMathStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitOfficeMathEnd(this);
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return xf1472bed58d7ef10.x8a4414b7d9d4073f(x40e458b3a58f5782);
	}

	private object x93e461c176ca1e50(int x6cc530a2cd983862)
	{
		return xd0c44e5ae0011daa.xf7866f89640a29a3(x6cc530a2cd983862);
	}

	object xf5ecf429e74b1c04.x9bd0b4c41657450b(int x6cc530a2cd983862)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x93e461c176ca1e50
		return this.x93e461c176ca1e50(x6cc530a2cd983862);
	}

	private void x9939815f86bdcfc3(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		xba08ce632055a1d9 = xd0c44e5ae0011daa.xf15263674eb297bb(xc0c4c459c6ccbd00);
		xbcea506a33cf9111 = xd0c44e5ae0011daa.x6d3720b962bd3112(xc0c4c459c6ccbd00);
	}

	void xf5ecf429e74b1c04.x16b3a875e7cc38ed(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9939815f86bdcfc3
		this.x9939815f86bdcfc3(xc0c4c459c6ccbd00, out xba08ce632055a1d9, out xbcea506a33cf9111);
	}

	private object xa49e661f5cc91e49(int x6cc530a2cd983862)
	{
		return x684b09378db148f4.xdafa1f94b023b665(this, x6cc530a2cd983862);
	}

	object xf5ecf429e74b1c04.x2685f947206319cf(int x6cc530a2cd983862)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa49e661f5cc91e49
		return this.xa49e661f5cc91e49(x6cc530a2cd983862);
	}

	private void x09376e92b9e1f394(int x6cc530a2cd983862, object xbcea506a33cf9111)
	{
		xd0c44e5ae0011daa.xae20093bed1e48a8(x6cc530a2cd983862, xbcea506a33cf9111);
	}

	void xf5ecf429e74b1c04.xd00aa8389522ce53(int x6cc530a2cd983862, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x09376e92b9e1f394
		this.x09376e92b9e1f394(x6cc530a2cd983862, xbcea506a33cf9111);
	}

	private void x69045f836de92891()
	{
		xd0c44e5ae0011daa.ClearAttrs();
	}

	void xf5ecf429e74b1c04.xe80983f2918b2568()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x69045f836de92891
		this.x69045f836de92891();
	}

	private xeedad81aaed42a76 x91e3a7c2f71688fa(xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		return x684b09378db148f4.x856218fd0771d379(this, xebf45bdcaa1fd1e1);
	}

	xeedad81aaed42a76 xcf3b0f04424de818.x75cbc81364d91526(xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x91e3a7c2f71688fa
		return this.x91e3a7c2f71688fa(xebf45bdcaa1fd1e1);
	}

	internal string x5881d3d5b8b306d3()
	{
		StringBuilder stringBuilder = new StringBuilder(Node.NodeTypeToString(NodeType));
		stringBuilder.Append(' ');
		Node node = this;
		while (node != null && node.ParentNode != null)
		{
			int num = 0;
			Node node2 = node.ParentNode.FirstChild;
			while (node2 != null && node2 != node)
			{
				num++;
				node2 = node2.NextSibling;
			}
			stringBuilder.AppendFormat("{0}{1}", (node == this) ? "" : ".", num);
			node = node.ParentNode;
		}
		return stringBuilder.ToString();
	}
}
