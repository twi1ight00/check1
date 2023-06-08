namespace ns237;

internal class Class6547 : Class6511
{
	private readonly Class6683 class6683_0;

	private readonly Class6682 class6682_0;

	internal int Count => class6682_0.Count;

	public Class6683 Resources => class6683_0;

	internal Class6547(Class6672 context)
		: base(context)
	{
		class6682_0 = new Class6682();
		class6683_0 = new Class6683(context);
	}

	internal void method_1(string pageRef)
	{
		class6682_0.Add(pageRef);
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/Pages");
		writer.method_18("/Count", class6682_0.Count);
		writer.Write("/Kids");
		class6682_0.method_0(writer);
		writer.Write("/Resources");
		writer.method_6();
		class6683_0.method_5(writer);
		writer.method_7();
		writer.method_7();
		writer.method_30();
		class6683_0.method_6(writer);
	}
}
