using ns24;
using ns28;

namespace Aspose.Slides;

public class Placeholder : IPlaceholder
{
	private Orientation orientation_0;

	private PlaceholderSize placeholderSize_0;

	private PlaceholderType placeholderType_0;

	private uint uint_0;

	private Class348 class348_0 = new Class348();

	public Orientation Orientation => orientation_0;

	public PlaceholderSize Size => placeholderSize_0;

	public PlaceholderType Type => placeholderType_0;

	public uint Index => uint_0;

	internal uint IndexInternal
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	internal bool HasCustomPrompt => PPTXUnsupportedProps.HasCustomPrompt;

	internal Class348 PPTXUnsupportedProps => class348_0;

	internal Placeholder(Class384 frame, int idx)
	{
		orientation_0 = Orientation.Horizontal;
		placeholderSize_0 = PlaceholderSize.Full;
		uint_0 = uint.MaxValue;
		switch (frame.PresentationClass)
		{
		case Enum64.const_0:
			placeholderType_0 = PlaceholderType.Title;
			break;
		case Enum64.const_1:
			placeholderType_0 = PlaceholderType.Body;
			break;
		case Enum64.const_2:
			placeholderType_0 = PlaceholderType.Subtitle;
			break;
		case Enum64.const_4:
			placeholderType_0 = PlaceholderType.Picture;
			break;
		case Enum64.const_5:
			placeholderType_0 = PlaceholderType.Object;
			break;
		case Enum64.const_6:
			placeholderType_0 = PlaceholderType.Chart;
			break;
		case Enum64.const_7:
			placeholderType_0 = PlaceholderType.Table;
			break;
		case Enum64.const_10:
			placeholderType_0 = PlaceholderType.SlideImage;
			break;
		case Enum64.const_3:
		case Enum64.const_8:
		case Enum64.const_9:
		case Enum64.const_11:
			break;
		case Enum64.const_12:
			placeholderType_0 = PlaceholderType.Header;
			break;
		case Enum64.const_13:
			placeholderType_0 = PlaceholderType.Footer;
			break;
		case Enum64.const_14:
			placeholderType_0 = PlaceholderType.DateAndTime;
			break;
		case Enum64.const_15:
			placeholderType_0 = PlaceholderType.SlideNumber;
			break;
		}
	}

	internal Placeholder(Orientation orientation, PlaceholderSize size, PlaceholderType type, uint index, bool hasCustomPrompt)
	{
		placeholderType_0 = type;
		placeholderSize_0 = size;
		orientation_0 = orientation;
		uint_0 = index;
		PPTXUnsupportedProps.HasCustomPrompt = hasCustomPrompt;
	}

	internal Placeholder()
	{
	}

	internal Enum64 method_0()
	{
		return Type switch
		{
			PlaceholderType.Title => Enum64.const_0, 
			PlaceholderType.Body => Enum64.const_1, 
			PlaceholderType.CenteredTitle => Enum64.const_0, 
			PlaceholderType.Subtitle => Enum64.const_2, 
			PlaceholderType.DateAndTime => Enum64.const_14, 
			PlaceholderType.SlideNumber => Enum64.const_15, 
			PlaceholderType.Footer => Enum64.const_13, 
			PlaceholderType.Header => Enum64.const_12, 
			PlaceholderType.Object => Enum64.const_1, 
			PlaceholderType.Chart => Enum64.const_6, 
			PlaceholderType.Table => Enum64.const_7, 
			PlaceholderType.SlideImage => Enum64.const_10, 
			PlaceholderType.Picture => Enum64.const_4, 
			_ => Enum64.const_1, 
		};
	}

	internal void method_1(Placeholder placeholder)
	{
		uint_0 = placeholder.uint_0;
		placeholderSize_0 = placeholder.placeholderSize_0;
		placeholderType_0 = placeholder.placeholderType_0;
		orientation_0 = placeholder.orientation_0;
		PPTXUnsupportedProps.HasCustomPrompt = placeholder.HasCustomPrompt;
	}
}
