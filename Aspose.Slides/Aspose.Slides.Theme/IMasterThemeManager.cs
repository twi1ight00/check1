using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("ecd85d4e-452c-43d4-a194-75cb372ff2a2")]
public interface IMasterThemeManager : IThemeManager
{
	bool IsOverrideThemeEnabled { get; set; }

	IMasterTheme OverrideTheme { get; set; }

	IThemeManager AsIThemeManager { get; }
}
