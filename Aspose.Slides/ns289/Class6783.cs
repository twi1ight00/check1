using ns301;

namespace ns289;

internal class Class6783
{
	private Class6785 class6785_0;

	private bool bool_0;

	private Class6780 class6780_0;

	private Class6780 class6780_1;

	private Class6780 class6780_2;

	private Class6780 class6780_3;

	private Class6780 class6780_4;

	public Class6785 GlyphSize
	{
		get
		{
			return class6785_0;
		}
		set
		{
			class6785_0 = value;
		}
	}

	public bool ApplyPageClipping
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

	public Class6780 OddPage => class6780_3;

	public Class6780 EvenPage => class6780_4;

	public Class6780 AnyPage
	{
		get
		{
			return class6780_2;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6780_2 = value;
			class6780_3 = null;
			class6780_4 = null;
		}
	}

	public Class6780 FirstPage
	{
		get
		{
			return class6780_0;
		}
		set
		{
			class6780_0 = value;
		}
	}

	public Class6780 LastPage
	{
		get
		{
			return class6780_1;
		}
		set
		{
			class6780_1 = value;
		}
	}

	internal Class6783()
	{
		class6780_2 = Class6780.A4;
		class6785_0 = new Class6785(13f, Enum920.const_0);
	}

	public void method_0(Class6780 oddPage, Class6780 evenPage)
	{
		Class6892.smethod_0(oddPage, "oddPage");
		Class6892.smethod_0(evenPage, "evenPage");
		class6780_3 = oddPage;
		class6780_4 = evenPage;
		class6780_2 = null;
	}
}
