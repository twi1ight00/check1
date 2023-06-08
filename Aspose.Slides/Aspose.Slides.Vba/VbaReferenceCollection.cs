using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[Guid("DA88A85A-B0DD-4575-971D-FFCA24C96E2F")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class VbaReferenceCollection : ICollection, IEnumerable, IEnumerable<IVbaReference>, IVbaReferenceCollection
{
	private readonly List<IVbaReference> list_0 = new List<IVbaReference>();

	private readonly VbaProject vbaProject_0;

	public int Count => list_0.Count;

	public IVbaReference this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection IVbaReferenceCollection.AsICollection => this;

	IEnumerable IVbaReferenceCollection.AsIEnumerable => this;

	internal List<IVbaReference> References => list_0;

	internal VbaReferenceCollection(VbaProject vbaProject)
	{
		vbaProject_0 = vbaProject;
	}

	public void Add(IVbaReference value)
	{
		vbaProject_0.method_0(value);
		list_0.Add(value);
	}

	IEnumerator<IVbaReference> IEnumerable<IVbaReference>.GetEnumerator()
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
