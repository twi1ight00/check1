using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;

namespace x4adf554d20d941a6;

internal class xad7715b8ed63de5f
{
	internal static void xceaa36575b797b5b(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		if (x5566e2d2acbd1fbe.x80b95148e8799434(x311e7a92306d7199.x9c9d9095366398e8.x5566e2d2acbd1fbe))
		{
			return;
		}
		ParagraphAlignment paragraphAlignment = x311e7a92306d7199.x406d8cd2af514771.xa79651e2f1a1416e.x9ba359ff37a3a63b;
		bool x8786efe6471e = x311e7a92306d7199.x8786efe6471e0521;
		if (x8786efe6471e)
		{
			x452d47656a81e83b(x311e7a92306d7199);
		}
		else
		{
			x98e6d5779680da6e(x311e7a92306d7199);
		}
		int num = 0;
		if (paragraphAlignment != 0)
		{
			num = (x8786efe6471e ? (x64f2876ef9cfce05(x311e7a92306d7199.xdc3f248db6e996ed, x8786efe6471e) - x311e7a92306d7199.x8df91a2f90079e88 + x311e7a92306d7199.x2206903f9421fd4b().X) : (x311e7a92306d7199.xdc1bf80853046136 - x64f2876ef9cfce05(x311e7a92306d7199.xdc3f248db6e996ed, x8786efe6471e)));
			if (num <= 0)
			{
				paragraphAlignment = ParagraphAlignment.Left;
			}
			if (x8786efe6471e)
			{
				num = -num;
			}
		}
		switch (paragraphAlignment)
		{
		case ParagraphAlignment.Center:
			x3c0fb01917868a79(x311e7a92306d7199.x0eafd527bd1e778e, num / 2);
			break;
		case ParagraphAlignment.Right:
			x3c0fb01917868a79(x311e7a92306d7199.x0eafd527bd1e778e, num);
			break;
		case ParagraphAlignment.Justify:
			if (x8786efe6471e)
			{
				xb074839806da7aa9(x311e7a92306d7199);
			}
			else
			{
				x6601a79a48c35b7b(x311e7a92306d7199);
			}
			break;
		case ParagraphAlignment.Distributed:
			if (x8786efe6471e)
			{
				x419ccc96626d243c(x311e7a92306d7199);
			}
			else
			{
				x4c15c36e9dab37d2(x311e7a92306d7199);
			}
			break;
		case ParagraphAlignment.Left:
			break;
		}
	}

	private static void x3c0fb01917868a79(x56410a8dd70087c5 x62584df2cb5d40dd, int xf7845a6fecd5afc3)
	{
		for (x56410a8dd70087c5 x56410a8dd70087c6 = x62584df2cb5d40dd; x56410a8dd70087c6 != null; x56410a8dd70087c6 = x56410a8dd70087c6.xbd2e6df53b2331ee)
		{
			x56410a8dd70087c6.x8df91a2f90079e88 += xf7845a6fecd5afc3;
		}
	}

	private static int x64f2876ef9cfce05(x56410a8dd70087c5 x62584df2cb5d40dd, bool x370968c2ea974ce4)
	{
		bool x4cd8dfaddfd72f3c = x62584df2cb5d40dd.x406d8cd2af514771.xa79651e2f1a1416e.x4cd8dfaddfd72f3c;
		int result = (x370968c2ea974ce4 ? x62584df2cb5d40dd.x5a7799e1836857e3.xdc1bf80853046136 : 0);
		for (x56410a8dd70087c5 x56410a8dd70087c6 = x62584df2cb5d40dd; x56410a8dd70087c6 != null; x56410a8dd70087c6 = x56410a8dd70087c6.xe41821af1989e791)
		{
			if ((!x319aaf89fcce8c8f(x56410a8dd70087c6) || !x4cd8dfaddfd72f3c) && !x5566e2d2acbd1fbe.x6634ed9c1dfbdfce(x56410a8dd70087c6.x5566e2d2acbd1fbe) && (25604 != x56410a8dd70087c6.x5566e2d2acbd1fbe || !x56410a8dd70087c6.x34251722ab416841.x109e3389933c23a8.x6f6877b222ed4153) && x56410a8dd70087c6.x5566e2d2acbd1fbe != 0)
			{
				result = (x370968c2ea974ce4 ? x56410a8dd70087c6.x8df91a2f90079e88 : x56410a8dd70087c6.x419ba17a5322627b);
			}
		}
		return result;
	}

