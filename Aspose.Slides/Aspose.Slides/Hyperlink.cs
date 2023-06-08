using System;
using System.Collections.Generic;
using ns24;
using ns33;

namespace Aspose.Slides;

public class Hyperlink : IHyperlink
{
	private static readonly Hyperlink hyperlink_0 = new Hyperlink(external: false, null, "ppaction://media");

	private static readonly Hyperlink hyperlink_1 = new Hyperlink(external: false, null, "ppaction://noaction");

	private static readonly Hyperlink hyperlink_2 = new Hyperlink(external: false, null, "ppaction://hlinkshowjump?jump=previousslide");

	private static readonly Hyperlink hyperlink_3 = new Hyperlink(external: false, null, "ppaction://hlinkshowjump?jump=nextslide");

	private static readonly Hyperlink hyperlink_4 = new Hyperlink(external: false, null, "ppaction://hlinkshowjump?jump=firstslide");

	private static readonly Hyperlink hyperlink_5 = new Hyperlink(external: false, null, "ppaction://hlinkshowjump?jump=lastslide");

	private static readonly Hyperlink hyperlink_6 = new Hyperlink(external: false, null, "ppaction://hlinkshowjump?jump=endshow");

	private static readonly Hyperlink hyperlink_7 = new Hyperlink(external: false, null, "ppaction://hlinkshowjump?jump=lastslideviewed");

	private readonly Class343 class343_0 = new Class343();

	internal Class343 PPTXUnsupportedProps => class343_0;

	private string InvalidUrl
	{
		get
		{
			return PPTXUnsupportedProps.InvalidUrl;
		}
		set
		{
			PPTXUnsupportedProps.InvalidUrl = value;
		}
	}

	internal string ActionString
	{
		get
		{
			return PPTXUnsupportedProps.ActionString;
		}
		set
		{
			PPTXUnsupportedProps.ActionString = value;
		}
	}

	internal string InternalUrl
	{
		get
		{
			return PPTXUnsupportedProps.InternalUrl;
		}
		set
		{
			PPTXUnsupportedProps.InternalUrl = value;
		}
	}

	public static Hyperlink NoAction => hyperlink_1;

	public static Hyperlink Media => hyperlink_0;

	public static Hyperlink NextSlide => hyperlink_3;

	public static Hyperlink PreviousSlide => hyperlink_2;

	public static Hyperlink FirstSlide => hyperlink_4;

	public static Hyperlink LastSlide => hyperlink_5;

	public static Hyperlink LastVievedSlide => hyperlink_7;

	public static Hyperlink EndShow => hyperlink_6;

	public string ExternalUrl => PPTXUnsupportedProps.ExternalUrl;

	public HyperlinkActionType ActionType
	{
		get
		{
			string param;
			string param2;
			return method_0(out param, out param2);
		}
	}

	internal long TargetCustomShowId
	{
		get
		{
			string param;
			string param2;
			HyperlinkActionType hyperlinkActionType = method_0(out param, out param2);
			if (hyperlinkActionType == HyperlinkActionType.StartCustomSlideShow && param != null)
			{
				try
				{
					return long.Parse(param);
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
				}
			}
			return -1L;
		}
	}

	public ISlide TargetSlide => PPTXUnsupportedProps.TargetSlide;

	public string TargetFrame => PPTXUnsupportedProps.TargetFrame;

	public string Tooltip => PPTXUnsupportedProps.Tooltip;

	public bool History => PPTXUnsupportedProps.History;

	public bool HighlightClick => PPTXUnsupportedProps.HighlightClick;

	public bool StopSoundOnClick => PPTXUnsupportedProps.StopSoundOnClick;

	public Hyperlink(string url)
	{
		PPTXUnsupportedProps.ExternalUrl = url;
	}

	public Hyperlink(ISlide slide)
		: this(external: false, null, "ppaction://hlinksldjump")
	{
		PPTXUnsupportedProps.TargetSlide = slide;
	}

	public Hyperlink(Hyperlink source, string targetFrame, string tooltip, bool history, bool stopSoundsOnClick, bool highlightClick)
	{
		ActionString = source.ActionString;
		PPTXUnsupportedProps.ExternalUrl = source.PPTXUnsupportedProps.ExternalUrl;
		PPTXUnsupportedProps.InternalUrl = source.PPTXUnsupportedProps.InternalUrl;
		InvalidUrl = source.InvalidUrl;
		PPTXUnsupportedProps.TargetFrame = targetFrame;
		PPTXUnsupportedProps.Tooltip = tooltip;
		PPTXUnsupportedProps.History = history;
		PPTXUnsupportedProps.StopSoundOnClick = stopSoundsOnClick;
		PPTXUnsupportedProps.HighlightClick = highlightClick;
	}

