using System.Collections.Generic;
using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns56;

namespace ns18;

internal class Class1211 : Class1188
{
	internal void method_5(IPresentation presentation)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType != XmlNodeType.Element || !(base.XmlPartReader.NamespaceURI == "http://schemas.openxmlformats.org/presentationml/2006/main") || !(base.XmlPartReader.LocalName == "viewPr"))
			{
				continue;
			}
			Class2321 @class = new Class2321(base.XmlPartReader);
			((Presentation)presentation).PPTXUnsupportedProps.ViewProps = new Class367();
			Class367 viewProps = ((Presentation)presentation).PPTXUnsupportedProps.ViewProps;
			if (@class.OutlineViewPr != null && @class.OutlineViewPr.SldLst != null && @class.OutlineViewPr.SldLst.SldList.Length > 0)
			{
				viewProps.OutlineViewPrSldLst = new Dictionary<IBaseSlide, bool>();
				Class2247[] sldList = @class.OutlineViewPr.SldLst.SldList;
				foreach (Class2247 class2 in sldList)
				{
					viewProps.OutlineViewPrSldLst.Add(base.DeserializationContext.SlidePartPathToSlide[base.DeserializationContext.RelationshipsOfCurrentPartEntry[class2.R_Id].TargetPart.PartPath], class2.Collapse);
				}
			}
			viewProps.ViewPropertiesElementData = @class;
		}
		method_2();
	}

	internal void method_6(IPresentation presentation)
	{
		method_3();
		Class367 viewProps = ((Presentation)presentation).PPTXUnsupportedProps.ViewProps;
		Class2321 viewPropertiesElementData = viewProps.ViewPropertiesElementData;
		if (viewPropertiesElementData.OutlineViewPr != null)
		{
			viewPropertiesElementData.OutlineViewPr.delegate2489_0(null);
			Dictionary<IBaseSlide, bool> outlineViewPrSldLst = viewProps.OutlineViewPrSldLst;
			if (outlineViewPrSldLst != null)
			{
				foreach (KeyValuePair<IBaseSlide, Class1342> item in base.SerializationContext.SlideToSlidePart)
				{
					if (outlineViewPrSldLst.ContainsKey(item.Key))
					{
						if (viewPropertiesElementData.OutlineViewPr.SldLst == null)
						{
							viewPropertiesElementData.OutlineViewPr.delegate2489_0(new Class2248());
						}
						Class2247 @class = viewPropertiesElementData.OutlineViewPr.SldLst.delegate2484_0();
						@class.R_Id = base.SerializationContext.RelationshipsOfCurrentPartEntry.method_4(item.Value).Id;
						@class.Collapse = outlineViewPrSldLst[item.Key];
					}
				}
			}
		}
		viewPropertiesElementData.vmethod_4(null, base.XmlPartWriter, "viewPr");
		method_4();
	}

	public Class1211(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1211(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
