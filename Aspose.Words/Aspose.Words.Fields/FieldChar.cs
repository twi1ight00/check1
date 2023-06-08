using x28925c9b27b37a46;

namespace Aspose.Words.Fields;

public abstract class FieldChar : SpecialChar
{
	private FieldType xf47d0d057a67ed4d;

	private bool x572b3b60acd3cc96;

	private bool x48ccc0b8c8f971f8;

	public FieldType FieldType => xf47d0d057a67ed4d;

	public bool IsLocked
	{
		get
		{
			return x572b3b60acd3cc96;
		}
		set
		{
			x572b3b60acd3cc96 = value;
		}
	}

	internal bool x6e94079169d5a06e
	{
		get
		{
			return x48ccc0b8c8f971f8;
		}
		set
		{
			x48ccc0b8c8f971f8 = value;
		}
	}

	internal FieldChar(DocumentBase doc, char fieldChar, xeedad81aaed42a76 runPr, FieldType type)
		: base(doc, fieldChar, runPr)
	{
		xf47d0d057a67ed4d = type;
	}

	internal void x8fdbe5468986594f(FieldType x77ce91e5324df734)
	{
		xf47d0d057a67ed4d = x77ce91e5324df734;
	}
}
