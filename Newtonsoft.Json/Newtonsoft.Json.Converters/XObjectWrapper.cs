using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters;

internal class XObjectWrapper : IXmlNode
{
	private static readonly List<IXmlNode> EmptyChildNodes = new List<IXmlNode>();

	private readonly XObject _xmlObject;

	public object WrappedNode => _xmlObject;

	public virtual XmlNodeType NodeType => _xmlObject.NodeType;

	public virtual string LocalName => null;

	public virtual List<IXmlNode> ChildNodes => EmptyChildNodes;

	public virtual List<IXmlNode> Attributes => null;

	public virtual IXmlNode ParentNode => null;

	public virtual string Value
	{
		get
		{
			return null;
		}
		set
		{
			throw new InvalidOperationException();
		}
	}

	public virtual string NamespaceUri => null;

	public XObjectWrapper(XObject xmlObject)
	{
		_xmlObject = xmlObject;
	}

	public virtual IXmlNode AppendChild(IXmlNode newChild)
	{
		throw new InvalidOperationException();
	}
}
