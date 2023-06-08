using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using ns305;
using ns72;
using ns73;
using ns74;
using ns79;
using ns81;
using ns84;
using ns88;

namespace ns76;

internal class Class3726 : Interface69
{
	private class Class3727 : IEnumerable, IEnumerable<Class3728>
	{
		private List<Class3728> list_0 = new List<Class3728>();

		public int Count => list_0.Count;

		public IEnumerator<Class3728> GetEnumerator()
		{
			return list_0.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(Class3728 rule)
		{
			list_0.Add(rule);
		}

		internal void method_0(Class3727 rules)
		{
			foreach (Class3728 rule in rules)
			{
				list_0.Add(rule);
			}
		}

		internal void method_1()
		{
			if (list_0.Count == 0)
			{
				return;
			}
			Class3728[] array = new Class3728[list_0.Count];
			list_0.CopyTo(array);
			list_0.Clear();
			list_0.Insert(0, array[0]);
			for (int i = 1; i < array.Length; i++)
			{
				Class3728 @class = array[i];
				int specificity = @class.Specificity;
				int num = i - 1;
				while (num >= 0 && list_0[num].Specificity > specificity)
				{
					num--;
				}
				list_0.Insert(num + 1, @class);
			}
		}
	}

	[DebuggerDisplay("{rule.CSSText}")]
	private class Class3728
	{
		private int int_0;

		private Class4051 class4051_0;

		private Interface59 interface59_0;

		public Class4051 Selector => class4051_0;

		public Interface59 Rule => interface59_0;

		public int Specificity => int_0;

		public Class3728(Interface59 rule)
		{
			interface59_0 = rule;
		}

		public Class3728(Class4051 selector, Interface59 rule)
		{
			class4051_0 = selector;
			interface59_0 = rule;
			int_0 = selector.Specificity;
		}
	}

	private Interface89 interface89_0;

	private readonly Interface65 interface65_0;

	private Interface102 interface102_0 = Class4248.Instance;

	private Interface101 interface101_0;

	private List<Interface78> list_0 = new List<Interface78>();

	private Class4142 class4142_0 = new Class4142();

	private Class4072 class4072_0;

	private Class4143 class4143_0;

	private Class4073 class4073_0;

	private Class3548<int> class3548_0;

	private Class3547<Class3770> class3547_0;

	private Class3546<Enum600, Class3770> class3546_0;

	private Class3546<Enum600, int> class3546_1;

	private Class3546<int, Enum600> class3546_2;

	private Class3547<bool> class3547_1;

	private Interface76 interface76_0;

	private Interface76 interface76_1;

	internal static readonly CultureInfo cultureInfo_0 = new CultureInfo("en-US");

	public Interface89 Document => interface89_0;

	Interface65 Interface69.Context => interface65_0;

	public Class3723 Context => (Class3723)interface65_0;

	public Interface102 ErrorHandler
	{
		get
		{
			return interface102_0;
		}
		set
		{
			interface102_0 = value;
		}
	}

	public Interface101 DocumentHandler
	{
		get
		{
			return interface101_0;
		}
		set
		{
			interface101_0 = value;
		}
	}

	public Interface96 CounterStyles => class4143_0;

	public Class4073 SystemFonts => class4073_0;

	public Class3726(Interface89 document, Interface65 context)
	{
		interface89_0 = document;
		interface65_0 = context;
		IList<Class3770> list = new Class3769().method_0();
		class3548_0 = new Class3548<int>(-1);
		class3547_0 = new Class3547<Class3770>();
		class3546_0 = new Class3546<Enum600, Class3770>();
		class3546_1 = new Class3546<Enum600, int>(-1);
		class3546_2 = new Class3546<int, Enum600>();
		class3547_1 = new Class3547<bool>();
		for (int i = 0; i < list.Count; i++)
		{
			class3547_0.method_0(i, list[i]);
			class3548_0.method_0(list[i].PropertyName, i);
			class3546_0.method_0(list[i].PropertyType, list[i]);
			class3546_1.method_0(list[i].PropertyType, i);
			class3546_2.method_0(i, list[i].PropertyType);
			class3547_1.method_0(i, list[i] is Class3969);
		}
		class4143_0 = new Class4143(class4142_0);
		class4073_0 = new Class4073();
		class4072_0 = new Class4072(this);
	}

