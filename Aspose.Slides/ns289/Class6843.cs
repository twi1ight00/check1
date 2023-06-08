using System;
using System.Collections;
using System.IO;
using ns183;
using ns235;
using ns277;
using ns280;
using ns286;
using ns287;
using ns288;
using ns294;
using ns295;

namespace ns289;

internal class Class6843
{
	private const string string_0 = "Times New Roman";

	private Interface355 interface355_0;

	private Interface322 interface322_0;

	public Class6843(Interface355 settings, Interface322 resourceLoadingCallback)
	{
		interface355_0 = settings;
		interface322_0 = resourceLoadingCallback;
	}

	public Class6778 method_0(Stream stream, Class6779 options)
	{
		interface355_0.CharSet = options.InputEncoding;
		interface355_0.Device = options.Device;
		Class6917 @class = new Class6917(new Class6964("a\r\n{\r\n\ttext-decoration:underline;\r\n\tcolor:Blue;\r\n\tdisplay:inline;\r\n}\r\naside\r\n{\r\n    display:block;\r\n}\r\naddress\r\n{\r\n    font-style: italic;\r\n\tdisplay: block;\r\n}\r\nabbr\r\n{\r\n    display:inline;\r\n}\r\nacronym\r\n{\r\n    display:inline;\r\n}\r\napplet\r\n{\r\n    display:inline;\r\n}\r\nbdo\r\n{\r\n    display:inline;\r\n}\r\nsection\r\n{\r\n    margin: 1.5em 0;\r\n    display: block;\r\n}\r\nblockquote\r\n{\r\n\tdisplay: block;\r\n\tmargin: 1.12em 40px;\r\n}\r\nmeter\r\n{\r\n    display:inline;\r\n}\r\nnav\r\n{\r\n    display:inline;\r\n}\r\nruby\r\n{\r\n    display:inline;\r\n}\r\nprogress\r\n{\r\n    display:inline;\r\n}\r\nfooter\r\n{\r\n    display:inline;\r\n}\r\nheader\r\n{\r\n    display:inline;\r\n}\r\nmark\r\n{\r\n    display:inline;\r\n    background-color:yellow;\r\n}\r\nbody\r\n{\r\n\tdisplay: block; \r\n    margin: 8px;\r\n\t/*color: black;*/\r\n\t/*background: white;*/\r\n}\r\ndd\r\n{\r\n\tmargin-left: 40px;\r\n\tdisplay: block;\r\n}\r\ndiv\r\n{\r\n\tdisplay: block;\r\n}\r\ndl\r\n{\r\n\tmargin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\ndt\r\n{\r\n\tdisplay: block;\r\n}\r\ndfn\r\n{\r\n    font-style: italic;\r\n    display:inline;\r\n}\r\nfieldset\r\n{\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n    border: solid 1px gray;\r\n}\r\nfigure\r\n{\r\n    margin-top: 1.12em;\r\n    margin-bottom: 1.12em;\r\n    margin-left: 2.12em;\r\n    margin-right: 2.12em;\r\n\tdisplay: block;\r\n}\r\nform\r\n{\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\nframe\r\n{\r\n\tdisplay: block;\r\n}\r\narticle\r\n{\r\n\tdisplay: block;\r\n}\r\nframeset\r\n{\r\n\tdisplay: block;\r\n}\r\ntime\r\n{\r\n    display:inline;\r\n}\r\nh1\r\n{\r\n    font-weight: bolder;\r\n    font-size: 2em;\r\n\tmargin: 0.67em 0;\t\r\n\tdisplay: block;\r\n}\r\nh2\r\n{\r\n    font-size: 1.5em;\r\n\tmargin: 0.75em 0;\r\n\tfont-weight: bolder;\r\n\tdisplay: block;\r\n}\r\nh3\r\n{\r\n    font-size: 1.17em;\r\n\tmargin: 0.83em 0;\r\n\tfont-weight: bolder;\r\n\tdisplay: block;\r\n}\r\nh4\r\n{\r\n    font-weight: bolder;\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n}\r\nh5\r\n{\r\n    font-weight: bolder;\r\n\tdisplay: block;\r\n\tfont-size: 0.83em;\r\n\tmargin: 1.5em 0;\r\n}\r\nh6\r\n{\r\n    font-weight: bolder;\r\n\tdisplay: block;\r\n\tfont-size:0.75em;\r\n\tmargin: 1.67em 0;\r\n}\r\nnoframes\r\n{\r\n\tdisplay: block;\r\n}\r\nol\r\n{\r\n    padding-left: 40px;\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n\tlist-style-type: decimal;\r\n}\r\np\r\n{\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n}\r\nul\r\n{\r\n    padding-left: 40px;\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n}\r\ncenter\r\n{\r\n\tdisplay: block;\r\n\ttext-align: center;\r\n}\r\ndir\r\n{\r\n    padding-left: 40px;\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\nhr\r\n{\r\n    /*border: 1px inset;*/\r\n    border: solid 1px gray;\r\n\tdisplay: block;\r\n\tmargin: 10px 0px;\r\n}\r\nmenu\r\n{\r\n    padding-left: 40px;\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\npre\r\n{\r\n    font-family: Courier New;\r\n    font-size: 0.87em;\r\n\twhite-space: pre;\r\n\tdisplay: block;\r\n}\r\nxmp\r\n{\r\n\tfont-family: Courier New;\r\n    font-size: 0.87em;\r\n\twhite-space: pre;\r\n\tdisplay: block;\r\n}\r\nplaintext\r\n{\r\n\tfont-family: Courier New;\r\n    font-size: 0.87em;\r\n\twhite-space: pre;\r\n\tdisplay: block;\r\n}\r\nspan\r\n{\r\n\tdisplay: inline;\r\n}\r\nli\r\n{\r\n\tdisplay: list-item;\r\n}\r\nhead\r\n{\r\n\tdisplay: none;\r\n}\r\ntable\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n    border-collapse: separate;\r\n\twidth: auto;\r\n\theight: auto;\r\n    border-spacing: 2px;\r\n    border-style:none;\r\n\tdisplay: table;\r\n}\r\ntd, th\r\n{\r\n\tdisplay: table-cell;\r\n\tborder-style: none;\r\n    vertical-align: middle;\r\n\tvertical-align: inherit;\r\n}\r\nth\r\n{\r\n\tfont-weight: bolder;\r\n\ttext-align: center;\r\n}\r\ntr\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    vertical-align: inherit;\r\n    border-style:none;\r\n\tdisplay: table-row;\r\n}\r\nthead\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    vertical-align: middle;\r\n    border-style:solid;\r\n\tdisplay: table-header-group;\r\n}\r\ntbody\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n\tborder-style:solid;\r\n    vertical-align: middle;\r\n\tdisplay: table-row-group;\r\n}\r\ntfoot\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    vertical-align: middle;\r\n    border-style:solid;\r\n\tdisplay: table-footer-group;\r\n}\r\ncol\r\n{\r\n\tdisplay: table-column;\r\n}\r\ncolgroup\r\n{\r\n\tdisplay: table-column-group;\r\n}\r\ncaption\r\n{\r\n\tdisplay: table-caption;\r\n\ttext-align: center;\r\n}\r\nb\r\n{\r\n\tfont-weight: bolder;\r\n\tdisplay:inline;\r\n}\r\nstrong\r\n{\r\n\tfont-weight: bolder;\r\n\tdisplay: inline;\r\n}\r\ni\r\n{\r\n\tfont-style: italic;\r\n\tdisplay:inline;\r\n}\r\ncite\r\n{\r\n\tfont-style: italic;\r\n\tdisplay:inline;\r\n}\r\nimg\r\n{\r\n    display:inline;\r\n}\r\nem\r\n{\r\n\tfont-style: italic;\r\n\tdisplay: inline;\r\n}\r\niframe\r\n{\r\n    display:inline;\r\n}\r\nvar\r\n{\r\n\tfont-style: italic;\r\n\tdisplay: inline;\r\n}\r\ntt\r\n{\r\n    font-family: monospace;\r\n    font-size: 0.87em;\r\n\tdisplay:inline;\r\n}\r\ncode\r\n{\r\n    font-family: monospace;\r\n    font-size: 0.87em;\r\n    display:inline;\r\n}\r\nq\r\n{\r\n    display:inline;\r\n    quotes: '\"' '\"';\r\n}\r\nq::before \r\n{\r\n    content: open-quote;\r\n}\r\nq::after \r\n{\r\n    content: close-quote;\r\n}\r\nlabel\r\n{\r\n    display:inline;\r\n}\r\nobject\r\n{\r\n    display:inline;\r\n}\r\nkbd\r\n{\r\n    font-family: monospace;\r\n    display:inline;\r\n    font-size: 0.87em;\r\n}\r\nsamp\r\n{\r\n    font-family: monospace;\r\n    font-size: 0.87em;\r\n    display:inline;\r\n}\r\nbutton\r\n{\r\n    display:inline;\r\n\tfont-style: italic;\r\n}\r\ntextarea\r\n{\r\n\tfont-style: italic;\r\n}\r\ninput\r\n{\r\n\tdisplay: inline-block;\r\n}\r\nselect\r\n{\r\n\tdisplay: inline-block;\r\n}\r\nbig\r\n{\r\n    font-size: larger;\r\n\t/*font-size: 1.333333em;*/\r\n\tdisplay:inline;\r\n}\r\nsmall\r\n{\r\n\tfont-size: smaller;\r\n\tdisplay:inline;\r\n}\r\ns\r\n{\r\n\ttext-decoration: line-through;\r\n\tdisplay: inline;\r\n}\r\nstrike\r\n{\r\n\ttext-decoration: line-through;\r\n\tdisplay:inline;\r\n}\r\ndel\r\n{\r\n    display:inline;\r\n\ttext-decoration: line-through;\r\n}\r\nol ul\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nul ol\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nul ul\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nol ol\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nu\r\n{\r\n\ttext-decoration: underline;\r\n\tdisplay: inline;\r\n}\r\nins\r\n{\r\n    display:inline;\r\n\ttext-decoration: underline;\r\n}\r\nfont\r\n{\r\n\tdisplay:inline;\r\n}\r\nsub\r\n{\r\n\tfont-size: 0.5em;\r\n\tvertical-align: sub;\r\n\tdisplay:inline;\r\n}\r\nsup\r\n{\r\n\tfont-size: 0.5em;\r\n\tvertical-align: super;\r\n\tdisplay:inline;\r\n}\r\noption\r\n{\r\n\tdisplay:inline;\r\n}\r\nselect\r\n{\r\n\tdisplay:inline;\r\n}\r\ncheckbox\r\n{\r\n\tdisplay:inline;\r\n}\r\ntextarea\r\n{\r\n  \tdisplay:inline;\r\n}"), interface355_0, interface322_0);
		Class7047 document = @class.method_0(stream);
		return method_3(document, options);
	}

