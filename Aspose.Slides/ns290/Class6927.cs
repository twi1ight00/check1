using ns284;
using ns301;

namespace ns290;

internal abstract class Class6927 : Interface346
{
	private Interface361 interface361_0;

	private readonly Interface351 interface351_0;

	internal Interface361 UnitConverter
	{
		get
		{
			if (interface361_0 == null)
			{
				interface361_0 = new Class6970();
			}
			return interface361_0;
		}
		set
		{
			interface361_0 = value;
		}
	}

	internal Interface351 BoxInfo => interface351_0;

	protected Class6927()
	{
		interface351_0 = new Class6942();
	}

	public abstract void imethod_0(Class6844 box);

	internal bool method_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		return interface351_0.imethod_7(box);
	}

	internal void method_1(Class6844 box, Class6845 container)
	{
		Class6892.smethod_0(box, "box");
		Class6892.smethod_0(container, "container");
		Class6845 parent = BoxInfo.imethod_5(box);
		box.Style.Display = Enum952.const_1;
		box.Parent = parent;
		Class6849 @class = BoxInfo.imethod_4(container);
		@class.method_0(box);
	}

	protected static Interface354 smethod_0(Interface346 formattingContext)
	{
		if (!(formattingContext is Class6929) && !(formattingContext is Class6931))
		{
			if (formattingContext is Class6933)
			{
				return new Class6950();
			}
			if (formattingContext is Class6934)
			{
				return new Class6949();
			}
			return new Class6946();
		}
		return new Class6947();
	}
}
