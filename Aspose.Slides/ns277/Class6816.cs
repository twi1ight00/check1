using System.Collections;
using System.Drawing;
using ns235;
using ns284;
using ns287;
using ns288;
using ns290;
using ns301;
using ns303;

namespace ns277;

internal sealed class Class6816 : Class6815
{
	private readonly Class6839 class6839_0;

	public Class6816(Class6839 documentBuilder, Interface322 resourceLoading)
		: base(resourceLoading)
	{
		Class6892.smethod_0(documentBuilder, "documentBuilder");
		Class6892.smethod_0(resourceLoading, "resourceLoading");
		class6839_0 = documentBuilder;
		base.StyleProvider = new Class6964("a\r\n{\r\n\ttext-decoration:underline;\r\n\tcolor:Blue;\r\n\tdisplay:inline;\r\n}\r\naside\r\n{\r\n    display:block;\r\n}\r\naddress\r\n{\r\n    font-style: italic;\r\n\tdisplay: block;\r\n}\r\nabbr\r\n{\r\n    display:inline;\r\n}\r\nacronym\r\n{\r\n    display:inline;\r\n}\r\napplet\r\n{\r\n    display:inline;\r\n}\r\nbr\r\n{\r\n    display:inline;\r\n}\r\nbdo\r\n{\r\n    display:inline;\r\n}\r\nsection\r\n{\r\n    margin: 1.5em 0;\r\n    display: block;\r\n}\r\nblockquote\r\n{\r\n\tdisplay: block;\r\n\tmargin: 1.12em 40px;\r\n}\r\nmeter\r\n{\r\n    display:inline;\r\n}\r\nnav\r\n{\r\n    display:inline;\r\n}\r\nruby\r\n{\r\n    display:inline;\r\n}\r\nprogress\r\n{\r\n    display:inline;\r\n}\r\nfooter\r\n{\r\n    display:inline;\r\n}\r\nheader\r\n{\r\n    display:inline;\r\n}\r\nmark\r\n{\r\n    display:inline;\r\n    background-color:yellow;\r\n}\r\nbody\r\n{\r\n\tdisplay: block; /*margin: 8px;*/\r\n\t/*color: black;*/\r\n\t/*background: white;*/\r\n}\r\ndd\r\n{\r\n\tmargin-left: 40px;\r\n\tdisplay: block;\r\n}\r\ndiv\r\n{\r\n\tdisplay: block;\r\n}\r\ndl\r\n{\r\n\tmargin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\ndt\r\n{\r\n\tdisplay: block;\r\n}\r\ndfn\r\n{\r\n    font-style: italic;\r\n    display:inline;\r\n}\r\nfieldset\r\n{\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n    border: solid 1px gray;\r\n}\r\nfigure\r\n{\r\n    margin-top: 2.1em;\r\n    margin-bottom: 2.1em;\r\n    margin-left: 2.1em;\r\n    margin-right: 2.1em;\r\n\tdisplay: block;\r\n}\r\nform\r\n{\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\nframe\r\n{\r\n\tdisplay: block;\r\n}\r\narticle\r\n{\r\n\tdisplay: block;\r\n}\r\nframeset\r\n{\r\n\tdisplay: block;\r\n}\r\ntime\r\n{\r\n    display:inline;\r\n}\r\nh1\r\n{\r\n    font-weight: bolder;\r\n    font-size: 2em;\r\n\tmargin: 0.67em 0;\t\r\n\tdisplay: block;\r\n}\r\nh2\r\n{\r\n    font-size: 1.5em;\r\n\tmargin: 0.75em 0;\r\n\tfont-weight: bolder;\r\n\tdisplay: block;\r\n}\r\nh3\r\n{\r\n    font-size: 1.17em;\r\n\tmargin: 0.83em 0;\r\n\tfont-weight: bolder;\r\n\tdisplay: block;\r\n}\r\nh4\r\n{\r\n    font-weight: bolder;\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n}\r\nh5\r\n{\r\n    font-weight: bolder;\r\n\tdisplay: block;\r\n\tfont-size: 0.83em;\r\n\tmargin: 1.5em 0;\r\n}\r\nh6\r\n{\r\n    font-weight: bolder;\r\n\tdisplay: block;\r\n\tfont-size:0.75em;\r\n\tmargin: 1.67em 0;\r\n}\r\nnoframes\r\n{\r\n\tdisplay: block;\r\n}\r\nol\r\n{\r\n    padding-left: 40px;\r\n    padding:0 0 0 40px;\r\n\tdisplay: block;\r\n\t/*margin: 1.12em 0;*/\r\n\tlist-style-type: decimal;\r\n}\r\np\r\n{\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n}\r\nul\r\n{\r\n    padding-left: 40px;\r\n    padding:0 0 0 40px;\r\n\tdisplay: block;\r\n    list-style-type: disc;\r\n\t/*margin: 1.12em 0;*/\r\n}\r\ncenter\r\n{\r\n\tdisplay: block;\r\n\ttext-align: center;\r\n}\r\ndir\r\n{\r\n    padding-left: 40px;\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\nhr\r\n{\r\n    /*border: 1px inset;*/\r\n    border: solid 1px gray;\r\n\tdisplay: block;\r\n\tmargin: 10px 0px;\r\n}\r\nmenu\r\n{\r\n    padding-left: 40px;\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\npre\r\n{\r\n    font-family: Courier New;\r\n    font-size: 0.87em;\r\n\twhite-space: pre;\r\n\tdisplay: block;\r\n}\r\nxmp\r\n{\r\n\tfont-family: Courier New;\r\n    font-size: 0.87em;\r\n\twhite-space: pre;\r\n\tdisplay: block;\r\n}\r\nplaintext\r\n{\r\n\tfont-family: Courier New;\r\n    font-size: 0.87em;\r\n\twhite-space: pre;\r\n\tdisplay: block;\r\n}\r\nspan\r\n{\r\n\tdisplay: inline;\r\n}\r\nli\r\n{\r\n\tdisplay: list-item;\r\n    padding:0 0 0 10pt;\r\n}\r\nhead\r\n{\r\n\tdisplay: none;\r\n}\r\ntable\r\n{\r\n    display: block;\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    border-spacing: 2px;\r\n\tdisplay: table;\r\n    border-collapse: separate;\r\n    border-style: outset;\r\n    border-color: black;\r\n    border-width: 0px;\r\n}\r\ntd, th\r\n{\r\n\tdisplay: table-cell;\r\n\tborder-style: inset;\r\n    border-width: 0px;\r\n    vertical-align: middle;\r\n\tvertical-align: inherit;\r\n}\r\nth\r\n{\r\n\tfont-weight: bolder;\r\n\ttext-align: center;\r\n}\r\ntr\r\n{\r\n    display: block;\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    vertical-align: inherit;\r\n    /*border-style:solid;*/\r\n\tdisplay: table-row;\r\n}\r\nthead\r\n{\r\n    display: block;\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    vertical-align: middle;\r\n    border: solid 0px black;\r\n\tdisplay: table-header-group;\r\n}\r\ntbody\r\n{\r\n    display: block;\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n\tborder-style:solid;\r\n    vertical-align: middle;\r\n\tdisplay: table-row-group;\r\n}\r\ntfoot\r\n{\r\n    display: block;\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    vertical-align: middle;\r\n    border-style:solid;\r\n\tdisplay: table-footer-group;\r\n}\r\ncol\r\n{\r\n\tdisplay: table-column;\r\n}\r\ncolgroup\r\n{\r\n\tdisplay: table-column-group;\r\n}\r\ncaption\r\n{\r\n\tdisplay: table-caption;\r\n\ttext-align: center;\r\n}\r\nb\r\n{\r\n\tfont-weight: bolder;\r\n\tdisplay:inline;\r\n}\r\nstrong\r\n{\r\n\tfont-weight: bolder;\r\n\tdisplay: inline;\r\n}\r\ni\r\n{\r\n\tfont-style: italic;\r\n\tdisplay:inline;\r\n}\r\ncite\r\n{\r\n\tfont-style: italic;\r\n\tdisplay:inline;\r\n}\r\nimg\r\n{\r\n    display:inline-block;\r\n}\r\nem\r\n{\r\n\tfont-style: italic;\r\n\tdisplay: inline;\r\n}\r\niframe\r\n{\r\n    display:inline;\r\n}\r\nvar\r\n{\r\n\tfont-style: italic;\r\n\tdisplay: inline;\r\n}\r\ntt\r\n{\r\n    font-family: monospace;\r\n    font-size: 0.87em;\r\n\tdisplay:inline;\r\n}\r\ncode\r\n{\r\n    font-family: monospace;\r\n    font-size: 0.87em;\r\n    display:inline;\r\n}\r\nq\r\n{\r\n    display:inline;\r\n}\r\nlabel\r\n{\r\n    display:inline;\r\n}\r\nobject\r\n{\r\n    display:inline;\r\n}\r\nkbd\r\n{\r\n    font-family: monospace;\r\n    display:inline;\r\n    font-size: 0.87em;\r\n}\r\nsamp\r\n{\r\n    font-family: monospace;\r\n    font-size: 0.87em;\r\n    display:inline;\r\n}\r\nbutton\r\n{\r\n    display:inline;\r\n\tfont-style: italic;\r\n}\r\ntextarea\r\n{\r\n\tfont-style: italic;\r\n}\r\ninput\r\n{\r\n\tdisplay: inline-block;\r\n}\r\nselect\r\n{\r\n\tdisplay: inline-block;\r\n}\r\nbig\r\n{\r\n    font-size: larger;\r\n\t/*font-size: 1.333333em;*/\r\n\tdisplay:inline;\r\n}\r\nsmall\r\n{\r\n\tfont-size: smaller;\r\n\tdisplay:inline;\r\n}\r\ns\r\n{\r\n\ttext-decoration: line-through;\r\n\tdisplay: inline;\r\n}\r\nstrike\r\n{\r\n\ttext-decoration: line-through;\r\n\tdisplay:inline;\r\n}\r\ndel\r\n{\r\n    display:inline;\r\n\ttext-decoration: line-through;\r\n}\r\nol ul\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nul ol\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nul ul\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nol ol\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nu\r\n{\r\n\ttext-decoration: underline;\r\n\tdisplay: inline;\r\n}\r\nins\r\n{\r\n    display:inline;\r\n\ttext-decoration: underline;\r\n}\r\nfont\r\n{\r\n\tdisplay:inline;\r\n}\r\nsub\r\n{\r\n\tfont-size: 0.83em;\r\n\tvertical-align: sub;\r\n\tdisplay:inline;\r\n}\r\nsup\r\n{\r\n\tfont-size: 0.83em;\r\n\tvertical-align: super;\r\n\tdisplay:inline;\r\n}\r\noption\r\n{\r\n\tdisplay:inline;\r\n}\r\nselect\r\n{\r\n\tdisplay:inline;\r\n}\r\ncheckbox\r\n{\r\n\tdisplay:inline;\r\n}\r\ntextarea\r\n{\r\n  \tdisplay:inline;\r\n}");
	}

