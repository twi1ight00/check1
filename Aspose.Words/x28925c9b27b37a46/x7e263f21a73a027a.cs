using System.Collections;
using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x7e263f21a73a027a : IEnumerable
{
	internal static readonly x7e263f21a73a027a x825c3b6fa3e39f20 = new x7e263f21a73a027a(x98739d759efb5fe7.x825c3b6fa3e39f20, x98739d759efb5fe7.x825c3b6fa3e39f20);

	private readonly x98739d759efb5fe7 x212ae880d15d2ed1;

	private readonly x98739d759efb5fe7 xb664a8c25c0c85cc;

	internal bool x30d6662e83251ab4
	{
		get
		{
			if (!x212ae880d15d2ed1.x30d6662e83251ab4)
			{
				return xb664a8c25c0c85cc.x30d6662e83251ab4;
			}
			return true;
		}
	}

	internal bool x807fa4fe13e2b839 => x212ae880d15d2ed1.x807fa4fe13e2b839(xb664a8c25c0c85cc);

	internal bool x880cbff6b687171e => x212ae880d15d2ed1.x40212106aad8a8b0.ParentNode == xb664a8c25c0c85cc.x40212106aad8a8b0.ParentNode;

	internal bool xf89ce0154d15311b => !x212ae880d15d2ed1.x375e8189a5358be0;

	internal bool x09a741c07fe6233f => !xb664a8c25c0c85cc.x83f9d074410e5abf;

	internal x98739d759efb5fe7 x12cb12b5d2cad53d => x212ae880d15d2ed1;

	internal x98739d759efb5fe7 x9fd888e65466818c => xb664a8c25c0c85cc;

	internal bool x7149c962c02931b3
	{
		get
		{
			if (x9fd888e65466818c.x40212106aad8a8b0.NodeType == NodeType.Run)
			{
				if (x212ae880d15d2ed1.x807fa4fe13e2b839(xb664a8c25c0c85cc))
				{
					if (x212ae880d15d2ed1.xf1d9b91c9700c401 < xb664a8c25c0c85cc.xf1d9b91c9700c401)
					{
						return x212ae880d15d2ed1.x375e8189a5358be0;
					}
					return true;
				}
				return false;
			}
			return x212ae880d15d2ed1.xb84fd3bd45bf0c24(xb664a8c25c0c85cc);
		}
	}

	internal x7e263f21a73a027a(Node start, Node end)
		: this(start, includeStart: true, end, includeEnd: true)
	{
	}

	internal x7e263f21a73a027a(Node start, bool includeStart, Node end, bool includeEnd)
		: this(includeStart ? x98739d759efb5fe7.xf86191ae51e45118(start) : x98739d759efb5fe7.xeea9b43f0c912fdb(start), includeEnd ? x98739d759efb5fe7.xeea9b43f0c912fdb(end) : x98739d759efb5fe7.xf86191ae51e45118(end))
	{
	}

	internal x7e263f21a73a027a(x98739d759efb5fe7 start, x98739d759efb5fe7 end)
	{
		x212ae880d15d2ed1 = start;
		xb664a8c25c0c85cc = end;
	}

	internal void x4973afdae604d531()
	{
		if (x212ae880d15d2ed1.x40212106aad8a8b0.NodeType == NodeType.Run && !x212ae880d15d2ed1.x375e8189a5358be0)
		{
			Run run = (Run)x212ae880d15d2ed1.x40212106aad8a8b0;
			int xf1d9b91c9700c = x212ae880d15d2ed1.xf1d9b91c9700c401;
			run.x4a406570a6226227(xf1d9b91c9700c);
			x212ae880d15d2ed1.xac0bfd155c704ff8();
			if (x807fa4fe13e2b839 && xb664a8c25c0c85cc.xf1d9b91c9700c401 != -1)
			{
				xb664a8c25c0c85cc.xf1d9b91c9700c401 -= xf1d9b91c9700c;
			}
		}
		if (xb664a8c25c0c85cc.x40212106aad8a8b0.NodeType == NodeType.Run && xb664a8c25c0c85cc.xf1d9b91c9700c401 > 0)
		{
			Run run2 = (Run)xb664a8c25c0c85cc.x40212106aad8a8b0;
			run2.xd0d7979207229aff(xb664a8c25c0c85cc.xf1d9b91c9700c401);
			xb664a8c25c0c85cc.x8a92b04b9d325900();
		}
	}

	internal void x7012609bcdb39574(DocumentVisitor x672ff13faf031f3d, xe83a6b069ec8efc2 xcbf24c118ac8aa0b)
	{
		x5aecdcadf3dde94b x5aecdcadf3dde94b2 = new x5aecdcadf3dde94b(this, x672ff13faf031f3d, xcbf24c118ac8aa0b);
		x5aecdcadf3dde94b2.xc2b3e0605f4afe6a();
	}

	internal Node x52b190e626f65140()
	{
		x4973afdae604d531();
		Node result = x7cc53a59d101f8fa();
		x5699f8523a546a42.x52b190e626f65140(this, xe1bd913bc72a8d58.x15fc7f7f5bee2386);
		return result;
	}

	private Node x7cc53a59d101f8fa()
	{
		Node x40212106aad8a8b = xb664a8c25c0c85cc.x40212106aad8a8b0;
		if (xb664a8c25c0c85cc.x83f9d074410e5abf)
		{
			return x40212106aad8a8b;
		}
		if (x40212106aad8a8b.NextSibling == null)
		{
			return x40212106aad8a8b.ParentNode;
		}
		return x40212106aad8a8b.NextSibling;
	}

	internal bool xae11a38e854312f4(NodeType xd080fb3c547ae2bf)
	{
		return x2b1ee3a87b36a988.x6e7216533ee7db3e(x212ae880d15d2ed1.x40212106aad8a8b0, xd080fb3c547ae2bf) == x2b1ee3a87b36a988.x6e7216533ee7db3e(xb664a8c25c0c85cc.x40212106aad8a8b0, xd080fb3c547ae2bf);
	}

	public IEnumerator GetEnumerator()
	{
		return new xb56968f92e308c8a(this);
	}
}
