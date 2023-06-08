using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("6e8e175f-2cba-4b54-87ff-cea960cf4ff7")]
[ComVisible(true)]
public interface IAudio
{
	string ContentType { get; }

	byte[] BinaryData { get; }
}
