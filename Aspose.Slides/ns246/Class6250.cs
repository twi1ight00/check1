using System.Collections.Generic;
using System.Drawing;
using ns224;
using ns235;
using ns242;

namespace ns246;

internal class Class6250
{
	protected Class6239 class6239_0;

	public Class6250(Class6239 docCreator)
	{
		class6239_0 = docCreator;
	}

	public virtual Class6204[] vmethod_0(Class6227 node)
	{
		List<Class6204> list = new List<Class6204>();
		Class6249 style = node.Style;
		if (style != null && style.class6248_0 != null)
		{
			list.AddRange(style.class6248_0.method_1(node));
		}
		return list.ToArray();
	}

	public virtual Class6204[] vmethod_1(Class6227 node)
	{
		Class6249 style = node.Style;
		List<Class6204> list = new List<Class6204>();
		if (style != null && style.class5998_1 != Class5998.class5998_141 && style.class5998_1 != null)
		{
			Class6217 @class = Class6217.smethod_1(new RectangleF(node.Location, node.Size));
			@class.Brush = new Class5997(style.class5998_1);
			Class6215 class2 = new Class6215();
			class2.Add(@class);
			list.Add(class2);
		}
		return list.ToArray();
	}
}
