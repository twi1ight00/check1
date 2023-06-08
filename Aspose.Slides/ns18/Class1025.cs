using Aspose.Slides;
using ns16;
using ns56;

namespace ns18;

internal class Class1025 : Class1023
{
	internal void method_2(IShape shape, IPictureFillFormat pictureFormat, Class2006 picElementData, string tagName, Class1346 serializationContext)
	{
		method_0();
		base.XmlPartWriter.WriteStartElement("p", "root", "http://schemas.openxmlformats.org/presentationml/2006/main");
		base.XmlPartWriter.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		base.XmlPartWriter.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		Class983.smethod_5(shape, picElementData.SpPr, serializationContext);
		Class1908 @class = (Class1908)picElementData.SpPr.delegate2773_2("prstGeom").Object;
		@class.Prst = ShapeType.Rectangle;
		Class974.smethod_1(pictureFormat, picElementData.BlipFill, serializationContext);
		picElementData.vmethod_4("p", base.XmlPartWriter, tagName);
		base.XmlPartWriter.WriteEndElement();
		method_1();
	}
}
