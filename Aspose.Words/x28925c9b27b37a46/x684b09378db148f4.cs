using Aspose.Words;
using xc76255e87e5986c6;

namespace x28925c9b27b37a46;

internal class x684b09378db148f4
{
	private x684b09378db148f4()
	{
	}

	internal static Style x01205336aca8f566(xcf3b0f04424de818 x31545d7c306a55e4)
	{
		return x01205336aca8f566(x31545d7c306a55e4, x3207364c42cdeab2: true);
	}

	private static Style x01205336aca8f566(xcf3b0f04424de818 x31545d7c306a55e4, bool x3207364c42cdeab2)
	{
		Style result = null;
		DocumentBase xbcf7b328881df2ae = x31545d7c306a55e4.xbcf7b328881df2ae;
		xeedad81aaed42a76 xc87649c48f7756d = x31545d7c306a55e4.xc87649c48f7756d2;
		if (x3207364c42cdeab2)
		{
			result = xbcf7b328881df2ae.Styles.xf194004582627ed5(xc87649c48f7756d.x8301ab10c226b0c2, 10);
		}
		else if (xc87649c48f7756d.x263d579af1d0d43f(50))
		{
			result = xbcf7b328881df2ae.Styles.x1976fb6958cf7237(xc87649c48f7756d.x8301ab10c226b0c2, x988fcf605f8efa7e: false);
		}
		return result;
	}

	internal static xeedad81aaed42a76 x856218fd0771d379(xcf3b0f04424de818 xda5bf54deb817e37, xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		xeedad81aaed42a76 xeedad81aaed42a77 = new xeedad81aaed42a76();
		x5f851b1938defe5f(xda5bf54deb817e37, xeedad81aaed42a77, xebf45bdcaa1fd1e1);
		return xeedad81aaed42a77;
	}

	internal static void x5f851b1938defe5f(xcf3b0f04424de818 x31545d7c306a55e4, xeedad81aaed42a76 x4ac4562403543b7a, xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		Style x0fb020b6255230e = x31545d7c306a55e4.xaef90b934cbe5a8c?.xfcffbd79482d97c7;
		Style x6614b8e76b3d5ed = x01205336aca8f566(x31545d7c306a55e4, x3207364c42cdeab2: false);
		xeedad81aaed42a76 xc87649c48f7756d = x31545d7c306a55e4.xc87649c48f7756d2;
		x5f851b1938defe5f(x31545d7c306a55e4.xbcf7b328881df2ae, x0fb020b6255230e, x6614b8e76b3d5ed, xc87649c48f7756d, x4ac4562403543b7a, xebf45bdcaa1fd1e1);
	}

	internal static void x5f851b1938defe5f(DocumentBase x6beba47238e0ade6, Style x0fb020b6255230e4, Style x6614b8e76b3d5ed7, xeedad81aaed42a76 xe273a7e2dbf2d05a, xeedad81aaed42a76 x4ac4562403543b7a, xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		bool flag = (xebf45bdcaa1fd1e1 & xecac24b19ed3a2b7.x87415330d9d0754a) != 0;
		xecac24b19ed3a2b7 xebf45bdcaa1fd1e2 = (flag ? xecac24b19ed3a2b7.x87415330d9d0754a : xecac24b19ed3a2b7.xe9e531d1a6725226);
		x3dabda6865ed239d x7ac07d7dd429ba6e = (flag ? x6beba47238e0ade6.x9bb3f6e28fa55f34() : null);
		if ((xebf45bdcaa1fd1e1 & xecac24b19ed3a2b7.x2be08ba736aa04f0) != 0)
		{
			x6beba47238e0ade6.Styles.x27096df7ca0cfe2e.xab3af626b1405ee8(x4ac4562403543b7a, x7ac07d7dd429ba6e);
		}
		if (x0fb020b6255230e4 != null)
		{
			if (x0fb020b6255230e4.Type == StyleType.Character)
			{
				x0fb020b6255230e4 = x6beba47238e0ade6.Styles.xf21e14e2c9db279a(StyleIdentifier.Normal, x988fcf605f8efa7e: false);
			}
			bool flag2 = (xebf45bdcaa1fd1e1 & xecac24b19ed3a2b7.xe65081df606950cc) != 0;
			object x82cc274dec6f4f4c = (flag2 ? x336746895523fd61(x0fb020b6255230e4, 190) : null);
			object x82cc274dec6f4f4c2 = (flag2 ? x336746895523fd61(x0fb020b6255230e4, 350) : null);
			x0fb020b6255230e4.x5f851b1938defe5f(x4ac4562403543b7a, xebf45bdcaa1fd1e2);
			x3ea3aabe84d62a54(x0fb020b6255230e4, 190, x82cc274dec6f4f4c);
			x3ea3aabe84d62a54(x0fb020b6255230e4, 350, x82cc274dec6f4f4c2);
		}
		if (x6614b8e76b3d5ed7 != null && x6614b8e76b3d5ed7.Type != StyleType.Paragraph && ((xebf45bdcaa1fd1e1 & xecac24b19ed3a2b7.xe66fef78f14a2a91) == 0 || x6614b8e76b3d5ed7.StyleIdentifier != StyleIdentifier.Hyperlink))
		{
			x6614b8e76b3d5ed7.x5f851b1938defe5f(x4ac4562403543b7a, xebf45bdcaa1fd1e2);
		}
		xe273a7e2dbf2d05a.xab3af626b1405ee8(x4ac4562403543b7a, x7ac07d7dd429ba6e);
	}