	private static void x1c575c5c2e116263(x56410a8dd70087c5 x62584df2cb5d40dd, out x56410a8dd70087c5 x943e15f60160bae8, out int xc177d129f782d9e2)
	{
		xc177d129f782d9e2 = 0;
		x943e15f60160bae8 = null;
		int num = 0;
		bool flag = false;
		for (x56410a8dd70087c5 x56410a8dd70087c6 = x62584df2cb5d40dd; x56410a8dd70087c6 != null; x56410a8dd70087c6 = x56410a8dd70087c6.xe41821af1989e791)
		{
			if (12803 == x56410a8dd70087c6.x5566e2d2acbd1fbe)
			{
				xc177d129f782d9e2 = 0;
				num = 0;
				x943e15f60160bae8 = null;
				flag = false;
			}
			else if (10754 == x56410a8dd70087c6.x5566e2d2acbd1fbe)
			{
				if (flag)
				{
					if (x943e15f60160bae8 == null)
					{
						x943e15f60160bae8 = x56410a8dd70087c6;
					}
					xc177d129f782d9e2 += x56410a8dd70087c6.x1be93eed8950d961;
				}
			}
			else if (9217 == x56410a8dd70087c6.x5566e2d2acbd1fbe)
			{
				flag = true;
				num = xc177d129f782d9e2;
			}
		}
		xc177d129f782d9e2 = num;
	}

	internal static void x98e6d5779680da6e(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		x56410a8dd70087c5 x56410a8dd70087c6 = x311e7a92306d7199.xdc3f248db6e996ed;
		int x8df91a2f90079e = ((x311e7a92306d7199.xdc3f248db6e996ed != x56410a8dd70087c6) ? x56410a8dd70087c6.x7f6ad514996fb03a.x419ba17a5322627b : 0);
		while (x56410a8dd70087c6 != null)
		{
			if (x56410a8dd70087c6.x5566e2d2acbd1fbe != 25604 || x56410a8dd70087c6.x34251722ab416841.x109e3389933c23a8.xab6edfb47ff0b74c == WrapType.Inline)
			{
				x56410a8dd70087c6.x8df91a2f90079e88 = x8df91a2f90079e;
				x56410a8dd70087c6.x32854f318cf1c144(0);
				x8df91a2f90079e = x56410a8dd70087c6.x419ba17a5322627b;
			}
			x56410a8dd70087c6 = x56410a8dd70087c6.xe41821af1989e791;
		}
	}

	internal static void x452d47656a81e83b(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		x56410a8dd70087c5 x56410a8dd70087c6 = x311e7a92306d7199.xdc3f248db6e996ed;
		int num = ((x311e7a92306d7199.xdc3f248db6e996ed == x56410a8dd70087c6) ? (x311e7a92306d7199.x419ba17a5322627b - x311e7a92306d7199.x2206903f9421fd4b().X) : x56410a8dd70087c6.x7f6ad514996fb03a.x419ba17a5322627b);
		while (x56410a8dd70087c6 != null)
		{
			if (x56410a8dd70087c6.x5566e2d2acbd1fbe != 25604 || x56410a8dd70087c6.x34251722ab416841.x109e3389933c23a8.xab6edfb47ff0b74c == WrapType.Inline)
			{
				x56410a8dd70087c6.x8df91a2f90079e88 = num - x56410a8dd70087c6.xdc1bf80853046136;
				x56410a8dd70087c6.x32854f318cf1c144(0);
				num = x56410a8dd70087c6.x8df91a2f90079e88;
			}
			x56410a8dd70087c6 = x56410a8dd70087c6.xe41821af1989e791;
		}
	}

	private static void x6601a79a48c35b7b(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		if (!x57d8fa44ac5b86c5(x311e7a92306d7199.x028068b313735e89))
		{
			return;
		}
		x1c575c5c2e116263(x311e7a92306d7199.xdc3f248db6e996ed, out var x943e15f60160bae, out var xc177d129f782d9e);
		if (0 >= xc177d129f782d9e)
		{
			return;
		}
		x56410a8dd70087c5 x56410a8dd70087c6 = x943e15f60160bae;
		int x8df91a2f90079e = x56410a8dd70087c6.x8df91a2f90079e88;
		int xbcea506a33cf = (x311e7a92306d7199.xdc1bf80853046136 - x64f2876ef9cfce05(x311e7a92306d7199.x0eafd527bd1e778e, x370968c2ea974ce4: false)) / xc177d129f782d9e;
		while (x56410a8dd70087c6 != null)
		{
			x56410a8dd70087c6.x8df91a2f90079e88 = x8df91a2f90079e;
			if (10754 == x56410a8dd70087c6.x5566e2d2acbd1fbe && xc177d129f782d9e > 0)
			{
				x56410a8dd70087c6.x32854f318cf1c144(xbcea506a33cf);
				xc177d129f782d9e -= x56410a8dd70087c6.x1be93eed8950d961;
			}
			x8df91a2f90079e = xfd32adc83f7de856.x82b7a775e4a72e79(x56410a8dd70087c6);
			x56410a8dd70087c6 = x56410a8dd70087c6.xe41821af1989e791;
		}
	}

