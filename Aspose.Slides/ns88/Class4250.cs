using ns73;
using ns74;
using ns77;
using ns83;

namespace ns88;

internal class Class4250
{
	public Interface80 method_0(Interface105 node)
	{
		if (node.Type == 68)
		{
			return method_1(node);
		}
		if (node.Type != 40)
		{
			throw new Exception11($"Token type '{node.Type}' is not valid.");
		}
		return method_1(node);
	}

	public Class3737 method_1(Interface105 node)
	{
		int i = 0;
		Class3737 @class = null;
		for (; i < node.ChildCount; i++)
		{
			Interface105 @interface = node.imethod_1(i);
			if (@interface.Type == 45)
			{
				@class = ((@class != null) ? @class.method_1(new Class3767(@interface.Text)) : new Class3767(@interface.Text));
			}
			else if (@interface.Type == 6)
			{
				@interface = node.imethod_1(++i);
				if (@class == null)
				{
					@class = method_2(@interface);
					if (@class == null)
					{
						throw new Exception11($"Invalid media query '{@interface.imethod_7()}' is not valid.");
					}
					continue;
				}
				Class3737 class2 = method_2(@interface);
				if (class2 == null)
				{
					throw new Exception11($"Invalid media query '{@interface.imethod_7()}' is not valid.");
				}
				@class = @class.method_1(class2);
			}
			else if (@interface.Type == 40)
			{
				@class = ((@class != null) ? @class.method_1(method_2(@interface)) : method_2(@interface));
			}
			else
			{
				_ = @interface.Type;
			}
		}
		return @class;
	}

	private Class3737 method_2(Interface105 node)
	{
		if (node.ChildCount == 1)
		{
			return Class3739.smethod_0(node.imethod_1(0).Text);
		}
		if (node.ChildCount == 2)
		{
			Interface105 node2 = node.imethod_1(1);
			Class3679 argument = method_3(node2);
			return Class3739.smethod_1(node.imethod_1(0).Text, argument);
		}
		if (node.ChildCount != 4)
		{
			throw new Exception11($"Token '{node.imethod_1(2).Text}' is not valid.");
		}
		Class3691 @class = new Class3691();
		Interface105 node3 = node.imethod_1(1);
		Class3679 value = method_3(node3);
		@class.Add(value);
		node3 = node.imethod_1(2);
		value = method_3(node3);
		@class.Add(value);
		node3 = node.imethod_1(3);
		value = method_3(node3);
		@class.Add(value);
		return Class3739.smethod_1(node.imethod_1(0).Text, @class);
	}

	private Class3679 method_3(Interface105 node)
	{
		Interface99 @interface = null;
		switch (node.Type)
		{
		case 45:
			@interface = Class4233.smethod_1(null, node.Text);
			break;
		case 103:
			@interface = Class4233.smethod_4(null, 4, node.Text);
			break;
		case 105:
			@interface = Class4233.smethod_0(null, node.Text);
			break;
		case 31:
		case 79:
			@interface = Class4233.smethod_10(null, node);
			break;
		}
		Class3679 result = null;
		if (@interface != null)
		{
			switch (@interface.LexicalUnitType)
			{
			case 44:
				result = new Class3684(@interface.imethod_1(), "dpi");
				break;
			case 45:
				result = new Class3684(@interface.imethod_1(), "dpcm");
				break;
			case 46:
				result = new Class3684(@interface.imethod_1(), "dppx");
				break;
			case 4:
				result = new Class3693(@interface);
				break;
			case 13:
				result = new Class3685(@interface.imethod_0(), 1);
				break;
			case 14:
				result = new Class3685(@interface.imethod_1(), 1);
				break;
			case 15:
				result = new Class3685(@interface.imethod_1(), 3);
				break;
			case 16:
				result = new Class3685(@interface.imethod_1(), 4);
				break;
			case 17:
				result = new Class3685(@interface.imethod_1(), 5);
				break;
			case 18:
				result = new Class3685(@interface.imethod_1(), 8);
				break;
			case 19:
				result = new Class3685(@interface.imethod_1(), 6);
				break;
			case 20:
				result = new Class3685(@interface.imethod_1(), 7);
				break;
			case 21:
				result = new Class3685(@interface.imethod_1(), 9);
				break;
			case 22:
				result = new Class3685(@interface.imethod_1(), 10);
				break;
			case 23:
				result = new Class3685(@interface.imethod_1(), 2);
				break;
			case 28:
				result = new Class3685(@interface.imethod_1(), 11);
				break;
			case 29:
				result = new Class3685(@interface.imethod_1(), 13);
				break;
			case 30:
				result = new Class3685(@interface.imethod_1(), 12);
				break;
			case 35:
				result = Class3689.smethod_1(@interface.imethod_5());
				break;
			case 36:
				result = Class3689.smethod_0(@interface.imethod_5());
				break;
			}
		}
		return result;
	}
}
