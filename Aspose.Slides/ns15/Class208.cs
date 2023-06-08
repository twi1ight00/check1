using Aspose.Slides;
using ns24;
using ns62;

namespace ns15;

internal class Class208
{
	public static void smethod_0(Class520 presetTextShape, Class2670 shapeContainer)
	{
		presetTextShape.TextShapeType = smethod_1(shapeContainer);
	}

	private static TextShapeType smethod_1(Class2670 shapeContainer)
	{
		if (shapeContainer.ShapeProp == null)
		{
			return TextShapeType.NotDefined;
		}
		return shapeContainer.ShapeProp.ShapeType switch
		{
			Enum425.const_136 => TextShapeType.Plain, 
			Enum425.const_137 => TextShapeType.Stop, 
			Enum425.const_138 => TextShapeType.Triangle, 
			Enum425.const_139 => TextShapeType.TriangleInverted, 
			Enum425.const_140 => TextShapeType.Chevron, 
			Enum425.const_141 => TextShapeType.ChevronInverted, 
			Enum425.const_142 => TextShapeType.RingInside, 
			Enum425.const_143 => TextShapeType.RingOutside, 
			Enum425.const_144 => TextShapeType.ArchUp, 
			Enum425.const_145 => TextShapeType.ArchDown, 
			Enum425.const_146 => TextShapeType.Circle, 
			Enum425.const_147 => TextShapeType.Button, 
			Enum425.const_148 => TextShapeType.ArchUpPour, 
			Enum425.const_149 => TextShapeType.ArchDownPour, 
			Enum425.const_150 => TextShapeType.CirclePour, 
			Enum425.const_151 => TextShapeType.ButtonPour, 
			Enum425.const_152 => TextShapeType.CurveUp, 
			Enum425.const_153 => TextShapeType.CurveDown, 
			Enum425.const_154 => TextShapeType.CascadeUp, 
			Enum425.const_155 => TextShapeType.CascadeDown, 
			Enum425.const_156 => TextShapeType.Wave1, 
			Enum425.const_157 => TextShapeType.Wave2, 
			Enum425.const_158 => TextShapeType.DoubleWave1, 
			Enum425.const_159 => TextShapeType.Wave4, 
			Enum425.const_160 => TextShapeType.Inflate, 
			Enum425.const_161 => TextShapeType.Deflate, 
			Enum425.const_162 => TextShapeType.InflateBottom, 
			Enum425.const_163 => TextShapeType.DeflateBottom, 
			Enum425.const_164 => TextShapeType.InflateTop, 
			Enum425.const_165 => TextShapeType.DeflateTop, 
			Enum425.const_166 => TextShapeType.DeflateInflate, 
			Enum425.const_167 => TextShapeType.DeflateInflateDeflate, 
			Enum425.const_168 => TextShapeType.FadeRight, 
			Enum425.const_169 => TextShapeType.FadeLeft, 
			Enum425.const_170 => TextShapeType.FadeUp, 
			Enum425.const_171 => TextShapeType.FadeDown, 
			Enum425.const_172 => TextShapeType.SlantUp, 
			Enum425.const_173 => TextShapeType.SlantDown, 
			Enum425.const_174 => TextShapeType.CanUp, 
			Enum425.const_175 => TextShapeType.CanDown, 
			Enum425.const_188 => TextShapeType.DoubleWave1, 
			_ => TextShapeType.NotDefined, 
		};
	}
}