	public void imethod_0(Interface78 listener)
	{
		list_0.Add(listener);
	}

	public void imethod_1(Interface78 listener)
	{
		list_0.Remove(listener);
	}

	public Interface76 imethod_2(string content)
	{
		Class4354 @class = new Class4354(this);
		return @class.imethod_1(content);
	}

	public Interface76 imethod_3(Class6976 ownerNode)
	{
		Class4354 @class = new Class4354(this, ownerNode);
		return @class.imethod_1(ownerNode.TextContent);
	}

	public Interface76 imethod_4(Stream stream)
	{
		Class4354 @class = new Class4354(this);
		return @class.imethod_2(stream);
	}

	public Interface76 imethod_5(string filePath, Class6976 ownerNode)
	{
		Class4258 @class = Context.ResourceLoading.imethod_0(this, new EventArgs1(filePath));
		if (@class.Data != null && @class.Data.Length != 0)
		{
			Encoding encoding = @class.Encoding ?? Encoding.UTF8;
			string @string = encoding.GetString(@class.Data);
			Class4354 class2 = new Class4354(this, ownerNode);
			Interface76 @interface = class2.imethod_1(@string);
			((Class3735)@interface).Href = filePath;
			return @interface;
		}
		return null;
	}

	public Interface58 imethod_6(string content, Class6976 ownerNode)
	{
		if (string.IsNullOrEmpty(content))
		{
			return new Class3719(new Class4074(this), ownerNode, this);
		}
		Class4354 @class = new Class4354(this, ownerNode);
		return @class.imethod_3(content);
	}

	public Interface58 imethod_7(Interface91 ownerNode)
	{
		return new Class3717(this);
	}

	internal string GetPropertyName(int index)
	{
		return class3547_0.method_1(index).PropertyName;
	}

	internal string GetPropertyName(Enum600 propertyType)
	{
		return class3546_0.method_1(propertyType).PropertyName;
	}

	internal int method_0(string name)
	{
		return class3548_0.method_1(name);
	}

	internal int method_1(Enum600 propertyType)
	{
		return class3546_1.method_1(propertyType);
	}

	internal Enum600 method_2(int index)
	{
		return class3546_2.method_1(index);
	}

	internal int method_3()
	{
		return class3547_0.Count;
	}

	internal Class3770 method_4(int index)
	{
		return class3547_0.method_1(index);
	}

	internal Class3770 method_5(string name)
	{
		int num = class3548_0.method_1(name);
		if (num == -1)
		{
			return null;
		}
		return class3547_0.method_1(num);
	}

	internal Class3770 method_6(Enum600 propertyType)
	{
		return class3546_0.method_1(propertyType);
	}

	internal bool method_7(int index)
	{
		return class3547_1.method_1(index);
	}

