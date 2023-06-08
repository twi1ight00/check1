using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns305;
using ns73;
using ns74;
using ns76;
using ns87;
using ns93;

namespace ns84;

internal class Class4347 : Class4345
{
	internal class Class4349
	{
		private Class4074 class4074_0;

		private Interface89 interface89_0;

		private Class3726 class3726_0;

		internal Class4349(Class4074 styleMap, Interface89 document)
		{
			class4074_0 = styleMap;
			class3726_0 = document.Engine as Class3726;
			interface89_0 = document;
		}

		public bool Contains(Enum600 propertyType)
		{
			return class4074_0.method_0(class3726_0.method_1(propertyType)) != null;
		}
	}

	public class Class4350 : IEnumerable, IEnumerable<Enum600>
	{
		private Class4074 class4074_0;

		private Class3726 class3726_0;

		internal Class4350(Class4074 map, Class3726 engine)
		{
			class4074_0 = map;
			class3726_0 = engine;
		}

		public IEnumerator<Enum600> GetEnumerator()
		{
			return new Class4351(class4074_0, class3726_0);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private class Class4351 : IDisposable, IEnumerator, IEnumerator<Enum600>
	{
		private Class4074 class4074_0;

		private Class3726 class3726_0;

		private int int_0;

		private int int_1;

		private Enum600 enum600_0;

		public Enum600 Current
		{
			get
			{
				if (int_0 == -1)
				{
					return (Enum600)0;
				}
				return enum600_0;
			}
		}

		object IEnumerator.Current => Current;

		public Class4351(Class4074 map, Class3726 engine)
		{
			class4074_0 = map;
			class3726_0 = engine;
			int_1 = engine.method_3();
		}

		public void Dispose()
		{
			class4074_0 = null;
			class3726_0 = null;
		}

		public bool MoveNext()
		{
			while (true)
			{
				if (int_0 < int_1)
				{
					Class3679 @class = class4074_0.method_0(int_0);
					if (@class != null)
					{
						break;
					}
					int_0++;
					continue;
				}
				return false;
			}
			enum600_0 = class3726_0.method_2(int_0);
			int_0++;
			return true;
		}

		public void Reset()
		{
			int_0 = 0;
		}
	}

	private Class6981 class6981_0;

	private Class4074 class4074_0;

	private Interface89 interface89_0;

	private Class3726 class3726_0;

	private string string_0;

	internal Class4349 PropertySet => new Class4349(class4074_0, interface89_0);

	public Class4347 FirstLine => method_4(Enum514.const_1);

	public Class4347 FirstLetter => method_4(Enum514.const_2);

	public Class4347 Before => method_4(Enum514.const_4);

	public Class4347 After => method_4(Enum514.const_3);

	public Class4347 Link => method_4(Enum514.const_9);

	public Class4347 Target => method_4(Enum514.const_14);

	public Class4347 Visited => method_4(Enum514.const_10);

	public Class4347 Active => method_4(Enum514.const_12);

	public Class4347 Default => method_4(Enum514.const_15);

	public Class4347 Selection => method_4(Enum514.const_16);

	public Class4347 Marker => method_4(Enum514.const_5);

	public Class4281 Animation => new Class4281(this);

	public Enum524 AlignContent => method_0<Enum524>(Enum600.const_0);

	public Class4173 AlignmentAdjust => new Class4173(vmethod_0(Enum600.const_2));

	public Enum528 AlignmentBaseline => method_0<Enum528>(Enum600.const_3);

	public Enum525 AlignItems => method_0<Enum525>(Enum600.const_1);

	public Enum525 AlignSelf => method_0<Enum525>(Enum600.const_4);

	public Class4205 Azimuth => new Class4205(vmethod_0(Enum600.const_14));

	public Class4299 Background => new Class4299(this);

	public Class4172 BaselineShift => new Class4172(vmethod_0(Enum600.const_25));

	public Enum521 BackfaceVisibility => method_0<Enum521>(Enum600.const_15);

	public Class4298 Border => new Class4298(this);

	public Class4280 Bookmark => new Class4280(this);

	public Class4230 Bottom => new Class4230(vmethod_0(Enum600.const_64));

	public Enum608 CaptionSide => method_0<Enum608>(Enum600.const_68);

	public Enum609 Clear => method_0<Enum609>(Enum600.const_69);

	public Class4222 Clip => new Class4222(vmethod_0(Enum600.const_70));

	public Class4185 Crop => new Class4185(vmethod_0(Enum600.const_85));

	public Color Color => method_1(Enum600.const_71);

	public Class4223 Content => new Class4223(vmethod_0(Enum600.const_82), vmethod_1(Enum600.const_215, null));

	public Class4276 Column => new Class4276(this);

	public Class4218 CueAfter => new Class4218(vmethod_0(Enum600.const_87));

	public Class4218 CueBefore => new Class4218(vmethod_0(Enum600.const_88));

	public Class4229 Cursor => new Class4229(vmethod_0(Enum600.const_89));

	public Class4159 BoxShadow => new Class4159(vmethod_0(Enum600.const_66));

	public Enum523 BoxSizing => method_0<Enum523>(Enum600.const_67);

	public Enum501 BreakAfter => method_0<Enum501>(Enum600.const_290);

	public Enum501 BreakBefore => method_0<Enum501>(Enum600.const_291);

	public Enum501 BreakInside => method_0<Enum501>(Enum600.const_292);

	public Enum632 Direction => method_0<Enum632>(Enum600.const_90);

	public Class4194 Display => new Class4194(vmethod_0(Enum600.const_91));

	public Enum548 DominantBaseline => method_0<Enum548>(Enum600.const_92);

	public Class4273 DropInitial => new Class4273(this);

	public Class4218 Icon => new Class4218(vmethod_0(Enum600.const_143));

	public Class4337 ImageOrientation => method_2(Enum600.const_144);

	public Class4182 ImageResolution => new Class4182(vmethod_0(Enum600.const_145));

	public Enum503 ImeMode => method_0<Enum503>(Enum600.const_146);

	public Class4157 InlineBoxAlign => new Class4157(vmethod_0(Enum600.const_147));

	public Class4211 Elevation => new Class4211(vmethod_0(Enum600.const_99));

	public Enum628 EmptyCells => method_0<Enum628>(Enum600.const_100);

	public Enum627 Float => method_0<Enum627>(Enum600.const_110);

	public Class4189 FloatOffset => new Class4189(vmethod_0(Enum600.const_111));

	public Class4278 Flex => new Class4278(this);

	public Class4294 Font => new Class4294(this);

	public Enum555 JustifyContent => method_0<Enum555>(Enum600.const_148);

	public Class4285 Grid => new Class4285(this);

	public Enum581 HangingPunctuation => method_0<Enum581>(Enum600.const_140);

	public Class4230 Height => new Class4230(vmethod_0(Enum600.const_141));

	public Enum579 Hyphens => method_0<Enum579>(Enum600.const_142);

	public Class4270 HyperlinkTarget => new Class4270(this);

	public Class4230 Left => new Class4230(vmethod_0(Enum600.const_149));

	public Class4225 LetterSpacing => new Class4225(vmethod_0(Enum600.const_150));

	public Enum578 LineBreak => method_0<Enum578>(Enum600.const_151);

	public Class4224 LineHeight => new Class4224(vmethod_0(Enum600.const_152));

	public Class4274 LineStacking => new Class4274(this);

	public Class4293 ListStyle => new Class4293(this);

	public Class4296 Margin => new Class4296(this);

	public Class4216 MaxHeight => new Class4216(vmethod_0(Enum600.const_172));

	public Class4216 MaxWidth => new Class4216(vmethod_0(Enum600.const_173));

	public Class4216 MinHeight => new Class4216(vmethod_0(Enum600.const_174));

	public Class4216 MinWidth => new Class4216(vmethod_0(Enum600.const_175));

	public Class4184 MoveTo => new Class4184(vmethod_0(Enum600.const_176));

	public Enum549 ObjectFit => method_0<Enum549>(Enum600.const_182);

	public Class4219 ObjectPosition => new Class4219(vmethod_0(Enum600.const_183));

	public Class4282 Marquee => new Class4282(this);

	public float Opacity => method_2(Enum600.const_184).Value;

	public int Orphans => (int)method_2(Enum600.const_186).Value;

	public int Order => (int)method_2(Enum600.const_185).Value;

	public Class4297 Outline => new Class4297(this);

	public Class4286 Overflow => new Class4286(this);

	public Enum580 OverflowWrap => method_0<Enum580>(Enum600.const_194);

	public Class4292 Padding => new Class4292(this);

	public Enum618 PageBreakAfter => method_0<Enum618>(Enum600.const_202);

	public Enum618 PageBreakBefore => method_0<Enum618>(Enum600.const_203);

	public Enum618 PageBreakInside => method_0<Enum618>(Enum600.const_204);

	public Enum553 PagePolicy => method_0<Enum553>(Enum600.const_205);

	public Class4291 Pause => new Class4291(this);

	public Class4337 PitchRange => method_2(Enum600.const_212);

	public Class4210 Pitch => new Class4210(vmethod_0(Enum600.const_211));

	public Class4209 PlayDuring => new Class4209(vmethod_0(Enum600.const_213));

	public Enum633 Position => method_0<Enum633>(Enum600.const_214);

	public Class4338 Perspective => method_2(Enum600.const_213);

	public Class4187 PerspectiveOrigin => new Class4187(vmethod_0(Enum600.const_210));

	public IList<Class4214.Class4352> Quotes => new Class4214(vmethod_0(Enum600.const_215)).Quotes;

	public Enum502 Resize => method_0<Enum502>(Enum600.const_216);

	public Class4272 Rest => new Class4272(this);

	public Class4337 Richness => method_2(Enum600.const_220);

	public Class4230 Right => new Class4230(vmethod_0(Enum600.const_221));

	public Class4337 Rotation => method_2(Enum600.const_222);

	public Class4200 RotationPoint => new Class4200(vmethod_0(Enum600.const_223));

	public Class4277 Ruby => new Class4277(this);

	public Enum596 SpeakHeader => method_0<Enum596>(Enum600.const_231);

	public Enum595 SpeakNumeral => method_0<Enum595>(Enum600.const_232);

	public Enum593 Speak => method_0<Enum593>(Enum600.const_229);

	public Enum543 SpeakAs => method_0<Enum543>(Enum600.const_230);

	public Class4337 Stress => method_2(Enum600.const_235);

	public Class4190 StringSet => new Class4190(vmethod_0(Enum600.const_236));

	public Class4208 SpeechRate => new Class4208(vmethod_0(Enum600.const_234));

	public Enum594 SpeakPunctuation => method_0<Enum594>(Enum600.const_233);

	public Class4337 TabSize => method_2(Enum600.const_238);

	public Enum617 TableLayout => method_0<Enum617>(Enum600.const_237);

	public Enum616 TextAlign => method_0<Enum616>(Enum600.const_239);

	public Enum577 TextAlignLast => method_0<Enum577>(Enum600.const_240);

	public Class4201 TextCombineHorizontal => new Class4201(vmethod_0(Enum600.const_241));

	public Class4290 TextDecoration => new Class4290(this);

	public Class4289 TextEmphasis => new Class4289(this);

	public Class4337 TextIndent => method_2(Enum600.const_253);

	public Enum576 TextJustify => method_0<Enum576>(Enum600.const_254);

	public Enum507 TextHeight => method_0<Enum507>(Enum600.const_252);

	public Enum571 TextOrientation => method_0<Enum571>(Enum600.const_255);

	public Class4183 TextOverflow => new Class4183(vmethod_0(Enum600.const_256));

	public Class4202 TextShadow => new Class4202(vmethod_0(Enum600.const_257));

	public Enum575 TextSpaceCollapse => method_0<Enum575>(Enum600.const_258);

	public Enum614 TextTransform => method_0<Enum614>(Enum600.const_259);

	public Enum574 TextUnderlinePosition => method_0<Enum574>(Enum600.const_260);

	public Class4304 Transform => new Class4304();

	public Class4187 TransformOrigin => new Class4187(vmethod_0(Enum600.const_263));

	public Class4279 Transition => new Class4279(this);

	public Enum558 TransformStyle => method_0<Enum558>(Enum600.const_264);

	public Class4230 Top => new Class4230(vmethod_0(Enum600.const_261));

	public Enum613 UnicodeBidi => method_0<Enum613>(Enum600.const_270);

	public Class4213 VerticalAlign => new Class4213(vmethod_0(Enum600.const_271));

	public Enum612 Visibility => method_0<Enum612>(Enum600.const_272);

	public Class4207 Volume => new Class4207(vmethod_0(Enum600.const_281));

	public Class4158 VoiceBalance => new Class4158(vmethod_0(Enum600.const_273));

	public Class4192 VoiceDuration => new Class4192(vmethod_0(Enum600.const_274));

	public IList<Class4206.Class4344> VoiceFamily => new Class4206(vmethod_0(Enum600.const_275)).VoiceFamilies;

	public Enum611 WhiteSpace => method_0<Enum611>(Enum600.const_282);

	public int Widows => (int)method_2(Enum600.const_283).Value;

	public Class4230 Width => new Class4230(vmethod_0(Enum600.const_284));

	public Class4225 WordSpacing => new Class4225(vmethod_0(Enum600.const_286));

	public Enum573 WordBreak => method_0<Enum573>(Enum600.const_285);

	public Enum509 WordWrap => method_0<Enum509>(Enum600.const_289);

	public Enum572 WritingMode => method_0<Enum572>(Enum600.const_287);

	public Class4230 ZIndex => new Class4230(vmethod_0(Enum600.const_288));

	internal Color CurrentColor => method_1(Enum600.const_71);

	internal Class4347(Class6981 element)
		: this(element, Enum514.const_0)
	{
	}

	internal Class4347(Class6981 element, Enum514 elementType)
	{
		class6981_0 = element;
		interface89_0 = element.OwnerDocument as Interface89;
		class3726_0 = (Class3726)interface89_0.Engine;
		if (elementType == Enum514.const_0)
		{
			string_0 = null;
		}
		else
		{
			string_0 = Class4342.smethod_0<Enum514>().imethod_2(elementType);
		}
		class4074_0 = ((Interface91)element).imethod_0(string_0);
		if (class4074_0 == null)
		{
			class4074_0 = class3726_0.method_8(element, string_0);
			((Interface91)element).imethod_1(string_0, class4074_0);
		}
	}

	public static Class4347 smethod_1(Class6981 element)
	{
		return new Class4347(element);
	}

	public bool Contains(Enum600 type)
	{
		int i = class3726_0.method_1(type);
		return class4074_0.method_0(i) != null;
	}

	internal override Class3679 vmethod_0(Enum600 type)
	{
		int propertyIndex = class3726_0.method_1(type);
		return class3726_0.method_9(class6981_0 as Interface91, string_0, propertyIndex);
	}

	internal override Class3679 vmethod_1(Enum600 type, string pseudo)
	{
		int propertyIndex = class3726_0.method_1(type);
		return class3726_0.method_9(class6981_0 as Interface91, pseudo, propertyIndex);
	}

	private Class4347 method_4(Enum514 elementType)
	{
		return new Class4347(class6981_0, elementType);
	}

	public Class4350 method_5()
	{
		return new Class4350(class4074_0, class3726_0);
	}
}
