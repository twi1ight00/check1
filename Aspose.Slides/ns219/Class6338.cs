using ns235;
using ns249;
using ns259;

namespace ns219;

internal class Class6338 : Class6337
{
	private Class6351 class6351_0;

	public Class6351 BlipFill
	{
		get
		{
			return class6351_0;
		}
		set
		{
			class6351_0 = value;
		}
	}

	public override Class6204 vmethod_0(Class6340 nodeRenderParams)
	{
		nodeRenderParams.TransformStack.method_0(vmethod_1());
		try
		{
			Class6412 @class = method_1(nodeRenderParams);
			@class.IsPictureRenderingMode = true;
			Class6213 class2 = base.Geometry.method_2(@class);
			Class6217 node = method_3(@class);
			class2.Insert(0, node);
			method_2(nodeRenderParams.TransformStack, class2);
			return class2;
		}
		finally
		{
			nodeRenderParams.TransformStack.method_1();
		}
	}

	private Class6217 method_3(Class6412 drawingContext)
	{
		Class6217 @class = base.Geometry.method_0(drawingContext);
		bool rotateWithShape = BlipFill.RotateWithShape;
		try
		{
			BlipFill.RotateWithShape = true;
			@class.Brush = BlipFill.vmethod_0(drawingContext.BrushRenderingContext);
			return @class;
		}
		finally
		{
			BlipFill.RotateWithShape = rotateWithShape;
		}
	}
}
