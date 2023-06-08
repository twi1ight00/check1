using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("0349f150-96ce-4b84-b5c5-20778e255690")]
[ClassInterface(ClassInterfaceType.None)]
public class ImageTransformOCollectionEffectiveData : ICollection, IEnumerable, IEnumerable<IEffectEffectiveData>, IImageTransformOCollectionEffectiveData, IEffectiveData
{
	private List<IEffectEffectiveData> list_0 = new List<IEffectEffectiveData>();

	public int Count => list_0.Count;

	public IEffectEffectiveData this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection IImageTransformOCollectionEffectiveData.AsICollection => this;

	IEnumerable IImageTransformOCollectionEffectiveData.AsIEnumerable => this;

	internal EffectEffectiveData Add(ImageTransformOperation operation, BaseSlide slide, FloatColor styleColor)
	{
		EffectEffectiveData @readonly = ((IEffect)operation).GetReadonly(slide, styleColor);
		list_0.Add(@readonly);
		return @readonly;
	}

	IEnumerator<IEffectEffectiveData> IEnumerable<IEffectEffectiveData>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ImageTransformOCollectionEffectiveData obj2))
		{
			return false;
		}
		return method_0(obj2);
	}

	internal bool method_0(IImageTransformOCollectionEffectiveData obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (list_0.Count != obj.Count)
		{
			return false;
		}
		if (0 < list_0.Count)
		{
			throw new NotImplementedException();
		}
		return true;
	}

	public override int GetHashCode()
	{
		return 23454;
	}
}
