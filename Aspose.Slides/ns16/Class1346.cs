using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;
using Aspose.Slides.Warnings;
using ns24;
using ns49;
using ns53;
using ns54;
using ns55;

namespace ns16;

internal class Class1346 : Class1344
{
	private readonly IPresentation ipresentation_0;

	private IPptxOptions ipptxOptions_0;

	private Enum167 enum167_0;

	private readonly Dictionary<IBaseSlide, string> dictionary_0;

	private readonly Dictionary<IBaseSlide, Class1342> dictionary_1;

	private readonly Dictionary<ITheme, Class1342> dictionary_2;

	private readonly Dictionary<IPPImage, Class1342> dictionary_3;

	private readonly Dictionary<IAudio, Class1342> dictionary_4;

	private readonly Dictionary<IVideo, Class1342> dictionary_5;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9 = 1037;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private Dictionary<Guid, Guid> dictionary_6;

	public Dictionary<IBaseSlide, string> SlideToSlidePartPath => dictionary_0;

	public Dictionary<IBaseSlide, Class1342> SlideToSlidePart => dictionary_1;

	public Dictionary<ITheme, Class1342> ThemeToThemePart => dictionary_2;

	public new Class1184 Package => (Class1184)base.Package;

	internal Enum167 Mode
	{
		get
		{
			return enum167_0;
		}
		set
		{
			enum167_0 = value;
		}
	}

	internal Dictionary<Guid, Guid> UsedTableStyles => dictionary_6;

	public IPresentation Presentation => ipresentation_0;

	public Class1346(Class1184 package, IPresentation presentation, IPptxOptions options)
		: base(package)
	{
		ipresentation_0 = presentation;
		ipptxOptions_0 = options;
		dictionary_0 = new Dictionary<IBaseSlide, string>();
		dictionary_1 = new Dictionary<IBaseSlide, Class1342>();
		dictionary_3 = new Dictionary<IPPImage, Class1342>();
		dictionary_4 = new Dictionary<IAudio, Class1342>();
		dictionary_5 = new Dictionary<IVideo, Class1342>();
		dictionary_2 = new Dictionary<ITheme, Class1342>();
		dictionary_6 = new Dictionary<Guid, Guid>();
	}

	internal void method_0(Class1341 deserializationContext)
	{
		switch (Mode)
		{
		default:
			throw new Exception();
		case Enum167.const_1:
			foreach (KeyValuePair<IPPImage, Class1342> item in dictionary_3)
			{
				deserializationContext.ImagePartToImage.Add(item.Value, item.Key);
			}
			foreach (KeyValuePair<IAudio, Class1342> item2 in dictionary_4)
			{
				deserializationContext.AudioPartToAudio.Add(item2.Value, item2.Key);
			}
			foreach (KeyValuePair<IVideo, Class1342> item3 in dictionary_5)
			{
				deserializationContext.VideoPartToVideo.Add(item3.Value, item3.Key);
			}
			switch (Mode)
			{
			default:
				throw new Exception();
			case Enum167.const_1:
				deserializationContext.method_0();
				break;
			case Enum167.const_0:
			case Enum167.const_2:
				break;
			}
			break;
		case Enum167.const_0:
		case Enum167.const_2:
			break;
		}
	}

	internal Class1342 method_1(IPPImage image)
	{
		if (!dictionary_3.ContainsKey(image))
		{
			return method_3(image);
		}
		return dictionary_3[image];
	}

	internal Class1342 method_2(IPPImage image)
	{
		if (!dictionary_3.ContainsKey(image))
		{
			switch (Mode)
			{
			default:
				throw new Exception();
			case Enum167.const_0:
			case Enum167.const_1:
			case Enum167.const_2:
				return method_3(image);
			}
		}
		return dictionary_3[image];
	}

	internal Class1342 method_3(IPPImage image)
	{
		Class344 pPTXUnsupportedProps = ((PPImage)image).PPTXUnsupportedProps;
		Class1305 partType = pPTXUnsupportedProps.PartType;
		Class1342 @class = Package.method_4("/ppt/media/image{0}." + partType.Extension, method_16, partType);
		switch (Mode)
		{
		default:
			throw new Exception();
		case Enum167.const_1:
			@class.Processed = true;
			break;
		case Enum167.const_0:
		case Enum167.const_2:
			@class.Data = pPTXUnsupportedProps.data;
			break;
		}
		dictionary_3.Add(image, @class);
		return @class;
	}

