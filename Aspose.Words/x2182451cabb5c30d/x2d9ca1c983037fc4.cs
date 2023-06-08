using Aspose.Words;
using x28925c9b27b37a46;
using xda075892eccab2ad;

namespace x2182451cabb5c30d;

internal class x2d9ca1c983037fc4 : x77fb5b1d5c73757b
{
	private bool x7255a5813e71e9fc;

	private bool x5c30b9438de6da86;

	private bool x6e75d86e07e07fee;

	private int xb27bacee944055a0;

	private bool x16c01d3465569fed;

	private x90347bcd8deede01 x90347bcd8deede01 => x28fcdc775a1d069c.x2c8c6741422a1298.Styles.x90347bcd8deede01;

	internal x2d9ca1c983037fc4(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.xa463373a6b1cbac6)
		{
			x6b9bad1114a45db3();
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\lsdstimax":
			x90347bcd8deede01.x6c7ca9aba118e7af = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\lsdlockeddef":
			x90347bcd8deede01.x799a64ee3b4ce806 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\lsdsemihiddendef":
			x90347bcd8deede01.xe27cb3f1d698353d = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\lsdunhideuseddef":
			x90347bcd8deede01.xa657c8b674ff2f76 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\lsdqformatdef":
			x90347bcd8deede01.x0c40b3ed8738297c = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\lsdprioritydef":
			x90347bcd8deede01.x4d0e04ab61f50baa = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\lsdsemihidden":
			x6e75d86e07e07fee = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\lsdunhideused":
			x16c01d3465569fed = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\lsdqformat":
			x5c30b9438de6da86 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\lsdpriority":
			xb27bacee944055a0 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\lsdlocked":
			x7255a5813e71e9fc = x153c99a852375422.x1ad7968449b109cd();
			break;
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		string xbcea506a33cf = x153c99a852375422.x8b1c61c709b6f253().Trim();
		StyleIdentifier styleIdentifier = x72a0c846678ecaf9.x3b3cea4656a2e16d(xbcea506a33cf);
		if (styleIdentifier != StyleIdentifier.User)
		{
			x90347bcd8deede01.x31805fef2aff8b5f.xd6b6ed77479ef68c(new x565726a756595ed4(styleIdentifier, x7255a5813e71e9fc, x5c30b9438de6da86, x6e75d86e07e07fee, xb27bacee944055a0, x16c01d3465569fed));
		}
		x6b9bad1114a45db3();
	}

	private void x6b9bad1114a45db3()
	{
		x7255a5813e71e9fc = x90347bcd8deede01.x799a64ee3b4ce806;
		x5c30b9438de6da86 = x90347bcd8deede01.x0c40b3ed8738297c;
		x6e75d86e07e07fee = x90347bcd8deede01.xe27cb3f1d698353d;
		xb27bacee944055a0 = x90347bcd8deede01.x4d0e04ab61f50baa;
		x16c01d3465569fed = x90347bcd8deede01.xa657c8b674ff2f76;
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		x25099a8bbbd55d1c x3146d638ec = x8d3f74e5f925679c.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.xa463373a6b1cbac6)
		{
			return this;
		}
		return null;
	}
}
