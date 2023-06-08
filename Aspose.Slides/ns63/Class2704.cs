namespace ns63;

internal class Class2704 : Class2639
{
	public const int int_0 = 4111;

	private static readonly int[] int_1 = new int[4] { 4100, 2147483647, 4115, 1 };

	public Class2872 ExMedia => (Class2872)method_1(4100);

	public Class2878 ExWavAudioEmbedded => (Class2878)method_1(4115);

	public Class2704()
	{
		base.Header.Type = 4111;
		base.Records.Add(new Class2872());
		base.Records.Add(new Class2878());
	}

	public Class2704(int dummi)
	{
		base.Header.Type = 4111;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
