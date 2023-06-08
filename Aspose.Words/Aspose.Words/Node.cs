using System;
using System.Collections;
using System.Diagnostics;
using Aspose.Words.Saving;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using xf989f31a236ff98c;

namespace Aspose.Words;

public abstract class Node
{
	private Node x8a08cc7cfe65e03b;

	private Node x5e50eec7f320e492;

	private Node xc6bd4deb565448bb;

	public abstract NodeType NodeType { get; }

	public CompositeNode ParentNode
	{
		get
		{
			if (x8a08cc7cfe65e03b == null)
			{
				return null;
			}
			if (x8a08cc7cfe65e03b.NodeType == NodeType.Null)
			{
				return null;
			}
			return (CompositeNode)x8a08cc7cfe65e03b;
		}
	}

	internal CompositeNode xdfa6ecc6f742f086
	{
		get
		{
			if (!x2b1ee3a87b36a988.x0302c7317ec57e52(ParentNode))
			{
				return ParentNode;
			}
			return ParentNode.xdfa6ecc6f742f086;
		}
	}

	public DocumentBase Document
	{
		[DebuggerStepThrough]
		get
		{
			if (this is DocumentBase)
			{
				return (DocumentBase)this;
			}
			if (x8a08cc7cfe65e03b == null)
			{
				return null;
			}
			return x8a08cc7cfe65e03b.Document;
		}
	}

	public Node PreviousSibling
	{
		get
		{
			CompositeNode parentNode = ParentNode;
			if (parentNode != null && this != parentNode.FirstChild)
			{
				return xe59ebb6cc4eed968;
			}
			return null;
		}
	}

	internal Node x90463af0c741fac1
	{
		get
		{
			Node node = x2b1ee3a87b36a988.x006ee30bbb04e012(PreviousSibling);
			if (node == null && x2b1ee3a87b36a988.x0302c7317ec57e52(ParentNode))
			{
				node = ParentNode.x90463af0c741fac1;
			}
			return node;
		}
	}

	internal Node xa6890a1cb2b8896e
	{
		get
		{
			Node node = x2b1ee3a87b36a988.xd5642c127a31bf8a(NextSibling);
			if (node == null && x2b1ee3a87b36a988.x0302c7317ec57e52(ParentNode))
			{
				node = ParentNode.xa6890a1cb2b8896e;
			}
			return node;
		}
	}

	public Node NextSibling
	{
		get
		{
			CompositeNode parentNode = ParentNode;
			if (parentNode != null && this != parentNode.LastChild)
			{
				return xf523c8cf086433fd;
			}
			return null;
		}
	}

	public virtual bool IsComposite => false;

	public Range Range => new Range(this);

	internal bool x16479f42fe4547f2
	{
		get
		{
			if (ParentNode != null)
			{
				return this == ParentNode.LastChild;
			}
			return true;
		}
	}

	internal bool x65c77554c620f590
	{
		get
		{
			if (ParentNode != null)
			{
				return this == ParentNode.FirstChild;
			}
			return true;
		}
	}

	internal bool x56657e375c13f7e3
	{
		get
		{
			for (Node previousSibling = PreviousSibling; previousSibling != null; previousSibling = previousSibling.PreviousSibling)
			{
				if (!x2b1ee3a87b36a988.x0f86e763fa9a14ff(previousSibling))
				{
					return false;
				}
			}
			return true;
		}
	}

	internal bool x8a3ddea83c393249
	{
		get
		{
			for (Node nextSibling = NextSibling; nextSibling != null; nextSibling = nextSibling.NextSibling)
			{
				if (!x2b1ee3a87b36a988.x0f86e763fa9a14ff(nextSibling))
				{
					return false;
				}
			}
			return true;
		}
	}

	internal Node xf523c8cf086433fd
	{
		get
		{
			return x5e50eec7f320e492;
		}
		set
		{
			x5e50eec7f320e492 = value;
		}
	}

	internal Node xe59ebb6cc4eed968
	{
		get
		{
			return xc6bd4deb565448bb;
		}
		set
		{
			xc6bd4deb565448bb = value;
		}
	}

