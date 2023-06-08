using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using ns276;
using ns33;
using ns53;

namespace ns55;

internal abstract class Class1224 : Class1223
{
	private const string string_0 = "Aspose.PptxPackage.resources";

	private static Class1343 class1343_0;

	private static SortedDictionary<string, byte[]> sortedDictionary_0;

	public abstract XmlSchemaCollection SchemaCollection { get; }

	public abstract string[] SchemaCollectionNames { get; }

	public virtual bool NoIndentation => false;

	public virtual SortedList<string, string> ImplicitNamespaces => null;

	static Class1224()
	{
		sortedDictionary_0 = new SortedDictionary<string, byte[]>();
		using (Stream zipStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.PptxPackage.resources.schemas.zip"))
		{
			using Class6752 @class = Class6752.Read(zipStream);
			IEnumerator enumerator = @class.method_75();
			while (enumerator.MoveNext())
			{
				Class6751 class2 = (Class6751)enumerator.Current;
				if (class2.IsDirectory)
				{
					continue;
				}
				using Stream stream = class2.method_19();
				byte[] array = new byte[class2.UncompressedSize];
				int num;
				for (int i = 0; i < array.Length; i += num)
				{
					num = stream.Read(array, i, array.Length - i);
					if (num == 0)
					{
						break;
					}
				}
				if (class2.FileName.StartsWith("http"))
				{
					sortedDictionary_0.Add("http://" + class2.FileName.Substring(5), array);
				}
				else
				{
					sortedDictionary_0.Add("http://zip/" + class2.FileName, array);
				}
			}
		}
		class1343_0 = new Class1343(sortedDictionary_0);
	}

	protected static XmlSchemaCollection smethod_1(string[] schemaCollectionNames)
	{
		XmlSchemaCollection result = null;
		if (schemaCollectionNames != null)
		{
			if (schemaCollectionNames.Length == 1 && schemaCollectionNames[0] != null && schemaCollectionNames[0].Length > 0)
			{
				result = smethod_2(schemaCollectionNames);
			}
			else if (schemaCollectionNames.Length > 1)
			{
				result = smethod_2(schemaCollectionNames);
			}
		}
		return result;
	}

	private static XmlSchemaCollection smethod_2(string[] schemaNames)
	{
		XmlSchemaCollection xmlSchemaCollection = new XmlSchemaCollection();
		try
		{
			foreach (string text in schemaNames)
			{
				string text2 = text;
				if (text2.IndexOf(':') < 0)
				{
					text2 = "http://zip/" + text2;
				}
				byte[] buffer = sortedDictionary_0[text2];
				ValidationEventHandler validationEventHandler = Class1181.smethod_1;
				XmlSchema schema = XmlSchema.Read(new XmlTextReader(text2, new MemoryStream(buffer, writable: false)), validationEventHandler);
				xmlSchemaCollection.Add(schema, class1343_0);
			}
			return xmlSchemaCollection;
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			return null;
		}
	}
}
