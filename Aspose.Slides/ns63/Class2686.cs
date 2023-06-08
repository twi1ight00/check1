namespace ns63;

internal class Class2686 : Class2639
{
	public const int int_0 = 12004;

	private static readonly int[] int_1 = new int[4] { 4026, 0, 12005, 2147483647 };

	public string AuthorName => method_5(0);

	public Class2842 AuthorIndexAtom => method_1(12005) as Class2842;

	public Class2686()
	{
		base.Header.Type = 12004;
	}

	public string method_5(short instance)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2843 && ((Class2843)base.Records[num]).Header.Instance == instance)
				{
					break;
				}
				num++;
				continue;
			}
			return "";
		}
		return ((Class2843)base.Records[num]).String;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
