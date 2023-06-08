using System;
using System.Collections;
using System.Collections.Generic;
using ns283;
using ns284;
using ns301;
using ns305;
using ns73;
using ns74;
using ns76;

namespace ns287;

internal class Class7047 : Class7046, Interface56, Interface87, Interface88, Interface89
{
	private class Class6776 : IDisposable, IEnumerator, IEnumerator<Class6976>
	{
		private Class6976 class6976_0;

		private Class6976 class6976_1;

		private Class6976 class6976_2;

		private bool bool_0;

		public Class6976 Current => class6976_2;

		object IEnumerator.Current => Current;

		public Class6776(Class6976 element)
		{
			class6976_0 = element;
		}

		public void Dispose()
		{
			class6976_0 = null;
			class6976_1 = null;
			class6976_2 = null;
		}

		public bool MoveNext()
		{
			if (!bool_0)
			{
				class6976_2 = class6976_0.FirstChild;
				bool_0 = true;
				return class6976_2 != null;
			}
			if (class6976_2.ParentNode != class6976_0)
			{
				if (class6976_1 == null)
				{
					class6976_2 = class6976_0.FirstChild;
				}
				else
				{
					class6976_2 = class6976_1.NextSibling;
				}
			}
			else
			{
				class6976_1 = class6976_2;
				class6976_2 = class6976_2.NextSibling;
			}
			return class6976_2 != null;
		}

		public void Reset()
		{
			class6976_2 = class6976_2.FirstChild;
			class6976_1 = null;
		}
	}

	private string string_15;

	private Interface69 interface69_0;

	private Hashtable hashtable_0 = new Hashtable();

	private string string_16 = "DEFAULT_ELEMENT";

	private Class3734 class3734_0 = new Class3734();

	private Interface95 interface95_0;

	private Interface56 interface56_0;

	public string Title
	{
		get
		{
			return method_42()?.TextContent;
		}
		set
		{
			Class6983 @class = method_42();
			if (@class != null)
			{
				@class.TextContent = value;
			}
		}
	}

	public string Referrer => null;

	public string Domain => null;

	public string URL => null;

	public Class7001 Body
	{
		get
		{
			Class6981 @class = vmethod_6("HTML");
			if (@class == null)
			{
				return null;
			}
			return @class.method_27("BODY") as Class7001;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			Class7015 @class = (Class7015)vmethod_6("HTML");
			Class7001 body = Body;
			if (body != null)
			{
				@class.method_1(body, value);
			}
			else
			{
				@class.vmethod_1(value);
			}
		}
	}

	public Class7011 FrameSet
	{
		get
		{
			Class6981 @class = vmethod_6("HTML");
			if (@class == null)
			{
				return null;
			}
			return @class.method_27("FRAMESET") as Class7011;
		}
	}

	public Class7078 Images => new Class7081(method_31("IMG"));

	public Class7078 Applets
	{
		get
		{
			Dictionary<string, IEnumerable<KeyValuePair<string, string>>> dictionary = new Dictionary<string, IEnumerable<KeyValuePair<string, string>>>(2);
			dictionary.Add("APPLET", null);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>(2);
			list.Add(new KeyValuePair<string, string>("classid", "clsid:CAFEEFAC-00"));
			list.Add(new KeyValuePair<string, string>("classid", "clsid:8AD9C840-044E-11D1-B3E9-00805F499D93"));
			dictionary.Add("OBJECT", list);
			List<KeyValuePair<string, string>> list2 = new List<KeyValuePair<string, string>>(3);
			list2.Add(new KeyValuePair<string, string>("type", "application/x-java-applet"));
			list2.Add(new KeyValuePair<string, string>("type", "application/x-java-bean"));
			list2.Add(new KeyValuePair<string, string>("type", "application/x-java-vm"));
			dictionary.Add("EMBED", list2);
			return new Class7081(method_33(dictionary));
		}
	}

	public Class7078 Links
	{
		get
		{
			Dictionary<string, IEnumerable<KeyValuePair<string, string>>> dictionary = new Dictionary<string, IEnumerable<KeyValuePair<string, string>>>(2);
			dictionary.Add("A", new KeyValuePair<string, string>[1]
			{
				new KeyValuePair<string, string>("href", null)
			});
			dictionary.Add("AREA", null);
			return new Class7081(method_34(dictionary));
		}
	}

