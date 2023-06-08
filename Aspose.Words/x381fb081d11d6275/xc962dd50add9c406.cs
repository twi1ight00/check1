using System;
using System.Collections;
using Aspose;
using Aspose.Words;
using Aspose.Words.Lists;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x7c4557e104065fc9;
using xce0136f05681c5e9;

namespace x381fb081d11d6275;

internal abstract class xc962dd50add9c406
{
	private readonly bool x9e44a5089e11f806;

	private readonly Stack x9f4ea74243424261;

	private int x5ca26042ee40b106 => (int)x9f4ea74243424261.Peek();

	private int x176a24a89680004b => x9f4ea74243424261.Count - 1;

	protected xc962dd50add9c406(bool enforceEpubCompliance)
	{
		x9e44a5089e11f806 = enforceEpubCompliance;
		x9f4ea74243424261 = new Stack();
	}

	internal void x18dd6bff0a34aaf3(Paragraph x41baca1d6c0c2e8e, x1a78664fa10a3755 x9e5248b49f0df7e8, x4ef6b4f19b033b48 x1458787a87172e23)
	{
		int xf13a626e550cef8f = x9e5248b49f0df7e8.xf13a626e550cef8f;
		int num = xf13a626e550cef8f - x176a24a89680004b;
		bool xa5ac9eb = num > 0 || x9e5248b49f0df7e8.x71c63f7e57f7ede5 != x5ca26042ee40b106;
		if (x903af03e39bcd255(x41baca1d6c0c2e8e, xa5ac9eb))
		{
			if (num > 0)
			{
				while (--num >= 0)
				{
					xc8f626afed283298(x41baca1d6c0c2e8e);
				}
			}
			else
			{
				while (++num <= 0)
				{
					xf4efd7ea1a61eebb();
				}
				if (x9e5248b49f0df7e8.x71c63f7e57f7ede5 != x5ca26042ee40b106)
				{
					xf4efd7ea1a61eebb();
					xc8f626afed283298(x41baca1d6c0c2e8e);
				}
			}
			StartListItem(x41baca1d6c0c2e8e, x9e5248b49f0df7e8, x1458787a87172e23);
		}
		else
		{
			xd7696af0a28b1b06();
			StartListItemAsNormalParagraph(x41baca1d6c0c2e8e, x9e5248b49f0df7e8, x1458787a87172e23);
			x6439dc62cdba55b7(x41baca1d6c0c2e8e);
			if (x41baca1d6c0c2e8e.ListLabel.xd8359a0ce34a3ba5 == ListTrailingCharacter.Tab)
			{
				WriteTabSimulationAfterLabel(x41baca1d6c0c2e8e, x9e5248b49f0df7e8);
			}
		}
	}

	internal void xd7696af0a28b1b06()
	{
		int num = x9f4ea74243424261.Count;
		while (--num >= 0)
		{
			xf4efd7ea1a61eebb();
		}
	}

	[JavaThrows(true)]
	protected abstract void StartListItem(Paragraph para, x1a78664fa10a3755 expandedParaPr, x4ef6b4f19b033b48 paraPositionInBorder);

	[JavaThrows(true)]
	protected abstract void StartListItemAsNormalParagraph(Paragraph para, x1a78664fa10a3755 expandedParaPr, x4ef6b4f19b033b48 paraPositionInBorder);

	[JavaThrows(true)]
	protected abstract void StartListCore(Paragraph para, ListLevel levelPr);

	[JavaThrows(true)]
	protected abstract void EndListCore();

	[JavaThrows(true)]
	protected abstract void WriteListLableCore(Paragraph para, string labelText);

	[JavaThrows(true)]
	protected abstract void WriteTabSimulationAfterLabel(Paragraph para, x1a78664fa10a3755 expandedParaPr);

	private void x6439dc62cdba55b7(Paragraph x41baca1d6c0c2e8e)
	{
		string text = x41baca1d6c0c2e8e.ListLabel.LabelString;
		if (x41baca1d6c0c2e8e.ListLabel.xd8359a0ce34a3ba5 == ListTrailingCharacter.Space)
		{
			text += ' ';
		}
		WriteListLableCore(x41baca1d6c0c2e8e, text);
	}

	private bool x903af03e39bcd255(Paragraph x41baca1d6c0c2e8e, bool xa5ac9eb353033610)
	{
		bool result = false;
		if (!x495fdb45f3d92b70.x451aaae1babb8e57(x41baca1d6c0c2e8e.x1a78664fa10a3755))
		{
			bool flag = x9e44a5089e11f806;
			if (!flag || !xa5ac9eb353033610 || x41baca1d6c0c2e8e.ListLabel.LabelValue == 1)
			{
				ListLevel listLevel = x41baca1d6c0c2e8e.ListFormat.ListLevel;
				result = listLevel.x44b52529222cea8a || (x495fdb45f3d92b70.x903af03e39bcd255(listLevel, flag) && !ListLabel.xc0242e835a99b224(listLevel, x41baca1d6c0c2e8e.x344511c4e4ce09da));
			}
		}
		return result;
	}

	private void xc8f626afed283298(Paragraph x41baca1d6c0c2e8e)
	{
		ListFormat listFormat = x41baca1d6c0c2e8e.ListFormat;
		x9f4ea74243424261.Push(listFormat.x71c63f7e57f7ede5);
		ListLevel listLevel = listFormat.ListLevel;
		StartListCore(x41baca1d6c0c2e8e, listLevel);
	}

	private void xf4efd7ea1a61eebb()
	{
		if (x176a24a89680004b < 0)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oammjcdnddknadboocioadpojnfplbnpbceaeblanmbblajbhmpbabhckaocbbfdpamdilcehpjehpafcphfnoofopfgjpmgiodhakkhlobijoiilopiejgjknnjmneklilkjmclfijlomamimhmpmomnmfneimn", 1560660939)));
		}
		EndListCore();
		x9f4ea74243424261.Pop();
	}
}
