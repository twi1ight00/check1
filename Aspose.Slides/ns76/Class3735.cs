using System;
using System.Xml;
using ns305;
using ns73;

namespace ns76;

internal class Class3735 : Interface75, Interface76
{
	private Class3732 class3732_0;

	private Class3726 class3726_0;

	private Class6976 class6976_0;

	private Interface76 interface76_0;

	private string string_0;

	private Interface59 interface59_0;

	private string string_1;

	private Interface79 interface79_0;

	private bool bool_0;

	private XmlNamespaceManager xmlNamespaceManager_0;

	private NameTable nameTable_0;

	private Enum498 enum498_0;

	public string Type => "text/css";

	public bool Disabled
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

	public Class6976 OwnerNode => class6976_0;

	public Interface76 ParentStyleSheet
	{
		get
		{
			return interface76_0;
		}
		set
		{
			interface76_0 = value;
		}
	}

	Interface75 Interface75.ParentStyleSheet => ParentStyleSheet;

	public string Href
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	string Interface75.Href => Href;

	public string Title
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Interface79 Media => interface79_0;

	public Interface59 OwnerRule
	{
		get
		{
			return interface59_0;
		}
		set
		{
			interface59_0 = value;
		}
	}

	public Interface73 CSSRules => class3732_0;

	public Class3726 Engine => class3726_0;

	public XmlNamespaceManager NamespaceManager => xmlNamespaceManager_0;

	public Enum498 StyleSheetOrigins => enum498_0;

	public Class3735()
		: this(Enum498.const_0)
	{
	}

	public Class3735(Enum498 styleSheetOrigins)
	{
		class3732_0 = new Class3732(this);
		interface79_0 = new Class3736();
		nameTable_0 = new NameTable();
		xmlNamespaceManager_0 = new XmlNamespaceManager(nameTable_0);
		enum498_0 = styleSheetOrigins;
	}

	public void method_0(Class3726 engine, Class6976 ownerNode)
	{
		class3726_0 = engine;
		class6976_0 = ownerNode;
	}

	public long imethod_0(string rule, int index)
	{
		throw new NotImplementedException();
	}

	public void imethod_1(int index)
	{
		class3732_0.RemoveAt(index);
	}

	public override string ToString()
	{
		return class3732_0.ToString();
	}
}
