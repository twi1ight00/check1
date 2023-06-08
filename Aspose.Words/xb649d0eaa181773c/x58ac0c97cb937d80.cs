using System.Collections;
using System.IO;
using Aspose;
using xf9a9481c3f63a419;

namespace xb649d0eaa181773c;

internal class x58ac0c97cb937d80 : x1a5567678eaa8bea
{
	private static readonly object xf0ead4d4930b8a2b = new object();

	private static volatile Hashtable xbae407f1236245b5;

	private static Hashtable x876ed1196310e342
	{
		get
		{
			if (xbae407f1236245b5 == null)
			{
				lock (xf0ead4d4930b8a2b)
				{
					if (xbae407f1236245b5 == null)
					{
						xbae407f1236245b5 = x783901b250eabee5();
					}
				}
			}
			return xbae407f1236245b5;
		}
	}

	[JavaConvertCheckedExceptions]
	public string x0bad4dd26413d7a1(string x00f49b798ac56374)
	{
		return (string)x876ed1196310e342[x00f49b798ac56374];
	}

	private static Hashtable x783901b250eabee5()
	{
		using Stream stream = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Resources.PresetShapeDefinitions.xml");
		using StreamReader streamReader = new StreamReader(stream);
		Hashtable hashtable = new Hashtable(190);
		xd4de6427d033881f(streamReader);
		string text;
		while ((text = streamReader.ReadLine()) != null && !text.StartsWith("</presetShapeDefinitons>"))
		{
			string key = x8d55c6c6ce5ef90b(text);
			hashtable.Add(key, text);
		}
		return hashtable;
	}

	private static string x8d55c6c6ce5ef90b(string x311e7a92306d7199)
	{
		int num = x311e7a92306d7199.IndexOf("<");
		int num2 = x311e7a92306d7199.IndexOf(">");
		return x311e7a92306d7199.Substring(num + 1, num2 - num - 1);
	}

	private static void xd4de6427d033881f(StreamReader xe134235b3526fa75)
	{
		xe134235b3526fa75.ReadLine();
		xe134235b3526fa75.ReadLine();
	}
}
