using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Lists;
using Aspose.Words.Loading;
using Aspose.Words.Tables;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x643046e3f004c49f;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;
using xb1090543d168d647;
using xf989f31a236ff98c;
using xf9a9481c3f63a419;

namespace x9b5b1a17490bd5f3;

internal class xc5f6f2ca0aafd220 : xc118baa3bc102199
{
	private const int x94ef9f89156be1c7 = 3;

	private readonly Stack x8c369dd4b7b71b4a = new Stack();

	private readonly Stack xec412cd4d823f487 = new Stack();

	private readonly Stack x7c52265a69daa8be = new Stack();

	private readonly x0cd0eeb5ca95cea9 xc7c8ca940d0bde59;

	private readonly Stack x19babaa6d05c2c60 = new Stack();

	private Node xd193f2c3d56c63aa;

	private DocumentBuilder x800085dd555f7711;

	private string x62ff3dabf0a6c41f;

	private bool xcce49fb52a4dacc7;

	private bool x2e572df84dee9bea;

	private double xdc55f1d401c8fec5;

	private int x99f7ec70d9b06596;

	private readonly Stack x7bd4cdc3676c2aab = new Stack();

	private readonly Stack x289160346e2ab743 = xc3cb38bc7b8201b7(ParagraphAlignment.Left);

	private bool x9145869b450617d6;

	private FormField x632061204aa8c20b;

	private x7778af522baacfda x6de74d3075f0cd04;

	private readonly IWarningCallback xa056586c1f99e199;

	private static readonly char[] xb6f494893064da69 = new char[2] { '+', '-' };

	private x0d6ae8e5a962fac2 x1a1696de1c96ba31
	{
		get
		{
			if (x7bd4cdc3676c2aab.Count <= 0)
			{
				return null;
			}
			return (x0d6ae8e5a962fac2)x7bd4cdc3676c2aab.Peek();
		}
	}

	internal x0cd0eeb5ca95cea9 x0cd0eeb5ca95cea9 => xc7c8ca940d0bde59;

	internal xc5f6f2ca0aafd220()
	{
		xc7c8ca940d0bde59 = new x0cd0eeb5ca95cea9();
	}

	internal xc5f6f2ca0aafd220(LoadOptions loadOptions)
		: this(loadOptions.ResourceLoadingCallback)
	{
		xa056586c1f99e199 = loadOptions.WarningCallback;
	}

	internal xc5f6f2ca0aafd220(IResourceLoadingCallback resourceLoadingCallback)
	{
		xc7c8ca940d0bde59 = new x0cd0eeb5ca95cea9(resourceLoadingCallback);
	}

	internal void x06b0e25aa6ad68a9(Stream xcf18e5243f8d5fd3, Encoding xff3edc9aa5f0523b, Document x6beba47238e0ade6)
	{
		x06b0e25aa6ad68a9(xcf18e5243f8d5fd3, xff3edc9aa5f0523b, new DocumentBuilder(x6beba47238e0ade6));
	}

	internal void x06b0e25aa6ad68a9(Stream xcf18e5243f8d5fd3, Encoding xff3edc9aa5f0523b, DocumentBuilder xd07ce4b74c5774a7)
	{
		if (xff3edc9aa5f0523b == null)
		{
			x53dc82a419732f24 x53dc82a419732f = new x53dc82a419732f24();
			xff3edc9aa5f0523b = x53dc82a419732f.xdef7f68a22ec051d(xcf18e5243f8d5fd3).Encoding;
			if (xff3edc9aa5f0523b == null)
			{
				xff3edc9aa5f0523b = Encoding.UTF8;
			}
		}
		xce9c5b0a9b7b658c xce9c5b0a9b7b658c = xd586e0c16bdae7fc(xd07ce4b74c5774a7);
		xce9c5b0a9b7b658c.x5d95f5f98c940295(xcf18e5243f8d5fd3, xff3edc9aa5f0523b);
		xe7b44b122fc48755(xce9c5b0a9b7b658c.x154bf1cc56c06b95);
	}

