using System;
using System.Collections.Generic;
using System.Threading;
using Aspose.Slides;

namespace ns4;

internal class Class518
{
	private BaseSlide baseSlide_0;

	private ParagraphFormat.Delegate9 delegate9_0;

	private ParagraphFormat.Delegate9 delegate9_1;

	internal event ParagraphFormat.Delegate9 m_textPropsChanged
	{
		add
		{
			ParagraphFormat.Delegate9 @delegate = delegate9_0;
			ParagraphFormat.Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				ParagraphFormat.Delegate9 value2 = (ParagraphFormat.Delegate9)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate9_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
		remove
		{
			ParagraphFormat.Delegate9 @delegate = delegate9_0;
			ParagraphFormat.Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				ParagraphFormat.Delegate9 value2 = (ParagraphFormat.Delegate9)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate9_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
	}

	internal event ParagraphFormat.Delegate9 m_parentChanged
	{
		add
		{
			ParagraphFormat.Delegate9 @delegate = delegate9_1;
			ParagraphFormat.Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				ParagraphFormat.Delegate9 value2 = (ParagraphFormat.Delegate9)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate9_1, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
		remove
		{
			ParagraphFormat.Delegate9 @delegate = delegate9_1;
			ParagraphFormat.Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				ParagraphFormat.Delegate9 value2 = (ParagraphFormat.Delegate9)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate9_1, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
	}

	internal Class518(BaseSlide slide)
	{
		baseSlide_0 = slide;
	}

	internal Shape method_0(Placeholder slidePlaceholder)
	{
		return baseSlide_0.method_6(slidePlaceholder.Index);
	}

	internal Shape method_1(IPlaceholder layoutPlaceholder, Placeholder slidePlaceholder)
	{
		PlaceholderType placeholderType = layoutPlaceholder.Type;
		switch (placeholderType)
		{
		case PlaceholderType.Title:
		case PlaceholderType.CenteredTitle:
			placeholderType = PlaceholderType.Title;
			break;
		case PlaceholderType.Body:
		case PlaceholderType.Subtitle:
		case PlaceholderType.Object:
		case PlaceholderType.Chart:
		case PlaceholderType.Table:
		case PlaceholderType.ClipArt:
		case PlaceholderType.Diagram:
		case PlaceholderType.Media:
		case PlaceholderType.Picture:
			placeholderType = PlaceholderType.Body;
			break;
		}
		return baseSlide_0.method_5(placeholderType);
	}

	internal void method_2(BaseSlide slide)
	{
		List<Shape> list = slide.method_3();
		foreach (Shape item in list)
		{
			Placeholder placeholder = (Placeholder)item.Placeholder;
			if (placeholder != null && item is AutoShape autoShape && autoShape.TextFrame != null)
			{
				TextFrame textFrame = (TextFrame)autoShape.TextFrame;
				((TextStyle)textFrame.TextFrameFormat.TextStyle).m_styleChanged += method_3;
				m_parentChanged += textFrame.textFrameFormat_0.class514_0.method_0;
			}
		}
	}

	internal void RemovePlaceholder(IShape shape)
	{
		if (shape.Placeholder != null && ((BaseSlide)shape.Slide).class518_0 == this && shape is AutoShape)
		{
			TextFrame textFrame = (TextFrame)((AutoShape)shape).TextFrame;
			if (textFrame != null)
			{
				((TextStyle)textFrame.TextFrameFormat.TextStyle).m_styleChanged -= method_3;
				m_parentChanged -= textFrame.textFrameFormat_0.class514_0.method_0;
			}
		}
	}

	internal void AddPlaceholder(IShape shape)
	{
		if (shape.Placeholder != null && ((BaseSlide)shape.Slide).class518_0 == this && shape is AutoShape autoShape)
		{
			TextFrame textFrame = (TextFrame)autoShape.TextFrame;
			if (textFrame != null)
			{
				((TextStyle)textFrame.TextFrameFormat.TextStyle).m_styleChanged += method_3;
				m_parentChanged += textFrame.textFrameFormat_0.class514_0.method_0;
			}
		}
	}

	internal void method_3(ParagraphFormat whichParagraph)
	{
		if (delegate9_0 != null)
		{
			delegate9_0(whichParagraph);
		}
	}

	internal void method_4(ParagraphFormat whichParagraph)
	{
		if (delegate9_1 != null)
		{
			delegate9_1(whichParagraph);
		}
		if (delegate9_0 != null)
		{
			delegate9_0(whichParagraph);
		}
	}

	internal List<uint> method_5()
	{
		List<uint> list = new List<uint>();
		List<Shape> list2 = baseSlide_0.method_3();
		foreach (Shape item in list2)
		{
			if (item.Placeholder != null)
			{
				list.Add(item.Placeholder.Index);
			}
		}
		return list;
	}
}
