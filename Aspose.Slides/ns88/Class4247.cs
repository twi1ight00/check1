using ns1;
using ns73;
using ns74;
using ns82;
using ns83;

namespace ns88;

internal class Class4247
{
	public Class3679 method_0(string value)
	{
		Class4079 @class = new Class4079(new Class4394(new Class4077(new Class4387(value))));
		Interface105 node = @class.method_5();
		Interface99 @interface = method_1(node);
		return @interface.LexicalUnitType switch
		{
			13 => new Class3685(@interface.imethod_0(), 1), 
			14 => new Class3685(@interface.imethod_1(), 1), 
			15 => new Class3685(@interface.imethod_1(), 3), 
			16 => new Class3685(@interface.imethod_1(), 4), 
			17 => new Class3685(@interface.imethod_1(), 5), 
			18 => new Class3685(@interface.imethod_1(), 8), 
			19 => new Class3685(@interface.imethod_1(), 6), 
			20 => new Class3685(@interface.imethod_1(), 7), 
			21 => new Class3685(@interface.imethod_1(), 9), 
			22 => new Class3685(@interface.imethod_1(), 10), 
			23 => new Class3685(@interface.imethod_1(), 2), 
			_ => throw Class4246.smethod_11(@interface.LexicalUnitType), 
		};
	}

	private Interface99 method_1(Interface105 node)
	{
		Interface99 @interface = null;
		switch (node.Type)
		{
		case 45:
			return Class4233.smethod_1(null, node.Text);
		default:
			if (node.Type == 0)
			{
				throw new Exception13(node.Text);
			}
			throw Class4246.smethod_10(node.Type, node.Text);
		case 105:
			return Class4233.smethod_0(null, node.Text);
		case 31:
		case 79:
		case 87:
			return Class4233.smethod_10(null, node);
		}
	}
}
