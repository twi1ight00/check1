using System;
using System.Collections;
using Aspose;
using Aspose.Words;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal abstract class xe25d778fe9f1252a : DocumentVisitor
{
	private readonly Stack x215f4deb55f3496c = new Stack();

	private readonly FieldType[] xebc726c1a6729b0c;

	private readonly bool x7cb2ce80dad02d5e;

	internal override bool x0ee6e13d00a3931f => false;

	protected bool xf59e73287256d89e => x215f4deb55f3496c.Count > 0;

	protected xe25d778fe9f1252a(FieldType[] fieldTypes)
	{
		xebc726c1a6729b0c = fieldTypes;
		x7cb2ce80dad02d5e = fieldTypes == null || fieldTypes.Length == 0;
	}

	protected xe25d778fe9f1252a()
		: this(null)
	{
	}

	internal static x6435b7bbb0879a04 x105bab38d511372f(Node xda5bf54deb817e37)
	{
		return x105bab38d511372f(xda5bf54deb817e37, x0d900d42b3598fde: true);
	}

	internal static x6435b7bbb0879a04 x105bab38d511372f(Node xda5bf54deb817e37, bool x0d900d42b3598fde)
	{
		return x105bab38d511372f(xda5bf54deb817e37, x0d900d42b3598fde, null);
	}

	internal static x6435b7bbb0879a04 x105bab38d511372f(Node xda5bf54deb817e37, bool x0d900d42b3598fde, FieldType[] x2750fa2a2b3ca928)
	{
		xa7cfd2f61a14bce5 xa7cfd2f61a14bce6 = new xa7cfd2f61a14bce5(x0d900d42b3598fde, x2750fa2a2b3ca928);
		xa7cfd2f61a14bce6.xf098323036d9ec26(xda5bf54deb817e37);
		return xa7cfd2f61a14bce6.x84aa3570d857bec4;
	}

	internal static x6435b7bbb0879a04 x105bab38d511372f(ArrayList xa955664f4f50999d, bool x0d900d42b3598fde)
	{
		return x105bab38d511372f(xa955664f4f50999d, x0d900d42b3598fde, null);
	}

	internal static x6435b7bbb0879a04 x105bab38d511372f(ArrayList xa955664f4f50999d, bool x0d900d42b3598fde, FieldType[] x2750fa2a2b3ca928)
	{
		xa7cfd2f61a14bce5 xa7cfd2f61a14bce6 = new xa7cfd2f61a14bce5(x0d900d42b3598fde, x2750fa2a2b3ca928);
		for (int i = 0; i < xa955664f4f50999d.Count; i++)
		{
			xa7cfd2f61a14bce6.xf098323036d9ec26((Node)xa955664f4f50999d[i]);
		}
		return xa7cfd2f61a14bce6.x84aa3570d857bec4;
	}

	internal static Hashtable xaacd1adf784d6cb4(Node xda5bf54deb817e37)
	{
		xb4ad9617bd4c5e53 xb4ad9617bd4c5e54 = new xb4ad9617bd4c5e53();
		xb4ad9617bd4c5e54.xf098323036d9ec26(xda5bf54deb817e37);
		return xb4ad9617bd4c5e54.x84aa3570d857bec4;
	}

	[JavaConvertCheckedExceptions]
	internal void xf098323036d9ec26(Node xda5bf54deb817e37)
	{
		xda5bf54deb817e37.Accept(this);
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		x215f4deb55f3496c.Push(fieldStart);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		x215f4deb55f3496c.Push(fieldSeparator);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		FieldSeparator x3de314ab70bbd9bf = (FieldSeparator)x33fe7eb3a43cb097(NodeType.FieldSeparator);
		FieldStart fieldStart = (FieldStart)x33fe7eb3a43cb097(NodeType.FieldStart);
		if (fieldStart == null)
		{
			return VisitorAction.Continue;
		}
		if (!xd31874b73b492157(fieldStart))
		{
			return VisitorAction.Continue;
		}
		Field field = x3759c06a3a4cf5d1.x43fef3435fba7a66(fieldStart, x3de314ab70bbd9bf, fieldEnd);
		OnFieldExtracted(field);
		return VisitorAction.Continue;
	}

	private bool xd31874b73b492157(FieldChar x2223f7db33837fbd)
	{
		if (!x7cb2ce80dad02d5e)
		{
			return Array.IndexOf(xebc726c1a6729b0c, x2223f7db33837fbd.FieldType) != -1;
		}
		return true;
	}

	private Node x33fe7eb3a43cb097(NodeType x1a523190ff9254e6)
	{
		Node result = null;
		if (x215f4deb55f3496c.Count > 0)
		{
			Node node = (Node)x215f4deb55f3496c.Peek();
			if (node != null && node.NodeType == x1a523190ff9254e6)
			{
				result = (Node)x215f4deb55f3496c.Pop();
			}
		}
		return result;
	}

	protected abstract void OnFieldExtracted(Field field);
}
