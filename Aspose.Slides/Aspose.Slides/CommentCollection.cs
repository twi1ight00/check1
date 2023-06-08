using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Aspose.Slides;

public sealed class CommentCollection : ICollection, IEnumerable, IEnumerable<IComment>, ICommentCollection
{
	private class Class491 : IComparer<IComment>
	{
		internal static Class491 class491_0 = new Class491();

		public int Compare(IComment x, IComment y)
		{
			DateTime createdTime = x.CreatedTime;
			DateTime createdTime2 = y.CreatedTime;
			return createdTime.CompareTo(createdTime2);
		}
	}

	internal List<IComment> list_0;

	private CommentAuthor commentAuthor_0;

	public int Count => list_0.Count;

	public IComment this[int index] => list_0[index];

	internal Presentation Presentation => commentAuthor_0.presentation_0;

	ICollection ICommentCollection.AsICollection => this;

	IEnumerable ICommentCollection.AsIEnumerable => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal CommentCollection(CommentAuthor parent)
	{
		commentAuthor_0 = parent;
		list_0 = new List<IComment>();
	}

	internal void Add(Comment value)
	{
		list_0.Add(value);
	}

	internal void Insert(int index, Comment value)
	{
		list_0.Insert(index, value);
	}

	public IComment AddComment(string text, ISlide slide, PointF position, DateTime creationTime)
	{
		Comment comment = method_0(text, (Slide)slide, position, creationTime);
		Add(comment);
		return comment;
	}

	public IComment InsertComment(int index, string text, ISlide slide, PointF position, DateTime creationTime)
	{
		Comment comment = method_0(text, (Slide)slide, position, creationTime);
		Insert(index, comment);
		return comment;
	}

	internal Comment method_0(string text, Slide slide, PointF position, DateTime creationTime)
	{
		if (slide == null)
		{
			throw new ArgumentNullException("slide", "slide can't be null.");
		}
		if (slide.ParentPresentation != Presentation)
		{
			throw new PptxEditException("Can't add comment to a slide from another presentation.");
		}
		Comment comment = new Comment(commentAuthor_0, text, slide, position, creationTime);
		slide.list_0.Add(comment);
		return comment;
	}

	public IComment[] ToArray()
	{
		return list_0.ToArray();
	}

	public IComment[] ToArray(int startIndex, int count)
	{
		if (startIndex < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		if (count >= 0 && startIndex + count <= Count)
		{
			Comment[] array = new Comment[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = (Comment)list_0[i + startIndex];
			}
			return array;
		}
		throw new ArgumentOutOfRangeException("count");
	}

	public void RemoveAt(int index)
	{
		IComment comment = this[index];
		((Slide)comment.Slide).list_0.Remove(comment);
		list_0.RemoveAt(index);
	}

	public void Remove(IComment comment)
	{
		int num = list_0.IndexOf(comment);
		if (num >= 0)
		{
			RemoveAt(num);
		}
	}

	public void Clear()
	{
		list_0.Clear();
	}

	IEnumerator<IComment> IEnumerable<IComment>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	internal void method_1()
	{
		list_0.Sort(Class491.class491_0);
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
