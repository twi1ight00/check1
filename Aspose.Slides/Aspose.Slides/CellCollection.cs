using System;
using System.Collections;
using ns24;
using ns33;

namespace Aspose.Slides;

public abstract class CellCollection : ICollection, IEnumerable, IPresentationComponent, ISlideComponent, ICellCollection
{
	private Class304 class304_0 = new Class304();

	internal static Class1169.Delegate16 delegate16_0 = smethod_0;

	internal Table ParentTable => vmethod_1();

	public int Count => vmethod_2();

	public ICell this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException($"value of index = {index} is out of range 0..{Count}");
			}
			return vmethod_3(index).BaseCell;
		}
	}

	ICollection ICellCollection.AsICollection => this;

	IEnumerable ICellCollection.AsIEnumerable => this;

	ISlideComponent ICellCollection.AsISlideComponent => this;

	public IBaseSlide Slide => ParentTable.Slide;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	public IPresentation Presentation => ParentTable.Presentation;

	internal Class304 PPTXUnsupportedProps => class304_0;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal CellCollection()
	{
	}

	internal abstract int vmethod_0(double offset);

	internal abstract Table vmethod_1();

	internal abstract int vmethod_2();

	internal abstract Cell vmethod_3(int index);

	internal abstract IEnumerator vmethod_4();

	public IEnumerator GetEnumerator()
	{
		return vmethod_4();
	}

	private static bool smethod_0(object obj, object data)
	{
		return ((Cell)obj).MergedTo == null;
	}

	public void CopyTo(Array array, int index)
	{
		vmethod_5(array, index);
	}

	internal abstract void vmethod_5(Array array, int destIndex);
}
