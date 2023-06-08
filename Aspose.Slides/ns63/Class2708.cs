using System.Runtime.CompilerServices;

namespace ns63;

internal class Class2708 : Class2639, Interface44
{
	internal const int int_0 = 4041;

	private static readonly int[] int_1 = new int[12]
	{
		1036, 2147483647, 2032, 1, 4026, 3, 5000, 2147483647, 1038, 2147483647,
		1039, 2147483647
	};

	[CompilerGenerated]
	private uint uint_0;

	public Class2714 Drawing => (Class2714)method_1(1036);

	public uint PersistId
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public Class2840 SlideSchemeColorSchemeAtom => (Class2840)method_1(2032);

	public Class2843 SlideName => method_4(3);

	public Class2728 SlideProgTagsContainer => (Class2728)method_1(5000);

	public Class2779 RoundTripThemeAtom => (Class2779)method_1(1038);

	public Class2786 RoundTripColorMappingAtom => (Class2786)method_1(1039);

	internal Class2708()
	{
		base.Header.Type = 4041;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
