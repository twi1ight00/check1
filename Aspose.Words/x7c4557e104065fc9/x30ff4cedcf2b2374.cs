using Aspose.Words;
using x2697283ff424107e;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x7c4557e104065fc9;

internal class x30ff4cedcf2b2374
{
	private class x0601c2253b787fe2
	{
		internal object x72d92bd1aff02e37;

		internal object x419ba17a5322627b;

		internal object xe360b1885d8d4a41;

		internal object x9bcb07e204e30218;
	}

	private enum xc5def7c8896d0ae3
	{
		x72d92bd1aff02e37,
		x419ba17a5322627b,
		xe360b1885d8d4a41,
		x9bcb07e204e30218,
		x95c57ee794bc0aec
	}

	private static readonly string[] x9045044e9a819e2d = new string[4] { "border-bottom-style", "border-left-style", "border-right-style", "border-top-style" };

	private static readonly string[] xa314aba0a0ac7778 = new string[4] { "border-bottom-width", "border-left-width", "border-right-width", "border-top-width" };

	private static readonly string[] x62064f31d8f70991 = new string[4] { "border-bottom-color", "border-left-color", "border-right-color", "border-top-color" };

	private static readonly string[] x7354db491da2a385 = new string[4] { "padding-bottom", "padding-left", "padding-right", "padding-top" };

	private x30ff4cedcf2b2374()
	{
	}

	internal static void x1227cb7b82063569(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, BorderCollection x241924dcc793876e)
	{
		x871804a2ef508d3f(x44ecfea61c937b8e, x241924dcc793876e.Left, x241924dcc793876e.Right, x241924dcc793876e.Top, x241924dcc793876e.Bottom);
		x6f1c9961f9c83c67(x241924dcc793876e);
	}

	internal static void xc97a923bf27b32e0(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, Border x14cf9593b86ecbaa)
	{
		x871804a2ef508d3f(x44ecfea61c937b8e, x14cf9593b86ecbaa, null, null, null);
		x6f1c9961f9c83c67(x14cf9593b86ecbaa);
	}

	private static void x871804a2ef508d3f(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, Border xa447fc54e41dfe06, Border xfc2074a859a5db8c, Border xc941868c59399d3e, Border xaf9a0436a70689de)
	{
		x0601c2253b787fe2 x0601c2253b787fe = new x0601c2253b787fe2();
		for (int i = 0; i < x44ecfea61c937b8e.xd44988f225497f3a; i++)
		{
			string x77c5b4b560d5d2e = x44ecfea61c937b8e.xf15263674eb297bb(i);
			xedac08b4826d3056 xf9eaf76facf8149b = x44ecfea61c937b8e.get_xe6d4b1b411ed94b5(i);
			xbb2a19c10a8677f0(x77c5b4b560d5d2e, xf9eaf76facf8149b, xa447fc54e41dfe06, xfc2074a859a5db8c, xc941868c59399d3e, xaf9a0436a70689de, x0601c2253b787fe);
		}
		if (xa447fc54e41dfe06 != null && x0601c2253b787fe.x72d92bd1aff02e37 != null)
		{
			xa447fc54e41dfe06.LineStyle = (LineStyle)x0601c2253b787fe.x72d92bd1aff02e37;
		}
		if (xfc2074a859a5db8c != null && x0601c2253b787fe.x419ba17a5322627b != null)
		{
			xfc2074a859a5db8c.LineStyle = (LineStyle)x0601c2253b787fe.x419ba17a5322627b;
		}
		if (xc941868c59399d3e != null && x0601c2253b787fe.xe360b1885d8d4a41 != null)
		{
			xc941868c59399d3e.LineStyle = (LineStyle)x0601c2253b787fe.xe360b1885d8d4a41;
		}
		if (xaf9a0436a70689de != null && x0601c2253b787fe.x9bcb07e204e30218 != null)
		{
			xaf9a0436a70689de.LineStyle = (LineStyle)x0601c2253b787fe.x9bcb07e204e30218;
		}
	}

