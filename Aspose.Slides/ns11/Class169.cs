using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns4;

namespace ns11;

internal sealed class Class169
{
	private readonly IWarningCallback iwarningCallback_0;

	private readonly Dictionary<string, Class64> dictionary_0 = new Dictionary<string, Class64>();

	private bool bool_0;

	private readonly IBaseSlide ibaseSlide_0;

	private Class63 class63_0;

	private readonly bool bool_1;

	private readonly bool bool_2;

	private readonly float float_0;

	private int int_0;

	private float float_1;

	private Interface2 interface2_0;

	private readonly Interface3 interface3_0;

	private IHyperlink ihyperlink_0;

	public IBaseSlide RenderingSlide => ibaseSlide_0;

	public Class63 BackgroundFill
	{
		get
		{
			return class63_0;
		}
		set
		{
			class63_0 = value;
		}
	}

	public bool CheckTransparencyOfAllImages
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool RasterizeMetafiles => bool_1;

	public bool PreserveBitmapAnimation => bool_2;

	public IWarningCallback WarningCallback => iwarningCallback_0;

	public float MaxMetafileRasterizationPixels => float_0;

	public int JpegQuality
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public float SufficientDpi
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public Interface2 DrawingControl
	{
		get
		{
			return interface2_0;
		}
		set
		{
			interface2_0 = value;
		}
	}

	public Interface3 ShapeDrawingCallback => interface3_0;

	public IHyperlink Hyperlink
	{
		get
		{
			return ihyperlink_0;
		}
		set
		{
			ihyperlink_0 = value;
		}
	}

	public Class64 method_0(string cachedImageCode)
	{
		dictionary_0.TryGetValue(cachedImageCode, out var value);
		return value;
	}

	public void method_1(string cachedImageCode, Class64 image)
	{
		dictionary_0[cachedImageCode] = image;
	}

	public string method_2(Image image)
	{
		foreach (KeyValuePair<string, Class64> item in dictionary_0)
		{
			if (item.Value.LoadedImage == image)
			{
				return item.Key;
			}
		}
		return null;
	}

	public Class169(IBaseSlide renderingSlide, Dictionary<string, Class64> imageCache, Class170 renderingOptions)
	{
		ibaseSlide_0 = renderingSlide;
		dictionary_0 = imageCache;
		bool_0 = renderingOptions.bool_0;
		iwarningCallback_0 = renderingOptions.iwarningCallback_0;
		float_0 = renderingOptions.float_0;
		bool_1 = renderingOptions.bool_1;
		bool_2 = renderingOptions.bool_2;
		int_0 = renderingOptions.byte_0;
		float_1 = renderingOptions.float_1;
		interface2_0 = renderingOptions.interface2_0;
		if (interface2_0 == null)
		{
			interface2_0 = Class165.class165_0;
		}
		interface3_0 = renderingOptions.interface3_0;
		if (interface3_0 == null)
		{
			interface3_0 = Class166.class166_0;
		}
	}
}
