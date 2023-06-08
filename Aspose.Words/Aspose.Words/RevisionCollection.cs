using System;
using System.Collections;
using x28925c9b27b37a46;
using xf9a9481c3f63a419;

namespace Aspose.Words;

[JavaGenericArguments("Iterable<Revision>")]
public class RevisionCollection : IEnumerable
{
	private class x8e876bb478990712 : IEnumerator
	{
		private readonly INodeCollection xc5e3f1d66a36efa0;

		private readonly x0a80b8c2d1e8cf13 x217ce743395ca83d;

		private int x57d3c0a64c1df452;

		private Revision xd66b3bfe87086cc8;

		private readonly RevisionCollection x74a1277606c51af8;

		public object Current => xd66b3bfe87086cc8;

		internal x8e876bb478990712(INodeCollection nodeRevisions, ArrayList styleRevisions, RevisionCollection parent)
		{
			xc5e3f1d66a36efa0 = nodeRevisions;
			x217ce743395ca83d = new x0a80b8c2d1e8cf13(styleRevisions.GetEnumerator());
			x74a1277606c51af8 = parent;
			Reset();
		}

		public bool MoveNext()
		{
			if (x57d3c0a64c1df452 + 1 < xc5e3f1d66a36efa0.Count)
			{
				xd66b3bfe87086cc8 = new Revision(xc5e3f1d66a36efa0[x57d3c0a64c1df452], x74a1277606c51af8);
				x57d3c0a64c1df452++;
				return true;
			}
			if (x217ce743395ca83d.x47f176deff0d42e2())
			{
				xd66b3bfe87086cc8 = (Revision)x217ce743395ca83d.x35cfcea4890f4e7d;
				return true;
			}
			xd66b3bfe87086cc8 = null;
			return false;
		}

		public void Reset()
		{
			x57d3c0a64c1df452 = -1;
			xd66b3bfe87086cc8 = null;
		}
	}

	private static readonly x9b90da2cbda6214d xe1c1bb0dd08034a6 = new x9b90da2cbda6214d();

	private NodeCollection xc5e3f1d66a36efa0;

	private readonly ArrayList x217ce743395ca83d = new ArrayList();

	public int Count => xc5e3f1d66a36efa0.Count + x217ce743395ca83d.Count;

	public Revision this[int index]
	{
		get
		{
			if (index < xc5e3f1d66a36efa0.Count)
			{
				return new Revision(xc5e3f1d66a36efa0[index], this);
			}
			int num = index - xc5e3f1d66a36efa0.Count;
			if (num < x217ce743395ca83d.Count)
			{
				return (Revision)x217ce743395ca83d[num];
			}
			throw new ArgumentOutOfRangeException("index");
		}
	}

	internal RevisionCollection(DocumentBase doc)
	{
		xc5e3f1d66a36efa0 = new NodeCollection(doc, xe1c1bb0dd08034a6, isDeep: true);
		foreach (Style style in doc.Styles)
		{
			if (style.xcb78713836fcc98a)
			{
				xd6b6ed77479ef68c(style);
			}
		}
	}

	public void AcceptAll()
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Revision revision = (Revision)enumerator.Current;
				revision.xb30fd80dd933c5a8(x510619ea70954ab6: true, xaf009d95451d3630: false, revision.xc5bb70cfaaae4a20 ? arrayList : arrayList2);
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
		xdd8aa62f92df1485.x698d7efb49fcb65f(arrayList, arrayList2);
		x6d7038e04941a055();
	}

	public void RejectAll()
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Revision revision = (Revision)enumerator.Current;
				revision.xb30fd80dd933c5a8(x510619ea70954ab6: false, xaf009d95451d3630: false, revision.xc5bb70cfaaae4a20 ? arrayList : arrayList2);
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
		xdd8aa62f92df1485.x698d7efb49fcb65f(arrayList, arrayList2);
		x6d7038e04941a055();
	}

	internal void xe88ab84767e8fb69(Revision xde2016e90885f436)
	{
		if (xde2016e90885f436.RevisionType != RevisionType.StyleDefinitionChange)
		{
			x350c7f51fd617cd6();
		}
		else
		{
			x217ce743395ca83d.Remove(xde2016e90885f436);
		}
	}

	internal void xd6b6ed77479ef68c(Style x44ecfea61c937b8e)
	{
		x217ce743395ca83d.Add(new Revision(x44ecfea61c937b8e, this));
	}

	internal void x52b190e626f65140(Style x44ecfea61c937b8e)
	{
		Revision revision = null;
		foreach (Revision item in x217ce743395ca83d)
		{
			if (item.ParentStyle.x8301ab10c226b0c2 == x44ecfea61c937b8e.x8301ab10c226b0c2)
			{
				revision = item;
				break;
			}
		}
		if (revision != null)
		{
			x217ce743395ca83d.Remove(revision);
		}
	}

	private void x6d7038e04941a055()
	{
		x350c7f51fd617cd6();
		x217ce743395ca83d.Clear();
	}

	private void x350c7f51fd617cd6()
	{
		xc5e3f1d66a36efa0 = new NodeCollection(xc5e3f1d66a36efa0.xc255c495fd9232ca, xe1c1bb0dd08034a6, isDeep: true);
	}

	public IEnumerator GetEnumerator()
	{
		return new x8e876bb478990712(xc5e3f1d66a36efa0, x217ce743395ca83d, this);
	}
}
