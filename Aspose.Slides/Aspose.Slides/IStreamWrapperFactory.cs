using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("D784F45F-EB75-4BBB-8582-7D4DDC75C405")]
public interface IStreamWrapperFactory
{
	IStreamWrapper CreateMemoryStreamWrapper();

	IStreamWrapper CreateMemoryStreamWrapper(byte[] buffer);

	IStreamWrapper CreateFileStreamWrapper(string fileName, FileMode fileMode);

	IStreamWrapper CreateFileStreamWrapper(string fileName, FileMode fileMode, FileAccess fileAccess);
}
