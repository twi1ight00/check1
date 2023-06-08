using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml;
using Aspose.Slides.Patterns;
using ns28;
using ns29;
using ns4;

namespace Aspose.Slides;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("13a09689-4561-4eb0-ad64-bd08927115e2")]
public sealed class Paragraph : IPresentationComponent, ISlideComponent, IParagraph, IObservable
{
	internal class Class514
	{
		public int int_0;

		internal static readonly Class514 class514_0 = new Class514();

		internal void method_0(ParagraphFormat whichParagraph)
		{
			int_0++;
		}
	}

	private class Class515
	{
		internal readonly int int_0;

		internal readonly Class514 class514_0;

		internal readonly ParagraphFormat paragraphFormat_0;

		private ParagraphFormatEffectiveData paragraphFormatEffectiveData_0;

		internal readonly BaseSlide baseSlide_0;

		internal readonly FloatColor floatColor_0;

		internal ParagraphFormatEffectiveData Cache
		{
			get
			{
				if (paragraphFormatEffectiveData_0 == null)
				{
					paragraphFormatEffectiveData_0 = new ParagraphFormatEffectiveData(paragraphFormat_0, baseSlide_0, floatColor_0);
				}
				return paragraphFormatEffectiveData_0;
			}
		}

		public Class515(ParagraphFormat cache, Class514 version, BaseSlide slide, FloatColor styleColor)
		{
			paragraphFormat_0 = cache;
			int_0 = version.int_0;
			class514_0 = version;
			baseSlide_0 = slide;
			floatColor_0 = styleColor;
		}
	}

	private readonly PortionCollection portionCollection_0;

	private Class515 class515_0;

	private readonly Class490 class490_0 = new Class490();

	private ParagraphFormat paragraphFormat_0;

	internal ParagraphCollection paragraphCollection_0;

	public IPortionCollection Portions => portionCollection_0;

	public IParagraphFormat ParagraphFormat => paragraphFormat_0;

	internal ParagraphFormat ParagraphFormatInternal => paragraphFormat_0;

	public string Text
	{
		get
		{
			return Class1179.smethod_3(TextInternal);
		}
		set
		{
			TextInternal = value;
		}
	}

