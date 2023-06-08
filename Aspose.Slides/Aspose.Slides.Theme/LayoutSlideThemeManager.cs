using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("4FABDE3A-5FEB-4117-8FEF-F5FEDE7AB6AF")]
[ClassInterface(ClassInterfaceType.None)]
public class LayoutSlideThemeManager : BaseOverrideThemeManager, IThemeManager, IOverrideThemeManager
{
	protected override IThemeable OwnerOfInheritedTheme => ((LayoutSlide)base.Parent).MasterSlide;

	internal LayoutSlideThemeManager(LayoutSlide parent)
		: base(parent)
	{
	}
}
