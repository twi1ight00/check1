using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal abstract class x99591af092599bad
{
	private const int x7764f2a3c6040308 = -1;

	private readonly Style x2d730567722c1496;

	protected Style x5b6656344a1f0b8e => x2d730567722c1496;

	protected x99591af092599bad(Style tocEntryStyle)
	{
		x2d730567722c1496 = tocEntryStyle;
	}

	protected abstract void ModifyInlineNode(Inline sourceInline, Inline modifiedInline);

	protected Node x57f70b425b43a885(Node x98cacf1c34b53cca, Node xc926b680b06084a7)
	{
		if (x98cacf1c34b53cca is Inline && xc926b680b06084a7 is Inline)
		{
			ModifyInlineNode((Inline)x98cacf1c34b53cca, (Inline)xc926b680b06084a7);
		}
		return xc926b680b06084a7;
	}

	internal static xe83a6b069ec8efc2 xbdd431120301ba2e(StyleIdentifier xdc4abb3e004e1785, StyleCollection x3fa6ecdd18b2ff6e, bool x73feb1b1b768c68e)
	{
		Style tocEntryStyle = x3fa6ecdd18b2ff6e.xf21e14e2c9db279a(xdc4abb3e004e1785, x988fcf605f8efa7e: true);
		if (!x73feb1b1b768c68e)
		{
			return new x1eb2a34c6450b3e1(tocEntryStyle);
		}
		return new xfaf63ce8c54cd8e9(tocEntryStyle);
	}

	protected void xcfa8ff6665b463cb(Inline xf7a250c42a4b8fc1, Inline xe947890993704cca)
	{
		int[] x567ee8998e5fe = x90387ee7af592451(xf7a250c42a4b8fc1);
		x937d774e9e1ab7aa(xe947890993704cca.xeedad81aaed42a76, x567ee8998e5fe);
	}

	protected int[] x90387ee7af592451(Inline x31545d7c306a55e4)
	{
		xeedad81aaed42a76 xeedad81aaed42a = x31545d7c306a55e4.xeedad81aaed42a76;
		int[] array = new int[xeedad81aaed42a.xe252973deea04dda];
		for (int i = 0; i < xeedad81aaed42a.xe252973deea04dda; i++)
		{
			xeedad81aaed42a.x16b3a875e7cc38ed(i, out var xba08ce632055a1d, out var xbcea506a33cf);
			array[i] = (IsExtraDirectAttribute(xba08ce632055a1d, xbcea506a33cf, x31545d7c306a55e4) ? xba08ce632055a1d : (-1));
		}
		return array;
	}

	protected virtual bool IsExtraDirectAttribute(int directAttrKey, object directAttrValue, Inline sourceInline)
	{
		if (!x3c4054366b5d58c7(directAttrKey) && !x4eacb46900157d50(directAttrKey, directAttrValue, sourceInline))
		{
			return x9db2d3050eb50d1f(directAttrKey, directAttrValue, sourceInline);
		}
		return true;
	}

	protected bool x3c4054366b5d58c7(int x337751f7ff5a51da)
	{
		if (x337751f7ff5a51da != 190 && x337751f7ff5a51da != 350)
		{
			return x337751f7ff5a51da == 50;
		}
		return true;
	}

	protected bool x4eacb46900157d50(int x8129734c921620d5, object xca70b27f873910bd, Inline xf7a250c42a4b8fc1)
	{
		object obj = x684b09378db148f4.xdafa1f94b023b665(xf7a250c42a4b8fc1, x8129734c921620d5);
		return xca70b27f873910bd.Equals(obj);
	}

	protected bool x9db2d3050eb50d1f(int x8129734c921620d5, object xd1d8df985b578197, Inline xf7a250c42a4b8fc1)
	{
		if (!(xd1d8df985b578197 is x9b28b1f7f0cc963f))
		{
			return false;
		}
		x9b28b1f7f0cc963f x9b28b1f7f0cc963f = (x9b28b1f7f0cc963f)xf7a250c42a4b8fc1.xcdd1fdba92902f20.x61d8cd76508e76c3(x8129734c921620d5, x9ee6c2f047893ddc: false);
		if (x9b28b1f7f0cc963f != x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc)
		{
			return x1da8b385123b5912(x8129734c921620d5, xf7a250c42a4b8fc1);
		}
		return true;
	}

	protected bool x1da8b385123b5912(int x337751f7ff5a51da, Inline xf7a250c42a4b8fc1)
	{
		if (x5b6656344a1f0b8e == null)
		{
			return false;
		}
		object obj = x5b6656344a1f0b8e.x61d8cd76508e76c3(x337751f7ff5a51da, x9ee6c2f047893ddc: true);
		object obj2 = xf7a250c42a4b8fc1.Font.xfe91eeeafcb3026a(x337751f7ff5a51da);
		return obj2.Equals(obj);
	}

	protected static void x937d774e9e1ab7aa(x4c1e058c67948d6a x72e03ac29430dcbc, int[] x567ee8998e5fe344)
	{
		foreach (int num in x567ee8998e5fe344)
		{
			if (num != -1)
			{
				x72e03ac29430dcbc.x52b190e626f65140(num);
			}
		}
	}
}
