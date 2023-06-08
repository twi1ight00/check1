using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A utility class that takes a set of <see cref="T:System.Reflection.MethodInfo" />s
/// and pulls out shadowed methods, only returning the ones that
/// are actually accessible to be overridden.
/// </summary>
internal class MethodSorter : IEnumerable<MethodInfo>, IEnumerable
{
	private readonly Dictionary<string, List<MethodInfo>> methodsByName = new Dictionary<string, List<MethodInfo>>();

	private readonly Type declaringType;

	public MethodSorter(Type declaringType, IEnumerable<MethodInfo> methodsToSort)
	{
		this.declaringType = declaringType;
		GroupMethodsByName(methodsToSort);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<MethodInfo> GetEnumerator()
	{
		foreach (KeyValuePair<string, List<MethodInfo>> methodList in methodsByName)
		{
			KeyValuePair<string, List<MethodInfo>> keyValuePair = methodList;
			if (keyValuePair.Value.Count == 1)
			{
				KeyValuePair<string, List<MethodInfo>> keyValuePair2 = methodList;
				yield return keyValuePair2.Value[0];
				continue;
			}
			MethodSorter methodSorter = this;
			KeyValuePair<string, List<MethodInfo>> keyValuePair3 = methodList;
			foreach (MethodInfo item in methodSorter.RemoveHiddenOverloads(keyValuePair3.Value))
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// Take the list of methods and put them together into lists index by method name.
	/// </summary>
	/// <param name="methodsToSort">Methods to sort through.</param>
	private void GroupMethodsByName(IEnumerable<MethodInfo> methodsToSort)
	{
		foreach (MethodInfo item in methodsToSort)
		{
			if (!methodsByName.ContainsKey(item.Name))
			{
				methodsByName[item.Name] = new List<MethodInfo>();
			}
			methodsByName[item.Name].Add(item);
		}
	}

	/// <summary>
	/// Given a list of overloads for a method, return only those methods
	/// that are actually visible. In other words, if there's a "new SomeType" method
	/// somewhere, return only the new one, not the one from the base class
	/// that's now hidden.
	/// </summary>
	/// <param name="methods">Sequence of methods to process.</param>
	/// <returns>Sequence of returned methods.</returns>
	private IEnumerable<MethodInfo> RemoveHiddenOverloads(IEnumerable<MethodInfo> methods)
	{
		List<MethodInfo> methodsByParameters = new List<MethodInfo>(methods);
		methodsByParameters.Sort(CompareMethodInfosByParameterLists);
		List<List<MethodInfo>> overloadGroups = new List<List<MethodInfo>>(GroupOverloadedMethods(methodsByParameters));
		foreach (List<MethodInfo> overload in overloadGroups)
		{
			yield return SelectMostDerivedOverload(overload);
		}
	}

	/// <summary>
	/// Take a semi-randomly ordered set of methods on a type and
	/// sort them into groups by name and by parameter list.
	/// </summary>
	/// <param name="sortedMethods">The list of methods.</param>
	/// <returns>Sequence of lists of methods, grouped by method name.</returns>
	private static IEnumerable<List<MethodInfo>> GroupOverloadedMethods(IList<MethodInfo> sortedMethods)
	{
		int index = 0;
		while (index < sortedMethods.Count)
		{
			int overloadStart = index;
			List<MethodInfo> overloads = new List<MethodInfo> { sortedMethods[overloadStart] };
			index++;
			while (index < sortedMethods.Count && CompareMethodInfosByParameterLists(sortedMethods[overloadStart], sortedMethods[index]) == 0)
			{
				overloads.Add(sortedMethods[index++]);
			}
			yield return overloads;
		}
	}

	/// <summary>
	/// Given a set of hiding overloads, return only the currently visible one.
	/// </summary>
	/// <param name="overloads">The set of overloads.</param>
	/// <returns>The most visible one.</returns>
	private MethodInfo SelectMostDerivedOverload(IList<MethodInfo> overloads)
	{
		if (overloads.Count == 1)
		{
			return overloads[0];
		}
		int num = int.MaxValue;
		MethodInfo result = null;
		foreach (MethodInfo overload in overloads)
		{
			int num2 = DeclarationDepth(overload);
			if (num2 < num)
			{
				num = num2;
				result = overload;
			}
		}
		return result;
	}

	/// <summary>
	/// Given a method, return a value indicating how deeply in the
	/// inheritance hierarchy the method is declared. Current type = 0,
	/// parent = 1, grandparent = 2, etc.
	/// </summary>
	/// <param name="method">Method to check.</param>
	/// <returns>Declaration depth</returns>
	private int DeclarationDepth(MethodInfo method)
	{
		int num = 0;
		Type baseType = declaringType;
		while (baseType != null && method.DeclaringType != declaringType)
		{
			num++;
			baseType = baseType.BaseType;
		}
		return num;
	}

	/// <summary>
	/// A <see cref="T:System.Comparison`1" /> implementation that can compare two <see cref="T:System.Reflection.MethodInfo" />
	/// based on their parameter lists.
	/// </summary>
	/// <param name="left">First <see cref="T:System.Reflection.MethodInfo" /> to compare.</param>
	/// <param name="right">Second <see cref="T:System.Reflection.MethodInfo" /> to compare.</param>
	/// <returns>&lt; 0, 0, or &gt; 0 based on which one is "greater" than the other.</returns>
	private static int CompareMethodInfosByParameterLists(MethodInfo left, MethodInfo right)
	{
		return CompareParameterLists(left.GetParameters(), right.GetParameters());
	}

	/// <summary>
	/// Compare two parameter lists.
	/// </summary>
	/// <param name="left">First parameter list.</param>
	/// <param name="right">Second parameter list.</param>
	/// <returns>&lt; 0, 0, or &gt; 0.</returns>
	private static int CompareParameterLists(ParameterInfo[] left, ParameterInfo[] right)
	{
		if (left.Length != right.Length)
		{
			return left.Length - right.Length;
		}
		for (int i = 0; i < left.Length; i++)
		{
			int num = CompareParameterInfo(left[i], right[i]);
			if (num != 0)
			{
				return num;
			}
		}
		return 0;
	}

	/// <summary>
	/// Compare two <see cref="T:System.Reflection.ParameterInfo" /> objects by type.
	/// </summary>
	/// <param name="left">First <see cref="T:System.Reflection.ParameterInfo" /></param>
	/// <param name="right">First <see cref="T:System.Reflection.ParameterInfo" /></param>
	/// <returns>&lt; 0, 0, or &gt; 0</returns>
	private static int CompareParameterInfo(ParameterInfo left, ParameterInfo right)
	{
		if (left.ParameterType == right.ParameterType)
		{
			return 0;
		}
		return string.Compare(left.ParameterType.FullName, right.ParameterType.FullName, StringComparison.OrdinalIgnoreCase);
	}
}
