using Aspose.Slides;
using ns16;
using ns24;

namespace ns4;

internal class Class142
{
	private Class352 class352_0 = new Class352();

	private uint uint_0;

	private NullableBool nullableBool_0 = NullableBool.NotDefined;

	private NullableBool nullableBool_1 = NullableBool.NotDefined;

	private Enum274 enum274_0;

	private Fonts fonts_0;

	private ColorFormat colorFormat_0;

	private FontCollectionIndex fontCollectionIndex_0;

	private ColorFormat colorFormat_1;

	public NullableBool IsBold
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
			method_0();
		}
	}

	public NullableBool IsItalic
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
			method_0();
		}
	}

	public Enum274 FontSource
	{
		get
		{
			return enum274_0;
		}
		set
		{
			enum274_0 = value;
			method_0();
		}
	}

	public IFonts Fonts => fonts_0;

	public IColorFormat FontColor => colorFormat_0;

	public FontCollectionIndex FontIndex
	{
		get
		{
			return fontCollectionIndex_0;
		}
		set
		{
			fontCollectionIndex_0 = value;
			method_0();
		}
	}

	public IColorFormat SchemeColor => colorFormat_1;

	public bool NeedElement
	{
		get
		{
			if (enum274_0 == Enum274.const_0 && colorFormat_1.ColorType == ColorType.NotDefined && nullableBool_0 == NullableBool.NotDefined && nullableBool_1 == NullableBool.NotDefined)
			{
				return PPTXUnsupportedProps.ExtensionList != null;
			}
			return true;
		}
	}

	internal Class352 PPTXUnsupportedProps => class352_0;

	internal uint Version => uint_0 + fonts_0.Version + colorFormat_0.Version + colorFormat_1.Version;

	internal Class142(IPresentationComponent parent)
	{
		fonts_0 = new Fonts(((Presentation)parent.Presentation).FontsListManager.FontsList);
		colorFormat_0 = new ColorFormat(parent as ISlideComponent);
		colorFormat_1 = new ColorFormat(parent as ISlideComponent);
	}

	private void method_0()
	{
		uint_0++;
	}
}
