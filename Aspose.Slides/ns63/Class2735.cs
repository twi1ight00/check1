namespace ns63;

internal class Class2735 : Class2639
{
	internal const int int_0 = 4040;

	private static readonly int[] int_1 = new int[6] { 4050, 2147483647, 4026, 0, 4026, 1 };

	public Class2906 KinsokuAtom => (Class2906)method_1(4050);

	public Class2843 KinsokuLeadingAtom => method_4(0);

	public Class2843 KinsokuFollowingAtom => method_4(1);

	public Class2735()
	{
		base.Header.Type = 4040;
		base.Header.Instance = 2;
	}

	internal void method_5()
	{
		Class2906 @class = new Class2906();
		@class.Level = Enum404.const_1;
		base.Records.Add(@class);
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
