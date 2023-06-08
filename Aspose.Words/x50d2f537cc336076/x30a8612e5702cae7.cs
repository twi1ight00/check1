using System.Collections;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Math;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class x30a8612e5702cae7 : DocumentVisitor
{
	private Stack x40faba523420f152 = new Stack();

	private x57df270da83ea6de x19c2f5c8c220ef20;

	internal x57df270da83ea6de x5b81632e5b71b64c(OfficeMath x203bd7b4a3be8d02)
	{
		x19c2f5c8c220ef20 = x5edac11e626da658.x7552c03e3988ad59(x203bd7b4a3be8d02, null);
		x40faba523420f152.Push(x19c2f5c8c220ef20);
		x203bd7b4a3be8d02.Accept(this);
		x19c2f5c8c220ef20.xb7ae55095fddecd9();
		x19c2f5c8c220ef20.x5152a5707921c783(0.5f, 0.5f);
		if (x19c2f5c8c220ef20.x6ae4612a8469678e.IsEmpty)
		{
			x19c2f5c8c220ef20.x6ae4612a8469678e = new RectangleF(0f, 0f, x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43, x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43);
		}
		return x19c2f5c8c220ef20;
	}

	public override VisitorAction VisitOfficeMathStart(OfficeMath officeMath)
	{
		x19c2f5c8c220ef20 = x5edac11e626da658.x7552c03e3988ad59(officeMath, x19c2f5c8c220ef20);
		x40faba523420f152.Push(x19c2f5c8c220ef20);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitOfficeMathEnd(OfficeMath officeMath)
	{
		x40faba523420f152.Pop();
		x19c2f5c8c220ef20 = (x57df270da83ea6de)x40faba523420f152.Peek();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRun(Run run)
	{
		if (!base.x991897f13cf6aadc)
		{
			xc1e7448c64b3a897 x4bbc2c453c = new xc1e7448c64b3a897(run.Text, run.xeedad81aaed42a76, xb3104861e1f4241e());
			x19c2f5c8c220ef20.x1fa9148f6731ff24(x4bbc2c453c);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		x75be698bf0c3a5c5();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		x45277e5380a187db();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		if (!fieldEnd.HasSeparator)
		{
			x45277e5380a187db();
		}
		return VisitorAction.Continue;
	}

	private bool xb3104861e1f4241e()
	{
		if (x19c2f5c8c220ef20.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x8c55fc884c93cb9f)
		{
			return false;
		}
		if (x19c2f5c8c220ef20.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1745ba6c6d5efbc4)
		{
			Node parentNode = x19c2f5c8c220ef20.xc48e358ce4f81353.ParentNode.ParentNode;
			if (parentNode.NodeType == NodeType.OfficeMath)
			{
				return ((OfficeMath)parentNode).x52642f91ccdeeb35.x3e68720d12325f49 != x3e68720d12325f49.x8c55fc884c93cb9f;
			}
			return true;
		}
		return true;
	}
}
