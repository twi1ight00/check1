using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using ns218;
using ns234;

namespace ns247;

internal class Class6256 : Class6254
{
	public Class6256()
	{
	}

	public Class6256(string filename)
	{
		using Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
		method_7(stream);
	}

	public Class6256(Stream stream)
	{
		method_7(stream);
	}

	public override void Save(Stream stream)
	{
		Class6172 @class = new Class6172(stream);
		foreach (Class6260 item in (IEnumerable)base.Parts)
		{
			item.Stream.Position = 0L;
			@class.method_0(smethod_6(item.Name), item.Stream);
		}
		@class.method_2();
	}

	private void method_7(Stream stream)
	{
		method_8(stream);
		Hashtable contentTypes = method_10();
		method_11(contentTypes);
		method_0();
	}

	private void method_8(Stream stream)
	{
		Class6170 @class = new Class6170(stream);
		while (@class.method_0())
		{
			Class6260 class2 = new Class6260(smethod_7(@class.EntryFileName), string.Empty);
			base.Parts.Add(class2);
			@class.method_2(class2.Stream);
			class2.Stream.Position = 0L;
		}
	}

	public Stream method_9(string partName)
	{
		if (base.Parts.Contains(partName))
		{
			return method_2(partName).Stream;
		}
		string pattern = string.Format(".*{0}/\\[(?<num>\\d+)\\]", partName.Replace(".", "\\.").Replace("[", "\\[").Replace("]", "\\]"));
		SortedList sortedList = new SortedList();
		foreach (Class6260 item in (IEnumerable)base.Parts)
		{
			Match match = Regex.Match(item.Name, pattern, RegexOptions.IgnoreCase);
			if (match.Success)
			{
				sortedList.Add(int.Parse(match.Groups["num"].Captures[0].Value), item.Stream);
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		if (sortedList.Values.Count == 0)
		{
			int i;
			for (i = 0; i < partName.Length; i++)
			{
				switch (partName[i])
				{
				case '.':
				case '/':
				case '\\':
					continue;
				}
				break;
			}
			string text = ((i <= 0 || i >= partName.Length - 1) ? partName : partName.Substring(i));
			text = text.Replace('\\', '/');
			if (!string.IsNullOrEmpty(text))
			{
				foreach (Class6260 item2 in (IEnumerable)base.Parts)
				{
					if (item2.Name.EndsWith(text, StringComparison.InvariantCultureIgnoreCase))
					{
						Class5964.smethod_9(item2.Stream, memoryStream);
						break;
					}
				}
			}
		}
		else
		{
			foreach (Stream value in sortedList.Values)
			{
				Class5964.smethod_9(value, memoryStream);
			}
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}

	private Hashtable method_10()
	{
		Hashtable hashtable = new Hashtable();
		Stream stream = method_9("/[Content_Types].xml");
		Class5944 @class = new Class5944(stream);
		while (@class.method_0("Types"))
		{
			switch (@class.LocalName)
			{
			case "Override":
				smethod_5(@class, hashtable);
				break;
			case "Default":
				smethod_4(@class, hashtable);
				break;
			default:
				@class.method_2();
				break;
			}
		}
		return hashtable;
	}

	private static void smethod_4(Class5944 partReader, Hashtable contentTypes)
	{
		string value = null;
		string text = null;
		while (partReader.method_10())
		{
			switch (partReader.LocalName)
			{
			case "ContentType":
				value = partReader.Value;
				break;
			case "Extension":
				text = partReader.Value;
				break;
			}
		}
		if (Class5964.smethod_20(value) && Class5964.smethod_20(text))
		{
			contentTypes[text] = value;
		}
	}

	private static void smethod_5(Class5944 partReader, Hashtable contentTypes)
	{
		string value = null;
		string text = null;
		while (partReader.method_10())
		{
			switch (partReader.LocalName)
			{
			case "ContentType":
				value = partReader.Value;
				break;
			case "PartName":
				text = partReader.Value;
				break;
			}
		}
		if (Class5964.smethod_20(value) && Class5964.smethod_20(text))
		{
			contentTypes[text] = value;
		}
	}

	private void method_11(Hashtable contentTypes)
	{
		foreach (Class6260 item in (IEnumerable)base.Parts)
		{
			string text = (string)contentTypes[item.Name];
			if (!Class5964.smethod_20(text))
			{
				text = (string)contentTypes[item.Extension];
			}
			item.ContentType = text;
		}
	}

	private static string smethod_6(string partName)
	{
		return partName.TrimStart('/');
	}

	private static string smethod_7(string zipName)
	{
		return "/" + zipName.Replace("\\", "/");
	}
}
