using System.Collections;
using System.Xml.XPath;
using x28925c9b27b37a46;

namespace Aspose.Words;

[JavaManual("In Java this works with Jaxen Xpath engine.")]
public class NodeList : IEnumerable
{
	private class xb79b95ca82fbf74a : IEnumerator
	{
		private NodeList xc7d5d28b3f8072cd;

		private int x57d3c0a64c1df452;

		private Node xd66b3bfe87086cc8;

		public object Current => xd66b3bfe87086cc8;

		internal xb79b95ca82fbf74a(NodeList nodes)
		{
			xc7d5d28b3f8072cd = nodes;
			Reset();
		}

		public bool MoveNext()
		{
			x57d3c0a64c1df452++;
			xc7d5d28b3f8072cd.xcfcb0e57adb99c3c(x57d3c0a64c1df452 + 1);
			xd66b3bfe87086cc8 = xc7d5d28b3f8072cd[x57d3c0a64c1df452];
			return xd66b3bfe87086cc8 != null;
		}

		public void Reset()
		{
			x57d3c0a64c1df452 = -1;
			xd66b3bfe87086cc8 = null;
		}
	}

	private XPathNodeIterator xad7bb7c9d893612c;

	private ArrayList x83784fea83f63bbc;

	private bool xfb5f3a1ca4d0218d;

	public Node this[int index]
	{
		get
		{
			if (index < 0)
			{
				index = Count + index;
				if (index < 0)
				{
					return null;
				}
			}
			if (index >= x83784fea83f63bbc.Count)
			{
				xcfcb0e57adb99c3c(index);
			}
			if (index >= x83784fea83f63bbc.Count)
			{
				return null;
			}
			return (Node)x83784fea83f63bbc[index];
		}
	}

	public int Count
	{
		get
		{
			xcfcb0e57adb99c3c(int.MaxValue);
			return x83784fea83f63bbc.Count;
		}
	}

	internal NodeList(XPathNodeIterator iterator)
	{
		xad7bb7c9d893612c = iterator;
		x83784fea83f63bbc = new ArrayList();
		xfb5f3a1ca4d0218d = false;
	}

	public Node[] ToArray()
	{
		int count = Count;
		Node[] array = new Node[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = this[i];
		}
		return array;
	}

	public IEnumerator GetEnumerator()
	{
		return new xb79b95ca82fbf74a(this);
	}

	internal void xcfcb0e57adb99c3c(int xc0c4c459c6ccbd00)
	{
		if (xfb5f3a1ca4d0218d)
		{
			return;
		}
		while (xc0c4c459c6ccbd00 >= x83784fea83f63bbc.Count)
		{
			if (xad7bb7c9d893612c.MoveNext())
			{
				x030154038d5d0afb x030154038d5d0afb = (x030154038d5d0afb)xad7bb7c9d893612c.Current;
				Node x3387295f12854dfd = x030154038d5d0afb.x3387295f12854dfd;
				if (x3387295f12854dfd != null)
				{
					x83784fea83f63bbc.Add(x3387295f12854dfd);
				}
				continue;
			}
			xfb5f3a1ca4d0218d = true;
			break;
		}
	}
}
