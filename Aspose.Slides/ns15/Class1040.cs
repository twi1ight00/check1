using Aspose.Slides;
using ns62;
using ns63;

namespace ns15;

internal class Class1040 : Class1038
{
	internal static void smethod_17(VideoFrame targetShape, Class2670 frame, Class2703 exVideoContainer, Class854 slideDeserializationContext)
	{
		if (frame != null && frame.ClientData != null && frame.ClientData.ExObjRefAtom != null)
		{
			if (exVideoContainer == null)
			{
				throw new PptException("Frame is not an VideoFrame.");
			}
			Class1038.smethod_15(targetShape, frame, slideDeserializationContext);
			Class2838 @class = null;
			if (frame.ClientData.AnimationInfo != null)
			{
				@class = frame.ClientData.AnimationInfo.AnimationAtom;
			}
			if (@class != null)
			{
				targetShape.PPTXUnsupportedProps.PlayModeInternal = (((@class.Flags & 4) == 0) ? VideoPlayModePreset.OnClick : VideoPlayModePreset.Auto);
			}
			else
			{
				targetShape.PPTXUnsupportedProps.PlayModeInternal = VideoPlayModePreset.OnClick;
			}
			targetShape.LinkPathLong = ((exVideoContainer.VideoFilePath == null) ? "" : exVideoContainer.VideoFilePath.String);
			targetShape.bool_3 = exVideoContainer.ExMediaAtom.FLoop;
			targetShape.HyperlinkClick = Hyperlink.Media;
			targetShape.audioVolumeMode_0 = AudioVolumeMode.Medium;
			return;
		}
		throw new PptException("Frame is not an VideoFrame.");
	}

	internal static void smethod_18(VideoFrame videoFrame)
	{
		VideoPlayModePreset playModeInternal = videoFrame.PPTXUnsupportedProps.PlayModeInternal;
		videoFrame.PPTXUnsupportedProps.PlayModeInternal = VideoPlayModePreset.Mixed;
		videoFrame.PlayMode = playModeInternal;
	}
}
