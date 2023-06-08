using System.IO;
using ns16;

namespace ns46;

internal class Class1007
{
	private Class744 class744_0;

	private Class746 class746_0;

	public Class1007(Class744 class744_1, Class746 class746_1)
	{
		class744_0 = class744_1;
		class746_0 = class746_1;
	}

	public Stream GetSource()
	{
		Stream input = class746_0.method_39(class744_0);
		byte[] buffer = new BinaryReader(input).ReadBytes((int)class744_0.Size);
		return new MemoryStream(buffer);
	}
}
