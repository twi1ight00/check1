using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Markup;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x53eb9320ebbb8395;

namespace xf989f31a236ff98c;

internal class x12d551e21425ffee
{
	private readonly Stack xaa8a0f0b73b35b89 = new Stack();

	private readonly Stack x3dbad978f1ccc108 = new Stack();

	private readonly Hashtable x3cd05e136ecdd285 = new Hashtable();

	private readonly Hashtable x0b99910fbd6b363f = new Hashtable();

	private readonly ArrayList x9d10707fc39f2c94 = new ArrayList();

	private readonly IWarningCallback xa056586c1f99e199;

	private readonly WarningSource x006c2eca1459fa26;

	internal bool x37e7de9a80315177 => xaa8a0f0b73b35b89.Count > 0;

	internal x12d551e21425ffee(IWarningCallback warningCallback, WarningSource warningSource)
	{
		xa056586c1f99e199 = warningCallback;
		x006c2eca1459fa26 = warningSource;
	}

	internal bool xa5f46b37320268ac(x55997ac957018945 x04137a6fd0e2d03c, CompositeNode xd3311d815ca25f02)
	{
		xaa8a0f0b73b35b89.Push(x04137a6fd0e2d03c);
		if (x04137a6fd0e2d03c.x57b60ae60739c9b5 != MarkupLevel.Inline)
		{
			x3cd05e136ecdd285[x04137a6fd0e2d03c] = xd3311d815ca25f02;
		}
		return x04137a6fd0e2d03c.x57b60ae60739c9b5 != MarkupLevel.Inline;
	}

	internal void xc0c75e3447cb93ab(x55997ac957018945 x04137a6fd0e2d03c)
	{
		x9d10707fc39f2c94.Add(x04137a6fd0e2d03c);
	}

	internal void xbf41e930a525aba9(CompositeNode xda5bf54deb817e37)
	{
		foreach (x55997ac957018945 item in x9d10707fc39f2c94)
		{
			xa5f46b37320268ac(item, xda5bf54deb817e37);
		}
		x9d10707fc39f2c94.Clear();
	}

	internal bool x8d4abec08bebbd61(CompositeNode xd3311d815ca25f02)
	{
		if (xaa8a0f0b73b35b89.Count == 0)
		{
			xbf41e930a525aba9(xd3311d815ca25f02);
			return false;
		}
		x55997ac957018945 x55997ac = (x55997ac957018945)xaa8a0f0b73b35b89.Pop();
		if (x55997ac.x57b60ae60739c9b5 != MarkupLevel.Inline)
		{
			x3dbad978f1ccc108.Push(x55997ac);
			x0b99910fbd6b363f[x55997ac] = xd3311d815ca25f02;
		}
		return x55997ac.x57b60ae60739c9b5 != MarkupLevel.Inline;
	}

	internal void x79f7fd8368ae8a71()
	{
		while (x3dbad978f1ccc108.Count > 0)
		{
			x55997ac957018945 x55997ac = (x55997ac957018945)x3dbad978f1ccc108.Pop();
			ArrayList arrayList = x2ab59ee8000cdc76((Node)x3cd05e136ecdd285[x55997ac], (Node)x0b99910fbd6b363f[x55997ac]);
			if (arrayList != null)
			{
				CompositeNode compositeNode = ((Node)arrayList[0]).ParentNode;
				if ((compositeNode.NodeType == NodeType.Table && x55997ac.x57b60ae60739c9b5 == MarkupLevel.Block) || (compositeNode.NodeType == NodeType.Row && x55997ac.x57b60ae60739c9b5 == MarkupLevel.Row) || (compositeNode.NodeType == NodeType.Cell && x55997ac.x57b60ae60739c9b5 == MarkupLevel.Cell))
				{
					arrayList.Clear();
					arrayList.Add(compositeNode);
					compositeNode = compositeNode.ParentNode;
				}
				else if (compositeNode.NodeType == NodeType.Cell && x55997ac.x57b60ae60739c9b5 == MarkupLevel.Row)
				{
					arrayList.Clear();
					arrayList.Add(((Cell)compositeNode).ParentRow);
					compositeNode = ((Cell)compositeNode).x133f2db9e5b5690d;
				}
				if (compositeNode.x8a4414b7d9d4073f((Node)x55997ac))
				{
					x8eeaaee7cd34452f((CompositeNode)x55997ac, arrayList);
				}
				else
				{
					xbbf9a1ead81dd3a1("Node is unable to accept markup, markup ignored.");
				}
			}
			else
			{
				xbbf9a1ead81dd3a1("Unable to get common parent range, markup ignored.");
			}
		}
	}

	private static ArrayList x2ab59ee8000cdc76(Node x54357f622b23380b, Node x59951c70187d7fc5)
	{
		int num = x2b1ee3a87b36a988.x2af57cfa111d1019(x54357f622b23380b);
		int num2 = x2b1ee3a87b36a988.x2af57cfa111d1019(x59951c70187d7fc5);
		int num3 = Math.Min(num, num2);
		x54357f622b23380b = x2b1ee3a87b36a988.x9b358cd73ee85ee5(x54357f622b23380b, num - num3);
		x59951c70187d7fc5 = x2b1ee3a87b36a988.x9b358cd73ee85ee5(x59951c70187d7fc5, num2 - num3);
		while (x54357f622b23380b != null && x59951c70187d7fc5 != null && x54357f622b23380b.ParentNode != x59951c70187d7fc5.ParentNode)
		{
			x54357f622b23380b = x54357f622b23380b.ParentNode;
			x59951c70187d7fc5 = x59951c70187d7fc5.ParentNode;
		}
		if (x54357f622b23380b != null && x59951c70187d7fc5 != null)
		{
			ArrayList arrayList = new ArrayList();
			while (x54357f622b23380b != null && x54357f622b23380b != x59951c70187d7fc5)
			{
				arrayList.Add(x54357f622b23380b);
				x54357f622b23380b = x54357f622b23380b.NextSibling;
			}
			arrayList.Add(x59951c70187d7fc5);
			return arrayList;
		}
		return null;
	}

	private static void x8eeaaee7cd34452f(CompositeNode x04137a6fd0e2d03c, ArrayList x9b10ace6509508c0)
	{
		Node node = (Node)x9b10ace6509508c0[0];
		node.ParentNode.InsertBefore(x04137a6fd0e2d03c, node);
		foreach (Node item in x9b10ace6509508c0)
		{
			x04137a6fd0e2d03c.AppendChild(item);
		}
	}

	private void xbbf9a1ead81dd3a1(string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(WarningType.DataLoss, x006c2eca1459fa26, xc2358fbac7da3d45));
		}
	}
}
