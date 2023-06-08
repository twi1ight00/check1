using Aspose.Slides;
using Aspose.Slides.Charts;
using ns24;
using ns56;

namespace ns25;

internal class Class312 : Class278, IPresentationComponent, ISlideComponent, IChartComponent, ILayoutable
{
	private Class885 class885_0 = new Class885();

	private IChart ichart_0;

	public float X
	{
		get
		{
			return class885_0.X;
		}
		set
		{
			class885_0.X = value;
		}
	}

	public float Y
	{
		get
		{
			return class885_0.Y;
		}
		set
		{
			class885_0.Y = value;
		}
	}

	public float Width
	{
		get
		{
			return class885_0.Width;
		}
		set
		{
			class885_0.Width = value;
		}
	}

	public float Height
	{
		get
		{
			return class885_0.Height;
		}
		set
		{
			class885_0.Height = value;
		}
	}

	public float Right => class885_0.Right;

	public float Bottom => class885_0.Bottom;

	public Class2081 XMode
	{
		get
		{
			return class885_0.XMode;
		}
		set
		{
			class885_0.XMode = value;
		}
	}

	public Class2081 YMode
	{
		get
		{
			return class885_0.YMode;
		}
		set
		{
			class885_0.YMode = value;
		}
	}

	public Class2081 WMode
	{
		get
		{
			return class885_0.WMode;
		}
		set
		{
			class885_0.WMode = value;
		}
	}

	public Class2081 HMode
	{
		get
		{
			return class885_0.HMode;
		}
		set
		{
			class885_0.HMode = value;
		}
	}

	public Class1885 ExtensionListOfLayout
	{
		get
		{
			return class885_0.ExtensionListOfLayout;
		}
		set
		{
			class885_0.ExtensionListOfLayout = value;
		}
	}

	public Class1885 ExtensionListOfManualLayout
	{
		get
		{
			return class885_0.ExtensionListOfManualLayout;
		}
		set
		{
			class885_0.ExtensionListOfManualLayout = value;
		}
	}

	public IChart Chart => ichart_0;

	IChartComponent ILayoutable.AsIChartComponent => this;

	ISlideComponent IChartComponent.AsISlideComponent => this;

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (ichart_0 == null)
			{
				return null;
			}
			return ichart_0.Slide;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (ichart_0 == null)
			{
				return null;
			}
			return ichart_0.Presentation;
		}
	}

	public Class312(IChart parent)
	{
		ichart_0 = parent;
	}
}
