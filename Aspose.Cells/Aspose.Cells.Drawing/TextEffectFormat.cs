using System.Runtime.CompilerServices;
using ns21;
using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Contains properties and methods that apply to WordArt objects.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///       Shapes shapes = workbook.Worksheets[0].Shapes;
///       shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1, "Aspose", "Arial", 30, false, false, 0, 0, 0, 0, 100, 200);
///       TextEffectFormat textEffectFormat = shapes[0].TextEffect;
///       textEffectFormat.SetTextEffect(MsoPresetTextEffect.TextEffect10);
///       workbook.Save("C:\\Book1.xls");
///
///       [Visual Basic]
///
///       'Instantiating a Workbook object
///       Dim workbook As Workbook = New Workbook()
///       Dim shapes As Shapes = workbook.Worksheets(0).Shapes
///       shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1, "Aspose", "Arial", 30, false, false, 0, 0, 0, 0, 100, 200)
///       Dim textEffectFormat As TextEffectFormat = shapes(0).TextEffect
///       TextEffectFormat.SetTextEffect(MsoPresetTextEffect.TextEffect10)
///       workbook.Save("C:\\Book1.xls")
///
///       </code>
/// </example>
public class TextEffectFormat
{
	private Shape shape_0;

	/// <summary>
	///       The text in the WordArt.
	///       </summary>
	public string Text
	{
		get
		{
			return method_0().GetStringValue(49344);
		}
		set
		{
			method_0().method_1(49344, Enum183.const_2, value);
		}
	}

	/// <summary>
	///       The name of the font used in the WordArt.
	///       </summary>
	public string FontName
	{
		get
		{
			return method_0().GetStringValue(49349);
		}
		set
		{
			method_0().method_1(49349, Enum183.const_2, value);
		}
	}

	/// <summary>
	///       Indicates whether font is bold.
	///       </summary>
	public bool FontBold
	{
		get
		{
			return method_0().method_5(255, 5, bool_0: false);
		}
		set
		{
			method_0().method_6(255, 5, value);
		}
	}

	/// <summary>
	///       Indicates whether font is italic.
	///       </summary>
	public bool FontItalic
	{
		get
		{
			return method_0().method_5(255, 4, bool_0: false);
		}
		set
		{
			method_0().method_6(255, 4, value);
		}
	}

	/// <summary>
	///       If true,characters in the specified WordArt are rotated 90 degrees relative to the WordArt's bounding shape.
	///       </summary>
	public bool RotatedChars
	{
		get
		{
			return method_0().method_5(255, 13, bool_0: false);
		}
		set
		{
			method_0().method_6(255, 13, value);
		}
	}

	/// <summary>
	///       The size (in points) of the font used in the WordArt.
	///       </summary>
	public int FontSize
	{
		get
		{
			return (int)method_0().method_7(195, 36f);
		}
		set
		{
			method_0().method_8(195, value);
		}
	}

