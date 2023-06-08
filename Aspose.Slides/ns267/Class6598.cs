using ns235;

namespace ns267;

internal abstract class Class6598
{
	private readonly Class6616 class6616_0;

	protected Class6616 Context => class6616_0;

	protected abstract string RootNodeName { get; }

	protected Class6598(Class6616 context)
	{
		class6616_0 = context;
	}

	public abstract bool vmethod_0(Class6204 node);

	public virtual void vmethod_1(Class6204 node)
	{
		if (node.Id != null && node.Id.Length > 0)
		{
			Context.Writer.method_25("Id", node.Id);
		}
	}

	public bool method_0(string nodeName)
	{
		return nodeName.Equals(RootNodeName);
	}

	protected abstract Class6204 vmethod_2();

	public Class6204 method_1()
	{
		Class6204 @class = vmethod_2();
		if (@class != null)
		{
			string value = string.Empty;
			if (Context.Reader.method_11("Id", out value) && value != null && value.Length > 0)
			{
				@class.Id = value;
			}
		}
		if (@class is Class6212 class2 && class6616_0.Reader.method_1())
		{
			do
			{
				Class6598 class3 = class6616_0.method_3(class6616_0.Reader.CurrentElement.Name);
				if (class3 != null)
				{
					class2.Add(class3.method_1());
				}
			}
			while (class6616_0.Reader.method_0());
			class6616_0.Reader.method_2();
		}
		return @class;
	}
}
