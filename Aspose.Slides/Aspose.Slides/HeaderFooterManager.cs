using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ns24;
using ns33;

namespace Aspose.Slides;

public sealed class HeaderFooterManager : IHeaderFooterManager
{
	private Presentation presentation_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	public bool IsFooterVisible
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
				bool_0 = value;
				method_7(PlaceholderType.Footer, bool_0);
				method_0();
			}
		}
	}

	public bool IsSlideNumberVisible
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (bool_1 != value)
			{
				bool_1 = value;
				method_7(PlaceholderType.SlideNumber, bool_1);
				method_0();
			}
		}
	}

	public bool IsDateTimeVisible
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (bool_2 != value)
			{
				bool_2 = value;
				method_7(PlaceholderType.DateAndTime, bool_2);
				method_0();
			}
		}
	}

	public void SetFooterText(string text)
	{
		smethod_11(PlaceholderType.Footer, text, presentation_0.Masters);
		smethod_11(PlaceholderType.Footer, text, presentation_0.LayoutSlides);
		smethod_11(PlaceholderType.Footer, text, presentation_0.Slides);
	}

	public void SetDateTimeText(string date)
	{
		smethod_11(PlaceholderType.DateAndTime, date, presentation_0.Masters);
		smethod_11(PlaceholderType.DateAndTime, date, presentation_0.LayoutSlides);
		smethod_11(PlaceholderType.DateAndTime, date, presentation_0.Slides);
	}

	public void SetVisibilityOnTitleSlide(bool isPlaceholdersVisible)
	{
		if (presentation_0.LayoutSlides.Count <= 0)
		{
			return;
		}
		presentation_0.PPTXUnsupportedProps.ShowHeaderFooterOnTitles = isPlaceholdersVisible;
		uint num = method_5();
		foreach (Slide slide in presentation_0.Slides)
		{
			if (slide.LayoutSlideInternal.PPTXUnsupportedProps.SlideId == num)
			{
				if (isPlaceholdersVisible)
				{
					smethod_12(slide, slide.LayoutSlideInternal);
				}
				else
				{
					smethod_13(slide);
				}
			}
		}
	}

	internal HeaderFooterManager(Presentation pres)
	{
		presentation_0 = pres;
	}

	internal void Initialize()
	{
		IMasterSlideCollection masters = presentation_0.Masters;
		if (masters != null && masters.Count > 0)
		{
			Class494 headerFooter = ((MasterSlide)masters[0]).PPTXUnsupportedProps.HeaderFooter;
			if (headerFooter != null)
			{
				bool_0 = headerFooter.IsFooterVisible;
				bool_2 = headerFooter.IsDateTimeVisible;
				bool_1 = headerFooter.IsSlideNumberVisible;
			}
		}
	}

	internal void method_0()
	{
		foreach (MasterSlide master in presentation_0.Masters)
		{
			method_6(master.PPTXUnsupportedProps.HeaderFooter);
		}
		foreach (LayoutSlide layoutSlide in presentation_0.LayoutSlides)
		{
			layoutSlide.PPTXUnsupportedProps.HeaderFooter.Remove();
		}
	}

	internal void method_1()
	{
		if (presentation_0 == null || !presentation_0.UpdateSlideNumberFields)
		{
			return;
		}
		int firstSlideNumber = presentation_0.PPTXUnsupportedProps.FirstSlideNumber;
		ISlideCollection slides = presentation_0.Slides;
		for (int i = 0; i < slides.Count; i++)
		{
			IBaseSlide slide = slides[i];
			smethod_9(slide, i + firstSlideNumber);
		}
		try
		{
			for (int j = 0; j < presentation_0.Slides.Count; j++)
			{
				BaseSlide baseSlide = (BaseSlide)presentation_0.Slides[j].NotesSlide;
				if (baseSlide != null)
				{
					smethod_9(baseSlide, j + firstSlideNumber);
				}
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
	}

	internal void method_2()
	{
		if (presentation_0 == null || !presentation_0.UpdateDateTimeFields)
		{
			return;
		}
		ISlideCollection slides = presentation_0.Slides;
		for (int i = 0; i < slides.Count; i++)
		{
			smethod_8(slides[i]);
		}
		try
		{
			for (int j = 0; j < presentation_0.Slides.Count; j++)
			{
				BaseSlide slide = (BaseSlide)presentation_0.Slides[j].NotesSlide;
				smethod_8(slide);
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
	}

	internal void method_3(BaseSlide slide, BaseSlide placeholdersCarrier)
	{
		if (slide == null || placeholdersCarrier == null)
		{
			return;
		}
		foreach (Shape shape in placeholdersCarrier.Shapes)
		{
			if (shape.Placeholder == null)
			{
				continue;
			}
			switch (shape.Placeholder.Type)
			{
			case PlaceholderType.Footer:
				if (!IsFooterVisible)
				{
					continue;
				}
				break;
			case PlaceholderType.SlideNumber:
				if (!IsSlideNumberVisible)
				{
					continue;
				}
				break;
			case PlaceholderType.DateAndTime:
				if (!IsDateTimeVisible)
				{
					continue;
				}
				break;
			}
			smethod_0(slide, shape);
		}
	}

	internal static void smethod_0(BaseSlide slide, Shape placeholderShape)
	{
		if (slide == null || placeholderShape == null)
		{
			return;
		}
		bool flag = false;
		AutoShape autoShape = null;
		PlaceholderType type = placeholderShape.Placeholder.Type;
		foreach (Shape shape3 in slide.Shapes)
		{
			if (shape3.Placeholder != null)
			{
				if (shape3.Placeholder.Type == type && shape3.Placeholder.Index == placeholderShape.Placeholder.Index)
				{
					flag = true;
					autoShape = shape3 as AutoShape;
					break;
				}
				if (shape3.Placeholder.Type == type && shape3.Placeholder.Index == uint.MaxValue)
				{
					slide.class518_0.RemovePlaceholder(shape3);
					shape3.AddPlaceholder(placeholderShape.Placeholder);
					shape3.ResetFrame();
					flag = true;
					autoShape = shape3 as AutoShape;
					break;
				}
			}
		}
		if (!flag)
		{
			IShape shape2 = ((ShapeCollection)slide.Shapes).method_11();
			shape2.Name = placeholderShape.Name;
			shape2.AddPlaceholder(placeholderShape.Placeholder);
			autoShape = shape2 as AutoShape;
			AutoShape autoShape2 = placeholderShape as AutoShape;
			if (autoShape != null && autoShape2 != null && autoShape2.TextFrame != null && autoShape2.TextFrame.Paragraphs.Count > 0)
			{
				IParagraphCollection paragraphs = autoShape2.TextFrame.Paragraphs;
				if (paragraphs[0].Portions.Count > 0)
				{
					autoShape.TextFrame.Paragraphs[0].Portions.Clear();
				}
				foreach (Portion portion3 in paragraphs[0].Portions)
				{
					Portion portion2 = new Portion(portion3.Text);
					portion2.method_0(portion3);
					if (portion3.IsField)
					{
						portion2.AddField(portion3.Field.Type);
					}
					autoShape.TextFrame.Paragraphs[0].Portions.Add(portion2);
					((ParagraphFormat)autoShape.TextFrame.Paragraphs[0].ParagraphFormat).method_0((ParagraphFormat)paragraphs[0].ParagraphFormat);
				}
			}
		}
		if (autoShape != null && (type == PlaceholderType.DateAndTime || type == PlaceholderType.Footer))
		{
			smethod_4(placeholderShape as AutoShape, autoShape);
		}
		smethod_3(slide);
	}

	internal static void smethod_1(BaseSlide slide, BaseSlide placeholdersCarrier, PlaceholderType type)
	{
		if (slide == null || placeholdersCarrier == null)
		{
			return;
		}
		foreach (Shape shape in placeholdersCarrier.Shapes)
		{
			if (shape.Placeholder != null && shape.Placeholder.Type == type)
			{
				smethod_0(slide, shape);
			}
		}
	}

	internal static void RemovePlaceholder(BaseSlide slide, PlaceholderType phType)
	{
		if (slide == null)
		{
			return;
		}
		for (int num = slide.Shapes.Count - 1; num >= 0; num--)
		{
			IShape shape = slide.Shapes[num];
			if (shape.Placeholder != null && shape.Placeholder.Type == phType)
			{
				slide.Shapes.RemoveAt(num);
				slide.class518_0.RemovePlaceholder(shape);
			}
		}
		smethod_3(slide);
	}

	internal static void smethod_2(BaseSlide slide)
	{
		for (int num = slide.Shapes.Count - 1; num >= 0; num--)
		{
			IShape shape = slide.Shapes[num];
			if (shape.Placeholder != null && shape.Placeholder.Index != uint.MaxValue)
			{
				((Placeholder)shape.Placeholder).IndexInternal = uint.MaxValue;
			}
		}
	}

	internal void method_4(BaseSlide slide, BaseSlide placeholdersCarrier)
	{
		smethod_10(slide, placeholdersCarrier, PlaceholderType.DateAndTime, bool_2);
		smethod_10(slide, placeholdersCarrier, PlaceholderType.Footer, bool_0);
		smethod_10(slide, placeholdersCarrier, PlaceholderType.SlideNumber, bool_1);
	}

	internal static void smethod_3(BaseSlide slide)
	{
		slide.class518_0.method_2(slide);
	}

	internal static void smethod_4(AutoShape sourceShape, AutoShape destenationShape)
	{
		if (sourceShape == null || destenationShape == null)
		{
			return;
		}
		IParagraphCollection paragraphs = destenationShape.TextFrame.Paragraphs;
		paragraphs.Clear();
		foreach (IParagraph paragraph in sourceShape.TextFrame.Paragraphs)
		{
			paragraphs.Add(new Paragraph((Paragraph)paragraph));
		}
		((TextFrameFormat)destenationShape.TextFrame.TextFrameFormat).method_3((TextFrameFormat)sourceShape.TextFrame.TextFrameFormat);
	}

	internal static void smethod_5(BaseSlide slide, BaseSlide layout)
	{
		Dictionary<uint, PlaceholderType> dictionary = new Dictionary<uint, PlaceholderType>();
		List<IPlaceholder> list = new List<IPlaceholder>();
		foreach (Shape shape3 in layout.Shapes)
		{
			IPlaceholder placeholder = shape3.Placeholder;
			if (placeholder != null && placeholder.Index != uint.MaxValue)
			{
				dictionary.Add(placeholder.Index, placeholder.Type);
			}
		}
		foreach (Shape shape4 in slide.Shapes)
		{
			IPlaceholder placeholder2 = shape4.Placeholder;
			if (placeholder2 != null && placeholder2.Index != uint.MaxValue)
			{
				if (dictionary.ContainsKey(placeholder2.Index) && placeholder2.Type == dictionary[placeholder2.Index])
				{
					dictionary.Remove(placeholder2.Index);
				}
				else
				{
					list.Add(placeholder2);
				}
			}
		}
		foreach (Placeholder item in list)
		{
			foreach (KeyValuePair<uint, PlaceholderType> item2 in dictionary)
			{
				if (item2.Value == item.Type)
				{
					item.IndexInternal = item2.Key;
					dictionary.Remove(item2.Key);
					break;
				}
			}
		}
	}

	internal static string smethod_6(string format, string languageID)
	{
		CultureInfo cultureInfo;
		if (languageID == null)
		{
			cultureInfo = CultureInfo.CreateSpecificCulture("en-us");
		}
		else
		{
			try
			{
				cultureInfo = CultureInfo.CreateSpecificCulture(languageID);
			}
			catch (ArgumentException)
			{
				cultureInfo = CultureInfo.CreateSpecificCulture("en-us");
			}
		}
		DateTimeFormatInfo dateTimeFormat = cultureInfo.DateTimeFormat;
		string text = dateTimeFormat.ShortDatePattern;
		switch (format)
		{
		case "datetime2":
			text = dateTimeFormat.LongDatePattern;
			break;
		case "datetime3":
			text = "dd MMMM yyyy";
			break;
		case "datetime4":
		{
			bool flag = false;
			for (int i = 0; i < dateTimeFormat.LongDatePattern.Length; i++)
			{
				if (dateTimeFormat.LongDatePattern[i] == ' ')
				{
					text = dateTimeFormat.LongDatePattern.Substring(i + 1);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				text = "MMMM dd, yyyy";
			}
			break;
		}
		case "datetime5":
			text = "dd'-'MMM'-'yy";
			break;
		case "datetime6":
			text = "MMMM yy";
			break;
		case "datetime7":
			text = "MMM'-'yy";
			break;
		case "datetime8":
			text = $"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}";
			break;
		case "datetime9":
			text = $"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.LongTimePattern}";
			break;
		case "datetime10":
			text = "HH:mm";
			break;
		case "datetime11":
			text = "HH:mm:ss";
			break;
		case "datetime12":
			text = "h:mm tt";
			break;
		case "datetime13":
			text = "h:mm:ss tt";
			break;
		}
		return DateTime.Now.ToString(text, cultureInfo);
	}

	internal static string smethod_7(string format)
	{
		return smethod_6(format, null);
	}

	internal uint method_5()
	{
		if (presentation_0 != null && presentation_0.LayoutSlides.Count > 0)
		{
			return ((LayoutSlide)presentation_0.LayoutSlides[0]).PPTXUnsupportedProps.SlideId;
		}
		return 0u;
	}

	private void method_6(Class494 hf)
	{
		if (hf != null)
		{
			hf.IsSlideNumberVisible = bool_1;
			hf.IsFooterVisible = bool_0;
			hf.IsDateTimeVisible = bool_2;
		}
	}

	private void method_7(PlaceholderType phType, bool newVisibleState)
	{
		for (int i = 0; i < presentation_0.Slides.Count; i++)
		{
			Slide slide = (Slide)presentation_0.Slides[i];
			method_8(slide, phType, newVisibleState);
		}
	}

	internal void method_8(Slide slide, PlaceholderType phType, bool newVisibleState)
	{
		foreach (Shape shape in slide.LayoutSlideInternal.Shapes)
		{
			if (shape.Placeholder != null && phType == shape.Placeholder.Type)
			{
				if (newVisibleState)
				{
					smethod_1(slide, slide.LayoutSlideInternal, phType);
				}
				else
				{
					RemovePlaceholder(slide, phType);
				}
			}
		}
	}

	private static void smethod_8(IBaseSlide slide)
	{
		IShapeCollection shapes = slide.Shapes;
		foreach (Shape item in shapes)
		{
			if (!(item is AutoShape autoShape) || autoShape.Placeholder == null || autoShape.Placeholder.Type != PlaceholderType.DateAndTime)
			{
				continue;
			}
			foreach (Paragraph paragraph in autoShape.TextFrame.Paragraphs)
			{
				foreach (Portion portion in paragraph.Portions)
				{
					if (portion.Field != null)
					{
						smethod_14(portion);
					}
				}
			}
		}
	}

	private static void smethod_9(IBaseSlide slide, int slideIndex)
	{
		IShapeCollection shapes = slide.Shapes;
		foreach (Shape item in shapes)
		{
			if (!(item is AutoShape autoShape) || autoShape.Placeholder == null || autoShape.Placeholder.Type != PlaceholderType.SlideNumber)
			{
				continue;
			}
			foreach (Portion portion in autoShape.TextFrame.Paragraphs[0].Portions)
			{
				if (portion.IsField && (FieldType)portion.Field.Type == FieldType.SlideNumber)
				{
					portion.Text = slideIndex.ToString();
				}
			}
		}
	}

	private static void smethod_10(BaseSlide slide, BaseSlide placeholdersCarrier, PlaceholderType phType, bool requiredVisibleState)
	{
		if (slide == null || placeholdersCarrier == null)
		{
			return;
		}
		bool flag = false;
		int num = slide.Shapes.Count - 1;
		while (num >= 0)
		{
			IShape shape = slide.Shapes[num];
			if (shape.Placeholder == null || shape.Placeholder.Type != phType)
			{
				num--;
				continue;
			}
			flag = true;
			break;
		}
		if (requiredVisibleState && !flag)
		{
			smethod_1(slide, placeholdersCarrier, phType);
		}
	}

	private static void smethod_11(PlaceholderType phType, string text, ICollection slides)
	{
		foreach (BaseSlide slide in slides)
		{
			IShapeCollection shapes = slide.Shapes;
			foreach (Shape item in shapes)
			{
				if (item is AutoShape autoShape && autoShape.Placeholder != null && autoShape.Placeholder.Type == phType)
				{
					autoShape.TextFrame.Paragraphs[0].Portions[0].Text = text;
					autoShape.TextFrame.Paragraphs[0].Portions[0].RemoveField();
				}
			}
		}
	}

	private static void smethod_12(BaseSlide slide, BaseSlide placeholdersCarrier)
	{
		if (slide != null && placeholdersCarrier != null)
		{
			smethod_1(slide, placeholdersCarrier, PlaceholderType.DateAndTime);
			smethod_1(slide, placeholdersCarrier, PlaceholderType.Footer);
			smethod_1(slide, placeholdersCarrier, PlaceholderType.SlideNumber);
		}
	}

	private static void smethod_13(BaseSlide slide)
	{
		if (slide != null)
		{
			RemovePlaceholder(slide, PlaceholderType.DateAndTime);
			RemovePlaceholder(slide, PlaceholderType.Footer);
			RemovePlaceholder(slide, PlaceholderType.SlideNumber);
		}
	}

	private static void smethod_14(Portion portion)
	{
		if (portion != null && portion.Field != null)
		{
			portion.Text = smethod_7(portion.Field.Type.InternalString);
		}
	}
}
