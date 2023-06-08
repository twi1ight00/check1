using System;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace Aspose.Words;

public class Run : Inline
{
	private string xed4a7b1500064e12;

	internal static readonly int[] xfc7b12804e684767 = new int[2] { 30, 40 };

	public override NodeType NodeType => NodeType.Run;

	public string Text
	{
		get
		{
			return xed4a7b1500064e12;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			xed4a7b1500064e12 = value;
		}
	}

	internal bool xadc83cc585a89881
	{
		get
		{
			if (xed4a7b1500064e12.Length == 0)
			{
				return false;
			}
			for (int i = 0; i < xed4a7b1500064e12.Length; i++)
			{
				if (!xebb9db61691ea142.x1adf194ca8126a4d(xed4a7b1500064e12[i]))
				{
					return false;
				}
			}
			return true;
		}
	}

	public Run(DocumentBase doc)
		: this(doc, "")
	{
	}

	public Run(DocumentBase doc, string text)
		: this(doc, text, new xeedad81aaed42a76())
	{
	}

	internal Run(DocumentBase doc, string text, xeedad81aaed42a76 runPr)
		: base(doc, runPr)
	{
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		xed4a7b1500064e12 = text;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return Node.x9708eba393e07242(visitor.VisitRun(this));
	}

	[JavaDelete("Don't need this in Java because the Text property getter is auto ported as getText() and all methods in Java are virtual.")]
	public override string GetText()
	{
		return xed4a7b1500064e12;
	}

	internal Run x4ede2f7ca43a1460(int xd4f974c06ffa392b, int x961016a387451f05, bool x1e2b473fecc8c6b6)
	{
		Run run = ((!x1e2b473fecc8c6b6) ? this : ((Run)Clone(isCloneChildren: false)));
		if (x961016a387451f05 == 0)
		{
			run.Text = string.Empty;
		}
		else
		{
			run.Text = run.Text.Substring(xd4f974c06ffa392b, x961016a387451f05);
		}
		return run;
	}

	internal Run x4a406570a6226227(int xb283228e2d44e087)
	{
		Run result = null;
		if (xb283228e2d44e087 > 0 && xb283228e2d44e087 < Text.Length)
		{
			result = (Run)base.ParentNode.InsertBefore(new Run(base.Document, Text.Substring(0, xb283228e2d44e087), (xeedad81aaed42a76)base.xeedad81aaed42a76.x8b61531c8ea35b85()), this);
			x4ede2f7ca43a1460(xb283228e2d44e087, Text.Length - xb283228e2d44e087, x1e2b473fecc8c6b6: false);
		}
		return result;
	}

	internal Run xd0d7979207229aff(int xb283228e2d44e087)
	{
		Run result = null;
		if (xb283228e2d44e087 > 0 && xb283228e2d44e087 < Text.Length)
		{
			result = (Run)base.ParentNode.InsertAfter(new Run(base.Document, Text.Substring(xb283228e2d44e087, Text.Length - xb283228e2d44e087), (xeedad81aaed42a76)base.xeedad81aaed42a76.x8b61531c8ea35b85()), this);
			x4ede2f7ca43a1460(0, xb283228e2d44e087, x1e2b473fecc8c6b6: false);
		}
		return result;
	}

	internal static bool xe190c8f083575592(string xb41faee6912a2313)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			return xebb9db61691ea142.x1adf194ca8126a4d(xb41faee6912a2313[0]);
		}
		return false;
	}
}
