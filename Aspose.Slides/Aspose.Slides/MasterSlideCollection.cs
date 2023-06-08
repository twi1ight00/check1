using System;
using System.Collections;
using System.Collections.Generic;
using ns16;

namespace Aspose.Slides;

public sealed class MasterSlideCollection : ICollection, IEnumerable, IEnumerable<IMasterSlide>, IMasterSlideCollection
{
	internal List<IMasterSlide> list_0;

	private Presentation presentation_0;

	public int Count => list_0.Count;

	public IMasterSlide this[int index] => list_0[index];

	ICollection IMasterSlideCollection.AsICollection => this;

	IEnumerable IMasterSlideCollection.AsIEnumerable => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal MasterSlideCollection(Presentation presentation)
	{
		list_0 = new List<IMasterSlide>();
		presentation_0 = presentation;
	}

	internal void Add(IMasterSlide value)
	{
		list_0.Add(value);
	}

	internal IMasterSlide method_0()
	{
		MasterSlide masterSlide = new MasterSlide(presentation_0);
		list_0.Add(masterSlide);
		return masterSlide;
	}

	public void Remove(IMasterSlide value)
	{
		if (!list_0.Contains(value))
		{
			return;
		}
		lock (((ICollection)list_0).SyncRoot)
		{
			if (value.HasDependingSlides)
			{
				throw new PptxEditException("Error removing master slide: this master slide is used in presentation.");
			}
			List<ILayoutSlide> list = new List<ILayoutSlide>(value.LayoutSlides);
			foreach (ILayoutSlide item in list)
			{
				item.Remove();
			}
			list_0.Remove(value);
			((MasterSlide)value).PresentationInternal = null;
		}
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= list_0.Count)
		{
			throw new IndexOutOfRangeException("Error removing master slide: index out of range.");
		}
		Remove(list_0[index]);
	}

	public void RemoveUnused(bool ignorePreserveField)
	{
		lock (((ICollection)list_0).SyncRoot)
		{
			int num = 0;
			while (num < list_0.Count)
			{
				MasterSlide masterSlide = (MasterSlide)list_0[num];
				if ((!ignorePreserveField && masterSlide.Preserve) || masterSlide.HasDependingSlides)
				{
					num++;
				}
				else
				{
					Remove(list_0[num]);
				}
			}
		}
	}

	public IMasterSlide AddClone(IMasterSlide sourceMaster)
	{
		return method_1((MasterSlide)sourceMaster, cloneLinkedLayouts: true);
	}

	public IMasterSlide InsertClone(int index, IMasterSlide sourceMaster)
	{
		MasterSlide masterSlide = method_1((MasterSlide)sourceMaster, cloneLinkedLayouts: true);
		int num = list_0.IndexOf(masterSlide);
		if (index == num)
		{
			return masterSlide;
		}
		lock (((ICollection)list_0).SyncRoot)
		{
			for (int num2 = num; num2 > index; num2--)
			{
				list_0[num2] = list_0[num2 - 1];
			}
			list_0[index] = masterSlide;
			return masterSlide;
		}
	}

	internal MasterSlide method_1(MasterSlide sourceMaster, bool cloneLinkedLayouts)
	{
		MasterSlide masterSlide;
		if (sourceMaster.ParentPresentation == presentation_0)
		{
			masterSlide = (MasterSlide)Class1026.smethod_4(presentation_0, sourceMaster, cloneLinkedLayouts);
		}
		else
		{
			masterSlide = (MasterSlide)Class1026.smethod_4(presentation_0, sourceMaster, cloneLinkedLayouts);
			masterSlide.method_7(sourceMaster.Presentation.DefaultTextStyle);
			for (int i = 0; i < masterSlide.masterLayoutSlideCollection_0.Count; i++)
			{
				LayoutSlide layoutSlide = (LayoutSlide)masterSlide.masterLayoutSlideCollection_0[i];
				layoutSlide.method_7(sourceMaster.Presentation.DefaultTextStyle);
			}
		}
		return masterSlide;
	}

	internal IMasterSlide method_2(IMasterSlide sourceMaster, bool cloneLinkedLayouts)
	{
		MasterSlide masterSlide = (MasterSlide)sourceMaster;
		ulong slideInternalId = masterSlide.SlideInternalId;
		WeakReference weakReference = null;
		if (presentation_0.dictionary_0.ContainsKey(slideInternalId))
		{
			weakReference = presentation_0.dictionary_0[slideInternalId];
		}
		IMasterSlide masterSlide2 = ((weakReference == null) ? null : (weakReference.Target as MasterSlide));
		if (masterSlide2 == null)
		{
			masterSlide2 = method_1(masterSlide, cloneLinkedLayouts);
			presentation_0.dictionary_0[slideInternalId] = new WeakReference(masterSlide2);
		}
		return masterSlide2;
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	IEnumerator<IMasterSlide> IEnumerable<IMasterSlide>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
