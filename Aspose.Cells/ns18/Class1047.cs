using System.Collections;
using System.Collections.Generic;
using ns1;

namespace ns18;

internal class Class1047
{
	private Class1047()
	{
	}

	public static void Write(Class1050 class1050_0, bool bool_0)
	{
		Class1016 @class = new Class1016();
		Class1016 class2 = new Class1016();
		foreach (Class1051 item in (IEnumerable)class1050_0.method_0())
		{
			string contentType;
			if ((contentType = item.ContentType) != null)
			{
				if (Class1742.dictionary_33 == null)
				{
					Class1742.dictionary_33 = new Dictionary<string, int>(8)
					{
						{ "application/vnd.openxmlformats-package.relationships+xml", 0 },
						{ "image/bmp", 1 },
						{ "image/x-emf", 2 },
						{ "image/gif", 3 },
						{ "image/jpeg", 4 },
						{ "image/x-pcz", 5 },
						{ "image/png", 6 },
						{ "image/x-wmf", 7 }
					};
				}
				if (Class1742.dictionary_33.TryGetValue(contentType, out var value))
				{
					switch (value)
					{
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
						if (!@class.Contains(item.method_0()))
						{
							@class.Add(item.method_0(), item.ContentType);
						}
						continue;
					case 0:
						continue;
					}
				}
			}
			class2.Add(item.Name, item.ContentType);
		}
		Class1051 class4 = new Class1051("/[Content_Types].xml", "");
		Class1009 class5 = new Class1009(class4.method_1(), bool_0);
		class5.method_1("Types");
		class5.method_9("xmlns", "http://schemas.openxmlformats.org/package/2006/content-types");
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
		class5.method_2();
		class1050_0.method_0().Add(class4);
	}

	private static void smethod_0(string string_0, string string_1, Class1009 class1009_0)
	{
		class1009_0.method_3("Default");
		class1009_0.method_9("Extension", string_0);
		class1009_0.method_9("ContentType", string_1);
		class1009_0.method_4();
	}

	private static void smethod_1(string string_0, string string_1, Class1009 class1009_0)
	{
		class1009_0.method_3("Override");
		class1009_0.method_9("PartName", string_0);
		class1009_0.method_9("ContentType", string_1);
		class1009_0.method_4();
	}
}
