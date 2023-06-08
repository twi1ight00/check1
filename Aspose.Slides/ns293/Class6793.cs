using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using ns233;
using ns234;
using ns235;
using ns236;
using ns292;
using ns318;

namespace ns293;

internal static class Class6793
{
	internal static byte[] smethod_0(Class6216 page, Enum923 imageType)
	{
		return imageType switch
		{
			Enum923.const_0 => smethod_4(page, Enum788.const_4), 
			Enum923.const_1 => smethod_4(page, Enum788.const_5), 
			Enum923.const_2 => smethod_4(page, Enum788.const_6), 
			Enum923.const_3 => smethod_4(page, Enum788.const_8), 
			Enum923.const_4 => smethod_2(page), 
			_ => throw new InvalidOperationException("Unsupported image format"), 
		};
	}

	internal static Enum922 smethod_1(Enum923 imageType)
	{
		return imageType switch
		{
			Enum923.const_0 => Enum922.const_0, 
			Enum923.const_1 => Enum922.const_1, 
			Enum923.const_2 => Enum922.const_2, 
			Enum923.const_3 => Enum922.const_4, 
			Enum923.const_4 => Enum922.const_5, 
			_ => throw new InvalidOperationException("Unsupported image format"), 
		};
	}

	internal static byte[] smethod_2(Class6216 page)
	{
		string svgContent = Class7190.smethod_1(ref page, normalizeAps: false);
		return smethod_3(svgContent);
	}

	internal static byte[] smethod_3(string svgContent)
	{
		Regex regex = new Regex("<!DOCTYPE[\\s\\S]+dtd[\\S\\S]+>");
		svgContent = regex.Replace(svgContent, string.Empty);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(svgContent);
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
		xmlNamespaceManager.AddNamespace("ns", "http://www.w3.org/2000/svg");
		svgContent = xmlDocument.SelectSingleNode("ns:svg", xmlNamespaceManager).OuterXml;
		return Encoding.UTF8.GetBytes(svgContent);
	}

	private static byte[] smethod_4(Class6216 page, Enum788 imageType)
	{
		using Class6150 @class = new Class6150(page.WidthPixels, page.HeightPixels);
		using Class6160 class2 = new Class6160(@class);
		class2.method_2();
		class2.method_1();
		Class6190 class3 = new Class6190();
		class3.method_0(page, class2.method_6());
		MemoryStream memoryStream = new MemoryStream();
		@class.Save(memoryStream, imageType);
		byte[] result = memoryStream.ToArray();
		memoryStream.Close();
		return result;
	}
}
