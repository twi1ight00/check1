using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns56;

namespace ns18;

internal class Class1191 : Class1190
{
	internal void method_7(IMasterHandoutSlide masterHandoutSlide)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "handoutMaster")
			{
				Class2194 @class = new Class2194(base.XmlPartReader);
				Class899.smethod_0(masterHandoutSlide, @class.CSld, base.SlideDeserializationContext);
				Class931.smethod_1(masterHandoutSlide.ThemeManager, @class.ClrMap);
				method_8(masterHandoutSlide, @class);
				method_5(masterHandoutSlide.ThemeManager);
			}
		}
		method_2();
	}

	private void method_8(IMasterHandoutSlide masterHandoutSlide, Class2194 handoutMasterElementData)
	{
		Class298 pPTXUnsupportedProps = ((MasterHandoutSlide)masterHandoutSlide).PPTXUnsupportedProps;
		pPTXUnsupportedProps.HeaderFooter = handoutMasterElementData.Hf;
		pPTXUnsupportedProps.ExtensionList = handoutMasterElementData.ExtLst;
	}

	internal void method_9(IMasterHandoutSlide masterHandoutSlide)
	{
		method_3();
		Class2194 @class = new Class2194();
		base.SerializationContext.SlideToSlidePart.Add(masterHandoutSlide, base.Part);
		Class899.smethod_2(masterHandoutSlide, @class.CSld, base.SlideSerializationContext);
		Class931.smethod_5(masterHandoutSlide.ThemeManager, @class.ClrMap);
		method_10(masterHandoutSlide, @class);
		@class.vmethod_4(null, base.XmlPartWriter, "handoutMaster");
		method_4();
	}

	private void method_10(IMasterHandoutSlide masterHandoutSlide, Class2194 handoutMasterElementData)
	{
		Class298 pPTXUnsupportedProps = ((MasterHandoutSlide)masterHandoutSlide).PPTXUnsupportedProps;
		handoutMasterElementData.delegate2460_0(pPTXUnsupportedProps.HeaderFooter);
		handoutMasterElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	public Class1191(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1191(Class1342 part, Class1346 serializationContext, IBaseSlide slide)
		: base(part, serializationContext, slide)
	{
	}
}
