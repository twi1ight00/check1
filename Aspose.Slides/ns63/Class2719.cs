using ns60;

namespace ns63;

internal class Class2719 : Class2717
{
	public const int int_0 = 1006;

	internal bool bool_2 = true;

	private static readonly int[] int_1 = new int[30]
	{
		1007, 2147483647, 1017, 2147483647, 4057, 2147483647, 14100, 2147483647, 1036, 2147483647,
		2032, 1, 4026, 3, 5000, 2147483647, 1038, 2147483647, 1039, 2147483647,
		1053, 2147483647, 14100, 2147483647, 11021, 2147483647, 11019, 2147483647, 1058, 2147483647
	};

	public Class2667 RtSlideSyncInfo12 => (Class2667)method_1(14100);

	public Class2667 RoundTripSlideSyncInfo12Container => (Class2667)method_1(14100);

	public Class2782 RoundTripContentMasterId12Atom => (Class2782)method_1(1058);

	public Class2719()
	{
		base.Header.Type = 1006;
	}

	public Class2840 method_6()
	{
		Class2840 @class = base.SlideSchemeColorSchemeAtom;
		if (@class == null)
		{
			int i;
			for (i = 0; i < base.Records.Count - 1; i++)
			{
				Class2623 class2 = base.Records[i];
				if (class2.Type == 1036)
				{
					break;
				}
			}
			@class = new Class2840();
			@class.Header.Instance = 1;
			base.Records.Insert(i + 1, @class);
		}
		return @class;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
