using System.Collections;
using Aspose.Words;

namespace x28925c9b27b37a46;

internal class xb56968f92e308c8a : x1f200d623d7fb856, IEnumerator
{
	private readonly x7e263f21a73a027a x4517c2b411ea1d52;

	private x98739d759efb5fe7 xc83d0e6d4611cafd;

	object IEnumerator.xb9ac0e46915f1b64 => x3387295f12854dfd;

	protected bool x83f9d074410e5abf => x4517c2b411ea1d52.x12cb12b5d2cad53d.xb84fd3bd45bf0c24(xc83d0e6d4611cafd);

	protected bool x375e8189a5358be0 => x4517c2b411ea1d52.x9fd888e65466818c.xb84fd3bd45bf0c24(xc83d0e6d4611cafd);

	protected bool x2cfe892a9c18ef55 => x4517c2b411ea1d52.x12cb12b5d2cad53d.x807fa4fe13e2b839(xc83d0e6d4611cafd);

	protected bool x4cfb8da53d040316 => x4517c2b411ea1d52.x9fd888e65466818c.x807fa4fe13e2b839(xc83d0e6d4611cafd);

	internal x7e263f21a73a027a x7d2e50686d249839 => x4517c2b411ea1d52;

	internal Node x3387295f12854dfd
	{
		get
		{
			if (xc83d0e6d4611cafd == null)
			{
				return null;
			}
			return xc83d0e6d4611cafd.x40212106aad8a8b0;
		}
	}

	internal x98739d759efb5fe7 x180f9c8380162d4e => xc83d0e6d4611cafd;

	internal xb56968f92e308c8a(x7e263f21a73a027a range)
	{
		x4517c2b411ea1d52 = range;
	}

	internal bool x1ef2c3be187f37a2()
	{
		return x1ef2c3be187f37a2(x0d900d42b3598fde: true);
	}

	internal bool x1ef2c3be187f37a2(bool x0d900d42b3598fde)
	{
		return x1ef2c3be187f37a2(x0d900d42b3598fde, x4283b4e6c57a1853: true);
	}

	internal bool x1ef2c3be187f37a2(bool x0d900d42b3598fde, bool x4283b4e6c57a1853)
	{
		if (x4517c2b411ea1d52.x30d6662e83251ab4 || x4517c2b411ea1d52.x7149c962c02931b3)
		{
			return false;
		}
		if (xc83d0e6d4611cafd == null)
		{
			xc83d0e6d4611cafd = x4517c2b411ea1d52.x12cb12b5d2cad53d.x8b61531c8ea35b85();
			if (x4517c2b411ea1d52.xf89ce0154d15311b)
			{
				return true;
			}
		}
		if (x0e410626c9576523(xe55df9fb33ab790b: false))
		{
			return false;
		}
		Node node = x3387295f12854dfd;
		do
		{
			if (!xc83d0e6d4611cafd.x9e19f5bd0a6dd5b7(null, xa17853d20c8c42bd: true, x0d900d42b3598fde, x2709983bf2ac093e: true, !x4283b4e6c57a1853, xad9f70dbf5281236: true, this))
			{
				return false;
			}
			if (x0e410626c9576523(!x4283b4e6c57a1853))
			{
				return false;
			}
		}
		while (x4283b4e6c57a1853 && (xc83d0e6d4611cafd.x375e8189a5358be0 || x3387295f12854dfd == node));
		return true;
	}

	private bool x0e410626c9576523(bool xe55df9fb33ab790b)
	{
		if (!x4cfb8da53d040316)
		{
			return false;
		}
		if (!x2cfe892a9c18ef55 && !x4517c2b411ea1d52.x09a741c07fe6233f)
		{
			return true;
		}
		if (xc83d0e6d4611cafd.x375e8189a5358be0 && !xe55df9fb33ab790b)
		{
			return true;
		}
		return false;
	}

