using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns56;

namespace ns18;

internal class Class964
{
	private const string string_0 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink";

	public static void smethod_0(IHyperlinkContainer hyperlinkContainer, Class1865 hlinkClickElementData, Class1865 hlinkHoverElementData, Class1341 deserializationContext)
	{
		if (hlinkClickElementData != null)
		{
			hyperlinkContainer.HyperlinkManager.SetExternalHyperlinkClick(null);
			IHyperlink hyperlinkClick = hyperlinkContainer.HyperlinkClick;
			smethod_1(hyperlinkClick, hlinkClickElementData, deserializationContext);
		}
		if (hlinkHoverElementData != null)
		{
			hyperlinkContainer.HyperlinkManager.SetExternalHyperlinkMouseOver(null);
			IHyperlink hyperlinkMouseOver = hyperlinkContainer.HyperlinkMouseOver;
			smethod_1(hyperlinkMouseOver, hlinkHoverElementData, deserializationContext);
		}
	}

	private static void smethod_1(IHyperlink hyperlink, Class1865 hyperlinkElementData, Class1341 deserializationContext)
	{
		Class343 pPTXUnsupportedProps = ((Hyperlink)hyperlink).PPTXUnsupportedProps;
		string r_Id = hyperlinkElementData.R_Id;
		if (!string.IsNullOrEmpty(r_Id))
		{
			Class1347 @class = deserializationContext.RelationshipsOfCurrentPartEntry[r_Id];
			if (@class.TargetMode == Enum180.const_2)
			{
				pPTXUnsupportedProps.ExternalUrl = @class.Target;
			}
			else
			{
				Class1183 parentPackage = deserializationContext.RelationshipsOfCurrentPartEntry.ParentPackage;
				if (parentPackage.method_3(@class.Target) != null)
				{
					if (!deserializationContext.SlidePartPathToUnresolvedHyperinks.ContainsKey(@class.Target))
					{
						deserializationContext.SlidePartPathToUnresolvedHyperinks.Add(@class.Target, new List<IHyperlink>());
					}
					deserializationContext.SlidePartPathToUnresolvedHyperinks[@class.Target].Add(hyperlink);
				}
				else
				{
					pPTXUnsupportedProps.ExternalUrl = @class.Target;
				}
			}
		}
		pPTXUnsupportedProps.TargetFrame = hyperlinkElementData.TgtFrame;
		pPTXUnsupportedProps.Tooltip = hyperlinkElementData.Tooltip;
		pPTXUnsupportedProps.History = hyperlinkElementData.History;
		pPTXUnsupportedProps.HighlightClick = hyperlinkElementData.HighlightClick;
		pPTXUnsupportedProps.StopSoundOnClick = hyperlinkElementData.EndSnd;
		pPTXUnsupportedProps.ExtensionList = hyperlinkElementData.ExtLst;
		pPTXUnsupportedProps.InvalidUrl = hyperlinkElementData.InvalidUrl;
		pPTXUnsupportedProps.ActionString = hyperlinkElementData.Action;
	}

	public static void smethod_2(IHyperlinkContainer hyperlinkContainer, Class1865.Delegate1474 addHlinkClick, Class1865.Delegate1474 addHlinkMouseOver, Class1346 serializationContext)
	{
		if (hyperlinkContainer != null)
		{
			smethod_3(hyperlinkContainer.HyperlinkClick, addHlinkClick, serializationContext);
			smethod_3(hyperlinkContainer.HyperlinkMouseOver, addHlinkMouseOver, serializationContext);
		}
	}

	private static void smethod_3(IHyperlink hyperlink, Class1865.Delegate1474 addHlink, Class1346 serializationContext)
	{
		if (hyperlink == null)
		{
			return;
		}
		Class1865 @class = addHlink();
		Class343 pPTXUnsupportedProps = ((Hyperlink)hyperlink).PPTXUnsupportedProps;
		if (pPTXUnsupportedProps.InternalUrl == "*")
		{
			@class.Action = "ppaction://noaction";
			return;
		}
		@class.TgtFrame = hyperlink.TargetFrame;
		@class.Tooltip = hyperlink.Tooltip;
		@class.History = hyperlink.History;
		@class.HighlightClick = hyperlink.HighlightClick;
		@class.EndSnd = hyperlink.StopSoundOnClick;
		if (hyperlink.ExternalUrl != null)
		{
			@class.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink", smethod_6(hyperlink.ExternalUrl), Enum180.const_2).Id;
		}
		else if (hyperlink.TargetSlide != null)
		{
			if (hyperlink.TargetSlide.Presentation != serializationContext.Presentation || serializationContext.Mode == Enum167.const_2)
			{
				@class.Action = "ppaction://noaction";
				return;
			}
			if (serializationContext.Mode == Enum167.const_1)
			{
				@class.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.openxmlformats.org/officeDocument/2006/relationships/slide", smethod_4(hyperlink), Enum180.const_1).Id;
			}
			else
			{
				@class.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.openxmlformats.org/officeDocument/2006/relationships/slide", serializationContext.SlideToSlidePartPath[hyperlink.TargetSlide], Enum180.const_1).Id;
			}
		}
		else if (pPTXUnsupportedProps.InternalUrl != null)
		{
			@class.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink", pPTXUnsupportedProps.InternalUrl, Enum180.const_1).Id;
		}
		@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		@class.InvalidUrl = pPTXUnsupportedProps.InvalidUrl;
		@class.Action = pPTXUnsupportedProps.ActionString;
	}

	public static string smethod_4(IHyperlink hyperlink)
	{
		return "slide" + (hyperlink.TargetSlide.SlideNumber - 1);
	}

	public static ISlide smethod_5(string label, Class1341 deserializationContext)
	{
		return deserializationContext.Presentation.Slides[Convert.ToInt32(label.Replace("slide", ""))];
	}

	private static string smethod_6(string url)
	{
		if (Uri.TryCreate(url, UriKind.Absolute, out var result))
		{
			if (string.IsNullOrEmpty(result.Scheme))
			{
				UriBuilder uriBuilder = new UriBuilder(result);
				uriBuilder.Scheme = Uri.UriSchemeFile;
				return uriBuilder.ToString();
			}
			return result.ToString();
		}
		return url;
	}
}