	internal x8e127cb7da826802 x8e127cb7da826802
	{
		get
		{
			if (NodeType == NodeType.Document)
			{
				return x8e127cb7da826802.x2c8c6741422a1298;
			}
			if (NodeType == NodeType.Section)
			{
				return x8e127cb7da826802.x10d7a1cae426b158;
			}
			if (NodeType == NodeType.Body || NodeType == NodeType.HeaderFooter)
			{
				return x8e127cb7da826802.x14b6653f4bd6f43f;
			}
			if (x2b1ee3a87b36a988.xb6578aa94903986e(this))
			{
				return x8e127cb7da826802.x47f7cc477e022148;
			}
			if (x2b1ee3a87b36a988.x15bc008974f7d712(this))
			{
				return x8e127cb7da826802.xb3a1dda83e2dc492;
			}
			return x8e127cb7da826802.x22a0fbb9469b35e1;
		}
	}

	protected Node()
	{
	}

	protected Node(DocumentBase doc)
	{
		x3e229cd2762a6ef5(doc);
	}

	internal Document x357c90b33d6bb8e6()
	{
		DocumentBase document = Document;
		if (document is Document)
		{
			return (Document)document;
		}
		throw new InvalidOperationException("This operation requires the node to be inside the main document.");
	}

	internal int x22e0084ce6e1ab9a()
	{
		if (ParentNode == null)
		{
			return 0;
		}
		int num = 0;
		for (Node node = ParentNode.FirstChild; node != this; node = node.NextSibling)
		{
			num += node.x2e39a445d52f6ea8();
		}
		return ParentNode.x22e0084ce6e1ab9a() + num;
	}

	internal int xa5f9788e35a220ed()
	{
		return x22e0084ce6e1ab9a() + x2e39a445d52f6ea8();
	}

	internal bool x263d579af1d0d43f(int x13d4cb8d1bd20347)
	{
		int num = x22e0084ce6e1ab9a();
		int num2 = num + x2e39a445d52f6ea8();
		if (x13d4cb8d1bd20347 >= num)
		{
			return x13d4cb8d1bd20347 < num2;
		}
		return false;
	}

	internal virtual Node x42ef18de02ad5182(int x13d4cb8d1bd20347)
	{
		if (!x263d579af1d0d43f(x13d4cb8d1bd20347))
		{
			return null;
		}
		return this;
	}

	public Node Clone(bool isCloneChildren)
	{
		return x8b61531c8ea35b85(isCloneChildren, null);
	}

