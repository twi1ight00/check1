namespace ns63;

internal class Class2690 : Class2639
{
	public const int int_0 = 4102;

	private static readonly int[] int_1 = new int[2] { 4101, 2147483647 };

	public Class2703 ExVideo => (Class2703)method_1(4101);

	public Class2690()
	{
		base.Header.Type = 4102;
		base.Records.Add(new Class2703());
	}

	public Class2690(int dummi)
	{
		base.Header.Type = 4102;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
