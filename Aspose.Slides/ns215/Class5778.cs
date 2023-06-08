using System.Collections;
using System.Drawing;
using System.IO;
using System.Xml;
using ns322;

namespace ns215;

internal class Class5778
{
	public static ArrayList smethod_0(Stream template, Stream dataset, SizeF pageSize)
	{
		Class5933 @class = new Class5933();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(template);
		xmlDocument.Normalize();
		XmlDocument xmlDocument2 = new XmlDocument();
		xmlDocument2.Load(dataset);
		xmlDocument2.Normalize();
		Class7685 javaScriptEngine = Class5933.smethod_0();
		Class5910 layoutsModel = @class.method_2(xmlDocument, xmlDocument2, pageSize, javaScriptEngine);
		Class5912 class2 = new Class5912();
		@class.method_3(class2, layoutsModel, javaScriptEngine);
		return class2.Pages;
	}
}
