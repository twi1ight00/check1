using System.Collections;
using System.Collections.Generic;
using System.Text;
using ns305;
using ns306;
using ns73;
using ns74;
using ns76;
using ns84;

namespace ns284;

internal class Class6983 : Class6982, Interface90, Interface91
{
	private Interface329 interface329_0;

	internal string string_0;

	private Interface69 interface69_0;

	private bool bool_0;

	private Interface66 interface66_0;

	private Interface58 interface58_0;

	private Interface58 interface58_1;

	private Hashtable hashtable_0 = new Hashtable();

	private string string_1 = "DEFAULT_STYLE";

	private Class3699 class3699_0;

	internal Class4347 StyleDeclarationInternal => Class4347.smethod_1(this);

	public new Interface329 Style
	{
		get
		{
			return interface329_0;
		}
		set
		{
			interface329_0 = value;
		}
	}

	internal Class6983 ParentElement => base.ParentNode as Class6983;

	public string OuterHtml
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("<{0}", class7096_0.Name);
			if (Attributes.Length != 0)
			{
				stringBuilder.Append(" ");
				for (int i = 0; i < Attributes.Length; i++)
				{
					Class7045 @class = Attributes[i];
					stringBuilder.AppendFormat("{0}='{1}'", @class.Name, @class.Value);
					if (i != Attributes.Length - 1)
					{
						stringBuilder.Append(" ");
					}
				}
			}
			stringBuilder.Append(">").Append(InnerHtml).AppendFormat("</{0}>", class7096_0.Name);
			return stringBuilder.ToString();
		}
	}

	public string InnerHtml
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (Class6976 @class = base.FirstChild; @class != null; @class = @class.NextSibling)
			{
				if (@class.NodeType == Enum969.const_0)
				{
					stringBuilder.Append(((Class6983)@class).OuterHtml);
				}
				else if (@class.NodeType == Enum969.const_2)
				{
					stringBuilder.Append(@class.NodeValue);
				}
			}
			return stringBuilder.ToString();
		}
	}

	internal Interface69 CSSEngine
	{
		get
		{
			if (interface69_0 == null)
			{
				interface69_0 = ((Interface89)base.OwnerDocument).Engine;
			}
			return interface69_0;
		}
	}

	Interface58 Interface90.Style
	{
		get
		{
			if (interface58_1 == null)
			{
				if (!method_34("style"))
				{
					interface58_1 = CSSEngine.imethod_6(string.Empty, this);
				}
				else
				{
					string text = method_20("style") ?? string.Empty;
					if (text.IndexOf('&') != -1)
					{
						text = text.Replace("&quot;", "\"");
					}
					interface58_1 = CSSEngine.imethod_6(text, this);
				}
			}
			return interface58_1;
		}
	}

	public Interface66 Counters
	{
		get
		{
			if (interface66_0 == null)
			{
				interface66_0 = CSSEngine.imethod_10(this);
			}
			return interface66_0;
		}
	}

	internal Interface57 InternalStyleCSS2
	{
		get
		{
			if (class3699_0 == null)
			{
				class3699_0 = new Class3699(imethod_2());
			}
			return class3699_0;
		}
	}

	protected internal Class6983(Class7096 name, Class7046 doc)
		: this(name, doc, isBlockContainerElement: true)
	{
		bool_0 = true;
	}

	protected internal Class6983(Class7096 name, Class7046 doc, bool isBlockContainerElement)
		: base(name, doc)
	{
		bool_0 = isBlockContainerElement;
	}

	public virtual void vmethod_5(Interface325 visitor)
	{
		if (StyleDeclarationInternal != null && StyleDeclarationInternal.Display.Value != Enum630.const_21)
		{
			if (bool_0)
			{
				visitor.imethod_11(this);
			}
			else
			{
				visitor.imethod_3(this);
			}
			if (StyleDeclarationInternal.Display.Value != Enum630.const_6)
			{
				method_48(visitor);
			}
			if (bool_0)
			{
				visitor.imethod_12(this);
			}
			else
			{
				visitor.imethod_4(this);
			}
		}
	}

	internal void method_48(Interface325 visitor)
	{
		for (Class6976 @class = base.FirstChild; @class != null; @class = @class.NextSibling)
		{
			if (@class is Class6983 class2)
			{
				class2.vmethod_5(visitor);
			}
			else if (@class is Class6980 text)
			{
				visitor.imethod_19(text);
			}
		}
	}

	internal T method_49<T>() where T : class
	{
		Class6983 parentElement = ParentElement;
		T val;
		while (true)
		{
			if (parentElement != null)
			{
				val = parentElement as T;
				if (val != null)
				{
					break;
				}
				parentElement = parentElement.ParentElement;
				continue;
			}
			return null;
		}
		return val;
	}

	internal T method_50<T>() where T : class
	{
		Class6981 @class = base.FirstElementChild;
		T val;
		while (true)
		{
			if (@class != null)
			{
				val = @class as T;
				if (val != null)
				{
					break;
				}
				@class = @class.NextElementSibling;
				continue;
			}
			return null;
		}
		return val;
	}

	protected int method_51(IEnumerable<Class6976> collection)
	{
		IEnumerator<Class6976> enumerator = collection.GetEnumerator();
		int num = -1;
		do
		{
			if (enumerator.MoveNext())
			{
				if (enumerator.Current != null)
				{
					num++;
					continue;
				}
				return -1;
			}
			return -1;
		}
		while (!enumerator.Current.Equals(this));
		return num;
	}

	protected void method_52(string attr, bool on)
	{
		if (on && !Attributes.Contains(attr))
		{
			Attributes.method_12(base.OwnerDocument.method_25(attr));
		}
		else if (!on && Attributes.Contains(attr))
		{
			Attributes.method_13(attr);
		}
	}

	public Class4074 imethod_0(string pseudoElement)
	{
		pseudoElement = ((!string.IsNullOrEmpty(pseudoElement)) ? pseudoElement.ToUpperInvariant() : string_1);
		if (hashtable_0.ContainsKey(pseudoElement))
		{
			return (Class4074)hashtable_0[pseudoElement];
		}
		return null;
	}

	public void imethod_1(string pseudoElement, Class4074 styleMap)
	{
		pseudoElement = ((!string.IsNullOrEmpty(pseudoElement)) ? pseudoElement.ToUpperInvariant() : string_1);
		if (hashtable_0.ContainsKey(pseudoElement))
		{
			hashtable_0[pseudoElement] = styleMap;
		}
		else
		{
			hashtable_0.Add(pseudoElement, styleMap);
		}
	}

	public Interface58 imethod_2()
	{
		if (interface58_0 == null)
		{
			interface58_0 = CSSEngine.imethod_7(this);
		}
		return interface58_0;
	}
}