	private static void xbb2a19c10a8677f0(string x77c5b4b560d5d2e5, xedac08b4826d3056 xf9eaf76facf8149b, Border xa447fc54e41dfe06, Border xfc2074a859a5db8c, Border xc941868c59399d3e, Border xaf9a0436a70689de, x0601c2253b787fe2 xdbd074d37c686bcc)
	{
		switch (x77c5b4b560d5d2e5)
		{
		case "border":
			x751b5c6dc423c06b(xf9eaf76facf8149b, xa447fc54e41dfe06, xfc2074a859a5db8c, xc941868c59399d3e, xaf9a0436a70689de, xdbd074d37c686bcc);
			break;
		case "border-style":
			x1da048cec876a9a7(xf9eaf76facf8149b, xc5def7c8896d0ae3.x95c57ee794bc0aec, xdbd074d37c686bcc);
			break;
		case "border-width":
			x45578bf953f6063b(xf9eaf76facf8149b, xa447fc54e41dfe06, xfc2074a859a5db8c, xc941868c59399d3e, xaf9a0436a70689de);
			break;
		case "border-color":
			x10b6e21504c2bcf0(xf9eaf76facf8149b, xa447fc54e41dfe06, xfc2074a859a5db8c, xc941868c59399d3e, xaf9a0436a70689de);
			break;
		case "border-left":
			x751b5c6dc423c06b(xf9eaf76facf8149b, xa447fc54e41dfe06, null, null, null, xdbd074d37c686bcc);
			break;
		case "border-right":
			x751b5c6dc423c06b(xf9eaf76facf8149b, null, xfc2074a859a5db8c, null, null, xdbd074d37c686bcc);
			break;
		case "border-top":
			x751b5c6dc423c06b(xf9eaf76facf8149b, null, null, xc941868c59399d3e, null, xdbd074d37c686bcc);
			break;
		case "border-bottom":
			x751b5c6dc423c06b(xf9eaf76facf8149b, null, null, null, xaf9a0436a70689de, xdbd074d37c686bcc);
			break;
		case "border-left-style":
			x1da048cec876a9a7(xf9eaf76facf8149b, xc5def7c8896d0ae3.x72d92bd1aff02e37, xdbd074d37c686bcc);
			break;
		case "border-left-width":
			x45578bf953f6063b(xf9eaf76facf8149b, xa447fc54e41dfe06, null, null, null);
			break;
		case "border-left-color":
			x10b6e21504c2bcf0(xf9eaf76facf8149b, xa447fc54e41dfe06, null, null, null);
			break;
		case "border-right-style":
			x1da048cec876a9a7(xf9eaf76facf8149b, xc5def7c8896d0ae3.x419ba17a5322627b, xdbd074d37c686bcc);
			break;
		case "border-right-width":
			x45578bf953f6063b(xf9eaf76facf8149b, null, xfc2074a859a5db8c, null, null);
			break;
		case "border-right-color":
			x10b6e21504c2bcf0(xf9eaf76facf8149b, null, xfc2074a859a5db8c, null, null);
			break;
		case "border-top-style":
			x1da048cec876a9a7(xf9eaf76facf8149b, xc5def7c8896d0ae3.xe360b1885d8d4a41, xdbd074d37c686bcc);
			break;
		case "border-top-width":
			x45578bf953f6063b(xf9eaf76facf8149b, null, null, xc941868c59399d3e, null);
			break;
		case "border-top-color":
			x10b6e21504c2bcf0(xf9eaf76facf8149b, null, null, xc941868c59399d3e, null);
			break;
		case "border-bottom-style":
			x1da048cec876a9a7(xf9eaf76facf8149b, xc5def7c8896d0ae3.x9bcb07e204e30218, xdbd074d37c686bcc);
			break;
		case "border-bottom-width":
			x45578bf953f6063b(xf9eaf76facf8149b, null, null, null, xaf9a0436a70689de);
			break;
		case "border-bottom-color":
			x10b6e21504c2bcf0(xf9eaf76facf8149b, null, null, null, xaf9a0436a70689de);
			break;
		}
	}

