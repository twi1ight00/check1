namespace ns63;

internal class Class2663 : Class2639
{
	internal const int int_0 = 61743;

	private static readonly int[] int_1 = new int[4] { 61752, 2147483647, 61738, 2147483647 };

	public Class2756 RotationBehaviorAtom => (Class2756)method_1(61752);

	public Class2654 Behavior => (Class2654)method_1(61738);

	public Class2663()
		: base(61743)
	{
		base.Header.Version = 15;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
