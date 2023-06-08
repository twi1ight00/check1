using System;
using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x98739d759efb5fe7
{
	internal static readonly x98739d759efb5fe7 x825c3b6fa3e39f20 = new x98739d759efb5fe7(null);

	private Node x48154453a08515ea;

	private int x62d9bfcf54e338cb;

	private int x823c6b25cc2689d8;

	internal Node x40212106aad8a8b0
	{
		get
		{
			return x48154453a08515ea;
		}
		set
		{
			x48154453a08515ea = value;
			x823c6b25cc2689d8 = -1;
		}
	}

	internal int xf1d9b91c9700c401
	{
		get
		{
			return x62d9bfcf54e338cb;
		}
		set
		{
			x62d9bfcf54e338cb = value;
		}
	}

	internal bool x83f9d074410e5abf => 0 >= xf1d9b91c9700c401;

	internal bool x375e8189a5358be0 => x1be93eed8950d961 <= xf1d9b91c9700c401;

	internal bool x30d6662e83251ab4 => null == x40212106aad8a8b0;

	private int x1be93eed8950d961
	{
		get
		{
			if (0 >= x823c6b25cc2689d8)
			{
				if (NodeType.Run == x40212106aad8a8b0.NodeType)
				{
					x823c6b25cc2689d8 = x40212106aad8a8b0.x2e39a445d52f6ea8();
				}
				else
				{
					x823c6b25cc2689d8 = 1;
				}
			}
			return x823c6b25cc2689d8;
		}
	}

	internal x98739d759efb5fe7(Node node)
		: this(node, 0)
	{
	}

	internal x98739d759efb5fe7(Node node, int offset)
	{
		x48154453a08515ea = node;
		x62d9bfcf54e338cb = offset;
		x823c6b25cc2689d8 = -1;
	}

	internal static x98739d759efb5fe7 xf86191ae51e45118(Node xda5bf54deb817e37)
	{
		x98739d759efb5fe7 x98739d759efb5fe8 = new x98739d759efb5fe7(xda5bf54deb817e37);
		x98739d759efb5fe8.xac0bfd155c704ff8();
		return x98739d759efb5fe8;
	}

	internal static x98739d759efb5fe7 xeea9b43f0c912fdb(Node xda5bf54deb817e37)
	{
		x98739d759efb5fe7 x98739d759efb5fe8 = new x98739d759efb5fe7(xda5bf54deb817e37);
		x98739d759efb5fe8.x8a92b04b9d325900();
		return x98739d759efb5fe8;
	}

	internal void xac0bfd155c704ff8()
	{
		xf1d9b91c9700c401 = 0;
	}

	internal void x8a92b04b9d325900()
	{
		xf1d9b91c9700c401 = x1be93eed8950d961;
	}

	internal bool x9e19f5bd0a6dd5b7(Node xc301afa072787492, bool xa17853d20c8c42bd, bool x0d900d42b3598fde, bool x2709983bf2ac093e, bool xa5486b84e3604cca, bool xad9f70dbf5281236)
	{
		return x9e19f5bd0a6dd5b7(xc301afa072787492, xa17853d20c8c42bd, x0d900d42b3598fde, x2709983bf2ac093e, xa5486b84e3604cca, xad9f70dbf5281236, null);
	}

	internal bool x9e19f5bd0a6dd5b7(Node xc301afa072787492, bool xa17853d20c8c42bd, bool x0d900d42b3598fde, bool x2709983bf2ac093e, bool xa5486b84e3604cca, bool xad9f70dbf5281236, x1f200d623d7fb856 xa17608be6f3e3287)
	{
		if (x30d6662e83251ab4)
		{
			if (xc301afa072787492 == null)
			{
				throw new ArgumentNullException("root");
			}
			x40212106aad8a8b0 = xc301afa072787492;
			xf1d9b91c9700c401 = ((!xa17853d20c8c42bd) ? x1be93eed8950d961 : 0);
			return true;
		}
		xf1d9b91c9700c401 = Math.Min(x1be93eed8950d961, Math.Max(0, xf1d9b91c9700c401));
		x92efcb0dc4970661 x92efcb0dc4970662 = x92efcb0dc4970661.x4d0b9d4447ba7566;
		if (xf852ea9f29f91dbf(xa17853d20c8c42bd, xa5486b84e3604cca, xad9f70dbf5281236))
		{
			x92efcb0dc4970662 = x92efcb0dc4970661.x36402acf75b1fd6a;
		}
		else if (x201d5b474fb7933f(xc301afa072787492, xa17853d20c8c42bd, x0d900d42b3598fde, x2709983bf2ac093e))
		{
			x92efcb0dc4970662 = x92efcb0dc4970661.x79a071bfba0c5e7d;
		}
		else if (xd612761dc1257d75(xa17853d20c8c42bd, xad9f70dbf5281236))
		{
			x92efcb0dc4970662 = x92efcb0dc4970661.xffb3b939df766df0;
		}
		else if (xcd0dc75175b27b87(xc301afa072787492, xa17853d20c8c42bd))
		{
			x92efcb0dc4970662 = x92efcb0dc4970661.x385d4715749f0bea;
		}
		else if (xb901486f2a042caa(xc301afa072787492, xa17853d20c8c42bd, x0d900d42b3598fde, x2709983bf2ac093e, xa5486b84e3604cca, xad9f70dbf5281236))
		{
			x92efcb0dc4970662 = x92efcb0dc4970661.x887a0c79ecbe5ee3;
		}
		if (x92efcb0dc4970662 != 0)
		{
			xa17608be6f3e3287?.x47f3804d8f6ba7c1(x92efcb0dc4970662);
			return true;
		}
		return false;
	}

	internal bool x47f176deff0d42e2(bool x4283b4e6c57a1853)
	{
		bool flag = x9e19f5bd0a6dd5b7(null, xa17853d20c8c42bd: true, x0d900d42b3598fde: true, x2709983bf2ac093e: true, !x4283b4e6c57a1853, xad9f70dbf5281236: true);
		if (flag && x375e8189a5358be0 && !x40212106aad8a8b0.IsComposite)
		{
			flag = x9e19f5bd0a6dd5b7(null, xa17853d20c8c42bd: true, x0d900d42b3598fde: true, x2709983bf2ac093e: true, !x4283b4e6c57a1853, xad9f70dbf5281236: true);
		}
		return flag;
	}

	internal bool xb84fd3bd45bf0c24(x98739d759efb5fe7 x13d4cb8d1bd20347)
	{
		if (x13d4cb8d1bd20347 == null)
		{
			return false;
		}
		if (x807fa4fe13e2b839(x13d4cb8d1bd20347))
		{
			return xf1d9b91c9700c401 == x13d4cb8d1bd20347.xf1d9b91c9700c401;
		}
		return false;
	}

	internal bool x807fa4fe13e2b839(x98739d759efb5fe7 x13d4cb8d1bd20347)
	{
		if (x13d4cb8d1bd20347 == null)
		{
			return false;
		}
		return x40212106aad8a8b0 == x13d4cb8d1bd20347.x40212106aad8a8b0;
	}

	internal x98739d759efb5fe7 x8b61531c8ea35b85()
	{
		return (x98739d759efb5fe7)MemberwiseClone();
	}

	private bool xf852ea9f29f91dbf(bool xa17853d20c8c42bd, bool xa5486b84e3604cca, bool xad9f70dbf5281236)
	{
		if (x40212106aad8a8b0 is CompositeNode)
		{
			return false;
		}
		if (!xa5486b84e3604cca)
		{
			return false;
		}
		if (xa17853d20c8c42bd)
		{
			if (xf1d9b91c9700c401 + (xad9f70dbf5281236 ? 1 : 2) > x1be93eed8950d961)
			{
				return false;
			}
			xf1d9b91c9700c401++;
		}
		else
		{
			if (xf1d9b91c9700c401 - (xad9f70dbf5281236 ? 1 : 2) < 0)
			{
				return false;
			}
			xf1d9b91c9700c401--;
		}
		return true;
	}

	private bool x201d5b474fb7933f(Node xc301afa072787492, bool xa17853d20c8c42bd, bool x0d900d42b3598fde, bool x2709983bf2ac093e)
	{
		if (!x0d900d42b3598fde)
		{
			return false;
		}
		if ((!xa17853d20c8c42bd || !x83f9d074410e5abf) && (xa17853d20c8c42bd || !x375e8189a5358be0))
		{
			return false;
		}
		if (!x2709983bf2ac093e && x40212106aad8a8b0 != xc301afa072787492 && x2b1ee3a87b36a988.xb871ce087a6d574e(x40212106aad8a8b0))
		{
			return false;
		}
		if (!x40212106aad8a8b0.IsComposite)
		{
			return false;
		}
		CompositeNode compositeNode = (CompositeNode)x40212106aad8a8b0;
		if (!compositeNode.HasChildNodes)
		{
			return false;
		}
		x40212106aad8a8b0 = (xa17853d20c8c42bd ? compositeNode.FirstChild : compositeNode.LastChild);
		xf1d9b91c9700c401 = ((!xa17853d20c8c42bd) ? x1be93eed8950d961 : 0);
		return true;
	}

	private bool xd612761dc1257d75(bool xa17853d20c8c42bd, bool xad9f70dbf5281236)
	{
		if (!xad9f70dbf5281236)
		{
			return false;
		}
		if (xa17853d20c8c42bd)
		{
			if (x375e8189a5358be0)
			{
				return false;
			}
			x8a92b04b9d325900();
		}
		else
		{
			if (x83f9d074410e5abf)
			{
				return false;
			}
			xac0bfd155c704ff8();
		}
		return true;
	}

	private bool xcd0dc75175b27b87(Node xc301afa072787492, bool xa17853d20c8c42bd)
	{
		if (xc301afa072787492 == x40212106aad8a8b0)
		{
			return false;
		}
		if (xa17853d20c8c42bd && x40212106aad8a8b0.NextSibling != null)
		{
			x40212106aad8a8b0 = x40212106aad8a8b0.NextSibling;
			xf1d9b91c9700c401 = 0;
			return true;
		}
		if (!xa17853d20c8c42bd && x40212106aad8a8b0.PreviousSibling != null)
		{
			x40212106aad8a8b0 = x40212106aad8a8b0.PreviousSibling;
			xf1d9b91c9700c401 = x1be93eed8950d961;
			return true;
		}
		return false;
	}

	private bool xb901486f2a042caa(Node xc301afa072787492, bool xa17853d20c8c42bd, bool x0d900d42b3598fde, bool x2709983bf2ac093e, bool xa5486b84e3604cca, bool xad9f70dbf5281236)
	{
		if (x40212106aad8a8b0 == xc301afa072787492)
		{
			return false;
		}
		if (x40212106aad8a8b0.ParentNode == null)
		{
			return false;
		}
		if (!x2709983bf2ac093e && xc301afa072787492 != x40212106aad8a8b0.ParentNode && x2b1ee3a87b36a988.xb871ce087a6d574e(x40212106aad8a8b0.ParentNode))
		{
			return false;
		}
		x40212106aad8a8b0 = x40212106aad8a8b0.ParentNode;
		xf1d9b91c9700c401 = (xa17853d20c8c42bd ? x1be93eed8950d961 : 0);
		if (!xad9f70dbf5281236)
		{
			return x9e19f5bd0a6dd5b7(xc301afa072787492, xa17853d20c8c42bd, x0d900d42b3598fde, x2709983bf2ac093e, xa5486b84e3604cca, xad9f70dbf5281236: false);
		}
		return true;
	}
}
