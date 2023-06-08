using System.Collections.Generic;
using System.Drawing;
using ns235;

namespace ns201;

internal class Class6181 : Class6176
{
	private Class6213 class6213_0;

	private List<Class6212[]> list_0 = new List<Class6212[]>();

	public override void vmethod_1(Class6216 page)
	{
		foreach (Class6212[] item in list_0)
		{
			item[0].Remove(item[1]);
			item[0].Add(item[2]);
		}
		list_0.Clear();
	}

	public override void vmethod_2(Class6213 canvas)
	{
		class6213_0 = canvas;
	}

	public override void vmethod_3(Class6213 canvas)
	{
		class6213_0 = null;
	}

	public override void vmethod_5(Class6217 path)
	{
		if (path.Hyperlink != null)
		{
			Class6213 @class = new Class6213();
			RectangleF activeRect = Class6182.smethod_2(path);
			@class.Hyperlink = Class6182.smethod_0(path.Hyperlink, activeRect);
			list_0.Add(new Class6212[3] { class6213_0, path, @class });
		}
	}
}
