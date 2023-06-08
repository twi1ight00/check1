using System.Collections;
using System.IO;
using Aspose.Words;
using x28925c9b27b37a46;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xeb665d1aeef09d64;
using xf989f31a236ff98c;

namespace xce0136f05681c5e9;

internal class xdf1dc37b28b425e3 : DocumentVisitor, xaa47e6d0b035aea6
{
	private x08802e9e984cd3ee x5a7a1d229173bf5d;

	private xd345c73dd1b16b74 xc0d087858ac2d6fc;

	private Hashtable x36facfe5b047fa60;

	private Hashtable x942b2625287f2853;

	private x26ee10d60756aeab xd6085637aa45b586;

	internal xd345c73dd1b16b74 x39ca55b691f96321 => xc0d087858ac2d6fc;

	public override VisitorAction VisitDocumentStart(Document doc)
	{
		x5a7a1d229173bf5d = new x08802e9e984cd3ee(this, doc.CompatibilityOptions);
		xc0d087858ac2d6fc = new xd345c73dd1b16b74();
		x36facfe5b047fa60 = new Hashtable();
		x942b2625287f2853 = new Hashtable();
		xd6085637aa45b586 = doc.FontInfos.x26ee10d60756aeab;
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph paragraph)
	{
		if (paragraph.xbc0119d7471ef12e)
		{
			x5a7a1d229173bf5d.xd22cb714335f8d2c(paragraph.ListLabel.LabelString, paragraph.ListLabel.Font);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRun(Run run)
	{
		if (run.Text.Length != 0)
		{
			x5a7a1d229173bf5d.xd22cb714335f8d2c(run.Text, run.Font);
		}
		return VisitorAction.Continue;
	}

	private void x33557a3be0b1f84f(Font x26094932cf7a9139, string xb41faee6912a2313, x000f21cbda739311 xcb075c7088c3b520)
	{
		x7b406e7da61917fd(x26094932cf7a9139, xb41faee6912a2313, xcb075c7088c3b520);
	}

	void xaa47e6d0b035aea6.x4fb8d507f4b3c96e(Font x26094932cf7a9139, string xb41faee6912a2313, x000f21cbda739311 xcb075c7088c3b520)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x33557a3be0b1f84f
		this.x33557a3be0b1f84f(x26094932cf7a9139, xb41faee6912a2313, xcb075c7088c3b520);
	}

	private void x541fe4f97f6116ea(Font x26094932cf7a9139)
	{
	}

	void xaa47e6d0b035aea6.xa2b89eef4b059bae(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x541fe4f97f6116ea
		this.x541fe4f97f6116ea(x26094932cf7a9139);
	}

	private void x2e952fbfe11ed7f6(Font x26094932cf7a9139)
	{
	}

	void xaa47e6d0b035aea6.x284f8021a6d47363(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x2e952fbfe11ed7f6
		this.x2e952fbfe11ed7f6(x26094932cf7a9139);
	}

	private void xec9101c87d930bb3(Font x26094932cf7a9139)
	{
	}

	void xaa47e6d0b035aea6.x6597dd39dd2fe401(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xec9101c87d930bb3
		this.xec9101c87d930bb3(x26094932cf7a9139);
	}

	private void x80eec05816a3ec1b(Font x26094932cf7a9139)
	{
	}

	void xaa47e6d0b035aea6.x52597787a113eeb0(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x80eec05816a3ec1b
		this.x80eec05816a3ec1b(x26094932cf7a9139);
	}

	private void x02a5eaaf390df90d(Font x26094932cf7a9139)
	{
	}

	void xaa47e6d0b035aea6.x3d5e17ecf5a24632(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x02a5eaaf390df90d
		this.x02a5eaaf390df90d(x26094932cf7a9139);
	}

	private void x4fceccea53b83084(Font x26094932cf7a9139)
	{
	}

	void xaa47e6d0b035aea6.x036788cf7c188d59(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4fceccea53b83084
		this.x4fceccea53b83084(x26094932cf7a9139);
	}

	private void x998f7a5af86f30ac(Font x26094932cf7a9139)
	{
		x7b406e7da61917fd(x26094932cf7a9139, "‑", x000f21cbda739311.x175297738c8b8d1e);
	}

	void xaa47e6d0b035aea6.x85c770ad4ef06982(Font x26094932cf7a9139)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x998f7a5af86f30ac
		this.x998f7a5af86f30ac(x26094932cf7a9139);
	}

	private void x6b648cb838324cb3(Font x26094932cf7a9139)
	{
		x7b406e7da61917fd(x26094932cf7a9139, "\u00ad", x000f21cbda739311.x175297738c8b8d1e);
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

	private void x7b406e7da61917fd(Font x26094932cf7a9139, string xb41faee6912a2313, x000f21cbda739311 xcb075c7088c3b520)
	{
		x6b1a899052c71a60 x26094932cf7a9140 = xd6085637aa45b586.FetchTTFont(x26094932cf7a9139.xaf95fb496eb25433(xcb075c7088c3b520), x26094932cf7a9139.xfa47517dba72fd20, null);
		xcd986872cf3bcf68 xcd986872cf3bcf = x5fa376febd884803(x26094932cf7a9140);
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			xcd986872cf3bcf.x3452aa488cc9006d(item);
		}
	}

	private xcd986872cf3bcf68 x5fa376febd884803(x6b1a899052c71a60 x26094932cf7a9139)
	{
		string key = x7895765729585fbf(x26094932cf7a9139);
		xcd986872cf3bcf68 xcd986872cf3bcf = (xcd986872cf3bcf68)xc0d087858ac2d6fc[key];
		if (xcd986872cf3bcf == null)
		{
			xcd986872cf3bcf = x26094932cf7a9139.x78789688b9fe78d2(x4867e759695b4319: false);
			xc0d087858ac2d6fc[key] = xcd986872cf3bcf;
		}
		return xcd986872cf3bcf;
	}

	private string x7895765729585fbf(x6b1a899052c71a60 x26094932cf7a9139)
	{
		string text = (string)x36facfe5b047fa60[x26094932cf7a9139];
		if (text == null)
		{
			text = Path.GetFileName(x26094932cf7a9139.xa39af5a82860a9a3).ToLower();
			int num = 0;
			if (x942b2625287f2853.ContainsKey(text))
			{
				object obj = x942b2625287f2853[text];
				num = ((obj == null) ? 1 : ((int)obj + 1));
			}
			else
			{
				x942b2625287f2853[text] = null;
			}
			if (num != 0)
			{
				text = $"{Path.GetFileNameWithoutExtension(text)}_{num}{Path.GetExtension(text)}";
			}
			x36facfe5b047fa60.Add(x26094932cf7a9139, text);
		}
		return text;
	}
}
