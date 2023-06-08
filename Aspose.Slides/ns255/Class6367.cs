using System.Collections;
using System.IO;
using ns221;
using ns234;

namespace ns255;

internal class Class6367 : Interface285
{
	private static readonly object object_0 = new object();

	private static Hashtable hashtable_0;

	private static Hashtable PresetXmls
	{
		get
		{
			if (hashtable_0 == null)
			{
				lock (object_0)
				{
					if (hashtable_0 == null)
					{
						hashtable_0 = smethod_0();
					}
				}
			}
			return hashtable_0;
		}
	}

	[Attribute1]
	public string imethod_0(string presetName)
	{
		return (string)PresetXmls[presetName];
	}

	private static Hashtable smethod_0()
	{
		using Stream stream = Class6166.smethod_0("Aspose.Resources.PresetShapeDefinitions.xml");
		using StreamReader streamReader = new StreamReader(stream);
		Hashtable hashtable = new Hashtable(190);
		smethod_2(streamReader);
		string text;
		while ((text = streamReader.ReadLine()) != null && !text.StartsWith("</presetShapeDefinitons>"))
		{
			string key = smethod_1(text);
			hashtable.Add(key, text);
		}
		return hashtable;
	}

	private static string smethod_1(string line)
	{
		int num = line.IndexOf("<");
		int num2 = line.IndexOf(">");
		return line.Substring(num + 1, num2 - num - 1);
	}

	private static void smethod_2(StreamReader reader)
	{
		reader.ReadLine();
		reader.ReadLine();
	}
}
