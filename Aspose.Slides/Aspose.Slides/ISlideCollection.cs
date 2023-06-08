using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Aspose.Slides.Import;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("f2375dc3-1d00-4e39-8e6c-0fc7fb011474")]
public interface ISlideCollection : ICollection, IEnumerable, IEnumerable<ISlide>
{
	ISlide this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	ISlide AddClone(ISlide sourceSlide);

	ISlide InsertClone(int index, ISlide sourceSlide);

	ISlide AddEmptySlide(ILayoutSlide layout);

	ISlide InsertEmptySlide(int index, ILayoutSlide layout);

	ISlide AddClone(ISlide sourceSlide, ILayoutSlide destLayout);

	ISlide InsertClone(int index, ISlide sourceSlide, ILayoutSlide destLayout);

	[Obsolete("Use AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout) method instead. Will be removed after 01.08.2014.")]
	ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

	ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);

	[Obsolete("Use InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout) method instead. Will be removed after 01.08.2014.")]
	ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

	ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);

	void Remove(ISlide value);

	void RemoveAt(int index);

	ISlide[] ToArray();

	ISlide[] ToArray(int startIndex, int count);

	void Reorder(int index, ISlide slide);

	void Reorder(int index, params ISlide[] slides);

	int IndexOf(ISlide slide);

	ISlide[] AddFromHtml(string htmlText, IHtmlExternalResolver resolver, string uri);

	ISlide[] AddFromHtml(string htmlText);

	ISlide[] AddFromHtml(TextReader htmlReader, IHtmlExternalResolver resolver, string uri);

	ISlide[] AddFromHtml(TextReader htmlReader);

	ISlide[] AddFromHtml(Stream htmlStream, IHtmlExternalResolver resolver, string uri);

	ISlide[] AddFromHtml(Stream htmlStream);

	ISlide[] InsertFromHtml(int index, string htmlText, IHtmlExternalResolver resolver, string uri);

	ISlide[] InsertFromHtml(int index, string htmlText);

	ISlide[] InsertFromHtml(int index, TextReader htmlReader, IHtmlExternalResolver resolver, string uri);

	ISlide[] InsertFromHtml(int index, TextReader htmlReader);

	ISlide[] InsertFromHtml(int index, Stream htmlStream, IHtmlExternalResolver resolver, string uri);

	ISlide[] InsertFromHtml(int index, Stream htmlStream);
}
