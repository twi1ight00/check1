using System;
using System.Collections;
using System.Drawing.Printing;

namespace Aspose.Words.Rendering;

[JavaManual("The printing framework is different on Java.")]
public class AsposeWordsPrintDocument : PrintDocument
{
	private readonly Document xd1424e1a0bb4a72b;

	private int x2d6df7514a3346cc;

	private int xdef8a3063ecb3f83;

	private PrinterSettingsContainer xfc025884ed1df16b;

	private static readonly Hashtable x447698051be9d1ae = new Hashtable();

	private static readonly object x4d25c27dfd0877ed = new object();

	public AsposeWordsPrintDocument(Document document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		xd1424e1a0bb4a72b = document;
	}

	internal void x8c61bb6b48e3599e()
	{
		base.PrintController = new StandardPrintController();
	}

	protected override void OnBeginPrint(PrintEventArgs e)
	{
		base.OnBeginPrint(e);
		switch (base.PrinterSettings.PrintRange)
		{
		case PrintRange.AllPages:
			x2d6df7514a3346cc = 1;
			xdef8a3063ecb3f83 = xd1424e1a0bb4a72b.PageCount;
			break;
		case PrintRange.SomePages:
			x2d6df7514a3346cc = base.PrinterSettings.FromPage;
			xdef8a3063ecb3f83 = base.PrinterSettings.ToPage;
			break;
		default:
			throw new InvalidOperationException("Unsupported print range.");
		}
		xcb9cc4ea05847956();
	}

	protected override void OnQueryPageSettings(QueryPageSettingsEventArgs e)
	{
		base.OnQueryPageSettings(e);
		PageInfo pageInfo = xd1424e1a0bb4a72b.GetPageInfo(x2d6df7514a3346cc - 1);
		e.PageSettings.PaperSize = pageInfo.GetDotNetPaperSize(xfc025884ed1df16b);
		e.PageSettings.PaperSource = pageInfo.GetSpecifiedPrinterPaperSource(xfc025884ed1df16b);
		e.PageSettings.Landscape = pageInfo.Landscape;
		if (pageInfo.Landscape && pageInfo.PaperSize == PaperSize.Custom)
		{
			int height = e.PageSettings.PaperSize.Height;
			e.PageSettings.PaperSize.Height = e.PageSettings.PaperSize.Width;
			e.PageSettings.PaperSize.Width = height;
		}
	}

	protected override void OnPrintPage(PrintPageEventArgs e)
	{
		base.OnPrintPage(e);
		float hardMarginX = e.PageSettings.HardMarginX;
		float hardMarginY = e.PageSettings.HardMarginY;
		xd1424e1a0bb4a72b.RenderToScale(x2d6df7514a3346cc - 1, e.Graphics, 0f - hardMarginX, 0f - hardMarginY, 1f);
		x2d6df7514a3346cc++;
		e.HasMorePages = x2d6df7514a3346cc <= xdef8a3063ecb3f83;
	}

	private void xcb9cc4ea05847956()
	{
		string printerName = base.PrinterSettings.PrinterName;
		PrinterSettingsContainer printerSettingsContainer;
		lock (x4d25c27dfd0877ed)
		{
			if (x447698051be9d1ae.ContainsKey(printerName))
			{
				printerSettingsContainer = (PrinterSettingsContainer)x447698051be9d1ae[printerName];
			}
			else
			{
				printerSettingsContainer = new PrinterSettingsContainer(base.PrinterSettings);
				x447698051be9d1ae.Add(printerName, printerSettingsContainer);
			}
		}
		xcb9cc4ea05847956(printerSettingsContainer);
	}

	private void xcb9cc4ea05847956(PrinterSettingsContainer x972403b69aa172bc)
	{
		xfc025884ed1df16b = x972403b69aa172bc;
	}
}
