using System.Drawing;
using ns164;
using ns167;

namespace ns163;

internal abstract class Class4743
{
	protected readonly Class4743 class4743_0;

	protected readonly Class4750 class4750_0;

	internal Class4743(Class4743 nextRecognizer, Class4750 context)
	{
		class4743_0 = nextRecognizer;
		class4750_0 = context;
	}

	internal static void smethod_0(Class4779 node, Class4750 context)
	{
		if (node != null && node.Parent != null && context != null)
		{
			context.BottomOfLastElement = node.Parent.method_0(new PointF(node.BoundingBox.Right, node.BoundingBox.Bottom), context.LeftMargin).Y;
		}
	}

	internal virtual bool vmethod_0(Class4779 node)
	{
		bool result = false;
		if (class4743_0 != null)
		{
			result = class4743_0.vmethod_0(node);
		}
		return result;
	}

	internal static Class4755 smethod_1()
	{
		Class4762 @class = new Class4762(new Class4767());
		Class4767 class2 = new Class4767();
		class2.Add(Enum670.const_9, 1f);
		class2.Add(Enum670.const_27, Enum674.const_2);
		@class.Add(new Class4765(string.Empty, class2, null));
		return @class;
	}
}
