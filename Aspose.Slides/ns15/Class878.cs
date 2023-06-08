using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using Aspose.Slides;
using ns62;
using ns63;

namespace ns15;

internal class Class878
{
	internal static byte[] byte_0 = new byte[105]
	{
		128, 122, 31, 240, 97, 0, 0, 0, 228, 66,
		239, 93, 34, 178, 227, 130, 73, 60, 57, 107,
		2, 187, 223, 95, 196, 40, 0, 0, 0, 8,
		0, 0, 0, 8, 0, 0, 0, 1, 0, 1,
		0, 0, 0, 0, 0, 32, 0, 0, 0, 137,
		11, 0, 0, 137, 11, 0, 0, 2, 0, 0,
		0, 2, 0, 0, 0, 255, 255, 255, 0, 0,
		0, 0, 0, 255, 0, 0, 0, 255, 0, 0,
		0, 255, 0, 0, 0, 247, 0, 0, 0, 255,
		0, 0, 0, 255, 0, 0, 0, 255, 0, 0,
		0, 127, 0, 0, 0
	};

	private PatternStyle patternStyle_0;

	private List<Class2911> list_0 = new List<Class2911>();

	private Class856 class856_0;

	public PatternStyle PatternStyle => patternStyle_0;

	public int ReferenceCount => list_0.Count;

	public Class878(PatternStyle patternStyle, Class856 serializationContext)
	{
		patternStyle_0 = patternStyle;
		class856_0 = serializationContext;
	}

	public void method_0(Class2911 odrawFillBlip)
	{
		list_0.Add(odrawFillBlip);
	}

	public Class2629 method_1(int blipId)
	{
		MemoryStream input = new MemoryStream(byte_0);
		BinaryReader reader = new BinaryReader(input);
		Class2629 @class = Class2950.smethod_0(reader) as Class2629;
		ResourceManager resourceManager = new ResourceManager(Class1060.string_0, Assembly.GetExecutingAssembly());
		byte[] bLIPFileData = (byte[])resourceManager.GetObject(Class1060.smethod_2(Class232.smethod_19(patternStyle_0)));
		Guid rgbUid = (Guid)resourceManager.GetObject(Class1060.smethod_2(Class232.smethod_19(patternStyle_0)) + " Guid");
		@class.BLIPFileData = bLIPFileData;
		@class.RgbUid = rgbUid;
		if (@class is Class2630)
		{
			((Class2630)@class).Tag = method_3(patternStyle_0);
		}
		method_2(blipId);
		return @class;
	}

	private void method_2(int blipId)
	{
		foreach (Class2911 item in list_0)
		{
			item.Value = (uint)blipId;
		}
	}

	private byte method_3(PatternStyle patternStyle)
	{
		switch (patternStyle)
		{
		default:
			throw new Exception();
		case PatternStyle.Percent05:
			return 196;
		case PatternStyle.Percent10:
			return 204;
		case PatternStyle.Percent20:
			return 212;
		case PatternStyle.Percent25:
			return 220;
		case PatternStyle.Percent30:
			return 228;
		case PatternStyle.Percent40:
			return 236;
		case PatternStyle.Percent50:
			return 197;
		case PatternStyle.Percent60:
			return 205;
		case PatternStyle.Percent70:
			return 213;
		case PatternStyle.Percent75:
			return 221;
		case PatternStyle.Percent80:
			return 229;
		case PatternStyle.Percent90:
			return 237;
		case PatternStyle.SmallCheckerBoard:
			return 219;
		case PatternStyle.Trellis:
			return 234;
		case PatternStyle.LightHorizontal:
			return 207;
		case PatternStyle.LightVertical:
			return 199;
		case PatternStyle.LightDownwardDiagonal:
			return 198;
		case PatternStyle.LightUpwardDiagonal:
			return 206;
		case PatternStyle.SmallGrid:
			return 203;
		case PatternStyle.DottedDiamond:
			return 218;
		case PatternStyle.WideDownwardDiagonal:
			return 230;
		case PatternStyle.WideUpwardDiagonal:
			return 238;
		case PatternStyle.DashedDownwardDiagonal:
			return 200;
		case PatternStyle.DashedUpwardDiagonal:
			return 208;
		case PatternStyle.NarrowVertical:
			return 215;
		case PatternStyle.NarrowHorizontal:
			return 223;
		case PatternStyle.DashedVertical:
			return 224;
		case PatternStyle.DashedHorizontal:
			return 216;
		case PatternStyle.LargeConfetti:
			return 240;
		case PatternStyle.LargeGrid:
			return 211;
		case PatternStyle.HorizontalBrick:
			return 225;
		case PatternStyle.LargeCheckerBoard:
			return 227;
		case PatternStyle.SmallConfetti:
			return 232;
		case PatternStyle.Zigzag:
			return 201;
		case PatternStyle.SolidDiamond:
			return 243;
		case PatternStyle.DiagonalBrick:
			return 217;
		case PatternStyle.OutlinedDiamond:
			return 235;
		case PatternStyle.Plaid:
			return 241;
		case PatternStyle.Sphere:
			return 242;
		case PatternStyle.Weave:
			return 233;
		case PatternStyle.DottedGrid:
			return 210;
		case PatternStyle.Divot:
			return 202;
		case PatternStyle.Shingle:
			return 226;
		case PatternStyle.Wave:
			return 209;
		case PatternStyle.DarkHorizontal:
		case PatternStyle.Horizontal:
			return 239;
		case PatternStyle.DarkVertical:
		case PatternStyle.Vertical:
			return 231;
		case PatternStyle.DarkDownwardDiagonal:
		case PatternStyle.DownwardDiagonal:
			return 214;
		case PatternStyle.Cross:
		case PatternStyle.DiagonalCross:
			throw new NotImplementedException();
		case PatternStyle.DarkUpwardDiagonal:
		case PatternStyle.UpwardDiagonal:
			return 222;
		}
	}
}
