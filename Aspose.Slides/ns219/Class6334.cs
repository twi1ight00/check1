using System.Collections.Generic;
using ns235;
using ns263;

namespace ns219;

internal abstract class Class6334 : Class6333
{
	private readonly List<Class6332> list_0 = new List<Class6332>();

	private Class6474 class6474_0;

	internal List<Class6332> Nodes => list_0;

	public override Class6473 vmethod_1()
	{
		if (class6474_0 == null)
		{
			class6474_0 = new Class6474();
		}
		return class6474_0;
	}

	internal void method_0(Class6474 transform)
	{
		class6474_0 = transform;
	}

	public override Class6204 vmethod_0(Class6340 nodeRenderParams)
	{
		nodeRenderParams.TransformStack.method_0(vmethod_1());
		try
		{
			Class6212 @class = vmethod_2();
			foreach (Class6332 node2 in Nodes)
			{
				Class6204 node = node2.vmethod_0(nodeRenderParams);
				@class.Add(node);
			}
			return @class;
		}
		finally
		{
			nodeRenderParams.TransformStack.method_1();
		}
	}

	internal void AddNode(Class6332 node)
	{
		if (node != null)
		{
			list_0.Add(node);
			node.Parent = this;
		}
	}

	protected abstract Class6212 vmethod_2();
}
