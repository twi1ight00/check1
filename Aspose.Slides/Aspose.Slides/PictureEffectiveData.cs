using Aspose.Slides.Effects;

namespace Aspose.Slides;

public class PictureEffectiveData : IPictureEffectiveData, IEffectiveData
{
	internal string string_0;

	internal PPImage ppimage_0;

	private ImageTransformOCollectionEffectiveData imageTransformOCollectionEffectiveData_0;

	public IPPImage Image => ppimage_0;

	public string LinkPathLong => string_0;

	public IImageTransformOCollectionEffectiveData ImageTransform => imageTransformOCollectionEffectiveData_0;

	internal PictureEffectiveData(ISlidesPicture source, BaseSlide slide, FloatColor styleColor)
	{
		string_0 = source.LinkPathLong;
		ppimage_0 = (PPImage)source.Image;
		imageTransformOCollectionEffectiveData_0 = new ImageTransformOCollectionEffectiveData();
		foreach (ImageTransformOperation item in source.ImageTransform)
		{
			imageTransformOCollectionEffectiveData_0.Add(item, slide, styleColor);
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PictureEffectiveData obj2))
		{
			return false;
		}
		return method_0(obj2);
	}

	internal bool method_0(IPictureEffectiveData obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!ppimage_0.Equals(obj.Image))
		{
			return false;
		}
		if (!imageTransformOCollectionEffectiveData_0.method_0(obj.ImageTransform))
		{
			return false;
		}
		if (string_0 != obj.LinkPathLong)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return 23454;
	}
}