	internal Class4074 method_8(Class6981 element, string pseudoElement)
	{
		Class4074 @class = new Class4074(this);
		Interface89 @interface = (Interface89)element.OwnerDocument;
		Interface91 interface2 = (Interface91)element;
		Class3727 class2 = null;
		Class3727 class3 = null;
		Class3727 class4 = null;
		if (interface76_0 != null && interface76_0.CSSRules.Length != 0L)
		{
			class3 = method_11(interface76_0, element, pseudoElement);
		}
		if (interface76_1 != null && interface76_1.CSSRules.Length != 0L)
		{
			class4 = method_11(interface76_1, element, pseudoElement);
		}
		if (@interface != null)
		{
			class2 = method_10(@interface.StyleSheets, element, pseudoElement);
		}
		Class3716 class5 = (Class3716)@interface.imethod_1(element, pseudoElement);
		Class3716 class6 = (Class3716)interface2.Style;
		if (class3 != null && class3.Count != 0)
		{
			method_13(@class, class3, important: false);
		}
		if (class4 != null && class4.Count != 0)
		{
			method_13(@class, class4, important: false);
		}
		if (pseudoElement == null)
		{
			Class3716 class7 = class4072_0.method_0(element);
			int length = class7.Length;
			for (int i = 0; i < length; i++)
			{
				int i2 = class7.method_2(i);
				@class.method_1(i2, class7.method_1(i));
			}
		}
		if (class2 != null && class2.Count != 0)
		{
			method_13(@class, class2, important: false);
		}
		if (class6.Length != 0)
		{
			int length2 = class6.Length;
			for (int j = 0; j < length2; j++)
			{
				int i3 = class6.method_2(j);
				@class.method_1(i3, class6.method_1(j));
				@class.method_3(i3, class6.method_3(j));
			}
		}
		for (int k = 0; k < class5.Length; k++)
		{
			if (class5.method_3(k))
			{
				int i4 = class5.method_2(k);
				@class.method_1(i4, class5.method_1(k));
				@class.method_3(i4, value: true);
			}
		}
		if (class2 != null && class2.Count != 0)
		{
			method_13(@class, class2, important: true);
		}
		if (class4 != null && class4.Count != 0)
		{
			method_13(@class, class4, important: true);
		}
		if (class3 != null && class3.Count != 0)
		{
			method_13(@class, class3, important: true);
		}
		return @class;
	}

	public Class3679 method_9(Interface91 element, string pseudoElement, int propertyIndex)
	{
		if (element == null)
		{
			return method_15(pseudoElement, propertyIndex);
		}
		Class4074 @class = element.imethod_0(pseudoElement);
		if (@class == null)
		{
			@class = method_8((Class6981)element, pseudoElement);
			element.imethod_1(pseudoElement, @class);
		}
		Class3679 class2 = @class.method_0(propertyIndex);
		if (@class.method_4(propertyIndex))
		{
			return class2;
		}
		Class3770 class3 = method_4(propertyIndex);
		Interface91 @interface = smethod_0((Class6981)element);
		if (class2 == null)
		{
			if (class3.IsInheritedProperty && @interface != null)
			{
				@class.method_7(propertyIndex, value: true);
				class2 = method_9(@interface, pseudoElement, propertyIndex);
			}
			else
			{
				class2 = class3.vmethod_1();
			}
		}
		else if (class2 == Class3700.Class3702.class3695_0)
		{
			if (@interface != null)
			{
				@class.method_7(propertyIndex, value: true);
				class2 = method_9(@interface, pseudoElement, propertyIndex);
			}
			else
			{
				class2 = class3.vmethod_1();
			}
		}
		try
		{
			class2 = class3.vmethod_2(element, this, pseudoElement, @class, class2, propertyIndex);
		}
		catch (Exception e)
		{
			ErrorHandler.imethod_0(Class4246.smethod_4(e));
			class2 = class3.vmethod_2(element, this, pseudoElement, @class, class3.vmethod_1(), propertyIndex);
		}
		@class.method_1(propertyIndex, class2);
		@class.method_5(propertyIndex, value: true);
		return class2;
	}

	private Class3727 method_10(Interface95 styleSheets, Class6981 element, string pseudoElement)
	{
		Class3727 @class = new Class3727();
		foreach (Interface76 styleSheet in styleSheets)
		{
			Class3727 class2 = method_11(styleSheet, element, pseudoElement);
			if (class2.Count != 0)
			{
				@class.method_0(class2);
			}
		}
		return @class;
	}

