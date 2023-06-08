using System;
using System.Collections;
using Aspose.Words;
using x13f1efc79617a47b;

namespace x28925c9b27b37a46;

internal class x5699f8523a546a42 : xce798d32ec270dda
{
	private readonly xe1bd913bc72a8d58 x28bd93c698e27624;

	private readonly ArrayList xf2635541db3fa704 = new ArrayList();

	private readonly ArrayList x3aee31323e046826 = new ArrayList();

	protected ArrayList xf0f16f09de99b462 => xf2635541db3fa704;

	internal x5699f8523a546a42(x7e263f21a73a027a range, xe1bd913bc72a8d58 joinMode)
		: base(range)
	{
		x28bd93c698e27624 = joinMode;
	}

	internal static void x7088fd15062d931f(Node x10aaa7cdfa38f254, Node xca09b6c2b5b18485)
	{
		if (xca09b6c2b5b18485 != null && xca09b6c2b5b18485.ParentNode != x10aaa7cdfa38f254.ParentNode)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ecpfceggmcngkdehjdlhcobiacjikcajnbhjgnnjibfkobmkbbdlkmjlfbbmdbimfapmdagnoannildocalohacpcajpaaaajkgaoonaeoebgplbcocckjjcloadmnhdgnodoifeonmejmdfcnkfhmbgphigmmpgklghimnhileiollibmcjihjj", 298409681)));
		}
		Node node = x10aaa7cdfa38f254;
		while (node != xca09b6c2b5b18485)
		{
			Node nextSibling = node.NextSibling;
			node.Remove();
			node = nextSibling;
		}
	}

	internal static void x52b190e626f65140(Node x10aaa7cdfa38f254, Node xca09b6c2b5b18485)
	{
		x52b190e626f65140(x10aaa7cdfa38f254, x4ec19a117bbb0963: true, xca09b6c2b5b18485, xead571f03cb4ee1d: true);
	}

	internal static void x52b190e626f65140(Node x10aaa7cdfa38f254, bool x4ec19a117bbb0963, Node xca09b6c2b5b18485, bool xead571f03cb4ee1d)
	{
		x52b190e626f65140(x10aaa7cdfa38f254, x4ec19a117bbb0963, xca09b6c2b5b18485, xead571f03cb4ee1d, xe1bd913bc72a8d58.x15fc7f7f5bee2386);
	}

	internal static void x52b190e626f65140(Node x10aaa7cdfa38f254, bool x4ec19a117bbb0963, Node xca09b6c2b5b18485, bool xead571f03cb4ee1d, xe1bd913bc72a8d58 x54530ac2e150d822)
	{
		x52b190e626f65140(new x7e263f21a73a027a(x10aaa7cdfa38f254, x4ec19a117bbb0963, xca09b6c2b5b18485, xead571f03cb4ee1d), x54530ac2e150d822);
	}

	internal static void x52b190e626f65140(x7e263f21a73a027a x9b10ace6509508c0, xe1bd913bc72a8d58 x54530ac2e150d822)
	{
		x5699f8523a546a42 x5699f8523a546a43 = new x5699f8523a546a42(x9b10ace6509508c0, x54530ac2e150d822);
		x5699f8523a546a43.xd993fd34ab5f063d();
	}

	internal void xd993fd34ab5f063d()
	{
		x267efc5f6ada2866();
		xb68068f44b288183();
		xb4edb0bfdcecb3a5();
	}

	private void xb68068f44b288183()
	{
		foreach (Node item in xf2635541db3fa704)
		{
			item.Remove();
		}
	}

	private void xb4edb0bfdcecb3a5()
	{
		switch (x28bd93c698e27624)
		{
		case xe1bd913bc72a8d58.x15fc7f7f5bee2386:
			x15fc7f7f5bee2386();
			break;
		case xe1bd913bc72a8d58.xd777282ef2cf0d3d:
			xd777282ef2cf0d3d();
			break;
		default:
			throw new ArgumentOutOfRangeException();
		case xe1bd913bc72a8d58.x93e9ea6b6c905cc5:
			break;
		}
	}

	internal void x15fc7f7f5bee2386()
	{
		foreach (CompositeNode item in x3aee31323e046826)
		{
			CompositeNode compositeNode2;
			Node x22bff10c3dd1f70f;
			if (item.PreviousSibling.IsComposite)
			{
				compositeNode2 = (CompositeNode)item.PreviousSibling;
				x22bff10c3dd1f70f = compositeNode2.LastChild;
			}
			else
			{
				compositeNode2 = item.PreviousSibling.ParentNode;
				x22bff10c3dd1f70f = item.PreviousSibling;
			}
			if (item.NodeType == NodeType.Section)
			{
				Body body = ((Section)item).Body;
				Body body2 = ((Section)compositeNode2).Body;
				body2.x2729186e1a0b4aeb(body.FirstChild, null, body2.LastChild);
			}
			else
			{
				compositeNode2.x2729186e1a0b4aeb(item.FirstChild, null, x22bff10c3dd1f70f);
			}
			item.Remove();
		}
	}

	internal void xd777282ef2cf0d3d()
	{
		foreach (CompositeNode item in x3aee31323e046826)
		{
			CompositeNode compositeNode2 = (item.PreviousSibling.IsComposite ? ((CompositeNode)item.PreviousSibling) : item.PreviousSibling.ParentNode);
			if (item.NodeType == NodeType.Section)
			{
				Body body = ((Section)compositeNode2).Body;
				Body body2 = ((Section)item).Body;
				body2.xefe78abe23c23f7a(body.FirstChild, null, body2.FirstChild);
			}
			else
			{
				item.xefe78abe23c23f7a(compositeNode2.FirstChild, null, item.FirstChild);
			}
			compositeNode2.Remove();
		}
	}

	protected override void OnMiddleParentNode()
	{
		xf2635541db3fa704.Add(base.x3387295f12854dfd);
	}

	protected override void OnLastParentNode()
	{
		x3aee31323e046826.Add(base.x3387295f12854dfd);
	}

	protected override void OnChildNode()
	{
		xf2635541db3fa704.Add(base.x3387295f12854dfd);
	}
}
