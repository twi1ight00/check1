using System.Drawing;
using x1c8faa688b1f0b0c;
using x32a884d842a34446;
using xad5c68c1ad3b0224;

namespace xb3013071794e5415;

internal class x6d22cf1ff5170ee8
{
	private xd4e66257276c6905 xa0db25b371643a4d;

	private xcd7d6e7318ee6574 x8cedcaa9a62c6e39;

	private xba4e61c28aac852c xa0c673ee50c952aa;

	private xc48e9faacc88a3d5 x541143294f4d8c9e;

	private x6f0dc7da3e6e3517 x096bf42c8d1339c4;

	private float x933fbdb4e4f6c448;

	private float xed5d42e5ec2e2a9e;

	private float x51556d800a83de54;

	private float xc8ff13cb9454e1a9;

	private float x8e520e9e621f413c => x8cedcaa9a62c6e39.x43e348908d6e68da.Width - (x933fbdb4e4f6c448 + xed5d42e5ec2e2a9e);

	private float x643719bbfb1aaffd => x8cedcaa9a62c6e39.x43e348908d6e68da.Height - (x51556d800a83de54 + xc8ff13cb9454e1a9);

	private x6d22cf1ff5170ee8(xd4e66257276c6905 chartSpace, xcd7d6e7318ee6574 context)
	{
		xa0db25b371643a4d = chartSpace;
		x8cedcaa9a62c6e39 = context;
	}

	internal static x4fdf549af9de6b97 xe406325e56f74b46(xd4e66257276c6905 x02726bba19c4d190, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x6d22cf1ff5170ee8 x6d22cf1ff5170ee9 = new x6d22cf1ff5170ee8(x02726bba19c4d190, x0f7b23d1c393aed9);
		x6d22cf1ff5170ee9.xe406325e56f74b46();
		return x0f7b23d1c393aed9.xc9443bca5b0a56d8;
	}

	private void xe406325e56f74b46()
	{
		x77286633e414c8fe();
		x5f4110dcb07fa3ed();
		x096bf42c8d1339c4.xe406325e56f74b46();
		x541143294f4d8c9e.xe406325e56f74b46();
		xa0c673ee50c952aa.xe406325e56f74b46();
		x2d245b453d3aefde();
	}

	private void x5f4110dcb07fa3ed()
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x09b60730e59f1f3a());
		x8cedcaa9a62c6e39.x490834a62c46f14d(xb8e7e788f6d);
		x3b57b69ffdd5e76d();
		xa0c673ee50c952aa = x8adc8548b06487d4();
		x541143294f4d8c9e = x29e10d570eb15eb8();
		x096bf42c8d1339c4 = new x6f0dc7da3e6e3517(xa0db25b371643a4d.x317eef27d88d4cf9.x665038dfa8849161, x8cedcaa9a62c6e39, x09b60730e59f1f3a());
	}

	private void x2d245b453d3aefde()
	{
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
	}

	private xba4e61c28aac852c x8adc8548b06487d4()
	{
		xba4e61c28aac852c xba4e61c28aac852c2 = new xba4e61c28aac852c(xa0db25b371643a4d, x8cedcaa9a62c6e39, x09b60730e59f1f3a());
		if (!xba4e61c28aac852c2.x3f5e31045e967a38 && xba4e61c28aac852c2.xb0f146032f47c24e > 0f)
		{
			x51556d800a83de54 += xba4e61c28aac852c2.xb0f146032f47c24e + x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
		}
		return xba4e61c28aac852c2;
	}

	private xc48e9faacc88a3d5 x29e10d570eb15eb8()
	{
		xc48e9faacc88a3d5 xc48e9faacc88a3d6 = new xc48e9faacc88a3d5(xa0db25b371643a4d, x8cedcaa9a62c6e39, x09b60730e59f1f3a());
		if (!xc48e9faacc88a3d6.x3f5e31045e967a38)
		{
			switch (xc48e9faacc88a3d6.xbe1e23e7d5b43370)
			{
			case xe52a139d93fd6397.x9bcb07e204e30218:
				xc8ff13cb9454e1a9 += xc48e9faacc88a3d6.xb0f146032f47c24e + x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
				break;
			case xe52a139d93fd6397.xe360b1885d8d4a41:
				x51556d800a83de54 += xc48e9faacc88a3d6.xb0f146032f47c24e + x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
				break;
			case xe52a139d93fd6397.x72d92bd1aff02e37:
				x933fbdb4e4f6c448 += xc48e9faacc88a3d6.xdc1bf80853046136 + x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
				break;
			case xe52a139d93fd6397.x419ba17a5322627b:
			case xe52a139d93fd6397.x46c964a11610fa46:
				xed5d42e5ec2e2a9e += xc48e9faacc88a3d6.xdc1bf80853046136 + x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
				break;
			}
		}
		return xc48e9faacc88a3d6;
	}

	private void x77286633e414c8fe()
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x09b60730e59f1f3a());
		x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, xa0db25b371643a4d.xff13b489d81606b6, x8cedcaa9a62c6e39.x5e969e12ada2aab2.x4daa252cdbc8fd0f, 0);
		x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xab391c46ff9a0a);
	}

	private RectangleF x09b60730e59f1f3a()
	{
		return new RectangleF(x933fbdb4e4f6c448, x51556d800a83de54, x8e520e9e621f413c, x643719bbfb1aaffd);
	}

	private void x3b57b69ffdd5e76d()
	{
		x933fbdb4e4f6c448 += x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
		x51556d800a83de54 += x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
		xed5d42e5ec2e2a9e += x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
		xc8ff13cb9454e1a9 += x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
	}
}
