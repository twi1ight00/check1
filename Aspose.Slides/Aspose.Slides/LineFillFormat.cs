using System;
using System.Threading;

namespace Aspose.Slides;

public class LineFillFormat : IFillParamSource, ILineFillFormat
{
	internal delegate void Delegate8();

	private Delegate8 delegate8_0;

	internal FillType fillType_0 = FillType.NotDefined;

	internal ColorFormat colorFormat_0;

	internal GradientFormat gradientFormat_0;

	internal PatternFormat patternFormat_0;

	internal NullableBool nullableBool_0 = NullableBool.NotDefined;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public FillType FillType
	{
		get
		{
			return fillType_0;
		}
		set
		{
			if (value != FillType.Picture && value != FillType.Group)
			{
				if (fillType_0 != value)
				{
					fillType_0 = value;
					if (delegate8_0 != null)
					{
						delegate8_0();
					}
					method_2();
				}
				return;
			}
			throw new Exception("LineFillFormat.FillType cannot be FillType.Picture or FillType.Group.");
		}
	}

	public IColorFormat SolidFillColor => colorFormat_0;

	public IGradientFormat GradientFormat => gradientFormat_0;

	public IPatternFormat PatternFormat => patternFormat_0;

	public NullableBool RotateWithShape
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
			method_2();
		}
	}

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

	internal uint Version => uint_0 + colorFormat_0.Version + gradientFormat_0.Version + patternFormat_0.Version;

	IFillParamSource ILineFillFormat.AsIFillParamSource => this;

	internal event Delegate8 FillTypeChanged
	{
		add
		{
			Delegate8 @delegate = delegate8_0;
			Delegate8 delegate2;
			do
			{
				delegate2 = @delegate;
				Delegate8 value2 = (Delegate8)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate8_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
		remove
		{
			Delegate8 @delegate = delegate8_0;
			Delegate8 delegate2;
			do
			{
				delegate2 = @delegate;
				Delegate8 value2 = (Delegate8)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate8_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
	}

	internal LineFillFormat(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0 = new ColorFormat(parent as ISlideComponent, PresetColor.Black);
		gradientFormat_0 = new GradientFormat(parent);
		patternFormat_0 = new PatternFormat(parent);
		nullableBool_0 = NullableBool.NotDefined;
	}

	internal void method_0(LineFillFormat source)
	{
		fillType_0 = source.fillType_0;
		colorFormat_0.method_0(source.colorFormat_0);
		gradientFormat_0.method_0(source.gradientFormat_0);
		patternFormat_0.method_0(source.patternFormat_0);
		nullableBool_0 = source.nullableBool_0;
		method_2();
	}

	internal void method_1(ILineFillFormatEffectiveData source)
	{
		fillType_0 = source.FillType;
		colorFormat_0.method_1(source.SolidFillColor);
		gradientFormat_0.method_1(source.GradientFormat);
		patternFormat_0.method_1(source.PatternFormat);
		nullableBool_0 = (source.RotateWithShape ? NullableBool.True : NullableBool.False);
		method_2();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is LineFillFormat lineFillFormat))
		{
			return false;
		}
		if (fillType_0 != lineFillFormat.fillType_0)
		{
			return false;
		}
		switch (fillType_0)
		{
		default:
			return true;
		case FillType.Solid:
			return colorFormat_0.Equals(lineFillFormat.colorFormat_0);
		case FillType.Gradient:
			if (gradientFormat_0.Equals(lineFillFormat.gradientFormat_0))
			{
				return nullableBool_0 == lineFillFormat.nullableBool_0;
			}
			return false;
		case FillType.Pattern:
			if (patternFormat_0.Equals(lineFillFormat.patternFormat_0))
			{
				return nullableBool_0 == lineFillFormat.nullableBool_0;
			}
			return false;
		}
	}

	public override int GetHashCode()
	{
		return 23453;
	}

	private void method_2()
	{
		uint_0++;
	}
}
