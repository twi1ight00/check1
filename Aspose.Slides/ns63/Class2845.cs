using ns60;

namespace ns63;

internal abstract class Class2845 : Class2623, Interface45
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

	protected Class2845(Class2951 subTextFrame)
	{
		class2951_0 = subTextFrame;
	}
}
