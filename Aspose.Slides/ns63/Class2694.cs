namespace ns63;

internal class Class2694 : Class2639
{
	public const int int_0 = 4055;

	private static readonly int[] int_1 = new int[8] { 4051, 2147483647, 4026, 0, 4026, 1, 4026, 3 };

	public Class2869 ExHyperlinkAtom => (Class2869)method_1(4051);

	public Class2843 FriendlyName => method_4(0);

	public Class2843 Target => method_4(1);

	public Class2843 Location => method_4(3);

	public Class2694()
	{
		base.Header.Type = 4055;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
