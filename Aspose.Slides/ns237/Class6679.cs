using System.IO;
using ns218;
using ns234;

namespace ns237;

internal class Class6679 : Class6678
{
	private readonly Class5967 class5967_0;

	public int CrossReferenceCount => class5967_0.Count;

	public Class6679(Stream stream)
		: base(stream)
	{
		class5967_0 = new Class5967();
		class5967_0.Add(0, 0);
	}

	public void method_29(Class6511 obj)
	{
		class5967_0.Add(obj.Id, (int)base.BaseStream.Position);
		method_4("{0} 0 obj", Class6159.smethod_24(obj.Id));
	}

	public void method_30()
	{
		method_2();
		method_3("endobj");
	}

	public int method_31()
	{
		int result = (int)base.BaseStream.Position;
		method_3("xref");
		method_4("0 {0}", Class6159.smethod_24(class5967_0.Count));
		method_3("0000000000 65535 f");
		for (int i = 1; i < class5967_0.Count; i++)
		{
			method_4("{0} 00000 n", Class6159.smethod_29((int)class5967_0.method_3(i)));
		}
		return result;
	}
}
