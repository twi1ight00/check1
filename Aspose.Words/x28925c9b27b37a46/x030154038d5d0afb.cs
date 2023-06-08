using System.Xml;
using System.Xml.XPath;
using Aspose;
using Aspose.Words;

namespace x28925c9b27b37a46;

[JavaManual("In Java this works with Jaxen Xpath engine.")]
internal class x030154038d5d0afb : XPathNavigator
{
	private readonly DocumentBase x232be220f517f721;

	private Node x5a4005b11b247c4d;

	private readonly NameTable xc95303b5a456bf7e;

	public override XPathNodeType NodeType
	{
		get
		{
			NodeType nodeType = x5a4005b11b247c4d.NodeType;
			if (nodeType == Aspose.Words.NodeType.Document || nodeType == Aspose.Words.NodeType.GlossaryDocument)
			{
				return XPathNodeType.Root;
			}
			return XPathNodeType.Element;
		}
	}

	public override string LocalName
	{
		get
		{
			xc95303b5a456bf7e.Add(Name);
			return xc95303b5a456bf7e.Get(Name);
		}
	}

	public override string Name => x5a4005b11b247c4d.GetType().Name;

	public override string Prefix => xc95303b5a456bf7e.Get(string.Empty);

	public override string NamespaceURI => xc95303b5a456bf7e.Get(string.Empty);

	public override string Value => x5a4005b11b247c4d.GetText();

	public override string BaseURI => string.Empty;

	public override string XmlLang => string.Empty;

	public override bool IsEmptyElement => false;

	public override XmlNameTable NameTable => xc95303b5a456bf7e;

	public override bool HasAttributes => false;

	public override bool HasChildren
	{
		get
		{
			if (x5a4005b11b247c4d.IsComposite)
			{
				return ((CompositeNode)x5a4005b11b247c4d).FirstChild != null;
			}
			return false;
		}
	}

	public Node x3387295f12854dfd => x5a4005b11b247c4d;

	internal static NodeList x478a82deb55cde7c(Node xda5bf54deb817e37, string x1f80364e7bdb9081)
	{
		XPathNavigator xPathNavigator = new x030154038d5d0afb(xda5bf54deb817e37);
		return new NodeList(xPathNavigator.Select(x1f80364e7bdb9081));
	}

	internal static Node x97bb330a631993a5(Node xda5bf54deb817e37, string x1f80364e7bdb9081)
	{
		XPathNavigator xPathNavigator = new x030154038d5d0afb(xda5bf54deb817e37);
		XPathNodeIterator xPathNodeIterator = xPathNavigator.Select(x1f80364e7bdb9081);
		if (xPathNodeIterator.MoveNext())
		{
			x030154038d5d0afb x030154038d5d0afb2 = (x030154038d5d0afb)xPathNodeIterator.Current;
			return x030154038d5d0afb2.x3387295f12854dfd;
		}
		return null;
	}

	internal x030154038d5d0afb(Node node)
	{
		x232be220f517f721 = node.Document;
		x5a4005b11b247c4d = node;
		xc95303b5a456bf7e = new NameTable();
		xc95303b5a456bf7e.Add(string.Empty);
	}

	private x030154038d5d0afb(x030154038d5d0afb src)
	{
		x232be220f517f721 = src.x232be220f517f721;
		x5a4005b11b247c4d = src.x5a4005b11b247c4d;
		xc95303b5a456bf7e = src.xc95303b5a456bf7e;
	}

	public override XPathNavigator Clone()
	{
		return new x030154038d5d0afb(this);
	}

	public override string GetAttribute(string localName, string namespaceURI)
	{
		return string.Empty;
	}

	public override bool MoveToAttribute(string localName, string namespaceURI)
	{
		return false;
	}

	public override bool MoveToFirstAttribute()
	{
		return false;
	}

	public override bool MoveToNextAttribute()
	{
		return false;
	}

	public override string GetNamespace(string name)
	{
		return string.Empty;
	}

	public override bool MoveToNamespace(string name)
	{
		return false;
	}

	public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
	{
		return false;
	}

	public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
	{
		return false;
	}

	public override bool MoveToNext()
	{
		return x01b2723108ff3dfe(x5a4005b11b247c4d.NextSibling);
	}

	public override bool MoveToPrevious()
	{
		return x01b2723108ff3dfe(x5a4005b11b247c4d.PreviousSibling);
	}

	public override bool MoveToFirst()
	{
		if (x5a4005b11b247c4d.ParentNode == null)
		{
			return false;
		}
		return x01b2723108ff3dfe(x5a4005b11b247c4d.ParentNode.FirstChild);
	}

	public override bool MoveToFirstChild()
	{
		if (!x5a4005b11b247c4d.IsComposite)
		{
			return false;
		}
		return x01b2723108ff3dfe(((CompositeNode)x5a4005b11b247c4d).FirstChild);
	}

	public override bool MoveToParent()
	{
		return x01b2723108ff3dfe(x5a4005b11b247c4d.ParentNode);
	}

	public override void MoveToRoot()
	{
		x01b2723108ff3dfe(x232be220f517f721);
	}

	public override bool MoveTo(XPathNavigator other)
	{
		return x01b2723108ff3dfe(((x030154038d5d0afb)other).x5a4005b11b247c4d);
	}

	public override bool MoveToId(string id)
	{
		return false;
	}

	public override bool IsSamePosition(XPathNavigator other)
	{
		return x5a4005b11b247c4d == ((x030154038d5d0afb)other).x5a4005b11b247c4d;
	}

	private bool x01b2723108ff3dfe(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 != null)
		{
			x5a4005b11b247c4d = xda5bf54deb817e37;
			return true;
		}
		return false;
	}
}
