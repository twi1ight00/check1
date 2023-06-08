using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;
using ns11;
using ns218;
using ns220;
using ns221;
using ns235;
using ns237;
using ns4;

namespace ns12;

internal class Class197
{
	internal static void smethod_0(Presentation pres, Stream stream, PdfOptions pdfOptions, ISaveOptions saveOptions)
	{
		if (pres.Slides.Count != 0)
		{
			Dictionary<string, Class64> imageCache = new Dictionary<string, Class64>();
			SizeF sizeF = new SizeF((float)Class5955.smethod_10(pres.SlideSize.Size.Width, 576.0), (float)Class5955.smethod_10(pres.SlideSize.Size.Height, 576.0));
			Class6197 @class = new Class6197(stream, pdfOptions.method_1(saveOptions));
			Class6216 class2 = new Class6216(sizeF.Width, sizeF.Height);
			Class170 class3 = new Class170();
			class3.bool_3 = true;
			class3.bool_0 = true;
			Class6213 node = ((Slide)pres.Slides[0]).method_16(pdfOptions.SaveMetafilesAsPng, pdfOptions, imageCache, class3);
			class2.Add(node);
			@class.method_0(class2);
			Class5956 info = @class.PdfDocument.Info;
			IDocumentProperties documentProperties = pres.DocumentProperties;
			info.Creator = "Aspose.Slides for .NET 15.1.0.0";
			info.Author = documentProperties.Author;
			info.Category = documentProperties.Category;
			info.CreationDate = documentProperties.CreatedTime;
			info.Description = documentProperties.Comments;
			info.GeneratorName = "Aspose.Slides for .NET 15.1.0.0";
			info.Keywords = documentProperties.Keywords;
			info.LastModifiedBy = documentProperties.LastSavedBy;
			info.LastPrinted = documentProperties.LastPrinted;
			info.ModifiedDate = documentProperties.LastSavedTime;
			info.Revision = documentProperties.RevisionNumber.ToString();
			info.Subject = documentProperties.Subject;
			info.Title = documentProperties.Title;
			@class.method_1();
			stream.Flush();
		}
	}

	internal static void smethod_1(Presentation pres, Stream stream, PdfOptions pdfOptions, ISaveOptions saveOptions)
	{
		int[] array = new int[pres.Slides.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = i + 1;
		}
		smethod_2(pres, stream, array, pdfOptions, saveOptions);
	}

	internal static void smethod_2(Presentation pres, Stream stream, int[] slides, PdfOptions pdfOptions, ISaveOptions saveOptions)
	{
		Stream stream2 = (stream.CanSeek ? stream : new MemoryStream());
		Dictionary<string, Class64> dictionary = new Dictionary<string, Class64>();
		SizeF sizeF = new SizeF((float)Class5955.smethod_10(pres.SlideSize.Size.Width, 72.0), (float)Class5955.smethod_10(pres.SlideSize.Size.Height, 72.0));
		Class6197 @class = new Class6197(stream2, pdfOptions.method_1(saveOptions));
		Class170 class2 = new Class170();
		class2.bool_3 = true;
		class2.bool_0 = true;
		class2.iwarningCallback_0 = pdfOptions.WarningCallback;
		class2.byte_0 = pdfOptions.JpegQuality;
		class2.float_1 = pdfOptions.SufficientResolution;
		try
		{
			foreach (int num in slides)
			{
				if (num >= 1 && num <= pres.Slides.Count)
				{
					Slide slide = (Slide)pres.Slides[num - 1];
					if (slide != null)
					{
						Class6216 class3 = new Class6216(sizeF.Width, sizeF.Height);
						Class6213 node = slide.method_16(pdfOptions.SaveMetafilesAsPng, pdfOptions, dictionary, class2);
						class3.Add(node);
						@class.method_0(class3);
					}
				}
			}
			Class5956 info = @class.PdfDocument.Info;
			IDocumentProperties documentProperties = pres.DocumentProperties;
			info.Creator = "Aspose.Slides for .NET 15.1.0.0";
			info.Author = documentProperties.Author;
			info.Category = documentProperties.Category;
			info.CreationDate = documentProperties.CreatedTime;
			info.Description = documentProperties.Comments;
			info.GeneratorName = "Aspose.Slides for .NET 15.1.0.0";
			info.Keywords = documentProperties.Keywords;
			info.LastModifiedBy = documentProperties.LastSavedBy;
			info.LastPrinted = documentProperties.LastPrinted;
			info.ModifiedDate = documentProperties.LastSavedTime;
			info.Revision = documentProperties.RevisionNumber.ToString();
			info.Subject = documentProperties.Subject;
			info.Title = documentProperties.Title;
			@class.method_1();
			stream2.Flush();
			if (stream2 != stream)
			{
				((MemoryStream)stream2).WriteTo(stream);
			}
		}
		finally
		{
			foreach (Class64 value in dictionary.Values)
			{
				((IDisposable)value).Dispose();
			}
		}
	}

