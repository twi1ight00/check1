using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class1024 : Class1023
{
	internal void method_2(IColorFormat color, Class1814 colorElementData, string tagName)
	{
		method_0();
		base.XmlPartWriter.WriteStartElement("a", "root", "http://schemas.openxmlformats.org/drawingml/2006/main");
		Class930.smethod_3(color, colorElementData);
		colorElementData.vmethod_4("a", base.XmlPartWriter, tagName);
		base.XmlPartWriter.WriteEndElement();
		method_1();
	}
}
