using ns56;

namespace ns8;

internal class Class133 : Class116
{
	private Class846 class846_0;

	private Class133 class133_0;

	public override string Name => ForeachNode.Name;

	public Class846 Filter => class846_0;

	private Class2169 ForeachNode => (Class2169)base.DataNode;

	public Class133(Class849 tree, Class2169 diagramNode)
	{
		class846_0 = new Class846(diagramNode);
	}

	public override void vmethod_0(Class837 parent, Class836 context)
	{
		if (!string.IsNullOrEmpty(ForeachNode.Ref))
		{
			if (class133_0 == null && method_4(base.Tree.RootLayout, ForeachNode.Ref) is Class133 @class)
			{
				class133_0 = (Class133)@class.method_0(this);
			}
			if (class133_0 != null)
			{
				class133_0.vmethod_0(parent, context);
			}
			return;
		}
		Class838 class2 = context.method_4(Filter, skipLastTransition: true);
		foreach (Class836 item in class2)
		{
			foreach (Class116 child in base.Children)
			{
				child.vmethod_0(parent, item);
			}
		}
	}
}
