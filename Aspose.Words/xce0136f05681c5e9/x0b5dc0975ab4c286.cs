using System;
using System.Collections;
using System.Drawing;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;
using x2697283ff424107e;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xe9865c3fb834da49;
using xf989f31a236ff98c;

namespace xce0136f05681c5e9;

internal class x0b5dc0975ab4c286 : x6585e25befaba8c8
{
	private const string x74837bbcb83c328e = "FontStream cannot be specified. When saving to one of the container formats based on HTML (e.g. EPUB or MHTML), all subsidiary parts must be encapsulated into the output package.";

	internal x0b5dc0975ab4c286(string fileName, xc1973d08dacd6dfc subsidiaryContentPartHandler, string exportFontsFolder, string exportFontsFolderAlias, string messageWhenNoOutputFolder)
		: base(fileName, subsidiaryContentPartHandler, exportFontsFolder, exportFontsFolderAlias, messageWhenNoOutputFolder)
	{
	}

	internal x63101ab0f6a74e8f[] xddf78efd6737dab2(Document x6beba47238e0ade6, HtmlSaveOptions xc27f01f21f67608c)
	{
		xdf1dc37b28b425e3 xdf1dc37b28b425e4 = new xdf1dc37b28b425e3();
		x6beba47238e0ade6.Accept(xdf1dc37b28b425e4);
		Hashtable hashtable = new Hashtable();
		xd345c73dd1b16b74 xd345c73dd1b16b = new xd345c73dd1b16b74();
		IFontSavingCallback fontSavingCallback = xc27f01f21f67608c.FontSavingCallback;
		int fontResourcesSubsettingSizeThreshold = xc27f01f21f67608c.FontResourcesSubsettingSizeThreshold;
		bool flag = fontSavingCallback != null || (fontResourcesSubsettingSizeThreshold > 0 && fontResourcesSubsettingSizeThreshold < int.MaxValue);
		foreach (DictionaryEntry item in xdf1dc37b28b425e4.x39ca55b691f96321)
		{
			string text = (string)item.Key;
			xcd986872cf3bcf68 xcd986872cf3bcf = (xcd986872cf3bcf68)item.Value;
			x6b1a899052c71a60 x29f65b3e7616f6b = xcd986872cf3bcf.x29f65b3e7616f6b3;
			FontStyle xfe2178c1f916f36c = x29f65b3e7616f6b.xfe2178c1f916f36c;
			bool flag2 = (xfe2178c1f916f36c & FontStyle.Bold) != 0;
			bool flag3 = (xfe2178c1f916f36c & FontStyle.Italic) != 0;
			string xa39af5a82860a9a = x29f65b3e7616f6b.xa39af5a82860a9a3;
			object obj = hashtable[xa39af5a82860a9a];
			if (obj != null)
			{
				xcdae7ada86065aa4(xd345c73dd1b16b, x29f65b3e7616f6b.x6054c4379c01a50d, flag2, flag3, (string)obj);
				continue;
			}
			int num = ((!flag || !x0d299f323d241756.x5959bccb67bbf051(xa39af5a82860a9a)) ? 1 : x29f65b3e7616f6b.x6b73aa01aa019d3a.GetSize());
			bool flag4 = num > fontResourcesSubsettingSizeThreshold;
			if (flag4 && x0d299f323d241756.x90637a473b1ceaaa(Path.GetExtension(text), ".ttc"))
			{
				text = Path.ChangeExtension(text, ".ttf");
			}
			text = ((x9f6db1997310ea42.Length > 0) ? $"{x9f6db1997310ea42}.{text}" : text);
			x3d213ffad4d30370 x3d213ffad4d = null;
			if (fontSavingCallback != null)
			{
				FontSavingArgs fontSavingArgs = new FontSavingArgs(x6beba47238e0ade6, x29f65b3e7616f6b.x6054c4379c01a50d, flag2, flag3, xa39af5a82860a9a, num, flag4, text);
				fontSavingCallback.FontSaving(fontSavingArgs);
				if (!fontSavingArgs.IsExportNeeded)
				{
					continue;
				}
				flag4 = fontSavingArgs.IsSubsettingNeeded;
				text = fontSavingArgs.FontFileName;
				if (x89e7ffdaa1e0fd25 != null && fontSavingArgs.x3477a684b2bbe7b0)
				{
					throw new InvalidOperationException("FontStream cannot be specified. When saving to one of the container formats based on HTML (e.g. EPUB or MHTML), all subsidiary parts must be encapsulated into the output package.");
				}
				if (fontSavingArgs.x3477a684b2bbe7b0)
				{
					x3d213ffad4d = fontSavingArgs.xd9984d5750dc6ac8();
				}
			}
			if (x89e7ffdaa1e0fd25 != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				xcdf129f8dbe26b89(xcd986872cf3bcf, flag4, memoryStream);
				x89e7ffdaa1e0fd25.xbc4db1b9481c1d31(new x32626c54bb4e8c9e("application/octet-stream", text, x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream)));
			}
			else if (x3d213ffad4d != null)
			{
				xcdf129f8dbe26b89(xcd986872cf3bcf, flag4, x3d213ffad4d.x59aa197935be8c77());
				x3d213ffad4d.x14e5354973c7740e();
			}
			else
			{
				x099b711ff05e633b();
				using FileStream xedc894794186020d = File.Create(Path.Combine(x68ad5cedc00f38e6, text));
				xcdf129f8dbe26b89(xcd986872cf3bcf, flag4, xedc894794186020d);
			}
			string text2 = xf5e402c3e2321905(text);
			xcdae7ada86065aa4(xd345c73dd1b16b, x29f65b3e7616f6b.x6054c4379c01a50d, flag2, flag3, text2);
			if (!flag4)
			{
				hashtable.Add(xa39af5a82860a9a, text2);
			}
		}
		x63101ab0f6a74e8f[] array = new x63101ab0f6a74e8f[xd345c73dd1b16b.Count];
		for (int i = 0; i < xd345c73dd1b16b.Count; i++)
		{
			array[i] = new x63101ab0f6a74e8f("@font-face", (xa3fc7dcdc8182ff6)xd345c73dd1b16b.GetByIndex(i));
		}
		return array;
	}

	private static void xcdae7ada86065aa4(xd345c73dd1b16b74 x4408c1bdd9858350, string x41166b24dc03e8e1, bool xb0c2ce71ea178326, bool xeac181883dccb27a, string x3fb9314ba6cf49ef)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		xa3fc7dcdc8182ff.x566936ceeb951bac("font-family", x41166b24dc03e8e1);
		if (xb0c2ce71ea178326)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("font-weight", "bold");
		}
		if (xeac181883dccb27a)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("font-style", "italic");
		}
		xa3fc7dcdc8182ff.xf0ca15702ca7498c("src", $"url('{x3fb9314ba6cf49ef}')");
		string key = $"{x41166b24dc03e8e1}++{(xb0c2ce71ea178326 ? 1 : 0) + (xeac181883dccb27a ? 2 : 0)}";
		x4408c1bdd9858350.Add(key, xa3fc7dcdc8182ff);
	}

	private static void xcdf129f8dbe26b89(xcd986872cf3bcf68 xdf4e8adcb2e5e03b, bool xd6d4ee00c9a35fc8, Stream xedc894794186020d)
	{
		if (xd6d4ee00c9a35fc8)
		{
			xdf4e8adcb2e5e03b.WriteToStream(xedc894794186020d);
			return;
		}
		using Stream x23cda4cfdf81f2cf = xdf4e8adcb2e5e03b.x29f65b3e7616f6b3.x6b73aa01aa019d3a.OpenStream();
		x0d299f323d241756.x3ad8e53785c39acd(x23cda4cfdf81f2cf, xedc894794186020d);
	}
}
