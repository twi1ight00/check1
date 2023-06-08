using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using Aspose;
using x5794c252ba25e723;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class x425a68c71e891281
{
	private static readonly Hashtable xb3e1321a198330cf;

	private x425a68c71e891281()
	{
	}

	public static Font x2afffb4ad6317b20(xe39d06eee35dd23d x26094932cf7a9139, xd7494258f09928b1 x20689150809a3d05)
	{
		FontStyle fontStyle = x26094932cf7a9139.xfe2178c1f916f36c;
		if (x26094932cf7a9139.xda4c813a32b9109b)
		{
			fontStyle ^= FontStyle.Italic;
		}
		if (!x16848d4ff504fa3a(x26094932cf7a9139))
		{
			try
			{
				FontFamily fontFamily = x20689150809a3d05.x12c77118432cdb0a(x26094932cf7a9139);
				if (fontFamily != null)
				{
					return new Font(fontFamily, x26094932cf7a9139.x53531537bb3331e6, x041681a37c8b1705(fontFamily, fontStyle), GraphicsUnit.Point);
				}
			}
			catch (Exception)
			{
			}
		}
		return xae317a9630af3402(x26094932cf7a9139.x6054c4379c01a50d, x26094932cf7a9139.x53531537bb3331e6, fontStyle);
	}

	public static Font xae317a9630af3402(string x585e3fe3e6cf11c8, float xa03db8a5ee939042, FontStyle xdf2a58420a175f25)
	{
		try
		{
			return new Font(x585e3fe3e6cf11c8, xa03db8a5ee939042, xdf2a58420a175f25, GraphicsUnit.Point);
		}
		catch (Exception)
		{
			FontFamily fontFamily = xbfe991032d6edde2(x585e3fe3e6cf11c8);
			FontStyle style = x041681a37c8b1705(fontFamily, xdf2a58420a175f25);
			return new Font(fontFamily.Name, xa03db8a5ee939042, style, GraphicsUnit.Point);
		}
	}

	private static FontFamily xbfe991032d6edde2(string xc15bd84e01929885)
	{
		FontFamily fontFamily = xbcafc4b9efa7be6d(xc15bd84e01929885);
		if (fontFamily == null)
		{
			fontFamily = xbcafc4b9efa7be6d("Times New Roman");
		}
		if (fontFamily == null)
		{
			fontFamily = x80c7622473471c42();
		}
		if (fontFamily == null)
		{
			throw new InvalidOperationException("No fonts are installed on the system.");
		}
		return fontFamily;
	}

	private static FontStyle x041681a37c8b1705(FontFamily xc0752627b0d47dbb, FontStyle x44ecfea61c937b8e)
	{
		if (xc0752627b0d47dbb.IsStyleAvailable(x44ecfea61c937b8e))
		{
			return x44ecfea61c937b8e;
		}
		switch (x44ecfea61c937b8e)
		{
		case FontStyle.Bold | FontStyle.Italic:
			if (xc0752627b0d47dbb.IsStyleAvailable(FontStyle.Italic))
			{
				return FontStyle.Italic;
			}
			if (xc0752627b0d47dbb.IsStyleAvailable(FontStyle.Bold))
			{
				return FontStyle.Bold;
			}
			break;
		case FontStyle.Bold:
		case FontStyle.Italic:
			if (xc0752627b0d47dbb.IsStyleAvailable(FontStyle.Bold | FontStyle.Italic))
			{
				return FontStyle.Bold | FontStyle.Italic;
			}
			break;
		}
		if (xc0752627b0d47dbb.IsStyleAvailable(FontStyle.Regular))
		{
			return FontStyle.Regular;
		}
		if (xc0752627b0d47dbb.IsStyleAvailable(FontStyle.Bold))
		{
			return FontStyle.Bold;
		}
		if (xc0752627b0d47dbb.IsStyleAvailable(FontStyle.Italic))
		{
			return FontStyle.Italic;
		}
		if (xc0752627b0d47dbb.IsStyleAvailable(FontStyle.Bold | FontStyle.Italic))
		{
			return FontStyle.Bold | FontStyle.Italic;
		}
		throw new InvalidOperationException("No fonts of this family are available.");
	}

	private static FontFamily xbcafc4b9efa7be6d(string x9e9070c6c983bbc0)
	{
		return (FontFamily)xb3e1321a198330cf[x9e9070c6c983bbc0];
	}

	private static FontFamily x80c7622473471c42()
	{
		IEnumerator enumerator = xb3e1321a198330cf.Values.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return (FontFamily)enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	private static bool x16848d4ff504fa3a(xe39d06eee35dd23d x26094932cf7a9139)
	{
		return xb3e1321a198330cf.ContainsKey(x26094932cf7a9139.x29f65b3e7616f6b3.x6054c4379c01a50d);
	}

	static x425a68c71e891281()
	{
		xb3e1321a198330cf = new Hashtable();
		FontFamily[] families = new InstalledFontCollection().Families;
		FontFamily[] array = families;
		foreach (FontFamily fontFamily in array)
		{
			xb3e1321a198330cf[fontFamily.Name] = fontFamily;
		}
	}
}
