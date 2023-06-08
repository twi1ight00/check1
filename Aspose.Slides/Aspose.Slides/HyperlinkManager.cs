namespace Aspose.Slides;

public sealed class HyperlinkManager : IHyperlinkManager
{
	private IHyperlinkContainer ihyperlinkContainer_0;

	public IHyperlink SetExternalHyperlinkClick(string url)
	{
		Hyperlink hyperlink = new Hyperlink(url);
		ihyperlinkContainer_0.HyperlinkClick = hyperlink;
		return hyperlink;
	}

	public IHyperlink SetInternalHyperlinkClick(ISlide targetSlide)
	{
		Hyperlink hyperlink = new Hyperlink(targetSlide);
		ihyperlinkContainer_0.HyperlinkClick = hyperlink;
		return hyperlink;
	}

	public void RemoveHyperlinkClick()
	{
		ihyperlinkContainer_0.HyperlinkClick = null;
	}

	public IHyperlink SetExternalHyperlinkMouseOver(string url)
	{
		Hyperlink hyperlink = new Hyperlink(url);
		ihyperlinkContainer_0.HyperlinkMouseOver = hyperlink;
		return hyperlink;
	}

	public IHyperlink SetInternalHyperlinkMouseOver(ISlide targetSlide)
	{
		Hyperlink hyperlink = new Hyperlink(targetSlide);
		ihyperlinkContainer_0.HyperlinkMouseOver = hyperlink;
		return hyperlink;
	}

	public void RemoveHyperlinkMouseOver()
	{
		ihyperlinkContainer_0.HyperlinkMouseOver = null;
	}

	internal HyperlinkManager(IHyperlinkContainer parentHyperlinkContainer)
	{
		ihyperlinkContainer_0 = parentHyperlinkContainer;
	}
}
