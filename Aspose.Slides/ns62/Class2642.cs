using System.IO;
using ns60;
using ns63;

namespace ns62;

internal class Class2642 : Class2639
{
	public const int int_0 = 61453;

	private Class2982 class2982_0;

	private Class2951 class2951_0;

	public Class2951 ContentRecords => class2951_0;

	public string Text
	{
		get
		{
			Class2951 contentRecords = ContentRecords;
			if (contentRecords != null && contentRecords.HaveTextData)
			{
				return contentRecords.ChildText;
			}
			return null;
		}
	}

	public Enum449 TextType
	{
		get
		{
			Class2951 contentRecords = ContentRecords;
			if (contentRecords != null && contentRecords.HaveTextHeader)
			{
				return contentRecords.TextHeader.TextType;
			}
			return Enum449.const_3;
		}
	}

	public Class2642()
		: base(61453)
	{
		class2982_0 = new Class2982(this);
		class2951_0 = class2982_0.method_1();
	}

	internal void method_5(Enum452 queryType, int index)
	{
		switch (queryType)
		{
		case Enum452.const_1:
			switch (index)
			{
			case 0:
			{
				Class2859 class2 = new Class2859(null);
				class2982_0.method_2(class2);
				class2.Header.Version = 0;
				class2.Header.Instance = 0;
				class2.TextType = Enum449.const_0;
				Class2858 class3 = new Class2858(null);
				class2982_0.method_2(class3);
				class3.Header.Version = 0;
				class3.Header.Instance = 0;
				class3.Text = "Образец заголовка";
				Class2853 class12 = new Class2853(null);
				class2982_0.method_2(class12);
				class12.Header.Version = 0;
				class12.Header.Instance = 0;
				class12.RgMasterTextPropRun.Add(new Class2961(18u, 0));
				Class2861 class8 = new Class2861(null);
				class2982_0.method_2(class8);
				class8.Header.Version = 0;
				class8.Header.Instance = 0;
				Class2986 class9 = new Class2986();
				class9.Count = (uint)class3.Text.Length;
				class9.SpecialInfo.SpellInfo = new Class2967();
				class9.SpecialInfo.method_3(1u);
				class8.RgTextSIRun = new Class2986[1] { class9 };
				break;
			}
			case 1:
			{
				Class2859 class2 = new Class2859(null);
				class2.Header.Version = 0;
				class2.Header.Instance = 0;
				class2.TextType = Enum449.const_1;
				class2982_0.method_2(class2);
				Class2858 class3 = new Class2858(null);
				class3.Header.Version = 0;
				class3.Header.Instance = 0;
				class3.Text = "Text example\r\nSecond level\r\nThird level\r\nFourth level\r\nFifth level";
				class2982_0.method_2(class3);
				Class2853 class12 = new Class2853(null);
				class12.Header.Version = 0;
				class12.Header.Instance = 0;
				class12.RgMasterTextPropRun.Add(new Class2961(15u, 0));
				class12.RgMasterTextPropRun.Add(new Class2961(15u, 1));
				class12.RgMasterTextPropRun.Add(new Class2961(15u, 2));
				class12.RgMasterTextPropRun.Add(new Class2961(18u, 3));
				class12.RgMasterTextPropRun.Add(new Class2961(14u, 4));
				class2982_0.method_2(class12);
				Class2861 class8 = new Class2861(null);
				class8.Header.Version = 0;
				class8.Header.Instance = 0;
				Class2986 class9 = new Class2986();
				class9.Count = (uint)class3.Text.Length;
				class9.SpecialInfo.SpellInfo = new Class2967();
				class9.SpecialInfo.method_3(1u);
				class8.RgTextSIRun = new Class2986[1] { class9 };
				class2982_0.method_2(class8);
				break;
			}
			case 2:
			{
				Class2859 class2 = new Class2859(null);
				class2.Header.Version = 0;
				class2.Header.Instance = 0;
				class2.TextType = Enum449.const_3;
				class2982_0.method_2(class2);
				Class2858 class3 = new Class2858(null);
				class3.Header.Version = 0;
				class3.Header.Instance = 0;
				class3.Text = "*";
				class2982_0.method_2(class3);
				Class2856 class4 = new Class2856(null);
				class4.Header.Version = 0;
				class4.Header.Instance = 0;
				Class2984 class5 = new Class2984();
				class5.Count = (uint)class3.Text.Length;
				Class2983 class6 = new Class2983();
				class6.Count = (uint)class3.Text.Length;
				class6.CharFormat.FontSize = 14;
				class4.RgTextPFRun = new Class2984[1] { class5 };
				class4.RgTextCFRun = new Class2983[1] { class6 };
				class2982_0.method_2(class4);
				Class2849 class11 = new Class2849(null);
				class11.Header.Version = 0;
				class11.Header.Instance = 0;
				class2982_0.method_2(class11);
				Class2861 class8 = new Class2861(null);
				class8.Header.Version = 0;
				class8.Header.Instance = 0;
				Class2986 class9 = new Class2986();
				class9.Count = (uint)class3.Text.Length;
				class9.SpecialInfo.SpellInfo = new Class2967();
				class9.SpecialInfo.method_3(1u);
				class8.RgTextSIRun = new Class2986[1] { class9 };
				class2982_0.method_2(class8);
				break;
			}
			case 3:
			{
				Class2859 class2 = new Class2859(null);
				class2.Header.Version = 0;
				class2.Header.Instance = 0;
				class2.TextType = Enum449.const_3;
				class2982_0.method_2(class2);
				Class2858 class3 = new Class2858(null);
				class3.Header.Version = 0;
				class3.Header.Instance = 0;
				class3.Text = "*";
				class2982_0.method_2(class3);
				Class2856 class4 = new Class2856(null);
				class4.Header.Version = 0;
				class4.Header.Instance = 0;
				Class2984 class5 = new Class2984();
				class5.Count = (uint)class3.Text.Length;
				class5.ParagraphFormat.TextAlignment = Enum455.const_2;
				Class2983 class6 = new Class2983();
				class6.Count = (uint)class3.Text.Length;
				class6.CharFormat.FontSize = 14;
				class4.RgTextPFRun = new Class2984[1] { class5 };
				class4.RgTextCFRun = new Class2983[1] { class6 };
				class2982_0.method_2(class4);
				Class2848 class10 = new Class2848(null);
				class10.Header.Version = 0;
				class10.Header.Instance = 0;
				class2982_0.method_2(class10);
				Class2861 class8 = new Class2861(null);
				class8.Header.Version = 0;
				class8.Header.Instance = 0;
				Class2986 class9 = new Class2986();
				class9.Count = (uint)class3.Text.Length;
				class9.SpecialInfo.SpellInfo = new Class2967();
				class9.SpecialInfo.method_3(1u);
				class8.RgTextSIRun = new Class2986[1] { class9 };
				class2982_0.method_2(class8);
				break;
			}
			case 4:
			{
				Class2859 class2 = new Class2859(null);
				class2.Header.Version = 0;
				class2.Header.Instance = 0;
				class2.TextType = Enum449.const_3;
				class2982_0.method_2(class2);
				Class2858 class3 = new Class2858(null);
				class3.Header.Version = 0;
				class3.Header.Instance = 0;
				class3.Text = "*";
				class2982_0.method_2(class3);
				Class2856 class4 = new Class2856(null);
				class4.Header.Version = 0;
				class4.Header.Instance = 0;
				Class2984 class5 = new Class2984();
				class5.Count = (uint)class3.Text.Length;
				class5.ParagraphFormat.TextAlignment = Enum455.const_3;
				Class2983 class6 = new Class2983();
				class6.Count = (uint)class3.Text.Length;
				class6.CharFormat.FontSize = 14;
				class4.RgTextPFRun = new Class2984[1] { class5 };
				class4.RgTextCFRun = new Class2983[1] { class6 };
				class2982_0.method_2(class4);
				Class2852 class7 = new Class2852(null);
				class7.Header.Version = 0;
				class7.Header.Instance = 0;
				class2982_0.method_2(class7);
				Class2861 class8 = new Class2861(null);
				class8.Header.Version = 0;
				class8.Header.Instance = 0;
				Class2986 class9 = new Class2986();
				class9.Count = (uint)class3.Text.Length;
				class9.SpecialInfo.SpellInfo = new Class2967();
				class9.SpecialInfo.method_3(1u);
				class8.RgTextSIRun = new Class2986[1] { class9 };
				class2982_0.method_2(class8);
				break;
			}
			}
			break;
		case Enum452.const_2:
			switch (index)
			{
			case 0:
			{
				Class2854 @class = new Class2854(null);
				@class.Header.Version = 0;
				@class.Header.Instance = 0;
				@class.Index = 0;
				class2982_0.method_2(@class);
				break;
			}
			case 1:
			{
				Class2854 @class = new Class2854(null);
				@class.Header.Version = 0;
				@class.Header.Instance = 0;
				@class.Index = 1;
				class2982_0.method_2(@class);
				break;
			}
			}
			break;
		}
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2982_0.method_6(reader, base.Header.Length);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2982_0.method_7(writer);
	}

	public override int vmethod_2()
	{
		return class2982_0.method_8();
	}
}
