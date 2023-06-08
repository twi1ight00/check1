using System.IO;
using Aspose.Words;
using x4e7201a131ebc6f0;
using x583d72a986201ed7;
using x6c95d9cf46ff5f25;
using x79490184cecf12a1;
using x9b5b1a17490bd5f3;
using xa604c4d210ae0581;
using xb92b7270f78a4e8d;
using xf9a9481c3f63a419;
using xfc5388ad7dff404f;
using xfce5b6a304778b89;

namespace xf989f31a236ff98c;

internal class x53dc82a419732f24
{
	private x755940550ade8e52 x93ce70fb4ad3e4ab;

	private xd8c3135513b9115b x1397becc000d27f0;

	private FileFormatInfo x73132d31ee0204ab;

	internal xd8c3135513b9115b xd8c3135513b9115b => x1397becc000d27f0;

	internal FileFormatInfo xdef7f68a22ec051d(Stream xcf18e5243f8d5fd3)
	{
		x93ce70fb4ad3e4ab = new x755940550ade8e52(xcf18e5243f8d5fd3);
		x73132d31ee0204ab = new FileFormatInfo();
		try
		{
			if (!xd37209c66b603c4a() && !x49c42236a5e1a9a3() && !x164adc8b8bff53b7())
			{
				xddf63f6fc7814643();
			}
		}
		finally
		{
			x93ce70fb4ad3e4ab.x0cb17c9decdb2ea1();
		}
		return x73132d31ee0204ab;
	}

	private bool xd37209c66b603c4a()
	{
		xd8c3135513b9115b xd8c3135513b9115b = x93ce70fb4ad3e4ab.x94bca3d4a5b94f61();
		if (xd8c3135513b9115b == null)
		{
			return false;
		}
		if (xd8c3135513b9115b.x25b20c8fab66a43d("\u0006DataSpaces"))
		{
			x73132d31ee0204ab.x9d4c5edc77b82e9e(LoadFormat.Docx);
			x73132d31ee0204ab.xeaa80867023c8b84(x3686d3d908723793: true);
		}
		else if (xd8c3135513b9115b.x25b20c8fab66a43d("WordDocument"))
		{
			x8aeace2bf92692ab x8aeace2bf92692ab = new x8aeace2bf92692ab(new BinaryReader(xd8c3135513b9115b.xc99244dbac07283d("WordDocument")), null);
			if (x8aeace2bf92692ab.x3bf62ca21be92f49)
			{
				x73132d31ee0204ab.x9d4c5edc77b82e9e(LoadFormat.DocPreWord97);
			}
			else
			{
				x73132d31ee0204ab.x9d4c5edc77b82e9e(x8aeace2bf92692ab.x6e7b4319da225d18 ? LoadFormat.Dot : LoadFormat.Doc);
			}
			x73132d31ee0204ab.xeaa80867023c8b84(x8aeace2bf92692ab.xa07212033002e423);
			bool x6826d133226dba = xd8c3135513b9115b.x25b20c8fab66a43d("_xmlsignatures") || xd8c3135513b9115b.x25b20c8fab66a43d("_signatures");
			x73132d31ee0204ab.x8f26221a4a86f4ff(x6826d133226dba);
		}
		bool flag = x73132d31ee0204ab.LoadFormat != LoadFormat.Unknown;
		x1397becc000d27f0 = (flag ? xd8c3135513b9115b : null);
		return x73132d31ee0204ab.LoadFormat != LoadFormat.Unknown;
	}