	public Class7078 Forms => new Class7081(method_31("FORM"));

	public Class7078 Anchors
	{
		get
		{
			Dictionary<string, IEnumerable<KeyValuePair<string, string>>> dictionary = new Dictionary<string, IEnumerable<KeyValuePair<string, string>>>(1);
			dictionary.Add("A", new KeyValuePair<string, string>[1]
			{
				new KeyValuePair<string, string>("name", null)
			});
			return new Class7081(method_34(dictionary));
		}
	}

	public string Cookie
	{
		get
		{
			return string_15;
		}
		set
		{
			string_15 = value;
		}
	}

	public Interface95 StyleSheets
	{
		get
		{
			if (interface95_0 == null)
			{
				interface95_0 = new Class6769(this);
			}
			return interface95_0;
		}
	}

	public Interface69 Engine
	{
		get
		{
			return interface69_0;
		}
		set
		{
			interface69_0 = value;
		}
	}

	public Interface56 DefaultView
	{
		get
		{
			if (interface56_0 == null)
			{
				interface56_0 = new Class3697(this);
			}
			return interface56_0;
		}
	}

	protected internal Class7047(Class7097 implementation)
		: base(implementation)
	{
	}

	private Class6983 method_42()
	{
		Class6981 @class = vmethod_6("HTML").method_27("HEAD");
		if (@class == null)
		{
			return null;
		}
		return @class.method_27("TITLE") as Class6983;
	}

	public void method_43()
	{
	}

	public void Close()
	{
	}

	public void Write(string text)
	{
	}

	public void method_44(string text)
	{
	}

	public Class7075 method_45(string elementName)
	{
		return method_31(elementName);
	}

	internal void method_46(Interface325 visitor)
	{
		if (base.DocumentElement is Class6983 @class)
		{
			@class.vmethod_5(visitor);
		}
	}

	public override void vmethod_7()
	{
		Class7015 @class = null;
		if (base.FirstChild != null)
		{
			@class = vmethod_6("HTML") as Class7015;
		}
		if (@class == null)
		{
			@class = (Class7015)CreateElement("HTML");
			Class6776 class2 = new Class6776(this);
			while (class2.MoveNext())
			{
				if (class2.Current.NodeType == Enum969.const_0 || class2.Current.NodeType == Enum969.const_2)
				{
					@class.vmethod_1(class2.Current);
				}
			}
			vmethod_1(@class);
		}
		for (Class6976 class3 = base.FirstChild; class3 != null; class3 = class3.NextSibling)
		{
			if (class3 != @class && (class3.NodeType == Enum969.const_0 || class3.NodeType == Enum969.const_2))
			{
				Class6976 class4 = class3.PreviousSibling;
				@class.vmethod_1(class3);
				if (class4 == null)
				{
					class4 = base.FirstChild;
				}
				class3 = class4;
			}
		}
		Class7075 class5 = @class.method_26("HTML");
		while (class5.Length != 0)
		{
			Class6976 class6 = class5[0];
			while (class6.FirstChild != null)
			{
				class6.ParentNode.method_0(class6.FirstChild, class6);
			}
			class6.ParentNode.method_2(class6);
		}
		Class7001 class7 = @class.method_27("BODY") as Class7001;
		Class7011 class8 = @class.method_27("FRAMESET") as Class7011;
		if (class7 == null && class8 == null)
		{
			class7 = (Class7001)CreateElement("BODY");
			Class6776 class9 = new Class6776(@class);
			while (class9.MoveNext())
			{
				if (class9.Current.NodeType == Enum969.const_0)
				{
					Class6981 class10 = (Class6981)class9.Current;
					switch (class10.TagName)
					{
					case "HEAD":
					case "BASE":
					case "COMMAND":
					case "LINK":
					case "META":
					case "STYLE":
					case "TITLE":
						continue;
					}
				}
				class7.vmethod_1(class9.Current);
			}
			@class.vmethod_1(class7);
		}
		Class7012 class11 = @class.method_27("HEAD") as Class7012;
		if (class11 == null)
		{
			class11 = (Class7012)CreateElement("HEAD");
			if (@class.FirstChild != null)
			{
				@class.method_0(class11, @class.FirstChild);
			}
			else
			{
				@class.vmethod_1(class11);
			}
		}
		Class6776 class12 = new Class6776(@class);
		Class6981 class13 = null;
		while (class12.MoveNext())
		{
			if (class12.Current.NodeType != Enum969.const_0)
			{
				continue;
			}
			Class6981 class14 = class12.Current as Class6981;
			switch (class14.TagName)
			{
			case "BASE":
			case "COMMAND":
			case "LINK":
			case "META":
			case "STYLE":
			case "TITLE":
				class11.vmethod_1(class14);
				continue;
			}
			if (class14 != class7 && class14 != class11 && class7 != null)
			{
				if (class13 == null)
				{
					class7.method_0(class14, class7.FirstChild);
				}
				else
				{
					class7.vmethod_0(class14, class13);
				}
				class13 = class14;
			}
		}
		if (class7 != null)
		{
			while (@class.LastChild != class7)
			{
				class7.vmethod_1(@class.LastChild);
			}
			Class7001 body = Body;
			Class6776 class15 = new Class6776(body);
			while (class15.MoveNext())
			{
				if (class15.Current.NodeType == Enum969.const_0)
				{
					method_47((Class6981)class15.Current, body, body, class11);
				}
			}
		}
		base.vmethod_7();
	}

