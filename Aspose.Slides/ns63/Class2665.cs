namespace ns63;

internal class Class2665 : Class2639
{
	internal const int int_0 = 61745;

	private static readonly int[] int_1 = new int[6] { 61754, 2147483647, 61762, 1, 61738, 2147483647 };

	public Class2759 SetBehaviorAtom => (Class2759)method_1(61754);

	public Class2764 VarTo => method_1(61762) as Class2764;

	public Class2654 Behavior => (Class2654)method_1(61738);

	public Class2665()
	{
		base.Header.Type = 61745;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
