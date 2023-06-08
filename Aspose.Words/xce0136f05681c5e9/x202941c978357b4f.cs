using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fonts;
using Aspose.Words.Lists;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using x461bbf0a821e3c87;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;
using xe9865c3fb834da49;
using xf989f31a236ff98c;

namespace xce0136f05681c5e9;

internal abstract class x202941c978357b4f
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly bool xb42f2f2b9987ee29;

	private readonly xe2ff3c3cd396cfd9 x09b9574bb5661d62;

	private readonly x0ce95024f2f68661 x05b7e725c9a2cde4;

	private readonly x68331b8428496f91 xa056586c1f99e199;

	private readonly HtmlSaveOptions x1cb867f3d40f3203;

	private readonly FontInfoCollection xa9f5d479d1be8b75;

	private readonly double x2368a322359f05df;

	private double x1a7f5667b1671322;

	private int xfe2617311442ef45;

	protected HtmlSaveOptions xf57de0fd37d5e97d => x1cb867f3d40f3203;

	protected bool x8d3e55aac9030e70 => x1cb867f3d40f3203.PrettyFormat;

	protected FontInfoCollection x0f1c1b952997f672 => xa9f5d479d1be8b75;

	protected x515d2f71e3e1988e xe1410f585439c7d4 => x09b9574bb5661d62.xe1410f585439c7d4;

	protected x202941c978357b4f(Document document, bool documentFragmentSaving, HtmlSaveOptions saveOptions, xe2ff3c3cd396cfd9 htmlWriterCommon, x0ce95024f2f68661 shapeResourceWriter, x68331b8428496f91 warningCallback)
	{
		xd1424e1a0bb4a72b = document;
		xb42f2f2b9987ee29 = documentFragmentSaving;
		x09b9574bb5661d62 = htmlWriterCommon;
		x05b7e725c9a2cde4 = shapeResourceWriter;
		xa056586c1f99e199 = warningCallback;
		x1cb867f3d40f3203 = saveOptions;
		xa9f5d479d1be8b75 = (x1cb867f3d40f3203.x5e55119260398f2a ? xd1424e1a0bb4a72b.FontInfos : null);
		if (x1cb867f3d40f3203.ExportRelativeFontSize)
		{
			Style style = xd1424e1a0bb4a72b.Styles[0];
			if (style != null)
			{
				x2368a322359f05df = style.Font.Size;
			}
			else
			{
				x2368a322359f05df = x4574ea26106f0edb.x4610495f80b4c267((int)xeedad81aaed42a76.x0095b789d636f3ae(190));
			}
			x1a7f5667b1671322 = x2368a322359f05df;
		}
		xfe2617311442ef45 = 0;
	}

	internal void x0961d4960608be76(ArrayList xa35f58bbe907c740)
	{
		if (xa35f58bbe907c740.Count == 0)
		{
			return;
		}
		bool flag = true;
		if (x1cb867f3d40f3203.CssSavingCallback != null)
		{
			CssSavingArgs cssSavingArgs = new CssSavingArgs(xd1424e1a0bb4a72b);
			x1cb867f3d40f3203.CssSavingCallback.CssSaving(cssSavingArgs);
			if (cssSavingArgs.x3477a684b2bbe7b0)
			{
				x3d213ffad4d30370 x3d213ffad4d = cssSavingArgs.xd9984d5750dc6ac8();
				Stream stream = x3d213ffad4d.x59aa197935be8c77();
				string value = x4a18e164a7711385(xa35f58bbe907c740);
				StreamWriter streamWriter = new StreamWriter(stream);
				streamWriter.Write(value);
				streamWriter.Flush();
				x3d213ffad4d.x14e5354973c7740e();
				streamWriter = null;
			}
			flag = cssSavingArgs.IsExportNeeded;
		}
		if (!flag)
		{
			return;
		}
		if (xb42f2f2b9987ee29)
		{
			if (xa056586c1f99e199 != null)
			{
				xa056586c1f99e199.xbbf9a1ead81dd3a1(WarningType.DataLoss, "Embedded and external CSS styles aren't available when a document fragment is exported!");
			}
		}
		else
		{
			DoWriteDocumentStyles(xa35f58bbe907c740);
		}
	}

	[JavaThrows(true)]
	internal abstract ArrayList xdbfcc0f818df30a4();

	internal virtual void xf567f5aadd93f9a8(Section xb32f8dd719a105db)
	{
		if (x1cb867f3d40f3203.ExportPageSetup)
		{
			xe1410f585439c7d4.xff520a0047c27122("class", $"Section{++xfe2617311442ef45}");
		}
	}

	[JavaThrows(true)]
	internal abstract void x23c8b7ad9bfc5719(Paragraph x41baca1d6c0c2e8e, x1a78664fa10a3755 x9e5248b49f0df7e8, bool x1ebf5501f9a725fb, x4ef6b4f19b033b48 x1458787a87172e23);

	[JavaThrows(true)]
	internal abstract void xabeba2b272a12ca7(Font x26094932cf7a9139, x000f21cbda739311 xcb075c7088c3b520, bool xf544375d86767c28);

	[JavaThrows(true)]
	internal void x6403e2e269084313(ListLevel x0fe7a8514e20eb94, double x5d7e66e9c97b3a9a)
	{
		string x8dcfbf7b6ef = string.Empty;
		Shape xc9c754014952f = x0fe7a8514e20eb94.xc9c754014952f758;
		if (xc9c754014952f != null && x5d7e66e9c97b3a9a > 0.0)
		{
			x8dcfbf7b6ef = x05b7e725c9a2cde4.x4831706ba6f80d0b(xc9c754014952f, x5d7e66e9c97b3a9a);
		}
		string xa7505a15e36bfe1e = x015eb412e40a664b.xee9c65145be54ec5(x1cb867f3d40f3203, x0fe7a8514e20eb94, x8dcfbf7b6ef);
		x314725af01129cb4(xa7505a15e36bfe1e);
	}

	[JavaThrows(true)]
	internal virtual void x9566076cef3a2874(Shape x5770cdefd8931aa9, ShapeBase x8739b0dd3627f37e, bool x43fd17e7d75faf32)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		if (x5770cdefd8931aa9 != null)
		{
			xb089aef4742fc3cc(x5770cdefd8931aa9, xa3fc7dcdc8182ff, x43fd17e7d75faf32);
		}
		x806b490257606c32(x8739b0dd3627f37e, xa3fc7dcdc8182ff);
		if (xa3fc7dcdc8182ff.xd44988f225497f3a > 0)
		{
			x314725af01129cb4(xa3fc7dcdc8182ff.x9a706f5d15bd6d95(x8d3e55aac9030e70));
		}
	}

	private static void x806b490257606c32(ShapeBase x8739b0dd3627f37e, xa3fc7dcdc8182ff6 x36c843bef78b260f)
	{
		switch (x8739b0dd3627f37e.WrapType)
		{
		case WrapType.Square:
		case WrapType.Tight:
		case WrapType.Through:
		{
			x36c843bef78b260f.xfd7a4669c14e659a("margin", x8739b0dd3627f37e.DistanceTop, x8739b0dd3627f37e.DistanceRight, x8739b0dd3627f37e.DistanceBottom, x8739b0dd3627f37e.DistanceLeft, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			bool flag = x8739b0dd3627f37e.HorizontalAlignment == HorizontalAlignment.Right;
			x36c843bef78b260f.xf0ca15702ca7498c("float", flag ? "right" : "left");
			break;
		}
		case WrapType.TopBottom:
		case WrapType.None:
		{
			x36c843bef78b260f.xf0ca15702ca7498c("position", "absolute");
			double xbcea506a33cf = x5b489da1031c7f4a(x8739b0dd3627f37e);
			string xc15bd84e = ((x8739b0dd3627f37e.ParentParagraph != null && x8739b0dd3627f37e.ParentParagraph.ParagraphFormat.Bidi) ? "margin-right" : "margin-left");
			x36c843bef78b260f.xd6d0700e6673d965(xc15bd84e, xbcea506a33cf, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			x36c843bef78b260f.xd6d0700e6673d965("margin-top", x8739b0dd3627f37e.Top, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			int num = x8739b0dd3627f37e.x2dacf7fcd96fee63;
			if (num == 0)
			{
				num = (x8739b0dd3627f37e.BehindText ? (x8739b0dd3627f37e.ZOrder - 65535) : x8739b0dd3627f37e.ZOrder);
			}
			Paragraph paragraph = (Paragraph)x8739b0dd3627f37e.xdfa6ecc6f742f086;
			if (paragraph.ParentStory is HeaderFooter)
			{
				num -= 65536;
			}
			x36c843bef78b260f.x0973ec6da4c01c5e("z-index", num);
			break;
		}
		case WrapType.Inline:
			break;
		}
	}

	private static double x5b489da1031c7f4a(ShapeBase x5770cdefd8931aa9)
	{
		switch (x5770cdefd8931aa9.HorizontalAlignment)
		{
		case HorizontalAlignment.Center:
		{
			Section section2 = (Section)x5770cdefd8931aa9.GetAncestor(NodeType.Section);
			return ((double)section2.PageSetup.x887b872a95caaab5 - x5770cdefd8931aa9.Width) / 2.0;
		}
		case HorizontalAlignment.Left:
		case HorizontalAlignment.Inside:
			return 0.0;
		case HorizontalAlignment.Right:
		case HorizontalAlignment.Outside:
		{
			Section section = (Section)x5770cdefd8931aa9.GetAncestor(NodeType.Section);
			return (double)section.PageSetup.x887b872a95caaab5 - x5770cdefd8931aa9.Width;
		}
		default:
			return x5770cdefd8931aa9.Left;
		}
	}

	private static void xb089aef4742fc3cc(Shape x5770cdefd8931aa9, xa3fc7dcdc8182ff6 x36c843bef78b260f, bool x43fd17e7d75faf32)
	{
		bool flag = false;
		if (x4d1876e41eb40120(x5770cdefd8931aa9))
		{
			Stroke stroke = x5770cdefd8931aa9.Stroke;
			if (stroke.On && stroke.x63b1a7c31a962459.xda71bf6f7c07c3bc > 0)
			{
				Border border = new Border();
				border.LineStyle = x8aa64ac02744cab2.xe9bc0b2ab2d85b2f(stroke.DashStyle);
				border.x3b83679cceee1fab(stroke.Weight);
				border.x63b1a7c31a962459 = stroke.x63b1a7c31a962459;
				flag = x30ff4cedcf2b2374.xad56ef88b1fac115(border, x36c843bef78b260f);
			}
			else if (x5770cdefd8931aa9.WrapType == WrapType.Inline)
			{
				ImageData imageData = x5770cdefd8931aa9.ImageData;
				if (imageData != null)
				{
					flag = x30ff4cedcf2b2374.xa95bac7421a1a927(x36c843bef78b260f, imageData.Borders, x82fdb3b4231a1374: false);
				}
			}
		}
		if (!flag && x43fd17e7d75faf32)
		{
			x36c843bef78b260f.xf0ca15702ca7498c("border", "none");
		}
	}

	internal static bool x4d1876e41eb40120(Shape x5770cdefd8931aa9)
	{
		bool result = false;
		if (x8aa64ac02744cab2.xf053cfa2478ebf73(x5770cdefd8931aa9.ShapeType))
		{
			Stroke stroke = x5770cdefd8931aa9.Stroke;
			if (stroke.On && stroke.x63b1a7c31a962459.xda71bf6f7c07c3bc > 0)
			{
				result = true;
			}
			else if (x5770cdefd8931aa9.WrapType == WrapType.Inline)
			{
				ImageData imageData = x5770cdefd8931aa9.ImageData;
				if (imageData != null)
				{
					BorderCollection borders = imageData.Borders;
					foreach (Border item in borders)
					{
						if (x30ff4cedcf2b2374.x268d6d4bc90473e9(item.LineStyle))
						{
							result = true;
							break;
						}
					}
				}
			}
		}
		return result;
	}

	[JavaThrows(true)]
	internal abstract void x746ca66f5c31e314(Table x1ec770899c98a268, double x072a638ef82da903);

	[JavaThrows(true)]
	internal abstract void x47fedfe9a943719d(Row xa806b754814b9ae0);

	[JavaThrows(true)]
	internal abstract void x1b6c90c46e2852e3(x9546c9d5ffe8dc51 xe6de5e5fa2d44af5);

	protected void xbb2a2396386bdb03(xa3fc7dcdc8182ff6 x36c843bef78b260f, Paragraph x43004763abb6b2ac, bool xbab733ddfd26bc0a)
	{
		if (x1cb867f3d40f3203.ExportRelativeFontSize)
		{
			xfe0fc5c78479c38d(x36c843bef78b260f, x43004763abb6b2ac, xbab733ddfd26bc0a);
		}
	}

	private void xfe0fc5c78479c38d(xa3fc7dcdc8182ff6 x36c843bef78b260f, Paragraph x43004763abb6b2ac, bool xbab733ddfd26bc0a)
	{
		x1a7f5667b1671322 = x2368a322359f05df;
		if (!x33380cf88234e9d6(x36c843bef78b260f, x74ad8d54bbfbd992: true) && x43004763abb6b2ac != null)
		{
			Style xfcffbd79482d97c = x43004763abb6b2ac.xfcffbd79482d97c7;
			double size = xfcffbd79482d97c.Font.Size;
			if (xbab733ddfd26bc0a)
			{
				double xbcea506a33cf = size / x1a7f5667b1671322;
				x36c843bef78b260f.set_xe6d4b1b411ed94b5("font-size", xedac08b4826d3056.x87b271b2896f9b89(xbcea506a33cf, x0ec035c4a2d07fb6.x62cd0075ae1f4023));
			}
			x1a7f5667b1671322 = size;
		}
	}

	protected void x6e55fba257b87843(xa3fc7dcdc8182ff6 x36c843bef78b260f)
	{
		if (x1cb867f3d40f3203.ExportRelativeFontSize)
		{
			x33380cf88234e9d6(x36c843bef78b260f, x74ad8d54bbfbd992: false);
		}
	}

	private bool x33380cf88234e9d6(xa3fc7dcdc8182ff6 x36c843bef78b260f, bool x74ad8d54bbfbd992)
	{
		bool result = false;
		xedac08b4826d3056 xedac08b4826d = x36c843bef78b260f.get_xe6d4b1b411ed94b5("font-size");
		if (xedac08b4826d != null)
		{
			double num = xedac08b4826d.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			if (num != x1a7f5667b1671322)
			{
				double xbcea506a33cf = num / x1a7f5667b1671322;
				if (x74ad8d54bbfbd992)
				{
					x1a7f5667b1671322 = num;
				}
				x36c843bef78b260f.set_xe6d4b1b411ed94b5("font-size", xedac08b4826d3056.x87b271b2896f9b89(xbcea506a33cf, x0ec035c4a2d07fb6.x62cd0075ae1f4023));
				result = true;
			}
			else
			{
				x36c843bef78b260f.x52b190e626f65140("font-size");
			}
		}
		return result;
	}

	protected string x4a18e164a7711385(ArrayList xa35f58bbe907c740)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		foreach (x63101ab0f6a74e8f item in xa35f58bbe907c740)
		{
			if (!flag)
			{
				stringBuilder.Append("\r\n");
			}
			flag = false;
			stringBuilder.Append(item.x9a706f5d15bd6d95(x8d3e55aac9030e70));
		}
		return stringBuilder.ToString();
	}

	protected void x314725af01129cb4(string xa7505a15e36bfe1e)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xa7505a15e36bfe1e))
		{
			xe1410f585439c7d4.xff520a0047c27122("style", xa7505a15e36bfe1e);
		}
	}

	protected void xd349b7f1296c4aca(string xa7505a15e36bfe1e)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xa7505a15e36bfe1e))
		{
			xe1410f585439c7d4.xd52401bdf5aacef6(" style=\"");
			xe1410f585439c7d4.x3d1be38abe5723e3(xa7505a15e36bfe1e);
			xe1410f585439c7d4.xd52401bdf5aacef6("\"");
		}
	}

	protected virtual void DoWriteDocumentStyles(ArrayList cssRules)
	{
		xe1410f585439c7d4.x2307058321cdb62f("style");
		xe1410f585439c7d4.x943f6be3acf634db("type", "text/css");
		xe1410f585439c7d4.xd52401bdf5aacef6(xfd515e6fd8f9d1e4(cssRules));
		xe1410f585439c7d4.x538f0e0fb2bf15ab("style");
	}

	private string xfd515e6fd8f9d1e4(ArrayList xa35f58bbe907c740)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		if (x8d3e55aac9030e70)
		{
			XmlTextWriter x5222f4285e37d66b = xe1410f585439c7d4.x5222f4285e37d66b;
			if (x5222f4285e37d66b.Formatting == Formatting.Indented)
			{
				char indentChar = x5222f4285e37d66b.IndentChar;
				int indentation = x5222f4285e37d66b.Indentation;
				text = new string(indentChar, indentation * 2);
				text2 = new string(indentChar, indentation);
			}
			text3 = "\r\n";
		}
		string value = text3 + text + text2;
		StringBuilder stringBuilder = new StringBuilder(1024);
		foreach (x63101ab0f6a74e8f item in xa35f58bbe907c740)
		{
			stringBuilder.Append(value);
			stringBuilder.Append(item.x9a706f5d15bd6d95(x8d3e55aac9030e70));
		}
		stringBuilder.Append(text3 + text);
		return stringBuilder.ToString();
	}
}
