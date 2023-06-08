using System.Xml;
using Aspose.Slides.Charts;
using ns16;
using ns18;
using ns25;
using ns56;

namespace ns17;

internal class Class915
{
	internal static void smethod_0(IChartWall wall, Class2123 surfaceElementData, Class1341 deserializationContext)
	{
		if (surfaceElementData == null)
		{
			return;
		}
		Class320 pPTXUnsupportedProps = ((ChartWall)wall).PPTXUnsupportedProps;
		if (surfaceElementData.Thickness != null)
		{
			wall.Thickness = (int)surfaceElementData.Thickness.Val;
		}
		if (surfaceElementData.PictureOptions != null)
		{
			pPTXUnsupportedProps.PictureOptions = surfaceElementData.PictureOptions;
			string namespaceURI = "http://schemas.openxmlformats.org/drawingml/2006/chart";
			XmlElement xmlElement = (XmlElement)Class1029.smethod_11(surfaceElementData.PictureOptions.XmlDocument.DocumentElement, "pictureFormat", namespaceURI);
			if (xmlElement != null)
			{
				string attribute = xmlElement.GetAttribute("val");
				if (attribute != null && attribute != "")
				{
					wall.PictureType = (PictureType)Class2543.class1151_0[attribute];
				}
			}
		}
		Class921.smethod_0(wall.Format, surfaceElementData.SpPr, deserializationContext);
		pPTXUnsupportedProps.ExtensionList = surfaceElementData.ExtLst;
	}

	internal static void smethod_1(IChartWall wall, Class2123.Delegate2099 addSurface, Class1346 serializationContext)
	{
		if (!smethod_2(wall))
		{
			return;
		}
		Class2123 @class = addSurface();
		Class320 pPTXUnsupportedProps = ((ChartWall)wall).PPTXUnsupportedProps;
		@class.delegate2136_0().Val = (uint)wall.Thickness;
		@class.delegate384_0(pPTXUnsupportedProps.PictureOptions);
		if (wall.PictureType != PictureType.NotDefined)
		{
			string namespaceURI = "http://schemas.openxmlformats.org/drawingml/2006/chart";
			if (@class.PictureOptions == null)
			{
				@class.delegate383_0();
				@class.PictureOptions.XmlDocument = new XmlDocument();
				@class.PictureOptions.XmlDocument.AppendChild(@class.PictureOptions.XmlDocument.CreateElement("c", "pictureOptions", namespaceURI));
			}
			XmlElement xmlElement = (XmlElement)Class1029.smethod_11(@class.PictureOptions.XmlDocument.DocumentElement, "pictureFormat", namespaceURI);
			if (xmlElement == null)
			{
				xmlElement = @class.PictureOptions.XmlDocument.CreateElement("c", "pictureFormat", namespaceURI);
				@class.PictureOptions.XmlDocument.DocumentElement.AppendChild(xmlElement);
			}
			xmlElement.SetAttribute("val", Class2543.smethod_1(wall.PictureType));
		}
		Class921.smethod_1(wall.Format, @class.delegate1630_0, serializationContext);
		@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	internal static bool smethod_2(IChartWall wall)
	{
		if (wall.Thickness <= 0 && !Class921.smethod_2(wall.Format))
		{
			return wall.PictureType != PictureType.NotDefined;
		}
		return true;
	}
}
