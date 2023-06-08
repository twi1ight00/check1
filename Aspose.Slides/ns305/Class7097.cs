using System;
using System.Xml;

namespace ns305;

internal class Class7097 : Interface367
{
	private XmlNameTable xmlNameTable_0;

	private XmlNamespaceManager xmlNamespaceManager_0;

	private Class7057 class7057_0;

	private string string_0;

	internal XmlNameTable NameTable => xmlNameTable_0;

	internal XmlNamespaceManager NamespaceManager => xmlNamespaceManager_0;

	internal Class7057 Factory => class7057_0;

	public Class7097(Class7057 factory, string feature)
		: this(new NameTable(), factory, feature)
	{
	}

	internal Class7097(XmlNameTable nt, Class7057 factory, string feature)
	{
		xmlNamespaceManager_0 = new XmlNamespaceManager(nt);
		xmlNameTable_0 = nt;
		class7057_0 = factory;
		string_0 = feature;
	}

	public virtual bool imethod_1(string feature, string version)
	{
		return string_0.Equals(feature, StringComparison.OrdinalIgnoreCase);
	}

	public virtual Class7049 imethod_2(string qualifiedName, string publicId, string systemId)
	{
		return new Class7049(qualifiedName, publicId, systemId, null, null);
	}

	public Class7046 imethod_0(string namespaceURI, string qualifiedName, Class7049 doctype)
	{
		Class7046 @class = ((class7057_0 == null) ? new Class7046(this) : class7057_0.vmethod_0(this));
		@class.NamespaceManager.AddNamespace(string.Empty, namespaceURI);
		if (doctype != null)
		{
			@class.vmethod_1(doctype);
		}
		return @class;
	}

	public object imethod_3(string feature, string version)
	{
		return this;
	}
}
