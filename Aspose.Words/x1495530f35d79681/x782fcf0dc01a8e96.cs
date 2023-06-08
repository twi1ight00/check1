using System;
using xf9a9481c3f63a419;

namespace x1495530f35d79681;

internal class x782fcf0dc01a8e96
{
	private readonly int x60adf410a9cceab0 = -1;

	private readonly DateTime xcb00aeb89d09a07d = DateTime.MinValue;

	private string xc61ff88f1f98652d = "";

	private readonly string x7653bfba0eb25e11 = "";

	private readonly string xe02f5a0888aae677 = "";

	private readonly string xe9dffb85116ec631 = "";

	private readonly int xc397a7c0aec51dff = -1;

	private readonly int x76e985e718e93710 = -1;

	private readonly string xf263b01e2956834c = "";

	internal int xea1e81378298fa81 => x60adf410a9cceab0;

	internal DateTime x197c47a24c81f695 => xcb00aeb89d09a07d;

	internal string x759aa16c2016a289
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			xc61ff88f1f98652d = value;
		}
	}

	internal string xb063bbfcfeade526 => x7653bfba0eb25e11;

	internal string xc085e830e777a251 => xe02f5a0888aae677;

	internal string x5995f9ab0072f644 => xe9dffb85116ec631;

	internal int x6aaf4d9b15644fca => xc397a7c0aec51dff;

	internal int x188288b446f5fc96 => x76e985e718e93710;

	internal string x3146d638ec378671 => xf263b01e2956834c;

	internal bool xbd2068db29af7264 => x60adf410a9cceab0 >= 0;

	internal bool xe881e3c2e6bcef53
	{
		get
		{
			if (xf263b01e2956834c == "Word.Comment")
			{
				return x60adf410a9cceab0 >= 0;
			}
			return false;
		}
	}

	internal x782fcf0dc01a8e96(x3c85359e1389ad43 xmlReader)
	{
		while (xmlReader.x1ac1960adc8c4c39())
		{
			switch (xmlReader.xa66385d80d4d296f)
			{
			case "id":
				x60adf410a9cceab0 = xmlReader.xbba6773b8ce56a01;
				break;
			case "date":
			case "createdate":
				xcb00aeb89d09a07d = xca004f56614e2431.x70982613fd6240f9(xmlReader.xd2f68ee6f47e9dfb);
				break;
			case "name":
				xc61ff88f1f98652d = xmlReader.xd2f68ee6f47e9dfb;
				break;
			case "author":
				x7653bfba0eb25e11 = xmlReader.xd2f68ee6f47e9dfb;
				break;
			case "initials":
				xe02f5a0888aae677 = xmlReader.xd2f68ee6f47e9dfb;
				break;
			case "original":
				xe9dffb85116ec631 = xmlReader.xd2f68ee6f47e9dfb;
				break;
			case "colFirst":
			case "col-first":
				xc397a7c0aec51dff = xmlReader.xbba6773b8ce56a01;
				break;
			case "colLast":
			case "col-last":
				x76e985e718e93710 = xmlReader.xbba6773b8ce56a01;
				break;
			case "type":
				xf263b01e2956834c = xmlReader.xd2f68ee6f47e9dfb;
				break;
			}
		}
	}
}
