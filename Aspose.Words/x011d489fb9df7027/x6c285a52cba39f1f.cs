using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x011d489fb9df7027;

internal class x6c285a52cba39f1f
{
	private readonly x7b71245a33212e76 xc454c03c23d4b4d9;

	internal static readonly x26d9ecb4bdf0456d xf834c2490de2a834 = x26d9ecb4bdf0456d.xfaad9cc1bd5f71bd;

	internal bool x173949c9cf8653ad
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(948);
		}
		set
		{
			xae20093bed1e48a8(948, value);
		}
	}

	internal bool xeba9aeb9e91e933a
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(947);
		}
		set
		{
			xae20093bed1e48a8(947, value);
		}
	}

	internal bool xd1fa05894bebebb2
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(946);
		}
		set
		{
			xae20093bed1e48a8(946, value);
		}
	}

	internal x206d87dc07f8c9e2 xceaa36575b797b5b
	{
		get
		{
			return (x206d87dc07f8c9e2)xfe91eeeafcb3026a(916);
		}
		set
		{
			xae20093bed1e48a8(916, value);
		}
	}

	internal double x9472539ef71e166c
	{
		get
		{
			return x3522d1b55b1aa13a((int)xfe91eeeafcb3026a(915));
		}
		set
		{
			x9b2d49211fe2676f(value, x9199ed88324d69ff: true);
		}
	}

	internal x6c285a52cba39f1f(x7b71245a33212e76 parent)
	{
		xc454c03c23d4b4d9 = parent;
	}

	internal void x7037cdd058db3069(double xbcea506a33cf9111)
	{
		x9b2d49211fe2676f(xbcea506a33cf9111, x9199ed88324d69ff: false);
	}

	private void x9b2d49211fe2676f(double xbcea506a33cf9111, bool x9199ed88324d69ff)
	{
		xbcea506a33cf9111 = x0d299f323d241756.x0b2d7be73d532b1c(xbcea506a33cf9111, 0.0, 0.0, 100.0, 100.0, x9199ed88324d69ff, "percent");
		xae20093bed1e48a8(915, x6f8eceb0c1380921(xbcea506a33cf9111));
	}

	private static double x3522d1b55b1aa13a(int xbcea506a33cf9111)
	{
		return (double)xbcea506a33cf9111 / 10.0;
	}

	private static int x6f8eceb0c1380921(double xbcea506a33cf9111)
	{
		return (int)(xbcea506a33cf9111 * 10.0);
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xfc928672852cc4c4(xba08ce632055a1d9);
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.x0817d5cde9e19bf6(xba08ce632055a1d9, xbcea506a33cf9111);
	}
}
