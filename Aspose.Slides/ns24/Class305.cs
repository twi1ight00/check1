using ns16;
using ns56;

namespace ns24;

internal class Class305 : Class278
{
	private Enum378 enum378_0 = Enum378.const_2;

	private Class1456 class1456_0;

	private Class1885 class1885_0;

	private Class1885 class1885_1;

	public Enum378 TextHorizontalOverflow
	{
		get
		{
			return enum378_0;
		}
		set
		{
			enum378_0 = value;
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

	public Class1885 ExtensionListOfCellProperties
	{
		get
		{
			return class1885_1;
		}
		set
		{
			class1885_1 = value;
		}
	}

	public void method_0(Class305 source)
	{
		enum378_0 = source.enum378_0;
		class1456_0 = source.class1456_0;
		class1885_0 = source.class1885_0;
		class1885_1 = source.class1885_1;
	}
}
