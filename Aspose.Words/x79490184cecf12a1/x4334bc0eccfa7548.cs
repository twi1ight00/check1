using System;
using System.Collections;
using Aspose.Words;
using x13f1efc79617a47b;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;
using xf9a9481c3f63a419;

namespace x79490184cecf12a1;

internal class x4334bc0eccfa7548
{
	private readonly x11e1346c12ead315 x7450cc1e48712286;

	private readonly Hashtable x69faaca472e2db29 = new Hashtable();

	private readonly Hashtable xacd1ddd0093177b4 = new Hashtable();

	internal x4334bc0eccfa7548(x11e1346c12ead315 reader)
	{
		x7450cc1e48712286 = reader;
		x06b0e25aa6ad68a9(FootnoteType.Footnote);
		x06b0e25aa6ad68a9(FootnoteType.Endnote);
	}

	internal Footnote x3e5f4bed8c6ef7e6(FootnoteType xd3526c7313d75391, int xeaf1b27180c0557b)
	{
		return xd3526c7313d75391 switch
		{
			FootnoteType.Endnote => (Footnote)x69faaca472e2db29[xeaf1b27180c0557b], 
			FootnoteType.Footnote => (Footnote)xacd1ddd0093177b4[xeaf1b27180c0557b], 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fjfmlkmmfkdnfkkndkboikiomjpolegpoinpejeabjladjcbkijbiiackihcihocadfdbimddidehhkejgbfpcif", 493405504))), 
		};
	}

	private void x06b0e25aa6ad68a9(FootnoteType xd3526c7313d75391)
	{
		string x061610664b4c984f;
		string text;
		Hashtable hashtable;
		bool x26f77e2004716cc;
		switch (xd3526c7313d75391)
		{
		case FootnoteType.Footnote:
			x061610664b4c984f = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/footnotes";
			text = "footnote";
			hashtable = xacd1ddd0093177b4;
			x26f77e2004716cc = false;
			break;
		case FootnoteType.Endnote:
			x061610664b4c984f = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/endnotes";
			text = "endnote";
			hashtable = x69faaca472e2db29;
			x26f77e2004716cc = true;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ggnfmhegghlgghchehjhjhainghimboipffjfgmjcgdkegkklfbljfillfpljegmbanmcfeneflniecokdjoaaap", 270097681)));
		}
		x3c85359e1389ad43 x3c85359e1389ad = x7450cc1e48712286.x1b1aeab2a2e668c4(x061610664b4c984f);
		if (x3c85359e1389ad == null)
		{
			return;
		}
		x3c85359e1389ad.x99f8cdb2827fa686();
		string xa66385d80d4d296f = x3c85359e1389ad.xa66385d80d4d296f;
		while (x3c85359e1389ad.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			if (x3c85359e1389ad.xa66385d80d4d296f == text)
			{
				x101cddc73c4f8cc2 x101cddc73c4f8cc = x101cddc73c4f8cc2.xe9e531d1a6725226;
				string text2 = null;
				while (x3c85359e1389ad.x1ac1960adc8c4c39())
				{
					switch (x3c85359e1389ad.xa66385d80d4d296f)
					{
					case "type":
						x101cddc73c4f8cc = xc62574be95c1c918.xa08f827e6da598ab(x3c85359e1389ad.xd2f68ee6f47e9dfb, x26f77e2004716cc);
						break;
					case "id":
						text2 = x3c85359e1389ad.xd2f68ee6f47e9dfb;
						break;
					}
				}
				if (x0d299f323d241756.x5959bccb67bbf051(text2))
				{
					if (x101cddc73c4f8cc == x101cddc73c4f8cc2.xe9e531d1a6725226)
					{
						Footnote footnote = new Footnote(x7450cc1e48712286.x2c8c6741422a1298, xd3526c7313d75391);
						xce4dd62ad1252b05.x06b0e25aa6ad68a9(x7450cc1e48712286, footnote);
						hashtable[xca004f56614e2431.x59884ab46dd0d856(text2)] = footnote;
					}
					else
					{
						xa1e2a8ed32a026dd xa1e2a8ed32a026dd = new xa1e2a8ed32a026dd(x7450cc1e48712286.x2c8c6741422a1298, x101cddc73c4f8cc);
						xce4dd62ad1252b05.x06b0e25aa6ad68a9(x7450cc1e48712286, xa1e2a8ed32a026dd);
						x7450cc1e48712286.x2c8c6741422a1298.x245aa7750b4a8072.set_xe6d4b1b411ed94b5(x101cddc73c4f8cc, xa1e2a8ed32a026dd);
					}
				}
			}
			else
			{
				x3c85359e1389ad.IgnoreElement();
			}
		}
		x7450cc1e48712286.xc8ab4e294c74831b();
	}
}
