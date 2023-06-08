using ns249;

namespace ns219;

internal abstract class Class6333 : Class6332, Interface280
{
	private Class6350 class6350_0;

	public Class6350 Fill
	{
		get
		{
			if (class6350_0 == null)
			{
				class6350_0 = new Class6357();
			}
			return class6350_0;
		}
		set
		{
			class6350_0 = value;
		}
	}

	Class6350 Interface280.imethod_0()
	{
		if (!(Fill is Class6353))
		{
			return Fill;
		}
		if (base.Parent is Interface280 @interface)
		{
			return @interface.imethod_0();
		}
		return null;
	}
}
