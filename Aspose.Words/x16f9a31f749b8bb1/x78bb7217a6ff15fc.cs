using System;
using System.Collections;
using Aspose.Words;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;
using xa604c4d210ae0581;

namespace x16f9a31f749b8bb1;

internal class x78bb7217a6ff15fc
{
	private readonly xa3ed3b2cd8f77351 x36d78faca8ad62db;

	private int xc384acb8ea9a831e;

	private readonly ArrayList x9ae842c98bb1e452 = new ArrayList();

	internal xcf0e7d2892f7a07d xcb7eb66829544493
	{
		get
		{
			if (x9ae842c98bb1e452.Count > 0)
			{
				return (xcf0e7d2892f7a07d)x9ae842c98bb1e452[x9ae842c98bb1e452.Count - 1];
			}
			return xcf0e7d2892f7a07d.x4d0b9d4447ba7566;
		}
		set
		{
			x9ae842c98bb1e452[x9ae842c98bb1e452.Count - 1] = value;
		}
	}

	internal x78bb7217a6ff15fc(xa3ed3b2cd8f77351 listener)
	{
		x36d78faca8ad62db = listener;
	}

	internal void xc3c9900b924c2d77(x6ace28180a74825a x94736b9db6910973)
	{
		if (x94736b9db6910973.xb8414804f39a9e90 > xc384acb8ea9a831e)
		{
			xe18e3367142a821d(x94736b9db6910973);
		}
		else if (x94736b9db6910973.xb8414804f39a9e90 < xc384acb8ea9a831e)
		{
			xbef07dd2c6913a8b(x94736b9db6910973);
		}
		else if (x94736b9db6910973.xb8414804f39a9e90 > 0 && !x94736b9db6910973.xd39cb952ead8cd7a)
		{
			x250ae5c9fa2b5462();
		}
	}

	internal void x3288e13b0258c322(x6ace28180a74825a x94736b9db6910973, xedb0eb766e25e0c9 xe193ceb565ecaa0a, char xb74a2158c6f43227)
	{
		if (x94736b9db6910973.xd39cb952ead8cd7a)
		{
			x9c1190c4a7a3b8bc(xe193ceb565ecaa0a);
		}
		else if (xb74a2158c6f43227 == '\a' || x94736b9db6910973.x521051256585691d)
		{
			x242dd382bbf39fb2();
		}
	}

	private void xe18e3367142a821d(x6ace28180a74825a x94736b9db6910973)
	{
		if (xc384acb8ea9a831e > 0)
		{
			x250ae5c9fa2b5462();
		}
		while (xc384acb8ea9a831e < x94736b9db6910973.xb8414804f39a9e90)
		{
			x36d78faca8ad62db.x751f41e8113776ff();
			x1914eddf1fde1228(xcf0e7d2892f7a07d.x2d6a2917055d6f8b);
			x250ae5c9fa2b5462();
			xc384acb8ea9a831e++;
		}
	}

	private void xbef07dd2c6913a8b(x6ace28180a74825a x94736b9db6910973)
	{
		if (xcb7eb66829544493 == xcf0e7d2892f7a07d.x2f05f7a24ceff75c)
		{
			x3dc950453374051a("Unexpected end of table, ignored.");
			x94736b9db6910973.xb8414804f39a9e90 = xc384acb8ea9a831e;
			return;
		}
		if (xcb7eb66829544493 == xcf0e7d2892f7a07d.xeb397955ada4f074)
		{
			x3dc950453374051a("Unexpected end of table, ignored.");
			x250ae5c9fa2b5462();
			x94736b9db6910973.xb8414804f39a9e90 = xc384acb8ea9a831e;
			return;
		}
		if (x94736b9db6910973.xb8414804f39a9e90 + 1 != xc384acb8ea9a831e)
		{
			x3dc950453374051a("Table end is at an incorrect nesting level.");
		}
		if (xcb7eb66829544493 != xcf0e7d2892f7a07d.x2d6a2917055d6f8b)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nokohpbpfpipmpppcpgakknakpebjolbgocclojcljadmohdeoodcjfebnmebndfjikfimbgemigempgjmghdnnhhheiklliamcjamjjilaknkhkjkokahfl", 2054285977)));
		}
		x36d78faca8ad62db.x48bcfa796334770b();
		x47c79a4d207183de();
		xc384acb8ea9a831e--;
	}

	private void x9c1190c4a7a3b8bc(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		if (xcb7eb66829544493 == xcf0e7d2892f7a07d.x2f05f7a24ceff75c)
		{
			x242dd382bbf39fb2();
		}
		if (xcb7eb66829544493 == xcf0e7d2892f7a07d.x2d6a2917055d6f8b)
		{
			x3dc950453374051a("Unexpected end of row, ignored.");
			return;
		}
		x36d78faca8ad62db.xda9f27edd6acffc8(xe193ceb565ecaa0a);
		xcb7eb66829544493 = xcf0e7d2892f7a07d.x2d6a2917055d6f8b;
	}

	private void x242dd382bbf39fb2()
	{
		if (xcb7eb66829544493 != 0)
		{
			if (xcb7eb66829544493 != xcf0e7d2892f7a07d.x2f05f7a24ceff75c)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gmbgmniganpgaoghfnnhhmeicmliancjoljjklakdhhkemokokflmkmldldmjkkmbgbnblinpkpnjjgojknohjeppelpnicanjjageabhjhbiiobcifckdmcmhddcikdfhbeociekhpeoggffcnfgheghglgbgchjbjhjfaiifhimfoijffjibmj", 484532593)));
			}
			x36d78faca8ad62db.x1faff6adf1093081();
			xcb7eb66829544493 = xcf0e7d2892f7a07d.xeb397955ada4f074;
		}
	}

	private void x250ae5c9fa2b5462()
	{
		if (xcb7eb66829544493 == xcf0e7d2892f7a07d.x2d6a2917055d6f8b)
		{
			x36d78faca8ad62db.x2640a8e9621a900d();
			xcb7eb66829544493 = xcf0e7d2892f7a07d.xeb397955ada4f074;
		}
		if (xcb7eb66829544493 == xcf0e7d2892f7a07d.xeb397955ada4f074)
		{
			x36d78faca8ad62db.x87e79416bec3e451();
			xcb7eb66829544493 = xcf0e7d2892f7a07d.x2f05f7a24ceff75c;
		}
	}

	private void x1914eddf1fde1228(xcf0e7d2892f7a07d x8fa7bad8f6d53176)
	{
		x9ae842c98bb1e452.Add(x8fa7bad8f6d53176);
	}

	private void x47c79a4d207183de()
	{
		x9ae842c98bb1e452.RemoveAt(x9ae842c98bb1e452.Count - 1);
	}

	private void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		x36d78faca8ad62db.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, xc2358fbac7da3d45);
	}
}
