using System;
using System.Collections.Generic;
using System.Xml;
using ns304;
using ns307;
using ns308;

namespace ns305;

internal class Class7046 : Class6976, Interface364, Interface368
{
	private Class7097 class7097_0;

	internal readonly string string_0;

	internal readonly string string_1;

	internal readonly string string_2;

	internal readonly string string_3;

	internal readonly string string_4;

	internal readonly string string_5;

	internal readonly string string_6;

	internal string string_7;

	internal string string_8;

	internal string string_9;

	internal string string_10;

	internal string string_11;

	internal string string_12;

	internal string string_13;

	private bool bool_0;

	private string string_14;

	private Class7073 class7073_0;

	private Class6976 class6976_2;

	internal XmlNameTable NameTable => class7097_0.NameTable;

	public XmlNamespaceManager NamespaceManager => class7097_0.NamespaceManager;

	public Class7049 Doctype => vmethod_5(Enum969.const_9) as Class7049;

	public Class7097 Implementation => class7097_0;

	public Class6981 DocumentElement
	{
		get
		{
			Class6981 @class = vmethod_6("HTML");
			if (@class != null)
			{
				return @class;
			}
			return vmethod_5(Enum969.const_0) as Class6981;
		}
	}

	internal Class7044 Declaration => base.FirstChild as Class7044;

	public string InputEncoding => null;

	public string XmlEncoding => Declaration?.Encoding;

	public bool XmlStandalone
	{
		get
		{
			Class7044 declaration = Declaration;
			if (declaration != null)
			{
				return declaration.Standalone == "yes";
			}
			return false;
		}
		set
		{
			Class7044 declaration = Declaration;
			if (declaration != null)
			{
				declaration.Standalone = (value ? "yes" : "no");
			}
		}
	}

	public string XmlVersion
	{
		get
		{
			return Declaration?.Version;
		}
		set
		{
			Class7044 declaration = Declaration;
			if (declaration != null)
			{
				declaration.Version = value;
			}
		}
	}

	public bool StrictErrorChecking
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public string DocumentURI
	{
		get
		{
			return string_14;
		}
		internal set
		{
			string_14 = value;
		}
	}

	public Class7073 DomConfig
	{
		get
		{
			if (class7073_0 == null)
			{
				class7073_0 = new Class7073();
			}
			return class7073_0;
		}
	}

	public override string BaseURI => string_14;

	public override string NodeName => string_3;

	public override Enum969 NodeType => Enum969.const_8;

	internal override Class6976 LastNode
	{
		get
		{
			return class6976_2;
		}
		set
		{
			class6976_2 = value;
		}
	}

	protected Class7046()
		: this(new Class7097(null, "html"))
	{
	}

	protected internal Class7046(Class7097 implementation)
	{
		class7097_0 = implementation;
		XmlNameTable nameTable = NameTable;
		string_3 = nameTable.Add("#document");
		string_2 = nameTable.Add("#document-fragment");
		string_1 = nameTable.Add("#comment");
		string_6 = nameTable.Add("#text");
		string_0 = nameTable.Add("#cdata-section");
		string_5 = nameTable.Add("#entity");
		string_13 = nameTable.Add("xmlns");
		string_12 = nameTable.Add("xml");
		string_8 = nameTable.Add("http://www.w3.org/2000/xmlns/");
		string_7 = nameTable.Add("http://www.w3.org/XML/1998/namespace");
		string_9 = nameTable.Add("http://www.w3.org/1999/xhtml");
	}

	protected virtual Class6976 vmethod_5(Enum969 type)
	{
		Class6976 @class = base.FirstChild;
		while (true)
		{
			if (@class != null)
			{
				if (@class.NodeType == type)
				{
					break;
				}
				@class = @class.NextSibling;
				continue;
			}
			return null;
		}
		return @class;
	}

	protected virtual Class6981 vmethod_6(string tagName)
	{
		Interface371 @interface = ((Interface368)this).imethod_0(base.FirstChild, 1, (Interface370)new Class7070(tagName), entityReferenceExpansion: false);
		return @interface.imethod_0() as Class6981;
	}

	public Class6981 CreateElement(string tagName)
	{
		Class6976.smethod_0(tagName, out var prefix, out var localName);
		return CreateElement(prefix, localName, null);
	}

	public virtual Class6981 CreateElement(string prefix, string localName, string namespaceURI)
	{
		if (class7097_0.Factory != null)
		{
			return class7097_0.Factory.CreateElement(new Class7096(prefix, localName, namespaceURI, this), this);
		}
		return new Class6981(new Class7096(prefix, localName, namespaceURI, this), this);
	}

