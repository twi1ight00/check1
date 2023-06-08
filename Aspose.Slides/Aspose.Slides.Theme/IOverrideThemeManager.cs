using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("778502ef-ee3d-4b84-9c60-62c8e155058f")]
public interface IOverrideThemeManager : IThemeManager
{
	bool IsOverrideThemeEnabled { get; }

	IOverrideTheme OverrideTheme { get; set; }

	IThemeManager AsIThemeManager { get; }
}
