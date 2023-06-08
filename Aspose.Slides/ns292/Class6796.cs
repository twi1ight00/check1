using ns284;
using ns301;

namespace ns292;

internal class Class6796
{
	private Class6795 class6795_0;

	private Class6795 class6795_1;

	private Class6795 class6795_2;

	private Class6795 class6795_3;

	private bool bool_0;

	private Class6959 class6959_0;

	public Class6795 TopBorderStyle
	{
		get
		{
			return class6795_0;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6795_0 = value;
		}
	}

	public Class6795 RightBorderStyle
	{
		get
		{
			return class6795_1;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6795_1 = value;
		}
	}

	public Class6795 BottomBorderStyle
	{
		get
		{
			return class6795_2;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6795_2 = value;
		}
	}

	public Class6795 LeftBorderStyle
	{
		get
		{
			return class6795_3;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6795_3 = value;
		}
	}

	public bool ResolutionDependentFlow
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class6959 PageMargin
	{
		get
		{
			return class6959_0;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6959_0 = value;
		}
	}

	public Class6796()
	{
		class6795_0 = new Class6795();
		class6795_1 = (Class6795)class6795_0.Clone();
		class6795_2 = (Class6795)class6795_0.Clone();
		class6795_3 = (Class6795)class6795_0.Clone();
		bool_0 = false;
		class6959_0 = new Class6959(0f, Enum955.const_4);
	}
}
