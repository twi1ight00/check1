namespace ns63;

internal class Class2736 : Class2639
{
	internal const int int_0 = 1023;

	private static readonly int[] int_1 = new int[2] { 1024, 2147483647 };

	public Class2896 VbaInfoAtom => (Class2896)method_1(1024);

	internal Class2736()
	{
		base.Header.Type = 1023;
	}

	public void method_5()
	{
		Class2896 item = new Class2896();
		base.Records.Add(item);
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
