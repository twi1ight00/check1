namespace ns63;

internal class Class2667 : Class2639
{
	internal const int int_0 = 14100;

	private static readonly int[] int_1 = new int[6] { 4026, 0, 4026, 0, 14101, 2147483647 };

	public Class2843 ServerId => method_4(0);

	public Class2843 SlideLibUrl => method_4(1);

	public Class2772 SlideSyncInfoAtom12 => (Class2772)method_1(14101);

	internal Class2667()
	{
		base.Header.Type = 14100;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
