using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Theme;
using ns11;
using ns12;
using ns33;
using ns6;

namespace ns4;

internal sealed class Class532
{
	internal sealed class Class533
	{
		private Paragraph paragraph_0;

		internal byte[] byte_0;

		internal int[] int_0;

		public Paragraph Paragraph => paragraph_0;

		public Class533(Paragraph paragraph)
		{
			paragraph_0 = paragraph;
			int_0 = new int[paragraph.Portions.Count];
			method_0();
		}

		internal void method_0()
		{
			if (paragraph_0.Portions.Count < 1)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < paragraph_0.Portions.Count; i++)
			{
				stringBuilder.Append(((Portion)paragraph_0.Portions[i]).TextInternal);
			}
			int length = stringBuilder.Length;
			if (length < 1)
			{
				return;
			}
			byte_0 = new byte[length];
			Class1153.Enum175[] array = new Class1153.Enum175[length];
			int num = 0;
			for (int j = 0; j < paragraph_0.Portions.Count; j++)
			{
				int_0[j] = num;
				int num2 = ((Portion)paragraph_0.Portions[j]).TextInternal.Length;
				byte b = (byte)((Fonts.smethod_0(paragraph_0.Portions[j].PortionFormat.LanguageId) == Enum2.const_2) ? 3 : 0);
				while (num2 > 0)
				{
					array[num] = Class1153.smethod_11(stringBuilder[num]);
					byte_0[num] = b;
					num2--;
					num++;
				}
			}
			Class1153.smethod_9(array, ref byte_0);
			Class1153.smethod_10(stringBuilder.ToString(), ref byte_0);
		}
	}

	internal sealed class Class534
	{
		private string string_0;

		private RectangleF rectangleF_0;

		private Class151 class151_0;

		public string Text => string_0;

		public RectangleF Rect => rectangleF_0;

		public Class151 TextParam => class151_0;

		public Class534(string text, RectangleF rect, Class151 tp)
		{
			string_0 = text;
			rectangleF_0 = rect;
			class151_0 = tp;
		}
	}

	internal sealed class Class535
	{
		private List<Class534> list_0 = new List<Class534>();

		private bool bool_0;

		public bool NotEmpty => bool_0;

		public void method_0(Class534 portion)
		{
			if (portion != null)
			{
				if (list_0.Count < 1)
				{
					bool_0 = true;
				}
				list_0.Add(portion);
			}
		}

		public void method_1(Class159 cv, Class532 tl, bool bidi)
		{
			if (tl == null || cv == null)
			{
				return;
			}
			int count = list_0.Count;
			if (count < 1)
			{
				return;
			}
			float num = list_0[0].Rect.X;
			if (bidi)
			{
				num = list_0[0].Rect.X + list_0[0].Rect.Width;
			}
			int num2 = list_0.Count;
			while (num2 > 0)
			{
				num2--;
				Class534 @class = list_0[num2];
				if (bidi)
				{
					num -= @class.Rect.Width;
				}
				RectangleF target = new RectangleF(new PointF(num, @class.Rect.Y), @class.Rect.Size);
				tl.method_9(cv, @class.Text, target, @class.TextParam);
				if (!bidi)
				{
					num += @class.Rect.Width;
				}
			}
			list_0.Clear();
			bool_0 = false;
		}

		public void method_2()
		{
			list_0.Clear();
			bool_0 = false;
		}
	}

	internal struct Struct17 : IComparable
	{
		private Class533 class533_0;

		public int int_0;

		public int int_1;

		public Paragraph Paragraph => class533_0.Paragraph;

		public Class533 BiDiParagraph => class533_0;

		public Portion CurrentPortion => (Portion)((class533_0.Paragraph == null) ? null : class533_0.Paragraph.Portions[int_0]);

		public char CurrentChar
		{
			get
			{
				if (int_1 >= 0 && CurrentPortion != null && int_1 < CurrentPortion.TextInternal.Length)
				{
					return CurrentPortion.TextInternal[int_1];
				}
				return '\0';
			}
		}

		public bool IsParagraphBegin
		{
			get
			{
				if (int_0 == 0)
				{
					return int_1 == 0;
				}
				return false;
			}
		}

		public int CurrentCharParagraphOffset => class533_0.int_0[int_0] + int_1;

		public byte CurrentCharLevel
		{
			get
			{
				int num = class533_0.int_0[int_0] + int_1;
				if (num < class533_0.byte_0.Length)
				{
					return class533_0.byte_0[num];
				}
				return 0;
			}
		}

		public bool CurrentCharRtlState => (CurrentCharLevel & 1) != 0;

		public bool CurrentRunRtlState => (CurrentCharLevel & 2) != 0;

		public byte CurrentCharInWordPosition => (byte)((uint)(CurrentCharLevel >> 2) & 3u);

		public byte CurrentCharLigatureInfo => (byte)((uint)(CurrentCharLevel >> 4) & 3u);

		public bool IsSymbol => (CurrentChar & 0xFF00) == 61440;

		public Class1153.Enum177 CharacterClass => Class1153.smethod_5(CurrentChar);

		public bool isHyphen
		{
			get
			{
				char currentChar = CurrentChar;
				if (currentChar != '–' && currentChar != '—')
				{
					return currentChar == '-';
				}
				return true;
			}
		}

		private int nextPortionIndex
		{
			get
			{
				if (Paragraph != null && int_0 < Paragraph.Portions.Count - 1)
				{
					return int_0 + 1;
				}
				return int_0;
			}
		}

		private int prevPortionIndex
		{
			get
			{
				if (int_0 > 0)
				{
					return int_0 - 1;
				}
				return 0;
			}
		}

		internal Struct17 ParagraphEnd
		{
			get
			{
				if (Paragraph != null)
				{
					return smethod_10(class533_0);
				}
				return this;
			}
		}

		internal Struct17 CurrentPortionEnd => new Struct17(class533_0, int_0, CurrentPortion.TextInternal.Length);

		internal Struct17 CurrentPortionBegin => new Struct17(class533_0, int_0, 0);

		public Struct17(Class533 bidiparagraph, int portionIndex, int charIndex)
		{
			class533_0 = bidiparagraph;
			int_0 = portionIndex;
			int_1 = charIndex;
			while (int_0 < Paragraph.Portions.Count - 1 && CurrentPortion.TextInternal.Length == 0)
			{
				int_0++;
			}
			method_0();
		}

		private void method_0()
		{
			while (int_1 < 0)
			{
				if (prevPortionIndex < int_0)
				{
					int_0--;
					int_1 += CurrentPortion.TextInternal.Length;
					continue;
				}
				int_1 = -1;
				break;
			}
			while (nextPortionIndex > int_0 && int_1 >= CurrentPortion.TextInternal.Length)
			{
				int num = int_1 - CurrentPortion.TextInternal.Length;
				int_1 = num;
				int_0++;
			}
			if (nextPortionIndex <= int_0 && int_1 >= CurrentPortion.TextInternal.Length)
			{
				int_0 = Paragraph.Portions.Count - 1;
				int_1 = CurrentPortion.TextInternal.Length;
			}
		}

		[SpecialName]
		public static Struct17 smethod_0(Struct17 it, int offset)
		{
			Struct17 result = new Struct17(it.class533_0, it.int_0, it.int_1 + offset);
			result.method_0();
			return result;
		}

		[SpecialName]
		public static Struct17 smethod_1(Struct17 it, int offset)
		{
			Struct17 result = new Struct17(it.class533_0, it.int_0, it.int_1 - offset);
			result.method_0();
			return result;
		}

		public int CompareTo(Struct17 it)
		{
			if (class533_0 != it.class533_0)
			{
				throw new Exception("iterators mismatch");
			}
			method_0();
			it.method_0();
			if (int_0 == it.int_0)
			{
				if (int_1 == it.int_1)
				{
					return 0;
				}
				if (int_1 < it.int_1)
				{
					return -1;
				}
				return 1;
			}
			if (int_0 < it.int_0)
			{
				return -1;
			}
			return 1;
		}

		public bool Equals(Struct17 it)
		{
			if (class533_0 != it.class533_0)
			{
				throw new Exception("iterators mismatch");
			}
			method_0();
			it.method_0();
			if (int_0 == it.int_0)
			{
				return int_1 == it.int_1;
			}
			return false;
		}

		[SpecialName]
		public static int smethod_2(Struct17 it1, Struct17 it2)
		{
			int num = it1.CompareTo(it2);
			if (num < 0)
			{
				Struct17 @struct = it1;
				it1 = it2;
				it2 = @struct;
			}
			int num2 = it1.int_1 - it2.int_1;
			for (int i = it2.int_0; i < it1.int_0; i++)
			{
				num2 += ((Portion)it2.Paragraph.Portions[i]).TextInternal.Length;
			}
			if (num < 0)
			{
				num2 = -num2;
			}
			return num2;
		}

		public void MoveNext(int count)
		{
			int_1 += count;
			method_0();
		}

		public void method_1(int count)
		{
			int_1 -= count;
			method_0();
		}

		public void MoveNext()
		{
			MoveNext(1);
		}

		public void method_2()
		{
			method_1(1);
		}

		[SpecialName]
		public static Struct17 smethod_3(Struct17 it)
		{
			return smethod_0(it, 1);
		}

		[SpecialName]
		public static Struct17 smethod_4(Struct17 it)
		{
			return smethod_1(it, 1);
		}

		public override bool Equals(object obj)
		{
			if (obj is Struct17)
			{
				return CompareTo((Struct17)obj) == 0;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return class533_0.Paragraph.GetHashCode() + (int_0 << 16) + (int_0 >> 16) + int_1;
		}

		public static bool operator ==(Struct17 it1, Struct17 it2)
		{
			return it1.Equals(it2);
		}

		public static bool operator !=(Struct17 it1, Struct17 it2)
		{
			return !it1.Equals(it2);
		}

		[SpecialName]
		public static bool smethod_5(Struct17 it1, Struct17 it2)
		{
			return it1.CompareTo(it2) < 0;
		}

		[SpecialName]
		public static bool smethod_6(Struct17 it1, Struct17 it2)
		{
			return it1.CompareTo(it2) > 0;
		}

		[SpecialName]
		public static bool smethod_7(Struct17 it1, Struct17 it2)
		{
			return it1.CompareTo(it2) <= 0;
		}

		[SpecialName]
		public static bool smethod_8(Struct17 it1, Struct17 it2)
		{
			return it1.CompareTo(it2) >= 0;
		}

		internal static Struct17 smethod_9(Class533 bidiparagraph)
		{
			return new Struct17(bidiparagraph, 0, 0);
		}

		internal static Struct17 smethod_10(Class533 bidiparagraph)
		{
			Paragraph paragraph = bidiparagraph.Paragraph;
			if (paragraph.Portions.Count < 1)
			{
				return smethod_9(bidiparagraph);
			}
			return new Struct17(bidiparagraph, paragraph.Portions.Count - 1, ((Portion)paragraph.Portions[paragraph.Portions.Count - 1]).TextInternal.Length);
		}

		internal static Struct17 smethod_11(Class533 bidiparagraph)
		{
			return smethod_1(smethod_10(bidiparagraph), 1);
		}

		internal static Struct17 smethod_12(Class533 bidiparagraph)
		{
			return new Struct17(bidiparagraph, 0, -1);
		}

		public static string smethod_13(Struct17 begin, Struct17 end)
		{
			if (begin == end)
			{
				return "";
			}
			char[] array = new char[smethod_2(end, begin)];
			int num = 0;
			while (begin != end)
			{
				char currentChar = begin.CurrentChar;
				array[num++] = currentChar;
			}
			return new string(array);
		}

		public static string smethod_14(ref Struct17 current, Struct17 end, out Class1153.Enum177 characterClass, bool forPdf)
		{
			if (current == end)
			{
				characterClass = Class1153.Enum177.const_0;
				return "";
			}
			characterClass = current.CharacterClass;
			Struct17 @struct = current;
			Struct17 struct2 = current;
			bool currentCharRtlState = @struct.CurrentCharRtlState;
			do
			{
				struct2.MoveNext();
			}
			while (struct2.CharacterClass == characterClass && struct2 != end && struct2.CurrentCharRtlState == currentCharRtlState);
			Struct17 it = smethod_1(struct2, 1);
			byte currentCharLigatureInfo = it.CurrentCharLigatureInfo;
			if (currentCharLigatureInfo != 0 && ((uint)currentCharLigatureInfo & (true ? 1u : 0u)) != 0)
			{
				do
				{
					it.MoveNext();
					currentCharLigatureInfo = it.CurrentCharLigatureInfo;
				}
				while (((uint)currentCharLigatureInfo & (true ? 1u : 0u)) != 0);
				struct2 = smethod_0(it, 1);
			}
			char[] array = new char[smethod_2(struct2, current)];
			int commonlength = 0;
			while (current != struct2)
			{
				char currentChar = current.CurrentChar;
				if (Class1153.smethod_15(currentChar))
				{
					current.MoveNext();
					if (current == struct2)
					{
						break;
					}
				}
				array[commonlength++] = currentChar;
				current.MoveNext();
			}
			return Class1153.smethod_7(array, commonlength, @struct.BiDiParagraph.byte_0, @struct.CurrentCharParagraphOffset);
		}

		int IComparable.CompareTo(object obj)
		{
			return CompareTo((Struct17)obj);
		}
	}

	internal struct Struct18
	{
		public Struct17 struct17_0;

		public float float_0;

		public Struct18(Struct17 TabEndIterator, float TabEndX)
		{
			struct17_0 = TabEndIterator;
			float_0 = TabEndX;
		}
	}

	internal sealed class Class536
	{
		internal Paragraph paragraph_0;

		internal Class533 class533_0;

		internal Struct17 struct17_0;

		internal Struct17 struct17_1;

		internal float float_0;

		internal float float_1;

		internal float float_2;

		internal float float_3;

		internal float float_4;

		internal float float_5;

		internal float float_6;

		internal float float_7;

		internal Struct18[] struct18_0;

		internal bool bool_0;

		internal float Top => float_1 - float_6;

		internal float Bottom => float_1 + float_7;

		internal Class536(Class533 bidiparagraph, Struct17 first, Struct17 last, float x, float y, float width, float widthWithHP, float height, float descent, Struct18[] tabEndPositions, bool firstLine)
		{
			class533_0 = bidiparagraph;
			paragraph_0 = bidiparagraph.Paragraph;
			struct17_0 = first;
			struct17_1 = last;
			float_0 = x;
			float_1 = y;
			float_2 = width;
			float_3 = widthWithHP;
			float_4 = height;
			float_6 = height - descent;
			if (float_4 == 0f)
			{
				float_5 = 0f;
			}
			else
			{
				float_5 = float_6 / float_4;
			}
			float_7 = descent;
			struct18_0 = tabEndPositions;
			bool_0 = firstLine;
		}
	}

	private class Class537
	{
		private readonly int[] int_0;

		private readonly float[] float_0;

		public Class537(int[] rangeStarts, float[] rangeWidths)
		{
			int_0 = rangeStarts;
			float_0 = rangeWidths;
		}

		public float method_0(char c)
		{
			int num = Array.BinarySearch(int_0, c);
			if (num < 0)
			{
				num = ~num - 1;
			}
			return float_0[num];
		}

		public string method_1(string str, ref int index)
		{
			int num = index;
			if (index < str.Length)
			{
				float num2 = method_0(str[index]);
				index++;
				if (float.IsNaN(num2))
				{
					while (index < str.Length && float.IsNaN(method_0(str[index])))
					{
						index++;
					}
				}
				else
				{
					while (index < str.Length && num2 == method_0(str[index]))
					{
						index++;
					}
				}
				if (num == 0 && index == str.Length)
				{
					return str;
				}
				return str.Substring(num, index - num);
			}
			return "";
		}
	}

	private class Class538
	{
		public readonly string string_0;

		public readonly int int_0;

		public readonly int int_1;

		public readonly Class151 class151_0;

		public Class538(string text, int begin, int end, Class151 textParam)
		{
			string_0 = text;
			int_0 = begin;
			int_1 = end;
			class151_0 = textParam;
		}
	}

	private delegate string Delegate10(int num);

	internal const float float_0 = 11520f;

	private const float float_1 = 0.112f;

	private const float float_2 = 0.25f;

	private const float float_3 = 0.07f;

	private const float float_4 = 0.13f;

	private const float float_5 = 0.01f;

	private const float float_6 = 0.02f;

	private const float float_7 = 1.6f;

	private static readonly float[] float_8;

	private static readonly float[] float_9;

	private static readonly float[] float_10;

	private static readonly float[] float_11;

	private static readonly float[] float_12;

	private static readonly float[] float_13;

	private static readonly float[] float_14;

	private static readonly float[] float_15;

	private static readonly float[] float_16;

	private static readonly float[] float_17;

	private static readonly float[] float_18;

	private static readonly float[] float_19;

	private static readonly float[] float_20;

	private Class151 class151_0;

	private Portion portion_0;

	internal static readonly char[] char_0;

	private static readonly string[] string_0;

	private static readonly Delegate10[] delegate10_0;

	private static readonly Delegate10 delegate10_1;

	private static readonly char[] char_1;

	private readonly Paragraph[] paragraph_0;

	private float float_21;

	private float float_22;

	private float float_23;

	private float float_24;

	private float float_25;

	private float float_26;

	private float float_27;

	private float float_28 = 1f;

	private float float_29;

	private float float_30;

	private readonly TextAnchorType textAnchorType_0;

	private readonly bool bool_0;

	private readonly int int_0;

	private readonly float float_31;

	private readonly FloatColor floatColor_0;

	private readonly IFontsEffectiveData ifontsEffectiveData_0;

	private readonly FontCollectionIndex fontCollectionIndex_0;

	private Class536[] class536_0;

	private int int_1;

	private readonly int[] int_2;

	private readonly ShapeFrame shapeFrame_0;

	private readonly BaseSlide baseSlide_0;

	private readonly Class159 class159_0 = new Class160(new Bitmap(32, 32), 32f, 32f);

	private readonly bool bool_1;

	private readonly string[] string_1;

	private readonly FontSchemeEffectiveData fontSchemeEffectiveData_0;

	private readonly LoadOptions loadOptions_0;

	internal uint uint_0;

	private bool bool_2;

	private static string[] string_2;

	private static readonly FontData[] fontData_0;

	private static readonly Hashtable hashtable_0;

	internal int int_3;

	[CompilerGenerated]
	private static Converter<string, FontData> converter_0;

	internal float TextHeight => float_26;

	internal float TextHeightWithoutTrailingEmptyLines => float_27;

	internal float TextWidth => float_24;

	internal bool WrapText => bool_1;

	internal float Width => float_23;

	internal bool ContainsSplittedWords => bool_2;

	internal Class532(IParagraphFormat[] cumulativeStyle, ParagraphCollection paragraphs, float width, float height, int columnCount, float columnSpacing, bool wrapText, TextAnchorType anchor, bool anchorCenter, IBaseSlide slide, FloatColor styleColor, IFontsEffectiveData defaultFonts, FontCollectionIndex defaultFontIndex, float fontCoef, float spacingReduction, Class169 rc)
	{
		float_22 = height;
		float_23 = width;
		int_0 = ((columnCount <= 1) ? 1 : columnCount);
		int_2 = new int[int_0];
		int_2[0] = 0;
		float_31 = (float.IsNaN(columnSpacing) ? 0f : columnSpacing);
		float_21 = (width - float_31 * (float)(int_0 - 1)) / (float)int_0;
		bool_1 = wrapText || int_0 > 1;
		IThemeEffectiveData themeEffectiveData = slide.CreateThemeEffective();
		if (themeEffectiveData != null)
		{
			fontSchemeEffectiveData_0 = (FontSchemeEffectiveData)themeEffectiveData.FontScheme;
		}
		if (styleColor == null)
		{
			styleColor = new FloatColor(0f, 0f, 0f);
		}
		floatColor_0 = styleColor;
		ifontsEffectiveData_0 = defaultFonts;
		shapeFrame_0 = new ShapeFrame(0f, 0f, width, height, NullableBool.False, NullableBool.False, 0f);
		baseSlide_0 = (BaseSlide)slide;
		float_28 = fontCoef;
		loadOptions_0 = ((Presentation)slide.Presentation).LoadOptions;
		for (int i = 0; i < cumulativeStyle.Length; i++)
		{
			if (cumulativeStyle[i].DefaultPortionFormat.FillFormat.FillType == FillType.NotDefined)
			{
				cumulativeStyle[i].DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
				cumulativeStyle[i].DefaultPortionFormat.FillFormat.SolidFillColor.Color = styleColor.Color;
			}
		}
		fontCollectionIndex_0 = ((defaultFontIndex == FontCollectionIndex.None) ? FontCollectionIndex.Minor : defaultFontIndex);
		for (int j = 0; j < cumulativeStyle.Length; j++)
		{
			smethod_6((ParagraphFormat)cumulativeStyle[j]);
		}
		Slide slide2 = ((rc != null) ? (rc.RenderingSlide as Slide) : null);
		int_3 = slide2?.SlideNumber ?? 0;
		bool isFieldVisible = true;
		if (slide2 != null && slide2.LayoutSlideInternal != null)
		{
			isFieldVisible = slide2.LayoutSlideInternal.PPTXUnsupportedProps.SlideId != ((HeaderFooterManager)slide.Presentation.HeaderFooterManager).method_5() || ((Presentation)slide.Presentation).PPTXUnsupportedProps.ShowHeaderFooterOnTitles;
		}
		List<Paragraph> list = new List<Paragraph>();
		Paragraph prevParagraph = null;
		for (int k = 0; k < paragraphs.Count; k++)
		{
			Paragraph paragraph = (Paragraph)paragraphs[k];
			list.AddRange(paragraph.method_6(cumulativeStyle[paragraph.ParagraphFormat.Depth], prevParagraph, slide.Presentation, isFieldVisible, int_3));
			prevParagraph = paragraph;
		}
		paragraph_0 = list.ToArray();
		string_1 = method_38();
		textAnchorType_0 = anchor;
		bool_0 = anchorCenter;
		method_3();
		method_0(height, spacingReduction);
		if (bool_0 && int_0 < 2)
		{
			float_29 = (float_23 - float_24) / 2f;
		}
	}

	internal void method_0(float height, float reduction)
	{
		float num = 0f;
		float_24 = 0f;
		Paragraph paragraph = null;
		if (class536_0.Length > 0)
		{
			Class536 @class = class536_0[0];
			paragraph = @class.paragraph_0;
		}
		for (int i = 0; i < class536_0.Length; i++)
		{
			Class536 class2 = class536_0[i];
			Paragraph paragraph2 = class2.paragraph_0;
			float num2 = smethod_14(paragraph2.ParagraphFormat.SpaceWithin, reduction, class2.float_4, 100);
			class2.float_6 = (num2 * 0.888f + class2.float_4 * 0.112f) * class2.float_5;
			class2.float_7 = num2 - class2.float_6;
			num += class2.float_6;
			if (paragraph2 != paragraph)
			{
				float num3 = smethod_14(paragraph2.ParagraphFormat.SpaceBefore, 0f, class2.float_4, 0);
				float num4 = smethod_14(paragraph.ParagraphFormat.SpaceAfter, 0f, class536_0[i - 1].float_4, 0);
				class2.float_6 += num3;
				class536_0[i - 1].float_7 += num4;
				num += num4 + num3;
			}
			class2.float_1 = num;
			num += class2.float_7;
			paragraph = paragraph2;
			if (float_24 < class2.float_2)
			{
				float_24 = class2.float_2;
			}
		}
		float_25 = (bool_0 ? float_24 : float_21);
		bool flag = true;
		for (int j = 0; j < class536_0.Length; j++)
		{
			if (class536_0[j].paragraph_0.ParagraphFormat.Alignment != TextAlignment.Center)
			{
				flag = false;
				break;
			}
		}
		for (int k = 0; k < class536_0.Length; k++)
		{
			Class536 class3 = class536_0[k];
			Paragraph paragraph3 = class3.paragraph_0;
			float num5 = 0f;
			switch (paragraph3.ParagraphFormat.Alignment)
			{
			case TextAlignment.NotDefined:
			case TextAlignment.Left:
				num5 = 0f;
				break;
			case TextAlignment.Center:
				num5 = (float_25 - (flag ? class3.float_3 : class3.float_2)) / 2f;
				break;
			case TextAlignment.Right:
				num5 = float_25 - class3.float_2;
				break;
			}
			class3.float_0 = num5;
		}
		float_22 = height;
		bool flag2 = false;
		if (class536_0.Length > 0 && int_0 > 1)
		{
			Class536 class4 = class536_0[class536_0.Length - 1];
			float num6 = class4.Bottom - class536_0[0].Top;
			float num7 = num6 / (float)int_0;
			if (num7 < float_22)
			{
				num7 = float_22;
			}
			do
			{
				int l = 0;
				float num8 = float.MaxValue;
				for (int m = 0; m < int_0; m++)
				{
					int_2[m] = l;
					if (l >= class536_0.Length)
					{
						continue;
					}
					float top;
					for (top = class536_0[int_2[m]].Top; l < class536_0.Length && !(class536_0[l].Bottom - top >= num7); l++)
					{
					}
					if (l < class536_0.Length)
					{
						float num9 = class536_0[l].Bottom - top - num7;
						if (num9 > 0f && num9 < num8)
						{
							num8 = class536_0[l].Bottom - top - num7;
						}
					}
				}
				if (l < class536_0.Length)
				{
					num7 += num8;
				}
				else
				{
					flag2 = true;
				}
			}
			while (!flag2);
		}
		float_26 = 0f;
		float_27 = 0f;
		for (int n = 0; n < int_0; n++)
		{
			int num10 = int_2[n];
			int num11 = ((n < int_0 - 1) ? int_2[n + 1] : class536_0.Length);
			if (num10 < num11)
			{
				float num12 = class536_0[num11 - 1].Bottom - class536_0[num10].Top;
				if (float_26 < num12)
				{
					float_26 = num12;
				}
			}
			if (int_1 < num11)
			{
				num11 = int_1;
			}
			if (num10 < num11)
			{
				float num13 = class536_0[num11 - 1].Bottom - class536_0[num10].Top;
				if (float_27 < num13)
				{
					float_27 = num13;
				}
			}
		}
		switch (textAnchorType_0)
		{
		case TextAnchorType.Center:
			float_30 = (float_22 - float_26) / 2f;
			break;
		case TextAnchorType.Bottom:
			float_30 = float_22 - float_26;
			break;
		}
	}

	internal void method_1(float fontScale, float spacingReduction)
	{
		float_28 = fontScale;
		method_3();
		method_0(float_22, spacingReduction);
		if (bool_0 && int_0 < 2)
		{
			float_29 = (float_23 - float_24) / 2f;
		}
	}

	private static bool smethod_0(Paragraph paragraph)
	{
		if (paragraph.ParagraphFormat.Bullet.Type > BulletType.None)
		{
			if (paragraph.TextInternal.Length <= 0)
			{
				return paragraph.ParagraphFormatInternal.PPTXUnsupportedProps.SoftParagraph;
			}
			return true;
		}
		return false;
	}

	private float method_2(int paragraphIndex, Portion portion)
	{
		Paragraph paragraph = paragraph_0[paragraphIndex];
		if (smethod_0(paragraph))
		{
			IFontData fontData = null;
			if (paragraph.ParagraphFormat.Bullet.IsBulletHardFont == NullableBool.True)
			{
				fontData = paragraph.ParagraphFormat.Bullet.Font;
			}
			Class151 @class = ((fontData == null) ? method_28(null, portion) : method_37(null, portion, fontData, loadOptions_0.DefaultRegularFont, defaultFontStyle: false));
			if (float.IsNaN(paragraph.ParagraphFormat.Bullet.Height))
			{
				if (paragraph.ParagraphFormat.Bullet.Height < 0f)
				{
					@class.FontHeight = (short)(0f - paragraph.ParagraphFormat.Bullet.Height);
				}
				else
				{
					@class.FontHeight = (short)((float)@class.FontHeight * paragraph.ParagraphFormat.Bullet.Height / 100f + 0.5f);
				}
			}
			if (paragraph.ParagraphFormat.Bullet.Type == BulletType.Picture)
			{
				IPPImage image = ((BulletFormat)paragraph.ParagraphFormat.Bullet).Picture.Image;
				if (image != null)
				{
					float num = @class.method_2(96f).SizeInPoints * 0.7f;
					float bulletWidth = (float)image.Width / (float)image.Height * num;
					return smethod_2(paragraph, bulletWidth);
				}
				return smethod_2(paragraph, 0f);
			}
			string text = string_1[paragraphIndex];
			if (paragraph.ParagraphFormat.RightToLeft == NullableBool.True)
			{
				Class1153.smethod_8(ref text);
			}
			return smethod_2(paragraph, method_12(text, @class).Width);
		}
		return smethod_3(paragraph);
	}

	internal void method_3()
	{
		if (paragraph_0 == null)
		{
			return;
		}
		List<Class536> list = new List<Class536>();
		List<Struct18> list2 = new List<Struct18>();
		bool_2 = false;
		for (int i = 0; i < paragraph_0.Length; i++)
		{
			bool flag = false;
			bool flag2 = false;
			bool firstLine = true;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			Paragraph paragraph = paragraph_0[i];
			Class533 bidiparagraph = new Class533(paragraph);
			Struct17 @struct = Struct17.smethod_9(bidiparagraph);
			Struct17 struct2 = @struct;
			Struct17 struct3 = @struct;
			Struct17 struct4 = @struct;
			Struct17 struct5 = @struct;
			Struct17 paragraphEnd = @struct.ParagraphEnd;
			float num6 = (bool_1 ? float_21 : 11520f);
			float CurrentX = method_2(i, @struct.CurrentPortion);
			float CurrentX2 = CurrentX;
			float beforeTabX = CurrentX;
			float lastTabX = CurrentX;
			TabAlignment tabAlign = TabAlignment.Left;
			Struct17 lastTabIterator = @struct;
			Struct17 struct6 = paragraphEnd;
			float delimeterX = 0f;
			bool flag3 = false;
			do
			{
				bool flag4 = false;
				Struct17 struct7 = struct2.CurrentPortionEnd;
				do
				{
					bool flag5 = false;
					if (flag2)
					{
						struct2.MoveNext();
						struct3 = (struct4 = (struct5 = struct2));
					}
					Struct17 struct8 = struct2;
					if (flag3 && Struct17.smethod_6(struct7, struct6))
					{
						struct7 = struct6;
					}
					float num7;
					float height;
					float descent;
					if (Struct17.smethod_5(struct2, struct7) && struct2.CurrentChar == '\t')
					{
						smethod_5(list2, tabAlign, lastTabIterator, lastTabX, beforeTabX, delimeterX, num6, ref CurrentX2);
						beforeTabX = CurrentX2;
						num7 = method_18(struct2, CurrentX2, out tabAlign);
						Font font = method_28(null, struct2.CurrentPortion).method_1().Font;
						smethod_1(font, out height, out descent);
						lastTabX = CurrentX2 + num7;
						if (tabAlign != 0)
						{
							num7 = 0f;
						}
						struct2.MoveNext();
						lastTabIterator = struct2;
						struct6 = struct2.ParagraphEnd;
						if (tabAlign == TabAlignment.Decimal)
						{
							struct6 = struct2;
							while (Struct17.smethod_5(struct6, struct2.ParagraphEnd) && (struct6.CurrentChar < '0' || struct6.CurrentChar > '9'))
							{
								struct6.MoveNext();
							}
							while (Struct17.smethod_5(struct6, struct2.ParagraphEnd) && ((struct6.CurrentChar >= '0' && struct6.CurrentChar <= '9') || Class1153.smethod_21(struct6.CurrentChar)))
							{
								struct6.MoveNext();
							}
							if (struct6 == struct2.ParagraphEnd)
							{
								tabAlign = TabAlignment.Right;
							}
							else
							{
								flag3 = true;
							}
						}
					}
					else
					{
						if (!Class1153.smethod_4(struct2.CurrentChar) && !struct2.isHyphen)
						{
							while (Struct17.smethod_5(struct2, struct7) && !Class1153.smethod_21(struct2.CurrentChar) && struct2.CurrentChar != '\n' && struct2.CurrentChar != '\v' && struct2.CurrentChar != '\t' && !Class1153.smethod_4(struct2.CurrentChar) && !struct2.isHyphen)
							{
								struct2.MoveNext();
							}
						}
						else
						{
							bool flag6 = Fonts.smethod_0(struct2.CurrentPortion.PortionFormat.LanguageId) == Enum2.const_1;
							struct2.MoveNext();
							flag5 = true;
							if (struct2.Paragraph.ParagraphFormat.HangingPunctuation == NullableBool.True && flag6 && Class1153.smethod_3(struct2.CurrentChar))
							{
								struct2.MoveNext();
							}
						}
						num7 = method_17(struct8, struct2, struct8.CurrentPortion, out height, out descent);
					}
					Struct17 struct9 = struct2;
					num4 = Math.Max(num4, height);
					num5 = Math.Max(num5, descent);
					num3 += num7;
					flag2 = struct2.CurrentChar == '\n' || struct2.CurrentChar == '\v';
					bool flag7 = struct2.CurrentChar == '\n';
					bool flag8 = struct2 == paragraphEnd || flag2;
					flag5 = flag5 || flag8 || Class1153.smethod_21(struct2.CurrentChar) || struct2.CurrentChar == '\t' || Class1153.smethod_4(struct2.CurrentChar) || struct2.isHyphen;
					while (Struct17.smethod_5(struct2, struct7) && Class1153.smethod_21(struct2.CurrentChar))
					{
						struct2.MoveNext();
					}
					if (struct2 == paragraphEnd)
					{
						flag8 = true;
					}
					if (flag3 && struct2 == struct6)
					{
						delimeterX = CurrentX2 + num3;
						struct7 = struct2.CurrentPortionEnd;
						flag3 = false;
					}
					if (CurrentX2 + num3 > num6)
					{
						flag2 = false;
						if (struct3 == struct4)
						{
							Struct17 struct10 = method_19(struct8, struct9, num6 - CurrentX2 - (num3 - num7));
							if (struct3 == struct10)
							{
								struct10.MoveNext();
							}
							struct4 = (struct5 = (struct2 = struct10));
							CurrentX += num3 - num7 + method_16(struct8, struct10, struct8.CurrentPortion);
							num = Math.Max(num, num4);
							num2 = Math.Max(num2, num5);
							num4 = 0f;
							num5 = 0f;
							flag4 = true;
							flag5 = false;
							num3 = 0f;
							bool_2 = true;
						}
						else
						{
							bool flag9 = false;
							if (struct2.Paragraph.ParagraphFormat.HangingPunctuation == NullableBool.True)
							{
								Struct17 begin = Struct17.smethod_1(struct2, 1);
								while (Class1153.smethod_21(begin.CurrentChar) && !begin.IsParagraphBegin)
								{
									begin.method_2();
								}
								if (Class1153.smethod_3(begin.CurrentChar) && !begin.IsParagraphBegin)
								{
									begin.method_2();
									if (begin.CurrentChar > ' ' && !Class1153.smethod_3(begin.CurrentChar))
									{
										begin.MoveNext();
										flag9 = CurrentX2 + num3 + method_16(begin, struct2, begin.CurrentPortion) <= num6;
										flag5 = true;
									}
								}
							}
							if (!flag9)
							{
								flag4 = true;
								struct2 = struct5;
								struct7 = struct2.CurrentPortionEnd;
								num3 = 0f;
								flag5 = false;
							}
						}
					}
					if (flag5)
					{
						num = Math.Max(num, num4);
						num2 = Math.Max(num2, num5);
						num4 = 0f;
						num5 = 0f;
						float num8 = num3 + method_16(struct9, struct2, struct8.CurrentPortion);
						if (flag && struct3 == struct4 && struct8 == struct9)
						{
							struct3 = struct2;
							CurrentX2 = 0f;
							CurrentX = 0f;
							num = 0f;
							num2 = 0f;
						}
						else
						{
							if (Struct17.smethod_5(struct8, struct9))
							{
								CurrentX = CurrentX2 + num3;
							}
							CurrentX2 += num8;
						}
						struct5 = struct2;
						num3 = 0f;
						struct4 = struct9;
						if (flag8)
						{
							flag4 = true;
						}
					}
					if (!flag4)
					{
						continue;
					}
					smethod_5(list2, tabAlign, lastTabIterator, lastTabX, beforeTabX, delimeterX, num6, ref CurrentX);
					float num9 = CurrentX;
					if (bool_1)
					{
						if (struct3 == struct4 && Struct17.smethod_5(struct3, paragraphEnd) && Class1153.smethod_21(struct3.CurrentChar))
						{
							struct4 = Struct17.smethod_0(struct3, 1);
						}
					}
					else
					{
						num9 = Math.Max(num9, CurrentX2);
					}
					float num10 = 0f;
					if (struct3.Paragraph.ParagraphFormat.HangingPunctuation == NullableBool.True)
					{
						Struct17 begin2 = Struct17.smethod_1(struct2, 1);
						if (Class1153.smethod_3(begin2.CurrentChar))
						{
							num10 = method_16(begin2, struct2, begin2.CurrentPortion);
						}
					}
					Struct18[] array = null;
					if (list2.Count > 0)
					{
						array = new Struct18[list2.Count];
						for (int j = 0; j < list2.Count; j++)
						{
							ref Struct18 reference = ref array[j];
							reference = list2[j];
						}
					}
					list2.Clear();
					Class536 item = new Class536(bidiparagraph, struct3, struct2, 0f, 0f, num9 - num10, num9, num, num2, array, firstLine);
					firstLine = flag7;
					list.Add(item);
					num = 0f;
					num2 = 0f;
					struct3 = (struct4 = struct2);
					num3 = 0f;
					CurrentX = (CurrentX2 = paragraph.ParagraphFormat.MarginLeft);
					flag = bool_1 && !flag2;
					flag4 = false;
					tabAlign = TabAlignment.Left;
					lastTabIterator = struct3;
					lastTabX = 0f;
				}
				while (Struct17.smethod_5(struct2, struct7));
			}
			while (Struct17.smethod_5(struct2, paragraphEnd));
		}
		class536_0 = list.ToArray();
		int_1 = class536_0.Length;
		while (int_1 > 0)
		{
			Class536 @class = class536_0[int_1 - 1];
			if (!(@class.struct17_0 != @class.struct17_1))
			{
				int_1--;
				continue;
			}
			break;
		}
	}

	public void method_4(Class159 canvas, Class169 rc)
	{
		Paragraph paragraph = null;
		int bulletIndex = 0;
		Hyperlink currentLink = null;
		FloatColor floatColor = new FloatColor(0f, 0.6f, 0.6f);
		if (class536_0.Length > 0 && baseSlide_0 != null)
		{
			floatColor = baseSlide_0.method_2(SchemeColor.Hyperlink).FColor;
		}
		Class63 linkFill = new Class63(floatColor.Color);
		for (int i = 0; i < int_0; i++)
		{
			int num = ((i < int_0 - 1) ? int_2[i + 1] : class536_0.Length);
			float columnOffsetX = (float_21 + float_31) * (float)i;
			float columnOffsetY = 0f;
			if (int_2[i] < num)
			{
				columnOffsetY = 0f - (class536_0[int_2[i]].float_1 - class536_0[int_2[0]].float_6);
			}
			for (int j = int_2[i]; j < num; j++)
			{
				Class536 @class = class536_0[j];
				bool lastInParagraph = j == class536_0.Length - 1 || @class.paragraph_0 != class536_0[j + 1].paragraph_0;
				Paragraph paragraph2 = @class.paragraph_0;
				try
				{
					if (paragraph2 == paragraph && Struct17.smethod_1(@class.struct17_0, 1).CurrentChar == '\v')
					{
						canvas.vmethod_19();
					}
				}
				catch (IndexOutOfRangeException ex)
				{
					Class1165.smethod_28(ex);
				}
				if (paragraph != paragraph2 && Struct17.smethod_5(@class.struct17_0, @class.struct17_1) && paragraph != null)
				{
					canvas.vmethod_18();
				}
				method_5(canvas, rc, draw: true, @class, columnOffsetX, columnOffsetY, ref currentLink, lastInParagraph, ref bulletIndex, linkFill);
				paragraph = paragraph2;
			}
		}
	}

	private void method_5(Class159 canvas, Class169 rc, bool draw, Class536 line, float columnOffsetX, float columnOffsetY, ref Hyperlink currentLink, bool lastInParagraph, ref int bulletIndex, Class63 linkFill)
	{
		Portion objB = null;
		Class151[] array = new Class151[4];
		Paragraph paragraph = line.paragraph_0;
		bool flag = paragraph.ParagraphFormat.RightToLeft == NullableBool.True;
		Class535 @class = new Class535();
		Struct17 struct17_ = line.struct17_0;
		Struct17 struct17_2 = line.struct17_1;
		PortionFormat portionFormat = (PortionFormat)struct17_.CurrentPortion.PortionFormat;
		TextUnderlineType textUnderlineType = TextUnderlineType.NotDefined;
		IFillFormat fillFormat = portionFormat.UnderlineFillFormat;
		ILineFormat lineFormat = portionFormat.UnderlineLineFormat;
		bool hasShadow;
		Color shadowColor = ((hasShadow = portionFormat.EffectFormat.OuterShadowEffect != null) ? portionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color : Color.Empty);
		float num = 0f;
		int num2 = 0;
		TextStrikethroughType textStrikethroughType = TextStrikethroughType.NotDefined;
		Color color = portionFormat.FillFormat.SolidFillColor.Color;
		Struct17 current = struct17_;
		float num3 = paragraph.ParagraphFormat.MarginLeft;
		if (line.bool_0)
		{
			num3 = smethod_3(paragraph);
			if (smethod_0(paragraph))
			{
				Portion currentPortion = current.CurrentPortion;
				if (paragraph.ParagraphFormat.Bullet.Type == BulletType.Picture)
				{
					try
					{
						PPImage pPImage = (PPImage)((BulletFormat)paragraph.ParagraphFormat.Bullet).Picture.Image;
						float num4 = ((paragraph.ParagraphFormat.Bullet.Height < 0f) ? method_22(0f - paragraph.ParagraphFormat.Bullet.Height) : (method_22(currentPortion.PortionFormat.FontHeight) * paragraph.ParagraphFormat.Bullet.Height / 100f)) * 0.7f;
						float num5 = 0f;
						if (pPImage != null)
						{
							num5 = (float)pPImage.Width / (float)pPImage.Height * num4;
							if (draw)
							{
								canvas.vmethod_21(pPImage, new RectangleF(columnOffsetX + float_29 + line.float_0 + smethod_4(paragraph), columnOffsetY + float_30 + line.float_1 - num4, num5, num4), null);
							}
						}
						num3 = smethod_2(paragraph, num5);
					}
					catch (Exception ex)
					{
						if (!(ex is NullReferenceException) && !(ex is IndexOutOfRangeException))
						{
							throw ex;
						}
						Class1165.smethod_28(ex);
					}
				}
				else
				{
					IFontData fontData = null;
					if (paragraph.ParagraphFormat.Bullet.IsBulletHardFont == NullableBool.True && paragraph.ParagraphFormat.Bullet.Type != BulletType.Numbered)
					{
						fontData = paragraph.ParagraphFormat.Bullet.Font;
					}
					Class151 class2 = ((fontData == null) ? method_28(rc, currentPortion) : method_37(rc, currentPortion, fontData, loadOptions_0.DefaultRegularFont, defaultFontStyle: false));
					if (!float.IsNaN(paragraph.ParagraphFormat.Bullet.Height))
					{
						if (paragraph.ParagraphFormat.Bullet.Height < 0f)
						{
							class2.FontHeight = (short)(0f - paragraph.ParagraphFormat.Bullet.Height);
						}
						else
						{
							class2.FontHeight = (short)((float)class2.FontHeight * paragraph.ParagraphFormat.Bullet.Height / 100f + 0.5f);
						}
					}
					class2.FontUnderline = false;
					if (paragraph.ParagraphFormat.Bullet.IsBulletHardColor == NullableBool.True)
					{
						class2.FontColor = ((ColorFormat)paragraph.ParagraphFormat.Bullet.Color).method_5(baseSlide_0, floatColor_0);
					}
					else
					{
						class2.FontFill = new Class63(new Class67(shapeFrame_0, canvas.Transform, null, baseSlide_0, rc), new Class493(currentPortion.PortionFormat.FillFormat, floatColor_0));
					}
					string text = string_1[bulletIndex];
					if (flag)
					{
						Class1153.smethod_8(ref text);
					}
					SizeF sizeF = method_12(text, class2);
					num3 = smethod_2(paragraph, sizeF.Width);
					float num6 = columnOffsetX + float_29 + line.float_0 + smethod_4(paragraph);
					if (flag)
					{
						num6 = line.float_0 + line.float_2 - (num6 - line.float_0) - sizeF.Width;
					}
					if (draw)
					{
						method_9(canvas, text, new RectangleF(num6, columnOffsetY + float_30 + line.float_1, sizeF.Width, sizeF.Height), class2);
					}
				}
			}
			bulletIndex++;
		}
		float num7 = num3;
		float num8 = num3;
		Struct17 @struct = struct17_2;
		float num9 = 0f;
		float num10 = 0f;
		if (paragraph.ParagraphFormat.Alignment == TextAlignment.Justify && !lastInParagraph)
		{
			@struct = current;
			Struct17 struct2 = current;
			while (Struct17.smethod_5(struct2, struct17_2))
			{
				char currentChar = struct2.CurrentChar;
				struct2.MoveNext();
				if (currentChar == '\t')
				{
					@struct = struct2;
				}
			}
			struct2 = @struct;
			int num11 = 0;
			float num12 = 0f;
			while (Struct17.smethod_5(struct2, struct17_2))
			{
				if (Class1153.smethod_21(struct2.CurrentChar))
				{
					num11++;
					num12 += struct2.CurrentPortion.PortionFormat.FontHeight;
				}
				struct2.MoveNext();
			}
			if (num11 > 0)
			{
				num9 = (float_25 - (line.float_2 + line.float_0)) * 0.75f / (float)num11;
				num10 = (float_25 - (line.float_2 + line.float_0)) * 0.25f / num12;
			}
		}
		float num13 = line.float_0;
		Class162 class3 = canvas as Class162;
		while (Struct17.smethod_5(current, struct17_2))
		{
			Struct17 struct3 = current.CurrentPortionEnd;
			if (Struct17.smethod_6(struct3, struct17_2))
			{
				struct3 = struct17_2;
			}
			Portion currentPortion2 = current.CurrentPortion;
			if ((Hyperlink)currentPortion2.PortionFormat.HyperlinkClick != currentLink)
			{
				if (currentLink != null)
				{
					canvas.vmethod_15();
				}
				currentLink = (Hyperlink)currentPortion2.PortionFormat.HyperlinkClick;
				if (currentLink != null)
				{
					canvas.vmethod_14(currentLink);
				}
			}
			if (draw)
			{
				smethod_15(currentPortion2.PortionFormat, out var underlineType, out var lineFormat2, out var fillFormat2);
				if (underlineType != textUnderlineType || lineFormat2 != lineFormat || fillFormat2 != fillFormat)
				{
					method_7(canvas, rc, textUnderlineType, num2, num, fillFormat, lineFormat, linkFill, float_29 + columnOffsetX + num13 + num7, float_29 + columnOffsetX + num13 + num3, float_30 + columnOffsetY + line.float_1, hasShadow, shadowColor);
					textUnderlineType = underlineType;
					fillFormat = fillFormat2;
					lineFormat = lineFormat2;
					num7 = num3;
				}
			}
			if (draw)
			{
				smethod_16(currentPortion2.PortionFormat, out var strikethroughType, out var strikethroughColor);
				if (strikethroughType != textStrikethroughType || strikethroughColor != color)
				{
					method_8(canvas, rc, textStrikethroughType, num2, num, color, float_29 + columnOffsetX + num13 + num8, float_29 + columnOffsetX + num13 + num3, float_30 + columnOffsetY + line.float_1, hasShadow);
					textStrikethroughType = strikethroughType;
					color = strikethroughColor;
					num8 = num3;
				}
			}
			if (textUnderlineType > TextUnderlineType.None || textStrikethroughType > TextStrikethroughType.None)
			{
				num2 = 0;
				num = 0f;
			}
			while (current != struct3 && current.CurrentChar == '\t')
			{
				current.MoveNext();
				TabAlignment tabAlign;
				float num14 = method_18(current, num3, out tabAlign);
				if (tabAlign != 0 && line.struct18_0 != null)
				{
					int i;
					for (i = 0; i < line.struct18_0.Length && Struct17.smethod_5(line.struct18_0[i].struct17_0, current); i++)
					{
					}
					if (i < line.struct18_0.Length && line.struct18_0[i].struct17_0 == current)
					{
						num3 = line.struct18_0[i].float_0;
						continue;
					}
				}
				num3 += num14;
			}
			Struct17 struct4 = current;
			bool flag2 = Struct17.smethod_8(current, @struct);
			if (class3 != null)
			{
				if (Struct17.smethod_5(struct4, struct3) && struct4.CurrentChar != '\t')
				{
					struct4.MoveNext();
				}
			}
			else if (flag2)
			{
				struct4 = struct3;
			}
			else
			{
				while (Struct17.smethod_5(struct4, struct3) && struct4.CurrentChar != '\t')
				{
					struct4.MoveNext();
				}
			}
			struct3 = struct4;
			Struct17 struct5 = struct3;
			if (flag2)
			{
				struct5 = current;
			}
			do
			{
				if (Struct17.smethod_7(struct5, current))
				{
					while (Struct17.smethod_5(struct5, struct3) && !Class1153.smethod_21(struct5.CurrentChar))
					{
						struct5.MoveNext();
					}
					if (Struct17.smethod_5(struct5, struct3))
					{
						struct5.MoveNext();
					}
				}
				bool flag3 = current.CurrentCharRtlState || current.CurrentRunRtlState;
				Class1153.Enum177 characterClass;
				string text2 = Struct17.smethod_14(ref current, struct5, out characterClass, canvas is Class164);
				if (line.paragraph_0 != null && line.paragraph_0.Text == "\t")
				{
					text2 = " ";
				}
				if (currentPortion2.PortionFormat.TextCapType == TextCapType.All)
				{
					text2 = text2.ToUpper();
				}
				if (!object.ReferenceEquals(currentPortion2, objB))
				{
					Array.Clear(array, 0, array.Length);
					objB = currentPortion2;
				}
				int num15 = (int)characterClass;
				bool flag4 = currentPortion2.PortionFormat.HyperlinkClick != null || currentPortion2.PortionFormat.HyperlinkMouseOver != null;
				if (array[num15] == null)
				{
					switch (characterClass)
					{
					case Class1153.Enum177.const_0:
						array[num15] = method_28(rc, currentPortion2);
						if (flag4)
						{
							array[num15].FontFill = linkFill;
						}
						break;
					case Class1153.Enum177.const_1:
						array[num15] = method_29(rc, currentPortion2);
						if (flag4)
						{
							array[(uint)characterClass].FontFill = linkFill;
						}
						break;
					case Class1153.Enum177.const_2:
						array[num15] = method_30(rc, currentPortion2);
						if (flag4)
						{
							array[num15].FontFill = linkFill;
						}
						break;
					case Class1153.Enum177.const_3:
						array[num15] = method_31(rc, currentPortion2);
						if (flag4)
						{
							array[num15].FontFill = linkFill;
						}
						break;
					}
				}
				Class151 class4 = array[num15];
				if (hasShadow = class4.FontShadow)
				{
					shadowColor = class4.ShadowColor;
				}
				PointF location = new PointF(float_29 + columnOffsetX + num13 + num3, float_30 + columnOffsetY + line.float_1);
				SizeF size = method_12(text2, class4);
				if (flag)
				{
					float x = line.float_0 + line.float_2 - (location.X - line.float_0) - size.Width;
					location = new PointF(x, location.Y);
				}
				num2 += text2.Length;
				num += (float)text2.Length * currentPortion2.PortionFormat.FontHeight;
				if (flag != flag3)
				{
					if (draw && (!(current == struct17_2) || !(text2 == " ")))
					{
						@class.method_0(new Class534(text2, new RectangleF(location, size), class4));
					}
				}
				else
				{
					if (@class.NotEmpty)
					{
						@class.method_1(canvas, this, flag);
					}
					if (draw)
					{
						method_9(canvas, text2, new RectangleF(location, size), class4);
					}
				}
				num3 += size.Width;
				if (current == struct5 && Struct17.smethod_5(current, struct3))
				{
					num3 += num9 + num10 * currentPortion2.PortionFormat.FontHeight;
				}
				if (currentLink != null && current == struct3)
				{
					canvas.vmethod_15();
					currentLink = null;
				}
			}
			while (Struct17.smethod_5(current, struct3));
		}
		if (@class.NotEmpty)
		{
			@class.method_1(canvas, this, flag);
		}
		if (!draw || (textUnderlineType <= TextUnderlineType.None && textStrikethroughType <= TextStrikethroughType.None))
		{
			return;
		}
		Class151 class5 = method_28(rc, line.struct17_0.CurrentPortion);
		float num16 = (float)(class5.FontHeight * class5.Escapement) / 100f;
		float num17 = float_29 + columnOffsetX + num13 + num3;
		if (textUnderlineType > TextUnderlineType.None)
		{
			float num18 = float_29 + columnOffsetX + num13 + num7;
			if (num17 - num18 > float_23)
			{
				num17 = num18 + float_23;
			}
			method_7(canvas, rc, textUnderlineType, num2, num, fillFormat, lineFormat, linkFill, num18, num17, float_30 + columnOffsetY + line.float_1 - num16, hasShadow, shadowColor);
		}
		if (textStrikethroughType > TextStrikethroughType.None)
		{
			float num18 = float_29 + columnOffsetX + num13 + num8;
			if (num17 - num18 > float_23)
			{
				num17 = num18 + float_23;
			}
			method_8(canvas, rc, textStrikethroughType, num2, num, color, num18, num17, float_30 + columnOffsetY + line.float_1 - num16, hasShadow);
		}
	}

	private void method_6(Class159 canvas, Class169 rc, float penWidth, float[] compoundArray, float[] dashPattern, float waveLength, IFillFormat lineFill, ILineFormat lineFormat, Class63 defaultFill, float startX, float endX, float y)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		Pen pen = new Pen(Color.Black, penWidth);
		if (compoundArray != null)
		{
			pen.CompoundArray = compoundArray;
		}
		if (dashPattern != null)
		{
			pen.DashPattern = dashPattern;
		}
		if (float.IsNaN(waveLength))
		{
			graphicsPath.AddLine(startX, y, endX, y);
		}
		else
		{
			float num = startX;
			float num2 = waveLength / 2f;
			for (float num3 = waveLength * 2f; num < endX; num += num3)
			{
				graphicsPath.AddLine(num, y - num2, num + waveLength, y + num2);
				graphicsPath.AddLine(num + waveLength, y + num2, num + num3, y - num2);
			}
		}
		graphicsPath.Widen(pen);
		Class63 fillParam = defaultFill;
		if (lineFill != null)
		{
			fillParam = new Class63(new Class67(shapeFrame_0, canvas.Transform, null, baseSlide_0, rc), new Class493(lineFill, floatColor_0));
		}
		canvas.vmethod_5(graphicsPath, (lineFormat == null || lineFormat.FillFormat.FillType <= FillType.NoFill) ? null : new Class66(new Class67(shapeFrame_0, canvas.Transform, null, baseSlide_0, rc), new Class512(lineFormat, floatColor_0)), fillParam);
	}

	private void method_7(Class159 canvas, Class169 rc, TextUnderlineType underlineType, int underlinePortionCharCount, float underlinePortionHeightSum, IFillFormat underlineFill, ILineFormat underlineLine, Class63 defaultFill, float startX, float endX, float y, bool hasShadow, Color shadowColor)
	{
		if (underlineType > TextUnderlineType.None && underlinePortionCharCount > 0)
		{
			float num = underlinePortionHeightSum / (float)underlinePortionCharCount;
			if (hasShadow)
			{
				PointF pointF = canvas.method_8();
				float num2 = pointF.X * num / 15f;
				float num3 = pointF.Y * num / 15f;
				method_7(canvas, rc, underlineType, underlinePortionCharCount, underlinePortionHeightSum, null, underlineLine, new Class63(shadowColor), startX + num2, endX + num2, y + num3, hasShadow: false, Color.Empty);
			}
			float num4 = num / 20f;
			float[] compoundArray = null;
			float[] dashPattern = null;
			float waveLength = float.NaN;
			switch (underlineType)
			{
			case TextUnderlineType.Words:
			case TextUnderlineType.Single:
				num4 = num * 0.07f;
				break;
			case TextUnderlineType.Double:
				num4 = num * 0.13f;
				compoundArray = float_18;
				break;
			case TextUnderlineType.Heavy:
				num4 = num * 0.13f;
				break;
			case TextUnderlineType.Dotted:
				num4 = num * 0.07f;
				dashPattern = float_8;
				break;
			case TextUnderlineType.HeavyDotted:
				num4 = num * 0.13f;
				dashPattern = float_9;
				break;
			case TextUnderlineType.Dashed:
				num4 = num * 0.07f;
				dashPattern = float_10;
				break;
			case TextUnderlineType.HeavyDashed:
				num4 = num * 0.13f;
				dashPattern = float_11;
				break;
			case TextUnderlineType.LongDashed:
				num4 = num * 0.07f;
				dashPattern = float_12;
				break;
			case TextUnderlineType.HeavyLongDashed:
				num4 = num * 0.13f;
				dashPattern = float_13;
				break;
			case TextUnderlineType.DotDash:
				num4 = num * 0.07f;
				dashPattern = float_14;
				break;
			case TextUnderlineType.HeavyDotDash:
				num4 = num * 0.13f;
				dashPattern = float_15;
				break;
			case TextUnderlineType.DotDotDash:
				num4 = num * 0.07f;
				dashPattern = float_16;
				break;
			case TextUnderlineType.HeavyDotDotDash:
				num4 = num * 0.13f;
				dashPattern = float_17;
				break;
			case TextUnderlineType.Wavy:
				num4 = num * 0.01f;
				waveLength = num * 0.13f - num4;
				break;
			case TextUnderlineType.HeavyWavy:
				num4 = num * 0.02f;
				waveLength = num * 0.13f - num4;
				break;
			case TextUnderlineType.DoubleWavy:
				num4 = num * 0.07f;
				compoundArray = float_19;
				waveLength = num * 0.13f - num4;
				break;
			}
			y += num / 10f;
			method_6(canvas, rc, num4, compoundArray, dashPattern, waveLength, underlineFill, underlineLine, defaultFill, startX, endX, y);
		}
	}

	private void method_8(Class159 canvas, Class169 rc, TextStrikethroughType strikethroughType, int portionCharCount, float linePortionHeightSum, Color lineColor, float startX, float endX, float y, bool hasShadow)
	{
		if (strikethroughType >= TextStrikethroughType.Single)
		{
			FillFormat fillFormat = new FillFormat(null);
			fillFormat.FillType = FillType.Solid;
			fillFormat.SolidFillColor.Color = lineColor;
			LineFormat lineFormat = new LineFormat(null);
			lineFormat.FillFormat.FillType = FillType.Solid;
			lineFormat.FillFormat.SolidFillColor.Color = lineColor;
			float num = linePortionHeightSum / (float)portionCharCount;
			if (hasShadow)
			{
				PointF pointF = canvas.method_8();
				float num2 = pointF.X * num / 15f;
				float num3 = pointF.Y * num / 15f;
				method_8(canvas, rc, strikethroughType, portionCharCount, linePortionHeightSum, lineColor, startX + num2, endX + num2, y + num3, hasShadow: false);
			}
			float penWidth = float.NaN;
			float[] compoundArray = null;
			switch (strikethroughType)
			{
			case TextStrikethroughType.Single:
				penWidth = num * 0.07f;
				break;
			case TextStrikethroughType.Double:
				penWidth = num * 0.07f * 3f;
				compoundArray = float_20;
				break;
			}
			y -= num / 4f;
			method_6(canvas, rc, penWidth, compoundArray, null, float.NaN, fillFormat, lineFormat, new Class63(lineColor), startX, endX, y);
		}
	}

	private void method_9(Class159 canvas, string text, RectangleF target, Class151 textParam)
	{
		Class733 @class = textParam.method_1();
		int num = @class.method_0(text, 0, text.Length);
		if (num == text.Length)
		{
			method_11(canvas, text, target, textParam);
			return;
		}
		string[] array = (@class.Available ? @class.method_2(text[num], (Enum1)@class.Font.GdiCharSet, textParam.FontPitchAndFamily, @class.Panose) : @class.method_2(text[num], textParam.FontCharset, textParam.FontPitchAndFamily, textParam.FontPanose));
		bool flag = !string.IsNullOrEmpty(textParam.DefaultFontName);
		Class151[] array2 = new Class151[array.Length + ((!flag) ? 1 : 2)];
		if (array.Length > 0)
		{
			Class54.smethod_1(textParam.FontName, array[0]);
			Class54.smethod_0(loadOptions_0, new FontData(textParam.FontName), Array.ConvertAll(array, (string typeface) => new FontData(typeface)));
		}
		array2[0] = textParam;
		if (flag)
		{
			array2[array2.Length - 1] = (Class151)textParam.Clone();
			array2[array2.Length - 1].FontName = textParam.DefaultFontName;
		}
		int i = 0;
		int num2 = 0;
		float num3 = 0f;
		while (num2 < text.Length)
		{
			for (; i < text.Length && text[i] != '\u202e' && text[i] != '\u202d'; i++)
			{
			}
			if (num2 < i)
			{
				num3 += method_10(canvas, text, 0, num2, i - num2, new RectangleF(target.X + num3, target.Y, target.Width - num3, target.Height), 0, array2, array, null);
			}
			num2 = i;
			for (; i < text.Length && text[i] != '\u202c'; i++)
			{
			}
			if (i < text.Length)
			{
				i++;
			}
			if (num2 < i)
			{
				List<Class538> list = new List<Class538>();
				method_10(canvas, text, (text[num2] != '\u202e') ? 1 : (-1), num2 + 1, i - num2 - 2, target, 0, array2, array, list);
				num2 = i;
				while (list.Count > 0)
				{
					Class538 class2 = list[list.Count - 1];
					list.RemoveAt(list.Count - 1);
					string text2 = $"\u202e{class2.string_0.Substring(class2.int_0, class2.int_1 - class2.int_0)}\u202c";
					SizeF sizeF = method_15(text2, array2[0]);
					method_11(canvas, text2, new RectangleF(target.X + num3, target.Y, target.Width - num3, target.Height), class2.class151_0);
					num3 += sizeF.Width;
				}
			}
		}
	}

	private float method_10(Class159 canvas, string text, int forcedDirection, int startIndex, int length, RectangleF target, int textParamIndex, Class151[] textParamCache, string[] substituteNames, List<Class538> rtlRenderOpsStack)
	{
		Class151 @class = textParamCache[textParamIndex];
		if (@class == null)
		{
			@class = (textParamCache[textParamIndex] = (Class151)textParamCache[0].Clone());
			@class.FontName = substituteNames[textParamIndex - 1];
		}
		Class733 class2 = @class.method_1();
		int num = startIndex + length;
		float num2 = target.X;
		float num3 = 0f;
		while (startIndex < num)
		{
			int num4 = class2.method_0(text, startIndex, num - startIndex);
			if (startIndex < num4)
			{
				if (startIndex > 0 && text[startIndex - 1] == '\u200d')
				{
					startIndex--;
				}
				if (forcedDirection == 0)
				{
					string text2 = text.Substring(startIndex, num4 - startIndex);
					SizeF sizeF = method_15(text2, @class);
					num3 += sizeF.Width;
					method_11(canvas, text2, new RectangleF(num2, target.Y, sizeF.Width, target.Height), @class);
					num2 += sizeF.Width;
				}
				else if (forcedDirection > 0)
				{
					string text3 = $"\u202d{text.Substring(startIndex, num4 - startIndex)}\u202c";
					SizeF sizeF2 = method_15(text3, @class);
					num3 += sizeF2.Width;
					method_11(canvas, text3, new RectangleF(num2, target.Y, sizeF2.Width, target.Height), @class);
					num2 += sizeF2.Width;
				}
				else
				{
					rtlRenderOpsStack.Add(new Class538(text, startIndex, num4, @class));
				}
				startIndex = num4;
			}
			if (startIndex < num)
			{
				num4 = class2.method_1(text, startIndex, num - startIndex);
				if (textParamIndex + 1 < textParamCache.Length)
				{
					float num5 = method_10(canvas, text, forcedDirection, startIndex, num4 - startIndex, new RectangleF(num2, target.Y, target.Width - num3, target.Height), textParamIndex + 1, textParamCache, substituteNames, rtlRenderOpsStack);
					num2 += num5;
					num3 += num5;
				}
				else if (forcedDirection == 0)
				{
					string text4 = text.Substring(startIndex, num4 - startIndex);
					SizeF sizeF3 = method_15(text4, textParamCache[0]);
					num3 += sizeF3.Width;
					method_11(canvas, text4, new RectangleF(num2, target.Y, sizeF3.Width, target.Height), @class);
					num2 += sizeF3.Width;
				}
				else if (forcedDirection > 0)
				{
					string text5 = $"\u202d{text.Substring(startIndex, num4 - startIndex)}\u202c";
					SizeF sizeF4 = method_15(text5, textParamCache[0]);
					num3 += sizeF4.Width;
					method_11(canvas, text5, new RectangleF(num2, target.Y, sizeF4.Width, target.Height), @class);
					num2 += sizeF4.Width;
				}
				else
				{
					rtlRenderOpsStack.Add(new Class538(text, startIndex, num4, @class));
				}
				startIndex = num4;
			}
		}
		return num3;
	}

	private void method_11(Class159 canvas, string text, RectangleF target, Class151 textParam)
	{
		Class537 @class = (Class537)hashtable_0[textParam.FontName];
		float num = target.X;
		if (@class != null)
		{
			int index = 0;
			while (index < text.Length)
			{
				string text2 = @class.method_1(text, ref index);
				float num2 = @class.method_0(text2[0]) * textParam.FFontHeight;
				Class151 class2 = textParam;
				if (!float.IsNaN(num2))
				{
					class2 = (Class151)textParam.Clone();
					class2.ForcedWidth = num2;
				}
				SizeF sizeF = class159_0.method_6(text2, new PointF(0f, 0f), class2);
				canvas.vmethod_13(text2, new RectangleF(num, target.Y, sizeF.Width, target.Height), class2);
				num += sizeF.Width;
			}
		}
		else
		{
			canvas.vmethod_13(text, target, textParam);
		}
	}

	private SizeF method_12(string text, Class151 textParam)
	{
		float descent;
		return method_13(text, textParam, out descent);
	}

	private SizeF method_13(string text, Class151 textParam, out float descent)
	{
		Class733 @class = textParam.method_1();
		int num = @class.method_0(text, 0, text.Length);
		if (num == text.Length)
		{
			smethod_1(@class.Font, out var height, out descent);
			return new SizeF(method_15(text, textParam).Width, height);
		}
		descent = 0f;
		string[] array = (@class.Available ? @class.method_2(text[num], (Enum1)@class.Font.GdiCharSet, textParam.FontPitchAndFamily, @class.Panose) : @class.method_2(text[num], textParam.FontCharset, textParam.FontPitchAndFamily, textParam.FontPanose));
		bool flag = !string.IsNullOrEmpty(textParam.DefaultFontName);
		Class151[] array2 = new Class151[array.Length + ((!flag) ? 1 : 2)];
		array2[0] = textParam;
		if (flag)
		{
			array2[array2.Length - 1] = (Class151)textParam.Clone();
			array2[array2.Length - 1].FontName = textParam.DefaultFontName;
		}
		int i = 0;
		int num2 = 0;
		float num3 = 0f;
		float height2 = 0f;
		while (num2 < text.Length)
		{
			for (; i < text.Length && text[i] != '\u202e' && text[i] != '\u202d'; i++)
			{
			}
			if (num2 < i)
			{
				SizeF sizeF = method_14(text, num2, i - num2, 0, array2, array);
				num3 += sizeF.Width;
				if (sizeF.Height > height2)
				{
					height2 = sizeF.Height;
				}
			}
			num2 = i;
			for (; i < text.Length && text[i] != '\u202c'; i++)
			{
			}
			if (i < text.Length)
			{
				i++;
			}
			if (num2 < i)
			{
				SizeF sizeF2 = method_14(text, num2 + 1, i - num2 - 2, 0, array2, array);
				num3 += sizeF2.Width;
				if (sizeF2.Height > height2)
				{
					height2 = sizeF2.Height;
				}
				num2 = i;
			}
		}
		i = 0;
		while (true)
		{
			if (i < array2.Length)
			{
				if (array2[i] != null)
				{
					@class = array2[i].method_1();
					if (@class.Available)
					{
						break;
					}
				}
				i++;
				continue;
			}
			smethod_1(textParam.method_1().Font, out height2, out descent);
			return new SizeF(num3, height2);
		}
		smethod_1(@class.Font, out height2, out descent);
		return new SizeF(num3, height2);
	}

	private SizeF method_14(string text, int startIndex, int length, int textParamIndex, Class151[] textParamCache, string[] substituteNames)
	{
		Class151 @class = textParamCache[textParamIndex];
		if (@class == null)
		{
			@class = (textParamCache[textParamIndex] = (Class151)textParamCache[0].Clone());
			@class.FontName = substituteNames[textParamIndex - 1];
		}
		Class733 class2 = @class.method_1();
		int num = startIndex + length;
		float num2 = 0f;
		float height = 0f;
		while (startIndex < num)
		{
			int num3 = class2.method_0(text, startIndex, num - startIndex);
			if (startIndex < num3)
			{
				string str = text.Substring(startIndex, num3 - startIndex);
				num2 += method_15(str, @class).Width;
				startIndex = num3;
			}
			if (startIndex < num)
			{
				num3 = class2.method_1(text, startIndex, num - startIndex);
				if (textParamIndex + 1 < textParamCache.Length)
				{
					num2 += method_14(text, startIndex, num3 - startIndex, textParamIndex + 1, textParamCache, substituteNames).Width;
				}
				else
				{
					string str2 = text.Substring(startIndex, num3 - startIndex);
					num2 += method_15(str2, textParamCache[0]).Width;
				}
				startIndex = num3;
			}
		}
		return new SizeF(num2, height);
	}

	private SizeF method_15(string str, Class151 currentTextParam)
	{
		Class537 @class = ((currentTextParam.FontName != null) ? ((Class537)hashtable_0[currentTextParam.FontName]) : null);
		if (@class != null)
		{
			SizeF result = new SizeF(0f, 0f);
			int index = 0;
			while (index < str.Length)
			{
				string text = @class.method_1(str, ref index);
				float num = @class.method_0(text[0]) * currentTextParam.FFontHeight;
				Class151 class2 = currentTextParam;
				if (!float.IsNaN(num))
				{
					class2 = (Class151)currentTextParam.Clone();
					class2.ForcedWidth = num;
				}
				SizeF sizeF = class159_0.method_6(text, new PointF(0f, 0f), class2);
				result.Width += sizeF.Width;
				result.Height = Math.Max(result.Height, sizeF.Height);
			}
			return result;
		}
		return class159_0.method_6(str, new PointF(0f, 0f), currentTextParam);
	}

	private float method_16(Struct17 begin, Struct17 end, Portion portion)
	{
		float height;
		return method_17(begin, end, portion, out height, out height);
	}

	private float method_17(Struct17 begin, Struct17 end, Portion portion, out float height, out float descent)
	{
		Class151 @class = null;
		Class151 class2 = null;
		Class151 class3 = null;
		Class151 class4 = null;
		float num = 0f;
		descent = 0f;
		height = num;
		float num2 = 0f;
		do
		{
			Class1153.Enum177 characterClass;
			string text = ((portion.PortionFormat.TextCapType != TextCapType.All) ? Struct17.smethod_14(ref begin, end, out characterClass, forPdf: false) : Struct17.smethod_14(ref begin, end, out characterClass, forPdf: false).ToUpper());
			Class151 textParam;
			switch (characterClass)
			{
			default:
				if (@class == null)
				{
					@class = method_28(null, portion);
				}
				textParam = @class;
				break;
			case Class1153.Enum177.const_1:
				if (class2 == null)
				{
					class2 = method_29(null, portion);
				}
				textParam = class2;
				break;
			case Class1153.Enum177.const_2:
				if (class3 == null)
				{
					class3 = method_30(null, portion);
				}
				textParam = class3;
				break;
			case Class1153.Enum177.const_3:
				if (class4 == null)
				{
					class4 = method_31(null, portion);
				}
				textParam = class4;
				break;
			}
			float descent2;
			SizeF sizeF = method_13(text, textParam, out descent2);
			if (height < sizeF.Height)
			{
				height = sizeF.Height;
			}
			if (descent < descent2)
			{
				descent = descent2;
			}
			num2 += sizeF.Width;
		}
		while (Struct17.smethod_5(begin, end));
		return num2;
	}

	internal static void smethod_1(Font font, out float height, out float descent)
	{
		FontFamily fontFamily = font.FontFamily;
		height = font.SizeInPoints * 1.6f;
		float num = fontFamily.GetCellAscent(font.Style);
		float num2 = fontFamily.GetCellDescent(font.Style);
		float num3 = num + num2;
		descent = height * num2 / num3;
	}

	private float method_18(Struct17 tabIterator, float position, out TabAlignment tabAlign)
	{
		Paragraph paragraph = tabIterator.Paragraph;
		tabAlign = TabAlignment.Left;
		ITabCollection tabs = tabIterator.Paragraph.ParagraphFormat.Tabs;
		float num = ((tabIterator.Paragraph.ParagraphFormat.DefaultTabSize <= 0f) ? 1E-05f : tabIterator.Paragraph.ParagraphFormat.DefaultTabSize);
		if (tabs == null)
		{
			if (position < paragraph.ParagraphFormat.MarginLeft)
			{
				return paragraph.ParagraphFormat.MarginLeft + paragraph.ParagraphFormat.Indent - position;
			}
			return (float)Math.Floor(1f + position / num) * num - position;
		}
		int i = 0;
		if (tabs.Count > 0 && (tabs[0].Position != 0.0 || position != 0f))
		{
			for (; i < tabs.Count && !((float)tabs[i].Position > position + 1E-05f); i++)
			{
			}
		}
		if (i < tabs.Count)
		{
			if (position < paragraph.ParagraphFormat.MarginLeft && tabs[i].Position > (double)paragraph.ParagraphFormat.MarginLeft)
			{
				return paragraph.ParagraphFormat.MarginLeft - position;
			}
			tabAlign = tabs[i].Alignment;
			if (tabs[i].Position == 0.0 && position == 0f)
			{
				return float.Epsilon;
			}
			return (float)(tabs[i].Position - (double)position);
		}
		if (i > 0 && i == tabs.Count && Math.Round(tabs[i - 1].Position) >= Math.Round(position))
		{
			return (float)(tabs[i - 1].Position - (double)position);
		}
		if (position < paragraph.ParagraphFormat.MarginLeft)
		{
			return paragraph.ParagraphFormat.MarginLeft - position;
		}
		return (float)Math.Floor(1f + position / num) * num - position;
	}

	private Struct17 method_19(Struct17 begin, Struct17 end, float width)
	{
		Portion currentPortion = begin.CurrentPortion;
		bool flag = begin.Paragraph.ParagraphFormat.HangingPunctuation == NullableBool.True;
		Class151 textParam = method_28(null, currentPortion);
		Struct17 @struct = begin;
		bool flag2 = false;
		if (Struct17.smethod_5(@struct, end) && @struct.CurrentChar == '\t')
		{
			@struct.MoveNext();
		}
		while (Struct17.smethod_5(@struct, end))
		{
			width -= method_12(new string(@struct.CurrentChar, 1), textParam).Width;
			bool flag3 = flag && Class1153.smethod_3(@struct.CurrentChar);
			if (width < 0f)
			{
				if (!flag3)
				{
					break;
				}
				if (flag2)
				{
					@struct.method_2();
					break;
				}
			}
			flag2 = flag3;
			@struct.MoveNext();
		}
		return @struct;
	}

	internal string GetFontName(IFontData fontdata)
	{
		if (fontdata == null)
		{
			return "Arial";
		}
		string text = fontdata.FontName;
		if (string.IsNullOrEmpty(text))
		{
			return "Arial";
		}
		if (text[0] == '+')
		{
			IFontData fontData = null;
			switch (text)
			{
			case "+mj-cs":
				fontData = fontSchemeEffectiveData_0.Major.ComplexScriptFont;
				break;
			case "+mj-ea":
				fontData = fontSchemeEffectiveData_0.Major.EastAsianFont;
				break;
			case "+mj-lt":
				fontData = fontSchemeEffectiveData_0.Major.LatinFont;
				break;
			case "+mn-cs":
				fontData = fontSchemeEffectiveData_0.Minor.ComplexScriptFont;
				break;
			case "+mn-ea":
				fontData = fontSchemeEffectiveData_0.Minor.EastAsianFont;
				break;
			case "+mn-lt":
				fontData = fontSchemeEffectiveData_0.Minor.LatinFont;
				break;
			}
			text = ((fontData != null) ? fontData.FontName : "Arial");
		}
		return text;
	}

	internal FontStyle method_20(IPortion Portion)
	{
		FontStyle fontStyle = FontStyle.Regular;
		if (Portion.PortionFormat.FontBold == NullableBool.True)
		{
			fontStyle |= FontStyle.Bold;
		}
		if (Portion.PortionFormat.FontItalic == NullableBool.True)
		{
			fontStyle |= FontStyle.Italic;
		}
		if (Portion.PortionFormat.FontUnderline > TextUnderlineType.None)
		{
			fontStyle |= FontStyle.Underline;
		}
		return fontStyle;
	}

	internal float method_21(IPortion Portion)
	{
		return method_22(Portion.PortionFormat.FontHeight);
	}

	internal float method_22(float FontHeight)
	{
		float num = FontHeight * float_28;
		if (float_28 != 1f)
		{
			num = (float)Math.Round(num);
		}
		return num;
	}

	internal Font method_23(Paragraph Paragraph)
	{
		IPortion portion = Paragraph.Portions[0];
		IParagraphFormat paragraphFormat = Paragraph.ParagraphFormat;
		Font font;
		if (paragraphFormat.Bullet.IsBulletHardFont == NullableBool.True && paragraphFormat.Bullet.Type == BulletType.Symbol)
		{
			font = method_27(portion, paragraphFormat.Bullet.Font, paragraphFormat.Bullet.Height / 100f, defaultFontStyle: true);
		}
		else
		{
			font = method_27(portion, portion.PortionFormat.LatinFont, paragraphFormat.Bullet.Height / 100f, defaultFontStyle: false);
			if (font.Style != 0)
			{
				if (paragraphFormat.Bullet.Type == BulletType.Symbol)
				{
					return new Font(font.FontFamily, font.SizeInPoints, FontStyle.Regular);
				}
				return new Font(font.FontFamily, font.SizeInPoints, font.Style & ~(FontStyle.Bold | FontStyle.Italic));
			}
		}
		return font;
	}

	internal Font method_24(Portion portion)
	{
		return method_27(portion, portion.PortionFormat.LatinFont, 1f, defaultFontStyle: false);
	}

	internal Font method_25(Portion portion)
	{
		return method_27(portion, portion.PortionFormat.SymbolFont, 1f, defaultFontStyle: false);
	}

	private Font method_26(string fontName, float fontHeight, FontStyle fontStyle)
	{
		return ((Presentation)baseSlide_0.ParentPresentation).FontsManagerInternal.method_3(fontName, fontHeight, Class732.smethod_0(fontName, fontStyle));
	}

	private Font method_27(IPortion portion, IFontData fontdata, float scale, bool defaultFontStyle)
	{
		FontStyle fontStyle = ((!defaultFontStyle) ? method_20(portion) : FontStyle.Regular);
		float fontHeight = method_21(portion) * scale * ((portion.PortionFormat.Escapement == 0f) ? 1f : 0.7f);
		if (scale < 0f)
		{
			fontHeight = method_22((short)((double)((0f - scale) * 100f) + 0.5));
		}
		fontHeight = method_32(fontHeight);
		if (fontHeight < 1f)
		{
			fontHeight = 1f;
		}
		try
		{
			if (fontdata != null)
			{
				return method_26(GetFontName(fontdata), fontHeight, fontStyle);
			}
			return method_26(((FontsEffectiveData)ifontsEffectiveData_0).method_1(portion.PortionFormat.LanguageId), fontHeight, fontStyle);
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			return method_26("Arial", fontHeight, fontStyle);
		}
	}

	private Class151 method_28(Class169 rc, Portion portion)
	{
		Enum1 charset;
		byte pitchFamily;
		byte[] panose;
		string fontname = method_33(portion, out charset, out pitchFamily, out panose);
		portion_0 = portion;
		class151_0 = new Class151(portion.PortionFormat, fontname, charset, pitchFamily, panose, loadOptions_0.DefaultRegularFont, floatColor_0, method_32(portion.PortionFormat.FontHeight), shapeFrame_0, baseSlide_0, rc);
		return class151_0;
	}

	private Class151 method_29(Class169 rc, Portion portion)
	{
		Enum1 charset;
		byte pitchFamily;
		byte[] panose;
		string fontname = method_34(portion, out charset, out pitchFamily, out panose);
		return new Class151(portion.PortionFormat, fontname, charset, pitchFamily, panose, loadOptions_0.DefaultAsianFont, floatColor_0, method_32(portion.PortionFormat.FontHeight), shapeFrame_0, baseSlide_0, rc);
	}

	private Class151 method_30(Class169 rc, Portion portion)
	{
		Enum1 charset;
		byte pitchFamily;
		byte[] panose;
		string fontname = method_35(portion, out charset, out pitchFamily, out panose);
		return new Class151(portion.PortionFormat, fontname, charset, pitchFamily, panose, loadOptions_0.DefaultAsianFont, floatColor_0, method_32(portion.PortionFormat.FontHeight), shapeFrame_0, baseSlide_0, rc);
	}

	private Class151 method_31(Class169 rc, Portion portion)
	{
		if (portion.PortionFormat.SymbolFont != null)
		{
			return new Class151(portion.PortionFormat, portion.PortionFormat.SymbolFont.FontName, (Enum1)((FontData)portion.PortionFormat.SymbolFont).CharSet, ((FontData)portion.PortionFormat.SymbolFont).PitchFamily, ((FontData)portion.PortionFormat.SymbolFont).Panose, loadOptions_0.DefaultSymbolFont, floatColor_0, method_32(portion.PortionFormat.FontHeight), shapeFrame_0, baseSlide_0, rc);
		}
		return new Class151(portion.PortionFormat, "WinDings", Enum1.const_2, 0, null, loadOptions_0.DefaultSymbolFont, floatColor_0, method_32(portion.PortionFormat.FontHeight), shapeFrame_0, baseSlide_0, rc);
	}

	private float method_32(float fontHeight)
	{
		if (float_28 == 1f)
		{
			return fontHeight;
		}
		return (float)Math.Round(fontHeight * float_28);
	}

	private string method_33(Portion portion, out Enum1 charset, out byte pitchFamily, out byte[] panose)
	{
		FontData fontData = null;
		fontData = ((portion.PortionFormat.LatinFont == null) ? fontData_0[(uint)(fontCollectionIndex_0 - 1)] : ((FontData)portion.PortionFormat.LatinFont));
		if (fontData != null)
		{
			string fontName = fontData.FontName;
			charset = (Enum1)fontData.CharSet;
			pitchFamily = fontData.PitchAndFamily;
			panose = fontData.Panose;
			if (!string.IsNullOrEmpty(fontName))
			{
				if (fontName[0] == '+')
				{
					string text = method_36(fontName, portion);
					if (!string.IsNullOrEmpty(text))
					{
						return text;
					}
				}
				return GetFontName(fontData);
			}
		}
		charset = Enum1.const_0;
		pitchFamily = 0;
		panose = null;
		return null;
	}

	private string method_34(Portion portion, out Enum1 charset, out byte pitchFamily, out byte[] panose)
	{
		FontData fontData = null;
		if (portion.PortionFormat.EastAsianFont != null)
		{
			fontData = (FontData)portion.PortionFormat.EastAsianFont;
		}
		if (fontData != null)
		{
			string fontName = fontData.FontName;
			charset = (Enum1)fontData.CharSet;
			pitchFamily = fontData.PitchAndFamily;
			panose = fontData.Panose;
			if (!string.IsNullOrEmpty(fontName))
			{
				if (fontName[0] == '+')
				{
					string text = method_36(fontName, portion);
					if (!string.IsNullOrEmpty(text))
					{
						return text;
					}
				}
				string fontName2 = GetFontName(fontData);
				if (string.IsNullOrEmpty(fontName2))
				{
					return method_35(portion, out charset, out pitchFamily, out panose);
				}
				return fontName2;
			}
		}
		return method_35(portion, out charset, out pitchFamily, out panose);
	}

	private string method_35(Portion portion, out Enum1 charset, out byte pitchFamily, out byte[] panose)
	{
		FontData fontData = null;
		if (portion.PortionFormat.ComplexScriptFont != null)
		{
			fontData = (FontData)portion.PortionFormat.ComplexScriptFont;
		}
		if (fontData != null)
		{
			string fontName = fontData.FontName;
			charset = (Enum1)fontData.CharSet;
			pitchFamily = fontData.PitchAndFamily;
			panose = fontData.Panose;
			if (!string.IsNullOrEmpty(fontName))
			{
				if (fontName[0] == '+')
				{
					string text = method_36(fontName, portion);
					if (!string.IsNullOrEmpty(text))
					{
						return text;
					}
				}
				string fontName2 = GetFontName(fontData);
				if (string.IsNullOrEmpty(fontName2))
				{
					return method_33(portion, out charset, out pitchFamily, out panose);
				}
				return fontName2;
			}
		}
		return method_33(portion, out charset, out pitchFamily, out panose);
	}

	private string method_36(string fontName, Portion portion)
	{
		if (fontName[0] == '+')
		{
			if (fontName.StartsWith("+mn"))
			{
				return ((FontsEffectiveData)fontSchemeEffectiveData_0.Minor).method_2(portion.PortionFormat.LanguageId);
			}
			if (fontName.StartsWith("+mj"))
			{
				return ((FontsEffectiveData)fontSchemeEffectiveData_0.Major).method_2(portion.PortionFormat.LanguageId);
			}
		}
		return null;
	}

	private Class151 method_37(Class169 rc, Portion portion, IFontData fontdata, string defaultFontName, bool defaultFontStyle)
	{
		Class151 @class;
		if (fontdata != null)
		{
			FontData fontData = (FontData)fontdata;
			@class = new Class151(portion.PortionFormat, GetFontName(fontdata), (Enum1)fontData.CharSet, fontData.PitchAndFamily, fontData.Panose, defaultFontName, floatColor_0, method_32(portion.PortionFormat.FontHeight), shapeFrame_0, baseSlide_0, rc);
		}
		else
		{
			@class = new Class151(portion.PortionFormat, "", Enum1.const_0, 0, null, defaultFontName, floatColor_0, method_32(portion.PortionFormat.FontHeight), shapeFrame_0, baseSlide_0, rc);
		}
		if (defaultFontStyle)
		{
			@class.FontItalic = false;
			@class.FontBold = false;
		}
		return @class;
	}

	internal static float smethod_2(Paragraph paragraph, float BulletWidth)
	{
		float num = Math.Max(smethod_4(paragraph) + BulletWidth, smethod_3(paragraph));
		if (!(num > 0f))
		{
			return 0f;
		}
		return num;
	}

	internal static float smethod_3(Paragraph paragraph)
	{
		IParagraphFormat paragraphFormat = paragraph.ParagraphFormat;
		float num2;
		if (smethod_0(paragraph))
		{
			float num = paragraphFormat.MarginLeft + paragraphFormat.Indent;
			num2 = ((!(paragraphFormat.Indent >= 0f)) ? ((num >= 0f) ? paragraphFormat.MarginLeft : (0f - paragraphFormat.Indent)) : num);
		}
		else
		{
			num2 = paragraphFormat.MarginLeft + paragraphFormat.Indent;
		}
		if (!(num2 > 0f))
		{
			return 0f;
		}
		return num2;
	}

	internal static float smethod_4(Paragraph paragraph)
	{
		IParagraphFormat paragraphFormat = paragraph.ParagraphFormat;
		if (paragraphFormat.Indent >= 0f)
		{
			return paragraphFormat.MarginLeft;
		}
		float num = paragraphFormat.MarginLeft + paragraphFormat.Indent;
		if (!(num >= 0f))
		{
			return 0f;
		}
		return num;
	}

	private static void smethod_5(List<Struct18> Tabs, TabAlignment LastTabAlignment, Struct17 LastTabIterator, float LastTabX, float BeforeTabX, float DelimeterX, float MaxWidth, ref float CurrentX)
	{
		if (LastTabAlignment == TabAlignment.Left)
		{
			return;
		}
		float num = BeforeTabX;
		switch (LastTabAlignment)
		{
		case TabAlignment.Center:
			num = LastTabX - (CurrentX - BeforeTabX) / 2f;
			if (num + (CurrentX - BeforeTabX) > MaxWidth)
			{
				num = MaxWidth - (CurrentX - BeforeTabX);
			}
			break;
		case TabAlignment.Right:
			num = LastTabX - (CurrentX - BeforeTabX);
			break;
		case TabAlignment.Decimal:
			num = LastTabX - (DelimeterX - BeforeTabX);
			if (num + (CurrentX - BeforeTabX) > MaxWidth)
			{
				num = MaxWidth - (CurrentX - BeforeTabX);
			}
			break;
		}
		if (num < BeforeTabX)
		{
			num = BeforeTabX;
		}
		Tabs.Add(new Struct18(LastTabIterator, num));
		CurrentX += num - BeforeTabX;
	}

	private static void smethod_6(ParagraphFormat para)
	{
		if (float.IsNaN(para.bulletFormat_0.float_0))
		{
			para.bulletFormat_0.float_0 = 100f;
		}
		if (double.IsNaN(para.double_0))
		{
			para.double_0 = 0.0;
		}
		if (double.IsNaN(para.double_1))
		{
			para.double_1 = 0.0;
		}
		if (double.IsNaN(para.double_2))
		{
			para.double_2 = 0.0;
		}
		IPortionFormat defaultPortionFormat = ((IParagraphFormat)para).DefaultPortionFormat;
		if (float.IsNaN(defaultPortionFormat.Escapement))
		{
			defaultPortionFormat.Escapement = 0f;
		}
		if (float.IsNaN(defaultPortionFormat.FontHeight))
		{
			defaultPortionFormat.FontHeight = 18f;
		}
		if (para.HangingPunctuation == NullableBool.NotDefined)
		{
			para.HangingPunctuation = NullableBool.True;
		}
	}

	internal string[] method_38()
	{
		return smethod_7(paragraph_0);
	}

	internal static string[] smethod_7(Paragraph[] paragraphs)
	{
		List<string> list = new List<string>(paragraphs.Length);
		int[] array = new int[10];
		Paragraph[] array2 = new Paragraph[10];
		Paragraph paragraph = null;
		foreach (Paragraph paragraph2 in paragraphs)
		{
			IParagraphFormat paragraphFormat = paragraph2.ParagraphFormat;
			if (!smethod_0(paragraph2))
			{
				list.Add(null);
				if (paragraphFormat.Bullet.Type == BulletType.None)
				{
					paragraph = (array2[paragraph2.ParagraphFormat.Depth] = null);
				}
				continue;
			}
			switch (paragraphFormat.Bullet.Type)
			{
			case BulletType.Symbol:
				list.Add(new string(paragraphFormat.Bullet.Char, 1));
				break;
			case BulletType.Numbered:
			{
				Paragraph paragraph3 = array2[paragraph2.ParagraphFormat.Depth];
				if (paragraph3 != null && paragraph != null && smethod_0(paragraph3) && paragraph2.ParagraphFormat.Depth <= paragraph.ParagraphFormat.Depth && ((ParagraphFormat)paragraph3.ParagraphFormat).bulletFormat_0.HasBullet && BulletType.Numbered == paragraph3.ParagraphFormat.Bullet.Type && paragraphFormat.Bullet.NumberedBulletStyle == paragraph3.ParagraphFormat.Bullet.NumberedBulletStyle && paragraphFormat.Bullet.NumberedBulletStartWith == paragraph3.ParagraphFormat.Bullet.NumberedBulletStartWith)
				{
					array[paragraph2.ParagraphFormat.Depth]++;
				}
				else
				{
					array[paragraph2.ParagraphFormat.Depth] = paragraphFormat.Bullet.NumberedBulletStartWith;
				}
				StringBuilder stringBuilder = new StringBuilder();
				Delegate10 @delegate = delegate10_1;
				int numberedBulletStyle = (int)paragraphFormat.Bullet.NumberedBulletStyle;
				if (numberedBulletStyle >= 0 && numberedBulletStyle < delegate10_0.Length)
				{
					@delegate = delegate10_0[numberedBulletStyle];
				}
				if (numberedBulletStyle >= 0 && numberedBulletStyle < string_0.Length)
				{
					int num = array[paragraph2.ParagraphFormat.Depth];
					switch (paragraphFormat.Bullet.NumberedBulletStyle)
					{
					default:
						stringBuilder.AppendFormat(string_0[numberedBulletStyle], @delegate(num));
						break;
					case NumberedBulletStyle.BulletCircleNumDBPlain:
						if (num <= 10)
						{
							num += 9311;
							stringBuilder.AppendFormat(string_0[numberedBulletStyle], (char)num);
						}
						else
						{
							stringBuilder.AppendFormat(string_0[numberedBulletStyle], @delegate(num));
						}
						break;
					case NumberedBulletStyle.BulletCircleNumWDWhitePlain:
						num = ((num % 10 == 0) ? 10 : (num % 10));
						num += 9311;
						stringBuilder.AppendFormat(string_0[numberedBulletStyle], (char)num);
						break;
					case NumberedBulletStyle.BulletCircleNumWDBlackPlain:
						num = ((num % 10 == 0) ? 10 : (num % 10));
						num += 10101;
						stringBuilder.AppendFormat(string_0[numberedBulletStyle], (char)num);
						break;
					}
				}
				else
				{
					stringBuilder.Append(@delegate(array[paragraph2.ParagraphFormat.Depth]));
				}
				list.Add(stringBuilder.ToString());
				break;
			}
			default:
				list.Add(null);
				break;
			}
			if (paragraph2.ParagraphFormatInternal.PPTXUnsupportedProps.SoftParagraph)
			{
				array[paragraph2.ParagraphFormat.Depth]--;
			}
			paragraph = (array2[paragraph2.ParagraphFormat.Depth] = paragraph2);
		}
		return list.ToArray();
	}

	private static string smethod_8(int num)
	{
		num--;
		char c = (char)(97 + num % 26);
		num = num / 26 + 1;
		return new string(c, num);
	}

	private static string smethod_9(int num)
	{
		num--;
		char c = (char)(65 + num % 26);
		num = num / 26 + 1;
		return new string(c, num);
	}

	private static string smethod_10(int num)
	{
		return num.ToString();
	}

	private static string smethod_11(int num)
	{
		if (num < 0)
		{
			throw new ArgumentException("Roman numbering for a negative number called");
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (num >= 1000)
		{
			stringBuilder.Append('m', num / 1000);
			num %= 1000;
		}
		if (num >= 900)
		{
			stringBuilder.Append("cm");
			num -= 900;
		}
		if (num >= 500)
		{
			stringBuilder.Append('d');
			num -= 500;
		}
		if (num >= 400)
		{
			stringBuilder.Append("cd");
			num -= 400;
		}
		if (num >= 100)
		{
			stringBuilder.Append('c', num / 100);
			num %= 100;
		}
		if (num >= 90)
		{
			stringBuilder.Append("xc");
			num -= 90;
		}
		if (num >= 50)
		{
			stringBuilder.Append('l');
			num -= 50;
		}
		if (num >= 40)
		{
			stringBuilder.Append("xl");
			num -= 40;
		}
		if (num >= 10)
		{
			stringBuilder.Append('x', num / 10);
			num %= 10;
		}
		if (num >= 9)
		{
			stringBuilder.Append("ix");
			num -= 9;
		}
		if (num >= 5)
		{
			stringBuilder.Append('v');
			num -= 5;
		}
		if (num >= 4)
		{
			stringBuilder.Append("iv");
			num -= 4;
		}
		if (num >= 1)
		{
			stringBuilder.Append('i', num);
		}
		return stringBuilder.ToString();
	}

	private static string smethod_12(int num)
	{
		if (num < 0)
		{
			throw new ArgumentException("Roman numbering for a negative number called");
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (num >= 1000)
		{
			stringBuilder.Append('M', num / 1000);
			num %= 1000;
		}
		if (num >= 900)
		{
			stringBuilder.Append("CM");
			num -= 900;
		}
		if (num >= 500)
		{
			stringBuilder.Append('D');
			num -= 500;
		}
		if (num >= 400)
		{
			stringBuilder.Append("CD");
			num -= 400;
		}
		if (num >= 100)
		{
			stringBuilder.Append('C', num / 100);
			num %= 100;
		}
		if (num >= 90)
		{
			stringBuilder.Append("XC");
			num -= 90;
		}
		if (num >= 50)
		{
			stringBuilder.Append('L');
			num -= 50;
		}
		if (num >= 40)
		{
			stringBuilder.Append("XL");
			num -= 40;
		}
		if (num >= 10)
		{
			stringBuilder.Append('X', num / 10);
			num %= 10;
		}
		if (num >= 9)
		{
			stringBuilder.Append("IX");
			num -= 9;
		}
		if (num >= 5)
		{
			stringBuilder.Append('V');
			num -= 5;
		}
		if (num >= 4)
		{
			stringBuilder.Append("IV");
			num -= 4;
		}
		if (num >= 1)
		{
			stringBuilder.Append('I', num);
		}
		return stringBuilder.ToString();
	}

	private static string smethod_13(int num)
	{
		string text;
		if (num >= 100)
		{
			text = smethod_10(num);
			char[] array = text.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = char_1[array[i] - 48];
			}
			text = new string(array);
		}
		else
		{
			int num2 = num / 10;
			text = ((num2 > 1) ? (char_1[num2].ToString() + char_1[10]) : ((num2 != 1) ? "" : char_1[10].ToString()));
			num %= 10;
			if (num > 0)
			{
				text += char_1[num];
			}
		}
		return text;
	}

	private static float smethod_14(float space, float reduction, float lineHeight, int defaultPercentage)
	{
		if (space >= 0f)
		{
			return lineHeight * Class1165.smethod_5(space / 100f - reduction, 0f, float.PositiveInfinity);
		}
		return 0f - space;
	}

	private static void smethod_15(IPortionFormat portionFormat, out TextUnderlineType underlineType, out ILineFormat lineFormat, out IFillFormat fillFormat)
	{
		underlineType = ((portionFormat.HyperlinkClick != null || portionFormat.HyperlinkMouseOver != null) ? TextUnderlineType.Single : portionFormat.FontUnderline);
		if (portionFormat.HyperlinkClick == null && portionFormat.HyperlinkMouseOver == null)
		{
			fillFormat = ((portionFormat.UnderlineFillFormat.FillType != FillType.NotDefined) ? portionFormat.UnderlineFillFormat : portionFormat.FillFormat);
			lineFormat = ((portionFormat.UnderlineLineFormat.FillFormat.FillType != FillType.NotDefined) ? portionFormat.UnderlineLineFormat : portionFormat.LineFormat);
		}
		else
		{
			fillFormat = null;
			lineFormat = null;
		}
	}

	private static void smethod_16(IPortionFormat portionFormat, out TextStrikethroughType strikethroughType, out Color strikethroughColor)
	{
		strikethroughType = portionFormat.StrikethroughType;
		strikethroughColor = portionFormat.FillFormat.SolidFillColor.Color;
	}

	static Class532()
	{
		float_8 = new float[2] { 1f, 1f };
		float_9 = new float[2] { 0.5f, 0.5f };
		float_10 = new float[2] { 3f, 2f };
		float_11 = new float[2] { 1.5f, 1f };
		float_12 = new float[2] { 8f, 4f };
		float_13 = new float[2] { 4f, 2f };
		float_14 = new float[4] { 1f, 2f, 3f, 2f };
		float_15 = new float[4] { 0.5f, 1f, 1.5f, 1f };
		float_16 = new float[6] { 1f, 2f, 1f, 2f, 3f, 2f };
		float_17 = new float[6] { 0.5f, 1f, 0.5f, 1f, 1.5f, 1f };
		float_18 = new float[4] { 0f, 0.333333f, 0.666667f, 1f };
		float_19 = new float[4] { 0f, 0.1f, 0.9f, 1f };
		float_20 = new float[4] { 0f, 0.333333f, 0.666667f, 1f };
		char_0 = new char[1] { '\n' };
		string_0 = new string[38]
		{
			"{0}.", "{0}.", "{0})", "{0}.", "({0})", "{0})", "{0}.", "{0}.", "({0})", "{0})",
			"({0})", "{0})", "({0})", "{0}", "({0})", "{0})", "{0}", "{0}.", "{0}", "{0}",
			"{0}", "{0}", "{0}.", "{0}-", "{0}-", "{0}-", "{0}", "{0}.", "{0}", "{0}.",
			"{0}.", "{0})", "({0})", "{0}.", "{0})", "({0})", "{0}.", "{0}."
		};
		delegate10_0 = new Delegate10[18]
		{
			smethod_8, smethod_9, smethod_10, smethod_10, smethod_11, smethod_11, smethod_11, smethod_12, smethod_8, smethod_8,
			smethod_9, smethod_9, smethod_10, smethod_10, smethod_12, smethod_12, smethod_13, smethod_13
		};
		delegate10_1 = smethod_10;
		char_1 = new char[11]
		{
			'○', '一', '二', '三', '四', '五', '六', '七', '八', '九',
			'十'
		};
		string_2 = new string[9] { "+mn-lt", "+mn-ea", "+mn-cs", "+mn-lt", "+mn-ea", "+mn-cs", "+mj-lt", "+mj-ea", "+mj-cs" };
		fontData_0 = new FontData[2]
		{
			new FontData("+mn-lt"),
			new FontData("+mj-lt")
		};
		hashtable_0 = new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant);
		hashtable_0.Add("wingdings", new Class537(new int[3] { 0, 128, 256 }, new float[3]
		{
			float.NaN,
			0.5f,
			float.NaN
		}));
		hashtable_0.Add("wingdings 2", new Class537(new int[3] { 0, 128, 256 }, new float[3]
		{
			float.NaN,
			0.5f,
			float.NaN
		}));
		hashtable_0.Add("wingdings 3", new Class537(new int[3] { 0, 128, 256 }, new float[3]
		{
			float.NaN,
			0.5f,
			float.NaN
		}));
	}

	[CompilerGenerated]
	private static FontData smethod_17(string typeface)
	{
		return new FontData(typeface);
	}
}
