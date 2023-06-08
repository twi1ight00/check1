using System;
using Aspose.Words;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x92361dccfa0347fd : x61ebdec02c254c25
{
	private xe0e644109215bf44 x5711ab82d2ac48d0;

	private readonly Footnote x48154453a08515ea;

	private int x331f83c9dde96ef3;

	private int x855d5edd1bc65bc9;

	internal override int x1be93eed8950d961 => 1;

	internal override string xf9ad6fb78355fe13
	{
		get
		{
			if (base.x332a8eedb847940d == null)
			{
				return "";
			}
			if (x37201fd6c5382fb2)
			{
				return x48154453a08515ea.x715a8c5c33fdc1a6;
			}
			xacf1bb6be5092987 xf48cd6e82340ac = ((xf6689e0eed33812c)base.x332a8eedb847940d.x2cbc0fc707d2e1eb()).xf48cd6e82340ac70;
			return x00b47748a95c9437.x19fa8583862b446b(x5138ebdd7c56c151(xc0a853db762872fe == StoryType.Footnotes), (xc0a853db762872fe == StoryType.Footnotes) ? xf48cd6e82340ac.x670f34a544b33166 : xf48cd6e82340ac.x668b67a105558a3f, x3b747bc7816d8768: true);
		}
	}

	internal bool x37201fd6c5382fb2
	{
		get
		{
			if (!x48154453a08515ea.xa72bf798a679c0aa)
			{
				return x0d299f323d241756.x5959bccb67bbf051(x48154453a08515ea.x715a8c5c33fdc1a6);
			}
			return false;
		}
	}

	internal override StoryType xc0a853db762872fe => x48154453a08515ea.StoryType;

	internal override x6e414db5d060a816 x6e414db5d060a816 => x6e414db5d060a816.x865739e9b580d3cf;

	internal override xfc6971c7d8314663 xfc6971c7d8314663 => xfc6971c7d8314663.xe9605a4bea014f21;

	internal override xe0e644109215bf44 x4397a67a49a78a04
	{
		get
		{
			if (x5711ab82d2ac48d0 == null && base.x332a8eedb847940d != null)
			{
				x5711ab82d2ac48d0 = base.x897301f2e0967b6d.x332a8eedb847940d.x2cbc0fc707d2e1eb();
			}
			return x5711ab82d2ac48d0;
		}
		set
		{
			x5711ab82d2ac48d0 = value;
		}
	}

	private int x58b388792ab34f8f
	{
		get
		{
			if (x331f83c9dde96ef3 == 0)
			{
				x92361dccfa0347fd x92361dccfa0347fd2 = x47acc756f6e7467c(21639);
				x331f83c9dde96ef3 = ((x92361dccfa0347fd2 != null) ? (x92361dccfa0347fd2.x58b388792ab34f8f + 1) : 0);
			}
			return x331f83c9dde96ef3;
		}
	}

	private int x67c42a3ac65864dc
	{
		get
		{
			if (x855d5edd1bc65bc9 == 0)
			{
				x92361dccfa0347fd x92361dccfa0347fd2 = x47acc756f6e7467c(21857);
				x855d5edd1bc65bc9 = ((x92361dccfa0347fd2 != null) ? (x92361dccfa0347fd2.x67c42a3ac65864dc + 1) : 0);
			}
			return x855d5edd1bc65bc9;
		}
	}

	internal x92361dccfa0347fd(Footnote node)
		: base(9217)
	{
		x48154453a08515ea = node;
	}

	internal override void x3e04636bf524a4cf(xb9e48f11d7f06ec9 x27f5ecb735ac9676)
	{
		if (x27f5ecb735ac9676 == xb9e48f11d7f06ec9.x56410a8dd70087c5)
		{
			for (xe0e644109215bf44 x185a13a95379e46d = x4397a67a49a78a04; x185a13a95379e46d != null; x185a13a95379e46d = x185a13a95379e46d.x185a13a95379e46d)
			{
				x16dabaa37d19a5ec x16dabaa37d19a5ec2 = (x16dabaa37d19a5ec)x185a13a95379e46d;
				x92361dccfa0347fd x92361dccfa0347fd2 = (x92361dccfa0347fd)x16dabaa37d19a5ec2.x465c7a263669f01c;
				x92361dccfa0347fd2.x331f83c9dde96ef3 = 0;
				x92361dccfa0347fd2.x855d5edd1bc65bc9 = 0;
			}
		}
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new x92361dccfa0347fd(x48154453a08515ea);
		}
		x7d95d971d8923f4c.x4397a67a49a78a04 = x4397a67a49a78a04;
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.xd6f110c8f49fa7d7(this);
	}

	internal x53cb1139c5c64ee6 xc7597154faf074c6()
	{
		xc63cc34daaa2e2d9 xa51d8d9790431b2b = x4397a67a49a78a04.xa51d8d9790431b2b;
		return xa51d8d9790431b2b.x5a5e07e9fa12451a switch
		{
			x5a5e07e9fa12451a.xfdc1a17f479acc42 => ((x8d9303345f12a846)xa51d8d9790431b2b).x927910b7aed705e2, 
			x5a5e07e9fa12451a.x25af49e7b49ea0bc => ((x7c1e2b821e8b8220)xa51d8d9790431b2b).x5d6d04c35215bc51.x5d6d04c35215bc51, 
			_ => throw new InvalidOperationException(), 
		};
	}

	private int xc76a12855c75c651()
	{
		int num = 0;
		x398b3bd0acd94b61 x398b3bd0acd94b62 = this;
		for (x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad); x852fe8bb5ac31099 != null; x852fe8bb5ac31099 = (x852fe8bb5ac31098)x852fe8bb5ac31099.x9b2bbd3d05bf558b())
		{
			if (!x852fe8bb5ac31099.x7149c962c02931b3)
			{
				if (x398b3bd0acd94b62 == null)
				{
					x398b3bd0acd94b62 = x852fe8bb5ac31099.x7e2e5dd40daabc3b;
				}
				while (x398b3bd0acd94b62 != null)
				{
					x398b3bd0acd94b62 = x82f666dd53fed993.x8488cb14fdb73804(x398b3bd0acd94b62, xfedb3635e0d89070: false, xc0a853db762872fe);
					if (x398b3bd0acd94b62 == null)
					{
						break;
					}
					x92361dccfa0347fd x92361dccfa0347fd2 = (x92361dccfa0347fd)x398b3bd0acd94b62;
					if (!x92361dccfa0347fd2.x37201fd6c5382fb2)
					{
						num++;
					}
				}
			}
		}
		return num;
	}

	private int x5138ebdd7c56c151(bool x897ec71a9f9588a0)
	{
		xacf1bb6be5092987 xf48cd6e82340ac = ((xf6689e0eed33812c)base.x332a8eedb847940d.x2cbc0fc707d2e1eb()).xf48cd6e82340ac70;
		int num = (x897ec71a9f9588a0 ? xf48cd6e82340ac.x1f4dededb9314c98 : xf48cd6e82340ac.x7a473c50b490c1c8);
		if (num != 1)
		{
			return x58b388792ab34f8f + num;
		}
		switch (x897ec71a9f9588a0 ? xf48cd6e82340ac.x2d48be5358bac023 : xf48cd6e82340ac.x0b588f8c055fc2c0)
		{
		case FootnoteNumberingRule.RestartPage:
			if (!x897ec71a9f9588a0)
			{
				throw new InvalidOperationException("Restart from page is not a valid rule for endnotes.");
			}
			return xc76a12855c75c651() + num;
		case FootnoteNumberingRule.RestartSection:
			return x67c42a3ac65864dc + num;
		default:
			return x58b388792ab34f8f + num;
		}
	}

	private x92361dccfa0347fd x47acc756f6e7467c(int x1e5cf3d7636c3c00)
	{
		if (x1e5cf3d7636c3c00 == 21788)
		{
			x398b3bd0acd94b61 x398b3bd0acd94b62 = this;
			for (x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad); x852fe8bb5ac31099 != null; x852fe8bb5ac31099 = (x852fe8bb5ac31098)x852fe8bb5ac31099.x9b2bbd3d05bf558b())
			{
				if (!x852fe8bb5ac31099.x7149c962c02931b3)
				{
					if (x398b3bd0acd94b62 == null)
					{
						x398b3bd0acd94b62 = x852fe8bb5ac31099.x7e2e5dd40daabc3b;
					}
					while (x398b3bd0acd94b62 != null)
					{
						x398b3bd0acd94b62 = x82f666dd53fed993.x8488cb14fdb73804(x398b3bd0acd94b62, xfedb3635e0d89070: false, xc0a853db762872fe);
						if (x398b3bd0acd94b62 == null)
						{
							break;
						}
						x92361dccfa0347fd x92361dccfa0347fd2 = (x92361dccfa0347fd)x398b3bd0acd94b62;
						if (!x92361dccfa0347fd2.x37201fd6c5382fb2)
						{
							return x92361dccfa0347fd2;
						}
					}
				}
			}
		}
		else
		{
			xe0e644109215bf44 xe0e644109215bf45 = ((x1e5cf3d7636c3c00 == 21639) ? null : base.x332a8eedb847940d.x2cbc0fc707d2e1eb());
			for (xe0e644109215bf44 xb7485c0917792fb = x4397a67a49a78a04.xb7485c0917792fb0; xb7485c0917792fb != null; xb7485c0917792fb = xb7485c0917792fb.xb7485c0917792fb0)
			{
				x92361dccfa0347fd x92361dccfa0347fd3 = (x92361dccfa0347fd)((x16dabaa37d19a5ec)xb7485c0917792fb).x465c7a263669f01c;
				if (x92361dccfa0347fd3 == null || (xe0e644109215bf45 != null && x92361dccfa0347fd3.x332a8eedb847940d.x2cbc0fc707d2e1eb() != xe0e644109215bf45))
				{
					break;
				}
				if (!x92361dccfa0347fd3.x37201fd6c5382fb2)
				{
					return x92361dccfa0347fd3;
				}
			}
		}
		return null;
	}
}
