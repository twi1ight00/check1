using System.Drawing;
using ns168;
using ns224;
using ns235;

namespace ns167;

internal class Class4781 : Class4780
{
	private RectangleF rectangleF_0;

	private readonly Class4857 class4857_0;

	internal Class4857 BoundingGraphics => class4857_0;

	internal override RectangleF BoundingBox => class4857_0.BoundingBox;

	internal override PointF Origin
	{
		get
		{
			return class4857_0.BoundingBox.Location;
		}
		set
		{
		}
	}

	internal override bool CanBeOptimized => false;

	internal RectangleF BigBrotherBoundary
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			rectangleF_0 = value;
		}
	}

	internal Class4781(Class4857 boundingGraphics)
	{
		class4857_0 = boundingGraphics;
		class4857_0.TextContainer = this;
		rectangleF_0 = class4857_0.BoundingBox;
	}

	internal override void vmethod_1(Class6216 targetPage)
	{
		base.vmethod_1(targetPage);
		Class6217 @class = Class6217.smethod_1(BoundingBox);
		@class.Pen = new Class6003(Class5998.class5998_134);
		targetPage.Add(@class);
	}
}
