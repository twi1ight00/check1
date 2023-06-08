namespace ns14;

internal abstract class Class423 : Interface1
{
	protected abstract int vmethod_0(string string_0);

	public int imethod_0(string string_0, bool bool_0)
	{
		int num = vmethod_0(string_0);
		if (bool_0)
		{
			num--;
		}
		if (num <= 11)
		{
			return num;
		}
		return 11;
	}

	protected virtual double vmethod_1(Class484 class484_0)
	{
		return (double)class484_0.method_2("0123456789") / 10.0;
	}
}
