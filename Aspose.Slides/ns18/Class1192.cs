using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns56;

namespace ns18;

internal class Class1192 : Class1190
{
	internal void method_7(IMasterNotesSlide masterNotesSlide)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "notesMaster")
			{
				Class2196 @class = new Class2196(base.XmlPartReader);
				Class899.smethod_0(masterNotesSlide, @class.CSld, base.SlideDeserializationContext);
				Class931.smethod_1(masterNotesSlide.ThemeManager, @class.ClrMap);
				method_8(masterNotesSlide, @class);
				method_5(masterNotesSlide.ThemeManager);
			}
		}
		method_2();
	}

	private void method_8(IMasterNotesSlide masterNotesSlide, Class2196 notesMasterElementData)
	{
		Class299 pPTXUnsupportedProps = ((MasterNotesSlide)masterNotesSlide).PPTXUnsupportedProps;
		pPTXUnsupportedProps.HeaderFooter = notesMasterElementData.Hf;
		pPTXUnsupportedProps.NotesStyle = notesMasterElementData.NotesStyle;
		pPTXUnsupportedProps.ExtensionList = notesMasterElementData.ExtLst;
	}

	internal void method_9(IMasterNotesSlide masterNotesSlide)
	{
		method_3();
		Class2196 @class = new Class2196();
		base.SerializationContext.SlideToSlidePart.Add(masterNotesSlide, base.Part);
		Class899.smethod_2(masterNotesSlide, @class.CSld, base.SlideSerializationContext);
		Class931.smethod_5(masterNotesSlide.ThemeManager, @class.ClrMap);
		method_10(masterNotesSlide, @class);
		@class.vmethod_4(null, base.XmlPartWriter, "notesMaster");
		method_4();
	}

	private void method_10(IMasterNotesSlide masterNotesSlide, Class2196 notesMasterElementData)
	{
		Class299 pPTXUnsupportedProps = ((MasterNotesSlide)masterNotesSlide).PPTXUnsupportedProps;
		notesMasterElementData.delegate2460_0(pPTXUnsupportedProps.HeaderFooter);
		notesMasterElementData.delegate1743_0(pPTXUnsupportedProps.NotesStyle);
		notesMasterElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	public Class1192(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1192(Class1342 part, Class1346 serializationContext, IBaseSlide slide)
		: base(part, serializationContext, slide)
	{
	}
}
