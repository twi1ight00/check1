namespace ns63;

internal class Class2652 : Class2639
{
	internal const int int_0 = 61739;

	private static readonly int[] int_1 = new int[12]
	{
		61748, 2147483647, 61759, 2147483647, 61762, 1, 61762, 2, 61762, 3,
		61738, 2147483647
	};

	public Class2745 AnimateBehaviorAtom => (Class2745)method_1(61748);

	public Class2653 AnimateValueList => (Class2653)method_1(61759);

	public Class2764 VarBy => ((Class2760)method_3(61762, 1)) as Class2764;

	public Class2764 VarFrom => ((Class2760)method_3(61762, 2)) as Class2764;

	public Class2764 VarTo => ((Class2760)method_3(61762, 3)) as Class2764;

	public Class2654 Behavior => (Class2654)method_1(61738);

	public Class2652()
	{
		base.Header.Type = 61739;
		base.Header.Version = 15;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
