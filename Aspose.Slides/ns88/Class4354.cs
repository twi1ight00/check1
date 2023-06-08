using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns1;
using ns305;
using ns73;
using ns76;
using ns77;
using ns81;
using ns82;
using ns83;
using ns89;

namespace ns88;

internal class Class4354 : Interface103
{
	private Interface101 interface101_0;

	private Interface100 interface100_0;

	private Interface102 interface102_0;

	private Class4071 class4071_0 = Class4071.Instance;

	private Class4066 class4066_0 = Class4066.Instance;

	private Class3731 class3731_0 = Class3731.Instance;

	private Class3726 class3726_0;

	private Class6976 class6976_0;

	public Class3731 RuleFactory => class3731_0;

	public Class4354(Class3726 engine)
		: this(engine, null)
	{
	}

	public Class4354(Class3726 engine, Class6976 ownerNode)
	{
		interface102_0 = engine.ErrorHandler;
		class3726_0 = engine;
		class6976_0 = ownerNode;
		interface100_0 = (interface101_0 = new Class4244(this, engine, ownerNode));
	}

	public void imethod_0(Interface101 documentHandler)
	{
		interface101_0 = documentHandler;
	}

	public Interface76 imethod_1(string source)
	{
		try
		{
			Class4079 @class = new Class4079(new Class4394(new Class4077(new Class4387(source))));
			Class4363 node = @class.method_3();
			return method_5(node);
		}
		catch (Exception e)
		{
			method_0(e);
			Class3735 class2 = (Class3735)((Interface63)class6976_0.OwnerDocument.Implementation).imethod_0(string.Empty, "all");
			class2.method_0(class3726_0, class6976_0);
			return class2;
		}
	}

	public Interface76 imethod_2(Stream stream)
	{
		try
		{
			Class4079 @class = new Class4079(new Class4394(new Class4077(new Class4390(stream))));
			Class4363 node = @class.method_3();
			return method_5(node);
		}
		catch (Exception e)
		{
			method_0(e);
			Class3735 class2 = (Class3735)((Interface63)class6976_0.OwnerDocument.Implementation).imethod_0(string.Empty, "all");
			class2.method_0(class3726_0, class6976_0);
			return class2;
		}
	}

	public Interface58 imethod_3(string source)
	{
		try
		{
			Class4079 @class = new Class4079(new Class4394(new Class4077(new Class4387(source))));
			Class4363 node = @class.method_4();
			return method_6(node);
		}
		catch (Exception e)
		{
			method_0(e);
			return new Class3717(class3726_0);
		}
	}

	private void method_0(Exception e)
	{
		interface102_0.imethod_1(new Exception11(e.Message, e));
	}

	private void method_1(Exception e)
	{
		interface102_0.imethod_0(new Exception11(e.Message));
	}

	private void method_2(string message)
	{
		interface102_0.imethod_0(new Exception11(message));
	}

	private void method_3(string token)
	{
		interface102_0.imethod_0(new Exception11($"The character '{token}' is not valid in the current state."));
	}

	private void method_4(string statement)
	{
		interface102_0.imethod_0(new Exception11(statement));
	}

	private Interface76 method_5(Interface105 node)
	{
		interface101_0.imethod_1();
		if (!method_26(node))
		{
			int childCount = node.ChildCount;
			for (int i = 0; i < childCount; i++)
			{
				try
				{
					method_7(node.imethod_1(i));
				}
				catch (Exception13 e)
				{
					method_1(e);
				}
				catch (Exception12 e2)
				{
					method_1(e2);
				}
			}
		}
		interface101_0.imethod_2();
		return ((Class4244)interface101_0).StyleSheet;
	}

	private Interface58 method_6(Interface105 node)
	{
		Interface100 objB = interface100_0;
		try
		{
			Class4245 @class = (Class4245)(interface100_0 = new Class4245(class3726_0, class6976_0));
			int num = 0;
			while (num < node.ChildCount)
			{
				Interface105 @interface = node.imethod_1(num++);
				if (101 == @interface.Type)
				{
					method_17(@interface);
				}
			}
			return @class.StyleDeclaration;
		}
		finally
		{
			if (!object.ReferenceEquals(interface100_0, objB))
			{
				interface100_0 = objB;
			}
		}
	}

