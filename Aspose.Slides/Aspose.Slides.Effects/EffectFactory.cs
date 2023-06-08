using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("5F0D20F4-7B74-4C9E-ABC7-97ECF8DD4C8C")]
public class EffectFactory : IEffectFactory
{
	private static readonly IImageTransformOperationFactory iimageTransformOperationFactory_0 = new ImageTransformOperationFactory();

	public IImageTransformOperationFactory ImageTransformOperationFactory => iimageTransformOperationFactory_0;

	public IGlow CreateGlow()
	{
		return new Glow(null);
	}

	public IInnerShadow CreateInnerShadow()
	{
		return new InnerShadow(null);
	}

	public IOuterShadow CreateOuterShadow()
	{
		return new OuterShadow(null);
	}

	public IPresetShadow CreatePresetShadow()
	{
		return new PresetShadow(null);
	}

	public IReflection CreateReflection()
	{
		return new Reflection(null);
	}

	public ISoftEdge CreateSoftEdge()
	{
		return new SoftEdge(null);
	}
}
