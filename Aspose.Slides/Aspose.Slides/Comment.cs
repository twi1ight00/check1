using System;
using System.Drawing;
using ns24;

namespace Aspose.Slides;

public sealed class Comment : IComment
{
	private Class332 class332_0 = new Class332();

	private string string_0;

	private DateTime dateTime_0;

	private PointF pointF_0;

	private Slide slide_0;

	private CommentAuthor commentAuthor_0;

	internal Class332 PPTXUnsupportedProps => class332_0;

	public string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public DateTime CreatedTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
		}
	}

	public ISlide Slide => slide_0;

	public ICommentAuthor Author => commentAuthor_0;

	public PointF Position
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	internal Comment(CommentAuthor author, string text, Slide slide, PointF position, DateTime dateTime)
	{
		commentAuthor_0 = author;
		string_0 = text;
		slide_0 = slide;
		pointF_0 = position;
		dateTime_0 = dateTime;
		PPTXUnsupportedProps.Idx = ++author.PPTXUnsupportedProps.LastIndex;
	}
}
