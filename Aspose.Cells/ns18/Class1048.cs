using System;
using ns22;

namespace ns18;

internal class Class1048
{
	private Class1048()
	{
	}

	public static void Write(Class1009 class1009_0, string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, string string_7)
	{
		class1009_0.method_1("cp:coreProperties");
		class1009_0.method_9("xmlns:cp", "http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		class1009_0.method_9("xmlns:dc", "http://purl.org/dc/elements/1.1/");
		class1009_0.method_9("xmlns:dcterms", "http://purl.org/dc/terms/");
		class1009_0.method_9("xmlns:dcmitype", "http://purl.org/dc/dcmitype/");
		class1009_0.method_9("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
		class1009_0.method_6("dc:title", string_0);
		class1009_0.method_6("dc:subject", string_1);
		class1009_0.method_6("dc:creator", string_2);
		class1009_0.method_6("cp:keywords", string_3);
		class1009_0.method_6("dc:description", string_4);
		class1009_0.method_6("cp:lastModifiedBy", string_5);
		class1009_0.method_5("cp:revision", string_6);
		class1009_0.method_7("cp:lastPrinted", dateTime_0);
		smethod_0(class1009_0, "created", dateTime_1);
		smethod_0(class1009_0, "modified", dateTime_2);
		class1009_0.method_6("cp:category", string_7);
		class1009_0.method_2();
	}

	private static void smethod_0(Class1009 class1009_0, string string_0, DateTime dateTime_0)
	{
		if (dateTime_0.Year > 1)
		{
			class1009_0.method_3("dcterms:" + string_0);
			class1009_0.method_9("xsi:type", "dcterms:W3CDTF");
			class1009_0.method_8(Class1025.smethod_0(dateTime_0));
			class1009_0.method_4();
		}
	}
}
