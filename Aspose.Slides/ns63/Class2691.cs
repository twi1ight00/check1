namespace ns63;

internal class Class2691 : Class2639
{
	internal const int int_0 = 4110;

	private static readonly int[] int_1 = new int[4] { 4100, 2147483647, 4114, 2147483647 };

	public Class2872 ExMediaAtom => (Class2872)method_1(4100);

	public Class2866 ExCDAudioAtom => (Class2866)method_1(4114);

	internal Class2691()
	{
		base.Header.Type = 4110;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
