using System.Collections;
using System.IO;
using System.Text;
using ns171;
using ns175;
using ns178;
using ns184;

namespace ns183;

internal class Class5941
{
	private const int int_0 = 96;

	private static ArrayList smethod_0(Stream stream, string DirName, Interface171 resourceLoadingCallback, bool splitElements, Hashtable blocksIdRectMap, bool forceAlignBreak, int resolution, string defaultFontName)
	{
		Class5939.smethod_0(out var exist);
		Class5734 @class = null;
		try
		{
			@class = Class5734.smethod_0();
			Class5738 class2 = @class.method_0();
			class2.object_0 = new ArrayList();
			class2.SplitPages = splitElements;
			class2.hashtable_1 = blocksIdRectMap;
			class2.ForceAlignBreak = forceAlignBreak;
			class2.method_39(resolution);
			class2.method_34(resolution);
			class2.DefaultFontName = defaultFontName;
			@class.method_15(new Class5184());
			@class.method_15(new Class5181());
			@class.method_20(resourceLoadingCallback);
			Class4923 class3 = @class.method_8("application/X-fop-ex-aps", class2, new MemoryStream());
			Class5692 class4 = new Class5692();
			class4.method_1(class3.method_2());
			class4.method_3(stream, DirName);
			return class2.object_0 as ArrayList;
		}
		finally
		{
			if (!exist)
			{
				Class5939.Instance.Dispose();
			}
			@class?.Dispose();
		}
	}

	public static string smethod_1(string src, string encodingName)
	{
		Class5681 @class = Class5681.smethod_0(encodingName);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in src)
		{
			int num = c;
			num &= 0xFF;
			stringBuilder.Append(@class.method_1(num));
		}
		return stringBuilder.ToString();
	}

	public static ArrayList smethod_2(Stream stream)
	{
		Interface171 resourceLoadingCallback = null;
		return smethod_3(stream, resourceLoadingCallback);
	}

	public static ArrayList smethod_3(Stream stream, Interface171 resourceLoadingCallback)
	{
		string dirName = null;
		if (stream is FileStream fileStream)
		{
			dirName = Path.GetDirectoryName(Path.GetFullPath(fileStream.Name));
		}
		return smethod_0(stream, dirName, resourceLoadingCallback, splitElements: false, null, forceAlignBreak: false, 96, null);
	}

	public static ArrayList smethod_4(string file)
	{
		Interface171 resourceLoadingCallback = null;
		return smethod_5(file, resourceLoadingCallback);
	}

	public static ArrayList smethod_5(string file, Interface171 resourceLoadingCallback)
	{
		using FileStream stream = new FileStream(file, FileMode.Open);
		return smethod_0(stream, Path.GetDirectoryName(Path.GetFullPath(file)), resourceLoadingCallback, splitElements: false, null, forceAlignBreak: false, 96, null);
	}

	public static ArrayList smethod_6(string file, Class5942 options)
	{
		using FileStream stream = new FileStream(file, FileMode.Open);
		return smethod_0(stream, Path.GetDirectoryName(Path.GetFullPath(file)), options.ResourceLoadingCallback, options.SplitElements, options.BlocksIdRectMap, options.ForceAlignBreak, options.Resolution, options.DefaultFontName);
	}

	public static ArrayList smethod_7(Stream stream, Class5942 options)
	{
		return smethod_0(stream, null, options.ResourceLoadingCallback, options.SplitElements, options.BlocksIdRectMap, options.ForceAlignBreak, options.Resolution, options.DefaultFontName);
	}
}
