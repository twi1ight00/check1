using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class132 : Class116
{
	private delegate bool Delegate11(Class117 item);

	private List<Class837> list_0;

	private Class117[] class117_0;

	private Class117[] class117_1;

	private Class117[] class117_2;

	private Class117[] class117_3;

	public Class117[] ForSelfFromSelf => class117_0;

	public Class117[] ForSelfFromChildren => class117_1;

	public Class117[] ForChildren => class117_2;

	public Class117[] Equalizers => class117_3;

	public Class132(Class2157 diagramNode)
	{
		list_0 = new List<Class837>();
	}

	public override void vmethod_0(Class837 parent, Class836 context)
	{
		list_0.Add(parent);
		parent.Constraints = this;
	}

	protected override void vmethod_1()
	{
		method_9();
		foreach (Class837 item in list_0)
		{
			method_5(item);
			if (item.Algorithm is Class121 @class)
			{
				@class.method_8(item);
			}
		}
	}

	private void method_5(Class837 point)
	{
		foreach (Class117 child in base.Children)
		{
			List<Class837> list = child.method_5(point);
			if (list.Count <= 0)
			{
				continue;
			}
			_ = child.Type;
			if ((child.ReferencedType == Enum305.const_22 && child.Value == 0.0 && child.Operator != Enum326.const_1) || (child.Operator != Enum326.const_1 && child.Operator != Enum326.const_2))
			{
				continue;
			}
			double num = method_6(child, point);
			foreach (Class837 item in list)
			{
				double num2 = item.method_20(child.Type);
				if (num2 == 0.0 || (num2 != num && child.ForRel != Enum329.const_1))
				{
					item.method_22(child.Type, num);
				}
			}
		}
	}

	private double method_6(Class117 constraint, Class837 point)
	{
		double result = 0.0;
		if (constraint.ReferencedType == Enum305.const_22)
		{
			result = constraint.Value;
		}
		else if (constraint.ReferencedForRel == Enum329.const_1)
		{
			result = method_7(point, constraint.ReferencedType, constraint.ForRel, point.method_35(constraint));
		}
		else
		{
			Class117 @class = null;
			if (point.Constraints != null)
			{
				foreach (Class117 child in point.Constraints.Children)
				{
					if (child != constraint && child.Type == constraint.ReferencedType && child.ForRel == constraint.ReferencedForRel && child.ForName == constraint.ReferencedForName && child.PointType == constraint.ReferencedPointType && (child.Operator == Enum326.const_2 || child.Operator == Enum326.const_1))
					{
						@class = child;
						break;
					}
				}
			}
			if (@class != null)
			{
				result = method_6(@class, point) * point.method_35(constraint);
			}
			else if (Class102.smethod_12(constraint.ReferencedType))
			{
				result = method_7(point, constraint.ReferencedType, Enum329.const_2, point.method_35(constraint));
			}
		}
		return result;
	}

	private double method_7(Class837 point, Enum305 refType, Enum329 forRel, double factor)
	{
		return ((forRel == Enum329.const_1) ? point.method_32(refType) : point.method_33(refType)) * factor;
	}

	private List<Class117> method_8(Delegate11 predicate)
	{
		List<Class117> list = new List<Class117>();
		foreach (Class117 child in base.Children)
		{
			if (predicate(child))
			{
				list.Add(child);
			}
		}
		return list;
	}

	private void method_9()
	{
		List<Class117> list = new List<Class117>();
		List<Class117> list2 = new List<Class117>();
		foreach (Class117 child in base.Children)
		{
			if (child.ReferencedType == Enum305.const_22)
			{
				list.Add(child);
			}
			else
			{
				list2.Add(child);
			}
		}
		Dictionary<Enum329, List<Class117>> dictionary = smethod_5(list2);
		if (dictionary.ContainsKey(Enum329.const_1))
		{
			_ = dictionary[Enum329.const_1];
			smethod_3(dictionary[Enum329.const_1], list);
		}
		List<Class135> list3 = method_3<Class135>().method_8();
		list3.AddRange(base.Tree.RootLayout.method_8());
		if (dictionary.ContainsKey(Enum329.const_2))
		{
			smethod_4(dictionary[Enum329.const_2], list3, list);
		}
		if (dictionary.ContainsKey(Enum329.const_3))
		{
			smethod_4(dictionary[Enum329.const_3], list3, list);
		}
		if (list.Count < base.Children.Count)
		{
			foreach (Class117 child2 in base.Children)
			{
				if (!list.Contains(child2))
				{
					list.Add(child2);
				}
			}
		}
		class117_3 = method_8(smethod_10).ToArray();
		base.Children.Clear();
		foreach (Class117 item in list)
		{
			base.Children.Add(item);
		}
		class117_2 = method_8(smethod_9).ToArray();
		class117_1 = method_8(smethod_8).ToArray();
		class117_0 = method_8(smethod_7).ToArray();
	}

	private static void smethod_3(IEnumerable<Class117> group, List<Class117> output)
	{
		List<Class117> list = new List<Class117>();
		List<Class117> list2 = new List<Class117>();
		foreach (Class117 item in group)
		{
			if (item.ReferencedForRel == Enum329.const_1)
			{
				list.Add(item);
			}
			else
			{
				list2.Add(item);
			}
		}
		list.Sort();
		list2.Sort();
		output.AddRange(list);
		output.AddRange(list2);
	}

	private static void smethod_4(IEnumerable<Class117> group, IEnumerable<Class135> allLayoutNodes, List<Class117> output)
	{
		Dictionary<string, List<Class117>> dictionary = smethod_6(group);
		if (dictionary.ContainsKey(string.Empty))
		{
			smethod_3(dictionary[string.Empty], output);
			dictionary.Remove(string.Empty);
		}
		foreach (Class135 allLayoutNode in allLayoutNodes)
		{
			if (dictionary.ContainsKey(allLayoutNode.Name))
			{
				smethod_3(dictionary[allLayoutNode.Name], output);
				dictionary.Remove(allLayoutNode.Name);
			}
		}
	}

	private static Dictionary<Enum329, List<Class117>> smethod_5(IEnumerable<Class117> list)
	{
		Dictionary<Enum329, List<Class117>> dictionary = new Dictionary<Enum329, List<Class117>>();
		foreach (Class117 item in list)
		{
			List<Class117> list2;
			if (!dictionary.ContainsKey(item.ForRel))
			{
				list2 = new List<Class117>();
				dictionary.Add(item.ForRel, list2);
			}
			else
			{
				list2 = dictionary[item.ForRel];
			}
			list2.Add(item);
		}
		return dictionary;
	}

	private static Dictionary<string, List<Class117>> smethod_6(IEnumerable<Class117> list)
	{
		Dictionary<string, List<Class117>> dictionary = new Dictionary<string, List<Class117>>();
		foreach (Class117 item in list)
		{
			List<Class117> list2;
			if (!dictionary.ContainsKey(item.ForName))
			{
				list2 = new List<Class117>();
				dictionary.Add(item.ForName, list2);
			}
			else
			{
				list2 = dictionary[item.ForName];
			}
			list2.Add(item);
		}
		return dictionary;
	}

	private static bool smethod_7(Class117 item)
	{
		if (item.ForRel == Enum329.const_1 && item.ReferencedForRel == Enum329.const_1)
		{
			return item.ReferencedType != Enum305.const_22;
		}
		return false;
	}

	private static bool smethod_8(Class117 item)
	{
		if (item.ForRel == Enum329.const_1 && item.ReferencedForRel != Enum329.const_1)
		{
			return item.ReferencedType != Enum305.const_22;
		}
		return false;
	}

	private static bool smethod_9(Class117 item)
	{
		if (item.ForRel != Enum329.const_1)
		{
			return item.ReferencedType != Enum305.const_22;
		}
		return false;
	}

	private static bool smethod_10(Class117 item)
	{
		if (item.Operator == Enum326.const_2)
		{
			return item.ReferencedType == Enum305.const_22;
		}
		return false;
	}
}
