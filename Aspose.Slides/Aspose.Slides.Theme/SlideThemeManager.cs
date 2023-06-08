using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("977F35FD-3CB3-4155-8863-A12742F2B87B")]
[ClassInterface(ClassInterfaceType.None)]
public class SlideThemeManager : BaseOverrideThemeManager, IThemeManager, IOverrideThemeManager
{
	protected override IThemeable OwnerOfInheritedTheme => ((Slide)base.Parent).LayoutSlide;

	internal SlideThemeManager(Slide parent)
		: base(parent)
	{
	}
}
