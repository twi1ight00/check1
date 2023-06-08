using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("1a300121-25da-4599-98d1-50203f9108d1")]
[ComVisible(true)]
public interface IExtraColorScheme
{
	string Name { get; }

	IColorScheme ColorScheme { get; }
}
