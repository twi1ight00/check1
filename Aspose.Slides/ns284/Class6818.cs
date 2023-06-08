using System;
using System.Collections.Generic;
using System.Drawing;
using ns277;
using ns84;

namespace ns284;

internal class Class6818 : ICloneable, Interface329
{
	private abstract class Class6819
	{
		private Enum925 enum925_0;

		public Enum925 Name => enum925_0;

		public Class6819(Enum925 name)
		{
			enum925_0 = name;
		}

		public abstract Class6819 Clone();
	}

	private enum Enum925
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15,
		const_16,
		const_17,
		const_18,
		const_19,
		const_20,
		const_21,
		const_22,
		const_23,
		const_24,
		const_25,
		const_26,
		const_27,
		const_28,
		const_29,
		const_30,
		const_31,
		const_32,
		const_33,
		const_34,
		const_35,
		const_36,
		const_37,
		const_38,
		const_39,
		const_40,
		const_41,
		const_42,
		const_43,
		const_44,
		const_45,
		const_46,
		const_47,
		const_48,
		const_49,
		const_50,
		const_51,
		const_52,
		const_53,
		const_54,
		const_55,
		const_56,
		const_57,
		const_58,
		const_59,
		const_60,
		const_61,
		const_62,
		const_63,
		const_64,
		const_65,
		const_66,
		const_67,
		const_68,
		const_69,
		const_70,
		const_71,
		const_72,
		const_73,
		const_74,
		const_75,
		const_76,
		const_77,
		const_78,
		const_79,
		const_80,
		const_81,
		const_82,
		const_83,
		const_84,
		const_85,
		const_86,
		const_87,
		const_88,
		const_89,
		const_90,
		const_91,
		const_92,
		const_93,
		const_94,
		const_95,
		const_96,
		const_97,
		const_98,
		const_99,
		const_100,
		const_101
	}

	private class Class6820<T> : Class6819
	{
		private T gparam_0;

		public T Value
		{
			get
			{
				return gparam_0;
			}
			set
			{
				gparam_0 = value;
			}
		}

		public Class6820(Enum925 name)
			: base(name)
		{
			gparam_0 = default(T);
		}

		public override Class6819 Clone()
		{
			Class6820<T> @class = new Class6820<T>(base.Name);
			@class.Value = gparam_0;
			return @class;
		}
	}

	private Class4347 class4347_0;

	private Class6983 class6983_0;

	private Interface355 interface355_0;

	private Dictionary<Enum925, Class6819> dictionary_0 = new Dictionary<Enum925, Class6819>();

	private static List<string> list_0 = new List<string>(new string[3] { "tr", "td", "th" });

	public FontStyle FontStyle
	{
		get
		{
			return method_0<FontStyle>(Enum925.const_0).Value;
		}
		set
		{
			method_1(Enum925.const_0, value);
		}
	}

	public float FontSize
	{
		get
		{
			return method_0<float>(Enum925.const_1).Value;
		}
		set
		{
			method_1(Enum925.const_1, value);
		}
	}

	public int FontLarger
	{
		get
		{
			return method_0<int>(Enum925.const_2).Value;
		}
		set
		{
			method_1(Enum925.const_2, value);
		}
	}

	public string FontFamilyName
	{
		get
		{
			return method_0<string>(Enum925.const_3).Value;
		}
		set
		{
			method_1(Enum925.const_3, value);
		}
	}

	public bool IsTextOverlined
	{
		get
		{
			return method_0<bool>(Enum925.const_4).Value;
		}
		set
		{
			method_1(Enum925.const_4, value);
		}
	}

	public float CharSpace
	{
		get
		{
			return method_0<float>(Enum925.const_5).Value;
		}
		set
		{
			method_1(Enum925.const_5, value);
		}
	}

	public Color Color
	{
		get
		{
			return method_0<Color>(Enum925.const_6).Value;
		}
		set
		{
			method_1(Enum925.const_6, value);
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return method_0<Color>(Enum925.const_7).Value;
		}
		set
		{
			method_1(Enum925.const_7, value);
		}
	}

	public Color FirstLineColor
	{
		get
		{
			return method_0<Color>(Enum925.const_8).Value;
		}
		set
		{
			method_1(Enum925.const_8, value);
		}
	}

	public Color FirstLetterColor
	{
		get
		{
			return method_0<Color>(Enum925.const_9).Value;
		}
		set
		{
			method_1(Enum925.const_9, value);
		}
	}

	public Enum952 Display
	{
		get
		{
			return method_0<Enum952>(Enum925.const_10).Value;
		}
		set
		{
			method_1(Enum925.const_10, value);
		}
	}

	public Enum953 Overflow
	{
		get
		{
			return method_0<Enum953>(Enum925.const_11).Value;
		}
		set
		{
			method_1(Enum925.const_11, value);
		}
	}

	public Enum954 Float
	{
		get
		{
			return method_0<Enum954>(Enum925.const_12).Value;
		}
		set
		{
			method_1(Enum925.const_12, value);
		}
	}

	public Enum956 Position
	{
		get
		{
			return method_0<Enum956>(Enum925.const_13).Value;
		}
		set
		{
			method_1(Enum925.const_13, value);
		}
	}

	public Enum935 Clear
	{
		get
		{
			return method_0<Enum935>(Enum925.const_14).Value;
		}
		set
		{
			method_1(Enum925.const_14, value);
		}
	}

	public Rectangle Clip
	{
		get
		{
			return method_0<Rectangle>(Enum925.const_15).Value;
		}
		set
		{
			method_1(Enum925.const_15, value);
		}
	}

	public Class6959 Left
	{
		get
		{
			return method_0<Class6959>(Enum925.const_16).Value;
		}
		set
		{
			method_1(Enum925.const_16, value);
		}
	}

	public Class6959 Top
	{
		get
		{
			return method_0<Class6959>(Enum925.const_17).Value;
		}
		set
		{
			method_1(Enum925.const_17, value);
		}
	}

	public Class6959 Bottom
	{
		get
		{
			return method_0<Class6959>(Enum925.const_18).Value;
		}
		set
		{
			method_1(Enum925.const_18, value);
		}
	}

	public Class6959 Right
	{
		get
		{
			return method_0<Class6959>(Enum925.const_19).Value;
		}
		set
		{
			method_1(Enum925.const_19, value);
		}
	}

	public int ZIndex
	{
		get
		{
			return method_0<int>(Enum925.const_20).Value;
		}
		set
		{
			method_1(Enum925.const_20, value);
		}
	}

	public Class6959 Width
	{
		get
		{
			return method_0<Class6959>(Enum925.const_21).Value;
		}
		set
		{
			method_1(Enum925.const_21, value);
		}
	}

	public Class6959 Height
	{
		get
		{
			return method_0<Class6959>(Enum925.const_22).Value;
		}
		set
		{
			method_1(Enum925.const_22, value);
		}
	}

	public Class6959 PaddingLeft
	{
		get
		{
			return method_0<Class6959>(Enum925.const_23).Value;
		}
		set
		{
			method_1(Enum925.const_23, value);
		}
	}

	public Class6959 PaddingRight
	{
		get
		{
			return method_0<Class6959>(Enum925.const_24).Value;
		}
		set
		{
			method_1(Enum925.const_24, value);
		}
	}

	public Class6959 PaddingTop
	{
		get
		{
			return method_0<Class6959>(Enum925.const_25).Value;
		}
		set
		{
			method_1(Enum925.const_25, value);
		}
	}

	public Class6959 PaddingBottom
	{
		get
		{
			return method_0<Class6959>(Enum925.const_26).Value;
		}
		set
		{
			method_1(Enum925.const_26, value);
		}
	}

	public Class6959 MarginLeft
	{
		get
		{
			return method_0<Class6959>(Enum925.const_27).Value;
		}
		set
		{
			method_1(Enum925.const_27, value);
		}
	}

	public Class6959 MarginRight
	{
		get
		{
			return method_0<Class6959>(Enum925.const_28).Value;
		}
		set
		{
			method_1(Enum925.const_28, value);
		}
	}

	public Class6959 MarginTop
	{
		get
		{
			return method_0<Class6959>(Enum925.const_29).Value;
		}
		set
		{
			method_1(Enum925.const_29, value);
		}
	}

	public Class6959 MarginBottom
	{
		get
		{
			return method_0<Class6959>(Enum925.const_30).Value;
		}
		set
		{
			method_1(Enum925.const_30, value);
		}
	}

	public Class6959 BorderWidthLeft
	{
		get
		{
			return method_0<Class6959>(Enum925.const_31).Value;
		}
		set
		{
			method_1(Enum925.const_31, value);
		}
	}

	public Class6959 BorderWidthRight
	{
		get
		{
			return method_0<Class6959>(Enum925.const_32).Value;
		}
		set
		{
			method_1(Enum925.const_32, value);
		}
	}

	public Class6959 BorderWidthTop
	{
		get
		{
			return method_0<Class6959>(Enum925.const_33).Value;
		}
		set
		{
			method_1(Enum925.const_33, value);
		}
	}

	public Class6959 BorderWidthBottom
	{
		get
		{
			return method_0<Class6959>(Enum925.const_34).Value;
		}
		set
		{
			method_1(Enum925.const_34, value);
		}
	}

	public Class6959 BorderTableWidthLeft
	{
		get
		{
			return method_0<Class6959>(Enum925.const_35).Value;
		}
		set
		{
			method_1(Enum925.const_35, value);
		}
	}

	public Class6959 BorderTableWidthRight
	{
		get
		{
			return method_0<Class6959>(Enum925.const_36).Value;
		}
		set
		{
			method_1(Enum925.const_36, value);
		}
	}

	public Class6959 BorderTableWidthTop
	{
		get
		{
			return method_0<Class6959>(Enum925.const_37).Value;
		}
		set
		{
			method_1(Enum925.const_37, value);
		}
	}

	public Class6959 BorderTableWidthBottom
	{
		get
		{
			return method_0<Class6959>(Enum925.const_38).Value;
		}
		set
		{
			method_1(Enum925.const_38, value);
		}
	}

	public Enum957 TextAlign
	{
		get
		{
			return method_0<Enum957>(Enum925.const_39).Value;
		}
		set
		{
			method_1(Enum925.const_39, value);
		}
	}

	public Enum958 TextVAlign
	{
		get
		{
			return method_0<Enum958>(Enum925.const_40).Value;
		}
		set
		{
			method_1(Enum925.const_40, value);
		}
	}

	public Enum959 WhiteSpace
	{
		get
		{
			return method_0<Enum959>(Enum925.const_41).Value;
		}
		set
		{
			method_1(Enum925.const_41, value);
		}
	}

	public Enum948 Align
	{
		get
		{
			return method_0<Enum948>(Enum925.const_42).Value;
		}
		set
		{
			method_1(Enum925.const_42, value);
		}
	}

	public Enum940 TextTransform
	{
		get
		{
			return method_0<Enum940>(Enum925.const_43).Value;
		}
		set
		{
			method_1(Enum925.const_43, value);
		}
	}

	public Class6959 TextIndent
	{
		get
		{
			return method_0<Class6959>(Enum925.const_44).Value;
		}
		set
		{
			method_1(Enum925.const_44, value);
		}
	}

	public Class6959 WordSpacing
	{
		get
		{
			return method_0<Class6959>(Enum925.const_45).Value;
		}
		set
		{
			method_1(Enum925.const_45, value);
		}
	}

	public Enum951 BorderStyleTop
	{
		get
		{
			return method_0<Enum951>(Enum925.const_46).Value;
		}
		set
		{
			method_1(Enum925.const_46, value);
		}
	}

	public Enum951 BorderStyleRight
	{
		get
		{
			return method_0<Enum951>(Enum925.const_47).Value;
		}
		set
		{
			method_1(Enum925.const_47, value);
		}
	}

	public Enum951 BorderStyleBottom
	{
		get
		{
			return method_0<Enum951>(Enum925.const_48).Value;
		}
		set
		{
			method_1(Enum925.const_48, value);
		}
	}

	public Enum951 BorderStyleLeft
	{
		get
		{
			return method_0<Enum951>(Enum925.const_49).Value;
		}
		set
		{
			method_1(Enum925.const_49, value);
		}
	}

	public Enum951 BorderTableStyleTop
	{
		get
		{
			return method_0<Enum951>(Enum925.const_50).Value;
		}
		set
		{
			method_1(Enum925.const_50, value);
		}
	}

	public Enum951 BorderTableStyleRight
	{
		get
		{
			return method_0<Enum951>(Enum925.const_51).Value;
		}
		set
		{
			method_1(Enum925.const_51, value);
		}
	}

	public Enum951 BorderTableStyleBottom
	{
		get
		{
			return method_0<Enum951>(Enum925.const_52).Value;
		}
		set
		{
			method_1(Enum925.const_52, value);
		}
	}

	public Enum951 BorderTableStyleLeft
	{
		get
		{
			return method_0<Enum951>(Enum925.const_53).Value;
		}
		set
		{
			method_1(Enum925.const_53, value);
		}
	}

	public Color BorderColorTop
	{
		get
		{
			return method_0<Color>(Enum925.const_54).Value;
		}
		set
		{
			method_1(Enum925.const_54, value);
		}
	}

	public Color BorderColorRight
	{
		get
		{
			return method_0<Color>(Enum925.const_55).Value;
		}
		set
		{
			method_1(Enum925.const_55, value);
		}
	}

	public Color BorderColorBottom
	{
		get
		{
			return method_0<Color>(Enum925.const_56).Value;
		}
		set
		{
			method_1(Enum925.const_56, value);
		}
	}

	public Color BorderColorLeft
	{
		get
		{
			return method_0<Color>(Enum925.const_57).Value;
		}
		set
		{
			method_1(Enum925.const_57, value);
		}
	}

	public Color BorderTableColorTop
	{
		get
		{
			return method_0<Color>(Enum925.const_58).Value;
		}
		set
		{
			method_1(Enum925.const_58, value);
		}
	}

	public Color BorderTableColorRight
	{
		get
		{
			return method_0<Color>(Enum925.const_59).Value;
		}
		set
		{
			method_1(Enum925.const_59, value);
		}
	}

	public Color BorderTableColorBottom
	{
		get
		{
			return method_0<Color>(Enum925.const_60).Value;
		}
		set
		{
			method_1(Enum925.const_60, value);
		}
	}

	public Color BorderTableColorLeft
	{
		get
		{
			return method_0<Color>(Enum925.const_61).Value;
		}
		set
		{
			method_1(Enum925.const_61, value);
		}
	}

	public float LineSpacing
	{
		get
		{
			return method_0<float>(Enum925.const_62).Value;
		}
		set
		{
			method_1(Enum925.const_62, value);
		}
	}

	public float LineHeight
	{
		get
		{
			return method_0<float>(Enum925.const_63).Value;
		}
		set
		{
			method_1(Enum925.const_63, value);
		}
	}

	public Enum939 TableLayout
	{
		get
		{
			return method_0<Enum939>(Enum925.const_64).Value;
		}
		set
		{
			method_1(Enum925.const_64, value);
		}
	}

	public int Colspan
	{
		get
		{
			return method_0<int>(Enum925.const_65).Value;
		}
		set
		{
			method_1(Enum925.const_65, value);
		}
	}

	public string Content
	{
		get
		{
			return method_0<string>(Enum925.const_66).Value;
		}
		set
		{
			method_1(Enum925.const_66, value);
		}
	}

	public int Rowspan
	{
		get
		{
			return method_0<int>(Enum925.const_67).Value;
		}
		set
		{
			method_1(Enum925.const_67, value);
		}
	}

	public Enum933 BorderCollapse
	{
		get
		{
			return method_0<Enum933>(Enum925.const_68).Value;
		}
		set
		{
			method_1(Enum925.const_68, value);
		}
	}

	public Enum937 EmptyCells
	{
		get
		{
			return method_0<Enum937>(Enum925.const_69).Value;
		}
		set
		{
			method_1(Enum925.const_69, value);
		}
	}

	public Class6959 BorderSpacingHorisontal
	{
		get
		{
			return method_0<Class6959>(Enum925.const_70).Value;
		}
		set
		{
			method_1(Enum925.const_70, value);
		}
	}

	public Class6959 BorderSpacingVertical
	{
		get
		{
			return method_0<Class6959>(Enum925.const_71).Value;
		}
		set
		{
			method_1(Enum925.const_71, value);
		}
	}

	public Class6959 CellPadding
	{
		get
		{
			return method_0<Class6959>(Enum925.const_72).Value;
		}
		set
		{
			method_1(Enum925.const_72, value);
		}
	}

	public int ListStyle
	{
		get
		{
			return method_0<int>(Enum925.const_73).Value;
		}
		set
		{
			method_1(Enum925.const_73, value);
		}
	}

	public Enum938 ListStylePosition
	{
		get
		{
			return method_0<Enum938>(Enum925.const_74).Value;
		}
		set
		{
			method_1(Enum925.const_74, value);
		}
	}

	public Class6959 CounterValue
	{
		get
		{
			return method_0<Class6959>(Enum925.const_75).Value;
		}
		set
		{
			method_1(Enum925.const_75, value);
		}
	}

	public int CounterIncrementValue
	{
		get
		{
			return method_0<int>(Enum925.const_76).Value;
		}
		set
		{
			method_1(Enum925.const_76, value);
		}
	}

	public bool IsBordered
	{
		get
		{
			return method_0<bool>(Enum925.const_77).Value;
		}
		set
		{
			method_1(Enum925.const_77, value);
		}
	}

	public string BackgroundImage
	{
		get
		{
			return method_0<string>(Enum925.const_78).Value;
		}
		set
		{
			method_1(Enum925.const_78, value);
		}
	}

	public Enum936 Direction
	{
		get
		{
			return method_0<Enum936>(Enum925.const_79).Value;
		}
		set
		{
			method_1(Enum925.const_79, value);
		}
	}

	public Enum950 PageBreakBefore
	{
		get
		{
			return method_0<Enum950>(Enum925.const_80).Value;
		}
		set
		{
			method_1(Enum925.const_80, value);
		}
	}

	public Enum950 PageBreakAfter
	{
		get
		{
			return method_0<Enum950>(Enum925.const_81).Value;
		}
		set
		{
			method_1(Enum925.const_81, value);
		}
	}

	public Enum950 PageBreakInside
	{
		get
		{
			return method_0<Enum950>(Enum925.const_82).Value;
		}
		set
		{
			method_1(Enum925.const_82, value);
		}
	}

	public int Orphans
	{
		get
		{
			return method_0<int>(Enum925.const_83).Value;
		}
		set
		{
			method_1(Enum925.const_83, value);
		}
	}

	public int Windows
	{
		get
		{
			return method_0<int>(Enum925.const_84).Value;
		}
		set
		{
			method_1(Enum925.const_84, value);
		}
	}

	public bool TextWrapType
	{
		get
		{
			return method_0<bool>(Enum925.const_85).Value;
		}
		set
		{
			method_1(Enum925.const_85, value);
		}
	}

	public Class6959 PageFirstMarginLeft
	{
		get
		{
			return method_0<Class6959>(Enum925.const_86).Value;
		}
		set
		{
			method_1(Enum925.const_86, value);
		}
	}

	public Class6959 PageFirstMarginRight
	{
		get
		{
			return method_0<Class6959>(Enum925.const_87).Value;
		}
		set
		{
			method_1(Enum925.const_87, value);
		}
	}

	public Class6959 PageFirstMarginTop
	{
		get
		{
			return method_0<Class6959>(Enum925.const_88).Value;
		}
		set
		{
			method_1(Enum925.const_88, value);
		}
	}

	public Class6959 PageFirstMarginBottom
	{
		get
		{
			return method_0<Class6959>(Enum925.const_89).Value;
		}
		set
		{
			method_1(Enum925.const_89, value);
		}
	}

	public Class6959 PageLeftMarginTop
	{
		get
		{
			return method_0<Class6959>(Enum925.const_90).Value;
		}
		set
		{
			method_1(Enum925.const_90, value);
		}
	}

	public Class6959 PageLeftMarginBottom
	{
		get
		{
			return method_0<Class6959>(Enum925.const_91).Value;
		}
		set
		{
			method_1(Enum925.const_91, value);
		}
	}

	public Class6959 PageLeftMarginLeft
	{
		get
		{
			return method_0<Class6959>(Enum925.const_92).Value;
		}
		set
		{
			method_1(Enum925.const_92, value);
		}
	}

	public Class6959 PageLeftMarginRight
	{
		get
		{
			return method_0<Class6959>(Enum925.const_93).Value;
		}
		set
		{
			method_1(Enum925.const_93, value);
		}
	}

	public Class6959 PageRightMarginTop
	{
		get
		{
			return method_0<Class6959>(Enum925.const_94).Value;
		}
		set
		{
			method_1(Enum925.const_94, value);
		}
	}

	public Class6959 PageRightMarginBottom
	{
		get
		{
			return method_0<Class6959>(Enum925.const_95).Value;
		}
		set
		{
			method_1(Enum925.const_95, value);
		}
	}

	public Class6959 PageRightMarginLeft
	{
		get
		{
			return method_0<Class6959>(Enum925.const_96).Value;
		}
		set
		{
			method_1(Enum925.const_96, value);
		}
	}

	public Class6959 PageRightMarginRight
	{
		get
		{
			return method_0<Class6959>(Enum925.const_97).Value;
		}
		set
		{
			method_1(Enum925.const_97, value);
		}
	}

	public Enum960 Visibility
	{
		get
		{
			return method_0<Enum960>(Enum925.const_99).Value;
		}
		set
		{
			method_1(Enum925.const_99, value);
		}
	}

	public Interface329 Before
	{
		get
		{
			return method_0<Interface329>(Enum925.const_100).Value;
		}
		set
		{
			method_1(Enum925.const_100, value);
		}
	}

	public Interface329 After
	{
		get
		{
			return method_0<Interface329>(Enum925.const_101).Value;
		}
		set
		{
			method_1(Enum925.const_101, value);
		}
	}

	public Class6818(Class4347 style, Class6983 element, Interface355 settings)
	{
		class4347_0 = style;
		class6983_0 = element;
		interface355_0 = settings;
	}

	private Class6820<T> method_0<T>(Enum925 name)
	{
		if (!dictionary_0.ContainsKey(name))
		{
			Class6820<T> @class = new Class6820<T>(name);
			@class.Value = (T)method_2(name);
			dictionary_0[name] = @class;
		}
		return (Class6820<T>)dictionary_0[name];
	}

	private void method_1<T>(Enum925 name, T value)
	{
		method_0<T>(name).Value = value;
	}

	private object method_2(Enum925 name)
	{
		Class6821 @class = new Class6821(class4347_0, this, class6983_0, interface355_0);
		return name switch
		{
			Enum925.const_0 => @class.method_0(), 
			Enum925.const_1 => @class.method_1(), 
			Enum925.const_2 => 0, 
			Enum925.const_3 => @class.method_2(), 
			Enum925.const_4 => @class.method_3(), 
			Enum925.const_5 => 0f, 
			Enum925.const_6 => @class.method_4(), 
			Enum925.const_7 => @class.method_5(), 
			Enum925.const_8 => @class.method_6(), 
			Enum925.const_9 => @class.method_7(), 
			Enum925.const_10 => @class.method_8(), 
			Enum925.const_11 => @class.method_9(), 
			Enum925.const_12 => @class.method_10(), 
			Enum925.const_13 => @class.method_11(), 
			Enum925.const_14 => @class.method_12(), 
			Enum925.const_15 => @class.method_13(), 
			Enum925.const_16 => @class.method_14(), 
			Enum925.const_17 => @class.method_15(), 
			Enum925.const_18 => @class.method_16(), 
			Enum925.const_19 => @class.method_17(), 
			Enum925.const_20 => (int)@class.method_18().Value, 
			Enum925.const_21 => @class.method_19(), 
			Enum925.const_22 => @class.method_20(), 
			Enum925.const_23 => @class.method_21(@class.Style.Padding.Left), 
			Enum925.const_24 => @class.method_21(@class.Style.Padding.Right), 
			Enum925.const_25 => @class.method_21(@class.Style.Padding.Top), 
			Enum925.const_26 => @class.method_21(@class.Style.Padding.Bottom), 
			Enum925.const_27 => @class.method_22(@class.Style.Margin.Left), 
			Enum925.const_28 => @class.method_22(@class.Style.Margin.Right), 
			Enum925.const_29 => @class.method_22(@class.Style.Margin.Top), 
			Enum925.const_30 => @class.method_22(@class.Style.Margin.Bottom), 
			Enum925.const_31 => @class.method_23(@class.Style.Border.Left.Width), 
			Enum925.const_32 => @class.method_23(@class.Style.Border.Right.Width), 
			Enum925.const_33 => @class.method_23(@class.Style.Border.Top.Width), 
			Enum925.const_34 => @class.method_23(@class.Style.Border.Bottom.Width), 
			Enum925.const_35 => @class.method_24(@class.Style.Border.Left.Width), 
			Enum925.const_36 => @class.method_24(@class.Style.Border.Right.Width), 
			Enum925.const_37 => @class.method_24(@class.Style.Border.Top.Width), 
			Enum925.const_38 => @class.method_24(@class.Style.Border.Bottom.Width), 
			Enum925.const_39 => @class.method_29(), 
			Enum925.const_40 => @class.method_30(), 
			Enum925.const_41 => @class.method_31(), 
			Enum925.const_42 => @class.method_32(), 
			Enum925.const_43 => @class.method_33(), 
			Enum925.const_44 => @class.method_34(), 
			Enum925.const_45 => @class.method_35(), 
			Enum925.const_46 => @class.method_25(@class.Style.Border.Top.Style), 
			Enum925.const_47 => @class.method_25(@class.Style.Border.Right.Style), 
			Enum925.const_48 => @class.method_25(@class.Style.Border.Bottom.Style), 
			Enum925.const_49 => @class.method_25(@class.Style.Border.Left.Style), 
			Enum925.const_50 => @class.method_26(@class.Style.Border.Top.Style), 
			Enum925.const_51 => @class.method_26(@class.Style.Border.Right.Style), 
			Enum925.const_52 => @class.method_26(@class.Style.Border.Bottom.Style), 
			Enum925.const_53 => @class.method_26(@class.Style.Border.Left.Style), 
			Enum925.const_54 => @class.method_27(@class.Style.Border.Top.Color), 
			Enum925.const_55 => @class.method_27(@class.Style.Border.Right.Color), 
			Enum925.const_56 => @class.method_27(@class.Style.Border.Bottom.Color), 
			Enum925.const_57 => @class.method_27(@class.Style.Border.Left.Color), 
			Enum925.const_58 => @class.method_28(@class.Style.Border.Top.Color), 
			Enum925.const_59 => @class.method_28(@class.Style.Border.Right.Color), 
			Enum925.const_60 => @class.method_28(@class.Style.Border.Bottom.Color), 
			Enum925.const_61 => @class.method_28(@class.Style.Border.Left.Color), 
			Enum925.const_62 => 0f, 
			Enum925.const_63 => @class.method_36(), 
			Enum925.const_64 => @class.method_37(), 
			Enum925.const_65 => 1, 
			Enum925.const_66 => @class.method_38(), 
			Enum925.const_67 => 1, 
			Enum925.const_68 => @class.method_39(), 
			Enum925.const_69 => @class.method_40(), 
			Enum925.const_70 => @class.method_21(class4347_0.Border.Spacing.Horizontal), 
			Enum925.const_71 => @class.method_21(class4347_0.Border.Spacing.Vertical), 
			Enum925.const_72 => @class.method_41(), 
			Enum925.const_73 => @class.method_42(), 
			Enum925.const_74 => @class.method_43(), 
			Enum925.const_75 => @class.method_44(), 
			Enum925.const_76 => 1, 
			Enum925.const_77 => false, 
			Enum925.const_78 => @class.method_45(), 
			Enum925.const_79 => @class.method_46(), 
			Enum925.const_80 => @class.method_47(@class.Style.PageBreakBefore), 
			Enum925.const_81 => @class.method_47(@class.Style.PageBreakAfter), 
			Enum925.const_82 => @class.method_47(@class.Style.PageBreakInside), 
			Enum925.const_83 => @class.Style.Orphans, 
			Enum925.const_84 => @class.Style.Widows, 
			Enum925.const_85 => @class.method_48(), 
			Enum925.const_86 => new Class6959(isAuto: true), 
			Enum925.const_87 => new Class6959(isAuto: true), 
			Enum925.const_88 => new Class6959(isAuto: true), 
			Enum925.const_89 => new Class6959(isAuto: true), 
			Enum925.const_90 => new Class6959(isAuto: true), 
			Enum925.const_91 => new Class6959(isAuto: true), 
			Enum925.const_92 => new Class6959(isAuto: true), 
			Enum925.const_93 => new Class6959(isAuto: true), 
			Enum925.const_94 => new Class6959(isAuto: true), 
			Enum925.const_95 => new Class6959(isAuto: true), 
			Enum925.const_96 => new Class6959(isAuto: true), 
			Enum925.const_97 => new Class6959(isAuto: true), 
			Enum925.const_99 => @class.method_49(), 
			Enum925.const_100 => @class.method_50(class4347_0.Before), 
			Enum925.const_101 => @class.method_50(class4347_0.After), 
			_ => throw new ArgumentException(), 
		};
	}

	public object Clone()
	{
		Class6818 @class = new Class6818(class4347_0, class6983_0, interface355_0);
		foreach (KeyValuePair<Enum925, Class6819> item in dictionary_0)
		{
			@class.dictionary_0.Add(item.Key, item.Value.Clone());
		}
		return @class;
	}

	public Interface329 imethod_0(string tagName)
	{
		Interface329 @interface = new Class6896();
		@interface.CharSpace = CharSpace;
		@interface.Color = Color;
		@interface.FontFamilyName = FontFamilyName;
		@interface.FontSize = FontSize;
		@interface.FontStyle = FontStyle;
		@interface.TextAlign = TextAlign;
		@interface.Align = Align;
		@interface.Height = Height;
		@interface.IsTextOverlined = IsTextOverlined;
		@interface.TextVAlign = TextVAlign;
		@interface.WhiteSpace = WhiteSpace;
		@interface.WordSpacing = WordSpacing;
		@interface.TextIndent = TextIndent;
		@interface.TextTransform = TextTransform;
		@interface.LineHeight = LineHeight;
		if (!list_0.Contains(tagName) && tagName != "#PCDATA")
		{
			@interface.BorderWidthLeft = BorderWidthLeft;
			@interface.BorderWidthRight = BorderWidthRight;
			@interface.BorderWidthTop = BorderWidthTop;
			@interface.BorderWidthBottom = BorderWidthBottom;
		}
		@interface.IsBordered = IsBordered;
		@interface.BorderCollapse = BorderCollapse;
		@interface.BorderSpacingHorisontal = BorderSpacingHorisontal;
		@interface.BorderSpacingVertical = BorderSpacingVertical;
		@interface.EmptyCells = EmptyCells;
		@interface.ListStylePosition = ListStylePosition;
		@interface.ListStyle = ListStyle;
		@interface.Direction = Direction;
		@interface.BackgroundColor = BackgroundColor;
		return @interface;
	}
}
