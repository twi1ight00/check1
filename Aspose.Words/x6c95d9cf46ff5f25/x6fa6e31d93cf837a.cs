using System;
using System.Collections;
using x13f1efc79617a47b;

namespace x6c95d9cf46ff5f25;

internal class x6fa6e31d93cf837a
{
	private readonly xd8cce4761dc846ee x1fe9d199bfe5160a = new xd8cce4761dc846ee();

	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public int x0bcabe1c3230f8a6 => x1fe9d199bfe5160a.get_xe6d4b1b411ed94b5(0);

	public int xe7417f6a11716af5
	{
		get
		{
			if (x1fe9d199bfe5160a.xd44988f225497f3a > 0)
			{
				return x1fe9d199bfe5160a.get_xe6d4b1b411ed94b5(x1fe9d199bfe5160a.xd44988f225497f3a - 1);
			}
			return 0;
		}
		set
		{
			x1fe9d199bfe5160a.set_xe6d4b1b411ed94b5(x1fe9d199bfe5160a.xd44988f225497f3a - 1, value);
		}
	}

	public int x82b0eb36012eef83 => x1fe9d199bfe5160a.xd44988f225497f3a;

	public int x23719734cf1f138c => x82b70567a5f68f41.Count;

	public int xd6b6ed77479ef68c(int x10aaa7cdfa38f254, int xca09b6c2b5b18485, object xccb63ca5f63dc470)
	{
		if (x1fe9d199bfe5160a.xd44988f225497f3a == 0)
		{
			x1fe9d199bfe5160a.xd6b6ed77479ef68c(x10aaa7cdfa38f254);
		}
		return xd6b6ed77479ef68c(xca09b6c2b5b18485, xccb63ca5f63dc470);
	}

	public int xd6b6ed77479ef68c(int x10aaa7cdfa38f254, object xccb63ca5f63dc470)
	{
		x1fe9d199bfe5160a.xd6b6ed77479ef68c(x10aaa7cdfa38f254);
		return x82b70567a5f68f41.Add(xccb63ca5f63dc470);
	}

	public void xd6b6ed77479ef68c(int x13d4cb8d1bd20347)
	{
		x1fe9d199bfe5160a.xd6b6ed77479ef68c(x13d4cb8d1bd20347);
	}

	public void x7121e9e177952651(int xc0c4c459c6ccbd00)
	{
		x1fe9d199bfe5160a.x7121e9e177952651(xc0c4c459c6ccbd00);
		x82b70567a5f68f41.RemoveAt(xc0c4c459c6ccbd00);
	}

	public void xa9d636b00ff486b7()
	{
		x1fe9d199bfe5160a.xa9d636b00ff486b7();
		x82b70567a5f68f41.Clear();
	}

	public int x11fb6e5bb55209b1(int x13d4cb8d1bd20347)
	{
		int num = x792b6f092cbf4bb1(x13d4cb8d1bd20347, xcfa33d2df024e5bc: false);
		if (num < 0)
		{
			if (x1fe9d199bfe5160a.xd44988f225497f3a <= 1)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("aiailjhifkoickfjakmjckdklekkoibloiilajpldigmmdnmkheneilnddcofhjolhapohhpjhopnhfabcmaegdbkgkbkgbcfbicggpchfgdbfndjaeejfledfcffejfaeagdehgndogndfhgdmhcddilojiidbjedijfdpjicgkadnkccelfcllbccmanimgbanibhnhmnnibfojamodadplljpioaabohafnoafnfbklmb", 629309501)));
			}
			num = x1fe9d199bfe5160a.xd44988f225497f3a - 2;
		}
		return num;
	}

	public int xd888124d3245cd86(int x13d4cb8d1bd20347)
	{
		return x792b6f092cbf4bb1(x13d4cb8d1bd20347, xcfa33d2df024e5bc: true);
	}

	public int x0ed62813cc2c183e(int x13d4cb8d1bd20347)
	{
		return x1fe9d199bfe5160a.x792b6f092cbf4bb1(x13d4cb8d1bd20347);
	}

	public int x4216d54b5cd25bfa(int x13d4cb8d1bd20347)
	{
		int num = xd888124d3245cd86(x13d4cb8d1bd20347);
		if (num < 0)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nikhikbicliipkpinkgjpknjifekljlkljclnjjlajamjehmhiombjfnaemncidoiikolibpgiipkippocgabhnahhebhhlbccccdhjcegadofhdgbodggfeagmecfdfnekfafbgkeigkepgdeghpdnhipdifelibecjcejjfdakndhkpcokcdflocmlnncmdckmfcbnenhnfcpngbgoabnoimdpfpkpoobacoiacopahmgb", 1782217290)));
		}
		return num;
	}

	public x8c4ac77eaef388b9 xca89f32a7f7f5d50(int x13d4cb8d1bd20347)
	{
		for (int i = 0; i < x1fe9d199bfe5160a.xd44988f225497f3a; i++)
		{
			if (x1fe9d199bfe5160a.get_xe6d4b1b411ed94b5(i) >= x13d4cb8d1bd20347)
			{
				return new x8c4ac77eaef388b9(this, i, x1fe9d199bfe5160a.get_xe6d4b1b411ed94b5(i));
			}
		}
		return new x8c4ac77eaef388b9(this, int.MaxValue, int.MaxValue);
	}

	public int xed8a0d4499d6f292(int xc0c4c459c6ccbd00)
	{
		return x1fe9d199bfe5160a.get_xe6d4b1b411ed94b5(xc0c4c459c6ccbd00);
	}

	public void x6d93cc54d095824a(int xc0c4c459c6ccbd00, int x13d4cb8d1bd20347)
	{
		x1fe9d199bfe5160a.set_xe6d4b1b411ed94b5(xc0c4c459c6ccbd00, x13d4cb8d1bd20347);
	}

	public object xe84e6ff66aac2a0e(int xc0c4c459c6ccbd00)
	{
		return x82b70567a5f68f41[xc0c4c459c6ccbd00];
	}

	public override string ToString()
	{
		return x1fe9d199bfe5160a.ToString();
	}

	private int x792b6f092cbf4bb1(int x30cc7819189f11b6, bool xcfa33d2df024e5bc)
	{
		int num = 0;
		int num2 = x1fe9d199bfe5160a.xd44988f225497f3a - 1;
		num2--;
		while (num <= num2)
		{
			int num3 = num + num2 >> 1;
			int num4 = x1fe9d199bfe5160a.get_xe6d4b1b411ed94b5(num3);
			int num5 = x1fe9d199bfe5160a.get_xe6d4b1b411ed94b5(num3 + 1);
			if (x30cc7819189f11b6 < num4)
			{
				num2 = num3 - 1;
				continue;
			}
			if (x30cc7819189f11b6 >= num5)
			{
				num = num3 + 1;
				continue;
			}
			if (x30cc7819189f11b6 == num4)
			{
				return num3;
			}
			if (!xcfa33d2df024e5bc)
			{
				return num3;
			}
			return ~num;
		}
		return ~num;
	}
}
