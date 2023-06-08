using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[ComVisible(true)]
[Guid("E17AB7D0-A96C-4C90-9D2A-8A17E733A572")]
[ClassInterface(ClassInterfaceType.None)]
public sealed class VbaModuleCollection : ICollection, IEnumerable, IEnumerable<IVbaModule>, IVbaModuleCollection
{
	[CompilerGenerated]
	private sealed class Class157
	{
		public string string_0;

		public bool method_0(IVbaModule m)
		{
			return m.Name == string_0;
		}
	}

	private readonly List<IVbaModule> list_0 = new List<IVbaModule>();

	private readonly VbaProject vbaProject_0;

	public int Count => list_0.Count;

	public IVbaModule this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection IVbaModuleCollection.AsICollection => this;

	IEnumerable IVbaModuleCollection.AsIEnumerable => this;

	internal VbaModuleCollection(VbaProject vbaProject)
	{
		vbaProject_0 = vbaProject;
	}

	internal void Add(IVbaModule value)
	{
		list_0.Add(value);
	}

	public void Remove(IVbaModule value)
	{
		if (list_0.Contains(value))
		{
			vbaProject_0.method_1(value.Name);
			list_0.Remove(value);
		}
	}

	public IVbaModule AddEmptyModule(string name)
	{
		if (string.IsNullOrEmpty(name.Trim()))
		{
			throw new ArgumentException("Name should not be an empty string", "name");
		}
		if (list_0.Find((IVbaModule m) => m.Name == name) != null)
		{
			throw new ArgumentException($"Module with name {name} already exists");
		}
		VbaModule vbaModule = vbaProject_0.AddEmptyModule(name);
		list_0.Add(vbaModule);
		return vbaModule;
	}

	IEnumerator<IVbaModule> IEnumerable<IVbaModule>.GetEnumerator()
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
