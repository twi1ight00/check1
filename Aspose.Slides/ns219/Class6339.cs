using ns235;
using ns253;
using ns259;

namespace ns219;

internal class Class6339 : Class6337
{
	private Class6451 class6451_0;

	public Class6451 TextShape
	{
		get
		{
			return class6451_0;
		}
		set
		{
			class6451_0 = value;
		}
	}

	public override Class6204 vmethod_0(Class6340 nodeRenderParams)
	{
		nodeRenderParams.TransformStack.method_0(vmethod_1());
		try
		{
			Class6412 @class = method_1(nodeRenderParams);
			Class6213 class2 = base.Geometry.method_2(@class);
			if (TextShape != null)
			{
				class2.Add(TextShape.method_0(nodeRenderParams, vmethod_1().BoundingBox, @class));
			}
			method_2(nodeRenderParams.TransformStack, class2);
			return class2;
		}
		finally
		{
			nodeRenderParams.TransformStack.method_1();
		}
	}
}
