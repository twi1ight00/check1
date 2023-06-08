using System;
using System.Collections.Generic;
using System.Drawing;
using ns33;

namespace Aspose.Slides;

public class ParagraphFormatEffectiveData : IPresentationComponent, ISlideComponent, IParagraphFormatEffectiveData, IEffectiveData
{
	internal BulletFormatEffectiveData bulletFormatEffectiveData_0;

	protected TextAlignment m_alignment;

	internal float float_0;

	internal float float_1;

	internal float float_2;

	internal NullableBool nullableBool_0;

	internal NullableBool nullableBool_1;

	internal NullableBool nullableBool_2;

	internal NullableBool nullableBool_3;

	internal double double_0;

	internal double double_1;

	internal double double_2;

	internal double double_3;

	internal SortedList<double, TabEffectiveData> sortedList_0 = new SortedList<double, TabEffectiveData>();

	internal TabEffectiveData[] tabEffectiveData_0;

	internal FontAlignment fontAlignment_0;

	internal ISlideComponent islideComponent_0;

	internal PortionFormatEffectiveData portionFormatEffectiveData_0 = new PortionFormatEffectiveData();

	internal short short_0;

	public short Depth
	{
		get
		{
			if (short_0 >= 0)
			{
				return short_0;
			}
			return 0;
		}
	}

	public IBulletFormatEffectiveData Bullet => bulletFormatEffectiveData_0;

	[Obsolete("Use Bullet.Type property instead. Property will be removed after 01.09.2013.")]
	public BulletType BulletType => bulletFormatEffectiveData_0.Type;

	[Obsolete("Use Bullet.Char property instead. Property will be removed after 01.09.2013.")]
	public char BulletChar => bulletFormatEffectiveData_0.Char;

	[Obsolete("Use Bullet.Font property instead. Property will be removed after 01.09.2013.")]
	public FontData BulletFont => (FontData)bulletFormatEffectiveData_0.Font;

	[Obsolete("Use Bullet.Height property instead. Property will be removed after 01.09.2013.")]
	public float BulletHeight => bulletFormatEffectiveData_0.Height;

	[Obsolete("Use Bullet.NumberedBulletStartWith property instead. Property will be removed after 01.09.2013.")]
	public short NumberedBulletStartWith => bulletFormatEffectiveData_0.NumberedBulletStartWith;

	[Obsolete("Use Bullet.NumberedBulletStyle property instead. Property will be removed after 01.09.2013.")]
	public NumberedBulletStyle NumberedBulletStyle => bulletFormatEffectiveData_0.NumberedBulletStyle;

	public TextAlignment Alignment => m_alignment;

	public float SpaceWithin => float_0;

	public float SpaceBefore => float_1;

	public float SpaceAfter => float_2;

	public bool EastAsianLineBreak => nullableBool_0 == NullableBool.True;

	public bool RightToLeft => nullableBool_1 == NullableBool.True;

	public bool LatinLineBreak => nullableBool_2 == NullableBool.True;

	public bool HangingPunctuation => nullableBool_3 == NullableBool.True;

	public float MarginLeft => (float)double_0;

	public float MarginRight => (float)double_1;

	public float Indent => (float)double_2;

	public float DefaultTabSize => (float)double_3;

	public ITabEffectiveData[] Tabs
	{
		get
		{
			TabEffectiveData[] array = new TabEffectiveData[sortedList_0.Count];
			for (int i = 0; i < sortedList_0.Count; i++)
			{
				array[i] = sortedList_0.Values[i];
			}
			return array;
		}
	}

	public FontAlignment FontAlignment => fontAlignment_0;

	public IPortionFormatEffectiveData DefaultPortionFormat => portionFormatEffectiveData_0;

