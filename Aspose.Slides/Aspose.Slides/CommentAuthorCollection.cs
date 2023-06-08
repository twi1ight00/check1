using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides;

public sealed class CommentAuthorCollection : ICollection, IEnumerable, IEnumerable<ICommentAuthor>, ICommentAuthorCollection
{
	private uint uint_0;

	internal List<ICommentAuthor> list_0;

	private Presentation presentation_0;

	public int Count => list_0.Count;

	public ICommentAuthor this[int index] => list_0[index];

	internal Presentation Presentation => presentation_0;

	ICollection ICommentAuthorCollection.AsICollection => this;

	IEnumerable ICommentAuthorCollection.AsIEnumerable => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal CommentAuthorCollection(Presentation pres)
	{
		presentation_0 = pres;
		list_0 = new List<ICommentAuthor>();
	}

	public ICommentAuthor AddAuthor(string name, string initials)
	{
		lock (((ICollection)list_0).SyncRoot)
		{
			foreach (CommentAuthor item in list_0)
			{
				uint_0 = ((item.Id >= uint_0) ? (item.Id + 1) : uint_0);
			}
			uint id = uint_0++;
			CommentAuthor commentAuthor2 = new CommentAuthor(presentation_0, id, name, initials);
			list_0.Add(commentAuthor2);
			return commentAuthor2;
		}
	}

	public ICommentAuthor[] ToArray()
	{
		return list_0.ToArray();
	}

	internal CommentAuthor method_0(uint id)
	{
		foreach (CommentAuthor item in list_0)
		{
			if (item.Id == id)
			{
				return item;
			}
		}
		return null;
	}

	public ICommentAuthor[] FindByName(string name)
	{
		ArrayList arrayList = new ArrayList();
		foreach (CommentAuthor item in list_0)
		{
			if (item.Name == name)
			{
				arrayList.Add(item);
			}
		}
		return (CommentAuthor[])arrayList.ToArray(typeof(CommentAuthor));
	}

	public ICommentAuthor[] FindByNameAndInitials(string name, string initials)
	{
		ArrayList arrayList = new ArrayList();
		foreach (CommentAuthor item in list_0)
		{
			if (item.Name == name && item.Initials == initials)
			{
				arrayList.Add(item);
			}
		}
		return (CommentAuthor[])arrayList.ToArray(typeof(CommentAuthor));
	}

	IEnumerator<ICommentAuthor> IEnumerable<ICommentAuthor>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