	internal static void smethod_3(Presentation pres, Stream stream, XpsOptions options)
	{
		int[] array = new int[pres.Slides.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = i + 1;
		}
		smethod_4(pres, stream, array, options);
	}

	internal static void smethod_4(Presentation pres, Stream stream, int[] slides, XpsOptions options)
	{
		SizeF sizeF = new SizeF((float)Class5955.smethod_10(pres.SlideSize.Size.Width, 72.0), (float)Class5955.smethod_10(pres.SlideSize.Size.Height, 72.0));
		Class5956 info = new Class5956();
		Class6596 options2 = new Class6596();
		Class6202 @class = new Class6202(info, options2);
		Dictionary<string, Class64> dictionary = new Dictionary<string, Class64>();
		Class170 class2 = new Class170();
		class2.bool_0 = true;
		class2.iwarningCallback_0 = options.WarningCallback;
		try
		{
			foreach (int num in slides)
			{
				if (num >= 1 && num <= pres.Slides.Count)
				{
					Slide slide = (Slide)pres.Slides[num - 1];
					if (slide != null)
					{
						Class6216 class3 = new Class6216(sizeF.Width, sizeF.Height);
						Class6213 node = slide.method_16(options.SaveMetafilesAsPng, options, dictionary, class2);
						class3.Add(node);
						@class.method_0(class3);
					}
				}
			}
			@class.method_1();
			@class.Package.Save(stream);
			stream.Flush();
		}
		finally
		{
			foreach (Class64 value in dictionary.Values)
			{
				((IDisposable)value).Dispose();
			}
		}
	}

	internal static void smethod_5(Presentation pres, Stream stream, TiffOptions options, bool withNotes)
	{
		int[] array = new int[pres.Slides.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = i + 1;
		}
		smethod_6(pres, stream, array, options, withNotes);
	}

