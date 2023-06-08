using System;
using ns5;

namespace Aspose.Slides.Effects;

public class SoftEdgeEffectiveData : EffectEffectiveData, ISoftEdgeEffectiveData
{
	private readonly double double_0 = 1.0;

	public double Radius => double_0;

	internal SoftEdgeEffectiveData(double radius)
	{
		double_0 = radius;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		throw new InvalidOperationException();
	}
}
