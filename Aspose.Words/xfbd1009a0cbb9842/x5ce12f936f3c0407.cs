using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x5ce12f936f3c0407 : x9710cfdf3f61d319
{
	private readonly Inline x23d393c606049c4c;

	internal x5ce12f936f3c0407(Inline runPrSource)
	{
		x23d393c606049c4c = runPrSource;
	}

	private void xdc1074cc34640437(x7e263f21a73a027a x7d95d971d8923f4c)
	{
		if (x23d393c606049c4c == null)
		{
			return;
		}
		foreach (Node item in x7d95d971d8923f4c)
		{
			if (item.NodeType == NodeType.Run)
			{
				Run run = (Run)item;
				xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)x23d393c606049c4c.xeedad81aaed42a76.x8b61531c8ea35b85();
				run.xeedad81aaed42a76.x456b2c186131b981(265, xeedad81aaed42a);
				run.xeedad81aaed42a76 = xeedad81aaed42a;
			}
		}
	}

	void x9710cfdf3f61d319.x18739bb47cc530dd(x7e263f21a73a027a x7d95d971d8923f4c)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xdc1074cc34640437
		this.xdc1074cc34640437(x7d95d971d8923f4c);
	}
}