	internal Node x64ae56857b252b27(xe83a6b069ec8efc2 xcbf24c118ac8aa0b, bool x457efc87f780f707)
	{
		x98739d759efb5fe7 x12cb12b5d2cad53d = x7d2e50686d249839.x12cb12b5d2cad53d;
		x98739d759efb5fe7 x9fd888e65466818c = x7d2e50686d249839.x9fd888e65466818c;
		Node node = (x457efc87f780f707 ? x3387295f12854dfd.Clone(isCloneChildren: true) : x3387295f12854dfd);
		bool x1e2b473fecc8c6b = !x457efc87f780f707;
		if (x3387295f12854dfd.NodeType == NodeType.Run)
		{
			Run run = (Run)node;
			int num = (x2cfe892a9c18ef55 ? x12cb12b5d2cad53d.xf1d9b91c9700c401 : 0);
			int num2 = ((!x4cfb8da53d040316) ? run.Text.Length : (x9fd888e65466818c.x375e8189a5358be0 ? run.Text.Length : x9fd888e65466818c.xf1d9b91c9700c401));
			int num3 = num2 - num;
			if (num3 < run.Text.Length)
			{
				node = run.x4ede2f7ca43a1460(num, num3, x1e2b473fecc8c6b);
			}
		}
		if (xcbf24c118ac8aa0b != null)
		{
			bool flag = node != x3387295f12854dfd;
			node = xcbf24c118ac8aa0b.x57f70b425b43a885(x3387295f12854dfd, node, !flag);
		}
		return node;
	}

	protected virtual void OnMoved(x92efcb0dc4970661 movement)
	{
	}

	protected static Node xa14d0084f5d1ce76(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 == null)
		{
			return null;
		}
		if (xda5bf54deb817e37.NodeType == NodeType.Body)
		{
			return xda5bf54deb817e37.ParentNode;
		}
		return xda5bf54deb817e37;
	}

	protected static Node x5de48b1c2cfe605c(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 == null)
		{
			return null;
		}
		return xda5bf54deb817e37.NodeType switch
		{
			NodeType.HeaderFooter => ((Section)xda5bf54deb817e37.ParentNode).Body?.FirstChild, 
			NodeType.Body => ((Body)xda5bf54deb817e37).FirstChild, 
			_ => xda5bf54deb817e37, 
		};
	}

	private bool xe89ce0670414e2ba()
	{
		return x1ef2c3be187f37a2();
	}

	bool IEnumerator.MoveNext()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xe89ce0670414e2ba
		return this.xe89ce0670414e2ba();
	}

	private void xf80999337bada71a()
	{
		xc83d0e6d4611cafd = null;
	}

	void IEnumerator.Reset()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xf80999337bada71a
		this.xf80999337bada71a();
	}

	private void x5f2a86d7bc89df8b(x92efcb0dc4970661 x90e2bcec392359ea)
	{
		switch (x90e2bcec392359ea)
		{
		case x92efcb0dc4970661.x887a0c79ecbe5ee3:
		{
			Node node2 = xa14d0084f5d1ce76(x3387295f12854dfd);
			if (node2 != x3387295f12854dfd)
			{
				xc83d0e6d4611cafd = x98739d759efb5fe7.xeea9b43f0c912fdb(node2);
			}
			break;
		}
		case x92efcb0dc4970661.x79a071bfba0c5e7d:
		{
			Node node = x5de48b1c2cfe605c(x3387295f12854dfd);
			if (node != x3387295f12854dfd)
			{
				xc83d0e6d4611cafd = x98739d759efb5fe7.xf86191ae51e45118(node);
			}
			break;
		}
		}
		OnMoved(x90e2bcec392359ea);
	}

	void x1f200d623d7fb856.x47f3804d8f6ba7c1(x92efcb0dc4970661 x90e2bcec392359ea)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x5f2a86d7bc89df8b
		this.x5f2a86d7bc89df8b(x90e2bcec392359ea);
	}
}
