using System;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using x6c95d9cf46ff5f25;
using xce0136f05681c5e9;
using xf989f31a236ff98c;
using xfc5388ad7dff404f;

namespace xdbe3cd173bd00464;

internal class x10f42db128083eb4 : x611b52a649966359, x3d2908992e1d1667, xaa47e6d0b035aea6
{
	private x8556eed81191af11 xb36c250515e408ad;

	private Document x232be220f517f721;

	private x873451caae5ad4ae x800085dd555f7711;

	private xe965bada78e2d6b1 x7e24ae8042d3886b;

	private Stream x6169576fb3c218d3;

	private x48005c1711cafdca x9af56536cdcf0ffc;

	private bool x62ac338fe2fcc3c9;

	private xd3ee97bb1871dd1b x999b74020ae6bd49;

	private x08802e9e984cd3ee x5a7a1d229173bf5d;

	private x9df536d98415d2d0 xa737d500a7554634;

	private x05df33911093beb0 x230c333abfdbfccd;

	private x0ce95024f2f68661 x05b7e725c9a2cde4;

	private xb388353c23101505 x9def3467b18564d5;

	private x43802f3ed3207329 x798fdbef8412d659;

	private xb7c37a50632d7dd3 xa056586c1f99e199;

	public SaveOutputParameters xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		xb36c250515e408ad = x5ac1382edb7bf2c2;
		xa2e0b7f7da663553();
		return new SaveOutputParameters("application/xaml+xml");
	}

	internal override VisitorAction x1b12ad7e0ad0df34(Footnote x897ec71a9f9588a0)
	{
		xa056586c1f99e199.xbbf9a1ead81dd3a1(WarningType.DataLoss, "FootNotes/EndNotes are not supported in XAML yet.");
		return VisitorAction.SkipThisNode;
	}

	internal override void xb5fb564b7a85b58c(AbsolutePositionTab x067d6ddeefb41622)
	{
		xa056586c1f99e199.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Absolute position tabs are not supported in XAML, using regular tab character.");
	}

	internal override VisitorAction x29a51827c03d354b(Footnote x897ec71a9f9588a0)
	{
		return VisitorAction.Continue;
	}

	internal override VisitorAction x9a7ad1735553086c(Inline x31545d7c306a55e4)
	{
		x5a7a1d229173bf5d.x5c6f8dca650ee955(x31545d7c306a55e4);
		return VisitorAction.Continue;
	}

	internal override void x51ff2e1c5d5075fd(Shape x5770cdefd8931aa9)
	{
		xa056586c1f99e199.xbbf9a1ead81dd3a1(WarningType.DataLoss, "Horizontal rules are not supported in XAML yet.");
	}

	internal override void x27335b788ad093c5(Shape x5770cdefd8931aa9, ShapeBase x8739b0dd3627f37e, bool x43fd17e7d75faf32, string x50a18ad2656e7181, double x9b0739496f8b5475, double x4d5aabc7a55b12ba, string x916e73d84a52710c)
	{
		if (x5770cdefd8931aa9 != null && !x5770cdefd8931aa9.IsInline)
		{
			xa056586c1f99e199.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLoss, "Floating shapes positioning is not supported in XAML yet.");
		}
		x800085dd555f7711.x2307058321cdb62f("Image");
		x800085dd555f7711.x943f6be3acf634db("Width", xb2b537767a3ea62c.x541e8c2724a511cc(x9b0739496f8b5475, "pt"));
		x800085dd555f7711.x943f6be3acf634db("Height", xb2b537767a3ea62c.x541e8c2724a511cc(x4d5aabc7a55b12ba, "pt"));
		x800085dd555f7711.x2307058321cdb62f("Image.Source");
		x800085dd555f7711.x2307058321cdb62f("BitmapImage");
		x800085dd555f7711.x943f6be3acf634db("DecodePixelWidth", x4574ea26106f0edb.xdbd829479885762d(x9b0739496f8b5475));
		x800085dd555f7711.x943f6be3acf634db("DecodePixelHeight", x4574ea26106f0edb.xdbd829479885762d(x4d5aabc7a55b12ba));
		x800085dd555f7711.x943f6be3acf634db("UriSource", x50a18ad2656e7181);
		x800085dd555f7711.x943f6be3acf634db("CacheOption", "OnLoad");
		x800085dd555f7711.x2dfde153f4ef96d0();
		x800085dd555f7711.x2dfde153f4ef96d0();
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	internal override VisitorAction x1b08a07a3132f8bc(Paragraph x41baca1d6c0c2e8e)
	{
		x1a78664fa10a3755 x9e5248b49f0df7e = x41baca1d6c0c2e8e.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x2be08ba736aa04f0 | xd9bc7f7e70d71e14.x3968babb3b57e478);
		xa737d500a7554634.x00149f2495b0f026(x41baca1d6c0c2e8e.x1a78664fa10a3755.x554aca059bdf6d48);
		if (x41baca1d6c0c2e8e.xbc0119d7471ef12e)
		{
			x9af56536cdcf0ffc.x18dd6bff0a34aaf3(x41baca1d6c0c2e8e, x9e5248b49f0df7e, x4ef6b4f19b033b48.x526d6c6f824cda87);
		}
		else
		{
			x9af56536cdcf0ffc.xd7696af0a28b1b06();
			x800085dd555f7711.x2307058321cdb62f("Paragraph");
			xc946ba15e395060e.x9ed6d11bbfc54525(x800085dd555f7711, x41baca1d6c0c2e8e.ParagraphFormat);
			xc946ba15e395060e.x96072a935905c3fb(x800085dd555f7711, x41baca1d6c0c2e8e.ParagraphBreakFont, xa737d500a7554634, xb36a059a5e87b854: true);
		}
		x230c333abfdbfccd.x7e7f331e0d5f065a();
		return VisitorAction.Continue;
	}

	internal override VisitorAction xa2e5fe5057cd7778(Paragraph x41baca1d6c0c2e8e)
	{
		xa737d500a7554634.xbcd358ebb8d4e95e();
		x230c333abfdbfccd.xd5a7d506e4113f23();
		x800085dd555f7711.x2dfde153f4ef96d0();
		x9af56536cdcf0ffc.x1932165b9bea79a4();
		return VisitorAction.Continue;
	}

	internal override void x7b60b74ac6a53b3f(Font x26094932cf7a9139, bool xf544375d86767c28)
	{
	}

	private void x33557a3be0b1f84f(Font x26094932cf7a9139, string xb41faee6912a2313, x000f21cbda739311 xcb075c7088c3b520)
	{
		x798fdbef8412d659.x486167d7a74e8e88(x26094932cf7a9139, xb41faee6912a2313);
	}

	void xaa47e6d0b035aea6.x4fb8d507f4b3c96e(Font x26094932cf7a9139, string xb41faee6912a2313, x000f21cbda739311 xcb075c7088c3b520)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x33557a3be0b1f84f
		this.x33557a3be0b1f84f(x26094932cf7a9139, xb41faee6912a2313, xcb075c7088c3b520);
	}

	private void x541fe4f97f6116ea(Font x26094932cf7a9139)
	{
		throw new NotImplementedException();
	}

	void xaa47e6d0b035aea6.xa2b89eef4b059bae(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x541fe4f97f6116ea
		this.x541fe4f97f6116ea(x26094932cf7a9139);
	}

	private void x2e952fbfe11ed7f6(Font x26094932cf7a9139)
	{
		x324712e3f7868747();
	}

	void xaa47e6d0b035aea6.x284f8021a6d47363(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x2e952fbfe11ed7f6
		this.x2e952fbfe11ed7f6(x26094932cf7a9139);
	}

	private void xec9101c87d930bb3(Font x26094932cf7a9139)
	{
		x324712e3f7868747();
	}

	void xaa47e6d0b035aea6.x6597dd39dd2fe401(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xec9101c87d930bb3
		this.xec9101c87d930bb3(x26094932cf7a9139);
	}

	private void x80eec05816a3ec1b(Font x26094932cf7a9139)
	{
		x324712e3f7868747();
	}

	void xaa47e6d0b035aea6.x52597787a113eeb0(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x80eec05816a3ec1b
		this.x80eec05816a3ec1b(x26094932cf7a9139);
	}

	private void x02a5eaaf390df90d(Font x26094932cf7a9139)
	{
		x798fdbef8412d659.x486167d7a74e8e88(x26094932cf7a9139, ControlChar.Tab);
	}

	void xaa47e6d0b035aea6.x3d5e17ecf5a24632(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x02a5eaaf390df90d
		this.x02a5eaaf390df90d(x26094932cf7a9139);
	}

	private void x4fceccea53b83084(Font x26094932cf7a9139)
	{
		x798fdbef8412d659.x486167d7a74e8e88(x26094932cf7a9139, ControlChar.NonBreakingSpace);
	}

	void xaa47e6d0b035aea6.x036788cf7c188d59(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4fceccea53b83084
		this.x4fceccea53b83084(x26094932cf7a9139);
	}

	private void x998f7a5af86f30ac(Font x26094932cf7a9139)
	{
		x798fdbef8412d659.x486167d7a74e8e88(x26094932cf7a9139, ControlChar.x89adeffeeacc7300);
	}

	void xaa47e6d0b035aea6.x85c770ad4ef06982(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x998f7a5af86f30ac
		this.x998f7a5af86f30ac(x26094932cf7a9139);
	}

	private void x6b648cb838324cb3(Font x26094932cf7a9139)
	{
		x798fdbef8412d659.x486167d7a74e8e88(x26094932cf7a9139, ControlChar.x1b055d6437b48a41);
	}

	void xaa47e6d0b035aea6.xf376b77c1a1556bf(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b648cb838324cb3
		this.x6b648cb838324cb3(x26094932cf7a9139);
	}

	private void xc363aa1cb5299338(Font x26094932cf7a9139, bool xe68b7760102eb0fd)
	{
	}

	void xaa47e6d0b035aea6.x920950f507ecd136(Font x26094932cf7a9139, bool xe68b7760102eb0fd)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xc363aa1cb5299338
		this.xc363aa1cb5299338(x26094932cf7a9139, xe68b7760102eb0fd);
	}

	private static xcd1c64d43058619d xcbfafc207393bb53()
	{
		xcd1c64d43058619d xcd1c64d43058619d = new xcd1c64d43058619d();
		xcd1c64d43058619d.x2de5889cbc39c38e = true;
		xcd1c64d43058619d.x9411afdd2481f8e3 = false;
		xcd1c64d43058619d.xfb7a4eb022a84f48 = 96;
		xcd1c64d43058619d.x5835d7994902857b = false;
		return xcd1c64d43058619d;
	}

	private void xa2e0b7f7da663553()
	{
		x232be220f517f721 = xb36c250515e408ad.x2c8c6741422a1298;
		x62ac338fe2fcc3c9 = xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.XamlFlowPack;
		x6169576fb3c218d3 = xb36c250515e408ad.xb8a774e0111d0fbe;
		if (x62ac338fe2fcc3c9)
		{
			x7e24ae8042d3886b = new xe965bada78e2d6b1();
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a("/Xaml/Document.xaml", "application/vnd.ms-wpf.xaml+xml");
			x7e24ae8042d3886b.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a);
			x6169576fb3c218d3 = xa2f1c3dcbd86f20a.xb8a774e0111d0fbe;
			x7e24ae8042d3886b.xadb7000bed559a9a.xd6b6ed77479ef68c("DocPartRelId0", "http://schemas.microsoft.com/wpf/2005/10/xaml/entry", xa2f1c3dcbd86f20a.x759aa16c2016a289, x1bc1cc5e4fd586bf: false);
		}
		x800085dd555f7711 = new x873451caae5ad4ae(x6169576fb3c218d3, Encoding.UTF8, isPrettyFormat: false, useOnOff: false);
		xa056586c1f99e199 = new xb7c37a50632d7dd3(xb36c250515e408ad.xf57de0fd37d5e97d.WarningCallback);
		x5a7a1d229173bf5d = new x08802e9e984cd3ee(this, x232be220f517f721.CompatibilityOptions);
		xa737d500a7554634 = new x9df536d98415d2d0();
		x230c333abfdbfccd = new xcf13ed10017a4f7e(x800085dd555f7711, xa056586c1f99e199);
		x798fdbef8412d659 = new x43802f3ed3207329(x232be220f517f721, x800085dd555f7711, xa737d500a7554634);
		x9af56536cdcf0ffc = new x48005c1711cafdca(x800085dd555f7711, x798fdbef8412d659);
		XamlFlowSaveOptions xdfde339da46db = (XamlFlowSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d;
		x9def3467b18564d5 = (x62ac338fe2fcc3c9 ? new xb388353c23101505() : null);
		x05b7e725c9a2cde4 = new x0ce95024f2f68661(this, x230c333abfdbfccd, xcbfafc207393bb53(), x82205aaa78b9d3c8(xb36c250515e408ad.xa39af5a82860a9a3, xdfde339da46db));
		xd4314a24b94f0688 fieldWriter = new xd4314a24b94f0688(x232be220f517f721, x5a7a1d229173bf5d, x230c333abfdbfccd, xa056586c1f99e199);
		xfdd04628da146b1d tableWriter = new xfdd04628da146b1d(x800085dd555f7711);
		x90c4f711d04be990 bookmarkWriter = new x90c4f711d04be990(xa056586c1f99e199);
		x999b74020ae6bd49 = new xd3ee97bb1871dd1b(xb36c250515e408ad.x2c8c6741422a1298, x9af56536cdcf0ffc, this, fieldWriter, bookmarkWriter, tableWriter, xa056586c1f99e199, xa737d500a7554634, x05b7e725c9a2cde4);
		x9b9ed0109b743e3b();
		x5231796f7ac904c0();
		xa0dfc102c691b11f();
		if (x62ac338fe2fcc3c9)
		{
			x37e34a3456bf5150.x6210059f049f0d48(x7e24ae8042d3886b, x5b792b12c6888eeb: false);
			x2819edc79dd3a61d.x6210059f049f0d48(x7e24ae8042d3886b, x5b792b12c6888eeb: false);
			x7e24ae8042d3886b.Save(xb36c250515e408ad.xb8a774e0111d0fbe);
		}
	}

	private void x9b9ed0109b743e3b()
	{
		x800085dd555f7711.x9b9ed0109b743e3b(x62ac338fe2fcc3c9 ? "Section" : "FlowDocument");
		x800085dd555f7711.x943f6be3acf634db("xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
		x800085dd555f7711.x943f6be3acf634db("xmlns:x", "http://schemas.microsoft.com/winfx/2006/xaml");
		x800085dd555f7711.x943f6be3acf634db("xml:space", "preserve");
	}

	private void xa0dfc102c691b11f()
	{
		x800085dd555f7711.xa0dfc102c691b11f();
		if (!x62ac338fe2fcc3c9)
		{
			return;
		}
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x7e24ae8042d3886b.xd6abb2ab950b4d22.get_xe6d4b1b411ed94b5("/Xaml/Document.xaml");
		foreach (xd59a0d3f8248c4e8 item in x9def3467b18564d5.xd6abb2ab950b4d22)
		{
			string text = $"/Xaml/{item.xb405a444ca77e2d4}";
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = new xa2f1c3dcbd86f20a(text, item.x0b93856f95be30d0);
			using (MemoryStream memoryStream = item.x878afbafb98bf640())
			{
				xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
			}
			x7e24ae8042d3886b.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a2);
			xa2f1c3dcbd86f20a.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.microsoft.com/wpf/2005/10/xaml/component", text, x1bc1cc5e4fd586bf: false);
		}
	}

	private void x5231796f7ac904c0()
	{
		for (Node node = x232be220f517f721.FirstChild; node != null; node = node.NextSibling)
		{
			x51ee56decc29a9da((Section)node);
		}
	}

	private void x51ee56decc29a9da(Section xb32f8dd719a105db)
	{
		x800085dd555f7711.x2307058321cdb62f("Section");
		xb32f8dd719a105db.Body.Accept(x999b74020ae6bd49);
		x9af56536cdcf0ffc.xd7696af0a28b1b06();
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x324712e3f7868747()
	{
		x800085dd555f7711.x2307058321cdb62f("LineBreak");
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private x8aa64ac02744cab2 x82205aaa78b9d3c8(string xafe2f3653ee64ebc, XamlFlowSaveOptions xdfde339da46db651)
	{
		return new x8aa64ac02744cab2(xafe2f3653ee64ebc, x9def3467b18564d5, xdfde339da46db651.ImagesFolder, xdfde339da46db651.ImagesFolderAlias, "Image file cannot be written to disk. When saving the document to a stream either ImagesFolder should be specified or custom streams should be provided via ImageSavingCallback. Please see documentation for details.", storeRemoteImages: false);
	}
}
