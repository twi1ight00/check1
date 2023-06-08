using System;
using x24ed092a62874e86;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;

namespace x5f5ca2a37b849b4a;

internal class xbf07f5794fa0e774
{
	private static object[] x6d0723a95d578e81 = new object[8]
	{
		xd10a745aac5a6f24.xc11782291118647f,
		xd10a745aac5a6f24.xec5408e95de7509f,
		new x19119439284aead2[1] { x19119439284aead2.x7e35b9f3a95994e6 },
		new x19119439284aead2[1] { x19119439284aead2.xa00e6a1b059e8528 },
		new x19119439284aead2[1] { x19119439284aead2.x05f2f8a88d550fdf },
		new x19119439284aead2[1] { x19119439284aead2.xb8500fb2f6ef9b56 },
		new x19119439284aead2[1] { x19119439284aead2.x1df53383f0784cbf },
		new x19119439284aead2[1] { x19119439284aead2.x5a18ff363fcd7795 }
	};

	private static object[] xabc470aec8a08f91 = new object[8]
	{
		xd10a745aac5a6f24.xa1527092eb1097b5,
		xd10a745aac5a6f24.x5cb1727ad2857d30,
		null,
		null,
		null,
		null,
		null,
		null
	};

	private static int[] x6a5272e56c9b4019 = new int[6] { 0, 0, 2, 2, 0, 2 };

	private static int[] xe3ab436c20c9ec47;

	private static int[] x0992d720693c02e0;

	private static x7ff3ebf195aaeb3e[] x26fa026416221909;

	private static x75bc8036f6f7a02b[] x8d042aa4aa0c27a2;

	internal static x75bc8036f6f7a02b x0ec9f6d096a990f2(int x44ecfea61c937b8e)
	{
		xcf87e16df391b1f6(x44ecfea61c937b8e);
		int num = (x44ecfea61c937b8e - 1) / 8;
		x19119439284aead2[] colors = x67ffeaa77e8e430d(x44ecfea61c937b8e);
		xda4dde4038ab80db[] colorModifiers = x77d4d1430a326c52(x44ecfea61c937b8e);
		float num2 = (float)x4574ea26106f0edb.x0fb738636eebfc1e(x0992d720693c02e0[num]);
		return new x75bc8036f6f7a02b(0, colors, colorModifiers, num2);
	}

	internal static x6fef6ec0027687a4 xa87d0dcf016863b9(int x44ecfea61c937b8e, bool x5b428099b4c542f7)
	{
		xcf87e16df391b1f6(x44ecfea61c937b8e);
		int num = (x44ecfea61c937b8e - 1) / 8;
		int themedFill = (x5b428099b4c542f7 ? xe3ab436c20c9ec47[num] : x6a5272e56c9b4019[num]);
		x19119439284aead2[] colors = x67ffeaa77e8e430d(x44ecfea61c937b8e);
		xda4dde4038ab80db[] colorModifiers = x77d4d1430a326c52(x44ecfea61c937b8e);
		return new x6fef6ec0027687a4(themedFill, colors, colorModifiers);
	}

