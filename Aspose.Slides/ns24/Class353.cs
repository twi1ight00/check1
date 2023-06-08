using ns56;

namespace ns24;

internal class Class353 : Class278
{
	private Class1456 class1456_0;

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

	public Class1456 Cell3D
	{
		get
		{
			return class1456_0;
		}
		set
		{
			class1456_0 = value;
		}
	}

	public bool NeedElement
	{
		get
		{
			if (ExtensionList == null)
			{
				return Cell3D != null;
			}
			return true;
		}
	}
}