	internal Class1342 method_4(Bitmap image)
	{
		Class1305 @class = (image.RawFormat.Equals(ImageFormat.Bmp) ? new Class1306() : (image.RawFormat.Equals(ImageFormat.Emf) ? new Class1307() : (image.RawFormat.Equals(ImageFormat.Gif) ? new Class1308() : (image.RawFormat.Equals(ImageFormat.Jpeg) ? new Class1309() : (image.RawFormat.Equals(ImageFormat.Png) ? new Class1311() : (image.RawFormat.Equals(ImageFormat.Tiff) ? new Class1312() : ((!image.RawFormat.Equals(ImageFormat.Wmf)) ? ((Class1305)new Class1313()) : ((Class1305)new Class1314()))))))));
		Class1342 class2 = Package.method_4("/ppt/media/image{0}." + @class.Extension, method_16, @class);
		using MemoryStream memoryStream = new MemoryStream();
		image.Save(memoryStream, image.RawFormat);
		class2.Data = memoryStream.ToArray();
		return class2;
	}

	internal Class1342 method_5(IAudio audio)
	{
		if (!dictionary_4.ContainsKey(audio))
		{
			return method_7(audio);
		}
		return dictionary_4[audio];
	}

	internal Class1342 method_6(IAudio audio)
	{
		if (!dictionary_4.ContainsKey(audio))
		{
			switch (Mode)
			{
			default:
				throw new Exception();
			case Enum167.const_0:
				throw new Exception();
			case Enum167.const_1:
			case Enum167.const_2:
				return method_7(audio);
			}
		}
		return dictionary_4[audio];
	}

	internal Class1342 method_7(IAudio audio)
	{
		Class293 pPTXUnsupportedProps = ((Audio)audio).PPTXUnsupportedProps;
		Class1342 @class = Package.method_4("/ppt/media/media{0}." + pPTXUnsupportedProps.Extension, method_17, Class1223.smethod_0(pPTXUnsupportedProps.ContentType));
		switch (Mode)
		{
		default:
			throw new Exception();
		case Enum167.const_1:
			@class.Processed = true;
			break;
		case Enum167.const_0:
		case Enum167.const_2:
			@class.Data = audio.BinaryData;
			break;
		}
		dictionary_4.Add(audio, @class);
		return @class;
	}

	internal Class1342 method_8(IVideo video)
	{
		if (!dictionary_5.ContainsKey(video))
		{
			return method_10(video);
		}
		return dictionary_5[video];
	}

	internal Class1342 method_9(IVideo video)
	{
		if (!dictionary_5.ContainsKey(video))
		{
			switch (Mode)
			{
			default:
				throw new Exception();
			case Enum167.const_0:
				throw new Exception();
			case Enum167.const_1:
			case Enum167.const_2:
				return method_10(video);
			}
		}
		return dictionary_5[video];
	}

	internal Class1342 method_10(IVideo video)
	{
		Class366 pPTXUnsupportedProps = ((Video)video).PPTXUnsupportedProps;
		Class1342 @class = Package.method_4("/ppt/media/media{0}." + pPTXUnsupportedProps.Extension, method_17, Class1223.smethod_0(pPTXUnsupportedProps.ContentType));
		switch (Mode)
		{
		default:
			throw new Exception();
		case Enum167.const_1:
			@class.Processed = true;
			break;
		case Enum167.const_0:
		case Enum167.const_2:
			@class.Data = video.BinaryData;
			break;
		}
		dictionary_5.Add(video, @class);
		return @class;
	}

	public int method_11()
	{
		return ++int_7;
	}

	public int method_12()
	{
		return int_7;
	}

	public int method_13()
	{
		return ++int_8;
	}

	public int method_14()
	{
		return ++int_9;
	}

	public int method_15()
	{
		return ++int_10;
	}

	public int method_16()
	{
		return ++int_11;
	}

	public int method_17()
	{
		return ++int_12;
	}

	public int method_18()
	{
		return ++int_13;
	}

	public int method_19()
	{
		return ++int_16;
	}

	public int method_20()
	{
		return int_13;
	}

	public int method_21()
	{
		return ++int_14;
	}

	public int method_22()
	{
		return ++int_15;
	}

	public int method_23()
	{
		return ++int_0;
	}

	public int method_24()
	{
		return ++int_1;
	}

	public int method_25()
	{
		return ++int_2;
	}

	public int method_26()
	{
		return ++int_3;
	}

	public int method_27()
	{
		return ++int_4;
	}

	public int method_28()
	{
		return ++int_5;
	}

	public int method_29()
	{
		return ++int_6;
	}

	internal void method_30(string description, WarningType warningType)
	{
		if (ipptxOptions_0 != null && ipptxOptions_0.WarningCallback != null)
		{
			Class1176 @class = new Class1176(description, warningType);
			@class.SendWarning(ipptxOptions_0.WarningCallback);
		}
	}
}
