using System;
using ns25;

namespace Aspose.Slides.Charts;

public class Format : IFormat
{
	private FillFormat fillFormat_0;

	private LineFormat lineFormat_0 = new LineFormat(null);

	private EffectFormat effectFormat_0 = new EffectFormat(null);

	private ThreeDFormat threeDFormat_0 = new ThreeDFormat(null);

	private Class323 class323_0 = new Class323();

	private uint uint_0;

	internal Class323 PPTXUnsupportedProps => class323_0;

	public IFillFormat Fill => fillFormat_0;

	public ILineFormat Line => lineFormat_0;

	public IEffectFormat Effect => effectFormat_0;

	public IThreeDFormat Effect3D => threeDFormat_0;

	internal uint Version => uint_0 + fillFormat_0.Version + lineFormat_0.Version + effectFormat_0.Version + threeDFormat_0.Version;

	internal Format(IChart parent)
	{
		fillFormat_0 = new FillFormat(parent);
		lineFormat_0.FillFormat.SolidFillColor.ColorType = ColorType.RGB;
	}

	internal void method_0(Format source)
	{
		fillFormat_0.method_0(source.fillFormat_0);
		lineFormat_0.method_0(source.lineFormat_0);
		effectFormat_0.method_0(source.effectFormat_0);
		threeDFormat_0.method_1(source.threeDFormat_0);
		if (source.PPTXUnsupportedProps.ExtensionList != null)
		{
			class323_0.ExtensionList = source.PPTXUnsupportedProps.ExtensionList.Clone();
		}
		method_1();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Format format))
		{
			return base.Equals(obj);
		}
		if (fillFormat_0.Equals(format.fillFormat_0) && lineFormat_0.Equals(format.lineFormat_0) && effectFormat_0.Equals(format.effectFormat_0))
		{
			return threeDFormat_0.Equals(format.threeDFormat_0);
		}
		return false;
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	private void method_1()
	{
		uint_0++;
	}
}
