using ns307;
using ns308;

namespace ns305;

internal class Class6981 : Class6976, Interface369
{
	protected Class7096 class7096_0;

	private Class7063 class7063_0;

	private Class6976 class6976_2;

	public override string LocalName => class7096_0.LocalName;

	public override string NamespaceURI => class7096_0.NamespaceURI;

	public override string Prefix
	{
		get
		{
			return class7096_0.Prefix;
		}
		set
		{
			class7096_0.Prefix = base.OwnerDocument.NameTable.Add(value);
		}
	}

	public string TagName => LocalName.ToUpper();

	public override Class7063 Attributes => class7063_0;

	public Class7095 SchemaTypeInfo => new Class7095(this);

	public override string NodeName => TagName;

	public override Enum969 NodeType => Enum969.const_0;

	public Class6981 FirstElementChild
	{
		get
		{
			using Interface372 @interface = ((Interface368)base.OwnerDocument).imethod_1((Class6976)this, 1, (Interface370)null, entityReferenceExpansion: false);
			return @interface.imethod_1() as Class6981;
		}
	}

	public Class6981 LastElementChild
	{
		get
		{
			using Interface372 @interface = ((Interface368)base.OwnerDocument).imethod_1((Class6976)this, 1, (Interface370)null, entityReferenceExpansion: false);
			return @interface.imethod_2() as Class6981;
		}
	}

	public Class6981 PreviousElementSibling
	{
		get
		{
			Class6976 previousSibling = base.PreviousSibling;
			if (previousSibling == null)
			{
				return null;
			}
			using Interface371 @interface = ((Interface368)base.OwnerDocument).imethod_0(previousSibling, 1, (Interface370)null, entityReferenceExpansion: false);
			return @interface.imethod_1() as Class6981;
		}
	}

	public Class6981 NextElementSibling
	{
		get
		{
			if (base.NextSibling == null)
			{
				return null;
			}
			using Interface371 @interface = ((Interface368)base.OwnerDocument).imethod_0(base.NextSibling, 1, (Interface370)null, entityReferenceExpansion: false);
			return @interface.imethod_0() as Class6981;
		}
	}

	public long ChildElementCount => new Class7084(this).Length;

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

	protected internal Class6981(Class7096 name, Class7046 doc)
		: base(doc)
	{
		class7096_0 = name;
		class7063_0 = new Class7063(this);
	}

	public string method_20(string name)
	{
		return method_23(name)?.Value;
	}

	public void method_21(string name, string value)
	{
		Class7045 @class = method_23(name);
		if (@class != null)
		{
			@class.Value = value;
			return;
		}
		@class = base.OwnerDocument.method_25(name);
		@class.Value = value;
		method_24(@class);
	}

	public void method_22(string name)
	{
		class7063_0.method_13(name);
	}

	public Class7045 method_23(string name)
	{
		return class7063_0.method_11(name);
	}

	public Class7045 method_24(Class7045 newAttr)
	{
		return class7063_0.method_12(newAttr);
	}

	public Class7045 method_25(Class7045 oldAttr)
	{
		return class7063_0.method_14(oldAttr);
	}

	public Class7075 method_26(string name)
	{
		return new Class7084(this, name);
	}

	public Class6981 method_27(string tagName)
	{
		if (base.FirstChild == null)
		{
			return null;
		}
		Interface371 @interface = new Class7072(base.FirstChild, 1, new Class7070(tagName), entityReferenceExpansion: false);
		return @interface.imethod_0() as Class6981;
	}

	public string method_28(string namespaceURI, string localName)
	{
		return class7063_0.method_15(namespaceURI, localName)?.Value;
	}

	public void method_29(string namespaceURI, string qualifiedName, string value)
	{
		Class7045 @class = class7063_0.method_15(namespaceURI, qualifiedName);
		if (@class != null)
		{
			@class.Value = value;
			return;
		}
		@class = base.OwnerDocument.method_26(namespaceURI, qualifiedName);
		@class.Value = value;
		method_24(@class);
	}

	public void method_30(string namespaceURI, string localName)
	{
		class7063_0.method_17(namespaceURI, localName);
	}

	public Class7045 method_31(string namespaceURI, string localName)
	{
		return class7063_0.method_15(namespaceURI, localName);
	}

	public Class7045 method_32(Class7045 newAttr)
	{
		return class7063_0.method_16(newAttr);
	}

	public Class7075 method_33(string namespaceURI, string localName)
	{
		return new Class7084(this, namespaceURI, localName);
	}

	public bool method_34(string name)
	{
		return Attributes.method_4(name) != null;
	}

	public bool method_35(string namespaceURI, string localName)
	{
		return class7063_0.method_15(namespaceURI, localName) != null;
	}

	public void method_36(string name, bool isId)
	{
		Class7045 @class = method_23(name);
		if (@class != null)
		{
			@class.IsId = isId;
		}
	}

	public void method_37(string namespaceURI, string localName, bool isId)
	{
		Class7045 @class = method_31(namespaceURI, localName);
		if (@class != null)
		{
			@class.IsId = isId;
		}
	}

	public void method_38(Class7045 idAttr, bool isId)
	{
		Class7045 @class = method_23(idAttr.Name);
		if (@class != null)
		{
			@class.IsId = isId;
		}
	}

	public override Class6976 vmethod_2(bool deep)
	{
		Class6981 @class = base.OwnerDocument.CreateElement(Prefix, LocalName, NamespaceURI);
		if (method_6())
		{
			foreach (Class7045 item in class7063_0)
			{
				Class7045 node = (Class7045)item.vmethod_2(deep: true);
				@class.Attributes.AddNode(node);
			}
		}
		if (deep)
		{
			for (Class6976 class2 = base.FirstChild; class2 != null; class2 = class2.NextSibling)
			{
				@class.vmethod_1(class2.vmethod_2(deep));
			}
		}
		return @class;
	}
}
