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

internal class Class1022
{
	private const string string_0 = "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}";

	private const string string_1 = "http://schemas.microsoft.com/office/powerpoint/2010/main";

	private const string string_2 = "http://schemas.microsoft.com/office/2007/relationships/media";

	private const string string_3 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

	private static float[] float_0 = new float[4] { 0f, 0.2f, 0.5f, 0.8f };

	internal static IVideoFrame smethod_0(IGroupShape groupShape, Class2004 picElementData, Class1979 videoFileElementData, Class1341 deserializationContext)
	{
		IVideoFrame videoFrame = null;
		string text = videoFileElementData.R_Link;
		XmlElement xmlElement = Class893.smethod_3(picElementData.NvPicPr.NvPr.ExtLst);
		if (xmlElement != null)
		{
			if (xmlElement.HasAttribute("embed", "http://schemas.openxmlformats.org/officeDocument/2006/relationships"))
			{
				string attribute = xmlElement.GetAttribute("embed", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
				if (attribute != null && attribute.Length > 0)
				{
					Class1347 @class = deserializationContext.RelationshipsOfCurrentPartEntry[attribute];
					videoFrame = groupShape.Shapes.AddVideoFrame(0f, 0f, 0f, 0f, deserializationContext.method_3(@class.TargetPart));
					Class983.smethod_3(videoFrame);
				}
			}
			if (xmlElement.HasAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships"))
			{
				text = xmlElement.GetAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			}
		}
		if (videoFrame == null && text != null && text.Length > 0)
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
				videoFrame = groupShape.Shapes.AddVideoFrame(0f, 0f, 0f, 0f, fname);
				Class983.smethod_3(videoFrame);
			}
		}
		return videoFrame;
	}

