using System;
using Aspose.Words.Fields;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x2d380f6141585930
{
	private const int x9700aad9bba3ce4a = -1;

	private readonly x5c928e5f0a98a22c xecc95f1d9e2a527a;

	private readonly x6ed66b5cf8da2955 xb965f36a141de102;

	private readonly x5e36356bc92c609b x02a9efce5fdffaef;

	private readonly xdbc94e34c2e61de1 xa0ba73c0b7473c7e = new xdbc94e34c2e61de1();

	private readonly xdbc94e34c2e61de1 x4cb222fc34c74767 = new xdbc94e34c2e61de1();

	private bool x5d4524dc09b6c7d7;

	private bool x21f190785b3e3036;

	private x98739d759efb5fe7 x7d80e07adf5858c7;

	private bool x2e024fd7a1249b69;

	private bool xbf127af17da750d9;

	private bool x3e61945adbb4ad79;

	private int x36870d156bdb5a69 = -1;

	private int x5062c3c4298b687a = -1;

	private bool x77c03c79c233f2cf
	{
		get
		{
			if (xecc95f1d9e2a527a.xd420ac3415caa02b == x1b9dfa914d94b6e0.x6fe652a9a79f74c7)
			{
				return xecc95f1d9e2a527a.xdb33379fd4e83768;
			}
			return false;
		}
	}

	private bool xee36d29c07b8fca1
	{
		get
		{
			if (!x21f190785b3e3036)
			{
				return x2e024fd7a1249b69;
			}
			return true;
		}
	}

	private bool xbfd984f469f0f82c => xb965f36a141de102.x3ecf81e56889c4af(x4cb222fc34c74767.xf9ad6fb78355fe13.ToLower()) != x9f6b815e19fa8f62.xf6c17f648b65c793;

	private xdbc94e34c2e61de1 xca93abf9292cd4f1
	{
		get
		{
			if (xbf127af17da750d9)
			{
				return x4cb222fc34c74767;
			}
			return xa0ba73c0b7473c7e;
		}
	}

	internal string xd420ac3415caa02b => xca93abf9292cd4f1.xf9ad6fb78355fe13;

	internal bool x2af81d05318e5fe2 => xbf127af17da750d9;

	internal int x609daf39d0822544
	{
		get
		{
			return x36870d156bdb5a69;
		}
		set
		{
			if (x36870d156bdb5a69 == -1)
			{
				x36870d156bdb5a69 = value;
			}
		}
	}

	internal int x55913a1dc35ee24c
	{
		get
		{
			return x5062c3c4298b687a;
		}
		set
		{
			if (x5062c3c4298b687a == -1)
			{
				x5062c3c4298b687a = value;
			}
		}
	}

	internal x2d380f6141585930(Field field, x6ed66b5cf8da2955 switchResolver)
		: this(new x8bdcbaf43f83522c(field, moveToFirstToken: true), field.x6edce55dcd2d335b, switchResolver)
	{
	}

	internal x2d380f6141585930(string fieldCode, x6ed66b5cf8da2955 switchResolver)
		: this(new xc2d10cc5ae93aafe(fieldCode, moveToFirstToken: true), null, switchResolver)
	{
	}

	private x2d380f6141585930(x5c928e5f0a98a22c tokenizer, x5e36356bc92c609b updateContext, x6ed66b5cf8da2955 switchResolver)
	{
		xecc95f1d9e2a527a = tokenizer;
		x02a9efce5fdffaef = updateContext;
		xb965f36a141de102 = switchResolver;
	}

	internal bool x2408a6db33935c93(bool x0bc1a2ec253ad36c)
	{
		if (x3e61945adbb4ad79)
		{
			return false;
		}
		if (!xbf127af17da750d9 && x4cb222fc34c74767.x149a4512fc76c776)
		{
			xbf127af17da750d9 = true;
			return true;
		}
		xa0ba73c0b7473c7e.xa9d636b00ff486b7();
		x4cb222fc34c74767.xa9d636b00ff486b7();
		x5d4524dc09b6c7d7 = false;
		xbf127af17da750d9 = false;
		bool flag = false;
		if (x21f190785b3e3036)
		{
			x1f96778a29980753();
		}
		if (x0bc1a2ec253ad36c)
		{
			x1c8bcfa3fef8c62c();
			x3e61945adbb4ad79 = true;
			return xa0ba73c0b7473c7e.x149a4512fc76c776;
		}
		while (!xecc95f1d9e2a527a.x0e410626c9576523)
		{
			if (!x77c03c79c233f2cf)
			{
				if (x42be32a552bb83b8())
				{
					x2a838433e35f890e();
					x9ed442c1833e090b();
					xecc95f1d9e2a527a.x2408a6db33935c93();
					return true;
				}
				if (xecc95f1d9e2a527a.xd420ac3415caa02b == x1b9dfa914d94b6e0.x6fe652a9a79f74c7)
				{
					if (xeff3895112e19c23(flag))
					{
						return true;
					}
					flag = !flag && xecc95f1d9e2a527a.x1efcac262b819134 == '\\';
				}
				else
				{
					x0ac7e8d3a2c63910();
				}
			}
			xecc95f1d9e2a527a.x2408a6db33935c93();
		}
		x9ed442c1833e090b();
		x3e61945adbb4ad79 = true;
		x2a838433e35f890e();
		return xa0ba73c0b7473c7e.x149a4512fc76c776;
	}

	private void x1c8bcfa3fef8c62c()
	{
		bool flag = false;
		xdbc94e34c2e61de1 xdbc94e34c2e61de2 = new xdbc94e34c2e61de1();
		while (!xecc95f1d9e2a527a.x0e410626c9576523)
		{
			if (!x77c03c79c233f2cf)
			{
				if (xecc95f1d9e2a527a.xd420ac3415caa02b == x1b9dfa914d94b6e0.x6fe652a9a79f74c7)
				{
					if (char.IsWhiteSpace(xecc95f1d9e2a527a.x1efcac262b819134))
					{
						if (flag)
						{
							xdbc94e34c2e61de2.x1f96778a29980753(xecc95f1d9e2a527a);
						}
					}
					else
					{
						flag = true;
						if (xdbc94e34c2e61de2.x149a4512fc76c776)
						{
							xa0ba73c0b7473c7e.x4e44137a7ec5c645(xdbc94e34c2e61de2);
						}
						x1f96778a29980753();
					}
				}
				else
				{
					flag = true;
					if (xdbc94e34c2e61de2.x149a4512fc76c776)
					{
						xa0ba73c0b7473c7e.x4e44137a7ec5c645(xdbc94e34c2e61de2);
					}
					x1f96778a29980753();
				}
			}
			xecc95f1d9e2a527a.x2408a6db33935c93();
		}
		x9ed442c1833e090b();
	}

	private bool x42be32a552bb83b8()
	{
		switch (xecc95f1d9e2a527a.xd420ac3415caa02b)
		{
		case x1b9dfa914d94b6e0.x6fe652a9a79f74c7:
			return false;
		case x1b9dfa914d94b6e0.xfdc1a17f479acc42:
			if (xecc95f1d9e2a527a.xdb33379fd4e83768)
			{
				return false;
			}
			return xd59a678ec2f6ac8a('\r');
		case x1b9dfa914d94b6e0.x10d7a1cae426b158:
			if (xecc95f1d9e2a527a.xdb33379fd4e83768)
			{
				return false;
			}
			return xd59a678ec2f6ac8a('\f');
		case x1b9dfa914d94b6e0.x4465bafc6dc0d5e5:
			x1f96778a29980753();
			return false;
		case x1b9dfa914d94b6e0.x50e8abecd48a6d6a:
			x2e024fd7a1249b69 = true;
			if (!x5d4524dc09b6c7d7)
			{
				x5d4524dc09b6c7d7 = true;
				return false;
			}
			return !x21f190785b3e3036;
		case x1b9dfa914d94b6e0.xc6c75be6e65e2ee9:
			x2e024fd7a1249b69 = false;
			return !x21f190785b3e3036;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void x0ac7e8d3a2c63910()
	{
		x2a838433e35f890e();
		switch (xecc95f1d9e2a527a.xd420ac3415caa02b)
		{
		case x1b9dfa914d94b6e0.x50e8abecd48a6d6a:
		case x1b9dfa914d94b6e0.xc6c75be6e65e2ee9:
			x1f96778a29980753();
			break;
		}
	}

	private bool xeff3895112e19c23(bool xfea447c457b29d12)
	{
		x609daf39d0822544 = xecc95f1d9e2a527a.x5eddc5de8738680a;
		x55913a1dc35ee24c = xecc95f1d9e2a527a.x885d577f7c56563e;
		char x1efcac262b = xecc95f1d9e2a527a.x1efcac262b819134;
		if (char.IsWhiteSpace(x1efcac262b))
		{
			return x3adc8ccba677f4c2();
		}
		switch (x1efcac262b)
		{
		case '"':
		case '“':
		case '”':
			return x06cb77e8aa7b2422(xfea447c457b29d12);
		case '\\':
			xeec706af7c9b3fbf(xfea447c457b29d12);
			return false;
		default:
			return x31367fe04c944205();
		}
	}

	private bool x3adc8ccba677f4c2()
	{
		if (!x5d4524dc09b6c7d7)
		{
			return false;
		}
		if (xee36d29c07b8fca1)
		{
			x1f96778a29980753();
			return false;
		}
		x2a838433e35f890e();
		x9ed442c1833e090b();
		return true;
	}

	private bool x06cb77e8aa7b2422(bool xfea447c457b29d12)
	{
		if (x667188f02a1c9fc9())
		{
			return false;
		}
		x2a838433e35f890e();
		if (x5d4524dc09b6c7d7)
		{
			if (!xfea447c457b29d12 && !x2e024fd7a1249b69)
			{
				if (x21f190785b3e3036)
				{
					x1f96778a29980753();
					x5d8401302a07c3c9();
					xead295c4ab561227();
				}
				else
				{
					x9ed442c1833e090b();
				}
				return true;
			}
			x1f96778a29980753();
		}
		else
		{
			x1f96778a29980753();
			xec1f7f6889aebe2b();
		}
		return false;
	}

	private void xeec706af7c9b3fbf(bool xfea447c457b29d12)
	{
		x2a838433e35f890e();
		if (!xfea447c457b29d12)
		{
			if (!x21f190785b3e3036)
			{
				xf7845a68c9dc7f21();
			}
			else
			{
				x1f96778a29980753();
			}
		}
		else
		{
			x1f96778a29980753();
		}
	}

	private bool x31367fe04c944205()
	{
		x1f96778a29980753();
		if (!x4cb222fc34c74767.x149a4512fc76c776)
		{
			return false;
		}
		if (x4cb222fc34c74767.x1be93eed8950d961 <= 3)
		{
			if (xbfd984f469f0f82c)
			{
				xbf127af17da750d9 = !xa0ba73c0b7473c7e.x149a4512fc76c776;
				xead295c4ab561227();
				return true;
			}
		}
		else
		{
			x2a838433e35f890e();
		}
		return false;
	}

	private bool xd59a678ec2f6ac8a(char x909d2e1880f228e8)
	{
		if (xee36d29c07b8fca1)
		{
			xa0ba73c0b7473c7e.x551aecbd188f3fc8(x909d2e1880f228e8);
			return false;
		}
		return x5d4524dc09b6c7d7;
	}

	private void x1f96778a29980753()
	{
		xdbc94e34c2e61de1 xdbc94e34c2e61de2 = ((!x4cb222fc34c74767.x149a4512fc76c776) ? xa0ba73c0b7473c7e : x4cb222fc34c74767);
		xdbc94e34c2e61de2.x1f96778a29980753(xecc95f1d9e2a527a);
		x5d4524dc09b6c7d7 = true;
	}

	private void xead295c4ab561227()
	{
		xecc95f1d9e2a527a.x2408a6db33935c93();
		x9ed442c1833e090b();
	}

	private void x9ed442c1833e090b()
	{
		xdbc94e34c2e61de1 xdbc94e34c2e61de2 = ((!x4cb222fc34c74767.x149a4512fc76c776) ? xa0ba73c0b7473c7e : x4cb222fc34c74767);
		xdbc94e34c2e61de2.x9ed442c1833e090b(xecc95f1d9e2a527a);
	}

	private void xf7845a68c9dc7f21()
	{
		x4cb222fc34c74767.xa9d636b00ff486b7();
		x4cb222fc34c74767.x1f96778a29980753(xecc95f1d9e2a527a);
		x5d4524dc09b6c7d7 = true;
	}

	private void x2a838433e35f890e()
	{
		xa0ba73c0b7473c7e.x4e44137a7ec5c645(x4cb222fc34c74767);
	}

	private void xec1f7f6889aebe2b()
	{
		x21f190785b3e3036 = true;
		if (x02a9efce5fdffaef != null)
		{
			x02a9efce5fdffaef.x06768d79f7751c4d = true;
		}
		x7d80e07adf5858c7 = xecc95f1d9e2a527a.x80766db8f9759629();
	}

	private void x5d8401302a07c3c9()
	{
		x21f190785b3e3036 = false;
		if (x02a9efce5fdffaef != null)
		{
			x02a9efce5fdffaef.x06768d79f7751c4d = false;
		}
		x7d80e07adf5858c7 = null;
	}

	private bool x667188f02a1c9fc9()
	{
		if (x7d80e07adf5858c7 == null)
		{
			return false;
		}
		if (x2b1ee3a87b36a988.xf36c5c9e57c969ad(x7d80e07adf5858c7.x40212106aad8a8b0) == x2b1ee3a87b36a988.xf36c5c9e57c969ad(xecc95f1d9e2a527a.x80766db8f9759629().x40212106aad8a8b0))
		{
			return false;
		}
		return true;
	}

	internal x7e263f21a73a027a x5ba1f3ac6b17bc97()
	{
		return xca93abf9292cd4f1.x451c3f5e0b9f8822();
	}
}