	public Class7048 method_20()
	{
		return new Class7048(this);
	}

	public Class6980 method_21(string data)
	{
		return new Class6980(data, this);
	}

	public Class6979 method_22(string data)
	{
		return new Class6979(data, this);
	}

	public Class6978 method_23(string data)
	{
		return new Class6978(data, this);
	}

	public Class7053 method_24(string target, string data)
	{
		return new Class7053(target, data, this);
	}

	public Class7045 method_25(string name)
	{
		string prefix = string.Empty;
		string localName = string.Empty;
		string empty = string.Empty;
		Class6976.smethod_0(name, out prefix, out localName);
		return method_27(prefix, localName, empty);
	}

	public Class7045 method_26(string namespaceURI, string qualifiedName)
	{
		string prefix = string.Empty;
		string localName = string.Empty;
		Class6976.smethod_0(qualifiedName, out prefix, out localName);
		return method_27(prefix, localName, namespaceURI);
	}

	public Class7045 method_27(string prefix, string localName, string namespaceURI)
	{
		Class7096 name = new Class7096(prefix, localName, namespaceURI, this);
		Class7045 @class = new Class7045(name, this);
		if (class7097_0.Factory != null)
		{
			@class.IsId = class7097_0.Factory.vmethod_1(name);
		}
		return @class;
	}

	public Class7052 method_28(string name)
	{
		return new Class7052(name, this);
	}

	public Class7044 method_29(string version, string encoding, string standalone)
	{
		return new Class7044(version, encoding, standalone, this);
	}

	public Class7049 method_30(string name, string publicId, string systemId, string internalSubset)
	{
		return new Class7049(name, publicId, systemId, internalSubset, this);
	}

	public Class7075 method_31(string tagname)
	{
		return new Class7084(this, tagname);
	}

	public Class7075 method_32(IEnumerable<string> tags)
	{
		return new Class7084(this, tags);
	}

	protected Class7075 method_33(IDictionary<string, IEnumerable<KeyValuePair<string, string>>> tagsAttrs)
	{
		return new Class7084(this, tagsAttrs, Enum964.const_0);
	}

	protected Class7075 method_34(IDictionary<string, IEnumerable<KeyValuePair<string, string>>> tagsAttrs)
	{
		return new Class7084(this, tagsAttrs, Enum964.const_1);
	}

	public Class6976 method_35(Class6976 importedNode, bool deep)
	{
		importedNode.vmethod_2(deep);
		importedNode.vmethod_4(this);
		return importedNode;
	}

	public Class6981 method_36(string namespaceURI, string qualifiedName)
	{
		Class6976.smethod_0(qualifiedName, out var prefix, out var localName);
		NamespaceManager.PushScope();
		NamespaceManager.AddNamespace(prefix, namespaceURI);
		Class6981 result = CreateElement(prefix, localName, namespaceURI);
		NamespaceManager.PopScope();
		return result;
	}

	public Class7045 method_37(string namespaceURI, string qualifiedName)
	{
		Class6976.smethod_0(qualifiedName, out var prefix, out var localName);
		return method_27(prefix, localName, namespaceURI);
	}

	public Class7075 method_38(string namespaceURI, string localName)
	{
		return new Class7084(this, namespaceURI, localName);
	}

	public Class6981 method_39(string elementId)
	{
		using Interface372 @interface = ((Interface368)base.OwnerDocument).imethod_1((Class6976)this, 1, (Interface370)new Class7069(elementId), entityReferenceExpansion: false);
		return @interface.imethod_6() as Class6981;
	}

	public Class6976 method_40(Class6976 source)
	{
		throw new NotImplementedException();
	}

	public virtual void vmethod_7()
	{
	}

	public Class6976 method_41(Class6976 n, string namespaceURI, string qualifiedName)
	{
		throw new NotImplementedException();
	}

	public override Class6976 vmethod_2(bool deep)
	{
		Class7046 @class = Implementation.imethod_0(NamespaceURI, NodeName, Doctype);
		@class.DocumentURI = DocumentURI;
		return @class;
	}

	Interface371 Interface368.imethod_0(Class6976 root, int whatToShow, Interface370 filter, bool entityReferenceExpansion)
	{
		return new Class7072(root, whatToShow, filter, entityReferenceExpansion);
	}

	Interface372 Interface368.imethod_1(Class6976 root, int whatToShow, Interface370 filter, bool entityReferenceExpansion)
	{
		return new Class7071(root, whatToShow, filter, entityReferenceExpansion);
	}

	public Interface363 imethod_3(string eventType)
	{
		return null;
	}
}