	[Obsolete("Use Bullet.Color property instead. Property will be removed after 01.09.2013.")]
	public Color BulletColor => bulletFormatEffectiveData_0.Color;

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (islideComponent_0 == null)
			{
				return null;
			}
			return islideComponent_0.Slide;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	ISlideComponent IParagraphFormatEffectiveData.AsISlideComponent => this;

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (islideComponent_0 == null)
			{
				return null;
			}
			return islideComponent_0.Presentation;
		}
	}

	internal ParagraphFormatEffectiveData(ParagraphFormat source, BaseSlide slide, FloatColor styleColor)
	{
		method_0(source, slide, styleColor);
	}

	internal void method_0(ParagraphFormat source, BaseSlide slide, FloatColor styleColor)
	{
		short_0 = source.PPTXUnsupportedProps.Depth;
		bulletFormatEffectiveData_0 = new BulletFormatEffectiveData(this, source, slide, styleColor);
		m_alignment = source.textAlignment_0;
		float_0 = source.float_1;
		float_1 = source.float_2;
		float_2 = source.float_3;
		nullableBool_0 = source.nullableBool_0;
		nullableBool_1 = source.nullableBool_1;
		nullableBool_2 = source.nullableBool_2;
		nullableBool_3 = source.nullableBool_3;
		double_0 = source.double_0;
		double_1 = source.double_1;
		double_2 = source.double_2;
		fontAlignment_0 = source.fontAlignment_0;
		double_3 = source.double_3;
		sortedList_0.Capacity = source.tabCollection_0.Count;
		foreach (Tab item in source.tabCollection_0)
		{
			sortedList_0.Add(item.Position, new TabEffectiveData(item));
		}
		portionFormatEffectiveData_0.method_3(source.portionFormat_0, slide, styleColor);
	}

	internal void method_1(ParagraphFormat paragraphFormat, BaseSlide slide, FloatColor styleColor)
	{
		bulletFormatEffectiveData_0.method_1(paragraphFormat, slide, styleColor);
		if (paragraphFormat.textAlignment_0 != TextAlignment.NotDefined)
		{
			m_alignment = paragraphFormat.textAlignment_0;
		}
		if (!float.IsNaN(paragraphFormat.float_1))
		{
			float_0 = paragraphFormat.float_1;
		}
		if (!float.IsNaN(paragraphFormat.float_2))
		{
			float_1 = paragraphFormat.float_2;
		}
		if (!float.IsNaN(paragraphFormat.float_3))
		{
			float_2 = paragraphFormat.float_3;
		}
		if (paragraphFormat.nullableBool_0 != NullableBool.NotDefined)
		{
			nullableBool_0 = paragraphFormat.nullableBool_0;
		}
		if (paragraphFormat.nullableBool_1 != NullableBool.NotDefined)
		{
			nullableBool_1 = paragraphFormat.nullableBool_1;
		}
		if (paragraphFormat.nullableBool_2 != NullableBool.NotDefined)
		{
			nullableBool_2 = paragraphFormat.nullableBool_2;
		}
		if (paragraphFormat.nullableBool_3 != NullableBool.NotDefined)
		{
			nullableBool_3 = paragraphFormat.nullableBool_3;
		}
		if (!double.IsNaN(paragraphFormat.double_0))
		{
			double_0 = paragraphFormat.double_0;
		}
		if (!double.IsNaN(paragraphFormat.double_1))
		{
			double_1 = paragraphFormat.double_1;
		}
		if (!double.IsNaN(paragraphFormat.double_2))
		{
			double_2 = paragraphFormat.double_2;
		}
		if (!double.IsNaN(paragraphFormat.double_3))
		{
			double_3 = paragraphFormat.double_3;
		}
		if (paragraphFormat.fontAlignment_0 != FontAlignment.Default)
		{
			fontAlignment_0 = paragraphFormat.fontAlignment_0;
		}
		if (paragraphFormat.PPTXUnsupportedProps.Depth != -1)
		{
			short_0 = paragraphFormat.PPTXUnsupportedProps.Depth;
		}
		for (int i = 0; i < sortedList_0.Count; i++)
		{
			ITab tab = paragraphFormat.tabCollection_0[i];
			sortedList_0[tab.Position] = new TabEffectiveData(tab);
		}
		portionFormatEffectiveData_0.method_4(paragraphFormat.portionFormat_0, slide, styleColor);
	}

	internal bool method_2(ParagraphFormatEffectiveData para)
	{
		if (bulletFormatEffectiveData_0.method_2(para.bulletFormatEffectiveData_0) && short_0 == para.short_0 && m_alignment == para.m_alignment && Class1165.smethod_0(float_0, para.float_0) && Class1165.smethod_0(float_1, para.float_1) && Class1165.smethod_0(float_2, para.float_2) && nullableBool_0 == para.nullableBool_0 && nullableBool_1 == para.nullableBool_1 && nullableBool_2 == para.nullableBool_2 && nullableBool_3 == para.nullableBool_3 && Class1165.smethod_1(double_0, para.double_0) && Class1165.smethod_1(double_1, para.double_1) && Class1165.smethod_1(double_2, para.double_2) && fontAlignment_0 == para.fontAlignment_0 && Class1165.smethod_1(double_3, para.double_3) && sortedList_0.Equals(para.sortedList_0) && portionFormatEffectiveData_0.method_2(para.portionFormatEffectiveData_0))
		{
			return true;
		}
		return false;
	}
}
