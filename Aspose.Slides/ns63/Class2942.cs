using System;
using System.Collections;
using System.IO;
using Aspose.Slides;
using ns60;

namespace ns63;

internal sealed class Class2942 : ICollection, IEnumerable, ICloneable
{
	internal SortedList sortedList_0 = new SortedList();

	public Class2978 this[int index] => (Class2978)sortedList_0.GetByIndex(index);

	public int Count => sortedList_0.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public Class2942()
	{
	}

	public Class2942(BinaryReader reader)
	{
		method_2(reader);
	}

	public int Add(Class2978 value)
	{
		if (value.ParentCollection != null)
		{
			throw new PptEditException("Can't add already used tab");
		}
		value.ParentCollection = this;
		if (sortedList_0.ContainsKey(value.Position))
		{
			if (((Class2978)sortedList_0[value.Position]).TabType == Enum456.const_0)
			{
				sortedList_0[value.Position] = value;
			}
		}
		else
		{
			sortedList_0[value.Position] = value;
		}
		return sortedList_0.IndexOfKey(value.Position);
	}

	public void Clear()
	{
		foreach (Class2978 value in sortedList_0.Values)
		{
			value.ParentCollection = null;
		}
		sortedList_0.Clear();
	}

	public void RemoveAt(int index)
	{
		((Class2978)sortedList_0.GetByIndex(index)).ParentCollection = null;
		sortedList_0.RemoveAt(index);
	}

	public void method_0(int position)
	{
		int num = sortedList_0.IndexOfKey((short)position);
		if (num >= 0)
		{
			RemoveAt(num);
		}
	}

	public Class2978 method_1(int position)
	{
		int num = sortedList_0.IndexOfKey((short)position);
		if (num >= 0)
		{
			return this[num];
		}
		return null;
	}

	internal void method_2(BinaryReader reader)
	{
		ushort num = reader.ReadUInt16();
		sortedList_0.Clear();
		for (int i = 0; i < num; i++)
		{
			Add(new Class2978(reader));
		}
	}

	internal void method_3(BinaryWriter writer)
	{
		_ = writer.BaseStream.Position;
		writer.Write((ushort)sortedList_0.Count);
		foreach (DictionaryEntry item in sortedList_0)
		{
			((Class2978)item.Value).method_2(writer);
		}
	}

	internal int method_4()
	{
		return 2 + sortedList_0.Count * 4;
	}

	internal bool method_5(Class2942 tabStopCollection)
	{
		if (sortedList_0.Count != tabStopCollection.sortedList_0.Count)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < sortedList_0.Count)
			{
				Class2978 @class = (Class2978)sortedList_0[num];
				Class2978 class2 = (Class2978)tabStopCollection.sortedList_0[num];
				if (@class.Position != class2.Position || @class.TabType != class2.TabType)
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public void CopyTo(Array array, int index)
	{
		sortedList_0.Values.CopyTo(array, index);
	}

	public IEnumerator GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}

	public object Clone()
	{
		return MemberwiseClone();
	}
}
