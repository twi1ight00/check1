using x28925c9b27b37a46;

namespace Aspose.Words;

public class SpecialChar : Inline
{
	private readonly string xed4a7b1500064e12;

	public override NodeType NodeType => NodeType.SpecialChar;

	internal SpecialChar(DocumentBase doc, char ch, xeedad81aaed42a76 runPr)
		: base(doc, runPr)
	{
		xed4a7b1500064e12 = ch.ToString();
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return Node.x9708eba393e07242(visitor.VisitSpecialChar(this));
	}

	public override string GetText()
	{
		return xed4a7b1500064e12;
	}
}
