using Aspose.Slides;
using ns22;
using ns63;

namespace ns15;

internal class Class206
{
	internal static MasterNotesSlide smethod_0(Class2720 notesContainer, Class857 deserializationContext)
	{
		return null;
	}

	internal static void smethod_1(MasterNotesSlide masterNotesSlide, Class2720 notesContainer)
	{
		Class265 pPTUnsupportedProps = masterNotesSlide.PPTUnsupportedProps;
		pPTUnsupportedProps.NotesContainer_RoundTripThemeAtom = notesContainer.RoundTripThemeAtom;
		pPTUnsupportedProps.NotesContainer_RoundTripColorMappingAtom = notesContainer.RoundTripColorMappingAtom;
		pPTUnsupportedProps.NotesContainer_RoundTripNotesMasterTextStyles12Atom = notesContainer.RoundTripNotesMasterTextStyles12Atom;
	}
}
