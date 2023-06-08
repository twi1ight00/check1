namespace ns63;

internal class Class2658 : Class2639
{
	internal const int int_0 = 61741;

	private static readonly int[] int_1 = new int[10] { 61750, 2147483647, 61762, 1, 61762, 2, 61762, 3, 61738, 2147483647 };

	public Class2751 EffectBehaviorAtom => (Class2751)method_1(61750);

	public Class2764 VarType => method_3(61762, 1) as Class2764;

	public Class2762 VarProgress => method_3(61762, 2) as Class2762;

	public Class2764 VarRuntimeContext => method_3(61762, 3) as Class2764;

	public Class2654 Behavior => (Class2654)method_1(61738);

	public Class2658()
		: base(61741)
	{
		base.Header.Version = 15;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
