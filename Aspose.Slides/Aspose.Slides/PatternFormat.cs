using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using ns276;
using ns28;
using ns33;

namespace Aspose.Slides;

public class PatternFormat : IPatternFormat
{
	internal class Class517
	{
		internal byte[,] byte_0;

		internal int int_0;
	}

	internal static readonly Dictionary<int, Class517> dictionary_0 = smethod_0("patterns.bin");

	private ColorFormat colorFormat_0;

	private ColorFormat colorFormat_1;

	private PatternStyle patternStyle_0;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public PatternStyle PatternStyle
	{
		get
		{
			return patternStyle_0;
		}
		set
		{
			patternStyle_0 = value;
			method_5();
		}
	}

	public IColorFormat ForeColor => colorFormat_0;

	public IColorFormat BackColor => colorFormat_1;

	internal IBaseSlide Slide
	{
		get
		{
			if (!(ipresentationComponent_0 is ISlideComponent slideComponent))
			{
				return null;
			}
			return slideComponent.Slide;
		}
	}

	internal uint Version => uint_0 + colorFormat_0.Version + colorFormat_1.Version;

	internal PatternFormat(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0 = new ColorFormat(parent as ISlideComponent, PresetColor.Black);
		colorFormat_1 = new ColorFormat(parent as ISlideComponent, PresetColor.Black);
	}

	internal void method_0(PatternFormat source)
	{
		patternStyle_0 = source.patternStyle_0;
		colorFormat_0.method_0(source.colorFormat_0);
		colorFormat_1.method_0(source.colorFormat_1);
		method_5();
	}

	internal void method_1(IPatternFormatEffectiveData source)
	{
		patternStyle_0 = source.PatternStyle;
		colorFormat_0.method_1(source.ForeColor);
		colorFormat_1.method_1(source.BackColor);
		method_5();
	}

	public Bitmap GetTileImage(Color background, Color foreground)
	{
		return smethod_1(indexed: false, patternStyle_0, background, foreground);
	}

	public Bitmap GetTileImage(Color styleColor)
	{
		IBaseSlide slide = Slide;
		FloatColor styleColor2 = new FloatColor(styleColor);
		return smethod_1(indexed: false, patternStyle_0, colorFormat_1.method_5(slide, styleColor2), colorFormat_0.method_5(slide, styleColor2));
	}

	private static Dictionary<int, Class517> smethod_0(string path)
	{
		Dictionary<int, Class517> dictionary = new Dictionary<int, Class517>();
		using Stream zipStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.templates.zip");
		using Class6752 @class = Class6752.Read(zipStream);
		Class6751 class2 = @class[path];
		using Stream stream = class2.method_19();
		using BinaryReader binaryReader = new BinaryReader(stream);
		bool flag = true;
		try
		{
			while (true)
			{
				BitArray bitArray = new BitArray(256, defaultValue: false);
				flag = true;
				if (stream.Position >= stream.Length - 2L)
				{
					break;
				}
				int key = binaryReader.ReadInt16();
				flag = false;
				int num = binaryReader.ReadByte();
				int num2 = binaryReader.ReadByte();
				byte[,] array = new byte[num2, num];
				for (int i = 0; i < num2; i++)
				{
					for (int j = 0; j < num; j++)
					{
						array[i, j] = binaryReader.ReadByte();
						bitArray[array[i, j]] = true;
					}
				}
				Class517 class3 = new Class517();
				class3.byte_0 = array;
				class3.int_0 = 0;
				for (int k = 0; k < bitArray.Count; k++)
				{
					if (bitArray[k])
					{
						class3.int_0++;
					}
				}
				dictionary[key] = class3;
			}
		}
		catch (EndOfStreamException ex)
		{
			Class1165.smethod_28(ex);
		}
		if (!flag)
		{
			throw new PptxException("Internal error: can't initialize pattern data.");
		}
		return dictionary;
	}

