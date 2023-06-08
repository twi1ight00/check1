using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Aspose.Slides.Import;
using Aspose.Slides.Warnings;
using ns16;
using ns277;
using ns31;

namespace Aspose.Slides;

public sealed class SlideCollection : ICollection, IEnumerable, IEnumerable<ISlide>, ISlideCollection
{
	private class Class522 : IComparer
	{
		internal static readonly Class522 class522_0 = new Class522();

		public int Compare(object a, object b)
		{
			Comment comment = (Comment)a;
			Comment comment2 = (Comment)b;
			if (((CommentAuthor)comment.Author).Id < ((CommentAuthor)comment2.Author).Id)
			{
				return -1;
			}
			if (((CommentAuthor)comment.Author).Id > ((CommentAuthor)comment2.Author).Id)
			{
				return 1;
			}
			return comment.PPTXUnsupportedProps.Idx.CompareTo(comment2.PPTXUnsupportedProps.Idx);
		}
	}

	internal List<ISlide> list_0;

	private Presentation presentation_0;

	internal static Slide[] slide_0 = new Slide[0];

	public int Count => list_0.Count;

	public ISlide this[int index] => list_0[index];

	ICollection ISlideCollection.AsICollection => this;

	IEnumerable ISlideCollection.AsIEnumerable => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal SlideCollection(Presentation parent)
	{
		list_0 = new List<ISlide>();
		presentation_0 = parent;
	}

	public ISlide AddClone(ISlide sourceSlide)
	{
		Slide slide = (Slide)sourceSlide;
		lock (presentation_0)
		{
			if (slide.Presentation == presentation_0)
			{
				return (Slide)Class1026.smethod_1(presentation_0, slide.LayoutSlide, slide);
			}
			SizeF size = presentation_0.SlideSize.Size;
			SizeF size2 = slide.Presentation.SlideSize.Size;
			if (size.Width != size2.Width || size.Height != size2.Height)
			{
				presentation_0.LoadOptions.method_1("The slide-size of source and of target presentation is different!", WarningType.UnexpectedContent);
			}
			IMasterSlide destMaster = ((MasterSlideCollection)presentation_0.Masters).method_2(slide.LayoutSlideInternal.MasterSlide, cloneLinkedLayouts: true);
			return AddClone(slide, destMaster, allowCloneMissingLayout: false);
		}
	}

	public ISlide InsertClone(int index, ISlide sourceSlide)
	{
		ISlide slide = AddClone(sourceSlide);
		Reorder(index, slide);
		return slide;
	}

	public ISlide AddEmptySlide(ILayoutSlide layout)
	{
		Slide slide = method_0(layout);
		Add(slide);
		return slide;
	}

	public ISlide InsertEmptySlide(int index, ILayoutSlide layout)
	{
		Slide slide = method_0(layout);
		Insert(index, slide);
		return slide;
	}

	private Slide method_0(ILayoutSlide layout)
	{
		if (layout == null)
		{
			throw new ArgumentNullException("layout");
		}
		if (layout.Presentation != presentation_0)
		{
			throw new PptxEditException("Layout from other presentation specified.");
		}
		Slide slide = presentation_0.method_19();
		slide.LayoutSlide = layout;
		return slide;
	}

	internal Slide method_1()
	{
		return presentation_0.method_19();
	}

	public ISlide AddClone(ISlide sourceSlide, ILayoutSlide destLayout)
	{
		if (destLayout.Presentation != presentation_0)
		{
			throw new PptxEditException("Layout must belong to the target presentation.");
		}
		Slide slide;
		if (sourceSlide.Presentation == presentation_0)
		{
			slide = (Slide)Class1026.smethod_1(presentation_0, destLayout, sourceSlide);
		}
		else
		{
			slide = (Slide)Class1026.smethod_1(presentation_0, destLayout, sourceSlide);
			slide.method_8(sourceSlide);
			slide.method_7(sourceSlide.Presentation.DefaultTextStyle);
		}
		return slide;
	}

	public ISlide InsertClone(int index, ISlide sourceSlide, ILayoutSlide destLayout)
	{
		ISlide slide = AddClone(sourceSlide, destLayout);
		Reorder(index, slide);
		return slide;
	}

