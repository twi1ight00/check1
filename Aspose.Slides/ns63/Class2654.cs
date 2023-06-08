namespace ns63;

internal class Class2654 : Class2639
{
	internal const int int_0 = 61738;

	private static readonly int[] int_1 = new int[8] { 61747, 2147483647, 61758, 2147483647, 61757, 2147483647, 61756, 2147483647 };

	public Class2747 BehaviorAtom => (Class2747)method_1(61747);

	public Class2666 StringList => (Class2666)method_1(61758);

	public Class2661 PropertyList => (Class2661)method_1(61757);

	public Class2649 ClientVisualElement => (Class2649)method_1(61756);

	public Class2654()
		: base(61738)
	{
		base.Header.Version = 15;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
