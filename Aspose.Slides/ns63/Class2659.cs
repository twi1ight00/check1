namespace ns63;

internal class Class2659 : Class2639
{
	internal const int int_0 = 61742;

	private static readonly int[] int_1 = new int[6] { 61751, 2147483647, 61762, 1, 61738, 2147483647 };

	public Class2754 MotionBehaviorAtom => (Class2754)method_1(61751);

	public Class2764 VarPath => method_3(61762, 1) as Class2764;

	public Class2654 TimeBehavior => (Class2654)method_1(61738);

	public Class2659()
		: base(61742)
	{
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
