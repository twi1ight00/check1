using System;
using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns33;
using ns53;
using ns55;
using ns56;
using ns57;

namespace ns18;

internal class Class893
{
	private const string string_0 = "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}";

	private const string string_1 = "http://schemas.microsoft.com/office/powerpoint/2010/main";

	private const string string_2 = "http://schemas.microsoft.com/office/2007/relationships/media";

	private const string string_3 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

	private static readonly float[] float_0 = new float[4] { 0f, 0.2f, 0.5f, 0.8f };

	internal static IAudioFrame smethod_0(IGroupShape groupShape, Class1799 audioCDElementData)
	{
		IAudioFrame audioFrame = groupShape.Shapes.AddAudioFrameCD(0f, 0f, 0f, 0f);
		Class983.smethod_3(audioFrame);
		audioFrame.AudioCdStartTrack = audioCDElementData.St.Track;
		audioFrame.AudioCdStartTrackTime = (int)audioCDElementData.St.Time;
		audioFrame.AudioCdEndTrack = audioCDElementData.End.Track;
		audioFrame.AudioCdEndTrackTime = (int)audioCDElementData.End.Time;
		return audioFrame;
	}

	internal static IAudioFrame smethod_1(IGroupShape groupShape, Class1838 embeddedWavAudioFile, Class1341 deserializationContext)
	{
		IAudioFrame audioFrame = null;
		string r_Embed = embeddedWavAudioFile.R_Embed;
		if (r_Embed != null && r_Embed.Length > 0)
		{
			Class1347 @class = deserializationContext.RelationshipsOfCurrentPartEntry[r_Embed];
			audioFrame = groupShape.Shapes.AddAudioFrameEmbedded(0f, 0f, 0f, 0f, deserializationContext.method_2(@class.TargetPart));
			Class983.smethod_3(audioFrame);
		}
		return audioFrame;
	}

