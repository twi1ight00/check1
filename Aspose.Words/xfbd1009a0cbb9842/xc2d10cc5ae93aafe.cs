using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class xc2d10cc5ae93aafe : x5c928e5f0a98a22c
{
	private readonly string x17b196bc6252cd1a;

	private int x57d3c0a64c1df452;

	public x1b9dfa914d94b6e0 xd420ac3415caa02b => x1b9dfa914d94b6e0.x6fe652a9a79f74c7;

	public bool xdb33379fd4e83768 => false;

	public char x1efcac262b819134 => x17b196bc6252cd1a[x57d3c0a64c1df452];

	public bool x0e410626c9576523 => x57d3c0a64c1df452 >= x17b196bc6252cd1a.Length;

	public int x5eddc5de8738680a => 1024;

	public int x885d577f7c56563e => 1024;

	internal xc2d10cc5ae93aafe(string fieldCode)
		: this(fieldCode, moveToFirstToken: false)
	{
	}

	internal xc2d10cc5ae93aafe(string fieldCode, bool moveToFirstToken)
	{
		x17b196bc6252cd1a = fieldCode;
		x57d3c0a64c1df452 = -1;
		if (moveToFirstToken)
		{
			x2408a6db33935c93();
		}
	}

	public bool x2408a6db33935c93()
	{
		x57d3c0a64c1df452++;
		return !x0e410626c9576523;
	}

	public x98739d759efb5fe7 x80766db8f9759629()
	{
		return x98739d759efb5fe7.x825c3b6fa3e39f20;
	}
}
