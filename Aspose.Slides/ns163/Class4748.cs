using ns167;
using ns169;

namespace ns163;

internal class Class4748 : Class4743
{
	private Class4743 class4743_1;

	private Class4747 class4747_0;

	internal Class4743 First
	{
		set
		{
			class4743_1 = value;
		}
	}

	public Class4748(Class4750 context)
		: base(null, context)
	{
	}

	internal override bool vmethod_0(Class4779 node)
	{
		bool result = false;
		class4747_0 = new Class4747(class4743_1, class4750_0);
		if (node is Class4782 @class)
		{
			Class4781 class2 = @class.method_33();
			class2.BoundingGraphics.HasBoundary = false;
			if (!(result = class4747_0.vmethod_0(class2)))
			{
				Class4785 node2 = Class4804.smethod_4(@class);
				result = class4747_0.vmethod_0(node2);
			}
		}
		return result;
	}
}