	internal static void smethod_6(Presentation pres, Stream stream, int[] slides, TiffOptions options, bool withNotes)
	{
		ImageCodecInfo imageCodecInfo = null;
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		foreach (ImageCodecInfo imageCodecInfo2 in imageEncoders)
		{
			if (imageCodecInfo2.MimeType.ToLower().Equals("image/tiff"))
			{
				imageCodecInfo = imageCodecInfo2;
			}
		}
		System.Drawing.Imaging.Encoder saveFlag = System.Drawing.Imaging.Encoder.SaveFlag;
		if (imageCodecInfo == null)
		{
			throw new PptException("Multi-page TIFF encoder not found.");
		}
		EncoderParameters encoderParameters;
		if (options.CompressionType != 0)
		{
			encoderParameters = new EncoderParameters(2);
			encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, smethod_12(options.CompressionType));
		}
		else
		{
			encoderParameters = new EncoderParameters(1);
		}
		Bitmap bitmap = null;
		for (int j = 0; j < slides.Length; j++)
		{
			int num = slides[j] - 1;
			if (num < 0 || num > pres.Slides.Count - 1)
			{
				continue;
			}
			Slide slide = (Slide)pres.Slides[num];
			if (slide == null)
			{
				continue;
			}
			Bitmap thumbnail;
			if (withNotes && slide.NotesSlide != null)
			{
				SizeF sizeF = new SizeF(pres.NotesSize.Width, pres.NotesSize.Height);
				thumbnail = ((NotesSlide)slide.NotesSlide).GetThumbnail((float)options.ImageSize.Width / sizeF.Width, (float)options.ImageSize.Height / sizeF.Height);
			}
			else
			{
				SizeF sizeF2 = new SizeF(pres.SlideSize.Size.Width, pres.SlideSize.Size.Height);
				thumbnail = slide.GetThumbnail((float)options.ImageSize.Width / sizeF2.Width, (float)options.ImageSize.Height / sizeF2.Height);
			}
			thumbnail.SetResolution(options.DpiX, options.DpiY);
			if (j == 0)
			{
				bitmap = thumbnail;
			}
			if (bitmap != null && thumbnail != null)
			{
				if (j == 0)
				{
					encoderParameters.Param[0] = new EncoderParameter(saveFlag, 18L);
					bitmap.Save(stream, imageCodecInfo, encoderParameters);
				}
				else
				{
					encoderParameters.Param[0] = new EncoderParameter(saveFlag, 23L);
					bitmap.SaveAdd(thumbnail, encoderParameters);
				}
			}
		}
		encoderParameters.Param[0] = new EncoderParameter(saveFlag, 20L);
		bitmap?.SaveAdd(encoderParameters);
	}

	internal static void smethod_7(Slide slide, Stream stream, TiffOptions options, bool withNotes)
	{
		ImageCodecInfo imageCodecInfo = null;
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		foreach (ImageCodecInfo imageCodecInfo2 in imageEncoders)
		{
			if (imageCodecInfo2.MimeType.ToLower().Equals("image/tiff"))
			{
				imageCodecInfo = imageCodecInfo2;
			}
		}
		if (imageCodecInfo == null)
		{
			throw new PptException("TIFF encoder not found.");
		}
		EncoderParameters encoderParameters;
		if (options.CompressionType != 0)
		{
			encoderParameters = new EncoderParameters(2);
			encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, smethod_12(options.CompressionType));
		}
		else
		{
			encoderParameters = new EncoderParameters(1);
		}
		Bitmap thumbnail;
		if (withNotes && slide.NotesSlide != null)
		{
			SizeF sizeF = new SizeF(slide.PresentationInternal.NotesSize.Width, slide.PresentationInternal.NotesSize.Height);
			thumbnail = ((NotesSlide)slide.NotesSlide).GetThumbnail((float)options.ImageSize.Width / sizeF.Width, (float)options.ImageSize.Height / sizeF.Height);
		}
		else
		{
			SizeF sizeF2 = new SizeF(slide.PresentationInternal.SlideSize.Size.Width, slide.PresentationInternal.SlideSize.Size.Height);
			thumbnail = slide.GetThumbnail((float)options.ImageSize.Width / sizeF2.Width, (float)options.ImageSize.Height / sizeF2.Height);
		}
		thumbnail.SetResolution(options.DpiX, options.DpiY);
		encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, 18L);
		thumbnail.Save(stream, imageCodecInfo, encoderParameters);
		encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, 20L);
		thumbnail.SaveAdd(encoderParameters);
	}

	internal static void smethod_8(Presentation pres, Stream stream, TiffOptions options)
	{
		smethod_5(pres, stream, options, withNotes: false);
	}

	internal static void smethod_9(Presentation pres, Stream stream, int[] slides, TiffOptions options)
	{
		smethod_6(pres, stream, slides, options, withNotes: false);
	}

	internal static void smethod_10(Presentation pres, Stream stream, HtmlOptions options)
	{
		int[] array = new int[pres.Slides.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = i + 1;
		}
		smethod_11(pres, stream, array, options);
	}

	internal static void smethod_11(Presentation pres, Stream stream, int[] slides, HtmlOptions options)
	{
		if (options == null)
		{
			options = new HtmlOptions();
		}
		ILinkEmbedController linkEmbedController = options.LinkEmbedController;
		Class170 @class = new Class170();
		@class.float_1 = 96f;
		Class195 class2 = new Class195();
		Class175 class3 = null;
		SVGOptions sVGOptions = null;
		Class163[] array = null;
		string[] array2 = new string[pres.Slides.Count];
		string[] array3 = new string[pres.Slides.Count];
		int[] array4 = null;
		Dictionary<string, Class64> dictionary = new Dictionary<string, Class64>();
		StreamWriter streamWriter = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
		new XmlTextWriter(streamWriter);
		ArrayList arrayList = new ArrayList();
		SlideImageFormat slideImageFormat = options.method_1();
		Enum16 slideImageType = slideImageFormat.SlideImageType;
		string text = "image/svg+xml";
		string extension = "svg";
		ImageCodecInfo encoder = null;
		EncoderParameters encoderParameters = null;
		HtmlGenerator htmlGenerator;
		if (slideImageType == Enum16.const_1)
		{
			htmlGenerator = new HtmlGenerator(streamWriter, pres.SlideSize.Size, SvgCoordinateUnit.Point);
			array4 = new int[slides.Length];
			if (slideImageFormat.ImageFormat.Guid == ImageFormat.Jpeg.Guid)
			{
				text = "image/jpeg";
				extension = "jpg";
				encoderParameters = new EncoderParameters(1);
				encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)options.JpegQuality);
			}
			else if (slideImageFormat.ImageFormat.Guid == ImageFormat.Png.Guid)
			{
				text = "image/png";
				extension = "png";
			}
			else
			{
				if (!(slideImageFormat.ImageFormat.Guid == ImageFormat.Tiff.Guid))
				{
					throw new ArgumentException("Unsupported image format");
				}
				text = "image/tiff";
				extension = "tif";
			}
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			foreach (ImageCodecInfo imageCodecInfo in imageEncoders)
			{
				if (imageCodecInfo.MimeType == text)
				{
					encoder = imageCodecInfo;
					break;
				}
			}
		}
		else
		{
			SizeF slideSize = new SizeF(pres.SlideSize.Size.Width / 72f, pres.SlideSize.Size.Height / 72f);
			htmlGenerator = new HtmlGenerator(streamWriter, slideSize, SvgCoordinateUnit.Inch);
			@class.bool_2 = true;
			array = new Class163[pres.Slides.Count];
			sVGOptions = (SVGOptions)((options.SlideImageFormat == null || ((SlideImageFormat)options.SlideImageFormat).SvgOptions == null) ? null : ((SlideImageFormat)options.SlideImageFormat).SvgOptions.Clone());
			if (sVGOptions == null)
			{
				sVGOptions = new SVGOptions();
			}
			sVGOptions.LinkEmbedController = linkEmbedController;
			class3 = new Class175(class2);
		}
		HtmlFormatter htmlFormatter = options.method_0();
		try
		{
			for (int j = 0; j < slides.Length; j++)
			{
				if (slides[j] < 1 || slides[j] > pres.Slides.Count)
				{
					continue;
				}
				Slide slide = (Slide)pres.Slides[slides[j] - 1];
				foreach (Shape shape in slide.Shapes)
				{
					if (shape is AutoShape && shape.Placeholder != null && (shape.Placeholder.Type == PlaceholderType.Title || shape.Placeholder.Type == PlaceholderType.CenteredTitle))
					{
						array2[slides[j] - 1] = ((TextFrame)((AutoShape)shape).TextFrame).TextInternal;
						break;
					}
				}
				LinkEmbedDecision decision;
				int num = class2.method_0(linkEmbedController, slide, null, "slide", text, extension, out decision);
				bool flag;
				if (flag = decision == LinkEmbedDecision.Link)
				{
					array3[slides[j] - 1] = linkEmbedController.GetUrl(num, 0);
					if (array3[slides[j] - 1] == null)
					{
						decision = LinkEmbedDecision.Ignore;
					}
				}
				if (decision != LinkEmbedDecision.Ignore)
				{
					arrayList.Add(slides[j] - 1);
					if (slideImageType == Enum16.const_0)
					{
						Class175 resources = (flag ? new Class175(class2) : class3);
						array[slides[j] - 1] = new Class163((int)pres.SlideSize.Size.Width, (int)pres.SlideSize.Size.Height, 72f, 72f, 72f, sVGOptions, resources);
						array[slides[j] - 1].int_8 = (flag ? num : 0);
						array[slides[j] - 1].bool_8 = true;
					}
					else
					{
						array4[j] = num;
					}
				}
			}
			htmlFormatter.method_0(htmlGenerator, pres);
			for (int k = 0; k < arrayList.Count; k++)
			{
				int num2 = (int)arrayList[k];
				int prevSlideIndex = ((k > 0) ? ((int)arrayList[k]) : (-1));
				int nextSlideIndex = ((k + 1 < arrayList.Count) ? ((int)arrayList[k + 1]) : (-1));
				htmlGenerator.method_4(prevSlideIndex, num2, nextSlideIndex);
				htmlFormatter.method_1(htmlGenerator, pres.Slides[num2]);
				htmlGenerator.Flush();
				if (array3[num2] == null)
				{
					if (slideImageType == Enum16.const_0)
					{
						array[num2].bool_7 = true;
						@class.interface3_0 = new Class182(array[num2], htmlGenerator, htmlFormatter.HtmlFormattingController, sVGOptions.ShapeFormattingController);
						((Slide)pres.Slides[num2]).method_14(array[num2], options, dictionary, @class);
						if (array[num2].HasSomethingRendered)
						{
							array[num2].method_10(htmlGenerator.TextWriter, writingXml: false);
						}
					}
					else
					{
						MemoryStream memoryStream = new MemoryStream();
						Image thumbnail = pres.Slides[num2].GetThumbnail(slideImageFormat.BitmapScale, slideImageFormat.BitmapScale);
						thumbnail.Save(memoryStream, encoder, encoderParameters);
						streamWriter.WriteLine("<img src=\"data:;base64,{0}\" class=\"slideImage\">", Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length));
					}
				}
				else
				{
					MemoryStream memoryStream2 = new MemoryStream();
					if (slideImageType == Enum16.const_0)
					{
						Slide slide2 = (Slide)pres.Slides[num2];
						slide2.method_14(array[num2], options, dictionary, @class);
						array[num2].method_9(memoryStream2, writingXml: true);
						linkEmbedController.SaveExternal(array[num2].int_8, memoryStream2.ToArray());
						streamWriter.WriteLine("<object data=\"{0}\" type=\"image/svg+xml\" class=\"slideImage\"></object>", array3[num2]);
					}
					else
					{
						Image thumbnail2 = pres.Slides[num2].GetThumbnail(slideImageFormat.BitmapScale, slideImageFormat.BitmapScale);
						thumbnail2.Save(memoryStream2, encoder, encoderParameters);
						linkEmbedController.SaveExternal(array4[num2], memoryStream2.ToArray());
						streamWriter.WriteLine("<img src=\"{0}\" class=\"slideImage\">", array3[num2]);
					}
				}
				htmlFormatter.method_2(htmlGenerator, pres.Slides[num2]);
				htmlGenerator.Flush();
			}
			htmlFormatter.method_3(htmlGenerator, pres);
			htmlGenerator.Flush();
			streamWriter.Flush();
		}
		finally
		{
			foreach (Class64 value in dictionary.Values)
			{
				((IDisposable)value).Dispose();
			}
		}
	}

	private static long smethod_12(TiffCompressionTypes type)
	{
		return type switch
		{
			TiffCompressionTypes.None => 6L, 
			TiffCompressionTypes.CCITT3 => 3L, 
			TiffCompressionTypes.CCITT4 => 4L, 
			TiffCompressionTypes.RLE => 5L, 
			_ => 2L, 
		};
	}
}