	public override Class6216[] vmethod_1(string html)
	{
		Class6892.smethod_1(html, "html");
		Interface329 defaultStyle = class6839_0.vmethod_2();
		float width = class6839_0.vmethod_3();
		float height = class6839_0.vmethod_4();
		SizeF pageSize = new SizeF(width, height);
		base.StyleProvider.method_2(defaultStyle, clearStyles: true);
		html = Class6962.smethod_0(html);
		Interface339 @interface = new Class6918(class6964_0, base.Settings, base.ResourceLoadingCallback);
		Class7047 @class = @interface.imethod_0(html);
		Class6786 renderContext = new Class6786(base.ResourceLoadingCallback);
		Interface360 textParser = new Class6965();
		Interface344 boxFactory = new Class6925(renderContext);
		Interface350 whitespaceProcessor = new Class6941();
		Interface343 boxModelBuilder = new Class6923(boxFactory, whitespaceProcessor);
		Class6924 class2 = new Class6924(boxModelBuilder, textParser);
		Class6844 boxModel = class2.method_1(@class.DocumentElement as Class7015);
		Interface351 boxInfo = new Class6942();
		Interface361 unitConverter = new Class6970();
		Interface345 formattingContextFactory = new Class6926(boxInfo, unitConverter, renderContext);
		Interface347 interface2 = new Class6935(pageSize, formattingContextFactory, renderContext);
		IList list = interface2.imethod_0(boxModel);
		Hashtable pageSet = new Hashtable();
		Class6216 class3 = new Class6216(class6839_0.vmethod_3(), class6839_0.vmethod_4());
		Class6213 node = new Class6213();
		class3.Add(node);
		pageSet.Add(pageSet.Count, class3);
		for (int i = 0; i < list.Count; i++)
		{
			class6839_0.vmethod_1((Class6844)list[i], ref pageSet);
		}
		return new Class6216[1] { class3 };
	}

