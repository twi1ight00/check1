using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("f5fa705f-cc61-4b57-a634-4f5acbdae875")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class PointCollection : IEnumerable, IEnumerable<IPoint>, IPointCollection
{
	private List<IPoint> list_0 = new List<IPoint>();

	public int Count => list_0.Count;

	public IPoint this[int index] => list_0[index];

	IEnumerable IPointCollection.AsIEnumerable => this;

	internal void Add(IPoint item)
	{
		list_0.Add(item);
	}

	internal void Insert(int index, Point item)
	{
		list_0.Insert(index, item);
	}

	internal void Remove(Point item)
	{
		list_0.Remove(item);
	}

	internal void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	internal void Clear()
	{
		list_0.Clear();
	}

	IEnumerator<IPoint> IEnumerable<IPoint>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
