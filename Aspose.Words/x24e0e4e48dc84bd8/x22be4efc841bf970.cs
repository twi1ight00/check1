using System;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using xa7850104c8d8c135;

namespace x24e0e4e48dc84bd8;

internal class x22be4efc841bf970
{
	private x54366fa5f75a02f7 x2421cb0c8da5f8ef = new x54366fa5f75a02f7();

	private x54366fa5f75a02f7 xbc9b7b66516e31be;

	private x54366fa5f75a02f7 xa32e501dc7fac3fb = new x54366fa5f75a02f7();

	public x54366fa5f75a02f7 x1e9acba06e394dcb
	{
		get
		{
			if (xbc9b7b66516e31be == null)
			{
				xbc9b7b66516e31be = xa32e501dc7fac3fb.x8b61531c8ea35b85();
				xbc9b7b66516e31be.x490e30087768649f(x2421cb0c8da5f8ef, MatrixOrder.Append);
			}
			return xbc9b7b66516e31be;
		}
	}

	public x54366fa5f75a02f7 xd71ff2df6be55726 => x2421cb0c8da5f8ef;

	public x54366fa5f75a02f7 x157c189cf7f71f03 => xa32e501dc7fac3fb;

	public void x3ef26574dd6a5679(x54366fa5f75a02f7 xa801ccff44b0c7eb, x0ccf5a71249ef4a6 xa4aa8b4150b11435)
	{
		switch (xa4aa8b4150b11435)
		{
		case x0ccf5a71249ef4a6.xd7dde027c81bb9a6:
			xa32e501dc7fac3fb = new x54366fa5f75a02f7();
			break;
		case x0ccf5a71249ef4a6.x9dcbb68afa7678b9:
			xa32e501dc7fac3fb.x490e30087768649f(xa801ccff44b0c7eb, MatrixOrder.Prepend);
			break;
		case x0ccf5a71249ef4a6.x73ec591f716ac6c5:
			xa32e501dc7fac3fb.x490e30087768649f(xa801ccff44b0c7eb, MatrixOrder.Append);
			break;
		case x0ccf5a71249ef4a6.x90fda48194fc6b9a:
			xa32e501dc7fac3fb = xa801ccff44b0c7eb;
			break;
		default:
			throw new ArgumentOutOfRangeException("mode");
		}
		xbc9b7b66516e31be = null;
	}

	public void xd84a07f373fdfcb3(double x9bdeb785c5aca5b5)
	{
		x2421cb0c8da5f8ef = new x54366fa5f75a02f7();
		x2421cb0c8da5f8ef.x5152a5707921c783((float)x9bdeb785c5aca5b5, (float)x9bdeb785c5aca5b5);
		xbc9b7b66516e31be = null;
	}

	public x22be4efc841bf970 x8b61531c8ea35b85()
	{
		x22be4efc841bf970 x22be4efc841bf971 = new x22be4efc841bf970();
		if (x2421cb0c8da5f8ef != null)
		{
			x22be4efc841bf971.x2421cb0c8da5f8ef = x2421cb0c8da5f8ef.x8b61531c8ea35b85();
		}
		if (xa32e501dc7fac3fb != null)
		{
			x22be4efc841bf971.xa32e501dc7fac3fb = xa32e501dc7fac3fb.x8b61531c8ea35b85();
		}
		if (xbc9b7b66516e31be != null)
		{
			x22be4efc841bf971.xbc9b7b66516e31be = xbc9b7b66516e31be.x8b61531c8ea35b85();
		}
		return x22be4efc841bf971;
	}
}
