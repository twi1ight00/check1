using System.IO;
using Aspose.Slides.Animation;
using ns24;

namespace Aspose.Slides;

public class AudioFrame : PictureFrame, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape, IPictureFrame, IAudioFrame
{
	internal string string_4 = "";

	internal string string_5 = "";

	private Audio audio_0;

	internal AudioPlayModePreset audioPlayModePreset_0;

	internal bool bool_1;

	private bool bool_2;

	private AudioVolumeMode audioVolumeMode_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	internal new Class283 PPTXUnsupportedProps => (Class283)base.PPTXUnsupportedProps;

	public int AudioCdStartTrack
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int AudioCdStartTrackTime
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public int AudioCdEndTrack
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	public int AudioCdEndTrackTime
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
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

	public AudioPlayModePreset PlayMode
	{
		get
		{
			return audioPlayModePreset_0;
		}
		set
		{
			audioPlayModePreset_0 = value;
			switch (audioPlayModePreset_0)
			{
			case AudioPlayModePreset.Auto:
				foreach (Sequence interactiveSequence in base.Slide.Timeline.InteractiveSequences)
				{
					interactiveSequence.RemoveByShape(this);
				}
				base.Slide.Timeline.MainSequence.RemoveByShape(this);
				base.Slide.Timeline.MainSequence.AddEffect(this, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.AfterPrevious);
				break;
			case AudioPlayModePreset.OnClick:
			{
				foreach (Sequence interactiveSequence2 in base.Slide.Timeline.InteractiveSequences)
				{
					interactiveSequence2.RemoveByShape(this);
				}
				base.Slide.Timeline.MainSequence.RemoveByShape(this);
				ISequence sequence4 = base.Slide.Timeline.InteractiveSequences.Add(this);
				sequence4.AddEffect(this, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
				break;
			}
			case AudioPlayModePreset.AllSlides:
				foreach (Sequence interactiveSequence3 in base.Slide.Timeline.InteractiveSequences)
				{
					interactiveSequence3.RemoveByShape(this);
				}
				base.Slide.Timeline.MainSequence.RemoveByShape(this);
				base.Slide.Timeline.MainSequence.AddEffect(this, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.AfterPrevious);
				break;
			case AudioPlayModePreset.Mixed:
				break;
			}
		}
	}

	public bool HideAtShowing
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

	public bool PlayLoopMode
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

	public bool Embedded => audio_0 != null;

	public string LinkPathLong
	{
		get
		{
			if (!Embedded && PPTXUnsupportedProps.AudioFrameType != Enum112.const_3)
			{
				return string_4;
			}
			return "";
		}
		set
		{
			if (!Embedded && PPTXUnsupportedProps.AudioFrameType != Enum112.const_3)
			{
				string_4 = value;
				string_5 = Path.GetFileName(string_4);
			}
		}
	}

	public IAudio EmbeddedAudio
	{
		get
		{
			return audio_0;
		}
		set
		{
			if (value != null && base.Presentation != ((Audio)value).Presentation)
			{
				throw new PptxEditException("Can't assign Audio object from the another presentation.");
			}
			audio_0 = (Audio)value;
		}
	}

	IPictureFrame IAudioFrame.AsIPictureFrame => this;

	internal AudioFrame(IBaseSlide parent)
		: base(parent, new Class283())
	{
	}

	internal void method_26()
	{
		base.PictureFormat.Picture.Image = ((ImageCollection)base.Presentation.Images).AudioImage;
	}

	internal bool method_27(Stream stream)
	{
		audio_0 = (Audio)base.Presentation.Audios.AddAudio(stream);
		return true;
	}
}
