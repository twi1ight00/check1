using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("42f1cf4f-ae15-4314-837e-6ede630607c4")]
[ComVisible(true)]
public interface IThemeManager
{
	IThemeEffectiveData CreateThemeEffective();

	void ApplyColorScheme(IExtraColorScheme scheme);
}
