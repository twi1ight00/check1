using x28925c9b27b37a46;

namespace Aspose.Words;

public class AbsolutePositionTab : SpecialChar
{
	private x55477ca1c0c8419f xbe63ce924b03850f;

	private x84d41ac121232475 x9886858906e51a59 = x84d41ac121232475.x4d0b9d4447ba7566;

	private x932d11b236987c0e x5d6e1fc3d9067a89;

	internal x55477ca1c0c8419f x9ba359ff37a3a63b
	{
		get
		{
			return xbe63ce924b03850f;
		}
		set
		{
			xbe63ce924b03850f = value;
		}
	}

	internal x932d11b236987c0e x7073c129de8d5e65
	{
		get
		{
			return x5d6e1fc3d9067a89;
		}
		set
		{
			x5d6e1fc3d9067a89 = value;
		}
	}

	internal x84d41ac121232475 x312ff11290b951a5
	{
		get
		{
			return x9886858906e51a59;
		}
		set
		{
			x9886858906e51a59 = value;
		}
	}

	internal AbsolutePositionTab(DocumentBase doc, xeedad81aaed42a76 runPr)
		: base(doc, '\t', runPr)
	{
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return Node.x9708eba393e07242(visitor.VisitAbsolutePositionTab(this));
	}
}
