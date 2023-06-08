namespace ns63;

internal class Class2697 : Class2639
{
	public const int int_0 = 4103;

	private static readonly int[] int_1 = new int[2] { 4101, 2147483647 };

	public Class2703 ExVideo => (Class2703)method_1(4101);

	internal Class2697()
	{
		base.Header.Type = 4103;
		base.Records.Add(new Class2703());
	}

	internal Class2697(int dummi)
	{
		base.Header.Type = 4103;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
