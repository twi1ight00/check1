using System;
using System.Runtime.InteropServices;
using ns12;

namespace Aspose.Slides.Export;

[Guid("3c6c5045-d90d-42c6-9271-9928d9dcfbab")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class SVGOptions : SaveOptions, ISaveOptions, ISVGOptions
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private int int_0;

	private ILinkEmbedController ilinkEmbedController_0 = Class2948.class2948_0;

	private ILinkEmbedController ilinkEmbedController_1;

	private Class181 class181_0;

	private int int_1 = 85;

	private ISvgShapeFormattingController isvgShapeFormattingController_0;

	public bool VectorizeText
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

	public int MetafileRasterizationDpi
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 1)
			{
				throw new ArgumentException("MetafileRasterizationDpi can't be less than 1");
			}
			int_0 = value;
		}
	}

	public bool Disable3DText
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool DisableGradientSplit
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool DisableLineEndCropping
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	internal Class181 FontHandlingRules => class181_0;

	public static SVGOptions Default => new SVGOptions();

	public static SVGOptions Simple
	{
		get
		{
			SVGOptions sVGOptions = new SVGOptions();
			sVGOptions.Disable3DText = true;
			sVGOptions.VectorizeText = false;
			sVGOptions.DisableGradientSplit = true;
			sVGOptions.DisableLineEndCropping = true;
			sVGOptions.FontHandlingRules.Clear();
			return sVGOptions;
		}
	}

	public static SVGOptions WYSIWYG
	{
		get
		{
			SVGOptions sVGOptions = new SVGOptions();
			sVGOptions.VectorizeText = true;
			sVGOptions.MetafileRasterizationDpi = 300;
			return sVGOptions;
		}
	}

	public int JpegQuality
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value < 1 || value > 100)
			{
				throw new ArgumentOutOfRangeException($"Value for JpegQuality ({value}) is out of range 1..100");
			}
			int_1 = value;
		}
	}

	public ISvgShapeFormattingController ShapeFormattingController
	{
		get
		{
			return isvgShapeFormattingController_0;
		}
		set
		{
			isvgShapeFormattingController_0 = value;
		}
	}

	internal ILinkEmbedController LinkEmbedController
	{
		get
		{
			return ilinkEmbedController_1;
		}
		set
		{
			ilinkEmbedController_1 = value;
			ilinkEmbedController_0 = value ?? Class2948.class2948_0;
		}
	}

	ISaveOptions ISVGOptions.AsISaveOptions => this;

	public SVGOptions()
	{
		class181_0 = new Class181();
		class181_0.method_0("Webdings", Enum14.const_2);
		class181_0.method_1("\\AWingdings\\s?[23]?\\z", Enum14.const_2);
		class181_0.method_0("Symbol", Enum14.const_2);
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		int_0 = 72;
	}

	public SVGOptions(ILinkEmbedController linkEmbedController)
		: this()
	{
		LinkEmbedController = linkEmbedController;
	}

	internal ILinkEmbedController method_0()
	{
		return ilinkEmbedController_0;
	}

	internal ISVGOptions Clone()
	{
		SVGOptions sVGOptions = (SVGOptions)MemberwiseClone();
		sVGOptions.class181_0 = new Class181(class181_0);
		return sVGOptions;
	}
}