	[Obsolete("Use AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout) method instead. Will be removed after 01.08.2014.")]
	public ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster)
	{
		return AddClone(sourceSlide, destMaster, allowCloneMissingLayout: false);
	}

	public ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)
	{
		Slide slide = (Slide)sourceSlide;
		MasterSlide masterSlide = (MasterSlide)destMaster;
		if (masterSlide.Presentation != presentation_0)
		{
			throw new PptxEditException("Master must belong to target presentation.");
		}
		MasterSlide masterSlide2 = (MasterSlide)slide.LayoutSlideInternal.MasterSlide;
		int i;
		for (i = 0; i < masterSlide2.masterLayoutSlideCollection_0.Count && slide.LayoutSlideInternal != masterSlide2.masterLayoutSlideCollection_0[i]; i++)
		{
		}
		LayoutSlide layoutSlide = null;
		if (i < masterSlide2.masterLayoutSlideCollection_0.Count && i < masterSlide.masterLayoutSlideCollection_0.Count && masterSlide.masterLayoutSlideCollection_0[i].LayoutType == slide.LayoutSlideInternal.LayoutType)
		{
			layoutSlide = (LayoutSlide)masterSlide.masterLayoutSlideCollection_0[i];
		}
		else
		{
			for (i = 0; i < masterSlide.masterLayoutSlideCollection_0.Count; i++)
			{
				if (slide.LayoutSlideInternal.LayoutType == masterSlide.masterLayoutSlideCollection_0[i].LayoutType || slide.LayoutSlideInternal.Name == masterSlide.masterLayoutSlideCollection_0[i].Name)
				{
					layoutSlide = (LayoutSlide)masterSlide.masterLayoutSlideCollection_0[i];
					break;
				}
			}
		}
		if (layoutSlide == null)
		{
			if (!allowCloneMissingLayout)
			{
				throw new PptxEditException($"Layout slide with \"{slide.LayoutSlideInternal.LayoutType}\" layout type or name \"{slide.LayoutSlideInternal.Name}\" not found for specified Master slide. ");
			}
			layoutSlide = (LayoutSlide)presentation_0.LayoutSlides.AddClone(slide.LayoutSlideInternal, masterSlide);
		}
		return AddClone(slide, layoutSlide);
	}

	[Obsolete("Use InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout) method instead. Will be removed after 01.08.2014.")]
	public ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster)
	{
		return InsertClone(index, sourceSlide, destMaster, allowCloneMissingLayout: false);
	}

	public ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)
	{
		ISlide slide = AddClone(sourceSlide, destMaster, allowCloneMissingLayout);
		Reorder(index, slide);
		return slide;
	}

	internal void Add(ISlide value)
	{
		list_0.Add(value);
		method_2();
	}

	internal void Insert(int index, ISlide value)
	{
		list_0.Insert(index, value);
		method_2();
	}

	internal void Clear()
	{
		list_0.Clear();
	}

	public void Remove(ISlide value)
	{
		if (list_0.Contains(value))
		{
			value.Remove();
		}
	}

	public void RemoveAt(int index)
	{
		list_0[index].Remove();
	}

	IEnumerator<ISlide> IEnumerable<ISlide>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public ISlide[] ToArray()
	{
		return list_0.ToArray();
	}

	public ISlide[] ToArray(int startIndex, int count)
	{
		if (startIndex >= 0 && count >= 0 && startIndex + count <= Count)
		{
			Slide[] array = new Slide[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = (Slide)list_0[i + startIndex];
			}
			return array;
		}
		throw new ArgumentOutOfRangeException("startIndex", "Wrong index or slides count.");
	}

	public void Reorder(int index, ISlide slide)
	{
		if (index >= 0 && index < Count)
		{
			if (slide.Presentation != presentation_0)
			{
				throw new PptxEditException("Trying to move slide from other presentation.");
			}
			int num = list_0.IndexOf(slide);
			if (num < 0)
			{
				throw new PptxEditException("Trying to move removed slide.");
			}
			if (index == num)
			{
				return;
			}
			lock (((ICollection)list_0).SyncRoot)
			{
				if (index < num)
				{
					for (int num2 = num; num2 > index; num2--)
					{
						list_0[num2] = list_0[num2 - 1];
					}
				}
				else
				{
					for (int i = num; i < index; i++)
					{
						list_0[i] = list_0[i + 1];
					}
				}
				list_0[index] = slide;
			}
			method_2();
			return;
		}
		throw new PptxEditException("Index must lay within [0..Count-1] range.");
	}

	internal void method_2()
	{
		if (presentation_0 != null && !presentation_0.IsParsingInProgress)
		{
			((HeaderFooterManager)presentation_0.HeaderFooterManager).method_1();
		}
	}

	public void Reorder(int index, params ISlide[] slides)
	{
		if (index >= 0 && index <= Count - slides.Length)
		{
			if (slides.Length == 0)
			{
				return;
			}
			Dictionary<ISlide, ISlide> dictionary = new Dictionary<ISlide, ISlide>(slides.Length);
			int num = 0;
			while (true)
			{
				if (num < slides.Length)
				{
					if (slides[num].Presentation == presentation_0)
					{
						if (!dictionary.ContainsKey(slides[num]))
						{
							dictionary[slides[num]] = slides[num];
							num++;
							continue;
						}
						throw new PptxEditException("Trying to move the same slide twice. Slide number: " + slides[num].SlideNumber);
					}
					throw new PptxEditException("Trying to move slide from other presentation.");
				}
				int count = list_0.Count;
				int num2 = 0;
				int[] array = new int[slides.Length];
				for (int i = 0; i < count; i++)
				{
					if (dictionary.ContainsKey(list_0[i]))
					{
						array[num2++] = i;
					}
				}
				if (num2 < slides.Length)
				{
					throw new PptxEditException("Trying to move removed slide.");
				}
				lock (((ICollection)list_0).SyncRoot)
				{
					for (int j = 0; j < array.Length - 1; j++)
					{
						int num3 = array[j] - j;
						int num4 = array[j + 1] - j - 2;
						if (num4 >= index)
						{
							num4 = index - 1;
						}
						for (int k = num3; k <= num4; k++)
						{
							list_0[k] = slides[k + j + 1];
						}
						if (num4 == index - 1)
						{
							break;
						}
					}
					int num5 = index + slides.Length - 1;
					int num6 = 0;
					int num7 = array.Length - 1;
					while (num6 < array.Length - 1)
					{
						int num8 = array[num7] + num6;
						int num9 = array[num7 - 1] + num6 + 2;
						if (num9 <= num5)
						{
							num9 = num5 + 1;
						}
						for (int num10 = num8; num10 >= num9; num10--)
						{
							list_0[num10] = slides[num10 - num6 - 1];
						}
						if (num9 == num5 + 1)
						{
							break;
						}
						num6++;
						num7--;
					}
					for (int l = 0; l < slides.Length; l++)
					{
						list_0[index + l] = slides[l];
					}
				}
				break;
			}
			method_2();
			return;
		}
		throw new PptxEditException("Index must lay within [0..Count - slides.Length] range.");
	}

	public int IndexOf(ISlide slide)
	{
		return list_0.IndexOf(slide);
	}

	public ISlide[] AddFromHtml(string htmlText, IHtmlExternalResolver resolver, string uri)
	{
		return method_3(Count, htmlText, resolver, uri);
	}

	public ISlide[] AddFromHtml(string htmlText)
	{
		return method_3(Count, htmlText, null, "");
	}

	public ISlide[] AddFromHtml(TextReader htmlReader, IHtmlExternalResolver resolver, string uri)
	{
		return method_3(Count, htmlReader.ReadToEnd(), resolver, uri);
	}

	public ISlide[] AddFromHtml(TextReader htmlReader)
	{
		return method_3(Count, htmlReader.ReadToEnd(), null, "");
	}

	public ISlide[] AddFromHtml(Stream htmlStream, IHtmlExternalResolver resolver, string uri)
	{
		return method_3(Count, new StreamReader(htmlStream).ReadToEnd(), resolver, uri);
	}

	public ISlide[] AddFromHtml(Stream htmlStream)
	{
		return method_3(Count, new StreamReader(htmlStream).ReadToEnd(), null, "");
	}

	public ISlide[] InsertFromHtml(int index, string htmlText, IHtmlExternalResolver resolver, string uri)
	{
		return method_3(index, htmlText, resolver, uri);
	}

	public ISlide[] InsertFromHtml(int index, string htmlText)
	{
		return method_3(index, htmlText, null, "");
	}

	public ISlide[] InsertFromHtml(int index, TextReader htmlReader, IHtmlExternalResolver resolver, string uri)
	{
		return method_3(index, htmlReader.ReadToEnd(), resolver, uri);
	}

	public ISlide[] InsertFromHtml(int index, TextReader htmlReader)
	{
		return method_3(index, htmlReader.ReadToEnd(), null, "");
	}

	public ISlide[] InsertFromHtml(int index, Stream htmlStream, IHtmlExternalResolver resolver, string uri)
	{
		return method_3(index, new StreamReader(htmlStream).ReadToEnd(), resolver, uri);
	}

	public ISlide[] InsertFromHtml(int index, Stream htmlStream)
	{
		return method_3(index, new StreamReader(htmlStream).ReadToEnd(), null, "");
	}

	private ISlide[] method_3(int index, string htmlText, IHtmlExternalResolver resolver, string uri)
	{
		if (index < 0 || index > Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		Class6840 @class = new Class6840(presentation_0, index, 72f, resolver, uri);
		Class6816 class2 = new Class6816(@class, new Class510(resolver));
		class2.vmethod_0(htmlText);
		return @class.method_0();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
