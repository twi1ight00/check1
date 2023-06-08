using System;
using System.IO;
using System.Text;
using System.Xml;
using ns16;

namespace ns22;

internal class Class1029
{
	private Class1029()
	{
	}

	public static XmlTextWriter smethod_0(Stream stream_0, Encoding encoding_0)
	{
		StreamWriter streamWriter = new StreamWriter(stream_0, encoding_0);
		streamWriter.NewLine = "\r\n";
		return new XmlTextWriter(streamWriter);
	}

	internal static XmlTextReader smethod_1(Stream stream_0)
	{
		return new XmlTextReader(stream_0);
	}

	internal static XmlTextReader smethod_2(StringReader stringReader_0)
	{
		return new XmlTextReader(stringReader_0);
	}

	internal static XmlTextReader smethod_3(string string_0, XmlNodeType xmlNodeType_0, XmlParserContext xmlParserContext_0)
	{
		return new XmlTextReader(string_0, xmlNodeType_0, xmlParserContext_0);
	}

	internal static XmlTextReader smethod_4(Class746 class746_0, string string_0)
	{
		Class744 @class = class746_0.method_38(string_0);
		if (@class == null)
		{
			return null;
		}
		Stream input = class746_0.method_39(@class);
		return new XmlTextReader(input);
	}

	internal static XmlTextWriter smethod_5(string string_0, Stream6 stream6_0)
	{
		Class744 @class = stream6_0.method_18(string_0);
		@class.method_5(DateTime.Now);
		return new XmlTextWriter(stream6_0, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
	}
}
