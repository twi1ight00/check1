using Aspose.Slides;
using ns56;
using ns7;

namespace ns18;

internal class Class962
{
	public static void smethod_0(Class155 groupTransform2D, Class1995 groupShapeElementData)
	{
		Class1862 xfrm = groupShapeElementData.GrpSpPr.Xfrm;
		if (xfrm != null)
		{
			Class1021.smethod_0(groupTransform2D, xfrm);
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			if (xfrm.ChOff != null)
			{
				num = (float)xfrm.ChOff.X;
				num2 = (float)xfrm.ChOff.Y;
			}
			if (xfrm.ChExt != null)
			{
				num3 = (float)xfrm.ChExt.Cx;
				num4 = (float)xfrm.ChExt.Cy;
			}
			groupTransform2D.method_5(num, num2, num3, num4);
		}
	}

	public static void smethod_1(GroupShape groupShape, Class1862.Delegate1465 addXfrm)
	{
		Class155 rawFrameImpl = groupShape.RawFrameImpl;
		double childX = rawFrameImpl.ChildX;
		double childY = rawFrameImpl.ChildY;
		double childWidth = rawFrameImpl.ChildWidth;
		double childHeight = rawFrameImpl.ChildHeight;
		double x = rawFrameImpl.X;
		double y = rawFrameImpl.Y;
		double width = rawFrameImpl.Width;
		double height = rawFrameImpl.Height;
		float rotation = rawFrameImpl.Rotation;
		NullableBool flipH = rawFrameImpl.FlipH;
		NullableBool flipV = rawFrameImpl.FlipV;
		if (!double.IsNaN(x) || !double.IsNaN(y) || !double.IsNaN(width) || !double.IsNaN(height) || !float.IsNaN(rotation) || flipH != NullableBool.NotDefined || flipV != NullableBool.NotDefined || (!double.IsNaN(childX) && childX != 0.0) || (!double.IsNaN(childY) && childY != 0.0) || (!double.IsNaN(childWidth) && childWidth != 0.0) || (!double.IsNaN(childHeight) && childHeight != 0.0))
		{
			Class1862 @class = addXfrm();
			IShapeFrame shapeFrame = groupShape.method_1();
			Class1903 class2 = @class.delegate1576_0();
			class2.X = (double.IsNaN(shapeFrame.X) ? 0f : shapeFrame.X);
			class2.Y = (double.IsNaN(shapeFrame.Y) ? 0f : shapeFrame.Y);
			Class1906 class3 = @class.delegate1585_0();
			class3.Cx = (double.IsNaN(shapeFrame.Width) ? 0f : shapeFrame.Width);
			class3.Cy = (double.IsNaN(shapeFrame.Height) ? 0f : shapeFrame.Height);
			@class.Rot = (float.IsNaN(shapeFrame.Rotation) ? 0f : shapeFrame.Rotation);
			@class.FlipH = shapeFrame.FlipH == NullableBool.True;
			@class.FlipV = shapeFrame.FlipV == NullableBool.True;
			if (childX != 0.0 || childY != 0.0)
			{
				Class1903 class4 = @class.delegate1576_1();
				class4.X = (double.IsNaN(childX) ? 0.0 : childX);
				class4.Y = (double.IsNaN(childY) ? 0.0 : childY);
			}
			if (childWidth != 0.0 || childHeight != 0.0)
			{
				Class1906 class5 = @class.delegate1585_1();
				class5.Cx = (double.IsNaN(childWidth) ? 0.0 : childWidth);
				class5.Cy = (double.IsNaN(childHeight) ? 0.0 : childHeight);
			}
		}
	}
}
