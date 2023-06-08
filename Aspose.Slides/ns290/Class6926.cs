using ns301;

namespace ns290;

internal class Class6926 : Interface345
{
	private readonly Interface351 interface351_0;

	private readonly Interface361 interface361_0;

	private Class6786 class6786_0;

	public Class6926(Interface351 boxInfo, Interface361 unitConverter, Class6786 renderContext)
	{
		Class6892.smethod_0(boxInfo, "boxInfo");
		Class6892.smethod_0(unitConverter, "unitConverter");
		Class6892.smethod_0(renderContext, "renderContext");
		interface351_0 = boxInfo;
		interface361_0 = unitConverter;
		class6786_0 = renderContext;
	}

	public Interface346 imethod_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		Class6927 @class = null;
		Class6845 class2 = box as Class6845;
		if (box is Class6852)
		{
			@class = new Class6933();
		}
		else if (box is Class6854)
		{
			@class = new Class6934();
		}
		else if (box is Class6851)
		{
			@class = new Class6932();
		}
		else if (class2 != null)
		{
			switch (interface351_0.imethod_1(box))
			{
			case Enum946.const_1:
				switch (interface351_0.imethod_0(class2))
				{
				case Enum946.const_0:
				{
					Interface348 aligner2 = new Class6936();
					@class = new Class6930(new Class6925(class6786_0), aligner2);
					break;
				}
				case Enum946.const_1:
				{
					Interface348 aligner = new Class6936();
					@class = new Class6928(aligner);
					break;
				}
				}
				break;
			case Enum946.const_0:
				@class = new Class6929();
				break;
			}
		}
		if (@class != null)
		{
			@class.UnitConverter = interface361_0;
		}
		return @class;
	}
}
