using System.Collections;
using Aspose.Words.Saving;

namespace x59d6a4fc5007b7a4;

internal class xa4665f59f0cb55bd
{
	private const int xd7a784a0ae986a62 = -1;

	private int xa0ec25c81547b246 = -1;

	private bool x3c98b8b51d5e258b;

	private readonly x91866f79774c2b6a x4a5a7d4a04c16783;

	internal string x35cfcea4890f4e7d
	{
		get
		{
			if (x7fdaa0d587ece54a)
			{
				x6cfb41b4bd00d940();
			}
			if (x4c197751d7571602)
			{
				xa0ec25c81547b246 = xb2917ec9757c4b01.Length;
				return null;
			}
			if (!x3c98b8b51d5e258b)
			{
				xd22cb714335f8d2c();
			}
			return xb2917ec9757c4b01[xa0ec25c81547b246];
		}
	}

	private string[] xb2917ec9757c4b01 => x4a5a7d4a04c16783.xa1a7cce7c5e4a4dc.xb2917ec9757c4b01;

	private bool x7fdaa0d587ece54a => xa0ec25c81547b246 == -1;

	private bool x4c197751d7571602 => xa0ec25c81547b246 >= xb2917ec9757c4b01.Length;

	internal xa4665f59f0cb55bd(x91866f79774c2b6a shapingWorkspace)
	{
		x4a5a7d4a04c16783 = shapingWorkspace;
	}

	internal bool x47f176deff0d42e2()
	{
		return ++xa0ec25c81547b246 < xb2917ec9757c4b01.Length;
	}

	internal static void xaa12240713c4e5bd(x4e23280611779ac3 xf12e60079a6c0aac, NumeralFormat x01d59ab59d3bce7c)
	{
		if (xf12e60079a6c0aac.x18dbf113276025ae)
		{
			xf12e60079a6c0aac.xf9ad6fb78355fe13 = xcfba8d945135c03d.x550781f8db1cf5f2(xf12e60079a6c0aac.xf9ad6fb78355fe13);
		}
		if (x34a37b5a89c466fd.x2a3e4106546123a1(xf12e60079a6c0aac.xf9ad6fb78355fe13[0]) && x45e2219c0e324605.x5987bcde09b106d1(x01d59ab59d3bce7c, xf12e60079a6c0aac.x3a7473f820dd300b, xf12e60079a6c0aac.xa59ac2c936c6b7bd))
		{
			xf12e60079a6c0aac.xf9ad6fb78355fe13 = x45e2219c0e324605.x550781f8db1cf5f2(xf12e60079a6c0aac.xf9ad6fb78355fe13, x01d59ab59d3bce7c, xf12e60079a6c0aac.x3a7473f820dd300b, xf12e60079a6c0aac.xa59ac2c936c6b7bd);
			xf12e60079a6c0aac.x3a7473f820dd300b = true;
		}
	}

	private void x6cfb41b4bd00d940()
	{
		xa0ec25c81547b246 = 0;
	}

	private void xd22cb714335f8d2c()
	{
		xf02702475fd1ff5e xf02702475fd1ff5e2 = new xf02702475fd1ff5e(x4a5a7d4a04c16783);
		xf02702475fd1ff5e2.x550781f8db1cf5f2();
		if (x4a5a7d4a04c16783.xd557958daa1f35fe.xcafcc3652239eeaf)
		{
			x4ff46dee511e4d3b();
		}
		x3c98b8b51d5e258b = true;
	}

	private void x4ff46dee511e4d3b()
	{
		xd557958daa1f35fe xd557958daa1f35fe2 = x4a5a7d4a04c16783.xd557958daa1f35fe;
		ArrayList arrayList = new ArrayList();
		if (xd557958daa1f35fe2.x63bd8d89cde0bbe8(x838b2dfd1391264c.x18f02ac63e62140a))
		{
			arrayList.Add(new x7e6545cb3fcd6d55(x4a5a7d4a04c16783));
		}
		if (xd557958daa1f35fe2.x63bd8d89cde0bbe8(x838b2dfd1391264c.x93242aad8aceb97c))
		{
			arrayList.Add(new x83858aacbae91983(x4a5a7d4a04c16783));
		}
		foreach (xc2469d942acfbc3d item in arrayList)
		{
			item.x550781f8db1cf5f2();
		}
	}
}
