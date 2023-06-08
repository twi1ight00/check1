using ns56;

namespace ns24;

internal class Class330 : Class278
{
	private Class1885 class1885_0;

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	public void method_0(Class330 source)
	{
		class1885_0 = source.class1885_0.Clone();
	}
}
