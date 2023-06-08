using System.IO;
using ns18;
using ns22;

namespace ns47;

internal abstract class Class1067
{
	[Attribute0(true)]
	internal abstract void Write(Class1394 class1394_0);

	internal MemoryStream method_0()
	{
		MemoryStream memoryStream = new MemoryStream();
		Class1394 class1394_ = new Class1394(memoryStream);
		Write(class1394_);
		return memoryStream;
	}
}
