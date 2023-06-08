namespace ns196;

internal class Class5695
{
	public static Class5695 class5695_0 = new Class5695("before");

	public static Class5695 class5695_1 = new Class5695("after");

	public static Class5695 class5695_2 = new Class5695("start");

	public static Class5695 class5695_3 = new Class5695("end");

	private string string_0;

	private Class5695(string name)
	{
		string_0 = name;
	}

	public string method_0()
	{
		return string_0;
	}

	public override string ToString()
	{
		return "RelSide:" + string_0;
	}
}
