namespace ns63;

internal class Class2657 : Class2639
{
	internal const int int_0 = 61733;

	private static readonly int[] int_1 = new int[4] { 61736, 2147483647, 61756, 2147483647 };

	public Enum396 ConditionType => (Enum396)base.Header.Instance;

	public Class2750 ConditionAtom => (Class2750)method_1(61736);

	public Class2649 VisualElement => (Class2649)method_1(61756);

	public Class2657()
		: base(61733)
	{
	}

	public Class2657(Enum396 type)
		: base(61733)
	{
		class2943_0.Instance = (short)type;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
