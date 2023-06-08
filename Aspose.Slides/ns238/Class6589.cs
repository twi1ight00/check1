using ns218;

namespace ns238;

internal class Class6589
{
	private Class6590 class6590_0;

	private Class6590 class6590_1;

	private int int_0;

	public Class6589(int expandedOutlineLevels)
	{
		class6590_0 = new Class6590(-1, "root", string.Empty);
		class6590_1 = class6590_0;
		int_0 = expandedOutlineLevels;
	}

	public void method_0(int level, string title, string navigationUrl)
	{
		if (level < 0 || !Class5964.smethod_20(title) || !Class5964.smethod_20(navigationUrl))
		{
			return;
		}
		Class6590 @class = new Class6590(level, title, navigationUrl);
		if (@class.Level > class6590_1.Level)
		{
			class6590_1.method_0(@class);
		}
		else if (@class.Level < class6590_1.Level)
		{
			while (class6590_1.Level >= @class.Level)
			{
				class6590_1 = class6590_1.Parent;
			}
			class6590_1.method_0(@class);
		}
		else
		{
			class6590_1.Parent.method_0(@class);
		}
		class6590_1 = @class;
	}

	public void method_1(Class5946 builder)
	{
		builder.method_2("outlines");
		builder.method_14("expandedOutlineLevels", int_0.ToString());
		class6590_0.method_1(builder);
		builder.method_3();
	}
}
