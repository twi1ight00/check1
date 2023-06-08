using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[Guid("8307610a-8fa0-4f1a-83e2-a8cb1db14dae")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class SoftEdge : ISoftEdge, IEffect
{
	private double double_0 = 1.0;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public double Radius
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_1();
		}
	}

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal uint Version => uint_0;

	internal SoftEdge(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
	}

	internal SoftEdge Clone()
	{
		return (SoftEdge)MemberwiseClone();
	}

	internal void method_0(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		method_1();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new SoftEdgeEffectiveData(double_0);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class44(double_0);
	}

	private void method_1()
	{
		uint_0++;
	}
}
