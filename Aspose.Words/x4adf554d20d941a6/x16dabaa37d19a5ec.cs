using System;
using Aspose.Words;

namespace x4adf554d20d941a6;

internal class x16dabaa37d19a5ec : xe0e644109215bf44
{
	internal override x398b3bd0acd94b61 x8b8a0a04b3aeaf3a => base.xa51d8d9790431b2b.x8b8a0a04b3aeaf3a;

	internal override x398b3bd0acd94b61 x7e2e5dd40daabc3b => base.x88fee64dba8223f9.x7e2e5dd40daabc3b;

	internal x56410a8dd70087c5 x465c7a263669f01c => x74fa1578db7c0c8f();

	internal x4af4ee0384f9176a x60c79c2c8163b21e => (x4af4ee0384f9176a)base.x332a8eedb847940d;

	internal override x1073233de8252b3e x8db1e90bce56e416(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		switch (xd7e5673853e47af4.x954503abc583f675)
		{
		case x954503abc583f675.xa19781cfbe8b4961:
		case x954503abc583f675.x48cc0c3eaf9f5f05:
		{
			x852fe8bb5ac31098 xe3e287548b3d01f = (x852fe8bb5ac31098)x465c7a263669f01c.xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad);
			return x60c79c2c8163b21e.x6160b752f2880dec(xe3e287548b3d01f, x502d59bacbd3e16e: true);
		}
		default:
			throw new InvalidOperationException("Unexpected part type.");
		}
	}

	internal override void x3df13c9311a0ba9b(xc63cc34daaa2e2d9 x0e990edf4549ee50)
	{
		base.x3df13c9311a0ba9b(x0e990edf4549ee50);
		x83fc89c2d7233276();
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x961a58a547e7668e(this);
	}

	internal static x56410a8dd70087c5 x22e642b5dff41b56(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		x16dabaa37d19a5ec x16dabaa37d19a5ec2 = (x16dabaa37d19a5ec)xd7e5673853e47af4.x332a8eedb847940d.x5c76a7629364cf4d(x5a5e07e9fa12451a.x10d7a1cae426b158);
		return x16dabaa37d19a5ec2.x465c7a263669f01c;
	}

	internal x398b3bd0acd94b61 xd9bfb81dd869f843()
	{
		xc63cc34daaa2e2d9 x5d6d04c35215bc = base.xa51d8d9790431b2b;
		if (x5d6d04c35215bc.x5a5e07e9fa12451a == x5a5e07e9fa12451a.x25af49e7b49ea0bc)
		{
			x5d6d04c35215bc = ((x7c1e2b821e8b8220)x5d6d04c35215bc).x5d6d04c35215bc51;
		}
		return x5d6d04c35215bc.x8b8a0a04b3aeaf3a;
	}

	internal x398b3bd0acd94b61 x7a2e26be4dfae7f2()
	{
		xc63cc34daaa2e2d9 xbc3a1ad7f75a88f = base.x88fee64dba8223f9;
		if (xbc3a1ad7f75a88f.x5a5e07e9fa12451a == x5a5e07e9fa12451a.x25af49e7b49ea0bc)
		{
			xbc3a1ad7f75a88f = ((x7c1e2b821e8b8220)xbc3a1ad7f75a88f).xbc3a1ad7f75a88f9;
		}
		return xbc3a1ad7f75a88f.x7e2e5dd40daabc3b;
	}

	internal static x852fe8bb5ac31098 x5658a0bfd852524d(x852fe8bb5ac31098 xe3e287548b3d01f5, StoryType xdbbf47b5e620c262)
	{
		switch (xdbbf47b5e620c262)
		{
		case StoryType.Footnotes:
		{
			for (x852fe8bb5ac31098 xa7cb6e8d24f405a = xe3e287548b3d01f5.xa7cb6e8d24f405a4; xa7cb6e8d24f405a != null; xa7cb6e8d24f405a = xa7cb6e8d24f405a.xa7cb6e8d24f405a4)
			{
				if (xa7cb6e8d24f405a.x69d28a4aeef83a6f != null)
				{
					return xa7cb6e8d24f405a;
				}
			}
			break;
		}
		case StoryType.Endnotes:
		{
			for (x852fe8bb5ac31098 x852fe8bb5ac31099 = xe3e287548b3d01f5.xf26f3fd618be2d13(); x852fe8bb5ac31099 != null; x852fe8bb5ac31099 = x852fe8bb5ac31099.xf26f3fd618be2d13())
			{
				if (x852fe8bb5ac31099.xd90ac7fcbe961761 != null)
				{
					return x852fe8bb5ac31099;
				}
			}
			break;
		}
		default:
			throw new InvalidOperationException("Unexpected story type.");
		}
		return null;
	}
}
