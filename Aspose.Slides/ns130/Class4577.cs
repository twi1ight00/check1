namespace ns130;

internal class Class4577
{
	private Class4575 class4575_0;

	private Class4578 class4578_0;

	public Class4577(Class4575 output, int range)
	{
		class4575_0 = output;
		class4578_0 = new Class4578(range);
	}

	public int method_0(int symbol)
	{
		int num = class4578_0.short_0[symbol];
		int num2 = 0;
		do
		{
			num2++;
			num = class4578_0.struct177_0[num].short_0;
		}
		while (num != 1);
		return num2 << 16;
	}

	public void method_1(int symbol)
	{
		int num = class4578_0.short_0[symbol];
		int a = num;
		bool[] array = new bool[50];
		int num2 = 0;
		do
		{
			int short_ = class4578_0.struct177_0[num].short_0;
			array[num2++] = class4578_0.struct177_0[short_].short_2 == num;
			num = short_;
		}
		while (num != 1);
		do
		{
			class4575_0.method_1(array[--num2]);
		}
		while (num2 > 0);
		class4578_0.method_0(a);
	}
}