	internal virtual Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		Node node = (Node)MemberwiseClone();
		if (x8a08cc7cfe65e03b != null)
		{
			node.x8a08cc7cfe65e03b = Document.x01d8b78e1a402cbd;
		}
		node.x5e50eec7f320e492 = null;
		node.xc6bd4deb565448bb = null;
		xe870d6f33992ceb4?.xcc01c1f2f17c1af0(this, node);
		return node;
	}

	[JavaThrows(true)]
	public abstract bool Accept(DocumentVisitor visitor);

	protected static bool x9708eba393e07242(VisitorAction xab8fe3cd8c5556fb)
	{
		switch (xab8fe3cd8c5556fb)
		{
		case VisitorAction.Continue:
		case VisitorAction.SkipThisNode:
			return true;
		case VisitorAction.Stop:
			return false;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ljcobljolkaplkhpjkopokfackmabfdbekkbejbcljicoipcgjgdoindoieejdlehhcfghjfeiagghhgjhogfhfhcdmh", 127001158)));
		}
	}

	public virtual string GetText()
	{
		return string.Empty;
	}

	public Node GetAncestor(Type ancestorType)
	{
		for (Node parentNode = ParentNode; parentNode != null; parentNode = parentNode.ParentNode)
		{
			if (ancestorType.IsAssignableFrom(parentNode.GetType()))
			{
				return parentNode;
			}
		}
		return null;
	}

	public Node GetAncestor(NodeType ancestorType)
	{
		for (Node parentNode = ParentNode; parentNode != null; parentNode = parentNode.ParentNode)
		{
			if (parentNode.NodeType == ancestorType)
			{
				return parentNode;
			}
		}
		return null;
	}

	public void Remove()
	{
		if (ParentNode == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hiaeckhemkoejkffhkmfjkdgcfkgbkbhbjihgjphfjgijjnifiejndljmhckmhjkhhalchhldiolohfmngmmfcdnghknhgbobgiolgpolfgpdbnpjfeaaglakacbffjbdfacbahcoeocmdfdkemdkddeaekedebfkphf", 1229733956)));
		}
		ParentNode.RemoveChild(this);
	}

	internal void xb2b69aae23a4ae6d(Node x8b2c3c076d5a7daf)
	{
		x8a08cc7cfe65e03b = ((x8b2c3c076d5a7daf != null) ? x8b2c3c076d5a7daf : Document.x01d8b78e1a402cbd);
	}

	internal void x3e229cd2762a6ef5(DocumentBase x6beba47238e0ade6)
	{
		x8a08cc7cfe65e03b = x6beba47238e0ade6?.x01d8b78e1a402cbd;
	}

	internal bool xd5b26cfce8730b50(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 == null)
		{
			throw new ArgumentNullException("node");
		}
		Node parentNode = ParentNode;
		while (parentNode != null && parentNode != this)
		{
			if (parentNode == xda5bf54deb817e37)
			{
				return true;
			}
			parentNode = parentNode.ParentNode;
		}
		return false;
	}

	internal virtual int x2e39a445d52f6ea8()
	{
		return GetText().Length;
	}

	public Node NextPreOrder(Node rootNode)
	{
		Node node = (IsComposite ? ((CompositeNode)this).FirstChild : null);
		if (node == null)
		{
			node = this;
			while (node != null && node != rootNode && node.NextSibling == null)
			{
				node = node.ParentNode;
			}
			if (node != null && node != rootNode)
			{
				node = node.NextSibling;
			}
		}
		if (node == rootNode)
		{
			node = null;
		}
		return node;
	}

	public Node PreviousPreOrder(Node rootNode)
	{
		Node node = PreviousSibling;
		while (node != null)
		{
			Node node2 = (node.IsComposite ? ((CompositeNode)node).LastChild : null);
			if (node2 == null)
			{
				break;
			}
			node = node2;
		}
		if (node == null)
		{
			node = ParentNode;
		}
		if (node == rootNode)
		{
			node = null;
		}
		return node;
	}

	internal Node x03a9a1b8afdf52f9(NodeType x558c88d8389dcfcf)
	{
		Node nextSibling = NextSibling;
		while (nextSibling != null && x558c88d8389dcfcf != nextSibling.NodeType)
		{
			nextSibling = nextSibling.NextSibling;
		}
		return nextSibling;
	}

	internal Node x10b66a8c4aa7ed78(NodeType x558c88d8389dcfcf)
	{
		Node previousSibling = PreviousSibling;
		while (previousSibling != null && x558c88d8389dcfcf != previousSibling.NodeType)
		{
			previousSibling = previousSibling.PreviousSibling;
		}
		return previousSibling;
	}

	[Obsolete("Use ToString(SaveFormat.Text) instead.")]
	public string ToTxt()
	{
		return ToString(SaveFormat.Text);
	}

	public string ToString(SaveFormat saveFormat)
	{
		x2e1772435f9b2289 x2e1772435f9b = xf125d554503b428e.x5ebf8e7e695c1d1f(saveFormat);
		return x2e1772435f9b.xa45b9f6fb2389318(this);
	}

	public string ToString(SaveOptions saveOptions)
	{
		x2e1772435f9b2289 x2e1772435f9b = xf125d554503b428e.x5ebf8e7e695c1d1f(saveOptions);
		return x2e1772435f9b.xa45b9f6fb2389318(this);
	}

	internal Node xbf2f86e9a68ae8e6(NodeType x558c88d8389dcfcf)
	{
		for (Node parentNode = ParentNode; parentNode != null; parentNode = parentNode.ParentNode)
		{
			if (parentNode.NodeType == x558c88d8389dcfcf)
			{
				return parentNode;
			}
			if (x2b1ee3a87b36a988.xb871ce087a6d574e(parentNode))
			{
				if (x558c88d8389dcfcf != 0)
				{
					break;
				}
				return parentNode;
			}
		}
		return null;
	}

	internal x98739d759efb5fe7 x3df2fc2e9da31f50()
	{
		Node previousSibling = PreviousSibling;
		if (previousSibling == null)
		{
			return x98739d759efb5fe7.xf86191ae51e45118(ParentNode);
		}
		return x98739d759efb5fe7.xeea9b43f0c912fdb(previousSibling);
	}

	internal x98739d759efb5fe7 x94cfa410ea3bb516()
	{
		Node nextSibling = NextSibling;
		if (nextSibling == null)
		{
			return x98739d759efb5fe7.xeea9b43f0c912fdb(ParentNode);
		}
		return x98739d759efb5fe7.xf86191ae51e45118(nextSibling);
	}

	internal bool x026dc2547516c59d(Node xda5bf54deb817e37)
	{
		return x24ebc4e51712ba1a(this, xda5bf54deb817e37);
	}

	internal static bool x24ebc4e51712ba1a(Node x19218ffab70283ef, Node xe7ebe10fa44d8d49)
	{
		if (x19218ffab70283ef == null || xe7ebe10fa44d8d49 == null)
		{
			return false;
		}
		Stack stack = xee198f7d5df9d377(x19218ffab70283ef);
		Stack stack2 = xee198f7d5df9d377(xe7ebe10fa44d8d49);
		Node node = (Node)x4fb73b2c7e843600(stack, stack2);
		if (node == null)
		{
			return false;
		}
		if (stack.Count == 0 || stack2.Count == 0)
		{
			return stack2.Count > 0;
		}
		object obj = stack.Peek();
		object obj2 = stack2.Peek();
		foreach (Node childNode in ((CompositeNode)node).ChildNodes)
		{
			if (childNode == obj)
			{
				return true;
			}
			if (childNode == obj2)
			{
				return false;
			}
		}
		return false;
	}

	private static Stack xee198f7d5df9d377(Node xda5bf54deb817e37)
	{
		Stack stack = new Stack();
		for (Node node = xda5bf54deb817e37; node != null; node = node.ParentNode)
		{
			stack.Push(node);
		}
		return stack;
	}

	private static object x4fb73b2c7e843600(Stack x19218ffab70283ef, Stack xe7ebe10fa44d8d49)
	{
		object result = null;
		while (x19218ffab70283ef.Peek() == xe7ebe10fa44d8d49.Peek())
		{
			result = x19218ffab70283ef.Pop();
			xe7ebe10fa44d8d49.Pop();
			if (x19218ffab70283ef.Count == 0 || xe7ebe10fa44d8d49.Count == 0)
			{
				break;
			}
		}
		return result;
	}

	public static string NodeTypeToString(NodeType nodeType)
	{
		return nodeType switch
		{
			NodeType.Any => "Any", 
			NodeType.Document => "Document", 
			NodeType.Section => "Section", 
			NodeType.Body => "Body", 
			NodeType.HeaderFooter => "HeaderFooter", 
			NodeType.Table => "Table", 
			NodeType.Row => "Row", 
			NodeType.Cell => "Cell", 
			NodeType.Paragraph => "Paragraph", 
			NodeType.BookmarkStart => "BookmarkStart", 
			NodeType.BookmarkEnd => "BookmarkEnd", 
			NodeType.GroupShape => "GroupShape", 
			NodeType.Shape => "Shape", 
			NodeType.Comment => "Comment", 
			NodeType.Footnote => "Footnote", 
			NodeType.Run => "Run", 
			NodeType.FieldStart => "FieldStart", 
			NodeType.FieldSeparator => "FieldSeparator", 
			NodeType.FieldEnd => "FieldEnd", 
			NodeType.FormField => "FormField", 
			NodeType.SpecialChar => "SpecialChar", 
			NodeType.SmartTag => "SmartTag", 
			NodeType.CustomXmlMarkup => "CustomXmlMarkup", 
			NodeType.StructuredDocumentTag => "StructuredDocumentTag", 
			NodeType.GlossaryDocument => "GlossaryDocument", 
			NodeType.BuildingBlock => "BuildingBlock", 
			NodeType.CommentRangeStart => "CommentRangeStart", 
			NodeType.CommentRangeEnd => "CommentRangeEnd", 
			NodeType.DrawingML => "DrawingML", 
			NodeType.OfficeMath => "OfficeMath", 
			NodeType.SubDocument => "SubDocument", 
			NodeType.System => "System", 
			NodeType.Null => "Null", 
			_ => "Unknown node type.", 
		};
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void x466dd296f7338c95(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xcbdf0bfb4ca95676(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal void x0f1c14ed23045dd1(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal void x7d47e950edb3a736(params object[] xcd31b50c43a96e21)
	{
	}
}