	private void method_7(Interface105 node)
	{
		switch (node.Type)
		{
		case 18:
			method_12(node);
			break;
		case 10:
			method_15(node);
			break;
		case 0:
			method_2(node.Text);
			break;
		case 47:
			method_13(node);
			break;
		case 41:
			method_10(node);
			break;
		case 25:
			method_9(node);
			break;
		case 67:
			method_8(node);
			break;
		case 53:
		case 56:
			method_2(node.Text);
			break;
		case 97:
			method_16(node);
			break;
		case 84:
			method_14(node);
			break;
		case 74:
			method_11(node);
			break;
		}
	}

	private void method_8(Interface105 node)
	{
		try
		{
			List<Interface80> list = new List<Interface80>();
			int i;
			for (i = 0; i < node.ChildCount; i++)
			{
				Interface105 @interface = node.imethod_1(i);
				if (@interface.Type == 68)
				{
					Class4250 @class = new Class4250();
					Interface80 interface2 = @class.method_0(@interface);
					if (interface2 != null)
					{
						list.Add(interface2);
					}
				}
				else if (@interface.Type == 97)
				{
					break;
				}
			}
			interface101_0.imethod_4(list);
			for (; i < node.ChildCount; i++)
			{
				Interface105 interface3 = node.imethod_1(i);
				if (interface3.Type == 97)
				{
					method_7(interface3);
				}
			}
			interface101_0.imethod_12();
		}
		catch (Exception11 e)
		{
			method_1(e);
		}
	}

	private void method_9(Interface105 node)
	{
		if (node.ChildCount == 0)
		{
			return;
		}
		Interface105 @interface = node.imethod_1(0);
		if (@interface.Type != 45)
		{
			method_2($"Unexpected token type '{Class4079.string_37[node.Type]}'.");
		}
		string name = @interface.imethod_7();
		@interface = node.imethod_1(1);
		if (@interface.Type != 101)
		{
			method_2($"Unexpected token type '{Class4079.string_37[node.Type]}'.");
		}
		try
		{
			interface101_0.imethod_5(name);
			Class3709 rule = (Class3709)((Class4244)interface101_0).CurrentRule;
			interface100_0 = new Class4243(rule);
			method_17(@interface);
			interface101_0.imethod_12();
		}
		finally
		{
			if (!object.ReferenceEquals(interface100_0, interface101_0))
			{
				interface100_0 = interface101_0;
			}
		}
	}

	private void method_10(Interface105 node)
	{
		interface101_0.imethod_6();
		if (node.ChildCount != 0)
		{
			Interface105 @interface = node.imethod_1(0);
			if (@interface.Type != 101)
			{
				method_2($"Unexpected token type '{Class4079.string_37[node.Type]}'.");
			}
			method_17(@interface);
		}
		interface101_0.imethod_12();
	}

	private void method_11(Interface105 node)
	{
		string prefix;
		string namespaceURI;
		if (node.ChildCount == 1)
		{
			prefix = string.Empty;
			node = node.imethod_1(0);
			namespaceURI = ((node.Type != 113) ? Class4233.smethod_0(null, node.Text).imethod_5() : Class4233.smethod_11(null, node).imethod_5());
		}
		else
		{
			prefix = node.imethod_1(0).Text;
			node = node.imethod_1(1);
			namespaceURI = ((node.Type != 113) ? Class4233.smethod_0(null, node.Text).imethod_5() : Class4233.smethod_11(null, node).imethod_5());
		}
		interface101_0.imethod_7(prefix, namespaceURI);
	}

	private void method_12(Interface105 node)
	{
		string encoding = node.Text.Substring(10, node.Text.Length - 12);
		interface101_0.imethod_8(encoding);
		interface101_0.imethod_12();
	}

