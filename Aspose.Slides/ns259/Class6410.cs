namespace ns259;

internal class Class6410
{
	private Class6403 class6403_0;

	private Class6403 class6403_1;

	internal Class6403 X
	{
		get
		{
			return class6403_0;
		}
		set
		{
			class6403_0 = ((value != null) ? value : new Class6403(0.0));
		}
	}

	internal Class6403 Y
	{
		get
		{
			return class6403_1;
		}
		set
		{
			class6403_1 = ((value != null) ? value : new Class6403(0.0));
		}
	}

	internal Class6410(string x, string y)
	{
		X = new Class6403(x);
		Y = new Class6403(y);
	}

	internal Class6410(double x, double y)
	{
		X = new Class6403(x);
		Y = new Class6403(y);
	}

	internal Class6410()
	{
		X = new Class6403(0.0);
		Y = new Class6403(0.0);
	}
}
