using System.Collections.Generic;
using ns243;
using ns244;
using ns245;

namespace ns242;

internal class Class6238
{
	private Class6239 class6239_0;

	protected Class6239 Creator => class6239_0;

	public virtual void vmethod_0(Class6239 creator)
	{
		class6239_0 = creator;
	}

	public virtual bool vmethod_1(Class6233 page, Interface260 node)
	{
		if (node is Class6237)
		{
			return false;
		}
		Class6225 @class = (Class6225)node;
		if (page.vmethod_8() < page.Size.Height)
		{
			float num = page.Size.Height - page.vmethod_8();
			if (num > @class.Size.Height)
			{
				float dy = page.vmethod_9();
				@class.method_1(dy);
				page.vmethod_5(@class);
				return true;
			}
			return vmethod_2(@class, num);
		}
		return false;
	}

	protected virtual bool vmethod_2(Class6225 layoutNode, float pageAvailableHeight)
	{
		Class6242 @class = vmethod_3(layoutNode);
		Class6225[] array = @class.vmethod_0(pageAvailableHeight, layoutNode);
		if (array.Length > 1)
		{
			method_0(array);
			return true;
		}
		return false;
	}

	protected void method_0(Class6225[] nodes)
	{
		List<Interface260> list = new List<Interface260>();
		list.Add(Creator.NodesHolder.vmethod_1());
		list.Add(nodes[0]);
		list.Add(nodes[1]);
		while (!Creator.NodesHolder.IsEmpty)
		{
			list.Add(Creator.NodesHolder.vmethod_1());
		}
		foreach (Interface260 item in list)
		{
			Creator.NodesHolder.vmethod_0(item);
		}
	}

	public virtual Class6242 vmethod_3(Class6225 node)
	{
		if (node is Class6230)
		{
			return new Class6243(this);
		}
		if (node is Class6228)
		{
			return new Class6245(this);
		}
		if (node is Class6229)
		{
			return new Class6246(this);
		}
		return new Class6244(this);
	}
}
