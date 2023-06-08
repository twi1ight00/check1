using System.Runtime.InteropServices;
using Aspose.Slides.Charts;

namespace Aspose.Slides.Theme;

[Guid("E7AD711E-54E3-404D-B6F6-54D3D4CC8BAC")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class ChartThemeManager : BaseOverrideThemeManager, IThemeManager, IOverrideThemeManager
{
	protected override IThemeable OwnerOfInheritedTheme => ((Chart)base.Parent).Slide;

	internal ChartThemeManager(Chart parent)
		: base(parent)
	{
	}
}
