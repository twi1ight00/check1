using Aspose.Words;

namespace xfbd1009a0cbb9842;

internal class xb5986aa209d01503
{
	private enum xb68dfd27113cf421
	{
		xa65a89fe71f479a6,
		xc189235946338703,
		x09d29a5572c3e1a9
	}

	private enum x802619d371a59f5d
	{
		xf9ad6fb78355fe13,
		x3e1feffd8ca6feb2,
		x871067292d764b33,
		x1d4111c56ee91167
	}

	private xb68dfd27113cf421 x9b529da35d1032aa;

	private int x0fd5b2176bb225c3;

	private readonly x6d232feca81d2281 xf3761e6c82d9b447;

	private readonly xe2ab94acf964af40 x248f4e17b962cf18;

	internal xb5986aa209d01503(x6d232feca81d2281 entryExtractor, xe2ab94acf964af40 validHeadingRange)
	{
		xf3761e6c82d9b447 = entryExtractor;
		x248f4e17b962cf18 = validHeadingRange;
		x9b529da35d1032aa = xb68dfd27113cf421.xa65a89fe71f479a6;
	}

	internal int x0d965722d540053e(Run xb0e5d73738e62f9e)
	{
		if (x9b529da35d1032aa == xb68dfd27113cf421.x09d29a5572c3e1a9)
		{
			x9b529da35d1032aa = xb68dfd27113cf421.xc189235946338703;
			x0fd5b2176bb225c3 = -1;
		}
		for (int i = 0; i < xb0e5d73738e62f9e.Text.Length; i++)
		{
			x802619d371a59f5d x8fbf940e9b8c = xc6acfdf884b9cc4c(xb0e5d73738e62f9e.Text[i]);
			switch (x9b529da35d1032aa)
			{
			case xb68dfd27113cf421.xa65a89fe71f479a6:
				xa65a89fe71f479a6(x8fbf940e9b8c, xb0e5d73738e62f9e);
				break;
			case xb68dfd27113cf421.xc189235946338703:
				xc189235946338703(x8fbf940e9b8c);
				break;
			}
			if (x9b529da35d1032aa == xb68dfd27113cf421.x09d29a5572c3e1a9)
			{
				break;
			}
		}
		return x0fd5b2176bb225c3;
	}

	private void xa65a89fe71f479a6(x802619d371a59f5d x8fbf940e9b8c4229, Run xb0e5d73738e62f9e)
	{
		if (x8fbf940e9b8c4229 == x802619d371a59f5d.xf9ad6fb78355fe13 && !xb0e5d73738e62f9e.x1a2af56d5e4e537b)
		{
			x0fd5b2176bb225c3 = xf3761e6c82d9b447.x5aee3a86e72f3836(xb0e5d73738e62f9e, x248f4e17b962cf18);
			if (xe2ab94acf964af40.x451fe5122b35ec1f(x0fd5b2176bb225c3))
			{
				x9b529da35d1032aa = xb68dfd27113cf421.x09d29a5572c3e1a9;
			}
			else
			{
				x9b529da35d1032aa = xb68dfd27113cf421.xc189235946338703;
			}
		}
	}

	private void xc189235946338703(x802619d371a59f5d x8fbf940e9b8c4229)
	{
		switch (x8fbf940e9b8c4229)
		{
		case x802619d371a59f5d.x871067292d764b33:
		case x802619d371a59f5d.x1d4111c56ee91167:
			x9b529da35d1032aa = xb68dfd27113cf421.xa65a89fe71f479a6;
			break;
		}
	}

	private static x802619d371a59f5d xc6acfdf884b9cc4c(char x3c4da2980d043c95)
	{
		switch (x3c4da2980d043c95)
		{
		case '\f':
			return x802619d371a59f5d.x871067292d764b33;
		case '\u000e':
			return x802619d371a59f5d.x1d4111c56ee91167;
		default:
			if (char.IsWhiteSpace(x3c4da2980d043c95))
			{
				return x802619d371a59f5d.x3e1feffd8ca6feb2;
			}
			return x802619d371a59f5d.xf9ad6fb78355fe13;
		}
	}
}