	internal static IAudioFrame smethod_2(IGroupShape groupShape, Class2004 picElementData, Class1801 audioFileElementData, Class1341 deserializationContext)
	{
		IAudioFrame audioFrame = null;
		string text = audioFileElementData.R_Link;
		XmlElement xmlElement = smethod_3(picElementData.NvPicPr.NvPr.ExtLst);
		if (xmlElement != null)
		{
			if (xmlElement.HasAttribute("embed", "http://schemas.openxmlformats.org/officeDocument/2006/relationships"))
			{
				string attribute = xmlElement.GetAttribute("embed", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
				if (attribute != null && attribute.Length > 0)
				{
					Class1347 @class = deserializationContext.RelationshipsOfCurrentPartEntry[attribute];
					audioFrame = groupShape.Shapes.AddAudioFrameEmbedded(0f, 0f, 0f, 0f, deserializationContext.method_2(@class.TargetPart));
					Class983.smethod_3(audioFrame);
					((AudioFrame)audioFrame).PPTXUnsupportedProps.AudioFrameType = Enum112.const_1;
				}
			}
			if (xmlElement.HasAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships"))
			{
				text = xmlElement.GetAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			}
		}
		if (audioFrame == null && text != null && text.Length > 0)
		{
			Class1347 class2 = deserializationContext.RelationshipsOfCurrentPartEntry[text];
			if (class2.TargetMode == Enum180.const_2)
			{
				string fname;
				try
				{
					Uri uri = new Uri(class2.Target);
					fname = uri.LocalPath;
				}
				catch (Exception ex)
				{
					fname = class2.Target;
					Class1165.smethod_28(ex);
				}
				audioFrame = groupShape.Shapes.AddAudioFrameLinked(0f, 0f, 0f, 0f, fname);
				Class983.smethod_3(audioFrame);
			}
		}
		return audioFrame;
	}

	internal static XmlElement smethod_3(Class1885 extLst)
	{
		if (extLst != null && extLst.ExtList.Length != 0)
		{
			XmlElement documentElement = Class2514.smethod_0(extLst, "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}").DocumentElement;
			if (documentElement != null)
			{
				return (XmlElement)Class1029.smethod_11(documentElement, "media", "http://schemas.microsoft.com/office/powerpoint/2010/main");
			}
			return null;
		}
		return null;
	}

	internal static void smethod_4(AudioFrame audioFrame, Class2006 audioFrameElementData, Class1346 serializationContext)
	{
		Class283 pPTXUnsupportedProps = audioFrame.PPTXUnsupportedProps;
		if (pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties == null)
		{
			pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties = new Class1888();
		}
		XmlElement xmlElement = Class2514.smethod_0(pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties, "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}")?.DocumentElement;
		Class976.smethod_2(audioFrame, audioFrameElementData, serializationContext);
		if (pPTXUnsupportedProps.AudioFrameType != Enum112.const_3)
		{
			if (audioFrame.EmbeddedAudio != null && (audioFrame.EmbeddedAudio == null || (!(audioFrame.EmbeddedAudio.ContentType != "audio/wav") && xmlElement == null)))
			{
				pPTXUnsupportedProps.AudioFrameType = Enum112.const_2;
			}
			else
			{
				pPTXUnsupportedProps.AudioFrameType = Enum112.const_1;
			}
		}
		audioFrameElementData.NvPicPr.NvPr.Media = null;
		switch (pPTXUnsupportedProps.AudioFrameType)
		{
		case Enum112.const_1:
		{
			Class1801 class4 = (Class1801)audioFrameElementData.NvPicPr.NvPr.delegate2773_0("audioFile").Object;
			Class1347 class5 = ((audioFrame.EmbeddedAudio == null) ? serializationContext.RelationshipsOfCurrentPartEntry.method_6(Class1303.class1338_0.Type, Class1165.smethod_17(audioFrame.LinkPathLong), Enum180.const_2) : serializationContext.RelationshipsOfCurrentPartEntry.method_4(serializationContext.method_5(audioFrame.EmbeddedAudio)));
			class4.R_Link = class5.Id;
			if (audioFrame.EmbeddedAudio != null)
			{
				Class1454 class6 = Class2514.smethod_2(pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties, "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}");
				Class1347 class7 = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.microsoft.com/office/2007/relationships/media", serializationContext.method_5(audioFrame.EmbeddedAudio).PartPath, Enum180.const_1);
				XmlDocument xmlDocument = new XmlDocument();
				XmlDocumentFragment xmlDocumentFragment = xmlDocument.CreateDocumentFragment();
				xmlDocumentFragment.InnerXml = class6.OuterXml;
				XmlElement xmlElement2 = (XmlElement)Class1029.smethod_13(xmlDocumentFragment.ChildNodes[0], "media", "http://schemas.microsoft.com/office/powerpoint/2010/main");
				xmlElement2.SetAttribute("embed", "http://schemas.openxmlformats.org/officeDocument/2006/relationships", class7.Id);
				class6.OuterXml = xmlDocumentFragment.OuterXml;
			}
			else
			{
				Class1454 class8 = Class2514.smethod_1(pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties, "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}");
				if (class8 != null)
				{
					((XmlElement)Class1029.smethod_11(class8.XmlDocument.DocumentElement, "media", "http://schemas.microsoft.com/office/powerpoint/2010/main"))?.RemoveAttribute("embed", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
				}
			}
			Class1454 class9 = Class2514.smethod_1(pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties, "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}");
			if (class9 == null)
			{
				break;
			}
			XmlElement xmlElement3 = (XmlElement)Class1029.smethod_11(class9.XmlDocument.DocumentElement, "media", "http://schemas.microsoft.com/office/powerpoint/2010/main");
			if (xmlElement3 != null)
			{
				if (audioFrame.LinkPathLong != null && audioFrame.LinkPathLong.Length > 0)
				{
					Class1347 class10 = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.microsoft.com/office/2007/relationships/media", Class1165.smethod_17(audioFrame.LinkPathLong), Enum180.const_2);
					xmlElement3.SetAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships", class10.Id);
				}
				else
				{
					xmlElement3.RemoveAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
				}
			}
			break;
		}
		default:
		{
			Class1838 class2 = (Class1838)audioFrameElementData.NvPicPr.NvPr.delegate2773_0("wavAudioFile").Object;
			Class1347 class3 = serializationContext.RelationshipsOfCurrentPartEntry.method_4(serializationContext.method_5(audioFrame.EmbeddedAudio));
			class2.R_Embed = class3.Id;
			break;
		}
		case Enum112.const_3:
		{
			Class1799 @class = (Class1799)audioFrameElementData.NvPicPr.NvPr.delegate2773_0("audioCd").Object;
			@class.St.Track = (byte)audioFrame.AudioCdStartTrack;
			@class.St.Time = (uint)audioFrame.AudioCdStartTrackTime;
			@class.End.Track = (byte)audioFrame.AudioCdEndTrack;
			@class.End.Time = (uint)audioFrame.AudioCdEndTrackTime;
			break;
		}
		}
		if (audioFrame.Slide is ISlide)
		{
			Slide slide = (Slide)audioFrame.Slide;
			uint num = Class1008.smethod_13(slide);
			if (slide.PPTXUnsupportedProps.TimingElementData == null)
			{
				slide.PPTXUnsupportedProps.TimingElementData = new Class2259();
			}
			Class2264 class11 = slide.PPTXUnsupportedProps.TimingElementData.TnLst;
			if (class11 == null)
			{
				class11 = slide.PPTXUnsupportedProps.TimingElementData.delegate2539_0();
			}
			Class2288 class12 = (Class2288)class11.delegate2773_0("audio").Object;
			if (audioFrame.PlayMode == AudioPlayModePreset.AllSlides)
			{
				class12.CMediaNode.NumSld = 999u;
			}
			num = (uint)(class12.CMediaNode.CTn.Id = (int)(num + 1));
			class12.CMediaNode.CTn.Spd = 1f;
			class12.CMediaNode.CTn.Accel = 0f;
			class12.CMediaNode.CTn.Decel = 0f;
			class12.CMediaNode.CTn.Fill = Enum289.const_3;
			class12.CMediaNode.ShowWhenStopped = !audioFrame.HideAtShowing;
			if (audioFrame.Volume == AudioVolumeMode.Mute)
			{
				class12.CMediaNode.Mute = true;
			}
			class12.CMediaNode.Vol = float_0[(int)((audioFrame.Volume == AudioVolumeMode.Mixed) ? AudioVolumeMode.Medium : audioFrame.Volume)];
			class12.CMediaNode.CTn.RepeatCount = Class1008.smethod_6(audioFrame.PlayLoopMode ? float.PositiveInfinity : 1f);
			class12.CMediaNode.CTn.Display = NullableBool.False;
			Class2294 class13 = (Class2294)class12.CMediaNode.TgtEl.delegate2773_0("spTgt").Object;
			class13.Spid = XmlConvert.ToString(audioFrame.ShapeId);
			Class2302 class14 = class12.CMediaNode.CTn.delegate2653_0();
			Class2301 class15 = class14.delegate2650_0();
			class15.Delay = Class1008.smethod_6(float.PositiveInfinity);
			Class2302 class16 = class12.CMediaNode.CTn.delegate2653_1();
			if (pPTXUnsupportedProps.AudioFrameType != Enum112.const_3)
			{
				Class2301 class17 = class16.delegate2650_0();
				class17.Delay = Class1008.smethod_6(0f);
				Class2306 class18 = (Class2306)class17.delegate2773_0("tgtEl").Object;
				class18.delegate2773_0("sldTgt");
				class17.Evt = Enum277.const_9;
			}
			Class2301 class19 = class16.delegate2650_0();
			class19.Delay = Class1008.smethod_6(0f);
			Class2306 class20 = (Class2306)class19.delegate2773_0("tgtEl").Object;
			class20.delegate2773_0("sldTgt");
			class19.Evt = Enum277.const_10;
			Class2301 class21 = class16.delegate2650_0();
			class19.Delay = Class1008.smethod_6(0f);
			Class2306 class22 = (Class2306)class21.delegate2773_0("tgtEl").Object;
			class22.delegate2773_0("sldTgt");
			class21.Evt = Enum277.const_11;
		}
	}
}
