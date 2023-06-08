using System;
using ns24;

namespace Aspose.Slides;

public sealed class Field : IPresentationComponent, ISlideComponent, IField
{
	private IFieldType ifieldType_0;

	private Portion portion_0;

	private Class337 class337_0 = new Class337();

	internal Class337 PPTXUnsupportedProps => class337_0;

	public IFieldType Type
	{
		get
		{
			return ifieldType_0;
		}
		set
		{
			ifieldType_0 = value;
		}
	}

	internal Guid Guid
	{
		get
		{
			return PPTXUnsupportedProps.Guid;
		}
		set
		{
			PPTXUnsupportedProps.Guid = value;
		}
	}

	private ParagraphFormat ParagraphFormat
	{
		get
		{
			return (ParagraphFormat)PPTXUnsupportedProps.ParagraphFormat;
		}
		set
		{
			PPTXUnsupportedProps.ParagraphFormat = value;
		}
	}

	internal Portion Parent => portion_0;

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (portion_0 == null)
			{
				return null;
			}
			return ((ISlideComponent)portion_0).Slide;
		}
	}

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (portion_0 == null)
			{
				return null;
			}
			return ((IPresentationComponent)portion_0).Presentation;
		}
	}

	ISlideComponent IField.AsISlideComponent => this;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	internal Field(Field field, Portion parent)
	{
		portion_0 = parent;
		ParagraphFormat = new ParagraphFormat(this);
		method_0(field);
	}

	internal Field(FieldType fieldType, Portion parent)
	{
		ifieldType_0 = fieldType;
		portion_0 = parent;
		Guid = Guid.NewGuid();
		ParagraphFormat = new ParagraphFormat(this);
	}

	private void method_0(Field field)
	{
		ifieldType_0 = field.ifieldType_0;
		ParagraphFormat.method_0(field.ParagraphFormat);
		Guid = Guid.NewGuid();
	}
}
