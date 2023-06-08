using ns115;
using ns118;
using ns133;

namespace ns134;

internal class Class4701
{
	public static Class4605 smethod_0(Interface116 interpreter, double dx, double dy)
	{
		Class4598 current = interpreter.GraphStateStack.Current;
		current.Position = new Class4600(current.Position.X + dx, current.Position.Y + dy);
		current.CTM.method_0(current.Position.X, current.Position.Y, out var x, out var y);
		Class4605 @class = new Class4605(x, y);
		current.Path.PathCommands.Add(@class);
		return @class;
	}

	public static Class4603 smethod_1(Interface116 interpreter, double x, double y)
	{
		Class4598 current = interpreter.GraphStateStack.Current;
		current.Position = new Class4600(x, y);
		current.CTM.method_0(current.Position.X, current.Position.Y, out var x2, out var y2);
		Class4603 @class = new Class4603(x2, y2);
		current.Path.PathCommands.Add(@class);
		return @class;
	}

	public static Class4603 smethod_2(Interface116 interpreter, double dx, double dy)
	{
		Class4598 current = interpreter.GraphStateStack.Current;
		current.Position = new Class4600(current.Position.X + dx, current.Position.Y + dy);
		current.CTM.method_0(current.Position.X, current.Position.Y, out var x, out var y);
		Class4603 @class = new Class4603(x, y);
		current.Path.PathCommands.Add(@class);
		return @class;
	}

	public static Class4602 smethod_3(Interface116 interpreter, double dx1, double dy1, double dx2, double dy2, double dx3, double dy3)
	{
		Class4598 current = interpreter.GraphStateStack.Current;
		double x = current.Position.X;
		double y = current.Position.Y;
		double num = x + dx1;
		double num2 = y + dy1;
		double num3 = num + dx2;
		double num4 = num2 + dy2;
		double x2 = num3 + dx3;
		double y2 = num4 + dy3;
		current.Position = new Class4600(x2, y2);
		current.CTM.method_0(num, num2, out var x3, out var y3);
		current.CTM.method_0(num3, num4, out var x4, out var y4);
		current.CTM.method_0(x2, y2, out var x5, out var y5);
		Class4602 @class = new Class4602(x3, y3, x4, y4, x5, y5);
		current.Path.PathCommands.Add(@class);
		return @class;
	}

	internal static Class4601 smethod_4(Interface116 interpreter)
	{
		Class4598 current = interpreter.GraphStateStack.Current;
		Class4601 @class = null;
		int num = current.Path.PathCommands.Count - 1;
		while (num >= 0)
		{
			if (!(current.Path.PathCommands[num] is Class4605))
			{
				num--;
				continue;
			}
			Class4605 class2 = (Class4605)current.Path.PathCommands[num];
			@class = new Class4601(class2.X, class2.Y);
			current.Path.PathCommands.Add(@class);
			break;
		}
		return @class;
	}
}