	private bool x49c42236a5e1a9a3()
	{
		xc5d5cabda4535c40 xc5d5cabda4535c = x93ce70fb4ad3e4ab.x59a8246b79e928e3();
		if (xc5d5cabda4535c == null)
		{
			return false;
		}
		while (xc5d5cabda4535c.xa10f9c7d6062e4a9())
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(xc5d5cabda4535c.x2b9ddc3bb222d878, "[Content_Types].xml"))
			{
				x73132d31ee0204ab.x9d4c5edc77b82e9e(xae13d15563a3a703.x6c4f542a03d83ce6(xc5d5cabda4535c.x2b03692de8748ac6()));
			}
			else if (x0d299f323d241756.x90637a473b1ceaaa(xc5d5cabda4535c.x2b9ddc3bb222d878, "_rels/.rels"))
			{
				x73132d31ee0204ab.x8f26221a4a86f4ff(xae13d15563a3a703.x727228e6a08acf61(xc5d5cabda4535c.x2b03692de8748ac6()));
			}
			else if (x0d299f323d241756.x90637a473b1ceaaa(xc5d5cabda4535c.x2b9ddc3bb222d878, "mimetype"))
			{
				x73132d31ee0204ab.x9d4c5edc77b82e9e(xf871da68decec406.x6c4f542a03d83ce6(xc5d5cabda4535c.x2b03692de8748ac6()));
			}
			else if (x0d299f323d241756.x90637a473b1ceaaa(xc5d5cabda4535c.x2b9ddc3bb222d878, "META-INF/manifest.xml"))
			{
				x73132d31ee0204ab.xeaa80867023c8b84(xf871da68decec406.xa4167addc9c6947c(xc5d5cabda4535c.x2b03692de8748ac6()));
			}
			else if (x0d299f323d241756.x90637a473b1ceaaa(xc5d5cabda4535c.x2b9ddc3bb222d878, "META-INF/documentsignatures.xml"))
			{
				x73132d31ee0204ab.x8f26221a4a86f4ff(xf871da68decec406.x727228e6a08acf61(xc5d5cabda4535c.x2b03692de8748ac6()));
			}
		}
		return x73132d31ee0204ab.LoadFormat != LoadFormat.Unknown;
	}

	private bool x164adc8b8bff53b7()
	{
		bool flag = x93ce70fb4ad3e4ab.xbd833075798c6c66("{\\rtf");
		if (flag)
		{
			x73132d31ee0204ab.x9d4c5edc77b82e9e(LoadFormat.Rtf);
		}
		return flag;
	}

	private bool xe552714a673186c4()
	{
		FileFormatInfo fileFormatInfo = x520e4348f42e9be5.xdef7f68a22ec051d(x93ce70fb4ad3e4ab);
		if (fileFormatInfo != null)
		{
			x73132d31ee0204ab = fileFormatInfo;
			return true;
		}
		return false;
	}

	private bool xddf63f6fc7814643()
	{
		if (xe552714a673186c4())
		{
			return true;
		}
		FileFormatInfo fileFormatInfo = null;
		x93ce70fb4ad3e4ab.x880181c35bd690f5();
		do
		{
			if (x44e356050168eff3())
			{
				return true;
			}
			if (fileFormatInfo == null)
			{
				fileFormatInfo = x15c10e3900d59861();
			}
		}
		while (x93ce70fb4ad3e4ab.xcdbb4957df38d59b());
		if (fileFormatInfo != null)
		{
			x73132d31ee0204ab = fileFormatInfo;
			return true;
		}
		return false;
	}

	private bool x44e356050168eff3()
	{
		if (!x89eaad14946897c2() && !xd369e6c2a156a417())
		{
			return xee9ac33055fcc4a0();
		}
		return true;
	}

	private bool xee9ac33055fcc4a0()
	{
		FileFormatInfo fileFormatInfo = x5b6d43a151149c74.xdef7f68a22ec051d(x93ce70fb4ad3e4ab);
		if (fileFormatInfo != null)
		{
			x73132d31ee0204ab = fileFormatInfo;
			return true;
		}
		return false;
	}

	private FileFormatInfo x15c10e3900d59861()
	{
		x93ce70fb4ad3e4ab.x22f29aa43d600533();
		return xa2f459f6e958df68.xdef7f68a22ec051d(x93ce70fb4ad3e4ab);
	}

	private bool x89eaad14946897c2()
	{
		bool flag = x93ce70fb4ad3e4ab.x263d579af1d0d43f("<w:wordDocument");
		if (flag)
		{
			x73132d31ee0204ab.x9d4c5edc77b82e9e(LoadFormat.WordML);
		}
		return flag;
	}

	private bool xd369e6c2a156a417()
	{
		bool flag = x93ce70fb4ad3e4ab.x263d579af1d0d43f("<pkg:package") && x93ce70fb4ad3e4ab.x263d579af1d0d43f("Word.Document");
		if (flag)
		{
			x252c4abfc5a8ee00 x252c4abfc5a8ee = x93ce70fb4ad3e4ab.x41ceed55f7eb173f();
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x252c4abfc5a8ee.x4bfdbcbc6a51d705(null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");
			switch (xa2f1c3dcbd86f20a.x0b93856f95be30d0)
			{
			case "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml":
				x73132d31ee0204ab.x9d4c5edc77b82e9e(LoadFormat.FlatOpc);
				break;
			case "application/vnd.ms-word.document.macroEnabled.main+xml":
				x73132d31ee0204ab.x9d4c5edc77b82e9e(LoadFormat.FlatOpcMacroEnabled);
				break;
			case "application/vnd.openxmlformats-officedocument.wordprocessingml.template.main+xml":
				x73132d31ee0204ab.x9d4c5edc77b82e9e(LoadFormat.FlatOpcTemplate);
				break;
			case "application/vnd.ms-word.template.macroEnabledTemplate.main+xml":
				x73132d31ee0204ab.x9d4c5edc77b82e9e(LoadFormat.FlatOpcTemplateMacroEnabled);
				break;
			default:
				flag = false;
				break;
			}
		}
		return flag;
	}
}
