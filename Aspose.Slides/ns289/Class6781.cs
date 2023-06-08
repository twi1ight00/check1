using ns301;

namespace ns289;

internal class Class6781
{
	private Class6785 class6785_0;

	private Class6785 class6785_1;

	private Class6785 class6785_2;

	private Class6785 class6785_3;

	public Class6785 Top
	{
		get
		{
			return class6785_0;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6785_0 = value;
		}
	}

	public Class6785 Right
	{
		get
		{
			return class6785_1;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6785_1 = value;
		}
	}

	public Class6785 Bottom
	{
		get
		{
			return class6785_2;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6785_2 = value;
		}
	}

	public Class6785 Left
	{
		get
		{
			return class6785_3;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6785_3 = value;
		}
	}

	public Class6781()
	{
		Top = new Class6785(0f, Enum920.const_1);
		Right = new Class6785(0f, Enum920.const_1);
		Bottom = new Class6785(0f, Enum920.const_1);
		Left = new Class6785(0f, Enum920.const_1);
	}
}
