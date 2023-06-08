using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using x28925c9b27b37a46;
using x59d6a4fc5007b7a4;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Rendering;

public class PageInfo
{
	private readonly SizeF x38c52850c18e3a74;

	private readonly int xf2db2832ca3b4c39;

	private readonly bool x4845987f866b7a91;

	private static readonly Hashtable x9cd6f2a03617f1a7;

	public PaperSize PaperSize => xb7dbd7bb3ed97d5b.xca878d9befa76e8f(x4574ea26106f0edb.x88bf16f2386d633e(x38c52850c18e3a74.Width), x4574ea26106f0edb.x88bf16f2386d633e(x38c52850c18e3a74.Height), x4845987f866b7a91);

	public float WidthInPoints => x38c52850c18e3a74.Width;

	public float HeightInPoints => x38c52850c18e3a74.Height;

	public SizeF SizeInPoints => x38c52850c18e3a74;

	internal int x241314909c687dab => x15e971129fd80714.x43fcc3f62534530b(x4574ea26106f0edb.xc4ed0440a9ee9c3e(x38c52850c18e3a74.Width) * 100.0);

	internal int xb3daa4cd0aa0abaa => x15e971129fd80714.x43fcc3f62534530b(x4574ea26106f0edb.xc4ed0440a9ee9c3e(x38c52850c18e3a74.Height) * 100.0);

	public int PaperTray => xf2db2832ca3b4c39;

	public bool Landscape => x4845987f866b7a91;

	internal PageInfo(xdcf47a8f1807f37c page)
	{
		x38c52850c18e3a74 = new SizeF(page.xdc1bf80853046136, page.xb0f146032f47c24e);
		xf2db2832ca3b4c39 = page.xa65184d44a47025b.xef64f56541986736;
		x4845987f866b7a91 = page.xa65184d44a47025b.x2c5926113e101674 == Orientation.Landscape;
	}

	public Size GetSizeInPixels(float scale, float dpi)
	{
		return x4574ea26106f0edb.x4bec21b1de9d1b5b(x38c52850c18e3a74, scale, dpi);
	}

	[JavaDelete("Not porting to Java.")]
	public System.Drawing.Printing.PaperSize GetDotNetPaperSize(PrinterSettingsContainer printerSettings)
	{
		if (printerSettings == null)
		{
			throw new ArgumentNullException("printerSettings");
		}
		PaperKind paperKind = x307a1bf817232313(PaperSize);
		if (paperKind != 0)
		{
			foreach (System.Drawing.Printing.PaperSize paperSize in printerSettings.PaperSizes)
			{
				if (paperSize.Kind == paperKind)
				{
					return paperSize;
				}
			}
		}
		return new System.Drawing.Printing.PaperSize("Custom", x241314909c687dab, xb3daa4cd0aa0abaa);
	}

	[JavaDelete("Not porting to Java.")]
	private static PaperKind x307a1bf817232313(PaperSize x9dc84f7137b23608)
	{
		object obj = x9cd6f2a03617f1a7[x9dc84f7137b23608];
		if (obj == null)
		{
			return PaperKind.Custom;
		}
		return (PaperKind)obj;
	}

	[JavaDelete("Not porting to Java.")]
	public PaperSource GetSpecifiedPrinterPaperSource(PrinterSettingsContainer printerSettings)
	{
		if (printerSettings == null)
		{
			throw new ArgumentNullException("printerSettings");
		}
		foreach (PaperSource paperSource in printerSettings.PaperSources)
		{
			if (paperSource.RawKind == PaperTray)
			{
				return paperSource;
			}
		}
		return printerSettings.DefaultPageSettingsPaperSource;
	}

	static PageInfo()
	{
		x9cd6f2a03617f1a7 = new Hashtable();
		x9cd6f2a03617f1a7.Add(PaperSize.A3, PaperKind.A3);
		x9cd6f2a03617f1a7.Add(PaperSize.A4, PaperKind.A4);
		x9cd6f2a03617f1a7.Add(PaperSize.A5, PaperKind.A5);
		x9cd6f2a03617f1a7.Add(PaperSize.B4, PaperKind.B4);
		x9cd6f2a03617f1a7.Add(PaperSize.B5, PaperKind.B5);
		x9cd6f2a03617f1a7.Add(PaperSize.Custom, PaperKind.Custom);
		x9cd6f2a03617f1a7.Add(PaperSize.EnvelopeDL, PaperKind.DLEnvelope);
		x9cd6f2a03617f1a7.Add(PaperSize.Executive, PaperKind.Executive);
		x9cd6f2a03617f1a7.Add(PaperSize.Folio, PaperKind.Folio);
		x9cd6f2a03617f1a7.Add(PaperSize.Ledger, PaperKind.Ledger);
		x9cd6f2a03617f1a7.Add(PaperSize.Legal, PaperKind.Legal);
		x9cd6f2a03617f1a7.Add(PaperSize.Letter, PaperKind.Letter);
		x9cd6f2a03617f1a7.Add(PaperSize.Paper10x14, PaperKind.Standard10x14);
		x9cd6f2a03617f1a7.Add(PaperSize.Paper11x17, PaperKind.Standard11x17);
		x9cd6f2a03617f1a7.Add(PaperSize.Quarto, PaperKind.Quarto);
		x9cd6f2a03617f1a7.Add(PaperSize.Statement, PaperKind.Statement);
		x9cd6f2a03617f1a7.Add(PaperSize.Tabloid, PaperKind.Tabloid);
	}
}
