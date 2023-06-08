using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using ns28;
using ns4;

namespace Aspose.Slides;

[Guid("657E9B28-2FD4-4FC5-BF8B-31F8FFF8A08C")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public sealed class Portion : IPresentationComponent, ISlideComponent, IPortion
{
	private string string_0 = "";

	private Field field_0;

	private PortionFormat portionFormat_0;

	internal Paragraph paragraph_0;

	private PortionFormatEffectiveData portionFormatEffectiveData_0;

	private WeakReference weakReference_0;

	public IPortionFormat PortionFormat => portionFormat_0;

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

	internal bool IsField => field_0 != null;

	public IField Field => field_0;

	internal string TextInternal
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value.IndexOfAny(ParagraphCollection.char_0) != -1)
			{
				throw new PptxException("Can't assign string which contains paragraph break character");
			}
			string text = string_0;
			string_0 = value;
			if (string_0 != text)
			{
				method_4();
			}
		}
	}

	ISlideComponent IPortion.AsISlideComponent => this;

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (paragraph_0 == null)
			{
				return null;
			}
			return ((ISlideComponent)paragraph_0).Slide;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (paragraph_0 == null)
			{
				return null;
			}
			return ((IPresentationComponent)paragraph_0).Presentation;
		}
	}

	public Portion()
	{
		portionFormat_0 = new PortionFormat(this);
	}

	public Portion(string str)
		: this()
	{
		string_0 = str;
	}

	public Portion(Portion portion)
	{
		portionFormat_0 = new PortionFormat(portion.portionFormat_0);
		string_0 = portion.string_0;
		if (portion.IsField)
		{
			field_0 = new Field(portion.field_0, this);
		}
	}

	public IPortionFormatEffectiveData CreatePortionFormatEffective()
	{
		if (paragraph_0 != null)
		{
			BaseSlide slide;
			FloatColor styleColor;
			IParagraphFormat paragraphFormat = paragraph_0.method_2(out slide, out styleColor);
			if (portionFormatEffectiveData_0 == null || weakReference_0 == null || weakReference_0.Target != paragraphFormat)
			{
				portionFormatEffectiveData_0 = new PortionFormatEffectiveData((PortionFormat)paragraphFormat.DefaultPortionFormat, slide, styleColor);
				portionFormatEffectiveData_0.method_4(portionFormat_0, slide, styleColor);
				weakReference_0 = new WeakReference(paragraphFormat);
			}
		}
		else if (portionFormatEffectiveData_0 == null)
		{
			portionFormatEffectiveData_0 = new PortionFormatEffectiveData(portionFormat_0, null, FloatColor.floatColor_0);
		}
		return portionFormatEffectiveData_0;
	}

	public void AddField(IFieldType fieldType)
	{
		field_0 = new Field((FieldType)fieldType, this);
	}

	public void AddField(string internalString)
	{
		field_0 = new Field(new FieldType(internalString), this);
	}

	public void RemoveField()
	{
		field_0 = null;
	}

	internal void method_0(Portion source)
	{
		portionFormat_0.vmethod_1(source.portionFormat_0);
		if (source.IsField)
		{
			field_0 = new Field(source.field_0, this);
		}
	}

	internal Portion(PortionFormat portionProps)
		: this()
	{
		string_0 = string.Empty;
		portionFormat_0.vmethod_1(portionProps);
	}

	internal string method_1(Presentation pres, bool isFieldVisible, int slideNumber)
	{
		if (IsField)
		{
			IField field = Field;
			if (pres != null)
			{
				if (field.Type.InternalString == "slidenum")
				{
					if (pres.UpdateSlideNumberFields)
					{
						if (isFieldVisible)
						{
							string_0 = (pres.PPTXUnsupportedProps.FirstSlideNumber + slideNumber - 1).ToString();
						}
						else
						{
							string_0 = string.Empty;
						}
					}
					else
					{
						string_0 = "‹#›";
					}
				}
				else if (field.Type.InternalString.StartsWith("datetime") && pres.UpdateDateTimeFields)
				{
					if (isFieldVisible)
					{
						string_0 = HeaderFooterManager.smethod_6(field.Type.InternalString, (PortionFormat != null) ? PortionFormat.LanguageId : null);
					}
					else
					{
						string_0 = string.Empty;
					}
				}
			}
		}
		return string_0;
	}

	internal Portion method_2(PortionFormat props)
	{
		Portion portion = new Portion(props);
		portionFormat_0.vmethod_2(portion.portionFormat_0);
		portion.string_0 = string_0;
		if (field_0 != null)
		{
			portion.field_0 = new Field(field_0, this);
		}
		return portion;
	}

	internal Portion method_3(PortionFormat props, IPresentation pres, bool isFieldVisible, int slideNumber)
	{
		Portion portion = new Portion(props);
		portionFormat_0.vmethod_2(portion.portionFormat_0);
		portion.string_0 = method_1((Presentation)pres, isFieldVisible, slideNumber);
		return portion;
	}

	internal void method_4()
	{
		portionFormatEffectiveData_0 = null;
		if (paragraph_0 != null)
		{
			paragraph_0.method_3();
		}
	}

	internal void method_5(string text, List<Class369> textStyles, Class437 spanStyle)
	{
		portionFormat_0.FillFormat.SolidFillColor.Color = Color.Black;
		portionFormat_0.FillFormat.FillType = FillType.Solid;
		foreach (Class369 textStyle in textStyles)
		{
			if (textStyle.LocalName == "style")
			{
				method_6((Class437)textStyle);
			}
		}
		if (spanStyle != null)
		{
			method_6(spanStyle);
		}
		if (text != null)
		{
			TextInternal = text;
		}
	}

	internal void method_6(Class437 style)
	{
		if (style.TextProperties == null)
		{
			return;
		}
		if (!double.IsNaN(style.TextProperties.FontSize))
		{
			portionFormat_0.FontHeight = (float)style.TextProperties.FontSize;
		}
		if (style.TextProperties.TextColor != Color.Empty)
		{
			portionFormat_0.FillFormat.FillType = FillType.Solid;
			portionFormat_0.FillFormat.SolidFillColor.Color = style.TextProperties.TextColor;
		}
		if (style.TextProperties.FontFamily != "")
		{
			portionFormat_0.LatinFont = new FontData(style.TextProperties.FontFamily.Replace("'", ""));
		}
		if (style.TextProperties.FontFamilyAsian != "")
		{
			portionFormat_0.EastAsianFont = new FontData(style.TextProperties.FontFamilyAsian.Replace("'", ""));
		}
		if (style.TextProperties.FontFamilyComplex != "")
		{
			portionFormat_0.ComplexScriptFont = new FontData(style.TextProperties.FontFamilyComplex.Replace("'", ""));
		}
		if (style.TextProperties.FontWeight.IndexOf("bold") > -1)
		{
			portionFormat_0.FontBold = NullableBool.True;
		}
		if (style.TextProperties.FontStyle == Enum44.const_1)
		{
			portionFormat_0.FontItalic = NullableBool.True;
		}
		if (style.TextProperties.TextUnderlineStyleOd != 0)
		{
			portionFormat_0.FontUnderline = TextUnderlineType.Single;
		}
		if (!(style.TextProperties.TextPosition != ""))
		{
			return;
		}
		string text = style.TextProperties.TextPosition;
		int num = text.IndexOf('%');
		if (num > 0)
		{
			text = text.Substring(0, num);
		}
		if (text.StartsWith("super"))
		{
			text = text.Substring(6).Trim();
		}
		else if (text.StartsWith("sub"))
		{
			text = text.Substring(3).Trim();
			if (text[0] != '-')
			{
				text = '-' + text;
			}
		}
		PortionFormat.Escapement = float.Parse(text, CultureInfo.InvariantCulture.NumberFormat);
	}

	internal void method_7(Class476 odpPackage, Class438 autoStyles, Class456 paragraph)
	{
		IPortionFormatEffectiveData portionFormatEffectiveData = CreatePortionFormatEffective();
		string namespaceURI = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";
		Class458 @class = (Class458)paragraph.method_35("span", namespaceURI);
		Class437 class2 = autoStyles.method_36("T" + odpPackage.int_0++);
		class2.Family = Enum84.const_1;
		@class.StyleName = class2;
		class2.method_39();
		@class.InnerText = TextInternal;
		class2.TextProperties.FontSize = portionFormatEffectiveData.FontHeight;
		class2.TextProperties.TextColor = portionFormatEffectiveData.FillFormat.SolidFillColor;
		if (portionFormatEffectiveData.LatinFont != null)
		{
			class2.TextProperties.FontFamily = "'" + portionFormatEffectiveData.LatinFont.FontName + "'";
		}
		if (portionFormatEffectiveData.EastAsianFont != null)
		{
			class2.TextProperties.FontFamilyAsian = "'" + portionFormatEffectiveData.EastAsianFont.GetFontName(paragraph_0.paragraphCollection_0.Slide.CreateThemeEffective()) + "'";
		}
		if (portionFormatEffectiveData.ComplexScriptFont != null)
		{
			class2.TextProperties.FontFamilyComplex = "'" + portionFormatEffectiveData.ComplexScriptFont.FontName + "'";
		}
		if (portionFormatEffectiveData.FontBold)
		{
			class2.TextProperties.FontWeight = "bold";
		}
		if (portionFormatEffectiveData.FontItalic)
		{
			class2.TextProperties.FontStyle = Enum44.const_1;
		}
		if (portionFormatEffectiveData.FontUnderline != 0 && portionFormatEffectiveData.FontUnderline != TextUnderlineType.NotDefined)
		{
			class2.TextProperties.TextUnderlineStyleOd = Enum59.const_1;
		}
		if (!float.IsNaN(portionFormatEffectiveData.Escapement) && portionFormatEffectiveData.Escapement != 0f)
		{
			class2.TextProperties.TextPosition = $"{portionFormatEffectiveData.Escapement}% 66.6667%";
		}
		class2.TextProperties.TextOutline = false;
		class2.TextProperties.TextLineThroughStyleOd = Enum59.const_0;
		class2.TextProperties.FontRelief = Enum43.const_0;
	}
}
