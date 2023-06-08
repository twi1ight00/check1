using ns235;

namespace ns267;

internal class Class6619
{
	internal const string string_0 = "Aps";

	private Class6616 class6616_0;

	public Class6619(Class6616 context)
	{
		class6616_0 = context;
	}

	public Class6204 method_0()
	{
		if (class6616_0.Reader.CurrentElement.Name.Equals("Aps") && class6616_0.Reader.method_1())
		{
			Class6598 @class = class6616_0.method_3(class6616_0.Reader.CurrentElement.Name);
			if (@class != null)
			{
				return @class.method_1();
			}
		}
		return null;
	}

	public void method_1(Class6204 node)
	{
		class6616_0.Writer.method_1("Aps");
		method_2(node);
		class6616_0.Resources.Flush();
		class6616_0.Writer.method_3();
	}

	public void method_2(Class6204 node)
	{
		Class6598 @class = class6616_0.method_2(node);
		@class.vmethod_1(node);
		if (node is Class6212 node2)
		{
			method_3(node2);
		}
		class6616_0.Writer.method_2();
	}

	private void method_3(Class6212 node)
	{
		for (int i = 0; i < node.Count; i++)
		{
			method_2(node[i]);
		}
	}
}
