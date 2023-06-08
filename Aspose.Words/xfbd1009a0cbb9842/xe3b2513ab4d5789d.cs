using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xb1090543d168d647;

namespace xfbd1009a0cbb9842;

internal class xe3b2513ab4d5789d : xf83652aff352c801, x4bf4b8af8c9f9e78
{
	private readonly string xbe1b3879b7d92a27;

	internal xe3b2513ab4d5789d(Field field, string result)
		: this(field, result, applyFormat: true)
	{
	}

	internal xe3b2513ab4d5789d(Field field, string result, bool applyFormat)
		: base(field, applyFormat)
	{
		xbe1b3879b7d92a27 = result;
	}

	protected override void ApplyResultCore()
	{
		Document document = base.xd1b40af56a8385d4.x357c90b33d6bb8e6();
		DocumentBuilder documentBuilder = new DocumentBuilder(document);
		xff78a0049b13b904(documentBuilder, base.xd1b40af56a8385d4.End);
		if (document.FieldOptions.IsBidiTextSupportedOnUpdate)
		{
			xc6f06bd555182c09(documentBuilder, xbe1b3879b7d92a27);
		}
		else
		{
			documentBuilder.Write(xbe1b3879b7d92a27);
		}
	}

	private static void xff78a0049b13b904(DocumentBuilder xd07ce4b74c5774a7, Node x22bff10c3dd1f70f)
	{
		xd07ce4b74c5774a7.MoveTo(x22bff10c3dd1f70f);
		Node node = x22bff10c3dd1f70f;
		do
		{
			node = node.PreviousSibling;
		}
		while (!(node is Inline) && node != null);
		Inline inline = (Inline)node;
		if (inline != null && inline.xeedad81aaed42a76.xd44988f225497f3a > 0)
		{
			xd07ce4b74c5774a7.x77184348a27ba1e6(((Inline)node).xeedad81aaed42a76, x692ced34f50137f2: true);
		}
	}

	private void xc6f06bd555182c09(DocumentBuilder xd07ce4b74c5774a7, string xb41faee6912a2313)
	{
		ArrayList arrayList = xc43925ba6f2dd66c.xcd89c6dd6a1b87e6(xb41faee6912a2313, base.xd1b40af56a8385d4.xadf6796b90c1934e(), this);
		foreach (xc43925ba6f2dd66c item in arrayList)
		{
			x6ec39b1b0c66f918[] xdcff38cbdd9cf = item.xdcff38cbdd9cf395;
			foreach (x6ec39b1b0c66f918 x6ec39b1b0c66f in xdcff38cbdd9cf)
			{
				if (x0d299f323d241756.x5959bccb67bbf051(x6ec39b1b0c66f.xf9ad6fb78355fe13))
				{
					xeedad81aaed42a76 xeedad81aaed42a = xd07ce4b74c5774a7.xdbd6535b15eacda9();
					if (x6ec39b1b0c66f.x0b228ef3d2b6a257)
					{
						xeedad81aaed42a.xcedf9c82728ad579 = x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
					}
					else
					{
						xeedad81aaed42a.x52b190e626f65140(265);
					}
					xd07ce4b74c5774a7.InsertNode(new Run(xd07ce4b74c5774a7.Document, x6ec39b1b0c66f.xf9ad6fb78355fe13, xeedad81aaed42a));
				}
			}
			if (x0d299f323d241756.x5959bccb67bbf051(item.x05db5df9789b24d9))
			{
				xd07ce4b74c5774a7.InsertParagraph();
			}
		}
	}

	private void xaf8eb5480ec6ab10(xc43925ba6f2dd66c x31e6518f5e08db6c, x61828b8ede430221[] x4b696a8ebe1f485a)
	{
		int xbd9ab1dea014f = x31e6518f5e08db6c.x3a03159a374ab4fd;
		foreach (x61828b8ede430221 x61828b8ede in x4b696a8ebe1f485a)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a = x61828b8ede.xbf7d698e3d6d1a49;
			if (xbf7d698e3d6d1a == xd2d2b731b30d7023.x311782148482223b || xbf7d698e3d6d1a == xd2d2b731b30d7023.x8b8c96d3cd6915df)
			{
				x61828b8ede.xbd9ab1dea014f991 = xbd9ab1dea014f;
			}
			else
			{
				xbd9ab1dea014f = x61828b8ede.xbd9ab1dea014f991;
			}
		}
	}

	void x4bf4b8af8c9f9e78.x57f70b425b43a885(xc43925ba6f2dd66c x31e6518f5e08db6c, x61828b8ede430221[] x4b696a8ebe1f485a)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xaf8eb5480ec6ab10
		this.xaf8eb5480ec6ab10(x31e6518f5e08db6c, x4b696a8ebe1f485a);
	}
}