	public override void vmethod_0(string html)
	{
		Class6892.smethod_1(html, "html");
		Interface329 defaultStyle = class6839_0.vmethod_2();
		float width = class6839_0.vmethod_3();
		float height = class6839_0.vmethod_4();
		SizeF pageSize = new SizeF(width, height);
		base.StyleProvider.method_2(defaultStyle, clearStyles: true);
		html = Class6962.smethod_0(html);
		Interface339 @interface = new Class6918(base.StyleProvider, base.Settings, base.ResourceLoadingCallback);
		Class7047 @class = @interface.imethod_0(html);
		Class6786 renderContext = new Class6786(base.ResourceLoadingCallback);
		Interface360 textParser = new Class6965();
		Interface344 boxFactory = new Class6925(renderContext);
		Interface350 whitespaceProcessor = new Class6941();
		Interface343 boxModelBuilder = new Class6923(boxFactory, whitespaceProcessor);
		Class6924 class2 = new Class6924(boxModelBuilder, textParser);
		Class6844 boxModel = class2.method_1(@class.DocumentElement as Class7015);
		Interface351 boxInfo = new Class6942();
		Interface361 unitConverter = new Class6970();
		Interface345 formattingContextFactory = new Class6926(boxInfo, unitConverter, renderContext);
		Interface347 interface2 = new Class6935(pageSize, formattingContextFactory, renderContext);
		IList list = interface2.imethod_0(boxModel);
		for (int i = 0; i < list.Count; i++)
		{
			class6839_0.vmethod_0((Class6844)list[i]);
		}
	}
}
