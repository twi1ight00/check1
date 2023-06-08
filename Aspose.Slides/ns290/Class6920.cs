using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6920 : Interface341
{
	private readonly Interface351 interface351_0;

	public Class6920(Interface351 boxInfoAccessor)
	{
		Class6892.smethod_0(boxInfoAccessor, "boxInfoAccessor");
		interface351_0 = boxInfoAccessor;
	}

	public IList imethod_0(Class6845 container, float height)
	{
		Class6892.smethod_0(container, "container");
		Class6845 @class = (Class6845)container.Clone();
		Class6845 class2 = (Class6845)container.Clone();
		method_0(@class, class2, container, height);
		List<Class6845> list = new List<Class6845>();
		list.Add(@class);
		list.Add(class2);
		return list;
	}

	private void method_0(Class6845 firstPart, Class6845 secondPart, Class6845 splittingBox, float height)
	{
		float num = interface351_0.imethod_18(splittingBox);
		float num2 = interface351_0.imethod_17(splittingBox);
		float num3 = height - num;
		float height2 = splittingBox.Size.Height - num3;
		firstPart.Size = new SizeF(splittingBox.Size.Width, num3);
		firstPart.Location = splittingBox.Location;
		secondPart.Size = new SizeF(splittingBox.Size.Width, height2);
		secondPart.Location = new PointF(splittingBox.Location.X, splittingBox.Location.Y + num3 + num2);
		firstPart.Style = Class6960.smethod_5(splittingBox.Style, isTopEdgeBroken: false, isBottomEdgeBroken: true);
		secondPart.Style = Class6960.smethod_5(splittingBox.Style, isTopEdgeBroken: true, isBottomEdgeBroken: false);
	}
}