	private Class3727 method_11(Interface76 styleSheet, Class6981 element, string pseudoElement)
	{
		Class3727 @class = new Class3727();
		foreach (Interface59 cSSRule in styleSheet.CSSRules)
		{
			switch (cSSRule.Type)
			{
			case 1:
			{
				if (cSSRule.Type != 1)
				{
					break;
				}
				Class3714 class5 = cSSRule as Class3714;
				foreach (Class4051 selector in class5.SelectorList)
				{
					if ((pseudoElement != null || !selector.vmethod_1()) && (pseudoElement == null || (!(pseudoElement == Class3724.string_0) && !(pseudoElement == Class3724.string_1)) || selector.vmethod_1()) && selector.imethod_0(element, pseudoElement))
					{
						@class.Add(new Class3728(selector, class5));
					}
				}
				break;
			}
			case 3:
			{
				Class3711 class7 = (Class3711)cSSRule;
				if (class7.StyleSheet == null)
				{
					break;
				}
				bool flag = true;
				if (class7.Media.Length != 0L)
				{
					flag = class7.Media.method_0(Context.Settings.Device);
				}
				if (flag)
				{
					Class3727 class8 = method_11(class7.StyleSheet, element, pseudoElement);
					if (class8.Count != 0)
					{
						@class.method_0(class8);
					}
				}
				break;
			}
			case 4:
			{
				Class3712 class2 = (Class3712)cSSRule;
				if (!class2.Media.method_0(Context.Settings.Device))
				{
					break;
				}
				foreach (Interface59 cSSRule2 in class2.CSSRules)
				{
					if (cSSRule2.Type != 1)
					{
						continue;
					}
					Class3714 class3 = (Class3714)cSSRule2;
					foreach (Class4051 selector2 in class3.SelectorList)
					{
						if ((pseudoElement == null || selector2.vmethod_1()) && selector2.imethod_0(element, pseudoElement))
						{
							@class.Add(new Class3728(selector2, class3));
						}
					}
				}
				break;
			}
			}
		}
		return @class;
	}

	private Class3727 method_12(Interface76 styleSheet, string pseudoElement)
	{
		Class3727 @class = new Class3727();
		foreach (Interface59 cSSRule in styleSheet.CSSRules)
		{
			switch (cSSRule.Type)
			{
			case 3:
			{
				Class3711 class4 = (Class3711)cSSRule;
				if (class4.StyleSheet == null)
				{
					break;
				}
				bool flag = true;
				if (class4.Media.Length != 0L)
				{
					flag = class4.Media.method_0(Context.Settings.Device);
				}
				if (flag)
				{
					Class3727 class5 = method_12(class4.StyleSheet, pseudoElement);
					if (class5.Count != 0)
					{
						@class.method_0(class5);
					}
				}
				break;
			}
			case 4:
			{
				Class3712 class6 = (Class3712)cSSRule;
				if (!class6.Media.method_0(Context.Settings.Device))
				{
					break;
				}
				foreach (Interface59 cSSRule2 in class6.CSSRules)
				{
					if (cSSRule2.Type == 6)
					{
						@class.Add(new Class3728(cSSRule2));
					}
				}
				break;
			}
			case 6:
			{
				Class3713 class2 = (Class3713)cSSRule;
				if (class2.SelectorList.Length == 0)
				{
					@class.Add(new Class3728(cSSRule));
				}
				foreach (Class4051 selector in class2.SelectorList)
				{
					if (selector.imethod_0(null, pseudoElement))
					{
						@class.Add(new Class3728(selector, class2));
					}
				}
				break;
			}
			}
		}
		return @class;
	}

	private void method_13(Class4074 styleMap, Class3727 rules, bool important)
	{
		rules.method_1();
		foreach (Class3728 rule in rules)
		{
			Class3716 @class = null;
			if (rule.Rule.Type == 1)
			{
				@class = (Class3716)((Interface74)rule.Rule).Style;
			}
			else if (rule.Rule.Type == 6)
			{
				@class = (Class3716)((Interface72)rule.Rule).Style;
			}
			for (int i = 0; i < @class.Length; i++)
			{
				int i2 = @class.method_2(i);
				if (important == @class.method_3(i))
				{
					Class3679 class2 = @class.method_1(i);
					if (class2 is Class3690 && rule.Rule.ParentStyleSheet.Href != null)
					{
						Class3690 class3 = class2 as Class3690;
						int num = rule.Rule.ParentStyleSheet.Href.LastIndexOf('/');
						string text = rule.Rule.ParentStyleSheet.Href.Substring(0, ++num);
						class2 = new Class3690(text + class3.vmethod_3());
					}
					styleMap.method_1(i2, class2);
					styleMap.method_3(i2, @class.method_3(i));
				}
			}
		}
	}

