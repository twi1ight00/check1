using System;
using System.Collections;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

[JavaGenericArguments("Iterable<Bookmark>")]
public class BookmarkCollection : IEnumerable
{
	private class xd88af2ad7b5cc3a1 : IEnumerator
	{
		private readonly INodeCollection xceef214d90365e20;

		private int x57d3c0a64c1df452;

		private BookmarkStart xd66b3bfe87086cc8;

		public object Current => xd66b3bfe87086cc8.Bookmark;

		internal xd88af2ad7b5cc3a1(INodeCollection bookmarkStarts)
		{
			xceef214d90365e20 = bookmarkStarts;
			Reset();
		}

		public bool MoveNext()
		{
			Node node = xceef214d90365e20[x57d3c0a64c1df452 + 1];
			if (node == null)
			{
				return false;
			}
			x57d3c0a64c1df452++;
			xd66b3bfe87086cc8 = (BookmarkStart)node;
			return true;
		}

		public void Reset()
		{
			x57d3c0a64c1df452 = -1;
			xd66b3bfe87086cc8 = null;
		}
	}

	private readonly INodeCollection xceef214d90365e20;

	public int Count => xceef214d90365e20.Count;

	public Bookmark this[int index] => ((BookmarkStart)xceef214d90365e20[index]).Bookmark;

	public Bookmark this[string bookmarkName]
	{
		get
		{
			x0d299f323d241756.x0aaaea7864a53f26(bookmarkName, "bookmarkName");
			foreach (BookmarkStart item in xceef214d90365e20)
			{
				if (x0d299f323d241756.x90637a473b1ceaaa(bookmarkName, item.Name))
				{
					return item.Bookmark;
				}
			}
			return null;
		}
	}

	internal BookmarkCollection(Node parent)
	{
		if (parent.IsComposite)
		{
			xceef214d90365e20 = ((CompositeNode)parent).GetChildNodes(NodeType.BookmarkStart, isDeep: true);
		}
		else
		{
			xceef214d90365e20 = x2c229a2f278462bd.x9834ddb0e0bd5996;
		}
	}

	internal int x2ee5ad3d826ed0fe(string xd17ec8f278d25c87)
	{
		int num = 0;
		foreach (BookmarkStart item in xceef214d90365e20)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(xd17ec8f278d25c87, item.Name))
			{
				return num;
			}
			num++;
		}
		return -1;
	}

	public void Remove(Bookmark bookmark)
	{
		if (bookmark == null)
		{
			throw new ArgumentNullException("bookmark");
		}
		bookmark.Remove();
	}

	public void Remove(string bookmarkName)
	{
		x0d299f323d241756.x0aaaea7864a53f26(bookmarkName, "bookmarkName");
		Remove(this[bookmarkName]);
	}

	public void RemoveAt(int index)
	{
		Remove(this[index]);
	}

	public void Clear()
	{
		for (int num = Count; num > 0; num--)
		{
			RemoveAt(0);
		}
	}

	public IEnumerator GetEnumerator()
	{
		return new xd88af2ad7b5cc3a1(xceef214d90365e20);
	}
}
