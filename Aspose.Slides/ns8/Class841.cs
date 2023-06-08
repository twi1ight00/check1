using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.SmartArt;
using ns16;
using ns56;

namespace ns8;

internal class Class841 : IEnumerable, IEnumerable<Class1073>
{
	private Class2180 class2180_0;

	private List<Class1073> list_0;

	public int Count => list_0.Count;

	public Class1073 this[int index] => list_0[index];

	public Class841(Class2180 ptListElementData, SmartArt parent, Class1341 deserializationContext)
	{
		class2180_0 = ptListElementData;
		Class2179[] ptList = class2180_0.PtList;
		list_0 = new List<Class1073>(ptList.Length);
		Class2179[] array = ptList;
		foreach (Class2179 ptElementData in array)
		{
			list_0.Add(new Class1073(ptElementData, parent, deserializationContext));
		}
	}

	public void Add(Class1073 item)
	{
		list_0.Add(item);
		class2180_0.delegate2270_0(Class1073.smethod_2(item));
	}

	public IEnumerator<Class1073> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	internal Class1073 method_0(string id, Enum337 type)
	{
		foreach (Class1073 item in list_0)
		{
			if ((item.Type == type || type == Enum337.const_0) && (id == null || item.ModelId == id))
			{
				return item;
			}
		}
		return null;
	}

	internal Class1073 method_1(string id, string layoutName)
	{
		foreach (Class1073 item in list_0)
		{
			if (item.PropertySet.PresAssocID == id && item.PropertySet.PresName == layoutName)
			{
				return item;
			}
		}
		return null;
	}
}
