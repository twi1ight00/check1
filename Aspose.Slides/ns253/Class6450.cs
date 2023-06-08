namespace ns253;

internal class Class6450
{
	private Class6435 class6435_0;

	private Class6435[] class6435_1 = new Class6435[9];

	public Class6435 DefaultParagraphProperties => class6435_0;

	public Class6435 ListLevel1Style => class6435_1[0];

	public Class6435 ListLevel2Style => class6435_1[1];

	public Class6435 ListLevel3Style => class6435_1[2];

	public Class6435 ListLevel4Style => class6435_1[3];

	public Class6435 ListLevel5Style => class6435_1[4];

	public Class6435 ListLevel6Style => class6435_1[5];

	public Class6435 ListLevel7Style => class6435_1[6];

	public Class6435 ListLevel8Style => class6435_1[7];

	public Class6435 ListLevel9Style => class6435_1[8];

	public Class6450()
	{
		for (int i = 0; i < class6435_1.Length; i++)
		{
			class6435_1[i] = new Class6435();
			class6435_1[i].Level = i;
			if (i > 0)
			{
				class6435_1[i].method_1(class6435_1[i - 1]);
				class6435_1[i].DefaultRunProperties.method_0(class6435_1[i - 1].DefaultRunProperties);
			}
		}
		class6435_0 = new Class6435();
		class6435_1[0].method_1(class6435_0);
		class6435_1[0].DefaultRunProperties.method_0(class6435_0.DefaultRunProperties);
	}

	public Class6435 method_0(int level)
	{
		return class6435_1[level];
	}
}