	private void method_13(Interface105 node)
	{
		string text = null;
		List<Interface80> list = new List<Interface80>();
		Class4254 @class = new Class4254(node, Class4255.smethod_0(22, 98, 100));
		while (@class.MoveNext())
		{
			switch (@class.Current.Type)
			{
			case 68:
			{
				Class4250 class2 = new Class4250();
				list.Add(class2.method_0(@class.Current));
				break;
			}
			case 113:
			{
				Interface99 interface2 = Class4233.smethod_11(null, @class.Current);
				text = interface2.imethod_5();
				break;
			}
			case 105:
			{
				Interface99 @interface = Class4233.smethod_0(null, @class.Current.Text);
				text = @interface.imethod_5();
				break;
			}
			case 0:
				method_1(Class4246.smethod_5(node.Text));
				return;
			}
		}
		Class3735 class3 = (Class3735)((Class4244)interface101_0).StyleSheet;
		if (class3.CSSRules.Length != 0L)
		{
			foreach (Interface59 cSSRule in class3.CSSRules)
			{
				if (3 != cSSRule.Type && 2 != cSSRule.Type)
				{
					method_1(Class4246.smethod_5($"Invalid @import position at line {node.Line}."));
					return;
				}
			}
		}
		interface101_0.imethod_9(text, list);
		Class4258 class4 = class3726_0.Context.ResourceLoading.imethod_0(class3726_0, new EventArgs1(text));
		if (class4.Data != null && class4.Data.Length != 0)
		{
			using MemoryStream stream = new MemoryStream(class4.Data);
			Class4354 class5 = new Class4354(class3726_0);
			class3 = (Class3735)class5.imethod_2(stream);
			class3.Href = text;
			interface101_0.imethod_13(class3);
		}
		interface101_0.imethod_12();
	}

	private void method_14(Interface105 node)
	{
		interface101_0.imethod_10();
		int num = 0;
		Class4051 @class = null;
		while (num < node.ChildCount)
		{
			Interface105 @interface = node.imethod_1(num++);
			switch (@interface.Type)
			{
			default:
				method_2($"Unexpected token type '{Class4079.string_37[node.Type]}'.");
				break;
			case 101:
				method_17(@interface);
				break;
			case 90:
				@class = method_24(@interface, @class);
				break;
			case 45:
				@class = method_24(@interface, @class);
				break;
			}
		}
		if (@class != null)
		{
			interface101_0.imethod_14(new Interface83[1] { @class });
		}
		interface101_0.imethod_12();
	}

