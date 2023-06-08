using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns4;
using ns49;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal sealed class Class857
{
	private Class2985 class2985_0;

	private Presentation presentation_0;

	private Guid[] guid_0;

	private Dictionary<int, PPImage> dictionary_0 = new Dictionary<int, PPImage>();

	private Dictionary<int, PPImage> dictionary_1 = new Dictionary<int, PPImage>();

	private Encoding encoding_0 = Encoding.Default;

	private List<Hyperlink> list_0 = new List<Hyperlink>();

	private Dictionary<uint, Class2669> dictionary_2 = new Dictionary<uint, Class2669>();

	private Dictionary<uint, Class854> dictionary_3 = new Dictionary<uint, Class854>();

	private readonly Dictionary<Class2733, Audio> dictionary_4 = new Dictionary<Class2733, Audio>();

	private Class60 class60_0;

	private Class854 class854_0;

	private Dictionary<uint, BaseSlide> dictionary_5 = new Dictionary<uint, BaseSlide>();

	private Dictionary<ISlide, Class2719> dictionary_6 = new Dictionary<ISlide, Class2719>();

	private Class2894[] class2894_0;

	private List<uint> list_1 = new List<uint>();

	public Presentation DomPresentation => presentation_0;

	public Class2721 PowerPointDocumentStream => class2985_0.PowerPointDocumentStream;

	public byte[] SummaryInformationStream => class2985_0.SummaryInformationStream;

	public byte[] DocumentSummaryInformationStream => class2985_0.DocumentSummaryInformationStream;

	public Class60 DocumentProperties
	{
		get
		{
			return class60_0;
		}
		set
		{
			class60_0 = value;
		}
	}

	public Class2737 PicturesStream => class2985_0.PicturesStream;

	public Class2688 DocumentContainer => class2985_0.PowerPointDocumentStream.DocumentContainer;

	public Guid[] ImagesGuids
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public Dictionary<int, PPImage> PictureIdToPPImage => dictionary_0;

	public Dictionary<int, PPImage> PictureBulletIdToPPImage => dictionary_1;

	public Encoding AnsiEncoding => encoding_0;

	public List<Hyperlink> InternalHyperlinks => list_0;

	public List<uint> MasterRefsList => list_1;

	public Dictionary<uint, Class2669> ShapeIdToFrame => dictionary_2;

	public Class854 LastAddedSlideContext => class854_0;

	public Dictionary<uint, BaseSlide> SlideIdToMasterOrLayoutSlide => dictionary_5;

	public Dictionary<ISlide, Class2719> DomSlideToSlideContainer => dictionary_6;

	public Class2894[] PptDefaultTextMasterStyleList
	{
		get
		{
			return class2894_0;
		}
		set
		{
			class2894_0 = value;
		}
	}

	internal IAudio method_0(Class2733 soundContainer)
	{
		if (!dictionary_4.ContainsKey(soundContainer))
		{
			Audio audio = (Audio)presentation_0.Audios.AddAudio(soundContainer.SoundDataBlob.Data);
			audio.PPTUnsupportedProps.SoundName = soundContainer.SoundName.String;
			dictionary_4.Add(soundContainer, audio);
			return audio;
		}
		return dictionary_4[soundContainer];
	}

	public Class857(Class2985 pptBinaryFile, Presentation presentation)
	{
		class2985_0 = pptBinaryFile;
		presentation_0 = presentation;
	}

	public void method_1(uint slideId, Class854 slideDeserializationContext)
	{
		class854_0 = slideDeserializationContext;
		dictionary_3.Add(slideId, slideDeserializationContext);
	}

	public Class854 method_2(uint slideId)
	{
		return dictionary_3[slideId];
	}

	public IBaseSlide method_3(uint slideId)
	{
		dictionary_3.TryGetValue(slideId, out var value);
		return value?.DomSlide;
	}

	internal void method_4(string description, WarningType warningType)
	{
		if (presentation_0.LoadOptions != null && presentation_0.LoadOptions.WarningCallback != null)
		{
			Class1176 @class = new Class1176(description, warningType);
			@class.SendWarning(presentation_0.LoadOptions.WarningCallback);
		}
	}
}
