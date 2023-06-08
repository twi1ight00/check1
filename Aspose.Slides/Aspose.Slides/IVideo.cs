using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("ec14dc83-bb51-44c0-b9a9-6388d0b0f566")]
public interface IVideo
{
	string ContentType { get; }

	byte[] BinaryData { get; }
}
