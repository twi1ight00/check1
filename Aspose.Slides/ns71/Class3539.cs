using System;
using System.IO;
using System.Text;
using ns45;

namespace ns71;

internal class Class3539
{
	private readonly int int_0;

	private Class3536 class3536_0;

	internal Class3536 ProjectInformation => class3536_0;

	internal Class3539(int codePage, string projectName)
	{
		int_0 = codePage;
		class3536_0 = new Class3536();
		class3536_0.method_2(projectName);
	}

	internal Class3539(Class1106 stream, int codePage)
	{
		if (stream == null)
		{
			throw new ArgumentNullException();
		}
		int_0 = codePage;
		class3536_0 = new Class3536();
		string s = Class3524.smethod_1(stream.method_8(), codePage);
		using StringReader reader = new StringReader(s);
		class3536_0.method_0(reader);
	}

	internal void method_0(Class1106 stream)
	{
		using StringWriter stringWriter = new StringWriter();
		class3536_0.method_1(stringWriter);
		string s = stringWriter.ToString();
		Encoding encoding = Encoding.GetEncoding(int_0);
		byte[] bytes = encoding.GetBytes(s);
		if (!stream.method_1(bytes))
		{
			throw new Exception9("Could not write project properties");
		}
	}
}