	private static void x751b5c6dc423c06b(xedac08b4826d3056 xf9eaf76facf8149b, Border xa447fc54e41dfe06, Border xfc2074a859a5db8c, Border xc941868c59399d3e, Border xaf9a0436a70689de, x0601c2253b787fe2 xdbd074d37c686bcc)
	{
		x1e40528755c1f053 x73cad9ab753bf0fa = xf9eaf76facf8149b.x73cad9ab753bf0fa;
		if (x73cad9ab753bf0fa == x1e40528755c1f053.xf8569aac1192e1a0)
		{
			x0a4437fb7b6e1adb x0a4437fb7b6e1adb = xf9eaf76facf8149b.xae38dac157c088d7();
			{
				foreach (xedac08b4826d3056 item in x0a4437fb7b6e1adb)
				{
					x751b5c6dc423c06b(item, xa447fc54e41dfe06, xfc2074a859a5db8c, xc941868c59399d3e, xaf9a0436a70689de, xdbd074d37c686bcc);
				}
				return;
			}
		}
		if (!x1da048cec876a9a7(xf9eaf76facf8149b, xc5def7c8896d0ae3.x95c57ee794bc0aec, xdbd074d37c686bcc) && !x45578bf953f6063b(xf9eaf76facf8149b, xa447fc54e41dfe06, xfc2074a859a5db8c, xc941868c59399d3e, xaf9a0436a70689de))
		{
			x10b6e21504c2bcf0(xf9eaf76facf8149b, xa447fc54e41dfe06, xfc2074a859a5db8c, xc941868c59399d3e, xaf9a0436a70689de);
		}
	}

