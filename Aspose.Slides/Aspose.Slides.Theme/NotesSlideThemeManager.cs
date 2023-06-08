using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("5FBD1037-149A-4B4E-BA5D-E2604E72F5B0")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class NotesSlideThemeManager : BaseOverrideThemeManager, IThemeManager, IOverrideThemeManager
{
	protected override IThemeable OwnerOfInheritedTheme => base.Parent.Presentation.MasterNotesSlideManager.MasterNotesSlide;

	internal NotesSlideThemeManager(NotesSlide parent)
		: base(parent)
	{
	}
}
