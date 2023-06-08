using Aspose.Words;
using x28925c9b27b37a46;
using x2a6f63b6650e76c4;

namespace xfbd1009a0cbb9842;

internal class x64629b07e6a0cb07 : x7c04dbcdccf44713
{
	private readonly string xed4a7b1500064e12;

	private readonly x7e263f21a73a027a x4517c2b411ea1d52;

	private x7e263f21a73a027a xaf8ed507ce44d7e5;

	internal x7e263f21a73a027a x7d2e50686d249839 => x4517c2b411ea1d52;

	internal x7e263f21a73a027a xd5f54c4e31213f30
	{
		get
		{
			if (xaf8ed507ce44d7e5 == null)
			{
				xa2ce893605872980();
			}
			return xaf8ed507ce44d7e5;
		}
	}

	internal x64629b07e6a0cb07(string text, x7e263f21a73a027a range)
	{
		xed4a7b1500064e12 = text;
		x4517c2b411ea1d52 = range;
	}

	internal string xd961adf06ad48c3f()
	{
		return xd961adf06ad48c3f(x82dae5f27bd7d807: true);
	}

	internal string xd961adf06ad48c3f(bool x82dae5f27bd7d807)
	{
		return x78f7ad9d7fd68e82.xef44648eae7d9918(xed4a7b1500064e12, x82dae5f27bd7d807);
	}

	private void xa2ce893605872980()
	{
		Node node = null;
		Node node2 = null;
		x98739d759efb5fe7 x98739d759efb5fe = x4517c2b411ea1d52.x9fd888e65466818c.x8b61531c8ea35b85();
		Node x40212106aad8a8b = x98739d759efb5fe.x40212106aad8a8b0;
		bool flag = false;
		int num = 0;
		while (true)
		{
			switch (x40212106aad8a8b.NodeType)
			{
			case NodeType.FieldEnd:
				if (num++ == 0 && node2 == null)
				{
					node2 = x40212106aad8a8b;
				}
				break;
			case NodeType.FieldStart:
				if (--num == 0)
				{
					node = x40212106aad8a8b;
				}
				break;
			}
			if (x40212106aad8a8b == x4517c2b411ea1d52.x12cb12b5d2cad53d.x40212106aad8a8b0)
			{
				flag = true;
			}
			if (flag && num == 0)
			{
				break;
			}
			do
			{
				x98739d759efb5fe.x9e19f5bd0a6dd5b7(null, xa17853d20c8c42bd: false, x0d900d42b3598fde: true, x2709983bf2ac093e: true, xa5486b84e3604cca: false, xad9f70dbf5281236: false);
			}
			while (x40212106aad8a8b == x98739d759efb5fe.x40212106aad8a8b0);
			x40212106aad8a8b = x98739d759efb5fe.x40212106aad8a8b0;
		}
		xaf8ed507ce44d7e5 = ((node != null && node2 != null) ? new x7e263f21a73a027a(node, node2) : x4517c2b411ea1d52);
	}

	private x82e26649b09596bd xe572abd1407c334c()
	{
		return new xdfbdf8708b1e8b71(xd961adf06ad48c3f());
	}

	x82e26649b09596bd x7c04dbcdccf44713.x297a08accbde149a()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xe572abd1407c334c
		return this.xe572abd1407c334c();
	}

	private x7e263f21a73a027a xef64f9c7fb4e1f5c()
	{
		return x4517c2b411ea1d52;
	}

	x7e263f21a73a027a x7c04dbcdccf44713.x2eb30ee04563e9e4()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xef64f9c7fb4e1f5c
		return this.xef64f9c7fb4e1f5c();
	}
}
