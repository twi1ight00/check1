using System.IO;
using System.Text;
using ns218;
using ns221;

namespace ns238;

internal class Class6578 : Class6568
{
	public Class6578(Class6567 context)
		: base(context)
	{
	}

	public void method_0(Class5956 info)
	{
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_9(smethod_0(info));
		@class.method_1(Enum878.const_53);
	}

	private static string smethod_0(Class5956 info)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
		Class5946 @class = new Class5946(memoryStream, encoding, isPrettyFormat: false);
		@class.method_0("rdf:RDF");
		@class.method_14("xmlns:rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
		@class.method_2("rdf:Description");
		@class.method_14("rdf:about", string.Empty);
		@class.method_14("xmlns:dc", "http://purl.org/dc/elements/1.1");
		@class.method_9("dc:format", "application/x-shockwave-flash");
		@class.method_9("dc:title", info.Title);
		@class.method_9("dc:description", info.Description);
		@class.method_9("dc:publisher", info.GeneratorName);
		@class.method_9("dc:creator", info.Creator);
		@class.method_9("dc:date", info.CreationDate.ToShortDateString());
		@class.method_3();
		@class.method_1();
		return encoding.GetString(memoryStream.GetBuffer());
	}
}
