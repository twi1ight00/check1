namespace x6c95d9cf46ff5f25;

internal class xb9015fe823e7e228
{
	private static readonly x09ce2c02826e31a6 x45a25a17dc2b0bb9;

	private static readonly xd345c73dd1b16b74 x638a3e9ac86960e7;

	private static readonly xd345c73dd1b16b74 xce629fe46fc56fb3;

	private static readonly x09ce2c02826e31a6 xe005282896cbb059;

	private static readonly x09ce2c02826e31a6 x1ca2de9872e886f0;

	private xb9015fe823e7e228()
	{
	}

	public static xfe2ff3c162b47c70 x79cfeb58677e6765(string xe1d3286d17e44a37)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xe1d3286d17e44a37))
		{
			return xfe2ff3c162b47c70.xf6c17f648b65c793;
		}
		object obj = x638a3e9ac86960e7[xe1d3286d17e44a37];
		if (obj != null)
		{
			return (xfe2ff3c162b47c70)obj;
		}
		return xfe2ff3c162b47c70.xf6c17f648b65c793;
	}

	public static xfe2ff3c162b47c70 x0f2906e6dae0813a(string xca6cce6923124135)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xca6cce6923124135))
		{
			return xfe2ff3c162b47c70.xf6c17f648b65c793;
		}
		if (xca6cce6923124135.StartsWith("."))
		{
			xca6cce6923124135 = xca6cce6923124135.Substring(1);
		}
		object obj = xce629fe46fc56fb3[xca6cce6923124135];
		if (obj != null)
		{
			return (xfe2ff3c162b47c70)obj;
		}
		return xfe2ff3c162b47c70.xf6c17f648b65c793;
	}

	public static string x0ad80fdc3fba643e(xfe2ff3c162b47c70 x4e17f25eeff90cf4)
	{
		return (string)xe005282896cbb059.get_xe6d4b1b411ed94b5((int)x4e17f25eeff90cf4);
	}

	public static string xac88cb4f794761a9(xfe2ff3c162b47c70 x4e17f25eeff90cf4)
	{
		return (string)x1ca2de9872e886f0.get_xe6d4b1b411ed94b5((int)x4e17f25eeff90cf4);
	}

	public static string ToString(xfe2ff3c162b47c70 fileFormat)
	{
		return (string)x45a25a17dc2b0bb9.get_xe6d4b1b411ed94b5((int)fileFormat);
	}

	private static void x70fa1602ceccddee(params object[] x337e217cb3ba0627)
	{
		for (int i = 0; i < x337e217cb3ba0627.Length; i += 4)
		{
			xfe2ff3c162b47c70 xfe2ff3c162b47c71 = (xfe2ff3c162b47c70)x337e217cb3ba0627[i];
			string xbcea506a33cf = (string)x337e217cb3ba0627[i + 1];
			string text = (string)x337e217cb3ba0627[i + 2];
			string text2 = (string)x337e217cb3ba0627[i + 3];
			if (!x45a25a17dc2b0bb9.x263d579af1d0d43f((int)xfe2ff3c162b47c71))
			{
				x45a25a17dc2b0bb9.xd6b6ed77479ef68c((int)xfe2ff3c162b47c71, xbcea506a33cf);
			}
			if (text != null)
			{
				if (!xe005282896cbb059.x263d579af1d0d43f((int)xfe2ff3c162b47c71))
				{
					xe005282896cbb059.xd6b6ed77479ef68c((int)xfe2ff3c162b47c71, text);
				}
				if (!x638a3e9ac86960e7.Contains(text))
				{
					x638a3e9ac86960e7.Add(text, xfe2ff3c162b47c71);
				}
			}
			if (text2 != null)
			{
				if (!x1ca2de9872e886f0.x263d579af1d0d43f((int)xfe2ff3c162b47c71))
				{
					x1ca2de9872e886f0.xd6b6ed77479ef68c((int)xfe2ff3c162b47c71, text2);
				}
				if (!xce629fe46fc56fb3.Contains(text2))
				{
					xce629fe46fc56fb3.Add(text2, xfe2ff3c162b47c71);
				}
			}
		}
	}

	static xb9015fe823e7e228()
	{
		x45a25a17dc2b0bb9 = new x09ce2c02826e31a6(50);
		x638a3e9ac86960e7 = new xd345c73dd1b16b74(isCaseSensitive: false);
		xce629fe46fc56fb3 = new xd345c73dd1b16b74(isCaseSensitive: false);
		xe005282896cbb059 = new x09ce2c02826e31a6();
		x1ca2de9872e886f0 = new x09ce2c02826e31a6();
		x70fa1602ceccddee(xfe2ff3c162b47c70.x34639b140e83dce7, "Xml", "text/xml", null, xfe2ff3c162b47c70.x34639b140e83dce7, "Xml", "application/xml", null, xfe2ff3c162b47c70.x15c106572f1e1fbf, "Tiff", "image/tiff", "tif", xfe2ff3c162b47c70.x15c106572f1e1fbf, "Tiff", null, "tiff", xfe2ff3c162b47c70.xc2746d872ce402e9, "Bmp", "image/bmp", "bmp", xfe2ff3c162b47c70.x6339cdb9e2b512c7, "Png", "image/png", "png", xfe2ff3c162b47c70.x796ab23ce57ee1e0, "Jpeg", "image/jpeg", "jpeg", xfe2ff3c162b47c70.x796ab23ce57ee1e0, "Jpeg", null, "jpg", xfe2ff3c162b47c70.xd69df86e2a88ddb2, "Emf", "image/x-emf", "emf", xfe2ff3c162b47c70.xb5fe04c34562f438, "Wmf", "image/x-wmf", "wmf", xfe2ff3c162b47c70.x26c36dd85013b919, "Pict", "image/x-pict", "pict", xfe2ff3c162b47c70.x26c36dd85013b919, "Pict", null, "pct", xfe2ff3c162b47c70.x8e716ec1cb703e9f, "Gif", "image/gif", "gif", xfe2ff3c162b47c70.x64a7e1d48dfb2e43, "Xps", "application/vnd.ms-xpsdocument", "xps", xfe2ff3c162b47c70.x6fcc29eace04fce1, "Pdf", "application/pdf", "pdf", xfe2ff3c162b47c70.xffe454f29a855c10, "Swf", "application/x-shockwave-flash", "swf", xfe2ff3c162b47c70.x6b60f7630a7ba83e, "Svg", "image/svg+xml", "svg", xfe2ff3c162b47c70.xbaa6d01bddb61fad, "Epub", "application/epub+zip", "epub", xfe2ff3c162b47c70.x4bc88de02db3a00d, "Html", "text/html", "html", xfe2ff3c162b47c70.x4bc88de02db3a00d, "Html", null, "htm", xfe2ff3c162b47c70.x4bc88de02db3a00d, "Html", null, "xhtml", xfe2ff3c162b47c70.x6575e3132c2315a1, "Txt", "text/plain", "txt", xfe2ff3c162b47c70.xf29d447b35560f87, "Doc", "application/msword", "doc", xfe2ff3c162b47c70.x3cb6807e93737c2d, "Dot", "application/msword", "dot", xfe2ff3c162b47c70.xbd631d649c3744d3, "DocPreWord97", null, "doc", xfe2ff3c162b47c70.x5896ed36f2cf9162, "Rtf", "application/rtf", "rtf", xfe2ff3c162b47c70.x13f5b6016cd2e8b8, "WordML", "text/xml", "wml", xfe2ff3c162b47c70.x13f5b6016cd2e8b8, "WordML", null, "wordml", xfe2ff3c162b47c70.x13f5b6016cd2e8b8, "WordML", null, "xml", xfe2ff3c162b47c70.x23a8fbf7780a9c30, "Mhtml", "multipart/related", "mht", xfe2ff3c162b47c70.x23a8fbf7780a9c30, "Mhtml", null, "mhtml", xfe2ff3c162b47c70.x23a8fbf7780a9c30, "Mhtml", null, "mhtm", xfe2ff3c162b47c70.x23a8fbf7780a9c30, "Mhtml", null, "msg", xfe2ff3c162b47c70.x23a8fbf7780a9c30, "Mhtml", null, "eml", xfe2ff3c162b47c70.xf2aa2ce921557bd6, "Docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx", xfe2ff3c162b47c70.x59bc1d2d01a89f08, "Docm", "application/vnd.ms-word.document.macroEnabled.12", "docm", xfe2ff3c162b47c70.x4fbfadbc48a8b0ff, "Dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template", "dotx", xfe2ff3c162b47c70.xeab79a7b060cfae0, "Dotm", "application/vnd.ms-word.template.macroEnabled.12", "dotm", xfe2ff3c162b47c70.xdc5b90a3edb706a6, "Odt", "application/vnd.oasis.opendocument.text", "odt", xfe2ff3c162b47c70.xf81522cc52524aa3, "Ott", "application/vnd.oasis.opendocument.text-template", "ott", xfe2ff3c162b47c70.xb50ee49625ffa9b3, "FlatOpc", "application/vnd.openxmlformats-officedocument.wordprocessingml.document+xml", "fopc", xfe2ff3c162b47c70.x13677b8122a7e4b9, "FlatOpcMacroEnabled", "application/vnd.ms-word.document.macroEnabled.main+xml", "fopc", xfe2ff3c162b47c70.x8b05d5ed9c1cf9d8, "FlatOpcTemplate", "application/vnd.openxmlformats-officedocument.wordprocessingml.template.main+xml", "fopc", xfe2ff3c162b47c70.x2a828bc9fd060b65, "FlatOpcTemplateMacroEnabled", "application/vnd.ms-word.template.macroEnabledTemplate.main+xml", "fopc", xfe2ff3c162b47c70.x996f98c23f508228, "XamlFlow", "application/xaml+xml", "xaml", xfe2ff3c162b47c70.x52164632cde900c3, "XamlFlowPack", "application/xaml+xml", "xamlpack", xfe2ff3c162b47c70.xce63990f9b88e8f7, "XamlFixed", "application/xml", "xaml");
	}
}
