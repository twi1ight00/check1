using x28925c9b27b37a46;

namespace Aspose.Words.Fields;

public class FieldStart : FieldChar
{
	public override NodeType NodeType => NodeType.FieldStart;

	internal FieldStart(DocumentBase doc, xeedad81aaed42a76 runPr, FieldType type)
		: base(doc, '\u0013', runPr, type)
	{
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		if (!x20b086a74595b881(visitor))
		{
			return true;
		}
		return Node.x9708eba393e07242(visitor.VisitFieldStart(this));
	}
}
