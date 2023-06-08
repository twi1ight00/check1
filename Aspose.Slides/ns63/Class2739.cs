namespace ns63;

internal class Class2739 : Class2639
{
	internal const int int_0 = 1043;

	private static readonly int[] int_1 = new int[2] { 1021, 2147483647 };

	public Class2904 ZoomViewInfo => (Class2904)method_1(1021);

	internal Class2739()
	{
		base.Header.Type = 1043;
	}

	internal void method_5()
	{
		Class2904 @class = new Class2904();
		@class.method_1(1);
		@class.Header.Version = 0;
		@class.Header.Instance = 0;
		base.Records.Add(@class);
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
