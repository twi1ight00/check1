using Aspose.Words.Lists;
using xd2754ae26d400653;

namespace x2182451cabb5c30d;

internal class x54ce96b10ed440aa : x77fb5b1d5c73757b
{
	private readonly List x870980ad82373217;

	private x136abcf7d9c0eef3 x04986b424b4953aa;

	internal x54ce96b10ed440aa(xe5e546ef5f0503b2 context, List list)
		: base(context)
	{
		x870980ad82373217 = list;
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		int count = x870980ad82373217.x6047afa6812e47bc.Count;
		x04986b424b4953aa = new x136abcf7d9c0eef3(base.x2c8c6741422a1298, count);
		x870980ad82373217.x6047afa6812e47bc.Add(x04986b424b4953aa);
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\listoverridestartat":
			x04986b424b4953aa.x33160172e2e7ff13 = true;
			break;
		case "\\levelstartat":
			x04986b424b4953aa.x6da6130e001c6962 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\listoverrideformat":
			x04986b424b4953aa.x178c863a9c967cd2 = true;
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		x25099a8bbbd55d1c x3146d638ec = x8d3f74e5f925679c.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.xf13a626e550cef8f)
		{
			return new xc1b9962c90992074(x28fcdc775a1d069c, x04986b424b4953aa.xf13a626e550cef8f);
		}
		return null;
	}
}