	/// <summary>
	///       Gets and sets the preset shape type.
	///       </summary>
	public MsoPresetTextEffectShape PresetShape
	{
		get
		{
			return shape_0.method_27().method_9().method_0() switch
			{
				136 => MsoPresetTextEffectShape.PlainText, 
				137 => MsoPresetTextEffectShape.Stop, 
				138 => MsoPresetTextEffectShape.TriangleUp, 
				139 => MsoPresetTextEffectShape.TriangleDown, 
				140 => MsoPresetTextEffectShape.ChevronUp, 
				141 => MsoPresetTextEffectShape.ChevronDown, 
				142 => MsoPresetTextEffectShape.RingInside, 
				143 => MsoPresetTextEffectShape.RingOutside, 
				144 => MsoPresetTextEffectShape.ArchUpCurve, 
				145 => MsoPresetTextEffectShape.ArchDownCurve, 
				146 => MsoPresetTextEffectShape.CircleCurve, 
				147 => MsoPresetTextEffectShape.ButtonCurve, 
				148 => MsoPresetTextEffectShape.ArchUpPour, 
				149 => MsoPresetTextEffectShape.ArchDownPour, 
				150 => MsoPresetTextEffectShape.CirclePour, 
				151 => MsoPresetTextEffectShape.ButtonPour, 
				152 => MsoPresetTextEffectShape.CurveUp, 
				153 => MsoPresetTextEffectShape.CurveDown, 
				154 => MsoPresetTextEffectShape.CascadeUp, 
				155 => MsoPresetTextEffectShape.CascadeDown, 
				156 => MsoPresetTextEffectShape.Wave1, 
				157 => MsoPresetTextEffectShape.Wave2, 
				158 => MsoPresetTextEffectShape.DoubleWave1, 
				159 => MsoPresetTextEffectShape.DoubleWave2, 
				160 => MsoPresetTextEffectShape.Inflate, 
				161 => MsoPresetTextEffectShape.Deflate, 
				162 => MsoPresetTextEffectShape.InflateBottom, 
				163 => MsoPresetTextEffectShape.DeflateBottom, 
				164 => MsoPresetTextEffectShape.InflateTop, 
				165 => MsoPresetTextEffectShape.DeflateTop, 
				166 => MsoPresetTextEffectShape.DeflateInflate, 
				167 => MsoPresetTextEffectShape.DeflateInflateDeflate, 
				168 => MsoPresetTextEffectShape.FadeRight, 
				169 => MsoPresetTextEffectShape.FadeLeft, 
				170 => MsoPresetTextEffectShape.FadeUp, 
				171 => MsoPresetTextEffectShape.FadeDown, 
				172 => MsoPresetTextEffectShape.SlantUp, 
				173 => MsoPresetTextEffectShape.SlantDown, 
				174 => MsoPresetTextEffectShape.CanUp, 
				175 => MsoPresetTextEffectShape.CanDown, 
				_ => MsoPresetTextEffectShape.Mixed, 
			};
		}
		set
		{
			if (value != MsoPresetTextEffectShape.Mixed)
			{
				shape_0.method_27().method_9().method_1((short)value);
			}
		}
	}

	internal TextEffectFormat(Shape shape_1)
	{
		shape_0 = shape_1;
	}

