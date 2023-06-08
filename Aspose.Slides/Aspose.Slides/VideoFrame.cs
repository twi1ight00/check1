using System.Drawing;
using System.IO;
using System.Reflection;
using Aspose.Slides.Animation;
using ns24;

namespace Aspose.Slides;

public class VideoFrame : PictureFrame, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape, IPictureFrame, IVideoFrame
{
	internal string string_4 = "";

	internal string string_5 = "";

	internal Video video_0;

	internal bool bool_1;

	internal AudioVolumeMode audioVolumeMode_0;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal new Class284 PPTXUnsupportedProps => (Class284)base.PPTXUnsupportedProps;

	public bool RewindVideo
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool PlayLoopMode
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool HideAtShowing
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public AudioVolumeMode Volume
	{
		get
		{
			return audioVolumeMode_0;
		}
		set
		{
			audioVolumeMode_0 = value;
		}
	}

	public VideoPlayModePreset PlayMode
	{
		get
		{
			return PPTXUnsupportedProps.PlayModeInternal;
		}
		set
		{
			PPTXUnsupportedProps.PlayModeInternal = value;
			switch (PPTXUnsupportedProps.PlayModeInternal)
			{
			case VideoPlayModePreset.OnClick:
			{
				foreach (Sequence interactiveSequence in base.Slide.Timeline.InteractiveSequences)
				{
					interactiveSequence.RemoveByShape(this);
				}
				base.Slide.Timeline.MainSequence.RemoveByShape(this);
				ISequence sequence2 = base.Slide.Timeline.InteractiveSequences.Add(this);
				sequence2.AddEffect(this, EffectType.MediaPause, EffectSubtype.None, EffectTriggerType.OnClick);
				break;
			}
			case VideoPlayModePreset.Mixed:
				break;
			case VideoPlayModePreset.Auto:
			case VideoPlayModePreset.AllSlides:
			{
				foreach (Sequence interactiveSequence2 in base.Slide.Timeline.InteractiveSequences)
				{
					interactiveSequence2.RemoveByShape(this);
				}
				base.Slide.Timeline.MainSequence.RemoveByShape(this);
				base.Slide.Timeline.MainSequence.AddEffect(this, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.AfterPrevious);
				ISequence sequence2 = base.Slide.Timeline.InteractiveSequences.Add(this);
				sequence2.AddEffect(this, EffectType.MediaPause, EffectSubtype.None, EffectTriggerType.OnClick);
				break;
			}
			}
		}
	}

	public bool FullScreenMode
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public string LinkPathLong
	{
		get
		{
			return string_4;
		}
		set
		{
			if (value != null)
			{
				string_4 = value;
				string_5 = Path.GetFileName(string_4);
			}
			else
			{
				string_4 = (string_5 = null);
			}
		}
	}

	public IVideo EmbeddedVideo
	{
		get
		{
			return video_0;
		}
		set
		{
			if (value != null && base.Presentation != ((Video)value).Presentation)
			{
				throw new PptxEditException("Can't assign Video object from the another presentation.");
			}
			video_0 = (Video)value;
		}
	}

	IPictureFrame IVideoFrame.AsIPictureFrame => this;

	internal VideoFrame(IBaseSlide parent)
		: base(parent, new Class284())
	{
	}

	internal void method_26()
	{
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.ObjectChanged.png");
		if (manifestResourceStream == null)
		{
			throw new PptxException("Aspose.Slides.dll is broken.");
		}
		base.PictureFormat.Picture.Image = base.Presentation.Images.AddImage(Image.FromStream(manifestResourceStream));
	}
}
