using ns60;

namespace ns63;

internal class Class2716 : Class2639
{
	internal const int int_0 = 2000;

	private static readonly int[] int_1 = new int[16]
	{
		5000, 2147483647, 1044, 1, 1043, 1, 1031, 1, 1018, 0,
		1018, 1, 1032, 1, 1023, 1
	};

	public Class2730 ProgTags => (Class2730)method_1(5000);

	public Class2740 NormalViewSetInfo => (Class2740)method_1(1044);

	public Class2739 NotesTextViewInfo => (Class2739)method_1(1043);

	public Class2827 OutlineViewInfo => (Class2827)method_1(1031);

	public Class2732 SlideViewInfo => (Class2732)method_3(1018, 0);

	public Class2732 NotesViewInfo => (Class2732)method_3(1018, 1);

	public Class2826 SorterViewInfo => (Class2826)method_1(1032);

	public Class2736 VBAInfo => (Class2736)method_1(1023);

	public Class2716()
	{
		base.Header.Type = 2000;
	}

	public void method_5()
	{
		Class2740 @class = new Class2740();
		@class.method_5();
		@class.Header.Version = 15;
		@class.Header.Instance = 1;
		base.Records.Add(@class);
		Class2732 class2 = new Class2732();
		class2.method_5();
		class2.Header.Version = 15;
		class2.Header.Instance = 0;
		base.Records.Add(class2);
		Class2739 class3 = new Class2739();
		class3.method_5();
		class3.Header.Version = 15;
		class3.Header.Instance = 1;
		base.Records.Add(class3);
		Class2736 class4 = new Class2736();
		class4.method_5();
		class4.Header.Instance = 1;
		base.Records.Add(class4);
		Class2730 class5 = new Class2730();
		class5.method_5(Enum452.const_0);
		class5.Header.Version = 15;
		class5.Header.Instance = 0;
		base.Records.Add(class5);
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
