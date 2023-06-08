using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Aspose.Slides;

public sealed class GradientStopCollection : ICollection, IEnumerable, IEnumerable<IGradientStop>, IGradientStopCollection
{
	internal List<IGradientStop> list_0;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public int Count => list_0.Count;

	public IGradientStop this[int index] => list_0[index];

	internal uint Version
	{
		get
		{
			uint num = uint_0;
			foreach (GradientStop item in list_0)
			{
				num += item.Version;
			}
			return num;
		}
	}

	ICollection IGradientStopCollection.AsICollection => this;

	IEnumerable IGradientStopCollection.AsIEnumerable => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal GradientStopCollection(IPresentationComponent parent)
	{
		list_0 = new List<IGradientStop>();
		ipresentationComponent_0 = parent;
	}

	internal GradientStop method_0(float position)
	{
		foreach (GradientStop item in list_0)
		{
			if (position == item.Position)
			{
				return item;
			}
		}
		return null;
	}

	internal IGradientStop Add(float position, IColorFormat color)
	{
		IGradientStop gradientStop = new GradientStop(position, color);
		list_0.Add(gradientStop);
		method_1();
		return gradientStop;
	}

	internal void Insert(int index, float position, ColorFormat color)
	{
		list_0.Insert(index, new GradientStop(position, color));
		method_1();
	}

	internal IGradientStop Add()
	{
		GradientStop gradientStop = new GradientStop(ipresentationComponent_0);
		list_0.Add(gradientStop);
		method_1();
		return gradientStop;
	}

	public IGradientStop Add(float position, Color color)
	{
		return Add(position, new ColorFormat(ipresentationComponent_0 as ISlideComponent, color));
	}

	public IGradientStop Add(float position, PresetColor presetColor)
	{
		return Add(position, new ColorFormat(ipresentationComponent_0 as ISlideComponent, presetColor));
	}

	public IGradientStop Add(float position, SchemeColor schemeColor)
	{
		return Add(position, new ColorFormat(ipresentationComponent_0 as ISlideComponent, schemeColor));
	}

	public void Insert(int index, float position, Color color)
	{
		Insert(index, position, new ColorFormat(ipresentationComponent_0 as ISlideComponent, color));
	}

	public void Insert(int index, float position, PresetColor presetColor)
	{
		Insert(index, position, new ColorFormat(ipresentationComponent_0 as ISlideComponent, presetColor));
	}

	public void Insert(int index, float position, SchemeColor schemeColor)
	{
		Insert(index, position, new ColorFormat(ipresentationComponent_0 as ISlideComponent, schemeColor));
	}

	public void RemoveAt(int index)
	{
		uint_0 = Version;
		method_1();
		list_0.RemoveAt(index);
	}

	public void Clear()
	{
		uint_0 = Version;
		method_1();
		list_0.Clear();
	}

	private void method_1()
	{
		uint_0++;
	}

	IEnumerator<IGradientStop> IEnumerable<IGradientStop>.GetEnumerator()
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
