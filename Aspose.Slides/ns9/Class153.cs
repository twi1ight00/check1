using Aspose.Slides;
using ns33;
using ns56;

namespace ns9;

internal class Class153
{
	private Class1885 class1885_0;

	private ColorSchemeIndex[] colorSchemeIndex_0 = new ColorSchemeIndex[12];

	private bool bool_0;

	private uint uint_0;

	internal static readonly Class1151 class1151_0 = new Class1151("dk1", "lt1", "dk2", "lt2", "accent1", "accent2", "accent3", "accent4", "accent5", "accent6", "hlink", "folHlink");

	internal static readonly SchemeColor[] schemeColor_0 = new SchemeColor[12]
	{
		SchemeColor.Background1,
		SchemeColor.Text1,
		SchemeColor.Background2,
		SchemeColor.Text2,
		SchemeColor.Accent1,
		SchemeColor.Accent2,
		SchemeColor.Accent3,
		SchemeColor.Accent4,
		SchemeColor.Accent5,
		SchemeColor.Accent6,
		SchemeColor.Hyperlink,
		SchemeColor.FollowedHyperlink
	};

	private static readonly Class1155 class1155_0 = new Class1155(SchemeColor.StyleColor, ColorSchemeIndex.Accent1, SchemeColor.Dark1, ColorSchemeIndex.Dark1, SchemeColor.Light1, ColorSchemeIndex.Light1, SchemeColor.Dark2, ColorSchemeIndex.Dark2, SchemeColor.Light2, ColorSchemeIndex.Light2);

	public bool On
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
				method_4();
			}
		}
	}

	internal Class1885 ExtensionList
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	internal uint Version => uint_0;

	internal Class153()
	{
		method_0();
	}

	internal void method_0()
	{
		colorSchemeIndex_0[0] = ColorSchemeIndex.Light1;
		colorSchemeIndex_0[1] = ColorSchemeIndex.Dark1;
		colorSchemeIndex_0[2] = ColorSchemeIndex.Light2;
		colorSchemeIndex_0[3] = ColorSchemeIndex.Dark2;
		colorSchemeIndex_0[4] = ColorSchemeIndex.Accent1;
		colorSchemeIndex_0[5] = ColorSchemeIndex.Accent2;
		colorSchemeIndex_0[6] = ColorSchemeIndex.Accent3;
		colorSchemeIndex_0[7] = ColorSchemeIndex.Accent4;
		colorSchemeIndex_0[8] = ColorSchemeIndex.Accent5;
		colorSchemeIndex_0[9] = ColorSchemeIndex.Accent6;
		colorSchemeIndex_0[10] = ColorSchemeIndex.Hyperlink;
		colorSchemeIndex_0[11] = ColorSchemeIndex.FollowedHyperlink;
		method_4();
	}

	public ColorSchemeIndex method_1(SchemeColor index)
	{
		if (index > SchemeColor.FollowedHyperlink)
		{
			return (ColorSchemeIndex)class1155_0[index];
		}
		return colorSchemeIndex_0[(int)index];
	}

	public void method_2(SchemeColor index, ColorSchemeIndex value)
	{
		if (index <= SchemeColor.FollowedHyperlink)
		{
			colorSchemeIndex_0[(int)index] = value;
			method_4();
		}
	}

	public void method_3(Class153 colorMapping)
	{
		if (colorMapping != null && colorMapping.bool_0)
		{
			bool_0 = true;
			for (int i = 0; i < colorSchemeIndex_0.Length; i++)
			{
				colorSchemeIndex_0[i] = colorMapping.colorSchemeIndex_0[i];
			}
			method_4();
		}
		else
		{
			bool_0 = false;
		}
	}

	private void method_4()
	{
		uint_0++;
	}
}
