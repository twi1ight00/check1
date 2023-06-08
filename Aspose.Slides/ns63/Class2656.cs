namespace ns63;

internal class Class2656 : Class2639
{
	internal const int int_0 = 61746;

	private static readonly int[] int_1 = new int[6] { 61755, 2147483647, 61762, 1, 61738, 2147483647 };

	public Class2749 CommandBehaviorAtom => (Class2749)method_1(61755);

	public Class2764 VarCommand => ((Class2760)method_1(61762)) as Class2764;

	public Class2654 Behavior => (Class2654)method_1(61738);

	public Class2656()
		: base(61746)
	{
		base.Header.Version = 15;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
