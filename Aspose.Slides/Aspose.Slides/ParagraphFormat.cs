using System;
using System.Threading;
using Aspose.Slides.Charts;
using ns22;
using ns24;
using ns33;
using ns4;

namespace Aspose.Slides;

public class ParagraphFormat : IChartParagraphFormat, IParagraphFormat
{
	internal delegate void Delegate9(ParagraphFormat whichParagraph);

	internal const float float_0 = 72f;

	internal BulletFormat bulletFormat_0;

	internal TextAlignment textAlignment_0;

	internal float float_1;

	internal float float_2;

	internal float float_3;

	internal NullableBool nullableBool_0;

	internal NullableBool nullableBool_1;

	internal NullableBool nullableBool_2;

	internal NullableBool nullableBool_3;

	internal double double_0;

	internal double double_1;

	internal double double_2;

	internal double double_3;

	internal TabCollection tabCollection_0 = new TabCollection();

	internal FontAlignment fontAlignment_0;

	internal IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	internal PortionFormat portionFormat_0;

	internal bool bool_0;

	private Delegate9 delegate9_0;

	private Class345 class345_0 = new Class345();

	private Class270 class270_0 = new Class270();

	short IParagraphFormat.Depth
	{
		get
		{
			if (PPTXUnsupportedProps.Depth >= 0)
			{
				return PPTXUnsupportedProps.Depth;
			}
			return 0;
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			else if (value > 9)
			{
				value = 9;
			}
			if (PPTXUnsupportedProps.Depth != value)
			{
				PPTXUnsupportedProps.Depth = value;
				method_7();
				method_9();
			}
		}
	}

	public TextAlignment Alignment
	{
		get
		{
			return textAlignment_0;
		}
		set
		{
			if (textAlignment_0 != value)
			{
				textAlignment_0 = value;
				method_7();
				method_9();
			}
		}
	}

	public float SpaceWithin
	{
		get
		{
			return float_1;
		}
		set
		{
			if (float_1 != value)
			{
				float_1 = value;
				method_7();
				method_9();
			}
		}
	}

	public float SpaceBefore
	{
		get
		{
			return float_2;
		}
		set
		{
			if (float_2 != value)
			{
				float_2 = value;
				method_7();
				method_9();
			}
		}
	}

	public float SpaceAfter
	{
		get
		{
			return float_3;
		}
		set
		{
			if (float_3 != value)
			{
				float_3 = value;
				method_7();
				method_9();
			}
		}
	}

