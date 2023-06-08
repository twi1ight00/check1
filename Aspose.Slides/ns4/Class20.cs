using System;
using Aspose.Slides;

namespace ns4;

internal abstract class Class20<T, TEffectiveDataPVITemp> : Class19<T, TEffectiveDataPVITemp>, IEffectiveData, Interface0 where T : IAccessiblePVIObject<TEffectiveDataPVITemp> where TEffectiveDataPVITemp : Class20<T, TEffectiveDataPVITemp>
{
	private T gparam_0;

	private Interface0 interface0_0;

	private bool bool_0;

	private Class21.Delegate3 delegate3_0;

	private uint uint_0;

	internal uint ActualVersion => uint_0;

	internal abstract TEffectiveDataPVITemp Default { get; }

	internal IBaseSlide Slide
	{
		get
		{
			if (!(gparam_0.Parent is ISlideComponent slideComponent))
			{
				return null;
			}
			return slideComponent.Slide;
		}
	}

	internal Class20(T parentAccessablePVIObject)
	{
		gparam_0 = parentAccessablePVIObject;
		uint_0 = uint.MaxValue;
	}

	internal Class20(Interface0 parentContainerEffectiveDataPVITemp)
	{
		interface0_0 = parentContainerEffectiveDataPVITemp;
		uint_0 = uint.MaxValue;
	}

	internal abstract TEffectiveDataPVITemp vmethod_3();

	internal virtual void vmethod_4()
	{
	}

	void Interface0.imethod_0()
	{
		method_0();
	}

	internal void method_0()
	{
		if (interface0_0 != null)
		{
			interface0_0.imethod_0();
			return;
		}
		if (gparam_0 != null)
		{
			TEffectiveDataPVITemp val = (bool_0 ? Default : vmethod_3());
			uint num = gparam_0.Version + val.ActualVersion;
			if (num != uint_0)
			{
				vmethod_0(val);
				vmethod_1(gparam_0);
				vmethod_4();
				IBaseSlide slide = Slide;
				FloatColor effectiveStyleColor = method_1(slide, val);
				vmethod_2(slide, effectiveStyleColor);
				uint_0 = num;
			}
			return;
		}
		throw new ArgumentNullException();
	}

	internal FloatColor method_1(IBaseSlide slide, TEffectiveDataPVITemp parentEffective)
	{
		ColorFormat colorFormat = Class22.smethod_0(gparam_0.Parent);
		delegate3_0 = ((colorFormat != null) ? new Class21.Delegate3(colorFormat.method_3) : parentEffective.delegate3_0);
		return (delegate3_0 != null) ? delegate3_0(slide) : null;
	}
}
