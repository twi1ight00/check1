using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Theme;
using Aspose.Slides.Warnings;
using ns49;
using ns53;
using ns54;

namespace ns16;

internal class Class1341 : Class1339
{
	private Presentation presentation_0;

	private Enum168 enum168_0;

	private readonly Dictionary<Class1342, IPPImage> dictionary_0;

	private readonly Dictionary<Class1342, IAudio> dictionary_1;

	private readonly Dictionary<Class1342, IVideo> dictionary_2;

	private readonly Dictionary<Class1342, ITheme> dictionary_3;

	private readonly Dictionary<string, List<IHyperlink>> dictionary_4;

	private readonly Dictionary<uint, ICommentAuthor> dictionary_5;

	private readonly Dictionary<string, IBaseSlide> dictionary_6;

	private readonly List<IShape> list_0 = new List<IShape>();

	private readonly SortedList<string, SortedList<string, Class1342>> sortedList_0;

	internal Dictionary<Class1342, IPPImage> ImagePartToImage => dictionary_0;

	internal Dictionary<Class1342, IAudio> AudioPartToAudio => dictionary_1;

	internal Dictionary<Class1342, IVideo> VideoPartToVideo => dictionary_2;

	internal Enum168 Mode
	{
		get
		{
			return enum168_0;
		}
		set
		{
			enum168_0 = value;
		}
	}

	internal Dictionary<string, List<IHyperlink>> SlidePartPathToUnresolvedHyperinks => dictionary_4;

	internal Dictionary<uint, ICommentAuthor> CommentAuthorXmlIdToCommentAuthor => dictionary_5;

	internal Dictionary<string, IBaseSlide> SlidePartPathToSlide => dictionary_6;

	internal List<IShape> Shapes => list_0;

	internal SortedList<string, SortedList<string, Class1342>> MasterSlidePartPathToBackLinksFromLayouts => sortedList_0;

	internal Dictionary<Class1342, ITheme> ThemePartToTheme => dictionary_3;

	internal Presentation Presentation => presentation_0;

	public Class1341(IPresentation presentation)
	{
		presentation_0 = (Presentation)presentation;
		dictionary_0 = new Dictionary<Class1342, IPPImage>();
		dictionary_1 = new Dictionary<Class1342, IAudio>();
		dictionary_2 = new Dictionary<Class1342, IVideo>();
		dictionary_3 = new Dictionary<Class1342, ITheme>();
		dictionary_4 = new Dictionary<string, List<IHyperlink>>();
		dictionary_5 = new Dictionary<uint, ICommentAuthor>();
		dictionary_6 = new Dictionary<string, IBaseSlide>();
		sortedList_0 = new SortedList<string, SortedList<string, Class1342>>();
	}

	internal void method_0()
	{
		foreach (ICommentAuthor commentAuthor in Presentation.CommentAuthors)
		{
			CommentAuthorXmlIdToCommentAuthor.Add(((CommentAuthor)commentAuthor).PPTXUnsupportedProps.Id, commentAuthor);
		}
	}

	internal IPPImage method_1(Class1342 imagePart)
	{
		if (imagePart == null)
		{
			return null;
		}
		if (!imagePart.PartPath.ToLower().EndsWith(".pdf") && !imagePart.PartPath.ToLower().EndsWith(".pict"))
		{
			if (!dictionary_0.ContainsKey(imagePart))
			{
				IPPImage iPPImage = Presentation.Images.AddImage(imagePart.method_0());
				dictionary_0.Add(imagePart, iPPImage);
				imagePart.Processed = true;
				return iPPImage;
			}
			return dictionary_0[imagePart];
		}
		return null;
	}

	internal IAudio method_2(Class1342 audioPart)
	{
		if (!dictionary_1.ContainsKey(audioPart))
		{
			Audio audio = (Audio)Presentation.Audios.AddAudio(audioPart.Data);
			audio.PPTXUnsupportedProps.ContentType = audioPart.ContentType.ContentType;
			int num = audioPart.PartPath.LastIndexOf('.');
			audio.PPTXUnsupportedProps.Extension = ((num >= 0) ? audioPart.PartPath.Substring(num + 1) : null);
			dictionary_1.Add(audioPart, audio);
			audioPart.Processed = true;
			return audio;
		}
		return dictionary_1[audioPart];
	}

	internal IVideo method_3(Class1342 videoPart)
	{
		if (!dictionary_2.ContainsKey(videoPart))
		{
			Video video = (Video)Presentation.Videos.AddVideo(videoPart.Data);
			video.PPTXUnsupportedProps.ContentType = videoPart.ContentType.ContentType;
			int num = videoPart.PartPath.LastIndexOf('.');
			video.PPTXUnsupportedProps.Extension = ((num >= 0) ? videoPart.PartPath.Substring(num + 1) : null);
			dictionary_2.Add(videoPart, video);
			videoPart.Processed = true;
			return video;
		}
		return dictionary_2[videoPart];
	}

	internal void method_4(string description, WarningType warningType)
	{
		if (Presentation.LoadOptions != null && Presentation.LoadOptions.WarningCallback != null)
		{
			Class1176 @class = new Class1176(description, warningType);
			@class.SendWarning(Presentation.LoadOptions.WarningCallback);
		}
	}
}
