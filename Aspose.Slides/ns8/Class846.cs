using System.Collections.Generic;
using ns33;
using ns56;

namespace ns8;

internal class Class846
{
	private List<Enum117> list_0;

	private List<int> list_1;

	private List<Enum332> list_2;

	private List<int> list_3;

	private List<int> list_4;

	private List<bool> list_5;

	private static readonly Class1151 class1151_0 = new Class1151("none", "ancst", "ancstOrSelf", "ch", "des", "desOrSelf", "follow", "followSib", "par", "preced", "precedSib", "root", "self");

	public List<Enum117> Axis => list_0;

	public List<int> Counts => list_1;

	public List<Enum332> Types => list_2;

	public List<int> Starts => list_3;

	public List<int> Steps => list_4;

	public List<bool> HideLastTransitions => list_5;

	public Class846(Class2191 element)
	{
		list_2 = smethod_1(element.PtType);
		list_0 = smethod_0(element.Axis);
		list_1 = smethod_2(element.Cnt);
		list_3 = smethod_2(element.St);
		list_4 = smethod_2(element.Step);
		list_5 = smethod_3(element.HideLastTrans);
	}

	public Class846(Class2178 element)
	{
		list_2 = smethod_1(element.PtType);
		list_0 = smethod_0(element.Axis);
		list_1 = smethod_2(element.Cnt);
		list_3 = smethod_2(element.St);
		list_4 = smethod_2(element.Step);
		list_5 = smethod_3(element.HideLastTrans);
	}

	public Class846(Class2169 element)
	{
		list_2 = smethod_1(element.PtType);
		list_0 = smethod_0(element.Axis);
		list_1 = smethod_2(element.Cnt);
		list_3 = smethod_2(element.St);
		list_4 = smethod_2(element.Step);
		list_5 = smethod_3(element.HideLastTrans);
	}

	private static List<Enum117> smethod_0(string axis)
	{
		List<Enum117> list = new List<Enum117>();
		list.Clear();
		string[] array = axis.Split(' ');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Length != 0)
			{
				list.Add((Enum117)class1151_0[text]);
			}
		}
		return list;
	}

	private static List<Enum332> smethod_1(string ptType)
	{
		List<Enum332> list = new List<Enum332>();
		string[] array = ptType.Split(' ');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Length != 0)
			{
				list.Add(Class2463.smethod_0(text));
			}
		}
		return list;
	}

	private static List<int> smethod_2(string cnt)
	{
		List<int> list = new List<int>();
		string[] array = cnt.Split(' ');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Length != 0)
			{
				list.Add(int.Parse(text));
			}
		}
		return list;
	}

	private static List<bool> smethod_3(string hideLastTrans)
	{
		List<bool> list = new List<bool>();
		string[] array = hideLastTrans.Split(' ');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Length != 0)
			{
				bool item = true;
				switch (text)
				{
				case "false":
				case "0":
				case "False":
				case "f":
					item = false;
					break;
				}
				list.Add(item);
			}
		}
		return list;
	}
}
