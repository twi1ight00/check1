using System.IO;
using Aspose;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal abstract class xba15250b3f24fd3a
{
	[JavaThrows(true)]
	internal abstract void x6210059f049f0d48(x73087173962e3778 xbdfb620b7167944b);

	internal MemoryStream x0fe354a7e0ea7cc1()
	{
		MemoryStream memoryStream = new MemoryStream();
		x73087173962e3778 xbdfb620b7167944b = new x73087173962e3778(memoryStream);
		x6210059f049f0d48(xbdfb620b7167944b);
		return memoryStream;
	}

	internal byte[] x2797b998ab68f4ab()
	{
		using MemoryStream memoryStream = x0fe354a7e0ea7cc1();
		return memoryStream.ToArray();
	}
}
