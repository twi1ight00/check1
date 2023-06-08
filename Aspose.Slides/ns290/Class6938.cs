using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns301;

namespace ns290;

internal class Class6938
{
	private readonly Interface340 interface340_0;

	private readonly Interface344 interface344_0;

	private readonly SizeF sizeF_0;

	private IList ilist_0;

	public Class6938(Interface340 blockBoxPlacer, Interface344 boxFactory, SizeF pageSize)
	{
		Class6892.smethod_0(blockBoxPlacer, "blockBoxPlacer");
		Class6892.smethod_0(boxFactory, "boxFactory");
		interface340_0 = blockBoxPlacer;
		interface344_0 = boxFactory;
		sizeF_0 = pageSize;
	}

	public IList method_0()
	{
		return ilist_0;
	}

	public void method_1(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6845 box2))
		{
			throw new ArgumentException("box should be a container");
		}
		ilist_0 = new List<Class6849>();
		Class6849 page = interface344_0.imethod_7(sizeF_0);
		method_2(box2, ref page, ilist_0);
		if (page.InnerBoxes.Count > 0)
		{
			ilist_0.Add(page);
		}
	}

	private void method_2(Class6844 box, ref Class6849 page, IList pages)
	{
		Class6844 @class = interface340_0.imethod_0(box, page);
		if (@class != null)
		{
			pages.Add(page);
			@class.Location = new PointF(@class.Location.X, 0f);
			page = interface344_0.imethod_7(sizeF_0);
			method_2(@class, ref page, pages);
		}
	}
}