	internal string TextInternal
	{
		get
		{
			string text = "";
			for (int i = 0; i < portionCollection_0.Count; i++)
			{
				text += ((Portion)portionCollection_0[i]).TextInternal;
			}
			return text;
		}
		set
		{
			if (value.IndexOfAny(ParagraphCollection.char_0) != -1)
			{
				throw new PptxException("Can't assign string which contains paragraph break character");
			}
			Portions.Clear();
			Portions.Add(new Portion(value));
		}
	}

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (paragraphCollection_0 == null)
			{
				return null;
			}
			return ((ISlideComponent)paragraphCollection_0).Slide;
		}
	}

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (paragraphCollection_0 == null)
			{
				return null;
			}
			return ((IPresentationComponent)paragraphCollection_0).Presentation;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	ISlideComponent IParagraph.AsISlideComponent => this;

	public Paragraph()
	{
		paragraphFormat_0 = new ParagraphFormat(this);
		portionCollection_0 = new PortionCollection(this);
	}

	public Paragraph(Paragraph para)
		: this()
	{
		method_0(para);
	}

	public void JoinPortionsWithSameFormatting()
	{
		int num = 0;
		while (num < Portions.Count - 1)
		{
			IPortion portion = Portions[num];
			IPortion portion2 = Portions[num + 1];
			bool smartTagClean = portion2.PortionFormat.SmartTagClean;
			portion2.PortionFormat.SmartTagClean = portion.PortionFormat.SmartTagClean;
			try
			{
				if (portion.PortionFormat.Equals(portion2.PortionFormat))
				{
					portion.Text += Portions[num + 1].Text;
					Portions.RemoveAt(num + 1);
					portion2 = null;
				}
				else
				{
					num++;
				}
			}
			finally
			{
				if (portion2 != null)
				{
					portion2.PortionFormat.SmartTagClean = smartTagClean;
				}
			}
		}
	}

	public IParagraphFormatEffectiveData CreateParagraphFormatEffective()
	{
		Class515 @class = class515_0;
		if (@class == null || @class.class514_0.int_0 != @class.int_0)
		{
			@class = (class515_0 = method_12());
		}
		return @class.Cache;
	}

	internal Paragraph(ParagraphFormat paraFormat)
		: this()
	{
		paragraphFormat_0.method_0(paraFormat);
	}

	internal void method_0(Paragraph source)
	{
		paragraphFormat_0.method_0((ParagraphFormat)source.ParagraphFormat);
		for (int i = 0; i < source.Portions.Count; i++)
		{
			portionCollection_0.Add(new Portion((Portion)source.Portions[i]));
		}
	}

	internal void method_1(Paragraph source)
	{
		paragraphFormat_0.method_0(source.paragraphFormat_0);
		class490_0.method_0(this);
	}

	internal ParagraphFormat method_2(out BaseSlide slide, out FloatColor styleColor)
	{
		Class515 @class = class515_0;
		if (@class == null || @class.class514_0.int_0 != @class.int_0)
		{
			@class = (class515_0 = method_12());
		}
		slide = @class.baseSlide_0;
		styleColor = @class.floatColor_0;
		return @class.paragraphFormat_0;
	}

	internal void method_3()
	{
		class515_0 = null;
		class490_0.method_0(this);
	}

	internal void method_4(IPortionFormat props)
	{
		if (ParagraphFormat.DefaultPortionFormat != null && object.ReferenceEquals(ParagraphFormat.DefaultPortionFormat, props))
		{
			class515_0 = null;
		}
		class490_0.method_0(this);
	}

	internal Paragraph method_5(IParagraphFormat props)
	{
		Paragraph paragraph = new Paragraph((ParagraphFormat)props);
		paragraphFormat_0.method_4(paragraph.paragraphFormat_0);
		if (portionCollection_0.Count > 0)
		{
			for (int i = 0; i < portionCollection_0.Count; i++)
			{
				paragraph.portionCollection_0.Add(((Portion)portionCollection_0[i]).method_2(paragraph.paragraphFormat_0.portionFormat_0));
			}
		}
		else
		{
			paragraph.portionCollection_0.Add(new Portion(paragraph.paragraphFormat_0.portionFormat_0));
		}
		return paragraph;
	}

	internal Paragraph[] method_6(IParagraphFormat props, Paragraph prevParagraph, IPresentation pres, bool isFieldVisible, int slideNumber)
	{
		List<Paragraph> list = new List<Paragraph>();
		if (portionCollection_0.Count > 0)
		{
			Paragraph paragraph = new Paragraph((ParagraphFormat)props);
			list.Add(paragraph);
			paragraphFormat_0.method_4(paragraph.paragraphFormat_0);
			for (int i = 0; i < portionCollection_0.Count; i++)
			{
				Portion portion = (Portion)portionCollection_0[i];
				string[] array = portion.TextInternal.Split(Class532.char_0);
				if (array.Length > 1)
				{
					string textInternal;
					Portion portion2;
					for (int j = 0; j < array.Length - 1; j++)
					{
						textInternal = array[j];
						portion2 = portion.method_3(paragraph.paragraphFormat_0.portionFormat_0, pres, isFieldVisible, slideNumber);
						portion2.TextInternal = textInternal;
						paragraph.portionCollection_0.Add(portion2);
						paragraph.paragraphFormat_0.PPTXUnsupportedProps.SoftParagraph = true;
						paragraph = new Paragraph((ParagraphFormat)props);
						list.Add(paragraph);
						paragraphFormat_0.method_4(paragraph.paragraphFormat_0);
					}
					textInternal = array[array.Length - 1];
					portion2 = portion.method_3(paragraph.paragraphFormat_0.portionFormat_0, pres, isFieldVisible, slideNumber);
					portion2.TextInternal = textInternal;
					paragraph.portionCollection_0.Add(portion2);
				}
				else
				{
					Portion portion2 = portion.method_3(paragraph.paragraphFormat_0.portionFormat_0, pres, isFieldVisible, slideNumber);
					paragraph.portionCollection_0.Add(portion2);
				}
			}
		}
		else
		{
			Paragraph paragraph2 = new Paragraph((ParagraphFormat)props);
			list.Add(paragraph2);
			paragraphFormat_0.method_4(paragraph2.paragraphFormat_0);
			paragraph2.portionCollection_0.Add(new Portion(paragraph2.paragraphFormat_0.portionFormat_0));
		}
		return list.ToArray();
	}

	internal void method_7(Class456 p, List<Class369> textStyles, int level)
	{
		Portions.Clear();
		method_8(textStyles, level);
		foreach (XmlNode childNode in p.ChildNodes)
		{
			Portion portion = new Portion();
			Portions.Add(portion);
			if (childNode.Name == "text:span")
			{
				Class458 @class = (Class458)childNode;
				portion.method_5(@class.Text, textStyles, @class.StyleName);
			}
			else if (childNode.Name == "text:tab")
			{
				portion.method_5("\t", textStyles, null);
			}
			else
			{
				portion.method_5(childNode.InnerText, textStyles, null);
			}
		}
	}

	internal void method_8(List<Class369> styles, int level)
	{
		foreach (Class369 style in styles)
		{
			if (style is Class437)
			{
				Class437 @class = (Class437)style;
				if (@class != null && @class.GraphicProperties != null)
				{
					Enum93 textareaVerticalAlign = @class.GraphicProperties.TextareaVerticalAlign;
					if (textareaVerticalAlign == Enum93.const_1)
					{
						ParagraphFormat.Alignment = TextAlignment.Center;
					}
				}
				if (@class != null && @class.ParagraphProperties != null)
				{
					switch (@class.ParagraphProperties.TextAlign)
					{
					case Enum91.const_0:
						ParagraphFormat.Alignment = TextAlignment.Left;
						break;
					case Enum91.const_1:
						ParagraphFormat.Alignment = TextAlignment.Right;
						break;
					case Enum91.const_2:
						ParagraphFormat.Alignment = TextAlignment.Left;
						break;
					case Enum91.const_3:
						ParagraphFormat.Alignment = TextAlignment.Right;
						break;
					case Enum91.const_4:
						ParagraphFormat.Alignment = TextAlignment.Center;
						break;
					case Enum91.const_5:
						ParagraphFormat.Alignment = TextAlignment.Justify;
						break;
					}
					if (!double.IsNaN(@class.ParagraphProperties.MarginLeft))
					{
						ParagraphFormat.MarginLeft = (float)@class.ParagraphProperties.MarginLeft;
					}
					if (!double.IsNaN(@class.ParagraphProperties.MarginRight))
					{
						ParagraphFormat.MarginRight = (float)@class.ParagraphProperties.MarginRight;
					}
					if (!double.IsNaN(@class.ParagraphProperties.MarginTop))
					{
						ParagraphFormat.SpaceBefore = (float)@class.ParagraphProperties.MarginTop * -1f;
					}
					if (!double.IsNaN(@class.ParagraphProperties.MarginBottom))
					{
						ParagraphFormat.SpaceAfter = (float)@class.ParagraphProperties.MarginBottom * -1f;
					}
					if (!double.IsNaN(@class.ParagraphProperties.TextIndent))
					{
						ParagraphFormat.Indent = (float)@class.ParagraphProperties.TextIndent;
					}
					if (!double.IsNaN(@class.ParagraphProperties.LineHeight))
					{
						ParagraphFormat.SpaceWithin = (float)@class.ParagraphProperties.LineHeight;
					}
				}
			}
			if (!(style is Class406))
			{
				continue;
			}
			Class406 class2 = (Class406)style;
			Class457 class3 = null;
			Class403 class4 = null;
			foreach (Class369 listLevel in class2.ListLevels)
			{
				if (listLevel is Class404 && (listLevel as Class404).Level == level)
				{
					Class404 class5 = (Class404)listLevel;
					ParagraphFormat.Bullet.Char = class5.BulletCharacter;
					ParagraphFormat.Bullet.Type = BulletType.Symbol;
					class3 = class5.TextProperties;
					class4 = class5.ListLevelProperties;
				}
				else if (listLevel.LocalName == "list-level-style-number" && (listLevel as Class405).Level == level)
				{
					Class405 class6 = (Class405)listLevel;
					BulletFormat bulletFormat = (BulletFormat)ParagraphFormat.Bullet;
					bulletFormat.Type = BulletType.Numbered;
					class3 = class6.TextProperties;
					class4 = class6.ListLevelProperties;
					if (class6.NumPrefix == "(" && class6.NumSuffix == ")" && class6.NumFormat == "a")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletAlphaLCParenBoth;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == ")" && class6.NumFormat == "a")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletAlphaLCParenRight;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == "." && class6.NumFormat == "a")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletAlphaLCPeriod;
					}
					else if (class6.NumPrefix == "(" && class6.NumSuffix == ")" && class6.NumFormat == "A")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletAlphaUCParenBoth;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == ")" && class6.NumFormat == "A")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletAlphaUCParenRight;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == "." && class6.NumFormat == "A")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletAlphaUCPeriod;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == "." && class6.NumFormat == "1")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletArabicDBPeriod;
					}
					else if (class6.NumPrefix == "(" && class6.NumSuffix == ")" && class6.NumFormat == "1")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletArabicParenBoth;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == ")" && class6.NumFormat == "1")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletArabicParenRight;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == "" && class6.NumFormat == "1")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletArabicDBPlain;
					}
					else if (class6.NumPrefix == "(" && class6.NumSuffix == ")" && class6.NumFormat == "i")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletRomanLCParenBoth;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == ")" && class6.NumFormat == "i")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletRomanLCParenRight;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == "." && class6.NumFormat == "i")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletRomanLCPeriod;
					}
					else if (class6.NumPrefix == "(" && class6.NumSuffix == ")" && class6.NumFormat == "I")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCParenBoth;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == ")" && class6.NumFormat == "I")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCParenRight;
					}
					else if (class6.NumPrefix == "" && class6.NumSuffix == "." && class6.NumFormat == "I")
					{
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
					}
					else
					{
						if (class6.NumPrefix == "")
						{
							bulletFormat.Type = BulletType.None;
							break;
						}
						bulletFormat.NumberedBulletStyle = NumberedBulletStyle.BulletArabicDBPeriod;
					}
				}
				if (ParagraphFormat.Bullet.Type == BulletType.None || ParagraphFormat.Bullet.Type == BulletType.NotDefined)
				{
					continue;
				}
				ParagraphFormat.Depth = (short)(level - 1);
				if (class4 != null)
				{
					if (!double.IsNaN(class4.SpaceBefore))
					{
						ParagraphFormat.SpaceBefore = (float)class4.SpaceBefore * -1f;
					}
					if (!double.IsNaN(class4.MinLabelWidth))
					{
						ParagraphFormat.Indent = (float)class4.MinLabelWidth * -1f;
					}
				}
				if (class3 != null)
				{
					if (!double.IsNaN(class3.FontSize))
					{
						ParagraphFormat.Bullet.Height = (float)class3.FontSize;
					}
					if (class3.FontFamily != "")
					{
						ParagraphFormat.Bullet.Font = new FontData(class3.FontFamily.Replace("'", ""));
						paragraphFormat_0.bulletFormat_0.nullableBool_0 = NullableBool.True;
					}
					if (class3.TextColor != Color.Empty)
					{
						ParagraphFormat.Bullet.Color.Color = class3.TextColor;
						((BulletFormat)ParagraphFormat.Bullet).nullableBool_1 = NullableBool.True;
					}
				}
				break;
			}
		}
	}

	internal void method_9(Class476 odpPackage, Class438 autoStyles, Class369 elem)
	{
		string namespaceURI = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";
		ParagraphFormatEffectiveData paragraphFormatEffectiveData = (ParagraphFormatEffectiveData)CreateParagraphFormatEffective();
		Class456 class2;
		if (paragraphFormatEffectiveData.BulletType != 0 && paragraphFormatEffectiveData.BulletType != BulletType.NotDefined)
		{
			int num = ParagraphFormat.Depth + 1;
			Class406 listStyle = autoStyles.method_37(odpPackage, this, num);
			Class369 @class = method_10(num, elem, listStyle);
			class2 = (Class456)@class.method_35("p", namespaceURI);
		}
		else
		{
			class2 = (Class456)elem.method_35("p", namespaceURI);
		}
		Class437 class3 = autoStyles.method_36("P" + odpPackage.int_0++);
		class3.Family = Enum84.const_0;
		class2.StyleName = class3;
		class3.method_38();
		switch (paragraphFormatEffectiveData.Alignment)
		{
		default:
			class3.ParagraphProperties.TextAlign = Enum91.const_6;
			break;
		case TextAlignment.Left:
			class3.ParagraphProperties.TextAlign = Enum91.const_2;
			break;
		case TextAlignment.Center:
			class3.ParagraphProperties.TextAlign = Enum91.const_4;
			break;
		case TextAlignment.Right:
			class3.ParagraphProperties.TextAlign = Enum91.const_1;
			break;
		case TextAlignment.Justify:
			class3.ParagraphProperties.TextAlign = Enum91.const_5;
			break;
		}
		if (!double.IsNaN(paragraphFormatEffectiveData.MarginLeft))
		{
			class3.ParagraphProperties.MarginLeft = paragraphFormatEffectiveData.MarginLeft;
		}
		if (!double.IsNaN(paragraphFormatEffectiveData.MarginRight))
		{
			class3.ParagraphProperties.MarginRight = paragraphFormatEffectiveData.MarginRight;
		}
		if (!double.IsNaN(paragraphFormatEffectiveData.SpaceBefore))
		{
			class3.ParagraphProperties.MarginTop = paragraphFormatEffectiveData.SpaceBefore * -1f;
		}
		if (!double.IsNaN(paragraphFormatEffectiveData.SpaceAfter))
		{
			class3.ParagraphProperties.MarginBottom = paragraphFormatEffectiveData.SpaceAfter * -1f;
		}
		if (!double.IsNaN(paragraphFormatEffectiveData.Indent))
		{
			class3.ParagraphProperties.TextIndent = paragraphFormatEffectiveData.Indent;
		}
		if (!double.IsNaN(paragraphFormatEffectiveData.SpaceWithin))
		{
			class3.ParagraphProperties.LineHeight = paragraphFormatEffectiveData.SpaceWithin;
		}
		foreach (Portion portion in Portions)
		{
			portion.method_7(odpPackage, autoStyles, class2);
		}
	}

	internal Class369 method_10(int level, Class369 parent, Class406 listStyle)
	{
		string namespaceURI = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";
		Class455 @class = (Class455)parent.method_35("list", namespaceURI);
		@class.ListStyleName = listStyle;
		Class369 class2 = @class.method_35("list-item", namespaceURI);
		if (level > 1)
		{
			return method_10(level - 1, class2, listStyle);
		}
		return class2;
	}

	internal int method_11()
	{
		return paragraphCollection_0?.method_0(this) ?? (-1);
	}

	void IObservable.Subscribe(IObserver observer)
	{
		class490_0.Subscribe(observer);
	}

	void IObservable.Unsubscribe(IObserver observer)
	{
		class490_0.Unsubscribe(observer);
	}

	private Class515 method_12()
	{
		TextFrame parent = paragraphCollection_0.Parent;
		if (parent != null)
		{
			BaseSlide slide = (BaseSlide)parent.Slide;
			ParagraphFormat cache = paragraphFormat_0.method_3(parent.TextStyleCache[(ParagraphFormat.Depth > 0) ? ParagraphFormat.Depth : 0]);
			return new Class515(cache, parent.textFrameFormat_0.class514_0, slide, parent.floatColor_0);
		}
		return new Class515(paragraphFormat_0, Class514.class514_0, null, FloatColor.floatColor_0);
	}
}
