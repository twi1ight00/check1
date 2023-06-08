using Aspose.Slides;
using ns16;
using ns24;

namespace ns4;

internal class Class143
{
	private Class149 class149_0;

	private Class149 class149_1;

	private Class149 class149_2;

	private Class149 class149_3;

	private Class149 class149_4;

	private Class149 class149_5;

	private Class149 class149_6;

	private Class149 class149_7;

	private Class148 class148_0;

	private Class353 class353_0 = new Class353();

	internal Class149 LeftBorder => class149_0;

	internal Class149 RightBorder => class149_1;

	internal Class149 TopBorder => class149_2;

	internal Class149 BottomBorder => class149_3;

	internal Class149 InsideHorizontalBorder => class149_4;

	internal Class149 InsideVerticalBorder => class149_5;

	internal Class149 TopLeftToBottomRightBorder => class149_6;

	internal Class149 TopRightToBottomLeftBorder => class149_7;

	internal Class148 FillFormat => class148_0;

	internal bool NeedElement
	{
		get
		{
			if (LeftBorder.Source == Enum275.const_0 && RightBorder.Source == Enum275.const_0 && TopBorder.Source == Enum275.const_0 && BottomBorder.Source == Enum275.const_0 && InsideHorizontalBorder.Source == Enum275.const_0 && InsideVerticalBorder.Source == Enum275.const_0 && TopLeftToBottomRightBorder.Source == Enum275.const_0 && TopRightToBottomLeftBorder.Source == Enum275.const_0 && FillFormat.Source == Enum273.const_0)
			{
				return PPTXUnsupportedProps.NeedElement;
			}
			return true;
		}
	}

	internal Class353 PPTXUnsupportedProps => class353_0;

	internal uint Version => class149_0.Version + class149_1.Version + class149_2.Version + class149_3.Version + class149_4.Version + class149_5.Version + class149_6.Version + class149_7.Version + class148_0.Version;

	internal Class143(IPresentationComponent parent)
	{
		class149_0 = new Class149(parent);
		class149_1 = new Class149(parent);
		class149_2 = new Class149(parent);
		class149_3 = new Class149(parent);
		class149_4 = new Class149(parent);
		class149_5 = new Class149(parent);
		class149_6 = new Class149(parent);
		class149_7 = new Class149(parent);
		class148_0 = new Class148(parent);
	}
}
