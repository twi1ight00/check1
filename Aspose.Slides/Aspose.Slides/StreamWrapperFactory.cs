using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("6B9A3515-0973-4686-BB42-C46B9A5FA12A")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class StreamWrapperFactory : IStreamWrapperFactory
{
	public IStreamWrapper CreateMemoryStreamWrapper()
	{
		return new StreamWrapper(new MemoryStream());
	}

	public IStreamWrapper CreateMemoryStreamWrapper(byte[] buffer)
	{
		return new StreamWrapper(new MemoryStream(buffer));
	}

	public IStreamWrapper CreateFileStreamWrapper(string fileName, FileMode fileMode)
	{
		return new StreamWrapper(new FileStream(fileName, fileMode));
	}

	public IStreamWrapper CreateFileStreamWrapper(string fileName, FileMode fileMode, FileAccess fileAccess)
	{
		return new StreamWrapper(new FileStream(fileName, fileMode, fileAccess));
	}
}
