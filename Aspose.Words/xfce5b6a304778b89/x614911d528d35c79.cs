using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x614911d528d35c79
{
	private x614911d528d35c79()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, bool xafd04c36a00d5bcf)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f;
		xe3843707a08acbb0 xe3843707a08acbb = new xe3843707a08acbb0();
		x80e7bc7a8daa7453(xe134235b3526fa75, xe3843707a08acbb);
		bool flag = false;
		while (xca994afbcb9073a.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "text-properties":
			{
				xeedad81aaed42a76 xeedad81aaed42a = xaf0a8e2144428ff9.x06b0e25aa6ad68a9(xe134235b3526fa75, xe3843707a08acbb);
				if (xeedad81aaed42a.xd44988f225497f3a > 0)
				{
					if (xe3843707a08acbb.xeedad81aaed42a76 != null)
					{
						xe3843707a08acbb.xeedad81aaed42a76.xab3af626b1405ee8(xeedad81aaed42a);
					}
					xe3843707a08acbb.xeedad81aaed42a76 = xeedad81aaed42a;
				}
				break;
			}
			case "text":
				xe3843707a08acbb.xacc0cf2788d5c15a = $"{xe3843707a08acbb.xacc0cf2788d5c15a}{xca994afbcb9073a.x2a1ea9d24e62bf84()}";
				break;
			case "day":
				xe3843707a08acbb.xacc0cf2788d5c15a = string.Format("{0}{1}", xe3843707a08acbb.xacc0cf2788d5c15a, x087986152205429f(xca994afbcb9073a, "d"));
				break;
			case "month":
				xe3843707a08acbb.xacc0cf2788d5c15a = string.Format("{0}{1}", xe3843707a08acbb.xacc0cf2788d5c15a, x087986152205429f(xca994afbcb9073a, "M"));
				if (x6a3fb1c93ad0eae5(xca994afbcb9073a))
				{
					xe3843707a08acbb.xacc0cf2788d5c15a = $"{xe3843707a08acbb.xacc0cf2788d5c15a}MM";
				}
				break;
			case "year":
				xe3843707a08acbb.xacc0cf2788d5c15a = string.Format("{0}{1}", xe3843707a08acbb.xacc0cf2788d5c15a, x087986152205429f(xca994afbcb9073a, "yy"));
				break;
			case "era":
				xe3843707a08acbb.xacc0cf2788d5c15a = $"{xe3843707a08acbb.xacc0cf2788d5c15a}g";
				break;
			case "day-of-week":
				xe3843707a08acbb.xacc0cf2788d5c15a = string.Format("{0}{1}dd", xe3843707a08acbb.xacc0cf2788d5c15a, x087986152205429f(xca994afbcb9073a, "d"));
				break;
			case "hours":
				xe3843707a08acbb.xacc0cf2788d5c15a = string.Format("{0}{1}", xe3843707a08acbb.xacc0cf2788d5c15a, x087986152205429f(xca994afbcb9073a, "H"));
				break;
			case "am-pm":
				xe3843707a08acbb.xacc0cf2788d5c15a = $"{xe3843707a08acbb.xacc0cf2788d5c15a}am/pm";
				flag = true;
				break;
			case "minutes":
				xe3843707a08acbb.xacc0cf2788d5c15a = string.Format("{0}{1}", xe3843707a08acbb.xacc0cf2788d5c15a, x087986152205429f(xca994afbcb9073a, "m"));
				break;
			case "seconds":
				xe3843707a08acbb.xacc0cf2788d5c15a = string.Format("{0}{1}", xe3843707a08acbb.xacc0cf2788d5c15a, x087986152205429f(xca994afbcb9073a, "s"));
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
		if (flag)
		{
			xe3843707a08acbb.xacc0cf2788d5c15a = xe3843707a08acbb.xacc0cf2788d5c15a.Replace("H", "h");
		}
		xe134235b3526fa75.x37eb83f4e2a8fe56.xd6b6ed77479ef68c(xe3843707a08acbb, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf);
	}

	private static void x80e7bc7a8daa7453(xf871da68decec406 xe134235b3526fa75, xe3843707a08acbb0 x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xca994afbcb9073a.x99f8cdb2827fa686();
		string text = "";
		string text2 = "";
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xf871da68decec406.x8125d547dbbe8218(xca994afbcb9073a, x44ecfea61c937b8e))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "language":
					text = xca994afbcb9073a.xd2f68ee6f47e9dfb;
					break;
				case "country":
					text2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
					break;
				}
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text) || x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			if (x44ecfea61c937b8e.xeedad81aaed42a76 == null)
			{
				x44ecfea61c937b8e.xeedad81aaed42a76 = new xeedad81aaed42a76();
			}
			x44ecfea61c937b8e.xeedad81aaed42a76.xd00aa8389522ce53(380, x0eb9a864413f34de.x1fd658c8428b3dd6($"{text}-{text2}"));
		}
	}

	private static bool xaf42c7380551e7aa(x536e1b48249b1390 xd19f1b93a822ffb3)
	{
		return xd19f1b93a822ffb3.xd68abcd61e368af9("style", "short").ToLower() == "long";
	}

	private static bool x6a3fb1c93ad0eae5(x536e1b48249b1390 xd19f1b93a822ffb3)
	{
		return xd19f1b93a822ffb3.xd68abcd61e368af9("textual", "false").ToLower() == "true";
	}

	private static string x087986152205429f(x536e1b48249b1390 xd19f1b93a822ffb3, string x82ee2972331a0e39)
	{
		if (xaf42c7380551e7aa(xd19f1b93a822ffb3))
		{
			return $"{x82ee2972331a0e39}{x82ee2972331a0e39}";
		}
		return x82ee2972331a0e39;
	}
}
