using System;
using System.Collections;
using x13f1efc79617a47b;
using x28925c9b27b37a46;

namespace Aspose.Words;

[JavaGenericArguments("Iterable<T>")]
[JavaGenericParameter("T extends Node")]
public class NodeCollection : INodeCollection, IEnumerable
{
	private readonly CompositeNode x437fa02210b98bec;

	private readonly DocumentBase xd1424e1a0bb4a72b;

	private readonly bool x0d85ab5f75b9fc80;

	private int xa6fa8b02817e3274;

	private int x18eaa95f10f1d19d;

	private Node xd66b3bfe87086cc8;

	private int x35a5073ffeb125c5;

	private readonly xdbbc00f1636b87bc x1a99c91c759cec52;

	public Node this[int index]
	{
		get
		{
			x284efa4acfd1a1c7();
			if (index < 0)
			{
				index = Count + index;
				if (index < 0)
				{
					return null;
				}
			}
			if (x18eaa95f10f1d19d == index)
			{
				return xd66b3bfe87086cc8;
			}
			int x10f4d88af727adbc = index - x18eaa95f10f1d19d;
			Node node = xd1569fa9f13ca2c9(xd66b3bfe87086cc8, x10f4d88af727adbc);
			if (node != null)
			{
				x18eaa95f10f1d19d = index;
				xd66b3bfe87086cc8 = node;
			}
			return node;
		}
	}

	public int Count
	{
		get
		{
			x284efa4acfd1a1c7();
			if (x35a5073ffeb125c5 == -1)
			{
				x35a5073ffeb125c5 = 0;
				xa01ec4575907f3a5 xa01ec4575907f3a = new xa01ec4575907f3a5(this);
				while (xa01ec4575907f3a.MoveNext())
				{
					x35a5073ffeb125c5++;
				}
			}
			return x35a5073ffeb125c5;
		}
	}

	internal CompositeNode xc255c495fd9232ca => x437fa02210b98bec;

	internal NodeCollection(CompositeNode container, NodeType nodeType, bool isDeep)
		: this(container, new x8e28d0731c3bcab3(nodeType), isDeep)
	{
	}

	internal NodeCollection(CompositeNode container, xdbbc00f1636b87bc matcher, bool isDeep)
	{
		if (container == null)
		{
			throw new ArgumentNullException("container");
		}
		if (matcher == null)
		{
			throw new ArgumentNullException("matcher");
		}
		x437fa02210b98bec = container;
		xd1424e1a0bb4a72b = container.Document;
		x1a99c91c759cec52 = matcher;
		x0d85ab5f75b9fc80 = isDeep;
		xe88ab84767e8fb69();
	}