	[Obsolete("Please use ApsConverter.Convert(Stream stream, ConverterOptions options) method for converting HTML to the APS.")]
	public Class6778 method_1(string htmlContent, Class6779 options)
	{
		Class7047 document = method_2(htmlContent, options);
		return method_3(document, options);
	}

	internal Class7047 method_2(string htmlContent, Class6779 options)
	{
		interface355_0.CharSet = options.InputEncoding;
		interface355_0.Device = options.Device;
		Class6917 @class = new Class6917(new Class6964("a\r\n{\r\n\ttext-decoration:underline;\r\n\tcolor:Blue;\r\n\tdisplay:inline;\r\n}\r\naside\r\n{\r\n    display:block;\r\n}\r\naddress\r\n{\r\n    font-style: italic;\r\n\tdisplay: block;\r\n}\r\nabbr\r\n{\r\n    display:inline;\r\n}\r\nacronym\r\n{\r\n    display:inline;\r\n}\r\napplet\r\n{\r\n    display:inline;\r\n}\r\nbdo\r\n{\r\n    display:inline;\r\n}\r\nsection\r\n{\r\n    margin: 1.5em 0;\r\n    display: block;\r\n}\r\nblockquote\r\n{\r\n\tdisplay: block;\r\n\tmargin: 1.12em 40px;\r\n}\r\nmeter\r\n{\r\n    display:inline;\r\n}\r\nnav\r\n{\r\n    display:inline;\r\n}\r\nruby\r\n{\r\n    display:inline;\r\n}\r\nprogress\r\n{\r\n    display:inline;\r\n}\r\nfooter\r\n{\r\n    display:inline;\r\n}\r\nheader\r\n{\r\n    display:inline;\r\n}\r\nmark\r\n{\r\n    display:inline;\r\n    background-color:yellow;\r\n}\r\nbody\r\n{\r\n\tdisplay: block; \r\n    margin: 8px;\r\n\t/*color: black;*/\r\n\t/*background: white;*/\r\n}\r\ndd\r\n{\r\n\tmargin-left: 40px;\r\n\tdisplay: block;\r\n}\r\ndiv\r\n{\r\n\tdisplay: block;\r\n}\r\ndl\r\n{\r\n\tmargin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\ndt\r\n{\r\n\tdisplay: block;\r\n}\r\ndfn\r\n{\r\n    font-style: italic;\r\n    display:inline;\r\n}\r\nfieldset\r\n{\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n    border: solid 1px gray;\r\n}\r\nfigure\r\n{\r\n    margin-top: 1.12em;\r\n    margin-bottom: 1.12em;\r\n    margin-left: 2.12em;\r\n    margin-right: 2.12em;\r\n\tdisplay: block;\r\n}\r\nform\r\n{\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\nframe\r\n{\r\n\tdisplay: block;\r\n}\r\narticle\r\n{\r\n\tdisplay: block;\r\n}\r\nframeset\r\n{\r\n\tdisplay: block;\r\n}\r\ntime\r\n{\r\n    display:inline;\r\n}\r\nh1\r\n{\r\n    font-weight: bolder;\r\n    font-size: 2em;\r\n\tmargin: 0.67em 0;\t\r\n\tdisplay: block;\r\n}\r\nh2\r\n{\r\n    font-size: 1.5em;\r\n\tmargin: 0.75em 0;\r\n\tfont-weight: bolder;\r\n\tdisplay: block;\r\n}\r\nh3\r\n{\r\n    font-size: 1.17em;\r\n\tmargin: 0.83em 0;\r\n\tfont-weight: bolder;\r\n\tdisplay: block;\r\n}\r\nh4\r\n{\r\n    font-weight: bolder;\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n}\r\nh5\r\n{\r\n    font-weight: bolder;\r\n\tdisplay: block;\r\n\tfont-size: 0.83em;\r\n\tmargin: 1.5em 0;\r\n}\r\nh6\r\n{\r\n    font-weight: bolder;\r\n\tdisplay: block;\r\n\tfont-size:0.75em;\r\n\tmargin: 1.67em 0;\r\n}\r\nnoframes\r\n{\r\n\tdisplay: block;\r\n}\r\nol\r\n{\r\n    padding-left: 40px;\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n\tlist-style-type: decimal;\r\n}\r\np\r\n{\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n}\r\nul\r\n{\r\n    padding-left: 40px;\r\n\tdisplay: block;\r\n\tmargin: 1.12em 0;\r\n}\r\ncenter\r\n{\r\n\tdisplay: block;\r\n\ttext-align: center;\r\n}\r\ndir\r\n{\r\n    padding-left: 40px;\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\nhr\r\n{\r\n    /*border: 1px inset;*/\r\n    border: solid 1px gray;\r\n\tdisplay: block;\r\n\tmargin: 10px 0px;\r\n}\r\nmenu\r\n{\r\n    padding-left: 40px;\r\n    margin: 1.12em 0;\r\n\tdisplay: block;\r\n}\r\npre\r\n{\r\n    font-family: Courier New;\r\n    font-size: 0.87em;\r\n\twhite-space: pre;\r\n\tdisplay: block;\r\n}\r\nxmp\r\n{\r\n\tfont-family: Courier New;\r\n    font-size: 0.87em;\r\n\twhite-space: pre;\r\n\tdisplay: block;\r\n}\r\nplaintext\r\n{\r\n\tfont-family: Courier New;\r\n    font-size: 0.87em;\r\n\twhite-space: pre;\r\n\tdisplay: block;\r\n}\r\nspan\r\n{\r\n\tdisplay: inline;\r\n}\r\nli\r\n{\r\n\tdisplay: list-item;\r\n}\r\nhead\r\n{\r\n\tdisplay: none;\r\n}\r\ntable\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n    border-collapse: separate;\r\n\twidth: auto;\r\n\theight: auto;\r\n    border-spacing: 2px;\r\n    border-style:none;\r\n\tdisplay: table;\r\n}\r\ntd, th\r\n{\r\n\tdisplay: table-cell;\r\n\tborder-style: none;\r\n    vertical-align: middle;\r\n\tvertical-align: inherit;\r\n}\r\nth\r\n{\r\n\tfont-weight: bolder;\r\n\ttext-align: center;\r\n}\r\ntr\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    vertical-align: inherit;\r\n    border-style:none;\r\n\tdisplay: table-row;\r\n}\r\nthead\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    vertical-align: middle;\r\n    border-style:solid;\r\n\tdisplay: table-header-group;\r\n}\r\ntbody\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n\tborder-style:solid;\r\n    vertical-align: middle;\r\n\tdisplay: table-row-group;\r\n}\r\ntfoot\r\n{\r\n    /*display: block;*/\r\n\tbackground-position: top left;\r\n\twidth: auto;\r\n\theight: auto;\r\n    vertical-align: middle;\r\n    border-style:solid;\r\n\tdisplay: table-footer-group;\r\n}\r\ncol\r\n{\r\n\tdisplay: table-column;\r\n}\r\ncolgroup\r\n{\r\n\tdisplay: table-column-group;\r\n}\r\ncaption\r\n{\r\n\tdisplay: table-caption;\r\n\ttext-align: center;\r\n}\r\nb\r\n{\r\n\tfont-weight: bolder;\r\n\tdisplay:inline;\r\n}\r\nstrong\r\n{\r\n\tfont-weight: bolder;\r\n\tdisplay: inline;\r\n}\r\ni\r\n{\r\n\tfont-style: italic;\r\n\tdisplay:inline;\r\n}\r\ncite\r\n{\r\n\tfont-style: italic;\r\n\tdisplay:inline;\r\n}\r\nimg\r\n{\r\n    display:inline;\r\n}\r\nem\r\n{\r\n\tfont-style: italic;\r\n\tdisplay: inline;\r\n}\r\niframe\r\n{\r\n    display:inline;\r\n}\r\nvar\r\n{\r\n\tfont-style: italic;\r\n\tdisplay: inline;\r\n}\r\ntt\r\n{\r\n    font-family: monospace;\r\n    font-size: 0.87em;\r\n\tdisplay:inline;\r\n}\r\ncode\r\n{\r\n    font-family: monospace;\r\n    font-size: 0.87em;\r\n    display:inline;\r\n}\r\nq\r\n{\r\n    display:inline;\r\n    quotes: '\"' '\"';\r\n}\r\nq::before \r\n{\r\n    content: open-quote;\r\n}\r\nq::after \r\n{\r\n    content: close-quote;\r\n}\r\nlabel\r\n{\r\n    display:inline;\r\n}\r\nobject\r\n{\r\n    display:inline;\r\n}\r\nkbd\r\n{\r\n    font-family: monospace;\r\n    display:inline;\r\n    font-size: 0.87em;\r\n}\r\nsamp\r\n{\r\n    font-family: monospace;\r\n    font-size: 0.87em;\r\n    display:inline;\r\n}\r\nbutton\r\n{\r\n    display:inline;\r\n\tfont-style: italic;\r\n}\r\ntextarea\r\n{\r\n\tfont-style: italic;\r\n}\r\ninput\r\n{\r\n\tdisplay: inline-block;\r\n}\r\nselect\r\n{\r\n\tdisplay: inline-block;\r\n}\r\nbig\r\n{\r\n    font-size: larger;\r\n\t/*font-size: 1.333333em;*/\r\n\tdisplay:inline;\r\n}\r\nsmall\r\n{\r\n\tfont-size: smaller;\r\n\tdisplay:inline;\r\n}\r\ns\r\n{\r\n\ttext-decoration: line-through;\r\n\tdisplay: inline;\r\n}\r\nstrike\r\n{\r\n\ttext-decoration: line-through;\r\n\tdisplay:inline;\r\n}\r\ndel\r\n{\r\n    display:inline;\r\n\ttext-decoration: line-through;\r\n}\r\nol ul\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nul ol\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nul ul\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nol ol\r\n{\r\n\tmargin-top: 0;\r\n\tmargin-bottom: 0;\r\n}\r\nu\r\n{\r\n\ttext-decoration: underline;\r\n\tdisplay: inline;\r\n}\r\nins\r\n{\r\n    display:inline;\r\n\ttext-decoration: underline;\r\n}\r\nfont\r\n{\r\n\tdisplay:inline;\r\n}\r\nsub\r\n{\r\n\tfont-size: 0.5em;\r\n\tvertical-align: sub;\r\n\tdisplay:inline;\r\n}\r\nsup\r\n{\r\n\tfont-size: 0.5em;\r\n\tvertical-align: super;\r\n\tdisplay:inline;\r\n}\r\noption\r\n{\r\n\tdisplay:inline;\r\n}\r\nselect\r\n{\r\n\tdisplay:inline;\r\n}\r\ncheckbox\r\n{\r\n\tdisplay:inline;\r\n}\r\ntextarea\r\n{\r\n  \tdisplay:inline;\r\n}"), interface355_0, interface322_0);
		return @class.imethod_0(htmlContent);
	}

	internal Class6778 method_3(Class7047 document, Class6779 options)
	{
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			using Class6890 class2 = new Class6890(memoryStream);
			Class6800 @class = new Class6800(document, new Class6799());
			Class6772 class3 = new Class6772(interface355_0, class2, options, interface322_0, @class);
			class3.method_7(document);
			class2.Flush();
			memoryStream.Seek(0L, SeekOrigin.Begin);
			Class5942 class4 = new Class5942();
			class4.DefaultFontName = "Times New Roman";
			Hashtable map = (class4.BlocksIdRectMap = new Hashtable());
			class4.ResourceLoadingCallback = new Class6763(interface322_0);
			class4.SplitElements = options.SplitElements;
			class4.ForceAlignBreak = true;
			ArrayList arrayList = Class5941.smethod_7(memoryStream, class4);
			Class6216[] array = new Class6216[arrayList.Count];
			arrayList.CopyTo(array);
			if (options.ApplyPageClipping)
			{
				array = new Class6782(options).method_1(array);
			}
			@class.method_1(array);
			@class.method_6(map);
			return new Class6778(@class);
		}
		finally
		{
			Class5939.Instance.Dispose();
		}
	}
}
