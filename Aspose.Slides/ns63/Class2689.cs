namespace ns63;

internal class Class2689 : Class2639
{
	internal const int int_0 = 1010;

	private static readonly int[] int_1 = new int[14]
	{
		4040, 2147483647, 2005, 2147483647, 4004, 2147483647, 4005, 2147483647, 4011, 2147483647,
		4009, 2147483647, 4003, 2147483647
	};

	public Class2735 Kinsoku => (Class2735)method_1(4040);

	public Class2706 FontCollection => (Class2706)method_1(2005);

	public Class2909 TextCFDefaultsAtom => (Class2909)method_1(4004);

	public Class2908 TextPFDefaultsAtom => (Class2908)method_1(4005);

	public Class2825 DefaultRulerAtom => (Class2825)method_1(4011);

	public Class2907 TextSIDefaultsAtom => (Class2907)method_1(4009);

	public Class2894 TextMasterStyleAtom => (Class2894)method_1(4003);

	public Class2689()
	{
		base.Header.Type = 1010;
	}

	internal void method_5()
	{
		Class2735 @class = new Class2735();
		@class.method_5();
		@class.Header.Version = 15;
		@class.Header.Instance = 2;
		base.Records.Add(@class);
		Class2706 class2 = new Class2706();
		class2.method_5();
		class2.Header.Version = 15;
		class2.Header.Instance = 0;
		base.Records.Add(class2);
		Class2909 class3 = new Class2909();
		class3.method_1();
		class3.Header.Version = 0;
		class3.Header.Instance = 0;
		base.Records.Add(class3);
		Class2908 class4 = new Class2908();
		class4.method_1();
		class4.Header.Version = 0;
		class4.Header.Instance = 0;
		base.Records.Add(class4);
		Class2907 class5 = new Class2907();
		class5.method_1();
		class5.Header.Version = 0;
		class5.Header.Instance = 0;
		base.Records.Add(class5);
		Class2894 class6 = new Class2894();
		class6.method_1(Enum449.const_0, defaultStyle: true);
		class6.Header.Version = 0;
		base.Records.Add(class6);
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
