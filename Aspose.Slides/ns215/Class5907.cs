using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using ns183;
using ns271;

namespace ns215;

internal class Class5907
{
	private const string string_0 = "Courier";

	internal static Dictionary<string, string[]> dictionary_0;

	static Class5907()
	{
		dictionary_0 = new Dictionary<string, string[]>();
		dictionary_0.Add("frutiger", new string[2] { "myriadpro", "Helvetica" });
		dictionary_0.Add("ubsheadline", new string[1] { "Times New Roman" });
	}

	internal static Class6730 smethod_0(string name, FontStyle style)
	{
		string name2 = name.Replace(" ", string.Empty);
		Class6730 @class = Class5939.Instance.method_4(name2, "Regular", 400, style);
		if (@class == null)
		{
			string text = name.ToLower(CultureInfo.InvariantCulture);
			foreach (KeyValuePair<string, string[]> item in dictionary_0)
			{
				if (!text.Contains(item.Key))
				{
					continue;
				}
				string[] value = item.Value;
				foreach (string name3 in value)
				{
					@class = Class5939.Instance.method_4(name3, "Regular", 400, style);
					if (@class != null)
					{
						Class5939.Instance.method_1(name, "Regular", 400, @class);
						break;
					}
				}
				if (@class == null)
				{
					string familyName = item.Value[item.Value.Length - 1];
					@class = Class6652.Instance.method_0(familyName, style, "Courier");
					Class5939.Instance.method_1(name, style.ToString(), 400, @class);
				}
				break;
			}
			if (@class == null)
			{
				@class = Class6652.Instance.method_0(name, style, "Courier");
				Class5939.Instance.method_1(name, style.ToString(), 400, @class);
			}
		}
		return @class;
	}
}