	private static void xb074839806da7aa9(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		if (!x57d8fa44ac5b86c5(x311e7a92306d7199.x028068b313735e89))
		{
			return;
		}
		x1c575c5c2e116263(x311e7a92306d7199.xdc3f248db6e996ed, out var x943e15f60160bae, out var xc177d129f782d9e);
		if (0 >= xc177d129f782d9e)
		{
			return;
		}
		x56410a8dd70087c5 x56410a8dd70087c6 = x943e15f60160bae;
		int x8df91a2f90079e = x56410a8dd70087c6.x356a2a9a4e4fbfdd.x8df91a2f90079e88;
		int xbcea506a33cf = (x64f2876ef9cfce05(x311e7a92306d7199.x0eafd527bd1e778e, x370968c2ea974ce4: true) - x311e7a92306d7199.x8df91a2f90079e88 + x311e7a92306d7199.x2206903f9421fd4b().X) / xc177d129f782d9e;
		while (x56410a8dd70087c6 != null)
		{
			if (10754 == x56410a8dd70087c6.x5566e2d2acbd1fbe && xc177d129f782d9e > 0)
			{
				x56410a8dd70087c6.x32854f318cf1c144(xbcea506a33cf);
				xc177d129f782d9e -= x56410a8dd70087c6.x1be93eed8950d961;
			}
			x56410a8dd70087c6.x8df91a2f90079e88 = x8df91a2f90079e - x56410a8dd70087c6.xdc1bf80853046136;
			x8df91a2f90079e = x56410a8dd70087c6.x8df91a2f90079e88;
			x56410a8dd70087c6 = x56410a8dd70087c6.xe41821af1989e791;
		}
	}

	private static void x4c15c36e9dab37d2(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		x6601a79a48c35b7b(x311e7a92306d7199);
	}

	private static void x419ccc96626d243c(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		xb074839806da7aa9(x311e7a92306d7199);
	}

	private static bool x57d8fa44ac5b86c5(x56410a8dd70087c5 x2aa5114a5da7d6c8)
	{
		if (x5566e2d2acbd1fbe.x7e8d028aa606b4d3(x2aa5114a5da7d6c8.x5566e2d2acbd1fbe))
		{
			return false;
		}
		if (21537 == x2aa5114a5da7d6c8.x5566e2d2acbd1fbe)
		{
			return false;
		}
		if (21639 == x2aa5114a5da7d6c8.x5566e2d2acbd1fbe)
		{
			return false;
		}
		if (x5566e2d2acbd1fbe.xd707791130626739(x2aa5114a5da7d6c8.x5566e2d2acbd1fbe) && x2aa5114a5da7d6c8.x53111d6596d16a99 is x4af4ee0384f9176a)
		{
			return false;
		}
		if (x2aa5114a5da7d6c8.x5566e2d2acbd1fbe == 21514 && x5d30045af3da9a92.x17a739e2668bd353(x2aa5114a5da7d6c8.x406d8cd2af514771))
		{
			return false;
		}
		return true;
	}

	private static bool x319aaf89fcce8c8f(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x5566e2d2acbd1fbe != 10754 && x5906905c888d3d98.x5566e2d2acbd1fbe != 10782 && x5906905c888d3d98.x5566e2d2acbd1fbe != 10768 && x5906905c888d3d98.x5566e2d2acbd1fbe != 10770)
		{
			if (x5906905c888d3d98.x5566e2d2acbd1fbe == 10769)
			{
				return !xeb4e50fbcf3eb078(x5906905c888d3d98);
			}
			return false;
		}
		return true;
	}

	private static bool xeb4e50fbcf3eb078(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x2de24895ffc1e75d != null && x5906905c888d3d98.x2de24895ffc1e75d is x5c28fdcd27dee7d9)
		{
			return ((x5c28fdcd27dee7d9)x5906905c888d3d98.x2de24895ffc1e75d).xc96d173d58dd8a20 == FieldType.FieldFormTextInput;
		}
		return false;
	}
}
