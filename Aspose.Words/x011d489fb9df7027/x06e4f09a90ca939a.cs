namespace x011d489fb9df7027;

internal class x06e4f09a90ca939a
{
	private readonly bool xbb6220240eb3c75f;

	private readonly int x4574aea041dd835f;

	internal bool x11f06dbf14c9ade8 => xbb6220240eb3c75f;

	internal int xd2f68ee6f47e9dfb => x4574aea041dd835f;

	internal x06e4f09a90ca939a()
		: this(0, isFormula: false)
	{
	}

	internal x06e4f09a90ca939a(int value)
		: this(value, isFormula: false)
	{
	}

	internal x06e4f09a90ca939a(int value, bool isFormula)
	{
		x4574aea041dd835f = value;
		xbb6220240eb3c75f = isFormula;
	}

	public override string ToString()
	{
		return string.Format("{0}{1}", x11f06dbf14c9ade8 ? "@" : "", xd2f68ee6f47e9dfb);
	}
}
