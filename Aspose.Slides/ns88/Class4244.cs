using System.Collections.Generic;
using ns305;
using ns73;
using ns76;
using ns77;
using ns79;
using ns81;

namespace ns88;

internal class Class4244 : Interface100, Interface101
{
	private Stack<Interface59> stack_0;

	private Class3735 class3735_0;

	private Class3716 class3716_0;

	private Class3726 class3726_0;

	private Interface103 interface103_0;

	private Class6976 class6976_0;

	public Interface76 StyleSheet => class3735_0;

	public Interface59 CurrentRule
	{
		get
		{
			if (stack_0.Count == 0)
			{
				return null;
			}
			return stack_0.Peek();
		}
		set
		{
			stack_0.Push(value);
		}
	}

	public Class4244(Interface103 parser, Class3726 engine, Class6976 ownerNode)
	{
		interface103_0 = parser;
		class3726_0 = engine;
		class6976_0 = ownerNode;
		stack_0 = new Stack<Interface59>();
	}

	public void imethod_1()
	{
		if (class6976_0 != null)
		{
			Interface63 @interface = (Interface63)class6976_0.OwnerDocument.Implementation;
			class3735_0 = (Class3735)@interface.imethod_0(string.Empty, "all");
		}
		else
		{
			class3735_0 = new Class3735();
		}
		class3735_0.method_0(class3726_0, class6976_0);
	}

	public void imethod_2()
	{
	}

	public void imethod_3()
	{
		CurrentRule = interface103_0.RuleFactory.method_0(1, class3735_0, CurrentRule);
		class3716_0 = (Class3716)((Class3714)CurrentRule).Style;
	}

	public void imethod_12()
	{
		Interface59 @interface = stack_0.Pop();
		if (stack_0.Count == 0)
		{
			((Class3732)class3735_0.CSSRules).Add(@interface);
		}
		else
		{
			Interface59 currentRule = CurrentRule;
			short type = currentRule.Type;
			if (type == 4)
			{
				((Class3732)((Class3712)currentRule).CSSRules).Add(@interface);
			}
		}
		if (@interface.Type == 1)
		{
			class3716_0 = null;
		}
	}

	public void imethod_4(IList<Interface80> media)
	{
		Class3712 @class = (Class3712)interface103_0.RuleFactory.method_0(4, class3735_0, CurrentRule);
		Class3736 media2 = @class.Media;
		foreach (Interface80 medium in media)
		{
			media2.Add(medium);
		}
		CurrentRule = @class;
	}

	public void imethod_6()
	{
		Interface59 @interface = interface103_0.RuleFactory.method_0(5, class3735_0, CurrentRule);
		class3716_0 = (Class3716)((Class3710)@interface).Style;
		CurrentRule = @interface;
	}

	public void imethod_7(string prefix, string namespaceURI)
	{
		class3735_0.NamespaceManager.AddNamespace(prefix, namespaceURI);
	}

	public void imethod_5(string name)
	{
		Class3709 @class = (Class3709)interface103_0.RuleFactory.method_0(11, class3735_0, CurrentRule);
		@class.Name = name;
		CurrentRule = @class;
	}

	public void imethod_8(string encoding)
	{
		Interface64 @interface = (Interface64)interface103_0.RuleFactory.method_0(2, class3735_0, CurrentRule);
		@interface.Encoding = encoding;
		CurrentRule = @interface;
	}

	public void imethod_9(string url, IList<Interface80> media)
	{
		Class3711 @class = (Class3711)interface103_0.RuleFactory.method_0(3, class3735_0, CurrentRule);
		@class.Href = url;
		Class3736 media2 = @class.Media;
		foreach (Interface80 medium in media)
		{
			media2.Add(medium);
		}
		CurrentRule = @class;
	}

	public void imethod_10()
	{
		Interface72 @interface = (Interface72)interface103_0.RuleFactory.method_0(6, class3735_0, CurrentRule);
		class3716_0 = (Class3716)@interface.Style;
		CurrentRule = @interface;
	}

	public void imethod_11(string text)
	{
		Interface77 @interface = (Interface77)interface103_0.RuleFactory.method_0(0, class3735_0, CurrentRule);
		@interface.CSSText = text;
		CurrentRule = @interface;
	}

	public void imethod_13(Interface76 styleSheet)
	{
		Class3711 @class = CurrentRule as Class3711;
		((Class3735)styleSheet).ParentStyleSheet = class3735_0;
		if (@class == null)
		{
			class3726_0.ErrorHandler.imethod_0(new Exception11($"CSS Rule '{CurrentRule.Type}' is not supported embedded stylesheets."));
			return;
		}
		((Class3735)styleSheet).OwnerRule = CurrentRule;
		@class.StyleSheet = styleSheet;
	}

	public void imethod_14(Interface83[] selectors)
	{
		Interface59 currentRule = CurrentRule;
		for (int i = 0; i < selectors.Length; i++)
		{
			Class4051 selector = (Class4051)selectors[i];
			if (currentRule.Type == 1)
			{
				((Class3714)currentRule).SelectorList.Add(selector);
			}
			else if (currentRule.Type == 6)
			{
				((Class3713)currentRule).SelectorList.Add(selector);
			}
		}
	}

	public void imethod_0(string name, Interface99 lu, bool important)
	{
		int num = class3726_0.method_0(name.ToLowerInvariant());
		if (num != -1)
		{
			Class3770 @class = class3726_0.method_4(num);
			if (!class3726_0.method_7(num))
			{
				Class3679 class2 = @class.vmethod_0(lu, class3726_0);
				if (class2.CSSValueType != 2 && lu.NextLexicalUnit != null)
				{
					throw Class4246.smethod_14(name);
				}
				class3716_0.vmethod_2(num, class2, important);
			}
			else
			{
				(@class as Class3969).vmethod_3(class3726_0, this, lu, important);
			}
		}
		else
		{
			class3726_0.ErrorHandler.imethod_0(new Exception11($"Invalid property name '{name}'."));
		}
	}
}
