namespace ns63;

internal class Class2705 : Class2639
{
	public const int int_0 = 4112;

	private static readonly int[] int_1 = new int[4] { 4100, 2147483647, 4026, 0 };

	public Class2872 ExMedia => (Class2872)method_1(4100);

	public Class2843 AudioFilePath => method_4(0);

	public Class2705()
	{
		base.Header.Type = 4112;
		base.Records.Add(new Class2872());
		base.Records.Add(new Class2843("", 0));
	}

	public Class2705(int dummi)
	{
		base.Header.Type = 4112;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
