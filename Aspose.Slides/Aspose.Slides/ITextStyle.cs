using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("d1d23c22-f002-42e0-98ee-43f1bf297e35")]
public interface ITextStyle
{
	IParagraphFormat DefaultParagraphFormat { get; }

	IParagraphFormat GetLevel(int index);
}
