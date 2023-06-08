using System.Collections;
using ns218;

namespace ns247;

internal static class Class6258
{
	public static void Write(Class6256 opcPackage, bool isPrettyFormat)
	{
		Class5968 @class = new Class5968();
		Class5968 class2 = new Class5968();
		foreach (Class6260 item in (IEnumerable)opcPackage.Parts)
		{
			switch (item.ContentType)
			{
			case "image/bmp":
			case "image/x-emf":
			case "image/gif":
			case "image/jpeg":
			case "image/x-pcz":
			case "image/png":
			case "image/x-wmf":
			case "application/vnd.openxmlformats-officedocument.obfuscatedFont":
				@class[item.Extension] = item.ContentType;
				break;
			default:
				class2.Add(item.Name, item.ContentType);
				break;
			case "application/vnd.openxmlformats-package.relationships+xml":
				break;
			}
		}
		Class6260 class4 = new Class6260("/[Content_Types].xml", string.Empty);
		opcPackage.Parts.Add(class4);
		Class5946 class5 = new Class5946(class4.Stream, isPrettyFormat);
		class5.method_0("Types");
		class5.method_14("xmlns", "http://schemas.openxmlformats.org/package/2006/content-types");
		foreach (DictionaryEntry item2 in @class)
		{
			smethod_0((string)item2.Key, (string)item2.Value, class5);
		}
		smethod_0("rels", "application/vnd.openxmlformats-package.relationships+xml", class5);
		smethod_0("xml", "application/xml", class5);
		foreach (DictionaryEntry item3 in class2)
		{
			smethod_1((string)item3.Key, (string)item3.Value, class5);
		}
		class5.method_1();
	}

	private static void smethod_0(string extension, string contentType, Class5946 builder)
	{
		builder.method_2("Default");
		builder.method_14("Extension", extension);
		builder.method_14("ContentType", contentType);
		builder.method_3();
	}

	private static void smethod_1(string partName, string contentType, Class5946 builder)
	{
		builder.method_2("Override");
		builder.method_14("PartName", partName);
		builder.method_14("ContentType", contentType);
		builder.method_3();
	}
}