	internal Hyperlink(bool external, string uri, string action)
	{
		if (external)
		{
			PPTXUnsupportedProps.ExternalUrl = uri;
			InternalUrl = null;
		}
		else
		{
			InternalUrl = uri;
			PPTXUnsupportedProps.ExternalUrl = null;
		}
		ActionString = action;
	}

	private HyperlinkActionType method_0(out string param1, out string param2)
	{
		param1 = (param2 = null);
		if (string.IsNullOrEmpty(ActionString))
		{
			return HyperlinkActionType.Hyperlink;
		}
		string text = ActionString.ToLower();
		if (!text.StartsWith("ppaction://"))
		{
			return HyperlinkActionType.Unknown;
		}
		int num = text.IndexOf('?');
		string text2 = text.Substring("ppaction://".Length, ((num > 0) ? num : text.Length) - "ppaction://".Length);
		Dictionary<string, string> dictionary = null;
		if (num > 0)
		{
			dictionary = new Dictionary<string, string>();
			while (num < text.Length)
			{
				int num2 = num + 1;
				num = text.IndexOf('&', num2);
				if (num < 0)
				{
					num = text.Length;
				}
				int num3 = text.IndexOf('=', num2, num - num2);
				if (num3 >= 0)
				{
					dictionary.Add(text.Substring(num2, num3 - num2), text.Substring(num3 + 1, num - num3 - 1));
				}
			}
		}
		string value = null;
		switch (text2)
		{
		case "noaction":
			return HyperlinkActionType.NoAction;
		case "customshow":
			dictionary?.TryGetValue("id", out param1);
			return HyperlinkActionType.StartCustomSlideShow;
		case "hlinkshowjump":
			dictionary?.TryGetValue("jump", out value);
			return value switch
			{
				"firstslide" => HyperlinkActionType.JumpFirstSlide, 
				"lastslide" => HyperlinkActionType.JumpLastSlide, 
				"previousslide" => HyperlinkActionType.JumpPreviousSlide, 
				"lastslideviewed" => HyperlinkActionType.JumpLastViewedSlide, 
				"endshow" => HyperlinkActionType.JumpEndShow, 
				_ => HyperlinkActionType.JumpNextSlide, 
			};
		case "hlinksldjump":
			param1 = InternalUrl;
			return HyperlinkActionType.JumpSpecificSlide;
		case "macro":
			dictionary?.TryGetValue("name", out param1);
			return HyperlinkActionType.StartMacro;
		case "media":
			return HyperlinkActionType.StartStopMedia;
		case "program":
			param1 = ExternalUrl;
			return HyperlinkActionType.StartProgram;
		case "hlinkfile":
			param1 = ExternalUrl;
			return HyperlinkActionType.OpenFile;
		case "hlinkpres":
			param1 = ExternalUrl;
			dictionary?.TryGetValue("slideindex", out param2);
			return HyperlinkActionType.OpenPresentation;
		default:
			return HyperlinkActionType.Unknown;
		}
	}

	public override bool Equals(object obj)
	{
		Hyperlink hyperlink = obj as Hyperlink;
		if (hyperlink != null)
		{
			return method_1(hyperlink);
		}
		return false;
	}

	public bool Equals(IHyperlink hlink)
	{
		if (hlink != null)
		{
			return method_1((Hyperlink)hlink);
		}
		return false;
	}

	private bool method_1(Hyperlink hlink)
	{
		if (ExternalUrl == hlink.ExternalUrl && InternalUrl == hlink.InternalUrl && TargetSlide == hlink.TargetSlide && TargetFrame == hlink.TargetFrame && Tooltip == hlink.Tooltip && History == hlink.History && HighlightClick == hlink.HighlightClick && StopSoundOnClick == hlink.StopSoundOnClick && InvalidUrl == hlink.InvalidUrl)
		{
			return ActionString == hlink.ActionString;
		}
		return false;
	}

	public static bool operator ==(Hyperlink hlink1, Hyperlink hlink2)
	{
		if (object.ReferenceEquals(hlink1, hlink2))
		{
			return true;
		}
		if (object.ReferenceEquals(hlink1, null))
		{
			return false;
		}
		return hlink1.Equals(hlink2);
	}

	public static bool operator !=(Hyperlink hlink1, Hyperlink hlink2)
	{
		if (object.ReferenceEquals(hlink1, hlink2))
		{
			return false;
		}
		if (object.ReferenceEquals(hlink1, null))
		{
			return true;
		}
		return !hlink1.Equals(hlink2);
	}

	public override int GetHashCode()
	{
		return ((InvalidUrl != null) ? InvalidUrl.GetHashCode() : 0) + ActionString.GetHashCode();
	}
}
