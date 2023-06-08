namespace ns63;

internal class Class2703 : Class2639
{
	internal const int int_0 = 4101;

	private static readonly int[] int_1 = new int[4] { 4100, 2147483647, 4026, 0 };

	public Class2872 ExMediaAtom => (Class2872)method_1(4100);

	public Class2843 VideoFilePath => method_4(0);

	internal Class2703()
	{
		base.Header.Type = 4101;
		base.Records.Add(new Class2872());
		base.Records.Add(new Class2843("", 0));
	}

	internal Class2703(int dummi)
	{
		base.Header.Type = 4101;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
