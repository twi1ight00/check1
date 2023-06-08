using System;
using Aspose.Slides;
using ns24;
using ns33;
using ns62;
using ns63;

namespace ns15;

internal class Class1039 : Class1038
{
	private static void smethod_17(AudioFrame targetShape, Class2670 frame, Class854 slideDeserializationContext)
	{
		Class1038.smethod_15(targetShape, frame, slideDeserializationContext);
		Class2838 @class = null;
		if (frame.ClientData.AnimationInfo != null)
		{
			@class = frame.ClientData.AnimationInfo.AnimationAtom;
		}
		if (@class != null)
		{
			targetShape.audioPlayModePreset_0 = (((@class.Flags & 4) == 0) ? AudioPlayModePreset.OnClick : AudioPlayModePreset.Auto);
		}
		else
		{
			targetShape.audioPlayModePreset_0 = AudioPlayModePreset.OnClick;
		}
		targetShape.HyperlinkClick = Hyperlink.Media;
		targetShape.Volume = AudioVolumeMode.Medium;
	}

	internal static void smethod_18(AudioFrame targetShape, Class2670 frame, Class2704 wavAudioEmbedded, Class854 slideDeserializationContext)
	{
		if (frame != null && frame.ClientData != null && frame.ClientData.ExObjRefAtom != null)
		{
			smethod_17(targetShape, frame, slideDeserializationContext);
			Class857 deserializationContext = slideDeserializationContext.DeserializationContext;
			Class2872 exMedia = wavAudioEmbedded.ExMedia;
			targetShape.string_5 = "";
			targetShape.string_4 = "";
			try
			{
				Class2734 soundCollection = deserializationContext.DocumentContainer.SoundCollection;
				Class2733 soundContainer = soundCollection.method_5((int)wavAudioEmbedded.ExWavAudioEmbedded.SoundIdRef);
				targetShape.EmbeddedAudio = deserializationContext.method_0(soundContainer);
				targetShape.PPTXUnsupportedProps.AudioFrameType = Enum112.const_2;
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
			}
			targetShape.PlayLoopMode = exMedia.FLoop;
			return;
		}
		throw new PptException("Frame is not an AudioFrame.");
	}

	internal static void smethod_19(AudioFrame targetShape, Class2670 frame, Class2705 wavAudioLink, Class854 slideDeserializationContext)
	{
		if (frame != null && frame.ClientData != null && frame.ClientData.ExObjRefAtom != null)
		{
			smethod_17(targetShape, frame, slideDeserializationContext);
			Class2872 exMedia = wavAudioLink.ExMedia;
			targetShape.LinkPathLong = ((wavAudioLink.AudioFilePath == null) ? "" : wavAudioLink.AudioFilePath.String);
			targetShape.PPTXUnsupportedProps.AudioFrameType = Enum112.const_1;
			targetShape.PlayLoopMode = exMedia.FLoop;
			return;
		}
		throw new PptException("Frame is not an AudioFrame.");
	}

	internal static void smethod_20(AudioFrame targetShape, Class2670 frame, Class2698 midiAudio, Class854 slideDeserializationContext)
	{
		if (frame != null && frame.ClientData != null && frame.ClientData.ExObjRefAtom != null)
		{
			smethod_17(targetShape, frame, slideDeserializationContext);
			Class2872 exMediaAtom = midiAudio.ExMediaAtom;
			targetShape.LinkPathLong = ((midiAudio.AudioFilePath == null) ? "" : midiAudio.AudioFilePath.String);
			targetShape.PPTXUnsupportedProps.AudioFrameType = Enum112.const_1;
			targetShape.PlayLoopMode = exMediaAtom.FLoop;
			return;
		}
		throw new PptException("Frame is not an AudioFrame.");
	}

	internal static void smethod_21(AudioFrame targetShape, Class2670 frame, Class2691 cdAudio, Class854 slideDeserializationContext)
	{
		if (frame == null || frame.ClientData == null || frame.ClientData.ExObjRefAtom == null)
		{
			throw new PptException("Frame is not an AudioFrame.");
		}
		smethod_17(targetShape, frame, slideDeserializationContext);
		Class2872 exMediaAtom = cdAudio.ExMediaAtom;
		Class2866 exCDAudioAtom = cdAudio.ExCDAudioAtom;
		targetShape.AudioCdStartTrack = exCDAudioAtom.StartTrack;
		targetShape.AudioCdStartTrackTime = exCDAudioAtom.StartTime;
		targetShape.AudioCdEndTrack = exCDAudioAtom.EndTrack;
		targetShape.AudioCdEndTrackTime = exCDAudioAtom.EndTime;
		targetShape.PPTXUnsupportedProps.AudioFrameType = Enum112.const_3;
		targetShape.PlayLoopMode = exMediaAtom.FLoop;
	}

	internal static void smethod_22(AudioFrame audioFrame)
	{
		AudioPlayModePreset audioPlayModePreset_ = audioFrame.audioPlayModePreset_0;
		audioFrame.audioPlayModePreset_0 = AudioPlayModePreset.Mixed;
		audioFrame.PlayMode = audioPlayModePreset_;
	}
}
