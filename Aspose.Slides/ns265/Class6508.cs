using ns237;

namespace ns265;

internal class Class6508 : Class6504
{
	private readonly string string_0;

	public static Class6508 NextPage => new Class6508("NextPage");

	public static Class6508 PreviousPage => new Class6508("PrevPage");

	public static Class6508 FirstPage => new Class6508("FirstPage");

	public static Class6508 LastPage => new Class6508("LastPage");

	public static Class6508 GoBack => new Class6508("GoBack");

	public Class6508(string name)
	{
		string_0 = name;
	}

	public override void vmethod_0(Class6678 writer)
	{
		writer.Write("/A");
		writer.method_6();
		writer.method_8("/Type", "/Action");
		writer.method_8("/S", "/Named");
		writer.method_8("/N", "/" + string_0);
		writer.method_7();
	}
}
