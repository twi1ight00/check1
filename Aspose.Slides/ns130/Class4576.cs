namespace ns130;

internal class Class4576
{
	private Class4574 class4574_0;

	private Class4578 class4578_0;

	public Class4576(Class4574 input, int range)
	{
		class4578_0 = new Class4578(range);
		class4574_0 = input;
	}

	public short method_0()
	{
		short num = 1;
		short short_;
		do
		{
			num = ((!class4574_0.method_0()) ? class4578_0.struct177_0[num].short_1 : class4578_0.struct177_0[num].short_2);
			short_ = class4578_0.struct177_0[num].short_3;
		}
		while (short_ < 0);
		class4578_0.method_0(num);
		return short_;
	}
}
