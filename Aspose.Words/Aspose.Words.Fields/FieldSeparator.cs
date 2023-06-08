using x011d489fb9df7027;
using x28925c9b27b37a46;

namespace Aspose.Words.Fields;

public class FieldSeparator : FieldChar
{
	private readonly x71d39fdf56861cca x92988a415a7f359b;

	public override NodeType NodeType => NodeType.FieldSeparator;

	internal x71d39fdf56861cca x71d39fdf56861cca => x92988a415a7f359b;

	internal FieldSeparator(DocumentBase doc, xeedad81aaed42a76 runPr, FieldType type)
		: base(doc, '\u0014', runPr, type)
	{
		x92988a415a7f359b = null;
	}

	internal FieldSeparator(DocumentBase doc, xeedad81aaed42a76 runPr, FieldType type, x71d39fdf56861cca oleObject)
		: base(doc, '\u0014', runPr, type)
	{
		x92988a415a7f359b = oleObject;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		if (!x20b086a74595b881(visitor))
		{
			return true;
		}
		return Node.x9708eba393e07242(visitor.VisitFieldSeparator(this));
	}
}
