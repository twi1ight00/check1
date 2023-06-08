using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6922 : Interface341
{
	private readonly Interface351 interface351_0;

	public Class6922(Interface351 boxInfoAccessor)
	{
		Class6892.smethod_0(boxInfoAccessor, "boxInfoAccessor");
		interface351_0 = boxInfoAccessor;
	}

	public IList imethod_0(Class6845 container, float width)
	{
		Class6892.smethod_0(container, "container");
		Class6845 @class = (Class6845)container.Clone();
		Class6845 class2 = (Class6845)container.Clone();
		method_0(@class, class2, container, width);
		List<Class6845> list = new List<Class6845>();
		list.Add(@class);
		list.Add(class2);
		return list;
	}

	private void method_0(Class6845 firstPart, Class6845 secondPart, Class6845 splittingBox, float width)
	{
		float num = interface351_0.imethod_15(splittingBox);
		float num2 = width - num;
		float width2 = splittingBox.Size.Width - num2;
		firstPart.Size = new SizeF(num2, splittingBox.Size.Height);
		firstPart.Location = splittingBox.Location;
		secondPart.Size = new SizeF(width2, splittingBox.Size.Height);
		secondPart.Location = splittingBox.Location;
		firstPart.Style = Class6960.smethod_2(splittingBox.Style, isLeftSideBroken: false, isRightSideBroken: true);
		secondPart.Style = Class6960.smethod_2(splittingBox.Style, isLeftSideBroken: true, isRightSideBroken: false);
	}
}
