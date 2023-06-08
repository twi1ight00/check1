using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class SubDocument : Node
{
	private string xb60ae86f79aa8262;

	internal string xa39af5a82860a9a3
	{
		get
		{
			return xb60ae86f79aa8262;
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "fileName");
			xb60ae86f79aa8262 = value;
		}
	}

	public override NodeType NodeType => NodeType.SubDocument;

	internal SubDocument(DocumentBase doc, string fileName)
		: base(doc)
	{
		xa39af5a82860a9a3 = fileName;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return Node.x9708eba393e07242(visitor.VisitSubDocument(this));
	}
}
