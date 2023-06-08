using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ns5;

namespace Aspose.Slides.Effects;

public sealed class ImageTransformOperationCollection : IEnumerable, ICollection<IImageTransformOperation>, IEnumerable<IImageTransformOperation>, IImageTransformOperationCollection
{
	private readonly List<IImageTransformOperation> list_0 = new List<IImageTransformOperation>();

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public int Count => list_0.Count;

	public bool IsReadOnly => ((ICollection<IImageTransformOperation>)list_0).IsReadOnly;

	public IImageTransformOperation this[int index] => list_0[index];

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal uint Version
	{
		get
		{
			uint num = uint_0;
			foreach (ImageTransformOperation item in list_0)
			{
				num += item.Version;
			}
			return num;
		}
	}

	IEnumerable IImageTransformOperationCollection.AsIEnumerable => this;

	internal ImageTransformOperationCollection(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
	}

	internal string method_0(IBaseSlide slide, FloatColor styleColor)
	{
		StringBuilder stringBuilder = new StringBuilder();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ImageTransformOperation imageTransformOperation = (ImageTransformOperation)enumerator.Current;
				stringBuilder.Append(imageTransformOperation.vmethod_1(slide, styleColor));
				stringBuilder.Append(';');
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return stringBuilder.ToString();
	}

	internal Image method_1(IBaseSlide slide, FloatColor styleColor, Bitmap img, bool forceTransformation)
	{
		if (Count > 0 || forceTransformation)
		{
			Class190 @class = Class190.smethod_0(img);
			img.Dispose();
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ImageTransformOperation imageTransformOperation = (ImageTransformOperation)enumerator.Current;
						@class = imageTransformOperation.vmethod_0(@class, slide, styleColor);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			img = @class.method_4();
		}
		return img;
	}

	public void RemoveAt(int index)
	{
		uint_0 = Version;
		method_2();
		list_0.RemoveAt(index);
	}

	public bool Remove(IImageTransformOperation item)
	{
		uint_0 = Version;
		method_2();
		return list_0.Remove(item);
	}

	public void Clear()
	{
		uint_0 = Version;
		method_2();
		list_0.Clear();
	}

	public bool Contains(IImageTransformOperation item)
	{
		return list_0.Contains(item);
	}

	public void CopyTo(IImageTransformOperation[] array, int arrayIndex)
	{
		list_0.CopyTo(array, arrayIndex);
	}

	public void Add(IImageTransformOperation operation)
	{
		ImageTransformOperation imageTransformOperation = (ImageTransformOperation)operation;
		if (imageTransformOperation.Parent != null)
		{
			imageTransformOperation = imageTransformOperation.Clone();
		}
		imageTransformOperation.vmethod_2(Parent);
		list_0.Add(imageTransformOperation);
		method_2();
	}

	public IAlphaBiLevel AddAlphaBiLevelEffect(float threshold)
	{
		AlphaBiLevel alphaBiLevel = new AlphaBiLevel(threshold, Parent);
		list_0.Add(alphaBiLevel);
		method_2();
		return alphaBiLevel;
	}

	public IAlphaCeiling AddAlphaCeilingEffect()
	{
		AlphaCeiling alphaCeiling = new AlphaCeiling(Parent);
		list_0.Add(alphaCeiling);
		method_2();
		return alphaCeiling;
	}

	public IAlphaFloor AddAlphaFloorEffect()
	{
		AlphaFloor alphaFloor = new AlphaFloor(Parent);
		list_0.Add(alphaFloor);
		method_2();
		return alphaFloor;
	}

	public IAlphaInverse AddAlphaInverseEffect()
	{
		AlphaInverse alphaInverse = new AlphaInverse(Parent);
		list_0.Add(alphaInverse);
		method_2();
		return alphaInverse;
	}

	public IAlphaModulate AddAlphaModulateEffect()
	{
		AlphaModulate alphaModulate = new AlphaModulate(Parent);
		list_0.Add(alphaModulate);
		method_2();
		return alphaModulate;
	}

	public IAlphaModulateFixed AddAlphaModulateFixedEffect(float amount)
	{
		AlphaModulateFixed alphaModulateFixed = new AlphaModulateFixed(amount, Parent);
		list_0.Add(alphaModulateFixed);
		method_2();
		return alphaModulateFixed;
	}

	public IAlphaReplace AddAlphaReplaceEffect(float alpha)
	{
		AlphaReplace alphaReplace = new AlphaReplace(alpha, Parent);
		list_0.Add(alphaReplace);
		method_2();
		return alphaReplace;
	}

	public IBiLevel AddBiLevelEffect(float threshold)
	{
		BiLevel biLevel = new BiLevel(threshold, Parent);
		list_0.Add(biLevel);
		method_2();
		return biLevel;
	}

	public IBlur AddBlurEffect(double radius, bool grow)
	{
		Blur blur = new Blur(radius, grow, Parent);
		list_0.Add(blur);
		method_2();
		return blur;
	}

	public IColorChange AddColorChangeEffect()
	{
		ColorChange colorChange = new ColorChange(Parent);
		list_0.Add(colorChange);
		method_2();
		return colorChange;
	}

	public IColorReplace AddColorReplaceEffect()
	{
		ColorReplace colorReplace = new ColorReplace(Parent);
		list_0.Add(colorReplace);
		method_2();
		return colorReplace;
	}

	public IDuotone AddDuotoneEffect()
	{
		Duotone duotone = new Duotone(Parent);
		list_0.Add(duotone);
		method_2();
		return duotone;
	}

	public IFillOverlay AddFillOverlayEffect()
	{
		FillOverlay fillOverlay = new FillOverlay(Parent);
		list_0.Add(fillOverlay);
		method_2();
		return fillOverlay;
	}

	public IGrayScale AddGrayScaleEffect()
	{
		GrayScale grayScale = new GrayScale(Parent);
		list_0.Add(grayScale);
		method_2();
		return grayScale;
	}

	public IHSL AddHSLEffect(float hue, float saturation, float luminance)
	{
		HSL hSL = new HSL(hue, saturation, luminance, Parent);
		list_0.Add(hSL);
		method_2();
		return hSL;
	}

	public ILuminance AddLuminanceEffect(float brightness, float contrast)
	{
		Luminance luminance = new Luminance(brightness, contrast, Parent);
		list_0.Add(luminance);
		method_2();
		return luminance;
	}

	public ITint AddTintEffect(float hue, float amount)
	{
		Tint tint = new Tint(hue, amount, Parent);
		list_0.Add(tint);
		method_2();
		return tint;
	}

	private void method_2()
	{
		uint_0++;
	}

	IEnumerator<IImageTransformOperation> IEnumerable<IImageTransformOperation>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
