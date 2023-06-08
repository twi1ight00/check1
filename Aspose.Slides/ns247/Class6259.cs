using System;
using ns218;
using ns234;

namespace ns247;

internal static class Class6259
{
	public static void Write(Class5946 builder, string title, string subject, string creator, string keywords, string description, string lastModifiedBy, string revision, DateTime lastPrinted, DateTime created, DateTime modified, string category)
	{
		builder.method_0("cp:coreProperties");
		builder.method_14("xmlns:cp", "http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		builder.method_14("xmlns:dc", "http://purl.org/dc/elements/1.1/");
		builder.method_14("xmlns:dcterms", "http://purl.org/dc/terms/");
		builder.method_14("xmlns:dcmitype", "http://purl.org/dc/dcmitype/");
		builder.method_14("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
		builder.method_10("dc:title", title);
		builder.method_10("dc:subject", subject);
		builder.method_10("dc:creator", creator);
		builder.method_10("cp:keywords", keywords);
		builder.method_10("dc:description", description);
		builder.method_10("cp:lastModifiedBy", lastModifiedBy);
		builder.method_9("cp:revision", revision);
		builder.method_11("cp:lastPrinted", lastPrinted);
		smethod_0(builder, "created", created);
		smethod_0(builder, "modified", modified);
		builder.method_10("cp:category", category);
		builder.method_1();
	}

	private static void smethod_0(Class5946 builder, string name, DateTime value)
	{
		if (value.Year > 1)
		{
			builder.method_2("dcterms:" + name);
			builder.method_14("xsi:type", "dcterms:W3CDTF");
			builder.method_13(Class6159.smethod_0(value));
			builder.method_3();
		}
	}
}
