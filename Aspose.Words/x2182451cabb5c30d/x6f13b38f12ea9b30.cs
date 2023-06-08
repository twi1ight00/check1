namespace x2182451cabb5c30d;

internal class x6f13b38f12ea9b30 : x3b57052406b93b82
{
	internal x6f13b38f12ea9b30(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xd1b40af56a8385d4:
			base.xe1410f585439c7d4.xcf72734b7092bebe();
			break;
		case x25099a8bbbd55d1c.xe93eb88030ad2248:
			base.xe1410f585439c7d4.x094e1db5f87bb62b(null);
			break;
		default:
			base.x41e7a76e7e854e6e(x153c99a852375422);
			break;
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.xd1b40af56a8385d4)
		{
			base.xe1410f585439c7d4.x3bb349c77392b35c();
		}
		else
		{
			base.xa4085ff83f9ddeeb();
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\flddirty":
			if (base.xe1410f585439c7d4.x3336ddd58ad28d89 != null)
			{
				base.xe1410f585439c7d4.x3336ddd58ad28d89.x6e94079169d5a06e = true;
			}
			break;
		case "\\fldlock":
			if (base.xe1410f585439c7d4.x3336ddd58ad28d89 != null)
			{
				base.xe1410f585439c7d4.x3336ddd58ad28d89.IsLocked = true;
			}
			break;
		case "\\fldedit":
		case "\\fldpriv":
			x28fcdc775a1d069c.xbd5e5733680bbfc8(x153c99a852375422.x1dafd189c5465293());
			break;
		default:
			base.xa2d8e36cb99ac0f4(x153c99a852375422);
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x985dd08fd338eeea:
		case x25099a8bbbd55d1c.xe93eb88030ad2248:
			return this;
		case x25099a8bbbd55d1c.x8119232d8a051462:
		case x25099a8bbbd55d1c.xe371885afc332af6:
		case x25099a8bbbd55d1c.xa02784f65694ca5f:
		case x25099a8bbbd55d1c.x244ef638ba612102:
		case x25099a8bbbd55d1c.x0498ce72dad89268:
		case x25099a8bbbd55d1c.x70db6c6c5d95991c:
		case x25099a8bbbd55d1c.x18a8ea22afe9348e:
		case x25099a8bbbd55d1c.xece13b02cb4b1216:
			return new x69c31a748f1ec0d5(x28fcdc775a1d069c);
		default:
			return base.x3e0bce851c12a688(x8d3f74e5f925679c);
		}
	}
}