	private void method_15(Interface105 node)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (node.ChildCount == 0)
		{
			stringBuilder.Append(node.imethod_7());
		}
		else
		{
			int num = 0;
			while (num < node.ChildCount)
			{
				stringBuilder.Append(node.imethod_1(num++).imethod_7());
			}
		}
		interface101_0.imethod_11(stringBuilder.ToString());
		interface101_0.imethod_12();
	}

	private void method_16(Interface105 node)
	{
		List<Interface83> list = new List<Interface83>();
		Class4051 @class = method_23(node.imethod_1(0));
		int num = 1;
		Interface105 @interface = null;
		bool flag = false;
		while (true)
		{
			Interface105 interface2 = node.imethod_1(num);
			switch (interface2.Type)
			{
			case 30:
				num++;
				interface2 = node.imethod_1(num);
				@class = class4071_0.method_4(@class, method_23(interface2));
				goto default;
			case 99:
				list.Add(@class);
				@class = method_23(interface2);
				goto default;
			case 101:
				@interface = interface2;
				flag = true;
				goto default;
			case 89:
				num++;
				interface2 = node.imethod_1(num);
				@class = class4071_0.method_6(@class, method_23(interface2));
				goto default;
			default:
				num++;
				if (num >= node.ChildCount || flag)
				{
					interface101_0.imethod_3();
					list.Add(@class);
					interface101_0.imethod_14(list.ToArray());
					if (@interface != null)
					{
						method_17(@interface);
					}
					interface101_0.imethod_12();
					return;
				}
				break;
			case 19:
				num++;
				interface2 = node.imethod_1(num);
				@class = class4071_0.method_9(@class, method_23(interface2));
				goto default;
			case 5:
				num++;
				interface2 = node.imethod_1(num);
				@class = class4071_0.method_5(@class, method_23(interface2));
				goto default;
			case 0:
			case 56:
				throw new Exception13(interface2.Text);
			}
		}
	}

	private void method_17(Interface105 node)
	{
		int childCount = node.ChildCount;
		int num = 0;
		Interface105 @interface;
		while (true)
		{
			if (num < childCount)
			{
				@interface = node.imethod_1(num);
				if (@interface.Type == 0)
				{
					break;
				}
				if (@interface.Type != 29)
				{
					method_2($"Unexpected token type '{Class4079.string_37[@interface.Type]}'.");
				}
				else
				{
					method_18(@interface);
				}
				num++;
				continue;
			}
			return;
		}
		method_2($"Unexpected token type '{@interface.Text}'.");
	}

	private void method_18(Interface105 node)
	{
		if (node.ChildCount <= 1)
		{
			method_2("Invalid property declaration.");
			return;
		}
		Interface99 @interface = null;
		bool important = false;
		int num = 0;
		Interface105 interface2 = node.imethod_1(0);
		if (interface2.Type == 117)
		{
			interface2 = node.imethod_1(++num);
		}
		if (interface2.Type == 39)
		{
			if (!(interface2.imethod_1(0).Text == "important"))
			{
				method_2($"Undefined rule !'{interface2.imethod_1(0).Text}'");
				return;
			}
			important = true;
			interface2 = node.imethod_1(++num);
		}
		if (interface2.Type == 45)
		{
			string unescapedText = ((Class4094)((Class4363)interface2).Token).UnescapedText;
			interface2 = node.imethod_1(++num);
			if (interface2.Type == 116)
			{
				try
				{
					for (int i = 0; i < interface2.ChildCount; i++)
					{
						Interface105 node2 = interface2.imethod_1(i);
						@interface = method_19(node2, @interface);
					}
					if (@interface != null && @interface.PreviousLexicalUnit != null)
					{
						@interface = @interface.First;
					}
					interface100_0.imethod_0(unescapedText, @interface, important);
					return;
				}
				catch (Exception13)
				{
					throw;
				}
				catch (Exception11 e)
				{
					method_1(e);
					return;
				}
			}
			method_2($"Unexpected token type '{Class4079.string_37[node.Type]}'.");
		}
		else
		{
			method_2($"Unexpected token type '{Class4079.string_37[interface2.Type]}'.");
		}
	}

	private Interface99 method_19(Interface105 node, Interface99 previous)
	{
		Interface86 token = ((Class4363)node).Token;
		if (token == null)
		{
			throw Class4246.smethod_10(node.Type, node.Text);
		}
		string text = ((!(token is Class4094 @class)) ? token.Text : @class.UnescapedText);
		Interface99 @interface = null;
		switch (node.Type)
		{
		case 22:
			return Class4233.smethod_4(previous, 0, ",");
		case 69:
			return Class4233.smethod_4(previous, 2, text);
		case 42:
			return method_20(node, previous);
		case 44:
			return Class4233.smethod_9(previous, node);
		case 45:
			if (node.Text.Length == 7 && "inherit" == text)
			{
				return Class4233.smethod_4(previous, 12, "inherit");
			}
			return Class4233.smethod_1(previous, text);
		case 88:
			return Class4233.smethod_4(previous, 1, text);
		case 31:
		case 79:
		case 87:
			return Class4233.smethod_10(previous, node);
		case 113:
			return Class4233.smethod_11(previous, node);
		case 103:
			return Class4233.smethod_4(previous, 4, text);
		default:
			if (node.Type == 0)
			{
				throw new Exception13(node.Text);
			}
			throw Class4246.smethod_10(node.Type, node.Text);
		case 105:
			return Class4233.smethod_0(previous, text);
		}
	}

	private Interface99 method_20(Interface105 node, Interface99 previous)
	{
		string text = node.Text;
		Interface99 @params = null;
		if (node.ChildCount != 0)
		{
			@params = method_21(node.imethod_1(0));
		}
		char c = text[0];
		if (c == 'R' || c == 'r')
		{
			switch (text[1])
			{
			case 'E':
			case 'e':
				if (text.Equals("rect(", StringComparison.InvariantCultureIgnoreCase))
				{
					return Class4233.smethod_8(previous, 38, @params);
				}
				break;
			case 'G':
			case 'g':
				if (text.Equals("rgb(", StringComparison.InvariantCultureIgnoreCase))
				{
					return Class4233.smethod_8(previous, 27, @params);
				}
				break;
			}
		}
		return Class4233.smethod_7(previous, text, @params);
	}

	private Interface99 method_21(Interface105 node)
	{
		if (node.Type != 116)
		{
			throw Class4246.smethod_10(node.Type, node.Text);
		}
		int num = 0;
		Interface99 @interface = null;
		while (num < node.ChildCount)
		{
			Interface105 node2 = node.imethod_1(num++);
			@interface = method_19(node2, @interface);
		}
		return @interface?.First;
	}

	private Class4051 method_22(Interface105 node, int childIndex)
	{
		Class4051 @class = method_24(node.imethod_1(childIndex++), null);
		while (childIndex < node.ChildCount)
		{
			Interface105 node2 = node.imethod_1(childIndex++);
			@class = method_24(node2, @class);
		}
		return @class;
	}

	private Class4051 method_23(Interface105 node)
	{
		if (node.Type == 0)
		{
			throw new Exception12(node.Text);
		}
		Class4051 @class = method_24(node.imethod_1(0), null);
		if (node.ChildCount == 1)
		{
			return @class;
		}
		int num = 1;
		while (num < node.ChildCount)
		{
			Interface105 node2 = node.imethod_1(num++);
			@class = method_24(node2, @class);
		}
		return @class;
	}

	private Class4051 method_24(Interface105 node, Class4051 parentSelector)
	{
		Class4051 @class = null;
		Interface81 @interface = null;
		string text;
		int num2;
		switch (node.Type)
		{
		case 20:
			@interface = class4066_0.method_0(null, Class4094.smethod_4(node));
			break;
		case 11:
			@interface = method_25(node);
			break;
		case 90:
		{
			if (node.ChildCount == 0)
			{
				int num = node.ChildIndex + 1;
				Interface105 parent = node.Parent;
				while (num < parent.ChildCount)
				{
					Interface105 t = parent.imethod_1(num);
					parent.imethod_4(num);
					node.imethod_2(t);
				}
			}
			num2 = 0;
			if (node.imethod_1(0).Type == 117)
			{
				num2++;
			}
			text = node.imethod_1(num2).Text;
			num2++;
			int num3 = node.TokenStopIndex - node.TokenStartIndex;
			if (num3 <= 2 && num3 > 0)
			{
				switch (num3)
				{
				case 2:
					break;
				case 1:
					goto IL_0220;
				default:
					goto end_IL_0010;
				}
				switch (text.ToLowerInvariant())
				{
				case "first-line":
				case "first-letter":
				case "before":
				case "after":
				case "target":
				case "selection":
				case "hover":
				case "focus":
					@class = class4071_0.method_7(null, text);
					break;
				case "lang(":
					throw new Exception12(text);
				default:
					@class = class4071_0.method_7(null, text);
					break;
				}
				break;
			}
			num3 = 1;
			int num4 = 1;
			goto IL_0220;
		}
		case 44:
			@interface = class4066_0.method_1(null, Class4094.smethod_3(node));
			break;
		case 45:
			@class = class4071_0.method_0(null, Class4094.smethod_5(node));
			break;
		case 33:
			{
				Interface105 interface2 = node.imethod_1(0);
				string namespaceURI = null;
				if (interface2.Type == 78)
				{
					namespaceURI = ((interface2.ChildCount == 0) ? string.Empty : Class4094.smethod_5(interface2.imethod_1(0)));
					interface2 = node.imethod_1(1);
				}
				@class = ((interface2.Type != 8) ? class4071_0.method_0(namespaceURI, Class4094.smethod_5(interface2)) : class4071_0.method_1(namespaceURI));
				break;
			}
			IL_0220:
			switch (text.ToLowerInvariant())
			{
			case "first-child":
				@interface = class4066_0.method_9();
				break;
			case "last-child":
				@interface = class4066_0.method_10();
				break;
			case "only-child":
				@interface = class4066_0.method_11();
				break;
			case "first-of-type":
				@interface = class4066_0.method_12();
				break;
			case "last-of-type":
				@interface = class4066_0.method_13();
				break;
			case "only-of-type":
				@interface = class4066_0.method_14();
				break;
			case "root":
				@interface = class4066_0.method_15();
				break;
			case "nth-child(":
				@interface = class4066_0.method_16(smethod_0(node));
				break;
			case "nth-last-child(":
				@interface = class4066_0.method_17(smethod_0(node));
				break;
			case "nth-of-type(":
				@interface = class4066_0.method_18(smethod_0(node));
				break;
			case "nth-last-of-type(":
				@interface = class4066_0.method_19(smethod_0(node));
				break;
			case "lang(":
			{
				IList<string> list = new List<string>();
				int num5 = 1;
				while (num5 < node.ChildCount)
				{
					Interface105 interface3 = node.imethod_1(num5++);
					if (interface3.Type != 22)
					{
						list.Add(interface3.Text);
					}
				}
				@interface = class4066_0.method_20(list);
				break;
			}
			case "not(":
			{
				Class4051 class2 = method_22(node, num2);
				@interface = class4066_0.method_21(class2);
				if (class2.SelectorType == 9)
				{
					throw new Exception12(@interface.ConditionText);
				}
				if (class2.SelectorType == 0 && ((Class4061)class2).Condition is Class4028)
				{
					throw new Exception12(@interface.ConditionText);
				}
				break;
			}
			case "enabled":
				@interface = class4066_0.method_22();
				break;
			case "disabled":
				@interface = class4066_0.method_23();
				break;
			case "checked":
				@interface = class4066_0.method_24();
				break;
			case "indeterminate":
				@interface = class4066_0.method_26();
				break;
			case "valid":
				@interface = class4066_0.method_27();
				break;
			case "invalid":
				@interface = class4066_0.method_28();
				break;
			case "required":
				@interface = class4066_0.method_29();
				break;
			case "optional":
				@interface = class4066_0.method_30();
				break;
			case "in-range":
				@interface = class4066_0.method_31();
				break;
			case "out-of-range":
				@interface = class4066_0.method_32();
				break;
			case "read-only":
				@interface = class4066_0.method_33();
				break;
			case "read-write":
				@interface = class4066_0.method_34();
				break;
			case "dir(":
				@interface = class4066_0.method_35(node.imethod_1(num2).Text);
				break;
			case "empty":
				@interface = class4066_0.method_25();
				break;
			case "link":
				@class = class4071_0.method_8();
				break;
			case "target":
			case "selection":
			case "hover":
			case "focus":
				@class = class4071_0.method_7(null, text);
				break;
			default:
				@class = class4071_0.method_7(null, text);
				break;
			}
			break;
			end_IL_0010:
			break;
		}
		if (@class != null)
		{
			if (parentSelector == null)
			{
				return @class;
			}
			return class4071_0.method_10(parentSelector, @class);
		}
		if (@interface != null)
		{
			if (parentSelector == null)
			{
				parentSelector = class4071_0.method_2();
			}
			return class4071_0.method_3(parentSelector, @interface);
		}
		return parentSelector;
	}

	private Interface81 method_25(Interface105 node)
	{
		string namespaceURI = null;
		int num = 0;
		if (node.imethod_1(0).Type == 78)
		{
			namespaceURI = ((node.imethod_1(num).ChildCount == 0) ? string.Empty : node.imethod_1(num).imethod_1(0).Text);
			num++;
		}
		string text = node.imethod_1(num).Text;
		if (num == node.ChildCount - 1)
		{
			return class4066_0.method_2(namespaceURI, text);
		}
		if (num != node.ChildCount - 3)
		{
			throw new Exception13(node.imethod_7());
		}
		string value = Class4233.smethod_0(null, node.imethod_1(num + 2).Text).imethod_5();
		return node.imethod_1(num + 1).Type switch
		{
			28 => class4066_0.method_5(namespaceURI, text, value), 
			24 => class4066_0.method_7(namespaceURI, text, value), 
			104 => class4066_0.method_6(namespaceURI, text, value), 
			49 => class4066_0.method_4(namespaceURI, text, value), 
			34 => class4066_0.method_8(namespaceURI, text, value), 
			35 => class4066_0.method_3(namespaceURI, text, value), 
			_ => throw Class4246.smethod_9(node.imethod_1(num + 1)), 
		};
	}

	private static Class4249 smethod_0(Interface105 node)
	{
		if (node.ChildCount == 2)
		{
			return Class4249.smethod_0(node.imethod_1(1).Text);
		}
		int num = 1;
		StringBuilder stringBuilder = new StringBuilder();
		while (num < node.ChildCount)
		{
			stringBuilder.Append(node.imethod_1(num++));
		}
		return Class4249.smethod_0(stringBuilder.ToString());
	}

	private bool method_26(Interface105 node)
	{
		if (node.Type == 57)
		{
			method_3(node.Text);
			return true;
		}
		return false;
	}
}
