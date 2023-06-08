using System;
using Aspose.Slides;
using ns22;
using ns62;
using ns63;

namespace ns15;

internal class Class1059
{
	internal static NotesSlide smethod_0(Slide slide, Class2720 notesContainer, Class854 slideDeserializationContext)
	{
		NotesSlide notesSlide = new NotesSlide(slide);
		foreach (Shape shape in notesSlide.Shapes)
		{
			if (shape.Placeholder == null || shape.Placeholder.Type != PlaceholderType.Body)
			{
				continue;
			}
			AutoShape autoShape = (AutoShape)shape;
			Class2884 notesAtom = notesContainer.NotesAtom;
			if (notesAtom == null)
			{
				throw new PptException("Notes_PPT loading error. NotesAtom record not found.");
			}
			Class2714 drawing = notesContainer.Drawing;
			if (drawing == null)
			{
				throw new NullReferenceException("Notes_PPT creating error. Drawing record not found.");
			}
			Class2671 groupShape = drawing.OfficeArtDg.GroupShape;
			if (groupShape == null)
			{
				break;
			}
			for (int i = 0; i < groupShape.Records.Count; i++)
			{
				if (groupShape.Records[i] is Class2670 @class)
				{
					Class2642 clientTextBox = @class.ClientTextBox;
					if (clientTextBox != null && clientTextBox.Header.IsContainer && clientTextBox.TextType == Enum449.const_2)
					{
						autoShape.TextFrameInternal = Class1066.smethod_1(autoShape, @class, slideDeserializationContext);
						break;
					}
				}
			}
			break;
		}
		smethod_1(notesSlide.PPTUnsupportedProps, notesContainer);
		return notesSlide;
	}

	internal static void smethod_1(Class265 unsupportedProps, Class2720 notes)
	{
		unsupportedProps.NotesContainer_RoundTripThemeAtom = notes.RoundTripThemeAtom;
		unsupportedProps.NotesContainer_RoundTripColorMappingAtom = notes.RoundTripColorMappingAtom;
		unsupportedProps.NotesContainer_RoundTripNotesMasterTextStyles12Atom = notes.RoundTripNotesMasterTextStyles12Atom;
	}
}
