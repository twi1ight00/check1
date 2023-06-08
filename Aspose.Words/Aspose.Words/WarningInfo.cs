using System;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class WarningInfo
{
	private readonly WarningType xc4b78473595712bd;

	private readonly WarningSource xc14c8280921f4967;

	private readonly string x82cab886de347dba;

	public WarningType WarningType => xc4b78473595712bd;

	public string Description => x82cab886de347dba;

	public WarningSource Source => xc14c8280921f4967;

	internal WarningInfo(WarningType warningType, WarningSource source, string description)
	{
		xc4b78473595712bd = warningType;
		xc14c8280921f4967 = source;
		x82cab886de347dba = description;
	}

	internal static WarningType x0e253203059fba0d(x6d058fdf61831c39 x2a14ac2bd5c81099)
	{
		return x2a14ac2bd5c81099 switch
		{
			x6d058fdf61831c39.x42daab0e7e499260 => WarningType.DataLoss, 
			x6d058fdf61831c39.x3d55d2f5d9d21184 => WarningType.MajorFormattingLoss, 
			x6d058fdf61831c39.x13efdeb5b4f0d186 => WarningType.MinorFormattingLoss, 
			x6d058fdf61831c39.x73d48b73a1b487ac => WarningType.FontSubstitution, 
			x6d058fdf61831c39.x65def832e35c82b0 => WarningType.UnexpectedContent, 
			_ => WarningType.MinorFormattingLoss, 
		};
	}

	internal static WarningSource xe21c54c20bac02ec(x3959df40367ac8a3 xc781fde78436dbc3)
	{
		return xc781fde78436dbc3 switch
		{
			x3959df40367ac8a3.xe42bd130f1e95570 => WarningSource.Shapes, 
			x3959df40367ac8a3.xc37a0b27f6a0dfd4 => WarningSource.DrawingML, 
			x3959df40367ac8a3.x5459fadea977d08d => WarningSource.Metafile, 
			x3959df40367ac8a3.xffe454f29a855c10 => WarningSource.Swf, 
			x3959df40367ac8a3.x64a7e1d48dfb2e43 => WarningSource.Xps, 
			x3959df40367ac8a3.x6fcc29eace04fce1 => WarningSource.Pdf, 
			x3959df40367ac8a3.xa460a0b649265441 => WarningSource.Image, 
			x3959df40367ac8a3.x2445f4cefb3cff80 => WarningSource.Layout, 
			_ => WarningSource.Unknown, 
		};
	}

	internal static string xc0178e023f7702e3(WarningSource x697d2859ebdde9ec)
	{
		return x697d2859ebdde9ec switch
		{
			WarningSource.Unknown => "Unknown", 
			WarningSource.Layout => "Layout", 
			WarningSource.DrawingML => "DrawingML", 
			WarningSource.OfficeMath => "OfficeMath", 
			WarningSource.Shapes => "Shapes", 
			WarningSource.Metafile => "Metafile", 
			WarningSource.Swf => "Swf", 
			WarningSource.Xps => "Xps", 
			WarningSource.Pdf => "Pdf", 
			WarningSource.Image => "Image", 
			WarningSource.Docx => "Docx", 
			WarningSource.Doc => "Doc", 
			WarningSource.Text => "Text", 
			WarningSource.Rtf => "Rtf", 
			WarningSource.WordML => "WordML", 
			WarningSource.Nrx => "Nrx", 
			WarningSource.Odt => "Odt", 
			WarningSource.Html => "Html", 
			_ => throw new ArgumentOutOfRangeException("warningSource"), 
		};
	}

	internal static WarningInfo xef3486beca5d0ebc(xe82e7ab706bd4d43 x71c9e1f82f2f02b5)
	{
		return new WarningInfo(x0e253203059fba0d(x71c9e1f82f2f02b5.xe000a5d50fd06280), xe21c54c20bac02ec(x71c9e1f82f2f02b5.xaf77e81a71d6921f), x71c9e1f82f2f02b5.x3d235fc95c355365);
	}
}
