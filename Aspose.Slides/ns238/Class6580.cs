using ns218;
using ns224;

namespace ns238;

internal class Class6580 : Class6568
{
	public Class6580(Class6567 context)
		: base(context)
	{
	}

	public void method_0(Class6591 placeObject)
	{
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_1(placeObject.CharacterId);
		base.Writer.method_1(3);
		Class6002 class2 = placeObject.RenderTransform;
		if (class2 == null)
		{
			class2 = new Class6002();
		}
		base.Writer.method_14(class2);
		@class.method_1(Enum878.const_3);
	}

	public void method_1(Class6591 placeObject)
	{
		bool flag = placeObject.RenderTransform != null;
		bool flag2 = Class5964.smethod_20(placeObject.Name);
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(placeObject.IsClip, closeByte: false);
		base.Writer.method_4(flag2, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(flag, closeByte: false);
		base.Writer.method_4(bit: true, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: true);
		base.Writer.method_1(placeObject.Depth);
		base.Writer.method_1(placeObject.CharacterId);
		if (flag)
		{
			base.Writer.method_14(placeObject.RenderTransform);
		}
		if (flag2)
		{
			base.Writer.method_9(placeObject.Name);
		}
		if (placeObject.IsClip)
		{
			base.Writer.method_1((short)(placeObject.Depth + 1));
		}
		@class.method_1(Enum878.const_23);
	}
}