	private void method_47(Class6981 htmlNode, Class6981 parent, Class6981 body, Class6981 head)
	{
		if (htmlNode.TagName.Equals("HTML"))
		{
			for (Class6976 @class = htmlNode.FirstChild; @class != null; @class = @class.NextSibling)
			{
				if (@class.FirstChild.NodeType == Enum969.const_0)
				{
					method_47((Class6981)@class, (Class6981)@class.ParentNode, body, head);
				}
			}
		}
		if (htmlNode.TagName.Equals("BODY"))
		{
			while (htmlNode.FirstChild != null)
			{
				Class6981 class2 = null;
				if (htmlNode.FirstChild.NodeType == Enum969.const_0)
				{
					class2 = (Class6981)htmlNode.FirstChild;
				}
				parent.method_0(htmlNode.FirstChild, htmlNode);
				if (class2 != null)
				{
					method_47(class2, parent, body, head);
				}
			}
			parent.method_2(htmlNode);
			return;
		}
		string tagName = htmlNode.TagName;
		string tagName2 = parent.TagName;
		if ((tagName.Equals("LI") && tagName2.Equals("LI")) || (tagName.Equals("TD") && tagName2.Equals("TH")) || (tagName.Equals("TD") && tagName2.Equals("TD")) || (tagName.Equals("TH") && tagName2.Equals("TH")) || (tagName.Equals("TR") && tagName2.Equals("TD")) || (tagName.Equals("TR") && tagName2.Equals("TH")) || (tagName.Equals("TR") && tagName2.Equals("TR")) || (tagName.Equals("DD") && tagName2.Equals("DT")) || (tagName.Equals("DD") && tagName2.Equals("DD")) || (tagName.Equals("DT") && tagName2.Equals("DD")))
		{
			htmlNode = (Class6981)parent.ParentNode.vmethod_1(htmlNode);
			parent = (Class6981)htmlNode.ParentNode;
		}
		if (tagName.Equals("FORM") && tagName2.Equals("TABLE"))
		{
			Class6776 class3 = new Class6776(htmlNode);
			Class6983 class4 = (Class6983)htmlNode.ParentNode;
			while (class3.MoveNext())
			{
				if (class3.Current.NodeType == Enum969.const_0)
				{
					if (class3.Current is Class7040 class5)
					{
						class4.vmethod_0(class5, htmlNode);
						method_47(class5, class4, body, head);
					}
					else
					{
						class4.ParentElement.method_0(class3.Current, class4);
					}
				}
				else
				{
					class4.ParentElement.method_0(class3.Current, class4);
				}
			}
		}
		if (htmlNode is Class7040)
		{
			if (!(parent is Class7041))
			{
				if (!(parent is Class6993))
				{
					while (htmlNode.FirstChild != null)
					{
						Class6981 class6 = null;
						if (htmlNode.FirstChild.NodeType == Enum969.const_0)
						{
							class6 = (Class6981)htmlNode.FirstChild;
						}
						parent.method_0(htmlNode.FirstChild, htmlNode);
						if (class6 != null)
						{
							method_47(class6, parent, body, head);
						}
					}
					parent.method_2(htmlNode);
				}
				else
				{
					Class6993 class7 = parent as Class6993;
					if (class7.Body == null)
					{
						Class6976 newChild = CreateElement("TBODY");
						parent.vmethod_1(newChild);
					}
					class7.Body.vmethod_1(htmlNode);
				}
			}
		}
		else if (htmlNode is Class7038 && !(parent is Class7040))
		{
			if (!(parent is Class7041))
			{
				if (!(parent is Class6993))
				{
					while (htmlNode.FirstChild != null)
					{
						Class6981 class8 = null;
						if (htmlNode.FirstChild.NodeType == Enum969.const_0)
						{
							class8 = (Class6981)htmlNode.FirstChild;
						}
						parent.method_0(htmlNode.FirstChild, htmlNode);
						if (class8 != null)
						{
							method_47(class8, parent, body, head);
						}
					}
					parent.method_2(htmlNode);
				}
				else
				{
					Class6993 class9 = parent as Class6993;
					if (class9.Body == null)
					{
						Class6976 newChild2 = CreateElement("TBODY");
						parent.vmethod_1(newChild2);
					}
					class9.Body.vmethod_1(htmlNode);
				}
			}
			else
			{
				Class6976 class10 = CreateElement("TR");
				parent.method_0(class10, htmlNode);
				Class6976 class11 = htmlNode;
				while (true)
				{
					Class6976 nextSibling = class11.NextSibling;
					class10.vmethod_1(class11);
					if (nextSibling == null || nextSibling.NodeType != Enum969.const_0 || ((Class6981)nextSibling).TagName != "TD")
					{
						break;
					}
					class11 = nextSibling;
				}
			}
		}
		Class6776 class12 = new Class6776(htmlNode);
		while (class12.MoveNext())
		{
			if (class12.Current.NodeType == Enum969.const_0)
			{
				method_47((Class6981)class12.Current, htmlNode, body, head);
			}
			else if (class12.Current.NodeType == Enum969.const_2 && htmlNode is Class7040 class13)
			{
				Class6993 class14 = class13.method_49<Class6993>();
				if (class14 != null && class14.ParentElement != null)
				{
					class14.ParentElement.method_0(class12.Current, class14);
				}
			}
		}
	}