	internal void x06b0e25aa6ad68a9(string x27d6d3ff1b275a1a, DocumentBuilder xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.PushFont();
		xd07ce4b74c5774a7.Font.ClearFormatting();
		xce9c5b0a9b7b658c xce9c5b0a9b7b658c = xd586e0c16bdae7fc(xd07ce4b74c5774a7);
		xce9c5b0a9b7b658c.xd82c42838030fa49(x27d6d3ff1b275a1a);
		xe7b44b122fc48755(xce9c5b0a9b7b658c.x154bf1cc56c06b95);
		xd07ce4b74c5774a7.PopFont();
		x07f87e486646174a(x9f03c363c4dd4c18: true);
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Html, xc2358fbac7da3d45));
		}
	}

	internal void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, xc2358fbac7da3d45);
	}

	private xce9c5b0a9b7b658c xd586e0c16bdae7fc(DocumentBuilder xd07ce4b74c5774a7)
	{
		x800085dd555f7711 = xd07ce4b74c5774a7;
		x62ff3dabf0a6c41f = xd07ce4b74c5774a7.Document.xb93d084d48e486dd;
		if (x62ff3dabf0a6c41f == null)
		{
			x62ff3dabf0a6c41f = string.Empty;
		}
		return new xce9c5b0a9b7b658c();
	}

	private void x5eb161ba463fc913(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		xe7b44b122fc48755(xda5bf54deb817e37);
	}

	void xc118baa3bc102199.x53ed331c1f3b8fda(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x5eb161ba463fc913
		this.x5eb161ba463fc913(xda5bf54deb817e37);
	}

	private void xe7b44b122fc48755(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		x643a80721ea71892(xda5bf54deb817e37);
		xd873da8d8a81b465();
		xca9ad4a20a9617e7(xda5bf54deb817e37);
	}

	private void x643a80721ea71892(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		x6f30b9de400ab259(xda5bf54deb817e37);
		for (int i = 0; i < xda5bf54deb817e37.x8898b61a98eb027f.xd44988f225497f3a; i++)
		{
			x643a80721ea71892(xda5bf54deb817e37.x8898b61a98eb027f.get_xe6d4b1b411ed94b5(i));
		}
	}

	private void x6f30b9de400ab259(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37.x1b809103b90e9c4f == x8be2136363630db4.x2dcc7207ee287dbb)
		{
			switch (xda5bf54deb817e37.x759aa16c2016a289)
			{
			case "style":
				x87a544229f82616c(xda5bf54deb817e37);
				break;
			case "link":
				x4302abe245c35953(xda5bf54deb817e37);
				break;
			case "base":
				x62ff3dabf0a6c41f = x2eb961e1e9c44511(xda5bf54deb817e37, "href");
				break;
			}
		}
	}

	private void x87a544229f82616c(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		if (x0d299f323d241756.x90637a473b1ceaaa(xda5bf54deb817e37.x75658b3f8be4005c("type", "text/css"), "text/css"))
		{
			x60c9fd7f08568188(xda5bf54deb817e37.xfdc36fc0993ac5e4, null, x62ff3dabf0a6c41f);
		}
	}

	private void x4302abe245c35953(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		if (x0d299f323d241756.x90637a473b1ceaaa(xda5bf54deb817e37.x75658b3f8be4005c("type", "text/css"), "text/css") && x0d299f323d241756.x90637a473b1ceaaa(xda5bf54deb817e37.x75658b3f8be4005c("rel", ""), "stylesheet"))
		{
			string text = x2eb961e1e9c44511(xda5bf54deb817e37, "href");
			if (text.Length > 0)
			{
				string text2 = x0d4d45882065c63e.x53d54e96515ee37d(x62ff3dabf0a6c41f, text);
				string x04d36c684aaf6f = x0cd0eeb5ca95cea9.xfef1b21403df783d(x62ff3dabf0a6c41f, text);
				x60c9fd7f08568188(x04d36c684aaf6f, text2, x0d4d45882065c63e.xad7c54e85c011ae5(text2));
			}
		}
	}

	private void x60c9fd7f08568188(string x04d36c684aaf6f89, string xbda579af315c6893, string x50fc2dc03ef1fe05)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x04d36c684aaf6f89))
		{
			if (x6de74d3075f0cd04 == null)
			{
				x6de74d3075f0cd04 = new x7778af522baacfda(x800085dd555f7711.Document, xc7c8ca940d0bde59);
			}
			x6de74d3075f0cd04.x60c9fd7f08568188(x04d36c684aaf6f89, xbda579af315c6893, x50fc2dc03ef1fe05);
		}
	}

	private void xd873da8d8a81b465()
	{
		if (x6de74d3075f0cd04 != null)
		{
			x6de74d3075f0cd04.xd873da8d8a81b465();
		}
	}

	private void xca9ad4a20a9617e7(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		if (xd01fc8d304d05d80(xda5bf54deb817e37, xa59013d234619c58: true))
		{
			for (int i = 0; i < xda5bf54deb817e37.x8898b61a98eb027f.xd44988f225497f3a; i++)
			{
				xca9ad4a20a9617e7(xda5bf54deb817e37.x8898b61a98eb027f.get_xe6d4b1b411ed94b5(i));
			}
			xd01fc8d304d05d80(xda5bf54deb817e37, xa59013d234619c58: false);
		}
	}

	private bool xd01fc8d304d05d80(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		switch (xda5bf54deb817e37.x1b809103b90e9c4f)
		{
		case x8be2136363630db4.x2dcc7207ee287dbb:
			return x501416f35422f0c6(xda5bf54deb817e37, xa59013d234619c58);
		case x8be2136363630db4.xf9ad6fb78355fe13:
			if (xa59013d234619c58)
			{
				xc985a8fb9de71d16((x5ed0803b99b17b70)xda5bf54deb817e37);
			}
			return true;
		default:
			return true;
		}
	}

	private bool x501416f35422f0c6(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (!xa59013d234619c58)
		{
			x9f607cbbca4f7b86();
		}
		bool result = x4b9eb3fda3482750(xda5bf54deb817e37, xa59013d234619c58);
		if (xa59013d234619c58)
		{
			x19f1ea59c01764f9(x800085dd555f7711.Font, xda5bf54deb817e37);
		}
		if (xa59013d234619c58 && x6de74d3075f0cd04 != null)
		{
			Style style = x6de74d3075f0cd04.xded912b09294bdf7(xda5bf54deb817e37.x759aa16c2016a289, xda5bf54deb817e37.x75658b3f8be4005c("class", string.Empty));
			if (style != null)
			{
				switch (style.Type)
				{
				case StyleType.Character:
					x800085dd555f7711.Font.Style = style;
					x2838f69315bb2f71(style.Font.Bidi);
					x800085dd555f7711.Font.Bidi = x873e05307b5dc5b5();
					break;
				case StyleType.Paragraph:
					x800085dd555f7711.ParagraphFormat.Style = style;
					x800085dd555f7711.ParagraphFormat.Bidi = xa0f128db6274f1c8(style.ParagraphFormat.Bidi);
					x800085dd555f7711.Font.Bidi = x711cb9f101fe04ce();
					break;
				}
			}
		}
		return result;
	}

	private bool x4b9eb3fda3482750(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		switch (xda5bf54deb817e37.x759aa16c2016a289)
		{
		case "b":
		case "big":
		case "em":
		case "i":
		case "s":
		case "small":
		case "strike":
		case "strong":
		case "sub":
		case "sup":
		case "tt":
		case "u":
		case "span":
		case "font":
			x19b1a63d9b3f797e(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "ins":
			x34b44ee2b1a2c379(xda5bf54deb817e37, x91bb72ac77aa7230.xf059562f878b500e, xa59013d234619c58);
			return true;
		case "del":
			x34b44ee2b1a2c379(xda5bf54deb817e37, x91bb72ac77aa7230.x1f522a512716a2ae, xa59013d234619c58);
			return true;
		case "input":
			if (xa59013d234619c58)
			{
				xece0d3e774310063(xda5bf54deb817e37);
			}
			return true;
		case "select":
			x67c3b63c2f5948eb(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "option":
			x57996f53789bfaa3(xda5bf54deb817e37, xa59013d234619c58);
			return false;
		case "a":
			x4e90493dab0afd96(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "br":
			if (xa59013d234619c58)
			{
				x283559d52017a418(xda5bf54deb817e37);
			}
			return true;
		case "ul":
		case "ol":
			xc3c49dee0351ef2c(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "img":
			if (xa59013d234619c58)
			{
				xd73b0246e62da7ff(xda5bf54deb817e37);
			}
			return true;
		case "body":
			xd7c937bd00c337e9(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "p":
		case "h1":
		case "h2":
		case "h3":
		case "h4":
		case "h5":
		case "h6":
			x499131ad9825b746(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "center":
			xc62635a47c126487(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "div":
			x748696e8240b1ee3(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "li":
			x4af14c17d019378d(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "pre":
			x6562e2083745c60a(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "hr":
			if (xa59013d234619c58)
			{
				x299f86a56d43eb79(xda5bf54deb817e37);
			}
			return true;
		case "table":
		{
			if (x800085dd555f7711.ParagraphFormat.IsListItem && !x2e572df84dee9bea && x800085dd555f7711.IsAtStartOfParagraph)
			{
				x800085dd555f7711.InsertParagraph();
			}
			xdc55f1d401c8fec5 = 0.0;
			string alignment = x495fdb45f3d92b70.x7f90501c33a75aa6((ParagraphAlignment)x289160346e2ab743.Peek());
			bool x4e90add18a = x99f7ec70d9b06596 == 0;
			x99f7ec70d9b06596++;
			new xbcfc3a3bbf12a494(x800085dd555f7711, alignment, this).x5b7cc3ed4565d299(xda5bf54deb817e37, x4e90add18a);
			x99f7ec70d9b06596--;
			return false;
		}
		case "th":
			x2ef5c0ed1641a224(xda5bf54deb817e37, xa59013d234619c58, x59c6d00e0898f6b8: true);
			return true;
		case "td":
			x2ef5c0ed1641a224(xda5bf54deb817e37, xa59013d234619c58, x59c6d00e0898f6b8: false);
			return true;
		case "html":
			xd39c224039ff08fa(xda5bf54deb817e37, xa59013d234619c58);
			return true;
		case "head":
			return true;
		case "title":
			if (xa59013d234619c58)
			{
				x800085dd555f7711.Document.BuiltInDocumentProperties["Title"].xb0c325557cbfd6d3(xda5bf54deb817e37.xfdc36fc0993ac5e4);
			}
			return false;
		case "meta":
			if (xa59013d234619c58)
			{
				x72fcd2ca0e351eae(xda5bf54deb817e37);
			}
			return false;
		case "base":
			if (xa59013d234619c58)
			{
				x62ff3dabf0a6c41f = x2eb961e1e9c44511(xda5bf54deb817e37, "href");
			}
			return false;
		case "caption":
		case "script":
		case "style":
		case "link":
			return false;
		default:
			return true;
		}
	}

	private void xd39c224039ff08fa(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (xa59013d234619c58)
		{
			xa52974e202c7f831(xda5bf54deb817e37.x75658b3f8be4005c("dir", "ltr"));
		}
		else
		{
			x56eaaac1a29f6398();
		}
	}

	private void xd7c937bd00c337e9(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (!xa59013d234619c58)
		{
			x800085dd555f7711.PopFont();
			x56eaaac1a29f6398();
			return;
		}
		x800085dd555f7711.PushFont();
		x800085dd555f7711.Font.Bidi = xa52974e202c7f831(xda5bf54deb817e37.x75658b3f8be4005c("dir", ""));
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		string text = x664c130a09af677a(xda5bf54deb817e37);
		if (text.Length != 0)
		{
			Shading shading = new Shading();
			xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6(text);
			xedac08b4826d3056 xedac08b4826d = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5("background-color");
			if (xedac08b4826d != null)
			{
				x4ce5248b91d2fbf7.x6392b9ac6bc562f4("background-color", xedac08b4826d, shading);
				x26d9ecb4bdf0456d = shading.x0e18178ac4b2272f;
			}
			else
			{
				xedac08b4826d3056 xedac08b4826d2 = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5("background");
				if (xedac08b4826d2 != null)
				{
					x4ce5248b91d2fbf7.x6392b9ac6bc562f4("background", xedac08b4826d2, shading);
					x26d9ecb4bdf0456d = shading.x0e18178ac4b2272f;
				}
			}
			xedac08b4826d3056 xedac08b4826d3 = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5("direction");
			if (xedac08b4826d3 != null)
			{
				x800085dd555f7711.Font.Bidi = xa0f128db6274f1c8(xedac08b4826d3.x48112399d54b30c7());
			}
		}
		if (x26d9ecb4bdf0456d.x7149c962c02931b3)
		{
			string text2 = xda5bf54deb817e37.x75658b3f8be4005c("bgcolor", "");
			if (text2.Length != 0)
			{
				x26d9ecb4bdf0456d = x495fdb45f3d92b70.x722b70a5a6410b8c(text2);
			}
		}
		if (!x26d9ecb4bdf0456d.x7149c962c02931b3)
		{
			x800085dd555f7711.Document.PageColor = x26d9ecb4bdf0456d.xc7656a130b2889c7();
		}
	}

	private void x34b44ee2b1a2c379(x9d6b37cac59aa2e2 xda5bf54deb817e37, x91bb72ac77aa7230 x5250f5bb8e8df781, bool xa59013d234619c58)
	{
		if (xa59013d234619c58)
		{
			string author = xda5bf54deb817e37.x75658b3f8be4005c("cite", "");
			DateTime dateTime = xca004f56614e2431.x70982613fd6240f9(xda5bf54deb817e37.x75658b3f8be4005c("datetime", ""));
			xc1b2bac943a0f541 xc1b2bac943a0f = new xc1b2bac943a0f541(x5250f5bb8e8df781, author, dateTime);
			x19babaa6d05c2c60.Push(xc1b2bac943a0f);
			xbca51c317bf2e883(xc1b2bac943a0f, x316ea6fef76fac6e: false);
		}
		else if (x19babaa6d05c2c60.Count > 0)
		{
			xbca51c317bf2e883((xc1b2bac943a0f541)x19babaa6d05c2c60.Pop(), x316ea6fef76fac6e: true);
		}
	}

	private void xbca51c317bf2e883(xc1b2bac943a0f541 xde2016e90885f436, bool x316ea6fef76fac6e)
	{
		xeedad81aaed42a76 xeedad81aaed42a = x800085dd555f7711.xdbd6535b15eacda9();
		int xba08ce632055a1d = ((xde2016e90885f436.x3146d638ec378671 == x91bb72ac77aa7230.xf059562f878b500e) ? 14 : 12);
		if (x316ea6fef76fac6e)
		{
			xeedad81aaed42a.x52b190e626f65140(xba08ce632055a1d);
		}
		else
		{
			xeedad81aaed42a.xd00aa8389522ce53(xba08ce632055a1d, xde2016e90885f436);
		}
		x800085dd555f7711.x77184348a27ba1e6(xeedad81aaed42a, x692ced34f50137f2: false);
	}

	private void xece0d3e774310063(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		x07f87e486646174a(x9f03c363c4dd4c18: true);
		string name = xda5bf54deb817e37.x75658b3f8be4005c("name", "");
		string text = xda5bf54deb817e37.x75658b3f8be4005c("value", "");
		string text2 = xda5bf54deb817e37.x75658b3f8be4005c("type", "text").ToLower();
		bool flag = xda5bf54deb817e37.xf9ca4ea3f3bfac5b.get_xe6d4b1b411ed94b5("disabled") != null;
		switch (text2)
		{
		case "radio":
		{
			Shape shape = new Shape(x800085dd555f7711.Document, ShapeType.Ellipse);
			shape.Width = 9.0;
			shape.Height = 9.0;
			shape.WrapType = WrapType.Inline;
			x800085dd555f7711.CurrentParagraph.AppendChild(shape);
			x800085dd555f7711.Write("  ");
			return;
		}
		case "checkbox":
		{
			bool defaultValue = xda5bf54deb817e37.xf9ca4ea3f3bfac5b.get_xe6d4b1b411ed94b5("checked") != null;
			FormField formField = x800085dd555f7711.InsertCheckBox(name, defaultValue, x15e971129fd80714.x43fcc3f62534530b(x800085dd555f7711.Font.Size));
			formField.Enabled = !flag;
			return;
		}
		case "reset":
			x800085dd555f7711.InsertField("MACROBUTTON ResetFormField [" + text + "]");
			return;
		case "submit":
		case "button":
			x800085dd555f7711.InsertField("MACROBUTTON DoFieldClick  [" + text + "]");
			return;
		case "image":
			xd73b0246e62da7ff(xda5bf54deb817e37);
			return;
		case "hidden":
			return;
		}
		int maxLength = xda5bf54deb817e37.x75658b3f8be4005c("maxlength", 0);
		bool flag2 = xda5bf54deb817e37.xf9ca4ea3f3bfac5b.get_xe6d4b1b411ed94b5("readonly") != null;
		FormField formField2 = x800085dd555f7711.InsertTextInput(name, TextFormFieldType.Regular, "", text, maxLength);
		formField2.Enabled = !flag && !flag2;
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			formField2.xd1b40af56a8385d4.Result = FormField.xb8fa1e789c415fba;
		}
	}

	private void x67c3b63c2f5948eb(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (xa59013d234619c58)
		{
			x07f87e486646174a(x9f03c363c4dd4c18: true);
			string name = xda5bf54deb817e37.x75658b3f8be4005c("name", "checkbox");
			x632061204aa8c20b = x800085dd555f7711.InsertComboBox(name, new string[1] { "" }, 0);
			x632061204aa8c20b.DropDownItems.Clear();
			x632061204aa8c20b.Enabled = true;
		}
		else
		{
			x632061204aa8c20b = null;
		}
	}

	private void x57996f53789bfaa3(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (!xa59013d234619c58 || x632061204aa8c20b == null || xda5bf54deb817e37.xf9ca4ea3f3bfac5b.get_xe6d4b1b411ed94b5("disabled") != null)
		{
			return;
		}
		string text = xda5bf54deb817e37.x75658b3f8be4005c("label", "");
		string text2 = ((text.Length > 0) ? text : x495fdb45f3d92b70.xf0c7bb08a8616ee4(xda5bf54deb817e37.xfdc36fc0993ac5e4, x4ff8b171363c7c38: true));
		bool flag = xda5bf54deb817e37.xf9ca4ea3f3bfac5b.get_xe6d4b1b411ed94b5("selected") != null;
		if (x632061204aa8c20b.DropDownItems.Count < 25)
		{
			x632061204aa8c20b.DropDownItems.Add(text2);
		}
		else
		{
			string arg = text2;
			if (flag)
			{
				arg = x632061204aa8c20b.DropDownItems[24];
				x632061204aa8c20b.DropDownItems[24] = text2;
			}
			xbbf9a1ead81dd3a1(WarningType.DataLoss, $"Item \"{arg}\" has been lost while adding DropDown elements.");
		}
		if (flag)
		{
			x632061204aa8c20b.DropDownSelectedIndex = x632061204aa8c20b.DropDownItems.Count - 1;
		}
	}

	private void xc985a8fb9de71d16(x5ed0803b99b17b70 xda5bf54deb817e37)
	{
		if (!x9145869b450617d6)
		{
			bool x4ff8b171363c7c = xcce49fb52a4dacc7 || x800085dd555f7711.IsAtStartOfParagraph || x23f78141b773d807();
			string text = x495fdb45f3d92b70.xf0c7bb08a8616ee4(xda5bf54deb817e37.xf9ad6fb78355fe13, x4ff8b171363c7c);
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				x07f87e486646174a(x9f03c363c4dd4c18: true);
				x9ddd1edda036fe69(text);
			}
		}
		else
		{
			x9ddd1edda036fe69(xda5bf54deb817e37.xf9ad6fb78355fe13);
		}
	}

	private void x9ddd1edda036fe69(string xb41faee6912a2313)
	{
		if (x873e05307b5dc5b5())
		{
			if (xb41faee6912a2313[0] != '\u202b')
			{
				xb41faee6912a2313 = '\u202b' + xb41faee6912a2313 + '\u202c';
			}
			ArrayList arrayList = xc43925ba6f2dd66c.xcd89c6dd6a1b87e6(xb41faee6912a2313);
			for (int i = 0; i < arrayList.Count; i++)
			{
				x6ec39b1b0c66f918[] xdcff38cbdd9cf = ((xc43925ba6f2dd66c)arrayList[i]).xdcff38cbdd9cf395;
				for (int j = 0; j < xdcff38cbdd9cf.Length; j++)
				{
					int num = (x711cb9f101fe04ce() ? j : (xdcff38cbdd9cf.Length - j - 1));
					x800085dd555f7711.Font.Bidi = xdcff38cbdd9cf[num].x0b228ef3d2b6a257;
					x800085dd555f7711.Write(xdcff38cbdd9cf[num].xf9ad6fb78355fe13);
				}
				if (((xc43925ba6f2dd66c)arrayList[i]).x05db5df9789b24d9 != "")
				{
					x800085dd555f7711.InsertParagraph();
				}
			}
			x800085dd555f7711.Font.Bidi = x873e05307b5dc5b5();
		}
		else
		{
			x800085dd555f7711.Write(xb41faee6912a2313);
		}
	}

	private void x07f87e486646174a(bool x9f03c363c4dd4c18)
	{
		if (xcce49fb52a4dacc7)
		{
			xcf4773b9ca735a8a(null, x9f03c363c4dd4c18);
		}
	}

	private bool x23f78141b773d807()
	{
		Node currentNode = x800085dd555f7711.CurrentNode;
		Paragraph currentParagraph = x800085dd555f7711.CurrentParagraph;
		Run run = null;
		Node node = ((xd193f2c3d56c63aa != null && currentParagraph == xd193f2c3d56c63aa.ParentNode) ? xd193f2c3d56c63aa : currentParagraph.FirstChild);
		for (Node node2 = node; node2 != currentNode; node2 = node2.NextSibling)
		{
			if (node2.NodeType == NodeType.Run)
			{
				run = (Run)node2;
			}
		}
		xd193f2c3d56c63aa = run;
		bool result = false;
		if (run != null)
		{
			string text = run.GetText();
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				char c = text[text.Length - 1];
				result = c == ' ' || c == '\v' || c == '\f';
			}
		}
		return result;
	}

	private void xcf4773b9ca735a8a(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool x9f03c363c4dd4c18)
	{
		xcce49fb52a4dacc7 = false;
		x2e572df84dee9bea = false;
		bool isAtStartOfParagraph = x800085dd555f7711.IsAtStartOfParagraph;
		if (!isAtStartOfParagraph)
		{
			x800085dd555f7711.InsertParagraph();
		}
		ParagraphAlignment paragraphAlignment = (ParagraphAlignment)x289160346e2ab743.Peek();
		if (paragraphAlignment != 0 || x800085dd555f7711.ParagraphFormat.x93a65560cc2296a9(1020))
		{
			x800085dd555f7711.ParagraphFormat.Alignment = paragraphAlignment;
		}
		bool flag = x800085dd555f7711.ParagraphFormat.x93a65560cc2296a9(1020);
		ParagraphAlignment alignment = x800085dd555f7711.ParagraphFormat.Alignment;
		int x71c63f7e57f7ede = x800085dd555f7711.ParagraphFormat.x71c63f7e57f7ede5;
		ListLevel listLevel = ((x71c63f7e57f7ede != 0 && !isAtStartOfParagraph && x1a1696de1c96ba31 != null) ? x1a1696de1c96ba31.x6798e661271685a9.ListLevels[x1a1696de1c96ba31.x51e5bb947db89a97] : null);
		x800085dd555f7711.ParagraphFormat.ClearFormatting();
		if (x7bd4cdc3676c2aab.Count != 0)
		{
			if (x71c63f7e57f7ede != 0)
			{
				if (isAtStartOfParagraph)
				{
					x800085dd555f7711.ParagraphFormat.x71c63f7e57f7ede5 = x71c63f7e57f7ede;
				}
				else
				{
					xdc55f1d401c8fec5 = listLevel.TextPosition;
					x800085dd555f7711.ParagraphFormat.LeftIndent = xdc55f1d401c8fec5;
				}
			}
			else if (xdc55f1d401c8fec5 != 0.0)
			{
				x800085dd555f7711.ParagraphFormat.LeftIndent = xdc55f1d401c8fec5;
			}
		}
		if (flag)
		{
			x800085dd555f7711.ParagraphFormat.Alignment = alignment;
		}
		x800085dd555f7711.ParagraphFormat.Bidi = x711cb9f101fe04ce();
		string text = ((xda5bf54deb817e37 != null) ? xda5bf54deb817e37.x75658b3f8be4005c("align", "") : "");
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x800085dd555f7711.ParagraphFormat.Alignment = x495fdb45f3d92b70.xa9a738046a9a4faa(text);
		}
		if (xda5bf54deb817e37 != null)
		{
			x800085dd555f7711.ParagraphFormat.Bidi = xa52974e202c7f831(xda5bf54deb817e37.x75658b3f8be4005c("dir", ""));
			x800085dd555f7711.PushFont();
			x800085dd555f7711.Font.Bidi = x711cb9f101fe04ce();
		}
		if (x9f03c363c4dd4c18)
		{
			x58e9991d3e1ee2f1();
		}
	}

	private void xeb168a2607fbbd1a(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37.x024a13cfae9ff232)
		{
			xcce49fb52a4dacc7 = true;
		}
		x800085dd555f7711.PopFont();
		x56eaaac1a29f6398();
	}

	private void x58e9991d3e1ee2f1()
	{
		x800085dd555f7711.ParagraphFormat.SpaceAfterAuto = true;
		x800085dd555f7711.ParagraphFormat.SpaceAfter = 14.0;
	}

	private void xd3148ca58672a2c8()
	{
		x800085dd555f7711.ParagraphFormat.SpaceAfterAuto = false;
		x800085dd555f7711.ParagraphFormat.SpaceAfter = 0.0;
	}

	private void x748696e8240b1ee3(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (xa59013d234619c58)
		{
			if (x6de74d3075f0cd04 != null)
			{
				x6de74d3075f0cd04.xd44cab19179e2eee(xda5bf54deb817e37.x75658b3f8be4005c("class", string.Empty), x800085dd555f7711.CurrentSection.PageSetup);
			}
			x289160346e2ab743.Push(x495fdb45f3d92b70.xa9a738046a9a4faa(xda5bf54deb817e37.x75658b3f8be4005c("align", "left")));
			xcf4773b9ca735a8a(xda5bf54deb817e37, x9f03c363c4dd4c18: false);
		}
		else
		{
			xeb168a2607fbbd1a(xda5bf54deb817e37);
			x289160346e2ab743.Pop();
		}
	}

	private void x4af14c17d019378d(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (xa59013d234619c58)
		{
			xcf4773b9ca735a8a(xda5bf54deb817e37, x9f03c363c4dd4c18: true);
			if (x1a1696de1c96ba31 != null)
			{
				x1a1696de1c96ba31.xcbea96666365f182(xda5bf54deb817e37);
			}
			xc559673761f886b5(xda5bf54deb817e37);
			return;
		}
		if (!x2e572df84dee9bea && x800085dd555f7711.IsAtStartOfParagraph)
		{
			x800085dd555f7711.InsertParagraph();
		}
		if (x800085dd555f7711.ParagraphFormat.IsListItem)
		{
			xd3148ca58672a2c8();
		}
		xdc55f1d401c8fec5 = 0.0;
		xeb168a2607fbbd1a(xda5bf54deb817e37);
	}

	private void x499131ad9825b746(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (xa59013d234619c58)
		{
			xcf4773b9ca735a8a(xda5bf54deb817e37, x9f03c363c4dd4c18: true);
			string x759aa16c2016a = xda5bf54deb817e37.x759aa16c2016a289;
			switch (x759aa16c2016a)
			{
			case "h1":
				x800085dd555f7711.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading1;
				break;
			case "h2":
				x800085dd555f7711.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading2;
				break;
			case "h3":
				x800085dd555f7711.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading3;
				break;
			case "h4":
				x800085dd555f7711.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading4;
				break;
			case "h5":
				x800085dd555f7711.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading5;
				break;
			case "h6":
				x800085dd555f7711.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading6;
				break;
			default:
				x3dc950453374051a(x759aa16c2016a);
				break;
			case "p":
				break;
			}
			xc559673761f886b5(xda5bf54deb817e37);
		}
		else
		{
			xeb168a2607fbbd1a(xda5bf54deb817e37);
		}
	}

	private void xc62635a47c126487(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (xa59013d234619c58)
		{
			x289160346e2ab743.Push(ParagraphAlignment.Center);
			xcf4773b9ca735a8a(xda5bf54deb817e37, x9f03c363c4dd4c18: true);
		}
		else
		{
			xeb168a2607fbbd1a(xda5bf54deb817e37);
			x289160346e2ab743.Pop();
		}
	}

	private void x6562e2083745c60a(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (xa59013d234619c58)
		{
			xcf4773b9ca735a8a(xda5bf54deb817e37, x9f03c363c4dd4c18: false);
			x9145869b450617d6 = true;
			x800085dd555f7711.Font.Name = "Courier New";
			xc559673761f886b5(xda5bf54deb817e37);
		}
		else
		{
			x9145869b450617d6 = false;
			xeb168a2607fbbd1a(xda5bf54deb817e37);
		}
	}

	private void xc559673761f886b5(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		x4edf5a654b83812d.xe7ce6487f5f217d1(x664c130a09af677a(xda5bf54deb817e37), x800085dd555f7711.ParagraphFormat);
	}

	private void x2ef5c0ed1641a224(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58, bool x59c6d00e0898f6b8)
	{
		if (x99f7ec70d9b06596 == 0)
		{
			return;
		}
		if (xa59013d234619c58)
		{
			ParagraphAlignment x7717e14a = ParagraphAlignment.Left;
			if (x59c6d00e0898f6b8)
			{
				x800085dd555f7711.PushFont();
				x800085dd555f7711.Bold = true;
				x7717e14a = ParagraphAlignment.Center;
			}
			if (!x495fdb45f3d92b70.x365021ddf20e0498(xda5bf54deb817e37, ref x7717e14a))
			{
				x495fdb45f3d92b70.x365021ddf20e0498(xda5bf54deb817e37.xc2cedc613dfc915b, ref x7717e14a);
			}
			x289160346e2ab743.Push(x7717e14a);
			xcf4773b9ca735a8a(xda5bf54deb817e37, x9f03c363c4dd4c18: true);
		}
		else
		{
			xeb168a2607fbbd1a(xda5bf54deb817e37);
			x289160346e2ab743.Pop();
			if (x59c6d00e0898f6b8)
			{
				x800085dd555f7711.PopFont();
			}
			xd3148ca58672a2c8();
		}
	}

	private void x4e90493dab0afd96(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		string text = x2eb961e1e9c44511(xda5bf54deb817e37, "href");
		string text2 = xda5bf54deb817e37.x75658b3f8be4005c("name", "");
		if (!x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			text2 = xda5bf54deb817e37.x75658b3f8be4005c("id", "");
		}
		if (xa59013d234619c58)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				string x11d58b056c032b = x2eb961e1e9c44511(xda5bf54deb817e37, "target");
				x800085dd555f7711.xb67b015f1a2f38a7(text, x11d58b056c032b);
				x800085dd555f7711.PushFont();
				x800085dd555f7711.Font.x63b1a7c31a962459 = x26d9ecb4bdf0456d.xe3a106a4c00973e3;
				x800085dd555f7711.Font.Underline = Underline.Single;
				x800085dd555f7711.Font.Bidi = xd83e33e7758cca1a(xda5bf54deb817e37.x75658b3f8be4005c("dir", ""));
			}
			if (x0d299f323d241756.x5959bccb67bbf051(text2))
			{
				x800085dd555f7711.StartBookmark(text2);
			}
		}
		else
		{
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				xc1c90bad06794ddb();
				x800085dd555f7711.PopFont();
				x800085dd555f7711.xbfa3ad37f5032b4f();
			}
			if (x0d299f323d241756.x5959bccb67bbf051(text2))
			{
				x800085dd555f7711.EndBookmark(text2);
			}
		}
	}

	private void x72fcd2ca0e351eae(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		string x19218ffab70283ef = xda5bf54deb817e37.x75658b3f8be4005c("name", "");
		string xbcea506a33cf = xda5bf54deb817e37.x75658b3f8be4005c("content", "");
		if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "description"))
		{
			x800085dd555f7711.Document.BuiltInDocumentProperties["Subject"].xb0c325557cbfd6d3(xbcea506a33cf);
		}
		else if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "keywords"))
		{
			x800085dd555f7711.Document.BuiltInDocumentProperties["Keywords"].xb0c325557cbfd6d3(xbcea506a33cf);
		}
	}

	private void x283559d52017a418(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6(x664c130a09af677a(xda5bf54deb817e37));
		string text = xa3fc7dcdc8182ff.xc79ba7b5665427dc("page-break-before").ToLower();
		BreakType breakType = ((!x0d299f323d241756.x90637a473b1ceaaa(xa3fc7dcdc8182ff.xc79ba7b5665427dc("mso-break-type"), "section-break")) ? ((text == "always") ? BreakType.PageBreak : (x0d299f323d241756.x90637a473b1ceaaa(xa3fc7dcdc8182ff.xc79ba7b5665427dc("mso-column-break-before"), "always") ? BreakType.ColumnBreak : BreakType.LineBreak)) : (text switch
		{
			"always" => BreakType.SectionBreakNewPage, 
			"left" => BreakType.SectionBreakEvenPage, 
			"right" => BreakType.SectionBreakOddPage, 
			_ => x0d299f323d241756.x90637a473b1ceaaa(xa3fc7dcdc8182ff.xc79ba7b5665427dc("mso-column-break-before"), "always") ? BreakType.SectionBreakNewColumn : BreakType.SectionBreakContinuous, 
		}));
		if (breakType == BreakType.LineBreak)
		{
			if (x66b614aca076a49c(xda5bf54deb817e37))
			{
				x07f87e486646174a(x9f03c363c4dd4c18: true);
				x800085dd555f7711.xb41fed203ad7c94f(breakType, x291fabf8727e1df6: false);
			}
			else if (xbba0b02dfd4033b8(xda5bf54deb817e37))
			{
				x07f87e486646174a(x9f03c363c4dd4c18: false);
				x2e572df84dee9bea = true;
				x800085dd555f7711.InsertParagraph();
			}
		}
		else
		{
			xcce49fb52a4dacc7 = false;
			x800085dd555f7711.xb41fed203ad7c94f(breakType, x291fabf8727e1df6: false);
		}
	}

	private bool xbba0b02dfd4033b8(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		x9d6b37cac59aa2e2 x9d6b37cac59aa2e = xda5bf54deb817e37;
		while ((x9d6b37cac59aa2e = x9d6b37cac59aa2e.xdf54af9a52918039) != null)
		{
			if (x7a05584a90862657(x9d6b37cac59aa2e))
			{
				return false;
			}
			if (x9d6b37cac59aa2e.x1b809103b90e9c4f == x8be2136363630db4.x2dcc7207ee287dbb)
			{
				break;
			}
		}
		x9d6b37cac59aa2e2 x9d6b37cac59aa2e2 = xda5bf54deb817e37;
		while ((x9d6b37cac59aa2e2 = x9d6b37cac59aa2e2.x1f3ed48ef81a3a47) != null)
		{
			if (x7a05584a90862657(x9d6b37cac59aa2e2))
			{
				return false;
			}
			if (x9d6b37cac59aa2e2.x1b809103b90e9c4f == x8be2136363630db4.x2dcc7207ee287dbb)
			{
				break;
			}
		}
		return true;
	}

	private bool x7a05584a90862657(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		return xda5bf54deb817e37.x1b809103b90e9c4f switch
		{
			x8be2136363630db4.xf9ad6fb78355fe13 => !x495fdb45f3d92b70.x9ecc47300149e587(xda5bf54deb817e37.xfdc36fc0993ac5e4), 
			x8be2136363630db4.x2dcc7207ee287dbb => x4e17596495bdb6e2(xda5bf54deb817e37), 
			_ => false, 
		};
	}

	private bool x66b614aca076a49c(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		x9d6b37cac59aa2e2 x9d6b37cac59aa2e = xda5bf54deb817e37;
		while ((x9d6b37cac59aa2e = x9d6b37cac59aa2e.xdf54af9a52918039) != null)
		{
			if (x9d6b37cac59aa2e.x759aa16c2016a289 == "style")
			{
				continue;
			}
			if (x9d6b37cac59aa2e.x1b809103b90e9c4f == x8be2136363630db4.x2dcc7207ee287dbb)
			{
				if (!x4e17596495bdb6e2(x9d6b37cac59aa2e))
				{
					break;
				}
				return true;
			}
			if (x9d6b37cac59aa2e.x1b809103b90e9c4f == x8be2136363630db4.xf9ad6fb78355fe13 && !x495fdb45f3d92b70.x9ecc47300149e587(x9d6b37cac59aa2e.xfdc36fc0993ac5e4))
			{
				return true;
			}
		}
		x9d6b37cac59aa2e2 xc2cedc613dfc915b = xda5bf54deb817e37.xc2cedc613dfc915b;
		if (xc2cedc613dfc915b != null && x4e17596495bdb6e2(xc2cedc613dfc915b))
		{
			return x66b614aca076a49c(xc2cedc613dfc915b);
		}
		return false;
	}

	private bool x4e17596495bdb6e2(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		string x759aa16c2016a = xda5bf54deb817e37.x759aa16c2016a289;
		if (x6de74d3075f0cd04 == null)
		{
			return x7778af522baacfda.xf994bf17bf2ebd41(x759aa16c2016a);
		}
		return x6de74d3075f0cd04.x4e17596495bdb6e2(x759aa16c2016a, xda5bf54deb817e37.x75658b3f8be4005c("class", string.Empty));
	}

	private void xc3c49dee0351ef2c(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		x0d6ae8e5a962fac2 x0d6ae8e5a962fac3 = x1a1696de1c96ba31;
		if (xa59013d234619c58)
		{
			xa52974e202c7f831(xda5bf54deb817e37.x75658b3f8be4005c("dir", ""));
			if (x0d6ae8e5a962fac3 == null)
			{
				x7bd4cdc3676c2aab.Push(new x0d6ae8e5a962fac2(x800085dd555f7711, xda5bf54deb817e37, 0));
			}
			else if (!x0d6ae8e5a962fac3.x038e7b90f8869b95(xda5bf54deb817e37))
			{
				int x51e5bb947db89a = x0d6ae8e5a962fac3.x51e5bb947db89a97;
				x7bd4cdc3676c2aab.Push(new x0d6ae8e5a962fac2(x800085dd555f7711, xda5bf54deb817e37, ListLevel.x0d41ea80cfb16612(x51e5bb947db89a + 1)));
			}
			return;
		}
		if (!x0d6ae8e5a962fac3.x5eb52b44a2d563c0())
		{
			x7bd4cdc3676c2aab.Pop();
			if (x7bd4cdc3676c2aab.Count == 0)
			{
				x58e9991d3e1ee2f1();
			}
		}
		x56eaaac1a29f6398();
	}

	private void x19b1a63d9b3f797e(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		if (xa59013d234619c58)
		{
			x800085dd555f7711.PushFont();
			x800085dd555f7711.Font.Bidi = xd83e33e7758cca1a(xda5bf54deb817e37.x75658b3f8be4005c("dir", ""));
			string x759aa16c2016a = xda5bf54deb817e37.x759aa16c2016a289;
			switch (x759aa16c2016a)
			{
			case "b":
			case "strong":
				x800085dd555f7711.Bold = true;
				x800085dd555f7711.Font.BoldBi = true;
				break;
			case "em":
			case "i":
				x800085dd555f7711.Italic = true;
				x800085dd555f7711.Font.ItalicBi = true;
				break;
			case "s":
			case "strike":
				x800085dd555f7711.Font.StrikeThrough = true;
				break;
			case "sub":
				x800085dd555f7711.Font.Subscript = true;
				break;
			case "sup":
				x800085dd555f7711.Font.Superscript = true;
				break;
			case "tt":
				x800085dd555f7711.Font.Name = "Courier New";
				x800085dd555f7711.Font.NameBi = "Courier New";
				break;
			case "u":
				x800085dd555f7711.Underline = Underline.Single;
				break;
			case "big":
				x800085dd555f7711.Font.Size = x800085dd555f7711.Font.Size * 1.15;
				x800085dd555f7711.Font.SizeBi = x800085dd555f7711.Font.Size * 1.15;
				break;
			case "small":
				x800085dd555f7711.Font.Size = x800085dd555f7711.Font.Size * 0.85;
				x800085dd555f7711.Font.SizeBi = x800085dd555f7711.Font.Size * 0.85;
				break;
			case "font":
				xd01820099757f8ba(xda5bf54deb817e37);
				break;
			default:
				x3dc950453374051a(x759aa16c2016a);
				break;
			case "span":
				break;
			}
			x69e8b423c22edb61.xff280c75a0537411(x664c130a09af677a(xda5bf54deb817e37), x800085dd555f7711.Font, x032ab0a06188d97e: true);
		}
		else
		{
			x800085dd555f7711.Font.Bidi = xc1c90bad06794ddb();
			x800085dd555f7711.PopFont();
		}
	}

	private void xd01820099757f8ba(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		string text = xda5bf54deb817e37.x75658b3f8be4005c("size", "");
		int num = xca004f56614e2431.x912616ee70b2d94d(text);
		if (num != int.MinValue)
		{
			if (text.IndexOfAny(xb6f494893064da69) >= 0)
			{
				num += 3;
			}
			x800085dd555f7711.Font.Size = x495fdb45f3d92b70.xb42d95ae44c48104(num);
		}
		string text2 = xda5bf54deb817e37.x75658b3f8be4005c("face", "");
		if (x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			x800085dd555f7711.Font.Name = text2;
		}
		string xbcea506a33cf = xda5bf54deb817e37.x75658b3f8be4005c("color", "");
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
		{
			x800085dd555f7711.Font.x63b1a7c31a962459 = x495fdb45f3d92b70.x722b70a5a6410b8c(xbcea506a33cf);
		}
	}

	private void xd73b0246e62da7ff(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		string x66fab2e81382593c = xda5bf54deb817e37.x75658b3f8be4005c("src", "");
		byte[] array = x0cd0eeb5ca95cea9.x184a537960bc4865(x62ff3dabf0a6c41f, x66fab2e81382593c);
		Shape shape;
		if (array != null)
		{
			shape = xfd311d4320ddebd9(array);
			if (shape == null)
			{
				shape = xfd311d4320ddebd9(x0cd0eeb5ca95cea9.x2f708ebc1039d3df(x62ff3dabf0a6c41f, x66fab2e81382593c));
			}
			if (shape == null)
			{
				shape = x800085dd555f7711.InsertImage(x0d299f323d241756.xcd6c2a9742c9220a());
			}
		}
		else
		{
			shape = new Shape(x800085dd555f7711.Document, ShapeType.Image);
			shape.WrapType = WrapType.Inline;
			string sourceFullName = x0d4d45882065c63e.x53d54e96515ee37d(x62ff3dabf0a6c41f, x66fab2e81382593c);
			shape.ImageData.SourceFullName = sourceFullName;
			x800085dd555f7711.InsertNode(shape);
		}
		if (xcf315f9c45451fb3(xda5bf54deb817e37.x75658b3f8be4005c("width", ""), out var x8dd0673907b52a1c))
		{
			shape.xf524ccc95fe8e714(ConvertUtil.PixelToPoint(x8dd0673907b52a1c));
		}
		if (xcf315f9c45451fb3(xda5bf54deb817e37.x75658b3f8be4005c("height", ""), out var x8dd0673907b52a1c2))
		{
			shape.x404ab2fc377ad1ed(ConvertUtil.PixelToPoint(x8dd0673907b52a1c2));
		}
	}

	private Shape xfd311d4320ddebd9(byte[] x43e181e083db6cdf)
	{
		try
		{
			return x800085dd555f7711.InsertImage(x43e181e083db6cdf);
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static bool xcf315f9c45451fb3(string xc2d7dc6c2c33055b, out int x8dd0673907b52a1c)
	{
		x8dd0673907b52a1c = 0;
		PreferredWidth preferredWidth = x495fdb45f3d92b70.x844d4319ee50b6d6(xc2d7dc6c2c33055b);
		if (preferredWidth == null)
		{
			return false;
		}
		switch (preferredWidth.Type)
		{
		case PreferredWidthType.Auto:
			return false;
		case PreferredWidthType.Points:
			x8dd0673907b52a1c = x4574ea26106f0edb.xdbd829479885762d(preferredWidth.Value);
			return true;
		case PreferredWidthType.Percent:
			return false;
		default:
			return false;
		}
	}

	private void x299f86a56d43eb79(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		Shape shape = Shape.xb939ebca8a836c60(x800085dd555f7711.Document);
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6(x664c130a09af677a(xda5bf54deb817e37));
		xedac08b4826d3056 xedac08b4826d = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5("width");
		if (xedac08b4826d == null)
		{
			string text = xda5bf54deb817e37.x75658b3f8be4005c("width", string.Empty);
			if (text.Length != 0)
			{
				xedac08b4826d = xedac08b4826d3056.x1f490eac106aee12("width", text);
			}
		}
		if (xedac08b4826d != null)
		{
			if (xedac08b4826d.x73cad9ab753bf0fa == x1e40528755c1f053.x2f7951fa0946af7e)
			{
				shape.x6c285a52cba39f1f.x7037cdd058db3069(xedac08b4826d.x043aafba68f5c559());
				shape.xf524ccc95fe8e714((double)x800085dd555f7711.CurrentSection.PageSetup.x887b872a95caaab5 * shape.x6c285a52cba39f1f.x9472539ef71e166c / 100.0);
			}
			else
			{
				double num = xedac08b4826d.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				if (num >= 0.0)
				{
					shape.xf524ccc95fe8e714(num);
					shape.x6c285a52cba39f1f.x9472539ef71e166c = 0.0;
				}
			}
		}
		xedac08b4826d3056 xedac08b4826d2 = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5("height");
		if (xedac08b4826d2 == null)
		{
			string text2 = xda5bf54deb817e37.x75658b3f8be4005c("size", string.Empty);
			if (text2.Length != 0)
			{
				xedac08b4826d2 = xedac08b4826d3056.x1f490eac106aee12("height", text2);
			}
		}
		if (xedac08b4826d2 != null && xedac08b4826d2.x73cad9ab753bf0fa != x1e40528755c1f053.x2f7951fa0946af7e)
		{
			double num2 = xedac08b4826d2.x1deebb03a3d03a50(x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			if (num2 >= 0.0)
			{
				shape.x404ab2fc377ad1ed(num2);
			}
		}
		string text3 = xa3fc7dcdc8182ff.xc79ba7b5665427dc("text-align");
		if (text3.Length == 0)
		{
			text3 = xda5bf54deb817e37.x75658b3f8be4005c("align", string.Empty);
		}
		shape.x6c285a52cba39f1f.xceaa36575b797b5b = x495fdb45f3d92b70.x76725d46a0c3cb9a(text3);
		if (xda5bf54deb817e37.x75658b3f8be4005c("noshade", null) != null)
		{
			shape.x6c285a52cba39f1f.xeba9aeb9e91e933a = true;
		}
		xedac08b4826d3056 xedac08b4826d3 = xa3fc7dcdc8182ff.get_xe6d4b1b411ed94b5("color");
		if (xedac08b4826d3 == null)
		{
			string text4 = xda5bf54deb817e37.x75658b3f8be4005c("color", "");
			if (text4.Length != 0)
			{
				xedac08b4826d3 = xedac08b4826d3056.x1f490eac106aee12("color", text4);
			}
		}
		if (xedac08b4826d3 != null && xedac08b4826d3.x73cad9ab753bf0fa == x1e40528755c1f053.x9b41425268471380)
		{
			shape.Fill.x63b1a7c31a962459 = xedac08b4826d3.xef50a938c8b9c7fd();
			shape.x6c285a52cba39f1f.xeba9aeb9e91e933a = true;
		}
		x07f87e486646174a(x9f03c363c4dd4c18: false);
		x800085dd555f7711.InsertNode(shape);
		xcce49fb52a4dacc7 = true;
	}

	internal bool xa0f128db6274f1c8(string xbf88eaa7c5e508d5)
	{
		x56eaaac1a29f6398();
		return xa52974e202c7f831(xbf88eaa7c5e508d5);
	}

	private bool xa0f128db6274f1c8(bool x4d21032b3ed37672)
	{
		x56eaaac1a29f6398();
		return xa52974e202c7f831(x4d21032b3ed37672 ? "rtl" : "ltr");
	}

	private void x2838f69315bb2f71(bool x4d21032b3ed37672)
	{
		xc1c90bad06794ddb();
		xd83e33e7758cca1a(x4d21032b3ed37672 ? "rtl" : "ltr");
	}

	private bool xd83e33e7758cca1a(string xbf88eaa7c5e508d5)
	{
		xec412cd4d823f487.Push(x495fdb45f3d92b70.x3732023a3d3acbf8(xbf88eaa7c5e508d5, x873e05307b5dc5b5()));
		return (bool)xec412cd4d823f487.Peek();
	}

	private bool x873e05307b5dc5b5()
	{
		if (xec412cd4d823f487.Count != 0)
		{
			return (bool)xec412cd4d823f487.Peek();
		}
		return x711cb9f101fe04ce();
	}

	private bool xc1c90bad06794ddb()
	{
		if (xec412cd4d823f487.Count != 0)
		{
			return (bool)xec412cd4d823f487.Pop();
		}
		return x711cb9f101fe04ce();
	}

	public bool xa52974e202c7f831(string xbf88eaa7c5e508d5)
	{
		if (x8c369dd4b7b71b4a.Count == 0)
		{
			x8c369dd4b7b71b4a.Push(x495fdb45f3d92b70.x3732023a3d3acbf8(xbf88eaa7c5e508d5, xf0e1f8c39ee2c6f7: false));
		}
		else
		{
			x8c369dd4b7b71b4a.Push(x495fdb45f3d92b70.x3732023a3d3acbf8(xbf88eaa7c5e508d5, x873e05307b5dc5b5()));
		}
		return (bool)x8c369dd4b7b71b4a.Peek();
	}

	public bool x56eaaac1a29f6398()
	{
		if (x8c369dd4b7b71b4a.Count != 0)
		{
			return (bool)x8c369dd4b7b71b4a.Pop();
		}
		return false;
	}

	public bool x711cb9f101fe04ce()
	{
		if (x8c369dd4b7b71b4a.Count != 0)
		{
			return (bool)x8c369dd4b7b71b4a.Peek();
		}
		return false;
	}

	private void x19f1ea59c01764f9(Font x26094932cf7a9139, x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		string text = xda5bf54deb817e37.x75658b3f8be4005c("lang", "");
		if (text != "")
		{
			int num = x495fdb45f3d92b70.xe7d40c349fabe0ed(text);
			if (num != 127)
			{
				if (x873e05307b5dc5b5())
				{
					x26094932cf7a9139.LocaleIdBi = num;
				}
				else
				{
					x26094932cf7a9139.LocaleId = num;
					x26094932cf7a9139.LocaleIdFarEast = num;
				}
				x7c52265a69daa8be.Push(num);
				return;
			}
		}
		x7c52265a69daa8be.Push(xde06b94a6e23a70a());
	}

	private int xde06b94a6e23a70a()
	{
		if (x7c52265a69daa8be.Count > 0)
		{
			return (int)x7c52265a69daa8be.Peek();
		}
		return 1024;
	}

	private void x9f607cbbca4f7b86()
	{
		if (x7c52265a69daa8be.Count > 0)
		{
			x7c52265a69daa8be.Pop();
		}
	}

	internal static string x664c130a09af677a(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		return x7778af522baacfda.xaca4ebd805fc7700(xda5bf54deb817e37.x75658b3f8be4005c("style", string.Empty));
	}

	private static string x2eb961e1e9c44511(x9d6b37cac59aa2e2 xda5bf54deb817e37, string x9e89cc6e6284edf4)
	{
		string text = xda5bf54deb817e37.x75658b3f8be4005c(x9e89cc6e6284edf4, "");
		return text.Replace("\"", "%22");
	}

	private static Stack xc3cb38bc7b8201b7(object xe0bab362570a5669)
	{
		Stack stack = new Stack();
		stack.Push(xe0bab362570a5669);
		return stack;
	}
}
