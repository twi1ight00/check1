namespace ns63;

internal class Class2664 : Class2639
{
	internal const int int_0 = 61744;

	private static readonly int[] int_1 = new int[4] { 61753, 2147483647, 61738, 2147483647 };

	public Class2757 ScaleBehaviorAtom => (Class2757)method_1(61753);

	public Class2654 Behavior => (Class2654)method_1(61738);

	public Class2664()
		: base(61744)
	{
		base.Header.Version = 15;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
