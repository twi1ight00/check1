using ns60;

namespace ns63;

internal abstract class Class2673 : Class2639
{
	internal const int int_0 = 5003;

	protected Class2673()
	{
		base.Header.Type = 5003;
		base.Header.Version = 0;
	}

	internal void method_5(Enum452 queryType)
	{
		if (queryType == Enum452.const_0)
		{
			Class2901 @class = new Class2901();
			@class.X = 46448;
			@class.Y = 46448;
			@class.Header.Version = 0;
			@class.Header.Instance = 0;
			base.Records.Add(@class);
		}
		else
		{
			Class2889 class2 = new Class2889();
			class2.Header.Version = 0;
			class2.Header.Instance = 0;
			base.Records.Add(class2);
		}
	}
}
