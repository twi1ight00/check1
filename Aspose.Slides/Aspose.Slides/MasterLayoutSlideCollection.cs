using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides;

public sealed class MasterLayoutSlideCollection : LayoutSlideCollection, IEnumerable<ILayoutSlide>, ICollection, IEnumerable, ILayoutSlideCollection, IMasterLayoutSlideCollection
{
	ILayoutSlideCollection IMasterLayoutSlideCollection.AsILayoutSlideCollection => this;

	internal MasterLayoutSlideCollection(MasterSlide parent)
		: base(parent)
	{
	}

	public ILayoutSlide AddClone(ILayoutSlide sourceLayout)
	{
		return base.PresentationInternal.LayoutSlides.AddClone(sourceLayout, (IMasterSlide)object_0);
	}

	public ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout)
	{
		ILayoutSlide layoutSlide = AddClone(sourceLayout);
		Reorder(index, layoutSlide);
		return layoutSlide;
	}

	public ILayoutSlide Add(SlideLayoutType layoutType, string layoutName)
	{
		return base.PresentationInternal.LayoutSlides.Add((IMasterSlide)object_0, layoutType, layoutName);
	}

	public ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName)
	{
		ILayoutSlide layoutSlide = Add(layoutType, layoutName);
		Reorder(index, layoutSlide);
		return layoutSlide;
	}

	public void RemoveAt(int index)
	{
		list_0[index].Remove();
	}

	public void Reorder(int index, ILayoutSlide layoutSlide)
	{
		if (index >= 0 && index < base.Count)
		{
			if (layoutSlide.Presentation != base.PresentationInternal)
			{
				throw new PptxEditException("Trying to move layout from other presentation.");
			}
			if (layoutSlide.MasterSlide != object_0)
			{
				throw new PptxEditException("Trying to move layout from other collection.");
			}
			int num = list_0.IndexOf(layoutSlide);
			if (index == num)
			{
				return;
			}
			lock (((ICollection)list_0).SyncRoot)
			{
				if (index < num)
				{
					for (int num2 = num; num2 > index; num2--)
					{
						list_0[num2] = list_0[num2 - 1];
					}
				}
				else
				{
					for (int i = num; i < index; i++)
					{
						list_0[i] = list_0[i + 1];
					}
				}
				list_0[index] = layoutSlide;
				return;
			}
		}
		throw new PptxEditException("Index must lay within [0..Count-1] range.");
	}
}
