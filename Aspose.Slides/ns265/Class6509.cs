using ns237;

namespace ns265;

internal class Class6509 : Class6504
{
	private readonly string string_0;

	public Class6509(string uri)
	{
		string_0 = uri;
	}

	public override void vmethod_0(Class6678 writer)
	{
		writer.Write("/A");
		writer.method_6();
		writer.method_8("/Type", "/Action");
		writer.method_8("/S", "/URI");
		writer.method_14("/URI", string_0, isEscape: true);
		writer.method_7();
	}
}
