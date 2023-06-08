using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("47cc7ad5-3fc5-4013-82a5-904b3272f27c")]
[ComVisible(true)]
public interface IXpsOptions : ISaveOptions
{
	bool SaveMetafilesAsPng { get; set; }

	ISaveOptions AsISaveOptions { get; }
}
