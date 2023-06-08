using System;
using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;

namespace x120d4bb5c80fb10c;

internal class x2edb8efcf734419a
{
	private xa3194ec78bd24615 x8446e731d644fa6b;

	private readonly ArrayList xd5126346e5101136 = new ArrayList();

	private byte[] xd08494dce3b2b550;

	private RectangleF x930e7264e89b1eb5;

	private xb8e7e788f6d59708 x9b1777152cf410e1;

	private x1ae70714edec817d x6c4b7a83d68ade87;

	private x03d68de1c2f74051 x6c69349c3fcd27a0;

	internal x03d68de1c2f74051 x7d93fe77a9fa1cbb
	{
		get
		{
			if (x6c69349c3fcd27a0 == null)
			{
				x145308e3a1daefc7();
			}
			return x6c69349c3fcd27a0;
		}
	}

	internal xb8e7e788f6d59708 x83dd92921f575263
	{
		get
		{
			xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xa7b580afa8756d69(x7d93fe77a9fa1cbb.xc8bd66f519a24321(), x7a848427f2a9a3b5: true);
			xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x23d6043fb9c177ec, 0.1f);
			xb8e7e788f6d.xd6b6ed77479ef68c(xab391c46ff9a0a);
			return xb8e7e788f6d;
		}
	}

	private xab391c46ff9a0a38[] xccf1ef7f15f14524 => (xab391c46ff9a0a38[])xd5126346e5101136.ToArray(typeof(xab391c46ff9a0a38));

	internal void x485706149e408fe2(xab391c46ff9a0a38 xe125219852864557)
	{
		if (xe125219852864557 == null)
		{
			throw new ArgumentNullException("path");
		}
		if (x8446e731d644fa6b != 0)
		{
			xd5126346e5101136.Clear();
			xd08494dce3b2b550 = null;
			x8446e731d644fa6b = xa3194ec78bd24615.x6a81a30bcaf20a97;
		}
		x9f280d9f6d9d4ccb(xe125219852864557);
	}

	internal void xa9557f69810d0afe(byte[] x43e181e083db6cdf, RectangleF xfe4205d5dd815113)
	{
		if (x43e181e083db6cdf == null)
		{
			throw new ArgumentNullException("imageBytes");
		}
		if (xfe4205d5dd815113.IsEmpty)
		{
			throw new ArgumentNullException("imageBounds");
		}
		x8446e731d644fa6b = xa3194ec78bd24615.xa460a0b649265441;
		xd08494dce3b2b550 = x43e181e083db6cdf;
		x930e7264e89b1eb5 = xfe4205d5dd815113;
	}

	internal void x15ad6dda8b6cdb4c(xab391c46ff9a0a38 xe125219852864557)
	{
		if (xe125219852864557 == null)
		{
			throw new ArgumentNullException("path");
		}
		if (x8446e731d644fa6b != xa3194ec78bd24615.x0e397c84d3b79406)
		{
			xd5126346e5101136.Clear();
			xd08494dce3b2b550 = null;
			x8446e731d644fa6b = xa3194ec78bd24615.x0e397c84d3b79406;
		}
		x9f280d9f6d9d4ccb(xe125219852864557);
	}

	internal void x9bc00449bdfc1e1e(xb8e7e788f6d59708 x08ce8f4769eb3234, RectangleF xda73fcb97c77d998)
	{
		if (x08ce8f4769eb3234 == null)
		{
			throw new ArgumentNullException("canvas");
		}
		xd5126346e5101136.Clear();
		xd08494dce3b2b550 = null;
		x8446e731d644fa6b = xa3194ec78bd24615.xa1eafe7821eb4aab;
		x9b1777152cf410e1 = x08ce8f4769eb3234;
		x930e7264e89b1eb5 = xda73fcb97c77d998;
	}

	private void x9f280d9f6d9d4ccb(xab391c46ff9a0a38 xe125219852864557)
	{
		xd5126346e5101136.Add(xe125219852864557);
	}

	private void x145308e3a1daefc7()
	{
		switch (x8446e731d644fa6b)
		{
		case xa3194ec78bd24615.x6a81a30bcaf20a97:
			xe56f5a729976a647();
			break;
		case xa3194ec78bd24615.xa460a0b649265441:
			x2fddd95d804996e4();
			break;
		case xa3194ec78bd24615.x0e397c84d3b79406:
			xe56f5a729976a647();
			break;
		case xa3194ec78bd24615.xa1eafe7821eb4aab:
			xe58843735bfedaa3();
			break;
		default:
			throw new ArgumentOutOfRangeException("WhatToWrap");
		}
		if (x6c4b7a83d68ade87 == null)
		{
			x6c4b7a83d68ade87 = new x1ae70714edec817d();
		}
		x6c69349c3fcd27a0 = xb48468b763132e39.x4a50984825eee908(x6c4b7a83d68ade87);
		if (xd08494dce3b2b550 == null)
		{
			x580b92f948528b31.x1cfcddd0e5e25d12(x6c69349c3fcd27a0);
		}
	}

	private void xe56f5a729976a647()
	{
		xab391c46ff9a0a38[] array = xccf1ef7f15f14524;
		foreach (xab391c46ff9a0a38 xe125219852864557 in array)
		{
			x03d68de1c2f74051 x03d68de1c2f74052 = x4550028bd6f6fe67.xa78bd34efc70ec90(xe125219852864557);
			if (x6c4b7a83d68ade87 == null)
			{
				x6c4b7a83d68ade87 = new x1ae70714edec817d(x03d68de1c2f74052);
			}
			else
			{
				x6c4b7a83d68ade87.x89d9fcfbcec41d3c(x03d68de1c2f74052);
			}
		}
	}

	private void x2fddd95d804996e4()
	{
		if (xd5126346e5101136.Count != 0)
		{
			xe56f5a729976a647();
			if (x6c4b7a83d68ade87 != null && x6c4b7a83d68ade87.xe9e87df45862c20a != 0)
			{
				return;
			}
		}
		x6c4b7a83d68ade87 = x225ce39bf4d3057e.xa78bd34efc70ec90(xd08494dce3b2b550, x930e7264e89b1eb5);
		if (x6c4b7a83d68ade87.xe9e87df45862c20a == 0)
		{
			xa6f263cf52e2036d();
		}
	}

	private void xa6f263cf52e2036d()
	{
		x6c4b7a83d68ade87 = new x1ae70714edec817d(new x03d68de1c2f74051(new PointF[4]
		{
			new PointF(x930e7264e89b1eb5.Left, x930e7264e89b1eb5.Top),
			new PointF(x930e7264e89b1eb5.Right, x930e7264e89b1eb5.Top),
			new PointF(x930e7264e89b1eb5.Right, x930e7264e89b1eb5.Bottom),
			new PointF(x930e7264e89b1eb5.Left, x930e7264e89b1eb5.Bottom)
		}));
	}

	private void xe58843735bfedaa3()
	{
		x6c4b7a83d68ade87 = x8d0dd4e94b25f99a.xa78bd34efc70ec90(x9b1777152cf410e1, x930e7264e89b1eb5);
	}
}
