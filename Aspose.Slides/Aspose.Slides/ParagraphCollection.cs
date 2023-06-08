using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Aspose.Slides.Export;
using Aspose.Slides.Import;
using Aspose.Slides.Patterns;
using ns30;
using ns4;

namespace Aspose.Slides;

public sealed class ParagraphCollection : IEnumerable, IPresentationComponent, ISlideComponent, IEnumerable<IParagraph>, IParagraphCollection, IObserver
{
	private static readonly ParagraphFormat paragraphFormat_0 = new ParagraphFormat(null);

	private readonly List<IParagraph> list_0;

	private TextFrame textFrame_0;

	internal static readonly char[] char_0 = new char[1] { '\r' };

	private EventHandler<EventArgs0> eventHandler_0;

	private uint uint_0;

	public int Count => list_0.Count;

	public bool IsReadOnly => ((ICollection<IParagraph>)list_0).IsReadOnly;

	public IParagraph this[int index] => list_0[index];

	internal TextFrame Parent => textFrame_0;

	internal uint Version_OldMode => uint_0;

	internal string Text
	{
		get
		{
			if (Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder(((Paragraph)this[0]).TextInternal);
			for (int i = 1; i < Count; i++)
			{
				stringBuilder.Append('\r');
				stringBuilder.Append(((Paragraph)this[i]).TextInternal);
			}
			return stringBuilder.ToString();
		}
		set
		{
			Paragraph paragraph = null;
			Portion portion = null;
			if (Count > 0)
			{
				paragraph = (Paragraph)this[0];
				if (paragraph.Portions.Count > 0)
				{
					portion = (Portion)paragraph.Portions[0];
				}
				Clear();
			}
			int num = 0;
			while (num < value.Length)
			{
				int num2 = value.IndexOfAny(char_0, num);
				if (num2 < 0)
				{
					num2 = value.Length;
				}
				Paragraph paragraph2 = new Paragraph();
				paragraph2.Portions.Add(new Portion(value.Substring(num, num2 - num)));
				Add(paragraph2);
				num = num2 + 1;
			}
			if (Count == 0)
			{
				Add(new Paragraph());
				this[0].Portions.Add(new Portion(""));
			}
			if (paragraph == null)
			{
				return;
			}
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Paragraph paragraph3 = (Paragraph)enumerator.Current;
					paragraph3.method_1(paragraph);
					if (portion == null)
					{
						continue;
					}
					foreach (Portion portion2 in paragraph3.Portions)
					{
						portion2.method_0(portion);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	ISlideComponent IParagraphCollection.AsISlideComponent => this;

	IBaseSlide ISlideComponent.Slide => Slide;

	internal IBaseSlide Slide
	{
		get
		{
			if (textFrame_0 == null)
			{
				return null;
			}
			return textFrame_0.Slide;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (textFrame_0 == null)
			{
				return null;
			}
			return textFrame_0.Presentation;
		}
	}

	IEnumerable IParagraphCollection.AsIEnumerable => this;

	internal event EventHandler<EventArgs0> ParagraphRemoved
	{
		add
		{
			EventHandler<EventArgs0> eventHandler = eventHandler_0;
			EventHandler<EventArgs0> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs0> value2 = (EventHandler<EventArgs0>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs0> eventHandler = eventHandler_0;
			EventHandler<EventArgs0> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs0> value2 = (EventHandler<EventArgs0>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	internal IParagraph Add()
	{
		Paragraph paragraph = new Paragraph();
		Add(paragraph);
		return paragraph;
	}

	public void Add(IParagraph value)
	{
		if (((Paragraph)value).paragraphCollection_0 != null)
		{
			throw new PptxEditException("Cannot add paragraph that is already added to another collection");
		}
		((Paragraph)value).paragraphCollection_0 = this;
		list_0.Add(value);
		method_3((Paragraph)value);
		method_1();
	}

	public int Add(IParagraphCollection value)
	{
		int count = Count;
		if (value.Count != 0 && (value.Count != 1 || ((Paragraph)value[0]).TextInternal.Length != 0))
		{
			int num = ((list_0.Count + value.Count) & -16) + 16;
			if (num > list_0.Capacity)
			{
				list_0.Capacity = num;
			}
			foreach (Paragraph item in value)
			{
				Paragraph paragraph = new Paragraph(item);
				paragraph.paragraphCollection_0 = this;
				method_3(paragraph);
				list_0.Add(paragraph);
			}
			method_1();
			return count;
		}
		return -1;
	}

	public int IndexOf(IParagraph item)
	{
		return list_0.IndexOf(item);
	}

	public void Insert(int index, IParagraph value)
	{
		if (((Paragraph)value).paragraphCollection_0 != null)
		{
			throw new PptxEditException("Cannot insert paragraph that is already added to another collection");
		}
		((Paragraph)value).paragraphCollection_0 = this;
		method_3((Paragraph)value);
		list_0.Insert(index, value);
		method_1();
	}

	public void Insert(int index, IParagraphCollection value)
	{
		if (value.Count == 0 || (value.Count == 1 && ((Paragraph)value[0]).TextInternal.Length == 0))
		{
			return;
		}
		list_0.InsertRange(index, ((ParagraphCollection)value).list_0);
		foreach (Paragraph item in value)
		{
			Paragraph paragraph = new Paragraph(item);
			paragraph.paragraphCollection_0 = this;
			method_3(paragraph);
			list_0[index++] = paragraph;
		}
		method_1();
	}

	public void Clear()
	{
		foreach (Paragraph item in list_0)
		{
			item.paragraphCollection_0 = null;
			method_4(item);
		}
		list_0.Clear();
		method_1();
	}

	public bool Contains(IParagraph item)
	{
		return list_0.Contains(item);
	}

	public void CopyTo(IParagraph[] array, int arrayIndex)
	{
		list_0.CopyTo(array, arrayIndex);
	}

	public void RemoveAt(int index)
	{
		Paragraph paragraph = (Paragraph)this[index];
		paragraph.paragraphCollection_0 = null;
		method_4(paragraph);
		list_0.RemoveAt(index);
		method_1();
	}

	public bool Remove(IParagraph item)
	{
		Paragraph paragraph = (Paragraph)item;
		paragraph.paragraphCollection_0 = null;
		bool result;
		if (result = list_0.Remove(paragraph))
		{
			method_1();
		}
		return result;
	}

	IEnumerator<IParagraph> IEnumerable<IParagraph>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	internal int method_0(Paragraph paragraph)
	{
		if (object.ReferenceEquals(this, paragraph.paragraphCollection_0))
		{
			return list_0.IndexOf(paragraph);
		}
		return -1;
	}

	internal void method_1()
	{
		uint_0++;
		if (textFrame_0 != null)
		{
			textFrame_0.textFrameFormat_0.method_1();
		}
	}

	internal void method_2(Paragraph whichParagraph)
	{
		method_1();
	}

	private void method_3(IObservable paragraph)
	{
		paragraph.Subscribe(this);
	}

	void IObserver.Notify(object sender)
	{
		method_2((Paragraph)sender);
	}

	public void AddFromHtml(string text)
	{
		AddFromHtml(text, null, null);
	}

	public void AddFromHtml(string text, IHtmlExternalResolver resolver, string uri)
	{
		Class499 @class = new Class499(this, (HtmlExternalResolver)resolver, uri);
		char[] text2 = text.ToCharArray();
		@class.method_0(text2);
	}

	public string ExportToHtml(int firstParagraphIndex, int paragraphsCount, ITextToHtmlConversionOptions options)
	{
		if (options == null)
		{
			options = new TextToHtmlConversionOptions();
		}
		if (firstParagraphIndex >= 0 && firstParagraphIndex < Count)
		{
			if (paragraphsCount >= 0 && firstParagraphIndex + paragraphsCount <= Count)
			{
				Paragraph[] array = new Paragraph[paragraphsCount];
				IBaseSlide slide = ((ISlideComponent)this).Slide;
				FloatColor styleColor = null;
				switch (options.TextInheritanceLimit)
				{
				case TextInheritanceLimit.All:
				{
					IParagraphFormat[] textStyleCache = textFrame_0.TextStyleCache;
					styleColor = textFrame_0.floatColor_0;
					for (int j = 0; j < paragraphsCount; j++)
					{
						array[j] = ((Paragraph)this[firstParagraphIndex + j]).method_5(textStyleCache[((Paragraph)this[firstParagraphIndex + j]).ParagraphFormat.Depth]);
					}
					break;
				}
				case TextInheritanceLimit.TextBox:
				{
					ParagraphFormat[] array2 = new ParagraphFormat[9];
					if (textFrame_0.islideComponent_0 is Cell)
					{
						Class142 textStyleCache2 = ((Cell)textFrame_0.islideComponent_0).TextStyleCache;
						styleColor = ((ColorFormat)textStyleCache2.SchemeColor).method_4(slide, null);
						for (int k = 0; k < array2.Length; k++)
						{
							array2[k] = (ParagraphFormat)textFrame_0.TextFrameFormat.TextStyle.GetLevel(k);
						}
					}
					else if (textFrame_0.islideComponent_0 is AutoShape)
					{
						for (int l = 0; l < array2.Length; l++)
						{
							array2[l] = (ParagraphFormat)textFrame_0.TextFrameFormat.TextStyle.GetLevel(l);
						}
					}
					ParagraphFormat paragraphFormat = (ParagraphFormat)textFrame_0.TextFrameFormat.TextStyle.DefaultParagraphFormat;
					if (paragraphFormat == null)
					{
						paragraphFormat = paragraphFormat_0;
					}
					for (int m = 0; m < array2.Length; m++)
					{
						if (array2[m] == null)
						{
							array2[m] = paragraphFormat;
						}
					}
					for (int n = 0; n < paragraphsCount; n++)
					{
						array[n] = ((Paragraph)this[firstParagraphIndex + n]).method_5(array2[((Paragraph)this[firstParagraphIndex + n]).ParagraphFormat.Depth]);
					}
					break;
				}
				case TextInheritanceLimit.ParagraphOnly:
				{
					for (int i = 0; i < paragraphsCount; i++)
					{
						array[i] = ((Paragraph)this[firstParagraphIndex + i]).method_5(paragraphFormat_0);
					}
					break;
				}
				}
				return Class509.smethod_0(array, (TextToHtmlConversionOptions)options, (BaseSlide)slide, styleColor);
			}
			throw new ArgumentOutOfRangeException("paragraphsCount");
		}
		throw new ArgumentOutOfRangeException("firstParagraphIndex");
	}

	internal ParagraphCollection(TextFrame parent)
	{
		textFrame_0 = parent;
		list_0 = new List<IParagraph>();
	}

	private void method_4(Paragraph paragraph)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, new EventArgs0(paragraph));
		}
	}
}
