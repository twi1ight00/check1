using System;
using System.Drawing;
using System.Drawing.Printing;
using Aspose.Slides;

namespace ns12;

internal class Class198 : PrintDocument
{
	private readonly Presentation presentation_0;

	private int int_0;

	private int int_1;

	public Class198(Presentation presentation)
	{
		if (presentation == null)
		{
			throw new ArgumentNullException("presentation");
		}
		presentation_0 = presentation;
	}

	protected override void OnBeginPrint(PrintEventArgs e)
	{
		base.OnBeginPrint(e);
		switch (base.PrinterSettings.PrintRange)
		{
		case PrintRange.AllPages:
			int_0 = 1;
			int_1 = presentation_0.Slides.Count;
			break;
		default:
			throw new InvalidOperationException("Unsupported print range.");
		case PrintRange.SomePages:
			int_0 = base.PrinterSettings.FromPage;
			int_1 = base.PrinterSettings.ToPage;
			break;
		}
	}

	protected override void OnPrintPage(PrintPageEventArgs e)
	{
		base.OnPrintPage(e);
		float num = (float)(e.PageSettings.Bounds.Width * e.PageSettings.PrinterResolution.X) / 100f;
		float num2 = (float)(e.PageSettings.Bounds.Height * e.PageSettings.PrinterResolution.Y) / 100f;
		float width = presentation_0.SlideSize.Size.Width;
		float height = presentation_0.SlideSize.Size.Height;
		float num3 = num / width;
		float num4 = num2 / height;
		float num5 = width / height;
		if (num3 < num4)
		{
			width = e.PageSettings.Bounds.Width;
			height = width / num5;
		}
		else
		{
			height = e.PageSettings.Bounds.Height;
			width = height * num5;
		}
		RectangleF rect = new RectangleF(0f, 0f, width - e.PageSettings.HardMarginX * 2.5f, height - e.PageSettings.HardMarginY * 2.5f);
		Image thumbnail = presentation_0.Slides[int_0 - 1].GetThumbnail(2f, 2f);
		e.Graphics.DrawImage(thumbnail, rect);
		int_0++;
		e.HasMorePages = int_0 <= int_1;
	}
}
