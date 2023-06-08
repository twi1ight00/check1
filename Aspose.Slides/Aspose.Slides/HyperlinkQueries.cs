using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Aspose.Slides;

public sealed class HyperlinkQueries : IHyperlinkQueries
{
	private delegate bool Delegate4(IHyperlinkContainer hyperlinkContainer);

	private object object_0;

	[CompilerGenerated]
	private static Delegate4 delegate4_0;

	[CompilerGenerated]
	private static Delegate4 delegate4_1;

	[CompilerGenerated]
	private static Delegate4 delegate4_2;

	public IList<IHyperlinkContainer> GetHyperlinkClicks()
	{
		return method_0(object_0, (IHyperlinkContainer x) => x.HyperlinkClick != null);
	}

	public IList<IHyperlinkContainer> GetHyperlinkMouseOvers()
	{
		return method_0(object_0, (IHyperlinkContainer x) => x.HyperlinkMouseOver != null);
	}

	public IList<IHyperlinkContainer> GetAnyHyperlinks()
	{
		return method_0(object_0, (IHyperlinkContainer x) => x.HyperlinkClick != null || x.HyperlinkMouseOver != null);
	}

	public void RemoveAllHyperlinks()
	{
		IList<IHyperlinkContainer> anyHyperlinks = GetAnyHyperlinks();
		foreach (IHyperlinkContainer item in anyHyperlinks)
		{
			item.HyperlinkManager.RemoveHyperlinkClick();
			item.HyperlinkManager.RemoveHyperlinkMouseOver();
		}
	}

	internal HyperlinkQueries(object parent)
	{
		object_0 = parent;
	}

	private List<IHyperlinkContainer> method_0(object component, Delegate4 filter)
	{
		List<IHyperlinkContainer> list = new List<IHyperlinkContainer>();
		if (component is TextFrame)
		{
			TextFrame textFrame = (TextFrame)component;
			foreach (IParagraph paragraph in textFrame.Paragraphs)
			{
				foreach (IPortion portion in paragraph.Portions)
				{
					if (filter(portion.PortionFormat))
					{
						list.Add(portion.PortionFormat);
					}
				}
			}
		}
		else if (component is BaseSlide)
		{
			BaseSlide baseSlide = (BaseSlide)component;
			foreach (IShape shape in baseSlide.Shapes)
			{
				if (filter(shape))
				{
					list.Add(shape);
				}
				if (shape is AutoShape)
				{
					list.AddRange(method_0(((AutoShape)shape).TextFrame, filter));
				}
			}
		}
		else
		{
			if (!(component is Presentation))
			{
				throw new ArgumentException();
			}
			Presentation presentation = (Presentation)component;
			foreach (ISlide slide in presentation.Slides)
			{
				list.AddRange(method_0(slide, filter));
			}
		}
		return list;
	}

	[CompilerGenerated]
	private static bool smethod_0(IHyperlinkContainer x)
	{
		return x.HyperlinkClick != null;
	}

	[CompilerGenerated]
	private static bool smethod_1(IHyperlinkContainer x)
	{
		return x.HyperlinkMouseOver != null;
	}

	[CompilerGenerated]
	private static bool smethod_2(IHyperlinkContainer x)
	{
		if (x.HyperlinkClick == null)
		{
			return x.HyperlinkMouseOver != null;
		}
		return true;
	}
}