	private static object x336746895523fd61(Style x44ecfea61c937b8e, int xba08ce632055a1d9)
	{
		object obj = x44ecfea61c937b8e.xeedad81aaed42a76.xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj != null)
		{
			int num = (int)obj;
			if (num == 24 || (num == 20 && x44ecfea61c937b8e.StyleIdentifier == StyleIdentifier.Normal))
			{
				x44ecfea61c937b8e.xeedad81aaed42a76.x52b190e626f65140(xba08ce632055a1d9);
				return obj;
			}
		}
		return null;
	}

	private static void x3ea3aabe84d62a54(Style x44ecfea61c937b8e, int xba08ce632055a1d9, object x82cc274dec6f4f4c)
	{
		if (x82cc274dec6f4f4c != null)
		{
			x44ecfea61c937b8e.xeedad81aaed42a76.xae20093bed1e48a8(xba08ce632055a1d9, x82cc274dec6f4f4c);
		}
	}

	internal static object xdafa1f94b023b665(xcf3b0f04424de818 x31545d7c306a55e4, int x6cc530a2cd983862)
	{
		object obj = x01205336aca8f566(x31545d7c306a55e4, x3207364c42cdeab2: false)?.x61d8cd76508e76c3(x6cc530a2cd983862, x9ee6c2f047893ddc: false);
		if (obj != null)
		{
			if (obj is x9b28b1f7f0cc963f)
			{
				obj = xe690183f0f6389a1(x31545d7c306a55e4, x6cc530a2cd983862, (x9b28b1f7f0cc963f)obj);
			}
		}
		else
		{
			obj = x6a9aaddaa75867df(x31545d7c306a55e4, x6cc530a2cd983862);
		}
		if (obj == null)
		{
			return x8d8422c84fadcd94(x31545d7c306a55e4, x6cc530a2cd983862);
		}
		return obj;
	}

	private static x9b28b1f7f0cc963f xe690183f0f6389a1(xcf3b0f04424de818 x31545d7c306a55e4, int x6cc530a2cd983862, x9b28b1f7f0cc963f x7137ab94ed705f1c)
	{
		x9b28b1f7f0cc963f result = x7137ab94ed705f1c;
		x9b28b1f7f0cc963f x9b28b1f7f0cc963f2 = (x9b28b1f7f0cc963f)x6a9aaddaa75867df(x31545d7c306a55e4, x6cc530a2cd983862);
		if (x9b28b1f7f0cc963f2 != null && x7137ab94ed705f1c != null)
		{
			x9b28b1f7f0cc963f x9b28b1f7f0cc963f3 = (x9b28b1f7f0cc963f)x8d8422c84fadcd94(x31545d7c306a55e4, x6cc530a2cd983862);
			result = ((x9b28b1f7f0cc963f3 != x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc) ? ((x7137ab94ed705f1c == x9b28b1f7f0cc963f2) ? x9b28b1f7f0cc963f.x12642456c7bf0815 : x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc) : x9b28b1f7f0cc963f3);
		}
		return result;
	}

	private static object x6a9aaddaa75867df(xcf3b0f04424de818 x31545d7c306a55e4, int x6cc530a2cd983862)
	{
		return x31545d7c306a55e4.xaef90b934cbe5a8c?.xfcffbd79482d97c7.x61d8cd76508e76c3(x6cc530a2cd983862, x9ee6c2f047893ddc: false);
	}

	private static object x8d8422c84fadcd94(xcf3b0f04424de818 x31545d7c306a55e4, int x6cc530a2cd983862)
	{
		object obj = x31545d7c306a55e4.xbcf7b328881df2ae.Styles.x27096df7ca0cfe2e.xf7866f89640a29a3(x6cc530a2cd983862);
		if (obj == null)
		{
			obj = xeedad81aaed42a76.xb1e619009047280c(x6cc530a2cd983862);
		}
		return obj;
	}

	internal static bool xdb80a3a0801e3e63(xcf3b0f04424de818 x31545d7c306a55e4)
	{
		return x31545d7c306a55e4.xc87649c48f7756d2.xba4e1d8a3e3316c8;
	}

	internal static bool xd779a54e74a3c346(xcf3b0f04424de818 x31545d7c306a55e4)
	{
		return x31545d7c306a55e4.xc87649c48f7756d2.x0392c0938d22c790;
	}

	internal static object xfe91eeeafcb3026a(xf5ecf429e74b1c04 x50a18ad2656e7181, int xba08ce632055a1d9)
	{
		if (x50a18ad2656e7181 == null)
		{
			return null;
		}
		object obj = x50a18ad2656e7181.x9bd0b4c41657450b(xba08ce632055a1d9);
		if (obj == null)
		{
			return x50a18ad2656e7181.x2685f947206319cf(xba08ce632055a1d9);
		}
		if (obj is x9b28b1f7f0cc963f)
		{
			return ((x9b28b1f7f0cc963f)obj).xa1d77f2e7738b62c(x50a18ad2656e7181, xba08ce632055a1d9);
		}
		return obj;
	}

	internal static bool xf2ad33c56ce6586d(xf5ecf429e74b1c04 x50a18ad2656e7181)
	{
		return x50a18ad2656e7181.x9bd0b4c41657450b(400) != null;
	}
}
