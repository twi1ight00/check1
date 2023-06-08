using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using ns271;

namespace Aspose.Slides;

public sealed class FontsLoader : IFontsLoader
{
	private static int[] int_0 = new int[143]
	{
		1078, 1052, 1025, 2049, 3073, 4097, 5121, 6145, 7169, 8193,
		9217, 10241, 11265, 12289, 13313, 14337, 15361, 16385, 1067, 1101,
		1068, 2092, 1069, 1059, 1093, 1026, 1109, 1027, 1028, 2052,
		3076, 4100, 5124, 1050, 1029, 1030, 1043, 2067, 1033, 2057,
		3081, 4105, 5129, 6153, 7177, 8201, 9225, 10249, 11273, 12297,
		13321, 1061, 1080, 1065, 1035, 1036, 2060, 3084, 4108, 5132,
		6156, 1079, 1031, 2055, 3079, 4103, 5127, 1032, 1095, 1037,
		1081, 1038, 1039, 1057, 1040, 2064, 1041, 1099, 2144, 1087,
		1111, 1042, 2066, 1062, 1063, 2087, 1071, 1086, 2110, 1100,
		1112, 1102, 2145, 1044, 2068, 1096, 1045, 1046, 2070, 1094,
		1048, 1049, 1103, 3098, 2074, 1113, 1051, 1060, 1034, 2058,
		3082, 4106, 5130, 6154, 7178, 8202, 9226, 10250, 11274, 12298,
		13322, 14346, 15370, 16394, 17418, 18442, 19466, 20490, 1072, 1089,
		1053, 2077, 1097, 1092, 1098, 1054, 1055, 1058, 1056, 2080,
		1091, 2115, 1066
	};

	private static readonly char[] char_0 = new char[2] { '/', '\\' };

	private static PrivateFontCollection privateFontCollection_0 = new PrivateFontCollection();

	private static IDictionary idictionary_0 = new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant);

	public static void LoadExternalFonts(string[] directories)
	{
		if (directories != null)
		{
			smethod_0(directories);
		}
	}

	public static void ClearCache()
	{
		if (privateFontCollection_0 != null)
		{
			privateFontCollection_0.Dispose();
			privateFontCollection_0 = new PrivateFontCollection();
		}
		idictionary_0.Clear();
	}

	private FontsLoader()
	{
	}

	private static void smethod_0(IList paths)
	{
		Class6652 instance = Class6652.Instance;
		lock (instance)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string[] array = instance.method_7();
			List<string> list = new List<string>(array);
			for (int i = 0; i < array.Length; i++)
			{
				string text = smethod_2(array[i]);
				dictionary[text] = text;
			}
			foreach (string path in paths)
			{
				string text3 = smethod_2(path);
				if (Directory.Exists(path) && !dictionary.ContainsKey(text3))
				{
					smethod_1(text3, recursive: true);
					list.Add(text3);
				}
			}
			instance.method_6(list.ToArray(), recursive: true);
			idictionary_0.Clear();
			FontFamily[] families = privateFontCollection_0.Families;
			FontFamily[] array2 = families;
			foreach (FontFamily fontFamily in array2)
			{
				for (int k = 0; k < int_0.Length; k++)
				{
					idictionary_0[fontFamily.GetName(int_0[k])] = fontFamily;
				}
			}
		}
	}

	private static void smethod_1(string dirName, bool recursive)
	{
		string[] files = Directory.GetFiles(dirName);
		string[] array = files;
		foreach (string path in array)
		{
			string filename = Path.Combine(dirName, path);
			try
			{
				privateFontCollection_0.AddFontFile(filename);
			}
			catch (FileNotFoundException)
			{
			}
		}
		if (recursive)
		{
			string[] directories = Directory.GetDirectories(dirName);
			foreach (string path2 in directories)
			{
				smethod_1(Path.Combine(dirName, path2), recursive);
			}
		}
	}

	private static string smethod_2(string name)
	{
		name = Path.GetFullPath(name);
		return name.TrimEnd(char_0);
	}

	internal static Font smethod_3(string familyName, float size, FontStyle style)
	{
		FontFamily fontFamily = (FontFamily)idictionary_0[familyName];
		if (fontFamily != null && fontFamily.IsStyleAvailable(style))
		{
			return new Font(fontFamily, size, style);
		}
		return new Font(familyName, size, style);
	}
}
