using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using ns218;
using ns224;
using ns271;

namespace ns234;

internal class Class6163 : IDisposable
{
	private PrivateFontCollection privateFontCollection_0;

	private readonly Hashtable hashtable_0;

	public Class6163()
	{
		privateFontCollection_0 = new PrivateFontCollection();
		hashtable_0 = new Hashtable();
	}

	public void Dispose()
	{
		if (privateFontCollection_0 != null)
		{
			privateFontCollection_0.Dispose();
			privateFontCollection_0 = null;
		}
		GC.SuppressFinalize(this);
	}

	public FontFamily method_0(Class5999 font)
	{
		method_1(font.TrueTypeFont.Data);
		return method_3(font.FamilyName);
	}

	private void method_1(Class6654 fontData)
	{
		if (!hashtable_0.ContainsKey(fontData))
		{
			if (fontData is Class6655 @class)
			{
				privateFontCollection_0.AddFontFile(@class.FileName);
			}
			else if (fontData is Class6656 fontData2)
			{
				method_2(fontData2);
			}
		}
	}

	private void method_2(Class6656 fontData)
	{
		byte[] data = fontData.Data;
		GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
		try
		{
			privateFontCollection_0.AddMemoryFont(gCHandle.AddrOfPinnedObject(), data.Length);
		}
		finally
		{
			gCHandle.Free();
		}
	}

	private FontFamily method_3(string familyName)
	{
		FontFamily[] families = privateFontCollection_0.Families;
		int num = 0;
		FontFamily fontFamily;
		while (true)
		{
			if (num < families.Length)
			{
				fontFamily = families[num];
				if (Class5964.smethod_42(fontFamily.Name, familyName))
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return fontFamily;
	}
}