	internal static void smethod_1(VideoFrame videoFrame, Class2006 videoFrameElementData, Class1346 serializationContext)
	{
		Class284 pPTXUnsupportedProps = videoFrame.PPTXUnsupportedProps;
		Class976.smethod_2(videoFrame, videoFrameElementData, serializationContext);
		bool flag;
		if ((flag = videoFrame.LinkPathLong != null && videoFrame.LinkPathLong.Length > 0) || videoFrame.EmbeddedVideo != null)
		{
			Class1979 @class = (Class1979)videoFrameElementData.NvPicPr.NvPr.delegate2773_0("videoFile").Object;
			Class1347 class2 = serializationContext.RelationshipsOfCurrentPartEntry.method_6(Class1317.class1338_0.Type, flag ? Class1165.smethod_17(videoFrame.LinkPathLong) : serializationContext.method_8(videoFrame.EmbeddedVideo).PartPath, flag ? Enum180.const_2 : Enum180.const_0);
			@class.R_Link = class2.Id;
			if (videoFrame.EmbeddedVideo != null)
			{
				if (pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties == null)
				{
					pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties = new Class1888();
				}
				Class1454 class3 = Class2514.smethod_2(pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties, "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}");
				XmlDocument xmlDocument = new XmlDocument();
				XmlDocumentFragment xmlDocumentFragment = xmlDocument.CreateDocumentFragment();
				xmlDocumentFragment.InnerXml = class3.OuterXml;
				XmlElement xmlElement = (XmlElement)Class1029.smethod_13(xmlDocumentFragment.ChildNodes[0], "media", "http://schemas.microsoft.com/office/powerpoint/2010/main");
				Class1347 class4 = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.microsoft.com/office/2007/relationships/media", serializationContext.method_8(videoFrame.EmbeddedVideo).PartPath, Enum180.const_0);
				xmlElement.SetAttribute("embed", "http://schemas.openxmlformats.org/officeDocument/2006/relationships", class4.Id);
				if (flag)
				{
					Class1347 class5 = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.microsoft.com/office/2007/relationships/media", Class1165.smethod_17(videoFrame.LinkPathLong), Enum180.const_2);
					xmlElement.SetAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships", class5.Id);
				}
				else
				{
					xmlElement.RemoveAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
				}
				class3.OuterXml = xmlDocumentFragment.OuterXml;
				Class1885 class6 = ((videoFrameElementData.NvPicPr.NvPr.ExtLst == null) ? videoFrameElementData.NvPicPr.NvPr.delegate1534_0() : videoFrameElementData.NvPicPr.NvPr.ExtLst);
				Class1449 class7 = class6.delegate383_0();
				class7.OuterXml = xmlDocumentFragment.OuterXml;
			}
			else
			{
				Class1454 class8 = Class2514.smethod_1(pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties, "{DAA4B4D4-6D71-4841-9C94-3DE7FCFB9230}");
				if (class8 != null)
				{
					XmlElement xmlElement2 = (XmlElement)Class1029.smethod_11(class8.XmlDocument.DocumentElement, "media", "http://schemas.microsoft.com/office/powerpoint/2010/main");
					if (xmlElement2 != null)
					{
						if (flag)
						{
							Class1347 class9 = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.microsoft.com/office/2007/relationships/media", Class1165.smethod_17(videoFrame.LinkPathLong), Enum180.const_2);
							xmlElement2.SetAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships", class9.Id);
						}
						else
						{
							xmlElement2.RemoveAttribute("link", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
						}
					}
				}
			}
		}
		if (videoFrame.Slide is ISlide)
		{
			Slide slide = (Slide)videoFrame.Slide;
			uint num = Class1008.smethod_13(slide);
			if (slide.PPTXUnsupportedProps.TimingElementData == null)
			{
				slide.PPTXUnsupportedProps.TimingElementData = new Class2259();
			}
			Class2264 class10 = slide.PPTXUnsupportedProps.TimingElementData.TnLst;
			if (class10 == null)
			{
				class10 = slide.PPTXUnsupportedProps.TimingElementData.delegate2539_0();
			}
			Class2289 class11 = (Class2289)class10.delegate2773_0("video").Object;
			if (pPTXUnsupportedProps.PlayModeInternal == VideoPlayModePreset.AllSlides)
			{
				class11.CMediaNode.NumSld = 999u;
			}
			num = (uint)(class11.CMediaNode.CTn.Id = (int)(num + 1));
			class11.CMediaNode.CTn.Spd = 1f;
			class11.CMediaNode.CTn.Accel = 0f;
			class11.CMediaNode.CTn.Decel = 0f;
			class11.CMediaNode.CTn.Fill = ((!videoFrame.RewindVideo) ? Enum289.const_3 : Enum289.const_1);
			class11.FullScrn = videoFrame.FullScreenMode;
			if (videoFrame.Volume == AudioVolumeMode.Mute)
			{
				class11.CMediaNode.Mute = true;
			}
			class11.CMediaNode.Vol = float_0[(int)videoFrame.Volume];
			class11.CMediaNode.CTn.Display = NullableBool.False;
			Class2294 class12 = (Class2294)class11.CMediaNode.TgtEl.delegate2773_0("spTgt").Object;
			class12.Spid = XmlConvert.ToString(videoFrame.ShapeId);
			class11.CMediaNode.ShowWhenStopped = !videoFrame.HideAtShowing;
			class11.CMediaNode.CTn.RepeatCount = Class1008.smethod_6(videoFrame.PlayLoopMode ? float.PositiveInfinity : 1f);
			Class2302 class13 = class11.CMediaNode.CTn.delegate2653_0();
			Class2301 class14 = class13.delegate2650_0();
			class14.Delay = Class1008.smethod_6(float.PositiveInfinity);
			if (pPTXUnsupportedProps.PlayModeInternal == VideoPlayModePreset.AllSlides)
			{
				Class2302 class15 = class11.CMediaNode.CTn.delegate2653_1();
				Class2301 class16 = class15.delegate2650_0();
				class16.Delay = Class1008.smethod_6(0f);
				Class2306 class17 = (Class2306)class16.delegate2773_0("tgtEl").Object;
				class17.delegate2773_0("sldTgt");
				class16.Evt = Enum277.const_10;
			}
			else
			{
				Class2302 class18 = class11.CMediaNode.CTn.delegate2653_1();
				Class2301 class19 = class18.delegate2650_0();
				class19.Delay = Class1008.smethod_6(0f);
				Class2306 class20 = (Class2306)class19.delegate2773_0("tgtEl").Object;
				class20.delegate2773_0("sldTgt");
				class19.Evt = Enum277.const_9;
				Class2301 class21 = class18.delegate2650_0();
				class19.Delay = Class1008.smethod_6(0f);
				Class2306 class22 = (Class2306)class21.delegate2773_0("tgtEl").Object;
				class22.delegate2773_0("sldTgt");
				class21.Evt = Enum277.const_10;
			}
		}
	}
}