	private static bool x1da048cec876a9a7(xedac08b4826d3056 xf9eaf76facf8149b, xc5def7c8896d0ae3 x93688eca9a5db2fc, x0601c2253b787fe2 xdbd074d37c686bcc)
	{
		if (xf9eaf76facf8149b.x73cad9ab753bf0fa == x1e40528755c1f053.xf8569aac1192e1a0)
		{
			x60b7a505461a80e7 x60b7a505461a80e = new x60b7a505461a80e7(xf9eaf76facf8149b);
			x1da048cec876a9a7(x60b7a505461a80e.x72d92bd1aff02e37, xc5def7c8896d0ae3.x72d92bd1aff02e37, xdbd074d37c686bcc);
			x1da048cec876a9a7(x60b7a505461a80e.x419ba17a5322627b, xc5def7c8896d0ae3.x419ba17a5322627b, xdbd074d37c686bcc);
			x1da048cec876a9a7(x60b7a505461a80e.xe360b1885d8d4a41, xc5def7c8896d0ae3.xe360b1885d8d4a41, xdbd074d37c686bcc);
			x1da048cec876a9a7(x60b7a505461a80e.x9bcb07e204e30218, xc5def7c8896d0ae3.x9bcb07e204e30218, xdbd074d37c686bcc);
			return true;
		}
		LineStyle x26516bbd7ae;
		bool flag = x95d2d310d439ac44(xf9eaf76facf8149b.x48112399d54b30c7(), out x26516bbd7ae);
		switch (x93688eca9a5db2fc)
		{
		case xc5def7c8896d0ae3.x72d92bd1aff02e37:
			if (flag)
			{
				xdbd074d37c686bcc.x72d92bd1aff02e37 = x26516bbd7ae;
			}
			else if (xdbd074d37c686bcc.x72d92bd1aff02e37 == null)
			{
				xdbd074d37c686bcc.x72d92bd1aff02e37 = LineStyle.None;
			}
			break;
		case xc5def7c8896d0ae3.x419ba17a5322627b:
			if (flag)
			{
				xdbd074d37c686bcc.x419ba17a5322627b = x26516bbd7ae;
			}
			else if (xdbd074d37c686bcc.x419ba17a5322627b == null)
			{
				xdbd074d37c686bcc.x419ba17a5322627b = LineStyle.None;
			}
			break;
		case xc5def7c8896d0ae3.xe360b1885d8d4a41:
			if (flag)
			{
				xdbd074d37c686bcc.xe360b1885d8d4a41 = x26516bbd7ae;
			}
			else if (xdbd074d37c686bcc.xe360b1885d8d4a41 == null)
			{
				xdbd074d37c686bcc.xe360b1885d8d4a41 = LineStyle.None;
			}
			break;
		case xc5def7c8896d0ae3.x9bcb07e204e30218:
			if (flag)
			{
				xdbd074d37c686bcc.x9bcb07e204e30218 = x26516bbd7ae;
			}
			else if (xdbd074d37c686bcc.x9bcb07e204e30218 == null)
			{
				xdbd074d37c686bcc.x9bcb07e204e30218 = LineStyle.None;
			}
			break;
		default:
			if (flag)
			{
				xdbd074d37c686bcc.x72d92bd1aff02e37 = x26516bbd7ae;
				xdbd074d37c686bcc.x419ba17a5322627b = x26516bbd7ae;
				xdbd074d37c686bcc.xe360b1885d8d4a41 = x26516bbd7ae;
				xdbd074d37c686bcc.x9bcb07e204e30218 = x26516bbd7ae;
				break;
			}
			if (xdbd074d37c686bcc.x72d92bd1aff02e37 == null)
			{
				xdbd074d37c686bcc.x72d92bd1aff02e37 = LineStyle.None;
			}
			if (xdbd074d37c686bcc.x419ba17a5322627b == null)
			{
				xdbd074d37c686bcc.x419ba17a5322627b = LineStyle.None;
			}
			if (xdbd074d37c686bcc.xe360b1885d8d4a41 == null)
			{
				xdbd074d37c686bcc.xe360b1885d8d4a41 = LineStyle.None;
			}
			if (xdbd074d37c686bcc.x9bcb07e204e30218 == null)
			{
				xdbd074d37c686bcc.x9bcb07e204e30218 = LineStyle.None;
			}
			break;
		}
		return flag;
	}

	private static bool x45578bf953f6063b(xedac08b4826d3056 xf9eaf76facf8149b, Border xa447fc54e41dfe06, Border xfc2074a859a5db8c, Border xc941868c59399d3e, Border xaf9a0436a70689de)
	{
		x1e40528755c1f053 x73cad9ab753bf0fa = xf9eaf76facf8149b.x73cad9ab753bf0fa;
		if (x73cad9ab753bf0fa == x1e40528755c1f053.xf8569aac1192e1a0)
		{
			x60b7a505461a80e7 x60b7a505461a80e = new x60b7a505461a80e7(xf9eaf76facf8149b);
			x45578bf953f6063b(x60b7a505461a80e.x72d92bd1aff02e37, xa447fc54e41dfe06, null, null, null);
			x45578bf953f6063b(x60b7a505461a80e.x419ba17a5322627b, null, xfc2074a859a5db8c, null, null);
			x45578bf953f6063b(x60b7a505461a80e.xe360b1885d8d4a41, null, null, xc941868c59399d3e, null);
			x45578bf953f6063b(x60b7a505461a80e.x9bcb07e204e30218, null, null, null, xaf9a0436a70689de);
			return true;
		}
		if (xa9e915f760bfbe6b(xf9eaf76facf8149b, out var x9b0739496f8b))
		{
			xa447fc54e41dfe06?.x3b83679cceee1fab(x9b0739496f8b);
			xfc2074a859a5db8c?.x3b83679cceee1fab(x9b0739496f8b);
			xc941868c59399d3e?.x3b83679cceee1fab(x9b0739496f8b);
			xaf9a0436a70689de?.x3b83679cceee1fab(x9b0739496f8b);
			return true;
		}
		return false;
	}

