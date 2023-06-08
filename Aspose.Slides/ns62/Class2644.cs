using ns60;
using ns63;

namespace ns62;

internal class Class2644 : Class2639
{
	internal const int int_0 = 61440;

	private Class2640 class2640_0;

	private Class2744 class2744_0;

	public Class2744 DrawingGroup
	{
		get
		{
			if (class2744_0 != null)
			{
				return class2744_0;
			}
			class2744_0 = method_1(61446) as Class2744;
			if (class2744_0 == null && base.AutoInit)
			{
				class2744_0 = new Class2744();
				base.Records.Insert(0, class2744_0);
			}
			return class2744_0;
		}
	}

	public Class2640 BlipStore
	{
		get
		{
			if (class2640_0 != null)
			{
				return class2640_0;
			}
			class2640_0 = method_1(61441) as Class2640;
			if (class2640_0 == null)
			{
				class2640_0 = new Class2640();
				class2640_0.Header.Instance = 0;
				if (base.Records.Count > 1)
				{
					base.Records.Insert(1, class2640_0);
				}
				else
				{
					base.Records.Add(class2640_0);
				}
			}
			return class2640_0;
		}
	}

	public Class2834 DrawingPrimaryOptions => method_1(61451) as Class2834;

	public Class2837 DrawingTertiaryOptions => method_1(61730) as Class2837;

	public Class2820 ColorMRU => method_1(61722) as Class2820;

	public Class2900 SplitColors => method_1(61726) as Class2900;

	public Class2644()
		: base(61440)
	{
		base.Header.Instance = 0;
	}

	internal void method_5()
	{
		Class2744 @class = new Class2744();
		@class.method_1();
		@class.Header.Version = 0;
		@class.Header.Instance = 0;
		base.Records.Add(@class);
		Class2834 class2 = new Class2834();
		class2.method_1(Enum452.const_0, 0);
		class2.Header.Version = 3;
		base.Records.Add(class2);
		Class2900 class3 = new Class2900(134217732u, 134217729u, 134217730u, 268435703u);
		class3.Header.Version = 0;
		class3.Header.Instance = 4;
		base.Records.Add(class3);
	}
}
