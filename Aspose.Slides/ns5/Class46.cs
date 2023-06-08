using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Effects;

namespace ns5;

internal class Class46 : ICollection, IEnumerable, IEnumerable<IEffectEffectiveData>, IImageTransformOCollectionEffectiveData, IEffectiveData
{
	private List<IEffectEffectiveData> list_0 = new List<IEffectEffectiveData>();

	public int Count => list_0.Count;

	public IEffectEffectiveData this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection IImageTransformOCollectionEffectiveData.AsICollection => this;

	IEnumerable IImageTransformOCollectionEffectiveData.AsIEnumerable => this;

	internal IEffectEffectiveData Add(ImageTransformOperation operation)
	{
		EffectEffectiveDataPVITemp @readonly = ((IEffect)operation).GetReadonly();
		list_0.Add(@readonly);
		return @readonly;
	}

	internal string method_0()
	{
		StringBuilder stringBuilder = new StringBuilder();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				EffectEffectiveDataPVITemp effectEffectiveDataPVITemp = (EffectEffectiveDataPVITemp)enumerator.Current;
				stringBuilder.Append(effectEffectiveDataPVITemp.vmethod_1());
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

	internal Image method_1(Bitmap img, bool forceTransformation)
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
						EffectEffectiveDataPVITemp effectEffectiveDataPVITemp = (EffectEffectiveDataPVITemp)enumerator.Current;
						@class = effectEffectiveDataPVITemp.vmethod_0(@class);
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

	public override bool Equals(object obj)
	{
		if (!(obj is Class46 obj2))
		{
			return false;
		}
		return method_2(obj2);
	}

	internal bool method_2(Class46 obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (list_0.Count != obj.list_0.Count)
		{
			return false;
		}
		if (0 < list_0.Count)
		{
			throw new NotImplementedException();
		}
		return true;
	}

	internal bool method_3(IImageTransformOCollectionEffectiveData obj)
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
}