	/// <summary>
	///       Sets the preset text effect.
	///       </summary>
	/// <param name="effect">The preset tect effect.</param>
	public void SetTextEffect(MsoPresetTextEffect effect)
	{
		Class1711 @class = method_0();
		switch (effect)
		{
		case MsoPresetTextEffect.TextEffect1:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect2:
			shape_0.method_27().method_9().method_1(172);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(385, Enum183.const_0, 0);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect3:
			shape_0.method_27().method_9().method_1(144);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(385, Enum183.const_0, 0);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect4:
			shape_0.method_27().method_9().method_1(161);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(327, Enum183.const_0, 5665);
			@class.method_1(385, Enum183.const_0, 0);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect5:
			shape_0.method_27().method_9().method_1(175);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(327, Enum183.const_0, 7200);
			@class.method_1(385, Enum183.const_0, 0);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect6:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(4, Enum183.const_0, 5898240);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294932224u);
			@class.method_1(385, Enum183.const_0, 0);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect7:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924048u);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect8:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(385, Enum183.const_0, 10053171);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 11711154);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(517, Enum183.const_0, 38100);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect9:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(385, Enum183.const_0, 11711154);
			@class.method_1(386, Enum183.const_0, 32768);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(448, Enum183.const_0, 13382451);
			@class.method_1(459, Enum183.const_0, 12700);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 16751001);
			@class.method_1(517, Enum183.const_0, 38100);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect10:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(196, Enum183.const_0, 78650);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(387, Enum183.const_0, 11184810);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 5066061);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(518, Enum183.const_0, 38100);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect11:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(385, Enum183.const_0, 13395456);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(448, Enum183.const_0, 16764057);
			@class.method_1(459, Enum183.const_0, 19050);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 153);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect12:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(4, Enum183.const_0, 5898240);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294932240u);
			@class.method_1(385, Enum183.const_0, 128);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(448, Enum183.const_0, 128);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 11711154);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect13:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 5);
			@class.method_1(385, Enum183.const_0, 65535);
			@class.method_1(387, Enum183.const_0, 3381759);
			@class.method_1(395, Enum183.const_0, 4286119936u);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(397, Enum183.const_0, 32768);
			@class.method_1(398, Enum183.const_0, 32768);
			@class.method_1(399, Enum183.const_0, 32768);
			@class.method_1(400, Enum183.const_0, 32768);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 12632256);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect14:
			shape_0.method_27().method_9().method_1(172);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(327, Enum183.const_0, 6924);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(385, Enum183.const_0, 13369446);
			@class.method_1(387, Enum183.const_0, 13369548);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(448, Enum183.const_0, 16751052);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 16751001);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(517, Enum183.const_0, 38100);
			@class.method_1(518, Enum183.const_0, 38100);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect15:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 2);
			@class.method_1(385, Enum183.const_0, 3368448);
			@class.method_1(49542, Enum183.const_4, Class1707.smethod_2(TextureType.GreenMarble));
			@class.method_1(49543, Enum183.const_2, "Paper bag");
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(448, Enum183.const_0, 32768);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(512, Enum183.const_0, 2);
			@class.method_1(513, Enum183.const_0, 13885383);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(517, Enum183.const_0, 4294637096u);
			@class.method_1(518, Enum183.const_0, 4294510096u);
			@class.method_1(521, Enum183.const_0, 81920);
			@class.method_1(524, Enum183.const_0, 81920);
			@class.method_1(528, Enum183.const_0, 4294934528u);
			@class.method_1(529, Enum183.const_0, 4294934528u);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect16:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(385, Enum183.const_0, 15532180);
			@class.method_1(387, Enum183.const_0, 16711680);
			@class.method_1(395, Enum183.const_0, 4289069056u);
			@class.method_1(49559, Enum183.const_4, MsoFillFormatHelper.smethod_49(GradientPresetType.Rainbow));
			@class.method_1(412, Enum183.const_0, 0);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(448, Enum183.const_0, 15395562);
			@class.method_1(459, Enum183.const_0, 12700);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(512, Enum183.const_0, 2);
			@class.method_1(513, Enum183.const_0, 12632256);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(522, Enum183.const_0, 46340);
			@class.method_1(524, Enum183.const_0, 32768);
			@class.method_1(526, Enum183.const_0, 4294967288u);
			@class.method_1(528, Enum183.const_0, 4294934528u);
			@class.method_1(529, Enum183.const_0, 32768);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect17:
			shape_0.method_27().method_9().method_1(156);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(385, Enum183.const_0, 16751001);
			@class.method_1(387, Enum183.const_0, 10066176);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 12632256);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(517, Enum183.const_0, 38100);
			@class.method_1(518, Enum183.const_0, 38100);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect18:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(4, Enum183.const_0, 5898240);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294932224u);
			@class.method_1(384, Enum183.const_0, 2);
			@class.method_1(385, Enum183.const_0, 9876932);
			@class.method_1(49542, Enum183.const_4, Class1707.smethod_2(TextureType.Sand));
			@class.method_1(49543, Enum183.const_2, "Sand");
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(448, Enum183.const_0, 9876932);
			@class.method_1(459, Enum183.const_0, 12700);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 13355979);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(517, Enum183.const_0, 38100);
			@class.method_1(518, Enum183.const_0, 38100);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect19:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 2);
			@class.method_1(385, Enum183.const_0, 10079487);
			@class.method_1(49542, Enum183.const_4, Class1707.smethod_2(TextureType.PaperBag));
			@class.method_1(49543, Enum183.const_2, "White marble");
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(645, Enum183.const_0, 127000);
			@class.method_1(647, Enum183.const_0, 13158);
			@class.method_1(703, Enum183.const_0, 983049);
			@class.method_1(716, Enum183.const_0, 0);
			@class.method_1(719, Enum183.const_0, 0);
			@class.method_1(720, Enum183.const_0, 11796480);
			@class.method_1(722, Enum183.const_0, 4000);
			@class.method_1(723, Enum183.const_0, 4294917296u);
			@class.method_1(726, Enum183.const_0, 52000);
			@class.method_1(727, Enum183.const_0, 50000);
			@class.method_1(730, Enum183.const_0, 14000);
			@class.method_1(767, Enum183.const_0, 2031639);
			break;
		case MsoPresetTextEffect.TextEffect20:
			shape_0.method_27().method_9().method_1(138);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(385, Enum183.const_0, 13434879);
			@class.method_1(387, Enum183.const_0, 10066431);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(645, Enum183.const_0, 228600);
			@class.method_1(647, Enum183.const_0, 13395456);
			@class.method_1(703, Enum183.const_0, 983049);
			@class.method_1(715, Enum183.const_0, 4293717296u);
			@class.method_1(718, Enum183.const_0, 4294934528u);
			@class.method_1(720, Enum183.const_0, 4292018176u);
			@class.method_1(722, Enum183.const_0, 10000);
			@class.method_1(723, Enum183.const_0, 0);
			@class.method_1(724, Enum183.const_0, 4294917296u);
			@class.method_1(726, Enum183.const_0, 44000);
			@class.method_1(727, Enum183.const_0, 0);
			@class.method_1(728, Enum183.const_0, 50000);
			@class.method_1(730, Enum183.const_0, 24000);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect21:
			shape_0.method_27().method_9().method_1(170);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(327, Enum183.const_0, 2158);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(385, Enum183.const_0, 132178);
			@class.method_1(387, Enum183.const_0, 52479);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(448, Enum183.const_0, 11711154);
			@class.method_1(459, Enum183.const_0, 12700);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(512, Enum183.const_0, 2);
			@class.method_1(513, Enum183.const_0, 875399);
			@class.method_1(516, Enum183.const_0, 45875);
			@class.method_1(524, Enum183.const_0, 32768);
			@class.method_1(526, Enum183.const_0, 4294967288u);
			@class.method_1(529, Enum183.const_0, 32768);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect22:
			shape_0.method_27().method_9().method_1(158);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(196, Enum183.const_0, 52429);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(385, Enum183.const_0, 16763955);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(448, Enum183.const_0, 10027008);
			@class.method_1(459, Enum183.const_0, 12700);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 10027008);
			@class.method_1(517, Enum183.const_0, 88900);
			@class.method_1(518, Enum183.const_0, 4294878396u);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect23:
			shape_0.method_27().method_9().method_1(152);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(327, Enum183.const_0, 8717);
			@class.method_1(384, Enum183.const_0, 1);
			@class.method_1(385, Enum183.const_0, 8421504);
			@class.method_1(387, Enum183.const_0, 65535);
			@class.method_1(49542, Enum183.const_4, MsoFillFormatHelper.smethod_74(FillPattern.DashedHorizontal));
			@class.method_1(49543, Enum183.const_2, "Narrow vertical");
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(459, Enum183.const_0, 12700);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(517, Enum183.const_0, 38100);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect24:
			shape_0.method_27().method_9().method_1(159);
			@class.method_1(4, Enum183.const_0, 5898240);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294932224u);
			@class.method_1(327, Enum183.const_0, 2809);
			@class.method_1(328, Enum183.const_0, 0);
			@class.method_1(49493, Enum183.const_4, new byte[78]
			{
				2, 0, 4, 0, 36, 0, 32, 0, 0, 0,
				0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0, 0, 128,
				255, 255, 255, 127, 0, 0, 0, 0, 107, 17,
				0, 0, 32, 0, 0, 0, 1, 1, 0, 0,
				1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 192, 33, 0, 0, 160, 50, 0, 0,
				0, 0, 0, 128, 255, 255, 255, 127
			});
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(385, Enum183.const_0, 65280);
			@class.method_1(387, Enum183.const_0, 16763904);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 8388608);
			@class.method_1(516, Enum183.const_0, 52429);
			@class.method_1(517, Enum183.const_0, 4294903796u);
			@class.method_1(518, Enum183.const_0, 76200);
			@class.method_1(575, Enum183.const_0, 196610);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(703, Enum183.const_0, 983041);
			@class.method_1(767, Enum183.const_0, 2031638);
			break;
		case MsoPresetTextEffect.TextEffect25:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(49559, Enum183.const_4, MsoFillFormatHelper.smethod_49(GradientPresetType.ChromeII));
			@class.method_1(412, Enum183.const_0, 0);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(640, Enum183.const_0, 80000);
			@class.method_1(641, Enum183.const_0, 43712);
			@class.method_1(645, Enum183.const_0, 228600);
			@class.method_1(647, Enum183.const_0, 16777215);
			@class.method_1(703, Enum183.const_0, 983053);
			@class.method_1(715, Enum183.const_0, 4293717296u);
			@class.method_1(718, Enum183.const_0, 4294934528u);
			@class.method_1(720, Enum183.const_0, 4292018176u);
			@class.method_1(722, Enum183.const_0, 10000);
			@class.method_1(723, Enum183.const_0, 0);
			@class.method_1(724, Enum183.const_0, 4294917296u);
			@class.method_1(726, Enum183.const_0, 44000);
			@class.method_1(727, Enum183.const_0, 0);
			@class.method_1(728, Enum183.const_0, 50000);
			@class.method_1(730, Enum183.const_0, 24000);
			@class.method_1(767, Enum183.const_0, 2031634);
			break;
		case MsoPresetTextEffect.TextEffect26:
			shape_0.method_27().method_9().method_1(154);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 2);
			@class.method_1(385, Enum183.const_0, 26112);
			@class.method_1(49542, Enum183.const_4, Class1707.smethod_2(TextureType.GreenMarble));
			@class.method_1(49543, Enum183.const_2, "Paper bag");
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(647, Enum183.const_0, 26112);
			@class.method_1(703, Enum183.const_0, 983049);
			@class.method_1(704, Enum183.const_0, 4293787648u);
			@class.method_1(715, Enum183.const_0, 4293717296u);
			@class.method_1(718, Enum183.const_0, 4294934528u);
			@class.method_1(720, Enum183.const_0, 4292018176u);
			@class.method_1(722, Enum183.const_0, 4000);
			@class.method_1(723, Enum183.const_0, 0);
			@class.method_1(724, Enum183.const_0, 4294917296u);
			@class.method_1(726, Enum183.const_0, 52000);
			@class.method_1(727, Enum183.const_0, 0);
			@class.method_1(728, Enum183.const_0, 50000);
			@class.method_1(730, Enum183.const_0, 14000);
			@class.method_1(767, Enum183.const_0, 2031635);
			break;
		case MsoPresetTextEffect.TextEffect27:
			shape_0.method_27().method_9().method_1(163);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(327, Enum183.const_0, 16518);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(387, Enum183.const_0, 7368816);
			@class.method_1(395, Enum183.const_0, 2949120);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(645, Enum183.const_0, 381000);
			@class.method_1(647, Enum183.const_0, 7771795);
			@class.method_1(703, Enum183.const_0, 983049);
			@class.method_1(704, Enum183.const_0, 4292608000u);
			@class.method_1(705, Enum183.const_0, 1966080);
			@class.method_1(715, Enum183.const_0, 0);
			@class.method_1(716, Enum183.const_0, 0);
			@class.method_1(718, Enum183.const_0, 0);
			@class.method_1(719, Enum183.const_0, 0);
			@class.method_1(720, Enum183.const_0, 0);
			@class.method_1(721, Enum183.const_0, 0);
			@class.method_1(722, Enum183.const_0, 10000);
			@class.method_1(723, Enum183.const_0, 4294917296u);
			@class.method_1(724, Enum183.const_0, 4294917296u);
			@class.method_1(726, Enum183.const_0, 44000);
			@class.method_1(727, Enum183.const_0, 50000);
			@class.method_1(730, Enum183.const_0, 24000);
			@class.method_1(767, Enum183.const_0, 2031634);
			break;
		case MsoPresetTextEffect.TextEffect28:
			shape_0.method_27().method_9().method_1(154);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(385, Enum183.const_0, 124927);
			@class.method_1(387, Enum183.const_0, 147198);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(397, Enum183.const_0, 65536);
			@class.method_1(398, Enum183.const_0, 65536);
			@class.method_1(399, Enum183.const_0, 65536);
			@class.method_1(400, Enum183.const_0, 65536);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(647, Enum183.const_0, 26367);
			@class.method_1(703, Enum183.const_0, 983049);
			@class.method_1(704, Enum183.const_0, 1179648);
			@class.method_1(705, Enum183.const_0, 1179648);
			@class.method_1(715, Enum183.const_0, 0);
			@class.method_1(716, Enum183.const_0, 0);
			@class.method_1(718, Enum183.const_0, 0);
			@class.method_1(719, Enum183.const_0, 0);
			@class.method_1(720, Enum183.const_0, 0);
			@class.method_1(721, Enum183.const_0, 0);
			@class.method_1(722, Enum183.const_0, 4000);
			@class.method_1(724, Enum183.const_0, 50000);
			@class.method_1(726, Enum183.const_0, 52000);
			@class.method_1(730, Enum183.const_0, 14000);
			@class.method_1(767, Enum183.const_0, 2031635);
			break;
		case MsoPresetTextEffect.TextEffect29:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294924032u);
			@class.method_1(384, Enum183.const_0, 7);
			@class.method_1(385, Enum183.const_0, 16116700);
			@class.method_1(387, Enum183.const_0, 1844821);
			@class.method_1(396, Enum183.const_0, 100);
			@class.method_1(49559, Enum183.const_4, MsoFillFormatHelper.smethod_49(GradientPresetType.Horizon));
			@class.method_1(412, Enum183.const_0, 0);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524288);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(647, Enum183.const_0, 12632256);
			@class.method_1(703, Enum183.const_0, 983049);
			@class.method_1(704, Enum183.const_0, 4294574080u);
			@class.method_1(716, Enum183.const_0, 1250000);
			@class.method_1(719, Enum183.const_0, 32768);
			@class.method_1(720, Enum183.const_0, 8847360);
			@class.method_1(722, Enum183.const_0, 4000);
			@class.method_1(723, Enum183.const_0, 0);
			@class.method_1(724, Enum183.const_0, 50000);
			@class.method_1(726, Enum183.const_0, 52000);
			@class.method_1(727, Enum183.const_0, 0);
			@class.method_1(728, Enum183.const_0, 4294917296u);
			@class.method_1(730, Enum183.const_0, 14000);
			@class.method_1(767, Enum183.const_0, 2031635);
			break;
		case MsoPresetTextEffect.TextEffect30:
			shape_0.method_27().method_9().method_1(136);
			@class.method_1(4, Enum183.const_0, 5898240);
			@class.method_1(191, Enum183.const_0, 524296);
			@class.method_1(255, Enum183.const_0, 4294932224u);
			@class.method_1(385, Enum183.const_0, 204);
			@class.method_1(447, Enum183.const_0, 1048592);
			@class.method_1(511, Enum183.const_0, 524296);
			@class.method_1(513, Enum183.const_0, 8816262);
			@class.method_1(575, Enum183.const_0, 196608);
			@class.method_1(639, Enum183.const_0, 65536);
			@class.method_1(640, Enum183.const_0, 80000);
			@class.method_1(645, Enum183.const_0, 228600);
			@class.method_1(647, Enum183.const_0, 6724095);
			@class.method_1(703, Enum183.const_0, 983049);
			@class.method_1(704, Enum183.const_0, 4293984256u);
			@class.method_1(705, Enum183.const_0, 1048576);
			@class.method_1(715, Enum183.const_0, 0);
			@class.method_1(716, Enum183.const_0, 0);
			@class.method_1(718, Enum183.const_0, 0);
			@class.method_1(719, Enum183.const_0, 0);
			@class.method_1(720, Enum183.const_0, 0);
			@class.method_1(721, Enum183.const_0, 0);
			@class.method_1(722, Enum183.const_0, 10000);
			@class.method_1(723, Enum183.const_0, 0);
			@class.method_1(724, Enum183.const_0, 50000);
			@class.method_1(726, Enum183.const_0, 44000);
			@class.method_1(727, Enum183.const_0, 0);
			@class.method_1(728, Enum183.const_0, 4294917296u);
			@class.method_1(730, Enum183.const_0, 24000);
			@class.method_1(767, Enum183.const_0, 2031634);
			break;
		}
	}

	[SpecialName]
	internal Class1711 method_0()
	{
		return shape_0.method_27().method_2();
	}

	[SpecialName]
	internal bool method_1()
	{
		return method_0().method_5(255, 12, bool_0: false);
	}

	[SpecialName]
	internal double method_2()
	{
		return method_0().method_7(196, 1f);
	}

	[SpecialName]
	internal Enum233 method_3()
	{
		return method_0().method_4(194, 1) switch
		{
			0 => Enum233.const_0, 
			1 => Enum233.const_1, 
			2 => Enum233.const_2, 
			3 => Enum233.const_3, 
			4 => Enum233.const_4, 
			5 => Enum233.const_5, 
			_ => Enum233.const_6, 
		};
	}

	internal static string smethod_0(Enum233 enum233_0)
	{
		return enum233_0 switch
		{
			Enum233.const_0 => "dist", 
			Enum233.const_1 => "ctr", 
			Enum233.const_2 => "l", 
			Enum233.const_3 => "r", 
			Enum233.const_4 => "just", 
			Enum233.const_5 => "justLow", 
			_ => null, 
		};
	}
}