	internal static Bitmap smethod_1(bool indexed, PatternStyle patternStyle, Color background, Color foreground)
	{
		if (!dictionary_0.TryGetValue((int)patternStyle, out var value))
		{
			value = dictionary_0[1];
		}
		bool flag = background.A < byte.MaxValue || foreground.A < byte.MaxValue;
		Bitmap bitmap = new Bitmap(value.byte_0.GetUpperBound(1) + 1, value.byte_0.GetUpperBound(0) + 1, flag ? PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
		for (int i = 0; i <= value.byte_0.GetUpperBound(0); i++)
		{
			for (int j = 0; j <= value.byte_0.GetUpperBound(1); j++)
			{
				float num = (float)(int)value.byte_0[i, j] / 255f;
				float num2 = 1f - num;
				bitmap.SetPixel(j, i, Color.FromArgb((int)Math.Round((float)(int)foreground.A * num + (float)(int)background.A * num2), (int)Math.Round((float)(int)foreground.R * num + (float)(int)background.R * num2), (int)Math.Round((float)(int)foreground.G * num + (float)(int)background.G * num2), (int)Math.Round((float)(int)foreground.B * num + (float)(int)background.B * num2)));
			}
		}
		bitmap.SetResolution(72f, 72f);
		return bitmap;
	}

	internal void method_2(Class399 hatch)
	{
		colorFormat_0.Color = hatch.Color;
		if (hatch.Style == Enum49.const_0)
		{
			if (hatch.Rotation != 0 && hatch.Rotation != 3600)
			{
				if (hatch.Rotation == 900)
				{
					if (hatch.Distance < 25.0)
					{
						patternStyle_0 = PatternStyle.LightVertical;
					}
					else
					{
						patternStyle_0 = PatternStyle.Vertical;
					}
				}
				else if (hatch.Rotation > 0 && hatch.Rotation < 900)
				{
					patternStyle_0 = PatternStyle.LightUpwardDiagonal;
				}
				else if (hatch.Rotation > 900 && hatch.Rotation < 3600)
				{
					patternStyle_0 = PatternStyle.LightDownwardDiagonal;
				}
				else
				{
					patternStyle_0 = PatternStyle.Unknown;
					method_5();
				}
			}
			else if (hatch.Distance < 25.0)
			{
				patternStyle_0 = PatternStyle.LightHorizontal;
			}
			else
			{
				patternStyle_0 = PatternStyle.Horizontal;
			}
		}
		else if (hatch.Rotation == 900)
		{
			if (hatch.Distance < 25.0)
			{
				patternStyle_0 = PatternStyle.Cross;
			}
			else
			{
				patternStyle_0 = PatternStyle.LargeGrid;
			}
		}
		else
		{
			patternStyle_0 = PatternStyle.DiagonalCross;
		}
	}

	internal void method_3(Class470 fillProp, Class476 odpPackage, FloatColor styleColor)
	{
		fillProp.FillImageRenderingStyle = Enum38.const_1;
		string imgName = (fillProp.FillImageName = "Img" + odpPackage.int_0++);
		IBaseSlide slide = Slide;
		if (slide != null)
		{
			IPPImage image = slide.Presentation.Images.AddImage(smethod_1(indexed: true, patternStyle_0, ((ColorFormat)BackColor).method_5(slide, styleColor), ((ColorFormat)ForeColor).method_5(slide, styleColor)));
			odpPackage.class465_0.method_3(imgName, odpPackage.method_9(image));
		}
	}

	internal void method_4(Class470 fillProp, Class476 odpPackage)
	{
		string text2 = (fillProp.HatchName = "Hatch" + odpPackage.int_0++);
		Class399 @class = odpPackage.class465_0.method_6(text2);
		@class.DisplayName = text2;
		@class.Color = colorFormat_0.Color;
		switch (patternStyle_0)
		{
		case PatternStyle.SmallGrid:
			@class.Style = Enum49.const_1;
			@class.Rotation = 900;
			@class.Distance = 2.89;
			break;
		case PatternStyle.LightUpwardDiagonal:
		case PatternStyle.WideUpwardDiagonal:
		case PatternStyle.DashedDownwardDiagonal:
			@class.Style = Enum49.const_0;
			@class.Rotation = 450;
			@class.Distance = 14.4;
			break;
		case PatternStyle.DarkVertical:
		case PatternStyle.LightVertical:
		case PatternStyle.NarrowVertical:
		case PatternStyle.DashedVertical:
			@class.Style = Enum49.const_0;
			@class.Rotation = 900;
			@class.Distance = 2.89;
			break;
		case PatternStyle.LargeGrid:
			@class.Style = Enum49.const_1;
			@class.Rotation = 900;
			@class.Distance = 14.4;
			break;
		case PatternStyle.DottedDiamond:
		case PatternStyle.LargeCheckerBoard:
			@class.Style = Enum49.const_1;
			@class.Rotation = 450;
			@class.Distance = 2.89;
			break;
		case PatternStyle.DiagonalBrick:
		case PatternStyle.OutlinedDiamond:
			@class.Style = Enum49.const_1;
			@class.Rotation = 2700;
			@class.Distance = 2.89;
			break;
		case PatternStyle.SmallCheckerBoard:
		case PatternStyle.Trellis:
		case PatternStyle.Plaid:
			@class.Style = Enum49.const_1;
			@class.Rotation = 450;
			@class.Distance = 2.89;
			break;
		case PatternStyle.HorizontalBrick:
		case PatternStyle.SolidDiamond:
		case PatternStyle.DottedGrid:
			@class.Style = Enum49.const_1;
			@class.Rotation = 900;
			@class.Distance = 2.89;
			break;
		case PatternStyle.NotDefined:
		case PatternStyle.Unknown:
		case PatternStyle.Percent05:
		case PatternStyle.Percent10:
		case PatternStyle.Percent20:
		case PatternStyle.Percent25:
		case PatternStyle.Percent30:
		case PatternStyle.Percent40:
		case PatternStyle.Percent50:
		case PatternStyle.Percent60:
		case PatternStyle.Percent70:
		case PatternStyle.Percent80:
		case PatternStyle.Percent90:
		case PatternStyle.LargeConfetti:
		case PatternStyle.SmallConfetti:
		case PatternStyle.Zigzag:
		case PatternStyle.Sphere:
		case PatternStyle.Weave:
		case PatternStyle.Divot:
			@class.Style = Enum49.const_0;
			@class.Rotation = 900;
			@class.Distance = 2.89;
			break;
		case PatternStyle.Percent75:
		case PatternStyle.DarkUpwardDiagonal:
			break;
		case PatternStyle.DarkDownwardDiagonal:
		case PatternStyle.LightDownwardDiagonal:
		case PatternStyle.WideDownwardDiagonal:
		case PatternStyle.DashedUpwardDiagonal:
		case PatternStyle.Shingle:
			@class.Style = Enum49.const_0;
			@class.Rotation = 2700;
			@class.Distance = 14.4;
			break;
		case PatternStyle.DarkHorizontal:
		case PatternStyle.LightHorizontal:
		case PatternStyle.NarrowHorizontal:
		case PatternStyle.DashedHorizontal:
		case PatternStyle.Wave:
			@class.Rotation = 0;
			@class.Style = Enum49.const_0;
			@class.Distance = 2.89;
			break;
		case PatternStyle.Horizontal:
			@class.Style = Enum49.const_0;
			@class.Rotation = 0;
			@class.Distance = 14.4;
			break;
		case PatternStyle.Vertical:
			@class.Style = Enum49.const_0;
			@class.Rotation = 900;
			@class.Distance = 14.4;
			break;
		case PatternStyle.Cross:
			@class.Style = Enum49.const_1;
			@class.Rotation = 900;
			@class.Distance = 14.4;
			break;
		case PatternStyle.DownwardDiagonal:
			@class.Style = Enum49.const_0;
			@class.Rotation = 2700;
			@class.Distance = 20.0;
			break;
		case PatternStyle.UpwardDiagonal:
			@class.Style = Enum49.const_0;
			@class.Rotation = 450;
			@class.Distance = 20.0;
			break;
		case PatternStyle.DiagonalCross:
			@class.Style = Enum49.const_1;
			@class.Rotation = 2700;
			@class.Distance = 2.89;
			break;
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PatternFormat patternFormat))
		{
			return base.Equals(obj);
		}
		if (!colorFormat_0.Equals(patternFormat.colorFormat_0))
		{
			return false;
		}
		if (!colorFormat_1.Equals(patternFormat.colorFormat_1))
		{
			return false;
		}
		if (patternStyle_0 != patternFormat.patternStyle_0)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return 23456;
	}

	private void method_5()
	{
		uint_0++;
	}
}
