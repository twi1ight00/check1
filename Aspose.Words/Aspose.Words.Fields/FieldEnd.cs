using x28925c9b27b37a46;

namespace Aspose.Words.Fields;

public class FieldEnd : FieldChar
{
	private bool xb9e870b334e529ab;

	public override NodeType NodeType => NodeType.FieldEnd;

	public bool HasSeparator => xb9e870b334e529ab;

	internal FieldEnd(DocumentBase doc, xeedad81aaed42a76 runPr, FieldType type, bool hasSeparator)
		: base(doc, '\u0015', runPr, type)
	{
		xb9e870b334e529ab = hasSeparator;
	}

	internal void x254cab982e9946b2(bool xbcea506a33cf9111)
	{
		xb9e870b334e529ab = xbcea506a33cf9111;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		if (!x20b086a74595b881(visitor))
		{
			return true;
		}
		return Node.x9708eba393e07242(visitor.VisitFieldEnd(this));
	}
}