	public void Add(Node node)
	{
		if (x0d85ab5f75b9fc80)
		{
			throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("akdaamkanlbbplibbmpbhlgcngnciledglldikcegkjeblaflfhfbkofikfgcfmgnjdhljkhnjbigeiimjpifigjbjnjkdekkilkjiclbijlohamkhhmkhomjhfnhgmndgdombkopfbpfgipfgppabgabfnapeebmelbefccbajcmeadkehdmdodkdfecplecddfldkffdbgcdigicpgdcghbdnhdceigclicccjecjjmnpj", 1274676063)));
		}
		x437fa02210b98bec.AppendChild(node);
	}

	public void Insert(int index, Node node)
	{
		if (x0d85ab5f75b9fc80)
		{
			throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ljhfnlofplfgokmgildhhlkhjkbilkiibkpihfgjcknjakekcjlkajclljjlfeamlihmcjommdfnhimnfidohikoadbpgiippgpplhgaecnaehebdhlblgccigjcegadeghddgodbffenemegadfjekfpebgpeigkpogldghjdnhgdeiodlilobjgdjjedakgchkecokmnelmbmlfcdmpbkmmbbncbinnapnlbgonanoabepmalpoacagmia", 1169381202)));
		}
		x437fa02210b98bec.InsertBefore(node, this[index]);
	}

	public void Remove(Node node)
	{
		node.Remove();
	}

	public void RemoveAt(int index)
	{
		this[index].Remove();
	}

	public void Clear()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Node node = (Node)enumerator.Current;
				node.Remove();
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public bool Contains(Node node)
	{
		return IndexOf(node) != -1;
	}

	public int IndexOf(Node node)
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Node node2 = (Node)enumerator.Current;
				if (node == node2)
				{
					return num;
				}
				num++;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return -1;
	}

	public Node[] ToArray()
	{
		return (Node[])x8a2b4876a80a0afd().ToArray(typeof(Node));
	}

	[JavaGenericArguments("Iterator<T>", "NodeCollectionEnumerator<T>")]
	public IEnumerator GetEnumerator()
	{
		return new xa01ec4575907f3a5(this);
	}

	internal ArrayList x8a2b4876a80a0afd()
	{
		ArrayList arrayList = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Node value = (Node)enumerator.Current;
				arrayList.Add(value);
			}
			return arrayList;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal Node x546e10f8b0fe6693(ref Node xc140f46ca02b5256, bool xa17853d20c8c42bd)
	{
		Node result;
		do
		{
			result = xc140f46ca02b5256;
			xc140f46ca02b5256 = (x0d85ab5f75b9fc80 ? x66ea269553c47a5f(xa17853d20c8c42bd, xc140f46ca02b5256) : (x1a99c91c759cec52.xd8a4d30a54634d09 ? x2a6f77ea15a1c248(xa17853d20c8c42bd, xc140f46ca02b5256) : x2714bd4c1351b490(xa17853d20c8c42bd, xc140f46ca02b5256)));
		}
		while (xc140f46ca02b5256 != null && !x1a99c91c759cec52.xc313ef0c9ca8870d(xc140f46ca02b5256));
		return result;
	}

	private Node x66ea269553c47a5f(bool xa17853d20c8c42bd, Node xda5bf54deb817e37)
	{
		if (!xa17853d20c8c42bd)
		{
			return xda5bf54deb817e37.PreviousPreOrder(x437fa02210b98bec);
		}
		return xda5bf54deb817e37.NextPreOrder(x437fa02210b98bec);
	}

	private Node x2714bd4c1351b490(bool xa17853d20c8c42bd, Node xda5bf54deb817e37)
	{
		if (!xa17853d20c8c42bd)
		{
			return x71d22ac719af7426(xda5bf54deb817e37);
		}
		return x3a4698d92c947fff(xda5bf54deb817e37);
	}

	private Node x2a6f77ea15a1c248(bool xa17853d20c8c42bd, Node xda5bf54deb817e37)
	{
		Node node = null;
		if (x2b1ee3a87b36a988.x0302c7317ec57e52(xda5bf54deb817e37))
		{
			CompositeNode compositeNode = (CompositeNode)xda5bf54deb817e37;
			node = (xa17853d20c8c42bd ? compositeNode.xfe93db1ba6e25886 : compositeNode.xc0f45b01af564b77);
		}
		if (node == null)
		{
			node = (xa17853d20c8c42bd ? x3a4698d92c947fff(xda5bf54deb817e37) : x71d22ac719af7426(xda5bf54deb817e37));
			while (node == null && x2b1ee3a87b36a988.x0302c7317ec57e52(xda5bf54deb817e37.ParentNode) && xda5bf54deb817e37.ParentNode != x437fa02210b98bec)
			{
				xda5bf54deb817e37 = xda5bf54deb817e37.ParentNode;
				node = (xa17853d20c8c42bd ? x3a4698d92c947fff(xda5bf54deb817e37) : x71d22ac719af7426(xda5bf54deb817e37));
			}
		}
		return node;
	}

	private Node xd1569fa9f13ca2c9(Node x4606b15cf4290d0f, int x10f4d88af727adbc)
	{
		bool xa17853d20c8c42bd = x10f4d88af727adbc > 0;
		if (x10f4d88af727adbc < 0)
		{
			x10f4d88af727adbc = -x10f4d88af727adbc;
		}
		Node xc140f46ca02b = x4606b15cf4290d0f;
		for (int i = 0; i < x10f4d88af727adbc; i++)
		{
			x546e10f8b0fe6693(ref xc140f46ca02b, xa17853d20c8c42bd);
			if (xc140f46ca02b == null)
			{
				return null;
			}
		}
		return xc140f46ca02b;
	}

	private Node x3a4698d92c947fff(Node xc140f46ca02b5256)
	{
		if (xc140f46ca02b5256 != x437fa02210b98bec)
		{
			return xc140f46ca02b5256.NextSibling;
		}
		return x437fa02210b98bec.FirstChild;
	}

	private Node x71d22ac719af7426(Node xc140f46ca02b5256)
	{
		if (xc140f46ca02b5256 != x437fa02210b98bec)
		{
			return xc140f46ca02b5256.PreviousSibling;
		}
		return x437fa02210b98bec.LastChild;
	}

	private void x284efa4acfd1a1c7()
	{
		if (xa6fa8b02817e3274 != xd1424e1a0bb4a72b.x19fe9dfc9a096408)
		{
			xe88ab84767e8fb69();
		}
	}

	private void xe88ab84767e8fb69()
	{
		xa6fa8b02817e3274 = xd1424e1a0bb4a72b.x19fe9dfc9a096408;
		x18eaa95f10f1d19d = -1;
		xd66b3bfe87086cc8 = x437fa02210b98bec;
		x35a5073ffeb125c5 = -1;
	}
}
