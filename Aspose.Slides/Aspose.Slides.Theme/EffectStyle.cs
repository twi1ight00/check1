namespace Aspose.Slides.Theme;

public class EffectStyle : IEffectStyle
{
	private EffectFormat effectFormat_0 = new EffectFormat(null);

	private ThreeDFormat threeDFormat_0 = new ThreeDFormat(null);

	public IEffectFormat EffectFormat => effectFormat_0;

	public IThreeDFormat ThreeDFormat => threeDFormat_0;

	internal uint Version => effectFormat_0.Version + threeDFormat_0.Version;

	internal EffectStyle()
	{
	}

	internal void method_0(EffectStyle effectStyle)
	{
		effectFormat_0.method_0(effectStyle.effectFormat_0);
		threeDFormat_0.method_1(effectStyle.threeDFormat_0);
	}
}