	private static bool xa9e915f760bfbe6b(xedac08b4826d3056 xf9eaf76facf8149b, out double x9b0739496f8b5475)
	{
		x9b0739496f8b5475 = 0.0;
		switch (xf9eaf76facf8149b.x73cad9ab753bf0fa)
		{
		case x1e40528755c1f053.x1dd2250c6e384ef7:
		case x1e40528755c1f053.x4a498a651d07aefe:
		{
			string x19218ffab70283ef = xf9eaf76facf8149b.x48112399d54b30c7();
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "thin"))
			{
				x9b0739496f8b5475 = 1.5;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "medium"))
			{
				x9b0739496f8b5475 = 3.0;
				return true;
			}
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "thick"))
			{
				x9b0739496f8b5475 = 4.5;
				return true;
			}
			return false;
		}
		case x1e40528755c1f053.x8c0d22e4c133799d:
		case x1e40528755c1f053.x1be93eed8950d961:
			x9b0739496f8b5475 = xf9eaf76facf8149b.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			return true;
		default:
			return false;
		}
	}

	private static bool x10b6e21504c2bcf0(xedac08b4826d3056 xf9eaf76facf8149b, Border xa447fc54e41dfe06, Border xfc2074a859a5db8c, Border xc941868c59399d3e, Border xaf9a0436a70689de)
	{
		x1e40528755c1f053 x73cad9ab753bf0fa = xf9eaf76facf8149b.x73cad9ab753bf0fa;
		if (x73cad9ab753bf0fa == x1e40528755c1f053.xf8569aac1192e1a0)
		{
			x60b7a505461a80e7 x60b7a505461a80e = new x60b7a505461a80e7(xf9eaf76facf8149b);
			x10b6e21504c2bcf0(x60b7a505461a80e.x72d92bd1aff02e37, xa447fc54e41dfe06, null, null, null);
			x10b6e21504c2bcf0(x60b7a505461a80e.x419ba17a5322627b, null, xfc2074a859a5db8c, null, null);
			x10b6e21504c2bcf0(x60b7a505461a80e.xe360b1885d8d4a41, null, null, xc941868c59399d3e, null);
			x10b6e21504c2bcf0(x60b7a505461a80e.x9bcb07e204e30218, null, null, null, xaf9a0436a70689de);
			return true;
		}
		if (xd80bd53ab495b0af(xf9eaf76facf8149b, out var x6c50a99faab7d))
		{
			if (xa447fc54e41dfe06 != null)
			{
				xa447fc54e41dfe06.x63b1a7c31a962459 = x6c50a99faab7d;
			}
			if (xfc2074a859a5db8c != null)
			{
				xfc2074a859a5db8c.x63b1a7c31a962459 = x6c50a99faab7d;
			}
			if (xc941868c59399d3e != null)
			{
				xc941868c59399d3e.x63b1a7c31a962459 = x6c50a99faab7d;
			}
			if (xaf9a0436a70689de != null)
			{
				xaf9a0436a70689de.x63b1a7c31a962459 = x6c50a99faab7d;
			}
			return true;
		}
		return false;
	}

	private static bool xd80bd53ab495b0af(xedac08b4826d3056 xf9eaf76facf8149b, out x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		x6c50a99faab7d741 = x26d9ecb4bdf0456d.x89fffa2751fdecbe;
		x1e40528755c1f053 x73cad9ab753bf0fa = xf9eaf76facf8149b.x73cad9ab753bf0fa;
		if (x73cad9ab753bf0fa == x1e40528755c1f053.x9b41425268471380)
		{
			x6c50a99faab7d741 = xf9eaf76facf8149b.xef50a938c8b9c7fd();
			return true;
		}
		return false;
	}

	internal static bool xa95bac7421a1a927(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, BorderCollection x241924dcc793876e, bool x82fdb3b4231a1374)
	{
		if (x241924dcc793876e.xa853df7acdb217c8)
		{
			return xa95bac7421a1a927(x44ecfea61c937b8e, x241924dcc793876e.Top, x241924dcc793876e.Left, x241924dcc793876e.Bottom, x241924dcc793876e.Right, x82fdb3b4231a1374);
		}
		return false;
	}

	internal static bool xa95bac7421a1a927(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, Border xc941868c59399d3e, Border xa447fc54e41dfe06, Border xaf9a0436a70689de, Border xfc2074a859a5db8c, bool x82fdb3b4231a1374)
	{
		bool flag = xad56ef88b1fac115(x44ecfea61c937b8e, xc941868c59399d3e, BorderType.Top, x82fdb3b4231a1374);
		bool flag2 = xad56ef88b1fac115(x44ecfea61c937b8e, xa447fc54e41dfe06, BorderType.Left, x82fdb3b4231a1374);
		bool flag3 = xad56ef88b1fac115(x44ecfea61c937b8e, xaf9a0436a70689de, BorderType.Bottom, x82fdb3b4231a1374);
		bool result = xad56ef88b1fac115(x44ecfea61c937b8e, xfc2074a859a5db8c, BorderType.Right, x82fdb3b4231a1374);
		if (!flag && !flag2 && !flag3)
		{
			return result;
		}
		return true;
	}

	internal static bool xad56ef88b1fac115(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, Border x14cf9593b86ecbaa, BorderType xe6e655492739f7d2, bool x82fdb3b4231a1374)
	{
		if (x14cf9593b86ecbaa == null)
		{
			return false;
		}
		if (!x14cf9593b86ecbaa.IsVisible)
		{
			return false;
		}
		x44ecfea61c937b8e.xf0ca15702ca7498c(x9045044e9a819e2d[(int)xe6e655492739f7d2], x447c743d45a64ae1(x14cf9593b86ecbaa.LineStyle));
		x44ecfea61c937b8e.xd6d0700e6673d965(xa314aba0a0ac7778[(int)xe6e655492739f7d2], x14cf9593b86ecbaa.xeae235558dc44397, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		x44ecfea61c937b8e.xf4868abd18f579a7(x62064f31d8f70991[(int)xe6e655492739f7d2], x14cf9593b86ecbaa.x63b1a7c31a962459);
		if (x82fdb3b4231a1374 && x14cf9593b86ecbaa.DistanceFromText > 0.0)
		{
			x44ecfea61c937b8e.xd6d0700e6673d965(x7354db491da2a385[(int)xe6e655492739f7d2], x14cf9593b86ecbaa.DistanceFromText, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
		return true;
	}

	internal static bool xad56ef88b1fac115(Border x14cf9593b86ecbaa, xa3fc7dcdc8182ff6 x44ecfea61c937b8e)
	{
		if (!x14cf9593b86ecbaa.IsVisible)
		{
			return false;
		}
		x44ecfea61c937b8e.xf0ca15702ca7498c("border-style", x447c743d45a64ae1(x14cf9593b86ecbaa.LineStyle));
		x44ecfea61c937b8e.xd6d0700e6673d965("border-width", x14cf9593b86ecbaa.xeae235558dc44397, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		x44ecfea61c937b8e.xf4868abd18f579a7("border-color", x14cf9593b86ecbaa.x63b1a7c31a962459);
		return true;
	}

	internal static void x9a036a30e27cef5e(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, BorderCollection x241924dcc793876e, bool xc1f791c0da7d5aa9, bool xafe24d0ee7944d28)
	{
		if (xc1f791c0da7d5aa9)
		{
			x9a036a30e27cef5e(x44ecfea61c937b8e, x241924dcc793876e.Top, BorderType.Top);
		}
		x9a036a30e27cef5e(x44ecfea61c937b8e, x241924dcc793876e.Left, BorderType.Left);
		if (xafe24d0ee7944d28)
		{
			x9a036a30e27cef5e(x44ecfea61c937b8e, x241924dcc793876e.Bottom, BorderType.Bottom);
		}
		x9a036a30e27cef5e(x44ecfea61c937b8e, x241924dcc793876e.Right, BorderType.Right);
	}

	internal static void x9a036a30e27cef5e(xa3fc7dcdc8182ff6 x44ecfea61c937b8e, Border x14cf9593b86ecbaa, BorderType xe6e655492739f7d2)
	{
		if (x14cf9593b86ecbaa != null && x14cf9593b86ecbaa.IsVisible && x14cf9593b86ecbaa.DistanceFromText > 0.0)
		{
			x44ecfea61c937b8e.xd6d0700e6673d965(x7354db491da2a385[(int)xe6e655492739f7d2], x14cf9593b86ecbaa.DistanceFromText, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
	}

	private static bool x95d2d310d439ac44(string x56474ab72a8d7da2, out LineStyle x26516bbd7ae94699)
	{
		switch (x56474ab72a8d7da2.ToLower())
		{
		case "none":
		case "hidden":
			x26516bbd7ae94699 = LineStyle.None;
			return true;
		case "dotted":
			x26516bbd7ae94699 = LineStyle.Dot;
			return true;
		case "dashed":
			x26516bbd7ae94699 = LineStyle.DashSmallGap;
			return true;
		case "double":
			x26516bbd7ae94699 = LineStyle.Double;
			return true;
		case "groove":
			x26516bbd7ae94699 = LineStyle.Emboss3D;
			return true;
		case "ridge":
			x26516bbd7ae94699 = LineStyle.Engrave3D;
			return true;
		case "solid":
		case "inset":
		case "outset":
			x26516bbd7ae94699 = LineStyle.Single;
			return true;
		default:
			x26516bbd7ae94699 = LineStyle.None;
			return false;
		}
	}

	private static string x447c743d45a64ae1(LineStyle x26516bbd7ae94699)
	{
		switch (x26516bbd7ae94699)
		{
		case LineStyle.DashLargeGap:
		case LineStyle.DashSmallGap:
		case LineStyle.DashDotStroker:
			return "dashed";
		case LineStyle.Dot:
		case LineStyle.DotDash:
		case LineStyle.DotDotDash:
			return "dotted";
		case LineStyle.Double:
		case LineStyle.Triple:
		case LineStyle.DoubleWave:
			return "double";
		case LineStyle.Emboss3D:
			return "groove";
		case LineStyle.Engrave3D:
			return "ridge";
		case LineStyle.None:
			return "none";
		default:
			return "solid";
		}
	}

	internal static bool x268d6d4bc90473e9(LineStyle x26516bbd7ae94699)
	{
		switch (x26516bbd7ae94699)
		{
		case LineStyle.Single:
		case LineStyle.Thick:
		case LineStyle.Double:
		case LineStyle.Hairline:
		case LineStyle.Dot:
		case LineStyle.DashLargeGap:
		case LineStyle.DotDash:
		case LineStyle.DotDotDash:
		case LineStyle.DashSmallGap:
		case LineStyle.DashDotStroker:
		case LineStyle.Emboss3D:
		case LineStyle.Engrave3D:
			return true;
		default:
			return false;
		}
	}

	private static void x6f1c9961f9c83c67(BorderCollection x241924dcc793876e)
	{
		int num = x241924dcc793876e.Count;
		while (--num >= 0)
		{
			x6f1c9961f9c83c67(x241924dcc793876e[num]);
		}
	}

	internal static void x6f1c9961f9c83c67(Border x14cf9593b86ecbaa)
	{
		float num = Border.xb556d1cd3d419a11(x14cf9593b86ecbaa.LineStyle, 1f);
		if (num > 1f)
		{
			x14cf9593b86ecbaa.x3b83679cceee1fab(x14cf9593b86ecbaa.LineWidth / (double)num);
		}
	}
}
