using Aspose.Slides;
using ns56;
using ns7;

namespace ns18;

internal class Class1021
{
	public static void smethod_0(Class154 transform2D, Class1862 xfrm)
	{
		if (xfrm != null)
		{
			double x = 0.0;
			double y = 0.0;
			if (xfrm.Off != null)
			{
				x = xfrm.Off.X;
				y = xfrm.Off.Y;
			}
			double width = 0.0;
			double height = 0.0;
			if (xfrm.Ext != null)
			{
				width = xfrm.Ext.Cx;
				height = xfrm.Ext.Cy;
			}
			transform2D.method_1(x, y, width, height, xfrm.Rot, xfrm.FlipH ? NullableBool.True : NullableBool.False, xfrm.FlipV ? NullableBool.True : NullableBool.False);
		}
	}

	public static void smethod_1(Class154 transform2D, Class1976 xfrm)
	{
		if (xfrm != null)
		{
			double x = 0.0;
			double y = 0.0;
			if (xfrm.Off != null)
			{
				x = xfrm.Off.X;
				y = xfrm.Off.Y;
			}
			double width = 0.0;
			double height = 0.0;
			if (xfrm.Ext != null)
			{
				width = xfrm.Ext.Cx;
				height = xfrm.Ext.Cy;
			}
			transform2D.method_1(x, y, width, height, xfrm.Rot, xfrm.FlipH ? NullableBool.True : NullableBool.False, xfrm.FlipV ? NullableBool.True : NullableBool.False);
		}
	}

	public static bool smethod_2(Class154 transform2D)
	{
		if (double.IsNaN(transform2D.X) && double.IsNaN(transform2D.Y) && double.IsNaN(transform2D.Width) && double.IsNaN(transform2D.Height) && double.IsNaN(transform2D.Rotation) && transform2D.FlipH == NullableBool.NotDefined)
		{
			return transform2D.FlipV != NullableBool.NotDefined;
		}
		return true;
	}

	public static void smethod_3(Shape shape, Class1976.Delegate1795 addXfrm)
	{
		Class154 rawFrameImpl = shape.RawFrameImpl;
		if (smethod_2(rawFrameImpl))
		{
			smethod_4(shape, addXfrm());
		}
	}

	public static void smethod_4(Shape shape, Class1976 xfrm)
	{
		Class154 rawFrameImpl = shape.RawFrameImpl;
		if (smethod_2(rawFrameImpl))
		{
			IShapeFrame frame = shape.method_1();
			smethod_5(frame, xfrm);
		}
	}

	public static void smethod_5(IShapeFrame frame, Class1976 xfrm)
	{
		Class1903 @class = xfrm.delegate1576_0();
		@class.X = (double.IsNaN(frame.X) ? 0f : frame.X);
		@class.Y = (double.IsNaN(frame.Y) ? 0f : frame.Y);
		Class1906 class2 = xfrm.delegate1585_0();
		class2.Cx = (double.IsNaN(frame.Width) ? 0f : frame.Width);
		class2.Cy = (double.IsNaN(frame.Height) ? 0f : frame.Height);
		xfrm.Rot = (float.IsNaN(frame.Rotation) ? 0f : frame.Rotation);
		xfrm.FlipH = frame.FlipH == NullableBool.True;
		xfrm.FlipV = frame.FlipV == NullableBool.True;
	}
}
