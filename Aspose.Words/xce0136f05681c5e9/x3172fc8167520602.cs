using Aspose.Words;
using Aspose.Words.Lists;
using Aspose.Words.Saving;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;
using xf989f31a236ff98c;

namespace xce0136f05681c5e9;

internal class x3172fc8167520602 : xc962dd50add9c406
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly HtmlSaveOptions x39a547a368d84104;

	private readonly xe98f79ab11a30ea7 x051c9719927a1ad1;

	private readonly xe2ff3c3cd396cfd9 x09b9574bb5661d62;

	private readonly x08802e9e984cd3ee x5a7a1d229173bf5d;

	private readonly x202941c978357b4f x97af76bcfe95c328;

	private readonly x1cfc9afea06d5324 xb4ae0d7648678478;

	private static readonly int[] xc3cc7238d8b95be7 = new int[3] { 30, 40, 50 };

	internal x3172fc8167520602(Document document, HtmlSaveOptions htmlSaveOptions, xe98f79ab11a30ea7 htmlI18NWriter, xe2ff3c3cd396cfd9 htmlWriterCommon, x08802e9e984cd3ee runWriter, x202941c978357b4f htmlStyleWriter, x1cfc9afea06d5324 navigationPointCollector)
		: base(htmlSaveOptions.x4e3c1d16eaf20ef3)
	{
		xd1424e1a0bb4a72b = document;
		x39a547a368d84104 = htmlSaveOptions;
		x051c9719927a1ad1 = htmlI18NWriter;
		x09b9574bb5661d62 = htmlWriterCommon;
		x5a7a1d229173bf5d = runWriter;
		x97af76bcfe95c328 = htmlStyleWriter;
		xb4ae0d7648678478 = navigationPointCollector;
	}

	protected override void StartListItem(Paragraph para, x1a78664fa10a3755 expandedParaPr, x4ef6b4f19b033b48 paraPositionInBorder)
	{
		x09b9574bb5661d62.xe1410f585439c7d4.x2307058321cdb62f("li");
		if (xb4ae0d7648678478 != null)
		{
			xb4ae0d7648678478.x84bc62e29f758549(x094308e428eb5b33: true, para, expandedParaPr);
		}
		x97af76bcfe95c328.x23c8b7ad9bfc5719(para, expandedParaPr, x1ebf5501f9a725fb: true, paraPositionInBorder);
		x051c9719927a1ad1.xb63df339721c535a(para, expandedParaPr);
	}

	protected override void StartListItemAsNormalParagraph(Paragraph para, x1a78664fa10a3755 expandedParaPr, x4ef6b4f19b033b48 paraPositionInBorder)
	{
		x09b9574bb5661d62.xe1410f585439c7d4.x2307058321cdb62f(x754017e579b6a8ff.x6f4063730e81a2f6(expandedParaPr.x8301ab10c226b0c2));
		if (xb4ae0d7648678478 != null)
		{
			xb4ae0d7648678478.x84bc62e29f758549(x094308e428eb5b33: true, para, expandedParaPr);
		}
		x97af76bcfe95c328.x23c8b7ad9bfc5719(para, expandedParaPr, x1ebf5501f9a725fb: false, paraPositionInBorder);
		x051c9719927a1ad1.xb63df339721c535a(para, expandedParaPr);
	}

	protected override void EndListCore()
	{
		x09b9574bb5661d62.xe1410f585439c7d4.x538f0e0fb2bf15ab();
	}

	protected override void WriteListLableCore(Paragraph para, string labelText)
	{
		if (x39a547a368d84104.CssStyleSheetType == CssStyleSheetType.Inline)
		{
			x5a7a1d229173bf5d.xd22cb714335f8d2c(labelText, para.ListLabel.Font);
			return;
		}
		xeedad81aaed42a76 x344511c4e4ce09da = para.x344511c4e4ce09da;
		bool flag = x344511c4e4ce09da.x8301ab10c226b0c2 != 10 || x344511c4e4ce09da.xa7ee97ddde231678(xc3cc7238d8b95be7);
		if (flag)
		{
			x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6("<span");
			x97af76bcfe95c328.xabeba2b272a12ca7(para.ParagraphBreakFont, x000f21cbda739311.x175297738c8b8d1e, xf544375d86767c28: false);
			x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6(">");
		}
		x5a7a1d229173bf5d.xd22cb714335f8d2c(labelText, para.ListFormat.ListLevel.Font);
		if (flag)
		{
			x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6("</span>");
		}
	}

	protected override void WriteTabSimulationAfterLabel(Paragraph para, x1a78664fa10a3755 expandedParaPr)
	{
		Font font = para.ListLabel.Font;
		xe39d06eee35dd23d xe39d06eee35dd23d = xd1424e1a0bb4a72b.FontInfos.x26ee10d60756aeab.x491f5a7224612753(font.Name, (float)font.Size, font.xfa47517dba72fd20);
		double num = xe39d06eee35dd23d.xee2b4ba51feab3ca(para.ListLabel.LabelString);
		double num2 = x4574ea26106f0edb.x0e1fdb362561ddb2(expandedParaPr.xc7d7e186f0ace1e0);
		double num3 = x4574ea26106f0edb.x0e1fdb362561ddb2(expandedParaPr.xc0741c7ff92cf1aa);
		if (!x39a547a368d84104.AllowNegativeIndent)
		{
			double num4 = num3 + num2;
			if (num4 < 0.0)
			{
				num3 -= num4;
			}
		}
		double num5 = num3 + num2 + num;
		double num6 = 0.0;
		TabStop tabStop = expandedParaPr.x8df6f6ca274123b0?.After(num5);
		double num7 = ((num2 < 0.0) ? (num3 - num5) : 0.0);
		if (tabStop != null)
		{
			num6 = tabStop.Position - num5;
			if (tabStop.Alignment != TabAlignment.List && num7 > 0.0 && num7 < num6)
			{
				num6 = num7;
			}
		}
		else if (num7 > 0.0)
		{
			num6 = num7;
		}
		if (num6 <= 0.0)
		{
			double defaultTabStop = xd1424e1a0bb4a72b.DefaultTabStop;
			if (defaultTabStop > 0.0)
			{
				for (num6 = defaultTabStop - num5; num6 <= 0.0; num6 += defaultTabStop)
				{
				}
			}
		}
		int num8 = (int)(num6 * 0.6857142857142856 + 0.5);
		x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6("<span style=\"font:7.0pt 'Times New Roman'\">");
		if (para.x1a78664fa10a3755.xcedf9c82728ad579)
		{
			x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6("<span dir=\"rtl\"></span>");
		}
		while (--num8 > 0)
		{
			x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6("&#xa0;");
		}
		x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6(" </span>");
	}

	protected override void StartListCore(Paragraph para, ListLevel levelPr)
	{
		if (levelPr.NumberStyle == NumberStyle.None || levelPr.NumberStyle == NumberStyle.Bullet)
		{
			x09b9574bb5661d62.xe1410f585439c7d4.x2307058321cdb62f("ul");
		}
		else
		{
			x09b9574bb5661d62.xe1410f585439c7d4.x2307058321cdb62f("ol");
			int labelValue = para.ListLabel.LabelValue;
			if (!x39a547a368d84104.x4e3c1d16eaf20ef3 && labelValue != 1)
			{
				x09b9574bb5661d62.xe1410f585439c7d4.x943f6be3acf634db("start", labelValue.ToString());
			}
		}
		if (!x39a547a368d84104.x4e3c1d16eaf20ef3)
		{
			x09b9574bb5661d62.xe1410f585439c7d4.xff520a0047c27122("type", x495fdb45f3d92b70.xff194a3741776ee2(levelPr));
		}
		x97af76bcfe95c328.x6403e2e269084313(levelPr, para.ListLabel.Font.Size);
	}
}
