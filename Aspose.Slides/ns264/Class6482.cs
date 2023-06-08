using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns233;
using ns235;

namespace ns264;

internal class Class6482
{
	private readonly Hashtable hashtable_0 = new Hashtable();

	public Class6213 method_0(Class6220 imageNode, Class6483 context)
	{
		int num = Class6145.smethod_1(imageNode.ImageBytes, null);
		Class6213 @class = (Class6213)hashtable_0[num];
		if (@class == null)
		{
			@class = Class6480.smethod_0(imageNode.ImageBytes, new SizeF(21600f, 21600f), context);
			hashtable_0[num] = @class;
		}
		Class6213 class2 = new Class6213();
		class2.Add(@class);
		RectangleF rectangleF = new RectangleF(0f, 0f, 21600f, 21600f);
		if (!Class6145.smethod_0(imageNode.Crop))
		{
			rectangleF = imageNode.Crop.method_0(rectangleF);
			class2.Clip = Class6217.smethod_1(rectangleF);
		}
		class2.RenderTransform = new Class6002();
		class2.RenderTransform.method_7(imageNode.Origin.X, imageNode.Origin.Y, MatrixOrder.Prepend);
		class2.RenderTransform.method_5(imageNode.Size.Width / rectangleF.Width, imageNode.Size.Height / rectangleF.Height, MatrixOrder.Prepend);
		class2.RenderTransform.method_7(0f - rectangleF.X, 0f - rectangleF.Y, MatrixOrder.Prepend);
		class2.Hyperlink = imageNode.Hyperlink;
		return class2;
	}
}
