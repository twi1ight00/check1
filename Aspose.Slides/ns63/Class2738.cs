namespace ns63;

internal class Class2738 : Class2639
{
	private static readonly int[] int_0 = new int[2] { 4086, 2147483647 };

	public Class2844 CurrentUserAtom => (Class2844)base.Records[0];

	public Class2738(Class2844 currentUserAtom)
	{
		base.Records.Add(currentUserAtom);
	}

	internal Class2738()
	{
	}

	public void method_5(Class2844 currentUserAtom)
	{
		base.Records.Clear();
		base.Records.Add(currentUserAtom);
	}

	protected override int[] vmethod_6()
	{
		return int_0;
	}
}