	internal static x75bc8036f6f7a02b xf36bb597030867d7(int x44ecfea61c937b8e)
	{
		xcf87e16df391b1f6(x44ecfea61c937b8e);
		int num = (x44ecfea61c937b8e - 1) / 8;
		x75bc8036f6f7a02b result = x8d042aa4aa0c27a2[num];
		switch (x44ecfea61c937b8e)
		{
		case 33:
			result = new x75bc8036f6f7a02b(0, x19119439284aead2.x34614caf8d0b54eb, xd10a745aac5a6f24.xf2e6c2727f793f33(50.0));
			break;
		case 34:
			result = new x75bc8036f6f7a02b(0, xd10a745aac5a6f24.x12df3c30ae96bfb1, xd10a745aac5a6f24.x4a0df79b9059e629);
			break;
		case 35:
			result = new x75bc8036f6f7a02b(0, x19119439284aead2.x7e35b9f3a95994e6, xd10a745aac5a6f24.xf2e6c2727f793f33(50.0));
			break;
		case 36:
			result = new x75bc8036f6f7a02b(0, x19119439284aead2.xa00e6a1b059e8528, xd10a745aac5a6f24.xf2e6c2727f793f33(50.0));
			break;
		case 37:
			result = new x75bc8036f6f7a02b(0, x19119439284aead2.x05f2f8a88d550fdf, xd10a745aac5a6f24.xf2e6c2727f793f33(50.0));
			break;
		case 38:
			result = new x75bc8036f6f7a02b(0, x19119439284aead2.xb8500fb2f6ef9b56, xd10a745aac5a6f24.xf2e6c2727f793f33(50.0));
			break;
		case 39:
			result = new x75bc8036f6f7a02b(0, x19119439284aead2.x1df53383f0784cbf, xd10a745aac5a6f24.xf2e6c2727f793f33(50.0));
			break;
		case 40:
			result = new x75bc8036f6f7a02b(0, x19119439284aead2.x5a18ff363fcd7795, xd10a745aac5a6f24.xf2e6c2727f793f33(50.0));
			break;
		}
		return result;
	}

	internal static x75bc8036f6f7a02b xbd2342b58438bbd5(int x44ecfea61c937b8e)
	{
		xcf87e16df391b1f6(x44ecfea61c937b8e);
		x19119439284aead2[] colors = x67ffeaa77e8e430d(x44ecfea61c937b8e);
		xda4dde4038ab80db[] colorModifiers = x77d4d1430a326c52(x44ecfea61c937b8e);
		return new x75bc8036f6f7a02b(0, colors, colorModifiers);
	}

	internal static x7ff3ebf195aaeb3e x1a64bd72918f4b0d(int x44ecfea61c937b8e)
	{
		xcf87e16df391b1f6(x44ecfea61c937b8e);
		int num = (x44ecfea61c937b8e - 1) / 8;
		return x26fa026416221909[num];
	}

	private static void xcf87e16df391b1f6(int x44ecfea61c937b8e)
	{
		if (x44ecfea61c937b8e < 1 || x44ecfea61c937b8e > 48)
		{
			throw new ArgumentException("Style value must be in range between 1 and 48 inclusively.");
		}
	}

	private static x19119439284aead2[] x67ffeaa77e8e430d(int x44ecfea61c937b8e)
	{
		int num = (x44ecfea61c937b8e - 1) % 8;
		x19119439284aead2[] result = (x19119439284aead2[])x6d0723a95d578e81[num];
		if (x44ecfea61c937b8e == 41)
		{
			result = xd10a745aac5a6f24.x93a0876c17392258;
		}
		return result;
	}

	private static xda4dde4038ab80db[] x77d4d1430a326c52(int x44ecfea61c937b8e)
	{
		int num = (x44ecfea61c937b8e - 1) % 8;
		xda4dde4038ab80db[] result = (xda4dde4038ab80db[])xabc470aec8a08f91[num];
		if (x44ecfea61c937b8e == 41)
		{
			result = xd10a745aac5a6f24.x29883890a6ee5bc1;
		}
		return result;
	}

	static xbf07f5794fa0e774()
	{
		int[] array = new int[6];
		xe3ab436c20c9ec47 = array;
		x0992d720693c02e0 = new int[6] { 3, 5, 5, 7, 5, 5 };
		x26fa026416221909 = new x7ff3ebf195aaeb3e[6]
		{
			null,
			new x7ff3ebf195aaeb3e(0, x19119439284aead2.x34614caf8d0b54eb, null),
			new x7ff3ebf195aaeb3e(1, x19119439284aead2.x34614caf8d0b54eb, null),
			new x7ff3ebf195aaeb3e(2, x19119439284aead2.x34614caf8d0b54eb, null),
			null,
			new x7ff3ebf195aaeb3e(2, x19119439284aead2.x34614caf8d0b54eb, null)
		};
		x8d042aa4aa0c27a2 = new x75bc8036f6f7a02b[6]
		{
			null,
			new x75bc8036f6f7a02b(0, x19119439284aead2.xbc991998f16b5de4, null),
			null,
			null,
			null,
			null
		};
	}
}
