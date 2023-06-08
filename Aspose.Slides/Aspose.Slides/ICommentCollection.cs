using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("20443dbf-d3aa-4e2a-82cc-9cf6a57fba07")]
public interface ICommentCollection : ICollection, IEnumerable, IEnumerable<IComment>
{
	IComment this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IComment AddComment(string text, ISlide slide, PointF position, DateTime creationTime);

	IComment InsertComment(int index, string text, ISlide slide, PointF position, DateTime creationTime);

	IComment[] ToArray();

	IComment[] ToArray(int startIndex, int count);

	void RemoveAt(int index);

	void Remove(IComment comment);

	void Clear();
}
