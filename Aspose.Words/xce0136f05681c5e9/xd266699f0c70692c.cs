using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Saving;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;

namespace xce0136f05681c5e9;

internal class xd266699f0c70692c : x26a1fc363fa95c48
{
	private bool x5993b5a778450b88;

	private readonly string xb60ae86f79aa8262;

	private readonly xc1973d08dacd6dfc x89e7ffdaa1e0fd25;

	internal xd266699f0c70692c(Document document, bool documentFragmentSaving, HtmlSaveOptions htmlSaveOptions, string fileName, x9df536d98415d2d0 fontColorResolver, xe2ff3c3cd396cfd9 htmlWriterCommon, x0ce95024f2f68661 shapeResourceWriter, xc1973d08dacd6dfc subsidiaryContentPartHandler, x68331b8428496f91 warningCallback)
		: base(document, documentFragmentSaving, htmlSaveOptions, fontColorResolver, htmlWriterCommon, shapeResourceWriter, warningCallback)
	{
		xb60ae86f79aa8262 = fileName;
		x89e7ffdaa1e0fd25 = subsidiaryContentPartHandler;
	}

	protected override void DoWriteDocumentStyles(ArrayList cssRules)
	{
		bool flag = x89e7ffdaa1e0fd25 != null;
		string x5d32a3741cc1f = null;
		string xabd26eb240940e8d;
		if (flag)
		{
			xabd26eb240940e8d = "styles.css";
		}
		else
		{
			x63dc572ccc95d138(out x5d32a3741cc1f, out xabd26eb240940e8d);
		}
		base.xe1410f585439c7d4.x2307058321cdb62f("link");
		base.xe1410f585439c7d4.x943f6be3acf634db("href", xabd26eb240940e8d);
		base.xe1410f585439c7d4.x943f6be3acf634db("type", "text/css");
		base.xe1410f585439c7d4.x943f6be3acf634db("rel", "stylesheet");
		base.xe1410f585439c7d4.x2dfde153f4ef96d0();
		if (x5993b5a778450b88)
		{
			return;
		}
		x5993b5a778450b88 = true;
		string text = x21de741c7816a3fd(cssRules);
		if (x89e7ffdaa1e0fd25 != null)
		{
			x89e7ffdaa1e0fd25.xbc4db1b9481c1d31(new x1441679dfc5dd25a(Encoding.UTF8, "text/css", xabd26eb240940e8d, text));
			return;
		}
		using StreamWriter streamWriter = new StreamWriter(x5d32a3741cc1f);
		streamWriter.Write(text);
	}

	private string x21de741c7816a3fd(ArrayList xa35f58bbe907c740)
	{
		StringBuilder stringBuilder = new StringBuilder(xc99eddae80770265());
		stringBuilder.Append(x4a18e164a7711385(xa35f58bbe907c740));
		return stringBuilder.ToString();
	}

	private void x63dc572ccc95d138(out string x5d32a3741cc1f212, out string xabd26eb240940e8d)
	{
		string text = xb60ae86f79aa8262;
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hllpkmcanmjafhabdlhbbmobblfcjgmcjlddekkdglbegkieikpeojgfefnfjhegcilgihchehjhfeaigjhioioimdfjkhmjgddkgikkeiblphilpgpliggmbhnmbcenpflnjgcomfjofbapeghpefopnffaofmaledbgfkbefbcgeiciepcodgdepmdcdeeookeoacflbjfibagcoggcdogadfhcdmhccdiibkianajacijcbpjmagkjankfbelolklpacmhajmflpmepgnepnnmkeoaamoipcpmojpepaabphapnoafofbejmbkndcmnkcpnbdhnidfipddmgephnepmefollfgmcgeljgcmahokhholohmkfiegmihkdjhkkjhkbknjikdgpkcfgldinlejemcjlmjjcndejnjiaoajhokdoofifpdimpfidaockaohbbnhibfhpbchgcogncogedngldlfcehfjeobafnahfdeofgffgjfmgbadhmekhaebindiijdpicpfjdenjldekjokklcclmcjledamfchmpbomjcfnenlnecdopakobcbpnaipfmopkofadpmajodbfokbglbchajcpppcnkgdlondhkeekolekocfkojfaoagijhgeoogeofhpimhondiomkihnbjinijfmpjangkomnkhhelhjllekcmbkjmlganllhnjlonllfolkmobkdpjfkpjkbaljiafjpacjgbojnbheecijlcajcdodjdnhaenhhefdoehhffmhmfogdgogkgkgbhhgihfgphbggiicni", 410385246)));
		}
		string text2 = base.xf57de0fd37d5e97d.CssStyleSheetFileName;
		if (x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			if (!Path.HasExtension(text2))
			{
				text2 += ".css";
			}
			x5d32a3741cc1f212 = (Path.IsPathRooted(text2) ? text2 : Path.Combine(Path.GetDirectoryName(text), text2));
			xabd26eb240940e8d = text2;
		}
		else
		{
			x5d32a3741cc1f212 = Path.ChangeExtension(text, ".css");
			xabd26eb240940e8d = Path.GetFileName(x5d32a3741cc1f212);
		}
	}

	private string xc99eddae80770265()
	{
		string text = xb60ae86f79aa8262;
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pnblhoilinplhogmmnnmbnenhnlnkncodijodnapolhpanopmlfailmabhdbcmkbklbcigicgkpccggdclndaleelkleljcfejjfnjag", 88715643));
		}
		string text2 = $"Styles for {text}";
		string text3 = string.Empty;
		if (base.xf57de0fd37d5e97d.xbfa4c2c3efbf56fd)
		{
			text3 = string.Format("Generated by {0}", "Aspose.Words for .NET 11.9.0.0");
		}
		int num = Math.Max(text2.Length, text3.Length);
		int repeatCount = num + 4;
		StringBuilder stringBuilder = new StringBuilder(1024);
		stringBuilder.Append('/');
		stringBuilder.Append('*', repeatCount);
		stringBuilder.AppendFormat("/\r\n/* {0}", text2);
		stringBuilder.Append(' ', num - text2.Length);
		if (text3 != string.Empty)
		{
			stringBuilder.AppendFormat(" */\r\n/* {0}", text3);
			stringBuilder.Append(' ', num - text3.Length);
		}
		stringBuilder.Append(" */\r\n/");
		stringBuilder.Append('*', repeatCount);
		stringBuilder.Append("/\r\n\r\n");
		return stringBuilder.ToString();
	}
}
