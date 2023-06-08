using Aspose.Words;
using Aspose.Words.Fields;
using x2a6f63b6650e76c4;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x811d4618e5f42dc7 : Field, x6ed66b5cf8da2955
{
	internal bool x6b54bdfbc4586f55
	{
		get
		{
			if (!x6d7e110cfa5f7d8a && !x68294767f7f352c8)
			{
				return x4e86d031c7e9c2ce;
			}
			return true;
		}
	}

	private bool x6d7e110cfa5f7d8a
	{
		get
		{
			if (base.Start.GetAncestor(NodeType.Body) == null)
			{
				return !x784ef392c790ed8f;
			}
			return false;
		}
	}

	private bool x68294767f7f352c8 => !x0d299f323d241756.x5959bccb67bbf051(x70c9403957f529f2);

	private bool x4e86d031c7e9c2ce
	{
		get
		{
			if (x2eb33b2a908602bb)
			{
				return base.x2c8c6741422a1298.Range.Bookmarks[x0e99a2a20bc3c647] == null;
			}
			return false;
		}
	}

	internal string x70c9403957f529f2 => base.xb452e2ee706d7a67.x642e37025c67edab(0);

	internal string x0e99a2a20bc3c647 => base.xb452e2ee706d7a67.x642e37025c67edab(1);

	internal bool x2eb33b2a908602bb => x0d299f323d241756.x5959bccb67bbf051(x0e99a2a20bc3c647);

	internal bool x784ef392c790ed8f => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\c");

	internal bool x7d0742df91ef6193 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\h");

	internal bool x7cdaaeb5826a325d => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\n");

	internal int xea0d951c148ab8a9 => base.xb452e2ee706d7a67.x38dcf39c0c123d8f("\\r");

	internal int x54f0b3761b536601 => base.xb452e2ee706d7a67.x38dcf39c0c123d8f("\\s");

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		if (x6d7e110cfa5f7d8a)
		{
			return new xd5801a931e010963(this, "Error! Main Document Only.");
		}
		if (x68294767f7f352c8)
		{
			return new xd5801a931e010963(this, "Error! No sequence specified.");
		}
		if (x4e86d031c7e9c2ce)
		{
			return new xd5801a931e010963(this, "Error! Bookmark not defined.");
		}
		if (x7d0742df91ef6193 && !base.xb452e2ee706d7a67.xcc2d426b867d703d("\\*"))
		{
			return new xca592a476766b11a(this, string.Empty);
		}
		x2f8218136742d918 xab8fe3cd8c5556fb = new x2f8218136742d918(base.x34a4695711b84f85, new xb0db6b65736c1e1c(x357c90b33d6bb8e6()));
		base.x34a4695711b84f85.x874035a07982e6e7(xab8fe3cd8c5556fb);
		x82e26649b09596bd result = base.x6edce55dcd2d335b.x803fdc6662fa3f31();
		return new xca592a476766b11a(this, result);
	}

	internal int x5f21ccf084377ea8(int x949e56390867f998)
	{
		if (xea0d951c148ab8a9 != -1)
		{
			return xea0d951c148ab8a9;
		}
		if (x54f0b3761b536601 != -1 && x54f0b3761b536601 == x23cc85605c70a605())
		{
			return 1;
		}
		if (x784ef392c790ed8f)
		{
			return x949e56390867f998;
		}
		return x949e56390867f998 + 1;
	}

	private int x23cc85605c70a605()
	{
		return base.Start.ParentParagraph.xfcffbd79482d97c7.StyleIdentifier switch
		{
			StyleIdentifier.Heading1 => 1, 
			StyleIdentifier.Heading2 => 2, 
			StyleIdentifier.Heading3 => 3, 
			StyleIdentifier.Heading4 => 4, 
			StyleIdentifier.Heading5 => 5, 
			StyleIdentifier.Heading6 => 6, 
			StyleIdentifier.Heading7 => 7, 
			StyleIdentifier.Heading8 => 8, 
			StyleIdentifier.Heading9 => 9, 
			_ => -1, 
		};
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\c":
		case "\\h":
		case "\\n":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\r":
		case "\\s":
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