	private Class4074 method_14(string pseudoElement)
	{
		Class4074 @class = new Class4074(this);
		Class3727 class2 = new Class3727();
		foreach (Interface76 styleSheet in Document.StyleSheets)
		{
			Class3727 class3 = method_12(styleSheet, pseudoElement);
			if (class3.Count != 0)
			{
				class2.method_0(class3);
			}
		}
		method_13(@class, class2, important: false);
		method_13(@class, class2, important: true);
		return @class;
	}

	public Class3679 method_15(string pseudoElement, int propertyIndex)
	{
		Class4074 @class = Document.imethod_2(pseudoElement);
		if (@class == null)
		{
			@class = method_14(pseudoElement);
			Document.imethod_3(pseudoElement, @class);
		}
		Class3679 class2 = @class.method_0(propertyIndex);
		if (@class.method_4(propertyIndex))
		{
			return class2;
		}
		Class3770 class3 = method_4(propertyIndex);
		try
		{
			class2 = class3.vmethod_2(null, this, pseudoElement, @class, class2, propertyIndex);
		}
		catch (Exception e)
		{
			ErrorHandler.imethod_0(Class4246.smethod_4(e));
			class2 = class3.vmethod_2(null, this, pseudoElement, @class, class3.vmethod_1(), propertyIndex);
		}
		@class.method_1(propertyIndex, class2);
		@class.method_5(propertyIndex, value: true);
		return class2;
	}

	public static Interface91 smethod_0(Class6981 element)
	{
		Class6976 parentNode = element.ParentNode;
		do
		{
			if (!(parentNode is Interface91 result))
			{
				parentNode = parentNode.ParentNode;
				continue;
			}
			return result;
		}
		while (parentNode != null);
		return null;
	}

	public void imethod_8(Interface89 document)
	{
		if (document is Class7046 @class && @class.DocumentElement != null)
		{
			method_17(document);
			method_16(@class.DocumentElement);
		}
	}

	public Interface66 imethod_10(Interface91 element)
	{
		return new Class3724((Class6981)element);
	}

	public void imethod_11(string styleSheet)
	{
		interface76_0 = imethod_2(styleSheet);
	}

	public void imethod_12(string styleSheet)
	{
		interface76_1 = imethod_2(styleSheet);
	}

	public void imethod_9(Interface91 element)
	{
		method_16(element as Class6981);
	}

	private void method_16(Class6981 element)
	{
		if (element is Interface91 @interface)
		{
			Class4074 @class = @interface.imethod_0(null);
			if (@class == null)
			{
				@class = method_8(element, null);
				@interface.imethod_1(null, @class);
			}
			int i = method_1(Enum600.const_84);
			int i2 = method_1(Enum600.const_83);
			int i3 = method_1(Enum600.const_82);
			Class3679 class2 = @class.method_0(i);
			if (class2 != null)
			{
				method_19(@interface, class2, null);
			}
			Class3679 class3 = @class.method_0(i2);
			if (class3 != null)
			{
				method_20(@interface, class3, null);
			}
			@class = @interface.imethod_0(Class3724.string_0);
			if (@class == null)
			{
				@class = method_8(element, Class3724.string_0);
				@interface.imethod_1(Class3724.string_0, @class);
			}
			if (@class.method_0(i3) != null)
			{
				class2 = @class.method_0(i);
				if (class2 != null)
				{
					method_19(@interface, class2, Class3724.string_0);
				}
				class3 = @class.method_0(i2);
				if (class3 != null)
				{
					method_20(@interface, class3, Class3724.string_0);
				}
			}
			@class = @interface.imethod_0(Class3724.string_1);
			if (@class == null)
			{
				@class = method_8(element, Class3724.string_1);
				@interface.imethod_1(Class3724.string_1, @class);
			}
			if (@class.method_0(i3) != null)
			{
				class2 = @class.method_0(i);
				if (class2 != null)
				{
					method_19(@interface, class2, Class3724.string_1);
				}
				class3 = @class.method_0(i2);
				if (class3 != null)
				{
					method_20(@interface, class3, Class3724.string_1);
				}
			}
			Interface91 interface2 = smethod_0(element);
			if (interface2 != null)
			{
				Class4074 class4 = interface2.imethod_0(null);
				if (class4 != null)
				{
					int num = method_3();
					for (int j = 0; j < num; j++)
					{
						Class3679 class5 = class4.method_0(j);
						Class3679 class6 = @class.method_0(j);
						if (class5 != null && class6 == null && method_4(j).IsInheritedProperty)
						{
							method_9(@interface, null, j);
						}
					}
				}
			}
		}
		for (Class6976 class7 = element.FirstChild; class7 != null; class7 = class7.NextSibling)
		{
			if (class7.NodeType == Enum969.const_0)
			{
				method_16((Class6981)class7);
			}
		}
	}

