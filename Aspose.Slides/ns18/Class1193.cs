using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Theme;
using ns16;
using ns24;
using ns53;
using ns55;
using ns56;

namespace ns18;

internal class Class1193 : Class1190
{
	internal void method_7(INotesSlide notesSlide)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "notes")
			{
				Class2197 @class = new Class2197(base.XmlPartReader);
				Class899.smethod_0(notesSlide, @class.CSld, base.SlideDeserializationContext);
				Class931.smethod_2(notesSlide.ThemeManager, @class.ClrMapOvr);
				method_8();
				Class900.smethod_0(notesSlide.ThemeManager, base.DeserializationContext);
				method_9(notesSlide, @class);
			}
		}
		method_2();
	}

	private void method_8()
	{
		Class1347[] array = base.DeserializationContext.RelationshipsOfCurrentPartEntry.method_0(Class1245.class1338_0);
		if (array != null && array.Length > 0)
		{
			_ = array[0].TargetPart;
		}
	}

	private void method_9(INotesSlide notesSlide, Class2197 notesElementData)
	{
		Class301 pPTXUnsupportedProps = ((NotesSlide)notesSlide).PPTXUnsupportedProps;
		pPTXUnsupportedProps.ExtensionList = notesElementData.ExtLst;
		pPTXUnsupportedProps.ShowMasterShapes = notesElementData.ShowMasterSp;
		pPTXUnsupportedProps.ShowMasterPlaceholderAnimations = notesElementData.ShowMasterPhAnim;
	}

	internal void method_10(INotesSlide notesSlide)
	{
		method_3();
		Class2197 @class = new Class2197();
		base.SerializationContext.SlideToSlidePart.Add(notesSlide, base.Part);
		Class899.smethod_2(notesSlide, @class.CSld, base.SlideSerializationContext);
		Class931.smethod_7(((BaseThemeManager)notesSlide.ThemeManager).ColorMappingOverride, @class.delegate1327_0());
		method_11(notesSlide, @class);
		@class.vmethod_4(null, base.XmlPartWriter, "notes");
		method_4();
	}

	private void method_11(INotesSlide notesSlide, Class2197 notesElementData)
	{
		Class301 pPTXUnsupportedProps = ((NotesSlide)notesSlide).PPTXUnsupportedProps;
		notesElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		notesElementData.ShowMasterSp = pPTXUnsupportedProps.ShowMasterShapes;
		notesElementData.ShowMasterPhAnim = pPTXUnsupportedProps.ShowMasterPlaceholderAnimations;
	}

	public Class1193(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1193(Class1342 part, Class1346 serializationContext, IBaseSlide slide)
		: base(part, serializationContext, slide)
	{
	}
}
