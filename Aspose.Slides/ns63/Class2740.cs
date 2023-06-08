namespace ns63;

internal class Class2740 : Class2639
{
	internal const int int_0 = 1044;

	private static readonly int[] int_1 = new int[2] { 1045, 2147483647 };

	public Class2902 NormalViewSetInfoAtom => (Class2902)method_1(1045);

	internal Class2740()
	{
		base.Header.Type = 1044;
	}

	internal void method_5()
	{
		Class2902 @class = new Class2902();
		@class.method_1();
		@class.Header.Version = 0;
		@class.Header.Instance = 0;
		base.Records.Add(@class);
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
