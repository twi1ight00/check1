namespace Aspose.Slides.Effects;

internal interface IEffect
{
	EffectEffectiveData GetReadonly(BaseSlide slide, FloatColor styleColor);

	EffectEffectiveDataPVITemp GetReadonly();
}
