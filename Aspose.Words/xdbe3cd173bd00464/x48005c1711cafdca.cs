using Aspose.Words;
using Aspose.Words.Lists;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using xce0136f05681c5e9;

namespace xdbe3cd173bd00464;

internal class x48005c1711cafdca : xc962dd50add9c406
{
	private readonly x43802f3ed3207329 x5a7a1d229173bf5d;

	private readonly x873451caae5ad4ae x800085dd555f7711;

	private bool x522f16749fe4b50b;

	internal x48005c1711cafdca(x873451caae5ad4ae builder, x43802f3ed3207329 runWriter)
		: base(enforceEpubCompliance: true)
	{
		x800085dd555f7711 = builder;
		x5a7a1d229173bf5d = runWriter;
	}

	internal void x1932165b9bea79a4()
	{
		if (x522f16749fe4b50b)
		{
			x800085dd555f7711.x2dfde153f4ef96d0();
			x522f16749fe4b50b = false;
		}
	}

	protected override void StartListItem(Paragraph para, x1a78664fa10a3755 expandedParaPr, x4ef6b4f19b033b48 paraPositionInBorder)
	{
		x522f16749fe4b50b = true;
		x800085dd555f7711.x2307058321cdb62f("ListItem");
		x800085dd555f7711.x2307058321cdb62f("Paragraph");
	}

	protected override void StartListItemAsNormalParagraph(Paragraph para, x1a78664fa10a3755 expandedParaPr, x4ef6b4f19b033b48 paraPositionInBorder)
	{
		x800085dd555f7711.x2307058321cdb62f("Paragraph");
		xc946ba15e395060e.x9ed6d11bbfc54525(x800085dd555f7711, para.ParagraphFormat);
	}

	protected override void EndListCore()
	{
		x800085dd555f7711.x538f0e0fb2bf15ab();
	}

	protected override void WriteListLableCore(Paragraph para, string labelText)
	{
		x5a7a1d229173bf5d.x486167d7a74e8e88(para.ListLabel.Font, labelText);
	}

	protected override void WriteTabSimulationAfterLabel(Paragraph para, x1a78664fa10a3755 expandedParaPr)
	{
		x5a7a1d229173bf5d.x486167d7a74e8e88(para.ListLabel.Font, ControlChar.Tab);
	}

	protected override void StartListCore(Paragraph para, ListLevel levelPr)
	{
		x800085dd555f7711.x2307058321cdb62f("List");
		x800085dd555f7711.x943f6be3acf634db("MarkerOffset", xb2b537767a3ea62c.x541e8c2724a511cc(levelPr.TabPosition, "pt"));
		x800085dd555f7711.x943f6be3acf634db("StartIndex", levelPr.StartAt);
		x800085dd555f7711.x943f6be3acf634db("MarkerStyle", xb2b537767a3ea62c.x321f0124fc6d50ae(levelPr.NumberStyle));
	}
}
