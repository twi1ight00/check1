using ns65;

namespace ns63;

internal class Class2696 : Class2639, Interface46
{
	public const int int_0 = 4046;

	private static readonly int[] int_1 = new int[12]
	{
		4049, 2147483647, 4035, 2147483647, 4026, 1, 4026, 2, 4026, 3,
		4033, 2147483647
	};

	public Class2871 ExOleLinkAtom => (Class2871)method_1(4049);

	public Class2875 ExOleObjAtom => (Class2875)method_1(4035);

	public Class2843 MenuNameAtom => method_4(1);

	public Class2843 ProgIdAtom => method_4(2);

	public Class2843 ClipboardNameAtom => method_4(3);

	public Class2822 Metafile => (Class2822)method_1(4033);

	public Class2696()
	{
		base.Header.Type = 4046;
		base.Records.Add(new Class2871());
		base.Records.Add(new Class2875());
		base.Records.Add(new Class2843("Object", 1));
		base.Records.Add(new Class2843("Object", 2));
		base.Records.Add(new Class2843("Object", 3));
	}

	public Class2696(int dummi)
	{
		base.Header.Type = 4046;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