	public NullableBool EastAsianLineBreak
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			if (nullableBool_0 != value)
			{
				nullableBool_0 = value;
				method_7();
				method_9();
			}
		}
	}

	public NullableBool RightToLeft
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			if (nullableBool_1 != value)
			{
				nullableBool_1 = value;
				method_7();
				method_9();
			}
		}
	}

	public NullableBool LatinLineBreak
	{
		get
		{
			return nullableBool_2;
		}
		set
		{
			if (nullableBool_2 != value)
			{
				nullableBool_2 = value;
				method_7();
				method_9();
			}
		}
	}

	public NullableBool HangingPunctuation
	{
		get
		{
			return nullableBool_3;
		}
		set
		{
			if (nullableBool_3 != value)
			{
				nullableBool_3 = value;
				method_7();
				method_9();
			}
		}
	}

	public float MarginLeft
	{
		get
		{
			return (float)double_0;
		}
		set
		{
			if (double_0 != (double)value)
			{
				double_0 = value;
				method_7();
				method_9();
			}
		}
	}

	public float MarginRight
	{
		get
		{
			return (float)double_1;
		}
		set
		{
			if (double_1 != (double)value)
			{
				double_1 = value;
				method_7();
				method_9();
			}
		}
	}

	public float Indent
	{
		get
		{
			return (float)double_2;
		}
		set
		{
			if (double_2 != (double)value)
			{
				double_2 = value;
				method_7();
				method_9();
			}
		}
	}

	public float DefaultTabSize
	{
		get
		{
			return (float)double_3;
		}
		set
		{
			if (double_3 != (double)value)
			{
				double_3 = value;
				method_7();
				method_9();
			}
		}
	}

	public ITabCollection Tabs => tabCollection_0;

	public FontAlignment FontAlignment
	{
		get
		{
			return fontAlignment_0;
		}
		set
		{
			if (fontAlignment_0 != value)
			{
				fontAlignment_0 = value;
				method_7();
				method_9();
			}
		}
	}

	IPortionFormat IParagraphFormat.DefaultPortionFormat => portionFormat_0;

	internal Class345 PPTXUnsupportedProps => class345_0;

	internal Class270 PPTUnsupportedProps => class270_0;

	internal IBaseSlide Slide
	{
		get
		{
			if (ipresentationComponent_0 is ISlideComponent)
			{
				return ((ISlideComponent)ipresentationComponent_0).Slide;
			}
			return null;
		}
	}

	IBulletFormat IParagraphFormat.Bullet => bulletFormat_0;

	internal uint Version => uint_0 + tabCollection_0.Version + portionFormat_0.Version + bulletFormat_0.Version + class345_0.Version;

	internal event Delegate9 m_changedEvent_OldMode
	{
		add
		{
			Delegate9 @delegate = delegate9_0;
			Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				Delegate9 value2 = (Delegate9)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate9_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
		remove
		{
			Delegate9 @delegate = delegate9_0;
			Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				Delegate9 value2 = (Delegate9)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate9_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
	}

	internal ParagraphFormat(IParagraphFormat paraprop, IPresentationComponent parent)
	{
		if (parent != null && !(parent is IFormattedTextContainer) && !(parent is Portion) && !(parent is Field) && !(parent is Paragraph) && !(parent is MasterSlide) && !(parent is Presentation) && !(parent is TextFrame))
		{
			throw new ArgumentException();
		}
		ipresentationComponent_0 = parent;
		portionFormat_0 = new PortionFormat(this);
		bulletFormat_0 = new BulletFormat(this);
		method_0((ParagraphFormat)paraprop);
	}

	internal ParagraphFormat(IPresentationComponent parent)
	{
		if (parent != null && !(parent is IFormattedTextContainer) && !(parent is Portion) && !(parent is Field) && !(parent is Paragraph) && !(parent is MasterSlide) && !(parent is Presentation) && !(parent is TextFrame))
		{
			throw new ArgumentException();
		}
		ipresentationComponent_0 = parent;
		PPTXUnsupportedProps.Depth = -1;
		bulletFormat_0 = new BulletFormat(this);
		textAlignment_0 = TextAlignment.NotDefined;
		float_1 = float.NaN;
		float_2 = float.NaN;
		float_3 = float.NaN;
		nullableBool_0 = NullableBool.NotDefined;
		nullableBool_1 = NullableBool.NotDefined;
		nullableBool_2 = NullableBool.NotDefined;
		nullableBool_3 = NullableBool.NotDefined;
		double_0 = double.NaN;
		double_1 = double.NaN;
		double_2 = double.NaN;
		double_3 = double.NaN;
		fontAlignment_0 = FontAlignment.Default;
		bulletFormat_0.Picture = new Picture(ipresentationComponent_0);
		PPTXUnsupportedProps.delegate14_0 = bulletFormat_0.method_0;
		portionFormat_0 = new PortionFormat(this);
	}

	internal void method_0(ParagraphFormat source)
	{
		textAlignment_0 = source.textAlignment_0;
		bulletFormat_0.method_1(source.bulletFormat_0);
		portionFormat_0.vmethod_1(source.portionFormat_0);
		double_3 = source.double_3;
		PPTXUnsupportedProps.Depth = source.PPTXUnsupportedProps.Depth;
		nullableBool_0 = source.nullableBool_0;
		fontAlignment_0 = source.fontAlignment_0;
		nullableBool_3 = source.nullableBool_3;
		double_2 = source.double_2;
		nullableBool_2 = source.nullableBool_2;
		float_1 = source.float_1;
		float_3 = source.float_3;
		double_0 = source.double_0;
		double_1 = source.double_1;
		nullableBool_1 = source.nullableBool_1;
		tabCollection_0.method_2(source.tabCollection_0);
		float_2 = source.float_2;
		PPTXUnsupportedProps.SoftParagraph = source.PPTXUnsupportedProps.SoftParagraph;
		method_9();
	}

	internal bool method_1(ParagraphFormat para)
	{
		if (PPTXUnsupportedProps.Depth == para.PPTXUnsupportedProps.Depth && bulletFormat_0.method_2(para.bulletFormat_0) && textAlignment_0 == para.textAlignment_0 && Class1165.smethod_0(float_1, para.float_1) && Class1165.smethod_0(float_2, para.float_2) && Class1165.smethod_0(float_3, para.float_3) && nullableBool_0 == para.nullableBool_0 && nullableBool_1 == para.nullableBool_1 && nullableBool_2 == para.nullableBool_2 && nullableBool_3 == para.nullableBool_3 && Class1165.smethod_1(double_0, para.double_0) && Class1165.smethod_1(double_1, para.double_1) && Class1165.smethod_1(double_2, para.double_2) && fontAlignment_0 == para.fontAlignment_0 && Class1165.smethod_1(double_3, para.double_3) && tabCollection_0.Equals(para.tabCollection_0) && portionFormat_0.Equals(para.portionFormat_0))
		{
			return true;
		}
		return false;
	}

	internal bool method_2(IChartParagraphFormat paragraphFormat)
	{
		ParagraphFormat paragraphFormat2 = (ParagraphFormat)paragraphFormat;
		if (textAlignment_0 == paragraphFormat2.textAlignment_0 && Class1165.smethod_0(float_1, paragraphFormat2.float_1) && Class1165.smethod_0(float_2, paragraphFormat2.float_2) && Class1165.smethod_0(float_3, paragraphFormat2.float_3) && nullableBool_0 == paragraphFormat2.nullableBool_0 && nullableBool_1 == paragraphFormat2.nullableBool_1 && nullableBool_2 == paragraphFormat2.nullableBool_2 && nullableBool_3 == paragraphFormat2.nullableBool_3 && Class1165.smethod_1(double_0, paragraphFormat2.double_0) && Class1165.smethod_1(double_1, paragraphFormat2.double_1) && Class1165.smethod_1(double_2, paragraphFormat2.double_2) && fontAlignment_0 == paragraphFormat2.fontAlignment_0 && Class1165.smethod_1(double_3, paragraphFormat2.double_3) && tabCollection_0.Equals(paragraphFormat2.tabCollection_0))
		{
			return true;
		}
		return false;
	}

	internal ParagraphFormat method_3(IParagraphFormat props)
	{
		ParagraphFormat paragraphFormat = new ParagraphFormat(props, ipresentationComponent_0);
		method_4(paragraphFormat);
		return paragraphFormat;
	}

	internal void method_4(ParagraphFormat props)
	{
		bulletFormat_0.method_3(props.bulletFormat_0);
		if (textAlignment_0 != TextAlignment.NotDefined)
		{
			props.textAlignment_0 = textAlignment_0;
		}
		if (!float.IsNaN(float_1))
		{
			props.float_1 = float_1;
		}
		if (!float.IsNaN(float_2))
		{
			props.float_2 = float_2;
		}
		if (!float.IsNaN(float_3))
		{
			props.float_3 = float_3;
		}
		if (nullableBool_0 != NullableBool.NotDefined)
		{
			props.nullableBool_0 = nullableBool_0;
		}
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			props.nullableBool_1 = nullableBool_1;
		}
		if (nullableBool_2 != NullableBool.NotDefined)
		{
			props.nullableBool_2 = nullableBool_2;
		}
		if (nullableBool_3 != NullableBool.NotDefined)
		{
			props.nullableBool_3 = nullableBool_3;
		}
		if (!double.IsNaN(double_0))
		{
			props.double_0 = double_0;
		}
		if (!double.IsNaN(double_1))
		{
			props.double_1 = double_1;
		}
		if (!double.IsNaN(double_2))
		{
			props.double_2 = double_2;
		}
		if (!double.IsNaN(double_3))
		{
			props.double_3 = double_3;
		}
		if (fontAlignment_0 != FontAlignment.Default)
		{
			props.fontAlignment_0 = fontAlignment_0;
		}
		props.ipresentationComponent_0 = ipresentationComponent_0;
		if (PPTXUnsupportedProps.Depth != -1)
		{
			props.PPTXUnsupportedProps.Depth = PPTXUnsupportedProps.Depth;
		}
		for (int i = 0; i < tabCollection_0.Count; i++)
		{
			props.tabCollection_0.Add(new Tab(tabCollection_0[i].Position, tabCollection_0[i].Alignment));
		}
		if (PPTXUnsupportedProps.SoftParagraph)
		{
			props.PPTXUnsupportedProps.SoftParagraph = PPTXUnsupportedProps.SoftParagraph;
		}
		portionFormat_0.vmethod_2(props.portionFormat_0);
	}

	internal void method_5(ParagraphFormat props)
	{
		bulletFormat_0.method_4(props.bulletFormat_0);
		if (textAlignment_0 == TextAlignment.NotDefined)
		{
			textAlignment_0 = props.textAlignment_0;
		}
		if (float.IsNaN(float_1))
		{
			float_1 = props.float_1;
		}
		if (float.IsNaN(float_2))
		{
			float_2 = props.float_2;
		}
		if (float.IsNaN(float_3))
		{
			float_3 = props.float_3;
		}
		if (nullableBool_0 == NullableBool.NotDefined)
		{
			nullableBool_0 = props.nullableBool_0;
		}
		if (nullableBool_1 == NullableBool.NotDefined)
		{
			nullableBool_1 = props.nullableBool_1;
		}
		if (nullableBool_2 == NullableBool.NotDefined)
		{
			nullableBool_2 = props.nullableBool_2;
		}
		if (nullableBool_3 == NullableBool.NotDefined)
		{
			nullableBool_3 = props.nullableBool_3;
		}
		if (double.IsNaN(double_0))
		{
			double_0 = props.double_0;
		}
		if (double.IsNaN(double_1))
		{
			double_1 = props.double_1;
		}
		if (double.IsNaN(double_2))
		{
			double_2 = props.double_2;
		}
		if (double.IsNaN(double_3))
		{
			double_3 = props.double_3;
		}
		if (fontAlignment_0 == FontAlignment.Default)
		{
			fontAlignment_0 = props.fontAlignment_0;
		}
		ipresentationComponent_0 = props.ipresentationComponent_0;
		if (PPTXUnsupportedProps.Depth == -1)
		{
			PPTXUnsupportedProps.Depth = props.PPTXUnsupportedProps.Depth;
		}
		for (int i = 0; i < props.tabCollection_0.Count; i++)
		{
			tabCollection_0.Add(new Tab(props.tabCollection_0[i].Position, props.tabCollection_0[i].Alignment));
		}
		if (!PPTXUnsupportedProps.SoftParagraph)
		{
			PPTXUnsupportedProps.SoftParagraph = props.PPTXUnsupportedProps.SoftParagraph;
		}
		portionFormat_0.vmethod_3(props.portionFormat_0);
	}

	internal void method_6(ParagraphFormat overriding, ParagraphFormat overriden)
	{
		bulletFormat_0.method_5(overriding.bulletFormat_0, overriden.bulletFormat_0);
		if (textAlignment_0 == TextAlignment.NotDefined)
		{
			if (overriding.textAlignment_0 != TextAlignment.NotDefined)
			{
				textAlignment_0 = overriding.textAlignment_0;
			}
			else if (overriden.textAlignment_0 != TextAlignment.NotDefined)
			{
				textAlignment_0 = TextAlignment.Left;
			}
		}
		if (float.IsNaN(float_1))
		{
			if (!float.IsNaN(overriding.float_1))
			{
				float_1 = overriding.float_1;
			}
			else if (!float.IsNaN(overriden.float_1))
			{
				float_1 = 100f;
			}
		}
		if (float.IsNaN(float_2))
		{
			if (!float.IsNaN(overriding.float_2))
			{
				float_2 = overriding.float_2;
			}
			else if (!float.IsNaN(overriden.float_2))
			{
				float_2 = 0f;
			}
		}
		if (float.IsNaN(float_3))
		{
			if (!float.IsNaN(overriding.float_3))
			{
				float_3 = overriding.float_3;
			}
			else if (!float.IsNaN(overriden.float_3))
			{
				float_3 = 0f;
			}
		}
		if (nullableBool_0 == NullableBool.NotDefined)
		{
			if (overriding.nullableBool_0 != NullableBool.NotDefined)
			{
				nullableBool_0 = overriding.nullableBool_0;
			}
			else if (overriden.nullableBool_0 != NullableBool.NotDefined)
			{
				nullableBool_0 = NullableBool.False;
			}
		}
		if (nullableBool_1 == NullableBool.NotDefined)
		{
			if (overriding.nullableBool_1 != NullableBool.NotDefined)
			{
				nullableBool_1 = overriding.nullableBool_1;
			}
			else if (overriden.nullableBool_1 != NullableBool.NotDefined)
			{
				nullableBool_1 = NullableBool.False;
			}
		}
		if (nullableBool_2 == NullableBool.NotDefined)
		{
			if (overriding.nullableBool_2 != NullableBool.NotDefined)
			{
				nullableBool_2 = overriding.nullableBool_2;
			}
			else if (overriden.nullableBool_2 != NullableBool.NotDefined)
			{
				nullableBool_2 = NullableBool.False;
			}
		}
		if (nullableBool_3 == NullableBool.NotDefined)
		{
			if (overriding.nullableBool_3 != NullableBool.NotDefined)
			{
				nullableBool_3 = overriding.nullableBool_3;
			}
			else if (overriden.nullableBool_3 != NullableBool.NotDefined)
			{
				nullableBool_3 = NullableBool.False;
			}
		}
		if (double.IsNaN(double_0))
		{
			if (!double.IsNaN(overriding.double_0))
			{
				double_0 = overriding.double_0;
			}
			else if (!double.IsNaN(overriden.double_0))
			{
				double_0 = 0.0;
			}
		}
		if (double.IsNaN(double_1))
		{
			if (!double.IsNaN(overriding.double_1))
			{
				double_1 = overriding.double_1;
			}
			else if (!double.IsNaN(overriden.double_1))
			{
				double_1 = 0.0;
			}
		}
		if (double.IsNaN(double_2))
		{
			if (!double.IsNaN(overriding.double_2))
			{
				double_2 = overriding.double_2;
			}
			else if (!double.IsNaN(overriden.double_2))
			{
				double_2 = 0.0;
			}
		}
		if (double.IsNaN(double_3))
		{
			if (!double.IsNaN(overriding.double_3))
			{
				double_3 = overriding.double_3;
			}
			else if (!double.IsNaN(overriden.double_3))
			{
				double_3 = 72.0;
			}
		}
		if (fontAlignment_0 == FontAlignment.Default)
		{
			if (overriding.fontAlignment_0 != FontAlignment.Default)
			{
				fontAlignment_0 = overriding.fontAlignment_0;
			}
			else if (overriden.fontAlignment_0 != FontAlignment.Default)
			{
				fontAlignment_0 = FontAlignment.Automatic;
			}
		}
		if (PPTXUnsupportedProps.Depth == -1)
		{
			if (overriding.PPTXUnsupportedProps.Depth != -1)
			{
				PPTXUnsupportedProps.Depth = overriding.PPTXUnsupportedProps.Depth;
			}
			else if (overriden.PPTXUnsupportedProps.Depth != -1)
			{
				PPTXUnsupportedProps.Depth = -1;
			}
		}
		if (tabCollection_0.Count == 0 && overriding.tabCollection_0.Count != 0)
		{
			for (int i = 0; i < overriding.tabCollection_0.Count; i++)
			{
				tabCollection_0.Add(new Tab(overriding.tabCollection_0[i].Position, overriding.tabCollection_0[i].Alignment));
			}
		}
		portionFormat_0.method_0(overriding.portionFormat_0, overriden.portionFormat_0);
	}

	internal void method_7()
	{
		if (Class21.bool_0)
		{
			method_8();
		}
	}

	internal void method_8()
	{
		if (delegate9_0 != null)
		{
			delegate9_0(this);
		}
	}

	internal virtual void vmethod_0(BasePortionFormat props)
	{
		if (Class21.bool_0)
		{
			method_8();
		}
	}

	private void method_9()
	{
		uint_0++;
	}
}
