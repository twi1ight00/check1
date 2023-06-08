namespace ns63;

internal abstract class Class2710 : Class2639, Interface45
{
	private Class2951 class2951_0;

	public Class2951 ParentFrame
	{
		get
		{
			return class2951_0;
		}
		set
		{
			class2951_0 = value;
		}
	}

	protected Class2710(Class2951 parentFrame)
	{
		class2951_0 = parentFrame;
	}
}
