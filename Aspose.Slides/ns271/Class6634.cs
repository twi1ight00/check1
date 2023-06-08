using System.IO;
using ns218;
using ns221;

namespace ns271;

internal abstract class Class6634
{
	[Attribute7(true)]
	internal abstract void Write(Class5951 writer);

	internal MemoryStream method_0()
	{
		MemoryStream memoryStream = new MemoryStream();
		Class5951 writer = new Class5951(memoryStream);
		Write(writer);
		return memoryStream;
	}
}
