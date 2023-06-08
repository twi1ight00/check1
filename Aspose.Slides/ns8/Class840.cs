using System.Collections;
using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class840 : IEnumerable, IEnumerable<Class839>
{
	private Class2164 class2164_0;

	private List<Class839> list_0;

	public int Count => list_0.Count;

	public Class839 this[int index] => list_0[index];

	public Class840(Class2164 cxnListElementData)
	{
		class2164_0 = cxnListElementData;
		Class2163[] cxnList = cxnListElementData.CxnList;
		list_0 = new List<Class839>(cxnList.Length);
		Class2163[] array = cxnList;
		foreach (Class2163 cxnElementData in array)
		{
			list_0.Add(new Class839(cxnElementData));
		}
	}

	public void Add(Class839 item)
	{
		list_0.Add(item);
		class2164_0.delegate2222_0(Class839.smethod_0(item));
	}

	internal Class839 method_0(Enum330 type, Class1073 source, Class1073 destination, string layoutId)
	{
		Class839 @class = new Class839(type);
		@class.method_0(source, this);
		@class.method_1(destination, this);
		@class.method_4(layoutId);
		Add(@class);
		return @class;
	}

	public IEnumerator<Class839> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
