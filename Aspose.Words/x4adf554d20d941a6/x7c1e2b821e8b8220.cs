using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x7c1e2b821e8b8220 : xc1e43d6be7c1713c
{
	private int x52d613e82f2f0170 = int.MinValue;

	private int x0f0abc56c6504ea3 = int.MinValue;

	private int[] x988a729185cf247d;

	private x9b06ad624eb7857a x52dc5d70a8f6b1d2;

	private int x975a9f4c5dd352ef = -1;

	private int xb5ded08ff8ff9e7d = int.MinValue;

	private Point x7e0ea7eb286876e3 = new Point(int.MinValue, int.MinValue);

	private int x3ca7aa4a3ab5aab8 = int.MinValue;

	internal override x5a5e07e9fa12451a x5a5e07e9fa12451a => x5a5e07e9fa12451a.x25af49e7b49ea0bc;

	internal x8f0e2f0364ae18aa xeb54885ba753f70e => (x8f0e2f0364ae18aa)base.x705ed5f9769744e5;

	internal override xcf9d359063aa93f2 x705ed5f9769744e5
	{
		set
		{
			base.x705ed5f9769744e5 = value;
			x89d8cf71874cebb8(this);
		}
	}

	internal override x398b3bd0acd94b61 x8b8a0a04b3aeaf3a
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal override x398b3bd0acd94b61 x7e2e5dd40daabc3b
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal x387d31b7e6ea1182 x5d6d04c35215bc51 => (x387d31b7e6ea1182)base.xa51d8d9790431b2b;

	internal x387d31b7e6ea1182 xbc3a1ad7f75a88f9 => (x387d31b7e6ea1182)base.x88fee64dba8223f9;

	internal int x1fb2a875e6411ef2
	{
		get
		{
			if (int.MinValue == x52d613e82f2f0170)
			{
				x459cc216f860f01f();
			}
			return x52d613e82f2f0170;
		}
	}

	internal int x1e5325ab72cf7ec9
	{
		get
		{
			if (int.MinValue == x0f0abc56c6504ea3)
			{
				x459cc216f860f01f();
			}
			return x0f0abc56c6504ea3;
		}
		set
		{
			x0f0abc56c6504ea3 = value;
		}
	}

	internal int[] x03bb6a33fcd217b4
	{
		get
		{
			if (x988a729185cf247d == null)
			{
				int num = x10da90eb9c780c82.x78bc24b1832f704d(this);
				if (num == xeb54885ba753f70e.x6e1eb96b81362ebc)
				{
					int num2 = xeb54885ba753f70e.x78427d61ba29da6a.Length;
					for (int i = 0; i < num2; i++)
					{
						int num3 = xeb54885ba753f70e.x78427d61ba29da6a[i];
						if ((float)num3 <= 0f)
						{
							num = 0;
							break;
						}
					}
					if (0 < num)
					{
						x988a729185cf247d = xeb54885ba753f70e.x78427d61ba29da6a;
					}
				}
				if (x988a729185cf247d == null)
				{
					x4e95fc502249468d.x30f8cb8a953e9256();
					x988a729185cf247d = new int[x4e95fc502249468d.x6e1eb96b81362ebc];
					for (int j = 0; j < x988a729185cf247d.Length; j++)
					{
						int val = x4574ea26106f0edb.x370502bb60141209(x4e95fc502249468d.xcda9277b4d19fd44(j).xdc1bf80853046136);
						x988a729185cf247d[j] = Math.Max(0, val);
					}
					x52dc5d70a8f6b1d2 = null;
				}
			}
			return x988a729185cf247d;
		}
		set
		{
			x988a729185cf247d = value;
		}
	}

	internal bool x752cfab9af626fd5 => base.x332a8eedb847940d.x5a5e07e9fa12451a == x5a5e07e9fa12451a.x11db8fc7f469a2fc;

	internal int x46557be7fe69f982
	{
		get
		{
			if (xb5ded08ff8ff9e7d == int.MinValue)
			{
				xb5ded08ff8ff9e7d = 0;
				if (x752cfab9af626fd5)
				{
					return xb5ded08ff8ff9e7d;
				}
				x387d31b7e6ea1182 xebb8ac1152da9a1f = x5d6d04c35215bc51;
				while (xebb8ac1152da9a1f != null && xebb8ac1152da9a1f.x768f9befb545345a.x0f709e8a26f5dccd)
				{
					xb5ded08ff8ff9e7d += xebb8ac1152da9a1f.x8b8a0a04b3aeaf3a.x319720dedc082a9d;
					xebb8ac1152da9a1f = xebb8ac1152da9a1f.xebb8ac1152da9a1f;
				}
			}
			return xb5ded08ff8ff9e7d;
		}
		set
		{
			xb5ded08ff8ff9e7d = value;
		}
	}

	internal x387d31b7e6ea1182 x51cc93a2c68d0be0
	{
		get
		{
			x387d31b7e6ea1182 result = null;
			x387d31b7e6ea1182 xebb8ac1152da9a1f = x5d6d04c35215bc51;
			while (xebb8ac1152da9a1f != null && xebb8ac1152da9a1f.x768f9befb545345a.x0f709e8a26f5dccd)
			{
				result = xebb8ac1152da9a1f;
				xebb8ac1152da9a1f = xebb8ac1152da9a1f.xebb8ac1152da9a1f;
			}
			return result;
		}
	}

	internal bool x3a7473f820dd300b => xeb54885ba753f70e.x3a7473f820dd300b;

	internal int x636fbcec18dfb6c9
	{
		get
		{
			return x3ca7aa4a3ab5aab8;
		}
		set
		{
			x3ca7aa4a3ab5aab8 = value;
		}
	}

	private x9b06ad624eb7857a x4e95fc502249468d
	{
		get
		{
			if (x52dc5d70a8f6b1d2 == null)
			{
				x52dc5d70a8f6b1d2 = new x9b06ad624eb7857a(this);
			}
			return x52dc5d70a8f6b1d2;
		}
	}

	internal override x1073233de8252b3e x8db1e90bce56e416(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		return base.x332a8eedb847940d.x8db1e90bce56e416(xd7e5673853e47af4);
	}

	internal override xc63cc34daaa2e2d9 x8b61531c8ea35b85()
	{
		x7c1e2b821e8b8220 x7c1e2b821e8b8221 = new x7c1e2b821e8b8220();
		x7c1e2b821e8b8221.x705ed5f9769744e5 = x705ed5f9769744e5;
		return x7c1e2b821e8b8221;
	}

	internal override void x1914eddf1fde1228(xc1e43d6be7c1713c x2612f62f94df47de)
	{
		if (x2612f62f94df47de == null)
		{
			x2612f62f94df47de = (xc1e43d6be7c1713c)base.x332a8eedb847940d.xbc13914359462815;
		}
		IList list = xae38dac157c088d7(null, null);
		for (int num = list.Count - 1; num >= 0; num--)
		{
			((x398b3bd0acd94b61)list[num]).xc255c495fd9232ca.x844530889595db77((x398b3bd0acd94b61)list[num], x7e9711ec413a6aba: true);
		}
		x7c1e2b821e8b8220 x2612f62f94df47de2 = (x7c1e2b821e8b8220)x8b61531c8ea35b85();
		x2612f62f94df47de.x45a34609c70da3e5(null, x2612f62f94df47de.xa51d8d9790431b2b, x2612f62f94df47de2);
		IList list2 = x3616d1988aadef8a(null, null);
		for (int num2 = list2.Count - 1; num2 >= 0; num2--)
		{
			((xc63cc34daaa2e2d9)list2[num2]).x1914eddf1fde1228(x2612f62f94df47de2);
		}
	}

	internal override void xcac6ac9df12a8893(xc1e43d6be7c1713c x2612f62f94df47de)
	{
		if (x2612f62f94df47de == null)
		{
			x2612f62f94df47de = (xc1e43d6be7c1713c)base.x332a8eedb847940d.x3e8d56eefc6dfdad;
		}
		x7c1e2b821e8b8220 x2612f62f94df47de2 = (x7c1e2b821e8b8220)x8b61531c8ea35b85();
		x2612f62f94df47de.x45a34609c70da3e5(x2612f62f94df47de.x88fee64dba8223f9, null, x2612f62f94df47de2);
		IList list = x3616d1988aadef8a(null, null);
		for (int i = 0; i < list.Count; i++)
		{
			((xc63cc34daaa2e2d9)list[i]).xcac6ac9df12a8893(x2612f62f94df47de2);
		}
	}

	internal override void x45a34609c70da3e5(xc63cc34daaa2e2d9 xd9ff4dee1dba180e, xc63cc34daaa2e2d9 xcc36986f44d69e8f, xc63cc34daaa2e2d9 x2612f62f94df47de)
	{
		x89d8cf71874cebb8(this);
		base.x45a34609c70da3e5(xd9ff4dee1dba180e, xcc36986f44d69e8f, x2612f62f94df47de);
	}

	internal override void x9966dca653a8c1b8(xc63cc34daaa2e2d9 x2612f62f94df47de)
	{
		x89d8cf71874cebb8(this);
		base.x9966dca653a8c1b8(x2612f62f94df47de);
	}

	internal override void xbd829faf77014ec7()
	{
		for (x387d31b7e6ea1182 xebb8ac1152da9a1f = x5d6d04c35215bc51; xebb8ac1152da9a1f != null; xebb8ac1152da9a1f = xebb8ac1152da9a1f.xebb8ac1152da9a1f)
		{
			xebb8ac1152da9a1f.xbd829faf77014ec7();
		}
	}

	internal override void xbee71552c60a47bd()
	{
		for (x387d31b7e6ea1182 xebb8ac1152da9a1f = x5d6d04c35215bc51; xebb8ac1152da9a1f != null; xebb8ac1152da9a1f = xebb8ac1152da9a1f.xebb8ac1152da9a1f)
		{
			xebb8ac1152da9a1f.xbee71552c60a47bd();
		}
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x79e6137ece11bd71(this);
	}

	internal override void xae7aaadc88b9a9f5(object xe0292b9ed559da7d, x9352d7e557b05f9e xfbf34718e704c6bc)
	{
		if (base.x332a8eedb847940d == null)
		{
			return;
		}
		x6fc22eab217fbfe8 x6fc22eab217fbfe9 = xfbf34718e704c6bc.x6082c9a47d8ce041;
		if (x6fc22eab217fbfe9 == x6fc22eab217fbfe8.x5572f47ce7012372 && xbd59d8ebf66427d6())
		{
			if (x5a5e07e9fa12451a.x11db8fc7f469a2fc == base.x332a8eedb847940d.x5a5e07e9fa12451a)
			{
				((x56b4eac69b5fa65b)base.x332a8eedb847940d).xe415ab19cab4a395();
				x7c1e2b821e8b8220 x7c1e2b821e8b8221 = (x7c1e2b821e8b8220)base.x332a8eedb847940d.x332a8eedb847940d.x332a8eedb847940d;
				if (x7c1e2b821e8b8221.xeb54885ba753f70e.xc61c6fcfb0c6e3c3)
				{
					x0680d4cf02fbe4e3(this, new x9352d7e557b05f9e(x7c1e2b821e8b8221, x6fc22eab217fbfe8.x5572f47ce7012372, x975a9f4c5dd352ef, null));
				}
				else
				{
					x6fc22eab217fbfe9 = x6fc22eab217fbfe8.x0a1be80c019129ed;
				}
			}
			else
			{
				x6fc22eab217fbfe9 = x6fc22eab217fbfe8.x0a1be80c019129ed;
			}
		}
		if (x6fc22eab217fbfe9 != x6fc22eab217fbfe8.x5572f47ce7012372 && x6fc22eab217fbfe9 != x6fc22eab217fbfe8.x0a1be80c019129ed)
		{
			return;
		}
		x03bb6a33fcd217b4 = null;
		for (x387d31b7e6ea1182 xebb8ac1152da9a1f = x5d6d04c35215bc51; xebb8ac1152da9a1f != null; xebb8ac1152da9a1f = xebb8ac1152da9a1f.xebb8ac1152da9a1f)
		{
			for (x56b4eac69b5fa65b x56b4eac69b5fa65b2 = xebb8ac1152da9a1f.x96ac59f61797f5b9; x56b4eac69b5fa65b2 != null; x56b4eac69b5fa65b2 = x56b4eac69b5fa65b2.xb2e852052ab1c1be)
			{
				x56b4eac69b5fa65b2.xdc1bf80853046136 = int.MinValue;
				for (xc63cc34daaa2e2d9 xc63cc34daaa2e2d10 = x56b4eac69b5fa65b2.xa51d8d9790431b2b; xc63cc34daaa2e2d10 != null; xc63cc34daaa2e2d10 = xc63cc34daaa2e2d10.xbc13914359462815)
				{
					if (x5a5e07e9fa12451a.x25af49e7b49ea0bc == xc63cc34daaa2e2d10.x5a5e07e9fa12451a)
					{
						x0680d4cf02fbe4e3(this, new x9352d7e557b05f9e(xc63cc34daaa2e2d10, x6fc22eab217fbfe8.x0a1be80c019129ed, x975a9f4c5dd352ef, null));
					}
					else if (x5a5e07e9fa12451a.xfdc1a17f479acc42 == xc63cc34daaa2e2d10.x5a5e07e9fa12451a)
					{
						xbba4ca0462c7486f.x4ebe1a5cd48cf864(xc63cc34daaa2e2d10);
					}
				}
			}
		}
	}

	internal xb8e7e788f6d59708 x68864d8ae2380262(PointF xb9c2cfae130d9256)
	{
		if (x752cfab9af626fd5)
		{
			return null;
		}
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		x387d31b7e6ea1182 xebb8ac1152da9a1f = x5d6d04c35215bc51;
		while (xebb8ac1152da9a1f != null && xebb8ac1152da9a1f.x768f9befb545345a.x0f709e8a26f5dccd)
		{
			xb8e7e788f6d59708 xda5bf54deb817e = (xb8e7e788f6d59708)xebb8ac1152da9a1f.x8b8a0a04b3aeaf3a.x2d6658ad60c6ebe9;
			xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e);
			xebb8ac1152da9a1f = xebb8ac1152da9a1f.xebb8ac1152da9a1f;
		}
		xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
		xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf(xb9c2cfae130d9256.X, xb9c2cfae130d9256.Y, MatrixOrder.Append);
		x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)x5d6d04c35215bc51.x8b8a0a04b3aeaf3a;
		Point xf671230c49fb86ad = new Point(x694f001896973fe4.xc255c495fd9232ca.x5c392d6ad6fe7e28 - x694f001896973fe4.x8df91a2f90079e88, x694f001896973fe4.xc255c495fd9232ca.x3dcafc2d758260e1 - x694f001896973fe4.xc821290d7ecc08bf);
		PointF pointF = x4574ea26106f0edb.xc96d70553223ee04(xf671230c49fb86ad);
		xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf(pointF.X, pointF.Y, MatrixOrder.Append);
		RectangleF x26545669838eb36e = x4574ea26106f0edb.xc96d70553223ee04(x3557aa8566455ba9.x357582c772cd02ee(x5d6d04c35215bc51.x5d6d04c35215bc51, -xf671230c49fb86ad.Y, x46557be7fe69f982));
		x26545669838eb36e.Offset(0f - pointF.X, 0f);
		xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
		return xb8e7e788f6d;
	}

	internal void x89d8cf71874cebb8(object x9ca7766fefee11a1)
	{
		if (xeb54885ba753f70e != null && (x9ca7766fefee11a1 == this || xeb54885ba753f70e.xc61c6fcfb0c6e3c3))
		{
			xac6c82c74ce247fb xac6c82c74ce247fb2 = x53111d6596d16a99;
			if (xac6c82c74ce247fb2 != null && x975a9f4c5dd352ef != xac6c82c74ce247fb2.xe5a6c1d25602b220)
			{
				x975a9f4c5dd352ef = xac6c82c74ce247fb2.xe5a6c1d25602b220;
				x0680d4cf02fbe4e3(this, new x9352d7e557b05f9e(this, x6fc22eab217fbfe8.x5572f47ce7012372, x975a9f4c5dd352ef, null));
			}
		}
	}

	internal Point x588d7683a6d1fbd5()
	{
		if (x7e0ea7eb286876e3.X != int.MinValue)
		{
			return x7e0ea7eb286876e3;
		}
		throw new NotImplementedException();
	}

	private void x459cc216f860f01f()
	{
		x4e95fc502249468d.x6073b6af1e685b60();
		x52d613e82f2f0170 = x4e95fc502249468d.x1fb2a875e6411ef2;
		x0f0abc56c6504ea3 = x4e95fc502249468d.x1e5325ab72cf7ec9;
	}

	private bool xbd59d8ebf66427d6()
	{
		if (int.MinValue == x52d613e82f2f0170 || int.MinValue == x0f0abc56c6504ea3)
		{
			return true;
		}
		int num = x52d613e82f2f0170;
		int num2 = x0f0abc56c6504ea3;
		x52dc5d70a8f6b1d2 = null;
		x52d613e82f2f0170 = int.MinValue;
		x0f0abc56c6504ea3 = int.MinValue;
		if (num == x1fb2a875e6411ef2)
		{
			return num2 != x1e5325ab72cf7ec9;
		}
		return true;
	}
}
