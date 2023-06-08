using System;
using System.Collections;
using System.Reflection;
using x13f1efc79617a47b;
using x5794c252ba25e723;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace xf269d97e8a02e911;

[DefaultMember("Item")]
internal class xcf56b3bea2f7249b
{
	private const int xa1b64b4d4789d990 = int.MinValue;

	private const int x4c9acd0727e1546b = 19;

	private readonly Hashtable x82b70567a5f68f41 = new Hashtable();

	private readonly bool x80ff5b227156e289;

	private int xf37fd1d258b42ddd;

	internal xbadcaf18b423f918 xe6d4b1b411ed94b5 => (xbadcaf18b423f918)x82b70567a5f68f41[x45cb9c0352055524];

	internal xcf56b3bea2f7249b(bool isEmf)
	{
		x80ff5b227156e289 = isEmf;
	}

	internal void xd6b6ed77479ef68c(xbadcaf18b423f918 xbcea506a33cf9111)
	{
		int num2 = (x80ff5b227156e289 ? ((x82b70567a5f68f41.Count > 19) ? xbcea506a33cf9111.x7efbe0a2dc0d335f : (xbcea506a33cf9111.x7efbe0a2dc0d335f = xf37fd1d258b42ddd++ | int.MinValue)) : ((xbcea506a33cf9111 != null) ? xa2e3a0720b7478ce() : xf37fd1d258b42ddd++));
		x82b70567a5f68f41[num2] = xbcea506a33cf9111;
	}

	internal void xddae736767606eb7(int x45cb9c0352055524)
	{
		if (x80ff5b227156e289)
		{
			if ((x45cb9c0352055524 & int.MinValue) != int.MinValue)
			{
				x82b70567a5f68f41.Remove(x45cb9c0352055524);
			}
		}
		else
		{
			x82b70567a5f68f41[x45cb9c0352055524] = null;
		}
	}

	private int xa2e3a0720b7478ce()
	{
		for (int i = 0; i < x82b70567a5f68f41.Count; i++)
		{
			if (!x82b70567a5f68f41.ContainsKey(i))
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("aealddhljcolaafmmcmmmddnbeknjdboediocepoodgpiomplcealclanccbacjbjnpbjchcpbocpbfdbcmdkmcemakegbbfdbifnapfnagg", 1066512361)));
			}
			if (x82b70567a5f68f41[i] == null)
			{
				return i;
			}
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("abioacpofcgpnbnpibeagclapmbbpajbibaclbhcbbocebfdnllddadekakeelafaaifdapfppfgikmgepdhiokhpjbiooiiknpieogjknnjfnekljlk", 1576462273)));
	}

	public void x7580f567d0f62e46(int x7ddd62ebffe7c083)
	{
		for (uint num = 0u; num < x7ddd62ebffe7c083; num++)
		{
			xd6b6ed77479ef68c(null);
		}
	}

	private void xd3ee09a872ca7c0b(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		xb6b31e10a27b56a2 xb6b31e10a27b56a3 = new xb6b31e10a27b56a2();
		if (x6c50a99faab7d741 == x26d9ecb4bdf0456d.x45260ad4b94166f2)
		{
			xb6b31e10a27b56a3.xfe2178c1f916f36c = xf68da7ebd6244f01.xe6f652a9fd917f11;
		}
		else
		{
			xb6b31e10a27b56a3.x7dd793a62d047456 = x6c50a99faab7d741;
		}
		xd6b6ed77479ef68c(xb6b31e10a27b56a3);
	}

	private void xd273ca8c9b84ab71(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		xd8229e5e57d947ce xd8229e5e57d947ce2 = new xd8229e5e57d947ce();
		if (x6c50a99faab7d741 == x26d9ecb4bdf0456d.x45260ad4b94166f2)
		{
			xd8229e5e57d947ce2.xfe2178c1f916f36c = xd6748f351bb3d69f.xe6f652a9fd917f11;
		}
		else
		{
			xd8229e5e57d947ce2.x9b41425268471380 = x6c50a99faab7d741;
		}
		xd6b6ed77479ef68c(xd8229e5e57d947ce2);
	}

	private void x0d37f61a716921be(string x17167998f7765ea9)
	{
		x3cc1f6fa2c94cf17 x3cc1f6fa2c94cf18 = new x3cc1f6fa2c94cf17();
		x3cc1f6fa2c94cf18.x77a92edb600f019b = x17167998f7765ea9;
		xd6b6ed77479ef68c(x3cc1f6fa2c94cf18);
	}

	private void x729dea2c451ceb29()
	{
		x70b83e4b61cc9d8c xbcea506a33cf = new x70b83e4b61cc9d8c();
		xd6b6ed77479ef68c(xbcea506a33cf);
	}

	public void x4bff4a77ade69aa8()
	{
		xd3ee09a872ca7c0b(x26d9ecb4bdf0456d.x8f02f53f1587477d);
		xd3ee09a872ca7c0b(x26d9ecb4bdf0456d.x89fffa2751fdecbe);
		xd3ee09a872ca7c0b(x26d9ecb4bdf0456d.xfaad9cc1bd5f71bd);
		xd3ee09a872ca7c0b(new x26d9ecb4bdf0456d(64, 64, 64));
		xd3ee09a872ca7c0b(x26d9ecb4bdf0456d.x89fffa2751fdecbe);
		xd3ee09a872ca7c0b(x26d9ecb4bdf0456d.x45260ad4b94166f2);
		xd273ca8c9b84ab71(x26d9ecb4bdf0456d.x8f02f53f1587477d);
		xd273ca8c9b84ab71(x26d9ecb4bdf0456d.x89fffa2751fdecbe);
		xd273ca8c9b84ab71(x26d9ecb4bdf0456d.x45260ad4b94166f2);
		xd273ca8c9b84ab71(x26d9ecb4bdf0456d.x45260ad4b94166f2);
		x0d37f61a716921be("Microsoft Sans Serif");
		x0d37f61a716921be("Courier New");
		x0d37f61a716921be("Microsoft Sans Serif");
		x0d37f61a716921be("Tahoma");
		x0d37f61a716921be("Microsoft Sans Serif");
		xd6b6ed77479ef68c(new xa74bf384c260fbb4());
		x0d37f61a716921be("Microsoft Sans Serif");
		x0d37f61a716921be("Microsoft Sans Serif");
		x729dea2c451ceb29();
		x729dea2c451ceb29();
	}
}
