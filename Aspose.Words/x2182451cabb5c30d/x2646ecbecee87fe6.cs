using Aspose.Words;

namespace x2182451cabb5c30d;

internal class x2646ecbecee87fe6 : x3b57052406b93b82
{
	private readonly bool xf2537fc9e30eb6a6;

	private Footnote xb36e3f9b3f81a1ae;

	internal x2646ecbecee87fe6(xe5e546ef5f0503b2 context, bool isAuto)
		: base(context)
	{
		xf2537fc9e30eb6a6 = isAuto;
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.x69d28a4aeef83a6f)
		{
			xb36e3f9b3f81a1ae = new Footnote(base.x2c8c6741422a1298, FootnoteType.Footnote, xf2537fc9e30eb6a6, null, base.xffb3238a8fd59aa7.x5f35c5e3977af81d());
			base.xe1410f585439c7d4.x1f4dededb9314c98(xb36e3f9b3f81a1ae);
			if (!xf2537fc9e30eb6a6)
			{
				Run run = xb36e3f9b3f81a1ae.ParentParagraph.xf562da51e0b3c429();
				xb36e3f9b3f81a1ae.x715a8c5c33fdc1a6 = run.GetText();
				run.Remove();
			}
		}
		else
		{
			base.x41e7a76e7e854e6e(x153c99a852375422);
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.x69d28a4aeef83a6f)
		{
			base.xe1410f585439c7d4.x08d6c67017518c71();
		}
		else
		{
			base.xa4085ff83f9ddeeb();
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x153c99a852375422.x1dafd189c5465293() == "\\ftnalt")
		{
			xb36e3f9b3f81a1ae.x88ea8242dd9d6152(FootnoteType.Endnote);
		}
		else
		{
			base.xa2d8e36cb99ac0f4(x153c99a852375422);
		}
	}
}
