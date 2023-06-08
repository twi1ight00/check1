using System;
using xeb665d1aeef09d64;

namespace Aspose.Words.Fonts;

public class FontSettings
{
	public static string DefaultFontName
	{
		get
		{
			return x9d888f53892d94df.x9834ddb0e0bd5996.x24fe1274033c7866;
		}
		set
		{
			x9d888f53892d94df.x9834ddb0e0bd5996.x24fe1274033c7866 = value;
		}
	}

	private FontSettings()
	{
	}

	public static void SetFontsFolder(string fontFolder, bool recursive)
	{
		SetFontsFolders(new string[1] { fontFolder }, recursive);
	}

	public static void SetFontsFolders(string[] fontsFolders, bool recursive)
	{
		if (fontsFolders == null)
		{
			throw new ArgumentNullException("fontsFolders");
		}
		FontSourceBase[] array = new FontSourceBase[fontsFolders.Length];
		for (int i = 0; i < fontsFolders.Length; i++)
		{
			array[i] = new FolderFontSource(fontsFolders[i], recursive);
		}
		SetFontsSources(array);
	}

	public static void SetFontsSources(FontSourceBase[] sources)
	{
		if (sources == null)
		{
			throw new ArgumentNullException("sources");
		}
		x551d3b1862a114b1[] array = new x551d3b1862a114b1[sources.Length];
		for (int i = 0; i < sources.Length; i++)
		{
			array[i] = sources[i].x5eff1f3a09faac7e();
		}
		x9d888f53892d94df.x9834ddb0e0bd5996.xe085d0969cf4c4d7(array);
	}

	public static FontSourceBase[] GetFontsSources()
	{
		x551d3b1862a114b1[] array = x9d888f53892d94df.x9834ddb0e0bd5996.x157ffd4aa001e74b();
		FontSourceBase[] array2 = new FontSourceBase[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = FontSourceBase.xef3486beca5d0ebc(array[i]);
		}
		return array2;
	}

	public static void ResetFontSources()
	{
		x9d888f53892d94df.x9834ddb0e0bd5996.x74f5a1ef3906e23c();
	}
}