	public Interface58 imethod_1(Class6981 elt, string pseudoElt)
	{
		return ((Interface91)elt).imethod_2();
	}

	public Class4074 imethod_2(string pseudoElement)
	{
		pseudoElement = ((!string.IsNullOrEmpty(pseudoElement)) ? pseudoElement.ToUpperInvariant() : string_16);
		if (hashtable_0.ContainsKey(pseudoElement))
		{
			return (Class4074)hashtable_0[pseudoElement];
		}
		return null;
	}

	public void imethod_3(string pseudoElement, Class4074 styleMap)
	{
		pseudoElement = ((!string.IsNullOrEmpty(pseudoElement)) ? pseudoElement.ToUpperInvariant() : string_16);
		if (hashtable_0.ContainsKey(pseudoElement))
		{
			hashtable_0[pseudoElement] = styleMap;
		}
		else
		{
			hashtable_0.Add(pseudoElement, styleMap);
		}
	}

	public Interface58 imethod_0(Class6981 element, string pseudoElement)
	{
		Interface91 @interface = (Interface91)element;
		Class4074 @class = @interface.imethod_0(pseudoElement);
		if (@class == null)
		{
			Engine.imethod_9(@interface);
			@class = @interface.imethod_0(pseudoElement);
		}
		return class3734_0.method_0(@class, interface69_0);
	}

	public void imethod_4(string styleSheet)
	{
		interface69_0.imethod_11(styleSheet);
	}

	public void imethod_5(string styleSheet)
	{
		interface69_0.imethod_12(styleSheet);
	}
}
