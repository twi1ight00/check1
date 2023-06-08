using ns60;

namespace ns63;

internal abstract class Class2722 : Class2639
{
	internal const int int_0 = 5002;

	internal Class2673 BinaryTagExtension => (Class2673)method_1(5003);

	protected Class2722()
	{
		base.Header.Type = 5002;
		base.Header.Instance = 0;
	}

	internal void method_5(Enum452 queryType)
	{
		Class2843 @class = new Class2843("___PPT10", 0);
		@class.Header.Version = 0;
		base.Records.Add(@class);
		Class2673 class2 = null;
		switch (queryType)
		{
		case Enum452.const_0:
			class2 = new Class2682();
			break;
		case Enum452.const_1:
		case Enum452.const_2:
			class2 = new Class2675();
			break;
		}
		class2.method_5(queryType);
		class2.Header.Version = 0;
		class2.Header.Instance = 0;
		base.Records.Add(class2);
	}
}
