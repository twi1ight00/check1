using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using ns218;

namespace ns247;

internal class Class6255 : Class6254
{
	public Class6255()
	{
	}

	public Class6255(string filename)
	{
		using Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
		method_7(stream);
	}

	public Class6255(Stream stream)
	{
		method_7(stream);
	}

	private void method_7(Stream stream)
	{
		method_8(stream);
		method_0();
	}

	private void method_8(Stream stream)
	{
		Class5944 @class = new Class5944(stream);
		while (@class.method_0("package"))
		{
			if (@class.LocalName != "part")
			{
				@class.method_2();
				continue;
			}
			Class6260 part = smethod_4(@class);
			base.Parts.Add(part);
		}
	}

	private static Class6260 smethod_4(Class5944 flatOpcReader)
	{
		string partName = flatOpcReader.method_4("name", string.Empty);
		string contentType = flatOpcReader.method_4("contentType", string.Empty);
		flatOpcReader.method_4("compression", "store");
		Class6260 @class = new Class6260(partName, contentType);
		flatOpcReader.method_0("part");
		switch (flatOpcReader.LocalName)
		{
		case "binaryData":
		{
			string s = flatOpcReader.method_11();
			byte[] array = Convert.FromBase64String(s);
			@class.Stream.Write(array, 0, array.Length);
			break;
		}
		case "xmlData":
		{
			StreamWriter streamWriter = new StreamWriter(@class.Stream);
			flatOpcReader.method_0("xmlData");
			streamWriter.Write(flatOpcReader.method_14());
			streamWriter.Flush();
			break;
		}
		}
		@class.Stream.Position = 0L;
		return @class;
	}

	public override void Save(Stream stream)
	{
		Class5946 @class = new Class5946(stream, isPrettyFormat: true);
		@class.XmlWriter.WriteStartDocument(standalone: true);
		@class.XmlWriter.WriteProcessingInstruction("mso-application", "progid=\"Word.Document\"");
		@class.method_2("pkg:package");
		@class.method_14("xmlns:pkg", "http://schemas.microsoft.com/office/2006/xmlPackage");
		foreach (Class6260 item in (IEnumerable)base.Parts)
		{
			item.Stream.Position = 0L;
			@class.method_2("pkg:part");
			@class.method_14("pkg:name", item.Name);
			@class.method_14("pkg:contentType", item.ContentType);
			if (!item.ContentType.EndsWith("xml"))
			{
				@class.method_14("pkg:compression", "store");
				@class.method_2("pkg:binaryData");
				@class.method_15(item.Stream);
				@class.method_3();
			}
			else
			{
				StreamReader streamReader = new StreamReader(item.Stream);
				string input = streamReader.ReadToEnd();
				Regex regex = new Regex("<\\?.*\\?>");
				input = regex.Replace(input, string.Empty);
				@class.method_2("pkg:xmlData");
				@class.method_7(input);
				@class.method_3();
			}
			@class.method_3();
		}
		@class.method_1();
	}
}
