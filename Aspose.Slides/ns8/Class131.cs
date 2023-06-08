using System;
using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class131 : Class116
{
	private List<Class847> list_0;

	private List<Class850> list_1;

	private Class850 class850_1;

	public override string Name => ((Class2154)base.DataNode).Name;

	public Class131(Class849 tree, Class2154 diagramNode)
	{
		list_0 = new List<Class847>();
		list_1 = new List<Class850>();
		Class2191[] ifList = diagramNode.IfList;
		foreach (Class2191 @class in ifList)
		{
			list_0.Add(new Class847(@class, this));
			Class850 class2 = new Class850();
			Class2605[] childNodeList = @class.ChildNodeList;
			foreach (Class2605 class3 in childNodeList)
			{
				Class116 class4 = Class116.smethod_0(tree, (Class1351)class3.Object, this);
				if (class4 != null)
				{
					class2.Add(class4);
				}
			}
			list_1.Add(class2);
		}
		class850_1 = new Class850();
		Class2605[] childNodeList2 = diagramNode.Else.ChildNodeList;
		foreach (Class2605 class5 in childNodeList2)
		{
			Class116 class6 = Class116.smethod_0(tree, (Class1351)class5.Object, this);
			if (class6 != null)
			{
				class850_1.Add(class6);
			}
		}
	}

	public override void vmethod_0(Class837 parent, Class836 context)
	{
		Class850 @class = method_5(context, parent);
		if (@class == null)
		{
			return;
		}
		foreach (Class116 item in @class)
		{
			item.vmethod_0(parent, context);
		}
	}

	public Class850 method_5(Class836 dataContext, Class837 presentationContext)
	{
		int num = 0;
		while (true)
		{
			if (num < list_1.Count)
			{
				if (list_0[num].method_0(dataContext, presentationContext))
				{
					break;
				}
				num++;
				continue;
			}
			return class850_1;
		}
		return list_1[num];
	}

	public Class116 method_6(Type targetType, Class836 dataContext, Class837 presentationContext)
	{
		Class850 @class = method_5(dataContext, presentationContext);
		foreach (Class116 item in @class)
		{
			if (targetType.IsAssignableFrom(item.GetType()))
			{
				return item;
			}
		}
		foreach (Class116 item2 in @class)
		{
			if (item2 is Class131 class4)
			{
				Class116 class5 = class4.method_6(targetType, dataContext, presentationContext);
				if (class5 != null)
				{
					return class5;
				}
			}
		}
		return null;
	}

	public override void Print(string margin)
	{
		Console.WriteLine(margin + ToString());
		if (list_1 != null)
		{
			Console.WriteLine(margin + "  True branch");
			foreach (Class850 item in list_1)
			{
				foreach (Class116 item2 in item)
				{
					_ = item2;
				}
			}
		}
		if (class850_1 == null)
		{
			return;
		}
		Console.WriteLine(margin + "  False branch");
		foreach (Class116 item3 in class850_1)
		{
			_ = item3;
		}
	}
}