	private void method_17(Interface89 document)
	{
		foreach (Interface76 styleSheet in document.StyleSheets)
		{
			method_18(styleSheet);
		}
	}

	private void method_18(Interface76 styleSheet)
	{
		foreach (Interface59 cSSRule in styleSheet.CSSRules)
		{
			switch (cSSRule.Type)
			{
			case 11:
				class4143_0.method_0((Class3709)cSSRule);
				break;
			case 3:
			{
				Class3711 @class = (Class3711)cSSRule;
				if (@class.StyleSheet == null)
				{
					break;
				}
				if (@class.Media.Length != 0L)
				{
					if (@class.Media.method_0(Context.Settings.Device))
					{
						method_18(@class.StyleSheet);
					}
				}
				else
				{
					method_18(@class.StyleSheet);
				}
				break;
			}
			}
		}
	}

	private void method_19(Interface91 element, Class3679 value, string pseudoElement)
	{
		if (value == Class3700.Class3702.class3689_4)
		{
			return;
		}
		Interface67 @interface = (Interface67)element.Counters;
		IEnumerator<Class3679> enumerator = ((Class3691)value).GetEnumerator();
		string text = null;
		while (enumerator.MoveNext())
		{
			Class3680 @class = (Class3680)enumerator.Current;
			if (@class == Class3700.Class3702.class3689_4)
			{
				break;
			}
			if (@class.PrimitiveType == 21)
			{
				if (text != null)
				{
					@interface.Reset(text, pseudoElement);
				}
				text = @class.vmethod_3();
			}
			else if (@class.PrimitiveType == 1 && text != null)
			{
				@interface.Reset(text, (int)@class.vmethod_1(1), pseudoElement);
				text = null;
			}
		}
		if (text != null)
		{
			@interface.Reset(text, pseudoElement);
		}
	}

	private void method_20(Interface91 element, Class3679 value, string pseudoElement)
	{
		if (value == Class3700.Class3702.class3689_4)
		{
			return;
		}
		Interface67 @interface = (Interface67)element.Counters;
		IEnumerator<Class3679> enumerator = ((Class3691)value).GetEnumerator();
		string text = null;
		while (enumerator.MoveNext())
		{
			Class3680 @class = (Class3680)enumerator.Current;
			if (@class == Class3700.Class3702.class3689_4)
			{
				break;
			}
			if (@class.PrimitiveType == 21)
			{
				if (text != null)
				{
					@interface.imethod_2(text, pseudoElement);
				}
				text = @class.vmethod_3();
			}
			else if (@class.PrimitiveType == 1 && text != null)
			{
				@interface.imethod_4(text, (int)@class.vmethod_1(1), pseudoElement);
				text = null;
			}
		}
		if (text != null)
		{
			@interface.imethod_2(text, pseudoElement);
		}
	}
}
